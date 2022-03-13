using GitHubUsersRepository.Data.Services.Interfaces;
using GitHubUsersRepository.Models;
using GitHubUsersRepository.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GitHubUsersRepository.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// Service used to access User data
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Service used to access Repo data
        /// </summary>
        private readonly IRepoService _repoService;

        public UserController(IUserService userService, IRepoService repoService)
        {
            _userService = userService;
            _repoService = repoService;
        }

        // GET: User/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: User/Search
        [HttpPost]
        public ActionResult Search(UserSearchViewModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                return View(searchModel);
            }

            return RedirectToAction("Details", searchModel);
        }

        // GET: User/Details?UserName=robconery
        public async Task<ActionResult> Details(UserSearchViewModel searchModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Search");
                }

                GithubUser requestedUser = await _userService.GetByUserName(searchModel.UserName);

                if (requestedUser == null)
                {
                    TempData["message"] = "No user with this username was found.";
                    return RedirectToAction("Search");
                }

                List<GithubRepo> fetchedUsersRepos = await _repoService.GetUsersTopFiveRepos(requestedUser.ReposUrl);

                UserDetailsViewModel vm = new UserDetailsViewModel
                {
                    AvatarUrl = requestedUser.AvatarUrl,
                    Location = requestedUser.Location ?? "N/A",
                    Name = requestedUser.Login,
                    Repos = fetchedUsersRepos
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                TempData["message"] = string.Concat("An error occurred when searching: ", ex.Message);
                return RedirectToAction("Search");
            }
        }
    }
}