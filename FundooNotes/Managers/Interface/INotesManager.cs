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
        public string TrashNote(int notesId, int userID);
        public string RestoreTrash(int notesId, int userID);
        public string ArchiveNote(int notesId, int userID);
        public string UnArchiveNote(int notesId, int userID);
        public string PinNote(int notesId, int userID);
        public string UnPinNote(int notesId, int userID);
        public string SetColor(NotesModel notesModel);
    }
}
