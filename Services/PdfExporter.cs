using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiplaceApp.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace SiplaceApp.Services
{
    public class PdfExporter
    {
     public void ExportToPdf(
            Recipe recipe,
            List<ReportRow> reportData,
            string filePath)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(30);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));
                    page.Header()
                        .Text("SIPLACE Setup Report")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);
                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Spacing(10);

                            column.Item()
                                .Text($"Recipe Name: {recipe.RecipeName}").FontSize(14).Bold();

                            column.Item()
                                .Text($"Line Name: {recipe.LineName}").FontSize(14).Bold();

                            column.Item()
                                .Text($"Model: {recipe.ModelName}").FontSize(14).Bold();

                            column.Item()
                                .Text($"Board Side: {recipe.BoardSide}").FontSize(14).Bold();

                            column.Item()
                                .Text(
                                    $"Import Date: {recipe.ImportedDate}").FontSize(14).Bold();
                                

                            column.Item()
                                .Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {

                                        columns.RelativeColumn(1.5f);
                                        columns.RelativeColumn(1f);
                                        columns.RelativeColumn(1f);
                                        columns.RelativeColumn(1.5f);
                                        columns.RelativeColumn(1.5f);
                                        columns.RelativeColumn(2.5f);
                                        columns.RelativeColumn(2.5f);
                                    });
                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Machine Name").Bold().FontSize(14);
                                        header.Cell().Text("Table").Bold().FontSize(14);
                                        header.Cell().Text("Track").Bold().FontSize(14);
                                        header.Cell().Text("Part Number").Bold().FontSize(14);
                                        header.Cell().Text("Quantity").Bold().FontSize(14);
                                        header.Cell().Text("Reference Designators").Bold().FontSize(14);
                                        header.Cell().Text("Feeder Type").Bold().FontSize(14);
                                    });
                                    foreach (var row in reportData)
                                    {
                                        table.Cell().Text(row.MachineName);
                                        table.Cell().Text(row.Table);
                                        table.Cell().Text(row.Track);
                                        table.Cell().Text(row.PartNumber);
                                        table.Cell().Text(row.Quantity.ToString());
                                        table.Cell().Text(row.ReferenceDesignators);
                                        table.Cell().Text(row.FeederType);
                                    }
                                });
                        });

                    page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Generated on: ");
                                x.Span(DateTime.Now.ToString("g")).SemiBold();


                            });
                });
            })
.GeneratePdf(filePath);
        }
    }
}