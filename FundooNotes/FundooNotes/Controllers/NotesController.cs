// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <summary>
    /// Notes controller where all route for application is defines
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    //[Authorize]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// variable of Interface note manager
        /// </summary>
        private readonly INotesManager noteManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="notes">The notes.</param>
        public NotesController(INotesManager notes)
        {
            this.noteManager = notes;
        }

        /// <summary>
        /// Create a note
        /// </summary>
        /// <param name="noteData">Note data variable</param>
        /// <returns>Retrieve success message</returns>
        [HttpPost]
        [Route("api/CreateNote")]
        public IActionResult CreateNotes([FromBody] NotesModel noteData)
        {
            try
            {
                ////Send user data to manager
                  string result = this.noteManager.CreateNote(noteData);
                if (result == "Note created!")
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
        /// Retrieve user notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Retrieve success message</returns>
        [HttpGet]
        [Route("api/GetUserNote")]
        public IActionResult GetUserNotes(int userId)
        {
            try
            {
                ////Send user data to manager
                List<NotesModel> result = this.noteManager.GetUserNotes(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved user Notes!", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "User doesn't have any notes!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }


        /// <summary>
        /// Trashes the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Return success message</returns>
        [HttpPut]
        [Route("api/TrashNote")]
        public IActionResult TrashNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.TrashNote(notesId);
                if (result != "Note doesn't Exist!")
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
        /// Restore trashed notes
        /// </summary>
        /// <param name="notesId">Note data variable</param>
        /// <returns>Returns success message</returns>
        [HttpPut]
        [Route("api/RestoreTrash")]
        public IActionResult RestoreTrash(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.RestoreTrash(notesId);
                if (result == "Note restored")
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
        /// Delete a note
        /// </summary>
        /// <param name="notesId">Note data variable</param>
        /// <returns>Returns success message</returns>
        [HttpDelete]
        [Route("api/DeleteNote")]
        public IActionResult DeleteNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.DeleteNote(notesId);
                if (result == "Note deleted!")
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
        /// Empty trashed notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Returns success message</returns>
        [HttpDelete]
        [Route("api/EmptyTrash")]
        public IActionResult EmptyTrash(int userId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.EmptyTrash(userId);
                if (result == "Trash has been cleared!")
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
        /// Archive notes
        /// </summary>
        /// <param name="notesId">Notes Id</param>
        /// <returns>Returns success message</returns>
        [HttpPut]
        [Route("api/ArchiveNote")]
        public IActionResult ArchiveNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.ArchiveNote(notesId);
                if (result != "Note doesn't Exist!")
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
        /// Un archive note
        /// </summary>
        /// <param name="notesId">Note data variable</param>
        /// <returns>Returns success message</returns>
        [HttpPut]
        [Route("api/UnArchiveNote")]
        public IActionResult UnArchiveNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.UnArchiveNote(notesId);
                if (result == "Note unarchived")
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
        /// Pin Note
        /// </summary>
        /// <param name="notesId">Notes Id</param>
        /// <returns>Returns success message</returns>
        [HttpPut]
        [Route("api/PinNote")]
        public IActionResult PinNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.PinNote(notesId);
                if (result != "Note doesn't Exist!")
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
        /// Un pin note
        /// </summary>
        /// <param name="notesId">Notes Id</param>
        /// <returns>Returns success message</returns>
        [HttpPut]
        [Route("api/UnPinNote")]
        public IActionResult UnPinNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.UnPinNote(notesId);
                if (result == "Note has been removed from Pin!")
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
        /// Set color for note
        /// </summary>
        /// <param name="noteData">Note data variable</param>
        /// <returns>Success message</returns>
        [HttpPut]
        [Route("api/SetColor")]
        public IActionResult SetColor(int notesId, string color)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.SetColor(notesId,color);
                if (result == "Note color has been Set!")
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
        /// Set reminder
        /// </summary>
        /// <param name="noteData">Note data variable</param>
        /// <returns>Returns request success message</returns>
        [HttpPut]
        [Route("api/SetReminder")]
        public IActionResult SetReminder(int notesId, string reminder)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.SetReminder(notesId , reminder);
                if (result == "Reminder has been Set!")
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
        /// Remove reminder
        /// </summary>
        /// <param name="noteData">Note data variable</param>
        /// <returns>Return request success message</returns>
        [HttpPut]
        [Route("api/RemoveReminder")]
        public IActionResult RemoveReminder(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.RemoveReminder(notesId);
                if (result == "Reminder deleted")
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
        /// Update note title and description
        /// </summary>
        /// <param name="noteData">Note data variable</param>
        /// <returns>Return success message</returns>
        [HttpPost]
        [Route("api/ UpdateNote")]
        public IActionResult UpdateNote([FromBody] NotesModel noteData)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.UpdateNote(noteData);
                if (result == "Updated Note!")
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
        /// Get all Reminder notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of Notes</returns>
        [HttpGet]
        [Route("api/GetReminder")]
        public IActionResult GetReminder(int userId)
        {
            try
            {
                ////Send user data to manager
                List<NotesModel> result = this.noteManager.GetReminder(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved Reminder Notes!", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No reminder has been set!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all Trashed notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of notes</returns>
        [HttpGet]
        [Route("api/GetTrash")]
        public IActionResult GetTrash(int userId)
        {
            try
            {
                ////Send user data to manager
                List<NotesModel> result = this.noteManager.GetTrash(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved Trash Notes!", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Trash does not have any notes!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all Archived notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of notes</returns>
        [HttpGet]
        [Route("api/GetArchive")]
        public IActionResult GetArchive(int userId)
        {
            try
            {
                ////Send user data to manager
                List<NotesModel> result = this.noteManager.GetArchive(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved Archived Notes!", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Archive doesn't contain any notes!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
