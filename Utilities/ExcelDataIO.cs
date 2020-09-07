using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;
using OfficeOpenXml;

namespace iLabJobs.utilities
{
    public class ExcelDataIO
    {
        private static DataTable ExcelToDataTable(string filename)
        {
            //Avoids -> "System.NotSupportedException: No data is available for encoding 1252"
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            using var excelReader = ExcelReaderFactory.CreateReader(stream);
            var resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table["Sheet1"];

            return resultTable;
        }

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        static readonly List<Datacollection> dataCollection = new List<Datacollection>();

        public static void PopulateInCollection(string filename)
        {
            DataTable table = ExcelToDataTable(filename);

            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dataTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCollection.Add(dataTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCollection
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                Log.Error("Class ExcelData | Method ReadData | Exception desc : " + e.Message);
                return null;
            }

        }

        public static void WriteData(string result, int rowNumber, int colNumber)
        {

            try
            {
                //Avoids -> ExcelPackage License Exception
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using var pack = new ExcelPackage(new FileInfo(Constant.FILE_TEST_DATA));

                ExcelWorkbook WorkBook = pack.Workbook;
                ExcelWorksheet worksheet = WorkBook.Worksheets.First();
                //Change the date cell - sets Date & time for the current test
                //row incremented because excel sheet has header
                worksheet.Cells[rowNumber + 1, colNumber - 1].Value = DateTime.Now.ToString();
                //Change the date cell - sets results for the current test
                //row incremented because excel sheet has header
                worksheet.Cells[rowNumber + 1, colNumber].Value = result;
                //save changes
                pack.Save();
            }
            catch (Exception e)
            {
                Log.Error("Class ExcelData | Method WriteData | Exception desc : " + e.Message);
                throw e;
            }
        }
    }
}

