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
    public class NGaugeBordersUC : NExampleBaseUC
    {
        private System.Windows.Forms.Label label1;
        
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
        private Nevron.UI.WinForm.Controls.NComboBox BorderTypeComboBox;
        private Label label2;
        private Nevron.UI.WinForm.Controls.NNumericUpDown RoundRectRoundingUpDown;
        private Nevron.UI.WinForm.Controls.NComboBox RadialGaugeAutoBorderTypeComboBox;
        private Label label6;
        private Nevron.UI.WinForm.Controls.NNumericUpDown CenterRoundingNumericUpDown;
        private Label label7;
        private Nevron.UI.WinForm.Controls.NNumericUpDown EdgeRoundingNumericUpDown;
        private Label label8;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NGaugeBordersUC()
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
			this.label1 = new System.Windows.Forms.Label();
			this.SweepAngleScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.BeginAngleScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LinearGaugeOrientationComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.BorderTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.RoundRectRoundingUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.RadialGaugeAutoBorderTypeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.CenterRoundingNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.EdgeRoundingNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RoundRectRoundingUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CenterRoundingNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EdgeRoundingNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Border Type:";
			// 
			// SweepAngleScrollBar
			// 
			this.SweepAngleScrollBar.Location = new System.Drawing.Point(10, 81);
			this.SweepAngleScrollBar.Maximum = 350;
			this.SweepAngleScrollBar.Minimum = -350;
			this.SweepAngleScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.SweepAngleScrollBar.Name = "SweepAngleScrollBar";
			this.SweepAngleScrollBar.Size = new System.Drawing.Size(153, 16);
			this.SweepAngleScrollBar.TabIndex = 3;
			this.SweepAngleScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SweepAngleScrollBar_ValueChanged);
			// 
			// BeginAngleScrollBar
			// 
			this.BeginAngleScrollBar.Location = new System.Drawing.Point(10, 35);
			this.BeginAngleScrollBar.Maximum = 360;
			this.BeginAngleScrollBar.Minimum = -360;
			this.BeginAngleScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.BeginAngleScrollBar.Name = "BeginAngleScrollBar";
			this.BeginAngleScrollBar.Size = new System.Drawing.Size(153, 16);
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
			this.groupBox1.Location = new System.Drawing.Point(3, 231);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(195, 116);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Radial Gauge";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.LinearGaugeOrientationComboBox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(0, 353);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(198, 72);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Linear Gauge";
			// 
			// LinearGaugeOrientationComboBox
			// 
			this.LinearGaugeOrientationComboBox.ListProperties.CheckBoxDataMember = "";
			this.LinearGaugeOrientationComboBox.ListProperties.DataSource = null;
			this.LinearGaugeOrientationComboBox.ListProperties.DisplayMember = "";
			this.LinearGaugeOrientationComboBox.Location = new System.Drawing.Point(14, 38);
			this.LinearGaugeOrientationComboBox.Name = "LinearGaugeOrientationComboBox";
			this.LinearGaugeOrientationComboBox.Size = new System.Drawing.Size(152, 21);
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
			// BorderTypeComboBox
			// 
			this.BorderTypeComboBox.ListProperties.CheckBoxDataMember = "";
			this.BorderTypeComboBox.ListProperties.DataSource = null;
			this.BorderTypeComboBox.ListProperties.DisplayMember = "";
			this.BorderTypeComboBox.Location = new System.Drawing.Point(17, 27);
			this.BorderTypeComboBox.Name = "BorderTypeComboBox";
			this.BorderTypeComboBox.Size = new System.Drawing.Size(149, 21);
			this.BorderTypeComboBox.TabIndex = 1;
			this.BorderTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BorderTypeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Corner Rounding:";
			// 
			// RoundRectRoundingUpDown
			// 
			this.RoundRectRoundingUpDown.Location = new System.Drawing.Point(113, 54);
			this.RoundRectRoundingUpDown.Name = "RoundRectRoundingUpDown";
			this.RoundRectRoundingUpDown.Size = new System.Drawing.Size(52, 20);
			this.RoundRectRoundingUpDown.TabIndex = 3;
			this.RoundRectRoundingUpDown.ValueChanged += new System.EventHandler(this.RoundRectRoundingUpDown_ValueChanged);
			// 
			// RadialGaugeAutoBorderTypeComboBox
			// 
			this.RadialGaugeAutoBorderTypeComboBox.ListProperties.CheckBoxDataMember = "";
			this.RadialGaugeAutoBorderTypeComboBox.ListProperties.DataSource = null;
			this.RadialGaugeAutoBorderTypeComboBox.ListProperties.DisplayMember = "";
			this.RadialGaugeAutoBorderTypeComboBox.Location = new System.Drawing.Point(14, 125);
			this.RadialGaugeAutoBorderTypeComboBox.Name = "RadialGaugeAutoBorderTypeComboBox";
			this.RadialGaugeAutoBorderTypeComboBox.Size = new System.Drawing.Size(152, 21);
			this.RadialGaugeAutoBorderTypeComboBox.TabIndex = 5;
			this.RadialGaugeAutoBorderTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.RadialGaugeAutoBorderTypeComboBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 109);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(134, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Radial Gauge Auto Border:";
			// 
			// CenterRoundingNumericUpDown
			// 
			this.CenterRoundingNumericUpDown.Location = new System.Drawing.Point(113, 162);
			this.CenterRoundingNumericUpDown.Name = "CenterRoundingNumericUpDown";
			this.CenterRoundingNumericUpDown.Size = new System.Drawing.Size(53, 20);
			this.CenterRoundingNumericUpDown.TabIndex = 7;
			this.CenterRoundingNumericUpDown.ValueChanged += new System.EventHandler(this.CenterRoundingNumericUpDown_ValueChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 169);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Center Rounding:";
			// 
			// EdgeRoundingNumericUpDown
			// 
			this.EdgeRoundingNumericUpDown.Location = new System.Drawing.Point(113, 188);
			this.EdgeRoundingNumericUpDown.Name = "EdgeRoundingNumericUpDown";
			this.EdgeRoundingNumericUpDown.Size = new System.Drawing.Size(53, 20);
			this.EdgeRoundingNumericUpDown.TabIndex = 9;
			this.EdgeRoundingNumericUpDown.ValueChanged += new System.EventHandler(this.EdgeRoundingNumericUpDown_ValueChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(11, 195);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(84, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Edge Rounding:";
			// 
			// NGaugeBordersUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.EdgeRoundingNumericUpDown);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.CenterRoundingNumericUpDown);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.RadialGaugeAutoBorderTypeComboBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.RoundRectRoundingUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BorderTypeComboBox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Name = "NGaugeBordersUC";
			this.Size = new System.Drawing.Size(180, 433);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RoundRectRoundingUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CenterRoundingNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EdgeRoundingNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public override void Initialize()
        {
            nChartControl1.Panels.Clear();
            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Gauge Borders");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // create the radial gauge
            CreateRadialGauge();

            // create the linear gauge
            CreateLinearGauge();

            BeginAngleScrollBar.Value = (int)m_RadialGauge.BeginAngle;
            SweepAngleScrollBar.Value = (int)m_RadialGauge.SweepAngle;
            CenterRoundingNumericUpDown.Value = 17;
            EdgeRoundingNumericUpDown.Value = 10;
            RoundRectRoundingUpDown.Value = 10;

            LinearGaugeOrientationComboBox.Items.Add("Horizontal");
            LinearGaugeOrientationComboBox.Items.Add("Vertical");
            LinearGaugeOrientationComboBox.SelectedIndex = 1;

            BorderTypeComboBox.Items.Add("Rectangular");
            BorderTypeComboBox.Items.Add("Rounded Rectangular");
            BorderTypeComboBox.Items.Add("Auto");
            BorderTypeComboBox.SelectedIndex = 2;

            RadialGaugeAutoBorderTypeComboBox.Items.Add("Circle");
            RadialGaugeAutoBorderTypeComboBox.Items.Add("Cut Circle");
            RadialGaugeAutoBorderTypeComboBox.Items.Add("Rounded Outline");
            RadialGaugeAutoBorderTypeComboBox.SelectedIndex = 0;
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
            NAdvancedGradientFillStyle advGradient = new NAdvancedGradientFillStyle();
            advGradient.BackgroundColor = Color.Black;
            advGradient.Points.Add(new NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle));
            m_LinearGauge.BackgroundFillStyle = advGradient;
            m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);

            NGaugeAxis axis = (NGaugeAxis)m_LinearGauge.Axes[0];
            axis.Anchor = new NModelGaugeAxisAnchor(new NLength(10, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left);
            ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

            // add some indicators
            AddRangeIndicatorToGauge(m_LinearGauge);
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
            advGradient.Points.Add(new NAdvancedGradientPoint(Color.White, 10, 10, 0, 100, AGPointShape.Circle));
            m_RadialGauge.BackgroundFillStyle = advGradient;

            // configure its axis
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

        private void UpdateGaugeBorders()
        {
            if (m_RadialGauge == null || m_LinearGauge == null)
                return;

            bool enableRoundRelatedControls = false;
            bool enableAutoRelatedControls = false;
            switch (BorderTypeComboBox.SelectedIndex)
            {
                case 0: // rect
                    m_RadialGauge.BorderStyle.Shape = BorderShape.Rectangle;
                    m_LinearGauge.BorderStyle.Shape = BorderShape.Rectangle;
                    break;
                case 1: // rounded rect
                    m_RadialGauge.BorderStyle.Shape = BorderShape.RoundedRect;
                    m_RadialGauge.BorderStyle.CornerRounding = new NLength((float)RoundRectRoundingUpDown.Value, NGraphicsUnit.Point);
                    m_LinearGauge.BorderStyle.Shape = BorderShape.RoundedRect;
                    m_LinearGauge.BorderStyle.CornerRounding = new NLength((float)RoundRectRoundingUpDown.Value, NGraphicsUnit.Point);

                    break;
                case 2: // auto
                    enableAutoRelatedControls = true;
                    m_RadialGauge.BorderStyle.Shape = BorderShape.Auto;
                    m_LinearGauge.BorderStyle.Shape = BorderShape.Auto;
                    break;
            }

            if (m_RadialGauge.BorderStyle.Shape == BorderShape.Auto)
            {
                // also apply auto settings
                
                switch (RadialGaugeAutoBorderTypeComboBox.SelectedIndex)
                {
                    case 0: // circle
                        m_RadialGauge.AutoBorder = RadialGaugeAutoBorder.Circle;
                        break;
                    case 1: // cut circle
                        enableRoundRelatedControls = true;
                        m_RadialGauge.AutoBorder = RadialGaugeAutoBorder.CutCircle;
                        m_RadialGauge.CenterBorderRounding = new NLength((float)CenterRoundingNumericUpDown.Value, NGraphicsUnit.Point);
                        m_RadialGauge.EdgeBorderRounding = new NLength((float)EdgeRoundingNumericUpDown.Value, NGraphicsUnit.Point);
                        break;
                    case 2: // rounded outline
                        enableRoundRelatedControls = true;
                        m_RadialGauge.AutoBorder = RadialGaugeAutoBorder.RoundedOutline;
                        m_RadialGauge.CenterBorderRounding = new NLength((float)CenterRoundingNumericUpDown.Value, NGraphicsUnit.Point);
                        m_RadialGauge.EdgeBorderRounding = new NLength((float)EdgeRoundingNumericUpDown.Value, NGraphicsUnit.Point);
                        break;
                }
            }

            RadialGaugeAutoBorderTypeComboBox.Enabled = enableAutoRelatedControls;
            CenterRoundingNumericUpDown.Enabled = enableRoundRelatedControls;
            EdgeRoundingNumericUpDown.Enabled = enableRoundRelatedControls;

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

        private void BorderTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGaugeBorders();
        }

        private void RadialGaugeAutoBorderTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGaugeBorders();
        }

        private void RoundRectRoundingUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateGaugeBorders();
        }

        private void CenterRoundingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateGaugeBorders();
        }

        private void EdgeRoundingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateGaugeBorders();
        }
    }
}
