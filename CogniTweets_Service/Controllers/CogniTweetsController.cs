using CogniTweets_Service.Business;
using CogniTweets_Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogniTweets_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CogniTweetsController : ControllerBase
    {
        private readonly ICogniTweetsBusiness _cogniTweetstBusiness;
        private ILogger<CogniTweetsController> _logger;

        public CogniTweetsController(ICogniTweetsBusiness _cogniTweetstBusiness, ILogger<CogniTweetsController> _logger)
        {
            this._cogniTweetstBusiness = _cogniTweetstBusiness;
            this._logger = _logger;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="user">user.</param>
        /// <returns>response.</returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] CogniTweetsUser user)
        {
            try
            {
                var result = await this._cogniTweetstBusiness.NewUserRegistration(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="user">user.</param>
        /// <returns>response.</returns>
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(string emailID, string password)
        {
            try
            {
                var result = await this._cogniTweetstBusiness.UserLogin(emailID, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Post Tweet.
        /// </summary>
        /// <param name="tweet">tweet.</param>
        /// <returns>response.</returns>
        [HttpPost]
        [Route("tweet")]
        public async Task<IActionResult> Tweet(Tweet tweet)
        {
            try
            {
                var result = await this._cogniTweetstBusiness.PostTweet(tweet);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>response.</returns>
        [HttpGet]
        [Route("allusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await this._cogniTweetstBusiness.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Get All Tweets.
        /// </summary>
        /// <returns>response.</returns>
        [HttpGet]
        [Route("alltweets")]
        public async Task<IActionResult> GetAllTweets()
        {
            try
            {
                var result = await this._cogniTweetstBusiness.GetAllTweets();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Update Password.
        /// </summary>
        /// <returns>response.</returns>
        [HttpPut]
        [Route("updatepassword")]
        public async Task<IActionResult> UpdatePassword(string emailId, string oldpassword, string newPassword)
        {
            try
            {
                var result = await this._cogniTweetstBusiness.UpdatePassword(emailId, oldpassword, newPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }

        /// <summary>
        /// Forgot Password.
        /// </summary>
        /// <returns>response.</returns>
        [HttpPut]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(string emailId, string password)
        {
            try
            {
                var result = await this._cogniTweetstBusiness.ForgotPassword(emailId, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }
        [HttpGet]
        [Route("usertweets")]
        public async Task<IActionResult> GetTweetsByUser(int userId)
        {
            try
            {
                var result = await this._cogniTweetstBusiness.GetTweetsByUser(userId);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }
    }
}
