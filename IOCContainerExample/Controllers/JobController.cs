using IOCContainerExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IOCContainerExample.Controllers
{
    /// <summary>
    /// Job Controller that shows Jobs found
    /// </summary>
    public class JobController : Controller
    {
        //Repository that holds the data, in a data-bound example this would be coming from a database
        private IJobRepository _jobRepository;
 
        /// <summary>
        /// Constructor for this controller that takes a repository item
        /// </summary>
        /// <param name="jobRepo">Interface for the repository</param>
        public JobController(IJobRepository jobRepo)
        {
            _jobRepository = jobRepo;
        }

        //
        // GET: /Job/
        public ActionResult Index()
        {
            return View(_jobRepository.GetAllJobs());
        }

        //
        // GET: /Job/Details/5
        public ActionResult Details(int id)
        {
            return View(_jobRepository.JobDetails(id));
        }

        #region Unused Methods
        /*
        //
        // GET: /Job/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Job/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Job/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Job/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Job/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Job/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
         */
        #endregion
    }
}
