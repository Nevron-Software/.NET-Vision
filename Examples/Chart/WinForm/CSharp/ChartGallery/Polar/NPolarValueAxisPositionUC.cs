using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NPolarValueAxisPositionUC : NExampleBaseUC
	{
		private int m_CustomAxisId;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RedAxisBeginUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox RadianAngleStepComboBox;
		private Label label2;
		private Label label1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RedAxisAngleUpDown;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RedEndUpDown;
		private Label label4;
		private Label label5;
		private Label label6;
		private Nevron.UI.WinForm.Controls.NNumericUpDown GreenAxisAngleUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RedBeginUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown GreenBeginUpDown;
		private Label label8;
		private Nevron.UI.WinForm.Controls.NNumericUpDown GreenEndUpDown;
		private Label label7;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown BeginAngleUpDown;
		private Nevron.UI.WinForm.Controls.NCheckBox DockGreenAxisCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox GreenAxisReflectionPaintCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox RedAxisPaintReflectionCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox DockRedAxisCheckBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public NPolarValueAxisPositionUC()
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
			this.RedAxisBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.RadianAngleStepComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.RedAxisAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.RedEndUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.GreenAxisAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.RedBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.GreenBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.GreenEndUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.DockRedAxisCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.RedAxisPaintReflectionCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.GreenAxisReflectionPaintCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.DockGreenAxisCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.BeginAngleUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.RedAxisBeginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RedAxisAngleUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RedEndUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GreenAxisAngleUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RedBeginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GreenBeginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GreenEndUpDown)).BeginInit();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// RedAxisBeginUpDown
			// 
			this.RedAxisBeginUpDown.Location = new System.Drawing.Point(76, 57);
			this.RedAxisBeginUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.RedAxisBeginUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.RedAxisBeginUpDown.Name = "RedAxisBeginUpDown";
			this.RedAxisBeginUpDown.Size = new System.Drawing.Size(85, 20);
			this.RedAxisBeginUpDown.TabIndex = 37;
			// 
			// RadianAngleStepComboBox
			// 
			this.RadianAngleStepComboBox.ListProperties.CheckBoxDataMember = "";
			this.RadianAngleStepComboBox.ListProperties.DataSource = null;
			this.RadianAngleStepComboBox.ListProperties.DisplayMember = "";
			this.RadianAngleStepComboBox.Location = new System.Drawing.Point(10, 77);
			this.RadianAngleStepComboBox.Name = "RadianAngleStepComboBox";
			this.RadianAngleStepComboBox.Size = new System.Drawing.Size(165, 21);
			this.RadianAngleStepComboBox.TabIndex = 3;
			this.RadianAngleStepComboBox.SelectedIndexChanged += new System.EventHandler(this.RadianAngleStepComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(162, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Radian Angle Step:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(162, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Begin Angle:";
			// 
			// RedAxisAngleUpDown
			// 
			this.RedAxisAngleUpDown.Location = new System.Drawing.Point(92, 44);
			this.RedAxisAngleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.RedAxisAngleUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.RedAxisAngleUpDown.Name = "RedAxisAngleUpDown";
			this.RedAxisAngleUpDown.Size = new System.Drawing.Size(73, 20);
			this.RedAxisAngleUpDown.TabIndex = 2;
			this.RedAxisAngleUpDown.ValueChanged += new System.EventHandler(this.RedAxisAngleUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 17);
			this.label3.TabIndex = 1;
			this.label3.Text = "Angle:";
			// 
			// RedEndUpDown
			// 
			this.RedEndUpDown.Location = new System.Drawing.Point(92, 133);
			this.RedEndUpDown.Name = "RedEndUpDown";
			this.RedEndUpDown.Size = new System.Drawing.Size(73, 20);
			this.RedEndUpDown.TabIndex = 7;
			this.RedEndUpDown.ValueChanged += new System.EventHandler(this.RedEndUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 17);
			this.label4.TabIndex = 4;
			this.label4.Text = "Begin Percent:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 17);
			this.label5.TabIndex = 6;
			this.label5.Text = "End Percent:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 46);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 17);
			this.label6.TabIndex = 1;
			this.label6.Text = "Angle:";
			// 
			// GreenAxisAngleUpDown
			// 
			this.GreenAxisAngleUpDown.Location = new System.Drawing.Point(92, 43);
			this.GreenAxisAngleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.GreenAxisAngleUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.GreenAxisAngleUpDown.Name = "GreenAxisAngleUpDown";
			this.GreenAxisAngleUpDown.Size = new System.Drawing.Size(73, 20);
			this.GreenAxisAngleUpDown.TabIndex = 2;
			this.GreenAxisAngleUpDown.ValueChanged += new System.EventHandler(this.GreenAxisAngleUpDown_ValueChanged);
			// 
			// RedBeginUpDown
			// 
			this.RedBeginUpDown.Location = new System.Drawing.Point(92, 109);
			this.RedBeginUpDown.Name = "RedBeginUpDown";
			this.RedBeginUpDown.Size = new System.Drawing.Size(73, 20);
			this.RedBeginUpDown.TabIndex = 5;
			this.RedBeginUpDown.ValueChanged += new System.EventHandler(this.RedBeginUpDown_ValueChanged);
			// 
			// GreenBeginUpDown
			// 
			this.GreenBeginUpDown.Location = new System.Drawing.Point(92, 97);
			this.GreenBeginUpDown.Name = "GreenBeginUpDown";
			this.GreenBeginUpDown.Size = new System.Drawing.Size(73, 20);
			this.GreenBeginUpDown.TabIndex = 5;
			this.GreenBeginUpDown.ValueChanged += new System.EventHandler(this.GreenBeginUpDown_ValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 124);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 17);
			this.label8.TabIndex = 6;
			this.label8.Text = "End Percent:";
			// 
			// GreenEndUpDown
			// 
			this.GreenEndUpDown.Location = new System.Drawing.Point(92, 121);
			this.GreenEndUpDown.Name = "GreenEndUpDown";
			this.GreenEndUpDown.Size = new System.Drawing.Size(73, 20);
			this.GreenEndUpDown.TabIndex = 7;
			this.GreenEndUpDown.ValueChanged += new System.EventHandler(this.GreenEndUpDown_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 100);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(84, 17);
			this.label7.TabIndex = 4;
			this.label7.Text = "Begin Percent:";
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.DockRedAxisCheckBox);
			this.nGroupBox1.Controls.Add(this.RedAxisPaintReflectionCheckBox);
			this.nGroupBox1.Controls.Add(this.RedEndUpDown);
			this.nGroupBox1.Controls.Add(this.label3);
			this.nGroupBox1.Controls.Add(this.RedAxisAngleUpDown);
			this.nGroupBox1.Controls.Add(this.label4);
			this.nGroupBox1.Controls.Add(this.label5);
			this.nGroupBox1.Controls.Add(this.RedBeginUpDown);
			this.nGroupBox1.Location = new System.Drawing.Point(10, 116);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(170, 162);
			this.nGroupBox1.TabIndex = 4;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Red Axis";
			// 
			// DockRedAxisCheckBox
			// 
			this.DockRedAxisCheckBox.ButtonProperties.BorderOffset = 2;
			this.DockRedAxisCheckBox.Location = new System.Drawing.Point(11, 19);
			this.DockRedAxisCheckBox.Name = "DockRedAxisCheckBox";
			this.DockRedAxisCheckBox.Size = new System.Drawing.Size(150, 24);
			this.DockRedAxisCheckBox.TabIndex = 0;
			this.DockRedAxisCheckBox.Text = "Dock Bottom";
			this.DockRedAxisCheckBox.CheckedChanged += new System.EventHandler(this.DockRedAxisCheckBox_CheckedChanged);
			// 
			// RedAxisPaintReflectionCheckBox
			// 
			this.RedAxisPaintReflectionCheckBox.ButtonProperties.BorderOffset = 2;
			this.RedAxisPaintReflectionCheckBox.Location = new System.Drawing.Point(11, 79);
			this.RedAxisPaintReflectionCheckBox.Name = "RedAxisPaintReflectionCheckBox";
			this.RedAxisPaintReflectionCheckBox.Size = new System.Drawing.Size(150, 24);
			this.RedAxisPaintReflectionCheckBox.TabIndex = 3;
			this.RedAxisPaintReflectionCheckBox.Text = "Paint Reflection";
			this.RedAxisPaintReflectionCheckBox.CheckedChanged += new System.EventHandler(this.RedAxisPaintReflectionCheckBox_CheckedChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.GreenAxisReflectionPaintCheckBox);
			this.nGroupBox2.Controls.Add(this.DockGreenAxisCheckBox);
			this.nGroupBox2.Controls.Add(this.GreenEndUpDown);
			this.nGroupBox2.Controls.Add(this.label6);
			this.nGroupBox2.Controls.Add(this.GreenAxisAngleUpDown);
			this.nGroupBox2.Controls.Add(this.GreenBeginUpDown);
			this.nGroupBox2.Controls.Add(this.label7);
			this.nGroupBox2.Controls.Add(this.label8);
			this.nGroupBox2.Location = new System.Drawing.Point(10, 284);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(170, 187);
			this.nGroupBox2.TabIndex = 5;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Green Axis";
			// 
			// GreenAxisReflectionPaintCheckBox
			// 
			this.GreenAxisReflectionPaintCheckBox.ButtonProperties.BorderOffset = 2;
			this.GreenAxisReflectionPaintCheckBox.Location = new System.Drawing.Point(11, 71);
			this.GreenAxisReflectionPaintCheckBox.Name = "GreenAxisReflectionPaintCheckBox";
			this.GreenAxisReflectionPaintCheckBox.Size = new System.Drawing.Size(150, 24);
			this.GreenAxisReflectionPaintCheckBox.TabIndex = 3;
			this.GreenAxisReflectionPaintCheckBox.Text = "Paint Reflection";
			this.GreenAxisReflectionPaintCheckBox.CheckedChanged += new System.EventHandler(this.GreenAxisPaintReflectionCheckBox_CheckedChanged);
			// 
			// DockGreenAxisCheckBox
			// 
			this.DockGreenAxisCheckBox.ButtonProperties.BorderOffset = 2;
			this.DockGreenAxisCheckBox.Location = new System.Drawing.Point(11, 19);
			this.DockGreenAxisCheckBox.Name = "DockGreenAxisCheckBox";
			this.DockGreenAxisCheckBox.Size = new System.Drawing.Size(150, 24);
			this.DockGreenAxisCheckBox.TabIndex = 0;
			this.DockGreenAxisCheckBox.Text = "Dock Left";
			this.DockGreenAxisCheckBox.CheckedChanged += new System.EventHandler(this.DockBlueAxisCheckBox_CheckedChanged);
			// 
			// BeginAngleUpDown
			// 
			this.BeginAngleUpDown.Location = new System.Drawing.Point(10, 29);
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
			this.BeginAngleUpDown.Size = new System.Drawing.Size(165, 20);
			this.BeginAngleUpDown.TabIndex = 1;
			this.BeginAngleUpDown.ValueChanged += new System.EventHandler(this.BeginAngleUpDown_ValueChanged);
			// 
			// NPolarValueAxisPositionUC
			// 
			this.Controls.Add(this.BeginAngleUpDown);
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.RadianAngleStepComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NPolarValueAxisPositionUC";
			this.Size = new System.Drawing.Size(180, 514);
			((System.ComponentModel.ISupportInitialize)(this.RedAxisBeginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RedAxisAngleUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RedEndUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GreenAxisAngleUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RedBeginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GreenBeginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GreenEndUpDown)).EndInit();
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.BeginAngleUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Polar Value Axis Position");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NPolarChart polar = new NPolarChart();
			polar.InnerRadius = new NLength(20);
			nChartControl1.Charts.Clear();
			nChartControl1.Charts.Add(polar);
			polar.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			polar.DisplayOnLegend = nChartControl1.Legends[0];

			// setup polar axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)polar.Axis(StandardAxis.Polar).ScaleConfigurator;
			linearScale.RoundToTickMax = true;
			linearScale.RoundToTickMin = true;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// setup polar angle axis
			NAngularScaleConfigurator angularScale = (NAngularScaleConfigurator)polar.Axis(StandardAxis.PolarAngle).ScaleConfigurator;
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, true);
			angularScale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			NScaleStripStyle strip = new NScaleStripStyle();
			strip.FillStyle = new NColorFillStyle(Color.FromArgb(125, 192, 192, 192));
			strip.Interlaced = true;
            strip.SetShowAtWall(ChartWallType.Polar, true);
			angularScale.StripStyles.Add(strip);

			// add a const line
			NAxisConstLine line = polar.Axis(StandardAxis.Polar).ConstLines.Add();
			line.Value = 50;
			line.StrokeStyle.Color = Color.SlateBlue;
			line.StrokeStyle.Width = new NLength(1, NGraphicsUnit.Pixel);

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

			// add a second value axes
			NPolarAxis primaryAxis = (NPolarAxis)polar.Axis(StandardAxis.Polar);
			NPolarAxis secondaryAxis = ((NPolarAxisCollection)polar.Axes).AddCustomAxis(PolarAxisOrientation.Value);
			m_CustomAxisId = secondaryAxis.AxisId;

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// color code the axes and series after the stylesheet is applied
			ApplyColorToAxis(primaryAxis, Color.Red);
			ApplyColorToAxis(secondaryAxis, Color.Green);

			series1.BorderStyle.Color = Color.DarkRed;
			series1.BorderStyle.Width = new NLength(2);

			series2.BorderStyle.Color = Color.DarkGreen;
			series2.BorderStyle.Width = new NLength(2);

			series2.DisplayOnAxis(StandardAxis.Polar, false);
			series2.DisplayOnAxis(m_CustomAxisId, true);

			// init form controls
			RadianAngleStepComboBox.Items.Add("15");
			RadianAngleStepComboBox.Items.Add("30");
			RadianAngleStepComboBox.Items.Add("45");
			RadianAngleStepComboBox.Items.Add("90");
			RadianAngleStepComboBox.SelectedIndex = 0;

			RedAxisAngleUpDown.Value = (decimal)0;
			RedBeginUpDown.Value = (decimal)0;
			RedEndUpDown.Value = (decimal)100;

			GreenAxisAngleUpDown.Value = (decimal)90;
			GreenBeginUpDown.Value = (decimal)0;
			GreenEndUpDown.Value = (decimal)100;
		}

		private void ApplyColorToAxis(NAxis axis, Color color)
		{
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;

			linearScale.RulerStyle.BorderStyle.Color = color;
			linearScale.OuterMajorTickStyle.LineStyle.Color = color;
			linearScale.OuterMinorTickStyle.LineStyle.Color = color;
			linearScale.InnerMajorTickStyle.LineStyle.Color = color;
			linearScale.InnerMinorTickStyle.LineStyle.Color = color;
			linearScale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(color);

			axis.InvalidateScale();
		}

		private void UpdateAxes()
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart == null)
				return;

			NAxis angleAxis = polarChart.Axis(StandardAxis.PolarAngle);

			// configure the red axis
			NAxis redAxis = polarChart.Axis(StandardAxis.Polar);
			NPolarAxisAnchor redAnchor;

			RedAxisAngleUpDown.Enabled = !DockRedAxisCheckBox.Checked;

			if (DockRedAxisCheckBox.Checked)
			{
				redAnchor = new NDockPolarAxisAnchor(PolarAxisDockZone.Bottom);
				RedAxisAngleUpDown.Enabled = false;
			}
			else
			{
				NCrossPolarAxisAnchor crossAnchor = new NCrossPolarAxisAnchor();
				crossAnchor.Crossings.Add(new NValueAxisCrossing(angleAxis, (float)RedAxisAngleUpDown.Value));
				redAnchor = crossAnchor;
			}

			redAnchor.PaintReflection = RedAxisPaintReflectionCheckBox.Checked;
			redAnchor.BeginPercent = (float)RedBeginUpDown.Value;
			redAnchor.EndPercent = (float)RedEndUpDown.Value;

			redAxis.Anchor = redAnchor;

			// configure the green axis
			NAxis greenAxis = polarChart.Axis(m_CustomAxisId);
			NPolarAxisAnchor greenAnchor;

			GreenAxisAngleUpDown.Enabled = !DockGreenAxisCheckBox.Checked;
			if (DockGreenAxisCheckBox.Checked)
			{
				NDockPolarAxisAnchor dockAnchor = new NDockPolarAxisAnchor(PolarAxisDockZone.Left);
				greenAnchor = dockAnchor;		
			}
			else
			{
				NCrossPolarAxisAnchor crossAnchor = new NCrossPolarAxisAnchor();
				crossAnchor.Crossings.Add(new NValueAxisCrossing(angleAxis, (float)GreenAxisAngleUpDown.Value));
				greenAnchor = crossAnchor;
			}

			greenAnchor.PaintReflection = GreenAxisReflectionPaintCheckBox.Checked;
			greenAnchor.BeginPercent = (float)GreenBeginUpDown.Value;
			greenAnchor.EndPercent = (float)GreenEndUpDown.Value;
			greenAxis.Anchor = greenAnchor;

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

		private void BeginAngleUpDown_ValueChanged(object sender, EventArgs e)
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart != null)
			{
				polarChart.BeginAngle = (float)BeginAngleUpDown.Value;
				nChartControl1.Refresh();
			}
		}

		private void RadianAngleStepComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			NPolarChart polarChart = nChartControl1.Charts[0] as NPolarChart;
			if (polarChart == null)
				return;

			NAngularScaleConfigurator angleScale = polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator as NAngularScaleConfigurator;

			switch (RadianAngleStepComboBox.SelectedIndex)
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

		private void RedAxisAngleUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void RedBeginUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void RedEndUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void GreenAxisAngleUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void GreenBeginUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void GreenEndUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void DockBlueAxisCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void DockRedAxisCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void RedAxisPaintReflectionCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}

		private void GreenAxisPaintReflectionCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAxes();
		}
	}
}
