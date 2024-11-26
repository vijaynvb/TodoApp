using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium.pages
{
    internal class Carwale_NewCarsPage: Carwale_BasePage
    {
        public Carwale_NewCarsPage(IWebDriver driver) : base(driver)
        {
        }


        public Carwale_BMWCarsPage GotoBMW()
        {
            driver.FindElement(By.LinkText("BMW")).Click();

            return new Carwale_BMWCarsPage(driver);
        }

        public Carwale_ToyotaCarsPage GoToToyota()
        {
            driver.FindElement(By.LinkText("toyotacar")).Click();
           
            return new Carwale_ToyotaCarsPage(driver);
        }


        public Carwale_AudiCarsPage GotoAudi()
        {
            driver.FindElement(By.LinkText("audicar")).Click();

            return new Carwale_AudiCarsPage(driver);
        }

        public Carwale_KiaCarsPage GoToKia()
        {
            driver.FindElement(By.LinkText("kiacar")).Click();

            return new Carwale_KiaCarsPage(driver);

        }

    }
}
