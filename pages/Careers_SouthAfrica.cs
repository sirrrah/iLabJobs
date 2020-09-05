using System;
using iLabJobs.utilities;
using OpenQA.Selenium;

namespace iLabJobs.pages
{
    public class Careers_SouthAfrica : BaseClass
    {
        private static IWebElement element;

        public Careers_SouthAfrica(IWebDriver driver) : base(driver) { }

        public static IWebElement Link_FirstPost()
        {
            try
            {
                element = driver.FindElement(By.XPath("//*[@class='wpjb-job-list wpjb-grid']/div[1]/div[2]/div[1]/a"));
                Log.Info("First job post link is found on the Job Lists Page");
            }
            catch (Exception ex)
            {
                Log.Error("First job post link is not found on the Job Lists Page");
                throw (ex);
            }
            return element;
        }

    }
}
