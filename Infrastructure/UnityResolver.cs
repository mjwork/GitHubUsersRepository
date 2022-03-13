using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Unity;

namespace GitHubUsersRepository.Infrastructure
{
    public class UnityResolver : IDependencyResolver
    {
        private IUnityContainer _unityContainer;

        public UnityResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return Enumerable.Empty<object>();
            }
        }
    }
}