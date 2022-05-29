using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_POM
{
    public class ViewStudentsPage_Tests: BasePageTests
    {
        [Test]
        public void Test_View_Students_Page_Content()
        {
            ViewStudentsPage studentsPage = new ViewStudentsPage(driver);
            studentsPage.Open();

            Assert.AreEqual("Students", studentsPage.GetPageTitle());
            Assert.AreEqual("Registered Students", studentsPage.GetpageHeadingText());
        }

        [Test]
        public void Test_Students_String()
        {
            ViewStudentsPage studentsPage = new ViewStudentsPage(driver);
            studentsPage.Open();
            string[] students = studentsPage.GetRegisteredStudents();

            foreach (var student in students)
            {
                Assert.That(student.IndexOf('(') > 0);
                Assert.That(student.EndsWith(')'));
            }
        }

        [Test]
        public void Test_Home_Page_Link()
        {
            ViewStudentsPage studentsPage = new ViewStudentsPage(driver);
            studentsPage.Open();
            studentsPage.LinkHomePage.Click();

            Assert.That(new HomePage(driver).IsOpen());
        }

        [Test]
        public void Test_Add_Student_Page_Link()
        {
            ViewStudentsPage studentsPage = new ViewStudentsPage(driver);
            studentsPage.Open();
            studentsPage.AddStudentPage.Click();

            Assert.That(new AddStudentPage(driver).IsOpen());
        }
    }
}
