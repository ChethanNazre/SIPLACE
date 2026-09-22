using System;
using System.Collections.Generic;
using System.Linq;
using SiplaceApp.Models;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace SiplaceApp.Services
{
    public class ExcelExporter
    {
        public void ExportToExcel(
            Recipe recipe,
            List<ReportRow> reportData,
            string filePath)
        {
            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Setup Report");

            worksheet.Cell(1,1).Value = "Recipe Name";
            worksheet.Cell(1, 2).Value = recipe.RecipeName;

            worksheet.Cell(2, 1).Value = "Line Name";
            worksheet.Cell(2, 2).Value = recipe.LineName;

            worksheet.Cell(3, 1).Value = "Model";
            worksheet.Cell(3, 2).Value = recipe.ModelName;

            worksheet.Cell(4, 1).Value = "Board Side";
            worksheet.Cell(4, 2).Value = recipe.BoardSide;

            worksheet.Cell(5, 1).Value = "Imported Date";
            worksheet.Cell(5, 2).Value = recipe.ImportedDate.ToString("yyyy-MM-dd HH:mm:ss");

            int headerRow = 7;
            worksheet.Cell(headerRow, 1).Value = "Machine Name";
            worksheet.Cell(headerRow, 2).Value = "Table";
            worksheet.Cell(headerRow, 3).Value = "Track";
            worksheet.Cell(headerRow, 4).Value = "Part Number";
            worksheet.Cell(headerRow, 5).Value = "Quantity";
            worksheet.Cell(headerRow, 6).Value = "Mounting Reference Designators";
            worksheet.Cell(headerRow, 7).Value = "Feeder Type";

            int currentRow = headerRow + 1;
            foreach (var row in reportData)
            {
                worksheet.Cell(currentRow, 1).Value = row.MachineName;
                worksheet.Cell(currentRow, 2).Value = row.Table;
                worksheet.Cell(currentRow, 3).Value = row.Track;
                worksheet.Cell(currentRow, 4).Value = row.PartNumber;
                worksheet.Cell(currentRow, 5).Value = row.Quantity;
                worksheet.Cell(currentRow, 6).Value = row.ReferenceDesignators;
                worksheet.Cell(currentRow, 7).Value = row.FeederType;
                currentRow++;
            }

            var headerRange = worksheet.Range(headerRow, 1, headerRow, 7);
            headerRange.Style.Font.Bold = true;
            worksheet.Columns().AdjustToContents();
            workbook.SaveAs(filePath);
        }
    }
}
