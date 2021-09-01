﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface INotesRepository
    {
        public string CreateNote(NotesModel noteData);
        public List<NotesModel> GetUserNotes(int userId);
        public string TrashNote(int notesId, int userID);
        public string RestoreTrash(int notesId, int userID);
        public string ArchiveNote(int notesId, int userID);
    }
}
