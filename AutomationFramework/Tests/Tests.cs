using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using AutomationFramework.PageObjects;

namespace AutomationFramework.Tests
{
    class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchForJob()
        {
            FindJobsPage findJobs = new FindJobsPage(driver);
            findJobs.GoToFindJobsPage();
            findJobs.SearchForJobs("QA");
        }

        [Test]
        public void SearchForACompanyReview()
        {
            CompanyReviewsPage companyReviewPage = new CompanyReviewsPage(driver);
            companyReviewPage.GoToCompanyReviewPage();
            companyReviewPage.SearchForACompanyReview("Manitoba Hydro");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
