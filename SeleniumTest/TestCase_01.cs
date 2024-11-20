using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace SeleniumTest
{
    class TestCase_01
    {
        public  void Main()
        {

            Console.WriteLine("Hello World!");
            string browser = "chrome"; // edge, firefox, safari, ie, opera, chrome
                                       // grid
            IWebDriver driver = null;
            if (browser == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (browser == "edge")
            {
                driver = new EdgeDriver();
            }
            #region :: Other Browsers ::
            //else if (browser == "firefox")
            //{
            //     driver = new FirefoxDriver(); 
            //}
            //else if (browser == "safari")
            //{
            //    driver = new SafariDriver(); 
            //}
            //else if (browser == "ie")
            //{
            //     driver = new InternetExplorerDriver(); 
            //}
            //else if (browser == "opera")
            //{
            //     driver = new OperaDriver(); 
            //}
            #endregion
            else
            {
                Console.WriteLine("Invalid Browser");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // wait for 10 seconds to find the element and then throw
            // if found before 10 seconds, it will not wait for 10 seconds
            if (driver != null)
            {
                driver.Url = "https://w3schools.com";


                //IWebElement textbox = driver.FindElement(By.Id("search2")); // id should be unique
                // textbox.SendKeys("HTML");
                driver.FindElement(By.Id("search2")).SendKeys("HTML");


                //IWebElement searchbtn = driver.FindElement(By.Id("learntocode_searchbtn"));
                //searchbtn.Click();
                //driver.FindElement(By.Id("learntocode_searchbtn")).Click();
                //driver.FindElement(By.XPath("//*[@id='learntocode_searchbtn']")).Click();

                var btn = driver.FindElements(By.TagName("button"));

                foreach (var item in btn)
                {
                    Console.WriteLine(item.Text);
                }

                btn[0].Click();
                //Thread.Sleep(10000); // 10 for sure 

                string title = driver.Title;
                Console.WriteLine(title);

                //var links = driver.FindElements(By.TagName("a"));
                //var count = links.Count;
                //Console.WriteLine("no of links in my page: " + count);
                //Console.WriteLine("no of links in my page: " + driver.FindElements(By.TagName("a")).Count);

                //driver.Close(); // is for closing the current tab
                //driver.Quit(); // is for closing the browser
            }
        }
    }
}


