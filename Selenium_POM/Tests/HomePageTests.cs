using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_POM
{
   public class HomePageTests : BasePageTests
    {
       
        [Test]
        public void Test_Home_Page_Content()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Open();

            Assert.AreEqual("MVC Example", homePage.GetPageTitle());
            Assert.AreEqual("Students Registry", homePage.GetpageHeadingText());

            homePage.GetStudentsCount();
        }

        [Test]
        public void Test_Home_Page_Links()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Open();
            homePage.LinkHomePage.Click();

            Assert.IsTrue(new HomePage(driver).IsOpen());
        }

        [Test]
        public void Test_View_Students_Page_Link()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Open();
            homePage.LinkViewStudentsPage.Click();

            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_Add_Student_Page_Link()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Open();
            homePage.AddStudentPage.Click();

            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }
    }
}
