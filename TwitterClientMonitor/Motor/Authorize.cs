using CoreTweet;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClientMonitor.WebDriver.Autorizacao.Pages;

namespace TwitterClientMonitor.Motor
{
    public class Authorize
    {
        public readonly string consumer_key;
        public readonly string consumer_secret;
        private bool IsAuthorize = false;

        public Authorize(string consumer_key, string consumer_secret)
        {
            this.consumer_key = consumer_key;
            this.consumer_secret = consumer_secret;
        }

        public Tokens AuthorizeService()
        {
            //session.AuthorizeUri.AbsoluteUri Acessar URL e autorizar o app depois bastar pegar o Pin que é gerado
            IWebDriver webDriver = new ChromeDriver("WebDriver/Driver");
            AutorizaAppPage autorizaAppPage = new AutorizaAppPage(webDriver);
            var session = OAuth.Authorize(this.consumer_key, this.consumer_secret);
            var PIN_CODE = autorizaAppPage.Start(session.AuthorizeUri.AbsoluteUri).GetPinCode();
            var tokens = OAuth.GetTokens(session, PIN_CODE);
            
            if (tokens != null)
            {
                IsAuthorize = true;
                return tokens;
            }

            IsAuthorize = false;
            return tokens;
        }

        public bool AuthorizeIsValid()
        {
            return this.IsAuthorize;
        }
    }
}
