using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPolarAngleAxisPositionUC : NExampleBaseUC
	{
		private int m_CustomAxisId;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NCheckBox DockDegreeAxisCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox DockGradAxisCheckBox;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown DegreeAxisCrossValueUpDown;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown GradAxisCrossValueUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
		private Label label6;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public NPolarAngleAxisPositionUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.DegreeAxisCrossValueUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.DockDegreeAxisCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.GradAxisCrossValueUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.DockGradAxisCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BeginAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.nGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DegreeAxisCrossValueUpDown)).BeginInit();
			this.nGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GradAxisCrossValueUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.label3);
			this.nGroupBox1.Controls.Add(this.DegreeAxisCrossValueUpDown);
			this.nGroupBox1.Controls.Add(this.DockDegreeAxisCheckBox);
			this.nGroupBox1.Location = new System.Drawing.Point(13, 41);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(167, 78);
			this.nGroupBox1.TabIndex = 2;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Degree Axis (Red)";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 17);
			this.label3.TabIndex = 1;
			this.label3.Text = "Cross Value:";
			// 
			// DegreeAxisCrossValueUpDown
			// 
			this.DegreeAxisCrossValueUpDown.Location = new System.Drawing.Point(82, 46);
			this.DegreeAxisCrossValueUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.DegreeAxisCrossValueUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.DegreeAxisCrossValueUpDown.Name = "DegreeAxisCrossValueUpDown";
			this.DegreeAxisCrossValueUpDown.Size = new System.Drawing.Size(77, 20);
			this.DegreeAxisCrossValueUpDown.TabIndex = 2;
			this.DegreeAxisCrossValueUpDown.ValueChanged += new System.EventHandler(this.DegreeAxisCrossValueUpDown_ValueChanged);
			// 
			// DockDegreeAxisCheckBox
			// 
			this.DockDegreeAxisCheckBox.ButtonProperties.BorderOffset = 2;
			this.DockDegreeAxisCheckBox.Location = new System.Drawing.Point(6, 19);
			this.DockDegreeAxisCheckBox.Name = "DockDegreeAxisCheckBox";
			this.DockDegreeAxisCheckBox.Size = new System.Drawing.Size(150, 24);
			this.DockDegreeAxisCheckBox.TabIndex = 0;
			this.DockDegreeAxisCheckBox.Text = "Dock";
			this.DockDegreeAxisCheckBox.CheckedChanged += new System.EventHandler(this.DockDegreeAxisCheckBox_CheckedChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.label1);
			this.nGroupBox2.Controls.Add(this.GradAxisCrossValueUpDown);
			this.nGroupBox2.Controls.Add(this.DockGradAxisCheckBox);
			this.nGroupBox2.Location = new System.Drawing.Point(13, 125);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(167, 78);
			this.nGroupBox2.TabIndex = 3;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Grad Axis (Green)";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Cross Value:";
			// 
			// GradAxisCrossValueUpDown
			// 
			this.GradAxisCrossValueUpDown.Location = new System.Drawing.Point(82, 49);
			this.GradAxisCrossValueUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.GradAxisCrossValueUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.GradAxisCrossValueUpDown.Name = "GradAxisCrossValueUpDown";
			this.GradAxisCrossValueUpDown.Size = new System.Drawing.Size(77, 20);
			this.GradAxisCrossValueUpDown.TabIndex = 2;
			this.GradAxisCrossValueUpDown.ValueChanged += new System.EventHandler(this.GradAxisCrossValueUpDown_ValueChanged);
			// 
			// DockGradAxisCheckBox
			// 
			this.DockGradAxisCheckBox.ButtonProperties.BorderOffset = 2;
			this.DockGradAxisCheckBox.Location = new System.Drawing.Point(6, 19);
			this.DockGradAxisCheckBox.Name = "DockGradAxisCheckBox";
			this.DockGradAxisCheckBox.Size = new System.Drawing.Size(150, 24);
			this.DockGradAxisCheckBox.TabIndex = 0;
			this.DockGradAxisCheckBox.Text = "Dock";
			this.DockGradAxisCheckBox.CheckedChanged += new System.EventHandler(this.DockGradAxisCheckBox_CheckedChanged);
			// 
			// BeginAngleUpDown
			// 
			this.BeginAngleUpDown.Location = new System.Drawing.Point(95, 8);
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
			this.BeginAngleUpDown.Size = new System.Drawing.Size(74, 20);
			this.BeginAngleUpDown.TabIndex = 1;
			this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 11);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(162, 17);
			this.label6.TabIndex = 0;
			this.label6.Text = "Begin Angle:";
			// 
			// NPolarAngleAxisPositionUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.BeginAngleUpDown);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NPolarAngleAxisPositionUC";
			this.Size = new System.Drawing.Size(180, 335);
			this.nGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DegreeAxisCrossValueUpDown)).EndInit();
			this.nGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GradAxisCrossValueUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Angle Axis Position");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NPolarChart polar = new NPolarChart();
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(polar);
			polar.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			polar.DisplayOnLegend = nChartControl1.Legends[0];
			polar.Depth = 5;
			polar.Width = 70.0f;
			polar.Height = 70.0f;

			// create a polar line series
			NPolarLineSeries series1 = new NPolarLineSeries();
			polar.Series.Add(series1);
			series1.Name = "Series 1";
			series1.CloseContour = true;
			series1.DataLabelStyle.Visible = false;
			series1.MarkerStyle.Visible = false;
			series1.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series1.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve1(series1, 50);

			// create a polar line series
			NPolarLineSeries series2 = new NPolarLineSeries();
			polar.Series.Add(series2);
			series2.Name = "Series 2";
			series2.CloseContour = true;
			series2.DataLabelStyle.Visible = false;
			series2.MarkerStyle.Visible = false;
			series2.MarkerStyle.Width = new NLength(1, NRelativeUnit.ParentPercentage);
			series2.MarkerStyle.Height = new NLength(1, NRelativeUnit.ParentPercentage);
			Curve2(series2, 100);

			// setup polar axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)polar.Axis(StandardAxis.Polar).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);

			NScaleStripStyle strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.Beige);
			strip.Interlaced = true;
			strip.SetShowAtWall(ChartWallType.Polar, true);
			linearScale.StripStyles.Add(strip);

			// setup polar angle axis
			NAngularScaleConfigurator degreeScale = (NAngularScaleConfigurator)polar.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
			degreeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			degreeScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			degreeScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);

			// add a second value axes
			NPolarAxis valueAxis = (NPolarAxis)polar.Axis(StandardAxis.Polar);

			NPolarAxis primaryAxis = (NPolarAxis)polar.Axis(StandardAxis.PolarAngle);
			NPolarAxis secondaryAxis = ((NPolarAxisCollection)polar.Axes).AddCustomAxis(PolarAxisOrientation.Angle);

			NAngularScaleConfigurator gradScale = new NAngularScaleConfigurator();
			gradScale.AngleUnit = NAngleUnit.Grad;
			gradScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			gradScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific);
			secondaryAxis.ScaleConfigurator = gradScale;
			m_CustomAxisId = secondaryAxis.AxisId;

			NCrossPolarAxisAnchor secondaryAnchor = new NCrossPolarAxisAnchor(PolarAxisOrientation.Angle);
			secondaryAnchor.Crossings.Add(new NValueAxisCrossing(valueAxis, 10));

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// color code the axes and series after the stylesheet is applied
			ApplyColorToAxis(primaryAxis, Color.Red);
			ApplyColorToAxis(secondaryAxis, Color.Green);

			series1.BorderStyle.Width = new NLength(2);
			series2.BorderStyle.Width = new NLength(2);

			DockDegreeAxisCheckBox.Checked = true;
			DockGradAxisCheckBox.Checked = false;
			DegreeAxisCrossValueUpDown.Value = 70;
			GradAxisCrossValueUpDown.Value = 50;
		}

		private void ApplyColorToAxis(NAxis axis, Color color)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			scale.RulerStyle.BorderStyle.Color = color;
			scale.OuterMajorTickStyle.LineStyle.Color = color;
			scale.OuterMinorTickStyle.LineStyle.Color = color;
			scale.InnerMajorTickStyle.LineStyle.Color = color;
			scale.InnerMinorTickStyle.LineStyle.Color = color;
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(color);

			axis.InvalidateScale();
		}

		
		private void UpdateAxes()
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart == null)
				return;

			NAxis valueAxis = polarChart.Axis(StandardAxis.Polar);
			NAxis degreeAxis = polarChart.Axis(StandardAxis.PolarAngle);
			NAxis gradAxis = polarChart.Axis(m_CustomAxisId);

			if (DockDegreeAxisCheckBox.Checked)
			{
				degreeAxis.Anchor = new NDockPolarAxisAnchor();
				DegreeAxisCrossValueUpDown.Enabled = false;
			}
			else
			{
				degreeAxis.Anchor = new NCrossPolarAxisAnchor(PolarAxisOrientation.Angle, new NValueAxisCrossing(valueAxis, (double)DegreeAxisCrossValueUpDown.Value));
				DegreeAxisCrossValueUpDown.Enabled = true;
			}

			if (DockGradAxisCheckBox.Checked)
			{
				gradAxis.Anchor = new NDockPolarAxisAnchor();
				GradAxisCrossValueUpDown.Enabled = false;
			}
			else
			{
				gradAxis.Anchor = new NCrossPolarAxisAnchor(PolarAxisOrientation.Angle, new NValueAxisCrossing(valueAxis, (double)GradAxisCrossValueUpDown.Value));
				GradAxisCrossValueUpDown.Enabled = true;
			}
			
			nChartControl1.Refresh();
		}

		internal static void Curve1(NPolarSeries series, int count)
		{
			series.Values.Clear();
			series.Angles.Clear();

			double angleStep = 2 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double angle = i * angleStep;
				double radius = 100 * Math.Cos(angle);

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
				double radius = 33 + 100 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle);

				radius = Math.Abs(radius);

				series.Values.Add(radius);
				series.Angles.Add(angle * 180 / Math.PI);
			}
		}

		private void DockDegreeAxisCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void DegreeAxisCrossValueUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void DockGradAxisCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void GradAxisCrossValueUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateAxes();
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
	}
}
