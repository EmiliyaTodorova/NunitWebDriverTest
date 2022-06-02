using DocumentFormat.OpenXml.Spreadsheet;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTest
{
    public class SoftUniTests
        {
        private WebDriver driver;
        private int search;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }
        [Test]
        public void Test_AssertAboutUsPageTitle()
        {
            var zaNasElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            zaNasElement.Click();
            string expectedTitle = "За нас - Софтуерен университет";
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }
        [Test]
        public void Test_Search_PositiveResult()
        {
            driver.FindElement(By.CssSelector("#search-icon-container > a > span > i")).Click();

            var searchBox = driver.FindElement(By.CssSelector(".container > form #search-input"));
            searchBox.Click();
            searchBox.SendKeys("QA");
            searchBox.SendKeys(Keys.Enter);
            var resultField = driver.FindElement(By.CssSelector("body > div.content > div > div > h2")).Text;
            var expectedValue = "Резултати от търсене на “QA”";
            Assert.That(resultField, Is.EqualTo(expectedValue));
        }
        [Test]
        public void Test_SearchButtonBySeleniumID()
        {
            driver.FindElement(By.CssSelector(".cell > .fa")).Click();
            driver.FindElement(By.CssSelector(".container > form #search-input")).Click();
            driver.FindElement(By.CssSelector(".container > form #search-input")).SendKeys("QA");
            driver.FindElement(By.CssSelector(".container > form #search-input")).SendKeys(Keys.Enter);
            Assert.That(driver.FindElement(By.CssSelector(".search-title")).Text, Is.EqualTo("Резултати от търсене на “QA”"));
        }
            
    }
}