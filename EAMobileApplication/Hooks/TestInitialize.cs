using AppiumEAFramework.Base;
using AppiumEAFramework.Config;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace EAMobileApplication.Hooks
{
    [Binding]
    public class TestInitialize
    {

       [BeforeScenario]
        public void InitializeTest()
        {
            //Initialize Settings
            ConfigReader.InitializeSettings();

            DriverFactory.Instance.InitializeAppiumDriver<AppiumDriver>(MobileType.Hybrid);
//            DriverFactory.Instance.InitializeAppiumDriver(
//    MobileType.Hybrid,
//    "Android",
//    "emulator-5554",
//    "/path/to/app.apk",
//    "/path/to/chromedriver"
//);
        }

        [TearDown]
        public void CleanUp()
        {
            DriverFactory.Instance.CloseApp();
        }


    }
}
