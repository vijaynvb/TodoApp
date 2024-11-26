using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitSelenium1
{
    internal class NU_09_CaptureScreenshot
    {
        static IWebDriver driver;

        static void CaptureScreenshot()
        {
            DateTime currentTime = DateTime.Now;
            string fileName = currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

            Screenshot screenshot = ((WebDriver) driver).GetScreenshot();
            screenshot.SaveAsFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\screenshot\\" + fileName);
        }

        static void CaptureElementScreenshot(IWebElement element)
        {

            DateTime currentTime = DateTime.Now;
            string fileName = "Element_" + currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

            Screenshot screenshot = ((ITakesScreenshot)element).GetScreenshot();
            screenshot.SaveAsFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\screenshot\\" + fileName);
        }

        [Test]
         public void TtyitPage()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.in/?tag=msndeskstdin-21&ref=pd_sl_1fp6radpzp_e&adgrpid=1326012680495996&hvadid=82876055419065&hvnetw=o&hvqmt=e&hvbmt=be&hvdev=c&hvlocint=&hvlocphy=156683&hvtargid=kwd-82876732654247:loc-90&hydadcr=5652_2377259";
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            CaptureScreenshot();

           /* driver.SwitchTo().Frame("iframeResult");
             driver.FindElement(By.XPath("/html/body/button")).Click();
            IWebElement elem = driver.FindElement(By.Id("mySubmit"));
            CaptureElementScreenshot(elem);*/
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver.Quit();
            }
        }
    }
}
