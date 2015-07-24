using IOCContainerExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IOCContainerExample.Controllers
{
    /// <summary>
    /// Custom Controller Factory to manage how the controllers are instantiated
    /// </summary>
    public class CustomControllerFactory : DefaultControllerFactory
    {
        //A list of the controllers that take a parameter
        private Dictionary<string, Type> paramExceptions;

        /// <summary>
        /// Constructor that fills the parameter exception list
        /// </summary>
        public CustomControllerFactory()
        {
            FillParameterExceptions();
        }

        /// <summary>
        /// Fills the parameter list with the mapping of controllers with their data repository injections
        /// </summary>
        private void FillParameterExceptions()
        {
            paramExceptions = new Dictionary<string, Type>();
            //Add new lines here to inject a repository type for a controller
            paramExceptions.Add("JobController", typeof(IJobRepository));
        }

        /// <summary>
        /// Gets a controller for the application
        /// </summary>
        /// <param name="requestContext">The Request coontext of the web request</param>
        /// <param name="controllerType">Type of Controller that is being constructed</param>
        /// <returns></returns>
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            IController controller = null;
            //Check to see if the controller needs a parameter
            if (IsControllerParameterized(controllerType.Name))
            {
                //Dynamically pull the parameter type and then resolve the type to construct the controller and pass the parameter in
                dynamic paramType = paramExceptions[controllerType.Name];
                controller = Activator.CreateInstance(controllerType, (dynamic)DependencyResolver.Current.GetService(paramType)) as Controller;
            }
            else
            {
                //Normal controller with no parameter constructor
                controller = Activator.CreateInstance(controllerType) as Controller;
            }
            return controller;
        }

        /// <summary>
        /// Utility method to get whether the controller being constructed contains a parameter
        /// </summary>
        /// <param name="controllerName">Controller name to check</param>
        /// <returns>boolean inducating whether the controller was found in the exceptions</returns>
        private bool IsControllerParameterized(string controllerName)
        {
            return paramExceptions.ContainsKey(controllerName);
        }
    } 
}