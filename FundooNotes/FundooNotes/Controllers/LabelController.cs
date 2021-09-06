// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using Managers.Interface;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    public class LabelController : ControllerBase
    {
        private readonly ILabelManager labelManager;
        public LabelController(ILabelManager labelManager)
        {
            this.labelManager = labelManager;
        }

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
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result});
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
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result});
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
        [HttpPut]
        [Route("api/CreateLabelUsingNote")]
        public IActionResult CreateLabelUsingNote([FromBody] LabelModel labelModel)
        {
            try
            {
                ////Send user data to manager
                string result = this.labelManager.CreateLabelUsingNote(labelModel);
                if (result != "Note added")
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

        [HttpGet]
        [Route("api/ DisplayLabelNote")]
        public IActionResult DisplayLabelNote(int userId, string labelName)
        {
            try
            {
                ////Send user data to manager
                List<LabelModel> result = this.labelManager.DisplayLabelNote( userId, labelName);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Notes Retrieved", Data = result});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result});
                }

            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

    }
}
