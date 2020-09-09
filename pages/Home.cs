using System;
using AventStack.ExtentReports;
using iLabJobs.utilities;
using OpenQA.Selenium;

namespace iLabJobs.pages
{
	public class Home : BaseClass
	{
		private static IWebElement element = null;

		public Home(IWebDriver driver) : base(driver, test) { }

		public static IWebElement Link_Careers()
		{
			try {
				element = driver.FindElement(By.LinkText("CAREERS"));
				Log.Info("careers link is not found on the Home Page");
				test.Log(Status.Info, "careers link is not found on the Home Page");
			} catch (Exception ex) {
				Log.Error("careers link is not found on the Home Page");
				test.Log(Status.Error, "careers link is not found on the Home Page");
				throw (ex);
			}
			return element;
		}
	}
}
