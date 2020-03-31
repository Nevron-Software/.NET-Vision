using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
    public class NCustomScaleBreaksUC : NExampleBaseUC
    {
        private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Nevron.UI.WinForm.Controls.NNumericUpDown FirstHorzBreakEndUpDown;
        private Nevron.UI.WinForm.Controls.NNumericUpDown FirstHorzBreakBeginUpDown;
        private Nevron.UI.WinForm.Controls.NGroupBox groupBox2;
        private Label label3;
        private Label label4;
        private Nevron.UI.WinForm.Controls.NNumericUpDown SecondHorzBreakEndUpDown;
        private Nevron.UI.WinForm.Controls.NNumericUpDown SecondHorzBreakBeginUpDown;
        private Nevron.UI.WinForm.Controls.NGroupBox groupBox3;
        private Label label5;
        private Label label6;
        private Nevron.UI.WinForm.Controls.NNumericUpDown FirstVertBreakEndUpDown;
        private Nevron.UI.WinForm.Controls.NNumericUpDown FirstVertBreakBeginUpDown;
        private Nevron.UI.WinForm.Controls.NGroupBox groupBox4;
        private Label label7;
        private Label label8;
        private Nevron.UI.WinForm.Controls.NNumericUpDown SecondVertBreakEndUpDown;
        private Nevron.UI.WinForm.Controls.NNumericUpDown SecondVertBreakBeginUpDown;

        private NCustomScaleBreak m_FirstHorzScaleBreak;
        private NCustomScaleBreak m_SecondHorzScaleBreak;
        private NCustomScaleBreak m_FirstVertScaleBreak;
        private NCustomScaleBreak m_SecondVertScaleBreak;

        public NCustomScaleBreaksUC()
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
            this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FirstHorzBreakEndUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.FirstHorzBreakBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.groupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SecondHorzBreakEndUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.SecondHorzBreakBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.groupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FirstVertBreakEndUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.FirstVertBreakBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.groupBox4 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SecondVertBreakEndUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.SecondVertBreakBeginUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstHorzBreakEndUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstHorzBreakBeginUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondHorzBreakEndUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondHorzBreakBeginUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstVertBreakEndUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstVertBreakBeginUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondVertBreakEndUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondVertBreakBeginUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FirstHorzBreakEndUpDown);
            this.groupBox1.Controls.Add(this.FirstHorzBreakBeginUpDown);
            this.groupBox1.Location = new System.Drawing.Point(10, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "First Horizontal Scale Break";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Begin:";
            // 
            // FirstHorzBreakEndUpDown
            // 
            this.FirstHorzBreakEndUpDown.Location = new System.Drawing.Point(74, 52);
            this.FirstHorzBreakEndUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.FirstHorzBreakEndUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.FirstHorzBreakEndUpDown.Name = "FirstHorzBreakEndUpDown";
            this.FirstHorzBreakEndUpDown.Size = new System.Drawing.Size(90, 20);
            this.FirstHorzBreakEndUpDown.TabIndex = 3;
            this.FirstHorzBreakEndUpDown.ValueChanged += new System.EventHandler(this.FirstHorzBreakEndUpDown_ValueChanged);
            // 
            // FirstHorzBreakBeginUpDown
            // 
            this.FirstHorzBreakBeginUpDown.Location = new System.Drawing.Point(74, 25);
            this.FirstHorzBreakBeginUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.FirstHorzBreakBeginUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.FirstHorzBreakBeginUpDown.Name = "FirstHorzBreakBeginUpDown";
            this.FirstHorzBreakBeginUpDown.Size = new System.Drawing.Size(90, 20);
            this.FirstHorzBreakBeginUpDown.TabIndex = 1;
            this.FirstHorzBreakBeginUpDown.ValueChanged += new System.EventHandler(this.FirstHorzBreakBeginUpDown_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.SecondHorzBreakEndUpDown);
            this.groupBox2.Controls.Add(this.SecondHorzBreakBeginUpDown);
            this.groupBox2.Location = new System.Drawing.Point(10, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 84);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Second Horizontal Scale Break";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "End:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Begin:";
            // 
            // SecondHorzBreakEndUpDown
            // 
            this.SecondHorzBreakEndUpDown.Location = new System.Drawing.Point(74, 55);
            this.SecondHorzBreakEndUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SecondHorzBreakEndUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.SecondHorzBreakEndUpDown.Name = "SecondHorzBreakEndUpDown";
            this.SecondHorzBreakEndUpDown.Size = new System.Drawing.Size(90, 20);
            this.SecondHorzBreakEndUpDown.TabIndex = 3;
            this.SecondHorzBreakEndUpDown.ValueChanged += new System.EventHandler(this.SecondHorzBreakEndUpDown_ValueChanged);
            // 
            // SecondHorzBreakBeginUpDown
            // 
            this.SecondHorzBreakBeginUpDown.Location = new System.Drawing.Point(74, 28);
            this.SecondHorzBreakBeginUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SecondHorzBreakBeginUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.SecondHorzBreakBeginUpDown.Name = "SecondHorzBreakBeginUpDown";
            this.SecondHorzBreakBeginUpDown.Size = new System.Drawing.Size(90, 20);
            this.SecondHorzBreakBeginUpDown.TabIndex = 1;
            this.SecondHorzBreakBeginUpDown.ValueChanged += new System.EventHandler(this.SecondHorzBreakBeginUpDown_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.FirstVertBreakEndUpDown);
            this.groupBox3.Controls.Add(this.FirstVertBreakBeginUpDown);
            this.groupBox3.Location = new System.Drawing.Point(10, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 84);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "First Vertical Scale Break";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "End:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Begin:";
            // 
            // FirstVertBreakEndUpDown
            // 
            this.FirstVertBreakEndUpDown.Location = new System.Drawing.Point(74, 55);
            this.FirstVertBreakEndUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.FirstVertBreakEndUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.FirstVertBreakEndUpDown.Name = "FirstVertBreakEndUpDown";
            this.FirstVertBreakEndUpDown.Size = new System.Drawing.Size(90, 20);
            this.FirstVertBreakEndUpDown.TabIndex = 3;
            this.FirstVertBreakEndUpDown.ValueChanged += new System.EventHandler(this.FirstVertBreakEndUpDown_ValueChanged);
            // 
            // FirstVertBreakBeginUpDown
            // 
            this.FirstVertBreakBeginUpDown.Location = new System.Drawing.Point(74, 28);
            this.FirstVertBreakBeginUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.FirstVertBreakBeginUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.FirstVertBreakBeginUpDown.Name = "FirstVertBreakBeginUpDown";
            this.FirstVertBreakBeginUpDown.Size = new System.Drawing.Size(90, 20);
            this.FirstVertBreakBeginUpDown.TabIndex = 1;
            this.FirstVertBreakBeginUpDown.ValueChanged += new System.EventHandler(this.FirstVertBreakBeginUpDown_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.SecondVertBreakEndUpDown);
            this.groupBox4.Controls.Add(this.SecondVertBreakBeginUpDown);
            this.groupBox4.Location = new System.Drawing.Point(10, 254);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 84);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Second Vertical Scale Break";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "End:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Begin:";
            // 
            // SecondVertBreakEndUpDown
            // 
            this.SecondVertBreakEndUpDown.Location = new System.Drawing.Point(74, 53);
            this.SecondVertBreakEndUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SecondVertBreakEndUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.SecondVertBreakEndUpDown.Name = "SecondVertBreakEndUpDown";
            this.SecondVertBreakEndUpDown.Size = new System.Drawing.Size(90, 20);
            this.SecondVertBreakEndUpDown.TabIndex = 3;
            this.SecondVertBreakEndUpDown.ValueChanged += new System.EventHandler(this.SecondVertBreakEndUpDown_ValueChanged);
            // 
            // SecondVertBreakBeginUpDown
            // 
            this.SecondVertBreakBeginUpDown.Location = new System.Drawing.Point(74, 26);
            this.SecondVertBreakBeginUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SecondVertBreakBeginUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.SecondVertBreakBeginUpDown.Name = "SecondVertBreakBeginUpDown";
            this.SecondVertBreakBeginUpDown.Size = new System.Drawing.Size(90, 20);
            this.SecondVertBreakBeginUpDown.TabIndex = 1;
            this.SecondVertBreakBeginUpDown.ValueChanged += new System.EventHandler(this.SecondVertBreakBeginUpDown_ValueChanged);
            // 
            // NCustomScaleBreaksUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NCustomScaleBreaksUC";
            this.Size = new System.Drawing.Size(193, 483);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstHorzBreakEndUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstHorzBreakBeginUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondHorzBreakEndUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondHorzBreakBeginUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstVertBreakEndUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstVertBreakBeginUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondVertBreakEndUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondVertBreakBeginUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public override void Initialize()
        {
            base.Initialize();

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Custom Scale Breaks<br/> <font size = '9pt'>Demonstrates how to apply custom scale breaks to the chart axes</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            NLegend legend = nChartControl1.Legends[0];
            legend.Mode = LegendMode.Disabled;

            NChart chart = nChartControl1.Charts[0];
            Random random = new Random();

            // create three random point series
            for (int i = 0; i < 3; i++)
            {
                NPointSeries point = new NPointSeries();
                point.UseXValues = true;
                point.UseZValues = true;
                point.DataLabelStyle.Visible = false;
                point.Size = new NLength(5);
                point.BorderStyle.Width = new NLength(0);

                // fill in some random data
                for (int j = 0; j < 30; j++)
                {
                    point.Values.Add(5 + random.Next(90));
                    point.XValues.Add(5 + random.Next(90));
                    point.ZValues.Add(5 + random.Next(90));
                }

                chart.Series.Add(point);
            }

            // create scale breaks
            m_FirstHorzScaleBreak = new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Orange)), null, new NLength(10)), new NRange1DD(10, 20));
            m_SecondHorzScaleBreak = new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Green)), null, new NLength(10)), new NRange1DD(80, 90));
            m_FirstVertScaleBreak = new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Red)), null, new NLength(10)), new NRange1DD(10, 20));
            m_SecondVertScaleBreak = new NCustomScaleBreak(new NLineScaleBreakStyle(new NColorFillStyle(Color.FromArgb(124, Color.Blue)), null, new NLength(10)), new NRange1DD(80, 90));

            // initalize form controls
            FirstHorzBreakBeginUpDown.Value = (decimal)10;
            FirstHorzBreakEndUpDown.Value = (decimal)20;
           
            SecondHorzBreakBeginUpDown.Value = (decimal)80;
            SecondHorzBreakEndUpDown.Value = (decimal)90;

            FirstVertBreakBeginUpDown.Value = (decimal)10;
            FirstVertBreakEndUpDown.Value = (decimal)20;

            SecondVertBreakBeginUpDown.Value = (decimal)80;
            SecondVertBreakEndUpDown.Value = (decimal)90;

            // configure scales
            NLinearScaleConfigurator xScale = new NLinearScaleConfigurator();
            xScale.RoundToTickMax = true;
            xScale.RoundToTickMin = true;
            xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            xScale.ScaleBreaks.Add(m_FirstHorzScaleBreak);
            xScale.ScaleBreaks.Add(m_SecondHorzScaleBreak);

            // add an interlaced strip to the X axis
            NScaleStripStyle xInterlacedStrip = new NScaleStripStyle();
            xInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
            xInterlacedStrip.Interlaced = true;
            xInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
            xScale.StripStyles.Add(xInterlacedStrip);
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale;
            chart.Axis(StandardAxis.PrimaryX).View = new NRangeAxisView(new NRange1DD(0, 100));

            NLinearScaleConfigurator yScale = new NLinearScaleConfigurator();
            yScale.RoundToTickMax = true;
            yScale.RoundToTickMin = true;
            yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            yScale.ScaleBreaks.Add(m_FirstVertScaleBreak);
            yScale.ScaleBreaks.Add(m_SecondVertScaleBreak);

            // add an interlaced strip to the Y axis
            NScaleStripStyle yInterlacedStrip = new NScaleStripStyle();
            yInterlacedStrip.SetShowAtWall(ChartWallType.Back, true);
            yInterlacedStrip.Interlaced = true;
            yInterlacedStrip.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.LightGray));
            yScale.StripStyles.Add(yInterlacedStrip);
            chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale;
            chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 100));

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
            styleSheet.Apply(nChartControl1.Document);
        }

        private NScaleBreakStyle CreateScaleBreakStyle(Color color)
        {
            NWaveScaleBreakStyle style = new NWaveScaleBreakStyle();
            style.VertStep = new NLength(20);
            style.FillStyle = new NColorFillStyle(color);
            return style;
        }

        private void UpdateScaleBreaks()
        {
            m_FirstHorzScaleBreak.Range = new NRange1DD((double)FirstHorzBreakBeginUpDown.Value, (double)FirstHorzBreakEndUpDown.Value);
            m_SecondHorzScaleBreak.Range = new NRange1DD((double)SecondHorzBreakBeginUpDown.Value, (double)SecondHorzBreakEndUpDown.Value);
            m_FirstVertScaleBreak.Range = new NRange1DD((double)FirstVertBreakBeginUpDown.Value, (double)FirstVertBreakEndUpDown.Value);
            m_SecondVertScaleBreak.Range = new NRange1DD((double)SecondVertBreakBeginUpDown.Value, (double)SecondVertBreakEndUpDown.Value);

            nChartControl1.Refresh();
        }

        private void FirstHorzBreakBeginUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreaks();
        }

        private void FirstHorzBreakEndUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreaks();
        }

        private void SecondHorzBreakBeginUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreaks();
        }

        private void SecondHorzBreakEndUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreaks();
        }

        private void FirstVertBreakBeginUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreaks();
        }

        private void FirstVertBreakEndUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreaks();
        }

        private void SecondVertBreakBeginUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreaks();
        }

        private void SecondVertBreakEndUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreaks();
        }
    }
}
