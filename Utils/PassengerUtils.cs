using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhiTest.Utils
{
    internal class PassengerUtils
    {
        public static List<PassengerData> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<PassengerData> excelDataList = new List<PassengerData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            PassengerData excelData = new PassengerData
                            {

                                Name = GetValueOrDefault(row, "name"),
                                Age = GetValueOrDefault(row, "age"),
                                Contact = GetValueOrDefault(row, "contact"),
                                Email = GetValueOrDefault(row, "email"),

                                Pin = GetValueOrDefault(row, "pin"),
                                State = GetValueOrDefault(row, "state"),


                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
