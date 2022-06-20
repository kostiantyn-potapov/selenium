using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FirstPrj
{
    public class SetMethods
    {
        //Enter text
        public static void EnterText(IWebElement webElement, string value)
        {
            webElement.SendKeys(value);
        }
        //Click into a button
        public static void Click(IWebElement webElement)
        {
            //WaitHelpers waitHelpers = new WaitHelpers();
            //waitHelpers.WaitUntilElementDisplayed(webElement, 20);
            webElement.Click();
        }
        //Selecting a drop down control
        public static void SelectDropdown(IWebElement webElement, string text)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }
    }
}
