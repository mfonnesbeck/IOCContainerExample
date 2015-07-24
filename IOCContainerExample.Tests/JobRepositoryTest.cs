using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IOCContainerExample.Repository;
using System.Collections.Generic;
using IOCContainerExample.Models;
using IOCContainerExample.Tests.Repository;

namespace IOCContainerExample.Tests
{
    [TestClass]
    public class JobRepositoryTest
    {
        //Locall test repository
        private IJobRepository jobRepo;
        private const string TEST = "Test";
        private const int ID = 99;
        private JobItem tji = new JobItem { jobID = ID, jobCompany = TEST, jobContactPerson = TEST, jobTitle = TEST, jobUpdate = DateTime.Today };

        [TestInitialize]
        public void Init()
        {
            //Get the test repository to test the interface and test class using the interface
            jobRepo = new TestJobRepository();
        }

        [TestMethod]
        public void GetAllItems()
        {
            //Get a list of the jobs
            List<JobItem> jis = jobRepo.GetAllJobs();

            //Tests
            Assert.IsNotNull( jis);
            Assert.AreEqual(1, jis.Count);
            Assert.AreEqual(ID, jis[0].jobID);
            Assert.AreEqual(TEST, jis[0].jobCompany);
            Assert.AreEqual(TEST, jis[0].jobContactPerson);
            Assert.AreEqual(TEST, jis[0].jobTitle);
            Assert.AreEqual(DateTime.Today, jis[0].jobUpdate);
        }

        [TestMethod]
        public void JobDetailsFound()
        {
            //Get a list of the jobs
            JobItem ji = jobRepo.JobDetails(ID);

            //Tests
            Assert.IsNotNull(ji);
            Assert.AreEqual(ID, ji.jobID);
            Assert.AreEqual(TEST, ji.jobCompany);
            Assert.AreEqual(TEST, ji.jobContactPerson);
            Assert.AreEqual(TEST, ji.jobTitle);
            Assert.AreEqual(DateTime.Today, ji.jobUpdate);
        }

        [TestMethod]
        public void JobDetailsNotFound()
        {
            //Get a list of the jobs
            JobItem ji = jobRepo.JobDetails(1);

            //Tests
            Assert.IsNull(ji);
        }
    }
}
