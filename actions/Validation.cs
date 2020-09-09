using System;
using AventStack.ExtentReports;
using iLabJobs.pages;
using iLabJobs.tests;
using iLabJobs.utilities;

namespace iLabJobs.actions
{
    public class Validation : BaseClass
    {
        public Validation(ExtentTest test) : base(driver, test) { }

        public static void Execute()
        {
            string name = Utils.GetTestCaseName(typeof(TestCase_01).ToString() + "_UploadFileError");
            try
            {

                if (JobPost.Error_UploadFile().Text.Contains("You need to upload at least one file."))
                {
                    BaseClass.TestResult = true;
                    Log.Info("TestResult value set to PASS!");
                    test.Log(Status.Info, "variable TestResult value set to PASS!");
                    test.Pass("'You need to upload at least one file.' Error message displayed");

                    Utils.TakeScreenshot(driver, test, name);

                }
                else
                {
                    throw new Exception("'You need to upload at least one file.' Error message not displayed");
                }
            }
            catch (Exception ex)
            {
                BaseClass.TestResult = false;
                Log.Info("TestResult value set to FAIL!");
                test.Log(Status.Error, "variable TestResult value set to FAIL!");
                test.Fail("'You need to upload at least one file.' Error message not displayed");
                Utils.TakeScreenshot(driver, test, name);
                throw (ex);
            }
        }
    }
}
