using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace iLabJobs.pages
{
    public class BaseClass
    {
        public static IWebDriver driver = null;
        public static bool TestResult;
        public static ExtentTest test;

        public BaseClass(IWebDriver driver, ExtentTest test)
        {
            BaseClass.driver = driver;
            BaseClass.test = test;
        }
    }
}