using iLabJobs.pages;
using iLabJobs.utilities;

namespace iLabJobs.actions
{
    public class JobPostSelection
    {
        public static void Execute()
        {
            Careers_SouthAfrica.Link_FirstPost().Click();
            Log.Info("first job link clicked from South Africa jobs page");
        }
    }
}
