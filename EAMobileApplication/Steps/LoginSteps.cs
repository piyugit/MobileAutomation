using AppiumEAFramework.Base;
using EAMobileApplication.Pages;
using NUnit.Framework;
using Reqnroll;
using Reqnroll.Assist.Dynamic;

namespace EAMobileApplication.Steps
{

    [Binding]
    public class LoginSteps : BaseStep
    {
        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I skip the welcome splash screen")]
        public void GivenISkipTheWelcomeSplashScreen()
        {
            PageFactory.Instance.CurrentPage = GetInstance<SplashPage>();
            PageFactory.Instance.CurrentPage = PageFactory.Instance.CurrentPage.As<SplashPage>().SkipWelcome();
        }

       

        [Then(@"I see the user login screen")]
        public void ThenISeeTheUserLoginScreen()
        {
            Assert.That(PageFactory.Instance.CurrentPage.As<LoginPage>().IsLoginPageExist(), Is.True, "Its not a login page");
        }

        [Then(@"I enter the username and password as")]
        public void ThenIEnterTheUsernameAndPasswordAs(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            PageFactory.Instance.CurrentPage.As<LoginPage>().Login((string)data.UserName, (string)data.Password);
        }

        [When(@"I click the Login button")]
        public void WhenIClickTheLoginButton()
        {
            PageFactory.Instance.CurrentPage = PageFactory.Instance.CurrentPage.As<HomePage>().ClickLogin();
        }

        [Then(@"I see the schedule page")]
        public void ThenISeeTheSchedulePage()
        {
            PageFactory.Instance.CurrentPage.As<HomePage>().IsSchedulePage();
        }

        [When(@"I click the breadcrumb menu button")]
        public void WhenIClickTheBreadcrumbMenuButton()
        {
            PageFactory.Instance.CurrentPage.As<HomePage>().ClickBreadCrumb();
        }

        [Then(@"I click the login button")]
        public void ThenIClickTheLoginButton()
        {
            PageFactory.Instance.CurrentPage = PageFactory.Instance.CurrentPage.As<LoginPage>().ClickLoginIn();
        }

    }
}
