using GitHubUsersRepository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubUsersRepository.Data.Services.Interfaces
{
    public interface IRepoService
    {
        /// <summary>
        /// Gets a Github User's top 5 repos, ordered by star gazer count, descending.
        /// </summary>
        /// <param name="reposUri">The URI of where to fetch the repo JSON.</param>
        /// <returns>A <see cref="List{GithubRepo}"/> containing the User's top 5 repos.</returns>
        Task<List<GithubRepo>> GetUsersTopFiveRepos(string reposUri);
    }
}