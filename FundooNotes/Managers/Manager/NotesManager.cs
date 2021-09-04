// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="Bridgelabz">
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
    /// Pass data from Controller to Repository
    /// </summary>
    /// <seealso cref="Managers.Interface.INotesManager" />
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly INotesRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates the note.
        /// </summary>
        /// <param name="noteData">The note data.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string CreateNote(NotesModel noteData)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.CreateNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the user notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Returns Notes List
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public List<NotesModel> GetUserNotes(int userId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.GetUserNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trashes the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string TrashNote(int notesId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.TrashNote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restores the trash.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string RestoreTrash(int notesId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.RestoreTrash(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Archives the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string ArchiveNote(int notesId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.ArchiveNote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restore the archive note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string UnArchiveNote(int notesId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.UnArchiveNote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Pins the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string PinNote(int notesId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.PinNote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restore the pin note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string UnPinNote(int notesId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.UnPinNote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string SetColor(int notesId, string color)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.SetColor(notesId, color);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string DeleteNote(int notesId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.DeleteNote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Sets the reminder.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string SetReminder(int notesId, string reminder)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.SetReminder(notesId, reminder);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the reminder.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string RemoveReminder(int notesId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.RemoveReminder(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the note.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string UpdateNote(NotesModel notesModel)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.UpdateNote(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string EmptyTrash(int userId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.EmptyTrash(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Returns Trash List
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public List<NotesModel> GetTrash(int userId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.GetTrash(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the reminder.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Returns Reminder List
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public List<NotesModel> GetReminder(int userId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.GetReminder(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the archive.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Returns Archive List
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public List<NotesModel> GetArchive(int userId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.GetArchive(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
