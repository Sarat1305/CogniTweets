using CogniTweets_Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CogniTweets_Service.Business
{
    public interface ICogniTweetsBusiness
    {
        /// <summary>
        /// NewUserRegistration
        /// </summary>
        /// <param name="users"></param>
        /// <returns>int</returns>
        Task<string> NewUserRegistration(CogniTweetsUser users);

        /// <summary>
        /// UserLogin
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        /// <returns>either true or false</returns>
        Task<string> UserLogin(string emailId, string password);

        /// <summary>
        /// GetAllTweets
        /// </summary>
        /// <returns>List of all tweets</returns>
        Task<IList<Tweet>> GetAllTweets();

        /// <summary>
        /// GetTweetsByUser
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List of tweets for the user</returns>
        Task<IList<Tweet>> GetTweetsByUser(int userID);

        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <returns>List of users</returns>
        Task<IList<CogniTweetsUser>> GetAllUsers();

        /// <summary>
        /// PostTweet
        /// </summary>
        /// <param name="tweet"></param>
        Task<string> PostTweet(Tweet tweet);

        /// <summary>
        /// UpdatePassword
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>either true or false</returns>
        Task<string> UpdatePassword(string emailId, string oldpassword, string newPassword);

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        /// <returns>either true or false</returns>
        Task<string> ForgotPassword(string emailId, string password);
    }
}
