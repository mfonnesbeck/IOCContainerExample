using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IOCContainerExample.Controllers
{
    /// <summary>
    /// Simple parameterless controller
    /// </summary>
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
    }
}
