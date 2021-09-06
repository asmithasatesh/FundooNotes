// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Collaborator model contains collaborator details
    /// </summary>
    public class CollaboratorModel
    {
        /// <summary>
        /// Gets or sets the collaborator identifier.
        /// </summary>
        /// <value>
        /// The collaborator identifier.
        /// </value>
        [Key]
        public int CollaboratorId { get; set; }

        /// <summary>
        /// Gets or sets the collaborator email.
        /// </summary>
        /// <value>
        /// The collaborator email.
        /// </value>
        [Required]
        [RegularExpression(@"(^[a-z]+)(([\. \+ \-]?[a-z A-Z 0-9])*)@(([0-9 a-z]+[\.]+[a-z]{3})+([\.]+[a-z]{2,3})?$)", ErrorMessage = "Not a valid Email")]
        public string CollaboratorEmail { get; set; }

        /// <summary>
        /// Gets or sets the notes identifier.
        /// </summary>
        /// <value>
        /// The notes identifier.
        /// </value>
        [ForeignKey("NotesModel")]
        public int NotesId { get; set; }

        /// <summary>
        /// Gets or sets the notes model.
        /// </summary>
        /// <value>
        /// The notes model.
        /// </value>
        public NotesModel NotesModel { get; set; }
    }
}
