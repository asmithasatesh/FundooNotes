// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class Reset Model
    /// </summary>
    public class ResetModel
    {
        /// <summary>
        /// Gets or sets EmailId
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}