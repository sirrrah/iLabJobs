using iLabJobs.pages;
using NUnit.Framework;

namespace iLabJobs.actions
{
    public class Validation
    {
        public static void Execute()
        {
            if(JobPost.Error_UploadFile().Text.Contains("You need to upload at least one file."))
            {
                Assert.IsTrue(true);
                BaseClass.TestResult = true;
            } else
            {
                BaseClass.TestResult = false;
            }
        }
    }
}
