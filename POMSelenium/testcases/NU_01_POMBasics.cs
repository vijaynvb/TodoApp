using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMSelenium.pageobjects;

namespace POMSelenium.testcases
{
    internal class NU_01_POMBasics // homepage
    {
        [Test]
        public void TestWithoutPOM()
        {
            // 1.Create a new instance of Selenium web Driver
            // 2. Navigate to the URL
            // 3. Find and Click the Login link
            // 4. Find the UserName text box
            // 5. Find the Password text box
            // 6. Click Submit 9

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.w3schools.com/";
            // chaing of methods 
            driver.FindElement(By.XPath("//*[@id=\"pagetop\"]/div[3]/a[1]")).Click();
            driver.FindElement(By.Name("email")).SendKeys("vijay.nvb@gmail.com");
            driver.FindElement(By.Name("password")).SendKeys("password");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[2]/div/div[5]/div/form/div[3]/button[2]")).Click();
        }

        [Test]
        public void TestWithPOM()
        {
            // use the page object model W3CSchools_loginPage to perform the same actions
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.w3schools.com/";
            W3CSchools_loginPage loginPage = new W3CSchools_loginPage(driver);
            loginPage.ClickLogin();
            loginPage.Login("vijay.nvb@gmail.com", "password");
        }
    }
}
