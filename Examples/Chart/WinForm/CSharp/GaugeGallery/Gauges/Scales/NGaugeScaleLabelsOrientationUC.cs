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
    public class NGaugeScaleLabelsOrientationUC : NExampleBaseUC
    {
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NComboBox AngleModeComboBox;
        private System.Windows.Forms.Label label2;
        private Nevron.UI.WinForm.Controls.NNumericUpDown CustomAngleNumericUpDown;
        private Nevron.UI.WinForm.Controls.NCheckBox AllowTextFlipCheckBox;
        
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

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NGaugeScaleLabelsOrientationUC()
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
			this.AngleModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.CustomAngleNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.AllowTextFlipCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SweepAngleScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.BeginAngleScrollBar = new Nevron.UI.WinForm.Controls.NHScrollBar();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LinearGaugeOrientationComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.CustomAngleNumericUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Angle Mode:";
			// 
			// AngleModeComboBox
			// 
			this.AngleModeComboBox.ListProperties.CheckBoxDataMember = "";
			this.AngleModeComboBox.ListProperties.DataSource = null;
			this.AngleModeComboBox.ListProperties.DisplayMember = "";
			this.AngleModeComboBox.Location = new System.Drawing.Point(11, 26);
			this.AngleModeComboBox.Name = "AngleModeComboBox";
			this.AngleModeComboBox.Size = new System.Drawing.Size(155, 21);
			this.AngleModeComboBox.TabIndex = 1;
			this.AngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.AngleModeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Custom Angle:";
			// 
			// CustomAngleNumericUpDown
			// 
			this.CustomAngleNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.CustomAngleNumericUpDown.Location = new System.Drawing.Point(11, 71);
			this.CustomAngleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.CustomAngleNumericUpDown.Name = "CustomAngleNumericUpDown";
			this.CustomAngleNumericUpDown.Size = new System.Drawing.Size(155, 20);
			this.CustomAngleNumericUpDown.TabIndex = 3;
			this.CustomAngleNumericUpDown.ValueChanged += new System.EventHandler(this.CustomAngleNumericUpDown_ValueChanged);
			// 
			// AllowTextFlipCheckBox
			// 
			this.AllowTextFlipCheckBox.AutoSize = true;
			this.AllowTextFlipCheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowTextFlipCheckBox.Location = new System.Drawing.Point(11, 108);
			this.AllowTextFlipCheckBox.Name = "AllowTextFlipCheckBox";
			this.AllowTextFlipCheckBox.Size = new System.Drawing.Size(109, 17);
			this.AllowTextFlipCheckBox.TabIndex = 4;
			this.AllowTextFlipCheckBox.Text = "Allow labels to flip";
			this.AllowTextFlipCheckBox.UseVisualStyleBackColor = true;
			this.AllowTextFlipCheckBox.CheckedChanged += new System.EventHandler(this.AllowTextFlipCheckBox_CheckedChanged);
			// 
			// SweepAngleScrollBar
			// 
			this.SweepAngleScrollBar.Location = new System.Drawing.Point(10, 83);
			this.SweepAngleScrollBar.Maximum = 350;
			this.SweepAngleScrollBar.Minimum = -350;
			this.SweepAngleScrollBar.MinimumSize = new System.Drawing.Size(32, 16);
			this.SweepAngleScrollBar.Name = "SweepAngleScrollBar";
			this.SweepAngleScrollBar.Size = new System.Drawing.Size(136, 16);
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
			this.BeginAngleScrollBar.Size = new System.Drawing.Size(136, 16);
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
			this.groupBox1.Location = new System.Drawing.Point(11, 149);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(155, 113);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Radial Gauge";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.LinearGaugeOrientationComboBox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(11, 268);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(155, 72);
			this.groupBox2.TabIndex = 6;
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
			this.LinearGaugeOrientationComboBox.Size = new System.Drawing.Size(133, 21);
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
			// NGaugeScaleLabelsOrientationUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.AllowTextFlipCheckBox);
			this.Controls.Add(this.CustomAngleNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.AngleModeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NGaugeScaleLabelsOrientationUC";
			this.Size = new System.Drawing.Size(180, 433);
			((System.ComponentModel.ISupportInitialize)(this.CustomAngleNumericUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public override void Initialize()
        {
            nChartControl1.Panels.Clear();

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Gauge Labels Orientation");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // create the radial gauge
            CreateRadialGauge();

			// create the linear gauge
            CreateLinearGauge();

            // update form controls
			AngleModeComboBox.FillFromEnum(typeof(ScaleLabelAngleMode));
			AngleModeComboBox.SelectedIndex = (int)ScaleLabelAngleMode.View;

            BeginAngleScrollBar.Value = (int)m_RadialGauge.BeginAngle;
            SweepAngleScrollBar.Value = (int)m_RadialGauge.SweepAngle;

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

            // configure the axis
            NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
            axis.Range = new NRange1DD(0, 100);
            axis.Anchor.RulerOrientation = RulerOrientation.Right;
            axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);

            ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

            // add some indicators
            AddRangeIndicatorToGauge(m_RadialGauge);
            
            NNeedleValueIndicator needle = new NNeedleValueIndicator(60);
			needle.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleMiddle;
            needle.OffsetFromScale = new NLength(15);
            m_RadialGauge.Indicators.Add(needle);
        }

        private void AddRangeIndicatorToGauge(NGaugePanel gauge)
        {
            // add some indicators
            NRangeIndicator rangeIndicator = new NRangeIndicator(new NRange1DD(75, 100));
            rangeIndicator.FillStyle = new NColorFillStyle(Color.Red);
            rangeIndicator.StrokeStyle.Width = new NLength(0);
            rangeIndicator.BeginWidth = new NLength(5);
            rangeIndicator.EndWidth = new NLength(10);
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

        private void UpdateScaleLabelAngle()
        {
            NScaleLabelAngle angle = new NScaleLabelAngle((ScaleLabelAngleMode)AngleModeComboBox.SelectedIndex,
                                                            (float)CustomAngleNumericUpDown.Value,
                                                            AllowTextFlipCheckBox.Checked);

            // apply angle to radial gauge axis
            NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
            NLinearScaleConfigurator scale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
            scale.LabelStyle.Angle = angle;

            // apply angle to linear gauge axis
            axis = (NGaugeAxis)m_LinearGauge.Axes[0];
            scale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
            scale.LabelStyle.Angle = angle;

            nChartControl1.Refresh();
        }

        private void AngleModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScaleLabelAngle();
        }

        private void CustomAngleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleLabelAngle();
        }

        private void AllowTextFlipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScaleLabelAngle();
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
    }
}
