using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace PracticeAutomation.Utility
{
    public class ExcelReader
    {
        public DataTable ReadExcelSheet(string filePath)
        {
            DataTable dataTable;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //open file and returns as Stream
            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using (var excelReader = ExcelReaderFactory.CreateReader(stream))
            {
                DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                dataTable = result.Tables[0];
                excelReader.Close();
            }
            return dataTable;
        }
    }
}
