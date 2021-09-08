// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Interface containing method declaration
    /// </summary>
    public interface ILabelRepository
    {
        /// <summary>
        /// Adds the label using edit.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns Success Message</returns>
        public string AddLabelUsingEdit(LabelModel labelModel);
        
        /// <summary>
        /// Removes the label using edit.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns Success Message</returns>
        public string RemoveLabelUsingEdit(string labelName, int userId);

        /// <summary>
        /// Edits the label using edit.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>Returns Success Message</returns>
        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName);

        /// <summary>
        /// Gets the label using user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns Success Message</returns>
        public List<LabelModel> GetLabelUsingUserId(int userId);

        /// <summary>
        /// Gets the label by note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>Returns Success Message</returns>
        public List<LabelModel> GetLabelByNoteId(int noteId);

        /// <summary>
        /// Removes the label.
        /// </summary>
        /// <param name="lableId">The label identifier.</param>
        /// <returns>Returns Success Message</returns>
        public string RemoveLabel(int lableId);

        /// <summary>
        /// Creates the label using note.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns Success Message</returns>
        public string CreateLabelUsingNote(LabelModel labelModel);

        /// <summary>
        /// Displays the label note.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>Returns Success Message</returns>
        public List<NotesModel> DisplayLabelNote(int userId, string labelName);
    }
}
