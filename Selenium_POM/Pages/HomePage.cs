using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_POM
{
   public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement StudentsCount => driver.FindElement(By.CssSelector("b"));
        
        public override string PageURL => "https://mvc-app-node-express.nakov.repl.co/";
      
        public void GetStudentsCount()
        {
            string count = StudentsCount.Text;
        }
    }
}
