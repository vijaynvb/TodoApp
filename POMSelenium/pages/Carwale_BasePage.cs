using OpenQA.Selenium;
using PageObjectModelFramework.pageobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace POMSelenium.pages
{
    internal class Carwale_BasePage
    {
        public IWebDriver driver;

        public Carwale_BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
