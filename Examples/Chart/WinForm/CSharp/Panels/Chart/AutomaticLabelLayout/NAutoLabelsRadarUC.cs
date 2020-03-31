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

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NAutoLabelsRadarUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableInitialPositioningCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableLabelAdjustmentCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox StackRadarAreasCheck;
		private System.ComponentModel.Container components = null;

		public NAutoLabelsRadarUC()
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
			this.StackRadarAreasCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(4, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(171, 24);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// EnableInitialPositioningCheck
			// 
			this.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2;
			this.EnableInitialPositioningCheck.Location = new System.Drawing.Point(4, 47);
			this.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck";
			this.EnableInitialPositioningCheck.Size = new System.Drawing.Size(166, 21);
			this.EnableInitialPositioningCheck.TabIndex = 12;
			this.EnableInitialPositioningCheck.Text = "Enable Initial Positioning";
			this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			// 
			// EnableLabelAdjustmentCheck
			// 
			this.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2;
			this.EnableLabelAdjustmentCheck.Location = new System.Drawing.Point(4, 78);
			this.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck";
			this.EnableLabelAdjustmentCheck.Size = new System.Drawing.Size(166, 21);
			this.EnableLabelAdjustmentCheck.TabIndex = 11;
			this.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment";
			this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			// 
			// StackRadarAreasCheck
			// 
			this.StackRadarAreasCheck.ButtonProperties.BorderOffset = 2;
			this.StackRadarAreasCheck.Location = new System.Drawing.Point(5, 148);
			this.StackRadarAreasCheck.Name = "StackRadarAreasCheck";
			this.StackRadarAreasCheck.Size = new System.Drawing.Size(166, 21);
			this.StackRadarAreasCheck.TabIndex = 13;
			this.StackRadarAreasCheck.Text = "Stack Radar Areas";
			this.StackRadarAreasCheck.CheckedChanged += new System.EventHandler(this.StackRadarAreasCheck_CheckedChanged);
			// 
			// NAutoLabelsRadarUC
			// 
			this.Controls.Add(this.StackRadarAreasCheck);
			this.Controls.Add(this.EnableInitialPositioningCheck);
			this.Controls.Add(this.EnableLabelAdjustmentCheck);
			this.Controls.Add(this.GenerateDataButton);
			this.Name = "NAutoLabelsRadarUC";
			this.Size = new System.Drawing.Size(180, 262);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Radar Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NRadarChart chart = new NRadarChart();
			nChartControl1.Charts.Add(chart);

			AddRadarAxis(chart, "Category A");
			AddRadarAxis(chart, "Category B");
			AddRadarAxis(chart, "Category C");
			AddRadarAxis(chart, "Category D");
			AddRadarAxis(chart, "Category E");
			AddRadarAxis(chart, "Category F");
			AddRadarAxis(chart, "Category G");

			// radar area series 1
			NRadarAreaSeries series1 = (NRadarAreaSeries)chart.Series.Add(SeriesType.RadarArea);
			series1.FillStyle = new NColorFillStyle(DarkOrange);
			series1.BorderStyle.Color = DarkOrange;
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Top;
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange;
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;

			// radar area series 2
			NRadarAreaSeries series2 = (NRadarAreaSeries)chart.Series.Add(SeriesType.RadarArea);
			series2.FillStyle = new NColorFillStyle(LightOrange);
			series2.BorderStyle.Color = LightOrange;
			series2.DataLabelStyle.Visible = true;
			series2.DataLabelStyle.VertAlign = VertAlign.Top;
			series2.DataLabelStyle.ArrowStrokeStyle.Color = LightOrange;
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = LightOrange;

			// label layout settings
			chart.LabelLayout.EnableInitialPositioning = true;
			chart.LabelLayout.EnableLabelAdjustment = true;

			NSizeL safeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));

			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.UseLabelLocations = true;
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.InvertLocationsIfIgnored = false;
			series1.LabelLayout.DataPointSafeguardSize = safeguardSize;

			series2.LabelLayout.EnableDataPointSafeguard = true;
			series2.LabelLayout.UseLabelLocations = true;
			series2.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series2.LabelLayout.InvertLocationsIfIgnored = false;
			series2.LabelLayout.DataPointSafeguardSize = safeguardSize;

			// fill with random data
			GenerateData(series1, series2);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			EnableInitialPositioningCheck.Checked = true;
			EnableLabelAdjustmentCheck.Checked = true;
			StackRadarAreasCheck.Checked = false;
		}

		private void AddRadarAxis(NRadarChart chart, string title)
		{
			NRadarAxis axis = new NRadarAxis();

			// set title
			axis.Title = title;

			// the axis scale should start from 0
			axis.View = new NRangeAxisView(new NRange1DD(0, 0), true, false);

			// setup scale
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			linearScale.RulerStyle.BorderStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Silver;
			linearScale.InnerMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);
			linearScale.OuterMajorTickStyle.Length = new NLength(2, NGraphicsUnit.Point);

			if (chart.Axes.Count == 0)
			{
				// if the first axis then configure grid style and stripes
				linearScale.MajorGridStyle.LineStyle.Color = Color.Gainsboro;
				linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
				linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Radar, true);

				// add interlaced stripe
				NScaleStripStyle strip = new NScaleStripStyle();
				strip.FillStyle = new NColorFillStyle(Color.FromArgb(64, 200, 200, 200));
				strip.Interlaced = true;
				strip.SetShowAtWall(ChartWallType.Radar, true);
				linearScale.StripStyles.Add(strip);
			}
			else
			{
				// hide labels
				linearScale.AutoLabels = false;
			}

			chart.Axes.Add(axis);
		}

		private void GenerateData(NSeries series0, NSeries series1)
		{
			series0.Values.FillRandomRange(Random, 7, 30.0, 80.0);
			series1.Values.FillRandomRange(Random, 7, 20.0, 60.0);			
		}

		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series0 = (NSeries)chart.Series[0];
			NSeries series1 = (NSeries)chart.Series[1];

			GenerateData(series0, series1);

			nChartControl1.Refresh();
		}

		private void EnableInitialPositioningCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked;

			nChartControl1.Refresh();
		}

		private void EnableLabelAdjustmentCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked;

			nChartControl1.Refresh();
		}

		private void StackRadarAreasCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NRadarAreaSeries radarArea = (NRadarAreaSeries)chart.Series[1];

			if (StackRadarAreasCheck.Checked)
			{
				radarArea.MultiAreaMode = MultiAreaMode.Stacked;
			}
			else
			{
				radarArea.MultiAreaMode = MultiAreaMode.Series;
			}

			nChartControl1.Refresh();
		}
	}
}