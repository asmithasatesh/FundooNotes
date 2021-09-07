// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// ----------------------------------------------------------------------------------------------------------
namespace Managers.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Interface for label manager
    /// </summary>
    public interface ILabelManager
    {
        /// <summary>
        /// Adds the label using edit.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns success message</returns>
        public string AddLabelUsingEdit(LabelModel labelModel);

        /// <summary>
        /// Removes the label using edit.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns success message</returns>
        public string RemoveLabelUsingEdit(string labelName, int userId);

        /// <summary>
        /// Edits the label using edit.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>Returns success message</returns>
        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName);

        /// <summary>
        /// Gets the label using user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns List</returns>
        public List<LabelModel> GetLabelUsingUserId(int userId);

        /// <summary>
        /// Gets the label by note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>Returns List</returns>
        public List<LabelModel> GetLabelByNoteId(int noteId);

        /// <summary>
        /// Removes the label.
        /// </summary>
        /// <param name="lableId">The label identifier.</param>
        /// <returns>Returns success message</returns>
        public string RemoveLabel(int lableId);

        /// <summary>
        /// Creates the label using note.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns success message</returns>
        public string CreateLabelUsingNote(LabelModel labelModel);

        /// <summary>
        /// Displays the label note.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>Returns List</returns>
        public List<NotesModel> DisplayLabelNote(int userId, string labelName);
    }
}
