﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface INotesRepository
    {
        public string CreateNote(NotesModel noteData);
    }
}
