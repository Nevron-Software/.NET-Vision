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
	public class NAutoLabelsXYZPointUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableLabelAdjustmentCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableInitialPositioningCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RemoveOverlappedLabelsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableDataPointSafeguardCheck;
		private Label label8;
		private Nevron.UI.WinForm.Controls.NNumericUpDown SafeguardSizeNumericUpDown;
		private System.ComponentModel.Container components = null;

		public NAutoLabelsXYZPointUC()
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
			this.EnableInitialPositioningCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RemoveOverlappedLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableDataPointSafeguardCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.SafeguardSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.SafeguardSizeNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// EnableLabelAdjustmentCheck
			// 
			this.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2;
			this.EnableLabelAdjustmentCheck.Location = new System.Drawing.Point(6, 115);
			this.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck";
			this.EnableLabelAdjustmentCheck.Size = new System.Drawing.Size(155, 21);
			this.EnableLabelAdjustmentCheck.TabIndex = 6;
			this.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment";
			this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(6, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(168, 24);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// EnableInitialPositioningCheck
			// 
			this.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2;
			this.EnableInitialPositioningCheck.Location = new System.Drawing.Point(6, 47);
			this.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck";
			this.EnableInitialPositioningCheck.Size = new System.Drawing.Size(169, 21);
			this.EnableInitialPositioningCheck.TabIndex = 7;
			this.EnableInitialPositioningCheck.Text = "Enable Initial Positioning";
			this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			// 
			// RemoveOverlappedLabelsCheck
			// 
			this.RemoveOverlappedLabelsCheck.ButtonProperties.BorderOffset = 2;
			this.RemoveOverlappedLabelsCheck.ButtonProperties.WrapText = true;
			this.RemoveOverlappedLabelsCheck.Location = new System.Drawing.Point(6, 68);
			this.RemoveOverlappedLabelsCheck.Name = "RemoveOverlappedLabelsCheck";
			this.RemoveOverlappedLabelsCheck.Size = new System.Drawing.Size(168, 41);
			this.RemoveOverlappedLabelsCheck.TabIndex = 8;
			this.RemoveOverlappedLabelsCheck.Text = "Remove Overlapped Labels After Initial Positioning";
			this.RemoveOverlappedLabelsCheck.CheckedChanged += new System.EventHandler(this.RemoveOverlappedLabelsCheck_CheckedChanged);
			// 
			// EnableDataPointSafeguardCheck
			// 
			this.EnableDataPointSafeguardCheck.ButtonProperties.BorderOffset = 2;
			this.EnableDataPointSafeguardCheck.Location = new System.Drawing.Point(6, 152);
			this.EnableDataPointSafeguardCheck.Name = "EnableDataPointSafeguardCheck";
			this.EnableDataPointSafeguardCheck.Size = new System.Drawing.Size(168, 21);
			this.EnableDataPointSafeguardCheck.TabIndex = 9;
			this.EnableDataPointSafeguardCheck.Text = "Enable Data Point Safeguard";
			this.EnableDataPointSafeguardCheck.CheckedChanged += new System.EventHandler(this.EnableDataPointSafeguardCheck_CheckedChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 186);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(161, 20);
			this.label8.TabIndex = 10;
			this.label8.Text = "Safeguard Size (in points):";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SafeguardSizeNumericUpDown
			// 
			this.SafeguardSizeNumericUpDown.Location = new System.Drawing.Point(6, 209);
			this.SafeguardSizeNumericUpDown.Name = "SafeguardSizeNumericUpDown";
			this.SafeguardSizeNumericUpDown.Size = new System.Drawing.Size(161, 20);
			this.SafeguardSizeNumericUpDown.TabIndex = 11;
			this.SafeguardSizeNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.SafeguardSizeNumericUpDown.ValueChanged += new System.EventHandler(this.SafeguardSizeNumericUpDown_ValueChanged);
			// 
			// NAutoLabelsXYZPointUC
			// 
			this.Controls.Add(this.label8);
			this.Controls.Add(this.SafeguardSizeNumericUpDown);
			this.Controls.Add(this.EnableDataPointSafeguardCheck);
			this.Controls.Add(this.RemoveOverlappedLabelsCheck);
			this.Controls.Add(this.EnableInitialPositioningCheck);
			this.Controls.Add(this.EnableLabelAdjustmentCheck);
			this.Controls.Add(this.GenerateDataButton);
			this.Name = "NAutoLabelsXYZPointUC";
			this.Size = new System.Drawing.Size(180, 390);
			((System.ComponentModel.ISupportInitialize)(this.SafeguardSizeNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XYZ Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NChart chart = nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight);
			chart.Depth = 55.0f;
			chart.Width = 55.0f;
			chart.Height = 55.0f;

			// set automatic walls
			foreach (NChartWall wall in chart.Walls)
			{
				wall.VisibilityMode = WallVisibilityMode.Auto;
			}

			// set auto axis anchors
			chart.Axis(StandardAxis.PrimaryX).Anchor = new NBestVisibilityAxisAnchor(AxisOrientation.Horizontal);
			chart.Axis(StandardAxis.PrimaryY).Anchor = new NBestVisibilityAxisAnchor(AxisOrientation.Vertical);
			chart.Axis(StandardAxis.Depth).Anchor = new NBestVisibilityAxisAnchor(AxisOrientation.Depth);

			// configure X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor, ChartWallType.Top, ChartWallType.Front };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// configure Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left, ChartWallType.Right, ChartWallType.Front };
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// add interlaced stripe for Y axis
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left, ChartWallType.Front, ChartWallType.Right };
			scaleY.StripStyles.Add(stripStyle);

			// configure Z axis
			NLinearScaleConfigurator scaleZ = new NLinearScaleConfigurator();
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleZ.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Floor, ChartWallType.Top, ChartWallType.Left, ChartWallType.Right };
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ;

			// point series 1
			NPointSeries series1 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			series1.Name = "Point 1";
			series1.PointShape = PointShape.Bar;
			series1.Size = new NLength(2.4f, NRelativeUnit.ParentPercentage);
			series1.UseXValues = true;
			series1.UseZValues = true;
			series1.InflateMargins = true;
			series1.FillStyle = new NColorFillStyle(DarkOrange);
			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Center;
			series1.DataLabelStyle.ArrowLength = new NLength(12);
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;

			// point series 2
			NPointSeries series2 = (NPointSeries)chart.Series.Add(SeriesType.Point);
			series2.Name = "Point 2";
			series2.PointShape = PointShape.Bar;
			series2.Size = new NLength(2.4f, NRelativeUnit.ParentPercentage);
			series2.UseXValues = true;
			series2.UseZValues = true;
			series2.InflateMargins = true;
			series2.FillStyle = new NColorFillStyle(LightOrange);
			series2.DataLabelStyle.Visible = true;
			series2.DataLabelStyle.VertAlign = VertAlign.Center;
			series2.DataLabelStyle.ArrowLength = new NLength(12);
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = LightOrange;

			// fill with random data
			GenerateData(chart);

			// label layout settings
			chart.LabelLayout.EnableInitialPositioning = true;
			chart.LabelLayout.EnableLabelAdjustment = true;

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// init form controls
			EnableLabelAdjustmentCheck.Checked = true;
			RemoveOverlappedLabelsCheck.Checked = false;
			EnableInitialPositioningCheck.Checked = true;
			EnableDataPointSafeguardCheck.Checked = true;
			SafeguardSizeNumericUpDown.Value = 12;
		}

		void GenerateData(NChart chart)
		{
			NPointSeries series0 = (NPointSeries)chart.Series[0];
			NPointSeries series1 = (NPointSeries)chart.Series[1];

			const int count = 12;

			series0.Values.FillRandomRange(Random, count, 0, 50);
			series0.XValues.FillRandomRange(Random, count, 0, 50);
			series0.ZValues.FillRandomRange(Random, count, 0, 50);

			series1.Values.FillRandomRange(Random, count, 25, 75);
			series1.XValues.FillRandomRange(Random, count, 25, 75);
			series1.ZValues.FillRandomRange(Random, count, 25, 75);
		}

		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			GenerateData(nChartControl1.Charts[0]);
			nChartControl1.Refresh();
		}
		private void EnableInitialPositioningCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			RemoveOverlappedLabelsCheck.Enabled = EnableInitialPositioningCheck.Checked;

			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked;

			nChartControl1.Refresh();
		}
		private void RemoveOverlappedLabelsCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheck.Checked;

			nChartControl1.Refresh();
		}
		private void EnableLabelAdjustmentCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			NChart chart = nChartControl1.Charts[0];
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked;

			nChartControl1.Refresh();
		}
		private void EnableDataPointSafeguardCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			SafeguardSizeNumericUpDown.Enabled = EnableDataPointSafeguardCheck.Checked;

			NChart chart = nChartControl1.Charts[0];
			chart.Series[0].LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheck.Checked;
			chart.Series[1].LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheck.Checked;

			nChartControl1.Refresh();
		}
		private void SafeguardSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (nChartControl1 == null)
				return;

			float sizeValue = (float)SafeguardSizeNumericUpDown.Value;

			NSizeL size = new NSizeL(new NLength(sizeValue, NGraphicsUnit.Point), new NLength(sizeValue, NGraphicsUnit.Point));

			NChart chart = nChartControl1.Charts[0];
			chart.Series[0].LabelLayout.DataPointSafeguardSize = size;
			chart.Series[1].LabelLayout.DataPointSafeguardSize = size;

			nChartControl1.Refresh();
		}
	}
}