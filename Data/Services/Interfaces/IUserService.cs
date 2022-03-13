using GitHubUsersRepository.Models;
using System.Threading.Tasks;

namespace GitHubUsersRepository.Data.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Gets a Github user by their username.
        /// </summary>
        /// <param name="username">The Github username to search for.</param>
        /// <returns>A <see cref="GithubUser"/> containing data for the requested user.</returns>
        Task<GithubUser> GetByUserName(string username);
    }
}