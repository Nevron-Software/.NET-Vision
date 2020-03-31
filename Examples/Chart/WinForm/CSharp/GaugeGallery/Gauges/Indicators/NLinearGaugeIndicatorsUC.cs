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
	public class NLinearGaugeIndicatorsUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;

		NLinearGaugePanel m_LinearGauge;
		NMarkerValueIndicator m_Indicator2;
		private System.Windows.Forms.Label label6;
		private Nevron.UI.WinForm.Controls.NComboBox GaugeOrientationCombo;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RangeIndicatorValueUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RangeIndicatorOriginUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown ValueIndicatorUpDown;
		private Nevron.UI.WinForm.Controls.NComboBox RangeIndicatorOriginModeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox ValueIndicatorShapeComboBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MarkerWidthUpDown;
		private Nevron.UI.WinForm.Controls.NButton ShowMarkerEditorButton;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MarkerHeightUpDown;
		NRangeIndicator m_Indicator1;

		public NLinearGaugeIndicatorsUC()
		{
			// This call is required by the Windows.Forms Form Designer.
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

		public static double FarenheitToCelsius(double farenheit)
		{
			return (farenheit - 32.0) * 5.0 / 9.0;
		}

		public static double CelsiusToFarenheit(double celsius)
		{
			return (celsius * 9.0) / 5.0 + 32.0f;
		}

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Linear Gauge Indicators");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
            nChartControl1.Panels.Add(header);

			// create a linear gauge
			m_LinearGauge = new NLinearGaugePanel();
			nChartControl1.Panels.Add(m_LinearGauge);
			m_LinearGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			m_LinearGauge.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(50, NRelativeUnit.ParentPercentage));
            m_LinearGauge.PaintEffect = new NGelEffectStyle();
            m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);
            m_LinearGauge.BackgroundFillStyle = new NGradientFillStyle(Color.Gray, Color.Black);

			m_LinearGauge.Axes.Clear();

			NRange1DD celsiusRange = new NRange1DD(-40, 60);

			// add celsius and farenheit axes
			NGaugeAxis celsiusAxis = new NGaugeAxis();
			celsiusAxis.Range = celsiusRange;
			celsiusAxis.Anchor = new NModelGaugeAxisAnchor(new NLength(-5), VertAlign.Center, RulerOrientation.Left, 0, 100);
			m_LinearGauge.Axes.Add(celsiusAxis);

			NGaugeAxis farenheitAxis = new NGaugeAxis();
			farenheitAxis.Range = new NRange1DD(CelsiusToFarenheit(celsiusRange.Begin), CelsiusToFarenheit(celsiusRange.End));
			farenheitAxis.Anchor = new NModelGaugeAxisAnchor(new NLength(5), VertAlign.Center, RulerOrientation.Right, 0, 100);
			m_LinearGauge.Axes.Add(farenheitAxis);

			// configure the scales
			NLinearScaleConfigurator celsiusScale = (NLinearScaleConfigurator)celsiusAxis.ScaleConfigurator;
			ConfigureScale(celsiusScale, "°C");
			celsiusScale.Sections.Add(CreateSection(Color.Red, Color.Red, new NRange1DD(40, 60)));
            celsiusScale.Sections.Add(CreateSection(Color.Blue, Color.SkyBlue, new NRange1DD(-40, -20)));

			NLinearScaleConfigurator farenheitScale = (NLinearScaleConfigurator)farenheitAxis.ScaleConfigurator;
			ConfigureScale(farenheitScale, "°F");

            farenheitScale.Sections.Add(CreateSection(Color.Red, Color.Red, new NRange1DD(CelsiusToFarenheit(40), CelsiusToFarenheit(60))));
            farenheitScale.Sections.Add(CreateSection(Color.Blue, Color.SkyBlue, new NRange1DD(CelsiusToFarenheit(-40), CelsiusToFarenheit(-20))));

			// now add two indicators
			m_Indicator1 = new NRangeIndicator();
			m_Indicator1.Value = 10;
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue;
			m_Indicator1.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.LightBlue, Color.Blue);
			m_LinearGauge.Indicators.Add(m_Indicator1);

			m_Indicator2 = new NMarkerValueIndicator();
			m_Indicator2.Value = 33;
			m_Indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			m_Indicator2.Shape.StrokeStyle.Color = Color.DarkRed;
			m_LinearGauge.Indicators.Add(m_Indicator2);

			// init form controls
			RangeIndicatorValueUpDown.Value = (decimal)m_Indicator1.Value;
			ValueIndicatorUpDown.Value = (decimal)m_Indicator2.Value;

			RangeIndicatorOriginModeComboBox.FillFromEnum(typeof(OriginMode));
			RangeIndicatorOriginModeComboBox.SelectedIndex = 0;

			ValueIndicatorShapeComboBox.FillFromEnum(typeof(SmartShape2D));
			ValueIndicatorShapeComboBox.SelectedIndex = (int)SmartShape2D.Triangle;

			GaugeOrientationCombo.FillFromEnum(typeof(LinearGaugeOrientation));
			GaugeOrientationCombo.SelectedIndex = 0;

			MarkerWidthUpDown.Value = (decimal)m_Indicator2.Width.Value;
			MarkerHeightUpDown.Value = (decimal)m_Indicator2.Height.Value;
		}

		private NScaleSectionStyle CreateSection(Color tickColor, Color labelColor, NRange1DD range)
		{
			NScaleSectionStyle scaleSection = new NScaleSectionStyle();
			scaleSection.Range = range;
            scaleSection.LabelTextStyle = new NTextStyle(new NFontStyle(), tickColor);
            scaleSection.MajorTickFillStyle = new NColorFillStyle(tickColor);

			NTextStyle labelStyle = new NTextStyle();
			labelStyle.FillStyle = new NColorFillStyle(labelColor);
            labelStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold);
			scaleSection.LabelTextStyle = labelStyle;

			return scaleSection;
		}

		private void ConfigureScale(NLinearScaleConfigurator scale, string text)
		{
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold);
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
            scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90);
            scale.MinorTickCount = 4;
            scale.RulerStyle.BorderStyle.Width = new NLength(0);
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.DarkGray));

			scale.Title.RulerAlignment = HorzAlign.Left;
			scale.Title.Text = text;
            scale.Title.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.View, 0);
			scale.Title.TextStyle.FontStyle.EmSize = new NLength(16);
			scale.Title.TextStyle.FontStyle.Style = FontStyle.Bold;
			scale.Title.TextStyle.FillStyle = new NGradientFillStyle(Color.White, Color.LightBlue);
			scale.Title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			scale.RoundToTickMax = false;
			scale.RoundToTickMin = false;
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.ShowMarkerEditorButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MarkerHeightUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.MarkerWidthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.ValueIndicatorUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ValueIndicatorShapeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.RangeIndicatorOriginModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.RangeIndicatorOriginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.RangeIndicatorValueUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.GaugeOrientationCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MarkerHeightUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MarkerWidthUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueIndicatorUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RangeIndicatorOriginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RangeIndicatorValueUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ShowMarkerEditorButton);
			this.groupBox1.Controls.Add(this.MarkerHeightUpDown);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.MarkerWidthUpDown);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.ValueIndicatorUpDown);
			this.groupBox1.Controls.Add(this.ValueIndicatorShapeComboBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(180, 208);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Value Indicator";
			// 
			// ShowMarkerEditorButton
			// 
			this.ShowMarkerEditorButton.Location = new System.Drawing.Point(8, 96);
			this.ShowMarkerEditorButton.Name = "ShowMarkerEditorButton";
			this.ShowMarkerEditorButton.Size = new System.Drawing.Size(166, 23);
			this.ShowMarkerEditorButton.TabIndex = 8;
			this.ShowMarkerEditorButton.Text = "Show Editor...";
			this.ShowMarkerEditorButton.Click += new System.EventHandler(this.ShowMarkerEditorButton_Click);
			// 
			// MarkerHeightUpDown
			// 
			this.MarkerHeightUpDown.Location = new System.Drawing.Point(96, 176);
			this.MarkerHeightUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.MarkerHeightUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
			this.MarkerHeightUpDown.Name = "MarkerHeightUpDown";
			this.MarkerHeightUpDown.Size = new System.Drawing.Size(78, 20);
			this.MarkerHeightUpDown.TabIndex = 7;
			this.MarkerHeightUpDown.ValueChanged += new System.EventHandler(this.MarkerHeightUpDown_ValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 176);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 23);
			this.label8.TabIndex = 6;
			this.label8.Text = "Height: ";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MarkerWidthUpDown
			// 
			this.MarkerWidthUpDown.Location = new System.Drawing.Point(96, 144);
			this.MarkerWidthUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.MarkerWidthUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
			this.MarkerWidthUpDown.Name = "MarkerWidthUpDown";
			this.MarkerWidthUpDown.Size = new System.Drawing.Size(78, 20);
			this.MarkerWidthUpDown.TabIndex = 5;
			this.MarkerWidthUpDown.ValueChanged += new System.EventHandler(this.MarkerWidthUpDown_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 23);
			this.label7.TabIndex = 4;
			this.label7.Text = "Width: ";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueIndicatorUpDown
			// 
			this.ValueIndicatorUpDown.Location = new System.Drawing.Point(96, 32);
			this.ValueIndicatorUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.ValueIndicatorUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
			this.ValueIndicatorUpDown.Name = "ValueIndicatorUpDown";
			this.ValueIndicatorUpDown.Size = new System.Drawing.Size(78, 20);
			this.ValueIndicatorUpDown.TabIndex = 1;
			this.ValueIndicatorUpDown.ValueChanged += new System.EventHandler(this.ValueIndicatorUpDown_ValueChanged);
			// 
			// ValueIndicatorShapeComboBox
			// 
			this.ValueIndicatorShapeComboBox.ListProperties.CheckBoxDataMember = "";
			this.ValueIndicatorShapeComboBox.ListProperties.DataSource = null;
			this.ValueIndicatorShapeComboBox.ListProperties.DisplayMember = "";
			this.ValueIndicatorShapeComboBox.Location = new System.Drawing.Point(96, 64);
			this.ValueIndicatorShapeComboBox.Name = "ValueIndicatorShapeComboBox";
			this.ValueIndicatorShapeComboBox.Size = new System.Drawing.Size(78, 21);
			this.ValueIndicatorShapeComboBox.TabIndex = 3;
			this.ValueIndicatorShapeComboBox.Text = "comboBox1";
			this.ValueIndicatorShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.ValueIndicatorShapeComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "Shape:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Value:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.RangeIndicatorOriginModeComboBox);
			this.groupBox2.Controls.Add(this.RangeIndicatorOriginUpDown);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.RangeIndicatorValueUpDown);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(0, 208);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(180, 128);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Range Indicator";
			// 
			// RangeIndicatorOriginModeComboBox
			// 
			this.RangeIndicatorOriginModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.RangeIndicatorOriginModeComboBox.ListProperties.DataSource = null;
			this.RangeIndicatorOriginModeComboBox.ListProperties.DisplayMember = "";
			this.RangeIndicatorOriginModeComboBox.Location = new System.Drawing.Point(95, 56);
			this.RangeIndicatorOriginModeComboBox.Name = "RangeIndicatorOriginModeComboBox";
			this.RangeIndicatorOriginModeComboBox.Size = new System.Drawing.Size(79, 21);
			this.RangeIndicatorOriginModeComboBox.TabIndex = 3;
			this.RangeIndicatorOriginModeComboBox.Text = "RangeIndicatorOriginModeComboBox";
			this.RangeIndicatorOriginModeComboBox.SelectedIndexChanged += new System.EventHandler(this.RangeIndicatorOriginModeComboBox_SelectedIndexChanged);
			// 
			// RangeIndicatorOriginUpDown
			// 
			this.RangeIndicatorOriginUpDown.Location = new System.Drawing.Point(96, 96);
			this.RangeIndicatorOriginUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.RangeIndicatorOriginUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
			this.RangeIndicatorOriginUpDown.Name = "RangeIndicatorOriginUpDown";
			this.RangeIndicatorOriginUpDown.Size = new System.Drawing.Size(78, 20);
			this.RangeIndicatorOriginUpDown.TabIndex = 5;
			this.RangeIndicatorOriginUpDown.ValueChanged += new System.EventHandler(this.RangeIndicatorOriginUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Origin:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Origin Mode:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Value:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RangeIndicatorValueUpDown
			// 
			this.RangeIndicatorValueUpDown.Location = new System.Drawing.Point(96, 16);
			this.RangeIndicatorValueUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.RangeIndicatorValueUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
			this.RangeIndicatorValueUpDown.Name = "RangeIndicatorValueUpDown";
			this.RangeIndicatorValueUpDown.Size = new System.Drawing.Size(78, 20);
			this.RangeIndicatorValueUpDown.TabIndex = 1;
			this.RangeIndicatorValueUpDown.ValueChanged += new System.EventHandler(this.RangeIndicatorValueUpDown_ValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 352);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 2;
			this.label6.Text = "Orientation:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GaugeOrientationCombo
			// 
			this.GaugeOrientationCombo.ListProperties.CheckBoxDataMember = "";
			this.GaugeOrientationCombo.ListProperties.DataSource = null;
			this.GaugeOrientationCombo.ListProperties.DisplayMember = "";
			this.GaugeOrientationCombo.Location = new System.Drawing.Point(96, 352);
			this.GaugeOrientationCombo.Name = "GaugeOrientationCombo";
			this.GaugeOrientationCombo.Size = new System.Drawing.Size(79, 21);
			this.GaugeOrientationCombo.TabIndex = 3;
			this.GaugeOrientationCombo.Text = "GaugeOrientationCombo";
			this.GaugeOrientationCombo.SelectedIndexChanged += new System.EventHandler(this.GaugeOrientationCombo_SelectedIndexChanged);
			// 
			// NLinearGaugeIndicatorsUC
			// 
			this.Controls.Add(this.GaugeOrientationCombo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NLinearGaugeIndicatorsUC";
			this.Size = new System.Drawing.Size(180, 416);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MarkerHeightUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MarkerWidthUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueIndicatorUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.RangeIndicatorOriginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RangeIndicatorValueUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RangeIndicatorOriginModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_Indicator1.OriginMode = (OriginMode)RangeIndicatorOriginModeComboBox.SelectedIndex;
			if (m_Indicator1.OriginMode != OriginMode.Custom)
			{
				RangeIndicatorOriginUpDown.Enabled = false;
			}
			else
			{
				RangeIndicatorOriginUpDown.Enabled = true;
			}

			nChartControl1.Refresh();		
		}

		private void GaugeOrientationCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		    m_LinearGauge.Orientation = (LinearGaugeOrientation)GaugeOrientationCombo.SelectedIndex;

            if (m_LinearGauge.Orientation == LinearGaugeOrientation.Horizontal)
            {
                m_LinearGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(130, NGraphicsUnit.Point));
                m_LinearGauge.Padding = new NMarginsL(20, 0, 10, 0);
            }
            else
            {
                m_LinearGauge.Size = new NSizeL(new NLength(130, NGraphicsUnit.Point), new NLength(80, NRelativeUnit.ParentPercentage));
                m_LinearGauge.Padding = new NMarginsL(0, 10, 0, 20);
            }
			nChartControl1.Refresh();
		}

		private void ValueIndicatorUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_Indicator2.Value = (double)ValueIndicatorUpDown.Value;
			nChartControl1.Refresh();
		}

		private void RangeIndicatorValueUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_Indicator1.Value = (double)RangeIndicatorValueUpDown.Value;
			nChartControl1.Refresh();
		}

		private void RangeIndicatorOriginUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_Indicator1.Origin = (double)RangeIndicatorOriginUpDown.Value;
			nChartControl1.Refresh();		
		}

		private void ValueIndicatorShapeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			N2DSmartShapeFactory factory = new N2DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle);
			m_Indicator2.Shape = factory.CreateShape((SmartShape2D)ValueIndicatorShapeComboBox.SelectedIndex);
			nChartControl1.Refresh();
		}

		private void ShowMarkerEditorButton_Click(object sender, System.EventArgs e)
		{
			NSmartShapeEditorUC editor2 = new NSmartShapeEditorUC();

			NSmartShapesCategory cat = new NSmartShapesCategory("Marker Shapes");
			N2DSmartShapeFactory factory = new N2DSmartShapeFactory(m_Indicator2.Shape.FillStyle, m_Indicator2.Shape.StrokeStyle, m_Indicator2.Shape.ShadowStyle);

			NSmartShape[] shapes = factory.CreateShapes();

			for (int i = 0; i < shapes.Length; i++)
			{
				cat.Add(shapes[i]);
			}

			editor2.PredefinedShapes = new NSmartShapesCategory[]{cat};
			editor2.Shape = (NSmartShape)(((ICloneable)m_Indicator2.Shape).Clone());

			if (editor2.ShowInHostForm() == DialogResult.OK)
			{
				m_Indicator2.Shape = editor2.Shape;
				nChartControl1.Refresh();
			}
			
			editor2.Dispose();
		}

		private void MarkerWidthUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_Indicator2.Width = new NLength((float)MarkerWidthUpDown.Value);
			nChartControl1.Refresh();
		}

		private void MarkerHeightUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			m_Indicator2.Height = new NLength((float)MarkerHeightUpDown.Value);
			nChartControl1.Refresh();
		}
	}
}
