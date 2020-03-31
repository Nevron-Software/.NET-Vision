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
	public class NAutoLabelsPolarUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NButton GenerateDataButton;
		private Label label8;
		private Nevron.UI.WinForm.Controls.NNumericUpDown SafeguardSizeNumericUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableDataPointSafeguardCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox RemoveOverlappedLabelsCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableInitialPositioningCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableLabelAdjustmentCheck;
		private System.ComponentModel.Container components = null;

		public NAutoLabelsPolarUC()
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
			this.label8 = new System.Windows.Forms.Label();
			this.SafeguardSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.EnableDataPointSafeguardCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RemoveOverlappedLabelsCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableInitialPositioningCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.EnableLabelAdjustmentCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.SafeguardSizeNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// GenerateDataButton
			// 
			this.GenerateDataButton.Location = new System.Drawing.Point(3, 9);
			this.GenerateDataButton.Name = "GenerateDataButton";
			this.GenerateDataButton.Size = new System.Drawing.Size(175, 24);
			this.GenerateDataButton.TabIndex = 4;
			this.GenerateDataButton.Text = "Generate Data";
			this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3, 186);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(175, 20);
			this.label8.TabIndex = 22;
			this.label8.Text = "Safeguard Size (in points):";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SafeguardSizeNumericUpDown
			// 
			this.SafeguardSizeNumericUpDown.Location = new System.Drawing.Point(3, 209);
			this.SafeguardSizeNumericUpDown.Name = "SafeguardSizeNumericUpDown";
			this.SafeguardSizeNumericUpDown.Size = new System.Drawing.Size(175, 20);
			this.SafeguardSizeNumericUpDown.TabIndex = 23;
			this.SafeguardSizeNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.SafeguardSizeNumericUpDown.ValueChanged += new System.EventHandler(this.SafeguardSizeNumericUpDown_ValueChanged);
			// 
			// EnableDataPointSafeguardCheck
			// 
			this.EnableDataPointSafeguardCheck.ButtonProperties.BorderOffset = 2;
			this.EnableDataPointSafeguardCheck.Location = new System.Drawing.Point(3, 152);
			this.EnableDataPointSafeguardCheck.Name = "EnableDataPointSafeguardCheck";
			this.EnableDataPointSafeguardCheck.Size = new System.Drawing.Size(169, 21);
			this.EnableDataPointSafeguardCheck.TabIndex = 21;
			this.EnableDataPointSafeguardCheck.Text = "Enable Data Point Safeguard";
			this.EnableDataPointSafeguardCheck.CheckedChanged += new System.EventHandler(this.EnableDataPointSafeguardCheck_CheckedChanged);
			// 
			// RemoveOverlappedLabelsCheck
			// 
			this.RemoveOverlappedLabelsCheck.ButtonProperties.BorderOffset = 2;
			this.RemoveOverlappedLabelsCheck.ButtonProperties.WrapText = true;
			this.RemoveOverlappedLabelsCheck.Location = new System.Drawing.Point(3, 68);
			this.RemoveOverlappedLabelsCheck.Name = "RemoveOverlappedLabelsCheck";
			this.RemoveOverlappedLabelsCheck.Size = new System.Drawing.Size(169, 41);
			this.RemoveOverlappedLabelsCheck.TabIndex = 20;
			this.RemoveOverlappedLabelsCheck.Text = "Remove Overlapped Labels After Initial Positioning";
			this.RemoveOverlappedLabelsCheck.CheckedChanged += new System.EventHandler(this.RemoveOverlappedLabelsCheck_CheckedChanged);
			// 
			// EnableInitialPositioningCheck
			// 
			this.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2;
			this.EnableInitialPositioningCheck.Location = new System.Drawing.Point(3, 47);
			this.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck";
			this.EnableInitialPositioningCheck.Size = new System.Drawing.Size(169, 21);
			this.EnableInitialPositioningCheck.TabIndex = 19;
			this.EnableInitialPositioningCheck.Text = "Enable Initial Positioning";
			this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			// 
			// EnableLabelAdjustmentCheck
			// 
			this.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2;
			this.EnableLabelAdjustmentCheck.Location = new System.Drawing.Point(3, 115);
			this.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck";
			this.EnableLabelAdjustmentCheck.Size = new System.Drawing.Size(169, 21);
			this.EnableLabelAdjustmentCheck.TabIndex = 18;
			this.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment";
			this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			// 
			// NAutoLabelsPolarUC
			// 
			this.Controls.Add(this.label8);
			this.Controls.Add(this.SafeguardSizeNumericUpDown);
			this.Controls.Add(this.EnableDataPointSafeguardCheck);
			this.Controls.Add(this.RemoveOverlappedLabelsCheck);
			this.Controls.Add(this.EnableInitialPositioningCheck);
			this.Controls.Add(this.EnableLabelAdjustmentCheck);
			this.Controls.Add(this.GenerateDataButton);
			this.Name = "NAutoLabelsPolarUC";
			this.Size = new System.Drawing.Size(180, 284);
			((System.ComponentModel.ISupportInitialize)(this.SafeguardSizeNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);

			// configure the chart
			NPolarChart chart = new NPolarChart();
			nChartControl1.Charts.Add(chart);

			chart.LabelLayout.EnableInitialPositioning = true;
			chart.LabelLayout.EnableLabelAdjustment = true;

			// setup polar value axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.Polar).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

			// setup polar angle axis
			NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

			// polar point series
			NPolarPointSeries series1 = (NPolarPointSeries)chart.Series.Add(SeriesType.PolarPoint);
			series1.PointShape = PointShape.Ellipse;
			series1.Size = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series1.InflateMargins = true;
			series1.FillStyle = new NColorFillStyle(DarkOrange);

			series1.DataLabelStyle.Visible = true;
			series1.DataLabelStyle.VertAlign = VertAlign.Center;
			series1.DataLabelStyle.ArrowLength = new NLength(12);
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange;
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange;
			
			series1.LabelLayout.EnableDataPointSafeguard = true;
			series1.LabelLayout.DataPointSafeguardSize = new NSizeL(
				new NLength(1.3f, NRelativeUnit.ParentPercentage),
				new NLength(1.3f, NRelativeUnit.ParentPercentage));
			series1.LabelLayout.UseLabelLocations = true;
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds;
			series1.LabelLayout.InvertLocationsIfIgnored = true;

			// fill with random data
			GenerateData(series1);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			EnableLabelAdjustmentCheck.Checked = true;
			RemoveOverlappedLabelsCheck.Checked = false;
			EnableInitialPositioningCheck.Checked = true;
			EnableDataPointSafeguardCheck.Checked = true;
			SafeguardSizeNumericUpDown.Value = 12;
		}

		void GenerateData(NPolarPointSeries series)
		{
			series.Values.FillRandomRange(Random, 25, 0.0, 100.0);
			series.Angles.FillRandomRange(Random, 25, 0.0, 360.0);
		}

		private void GenerateDataButton_Click(object sender, System.EventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NPolarPointSeries series = (NPolarPointSeries)chart.Series[0];

			GenerateData(series);

			nChartControl1.Refresh();
		}
		private void EnableInitialPositioningCheck_CheckedChanged(object sender, EventArgs e)
		{
			RemoveOverlappedLabelsCheck.Enabled = EnableInitialPositioningCheck.Checked;

			if (nChartControl1 == null)
				return;

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
		private void EnableLabelAdjustmentCheck_CheckedChanged(object sender, EventArgs e)
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

			nChartControl1.Refresh();
		}
	}
}