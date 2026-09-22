namespace SiplaceApp.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string LineName { get; set; }
        public string ModelName { get; set; }
        public string BoardSide { get; set; }
        public DateTime ImportedDate { get; set; }

        public ICollection<SetupDetail> SetupDetails { get; set; } = new List<SetupDetail>();
    }
}
