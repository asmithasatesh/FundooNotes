using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Class ResetModel
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