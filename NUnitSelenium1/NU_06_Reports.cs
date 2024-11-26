using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

//using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace NUnitSelenium1
{
    internal class NU_06_Reports
    {
        // install ExtentReports and ExtentReports.NUnit packages from nuget

        private ExtentReports extent;
        private ExtentTest test;

        [OneTimeSetUp]
        public void BeforeAllTest()
        {
            DateTime currentTime = DateTime.Now;
            string fileName = "Extent_" + currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".html";

            //string fileName = "extent.html";
            string pathtofile = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\reports\\" + fileName;

            var htmlReporter = new ExtentSparkReporter(pathtofile);
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = "CBA Test Suite";
            htmlReporter.Config.ReportName = "Automation Test Results";
            htmlReporter.Config.Encoding = "utf-8";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Automation Tester", "Vijay Reddy");
            extent.AddSystemInfo("Organization", "CBA");
            extent.AddSystemInfo("Build No: ", "CBA-101");
        }
        #region :: Step 2 ::
        [SetUp]
        public void BeforeEachTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }

        [TearDown]
        public void AfterEachTest()
        {
            //Get the test status to update in the report of each test
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus == TestStatus.Passed)
            {
                //test.Pass("Test case pass");
                // more customizations can be done using below code with extent reports
                IMarkup markup = MarkupHelper.CreateLabel("PASS", ExtentColor.Green);
                test.Pass(markup);

            }
            else if (testStatus == TestStatus.Skipped)
            {
                test.Skip("Test Skipped");
                //test.Skip("Test Skipped : " + TestContext.CurrentContext.Result.Message);
                //IMarkup markup = MarkupHelper.CreateLabel("SKIP", ExtentColor.Amber);
                //test.Skip(markup);
            }
            else if (testStatus == TestStatus.Failed)
            {
                test.Fail("Test Failed");
                //test.Fail("Test Failed : " + TestContext.CurrentContext.Result.Message);
                //IMarkup markup = MarkupHelper.CreateLabel("FAIL", ExtentColor.Red);
                //test.Fail(markup);
            }
        }
        #endregion
        [OneTimeTearDown]
        public void AfterAllTests()
        {
            extent.Flush();
        }

        // different test cases
        // one test case needed for generating the report

        [Test]
        public void LoginTest()
        {

            test.Info("Entering username");
            test.Info("Entering password");
            test.Info("Clicking on Submit button");
            //test.Pass("Test case pass");
            Assert.Pass("Test case pass");
        }

        [Test]
        public void UserRegTest()
        {
            test.Info("Entering First Name");
            test.Info("Entering Last Name");
            // instead of fail , we can use Assert.Fail and
            // capture the status in afftereachtest
            // method to write in the report
            // test.Fail("Failing the test case");
            Assert.Fail("Failing the test case");
        }

        [Test]
        public void ComposeEmailTest()
        {
            test.Info("Composing Email");
           // test.Skip("Skipping the test case");
            Assert.Ignore("Skipping the test case");
        }
    }
}
