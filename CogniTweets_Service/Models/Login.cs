using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CogniTweets_Service.Models
{
    public class Login
    {
        /// <summary>
        /// Holds UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Holds EmailId
        /// </summary>
        [Required]
        public string EmailId { get; set; }

        /// <summary>
        /// Holds Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
