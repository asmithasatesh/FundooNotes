

namespace FundooNotes.Controllers
{
    using Managers.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }
        
        //Check for POST Request 
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                //Send user data to manager
                bool result = this.manager.Register(userData);
                if(result == true)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Resgisteration Successful" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = "Resgisteration Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }

        //Check for GET Request in Login Page
        [HttpGet]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginModel userData)
        {
            try
            {
                //Send user data to manager
                bool result = this.manager.Login(userData.Email,userData.Password);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Login Successful" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = "Login Unsuccessful, Email or Password is Incorrecr" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
        //Check for GET Request in ForgetPassword
        [HttpGet]
        [Route("api/forgetPassword")]
        public IActionResult ForgetPassword(string Email)
        {
            try
            {
                //Send user data to manager
                bool result = this.manager.ForgetPassword(Email);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { status = true, Message = "Please check your email" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { status = false, Message = "Email not Sent" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { status = false, Message = ex.Message });
            }
        }
    }
}
