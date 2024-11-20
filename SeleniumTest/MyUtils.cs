using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    public static class MyUtils
    {
        // extension methods
        public static void ClickSearchBtn(this IWebDriver driver, string buttonId)
        {
            IWebElement searchbtn = driver.FindElement(By.XPath(buttonId));
            searchbtn.Click();
        }
    }
}
