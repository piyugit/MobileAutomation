using AppiumEAFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace EAMobileApplication.Pages
{
    class SplashPage : BasePage
    {
        public IWebElement btnSkip => AppiumDriver.FindElement(By.XPath("//ion-button[text()='Skip']"));
        public IWebElement btnSkip2(string text) => AppiumDriver.FindElement(MobileBy.AndroidUIAutomator($"new UiSelector().text(\"{text}\")"));
        

        internal HomePage SkipWelcome()
        {
            btnSkip.Click();
            return GetInstance<HomePage>();
        }
    }
}
