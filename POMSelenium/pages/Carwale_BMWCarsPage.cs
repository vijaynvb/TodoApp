using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium.pages
{
    internal class Carwale_BMWCarsPage
    {
        IWebDriver driver;

        public Carwale_BMWCarsPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void GetCarTitle()
        {

            Console.WriteLine("BMW Car Title");
        }
    }
}
