using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;


namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NSortedPieUC : NExampleBaseUC
	{
		private NPieSeries m_Pie;
		private Nevron.UI.WinForm.Controls.NButton SortAscendingButton;
		private Nevron.UI.WinForm.Controls.NButton SortDescendingButton;
		private Nevron.UI.WinForm.Controls.NButton ChangeDataButton;
		private System.ComponentModel.Container components = null;

		public NSortedPieUC()
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
			this.SortAscendingButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SortDescendingButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.SuspendLayout();
			// 
			// SortAscendingButton
			// 
			this.SortAscendingButton.Location = new System.Drawing.Point(5, 41);
			this.SortAscendingButton.Name = "SortAscendingButton";
			this.SortAscendingButton.Size = new System.Drawing.Size(170, 24);
			this.SortAscendingButton.TabIndex = 1;
			this.SortAscendingButton.Text = "Sort Ascending";
			this.SortAscendingButton.Click += new System.EventHandler(this.SortAscendingButton_Click);
			// 
			// SortDescendingButton
			// 
			this.SortDescendingButton.Location = new System.Drawing.Point(5, 73);
			this.SortDescendingButton.Name = "SortDescendingButton";
			this.SortDescendingButton.Size = new System.Drawing.Size(170, 24);
			this.SortDescendingButton.TabIndex = 2;
			this.SortDescendingButton.Text = "Sort Descending";
			this.SortDescendingButton.Click += new System.EventHandler(this.SortDescendingButton_Click);
			// 
			// ChangeDataButton
			// 
			this.ChangeDataButton.Location = new System.Drawing.Point(5, 9);
			this.ChangeDataButton.Name = "ChangeDataButton";
			this.ChangeDataButton.Size = new System.Drawing.Size(170, 24);
			this.ChangeDataButton.TabIndex = 0;
			this.ChangeDataButton.Text = "Change Data";
			this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			// 
			// NSortedPieUC
			// 
			this.Controls.Add(this.ChangeDataButton);
			this.Controls.Add(this.SortDescendingButton);
			this.Controls.Add(this.SortAscendingButton);
			this.Name = "NSortedPieUC";
			this.Size = new System.Drawing.Size(180, 129);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Sorted Pie Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NChart chart = new NPieChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);

			// configure the chart
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.VividCameraLight);
			chart.DisplayOnLegend = nChartControl1.Legends[0];
			chart.Location = new NPointL(new NLength(20, NRelativeUnit.ParentPercentage), new NLength(20, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(60, NRelativeUnit.ParentPercentage));

			// configure the legend
			NLegend legend = nChartControl1.Legends[0];
			legend.FillStyle = new NColorFillStyle(Color.FromArgb(100, Color.White));

			// configure the pie series
			m_Pie = (NPieSeries)chart.Series.Add(SeriesType.Pie);
			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints;
			m_Pie.Legend.Format = "<label> <percent>";

			// add data
			m_Pie.BorderStyle.Color = Color.LightGray;
			m_Pie.AddDataPoint(new NDataPoint(0, "Cars"));
			m_Pie.AddDataPoint(new NDataPoint(0, "Trains"));
			m_Pie.AddDataPoint(new NDataPoint(0, "Airplanes"));
			m_Pie.AddDataPoint(new NDataPoint(0, "Buses"));
			m_Pie.AddDataPoint(new NDataPoint(0, "Ships"));

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

			ChangeDataButton_Click(null, null);
		}

		private void ChangeDataButton_Click(object sender, System.EventArgs e)
		{
			m_Pie.Values.FillRandom(Random, 5);
			nChartControl1.Refresh();
		}

		private void SortAscendingButton_Click(object sender, System.EventArgs e)
		{
			DataSeriesMask included = DataSeriesMask.RandomAccess | 
										DataSeriesMask.FillStyles | 
										DataSeriesMask.StrokeStyles | 
										DataSeriesMask.DataLabelStyles;
			DataSeriesMask excluded = DataSeriesMask.PieDetachments;
			NDataSeriesCollection arr = m_Pie.GetDataSeries(included, excluded, false);

			int masterDataSeries = arr.FindByMask(DataSeriesMask.Values);
			arr.Sort(masterDataSeries, DataSeriesSortOrder.Ascending);

			nChartControl1.Refresh();
		}

		private void SortDescendingButton_Click(object sender, System.EventArgs e)
		{
			DataSeriesMask included = DataSeriesMask.RandomAccess | 
										DataSeriesMask.FillStyles |
										DataSeriesMask.StrokeStyles |
										DataSeriesMask.DataLabelStyles;
			DataSeriesMask excluded = DataSeriesMask.PieDetachments;
			NDataSeriesCollection arr = m_Pie.GetDataSeries(included, excluded, false);

			int masterDataSeries = arr.FindByMask(DataSeriesMask.Values);
			arr.Sort(masterDataSeries, DataSeriesSortOrder.Descending);

			nChartControl1.Refresh();
		}

	}
}
