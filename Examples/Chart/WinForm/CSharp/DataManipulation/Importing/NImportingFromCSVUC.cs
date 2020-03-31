using System;
using System.Collections.Generic;
using System.Text;
using Nevron.GraphicsCore;
using Nevron.Chart;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Chart.CSVReader;

namespace Nevron.Examples.Chart.WinForm
{
    public class NImportingFromCSVUC : NExampleBaseUC
    {
        private Nevron.UI.WinForm.Controls.NButton ClearChart;
		private Nevron.UI.WinForm.Controls.NButton ImportFromCSV;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NDataGridView nDataGridView1;
        private System.ComponentModel.Container components = null;

        public NImportingFromCSVUC()
        {
			InitializeComponent();  
        }

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.ClearChart = new Nevron.UI.WinForm.Controls.NButton();
			this.ImportFromCSV = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.nDataGridView1 = new Nevron.UI.WinForm.Controls.NDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.nDataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// ClearChart
			// 
			this.ClearChart.Location = new System.Drawing.Point(8, 8);
			this.ClearChart.Name = "ClearChart";
			this.ClearChart.Size = new System.Drawing.Size(151, 24);
			this.ClearChart.TabIndex = 0;
			this.ClearChart.Text = "Clear Chart";
			this.ClearChart.Click += new System.EventHandler(this.ClearChart_Click);
			// 
			// ImportFromCSV
			// 
			this.ImportFromCSV.Location = new System.Drawing.Point(8, 40);
			this.ImportFromCSV.Name = "ImportFromCSV";
			this.ImportFromCSV.Size = new System.Drawing.Size(151, 23);
			this.ImportFromCSV.TabIndex = 1;
			this.ImportFromCSV.Text = "Import From CSV File";
			this.ImportFromCSV.Click += new System.EventHandler(this.ImportFromCSV_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "CSV file content:";
			// 
			// nDataGridView1
			// 
			this.nDataGridView1.AllowUserToAddRows = false;
			this.nDataGridView1.AllowUserToDeleteRows = false;
			this.nDataGridView1.AllowUserToResizeRows = false;
			this.nDataGridView1.ReadOnly = true;
			this.nDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.nDataGridView1.Location = new System.Drawing.Point(8, 93);
			this.nDataGridView1.Name = "nDataGridView1";
			this.nDataGridView1.Size = new System.Drawing.Size(199, 228);
			this.nDataGridView1.TabIndex = 4;
			// 
			// NImportingFromCSVUC
			// 
			this.Controls.Add(this.nDataGridView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ImportFromCSV);
			this.Controls.Add(this.ClearChart);
			this.Name = "NImportingFromCSVUC";
			this.Size = new System.Drawing.Size(210, 400);
			((System.ComponentModel.ISupportInitialize)(this.nDataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }		

        #endregion

		public override void Initialize()
		{
			base.Initialize();

			InitTitleAndBackground();
		}

		private void InitTitleAndBackground()
		{
			// add a title
			NLabel title = nChartControl1.Labels.AddHeader("Import from CSV File");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
		}

		void ImportFromCSV_Click(object sender, EventArgs e)
		{
			nChartControl1.Clear();
			InitTitleAndBackground();

			NBarSeries bar0 = (NBarSeries)nChartControl1.Charts[0].Series.Add(SeriesType.Bar);
			bar0.Legend.Mode = SeriesLegendMode.DataPoints;
			//bar0.FillStyle = new NColorFillStyle(Color.Aquamarine);
			NBarSeries bar1 = (NBarSeries)nChartControl1.Charts[0].Series.Add(SeriesType.Bar);
			bar1.Legend.Mode = SeriesLegendMode.DataPoints;
			//bar0.FillStyle = new NColorFillStyle(Color.BurlyWood);
			bar1.MultiBarMode = MultiBarMode.Clustered;

			string csvFile = Application.StartupPath + "\\..\\..\\DataManipulation\\Importing\\Sample.csv";

			NCsvReader reader = new NCsvReader();
			reader.CellSeparator = ',';
			reader.LineSeparators = new char[] { '\r', '\n' };
			reader.HasHeader = false;
			reader.EscapeCharacter = '\\';
			reader.TrimCell = true;

			reader.Columns.Add(new NStringCsvColumn("String Column"));
			reader.Columns.Add(new NDoubleCsvColumn("Double Column"));
			reader.Columns.Add(new NDecimalCsvColumn("Decimal Column"));
			reader.Columns.Add(new NColorCsvColumn("Color0 Column"));
			reader.Columns.Add(new NColorCsvColumn("Color1 Column"));

			try
			{
				DataTable dt = reader.LoadDataTableFromFile(csvFile);
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", dt, "Double Column");
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", dt, "String Column");
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", dt, "Color0 Column");

				nChartControl1.DataBindingManager.AddBinding(0, 1, "Values", dt, "Decimal Column");
				nChartControl1.DataBindingManager.AddBinding(0, 1, "Labels", dt, "String Column");
				nChartControl1.DataBindingManager.AddBinding(0, 1, "FillStyles", dt, "Color1 Column");

				nDataGridView1.DataSource = dt;
				nDataGridView1.AutoResizeColumns();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			nChartControl1.Refresh();
		}

		private void ClearChart_Click(object sender, System.EventArgs e)
		{
			nChartControl1.Clear();
			InitTitleAndBackground();
			nChartControl1.Refresh();
			nDataGridView1.DataSource = null;
		}
    }
}
