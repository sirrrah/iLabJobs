using System;
using AventStack.ExtentReports;
using iLabJobs.pages;
using iLabJobs.tests;
using iLabJobs.utilities;

namespace iLabJobs.actions
{
    public class JobApplication : BaseClass
    {

        public JobApplication(ExtentTest test) : base(driver, test) { }

        public static void Execute(int TestCaseRow)
        {
            string ss_name = Utils.GetTestCaseName(typeof(TestCase_01).ToString() + "_ClickApplyOnlineButton");
            string ss_name1 = Utils.GetTestCaseName(typeof(TestCase_01).ToString() + "_FillNameField");
            string ss_name2 = Utils.GetTestCaseName(typeof(TestCase_01).ToString() + "_FillEmailField");
            string ss_name3 = Utils.GetTestCaseName(typeof(TestCase_01).ToString() + "_FillPhoneField");
            string ss_name4 = Utils.GetTestCaseName(typeof(TestCase_01).ToString() + "_ClickSendButton");

            JobPost.Button_ApplyOnline().Click();
            Log.Info("'Apply Online' button clicked from the job post page");
            Utils.TakeScreenshot(driver, test, ss_name);
            test.Log(Status.Info, "'Apply Online' button clicked from the job post page");

            string name = Constant.GetFullName(TestCaseRow);
            JobPost.Textbox_ApplicantName().SendKeys(name);
            Utils.TakeScreenshot(driver, test, ss_name1);
            Log.Info(name + " is entered in the applicant name field");
            test.Log(Status.Info, name + " is entered in the applicant name field");

            string email = Constant.GetEmail(TestCaseRow);
            JobPost.Textbox_Email().SendKeys(email);
            Utils.TakeScreenshot(driver, test, ss_name2);
            Log.Info(email + " is entered in the email field");
            test.Log(Status.Info, email + " is entered in the email field");

            string phone = AutoPhoneNumber();
            JobPost.Textbox_Phone().SendKeys(phone);
            Utils.TakeScreenshot(driver, test, ss_name3);
            Log.Info(phone + " is entered on applicant name field");
            test.Log(Status.Info, phone + " is entered on applicant name field");

            JobPost.Buttton_SendApplication().Click();
            Utils.TakeScreenshot(driver, test, ss_name4);
            Log.Info("button 'SEND APPLICATION' clicked");
            test.Log(Status.Info, "button 'SEND APPLICATION' clicked");
        }

        // Auto-generates a 10 digit phone number, format: 083 568 7859
        private static string AutoPhoneNumber()
        {
            Log.Info("Generating phone number...");
            test.Log(Status.Info, "Generating phone number...");
            string num = "0";
            Random rnd = new Random();
            for (int a = 0; a < 11; a++)
                if(a == 2 || a == 6)
                    num = string.Concat(num, " ");
                else
                    if(a == 0)
                        num = string.Concat(num, rnd.Next(6,9).ToString());
                    else
                        num = string.Concat(num, rnd.Next(10).ToString());
            
            return num;
        }
    }
}
