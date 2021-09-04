// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepository.cs" company="Bridgelabz">
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
    public interface INotesRepository
    {
        /// <summary>
        /// Creates the note.
        /// </summary>
        /// <param name="noteData">The note data.</param>
        /// <returns>Returns success message</returns>
        public string CreateNote(NotesModel noteData);

        /// <summary>
        /// Gets the user notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns Notes List</returns>
        public List<NotesModel> GetUserNotes(int userId);

        /// <summary>
        /// Trashes the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        public string TrashNote(int notesId);

        /// <summary>
        /// Restores the trash.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        public string RestoreTrash(int notesId);

        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        public string DeleteNote(int notesId);

        /// <summary>
        /// Archives the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        public string ArchiveNote(int notesId);

        /// <summary>
        /// Restore the archive note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        public string UnArchiveNote(int notesId);

        /// <summary>
        /// Pins the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        public string PinNote(int notesId);

        /// <summary>
        /// Restore the pin note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        public string UnPinNote(int notesId);

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>Returns success message</returns>
        public string SetColor(int notesId, string color);

        /// <summary>
        /// Sets the reminder.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>Returns success message</returns>
        public string SetReminder(int notesId, string reminder);

        /// <summary>
        /// Removes the reminder.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>Returns success message</returns>
        public string RemoveReminder(int notesId);

        /// <summary>
        /// Updates the note.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>Returns success message</returns>
        public string UpdateNote(NotesModel notesModel);

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns success message</returns>
        public string EmptyTrash(int userId);

        /// <summary>
        /// Gets the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns Trash List</returns>
        public List<NotesModel> GetTrash(int userId);

        /// <summary>
        /// Gets the reminder.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns Reminder List</returns>
        public List<NotesModel> GetReminder(int userId);

        /// <summary>
        /// Gets the archive.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns Archive List</returns>
        public List<NotesModel> GetArchive(int userId);
    }
}
