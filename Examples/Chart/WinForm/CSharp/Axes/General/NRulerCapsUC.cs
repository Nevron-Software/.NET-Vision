using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
    public class NRulerCapsUC : NExampleBaseUC
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Nevron.UI.WinForm.Controls.NComboBox BeginCapComboBox;
        private Nevron.UI.WinForm.Controls.NComboBox EndCapComboBox;
        private Nevron.UI.WinForm.Controls.NCheckBox PaintOnScaleBreaks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Nevron.UI.WinForm.Controls.NNumericUpDown WidthNumericUpDown;
        private Nevron.UI.WinForm.Controls.NNumericUpDown HeightNumericUpDown;
        private System.ComponentModel.IContainer components = null;
        private Nevron.UI.WinForm.Controls.NComboBox ScaleBreakCapComboBox;
        private Label label5;

        public NRulerCapsUC()
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
            this.label2 = new System.Windows.Forms.Label();
            this.BeginCapComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.EndCapComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.PaintOnScaleBreaks = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WidthNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.HeightNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.ScaleBreakCapComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Begin Cap Style:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Cap Style:";
            // 
            // BeginCapComboBox
            // 
            this.BeginCapComboBox.Location = new System.Drawing.Point(12, 28);
            this.BeginCapComboBox.Name = "BeginCapComboBox";
            this.BeginCapComboBox.Size = new System.Drawing.Size(175, 21);
            this.BeginCapComboBox.TabIndex = 1;
            this.BeginCapComboBox.SelectedIndexChanged += new System.EventHandler(this.BeginCapComboBox_SelectedIndexChanged);
            // 
            // EndCapComboBox
            // 
            this.EndCapComboBox.Location = new System.Drawing.Point(12, 130);
            this.EndCapComboBox.Name = "EndCapComboBox";
            this.EndCapComboBox.Size = new System.Drawing.Size(175, 21);
            this.EndCapComboBox.TabIndex = 5;
            this.EndCapComboBox.SelectedIndexChanged += new System.EventHandler(this.EndCapComboBox_SelectedIndexChanged);
            // 
            // PaintOnScaleBreaks
            // 
            this.PaintOnScaleBreaks.AutoSize = true;
            this.PaintOnScaleBreaks.ButtonProperties.BorderOffset = 2;
            this.PaintOnScaleBreaks.Location = new System.Drawing.Point(12, 166);
            this.PaintOnScaleBreaks.Name = "PaintOnScaleBreaks";
            this.PaintOnScaleBreaks.Size = new System.Drawing.Size(131, 17);
            this.PaintOnScaleBreaks.TabIndex = 6;
            this.PaintOnScaleBreaks.Text = "Paint on Scale Breaks";
            this.PaintOnScaleBreaks.UseVisualStyleBackColor = true;
            this.PaintOnScaleBreaks.CheckedChanged += new System.EventHandler(this.PaintOnScaleBreaks_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Width:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Height:";
            // 
            // WidthNumericUpDown
            // 
            this.WidthNumericUpDown.Location = new System.Drawing.Point(92, 217);
            this.WidthNumericUpDown.Name = "WidthNumericUpDown";
            this.WidthNumericUpDown.Size = new System.Drawing.Size(95, 20);
            this.WidthNumericUpDown.TabIndex = 8;
            this.WidthNumericUpDown.ValueChanged += new System.EventHandler(this.WidthNumericUpDown_ValueChanged);
            // 
            // HeightNumericUpDown
            // 
            this.HeightNumericUpDown.Location = new System.Drawing.Point(92, 244);
            this.HeightNumericUpDown.Name = "HeightNumericUpDown";
            this.HeightNumericUpDown.Size = new System.Drawing.Size(95, 20);
            this.HeightNumericUpDown.TabIndex = 10;
            this.HeightNumericUpDown.ValueChanged += new System.EventHandler(this.HeightNumericUpDown_ValueChanged);
            // 
            // ScaleBreakCapComboBox
            // 
            this.ScaleBreakCapComboBox.Location = new System.Drawing.Point(12, 79);
            this.ScaleBreakCapComboBox.Name = "ScaleBreakCapComboBox";
            this.ScaleBreakCapComboBox.Size = new System.Drawing.Size(175, 21);
            this.ScaleBreakCapComboBox.TabIndex = 3;
            this.ScaleBreakCapComboBox.SelectedIndexChanged += new System.EventHandler(this.ScaleBreakCapStyleComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Scale Break Cap Style:";
            // 
            // NRulerCapsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScaleBreakCapComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HeightNumericUpDown);
            this.Controls.Add(this.WidthNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PaintOnScaleBreaks);
            this.Controls.Add(this.EndCapComboBox);
            this.Controls.Add(this.BeginCapComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NRulerCapsUC";
            this.Size = new System.Drawing.Size(203, 288);
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public override void Initialize()
        {
            base.Initialize();

			nChartControl1.Panels.Clear();

            // set a chart title
            NLabel title = new NLabel("Axis Ruler Caps<br/> <font size = '9pt'>Demonstrates how to change the caps of the axis ruler</font>");
			title.DockMode = PanelDockMode.Top;
			title.Margins = new NMarginsL(10, 10, 10, 10);
            title.TextStyle.TextFormat = TextFormat.XML;
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.FitAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			nChartControl1.Panels.Add(title);

			NCartesianChart chart = new NCartesianChart();
			chart.DockMode = PanelDockMode.Fill;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Margins = new NMarginsL(10, 0, 20, 10);
			nChartControl1.Panels.Add(chart);

            Random random = new Random();

            // feed some random data 
            NPointSeries point = new NPointSeries();
            point.DataLabelStyle.Visible = false;
            point.UseXValues = true;
            point.Size = new NLength(5);
            point.BorderStyle.Width = new NLength(0);

            // fill in some random data
            for (int j = 0; j < 30; j++)
            {
                point.Values.Add(5 + random.Next(90));
                point.XValues.Add(5 + random.Next(90));
            }

            chart.Series.Add(point);

            // configure scales
            NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
            xScale.RoundToTickMax = true;
            xScale.RoundToTickMin = true;
            xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			xScale.ScaleBreaks.Add(new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Orange)), null, new NLength(10)), new NRange1DD(29, 41)));

            // add an interlaced strip to the X axis
            NScaleStripStyle xInterlacedStrip = new NScaleStripStyle();
            xInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
            xInterlacedStrip.Interlaced = true;
            xInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
            xScale.StripStyles.Add(xInterlacedStrip);

			NCartesianAxis xAxis = (NCartesianAxis)chart.Axis(StandardAxis.PrimaryX);
            xAxis.ScaleConfigurator = xScale;
			xAxis.View = new NRangeAxisView(new NRange1DD(0, 100));

			NDockAxisAnchor xAxisAnchor = new NDockAxisAnchor(AxisDockZone.FrontBottom);
			xAxisAnchor.BeforeSpace = new NLength(10);
			xAxis.Anchor = xAxisAnchor;

            NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();
            yScale.RoundToTickMax = true;
            yScale.RoundToTickMin = true;
            yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			yScale.ScaleBreaks.Add(new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Orange)), null, new NLength(10)), new NRange1DD(29, 41)));

            // add an interlaced strip to the Y axis
            NScaleStripStyle yInterlacedStrip = new NScaleStripStyle();
            yInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
            yInterlacedStrip.Interlaced = true;
            yInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
            yScale.StripStyles.Add(yInterlacedStrip);

			NCartesianAxis yAxis = (NCartesianAxis)chart.Axis(StandardAxis.PrimaryY);
			yAxis.ScaleConfigurator = yScale;
			yAxis.View = new NRangeAxisView(new NRange1DD(0, 100));

			NDockAxisAnchor yAxisAnchor = new NDockAxisAnchor(AxisDockZone.FrontLeft);
			yAxisAnchor.BeforeSpace = new NLength(10);
			yAxis.Anchor = yAxisAnchor;

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);

            // Init form controls
            BeginCapComboBox.FillFromEnum(typeof(CapStyle));
            EndCapComboBox.FillFromEnum(typeof(CapStyle));
            ScaleBreakCapComboBox.FillFromEnum(typeof(CapStyle));

            BeginCapComboBox.SelectedIndex = (int)CapStyle.Ellipse;
            EndCapComboBox.SelectedIndex = (int)CapStyle.Arrow;
            ScaleBreakCapComboBox.SelectedIndex = (int)CapStyle.LeftCrossLine;
            WidthNumericUpDown.Value = (decimal)5;
            HeightNumericUpDown.Value = (decimal)5;
        }

        private void UpdateRulerStyles()
        {
            NChart chart = nChartControl1.Charts[0];

            UpdateRulerStyleForAxis(chart.Axis(StandardAxis.PrimaryX));
            UpdateRulerStyleForAxis(chart.Axis(StandardAxis.PrimaryY));

            nChartControl1.Refresh();
        }

        private void UpdateRulerStyleForAxis(NAxis axis)
        {
            NStandardScaleConfigurator scale = (NStandardScaleConfigurator)axis.ScaleConfigurator;

            // apply style to begin and end caps
            scale.RulerStyle.BeginCapStyle.Style = (CapStyle)BeginCapComboBox.SelectedIndex;
            scale.RulerStyle.EndCapStyle.Style = (CapStyle)EndCapComboBox.SelectedIndex;
            scale.RulerStyle.ScaleBreakCapStyle.Style = (CapStyle)ScaleBreakCapComboBox.SelectedIndex;
            scale.RulerStyle.PaintOnScaleBreaks = PaintOnScaleBreaks.Checked;

            // apply cap style sizes
            NSizeL capSize = new NSizeL((float)WidthNumericUpDown.Value, (float)HeightNumericUpDown.Value);
            scale.RulerStyle.BeginCapStyle.Size = capSize;
            scale.RulerStyle.EndCapStyle.Size = capSize;
            scale.RulerStyle.ScaleBreakCapStyle.Size = capSize;
        }

        private void BeginCapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRulerStyles();
        }

        private void EndCapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRulerStyles();
        }

        private void WidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateRulerStyles();
        }

        private void HeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateRulerStyles();
        }

        private void PaintOnScaleBreaks_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRulerStyles();
        }

        private void ScaleBreakCapStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRulerStyles();
        }
    }
}
