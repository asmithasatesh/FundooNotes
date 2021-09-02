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
        public string SetColor(NotesModel notesModel)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.SetColor(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
        public string SetReminder(NotesModel notesModel)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.SetReminder(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveReminder(NotesModel notesModel)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.RemoveReminder(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
        public string EmptyTrash(int UserId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.EmptyTrash(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
