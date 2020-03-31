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
	public class NIndicatorPaletteUC : NExampleBaseUC
	{
		private Random rand = new Random();
		private NRadialGaugePanel m_RadialGauge;
		private NRangeIndicator m_RangeIndicator;
		private UI.WinForm.Controls.NComboBox PaletteColorModeComboBox;
		private Label label2;
		private UI.WinForm.Controls.NCheckBox EnableIndicatorPaletteCheckBox;
		private NNeedleValueIndicator m_NeedleIndicator;
		private Label label1;
		private UI.WinForm.Controls.NNumericUpDown IndicatorsValueUpDown;
		private NPalette m_Palette;

		public NIndicatorPaletteUC()
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
			this.PaletteColorModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.EnableIndicatorPaletteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.IndicatorsValueUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.IndicatorsValueUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// PaletteColorModeComboBox
			// 
			this.PaletteColorModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.PaletteColorModeComboBox.ListProperties.DataSource = null;
			this.PaletteColorModeComboBox.ListProperties.DisplayMember = "";
			this.PaletteColorModeComboBox.Location = new System.Drawing.Point(20, 102);
			this.PaletteColorModeComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.PaletteColorModeComboBox.Name = "PaletteColorModeComboBox";
			this.PaletteColorModeComboBox.Size = new System.Drawing.Size(302, 40);
			this.PaletteColorModeComboBox.TabIndex = 5;
			this.PaletteColorModeComboBox.Text = "RangeIndicatorOriginModeComboBox";
			this.PaletteColorModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PaletteColorModeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(20, 52);
			this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(340, 44);
			this.label2.TabIndex = 4;
			this.label2.Text = "Palette Spread Mode:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EnableIndicatorPaletteCheckBox
			// 
			this.EnableIndicatorPaletteCheckBox.ButtonProperties.BorderOffset = 2;
			this.EnableIndicatorPaletteCheckBox.Location = new System.Drawing.Point(20, 0);
			this.EnableIndicatorPaletteCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.EnableIndicatorPaletteCheckBox.Name = "EnableIndicatorPaletteCheckBox";
			this.EnableIndicatorPaletteCheckBox.Size = new System.Drawing.Size(302, 44);
			this.EnableIndicatorPaletteCheckBox.TabIndex = 36;
			this.EnableIndicatorPaletteCheckBox.Text = "Enable Indicator Palette";
			this.EnableIndicatorPaletteCheckBox.CheckedChanged += new System.EventHandler(this.EnableIndicatorPaletteCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 173);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(340, 44);
			this.label1.TabIndex = 37;
			this.label1.Text = "Indicators Value:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// IndicatorsValueUpDown
			// 
			this.IndicatorsValueUpDown.Location = new System.Drawing.Point(26, 223);
			this.IndicatorsValueUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.IndicatorsValueUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.IndicatorsValueUpDown.Name = "IndicatorsValueUpDown";
			this.IndicatorsValueUpDown.Size = new System.Drawing.Size(296, 30);
			this.IndicatorsValueUpDown.TabIndex = 38;
			this.IndicatorsValueUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.IndicatorsValueUpDown.ValueChanged += new System.EventHandler(this.IndicatorsValueUpDown_ValueChanged);
			// 
			// NIndicatorPaletteUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.IndicatorsValueUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.EnableIndicatorPaletteCheckBox);
			this.Controls.Add(this.PaletteColorModeComboBox);
			this.Controls.Add(this.label2);
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.Name = "NIndicatorPaletteUC";
			this.Size = new System.Drawing.Size(360, 483);
			((System.ComponentModel.ISupportInitialize)(this.IndicatorsValueUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Indicator Palette");
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
			m_RangeIndicator = new NRangeIndicator();
			m_RangeIndicator.Value = 20;
			m_RangeIndicator.FillStyle = new NGradientFillStyle(Color.Yellow, Color.Red);
			m_RangeIndicator.StrokeStyle.Color = Color.DarkBlue;
			m_RangeIndicator.EndWidth = new NLength(20);
			m_RadialGauge.Indicators.Add(m_RangeIndicator);

			m_NeedleIndicator = new NNeedleValueIndicator();
			m_NeedleIndicator.Value = 79;
			m_NeedleIndicator.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_NeedleIndicator.Shape.StrokeStyle.Color = Color.Red;
			m_RadialGauge.Indicators.Add(m_NeedleIndicator);
			m_RadialGauge.SweepAngle = 270;

			// add radial gauge
			nChartControl1.Panels.Add(m_RadialGauge);

			m_Palette = new NPalette();
			m_Palette.SmoothPalette = true;
			m_Palette.PositiveColor = Color.Green;
			m_Palette.NegativeColor = Color.Red;

			// Init form controls
			PaletteColorModeComboBox.FillFromEnum(typeof(PaletteColorMode));
			PaletteColorModeComboBox.SelectedIndex = (int)PaletteColorMode.Spread;
			IndicatorsValueUpDown.Value = 50;
			EnableIndicatorPaletteCheckBox.Checked = true;
		}

		private void EnableIndicatorPaletteCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (EnableIndicatorPaletteCheckBox.Checked)
			{
				m_NeedleIndicator.Palette = (NPalette)m_Palette.Clone();
				m_RangeIndicator.Palette = (NPalette)m_Palette.Clone();
			}
			else
			{
				m_NeedleIndicator.Palette = null;
				m_RangeIndicator.Palette = null;
			}

			nChartControl1.Refresh();
		}

		private void PaletteColorModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_RangeIndicator.PaletteColorMode = (PaletteColorMode)PaletteColorModeComboBox.SelectedIndex;
			nChartControl1.Refresh();
		}

		private void IndicatorsValueUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_NeedleIndicator.Value = (double)IndicatorsValueUpDown.Value;
			m_RangeIndicator.Value = (double)IndicatorsValueUpDown.Value;
			nChartControl1.Refresh();
		}
	}
}
