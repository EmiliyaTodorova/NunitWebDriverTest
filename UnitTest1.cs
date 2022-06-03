using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTest
    {
        private ChromeDriver driver;
        IWebElement field1;
        IWebElement field2;
        IWebElement operation;
        IWebElement calculate;
        IWebElement resultField;
        IWebElement clearField;

       [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
            field1 = driver.FindElement(By.Id("number1"));
            field2 = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculate = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            clearField = driver.FindElement(By.Id("resetButton"));
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [TestCase("5", "6", "+", "Result: 11")]
        [TestCase("15", "9", "-", "Result: 6")]
        [TestCase("2", "2", "*", "Result: 4")]
        [TestCase("6", "3", "/", "Result: 2")]
        [TestCase("", "", "/", "Result: invalid input")]
        public void TestCalculator(string num1, string num2, string operato, string result)
        {
            field1.SendKeys(num1);
            operation.SendKeys(operato);
            field2.SendKeys(num2);
            calculate.Click();
            string expectedValue = result;
            Assert.That(expectedValue, Is.EqualTo(resultField.Text));
            clearField.Click();
        }
    }
}