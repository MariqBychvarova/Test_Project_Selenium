using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_POM
{
    public class BasePage
    {
       public   IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public virtual string PageURL { get; }

        public IWebElement LinkHomePage => driver.FindElement(By.XPath("//a[contains(text(),'Home')]"));

        public IWebElement LinkViewStudentsPage => driver.FindElement(By.XPath("//a[contains(text(),'View Students')]"));

        public IWebElement AddStudentPage => driver.FindElement(By.XPath("//a[contains(text(),'Add Student')]"));

        public IWebElement ElementPageHeading => driver.FindElement(By.CssSelector("h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(PageURL);
        }

        public bool IsOpen()
        {
            return driver.Url == PageURL;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetpageHeadingText()
        {
            return ElementPageHeading.Text;
        }

    }
}
