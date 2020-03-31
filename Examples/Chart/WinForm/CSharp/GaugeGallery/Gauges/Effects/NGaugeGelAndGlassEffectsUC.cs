using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
    public class NGaugeGelAndGlassEffectsUC : NExampleBaseUC
    {
        
        private Nevron.UI.WinForm.Controls.NHScrollBar SweepAngleScrollBar;
        private Nevron.UI.WinForm.Controls.NHScrollBar BeginAngleScrollBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;

        private NRadialGaugePanel m_RadialGauge;
        private NLinearGaugePanel m_LinearGauge;
        private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
        private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
        private Label label5;
        private Nevron.UI.WinForm.Controls.NComboBox LinearGaugeOrientationComboBox;
        private Nevron.UI.WinForm.Controls.NComboBox PaintEffectComboBox;
        private Label label1;
        private Label label2;
        private Nevron.UI.WinForm.Controls.NGroupBox GlassEffectGroupBox;
        private Label label6;
        private Nevron.UI.WinForm.Controls.NNumericUpDown SpreadUpDown;
        private Nevron.UI.WinForm.Controls.NNumericUpDown DirectionUpDown;
        private Nevron.UI.WinForm.Controls.NComboBox PaintEffectShapeComboBox;
        private Label label7;
        private Nevron.UI.WinForm.Controls.NGroupBox GelEffectGroupBox;
        private Nevron.UI.WinForm.Controls.NNumericUpDown LeftMarginUpDown;
        private Label label8;
        private Nevron.UI.WinForm.Controls.NNumericUpDown TopMarginUpDown;
        private Label label9;
        private Nevron.UI.WinForm.Controls.NNumericUpDown RightMarginUpDown;
        private Label label10;
        private Nevron.UI.WinForm.Controls.NNumericUpDown BottomMarginUpDown;
        private Label label11;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NGaugeGelAndGlassEffectsUC()
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
			this.SweepAngleScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.BeginAngleScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LinearGaugeOrientationComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.PaintEffectComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.GlassEffectGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.SpreadUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.DirectionUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.PaintEffectShapeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.GelEffectGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BottomMarginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.RightMarginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.TopMarginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.LeftMarginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.GlassEffectGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpreadUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DirectionUpDown)).BeginInit();
			this.GelEffectGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BottomMarginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightMarginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TopMarginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftMarginUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// SweepAngleScrollBar
			// 
			this.SweepAngleScrollBar.Location = new System.Drawing.Point(10, 83);
			this.SweepAngleScrollBar.Maximum = 350;
			this.SweepAngleScrollBar.Minimum = -350;
			this.SweepAngleScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.SweepAngleScrollBar.Name = "SweepAngleScrollBar";
			this.SweepAngleScrollBar.Size = new System.Drawing.Size(147, 16);
			this.SweepAngleScrollBar.TabIndex = 3;
			this.SweepAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SweepAngleScrollBar_ValueChanged);
			// 
			// BeginAngleScrollBar
			// 
			this.BeginAngleScrollBar.Location = new System.Drawing.Point(10, 37);
			this.BeginAngleScrollBar.Maximum = 360;
			this.BeginAngleScrollBar.Minimum = -360;
			this.BeginAngleScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.BeginAngleScrollBar.Name = "BeginAngleScrollBar";
			this.BeginAngleScrollBar.Size = new System.Drawing.Size(147, 16);
			this.BeginAngleScrollBar.TabIndex = 1;
			this.BeginAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BeginAngleScrollBar_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Sweep Angle:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Begin Angle:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BeginAngleScrollBar);
			this.groupBox1.Controls.Add(this.SweepAngleScrollBar);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(9, 358);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(183, 113);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Radial Gauge";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.LinearGaugeOrientationComboBox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(9, 477);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(183, 72);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Linear Gauge";
			// 
			// LinearGaugeOrientationComboBox
			// 
			this.LinearGaugeOrientationComboBox.ListProperties.CheckBoxDataMember = "";
			this.LinearGaugeOrientationComboBox.ListProperties.DataSource = null;
			this.LinearGaugeOrientationComboBox.ListProperties.DisplayMember = "";
			this.LinearGaugeOrientationComboBox.Location = new System.Drawing.Point(13, 38);
			this.LinearGaugeOrientationComboBox.Name = "LinearGaugeOrientationComboBox";
			this.LinearGaugeOrientationComboBox.Size = new System.Drawing.Size(144, 21);
			this.LinearGaugeOrientationComboBox.TabIndex = 1;
			this.LinearGaugeOrientationComboBox.SelectedIndexChanged += new System.EventHandler(this.LinearGaugeOrientationComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Orientation:";
			// 
			// PaintEffectComboBox
			// 
			this.PaintEffectComboBox.ListProperties.CheckBoxDataMember = "";
			this.PaintEffectComboBox.ListProperties.DataSource = null;
			this.PaintEffectComboBox.ListProperties.DisplayMember = "";
			this.PaintEffectComboBox.Location = new System.Drawing.Point(9, 27);
			this.PaintEffectComboBox.Name = "PaintEffectComboBox";
			this.PaintEffectComboBox.Size = new System.Drawing.Size(157, 21);
			this.PaintEffectComboBox.TabIndex = 1;
			this.PaintEffectComboBox.SelectedIndexChanged += new System.EventHandler(this.PaintEffectComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Paint Effect:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Light Direction:";
			// 
			// GlassEffectGroupBox
			// 
			this.GlassEffectGroupBox.Controls.Add(this.SpreadUpDown);
			this.GlassEffectGroupBox.Controls.Add(this.DirectionUpDown);
			this.GlassEffectGroupBox.Controls.Add(this.label6);
			this.GlassEffectGroupBox.Controls.Add(this.label2);
			this.GlassEffectGroupBox.Location = new System.Drawing.Point(9, 109);
			this.GlassEffectGroupBox.Name = "GlassEffectGroupBox";
			this.GlassEffectGroupBox.Size = new System.Drawing.Size(183, 82);
			this.GlassEffectGroupBox.TabIndex = 4;
			this.GlassEffectGroupBox.TabStop = false;
			this.GlassEffectGroupBox.Text = "Glass Effect";
			// 
			// SpreadUpDown
			// 
			this.SpreadUpDown.Location = new System.Drawing.Point(105, 42);
			this.SpreadUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
			this.SpreadUpDown.Name = "SpreadUpDown";
			this.SpreadUpDown.Size = new System.Drawing.Size(52, 20);
			this.SpreadUpDown.TabIndex = 3;
			this.SpreadUpDown.ValueChanged += new System.EventHandler(this.SpreadUpDown_ValueChanged);
			// 
			// DirectionUpDown
			// 
			this.DirectionUpDown.Location = new System.Drawing.Point(105, 16);
			this.DirectionUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.DirectionUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.DirectionUpDown.Name = "DirectionUpDown";
			this.DirectionUpDown.Size = new System.Drawing.Size(52, 20);
			this.DirectionUpDown.TabIndex = 1;
			this.DirectionUpDown.ValueChanged += new System.EventHandler(this.DirectionUpDown_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Light Spread:";
			// 
			// PaintEffectShapeComboBox
			// 
			this.PaintEffectShapeComboBox.ListProperties.CheckBoxDataMember = "";
			this.PaintEffectShapeComboBox.ListProperties.DataSource = null;
			this.PaintEffectShapeComboBox.ListProperties.DisplayMember = "";
			this.PaintEffectShapeComboBox.Location = new System.Drawing.Point(9, 73);
			this.PaintEffectShapeComboBox.Name = "PaintEffectShapeComboBox";
			this.PaintEffectShapeComboBox.Size = new System.Drawing.Size(157, 21);
			this.PaintEffectShapeComboBox.TabIndex = 3;
			this.PaintEffectShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.PaintEffectShapeComboBox_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(99, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "Paint Effect Shape:";
			// 
			// GelEffectGroupBox
			// 
			this.GelEffectGroupBox.Controls.Add(this.BottomMarginUpDown);
			this.GelEffectGroupBox.Controls.Add(this.label11);
			this.GelEffectGroupBox.Controls.Add(this.RightMarginUpDown);
			this.GelEffectGroupBox.Controls.Add(this.label10);
			this.GelEffectGroupBox.Controls.Add(this.TopMarginUpDown);
			this.GelEffectGroupBox.Controls.Add(this.label9);
			this.GelEffectGroupBox.Controls.Add(this.LeftMarginUpDown);
			this.GelEffectGroupBox.Controls.Add(this.label8);
			this.GelEffectGroupBox.Location = new System.Drawing.Point(9, 197);
			this.GelEffectGroupBox.Name = "GelEffectGroupBox";
			this.GelEffectGroupBox.Size = new System.Drawing.Size(183, 155);
			this.GelEffectGroupBox.TabIndex = 5;
			this.GelEffectGroupBox.TabStop = false;
			this.GelEffectGroupBox.Text = "Gel Effect";
			// 
			// BottomMarginUpDown
			// 
			this.BottomMarginUpDown.Location = new System.Drawing.Point(105, 97);
			this.BottomMarginUpDown.Name = "BottomMarginUpDown";
			this.BottomMarginUpDown.Size = new System.Drawing.Size(52, 20);
			this.BottomMarginUpDown.TabIndex = 7;
			this.BottomMarginUpDown.ValueChanged += new System.EventHandler(this.BottomMarginUpDown_ValueChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(10, 104);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(78, 13);
			this.label11.TabIndex = 6;
			this.label11.Text = "Bottom Margin:";
			// 
			// RightMarginUpDown
			// 
			this.RightMarginUpDown.Location = new System.Drawing.Point(105, 71);
			this.RightMarginUpDown.Name = "RightMarginUpDown";
			this.RightMarginUpDown.Size = new System.Drawing.Size(52, 20);
			this.RightMarginUpDown.TabIndex = 5;
			this.RightMarginUpDown.ValueChanged += new System.EventHandler(this.RightMarginUpDown_ValueChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 78);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(70, 13);
			this.label10.TabIndex = 4;
			this.label10.Text = "Right Margin:";
			// 
			// TopMarginUpDown
			// 
			this.TopMarginUpDown.Location = new System.Drawing.Point(105, 45);
			this.TopMarginUpDown.Name = "TopMarginUpDown";
			this.TopMarginUpDown.Size = new System.Drawing.Size(52, 20);
			this.TopMarginUpDown.TabIndex = 3;
			this.TopMarginUpDown.ValueChanged += new System.EventHandler(this.TopMarginUpDown_ValueChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(10, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 13);
			this.label9.TabIndex = 2;
			this.label9.Text = "Top Margin:";
			// 
			// LeftMarginUpDown
			// 
			this.LeftMarginUpDown.Location = new System.Drawing.Point(105, 19);
			this.LeftMarginUpDown.Name = "LeftMarginUpDown";
			this.LeftMarginUpDown.Size = new System.Drawing.Size(52, 20);
			this.LeftMarginUpDown.TabIndex = 1;
			this.LeftMarginUpDown.ValueChanged += new System.EventHandler(this.LeftMarginUpDown_ValueChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(10, 26);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Left Margin:";
			// 
			// NGaugeGelAndGlassEffectsUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label7);
			this.Controls.Add(this.GelEffectGroupBox);
			this.Controls.Add(this.GlassEffectGroupBox);
			this.Controls.Add(this.PaintEffectShapeComboBox);
			this.Controls.Add(this.PaintEffectComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "NGaugeGelAndGlassEffectsUC";
			this.Size = new System.Drawing.Size(180, 554);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.GlassEffectGroupBox.ResumeLayout(false);
			this.GlassEffectGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpreadUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DirectionUpDown)).EndInit();
			this.GelEffectGroupBox.ResumeLayout(false);
			this.GelEffectGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BottomMarginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightMarginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TopMarginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftMarginUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public override void Initialize()
        {
            nChartControl1.Panels.Clear();

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Gauge Glass and Gel Effects");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // create the radial gauge
            CreateRadialGauge();

            // create the linear gauge
            CreateLinearGauge();

            // update form controls
            PaintEffectComboBox.Items.Add("None");
            PaintEffectComboBox.Items.Add("Gel");
            PaintEffectComboBox.Items.Add("Glass");
            PaintEffectComboBox.SelectedIndex = 1; // gel

            PaintEffectShapeComboBox.Items.Add("Region");
            PaintEffectShapeComboBox.Items.Add("Rectangle");
            PaintEffectShapeComboBox.Items.Add("Ellipse");
            PaintEffectShapeComboBox.Items.Add("RoundedRect");
            PaintEffectShapeComboBox.SelectedIndex = 2; // ellipse

            BeginAngleScrollBar.Value = (int)m_RadialGauge.BeginAngle;
            SweepAngleScrollBar.Value = (int)m_RadialGauge.SweepAngle;

            DirectionUpDown.Value = 45;
            SpreadUpDown.Value = 60;

            LeftMarginUpDown.Value = 3;
            TopMarginUpDown.Value = 3;
            RightMarginUpDown.Value = 3;
            BottomMarginUpDown.Value = 80;

            LinearGaugeOrientationComboBox.Items.Add("Horizontal");
            LinearGaugeOrientationComboBox.Items.Add("Vertical");
            LinearGaugeOrientationComboBox.SelectedIndex = 1;
        }

        private void ApplyScaleSectionToAxis(NLinearScaleConfigurator scale)
        {
            NScaleSectionStyle scaleSection = new NScaleSectionStyle();

            scaleSection.Range = new NRange1DD(70, 100);
            scaleSection.LabelTextStyle = new NTextStyle();
            scaleSection.LabelTextStyle.FillStyle = new NColorFillStyle(KnownArgbColorValue.DarkRed);
            scaleSection.LabelTextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold);
            scaleSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkRed);

            scale.Sections.Add(scaleSection);
        }

        private void CreateLinearGauge()
        {
            m_LinearGauge = new NLinearGaugePanel();
            nChartControl1.Panels.Add(m_LinearGauge);

            // create the background panel
            m_LinearGauge.BackgroundFillStyle = new NColorFillStyle(Color.Black);
            m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);

            NGaugeAxis axis = (NGaugeAxis)m_LinearGauge.Axes[0];
            axis.Anchor = new NModelGaugeAxisAnchor(new NLength(10, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left);
            ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

            // add some indicators
            AddRangeIndicatorToGauge(m_LinearGauge);
            m_LinearGauge.Indicators.Add(new NMarkerValueIndicator(60));
        }

        private void UpdateEffects()
        {
            if (m_LinearGauge == null || m_RadialGauge == null)
                return;

            NPaintEffectStyle paintEffect = null;

            switch (PaintEffectComboBox.SelectedIndex)
            {
                case 0: // None
                    GlassEffectGroupBox.Enabled = false;
                    GelEffectGroupBox.Enabled = false;
                    PaintEffectShapeComboBox.Enabled = false;

                    break;
                case 1: // Gel
                    GlassEffectGroupBox.Enabled = false;
                    GelEffectGroupBox.Enabled = true;
                    PaintEffectShapeComboBox.Enabled = true;

                    NGelEffectStyle gelEffect = new NGelEffectStyle();
                    gelEffect.Shape = (PaintEffectShape)PaintEffectShapeComboBox.SelectedIndex;
                    gelEffect.Margins = new NMarginsL(  (float)LeftMarginUpDown.Value, 
                                                        (float)TopMarginUpDown.Value, 
                                                        (float)RightMarginUpDown.Value, 
                                                        (float)BottomMarginUpDown.Value);

                    paintEffect = gelEffect;
                    break;
                case 2: // Glass
                    GlassEffectGroupBox.Enabled = true;
                    GelEffectGroupBox.Enabled = false;
                    PaintEffectShapeComboBox.Enabled = true;

                    NGlassEffectStyle glassEffect = new NGlassEffectStyle();
                    glassEffect.Shape = (PaintEffectShape)PaintEffectShapeComboBox.SelectedIndex;
                    glassEffect.LightSpread = (float)SpreadUpDown.Value;
                    glassEffect.LightDirection = (float)DirectionUpDown.Value;
                    glassEffect.LightColor = Color.FromArgb(200, Color.White);
                    glassEffect.DarkColor = Color.FromArgb(200, Color.Gray);

                    paintEffect = glassEffect;
                    break;
            }

            if (paintEffect == null)
            {
                m_LinearGauge.PaintEffect = null;
                m_RadialGauge.PaintEffect = null;
            }
            else
            {
                m_LinearGauge.PaintEffect = paintEffect;
                m_RadialGauge.PaintEffect = (NPaintEffectStyle)paintEffect.Clone();
            }

            nChartControl1.Refresh();
        }

        private void CreateRadialGauge()
        {
            // create the radial gauge
            m_RadialGauge = new NRadialGaugePanel();
            nChartControl1.Panels.Add(m_RadialGauge);

            // create the radial gauge
            m_RadialGauge.SweepAngle = 270;
            m_RadialGauge.BeginAngle = -90;

            // set some background
            m_RadialGauge.BackgroundFillStyle = new NColorFillStyle(Color.Black);;
            m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);

            // configure the axis
            NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
            axis.Range = new NRange1DD(0, 100);
            axis.Anchor.RulerOrientation = RulerOrientation.Right;
            axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);

            ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

            // add some indicators
            AddRangeIndicatorToGauge(m_RadialGauge);
            
            NNeedleValueIndicator needle = new NNeedleValueIndicator(60);
            needle.OffsetFromScale = new NLength(15);
            m_RadialGauge.Indicators.Add(needle);
        }

        private void AddRangeIndicatorToGauge(NGaugePanel gauge)
        {
            // add some indicators
            NRangeIndicator rangeIndicator = new NRangeIndicator(new NRange1DD(75, 100));
            rangeIndicator.FillStyle = new NColorFillStyle(Color.Red);
            rangeIndicator.StrokeStyle.Width = new NLength(0);
            rangeIndicator.OffsetFromScale = new NLength(11);
            rangeIndicator.BeginWidth = new NLength(5);
            rangeIndicator.EndWidth = new NLength(10);
            rangeIndicator.OffsetFromScale = new NLength(15);
            rangeIndicator.PaintOrder = IndicatorPaintOrder.BeforeScale;

            gauge.Indicators.Add(rangeIndicator);
        }

        private void ConfigureScale(NLinearScaleConfigurator scale)
        {
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale.LabelFitModes = new LabelFitMode[0];
            scale.MinorTickCount = 3;
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
            scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 12, FontStyle.Bold);
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
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

        private void PaintEffectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEffects();
        }

        private void PaintEffectShapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEffects();
        }

        private void DirectionUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateEffects();
        }

        private void SpreadUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateEffects();
        }

        private void LeftMarginUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateEffects();
        }

        private void TopMarginUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateEffects();
        }

        private void RightMarginUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateEffects();
        }

        private void BottomMarginUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateEffects();
        }
    }
}
