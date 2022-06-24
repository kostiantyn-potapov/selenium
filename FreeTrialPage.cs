using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace FirstPrj
{
    public class FreeTrialPage
    {
        Random random = new Random();

        private WaitHelpers waitHelpers;

        private IWebDriver driver;

        public FreeTrialPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            waitHelpers = new WaitHelpers(driver);
        }     

        [FindsBy(How = How.XPath, Using = "//*[@class='step__control step__control_forward'][contains(text(), 'No')]")]
        private IWebElement NoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'I’m looking for')]")]
        private IWebElement NewDesignSolution { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FirstName']")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='LastName']")]
        private IWebElement LasttName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Company']")]
        private IWebElement CompanyName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Email']")]
        private IWebElement Email { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='flag-container']")]
        private IWebElement Flag { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='country-name']")]
        private IWebElement FlagCountryName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Phone']")]
        private IWebElement Phone { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Country']")]
        private IWebElement Country { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='State']")]
        private IWebElement State { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='PostalCode']")]
        private IWebElement ZIP { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Evaluation_resaon__c']")]
        private IWebElement EvaluationReason { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Competitor_Tool__c']")]
        private IWebElement CompetitorTool { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Used_Altium_Designer__c']")]
        private IWebElement UsedAltiumDesigner { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Opt_In__c']")]
        private IWebElement CheckboxPrivacyPolicy { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Get')]")]
        private IWebElement GetFreeTrial { get; set; }

        [FindsBy(How = How.XPath, Using = "//iframe[@data-gtm-yt-inspected-1232471_178='true']")]
        private IWebElement IFrame { get; set; }

        public void AnswerTheQuestions()
        {
            waitHelpers.WaitElementToBeClickable(NoButton, 20);
            NoButton.Click();
            waitHelpers.WaitElementToBeClickable(NewDesignSolution, 20);
            NewDesignSolution.Click();
        }

        public void FillTheForm()
        {
            waitHelpers.WaitElementToBeClickable(FirstName, 20);
            SetMethods.Click(FirstName);
            SetMethods.EnterText(FirstName, "Kostiantyn");
            waitHelpers.WaitElementToBeClickable(LasttName, 20);
            SetMethods.Click(LasttName);
            SetMethods.EnterText(LasttName, "Potapov");
            waitHelpers.WaitElementToBeClickable(CompanyName, 20);
            SetMethods.Click(CompanyName);
            SetMethods.EnterText(CompanyName, "Test");
            waitHelpers.WaitElementToBeClickable(Email, 20);
            SetMethods.Click(Email);
            SetMethods.EnterText(Email, "kostiantyn.potapov+test@altium.com");
            //waitHelpers.WaitElementToBeClickable(Flag, 20);
            //SetMethods.Click(Flag);
            //waitHelpers.WaitElementToBeClickable(FlagCountryName, 20);
            //SetMethods.SelectDropdown(FlagCountryName, "United States");
            waitHelpers.WaitElementToBeClickable(Country, 20);
            SetMethods.Click(Country);
            SetMethods.SelectDropdown(Country, "UNITED STATES");
            waitHelpers.WaitElementToBeClickable(Phone, 20);
            SetMethods.Click(Phone);
            Phone.Clear();
            SetMethods.EnterText(Phone, "145345345345");
            waitHelpers.WaitElementToBeClickable(State, 20);
            SetMethods.SelectDropdown(State, "CA");
            waitHelpers.WaitElementToBeClickable(ZIP, 20);
            SetMethods.EnterText(ZIP, "91016");
            waitHelpers.WaitElementToBeClickable(EvaluationReason, 20);
            SetMethods.SelectDropdown(EvaluationReason, "I use a competitive solution and am curious what Altium Designer has to offer.");
            waitHelpers.WaitElementToBeClickable(CompetitorTool, 20);
            SetMethods.SelectDropdown(CompetitorTool, "Eagle");
            waitHelpers.WaitElementToBeClickable(UsedAltiumDesigner, 20);
            SetMethods.SelectDropdown(UsedAltiumDesigner, "Never");
            waitHelpers.WaitElementToBeClickable(CheckboxPrivacyPolicy, 20);
            SetMethods.Click(CheckboxPrivacyPolicy);
            waitHelpers.WaitElementToBeClickable(GetFreeTrial, 20);
            SetMethods.Click(GetFreeTrial);
        }

        public void SwitchToFrame()
        {
            driver.SwitchTo().Frame(IFrame);
        }

        public void SwitchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
