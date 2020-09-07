﻿using iLabJobs.tests;

namespace iLabJobs.utilities
{
    class Constant
    {

		public static readonly string URL = "https://www.ilabquality.com";
		public static readonly string FILE_TEST_DATA = @"A:\Work\Visual Studio\iLabJobs\Data\test_data.xlsx";
        
		//Get data sheet row number to use
        static readonly int  Row = TestCase_01.TestCaseRow; 
		//Test Data Sheet dataset
        public static readonly string TEST_CASE_NAME = ExcelDataIO.ReadData(Row, "Test Case Name");
        public static readonly string BROWSER = ExcelDataIO.ReadData(Row, "Browser");
		public static readonly string NAME = ExcelDataIO.ReadData(Row, "Full Name");
		public static readonly string EMAIL = ExcelDataIO.ReadData(Row, "Email");
		public static readonly string TEST_DATE = ExcelDataIO.ReadData(Row, "Test Datetime");
		public static readonly string RESULT = ExcelDataIO.ReadData(Row, "Result");
		public static readonly string PATH_SCREENSHOT = "D://ToolsQA//OnlineStore//src//Screenshots//";
		
        //Test Data Sheet columns
		public static readonly int COLUMN_RESULT = 6;
    }
}
