using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class EbayTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://www.ebay.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
             }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheEbayTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("gh-ac")).Click();
            driver.FindElement(By.Id("gh-ac")).Clear();
            driver.FindElement(By.Id("gh-ac")).SendKeys("iphone 7");
            driver.FindElement(By.Id("gh-btn")).Click();
            driver.FindElement(By.LinkText("Buy It Now")).Click();
            driver.FindElement(By.LinkText("Best Match")).Click();
            driver.FindElement(By.LinkText("Price + Shipping: lowest first")).Click();
            driver.FindElement(By.XPath("//img[@alt='Apple iPhone 4 8GB Black Sprint 7.1.2']")).Click();
            driver.FindElement(By.Id("viTabs_1")).Click();
            driver.FindElement(By.Id("shZipCode")).Clear();
            driver.FindElement(By.Id("shZipCode")).SendKeys("30044");
            driver.FindElement(By.Id("shGetRates")).Click();
            driver.FindElement(By.Id("gh-logo")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
