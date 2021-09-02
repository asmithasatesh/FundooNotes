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
        public NotesController(INotesManager notes)
        {
            this.noteManager = notes;
        }
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

        //Retrieve user notes
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
