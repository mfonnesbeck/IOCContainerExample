using System;

namespace IOCContainerExample.Models
{
    /// <summary>
    /// A Job Model that stores a Job opportunity tracked
    /// </summary>
    public class JobItem
    {
        public int jobID { get; set; }
        public string jobCompany { get; set; }
        public string jobTitle { get; set; }
        public string jobContactPerson { get; set; }
        public DateTime jobUpdate { get; set; }
    }
}