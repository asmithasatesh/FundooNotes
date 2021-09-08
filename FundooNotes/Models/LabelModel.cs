// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Label model to access data
    /// </summary>
    public class LabelModel
    {
        /// <summary>
        /// Gets or sets the label identifier.
        /// </summary>
        /// <value>
        /// The label identifier.
        /// </value>
        [Key]
        public int LabelId { get; set; }

        /// <summary>
        /// Gets or sets the name of the label.
        /// </summary>
        /// <value>
        /// The name of the label.
        /// </value>
        [Required]
        public string LabelName { get; set; }

        /// <summary>
        /// Gets or sets the notes identifier.
        /// </summary>
        /// <value>
        /// The notes identifier.
        /// </value>
        [ForeignKey("NotesModel")]
        public int? NotesId { get; set; }

        /// <summary>
        /// Gets or sets the notes model.
        /// </summary>
        /// <value>
        /// The notes model.
        /// </value>
        public NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the register model.
        /// </summary>
        /// <value>
        /// The register model.
        /// </value>
        public RegisterModel RegisterModel { get; set; }
    }
}
