using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium.pageobjects
{
    internal class W3CSchools_loginPage
    {
        IWebDriver driver;

        public W3CSchools_loginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement BtnLoginPage => driver.FindElement(By.XPath("//*[@id=\"pagetop\"]/div[3]/a[1]"));

        IWebElement TxtEmail => driver.FindElement(By.Name("email"));

        IWebElement TxtPassword => driver.FindElement(By.Name("password"));

        IWebElement BtnLogin => driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div[2]/div/div[5]/div/form/div[3]/button[2]"));

        public void ClickLogin()
        {
            BtnLoginPage.Click();
        }
        public void Login(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            // rememberme
            //captcha
            BtnLogin.Click();
        }
    }
}
