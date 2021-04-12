using CogniTweets_Service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogniTweets_Service.Repositories
{
    public class CogniTweetsRepository : ICogniTweetsRepository
    {
        /// <summary>
        /// _dbcontext
        /// </summary>
        private readonly CogniTweetsDBContext _dbcontext;

        /// <summary>
        /// CogniTweetsRepository Constuctor
        /// </summary>
        /// <param name="context"></param>
        public CogniTweetsRepository(CogniTweetsDBContext context)
        {
            _dbcontext = context;
        }

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        /// <returns>either true or false</returns>
        public async Task<bool> ForgotPassword(string emailId, string password)
        {
            var result = await _dbcontext.Users.Where(s => s.EmailId == emailId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Password = password;
                _dbcontext.Update(result);
                var response = _dbcontext.SaveChanges();
                if (response > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// GetAllTweets
        /// </summary>
        /// <returns>List of tweets</returns>
        public async Task<IList<Tweet>> GetAllTweets()
        {
            var tweets = await _dbcontext.Tweets.ToListAsync();
            return tweets;
        }

        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <returns>List of Users</returns>
        public async Task<IList<CogniTweetsUser>> GetAllUsers()
        {
            var result = await _dbcontext.Users.Select(p => new CogniTweetsUser
            {
                FirstName = p.FirstName,
                LastName = p.LastName
            }).ToListAsync();
            return result;
        }

        /// <summary>
        /// GetTweetsByUser
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Twees list of Logged in user</returns>
        public async Task<IList<Tweet>> GetTweetsByUser(int userID)
        {
            var result = await _dbcontext.Tweets.Where(i => i.CogniTweetsUserId == userID).ToListAsync();
            return result;
        }

        /// <summary>
        /// PostTweet
        /// </summary>
        /// <param name="tweet"></param>
        /// <returns>int</returns>
        public async Task<int> PostTweet(Tweet tweet)
        {
            _dbcontext.Tweets.Add(tweet);
            var result = await _dbcontext.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// NewUserRegistration
        /// </summary>
        /// <param name="users"></param>
        /// <returns>int</returns>
        public async Task<int> NewUserRegistration(CogniTweetsUser newUser)
        {
            _dbcontext.Users.Add(newUser);
            var result = await _dbcontext.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        /// <returns>either true or false</returns>
        public async Task<bool> Login(string emailId, string password)
        {
            CogniTweetsUser user = await _dbcontext.Users.SingleOrDefaultAsync(e => e.EmailId == emailId && e.Password == password);
            if (user != null)
                return true;
            else
                return false;

        }

        /// <summary>
        /// UpdatePassword
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>either true or false</returns>
        public async Task<bool> UpdatePassword(string emailId, string oldpassword, string newPassword)
        {
            var update = await _dbcontext.Users.Where(x => x.EmailId == emailId && x.Password == oldpassword).FirstOrDefaultAsync();
            if (update != null)
            {
                update.Password = newPassword;
                _dbcontext.Users.Update(update);
                var result = await _dbcontext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ValidateEmailId
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns>user</returns>
        public async Task<CogniTweetsUser> ValidateEmailId(string emailId)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(e => e.EmailId == emailId);
            return user;

        }
    }
}
