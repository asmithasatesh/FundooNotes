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
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;

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
                this.logger.LogInformation("User Controller register method called!!!"); 
                string result = this.manager.Register(userData);
                if (result == "Registeration Successful")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
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
                    return this.Ok(new { Status = true, Message = "Login Successful!", result.FirstName, result.LastName, result.Email, userToken });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Incorrect Email or Password", Data = result });
                }
            }
            catch (Exception ex)
            {
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
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Please check your email" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Email not Sent" });
                }
            }
            catch (Exception ex)
            {
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
                bool result = this.manager.ResetPassword(userData.Email, userData.Password);

                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Password Reseted Successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Password Reset Failed!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
