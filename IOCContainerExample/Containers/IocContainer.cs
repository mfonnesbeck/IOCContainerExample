using IOCContainerExample.Controllers;
using IOCContainerExample.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IOCContainerExample.Containers
{
    /// <summary>
    /// IOC Container that registers and holds and resolves controller and repository types
    /// </summary>
    public class IocContainer : IDependencyResolver, IDisposable
    {
        //IOC Unity Container
        protected IUnityContainer _container;
        protected ContainerControlledLifetimeManager _controlledLifetimeManager;

        /// <summary>
        /// Constructor to create container
        /// </summary>
        public IocContainer()
        {
            _container = BuildUnityContainer();
        }

        /// <summary>
        /// Actually builds the container and registers types
        /// </summary>
        /// <returns></returns>
        private IUnityContainer BuildUnityContainer()
        {
            // Create a new Unity dependency injection container
            var ucontainer = new UnityContainer();

            // Register instances to be used when resolving constructor parameter dependencies
            RegisterSingletons(ucontainer);
            // Register the Controllers that should be injectable
            RegisterTransients(ucontainer);

            return ucontainer;
        }

        /// <summary>
        /// Registers all Singleton instances where there should only be one instance of the registered object
        /// </summary>
        /// <param name="ucontainer">Unit Container that these instances are registered with</param>
        private void RegisterSingletons(UnityContainer ucontainer)
        {
            //Instantiate the lifetime manager to track the singletons
            _controlledLifetimeManager = new ContainerControlledLifetimeManager();
            ucontainer.RegisterType<IJobRepository, JobRepository>(_controlledLifetimeManager);
        }

        /// <summary>
        /// Registers all Transient (default) instances where it will serve up a new instance each time resolved
        /// </summary>
        /// <param name="ucontainer">Unit Container that these instances are registered with</param>
        private void RegisterTransients(UnityContainer ucontainer)
        {
            //The default lifetime manager is TransientLifetimeManager, no need to specify
            ucontainer.RegisterType<JobController>();
            ucontainer.RegisterType<HomeController>();
        }

        #region Implemented Interface Methods
        /// <summary>
        /// IDependencyResolver method to get the desired registered type "service"
        /// </summary>
        /// <param name="serviceType">Type to resolve</param>
        /// <returns>Generic object reference to the stored object</returns>
        public object GetService(Type serviceType)
        {
            if (_container.IsRegistered(serviceType))
            {
                return _container.Resolve(serviceType);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// IDependencyResolver method to get the desired registered types "services"
        /// </summary>
        /// <param name="serviceType">Type to resolve</param>
        /// <returns>A List of generic object references of the stored matching types</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (_container.IsRegistered(serviceType))
            {
                return _container.ResolveAll(serviceType);
            }
            else
            {
                return new List<object>();
            }
        }

        /// <summary>
        /// IDisposable method to properly dispose of this container object
        /// </summary>
        public void Dispose()
        {
            if (_container != null)
            {
                _container.Dispose();
                _container = null;
            }
        }
        #endregion Implemented Interface Methods
    }
}