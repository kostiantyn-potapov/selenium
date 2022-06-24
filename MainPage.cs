using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FirstPrj
{
    public class MainPage
    {
        private WaitHelpers waitHelpers;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            waitHelpers = new WaitHelpers(driver);
        }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Sign In')]")]
        private IWebElement SignIn { get; set; }

        public void SignInButtonIsClicable()
        {
            //new WaitHelpers().WaitUntilElementClickable(SignIn);
            waitHelpers.WaitElementToBeClickable(SignIn, 20);
        }
    }
}
