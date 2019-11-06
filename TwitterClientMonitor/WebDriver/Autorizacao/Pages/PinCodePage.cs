using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClientMonitor.WebDriver.Autorizacao.Pages
{
    public class PinCodePage
    {
        private IWebDriver WebDriver;

        public PinCodePage(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }

        public string GetPinCode()
        {
            return WebDriver.FindElement(By.XPath("//*[@id=\"oauth_pin\"]/p/kbd/code")).Text;
        }
    }
}
