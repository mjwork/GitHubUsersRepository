using System.Collections.Generic;

namespace GitHubUsersRepository.Models.ViewModels
{
    /// <summary>
    /// ViewModel for the User Details page.
    /// </summary>
    public class UserDetailsViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string AvatarUrl { get; set; }
        public List<GithubRepo> Repos { get; set; }
    }
}