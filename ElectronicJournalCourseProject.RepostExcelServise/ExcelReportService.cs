using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ElectronicJournalCourseProject.RepostExcelServise
{
    public class ExcelReportService
    {
        private string _abbreviature;
        private string _subjectName;

        public ExcelReportService(string abbreviature, string subjectName)
        {
            _abbreviature = abbreviature;
            _subjectName = subjectName;
        }

        public void ConvertDataTableToExcel(DataTable dt, string pathToFolder)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Отчёт");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                }

                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = dt.Rows[row][col].ToString();
                    }
                }

                var excelBytes = package.GetAsByteArray();
                string path = Path.Combine(pathToFolder, $"{_abbreviature}{_subjectName}.xlsx");
                File.WriteAllBytes(path, excelBytes);
            }
        }
    }
}

