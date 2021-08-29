using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Managers.Interface;

namespace FundooNotes.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
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



    }
}
