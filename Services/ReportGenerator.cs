using System;
using System.Collections.Generic;
using System.Text;
using SiplaceApp.Models;
using SiplaceApp.Data;
using System.Linq;


namespace SiplaceApp.Services
{
    public class ReportGenerator
    {
        private readonly SiplaceContext _context;
        public ReportGenerator(SiplaceContext context)
        {
            _context = context;
        }
        public List<ReportRow> GenerateReport(int recipeId)
        {
           var groupedDetails = _context.SetupDetails.Where(d => d.RecipeId == recipeId)
                .GroupBy(d =>
                new { d.MachineName, 
                      d.Table, 
                      d.Track,
                      d.PartNumber,
                      d.FeederType
                })

                .Select(g => new ReportRow
                {
                    MachineName = g.Key.MachineName,
                    Table = g.Key.Table,
                    Track = g.Key.Track,
                    PartNumber = g.Key.PartNumber, 

                    Quantity = g.Sum(d => d.Quantity),
                    ReferenceDesignators = string.Join(",", g.Select(d => d.ReferenceDesignators)),

                    FeederType = g.Key.FeederType
                })

                  .OrderBy(r => r.MachineName)
                  .ThenBy(r => r.Table)
                  
                  .ToList();

            return groupedDetails;
        }
                
        }
    public class ReportRow
    {
        public string MachineName { get; set; }
        public string Table { get; set; }
        public string Track { get; set; }
        public string PartNumber { get; set; }
        public int Quantity { get; set; }
        public string ReferenceDesignators { get; set; }
        public string FeederType { get; set; }
    }
}

