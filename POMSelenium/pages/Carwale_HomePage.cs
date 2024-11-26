using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium.pages
{
    internal class Carwale_HomePage: Carwale_BasePage
    {
        public Carwale_HomePage(IWebDriver driver) : base(driver)
        {
        }

        public Carwale_NewCarPage FindNewCars()
        {
            IWebElement newCar = driver.FindElement(By.XPath("//div[normalize-space()='NEW CARS']"));
            new Actions(driver).MoveToElement(newCar).Perform();
            driver.FindElement(By.XPath("//div[normalize-space()='Find New Cars']")).Click();

            return new Carwale_NewCarPage(driver);

        }



        public void SearchCars()
        {

        }



        public void GoToTrendingCars()
        {

        }



        public void GoToFeaturedCars()
        {

        }
    }
}
