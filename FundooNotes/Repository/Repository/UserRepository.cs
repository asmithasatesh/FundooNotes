// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Repository
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using Experimental.System.Messaging;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;
    using StackExchange.Redis;

    /// <summary>
    /// This class is used to store and manage user data
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// User context is used to call constructor for database Context
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// The configuration variable
        /// </summary>
        public readonly IConfiguration Configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        /// <param name="configuration">The configuration.</param>
        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.UserContext = userContext;
            this.Configuration = configuration;
        }

        /// <summary>
        /// Register method to check whether data is present or not
        /// </summary>
        /// <param name="userData">User Data</param>
        /// <returns>Return true when changes are saved</returns>
        public string Register(RegisterModel userData)
        {
            try
            {
                var checkUser = this.UserContext.Users.Where(user => user.Email == userData.Email).FirstOrDefault();
                if (checkUser == null)
                {
                    if (userData != null)
                    {
                        //// Encrypt password
                        userData.Password = this.EncryptPassword(userData.Password);

                        //// Add data to Dbset
                        this.UserContext.Users.Add(userData);
                        this.UserContext.SaveChanges();
                        return "Registeration Successful";
                    }

                    return "Registeration not Successful";
                }
                else
                {
                    return "Email already exist! please try again!";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Check whether login and Password matches the Database
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <param name="password">Password for user email</param>
        /// <returns>Return true if email id and Login matches</returns>
        public RegisterModel Login(string email, string password)
        {
            try
            {
                string encodedPassword = this.EncryptPassword(password);
                var login = this.UserContext.Users
                    .Where(x => (x.Email == email && x.Password == encodedPassword)).FirstOrDefault();
                ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                IDatabase database = connection.GetDatabase();
                database.StringSet(key: "First Name", login.FirstName);
                database.StringSet(key: "Last Name", login.LastName);
                database.StringSet(key: "User Id", login.UserId);
                return login;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns a token string</returns>
        public string GenerateToken(string email)
        {
            var key = Encoding.UTF8.GetBytes(this.Configuration["Secret"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }

        /// <summary>
        /// Encrypt password to Base 64 string
        /// </summary>
        /// <param name="plainText">Password in Alphabets</param>
        /// <returns>Encrypted password</returns>
        public string EncryptPassword(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Reset password for given email
        /// </summary>
        /// <param name="email">The Email</param>
        /// <param name="password">The Password</param>
        /// <returns>Returns true if successful</returns>
        public bool ResetPassword(string email, string password)
        {
            try
            {
                var user = this.UserContext.Users.Where(x => x.Email == email).FirstOrDefault();
                user.Password = this.EncryptPassword(password);
                this.UserContext.Users.Update(user);
                this.UserContext.SaveChanges();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forget password: Send the email to Send MSMQ
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <returns>Return true if email is sent successfully</returns>
        public bool ForgetPassword(string email)
        {
            try
            {
                if (this.SendMSMQ(email) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This will create a MSMQ queue and store the message details
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <returns>Return value received from MSMQ Method</returns>
        public bool SendMSMQ(string email)
        {
            MessageQueue msgqueue;
            if (MessageQueue.Exists(@".\Private$\MyFundooQueue"))
            {
                msgqueue = new MessageQueue(@".\Private$\MyFundooQueue");
            }
            else
            {
                msgqueue = MessageQueue.Create(@".\Private$\MyFundooQueue");
            }

            Message message = new Message();
            var formatter = new BinaryMessageFormatter();
            message.Formatter = formatter;
            message.Body = "This is body content stored in MSMQ";
            msgqueue.Label = "This is Queue Label";
            msgqueue.Send(message);
            return this.RecieveMSMQ(email);
        }

        /// <summary>
        /// Receive message details from user
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <returns>Return data based on SendToMail</returns>
        public bool RecieveMSMQ(string email)
        {
            ////For reading msmq message
            var receivequeue = new MessageQueue(@".\Private$\MyFundooQueue");
            var receivemsg = receivequeue.Receive();
            receivemsg.Formatter = new BinaryMessageFormatter();

            ////Send To-Email address and emailBody content as parameter
            if (this.SendToMail(email, receivemsg))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method send mail to given email using protocols
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <param name="emailBody">Email Body</param>
        /// <returns>Returns true is done successfully</returns>
        private bool SendToMail(string email, Message emailBody)
        {
            MailMessage mailMessage = new MailMessage();

            ////Create smpt client
            SmtpClient smtp = new SmtpClient();
            mailMessage.From = new MailAddress("generalemailapplication@gmail.com");

            ////Set To-Address
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Link to reset your password for Fundoo";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = emailBody.Body.ToString();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("generalemailapplication@gmail.com", "Abcd@1234");
            smtp.Send(mailMessage);
            return true;
        }
    }
}