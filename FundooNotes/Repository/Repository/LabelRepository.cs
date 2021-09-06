using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public LabelRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        /// <summary>
        /// Adds the label using edit.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exceptions</exception>
        public string AddLabelUsingEdit(LabelModel labelModel)
        {
            try
            {
                var existLabel = this.UserContext.Labels.Where(label => label.LabelName == labelModel.LabelName && labelModel.UserId == label.UserId).SingleOrDefault();
                if(existLabel == null)
                {
                    this.UserContext.Labels.Add(labelModel);
                    this.UserContext.SaveChanges();
                    return "Label created";
                }

                return "Label already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the label using edit.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exceptions</exception>
        public string RemoveLabelUsingEdit(string labelName, int userId)
        {
            try
            {
                var labelList = this.UserContext.Labels.Where(label => label.LabelName == labelName && label.UserId == userId).ToList();
                if( labelList.Count != 0)
                {
                    this.UserContext.Labels.RemoveRange(labelList);
                    this.UserContext.SaveChanges();
                    return "Label deleted";
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edits the label using edit.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exceptions</exception>
        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName)
        {
            try
            {
                var labelList = this.UserContext.Labels.Where(label => label.LabelName == labelName && label.UserId == userId).ToList();
                var checknewLabel = this.UserContext.Labels.Where(label => label.LabelName == newLabelName && label.UserId == userId).ToList();
                if (labelList.Count != 0)
                {
                    foreach (var label in labelList)
                    {
                        label.LabelName = newLabelName;
                    }

                    this.UserContext.UpdateRange(labelList);
                    this.UserContext.SaveChanges();
                    if(checknewLabel.Count != 0)
                    {
                        return "Merge the '" + labelName+ "' label with the '" + newLabelName+ "' label? All notes labeled with '" + labelName+ "' will be labeled with '" + newLabelName+ "', and the '" + labelName+ "' label will be deleted.";
                    }

                    return "Label Updated";
                }

                return "Couldn't update Label";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Adds the label using edit.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exceptions</exception>
        public string CreateLabelUsingNote(LabelModel labelModel)
        {
            try
            {
                var existLabel = this.UserContext.Labels.Where(label => label.LabelName == labelModel.LabelName && labelModel.NotesId == label.NotesId).SingleOrDefault();
                if (existLabel == null)
                {
                    var noteId = labelModel.NotesId;
                    labelModel.NotesId = null;
                    AddLabelUsingEdit(labelModel);
                    labelModel.LabelId = 0;
                    labelModel.NotesId = noteId;
                    this.UserContext.Labels.Add(labelModel);
                    this.UserContext.SaveChanges();
                    return "Note added";
                }
                return "Label already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveLabel(int lableId)
        {
            try
            {
                var noteLabel = this.UserContext.Labels.Where(x => x.LabelId == lableId).SingleOrDefault();
                if (noteLabel != null)
                {
                    this.UserContext.Labels.Remove(noteLabel);
                    this.UserContext.SaveChanges();
                    return ("Label is removed");
                }
                return "Remove label failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<LabelModel> GetLabelUsingUserId(int userId)
        {
            try
            {
                var listLabel = this.UserContext.Labels.Where(label => userId == label.UserId && label.NotesId == null).ToList();
                if (listLabel.Count != 0)
                {
                    return listLabel;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<LabelModel> GetLabelByNoteId(int noteId)
        {
            try
            {
                var label = this.UserContext.Labels.Where(x => x.NotesId == noteId).ToList();
                if (label.Count != 0)
                {
                    return label;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
