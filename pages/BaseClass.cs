using OpenQA.Selenium;

namespace iLabJobs.pages
{
    public class BaseClass
    {
        public static IWebDriver driver = null;
        public static bool TestResult;

        public BaseClass(IWebDriver driver)
        {
            BaseClass.driver = driver;
            BaseClass.TestResult = true;
        }

    }
}