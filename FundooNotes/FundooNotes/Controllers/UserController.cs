// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using Managers.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using StackExchange.Redis;

    /// <summary>
    /// Based on Route value will be changed
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class UserController : ControllerBase
    {
        /// <summary>
        /// User manager Object
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// The logger variable for user controller
        /// </summary>
        private readonly ILogger<UserController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="logger">The logger.</param>
        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        /// <summary>
        /// Check for POST Request in Register
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>Returns Response</returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                ////Send user data to manager
                string result = this.manager.Register(userData);
                if (result == "Registeration Successful")
                {
                    this.logger.LogInformation(userData.FirstName + " " + userData.LastName + " has been added successfully!!");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    this.logger.LogInformation("User registeration Unsuccessful for user " + userData.FirstName + " " + userData.LastName);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation("Exception while adding user : " + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Check for GET Request in Login Page
        /// </summary>
        /// <param name="userData">User data</param>
        /// <returns>Returns Response</returns>
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginModel userData)
        {
            try
            {
                ////Send user data to manager
                RegisterModel result = this.manager.Login(userData.Email, userData.Password);
                var userToken = this.manager.GenerateToken(userData.Email);
                if (result != null)
                {
                    ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connection.GetDatabase();
                    string firstName = database.StringGet("First Name");
                    string lastName = database.StringGet("Last Name");
                    int userId = Convert.ToInt32(database.StringGet("User Id"));
                    this.logger.LogInformation(result.FirstName + " " + result.LastName + " has Logged in!!");
                    return this.Ok(new { Status = true, Message = "Login Successful!", firstName, lastName, userId, result.Email, userToken });
                }
                else
                {
                    this.logger.LogInformation("User entered incorrect email or password");
                    return this.BadRequest(new { Status = false, Message = "Incorrect Email or Password", Data = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation("Exception while login : " + ex.Message);
                return this.NotFound(new { Status = false, ex.Message });
            }
        }

        /// <summary>
        /// Check for GET Request in ForgetPassword
        /// </summary>
        /// <param name="email">Email Id</param>
        /// <returns>Returns Response</returns>
        [HttpPost]
        [Route("api/forgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                ////Send user data to manager
                bool result = this.manager.ForgetPassword(email);
                if (result == true)
                {
                    HttpContext.Session.SetString("SessionEmail", email);
                    this.logger.LogInformation("Forget password mail sent to user at Gmail : " + email);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Please check your email" });
                }
                else
                {
                    this.logger.LogInformation("Couldn't send email to : " + email);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Email not Sent" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation("Exception while sending mail for forget password : " + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>Returns Response</returns>
        [HttpPut]
        [Route("api/resetPassword")]
        public IActionResult ResetPassword([FromBody] ResetModel userData)
        {
            try
            {
                string email = HttpContext.Session.GetString("SessionEmail");
                if (email == null)
                {
                    return this.BadRequest(new { Status = false, Message = "Time expired! Try again.", email });
                }

                bool result = this.manager.ResetPassword(userData.Email, userData.Password);
                if (result == true)
                {
                    this.logger.LogInformation("Password reset successful for email: " + email);
                    return this.Ok(new { Status = true, Message = "Password Reseted Successfully", email });
                }
                else
                {
                    this.logger.LogInformation("Couldn't reset password for email: " + email);
                    return this.BadRequest(new { Status = false, Message = "Password Reset Failed!", email });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation("Exception while reset password : " + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
