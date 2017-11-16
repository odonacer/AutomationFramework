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
    class FindSalariesPage
    {
        //Declare instance vars for IWebDriver, page's url
        private IWebDriver driver;
        private string findJobsURL = "https://www.indeed.ca/"; 
        private string findSalariesPageURL = "https://www.indeed.ca/salaries?from=headercmplink&attributionid=homepage";
        public FindSalariesPage(IWebDriver driver)
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

        [FindsBy(How = How.Id, Using = "cmp-salary-search-submit")]
        private IWebElement searchSalariesButton;

        public void GoToFindSalariesPageByURL()
        {
            driver.Navigate().GoToUrl(findSalariesPageURL);
        }

       
    }
}
