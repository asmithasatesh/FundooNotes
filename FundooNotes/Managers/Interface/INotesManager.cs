using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Interface
{
    public interface INotesManager
    {
        public string CreateNote(NotesModel noteData);
        public List<NotesModel> GetUserNotes(int userId);
        public string TrashNote(int notesId);
        public string RestoreTrash(int notesId);
        public string DeleteNote(int notesId);
        public string ArchiveNote(int notesId);
        public string UnArchiveNote(int notesId);
        public string PinNote(int notesId);
        public string UnPinNote(int notesId);
        public string SetColor(NotesModel notesModel);
        public string SetReminder(NotesModel notesModel);
        public string RemoveReminder(NotesModel notesModel);
        public string UpdateNote(NotesModel notesModel);
        public string EmptyTrash(int UserId);
    }
}
