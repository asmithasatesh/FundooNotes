using Managers.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    //[Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesManager noteManager;
        /// <summary>
        /// Initialise INoteManager
        /// </summary>
        /// <param name="notes">Instance of</param>
        public NotesController(INotesManager notes)
        {
            this.noteManager = notes;
        }

        /// <summary>
        /// Create a note
        /// </summary>
        /// <param name="noteData"></param>
        /// <returns>Retrieve success message</returns>
        [HttpPost]
        [Route("api/CreateNote")]
        public IActionResult CreateNotes([FromBody] NotesModel noteData)
        {
            try
            {
                ////Send user data to manager
                  string result = this.noteManager.CreateNote(noteData);
                if (result == "Note has been created!")
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
        /// <param name="UserId"></param>
        /// <returns>Retrieve success message</returns>
        [HttpGet]
        [Route("api/GetUserNote")]
        public IActionResult GetUserNotes(int UserId)
        {
            try
            {
                ////Send user data to manager
                List<NotesModel> result = this.noteManager.GetUserNotes(UserId);
                if (result.Count!=0)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved user Notes!" , Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result.ToString() });
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
                if (result == "Note has been moved to Trash!")
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
        /// <param name="notesId"></param>
        /// <returns>Returns success message</returns>
        [HttpPut]
        [Route("api/RestoreTrash")]
        public IActionResult RestoreTrash(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.RestoreTrash(notesId);
                if (result == "Note has been restored!")
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
        /// <param name="notesId"></param>
        /// <returns>Returns success message</returns>
        [HttpDelete]
        [Route("api/DeleteNote")]
        public IActionResult DeleteNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.DeleteNote(notesId);
                if (result == "Note has been deleted!")
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
        /// <param name="UserId"></param>
        /// <returns>Returns success message</returns>
        [HttpDelete]
        [Route("api/EmptyTrash")]
        public IActionResult EmptyTrash(int UserId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.EmptyTrash(UserId);
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
        /// <param name="notesId"></param>
        /// <returns>Returns success message</returns>
        [HttpPut]
        [Route("api/ArchiveNote")]
        public IActionResult ArchiveNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.ArchiveNote(notesId);
                if (result == "Note has been Archieved!")
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
        /// <param name="notesId"></param>
        /// <returns>Returns success message</returns>
        [HttpPut]
        [Route("api/UnArchiveNote")]
        public IActionResult UnArchiveNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.UnArchiveNote(notesId);
                if (result == "Note has been unarchived!")
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
        /// <param name="notesId"></param>
        /// <returns>Returns success message</returns>
        [HttpPut]
        [Route("api/PinNote")]
        public IActionResult PinNote(int notesId)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.PinNote(notesId);
                if (result == "Note has been Pinned!")
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
        /// <param name="notesId"></param>
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
        /// <param name="noteData"></param>
        /// <returns>Success message</returns>
        [HttpPut]
        [Route("api/SetColor")]
        public IActionResult SetColor([FromBody] NotesModel noteData)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.SetColor(noteData);
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
        /// <param name="noteData"></param>
        /// <returns>Returns request success message</returns>
        [HttpPut]
        [Route("api/SetReminder")]
        public IActionResult SetReminder([FromBody] NotesModel noteData)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.SetReminder(noteData);
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
        /// <param name="noteData"></param>
        /// <returns>Return request success message</returns>
        [HttpPut]
        [Route("api/RemoveReminder")]
        public IActionResult RemoveReminder([FromBody] NotesModel noteData)
        {
            try
            {
                ////Send user data to manager
                string result = this.noteManager.RemoveReminder(noteData);
                if (result == "Reminder has been Removed!")
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
        /// <param name="noteData"></param>
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

        //Retrieve user notes
        /// <summary>
        /// Get asll Reminder notes
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>List of Notes</returns>
        [HttpGet]
        [Route("api/GetReminder")]
        public IActionResult GetReminder(int UserId)
        {
            try
            {
                ////Send user data to manager
                List<NotesModel> result = this.noteManager.GetReminder(UserId);
                if (result.Count != 0)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved Reminder Notes!", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result.ToString() });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        //Retrieve user notes

        /// <summary>
        /// Get all Trashed notes
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>List of notes</returns>
        [HttpGet]
        [Route("api/GetTrash")]
        public IActionResult GetTrash(int UserId)
        {
            try
            {
                ////Send user data to manager
                List<NotesModel> result = this.noteManager.GetTrash(UserId);
                if (result.Count != 0)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved Trash Notes!", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result.ToString() });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        //Retrieve user notes

        /// <summary>
        /// Get all Archived notes
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>List of notes</returns>
        [HttpGet]
        [Route("api/GetArchive")]
        public IActionResult GetArchive(int UserId)
        {
            try
            {
                ////Send user data to manager
                List<NotesModel> result = this.noteManager.GetArchive(UserId);
                if (result.Count != 0)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved Archived Notes!", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result.ToString() });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
