using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGaugeCustomRangeLabelsUC : NExampleBaseUC
	{
		NLinearGaugePanel m_LinearGauge;
		NRadialGaugePanel m_RadialGauge;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NComboBox LinearGaugeOrientationComboBox;
		private Label label5;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NHScrollBar BeginAngleScrollBar;
		private Nevron.UI.WinForm.Controls.NHScrollBar SweepAngleScrollBar;
		private Label label3;
		private Label label4;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowMinRangeCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox ShowMaxRangeCheckBox;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public NGaugeCustomRangeLabelsUC()
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
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LinearGaugeOrientationComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BeginAngleScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.SweepAngleScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ShowMinRangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowMaxRangeCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.LinearGaugeOrientationComboBox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(3, 196);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(173, 72);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Linear Gauge";
			// 
			// LinearGaugeOrientationComboBox
			// 
			this.LinearGaugeOrientationComboBox.ListProperties.CheckBoxDataMember = "";
			this.LinearGaugeOrientationComboBox.ListProperties.DataSource = null;
			this.LinearGaugeOrientationComboBox.ListProperties.DisplayMember = "";
			this.LinearGaugeOrientationComboBox.Location = new System.Drawing.Point(3, 31);
			this.LinearGaugeOrientationComboBox.Name = "LinearGaugeOrientationComboBox";
			this.LinearGaugeOrientationComboBox.Size = new System.Drawing.Size(151, 21);
			this.LinearGaugeOrientationComboBox.TabIndex = 1;
			this.LinearGaugeOrientationComboBox.SelectedIndexChanged += new System.EventHandler(this.LinearGaugeOrientationComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Orientation:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BeginAngleScrollBar);
			this.groupBox1.Controls.Add(this.SweepAngleScrollBar);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(3, 77);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(173, 113);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Radial Gauge";
			// 
			// BeginAngleScrollBar
			// 
			this.BeginAngleScrollBar.Location = new System.Drawing.Point(3, 30);
			this.BeginAngleScrollBar.Maximum = 360;
			this.BeginAngleScrollBar.Minimum = -360;
			this.BeginAngleScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.BeginAngleScrollBar.Name = "BeginAngleScrollBar";
			this.BeginAngleScrollBar.Size = new System.Drawing.Size(154, 16);
			this.BeginAngleScrollBar.TabIndex = 1;
			this.BeginAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BeginAngleScrollBar_ValueChanged);
			// 
			// SweepAngleScrollBar
			// 
			this.SweepAngleScrollBar.Location = new System.Drawing.Point(3, 76);
			this.SweepAngleScrollBar.Maximum = 350;
			this.SweepAngleScrollBar.Minimum = -350;
			this.SweepAngleScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.SweepAngleScrollBar.Name = "SweepAngleScrollBar";
			this.SweepAngleScrollBar.Size = new System.Drawing.Size(154, 16);
			this.SweepAngleScrollBar.TabIndex = 3;
			this.SweepAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SweepAngleScrollBar_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Begin Angle:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Sweep Angle:";
			// 
			// ShowMinRangeCheckBox
			// 
			this.ShowMinRangeCheckBox.AutoSize = true;
			this.ShowMinRangeCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowMinRangeCheckBox.Location = new System.Drawing.Point(12, 14);
			this.ShowMinRangeCheckBox.Name = "ShowMinRangeCheckBox";
			this.ShowMinRangeCheckBox.Size = new System.Drawing.Size(108, 17);
			this.ShowMinRangeCheckBox.TabIndex = 0;
			this.ShowMinRangeCheckBox.Text = "Show Min Range";
			this.ShowMinRangeCheckBox.UseVisualStyleBackColor = true;
			this.ShowMinRangeCheckBox.CheckedChanged += new System.EventHandler(this.ShowMinRangeCheckBox_CheckedChanged);
			// 
			// ShowMaxRangeCheckBox
			// 
			this.ShowMaxRangeCheckBox.AutoSize = true;
			this.ShowMaxRangeCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowMaxRangeCheckBox.Location = new System.Drawing.Point(12, 37);
			this.ShowMaxRangeCheckBox.Name = "ShowMaxRangeCheckBox";
			this.ShowMaxRangeCheckBox.Size = new System.Drawing.Size(111, 17);
			this.ShowMaxRangeCheckBox.TabIndex = 1;
			this.ShowMaxRangeCheckBox.Text = "Show Max Range";
			this.ShowMaxRangeCheckBox.UseVisualStyleBackColor = true;
			this.ShowMaxRangeCheckBox.CheckedChanged += new System.EventHandler(this.ShowMaxRangeCheckBox_CheckedChanged);
			// 
			// NGaugeCustomRangeLabelsUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ShowMaxRangeCheckBox);
			this.Controls.Add(this.ShowMinRangeCheckBox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NGaugeCustomRangeLabelsUC";
			this.Size = new System.Drawing.Size(180, 454);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Gauge Custom Range Labels<br/><font size = '9pt'>Demonstrates how to use custom range labels to denote ranges on a scale</font>");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.TextFormat = TextFormat.XML;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// create the radial gauge
			CreateRadialGauge();
			
			// create the linear gauge
			CreateLinearGauge();

			// init form controls
			BeginAngleScrollBar.Value = (int)m_RadialGauge.BeginAngle;
			SweepAngleScrollBar.Value = (int)m_RadialGauge.SweepAngle;

			LinearGaugeOrientationComboBox.Items.Add("Horizontal");
			LinearGaugeOrientationComboBox.Items.Add("Vertical");
			LinearGaugeOrientationComboBox.SelectedIndex = 1;

			ShowMinRangeCheckBox.Checked = true;
			ShowMaxRangeCheckBox.Checked = true;
		}

		private void CreateLinearGauge()
		{
			m_LinearGauge = new NLinearGaugePanel();
			nChartControl1.Panels.Add(m_LinearGauge);

			// create the background panel
			NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
			advGradient.BackgroundColor = Color.Black;
			advGradient.Points.Add(new NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle));
			m_LinearGauge.BackgroundFillStyle = advGradient;
			m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);

			NGaugeAxis axis = (NGaugeAxis)m_LinearGauge.Axes[0];
			axis.Anchor = new NModelGaugeAxisAnchor(new NLength(20, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left);
			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
			m_LinearGauge.Indicators.Add(new NMarkerValueIndicator(60));
		}

		private void CreateRadialGauge()
		{
			// create the radial gauge
			m_RadialGauge = new NRadialGaugePanel();
			m_RadialGauge.PaintEffect = new NGlassEffectStyle();
			m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			nChartControl1.Panels.Add(m_RadialGauge);

			// create the radial gauge
			m_RadialGauge.SweepAngle = 270;
			m_RadialGauge.BeginAngle = -90;

			// set some background
			NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
			advGradient.BackgroundColor = Color.Black;
			advGradient.Points.Add(new NAdvancedGradientPoint(Color.LightGray, 10, 10, 0, 100, AGPointShape.Circle));
			m_RadialGauge.BackgroundFillStyle = advGradient;

			// configure the axis
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			axis.Range = new NRange1DD(0, 100);
			axis.Anchor.RulerOrientation = RulerOrientation.Right;
			axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);

			ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

			// add some indicators
			NNeedleValueIndicator needle = new NNeedleValueIndicator(60);
			needle.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleMiddle;
			needle.OffsetFromScale = new NLength(15);
			m_RadialGauge.Indicators.Add(needle);
		}

		private void ConfigureScale(NLinearScaleConfigurator scale)
		{
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelFitModes = new LabelFitMode[0];
			scale.MinorTickCount = 3;
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
			scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 10, FontStyle.Bold);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
		}

		private void UpdateAxisRanges()
		{
			NLinearScaleConfigurator linearGaugeScale = ((NGaugeAxis)m_LinearGauge.Axes[0]).ScaleConfigurator as NLinearScaleConfigurator;
			NLinearScaleConfigurator radialGaugeScale = ((NGaugeAxis)m_RadialGauge.Axes[0]).ScaleConfigurator as NLinearScaleConfigurator;

			linearGaugeScale.CustomLabels.Clear();
			linearGaugeScale.Sections.Clear();

			radialGaugeScale.CustomLabels.Clear();
			radialGaugeScale.Sections.Clear();

			if (ShowMinRangeCheckBox.Checked)
			{
				ApplyScaleSectionToAxis(linearGaugeScale, "Min", new NRange1DD(0, 20), Color.LightBlue);
				ApplyScaleSectionToAxis(radialGaugeScale, "Min", new NRange1DD(0, 20), Color.LightBlue);
			}

			if (ShowMaxRangeCheckBox.Checked)
			{
				ApplyScaleSectionToAxis(linearGaugeScale, "Max", new NRange1DD(80, 100), Color.Red);
				ApplyScaleSectionToAxis(radialGaugeScale, "Max", new NRange1DD(80, 100), Color.Red);
			}

			nChartControl1.Refresh();
		}

		private void ApplyScaleSectionToAxis(NLinearScaleConfigurator scale, string text, NRange1DD range, Color color)
		{
			NScaleSectionStyle scaleSection = new NScaleSectionStyle();

			scaleSection.Range = range;
			scaleSection.LabelTextStyle = new NTextStyle();
			scaleSection.LabelTextStyle.FillStyle = new NColorFillStyle(color);
			scaleSection.LabelTextStyle.FontStyle = new NFontStyle("Arial", 10,FontStyle.Bold | FontStyle.Italic);
			scaleSection.MajorTickStrokeStyle = new NStrokeStyle(color);

			scale.Sections.Add(scaleSection);

			NCustomRangeLabel rangeLabel = new NCustomRangeLabel(range, text);
			rangeLabel.Style.WrapText = false;
			rangeLabel.Style.KeepInsideRuler = false;
			rangeLabel.Style.StrokeStyle.Color = color;
			rangeLabel.Style.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			rangeLabel.Style.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			rangeLabel.Style.TickMode = RangeLabelTickMode.Center;

			scale.CustomLabels.Add(rangeLabel);
		}

		private void BeginAngleScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_RadialGauge.BeginAngle = BeginAngleScrollBar.Value;
			nChartControl1.Refresh();
		}

		private void SweepAngleScrollBar_ValueChanged(object sender, Nevron.UI.WinForm.Controls.ScrollBarEventArgs e)
		{
			m_RadialGauge.SweepAngle = SweepAngleScrollBar.Value;
			nChartControl1.Refresh();
		}

		private void LinearGaugeOrientationComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_LinearGauge.Orientation = (LinearGaugeOrientation)LinearGaugeOrientationComboBox.SelectedIndex;

			if (m_LinearGauge.Orientation == LinearGaugeOrientation.Horizontal)
			{
				m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
				m_RadialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(55, NRelativeUnit.ParentPercentage));
				m_RadialGauge.ContentAlignment = ContentAlignment.BottomCenter;

				m_LinearGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
				m_LinearGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NGraphicsUnit.Point));
				m_LinearGauge.Padding = new NMarginsL(13, 0, 13, 0);
			}
			else
			{
				m_RadialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
				m_RadialGauge.Size = new NSizeL(new NLength(45, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
				m_RadialGauge.ContentAlignment = ContentAlignment.BottomRight;

				m_LinearGauge.Location = new NPointL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
				m_LinearGauge.Size = new NSizeL(new NLength(80, NGraphicsUnit.Point), new NLength(80, NRelativeUnit.ParentPercentage));
				m_LinearGauge.Padding = new NMarginsL(0, 13, 0, 13);
			}

			nChartControl1.Refresh();
		}

		private void ShowMinRangeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAxisRanges();
		}

		private void ShowMaxRangeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateAxisRanges();
		}
	}
}
