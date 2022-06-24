using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FirstPrj
{
    public class WaitHelpers
    {
        private IWebDriver driver;

        public WaitHelpers(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public enum TimeSet
        {
            Default = 30,
            One = 1,
            Two = 2,
            Three = 3
        }

        protected bool CheckWebElementPresenceByXPath(string path, int countAttempts, int sleepTime = 500)
        {
            int currentAttempt = 0;
            SetImplicitWait((int)TimeSet.One);
            while (++currentAttempt < countAttempts)
            {
                IList<IWebElement> elements = driver.FindElements(By.XPath(path));
                if (elements.Any() && elements[0].Displayed)
                {
                    return true;
                }

                Thread.Sleep(sleepTime);
            }

            SetImplicitWait((int)TimeSet.Default);
            return false;
        }

        protected bool CheckWebElementPresenceByXPath(By locator, int countAttempts, int sleepTime = 500)
        {
            int currentAttempt = 0;
            SetImplicitWait((int)TimeSet.One);
            while (++currentAttempt < countAttempts)
            {
                IList<IWebElement> elements = driver.FindElements(locator);
                if (elements.Any() && elements[0].Displayed)
                {
                    return true;
                }

                Thread.Sleep(sleepTime);
            }

            SetImplicitWait((int)TimeSet.Default);
            return false;
        }

        protected bool CheckWebElementPresence(By locator, int countAttempts, int sleepTime = 500)
        {
            int currentAttempt = 0;
            SetImplicitWait((int)TimeSet.One);
            while (++currentAttempt < countAttempts)
            {
                IList<IWebElement> elements = driver.FindElements(locator);
                if (elements.Any() && elements[0].Displayed)
                {
                    return true;
                }

                Thread.Sleep(sleepTime);
            }

            SetImplicitWait((int)TimeSet.Default);
            return false;
        }

        protected void SetImplicitWait(int sec)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
        }

        private static bool WaitElementByState(int timeout, Func<bool> state)
        {
            for (int i = 0; i <= timeout;)
            {
                if (state())
                {
                    return true;
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
                i++;
            }

            return false;
        }

        public bool WaitUntilElementDisplayed(IWebElement element, int timeout, bool silent = false)
        {
            try
            {
                if (WaitElementByState(timeout, () => { return element.Displayed; }))
                    return true;

                if (!silent) throw new WebDriverTimeoutException($"element {element.TagName} not appeared after timeout {timeout} seconds");
            }
            catch (NoSuchElementException)
            {
                if (!silent) throw;
            }

            return false;
        }

        public bool WaitUntilElementNotDisplayed(IWebElement element, int timeout, bool silent = false)
        {
            try
            {
                if (WaitElementByState(timeout, () => { return !element.Displayed; }))
                    return true;

                if (!silent) throw new WebDriverTimeoutException($"element {element.TagName} not hidden after timeout {timeout} seconds");
            }
            catch (NoSuchElementException)
            {
                if (!silent) throw;
            }

            return false;
        }

        public bool IsExists(By locator)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            catch (WebDriverException)
            {
                return false;
            }

            return true;
        }

        public void WaitUntilElementClickable(IWebElement webElement)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(50)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
        }

        public void WaitUntilElementClickable(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitUntilElementVisible(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitUntilInvisible(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public bool WaitUntilTextToBePresentInElement(IWebElement element, string text)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, text));
            }
            catch (WebDriverException)
            {
                return false;
            }

            return true;
        }

        public void WaitUntilAlertIsPresent()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public void WaitUntilElementExists(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public void WaitUntilElementsClickable(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }

        public void WaitForLinkToContain(string linkElement)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(linkElement));
        }

        public void WaitForItemNotExists(By locator, int timeOutSec)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutSec)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void WaitUntilPageLoad()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitElementToBeClickable(IWebElement webElement, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }
    }
}
