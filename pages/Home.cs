using System;
using iLabJobs.utilities;
using OpenQA.Selenium;

namespace iLabJobs.pages
{
	public class Home : BaseClass
	{
		private static IWebElement element = null;

		public Home(IWebDriver driver) : base(driver) { }

		public static IWebElement Link_Careers()
		{
			try {
				element = driver.FindElement(By.LinkText("CAREERS"));
				Log.Info("careers link is found on the Home Page");
			} catch (Exception ex) {
				Log.Error("careers link is not found on the Home Page");
				throw (ex);
			}
			return element;
		}
	}
}
