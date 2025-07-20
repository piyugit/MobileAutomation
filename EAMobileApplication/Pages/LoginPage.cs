using System.Threading;
using AppiumEAFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace EAMobileApplication.Pages
{
    class LoginPage : BasePage
    {

        IWebElement txtEmail => AppiumDriver.FindElement(By.XPath("//ion-input[@ng-reflect-name='username']/input"));

        IWebElement txtPassword => AppiumDriver.FindElement(By.XPath("//ion-input[@ng-reflect-name='password']/input"));

        IWebElement btnLogin => AppiumDriver.FindElement(By.XPath("//ion-button[text()='Login']"));

        internal void Login(string email, string password)
        {
            Thread.Sleep(2000);
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
            AppiumDriver.HideKeyboard();
        }

        internal HomePage ClickLoginIn()
        {
            btnLogin.Click();
            return GetInstance<HomePage>();
        }

        public bool IsLoginPageExist()
        {
            return txtEmail.Displayed;
        }

    }
}
