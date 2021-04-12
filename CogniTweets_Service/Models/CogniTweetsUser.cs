using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CogniTweets_Service.Models
{
    public class CogniTweetsUser
    {
        /// <summary>
        /// Holds UserId of User
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Holds FirstName of User
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Holds LastName of User
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Holds Gender of User
        /// </summary>
        [Required]       
        public string Gender { get; set; }

        /// <summary>
        /// Holds DOB of User
        /// </summary>
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }

        /// <summary>
        /// Holds EmailId of User
        /// </summary>
        [Required]
        public string EmailId { get; set; }

        /// <summary>
        /// Holds Password of User
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Holds Tweets of User
        /// </summary>
        public IList<Tweet> Tweets { get; set; }

    }
}
