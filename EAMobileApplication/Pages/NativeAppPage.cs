using AppiumEAFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using Reqnroll;
using Reqnroll.Assist;
using Reqnroll.Assist.Dynamic;

namespace EAMobileApplication.Pages
{
    public class NativeAppPage : BasePage
    {

        IWebElement txtEmail => AppiumDriver.FindElement(MobileBy.AccessibilityId("email"));

        IWebElement txtPassword => AppiumDriver.FindElement(MobileBy.AccessibilityId("password"));

        IWebElement picker => AppiumDriver.FindElement(MobileBy.AccessibilityId("picker"));

        IWebElement pickerItem => AppiumDriver.FindElement(MobileBy.AccessibilityId("android:id/text1"));


        //public void Login(Table table)
        //{
        //    DriverFactory.Instance.WaitForElement(txtEmail);
        //    //dynamic data = table.CreateDynamicInstance();
        //    //txtEmail.SendKeys((string)data.Email);
        //    //txtPassword.SendKeys((string)data.Password);
        //}
        public void Login(Table table)
        {
            var data = table.CreateDynamicInstance();

            DriverFactory.Instance.WaitForElement(txtEmail);
            //update later
            //txtEmail.SendKeys((string)data);
            //txtPassword.SendKeys((string)data.Password);
        }
        public void SelectPicker()
        {
            picker.Click();
            pickerItem.Click();
        }

    }
}
