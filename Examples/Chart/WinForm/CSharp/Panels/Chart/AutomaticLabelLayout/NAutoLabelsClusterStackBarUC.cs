using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAutoLabelsClusterStackBarUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableInitialPositioningCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableLabelAdjustmentCheck;
		private System.ComponentModel.Container components = null;

		public NAutoLabelsClusterStackBarUC()
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
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.EnableInitialPositioningCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableLabelAdjustmentCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(9, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(166, 24);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// EnableInitialPositioningCheck
			// 
			this.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2;
			this.EnableInitialPositioningCheck.Location = new System.Drawing.Point(9, 51);
			this.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck";
			this.EnableInitialPositioningCheck.Size = new System.Drawing.Size(166, 21);
			this.EnableInitialPositioningCheck.TabIndex = 14;
			this.EnableInitialPositioningCheck.Text = "Enable Initial Positioning";
			this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			// 
			// EnableLabelAdjustmentCheck
			// 
			this.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2;
			this.EnableLabelAdjustmentCheck.Location = new System.Drawing.Point(9, 82);
			this.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck";
			this.EnableLabelAdjustmentCheck.Size = new System.Drawing.Size(166, 19);
			this.EnableLabelAdjustmentCheck.TabIndex = 13;
			this.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment";
			this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			// 
			// NAutoLabelsClusterStackBarUC
			// 
			this.Controls.Add(this.EnableInitialPositioningCheck);
			this.Controls.Add(this.EnableLabelAdjustmentCheck);
			this.Controls.Add(this.GenerateDataButton);
			this.Name = "NAutoLabelsClusterStackBarUC";
			this.Size = new System.Drawing.Size(180, 265);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Cluster Stack Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

			// configure Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

			NSizeL dataPointSafeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));

			// series 1
			NBarSeries series1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			series1.Name = "Bar 1";
			series1.FillStyle = new NColorFillStyle(DarkOrange);
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Center;

			// series 2
			NBarSeries series2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			series2.Name = "Bar 2";
			series2.MultiBarMode = MultiBarMode.Stacked;
			series2.FillStyle = new NColorFillStyle(LightOrange);
			series2.DataLabelStyle.Visible = true;
			series2.DataLabelStyle.VertAlign = VertAlign.Center;

			// series 3
			NBarSeries series3 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			series3.Name = "Bar 3";
			series3.MultiBarMode = MultiBarMode.Clustered;
			series3.FillStyle = new NColorFillStyle(LightGreen);
			series3.DataLabelStyle.Visible = true;
			series3.DataLabelStyle.VertAlign = VertAlign.Top;
			series3.DataLabelStyle.ArrowLength = new NLength(10);

			// generate random data
			GenerateData(chart);

			// enable initial labels positioning
			chart.LabelLayout.EnableInitialPositioning = true;

			// enable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = true;

			// series 1 data points must not be overlapped
			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize;

			// do not use label location proposals for series 1
			series1.LabelLayout.UseLabelLocations = false;

			// series 2 data points must not be overlapped
			series2.LabelLayout.EnableDataPointSafeguard = true;
			series2.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize;

			// do not use label location proposals for series 2
			series2.LabelLayout.UseLabelLocations = false;

			// series 3 data points must not be overlapped
			series3.LabelLayout.EnableDataPointSafeguard = true;
			series3.LabelLayout.DataPointSafeguardSize = dataPointSafeguardSize;

			// series 3 data labels can be placed above and below the origin point
			series3.LabelLayout.UseLabelLocations = true;
			series3.LabelLayout.LabelLocations = new LabelLocation[] { LabelLocation.Top, LabelLocation.Bottom };
			series3.LabelLayout.InvertLocationsIfIgnored = false;
			series3.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// init form controls
			EnableInitialPositioningCheck.Checked = true;
			EnableLabelAdjustmentCheck.Checked = true;
		}

		void GenerateData(NChart chart)
		{
			((NSeries)chart.Series[0]).Values.FillRandomRange(Random, 10, 5.0, 20.0);
			((NSeries)chart.Series[1]).Values.FillRandomRange(Random, 10, 5.0, 20.0);
			((NSeries)chart.Series[2]).Values.FillRandomRange(Random, 10, 10.0, 20.0);
		}

		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			GenerateData(chart);

			nChartControl1.Refresh();
		}

		private void EnableInitialPositioningCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked;

			nChartControl1.Refresh();
		}

		private void EnableLabelAdjustmentCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked;

			nChartControl1.Refresh();
		}
	}
}