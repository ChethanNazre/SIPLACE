using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SiplaceApp.Data;
using SiplaceApp.Services;

namespace SiplaceApp
{
    public partial class MainForm : Form
    {
        private readonly XMLParser _xmlParser;
        private readonly SiplaceContext _context;
        private readonly ReportGenerator _reportGenerator;
        private readonly ExcelExporter _excelExporter;
        private readonly PdfExporter _pdfExporter;

        public MainForm()
        {
            InitializeComponent();

            _xmlParser = new XMLParser();
            _context = new SiplaceContext();
            _reportGenerator = new ReportGenerator(_context);
            _excelExporter = new ExcelExporter();
            _pdfExporter = new PdfExporter();

            btnExcel.Enabled = false;
            btnPdf.Enabled = false;

            btnImportXml.Click += btnImportXml_Click;
            btnExcel.Click += btnExcel_Click;
            btnPdf.Click += btnPdf_Click;

            dgvRecipes.SelectionChanged += dgvRecipes_SelectionChanged;

            LoadRecipes();
        } 

        private string GetReportsFolder()
        {
            string projectRoot = Directory.GetParent(
                AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;

            string reportsFolder = Path.Combine(projectRoot, "Reports");

            Directory.CreateDirectory(reportsFolder);

            return reportsFolder;
        }


        private void btnImportXml_Click(
            object sender,
            EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Select SIPLACE XML Recipe Files";
            dialog.Filter = "XML Files (*.xml)|*.xml";
            dialog.Multiselect = true;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            int importedCount = 0;

            try
            {
                foreach (string filePath in dialog.FileNames)
                {
                    var recipe = _xmlParser.ParseRecipe(filePath);

                    _context.Recipes.Add(recipe);

                    importedCount++;
                }

                _context.SaveChanges();

                LoadRecipes();

                MessageBox.Show(
                    $"{importedCount} recipe(s) imported successfully.",
                    "Import Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error importing recipe:\n\n{ex.Message}",
                    "Import Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadRecipes()
        {
            var recipes = _context.Recipes
                .OrderByDescending(r => r.ImportedDate)
                .Select(r => new
                {
                    r.RecipeId,
                    r.RecipeName,
                    r.LineName,
                    r.ModelName,
                    r.BoardSide,
                    r.ImportedDate
                })
                .ToList();

            dgvRecipes.DataSource = recipes;

            if (dgvRecipes.Columns["RecipeId"] != null)
            {
                dgvRecipes.Columns["RecipeId"].Visible = false;
            }

            if (dgvRecipes.Columns["RecipeName"] != null)
                dgvRecipes.Columns["RecipeName"].HeaderText = "Recipe Name";

            if (dgvRecipes.Columns["LineName"] != null)
                dgvRecipes.Columns["LineName"].HeaderText = "Line Name";

            if (dgvRecipes.Columns["ModelName"] != null)
                dgvRecipes.Columns["ModelName"].HeaderText = "Model";

            if (dgvRecipes.Columns["BoardSide"] != null)
                dgvRecipes.Columns["BoardSide"].HeaderText = "Board Side";

            if (dgvRecipes.Columns["ImportedDate"] != null)
                dgvRecipes.Columns["ImportedDate"].HeaderText = "Imported Date";
        }

        private void dgvRecipes_SelectionChanged(
            object sender,
            EventArgs e)
        {
            bool recipeSelected =
                dgvRecipes.SelectedRows.Count > 0;

            btnExcel.Enabled = recipeSelected;
            btnPdf.Enabled = recipeSelected;
        }

        private int? GetSelectedRecipeId()
        {
            if (dgvRecipes.SelectedRows.Count == 0)
                return null;

            return Convert.ToInt32(
                dgvRecipes.SelectedRows[0]
                    .Cells["RecipeId"]
                    .Value);
        }

        private void btnExcel_Click(
            object sender,
            EventArgs e)
        {
            int? recipeId = GetSelectedRecipeId();

            if (recipeId == null)
                return;

            var recipe = _context.Recipes
                .FirstOrDefault(r => r.RecipeId == recipeId.Value);

            if (recipe == null)
                return;

            var reportData =
                _reportGenerator.GenerateReport(recipe.RecipeId);

            string reportsFolder = GetReportsFolder();

            using SaveFileDialog dialog = new SaveFileDialog();

            dialog.Title = "Save Excel Report";
            dialog.InitialDirectory = reportsFolder;
            dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            dialog.FileName =
                $"{recipe.RecipeName}_Setup_Report.xlsx";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                _excelExporter.ExportToExcel(
                    recipe,
                    reportData,
                    dialog.FileName);

                MessageBox.Show(
                    "Excel report generated successfully.",
                    "Export Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error generating Excel report:\n\n{ex.Message}",
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPdf_Click(
            object sender,
            EventArgs e)
        {
            int? recipeId = GetSelectedRecipeId();

            if (recipeId == null)
                return;

            var recipe = _context.Recipes
                .FirstOrDefault(r => r.RecipeId == recipeId.Value);

            if (recipe == null)
                return;

            var reportData =
                _reportGenerator.GenerateReport(recipe.RecipeId);

            string reportsFolder = GetReportsFolder();

            using SaveFileDialog dialog = new SaveFileDialog();

            dialog.Title = "Save PDF Report";
            dialog.InitialDirectory = reportsFolder;
            dialog.Filter = "PDF Files (*.pdf)|*.pdf";
            dialog.FileName =
                $"{recipe.RecipeName}_Setup_Report.pdf";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                _pdfExporter.ExportToPdf(
                    recipe,
                    reportData,
                    dialog.FileName);

                MessageBox.Show(
                    "PDF report generated successfully.",
                    "Export Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error generating PDF report:\n\n{ex.Message}",
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}