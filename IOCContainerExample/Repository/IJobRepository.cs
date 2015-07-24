using IOCContainerExample.Models;
using System;
using System.Collections.Generic;

namespace IOCContainerExample.Repository
{
    /// <summary>
    /// Interface for the JobRepository object
    /// </summary>
    public interface IJobRepository
    {
        List<JobItem> GetAllJobs();
        JobItem JobDetails(int id);
    }
}