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
                                .Text($"Recipe Name: {recipe.RecipeName}");

                            column.Item()
                                .Text($"Line Name: {recipe.LineName}");

                            column.Item()
                                .Text($"Model: {recipe.ModelName}");

                            column.Item()
                                .Text($"Board Side: {recipe.BoardSide}");

                            column.Item()
                                .Text(
                                    $"Import Date: {recipe.ImportedDate}"
                                );

                            column.Item()
                                .Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {

                                        columns.RelativeColumn(2.4f);
                                        columns.RelativeColumn(1.2f);
                                        columns.RelativeColumn(0.8f);
                                        columns.RelativeColumn(1.8f);
                                        columns.RelativeColumn(0.8f);
                                        columns.RelativeColumn(2.4f);
                                        columns.RelativeColumn(1.5f);
                                    });
                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Machine Name").Bold();
                                        header.Cell().Text("Table").Bold();
                                        header.Cell().Text("Track").Bold();
                                        header.Cell().Text("Part Number").Bold();
                                        header.Cell().Text("Quantity").Bold();
                                        header.Cell().Text("Reference Designators").Bold();
                                        header.Cell().Text("Feeder Type").Bold();
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