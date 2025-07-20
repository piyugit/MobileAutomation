using AppiumEAFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace EAMobileApplication.Pages
{
    class HomePage : BasePage
    {
        public IWebElement btnMenu => AppiumDriver.FindElement(By.XPath("//ion-menu-button"));

        public IWebElement menuLogin => AppiumDriver.FindElement(By.XPath("//ion-label[text()=' Login ']"));

        public IWebElement menuLogout => AppiumDriver.FindElement(By.XPath("//ion-label[text()=' Logout ']"));

        public IWebElement menuSchedule => AppiumDriver.FindElement(By.XPath("//ion-label[text()=' Schedule ']"));

        public IWebElement menuSpeakers => AppiumDriver.FindElement(By.XPath("//ion-label[text()=' Speakers ']"));

        public IWebElement lblHomePageHeader => AppiumDriver.FindElement(By.XPath("//ion-title[text()='Schedule']"));

        public IWebElement tabSpeakers => AppiumDriver.FindElement(By.XPath("//ion-label[text()='Speakers']"));

        internal bool IsLogoutExist() => menuLogout.Displayed;




        public bool IsSchedulePage()
        {
            Thread.Sleep(5000);
            return lblHomePageHeader.Displayed;
        }


        public LoginPage ClickLogin()
        {
            menuLogin.Click();
            return GetInstance<LoginPage>();
        }

        public void ClickBreadCrumb()
        {
            btnMenu.Click();
        }

    }
}
