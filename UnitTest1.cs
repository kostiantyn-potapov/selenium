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
        IWebDriver driver = new ChromeDriver(@"/Users/kostiantyn.potapov/Projects/selenium/bin/Debug");

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("http://altium.com");
        }

        [Test]
        public void MainPageLoad()
        {
            MainPage mainPage = new MainPage(driver);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            mainPage.SignInButtonIsClicable();

            stopWatch.Stop();
            int tsActual = stopWatch.Elapsed.Seconds;
            int tsExpected = 1;

            NUnit.Framework.Assert.IsTrue(tsActual < tsExpected, $"Page is loaded in the time longer than expected. " + $"Expected: {tsExpected}sec, Measured: {tsActual}sec");
        }

        [Test]
        public void FreeTrials()
        {
            driver.Navigate().GoToUrl("https://www.altium.com/altium-trial-flow");
            FreeTrialPage freeTrialPage = new FreeTrialPage(driver);
            freeTrialPage.ClickNoButton();
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Close();
        }
    }
}
