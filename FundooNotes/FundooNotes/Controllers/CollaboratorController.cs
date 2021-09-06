// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using Managers.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <summary>
    /// Collaborator controller is where all route for application is defines
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// The collaborator manager
        /// </summary>
        private readonly ICollaboratorManager collaboratorManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorController"/> class.
        /// </summary>
        /// <param name="collaborator">The collaborator.</param>
        public CollaboratorController(ICollaboratorManager collaborator)
        {
            this.collaboratorManager = collaborator;
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaboratorModel">The collaborator model.</param>
        /// <returns>Success data and message</returns>
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
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = collaboratorModel.CollaboratorEmail });
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
        /// Removes the collaborator.
        /// </summary>
        /// <param name="collabId">The collaborator identifier.</param>
        /// <returns>Returns success message</returns>
        [HttpDelete]
        [Route("api/RemoveCollaborator")]
        public IActionResult RemoveCollaborator(int collabId)
        {
            try
            {
                ////Send user data to manager
                string result = this.collaboratorManager.RemoveCollaborator(collabId);
                if (result == "Collaborator removed")
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
        /// Gets the collaborator.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns List of Collaborators</returns>
        [HttpGet]
        [Route("api/GetCollaborator")]
        public IActionResult GetCollaborator(int notesId)
        {
            try
            {
                ////Send user data to manager
                List<CollaboratorModel> result = this.collaboratorManager.GetCollaborator(notesId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<CollaboratorModel>>() { Status = true, Message = "Retrieved Collaborators", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Couln't retrieve Collaborator" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
