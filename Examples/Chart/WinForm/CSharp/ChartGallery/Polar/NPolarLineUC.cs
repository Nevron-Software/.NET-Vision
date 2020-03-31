using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPolarLineUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NComboBox AngleStepCombo;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
		private Label label6;
		private System.ComponentModel.Container components = null;

		public NPolarLineUC()
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
			this.AngleStepCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.BeginAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// AngleStepCombo
			// 
			this.AngleStepCombo.ListProperties.CheckBoxDataMember = "";
			this.AngleStepCombo.ListProperties.DataSource = null;
			this.AngleStepCombo.ListProperties.DisplayMember = "";
			this.AngleStepCombo.Location = new System.Drawing.Point(9, 78);
			this.AngleStepCombo.Name = "AngleStepCombo";
			this.AngleStepCombo.Size = new System.Drawing.Size(162, 21);
			this.AngleStepCombo.TabIndex = 28;
			this.AngleStepCombo.SelectedIndexChanged += new System.EventHandler(this.AngleStepCombo_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(162, 16);
			this.label3.TabIndex = 27;
			this.label3.Text = "Radian Angle Step:";
			// 
			// BeginAngleUpDown
			// 
			this.BeginAngleUpDown.Location = new System.Drawing.Point(9, 30);
			this.BeginAngleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.BeginAngleUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.BeginAngleUpDown.Name = "BeginAngleUpDown";
			this.BeginAngleUpDown.Size = new System.Drawing.Size(161, 20);
			this.BeginAngleUpDown.TabIndex = 26;
			this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(9, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(162, 17);
			this.label6.TabIndex = 25;
			this.label6.Text = "Begin Angle:";
			// 
			// NPolarLineUC
			// 
			this.Controls.Add(this.AngleStepCombo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BeginAngleUpDown);
			this.Controls.Add(this.label6);
			this.Name = "NPolarLineUC";
			this.Size = new System.Drawing.Size(180, 337);
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Line");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NPolarChart chart = new NPolarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(chart);
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.DisplayOnLegend = nChartControl1.Legends[0];
			chart.Depth = 5;
			chart.Width = 70.0f;
			chart.Height = 70.0f;

			// setup polar axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.Polar).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

			NScaleStripStyle strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, Color.Beige));
			strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
			linearScale.StripStyles.Add(strip);

			// setup polar angle axis
			NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
            angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, 192, 192, 192));
			strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
			angularScale.StripStyles.Add(strip);

			// add a const line
			NAxisConstLine line = chart.Axis(StandardAxis.Polar).ConstLines.Add();
			line.Value = 50;
			line.StrokeStyle.Color = Color.SlateBlue;
			line.StrokeStyle.Width = new NLength(1, NGraphicsUnit.Pixel);

			// create a polar line series
			NPolarLineSeries series1 = new NPolarLineSeries();
			chart.Series.Add(series1);
			series1.Name = "Series 1";
			series1.CloseContour = true;
			series1.DataLabelStyle.Visible = false;
			series1.MarkerStyle.Visible = false;
			series1.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series1.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve1(series1, 50);

			// create a polar line series
			NPolarLineSeries series2 = new NPolarLineSeries();
			chart.Series.Add(series2);
			series2.Name = "Series 2";
			series2.CloseContour = true;
			series2.DataLabelStyle.Visible = false;
			series2.MarkerStyle.Visible = false;
			series2.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series2.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve2(series2, 100);

			// create a polar line series
			NPolarLineSeries series3 = new NPolarLineSeries();
			chart.Series.Add(series3);
			series3.Name = "Series 3";
			series3.CloseContour = false;
			series3.DataLabelStyle.Visible = false;
			series3.MarkerStyle.Visible = false;
			series3.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series3.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve3(series3, 100);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			AngleStepCombo.Items.Add("15");
			AngleStepCombo.Items.Add("30");
			AngleStepCombo.Items.Add("45");
			AngleStepCombo.Items.Add("90");
			AngleStepCombo.SelectedIndex = 0;
		}

		internal static void Curve1(NPolarSeries series, int count)
		{
			series.Values.Clear();
			series.Angles.Clear();

			double angleStep = 2 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double angle = i * angleStep;
				double radius = 1 + Math.Cos(angle);

				series.Values.Add(radius);
				series.Angles.Add(angle * 180 / Math.PI);
			}
		}
		internal static void Curve2(NPolarSeries series, int count)
		{
			series.Values.Clear();
			series.Angles.Clear();

			double angleStep = 2 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double angle = i * angleStep;
				double radius = 0.2 + 1.7 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle);

				radius = Math.Abs(radius);

				series.Values.Add(radius);
				series.Angles.Add(angle * 180 / Math.PI);
			}
		}
		internal static void Curve3(NPolarSeries series, int count)
		{
			series.Values.Clear();
			series.Angles.Clear();

			double angleStep = 4 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double angle = i * angleStep;
				double radius = 0.2 + angle / 5.0;

				series.Values.Add(radius);
				series.Angles.Add(angle * 180 / Math.PI);
			}
		}

		private void BeginAngleUpDown_ValueChanged(object sender, EventArgs e)
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart != null)
			{
				polarChart.BeginAngle = (float)BeginAngleUpDown.Value;
				nChartControl1.Refresh();
			}
		}
		private void AngleStepCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart == null)
				return;

			NAngularScaleConfigurator angleScale = polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator as NAngularScaleConfigurator;

			switch (AngleStepCombo.SelectedIndex)
			{
				case 0:
					angleScale.MajorTickMode = MajorTickMode.CustomStep;
					angleScale.CustomStep = new NAngle(15, NAngleUnit.Degree);
					break;

				case 1:
					angleScale.MajorTickMode = MajorTickMode.CustomStep;
					angleScale.CustomStep = new NAngle(30, NAngleUnit.Degree);
					break;

				case 2:
					angleScale.MajorTickMode = MajorTickMode.CustomStep;
					angleScale.CustomStep = new NAngle(45, NAngleUnit.Degree);
					break;

				case 3:
					angleScale.MajorTickMode = MajorTickMode.CustomStep;
					angleScale.CustomStep = new NAngle(90, NAngleUnit.Degree);
					break;

				default:
					Debug.Assert(false);
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
