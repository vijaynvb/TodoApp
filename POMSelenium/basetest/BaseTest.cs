using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using log4net;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;


namespace PageObjectModelFramework.basetest
{
    [SetUpFixture]
    internal class BaseTest
    {
        /*
         * Extent Reports
         * Logs
         * Database
         * Keywords
         * Screenshots
         * WebDriver
         * Configuration
         * ThreadLocal
         * 
         */

        public static ThreadLocal<IWebDriver> driver = new();
        private static ExtentReports extent;
        public static ThreadLocal<ExtentTest> exTest = new();

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IConfiguration configuration;
        static string fileName;

        public static IWebDriver GetDriver()
        {
            return driver.Value;
        }

        public static ExtentTest GetExtentTest()
        {
            return exTest.Value;
        }

        static BaseTest()
        {
            DateTime currentTime = DateTime.Now;
            string fileName = "Extent_" + currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".html";
            extent = CreateInstance(fileName);
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            log.Info("Test Execution Started !!!");

            var basePath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName + "\\resources\\";
            if (basePath == null)
            {
                throw new InvalidOperationException("Base path could not be determined.");
            }

            configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        [SetUp]
        public void BeforeEachTest()
        {
            exTest.Value = extent.CreateTest(TestContext.CurrentContext.Test.ClassName + " @ Test Case Name : " + TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterEachTest()
        {
            // Get the test status
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            if (testStatus == TestStatus.Passed)
            {
                GetExtentTest().Pass("Test case pass");
                IMarkup markup = MarkupHelper.CreateLabel("PASS", ExtentColor.Green);
                GetExtentTest().Pass(markup);
            }
            else if (testStatus == TestStatus.Skipped)
            {
                GetExtentTest().Skip("Test Skipped : " + TestContext.CurrentContext.Result.Message);
                IMarkup markup = MarkupHelper.CreateLabel("SKIP", ExtentColor.Amber);
                GetExtentTest().Skip(markup);
            }
            else if (testStatus == TestStatus.Failed)
            {
                CaptureScreenshot();

                GetExtentTest().Fail("Test Failed : " + TestContext.CurrentContext.Result.Message);
                GetExtentTest().Fail("<b><font color=red>  Screenshot of failure </font></b><br>", MediaEntityBuilder.CreateScreenCaptureFromPath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\screenshots\\" + fileName).Build());
                IMarkup markup = MarkupHelper.CreateLabel("FAIL", ExtentColor.Red);
                GetExtentTest().Fail(markup);
            }

            if (driver.Value != null)
            {
                GetDriver().Quit();
            }
        }

        private void CaptureScreenshot()
        {
            DateTime currentTime = DateTime.Now;
            fileName = currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

            Screenshot screenshot = GetDriver().TakeScreenshot();
            screenshot.SaveAsFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\screenshots\\" + fileName);
        }

        private dynamic GetBrowserOptions(string browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    return new ChromeOptions();
                case "firefox":
                    return new FirefoxOptions();
            }
            return new ChromeOptions();
        }

        public void SetUp(string browserName)
        {
            dynamic options = GetBrowserOptions(browserName);
            options.PlatformName = "windows";

            driver.Value = new RemoteWebDriver(new Uri(configuration["AppSettings:gridurl"]), options.ToCapabilities());

            GetDriver().Url = configuration["AppSettings:testsiteurl"];
            GetDriver().Manage().Window.Maximize();
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(configuration["AppSettings:implicit.wait"]));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.Flush();
            if (driver == null)
            {
                driver.Dispose();
                exTest.Dispose();
                log.Info("Test execution completed !!!");
            }
        }

        public static ExtentReports CreateInstance(string fileName)
        {
            var htmlReporter = new ExtentSparkReporter(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\reports\\" + fileName);
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = "CBA Test Suite";
            htmlReporter.Config.ReportName = "Automation Test Results";
            htmlReporter.Config.Encoding = "utf-8";

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Automation Tester", "Vijay Reddy");
            extent.AddSystemInfo("Organization", "CBA");
            extent.AddSystemInfo("Build No: ", "CBA-1234");
            return extent;
        }
    }
}
