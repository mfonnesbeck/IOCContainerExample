using IOCContainerExample.Models;
using IOCContainerExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOCContainerExample.Tests.Repository
{
    public class TestJobRepository : IJobRepository, IDisposable
    {
        //Test Data
        private List<JobItem> items = new List<JobItem>() { 
            new JobItem{jobID=99, jobCompany="Test", jobContactPerson="Test", jobTitle="Test", jobUpdate=DateTime.Today}
        };

        /// <summary>
        /// Gets a list of all Jobs
        /// </summary>
        /// <returns>A List of all Jobs</returns>
        public List<JobItem> GetAllJobs()
        {
            return items;
        }

        /// <summary>
        /// Returns a single sought-for Job
        /// </summary>
        /// <param name="id">Id for the Job</param>
        /// <returns>The found Job object</returns>
        public JobItem JobDetails(int id)
        {
            var item = items.Find(i => i.jobID == id);
            return item;
        }

        /// <summary>
        /// IDisposable method to properly dispose of the Job Repository object 
        /// </summary>
        public void Dispose()
        {
            items = null;
        }
    }
}
