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
	public class NExportingToDataTableUC : NExampleBaseUC
	{
		private System.Windows.Forms.DataGrid DataGrid;
		private Nevron.UI.WinForm.Controls.NComboBox ChartCombo;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NButton ExportToDataTable;
		private System.Data.DataView dataView1;
		private System.ComponentModel.Container components = null;

		public NExportingToDataTableUC()
		{
			InitializeComponent();

			ChartCombo.Items.Add("Bar Chart");
			ChartCombo.Items.Add("Line Chart with X Values");
			ChartCombo.Items.Add("Pie Chart with Detachments");
			ChartCombo.Items.Add("Open High Low Close");
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
			this.DataGrid = new System.Windows.Forms.DataGrid();
			this.dataView1 = new System.Data.DataView();
			this.ChartCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ExportToDataTable = new Nevron.UI.WinForm.Controls.NButton();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			this.SuspendLayout();
			// 
			// DataGrid
			// 
			this.DataGrid.AllowSorting = false;
			this.DataGrid.CaptionVisible = false;
			this.DataGrid.DataMember = "";
			this.DataGrid.DataSource = this.dataView1;
			this.DataGrid.FlatMode = true;
			this.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DataGrid.Location = new System.Drawing.Point(8, 8);
			this.DataGrid.Name = "DataGrid";
			this.DataGrid.ReadOnly = true;
			this.DataGrid.Size = new System.Drawing.Size(345, 160);
			this.DataGrid.TabIndex = 1;
			// 
			// ChartCombo
			// 
			this.ChartCombo.Location = new System.Drawing.Point(360, 28);
			this.ChartCombo.Name = "ChartCombo";
			this.ChartCombo.Size = new System.Drawing.Size(160, 21);
			this.ChartCombo.TabIndex = 2;
			this.ChartCombo.SelectedIndexChanged += new System.EventHandler(this.ChartCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(360, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Predefined Chart:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ExportToDataTable
			// 
			this.ExportToDataTable.Location = new System.Drawing.Point(360, 65);
			this.ExportToDataTable.Name = "ExportToDataTable";
			this.ExportToDataTable.Size = new System.Drawing.Size(160, 23);
			this.ExportToDataTable.TabIndex = 4;
			this.ExportToDataTable.Text = "Export To Data Table";
			this.ExportToDataTable.Click += new System.EventHandler(this.ExportToDataTable_Click);
			// 
			// NExportingToDataTableUC
			// 
			this.Controls.Add(this.ExportToDataTable);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ChartCombo);
			this.Controls.Add(this.DataGrid);
			this.Name = "NExportingToDataTableUC";
			this.Size = new System.Drawing.Size(528, 186);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Export to Data Table");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 20, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid;
			title.TextStyle.ShadowStyle.Color = Color.White;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			ChartCombo.SelectedIndex = 0;
		}

		private void ChartCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NChart chart = null;
			nChartControl1.Charts.Clear();

			switch (ChartCombo.SelectedIndex)
			{
				case 0: // Bar Chart
				{
					chart = new NCartesianChart();
					chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NOrdinalScaleConfigurator();

					NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
					bar.Values.FillRandom(Random, 10);
					bar.Labels.FillRandom(Random, 10);
					break;
				}

				case 1: // Line Chart With X Values
				{
					chart = new NCartesianChart();
					chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();

					NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
					line.UseXValues = true;
					line.Values.FillRandom(Random, 10);
					line.Labels.FillRandom(Random, 10);

					double x = 1;
					for (int i = 0; i < 10; i++)
					{
						line.XValues.Add(x);
						x += Random.NextDouble() * 2 + 0.2;
					}

					break;
				}

				case 2: // Pie Chart with detachments
				{
					chart = new NPieChart();
					NPieSeries pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
					pie.Values.FillRandom(Random, 10);
					pie.Labels.FillRandom(Random, 10);

					for (int i = 0; i < 10; i++)
					{
						pie.FillStyles[i] = new NColorFillStyle(RandomColor());
						pie.Detachments.Add(5 + (double)Random.Next(20));
					}

					break;
				}

				case 3: // Open - High - Low - Close
				{
					chart = new NCartesianChart();
					chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NOrdinalScaleConfigurator();

					NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
					stock.DataLabelStyle.Visible = false;
					GenerateOHLCData(stock, 300, 20);
					break;
				}
			}

			if (chart is NCartesianChart)
			{
				((NCartesianChart)chart).BoundsMode = BoundsMode.Stretch;
			}

			chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
			nChartControl1.Panels.Add(chart);
			chart.DisplayOnLegend = nChartControl1.Legends[0];
			
			nChartControl1.Refresh();
		}

		private void ExportToDataTable_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NDataSeriesCollection arrSeries = new NDataSeriesCollection();
			string sTableName = "";

			switch (ChartCombo.SelectedIndex)
			{
				case 0: // Bar Chart
					NBarSeries bar = (NBarSeries)chart.Series[0];
					sTableName = "Bar Chart";
					
					arrSeries.Add(bar.Values, DataSeriesMask.Values);
					arrSeries.Add(bar.Labels, DataSeriesMask.Labels);
					break;

				case 1: // Line Chart With X Values
					NLineSeries line = (NLineSeries)chart.Series[0];
					sTableName = "Line Chart";

					arrSeries.Add(line.Values, DataSeriesMask.Values);
					arrSeries.Add(line.XValues, DataSeriesMask.XValues);
					arrSeries.Add(line.Labels, DataSeriesMask.Labels);
					break;

				case 2: // Pie Chart with detachments
					NPieSeries pie = (NPieSeries)chart.Series[0];
					sTableName = "Pie Chart";

					arrSeries.Add(pie.Values, DataSeriesMask.Values);
					arrSeries.Add(pie.Detachments, DataSeriesMask.PieDetachments);
					arrSeries.Add(pie.Labels, DataSeriesMask.Labels);
					break;

				case 3: // Open - High - Low - Close
					NStockSeries stock = (NStockSeries)chart.Series[0];
					sTableName = "Stock Chart";

					arrSeries.Add(stock.OpenValues, DataSeriesMask.StockOpenValues);
					arrSeries.Add(stock.HighValues, DataSeriesMask.StockHighValues);
					arrSeries.Add(stock.LowValues, DataSeriesMask.StockLowValues);
					arrSeries.Add(stock.CloseValues, DataSeriesMask.StockCloseValues);
					break;
			}

			dataView1.Table = arrSeries.ExportToDataTable(sTableName);

			nChartControl1.Refresh();
		}

	}
}
