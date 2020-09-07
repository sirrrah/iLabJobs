using iLabJobs.pages;
using iLabJobs.utilities;

namespace iLabJobs.actions
{
    public class Validation
    {
        public static void Execute()
        {
            if(JobPost.Error_UploadFile().Text.Contains("You need to upload at least one file."))
            {
                BaseClass.TestResult = true;
                Log.Info("test results set to PASSED!");
            } else
            {
                BaseClass.TestResult = false;
                Log.Info("test results set to FAILED!");
            }
        }
    }
}
