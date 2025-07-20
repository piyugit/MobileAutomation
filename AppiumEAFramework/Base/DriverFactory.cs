using AppiumEAFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Support.UI;

namespace AppiumEAFramework.Base
{
    public enum MobileType
    {
        Native,
        Hybrid
    }

    public enum PlatformName
    {
        Android,
        iOS
    }

    public class DriverFactory
    {
        private AppiumLocalService _appiumLocalService;

        private static readonly Lazy<DriverFactory> _instance = new(() => new DriverFactory());

        public static DriverFactory Instance => _instance.Value;

        private DriverFactory() { }

        // Use non-generic AppiumDriver for Appium 8+
        public AppiumDriver AppiumDriver { get; private set; }

        public void InitializeAppiumDriver<T>(MobileType mobileType) where T : AppiumDriver
        {
            var driverOptions = new AppiumOptions
            {
                PlatformName = Settings.PlatformName,
                DeviceName = Settings.DeviceName,
                AutomationName = "UiAutomator2",
                App= Settings.AUTPath
            };
            //var driverOptions = new AppiumOptions();
            //driverOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformName, Settings.PlatformName);
            //driverOptions.AddAdditionalAppiumOption( Settings.DeviceName);
            //driverOptions.AddAdditionalAppiumOption(MobileCapabilityType.App, Settings.AUTPath);
            driverOptions.AddAdditionalAppiumOption("chromedriverExecutable", Settings.ChromeDriverPath);

            var builder = StartAppiumLocalService();

            AppiumDriver = new AndroidDriver(builder, driverOptions);

            if (mobileType == MobileType.Hybrid)
            {
                var contexts = ((IContextAware)AppiumDriver).Contexts;
                string webviewContext = null;

                for (var i = 0; i < contexts.Count; i++)
                {
                    Console.WriteLine(contexts[i]);
                    if (contexts[i].Contains("WEBVIEW"))
                    {
                        webviewContext = contexts[i];
                        break;
                    }
                }

                ((IContextAware)AppiumDriver).Context = webviewContext;
            }

        }


        private AppiumLocalService StartAppiumLocalService()
        {
            _appiumLocalService = new AppiumServiceBuilder()
                .UsingAnyFreePort()
                .Build();

            if (!_appiumLocalService.IsRunning)
                _appiumLocalService.Start();

            return _appiumLocalService;
        }

        private void SwitchToWebViewContext()
        {
            if (AppiumDriver is IContextAware contextAware)
            {
                var contexts = contextAware.Contexts;
                foreach (var context in contexts)
                {
                    Console.WriteLine(context);
                    if (context.Contains("WEBVIEW"))
                    {
                        contextAware.Context = context;
                        break;
                    }
                }
            }
        }

        public void CloseApp()
        {
            AppiumDriver?.Close();
        }

        public void WaitForElement(IWebElement element, int timeoutInSeconds = 15)
        {
            var wait = new DefaultWait<AppiumDriver>(AppiumDriver)
            {
                Timeout = TimeSpan.FromSeconds(timeoutInSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(_ => element.Displayed);
        }
    }
}
