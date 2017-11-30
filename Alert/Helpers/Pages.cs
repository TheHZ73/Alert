using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Alert
{
    class Pages
    {
        private IWebDriver driver;
        private By inputAlertTab = By.XPath("//a[contains(text(),'Input Alert')]");
        private By alertButton = By.XPath(
            "//button[contains(text(), 'Click the button to demonstrate the Input box')]");
        private By checkText = By.Id("demo");
        private By imageAlert = By.XPath("//img[@src=\"images/simple_alert.jpg\"]");

        public Pages(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenWindowEnterTextAlert()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(inputAlertTab));
            driver.FindElement(inputAlertTab).Click();
            driver.SwitchTo().Frame(1);
            driver.FindElement(alertButton).Click();
        }

        public void OpenAlertPage()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(imageAlert));
            driver.FindElement(imageAlert).Click();
        }

        public void SetTextInAlert(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();
        }

        public bool CheckInputText(string text)
        {
            return driver.FindElement(checkText).Text.Contains(text);
        }
    }
}
