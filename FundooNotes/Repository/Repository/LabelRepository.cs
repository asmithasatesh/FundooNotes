// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// Execute business logic for Labels
    /// </summary>
    /// <seealso cref="Repository.Interface.ILabelRepository" />
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRepository"/> class.
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
                var existLabel = this.UserContext.Labels.Where(label => label.LabelName == labelModel.LabelName && labelModel.UserId == label.UserId && label.NotesId == null).SingleOrDefault();
                if (existLabel == null)
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
                if (labelList.Count != 0)
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
                    if (checknewLabel.Count != 0)
                    {
                        return "Merge the '" + labelName + "' label with the '" + newLabelName + "' label? All notes labeled with '" + labelName + "' will be labeled with '" + newLabelName + "', and the '" + labelName + "' label will be deleted.";
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
                    LabelModel tempModel = (LabelModel)labelModel.Clone();
                    labelModel.NotesId = null;
                    this.AddLabelUsingEdit(labelModel);
                    this.UserContext.Labels.Add(tempModel);
                    this.UserContext.SaveChanges();
                    return "Label added";
                }

                return "Label already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the label.
        /// </summary>
        /// <param name="lableId">The label identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns Exception</exception>
        public string RemoveLabel(int lableId)
        {
            try
            {
                var noteLabel = this.UserContext.Labels.Where(x => x.LabelId == lableId).SingleOrDefault();
                if (noteLabel != null)
                {
                    this.UserContext.Labels.Remove(noteLabel);
                    this.UserContext.SaveChanges();
                    return "Label is removed";
                }

                return "Remove label failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the label using user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>List of Label</returns>
        /// <exception cref="System.Exception">Returns exception</exception>
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

        /// <summary>
        /// Get label by note id
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns>Returns list of Label</returns>
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

        /// <summary>
        /// Display note
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="labelName">Label Name</param>
        /// <returns>Returns List of Notes</returns>
        public List<NotesModel> DisplayLabelNote(int userId, string labelName)
        {
            try
            {
                var label = (from o in this.UserContext.Notes
                join n in this.UserContext.Labels
                on o.UserId equals n.UserId
                where n.LabelName == labelName && n.UserId == userId && n.NotesId != null
                select o).ToList();

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
