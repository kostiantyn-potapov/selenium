using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FirstPrj
{
    public class SetMethods
    {
        //Enter text
        public static void EnterText(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "XPath")
            {
                driver.FindElement(By.XPath(element)).SendKeys(value);
            }
            if (elementType == "Id")
            {
                driver.FindElement(By.Id(element)).SendKeys(value);
            }
        }
        //Click into a button
        public static void Click(IWebDriver driver, string element, string elementType)
        {
            if (elementType == "XPath")
            {
                driver.FindElement(By.XPath(element)).Click();
            }
        }
        //Selecting a drop down control
        public static void SelectDropdown(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "XPath")
            {
                new SelectElement(driver.FindElement(By.XPath(element))).SelectByText(value);
            }
            if (elementType == "Id")
            {
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
            }
        }
    }
}
