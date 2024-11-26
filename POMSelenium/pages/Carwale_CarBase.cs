using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class Carwale_CarBase
    {

        IWebDriver driver;


        public Carwale_CarBase(IWebDriver driver)
        {

            this.driver = driver;
        }


        public string GetCarTitle()
        {

            return BasePage.keyword.GetText("CarBase", "cartitle", "XPATH");

        }



        public void GetCarNameAndPrice()
        {

            for(int i = 0; i<BasePage.keyword.FindElements("CarBase", "carprice", "XPATH").Count; i++)
            {

                Console.WriteLine(BasePage.keyword.FindElements("CarBase", "carname", "XPATH")[i].Text +"----Car price is : "+ BasePage.keyword.FindElements("CarBase", "carprice", "XPATH")[i].Text);

            }

        }



    }
}
