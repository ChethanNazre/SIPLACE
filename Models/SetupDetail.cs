using System;
using System.Collections.Generic;
using System.Text;

namespace SiplaceApp.Models
{
    public class SetupDetail
    {
        public int DetailId { get; set; }
        public int RecipeId { get; set; }
        public string MachineName { get; set; }
        public string Table { get; set; }
        public string Track { get; set; }
        public string PartNumber { get; set; }
        public int Quantity { get; set; }
        public string ReferenceDesignator { get; set; }
        public string feederType { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
