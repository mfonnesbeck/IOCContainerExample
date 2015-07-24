using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IOCContainerExample.Tests.Container;
using IOCContainerExample.Repository;
using System.Collections.Generic;
using System.Linq;

namespace IOCContainerExample.Tests
{
    [TestClass]
    public class IocContainerTest
    {
        [TestMethod]
        public void CreateDestory()
        {
            //Create/Build the container
            TestIocContainer ioc = new TestIocContainer();
            
            //Tests
            Assert.IsNotNull(ioc);

            //Destory container
            ioc.Dispose();
            Assert.IsNotNull(ioc);
        }

        [TestMethod]
        public void GetServiceTest()
        {
            //Get the JobRepository
            TestIocContainer ioc = new TestIocContainer();

            //Get the IJobRepository Test object
            object jobRepo = ioc.GetService(typeof(IJobRepository));

            //Tests
            Assert.IsNotNull(jobRepo);
            Assert.IsInstanceOfType(jobRepo, typeof(IJobRepository));
            Assert.IsNotNull(((IJobRepository)jobRepo).GetAllJobs());

            //Cleanup
            ioc.Dispose();
        }

        [TestMethod]
        public void GetServicesTest()
        {
            //Get the JobRepository
            TestIocContainer ioc = new TestIocContainer();

            //Get the IJobRepository Test object
            IEnumerable<object> jobRepo = ioc.GetServices(typeof(IJobRepository));
            List<object> jobRepoList = jobRepo.ToList<object>();

            //Tests
            Assert.IsNotNull(jobRepo);
            Assert.IsNotNull(jobRepoList);
            foreach (object job in jobRepoList)
            {
                IJobRepository oneJobRepo = (IJobRepository)job;
                Assert.IsNotNull(oneJobRepo.GetAllJobs());
            }

            //Cleanup
            ioc.Dispose();
        }
    }
}
