using Managers.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorManager collaboratorManager;
        public CollaboratorController(ICollaboratorManager collaborator)
        {
            this.collaboratorManager = collaborator;
        }

        [HttpPost]
        [Route("api/AddCollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel collaboratorModel)
        {
            try
            {
                ////Send user data to manager
                string result = this.collaboratorManager.AddCollaborator(collaboratorModel);
                if (result == "Collaborator added")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result , Data= collaboratorModel.CollaboratorEmail});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }

            }
            catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
