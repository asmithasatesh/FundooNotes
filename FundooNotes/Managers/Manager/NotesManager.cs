using Managers.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Manager
{
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly INotesRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
        }
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

        public string TrashNote(int notesId, int userID)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.TrashNote(notesId, userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RestoreTrash(int notesId, int userID)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.RestoreTrash(notesId, userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ArchiveNote(int notesId, int userID)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.ArchiveNote(notesId, userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
