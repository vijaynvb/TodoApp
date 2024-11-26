using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitSelenium.Utilities
{
    internal class ExcelReadUtil
    {
        // Install Nugetpackage EPPlus to read excel files
        public static IEnumerable<TestCaseData> GetTestDataFromExcel(string filePath, string sheetName, List<string> columnNames)
        {
            var testData = new List<TestCaseData>();

            // Load Excel file
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[sheetName];
                if (worksheet == null)
                {
                    throw new ArgumentException($"Sheet '{sheetName}' not found in the Excel file.");
                }

                // Find column indices for specified column names
                var columnIndices = new Dictionary<string, int>();
                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                {
                    var cellValue = worksheet.Cells[1, col].Value?.ToString();
                    if (columnNames.Contains(cellValue))
                    {
                        columnIndices[cellValue] = col;
                    }
                }

                // Check if all column names are found
                foreach (var columnName in columnNames)
                {
                    if (!columnIndices.ContainsKey(columnName))
                    {
                        throw new ArgumentException($"Column name '{columnName}' not found in the Excel file.");
                    }
                }

                // Read test data
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var data = new List<string>();
                    foreach (var columnName in columnNames)
                    {
                        data.Add(worksheet.Cells[row, columnIndices[columnName]].Value?.ToString());
                    }
                    testData.Add(new TestCaseData(data.ToArray()));
                }
            }

            return testData;
        }
    }
}
