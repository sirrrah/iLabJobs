using AventStack.ExtentReports;
using iLabJobs.pages;
using iLabJobs.tests;
using iLabJobs.utilities;

namespace iLabJobs.actions
{
    public class JobPostSelection : BaseClass
    {
        public JobPostSelection(ExtentTest test) : base(driver, test) { }

        public static void Execute()
        {
            string name = Utils.GetTestCaseName(typeof(TestCase_01).ToString() + "_SelectFirstPost");
            Careers_SouthAfrica.Link_FirstPost().Click();
            Utils.TakeScreenshot(driver, test, name);
            Log.Info("first job link clicked from South Africa jobs page");
            test.Log(Status.Info, "first job link clicked from South Africa jobs page");
        }
    }
}
