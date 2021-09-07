// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using Managers.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <summary>
    /// Label controller is where all route for application is defines
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// The label manager
        /// </summary>
        private readonly ILabelManager labelManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController"/> class.
        /// </summary>
        /// <param name="labelManager">The label manager.</param>
        public LabelController(ILabelManager labelManager)
        {
            this.labelManager = labelManager;
        }

        /// <summary>
        /// Adds the label using edit.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns exception</returns>
        [HttpPost]
        [Route("api/AddLabelUsingEdit")]
        public IActionResult AddLabelUsingEdit([FromBody] LabelModel labelModel)
        {
            try
            {
                ////Send user data to manager
                string result = this.labelManager.AddLabelUsingEdit(labelModel);
                if (result == "Label created")
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
        /// Removes the label using edit.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns message</returns>
        [HttpDelete]
        [Route("api/RemoveLabelUsingEdit")]
        public IActionResult RemoveLabelUsingEdit(string labelName, int userId)
        {
            try
            {
                ////Send user data to manager
                string result = this.labelManager.RemoveLabelUsingEdit(labelName, userId);
                if (result == "Label deleted")
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
        /// Edits the label using edit.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>Returns message</returns>
        [HttpPut]
        [Route("api/EditLabelUsingEdit")]
        public IActionResult EditLabelUsingEdit(int userId, string labelName, string newLabelName)
        {
            try
            {
                ////Send user data to manager
                string result = this.labelManager.EditLabelUsingEdit(userId, labelName, newLabelName);
                if (result != "Couldn't update Label")
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
        /// Gets the label using user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns message</returns>
        [HttpGet]
        [Route("api/GetLabelUsingUserId")]
        public IActionResult GetLabelUsingUserId(int userId)
        {
            try
            {
                ////Send user data to manager
                List<LabelModel> result = this.labelManager.GetLabelUsingUserId(userId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the label by note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>Returns message</returns>
        [HttpGet]
        [Route("api/GetLabelByNoteId")]
        public IActionResult GetLabelByNoteId(int noteId)
        {
            try
            {
                ////Send user data to manager
                List<LabelModel> result = this.labelManager.GetLabelByNoteId(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Removes the label.
        /// </summary>
        /// <param name="lableId">The label identifier.</param>
        /// <returns>Returns message</returns>
        [HttpDelete]
        [Route("api/RemoveLabel")]
        public IActionResult RemoveLabel(int lableId)
        {
            try
            {
                ////Send user data to manager
                string result = this.labelManager.RemoveLabel(lableId);
                if (result != "Label is removed")
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
        /// Creates the label using note.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns message</returns>
        [HttpPut]
        [Route("api/CreateLabelUsingNote")]
        public IActionResult CreateLabelUsingNote([FromBody] LabelModel labelModel)
        {
            try
            {
                ////Send user data to manager
                string result = this.labelManager.CreateLabelUsingNote(labelModel);
                if (result != "Label added")
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
        /// Displays the label note.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>Returns message</returns>
        [HttpGet]
        [Route("api/ DisplayLabelNote")]
        public IActionResult DisplayLabelNote(int userId, string labelName)
        {
            try
            {
                ////Send user data to manager
                List<NotesModel> result = this.labelManager.DisplayLabelNote(userId, labelName);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "Notes Retrieved", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<NotesModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
