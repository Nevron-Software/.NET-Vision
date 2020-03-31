using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Dom;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.SmartShapes;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NIndicatorValueDampeningUC : NExampleBaseUC
	{
		private double m_Angle;
		private Random rand = new Random();
		private NRadialGaugePanel m_RadialGauge;
		private NNumericDisplayPanel m_NumericDisplay;
		private NRangeIndicator m_Indicator1;
		private NNeedleValueIndicator m_Indicator2;
		private System.Windows.Forms.Timer m_Timer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NNumericUpDown DampeningIntervalUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown DampeningStepsUpDown;		
		private Nevron.UI.WinForm.Controls.NButton StartStopTimerButton;
		private Nevron.UI.WinForm.Controls.NCheckBox EnableValueDampeningCheckBox;
		private Nevron.UI.WinForm.Controls.NNumericUpDown nNumericUpDown1;

		public NIndicatorValueDampeningUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.components = new System.ComponentModel.Container();
			this.m_Timer = new System.Windows.Forms.Timer(this.components);
			this.DampeningIntervalUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.DampeningStepsUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.StartStopTimerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.EnableValueDampeningCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nNumericUpDown1 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DampeningIntervalUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DampeningStepsUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.m_Timer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// DampeningIntervalUpDown
			// 
			this.DampeningIntervalUpDown.Location = new System.Drawing.Point(115, 38);
			this.DampeningIntervalUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.DampeningIntervalUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DampeningIntervalUpDown.Name = "DampeningIntervalUpDown";
			this.DampeningIntervalUpDown.Size = new System.Drawing.Size(57, 20);
			this.DampeningIntervalUpDown.TabIndex = 31;
			this.DampeningIntervalUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DampeningIntervalUpDown.ValueChanged += new System.EventHandler(this.DampeningIntervalUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 16);
			this.label3.TabIndex = 30;
			this.label3.Text = "Interval:";
			// 
			// DampeningStepsUpDown
			// 
			this.DampeningStepsUpDown.Location = new System.Drawing.Point(115, 64);
			this.DampeningStepsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DampeningStepsUpDown.Name = "DampeningStepsUpDown";
			this.DampeningStepsUpDown.Size = new System.Drawing.Size(57, 20);
			this.DampeningStepsUpDown.TabIndex = 33;
			this.DampeningStepsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DampeningStepsUpDown.ValueChanged += new System.EventHandler(this.DampeningStepsUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 16);
			this.label1.TabIndex = 32;
			this.label1.Text = "Steps:";
			// 
			// StartStopTimerButton
			// 
			this.StartStopTimerButton.Location = new System.Drawing.Point(11, 141);
			this.StartStopTimerButton.Name = "StartStopTimerButton";
			this.StartStopTimerButton.Size = new System.Drawing.Size(161, 23);
			this.StartStopTimerButton.TabIndex = 34;
			this.StartStopTimerButton.Text = "Stop Timer";
			this.StartStopTimerButton.UseVisualStyleBackColor = true;
			this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			// 
			// EnableValueDampeningCheckBox
			// 
			this.EnableValueDampeningCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableValueDampeningCheckBox.Location = new System.Drawing.Point(8, 10);
			this.EnableValueDampeningCheckBox.Name = "EnableValueDampeningCheckBox";
			this.EnableValueDampeningCheckBox.Size = new System.Drawing.Size(151, 23);
			this.EnableValueDampeningCheckBox.TabIndex = 35;
			this.EnableValueDampeningCheckBox.Text = "Enable Value Dampening";
			this.EnableValueDampeningCheckBox.CheckedChanged += new System.EventHandler(this.EnableValueDampeningCheckBox_CheckedChanged);
			// 
			// nNumericUpDown1
			// 
			this.nNumericUpDown1.Location = new System.Drawing.Point(116, 115);
			this.nNumericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nNumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nNumericUpDown1.Name = "nNumericUpDown1";
			this.nNumericUpDown1.Size = new System.Drawing.Size(57, 20);
			this.nNumericUpDown1.TabIndex = 37;
			this.nNumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 36;
			this.label2.Text = "Timer Interval:";
			// 
			// NIndicatorValueDampeningUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nNumericUpDown1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.EnableValueDampeningCheckBox);
			this.Controls.Add(this.StartStopTimerButton);
			this.Controls.Add(this.DampeningStepsUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DampeningIntervalUpDown);
			this.Controls.Add(this.label3);
			this.Name = "NIndicatorValueDampeningUC";
			this.Size = new System.Drawing.Size(180, 251);
			((System.ComponentModel.ISupportInitialize)(this.DampeningIntervalUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DampeningStepsUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nNumericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Indicator Value Dampening");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(header);

			// create the radial gauge
			m_RadialGauge = new NRadialGaugePanel();
			m_RadialGauge.PaintEffect = new NGlassEffectStyle();
			m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
			m_RadialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			m_RadialGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(55, NRelativeUnit.ParentPercentage));
			m_RadialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
			m_RadialGauge.BackgroundFillStyle = new NGradientFillStyle(Color.DarkGray, Color.Black);

			// configure scale
			NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			scale.MinorTickCount = 4;
			scale.RulerStyle.BorderStyle.Width = new NLength(0);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

			// add radial gauge indicators
			m_Indicator1 = new NRangeIndicator();
			m_Indicator1.Value = 20;
			m_Indicator1.FillStyle = new NGradientFillStyle(Color.Yellow, Color.Red);
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue;
			m_Indicator1.EndWidth = new NLength(20);
			m_RadialGauge.Indicators.Add(m_Indicator1);

			m_Indicator2 = new NNeedleValueIndicator();
			m_Indicator2.Value = 79;
			m_Indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_Indicator2.Shape.StrokeStyle.Color = Color.Red;
			m_RadialGauge.Indicators.Add(m_Indicator2);
			m_RadialGauge.SweepAngle = 270;

			// add radial gauge
			nChartControl1.Panels.Add(m_RadialGauge);

			// create and configure a numeric display attached to the radial gauge
			m_NumericDisplay = new NNumericDisplayPanel();
			m_NumericDisplay.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));
			m_NumericDisplay.ContentAlignment = ContentAlignment.TopCenter;
			m_NumericDisplay.SegmentWidth = new NLength(2, NGraphicsUnit.Point);
			m_NumericDisplay.SegmentGap = new NLength(1, NGraphicsUnit.Point);
			m_NumericDisplay.CellSize = new NSizeL(new NLength(15, NGraphicsUnit.Point), new NLength(30, NGraphicsUnit.Point));
			m_NumericDisplay.DecimalCellSize = new NSizeL(new NLength(10, NGraphicsUnit.Point), new NLength(20, NGraphicsUnit.Point));
			m_NumericDisplay.ShowDecimalSeparator = false;
			m_NumericDisplay.CellAlignment = VertAlign.Top;
			m_NumericDisplay.BackgroundFillStyle = new NColorFillStyle(Color.DimGray);
			m_NumericDisplay.LitFillStyle = new NGradientFillStyle(Color.Lime, Color.Green);
			m_NumericDisplay.CellCountMode = DisplayCellCountMode.Fixed;
			m_NumericDisplay.CellCount = 6;
			m_NumericDisplay.Padding = new NMarginsL(6, 3, 6, 3);
			m_RadialGauge.ChildPanels.Add(m_NumericDisplay);

			// create a sunken border around the display
			NEdgeBorderStyle borderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
			borderStyle.OuterBevelWidth = new NLength(0);
			borderStyle.MiddleBevelWidth = new NLength(0);
			m_NumericDisplay.BorderStyle = borderStyle;

			// init form controls
			EnableValueDampeningCheckBox.Checked = true;
			DampeningIntervalUpDown.Value = 50;
			DampeningStepsUpDown.Value = 10;


			m_Timer.Interval = 200;
			m_Timer.Start();
		}

		private void UpdateIndicators()
		{
			if (m_Indicator1 != null)
			{
				m_Indicator1.EnableDampening = EnableValueDampeningCheckBox.Checked;
				m_Indicator1.DampeningInterval = (int)DampeningIntervalUpDown.Value;
				m_Indicator1.DampeningSteps = (int)DampeningStepsUpDown.Value;
			}

			if (m_Indicator2 != null)
			{
				m_Indicator2.EnableDampening = EnableValueDampeningCheckBox.Checked;
				m_Indicator2.DampeningInterval = (int)DampeningIntervalUpDown.Value;
				m_Indicator2.DampeningSteps = (int)DampeningStepsUpDown.Value;
				m_Indicator2.Value = 20 + Math.Sin(m_Angle) + rand.Next(40);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			m_Angle += Math.PI / 180.0;

			m_Indicator1.Value = 50 + Math.Sin(m_Angle) * (20 + rand.Next(30));
			m_NumericDisplay.Value = m_Indicator1.Value;
			m_Indicator2.Value = 50 + Math.Sin(m_Angle) * (30 + rand.Next(20));

			nChartControl1.Refresh();
		}

		private void StartStopTimerButton_Click(object sender, EventArgs e)
		{
			if (m_Timer.Enabled)
			{
				StartStopTimerButton.Text = "Start Timer";
				m_Timer.Stop();
			}
			else
			{
				StartStopTimerButton.Text = "Stop Timer";
				m_Timer.Start();
			}
		}

		private void DampeningIntervalUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateIndicators();
		}

		private void DampeningStepsUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateIndicators();
		}

		private void EnableValueDampeningCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateIndicators();
		}
	}
}
