

namespace Repository.Repository
{
    using Experimental.System.Messaging;
    using global::Repository.Context;
    using global::Repository.Interface;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    public class UserRepository:IUserRepository
    {
        public readonly UserContext userContext;
        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public bool Register(RegisterModel userData)
        {
            try
            {
                //Check whether data is present in userdata 
                if(userData !=null)
                {
                    //Encrypt password
                    userData.Password = EncryptPassword(userData.Password);
                    //Add data to Dbset
                    this.userContext.Users.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //check whether login and Password matches the Database
        public bool Login(string email, String password)
        {
            try
            {
                string encodedPassword = EncryptPassword(password);
                var login = this.userContext.Users
                    .Where(x => (x.Email == email && x.Password == encodedPassword)).FirstOrDefault();
                if(login!=null)
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

        //Encrypt password to Base 64 string
        public static string EncryptPassword(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //Forget password: Send the email to Send MSMQ
        public bool ForgetPassword(string Email)
        {
            try
            {
                if(SendMSMQ(Email) == true)
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

        //This will create a MSMQ queue and store the message details
        public bool SendMSMQ(string Email)
        {
            MessageQueue msgqueue;
            if(MessageQueue.Exists(@".\Private$\MyFundooQueue"))
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
            return RecieveMSMQ(Email);
        }
        public bool RecieveMSMQ(string Email)
        {
            //for reading msmq
            var receivequeue = new MessageQueue(@".\Private$\MyFundooQueue");
            var receivemsg = receivequeue.Receive();
            receivemsg.Formatter = new BinaryMessageFormatter();
            string linktosend = receivemsg.Body.ToString();
            return true;
        }
    }
}
