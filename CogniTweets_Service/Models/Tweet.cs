

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CogniTweets_Service.Models
{
    public class Tweet
    {
        /// <summary>
        /// Holds Id
        /// </summary>
        
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Holds CogniTweetsUserId
        /// </summary>      
        public int CogniTweetsUserId { get; set; }

        /// <summary>
        /// Holds Tweets
        /// </summary>
        public string Tweets { get; set; }
    }
}
