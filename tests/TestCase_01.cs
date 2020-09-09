//____________________________________________________________________________
//Author: Siphesihle Pangumso
//Date: 05/09/2020
//Desc: An automation test framework to test the iLAB Jobs applicatiion page.
//____________________________________________________________________________

using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using iLabJobs.actions;
using iLabJobs.pages;
using iLabJobs.utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace iLabJobs.tests
{
    // Reuseable test case against a variaty of browsers and user input.
    // NUnit Test case pattern divides a test into three parts.
    // Below parameter passed is the row number from Excel Data Sheet: 1 - chrome, 2 - firefox
    [TestFixture(1)]
    [TestFixture(2)]
    public class TestCase_01
    {
        IWebDriver driver;
        // The row from Test Data Sheet to run the test from
        public static int TestCaseRow;
        readonly ExtentReports extent = new ExtentReports();
        ExtentTest test;

        // Constructor necessary for the TestTexture parameterization
        public TestCase_01(int _TestCaseRow)
        {
            TestCaseRow = _TestCaseRow;
        }

        [SetUp]
        public void Before()
        {
            // Refine the test case name from the full class name
            string TestCaseName = Utils.GetTestCaseName(this.ToString());

            // Start (prettified) printing of logs
            // for log4net to work "[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]" must be added to AssemblyInfo.cs
            Log.StartTestCase(TestCaseName);

            // Set up the Test Data Excel file using file path
            // I'd pass Constant.FILE_TEST_DATA but throws 'NullReferenceException: Object reference not set to an instance of an object'
            ExcelDataIO.PopulateInCollection(@"A:\Work\Visual Studio\iLabJobs\Data\test_data.xlsx");
            
            // Extent Report declaration
            // Folders unique because HTML Reporter only accepts path and creates 'index.html' instead of allowing a custom file name
            ExtentHtmlReporter reporter = new ExtentHtmlReporter(Constant.PATH_HTML_REPORT + Constant.GetTestCaseName(TestCaseRow) + @"\");
            extent.AttachReporter(reporter);
            test = extent.CreateTest(TestCaseName, "Test the 'upload at least one file' error using " + Constant.GetBrowser(TestCaseRow) + " browser");
            
            test.Log(Status.Info, "****************** EXECUTING " + TestCaseName + " TEST ******************");

            // Launch the browser, this will take the Browser Type from Test Data Sheet 
            driver = Utils.OpenBrowser(TestCaseRow);
            test.Log(Status.Info, "Browswer launched and visited " + Constant.URL);

            // Initialize the Base Class for the web driver
            // Web driver also inherited by the Page classes and/or Module Actions
            new BaseClass(driver, test);
        }

        [Test]
        public void TestUploadFile()
        {
            // Catches exceptions thrown from any class or method
            try
            {
                // Navigates to a country's job vacancies, South Africa, in this case 
                CountrySelection.Execute();
                test.Pass("Country selection for available jobs successful");

                // Selects Job posts, only the first one in the list in this case 
                JobPostSelection.Execute();
                test.Pass("job post selection successful");

                // Implements the job application process of filling the application form
                // Retrieves user information from excel data sheet to fill the application
                JobApplication.Execute(TestCaseRow);
                test.Pass("job application successful");

                // Validates whether the test case passes or fails based on the error message returned
                Validation.Execute();

                // Passes or fails the test from the set test result value
                // test result value is insert or updated in the excel data sheet
                if (BaseClass.TestResult == true)
                {
                    // If the value of test results is True, then test is complete - pass 
                    ExcelDataIO.WriteData("Pass", TestCaseRow, Constant.COLUMN_RESULT);
                }
                else
                {
                    // If the value of test results is False, then test is complete - fail 
                    // Throws exception in case of a fail, caught by catch block below
                    throw new Exception("Test Case Failed - Validation failed");
                }
            }
            catch (Exception e)
            {
                // If in case you got any exception during the test, it will mark your test as Fail in the test result sheet
                ExcelDataIO.WriteData("Fail", TestCaseRow, Constant.COLUMN_RESULT);
                // This will print the error log message
                Log.Error(e.Message);
                test.Log(Status.Error, e.Message);

                // Exception to fail the test completely in the NUnit results
                throw e;
            }
        }

        [TearDown]
        public void TearDown()
        {
            //print test logs end
            Log.EndTestCase();
            test.Log(Status.Info, "****************** TEST COMPLETE ******************");
            //save report & close resources
            extent.Flush();
            //close opened driver
            driver.Quit();
        }
    }
}
