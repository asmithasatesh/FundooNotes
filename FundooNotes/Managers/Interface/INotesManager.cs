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
        public string ArchiveNote(int notesId);
    }
}
