using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium_POM.Tests
{
    public class AddStudentPage_Tests:BasePageTests
    {
        [Test]
        public void Test_Add_Student_Page_Content()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            Assert.AreEqual("Add Student", addStudentPage.GetPageTitle());
            Assert.AreEqual("Register New Student", addStudentPage.GetpageHeadingText());
            Assert.AreEqual(string.Empty, addStudentPage.FieldStudentName.Text);
            Assert.AreEqual(string.Empty, addStudentPage.FieldStudentEmail.Text);
            Assert.AreEqual("Add", addStudentPage.AddButton.Text);
        }

       [Test]
       public void Test_Add_Students_Home_Link()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            addStudentPage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen());
        }

        [Test]
        public void Test_Add_Student_Page_View_Student_Link()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();
            addStudentPage.LinkViewStudentsPage.Click();

            Assert.That(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_Add_Valid_Student()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();
            string name = "New student" + DateTime.Now.Ticks;
            string email = "email" + DateTime.Now.Ticks + "@email.com";
            addStudentPage.AddStudent(name, email);

            ViewStudentsPage viewStudents = new ViewStudentsPage(driver);
            viewStudents.Open();

            Assert.That(new ViewStudentsPage(driver).IsOpen());

            string[] listOfStudents = viewStudents.GetRegisteredStudents();
            string newStudent = listOfStudents[listOfStudents.Length - 1];

            Assert.AreEqual(newStudent, $"{name} ({email})");                   
        }

        [Test]
        public void Test_Add_Invalid_Student()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();
            string name = string.Empty;
            string email = string.Empty;
            addStudentPage.AddStudent(name, email);
            string message = addStudentPage.DisplayErrorMessage();

            Assert.That(new AddStudentPage(driver).IsOpen());
            Assert.AreEqual(addStudentPage.ElementErrorMessage.Text, message);

        }

    }
}
