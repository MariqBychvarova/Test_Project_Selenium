using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

public class SeleniumTests
{
    IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [TearDown]
    public void ShutDown()
    {
        driver.Quit();
    }

    [Test]
    public void SearchQaInWikiPedia()
    {
        driver.Url = "https://www.wikipedia.org/";
        driver.FindElement(By.Id("searchInput")).SendKeys("QA");
        driver.FindElement(By.Id("searchInput")).SendKeys(Keys.Enter);
    }

    [Test]
    public void AddTwoNumbers_Valid()
    {
        driver.Url = "https://sum-numbers.nakov.repl.co";       
        driver.FindElement(By.Id("number1")).SendKeys("5");       
        driver.FindElement(By.Id("number2")).SendKeys("3");
        driver.FindElement(By.Id("calcButton")).Click();
        string result= driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual("Sum: 8", result);
    }

    [Test]
    public void AddTwoNumbers_Invalid()
    {
        driver.Url = "https://sum-numbers.nakov.repl.co";
        driver.FindElement(By.Id("number1")).SendKeys("hello");
        driver.FindElement(By.Id("number2")).SendKeys("bye");
        driver.FindElement(By.Id("calcButton")).Click();
        string result = driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual(result, "Sum: invalid input");
    }

    [Test]
    public void CheckResetButton()
    {
        driver.Url = "https://sum-numbers.nakov.repl.co";
        driver.FindElement(By.Id("number1")).SendKeys("5");
        driver.FindElement(By.Id("number2")).SendKeys("3");
        driver.FindElement(By.Id("calcButton")).Click();
        driver.FindElement(By.Id("resetButton")).Click();
        string number1Field = driver.FindElement(By.Id("number1")).Text;
        string number2Field = driver.FindElement(By.Id("number2")).Text;
        Assert.AreEqual(number1Field, string.Empty);
        Assert.AreEqual(number2Field, string.Empty);
    }
}
