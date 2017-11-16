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
    class CompanyReviewsPage
    {
        private IWebDriver driver;
        private string companyReviewPageURL = "https://www.indeed.ca/Best-Places-to-Work?from=headercmplink&attributionid=";
        public CompanyReviewsPage(IWebDriver driver)
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

        [FindsBy(How = How.Id, Using = "cmp-discovery-cs-submit")]
        private IWebElement searchCompanyReviewButton;

        [FindsBy(How = How.Id, Using = "search-by-company-input")]
        private IWebElement companyReviewTextField;

        public CompanyReviewsPage GoToCompanyReviewPage()
        {
            driver.Navigate().GoToUrl(companyReviewPageURL);
            return new CompanyReviewsPage(driver);
        }

        public void SearchForACompanyReview(string companyName)
        {
            companyReviewTextField.SendKeys(companyName);
            searchCompanyReviewButton.Click();
            Assert.AreEqual(companyName, companyReviewTextField.GetAttribute("value"));
            Assert.AreEqual(companyName, driver.FindElement(By.LinkText(companyName)).Text);
        }
    }
}
