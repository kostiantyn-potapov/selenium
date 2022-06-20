using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace FirstPrj
{
    public class FreeTrialPage
    {
        public FreeTrialPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        WaitHelpers waitHelpers = new WaitHelpers();

        [FindsBy(How = How.XPath, Using = "//*[@class='step__control step__control_forward'][contains(text(), 'No')]")]
        public IWebElement NoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'I’m looking for')]")]
        private IWebElement NewDesignSolution { get; set; }

        public void ClickNoButton()
        {
            waitHelpers.WaitElementToBeClickable(NoButton, 20);
            NoButton.Click();
        }
    }
}
