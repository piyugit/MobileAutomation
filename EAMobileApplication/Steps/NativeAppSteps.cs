using AppiumEAFramework.Base;
using EAMobileApplication.Pages;
using Reqnroll;

namespace EAMobileApplication.Steps
{
    [Binding]
    public class NativeAppSteps
    {

        [Given(@"I enter the email and password as")]
        public void GivenIEnterTheEmailAndPasswordAs(Table table)
        {
            PageFactory.Instance.CurrentPage = new NativeAppPage();
            PageFactory.Instance.CurrentPage.As<NativeAppPage>().Login(table);
        }

        [Given(@"I perform slider operation")]
        public void GivenIPerformSliderOperation()
        {
            PageFactory.Instance.CurrentPage.As<NativeAppPage>().SelectPicker();
        }
    }
}
