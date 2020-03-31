using System;
using System.Collections.Generic;
using System.Text;
using Nevron.GraphicsCore;
using Nevron.Chart;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
    public class NImportingFromXLSUC : NExampleBaseUC
	{
		#region Construcotrs

		public NImportingFromXLSUC()
        {
			InitializeComponent();
		}

		#endregion

		#region Overrides

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

		public override void Initialize()
		{
			base.Initialize();

			InitTitleAndBackground();
		}

		#endregion

		#region Component Designer generated code

		/// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.ClearChart = new Nevron.UI.WinForm.Controls.NButton();
			this.ImportFromXLS = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.nDataGridView1 = new Nevron.UI.WinForm.Controls.NDataGridView();
			this.ImportFromXLSX = new Nevron.UI.WinForm.Controls.NButton();
			this.nCheckBox1 = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nDataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// ClearChart
			// 
			this.ClearChart.Location = new System.Drawing.Point(8, 8);
			this.ClearChart.Name = "ClearChart";
			this.ClearChart.Size = new System.Drawing.Size(165, 24);
			this.ClearChart.TabIndex = 0;
			this.ClearChart.Text = "Clear Chart";
			this.ClearChart.Click += new System.EventHandler(this.ClearChart_Click);
			// 
			// ImportFromXLS
			// 
			this.ImportFromXLS.Location = new System.Drawing.Point(8, 38);
			this.ImportFromXLS.Name = "ImportFromXLS";
			this.ImportFromXLS.Size = new System.Drawing.Size(165, 23);
			this.ImportFromXLS.TabIndex = 1;
			this.ImportFromXLS.Text = "Import From XLS File";
			this.ImportFromXLS.Click += new System.EventHandler(this.ImportFromXLS_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 126);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "XLS file content:";
			// 
			// nDataGridView1
			// 
			this.nDataGridView1.AllowUserToAddRows = false;
			this.nDataGridView1.AllowUserToDeleteRows = false;
			this.nDataGridView1.AllowUserToResizeRows = false;
			this.nDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
			this.nDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.nDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.nDataGridView1.Location = new System.Drawing.Point(8, 142);
			this.nDataGridView1.Name = "nDataGridView1";
			this.nDataGridView1.ReadOnly = true;
			this.nDataGridView1.Size = new System.Drawing.Size(165, 228);
			this.nDataGridView1.TabIndex = 5;
			// 
			// ImportFromXLSX
			// 
			this.ImportFromXLSX.Location = new System.Drawing.Point(8, 67);
			this.ImportFromXLSX.Name = "ImportFromXLSX";
			this.ImportFromXLSX.Size = new System.Drawing.Size(165, 23);
			this.ImportFromXLSX.TabIndex = 2;
			this.ImportFromXLSX.Text = "Import From XLSX File";
			this.ImportFromXLSX.Click += new System.EventHandler(this.ImportFromXLSX_Click);
			// 
			// nCheckBox1
			// 
			this.nCheckBox1.AutoSize = true;
			this.nCheckBox1.ButtonProperties.BorderOffset = 2;
			this.nCheckBox1.Location = new System.Drawing.Point(8, 96);
			this.nCheckBox1.Name = "nCheckBox1";
			this.nCheckBox1.Size = new System.Drawing.Size(141, 17);
			this.nCheckBox1.TabIndex = 3;
			this.nCheckBox1.Text = "Load from range (A1:E3)";
			// 
			// NImportingFromXLSUC
			// 
			this.Controls.Add(this.ImportFromXLSX);
			this.Controls.Add(this.nDataGridView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ImportFromXLS);
			this.Controls.Add(this.ClearChart);
			this.Controls.Add(this.nCheckBox1);
			this.Name = "NImportingFromXLSUC";
			this.Size = new System.Drawing.Size(180, 376);
			((System.ComponentModel.ISupportInitialize)(this.nDataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }			

        #endregion

		#region Implementation

		private void InitTitleAndBackground()
		{
			// add a title
			NLabel title = nChartControl1.Labels.AddHeader("Import from Excel File");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
		}

		private void LoadData(string fileName)
		{
			nChartControl1.Clear();
			InitTitleAndBackground();

			NBarSeries bar0 = (NBarSeries)nChartControl1.Charts[0].Series.Add(SeriesType.Bar);
			bar0.Legend.Mode = SeriesLegendMode.DataPoints;
			NBarSeries bar1 = (NBarSeries)nChartControl1.Charts[0].Series.Add(SeriesType.Bar);
			bar1.Legend.Mode = SeriesLegendMode.DataPoints;
			bar1.MultiBarMode = MultiBarMode.Clustered;

			try
			{
				NExcelReader reader = new NExcelReader();
				DataTable dt;

				if (nCheckBox1.Checked)
				{
					dt = reader.ReadRange(fileName, "Sample", "A1:E3").Tables[0];
				}
				else
				{
					dt = reader.ReadAll(fileName).Tables[0];
										
				}

				DataColumnCollection columns = dt.Columns;
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", dt, columns[1].ColumnName);
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", dt, columns[0].ColumnName);
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", dt, columns[3].ColumnName);

				nChartControl1.DataBindingManager.AddBinding(0, 1, "Values", dt, columns[2].ColumnName);
				nChartControl1.DataBindingManager.AddBinding(0, 1, "Labels", dt, columns[0].ColumnName);
				nChartControl1.DataBindingManager.AddBinding(0, 1, "FillStyles", dt, columns[4].ColumnName);
				nDataGridView1.DataSource = dt;					

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			nChartControl1.Refresh();
		}

		#endregion

		#region Event handlres

		void ImportFromXLS_Click(object sender, EventArgs e)
		{
			string xlsFile = Application.StartupPath + "\\..\\..\\DataManipulation\\Importing\\Sample.xls";
			LoadData(xlsFile);
		}

		private void ImportFromXLSX_Click(object sender, EventArgs e)
		{
			string xlsFile = Application.StartupPath + "\\..\\..\\DataManipulation\\Importing\\Sample.xlsx";
			LoadData(xlsFile);
		}

		private void ClearChart_Click(object sender, System.EventArgs e)
		{
			nChartControl1.Clear();
			InitTitleAndBackground();
			nChartControl1.Refresh();
			nDataGridView1.DataSource = null;
		}	

		#endregion

		#region Fields

		private Nevron.UI.WinForm.Controls.NButton ClearChart;
		private Nevron.UI.WinForm.Controls.NButton ImportFromXLS;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NDataGridView nDataGridView1;
		private Nevron.UI.WinForm.Controls.NButton ImportFromXLSX;
		private Nevron.UI.WinForm.Controls.NCheckBox nCheckBox1;
		private System.ComponentModel.Container components = null;

		#endregion
	}
}
