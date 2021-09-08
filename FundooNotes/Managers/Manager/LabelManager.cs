// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Managers.Manager
{
    using System;
    using System.Collections.Generic;
    using Managers.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// Calls repository methods
    /// </summary>
    /// <seealso cref="Managers.Interface.ILabelManager" />
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// The label repository
        /// </summary>
        private readonly ILabelRepository labelRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelManager"/> class.
        /// </summary>
        /// <param name="labelRepository">The label repository.</param>
        public LabelManager(ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }

        /// <summary>
        /// Adds the label using edit.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string AddLabelUsingEdit(LabelModel labelModel)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.AddLabelUsingEdit(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the label using edit.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string RemoveLabelUsingEdit(string labelName, int userId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.RemoveLabelUsingEdit(labelName, userId);
            }
            catch (Exception ex)
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
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.EditLabelUsingEdit(userId, labelName, newLabelName);
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
        /// <returns>
        /// Returns List
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public List<LabelModel> GetLabelUsingUserId(int userId) 
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.GetLabelUsingUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the label by note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// Returns List
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public List<LabelModel> GetLabelByNoteId(int noteId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.GetLabelByNoteId(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the label.
        /// </summary>
        /// <param name="lableId">The label identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string RemoveLabel(int lableId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.RemoveLabel(lableId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Creates the label using note.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string CreateLabelUsingNote(LabelModel labelModel)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.CreateLabelUsingNote(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Displays the label note.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>
        /// Returns List
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public List<NotesModel> DisplayLabelNote(int userId, string labelName)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.DisplayLabelNote(userId, labelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
