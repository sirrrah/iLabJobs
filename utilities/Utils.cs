using System;
using System.IO;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace iLabJobs.utilities 
{
    class Utils
    {
        public static IWebDriver driver;

        public static IWebDriver OpenBrowser(int TestCaseRow)
        {
            string browser = Constant.GetBrowser(TestCaseRow);
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
                    _ => new ChromeDriver(),
                };
                Log.Info("new driver instantiated");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Log.Info("Implicit wait applied on the driver for 10 seconds");
            
                driver.Navigate().GoToUrl(Constant.URL);
                Log.Info("Web application launched");
                
                return driver;
            }
            catch (Exception e)
            {
			    Log.Error("Class Utils | Method OpenBrowser | Exception desc : " + e.Message);
                throw e;
		    }
        }

        internal static void TakeScreenshot(IWebDriver driver, ExtentTest test, string TestCaseName)
        {
            string dir = Constant.PATH_SCREENSHOT;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string path = dir + TestCaseName + " " + DateTime.Now.ToString("MM-dd-yy_Hmm") + ".png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            test.AddScreenCaptureFromPath(path, TestCaseName + " screenshot");
        }

        internal static string GetTestCaseName(string tc_name)
        {
            try
            {
                tc_name = tc_name.Substring(tc_name.LastIndexOf(".") + 1);
                return tc_name;
            }
            catch (Exception e)
            {
                Log.Error("Class Utils | Method OpenBrowser | Exception desc : " + e.Message);
                throw e;
            }

        }

    }
}
