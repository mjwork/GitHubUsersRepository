using GitHubUsersRepository.Data.Services.Interfaces;
using GitHubUsersRepository.Helpers;
using GitHubUsersRepository.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace GitHubUsersRepository.Data.Services
{
    public class UserService : IUserService
    {
        /// <inheritdoc/>
        public async Task<GithubUser> GetByUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            try
            {
                string getUserUri = string.Concat(ConfigurationManager.AppSettings["GithubUsersUrl"], username);

                string apiResponse = await ExternalApiHelper.CallExternalApi(getUserUri);

                if (apiResponse == null)
                {
                    return null;
                }

                GithubUser requestedUser = JsonConvert.DeserializeObject<GithubUser>(apiResponse);

                return requestedUser;
            }
            catch
            {
                throw new Exception("There was an error fetching the requested user.");
            }
        }
    }
}