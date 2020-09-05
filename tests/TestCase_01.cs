using System;
using iLabJobs.actions;
using iLabJobs.pages;
using iLabJobs.utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace iLabJobs.tests
{
    public class TestCase_01
    {
        IWebDriver driver;

        [SetUp]
        public void Before()
        {
            Log.StartTestCase(Utils.GetTestCaseName(this.ToString()));

            // Launching the browser, this will take the Browser Type from Test Data Sheet 
            driver = Utils.OpenBrowser("chrome");

            new BaseClass(driver);
        }

        [Test]
        public void Main()
        {
            try
            {
                CountrySelection.Execute();

                JobPostSelection.Execute();

                JobApplication.Execute();

                Validation.Execute();

                if (BaseClass.TestResult == true)
                {
                    // If the value of boolean variable is True, then your test is complete pass and do this
                    //ExcelUtils.setCellData("Pass", iTestCaseRow, Constant.Col_Result);
                }
                else
                {
                    // If the value of boolean variable is False, then your test is fail, and you like to report it accordingly
                    // This is to throw exception in case of fail test, this exception will be caught by catch block below
                    throw new Exception("Test Case Failed - Validation failed");
                }
            }
            catch (Exception e)
            {
                // If in case you got any exception during the test, it will mark your test as Fail in the test result sheet
                //ExcelUtils.setCellData("Fail", iTestCaseRow, Constant.Col_Result);
                // If the exception is in between the test, bcoz of any element not found or anything, this will take a screen shot
                //Utils.takeScreenshot(driver, sTestCaseName);
                // This will print the error log message
                Log.Error(e.Message);
                // Again throwing the exception to fail the test completely in the NUnit results
                throw e;
            }
        }

        [TearDown]
        public void TearDown()
        {
            Log.EndTestCase();
            driver.Quit();
        }
    }
}
