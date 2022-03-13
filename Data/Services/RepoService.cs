using GitHubUsersRepository.Data.Services.Interfaces;
using GitHubUsersRepository.Helpers;
using GitHubUsersRepository.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubUsersRepository.Data.Services
{
    public class RepoService : IRepoService
    {
        public async Task<List<GithubRepo>> GetUsersTopFiveRepos(string reposUri)
        {
            if (string.IsNullOrWhiteSpace(reposUri))
            {
                return null;
            }

            string apiResponse = await ExternalApiHelper.CallExternalApi(reposUri);

            List<GithubRepo> requestedRepos = JsonConvert.DeserializeObject<List<GithubRepo>>(apiResponse);

            return requestedRepos.OrderByDescending(repo => repo.StargazersCount).Take(5).ToList();
        }
    }
}