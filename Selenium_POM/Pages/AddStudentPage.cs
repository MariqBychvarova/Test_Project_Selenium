using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_POM
{
    public class AddStudentPage : BasePage
    {
       

        public AddStudentPage(IWebDriver driver) :base(driver)
        {

        }

        public IWebElement ElementErrorMessage => driver.FindElement(By.CssSelector("body > div"));

        public IWebElement FieldStudentName => driver.FindElement(By.CssSelector("#name"));

        public IWebElement FieldStudentEmail => driver.FindElement(By.CssSelector("#email"));

        public IWebElement AddButton => driver.FindElement(By.CssSelector("button"));

        public override string PageURL => "https://mvc-app-node-express.nakov.repl.co/add-student";

        public void AddStudent(string name,string email)
        {
            FieldStudentName.SendKeys(name);
            FieldStudentEmail.SendKeys(email);
            AddButton.Click();
        }

        public string DisplayErrorMessage()
        {
            AddButton.Click();
            string message = ElementErrorMessage.Text;
            return message;
        }
       
    }
}
