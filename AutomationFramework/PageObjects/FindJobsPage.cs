using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace AutomationFramework.PageObjects
{
    class FindJobsPage
    {
        private IWebDriver driver;
        public string findJobsURL = "https://www.indeed.ca/";
        public FindJobsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "jobsLink")]
        private IWebElement findJobsLink;

        [FindsBy(How = How.XPath, Using = "//*[text()=\"Find Salaries\"]")]
        private IWebElement findSalariesLink;

        [FindsBy(How = How.XPath, Using = "//*[text()=\"Company Reviews\"]")]
        private IWebElement companyReviewsLink;

        [FindsBy(How = How.Id, Using = "fj")]
        private IWebElement findJobsButton;

        [FindsBy(How = How.ClassName, Using = "sl")]
        private IWebElement advancedSearchLink;

        [FindsBy(How = How.Id, Using = "what")]
        private IWebElement whatTextField;

        [FindsBy(How = How.Id, Using = "where")]
        private IWebElement whereTextField;

        [FindsBy(How = How.ClassName, Using = "resume-promo-link")]
        private IWebElement uploadResumeLink;

        public CompanyReviewsPage GoToCompanyReviewPage()
        {
            companyReviewsLink.Click();
            return new CompanyReviewsPage(driver);
        }

        public FindSalariesPage GoToFindSalariesPage()
        {
            findJobsLink.Click();
            return new FindSalariesPage(driver);
        }

        public FindJobsPage GoToFindJobsPageByLink()
        {
            findJobsLink.Click();
            return new FindJobsPage(driver);
        }
        public FindJobsPage GoToFindJobsPage()
        {
            driver.Navigate().GoToUrl(findJobsURL);
            return new FindJobsPage(driver);
        }

        public void SearchForJobs(string jobTitle)
        {
            whatTextField.SendKeys(jobTitle);
            findJobsButton.Click();
            Assert.AreEqual(jobTitle, whatTextField.GetAttribute("value"));
        }
    }
}
