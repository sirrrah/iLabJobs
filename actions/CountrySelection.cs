using AventStack.ExtentReports;
using iLabJobs.pages;
using iLabJobs.tests;
using iLabJobs.utilities;

namespace iLabJobs.actions
{
    public class CountrySelection : BaseClass
    {
        public CountrySelection(ExtentTest test) : base(driver, test) { }

        public static void Execute()
        {
            string ss_name = Utils.GetTestCaseName(typeof(TestCase_01).ToString() + "_ClickCareersLink");
            Home.Link_Careers().Click();
            Log.Info("'careers' link clicked in the Home page");
            Utils.TakeScreenshot(driver, test, ss_name);
            test.Log(Status.Info, "'careers' link clicked from Home page");

            string ss_name1 = Utils.GetTestCaseName(typeof(TestCase_01).ToString() + "_ClickSouthAfricaLink");
            Careers.Link_SouthAfrica().Click();
            Utils.TakeScreenshot(driver, test, ss_name1);
            Log.Info("'South Africa' link clicked in the Careers page");
            test.Log(Status.Info, "'South Africa' link clicked in the Careers page");
        }
    }
}
