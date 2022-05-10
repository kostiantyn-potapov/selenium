using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FirstPrj
{
    public class MainPage
    {
        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Sign In')]")]
        private IWebElement SignIn { get; set; }

        public void New()
        {
            new WaitHelpers().WaitUntilElementClickable(SignIn);
        }
    }
}
