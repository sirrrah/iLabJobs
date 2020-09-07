//____________________________________________________________________________
//Author: Siphesihle Pangumso
//Date: 05/09/2020
//Desc: An automation test framework to test the iLAB Jobs applicatiion page.
//____________________________________________________________________________

using System;
using iLabJobs.actions;
using iLabJobs.pages;
using iLabJobs.utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace iLabJobs.tests
{
    // Reuseable test case against a variaty of browsers and user input.
    // NUnit Test case pattern divides a test into three parts.
    // SetUp Method is the prerequisite and code will always be the same for every test.
    public class TestCase_01
    {
        IWebDriver driver;
        // The row from Test Data Sheet to run the test from
        public static readonly int TestCaseRow = 1;

        [SetUp]
        public void Before()
        {
            // Start printing the logs + the Test Case name
            // for log4net to work "[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]" must be added to AssemblyInfo.cs
            Log.StartTestCase(Utils.GetTestCaseName(this.ToString()));

            // Set up the Test Data Excel file using file path
            // I'd use Constant.FILE_TEST_DATA as parameter but throws 'NullReferenceException: Object reference not set to an instance of an object'
            ExcelDataIO.PopulateInCollection(@"A:\Work\Visual Studio\iLabJobs\Data\test_data.xlsx");

            // Launch the browser, this will take the Browser Type from Test Data Sheet 
            driver = Utils.OpenBrowser();

            // Initialize the Base Class for the web driver
            // Web driver also inherited by the Page classes and/or Module Actions
            new BaseClass(driver);
        }

        [Test]
        public void Main()
        {
            // Catches exceptions thrown from any class or method
            try
            {
                // Navigates to a country's job vacancies, South Africa, in this case 
                CountrySelection.Execute();

                // Selects Job posts, only the first one in the list in this case 
                JobPostSelection.Execute();

                // Implements the job application process by filling the application form
                // Retrieves user information from excel data sheet to fill the application
                JobApplication.Execute();

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
                // Exception to fail the test completely in the NUnit results
                throw e;
            }
        }

        [TearDown]
        public void TearDown()
        {
            //print test logs end
            Log.EndTestCase();
            //close opened driver
            driver.Quit();
        }
    }
}
