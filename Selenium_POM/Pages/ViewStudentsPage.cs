using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Selenium_POM
{
   public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) :base(driver)
        {

        }

        public ReadOnlyCollection<IWebElement> ListOfStudents => driver.FindElements(By.CssSelector("body > ul > li"));
        
        public override string PageURL => "https://mvc-app-node-express.nakov.repl.co/students";

        public string[] GetRegisteredStudents()
        {
            string[] listOfStudents = ListOfStudents.Select(x => x.Text).ToArray();
            return listOfStudents;
        }
        
    }
}
