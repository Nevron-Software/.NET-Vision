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
	public class NAutoLabelsAreaUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NCheckBox EnableLabelAdjustmentCheck;
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableDataPointSafeguardCheck;
		private System.ComponentModel.Container components = null;

		public NAutoLabelsAreaUC()
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
			this.EnableLabelAdjustmentCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.GenerateDataButton = new Nevron.UI.WinForm.Controls.NButton();
			this.EnableDataPointSafeguardCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// EnableLabelAdjustmentCheck
			// 
			this.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2;
			this.EnableLabelAdjustmentCheck.Location = new System.Drawing.Point(5, 50);
			this.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck";
			this.EnableLabelAdjustmentCheck.Size = new System.Drawing.Size(171, 21);
			this.EnableLabelAdjustmentCheck.TabIndex = 6;
			this.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment";
			this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(5, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(171, 24);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// EnableDataPointSafeguardCheck
			// 
			this.EnableDataPointSafeguardCheck.ButtonProperties.BorderOffset = 2;
			this.EnableDataPointSafeguardCheck.Location = new System.Drawing.Point(5, 83);
			this.EnableDataPointSafeguardCheck.Name = "EnableDataPointSafeguardCheck";
			this.EnableDataPointSafeguardCheck.Size = new System.Drawing.Size(171, 21);
			this.EnableDataPointSafeguardCheck.TabIndex = 10;
			this.EnableDataPointSafeguardCheck.Text = "Enable Data Point Safeguard";
			this.EnableDataPointSafeguardCheck.CheckedChanged += new System.EventHandler(this.EnableDataPointSafeguardCheck_CheckedChanged);
			// 
			// NAutoLabelsAreaUC
			// 
			this.Controls.Add(this.EnableDataPointSafeguardCheck);
			this.Controls.Add(this.EnableLabelAdjustmentCheck);
			this.Controls.Add(this.GenerateDataButton);
			this.Name = "NAutoLabelsAreaUC";
			this.Size = new System.Drawing.Size(180, 148);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Area Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Height = 30;
			chart.Depth = 5;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective);

			// configure X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// configure Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// hide the Z axis
			chart.Axis(StandardAxis.Depth).Visible = false;

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

			// area series
			NAreaSeries series1 = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			series1.InflateMargins = true;
			series1.UseXValues = true;
			series1.FillStyle = new NColorFillStyle(DarkOrange);
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Top;
			series1.DataLabelStyle.ArrowLength = new NLength(10);
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange;
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;

			// disable initial label positioning
			chart.LabelLayout.EnableInitialPositioning = false;

			// enable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = true;

			// enable the data point safesuard and set its size
			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.DataPointSafeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));

			// fill with random data
			GenerateData(series1);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			EnableLabelAdjustmentCheck.Checked = true;
			EnableDataPointSafeguardCheck.Checked = true;
		}

		void GenerateData(NAreaSeries series)
		{
			series.Values.Clear();
			series.XValues.Clear();

			double xvalue = 10;

			for (int i = 0; i < 24; i++)
			{
				double value = Math.Sin(i * 0.4) * 5 + Random.NextDouble() * 3;
				xvalue += 1 + Random.NextDouble() * 20;

				series.Values.Add(value);
				series.XValues.Add(xvalue);
			}
		}

		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NAreaSeries series = (NAreaSeries)chart.Series[0];

			GenerateData(series);

			nChartControl1.Refresh();
		}
		private void EnableLabelAdjustmentCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			EnableDataPointSafeguardCheck.Enabled = EnableLabelAdjustmentCheck.Checked;

			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked;

			nChartControl1.Refresh();
		}

		private void EnableDataPointSafeguardCheck_CheckedChanged(object sender, EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			chart.Series[0].LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheck.Checked;

			nChartControl1.Refresh();
		}
	}
}