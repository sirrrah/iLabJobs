using iLabJobs.pages;
using iLabJobs.utilities;

namespace iLabJobs.actions
{
    public class CountrySelection
    {
        public static void Execute()
        {
            Home.Link_Careers().Click();
            Log.Info("link careers clicked from Home page");

            Careers.Link_SouthAfrica().Click();
            Log.Info("link South Africa clicked from Careers page");
        }
    }
}
