using System;
using iLabJobs.pages;
using iLabJobs.utilities;

namespace iLabJobs.actions
{
    public class JobApplication
    {
        public static void Execute()
        {
            JobPost.Button_ApplyOnline().Click();
            Log.Info("'Apply Online' button clicked from the job post page");

            JobPost.Textbox_ApplicantName().SendKeys("Sihle");
            Log.Info("Sihle is entered in the applicant name field");

            JobPost.Textbox_Email().SendKeys("automationAssessment@iLABQuality.com");
            Log.Info("automationAssessment@iLABQuality.com is entered in the email field");

            string phone = AutoPhoneNumber();
            JobPost.Textbox_Phone().SendKeys(phone);
            Log.Info(phone + " is entered on applicant name field");

            JobPost.Buttton_SendApplication().Click();
            Log.Info("button 'SEND APPLICATION' clicked");
        }

        private static string AutoPhoneNumber()
        {
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
