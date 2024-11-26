using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSelenium1
{
    //[TestFixture]
    public class BaseTest
    {
        
        [OneTimeSetUp]
        public void BeforeAllTestCases()
        {
            // open database connection
            // connection string 
            // refere to data source
            TestContext.Progress.WriteLine("Before test suite");
        }

        [OneTimeTearDown]
        public void AfterAllTestCases()
        {
            // close database connection
            TestContext.Progress.WriteLine("After test suite");
        }
    }
}
