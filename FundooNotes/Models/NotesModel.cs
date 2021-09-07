// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Notes model to access data
    /// </summary>
    public class NotesModel
    {
        /// <summary>
        /// Gets or sets the notes identifier.
        /// </summary>
        /// <value>
        /// The notes identifier.
        /// </value>
        [Key]
        public int NotesId { get; set; }

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

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the remainder.
        /// </summary>
        /// <value>
        /// The remainder.
        /// </value>
        public string Remainder { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NotesModel"/> is archive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if archive; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool Archive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NotesModel"/> is pin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if pin; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool Pin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NotesModel"/> is trash.
        /// </summary>
        /// <value>
        ///   <c>true</c> if trash; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool Trash { get; set; }
    }
}
