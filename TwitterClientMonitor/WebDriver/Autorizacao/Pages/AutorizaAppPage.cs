using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClientMonitor.WebDriver.Autorizacao.Pages
{
    public class AutorizaAppPage
    {
        private IWebDriver WebDriver;

        public AutorizaAppPage(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }

        public PinCodePage Start(string url)
        {
            var usertwitter = ConfigurationManager.AppSettings["user-twitter"];

            var passwordtwitter = ConfigurationManager.AppSettings["password-twitter"];

            WebDriver.Navigate().GoToUrl(url);

            new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5));

            WebDriver.FindElement(By.XPath("//*[@id=\"username_or_email\"]")).SendKeys(usertwitter);

            WebDriver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys(passwordtwitter);

            WebDriver.FindElement(By.XPath("//*[@id=\"allow\"]")).Click();

            new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5));

            return new PinCodePage(this.WebDriver);
        }
    }
}
