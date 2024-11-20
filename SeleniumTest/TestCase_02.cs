using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace SeleniumTest
{
    class TestCase_02
    {
        public  void Main()
        {
            Console.WriteLine("Hello World!");
            IWebDriver driver = new ChromeDriver();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // wait for 10 seconds to find the element and then throw
            // if found before 10 seconds, it will not wait for 10 seconds
            
            driver.Url = "https://w3schools.com";


            
           // IWebElement searchbtn = driver.FindElement(By.XPath());
           // searchbtn.Click();

            driver.ClickSearchBtn("\"//*[@id=\\\"pagetop\\\"]/div[3]/a[1]\"");
              
            var textboxUsername = driver.FindElement(By.Name("email"));
            var textboxPassword = driver.FindElement(By.Name("password"));

            textboxUsername.SendKeys("vjay.nvb@gmail.com");
            textboxPassword.SendKeys("P@ssw0rd123");


            IWebElement loginbtn = driver.FindElement(By.XPath("//*[@id=\"root\"]/div[2]/div/div[1]/div/div[2]/div/div[5]/div/form/div[3]/button[2]"));
            loginbtn.Click();//*[@id="root"]/div[2]/div/div[1]/div/div[2]/div/div[5]/div/form/div[3]/button[2]

            var errormsg = driver.FindElement(By.XPath("//*[@id='root']/div[2]/div/div[1]/div/div[2]/div/div[5]/div/form/div[2]"));
            Console.WriteLine(errormsg.Text);

            //driver.Close(); // is for closing the current tab
            //driver.Quit(); // is for closing the browser

        }
    }
}


