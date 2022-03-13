using GitHubUsersRepository.Data.Services;
using GitHubUsersRepository.Data.Services.Interfaces;
using GitHubUsersRepository.Infrastructure;
using System.Web.Mvc;
using Unity;

namespace GitHubUsersRepository.App_Start
{
    public static class ServiceRegistrations
    {
        /// <summary>
        /// Configure dependency injection via Unity.
        /// </summary>
        public static void ConfigureUnity()
        {
            IUnityContainer container = new UnityContainer();

            RegisterServices(container);

            DependencyResolver.SetResolver(new UnityResolver(container));
        }

        /// <summary>
        /// Register our services to be injected.
        /// </summary>
        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRepoService, RepoService>();
        }
    }
}