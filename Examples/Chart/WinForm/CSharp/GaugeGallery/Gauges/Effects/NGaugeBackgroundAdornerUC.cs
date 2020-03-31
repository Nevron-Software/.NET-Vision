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
    public class NGaugeBackgroundAdornerUC : NExampleBaseUC
    {

        private NRadialGaugePanel m_RadialGauge;
        private NLinearGaugePanel m_LinearGauge;
        private Nevron.UI.WinForm.Controls.NComboBox AdornerShapeComboBox;
        private Label label1;
        private Nevron.UI.WinForm.Controls.NGroupBox GelEffectGroupBox;
        private Nevron.UI.WinForm.Controls.NNumericUpDown BottomMarginUpDown;
        private Label label11;
        private Nevron.UI.WinForm.Controls.NNumericUpDown RightMarginUpDown;
        private Label label10;
        private Nevron.UI.WinForm.Controls.NNumericUpDown TopMarginUpDown;
        private Label label9;
        private Nevron.UI.WinForm.Controls.NNumericUpDown LeftMarginUpDown;
        private Label label8;
        private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
        private Nevron.UI.WinForm.Controls.NComboBox LinearGaugeOrientationComboBox;
        private Label label5;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NGaugeBackgroundAdornerUC()
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
			this.AdornerShapeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.GelEffectGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.BottomMarginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.RightMarginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.TopMarginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.LeftMarginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.LinearGaugeOrientationComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.GelEffectGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BottomMarginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightMarginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TopMarginUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftMarginUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// AdornerShapeComboBox
			// 
			this.AdornerShapeComboBox.ListProperties.CheckBoxDataMember = "";
			this.AdornerShapeComboBox.ListProperties.DataSource = null;
			this.AdornerShapeComboBox.ListProperties.DisplayMember = "";
			this.AdornerShapeComboBox.Location = new System.Drawing.Point(9, 27);
			this.AdornerShapeComboBox.Name = "AdornerShapeComboBox";
			this.AdornerShapeComboBox.Size = new System.Drawing.Size(159, 21);
			this.AdornerShapeComboBox.TabIndex = 1;
			this.AdornerShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.PaintEffectComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Shape:";
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
			this.GelEffectGroupBox.Location = new System.Drawing.Point(9, 64);
			this.GelEffectGroupBox.Name = "GelEffectGroupBox";
			this.GelEffectGroupBox.Size = new System.Drawing.Size(183, 155);
			this.GelEffectGroupBox.TabIndex = 6;
			this.GelEffectGroupBox.TabStop = false;
			this.GelEffectGroupBox.Text = "Margins";
			// 
			// BottomMarginUpDown
			// 
			this.BottomMarginUpDown.Location = new System.Drawing.Point(107, 97);
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
			this.RightMarginUpDown.Location = new System.Drawing.Point(107, 71);
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
			this.TopMarginUpDown.Location = new System.Drawing.Point(107, 45);
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
			this.LeftMarginUpDown.Location = new System.Drawing.Point(107, 19);
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.LinearGaugeOrientationComboBox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(9, 241);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(183, 72);
			this.groupBox2.TabIndex = 8;
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
			this.LinearGaugeOrientationComboBox.Size = new System.Drawing.Size(146, 21);
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
			// NGaugeBackgroundAdornerUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.GelEffectGroupBox);
			this.Controls.Add(this.AdornerShapeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "NGaugeBackgroundAdornerUC";
			this.Size = new System.Drawing.Size(180, 554);
			this.GelEffectGroupBox.ResumeLayout(false);
			this.GelEffectGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BottomMarginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightMarginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TopMarginUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftMarginUpDown)).EndInit();
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
            NLabel title = nChartControl1.Labels.AddHeader("Gauge Background Adorner");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // create the radial gauge
            CreateRadialGauge();

            // create the linear gauge
            CreateLinearGauge();

            // update form controls
            AdornerShapeComboBox.FillFromEnum(typeof(GaugeBackroundAdornerShape));
            AdornerShapeComboBox.SelectedIndex = 0;

            LeftMarginUpDown.Value = 0;
            TopMarginUpDown.Value = 55;
            RightMarginUpDown.Value = 0;
            BottomMarginUpDown.Value = 0;

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

        private NGaugeBackgroundAdorner CreateBackgroundAdorner()
        {
            GaugeBackroundAdornerShape shape = (GaugeBackroundAdornerShape)AdornerShapeComboBox.SelectedIndex;
            NMarginsL margins = new NMarginsL(new NLength((float)LeftMarginUpDown.Value, NRelativeUnit.ParentPercentage), 
                                                new NLength((float)TopMarginUpDown.Value, NRelativeUnit.ParentPercentage),
                                                new NLength((float)RightMarginUpDown.Value, NRelativeUnit.ParentPercentage),
                                                new NLength((float)BottomMarginUpDown.Value, NRelativeUnit.ParentPercentage));

            NGaugeBackgroundAdorner adorner = new NGaugeBackgroundAdorner();
            adorner.FillStyle = new NGradientFillStyle(Color.FromArgb(0, Color.Black), Color.FromArgb(120, Color.LightGreen));
            adorner.Shape = shape;
            adorner.Margins = margins;

            return adorner;
        }

        private void UpdateEffects()
        {
            if (m_LinearGauge == null || m_RadialGauge == null)
                return;

            m_LinearGauge.BackgroundAdorner = CreateBackgroundAdorner();
            m_RadialGauge.BackgroundAdorner = CreateBackgroundAdorner();

            nChartControl1.Refresh();
        }

        private void CreateRadialGauge()
        {
            // create the radial gauge
            m_RadialGauge = new NRadialGaugePanel();
            nChartControl1.Panels.Add(m_RadialGauge);

            // create the radial gauge
            m_RadialGauge.BeginAngle = -225;
            m_RadialGauge.SweepAngle = 270;

            // set some background
            m_RadialGauge.BackgroundFillStyle = new NColorFillStyle(Color.Black);;
            m_RadialGauge.PaintEffect = new NGlassEffectStyle();
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

            LinearGaugeOrientationComboBox.SelectedIndex = 0;
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
            rangeIndicator.PaintOrder = IndicatorPaintOrder.AfterScale;

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
