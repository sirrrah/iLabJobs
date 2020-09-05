using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace iLabJobs.utilities
{
    class Utils
    {
        public static IWebDriver driver;
        public static IWebDriver OpenBrowser(string browser)
        {
            //browser = ExcelFactory.getData();
            try 
            { 
                driver = (browser.ToLower()) switch
                {
                    //Opens Google Chrome
                    "chrome" => new ChromeDriver(),
                    //Opens Mozilla Firefox
                    "firefox" => new FirefoxDriver(),
                    //Opens Microsoft Edge but returns 'Unexpected error'
                    //"edge" => new EdgeDriver(),
                    //Default browser is Chrome
                    _ => OpenBrowser("chrome"),
                };
                Log.Info("new driver instantiated");
            
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Log.Info("Implicit wait applied on the driver for 10 seconds");
            
                driver.Navigate().GoToUrl(Constant.URL);
                Log.Info("Web application launched");
            }
            catch (Exception e)
            {
			    Log.Error("Class Utils | Method OpenBrowser | Exception desc : " + e.Message);
		    }
            return driver;
        }

        internal static string GetTestCaseName(string tc_name)
        {
            try
            {
                tc_name = tc_name.Substring(tc_name.LastIndexOf(".") + 1);
            }
            catch (Exception e)
            {
                Log.Error("Class Utils | Method OpenBrowser | Exception desc : " + e.Message);
            }
            return tc_name;

        }

    }
}
