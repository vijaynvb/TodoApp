using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace POMSelenium.utils
{
    public static class SeleniumCustomMethods
    {
        //1. Method should get the locator
        //2. Start getting the type of identifier
        //3. Perform operation on the locator

        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SelectDropDownByValue(this IWebElement locator, string value)
        {

            var selectElement = new SelectElement(locator);
            selectElement.SelectByValue(value);
        }

        public static void MultiSelectElements(this IWebElement locator, string[] values)
        {
            var multiSelect = new SelectElement(locator);
            foreach (var value in values)
            {
                multiSelect.SelectByValue(value);
            }
        }

        public static List<string> GetAllSelectedLists(this IWebElement locator)
        {
            var options = new List<string>();
            var multiSelect = new SelectElement(locator);
            var selectedOption = multiSelect.AllSelectedOptions;
            foreach (IWebElement option in selectedOption)
            {
                options.Add(option.Text);
            }
            return options;
        }
    }
}
