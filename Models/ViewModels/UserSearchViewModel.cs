using GitHubUsersRepository.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace GitHubUsersRepository.Models.ViewModels
{
    /// <summary>
    /// ViewModel for the User Search page.
    /// </summary>
    public class UserSearchViewModel
    {
        [Required]
        [GithubUsername]
        public string UserName { get; set; }
    }
}