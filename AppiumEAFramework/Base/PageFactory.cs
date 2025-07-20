namespace AppiumEAFramework.Base
{
    public class PageFactory
    {

        private static Lazy<PageFactory> _instance = new Lazy<PageFactory>(() => new PageFactory());

        public static PageFactory Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private PageFactory() { }


        public BasePage CurrentPage { get; set; }

    }
}
