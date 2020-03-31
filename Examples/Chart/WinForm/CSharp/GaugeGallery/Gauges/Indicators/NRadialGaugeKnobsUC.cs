using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.SmartShapes;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NRadialGaugeKnobsUC : NExampleBaseUC
	{
		bool m_Updating;
		NRadialGaugePanel m_RadialGauge;
		private Nevron.UI.WinForm.Controls.NComboBox MarkerShapeComboBox;
		private Label label5;
		private Nevron.UI.WinForm.Controls.NComboBox OuterRimPatternComboBox;
		private Label label1;
		private Label label2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown OuterRimPatternRepeatCountUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown OuterRimRadiusOffsetUpDown;
		private Label label3;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private Nevron.UI.WinForm.Controls.NNumericUpDown InnerRimRadiusOffsetUpDown;
		private Label label4;
		private Nevron.UI.WinForm.Controls.NNumericUpDown InnerRimPatternRepeatCountUpDown;
		private Label label6;
		private Nevron.UI.WinForm.Controls.NComboBox InnerRimPatternComboBox;
		private Label label7;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MarkerOffsetUpDown;
		private Label label8;
		private Nevron.UI.WinForm.Controls.NComboBox MarkerPaintOrderComboBox;
		private Label label9;
		NNumericDisplayPanel m_NumericDisplay;
	
		public NRadialGaugeKnobsUC()
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
			this.MarkerShapeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.OuterRimPatternComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.OuterRimPatternRepeatCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.OuterRimRadiusOffsetUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.InnerRimRadiusOffsetUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.InnerRimPatternRepeatCountUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.InnerRimPatternComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.MarkerPaintOrderComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.MarkerOffsetUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.OuterRimPatternRepeatCountUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OuterRimRadiusOffsetUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InnerRimRadiusOffsetUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InnerRimPatternRepeatCountUpDown)).BeginInit();
			this.nGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MarkerOffsetUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// MarkerShapeComboBox
			// 
			this.MarkerShapeComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.MarkerShapeComboBox.ListProperties.CheckBoxDataMember = "";
			this.MarkerShapeComboBox.ListProperties.DataSource = null;
			this.MarkerShapeComboBox.ListProperties.DisplayMember = "";
			this.MarkerShapeComboBox.Location = new System.Drawing.Point(3, 36);
			this.MarkerShapeComboBox.Name = "MarkerShapeComboBox";
			this.MarkerShapeComboBox.Size = new System.Drawing.Size(174, 21);
			this.MarkerShapeComboBox.TabIndex = 5;
			this.MarkerShapeComboBox.Text = "KnobStyleComboBox";
			this.MarkerShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.MarkerShapeComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Top;
			this.label5.Location = new System.Drawing.Point(3, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(174, 20);
			this.label5.TabIndex = 4;
			this.label5.Text = "Shape:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// OuterRimPatternComboBox
			// 
			this.OuterRimPatternComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.OuterRimPatternComboBox.ListProperties.CheckBoxDataMember = "";
			this.OuterRimPatternComboBox.ListProperties.DataSource = null;
			this.OuterRimPatternComboBox.ListProperties.DisplayMember = "";
			this.OuterRimPatternComboBox.Location = new System.Drawing.Point(3, 39);
			this.OuterRimPatternComboBox.Name = "OuterRimPatternComboBox";
			this.OuterRimPatternComboBox.Size = new System.Drawing.Size(174, 21);
			this.OuterRimPatternComboBox.TabIndex = 7;
			this.OuterRimPatternComboBox.Text = "KnobStyleComboBox";
			this.OuterRimPatternComboBox.SelectedIndexChanged += new System.EventHandler(this.OuterRimPatternComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Pattern:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(3, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(174, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Repeat Count:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// OuterRimPatternRepeatCountUpDown
			// 
			this.OuterRimPatternRepeatCountUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.OuterRimPatternRepeatCountUpDown.Location = new System.Drawing.Point(3, 83);
			this.OuterRimPatternRepeatCountUpDown.Name = "OuterRimPatternRepeatCountUpDown";
			this.OuterRimPatternRepeatCountUpDown.Size = new System.Drawing.Size(174, 20);
			this.OuterRimPatternRepeatCountUpDown.TabIndex = 9;
			this.OuterRimPatternRepeatCountUpDown.ValueChanged += new System.EventHandler(this.OuterRimPatternRepeatCountUpDown_ValueChanged);
			// 
			// OuterRimRadiusOffsetUpDown
			// 
			this.OuterRimRadiusOffsetUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.OuterRimRadiusOffsetUpDown.Location = new System.Drawing.Point(3, 126);
			this.OuterRimRadiusOffsetUpDown.Name = "OuterRimRadiusOffsetUpDown";
			this.OuterRimRadiusOffsetUpDown.Size = new System.Drawing.Size(174, 20);
			this.OuterRimRadiusOffsetUpDown.TabIndex = 11;
			this.OuterRimRadiusOffsetUpDown.ValueChanged += new System.EventHandler(this.OuterRimRadiusOffsetUpDown_ValueChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(3, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(174, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Radius Offset:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.OuterRimRadiusOffsetUpDown);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.OuterRimPatternRepeatCountUpDown);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.OuterRimPatternComboBox);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(0, 154);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(180, 163);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Outer Rim:";
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.InnerRimRadiusOffsetUpDown);
			this.nGroupBox1.Controls.Add(this.label4);
			this.nGroupBox1.Controls.Add(this.InnerRimPatternRepeatCountUpDown);
			this.nGroupBox1.Controls.Add(this.label6);
			this.nGroupBox1.Controls.Add(this.InnerRimPatternComboBox);
			this.nGroupBox1.Controls.Add(this.label7);
			this.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(0, 317);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(180, 163);
			this.nGroupBox1.TabIndex = 13;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Inner Rim:";
			// 
			// InnerRimRadiusOffsetUpDown
			// 
			this.InnerRimRadiusOffsetUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.InnerRimRadiusOffsetUpDown.Location = new System.Drawing.Point(3, 126);
			this.InnerRimRadiusOffsetUpDown.Name = "InnerRimRadiusOffsetUpDown";
			this.InnerRimRadiusOffsetUpDown.Size = new System.Drawing.Size(174, 20);
			this.InnerRimRadiusOffsetUpDown.TabIndex = 11;
			this.InnerRimRadiusOffsetUpDown.ValueChanged += new System.EventHandler(this.InnerRimRadiusOffsetUpDown_ValueChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(3, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(174, 23);
			this.label4.TabIndex = 10;
			this.label4.Text = "Radius Offset:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// InnerRimPatternRepeatCountUpDown
			// 
			this.InnerRimPatternRepeatCountUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.InnerRimPatternRepeatCountUpDown.Location = new System.Drawing.Point(3, 83);
			this.InnerRimPatternRepeatCountUpDown.Name = "InnerRimPatternRepeatCountUpDown";
			this.InnerRimPatternRepeatCountUpDown.Size = new System.Drawing.Size(174, 20);
			this.InnerRimPatternRepeatCountUpDown.TabIndex = 9;
			this.InnerRimPatternRepeatCountUpDown.ValueChanged += new System.EventHandler(this.InnerRimPatternRepeatCountUpDown_ValueChanged);
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Top;
			this.label6.Location = new System.Drawing.Point(3, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(174, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "Repeat Count:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// InnerRimPatternComboBox
			// 
			this.InnerRimPatternComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.InnerRimPatternComboBox.ListProperties.CheckBoxDataMember = "";
			this.InnerRimPatternComboBox.ListProperties.DataSource = null;
			this.InnerRimPatternComboBox.ListProperties.DisplayMember = "";
			this.InnerRimPatternComboBox.Location = new System.Drawing.Point(3, 39);
			this.InnerRimPatternComboBox.Name = "InnerRimPatternComboBox";
			this.InnerRimPatternComboBox.Size = new System.Drawing.Size(174, 21);
			this.InnerRimPatternComboBox.TabIndex = 7;
			this.InnerRimPatternComboBox.Text = "InnerRimPatternComboBox";
			this.InnerRimPatternComboBox.SelectedIndexChanged += new System.EventHandler(this.InnerRimPatternComboBox_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(3, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(174, 23);
			this.label7.TabIndex = 6;
			this.label7.Text = "Pattern:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.MarkerPaintOrderComboBox);
			this.nGroupBox2.Controls.Add(this.label9);
			this.nGroupBox2.Controls.Add(this.MarkerOffsetUpDown);
			this.nGroupBox2.Controls.Add(this.label8);
			this.nGroupBox2.Controls.Add(this.MarkerShapeComboBox);
			this.nGroupBox2.Controls.Add(this.label5);
			this.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(0, 0);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(180, 154);
			this.nGroupBox2.TabIndex = 14;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Marker:";
			// 
			// MarkerPaintOrderComboBox
			// 
			this.MarkerPaintOrderComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.MarkerPaintOrderComboBox.ListProperties.CheckBoxDataMember = "";
			this.MarkerPaintOrderComboBox.ListProperties.DataSource = null;
			this.MarkerPaintOrderComboBox.ListProperties.DisplayMember = "";
			this.MarkerPaintOrderComboBox.Location = new System.Drawing.Point(3, 120);
			this.MarkerPaintOrderComboBox.Name = "MarkerPaintOrderComboBox";
			this.MarkerPaintOrderComboBox.Size = new System.Drawing.Size(174, 21);
			this.MarkerPaintOrderComboBox.TabIndex = 14;
			this.MarkerPaintOrderComboBox.Text = "KnobStyleComboBox";
			this.MarkerPaintOrderComboBox.SelectedIndexChanged += new System.EventHandler(this.MarkerPaintOrderComboBox_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Top;
			this.label9.Location = new System.Drawing.Point(3, 100);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(174, 20);
			this.label9.TabIndex = 13;
			this.label9.Text = "Paint Order:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// MarkerOffsetUpDown
			// 
			this.MarkerOffsetUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.MarkerOffsetUpDown.Location = new System.Drawing.Point(3, 80);
			this.MarkerOffsetUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.MarkerOffsetUpDown.Name = "MarkerOffsetUpDown";
			this.MarkerOffsetUpDown.Size = new System.Drawing.Size(174, 20);
			this.MarkerOffsetUpDown.TabIndex = 12;
			this.MarkerOffsetUpDown.ValueChanged += new System.EventHandler(this.MarkerOffsetUpDown_ValueChanged);
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Top;
			this.label8.Location = new System.Drawing.Point(3, 57);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(174, 23);
			this.label8.TabIndex = 6;
			this.label8.Text = "Offset:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// NRadialGaugeKnobsUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nGroupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.nGroupBox2);
			this.Name = "NRadialGaugeKnobsUC";
			this.Size = new System.Drawing.Size(180, 598);
			((System.ComponentModel.ISupportInitialize)(this.OuterRimPatternRepeatCountUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OuterRimRadiusOffsetUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.InnerRimRadiusOffsetUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InnerRimPatternRepeatCountUpDown)).EndInit();
			this.nGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MarkerOffsetUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Radial Gauge Knob Indicators");
			header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			header.ContentAlignment = ContentAlignment.BottomRight;
			header.DockMode = PanelDockMode.Top;
			header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
			header.Margins = new NMarginsL(5, 5, 5, 5);

			nChartControl1.Panels.Add(header);

			NDockPanel panelContainer = new NDockPanel();
			panelContainer.DockMode = PanelDockMode.Fill;

			// create the knob indicator
			NKnobIndicator knobIndicator = new NKnobIndicator();
			knobIndicator.OffsetFromScale = new NLength(-3);

			// apply fill style to the marker
			NAdvancedGradientFillStyle advancedGradientFill = new NAdvancedGradientFillStyle();
			advancedGradientFill.BackgroundColor = Color.Red;
			advancedGradientFill.Points.Add(new NAdvancedGradientPoint(Color.White, 20, 20, 0, 100, AGPointShape.Circle));
			knobIndicator.MarkerShape.FillStyle = advancedGradientFill;
			knobIndicator.ValueChanged += new EventHandler(knobIndicator_ValueChanged);
			 
			m_RadialGauge = CreateRadialGauge(knobIndicator);
			m_NumericDisplay = CreateNumericDisplay();

			panelContainer.ChildPanels.Add(m_NumericDisplay);
			panelContainer.ChildPanels.Add(m_RadialGauge);

			panelContainer.Margins = new NMarginsL(10, 10, 10, 10);
			nChartControl1.Panels.Add(panelContainer);

			nChartControl1.Controller.Tools.Add(new NSelectorTool());
			nChartControl1.Controller.Tools.Add(new NIndicatorDragTool());

			m_Updating = true;

			// Init form controls 
			MarkerShapeComboBox.FillFromEnum(typeof(SmartShape2D));
			MarkerShapeComboBox.SelectedIndex = (int)SmartShape2D.Ellipse;
			MarkerOffsetUpDown.Value = (decimal)knobIndicator.OffsetFromScale.Value;
			MarkerPaintOrderComboBox.FillFromEnum(typeof(KnobMarkerPaintOrder));
			MarkerPaintOrderComboBox.SelectedIndex = (int)knobIndicator.MarkerPaintOrder;

			// outer rim
			OuterRimPatternComboBox.FillFromEnum(typeof(CircularRimPattern));
			OuterRimPatternComboBox.SelectedIndex = (int)knobIndicator.OuterRimStyle.Pattern;
			OuterRimPatternRepeatCountUpDown.Value = (decimal)knobIndicator.OuterRimStyle.PatternRepeatCount;
			OuterRimRadiusOffsetUpDown.Value = (decimal)knobIndicator.OuterRimStyle.Offset.Value;

			// inner rim
			InnerRimPatternComboBox.FillFromEnum(typeof(CircularRimPattern));
			InnerRimPatternComboBox.SelectedIndex = (int)knobIndicator.InnerRimStyle.Pattern; 
			InnerRimPatternRepeatCountUpDown.Value = (decimal)knobIndicator.InnerRimStyle.PatternRepeatCount;
			InnerRimRadiusOffsetUpDown.Value = (decimal)knobIndicator.InnerRimStyle.Offset.Value;

			m_Updating = false;

			OuterRimPatternRepeatCountUpDown.Value = 6;
		}

		private NRadialGaugePanel CreateRadialGauge(NKnobIndicator knobIndicator)
		{
			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();

			radialGauge.Size = new NSizeL(new NLength(0), new NLength(50, NRelativeUnit.ParentPercentage));
			radialGauge.ContentAlignment = ContentAlignment.MiddleCenter;
			radialGauge.DockMode = PanelDockMode.Fill;
			radialGauge.SweepAngle = 270;
			radialGauge.BeginAngle = -225;
			radialGauge.CapStyle.Visible = false;

			radialGauge.Indicators.Add(knobIndicator);

			// configure scale
			NGaugeAxis axis = (NGaugeAxis)radialGauge.Axes[0];
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
			scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Italic);
			scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.Black);
			scale.LabelStyle.Angle = new NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0);
			scale.MinorTickCount = 4;
			scale.RulerStyle.BorderStyle.Width = new NLength(0);
			scale.RulerStyle.FillStyle = new NColorFillStyle(Color.DarkGray);

			return radialGauge;
		}

		void knobIndicator_ValueChanged(object sender, EventArgs e)
		{
			if (m_RadialGauge == null)
				return;

			m_NumericDisplay.Value = ((NIndicator)m_RadialGauge.Indicators[0]).Value;
		}

		private NNumericDisplayPanel CreateNumericDisplay()
		{
			NNumericDisplayPanel numericDisplay = new NNumericDisplayPanel();
			numericDisplay.Size = new NSizeL(new NLength(0), new NLength(50, NRelativeUnit.ParentPercentage));
			numericDisplay.DockMode = PanelDockMode.Bottom;
			numericDisplay.BoundsMode = BoundsMode.Fit;
			numericDisplay.Margins = new NMarginsL(10, 10, 10, 10);
			numericDisplay.ContentAlignment = ContentAlignment.MiddleCenter;

			return numericDisplay;
		}

		private void UpdateKnob()
		{
			if (m_Updating)
				return;

			NKnobIndicator knob = m_RadialGauge.Indicators[0] as NKnobIndicator;

			// update the knob marker shape
			N2DSmartShapeFactory factory = new N2DSmartShapeFactory(knob.MarkerShape.FillStyle, knob.MarkerShape.StrokeStyle, knob.MarkerShape.ShadowStyle);
			knob.MarkerShape = factory.CreateShape((SmartShape2D)MarkerShapeComboBox.SelectedIndex);
			knob.OffsetFromScale = new NLength((float)MarkerOffsetUpDown.Value, NGraphicsUnit.Point);
			knob.MarkerPaintOrder = (KnobMarkerPaintOrder)MarkerPaintOrderComboBox.SelectedIndex;

			// update the outer rim style
			knob.OuterRimStyle.Pattern = (CircularRimPattern)OuterRimPatternComboBox.SelectedIndex;
			knob.OuterRimStyle.PatternRepeatCount = (int)OuterRimPatternRepeatCountUpDown.Value;
			knob.OuterRimStyle.Offset = new NLength((float)OuterRimRadiusOffsetUpDown.Value, NGraphicsUnit.Point);

			// update the inner rim style
			knob.InnerRimStyle.Pattern = (CircularRimPattern)InnerRimPatternComboBox.SelectedIndex;
			knob.InnerRimStyle.PatternRepeatCount = (int)InnerRimPatternRepeatCountUpDown.Value;
			knob.InnerRimStyle.Offset = new NLength((float)InnerRimRadiusOffsetUpDown.Value, NGraphicsUnit.Point);

			nChartControl1.Refresh();
		}

		private void MarkerShapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateKnob();
		}

		private void InnerRimPatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateKnob();
		}

		private void InnerRimPatternRepeatCountUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateKnob();
		}

		private void InnerRimRadiusOffsetUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateKnob();
		}

		private void OuterRimPatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateKnob();
		}

		private void OuterRimPatternRepeatCountUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateKnob();
		}

		private void OuterRimRadiusOffsetUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateKnob();
		}

		private void MarkerOffsetUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateKnob();
		}

		private void MarkerPaintOrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateKnob();
		}
	}
}
