using Managers.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
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
                    return this.Ok(new { Status = true, Message = "Retrieved user Notes!" ,Data = result });
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
        [HttpPost]
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
        [HttpPost]
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

        [HttpPost]
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
    }
}
