using Managers.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class NotesController : ControllerBase
    {
        private readonly INotesManager noteManager;
        public NotesController(INotesManager notes)
        {
            this.noteManager = notes;
        }
    }
}
