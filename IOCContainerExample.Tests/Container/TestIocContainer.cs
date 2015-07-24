using IOCContainerExample.Repository;
using IOCContainerExample.Tests.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IOCContainerExample.Tests.Container
{
    public class TestIocContainer : IDependencyResolver, IDisposable
    {
        //IOC Unity Container
        private IUnityContainer _container;

        /// <summary>
        /// Constructor to create container
        /// </summary>
        public TestIocContainer()
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
            ucontainer.RegisterType<IJobRepository, TestJobRepository>();

            return ucontainer;
        }

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
    }
}
