using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace FirstPrj
{
    class UnitTest1
    {

        IWebDriver driver = new ChromeDriver(@"/Users/kostiantyn.potapov/Projects/FirstPrj/bin/Debug");

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("http://altium.com");
        }

        [Test]
        public void MainPageLoad()
        {
            
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            // Wait for the required any element (I am waiting for Login button in fb)
            //IWebElement element = webdriver.FindElement(By.XPath("//*[contains(text(), 'Sign In')]"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var element1 = wait.Until(webdriver => webdriver.FindElement(By.XPath("//*[contains(text(), 'Sign In')]")));

            stopWatch.Stop();
            int tsActual = stopWatch.Elapsed.Seconds;
            int tsExpected = 1;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //ts.Hours, ts.Minutes, ts.Seconds,
            //ts.Milliseconds / 10);
            NUnit.Framework.Assert.IsTrue(tsActual < tsExpected, $"Page is loaded in the time longer than expected. " + $"Expected: {tsExpected}sec, Measured: {tsActual}sec");
        }

        [Test]
        public void FreeTrials()
        {
            driver.Navigate().GoToUrl("https://www.altium.com/altium-trial-flow");
            /*WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var element1 = wait.Until(webdriver => webdriver.FindElement(By.XPath("//*[contains(@data-go-to-step, '5')]")));
            element1.Click();
            var element2 = wait.Until(webdriver => webdriver.FindElement(By.XPath("//*[contains(text(), 'I’m looking for')]")));
            element2.Click();
            var form = wait.Until(webdriver => webdriver.FindElement(By.XPath("//*[contains(@id, 'instructionsText')]")));*/
            SetMethods.Click(driver, "//*[contains(@data-go-to-step, '5')]", "XPath");
            SetMethods.Click(driver, "//*[contains(text(), 'I’m looking for')]", "Xpath");
            SetMethods.EnterText(driver, "//*[@id='FirstName']", "FirstBanan", "Id");
            SetMethods.EnterText(driver, "//*[@id='LastName']", "LastBanan", "Id");
            SetMethods.EnterText(driver, "//*[@id='Company']", "27042022Company", "Id");
            SetMethods.EnterText(driver, "//*[@id='Email']", "kostiantyn.potapov+test27042022", "Id");
            SetMethods.EnterText(driver, "//*[@id='Phone']", "12121212", "Id");
            SetMethods.Click(driver, "//*[@id='Country']", "Id");
            SetMethods.SelectDropdown(driver, "//*[contains(@value, 'ALBANIA')]", "ALBANIA", "XPath");
            SetMethods.Click(driver, "//*[@id='Evaluation_resaon__c']", "Id");
            SetMethods.Click(driver, "//*[contains(text(), 'I use')]", "XPath");
            SetMethods.Click(driver, "//*[@id='Competitor_Tool__c']", "Id");
            SetMethods.SelectDropdown(driver, "//*[contains(text(), 'DipTrace')]", "DipTrace", "XPath");
            SetMethods.Click(driver, "//*[@id='Used_Altium_Designer__c']", "Id");
            SetMethods.SelectDropdown(driver, "//*[contains(text(), 'Never')]", "Never", "XPath");
            SetMethods.Click(driver, "//*[@type='submit']", "XPath");
            Thread.Sleep(5000);
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Close();
        }
    }
}
