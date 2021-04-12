using CogniTweets_Service.Models;
using CogniTweets_Service.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CogniTweets_Service.Business
{
    public class CogniTweetsBusiness: ICogniTweetsBusiness
    {
        /// <summary>
        /// _cogniTweetsRepository
        /// </summary>
        private readonly ICogniTweetsRepository _cogniTweetsRepository;

        /// <summary>
        /// _logger
        /// </summary>
        private ILogger<CogniTweetsBusiness> _logger;

        /// <summary>
        /// CogniTweetsBusiness Contructor
        /// </summary>
        /// <param name="_cogniTweetsRepository"></param>
        /// <param name="_logger"></param>
        public CogniTweetsBusiness(ICogniTweetsRepository _cogniTweetsRepository, ILogger<CogniTweetsBusiness> _logger)
        {
            this._cogniTweetsRepository = _cogniTweetsRepository;
            this._logger = _logger;
        }

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        public async Task<string> ForgotPassword(string emailId, string password)
        {
            string message = string.Empty;
            password = this.EncryptPassword(password);
            var result = await this._cogniTweetsRepository.ForgotPassword(emailId, password);
            if (result)
            {
                message = "Changed Password";
            }
            else
            {
                message = "Failed";
            }
            return message;
        }

        /// <summary>
        /// GetAllTweets
        /// </summary>
        /// <returns>All tweets</returns>
        public async Task<IList<Tweet>> GetAllTweets()
        {
            try
            {
                var result = await this._cogniTweetsRepository.GetAllTweets();
                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while retrieving all tweets");
                throw;
            }
        }

        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <returns> All users</returns>
        public async Task<IList<CogniTweetsUser>> GetAllUsers()
        {
            try
            {
                var result = await this._cogniTweetsRepository.GetAllUsers();
                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while retrieving all registered users");
                throw;
            }
        }

        /// <summary>
        /// GetTweetsByUser
        /// </summary>
        /// <param name="userID"></param>
        /// <returns> list of tweets => userID</returns>
        public async Task<IList<Tweet>> GetTweetsByUser(int userID)
        {
            try
            {
                var result = await this._cogniTweetsRepository.GetTweetsByUser(userID);
                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while retrieving all tweets");
                throw;
            }
        }

        /// <summary>
        /// PostTweet
        /// </summary>
        /// <param name="tweet"></param>
        public async Task<string> PostTweet(Tweet tweet)
        {
            try
            {
                string message = string.Empty;
                var result = await this._cogniTweetsRepository.PostTweet(tweet);
                if (result > 0)
                {
                    message = "Posted";
                }
                else
                {
                    message = "Error occured";
                }
                return message;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while retrieving all tweets");
                throw;
            }
        }

        /// <summary>
        /// UpdatePassword
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newPassword"></param>
        public async Task<string> UpdatePassword(string emailId, string oldpassword, string newPassword)
        {
            try
            {
                string message = string.Empty;
                newPassword = this.EncryptPassword(newPassword);
                oldpassword = this.EncryptPassword(oldpassword);
                var result = await this._cogniTweetsRepository.UpdatePassword(emailId, oldpassword, newPassword);
                if (result)
                {
                    message = "Updated Successfully";
                }
                else
                {
                    message = "Update Failed";
                }
                return message;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while retrieving all tweets");
                throw;
            }
        }

        /// <summary>
        /// UserLogin
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        public async Task<string> UserLogin(string emailId, string password)
        {
            try
            {
                string message = string.Empty;
                password = this.EncryptPassword(password);
                var result = await this._cogniTweetsRepository.Login(emailId, password);
                if (result)
                {
                    message = "Successfully logged in";
                }
                else
                {
                    message = "login failed";
                }
                return message;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while retrieving all tweets");
                throw;
            }
        }

        /// <summary>
        /// NewUserRegistration
        /// </summary>
        /// <param name="user"></param>
        public async Task<string> NewUserRegistration(CogniTweetsUser user)
        {
            try
            {
                string message = string.Empty;
                var validate = await this._cogniTweetsRepository.ValidateEmailId(user.EmailId);
                if (validate == null)
                {
                    user.Password = this.EncryptPassword(user.Password);
                    var result = await this._cogniTweetsRepository.NewUserRegistration(user);
                    if (result > 0)
                    {
                        message = "Successfully registerd";
                    }
                    else
                    {
                        message = "Registration failed";
                    }
                }
                else
                {
                    message = "EmailId is already used";
                }

                return message;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while retrieving all tweets");
                throw;
            }
        }

        /// <summary>
        /// EncryptPassword
        /// </summary>
        /// <param name="password"></param>
        private string EncryptPassword(string password)
        {
            string message = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            message = Convert.ToBase64String(encode);
            return message;
        }
    }
}
