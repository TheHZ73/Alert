using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace Alert
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            string directoryForChromeDriver = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(directoryForChromeDriver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

        [Test]
        public void TestAlert()
        {
            driver.Navigate().GoToUrl(@"http://way2automation.com/way2auto_jquery/alert.php");

            string login = "TheHZ";
            string password = "Wizard73";
            var loginForm = new LoginForm(driver);
            loginForm.Login(login, password);

            var page = new Pages(driver);
            page.OpenAlertPage();
            page.OpenWindowEnterTextAlert();

            string inputInAlertText = "Текст для ввода и проверки";
            page.SetTextInAlert(inputInAlertText);
            Assert.True(page.CheckInputText(inputInAlertText));
        }
    }
}

