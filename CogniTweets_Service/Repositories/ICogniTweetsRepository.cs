using CogniTweets_Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CogniTweets_Service.Repositories
{
    public interface ICogniTweetsRepository
    {
        /// <summary>
        /// NewUserRegistration
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        Task<int> NewUserRegistration(CogniTweetsUser newUser);

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> Login(string emailId, string password);

        /// <summary>
        /// GetAllTweets
        /// </summary>
        /// <returns>List of All Tweets</returns>
        Task<IList<Tweet>> GetAllTweets();

        /// <summary>
        /// GetTweetsByUser
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List of Tweets of Loggedin User</returns>
        Task<IList<Tweet>> GetTweetsByUser(int userID);

        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <returns>List of All Users</returns>
        Task<IList<CogniTweetsUser>> GetAllUsers();

        /// <summary>
        /// PostTweet
        /// </summary>
        /// <param name="tweet"></param>
        /// <returns>int</returns>
        Task<int> PostTweet(Tweet tweet);

        /// <summary>
        /// UpdatePassword
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>either true or false</returns>
        Task<bool> UpdatePassword(string emailId, string oldpassword, string newPassword);

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        /// <returns>either true or false</returns>
        Task<bool> ForgotPassword(string emailId, string password);

        /// <summary>
        /// ValidateEmailId
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns>CogniTweetsUser</returns>
        Task<CogniTweetsUser> ValidateEmailId(string emailId);
    }
}
