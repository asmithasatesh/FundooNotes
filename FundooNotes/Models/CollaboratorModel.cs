using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class CollaboratorModel
    {
        [Key]
        public int CollaboratorId { get; set; }

        [Required]
        public string CollaboratorEmail { get; set; }

        [ForeignKey("NotesModel")]
        public int NotesId { get; set; } 

        public NotesModel NotesModel { get; set; }
    }
}
