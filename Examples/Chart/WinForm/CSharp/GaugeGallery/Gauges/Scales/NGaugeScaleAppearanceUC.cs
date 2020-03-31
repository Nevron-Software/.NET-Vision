using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NGaugeScaleAppearanceUC : NExampleBaseUC
	{
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox PredefinedScaleStyleComboBox;
		private Nevron.UI.WinForm.Controls.NButton RulerFillStyleButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Nevron.UI.WinForm.Controls.NButton RulerStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton MajorTicksFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton MajorTicksStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton MinorTicksFillStyleButton;
		private Nevron.UI.WinForm.Controls.NButton MinorTicksStrokeStyleButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RulerLengthUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown RulerOffsetUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MajorTicksOffsetUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MajorTickLengthUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MajorTickWidthUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MinorTickOffsetUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MinorTickWidthUpDown;
		private Nevron.UI.WinForm.Controls.NNumericUpDown MinorTickLengthUpDown;
		private System.Windows.Forms.Label label10;
		private Nevron.UI.WinForm.Controls.NComboBox MajorTickShapeComboBox;
		private Nevron.UI.WinForm.Controls.NComboBox MinorTickShapeComboBox;
		private System.Windows.Forms.Label label11;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		NGaugeAxis m_Axis;
		bool m_Updating;

		public NGaugeScaleAppearanceUC()
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

		public override void Initialize()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel header = new NLabel("Gauge Axis Scale Appearance");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));
            
			nChartControl1.Panels.Add(header);

			// create the radial gauge
			NRadialGaugePanel radialGauge = new NRadialGaugePanel();

            radialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            radialGauge.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            radialGauge.BackgroundFillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Gray);
            radialGauge.PaintEffect = new NGlassEffectStyle();
            radialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            radialGauge.PositionChildPanelsInContentBounds = true;

			nChartControl1.Panels.Add(radialGauge);

            m_Axis = (NGaugeAxis)radialGauge.Axes[0];
            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
            scale.MinorTickCount = 3;

			NRangeIndicator indicator1 = new NRangeIndicator();
			indicator1.Value = 80;
			indicator1.OriginMode = OriginMode.ScaleMax;
			indicator1.FillStyle = new NColorFillStyle(Color.Red);
			indicator1.StrokeStyle.Color = Color.DarkRed;
			radialGauge.Indicators.Add(indicator1);

			NNeedleValueIndicator indicator2 = new NNeedleValueIndicator();
			indicator2.Value = 79;
			indicator2.Shape.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red);
			indicator2.Shape.StrokeStyle.Color = Color.Red;
			radialGauge.Indicators.Add(indicator2);
			radialGauge.SweepAngle = 270;

			m_Updating = true;

			MinorTickShapeComboBox.FillFromEnum(typeof(ScaleTickShape));
			MajorTickShapeComboBox.FillFromEnum(typeof(ScaleTickShape));
			PredefinedScaleStyleComboBox.FillFromEnum(typeof(PredefinedScaleStyle));
			PredefinedScaleStyleComboBox.SelectedIndex = (int)PredefinedScaleStyle.Standard;

			m_Updating = false;

			InitFormControls();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.RulerLengthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.RulerOffsetUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.RulerStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.RulerFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.MajorTickShapeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.MajorTickWidthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.MajorTickLengthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.MajorTicksOffsetUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.MajorTicksStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MajorTicksFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.MinorTickShapeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.MinorTickWidthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.MinorTickOffsetUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.MinorTicksStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.MinorTicksFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.MinorTickLengthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.PredefinedScaleStyleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RulerLengthUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RulerOffsetUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MajorTickWidthUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MajorTickLengthUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MajorTicksOffsetUpDown)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MinorTickWidthUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MinorTickOffsetUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MinorTickLengthUpDown)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.RulerLengthUpDown);
			this.groupBox1.Controls.Add(this.RulerOffsetUpDown);
			this.groupBox1.Controls.Add(this.RulerStrokeStyleButton);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.RulerFillStyleButton);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(0, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(180, 144);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ruler";
			// 
			// RulerLengthUpDown
			// 
			this.RulerLengthUpDown.Location = new System.Drawing.Point(92, 112);
			this.RulerLengthUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.RulerLengthUpDown.Name = "RulerLengthUpDown";
			this.RulerLengthUpDown.Size = new System.Drawing.Size(78, 20);
			this.RulerLengthUpDown.TabIndex = 5;
			this.RulerLengthUpDown.ValueChanged += new System.EventHandler(this.RulerLengthUpDown_ValueChanged);
			// 
			// RulerOffsetUpDown
			// 
			this.RulerOffsetUpDown.Location = new System.Drawing.Point(92, 88);
			this.RulerOffsetUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.RulerOffsetUpDown.Name = "RulerOffsetUpDown";
			this.RulerOffsetUpDown.Size = new System.Drawing.Size(78, 20);
			this.RulerOffsetUpDown.TabIndex = 3;
			this.RulerOffsetUpDown.ValueChanged += new System.EventHandler(this.RulerOffsetUpDown_ValueChanged);
			// 
			// RulerStrokeStyleButton
			// 
			this.RulerStrokeStyleButton.Location = new System.Drawing.Point(12, 56);
			this.RulerStrokeStyleButton.Name = "RulerStrokeStyleButton";
			this.RulerStrokeStyleButton.Size = new System.Drawing.Size(158, 23);
			this.RulerStrokeStyleButton.TabIndex = 1;
			this.RulerStrokeStyleButton.Text = "Stroke Style";
			this.RulerStrokeStyleButton.Click += new System.EventHandler(this.RulerStrokeStyleButton_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Length:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Offset:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RulerFillStyleButton
			// 
			this.RulerFillStyleButton.Location = new System.Drawing.Point(12, 24);
			this.RulerFillStyleButton.Name = "RulerFillStyleButton";
			this.RulerFillStyleButton.Size = new System.Drawing.Size(158, 23);
			this.RulerFillStyleButton.TabIndex = 0;
			this.RulerFillStyleButton.Text = "Fill Style";
			this.RulerFillStyleButton.Click += new System.EventHandler(this.RulerFillStyleButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.MajorTickShapeComboBox);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.MajorTickWidthUpDown);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.MajorTickLengthUpDown);
			this.groupBox2.Controls.Add(this.MajorTicksOffsetUpDown);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.MajorTicksStrokeStyleButton);
			this.groupBox2.Controls.Add(this.MajorTicksFillStyleButton);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ImageIndex = 0;
			this.groupBox2.Location = new System.Drawing.Point(0, 208);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(180, 216);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Major Ticks";
			// 
			// MajorTickShapeComboBox
			// 
			this.MajorTickShapeComboBox.ListProperties.CheckBoxDataMember = "";
			this.MajorTickShapeComboBox.ListProperties.DataSource = null;
			this.MajorTickShapeComboBox.ListProperties.DisplayMember = "";
			this.MajorTickShapeComboBox.Location = new System.Drawing.Point(72, 24);
			this.MajorTickShapeComboBox.Name = "MajorTickShapeComboBox";
			this.MajorTickShapeComboBox.Size = new System.Drawing.Size(98, 21);
			this.MajorTickShapeComboBox.TabIndex = 1;
			this.MajorTickShapeComboBox.Text = "comboBox1";
			this.MajorTickShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.MajorTickShapeComboBox_SelectedIndexChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 24);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "Shape:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MajorTickWidthUpDown
			// 
			this.MajorTickWidthUpDown.Location = new System.Drawing.Point(92, 184);
			this.MajorTickWidthUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.MajorTickWidthUpDown.Name = "MajorTickWidthUpDown";
			this.MajorTickWidthUpDown.Size = new System.Drawing.Size(78, 20);
			this.MajorTickWidthUpDown.TabIndex = 9;
			this.MajorTickWidthUpDown.ValueChanged += new System.EventHandler(this.MajorTickWidthUpDown_ValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 176);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "Width:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MajorTickLengthUpDown
			// 
			this.MajorTickLengthUpDown.Location = new System.Drawing.Point(92, 152);
			this.MajorTickLengthUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.MajorTickLengthUpDown.Name = "MajorTickLengthUpDown";
			this.MajorTickLengthUpDown.Size = new System.Drawing.Size(78, 20);
			this.MajorTickLengthUpDown.TabIndex = 7;
			this.MajorTickLengthUpDown.ValueChanged += new System.EventHandler(this.MajorTickLengthUpDown_ValueChanged);
			// 
			// MajorTicksOffsetUpDown
			// 
			this.MajorTicksOffsetUpDown.Location = new System.Drawing.Point(92, 120);
			this.MajorTicksOffsetUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.MajorTicksOffsetUpDown.Name = "MajorTicksOffsetUpDown";
			this.MajorTicksOffsetUpDown.Size = new System.Drawing.Size(78, 20);
			this.MajorTicksOffsetUpDown.TabIndex = 5;
			this.MajorTicksOffsetUpDown.ValueChanged += new System.EventHandler(this.MajorTicksOffsetUpDown_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Offset:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Length:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MajorTicksStrokeStyleButton
			// 
			this.MajorTicksStrokeStyleButton.Location = new System.Drawing.Point(12, 88);
			this.MajorTicksStrokeStyleButton.Name = "MajorTicksStrokeStyleButton";
			this.MajorTicksStrokeStyleButton.Size = new System.Drawing.Size(158, 23);
			this.MajorTicksStrokeStyleButton.TabIndex = 3;
			this.MajorTicksStrokeStyleButton.Text = "Stroke Style";
			this.MajorTicksStrokeStyleButton.Click += new System.EventHandler(this.MajorTicksStrokeStyleButton_Click);
			// 
			// MajorTicksFillStyleButton
			// 
			this.MajorTicksFillStyleButton.Location = new System.Drawing.Point(12, 56);
			this.MajorTicksFillStyleButton.Name = "MajorTicksFillStyleButton";
			this.MajorTicksFillStyleButton.Size = new System.Drawing.Size(158, 23);
			this.MajorTicksFillStyleButton.TabIndex = 2;
			this.MajorTicksFillStyleButton.Text = "Fill Style";
			this.MajorTicksFillStyleButton.Click += new System.EventHandler(this.MajorTicksFillStyleButton_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.MinorTickShapeComboBox);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.MinorTickWidthUpDown);
			this.groupBox3.Controls.Add(this.MinorTickOffsetUpDown);
			this.groupBox3.Controls.Add(this.MinorTicksStrokeStyleButton);
			this.groupBox3.Controls.Add(this.MinorTicksFillStyleButton);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.MinorTickLengthUpDown);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.ImageIndex = 0;
			this.groupBox3.Location = new System.Drawing.Point(0, 424);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(180, 216);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Minor Ticks";
			// 
			// MinorTickShapeComboBox
			// 
			this.MinorTickShapeComboBox.ListProperties.CheckBoxDataMember = "";
			this.MinorTickShapeComboBox.ListProperties.DataSource = null;
			this.MinorTickShapeComboBox.ListProperties.DisplayMember = "";
			this.MinorTickShapeComboBox.Location = new System.Drawing.Point(72, 24);
			this.MinorTickShapeComboBox.Name = "MinorTickShapeComboBox";
			this.MinorTickShapeComboBox.Size = new System.Drawing.Size(98, 21);
			this.MinorTickShapeComboBox.TabIndex = 1;
			this.MinorTickShapeComboBox.Text = "comboBox1";
			this.MinorTickShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.MinorTickShapeComboBox_SelectedIndexChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 24);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 23);
			this.label11.TabIndex = 0;
			this.label11.Text = "Shape:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MinorTickWidthUpDown
			// 
			this.MinorTickWidthUpDown.Location = new System.Drawing.Point(92, 152);
			this.MinorTickWidthUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.MinorTickWidthUpDown.Name = "MinorTickWidthUpDown";
			this.MinorTickWidthUpDown.Size = new System.Drawing.Size(78, 20);
			this.MinorTickWidthUpDown.TabIndex = 7;
			this.MinorTickWidthUpDown.ValueChanged += new System.EventHandler(this.MinorTickWidthUpDown_ValueChanged);
			// 
			// MinorTickOffsetUpDown
			// 
			this.MinorTickOffsetUpDown.Location = new System.Drawing.Point(92, 120);
			this.MinorTickOffsetUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.MinorTickOffsetUpDown.Name = "MinorTickOffsetUpDown";
			this.MinorTickOffsetUpDown.Size = new System.Drawing.Size(78, 20);
			this.MinorTickOffsetUpDown.TabIndex = 5;
			this.MinorTickOffsetUpDown.ValueChanged += new System.EventHandler(this.MinorTickOffsetUpDown_ValueChanged);
			// 
			// MinorTicksStrokeStyleButton
			// 
			this.MinorTicksStrokeStyleButton.Location = new System.Drawing.Point(12, 88);
			this.MinorTicksStrokeStyleButton.Name = "MinorTicksStrokeStyleButton";
			this.MinorTicksStrokeStyleButton.Size = new System.Drawing.Size(158, 23);
			this.MinorTicksStrokeStyleButton.TabIndex = 3;
			this.MinorTicksStrokeStyleButton.Text = "Stroke Style";
			this.MinorTicksStrokeStyleButton.Click += new System.EventHandler(this.MinorTicksStrokeStyleButton_Click);
			// 
			// MinorTicksFillStyleButton
			// 
			this.MinorTicksFillStyleButton.Location = new System.Drawing.Point(12, 56);
			this.MinorTicksFillStyleButton.Name = "MinorTicksFillStyleButton";
			this.MinorTicksFillStyleButton.Size = new System.Drawing.Size(158, 23);
			this.MinorTicksFillStyleButton.TabIndex = 2;
			this.MinorTicksFillStyleButton.Text = "Fill Style";
			this.MinorTicksFillStyleButton.Click += new System.EventHandler(this.MinorTicksFillStyleButton_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 184);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "Length:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 23);
			this.label7.TabIndex = 4;
			this.label7.Text = "Offset:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(12, 152);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 23);
			this.label9.TabIndex = 6;
			this.label9.Text = "Width:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MinorTickLengthUpDown
			// 
			this.MinorTickLengthUpDown.Location = new System.Drawing.Point(92, 184);
			this.MinorTickLengthUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.MinorTickLengthUpDown.Name = "MinorTickLengthUpDown";
			this.MinorTickLengthUpDown.Size = new System.Drawing.Size(78, 20);
			this.MinorTickLengthUpDown.TabIndex = 9;
			this.MinorTickLengthUpDown.ValueChanged += new System.EventHandler(this.MinorTickLengthUpDown_ValueChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.PredefinedScaleStyleComboBox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(180, 64);
			this.panel1.TabIndex = 0;
			// 
			// PredefinedScaleStyleComboBox
			// 
			this.PredefinedScaleStyleComboBox.ListProperties.CheckBoxDataMember = "";
			this.PredefinedScaleStyleComboBox.ListProperties.DataSource = null;
			this.PredefinedScaleStyleComboBox.ListProperties.DisplayMember = "";
			this.PredefinedScaleStyleComboBox.Location = new System.Drawing.Point(8, 32);
			this.PredefinedScaleStyleComboBox.Name = "PredefinedScaleStyleComboBox";
			this.PredefinedScaleStyleComboBox.Size = new System.Drawing.Size(162, 21);
			this.PredefinedScaleStyleComboBox.TabIndex = 1;
			this.PredefinedScaleStyleComboBox.Text = "comboBox1";
			this.PredefinedScaleStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.PredefinedScaleStyleComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Load Predefined Scale Style:";
			// 
			// NGaugeScaleAppearanceUC
			// 
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Name = "NGaugeScaleAppearanceUC";
			this.Size = new System.Drawing.Size(180, 648);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.RulerLengthUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RulerOffsetUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MajorTickWidthUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MajorTickLengthUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MajorTicksOffsetUpDown)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MinorTickWidthUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MinorTickOffsetUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MinorTickLengthUpDown)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitFormControls()
		{
			if (m_Updating)
				return;

			m_Updating = true;

			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			RulerLengthUpDown.Value = (decimal)scale.RulerStyle.Height.Value;
			RulerOffsetUpDown.Value = (decimal)scale.RulerStyle.Offset.Value;

			MajorTicksOffsetUpDown.Value = (decimal)scale.OuterMajorTickStyle.Offset.Value;
			MajorTickLengthUpDown.Value = (decimal)scale.OuterMajorTickStyle.Length.Value;
			MajorTickWidthUpDown.Value = (decimal)scale.OuterMajorTickStyle.Width.Value;
			MajorTickShapeComboBox.SelectedIndex = (int)scale.OuterMajorTickStyle.Shape;

			MinorTickOffsetUpDown.Value = (decimal)scale.OuterMinorTickStyle.Offset.Value;
			MinorTickWidthUpDown.Value = (decimal)scale.OuterMinorTickStyle.Width.Value;
			MinorTickLengthUpDown.Value = (decimal)scale.OuterMinorTickStyle.Length.Value;
			MinorTickShapeComboBox.SelectedIndex = (int)scale.OuterMinorTickStyle.Shape;

			m_Updating = false;
		}

		private void UpdateScale()
		{
			if (m_Updating)
				return;

			m_Updating = true;

			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			scale.RulerStyle.Height = new NLength((float)RulerLengthUpDown.Value);
			scale.RulerStyle.Offset = new NLength((float)RulerOffsetUpDown.Value);

			scale.OuterMajorTickStyle.Offset = new NLength((float)MajorTicksOffsetUpDown.Value);
			scale.OuterMajorTickStyle.Length = new NLength((float)MajorTickLengthUpDown.Value);
			scale.OuterMajorTickStyle.Width = new NLength((float)MajorTickWidthUpDown.Value);
			scale.OuterMajorTickStyle.Shape = (ScaleTickShape)MajorTickShapeComboBox.SelectedIndex;

			scale.OuterMinorTickStyle.Offset = new NLength((float)MinorTickOffsetUpDown.Value);
			scale.OuterMinorTickStyle.Width= new NLength((float)MinorTickWidthUpDown.Value);
			scale.OuterMinorTickStyle.Length = new NLength((float)MinorTickLengthUpDown.Value);
			scale.OuterMinorTickStyle.Shape = (ScaleTickShape)MinorTickShapeComboBox.SelectedIndex;

			m_Updating = false;

			nChartControl1.Refresh();
		}

		private void PredefinedScaleStyleComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			scale.SetPredefinedScaleStyle((PredefinedScaleStyle)PredefinedScaleStyleComboBox.SelectedIndex);
			InitFormControls();

			nChartControl1.Refresh();
		}

		private void RulerFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(scale.RulerStyle.FillStyle, out fillStyleResult))
			{
				scale.RulerStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void RulerStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NStrokeStyle stokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(scale.RulerStyle.BorderStyle, out stokeStyleResult))
			{
				scale.RulerStyle.BorderStyle = stokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MajorTicksFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(scale.OuterMajorTickStyle.FillStyle, out fillStyleResult))
			{
				scale.OuterMajorTickStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MajorTicksStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NStrokeStyle stokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(scale.OuterMajorTickStyle.LineStyle, out stokeStyleResult))
			{
				scale.OuterMajorTickStyle.LineStyle = stokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MinorTicksFillStyleButton_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NFillStyle fillStyleResult;

			if (NFillStyleTypeEditor.Edit(scale.OuterMinorTickStyle.FillStyle, out fillStyleResult))
			{
				scale.OuterMinorTickStyle.FillStyle = fillStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void MinorTicksStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			NStandardScaleConfigurator scale = (NStandardScaleConfigurator)m_Axis.ScaleConfigurator;
			NStrokeStyle stokeStyleResult;

			if (NStrokeStyleTypeEditor.Edit(scale.OuterMinorTickStyle.LineStyle, out stokeStyleResult))
			{
				scale.OuterMinorTickStyle.LineStyle = stokeStyleResult;
				nChartControl1.Refresh();
			}
		}

		private void RulerOffsetUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void RulerLengthUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void MajorTickShapeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void MajorTicksOffsetUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void MajorTickLengthUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void MajorTickWidthUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void MinorTickShapeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void MinorTickOffsetUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void MinorTickWidthUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();
		}

		private void MinorTickLengthUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			UpdateScale();		
		}
	}
}
