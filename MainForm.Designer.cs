namespace SiplaceApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            grpImport = new GroupBox();
            btnImportXml = new Button();
            lblImportDescription = new Label();
            grpRecipes = new GroupBox();
            dgvRecipes = new DataGridView();
            btnExcel = new Button();
            btnPdf = new Button();
            grpGenerate = new GroupBox();
            grpImport.SuspendLayout();
            grpRecipes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecipes).BeginInit();
            grpGenerate.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(36, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(711, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SIPLACE SETUP REPORT GENERATOR";
            lblTitle.Click += label1_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(43, 95);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(701, 30);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Import, manage and generate setup reports from SIPLACE XML recipes";
            // 
            // grpImport
            // 
            grpImport.Controls.Add(btnImportXml);
            grpImport.Controls.Add(lblImportDescription);
            grpImport.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpImport.Location = new Point(52, 185);
            grpImport.Name = "grpImport";
            grpImport.Size = new Size(525, 150);
            grpImport.TabIndex = 2;
            grpImport.TabStop = false;
            grpImport.Text = "IMPORT RECIPES";
            // 
            // btnImportXml
            // 
            btnImportXml.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImportXml.Location = new Point(138, 88);
            btnImportXml.Name = "btnImportXml";
            btnImportXml.Size = new Size(250, 40);
            btnImportXml.TabIndex = 2;
            btnImportXml.Text = "Import XML Files";
            btnImportXml.UseVisualStyleBackColor = true;
            // 
            // lblImportDescription
            // 
            lblImportDescription.AutoSize = true;
            lblImportDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblImportDescription.Location = new Point(69, 45);
            lblImportDescription.Name = "lblImportDescription";
            lblImportDescription.Size = new Size(395, 28);
            lblImportDescription.TabIndex = 0;
            lblImportDescription.Text = "Select one or more SIPLACE XML recipe files";
            // 
            // grpRecipes
            // 
            grpRecipes.Controls.Add(dgvRecipes);
            grpRecipes.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpRecipes.Location = new Point(52, 361);
            grpRecipes.Name = "grpRecipes";
            grpRecipes.Size = new Size(1099, 389);
            grpRecipes.TabIndex = 3;
            grpRecipes.TabStop = false;
            grpRecipes.Text = "IMPORTED RECIPES";
            // 
            // dgvRecipes
            // 
            dgvRecipes.AllowUserToAddRows = false;
            dgvRecipes.AllowUserToDeleteRows = false;
            dgvRecipes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecipes.BackgroundColor = SystemColors.Control;
            dgvRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecipes.Location = new Point(37, 63);
            dgvRecipes.MultiSelect = false;
            dgvRecipes.Name = "dgvRecipes";
            dgvRecipes.ReadOnly = true;
            dgvRecipes.RowHeadersVisible = false;
            dgvRecipes.RowHeadersWidth = 62;
            dgvRecipes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecipes.Size = new Size(1013, 287);
            dgvRecipes.TabIndex = 0;
            // 
            // btnExcel
            // 
            btnExcel.Enabled = false;
            btnExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExcel.Location = new Point(64, 38);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(400, 40);
            btnExcel.TabIndex = 4;
            btnExcel.Text = "Generate Excel";
            btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnPdf
            // 
            btnPdf.Enabled = false;
            btnPdf.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPdf.Location = new Point(64, 91);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(400, 40);
            btnPdf.TabIndex = 5;
            btnPdf.Text = "Generate PDF";
            btnPdf.UseVisualStyleBackColor = true;
            // 
            // grpGenerate
            // 
            grpGenerate.Controls.Add(btnPdf);
            grpGenerate.Controls.Add(btnExcel);
            grpGenerate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpGenerate.Location = new Point(626, 185);
            grpGenerate.Name = "grpGenerate";
            grpGenerate.Size = new Size(525, 150);
            grpGenerate.TabIndex = 6;
            grpGenerate.TabStop = false;
            grpGenerate.Text = "GENERATE";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1203, 804);
            Controls.Add(grpRecipes);
            Controls.Add(grpImport);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Controls.Add(grpGenerate);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1195, 768);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SIPLACE Setup Report Generator";
            Load += MainForm_Load;
            grpImport.ResumeLayout(false);
            grpImport.PerformLayout();
            grpRecipes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecipes).EndInit();
            grpGenerate.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private GroupBox grpImport;
        private Label lblImportDescription;
        private Button btnImportXml;
        private GroupBox grpRecipes;
        private DataGridView dgvRecipes;
        private Button btnExcel;
        private Button btnPdf;
        private GroupBox grpGenerate;
    }
}
