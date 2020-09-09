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
				// Uses Xpath Regular expression to find element
				element = driver.FindElement(By.XPath("//a[contains(@href,'om/careers')]"));
				Log.Info("careers link is found on the Home Page - using xpath regex");
				test.Log(Status.Info, "careers link is found on the Home Page - using xpath regex");
			} catch (Exception ex) {
				Log.Error("careers link is not found on the Home Page");
				test.Log(Status.Error, "careers link is not found on the Home Page");
				throw (ex);
			}
			return element;
		}
	}
}
