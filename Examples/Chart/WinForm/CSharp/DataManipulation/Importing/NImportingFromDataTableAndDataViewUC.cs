using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NImportingFromDataTableAndDataViewUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton ClearChart;
		private Nevron.UI.WinForm.Controls.NButton ImportFromDataTable;
		private Nevron.UI.WinForm.Controls.NButton ImportFromDataView;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.DataGrid DataGrid;
		private System.ComponentModel.Container components = null;

		public NImportingFromDataTableAndDataViewUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataView1 = new System.Data.DataView();
			this.DataGrid = new System.Windows.Forms.DataGrid();
			this.ClearChart = new Nevron.UI.WinForm.Controls.NButton();
			this.ImportFromDataTable = new Nevron.UI.WinForm.Controls.NButton();
			this.ImportFromDataView = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// DataGrid
			// 
			this.DataGrid.DataMember = "";
			this.DataGrid.DataSource = this.dataView1;
			this.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DataGrid.Location = new System.Drawing.Point(9, 8);
			this.DataGrid.Name = "DataGrid";
			this.DataGrid.Size = new System.Drawing.Size(193, 160);
			this.DataGrid.TabIndex = 0;
			this.DataGrid.TextChanged += new System.EventHandler(this.DataGrid_TextChanged);
			// 
			// ClearChart
			// 
			this.ClearChart.Location = new System.Drawing.Point(9, 178);
			this.ClearChart.Name = "ClearChart";
			this.ClearChart.Size = new System.Drawing.Size(193, 23);
			this.ClearChart.TabIndex = 4;
			this.ClearChart.Text = "Clear Chart";
			this.ClearChart.Click += new System.EventHandler(this.ClearChart_Click);
			// 
			// ImportFromDataTable
			// 
			this.ImportFromDataTable.Location = new System.Drawing.Point(9, 210);
			this.ImportFromDataTable.Name = "ImportFromDataTable";
			this.ImportFromDataTable.Size = new System.Drawing.Size(193, 23);
			this.ImportFromDataTable.TabIndex = 5;
			this.ImportFromDataTable.Text = "Import From Data Table";
			this.ImportFromDataTable.Click += new System.EventHandler(this.ImportFromDataTable_Click);
			// 
			// ImportFromDataView
			// 
			this.ImportFromDataView.Location = new System.Drawing.Point(9, 242);
			this.ImportFromDataView.Name = "ImportFromDataView";
			this.ImportFromDataView.Size = new System.Drawing.Size(193, 23);
			this.ImportFromDataView.TabIndex = 6;
			this.ImportFromDataView.Text = "Import From Data View";
			this.ImportFromDataView.Click += new System.EventHandler(this.ImportFromDataView_Click);
			// 
			// NImportingFromDataTableAndDataViewUC
			// 
			this.Controls.Add(this.ImportFromDataView);
			this.Controls.Add(this.ImportFromDataTable);
			this.Controls.Add(this.ClearChart);
			this.Controls.Add(this.DataGrid);
			this.Name = "NImportingFromDataTableAndDataViewUC";
			this.Size = new System.Drawing.Size(211, 284);
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			SetupChartTitle();

			// create a data table and bind it to the view
			DataTable table = new DataTable("MyTable");
			dataView1.Table = table;

			table.Columns.Add("Values", typeof(double));
			table.Columns.Add("Labels", typeof(string));

			table.Rows.Add(new object[] { 31, "Item1" });
			table.Rows.Add(new object[] { 24, "Item2" });
			table.Rows.Add(new object[] { 43, "Item3" });
			table.Rows.Add(new object[] { 34, "Item4" });

			dataView1.Table = table;
		}

		private void SetupChartTitle()
		{
			NLabel title = nChartControl1.Labels.AddHeader("Import from Data View");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
		}

		private void DataGrid_TextChanged(object sender, System.EventArgs e)
		{
			nChartControl1.Refresh();
		}

		private void ClearChart_Click(object sender, System.EventArgs e)
		{
			nChartControl1.Clear();
			SetupChartTitle();
			nChartControl1.Refresh();		
		}

		private void ImportFromDataTable_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Series.Clear();

			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);

			NDataSeriesCollection arrSeries = new NDataSeriesCollection();
			arrSeries.Add(bar.Values, DataSeriesMask.Values);
			arrSeries.Add(bar.Labels, DataSeriesMask.Labels);

			string[] arrCollumns = { "Values", "Labels" };
			arrSeries.FillFromDataTable(dataView1.Table, arrCollumns);

			nChartControl1.Refresh();
		}

		private void ImportFromDataView_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Series.Clear();

			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);

			NDataSeriesCollection arrSeries = new NDataSeriesCollection();
			arrSeries.Add(bar.Values, DataSeriesMask.Values);
			arrSeries.Add(bar.Labels, DataSeriesMask.Labels);

			string[] arrCollumns = { "Values", "Labels" };
			arrSeries.FillFromDataView(dataView1, arrCollumns);

			nChartControl1.Refresh();
		}
	}
}
