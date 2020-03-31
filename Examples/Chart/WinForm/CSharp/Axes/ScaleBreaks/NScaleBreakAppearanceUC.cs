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
    public class NScaleBreakAppearanceUC : NExampleBaseUC
    {
        public NScaleBreakAppearanceUC()
        {
            InitializeComponent();
        }

        private Label label1;
        private Nevron.UI.WinForm.Controls.NComboBox ScaleBreakStyleComboBox;
        private Label label2;
        private Label label3;
        private Nevron.UI.WinForm.Controls.NNumericUpDown HorzStepNumericUpDown;
        private Nevron.UI.WinForm.Controls.NNumericUpDown VertStepNumericUpDown;
        private Nevron.UI.WinForm.Controls.NButton StrokeStyleButton;
        private Nevron.UI.WinForm.Controls.NComboBox PatternComboBox;
        private Label label4;
        private Nevron.UI.WinForm.Controls.NButton FillStyleButton;
        private Nevron.UI.WinForm.Controls.NNumericUpDown LengthUpDown;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;

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
            this.label1 = new System.Windows.Forms.Label();
            this.ScaleBreakStyleComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HorzStepNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.VertStepNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.StrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.PatternComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.LengthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HorzStepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VertStepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Style:";
            // 
            // ScaleBreakStyleComboBox
            // 
            this.ScaleBreakStyleComboBox.Location = new System.Drawing.Point(15, 35);
            this.ScaleBreakStyleComboBox.Name = "ScaleBreakStyleComboBox";
            this.ScaleBreakStyleComboBox.Size = new System.Drawing.Size(156, 21);
            this.ScaleBreakStyleComboBox.TabIndex = 1;
            this.ScaleBreakStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.ScaleBreakStyleComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Horz Step:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vert Step:";
            // 
            // HorzStepNumericUpDown
            // 
            this.HorzStepNumericUpDown.Location = new System.Drawing.Point(78, 120);
            this.HorzStepNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.HorzStepNumericUpDown.Name = "HorzStepNumericUpDown";
            this.HorzStepNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.HorzStepNumericUpDown.TabIndex = 5;
            this.HorzStepNumericUpDown.ValueChanged += new System.EventHandler(this.HorzStepNumericUpDown_ValueChanged);
            // 
            // VertStepNumericUpDown
            // 
            this.VertStepNumericUpDown.Location = new System.Drawing.Point(78, 147);
            this.VertStepNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.VertStepNumericUpDown.Name = "VertStepNumericUpDown";
            this.VertStepNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.VertStepNumericUpDown.TabIndex = 8;
            this.VertStepNumericUpDown.ValueChanged += new System.EventHandler(this.VertStepNumericUpDown_ValueChanged);
            // 
            // StrokeStyleButton
            // 
            this.StrokeStyleButton.Location = new System.Drawing.Point(18, 214);
            this.StrokeStyleButton.Name = "StrokeStyleButton";
            this.StrokeStyleButton.Size = new System.Drawing.Size(156, 23);
            this.StrokeStyleButton.TabIndex = 13;
            this.StrokeStyleButton.Text = "Stroke Style...";
            this.StrokeStyleButton.UseVisualStyleBackColor = true;
            this.StrokeStyleButton.Click += new System.EventHandler(this.StrokeStyleButton_Click);
            // 
            // PatternComboBox
            // 
            this.PatternComboBox.Location = new System.Drawing.Point(15, 91);
            this.PatternComboBox.Name = "PatternComboBox";
            this.PatternComboBox.Size = new System.Drawing.Size(156, 21);
            this.PatternComboBox.TabIndex = 3;
            this.PatternComboBox.SelectedIndexChanged += new System.EventHandler(this.PatternComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Pattern:";
            // 
            // FillStyleButton
            // 
            this.FillStyleButton.Location = new System.Drawing.Point(18, 243);
            this.FillStyleButton.Name = "FillStyleButton";
            this.FillStyleButton.Size = new System.Drawing.Size(156, 23);
            this.FillStyleButton.TabIndex = 14;
            this.FillStyleButton.Text = "Fill Style...";
            this.FillStyleButton.UseVisualStyleBackColor = true;
            this.FillStyleButton.Click += new System.EventHandler(this.FillStyleButton_Click);
            // 
            // LengthUpDown
            // 
            this.LengthUpDown.Location = new System.Drawing.Point(78, 173);
            this.LengthUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.LengthUpDown.Name = "LengthUpDown";
            this.LengthUpDown.Size = new System.Drawing.Size(68, 20);
            this.LengthUpDown.TabIndex = 11;
            this.LengthUpDown.ValueChanged += new System.EventHandler(this.LengthUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Length:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "pt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "pt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "pt";
            // 
            // NScaleBreakAppearanceUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LengthUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FillStyleButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PatternComboBox);
            this.Controls.Add(this.StrokeStyleButton);
            this.Controls.Add(this.VertStepNumericUpDown);
            this.Controls.Add(this.HorzStepNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ScaleBreakStyleComboBox);
            this.Controls.Add(this.label1);
            this.Name = "NScaleBreakAppearanceUC";
            this.Size = new System.Drawing.Size(186, 325);
            ((System.ComponentModel.ISupportInitialize)(this.HorzStepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VertStepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public override void Initialize()
        {
            base.Initialize();
            
            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Scale Break Appearance<br/> <font size = '9pt'>Demonstrates how to change the scale break appearance</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            NLegend legend = nChartControl1.Legends[0];
            legend.Mode = LegendMode.Disabled;

            NChart chart = nChartControl1.Charts[0];
            chart.Wall(ChartWallType.Back).FillStyle = new NGradientFillStyle(Color.White, Color.DarkGray);

            // configure scale
            NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
            linearScale.RoundToTickMax = true;
            linearScale.RoundToTickMin = true;
            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            linearScale.MinTickDistance = new NLength(15);

            // add an interlaced strip to the Y axis
            NScaleStripStyle interlacedStrip = new NScaleStripStyle();
            interlacedStrip.SetShowAtWall(ChartWallType.Back, true);
            interlacedStrip.Interlaced = true;
            interlacedStrip.FillStyle = new NColorFillStyle(Color.Beige);
            linearScale.StripStyles.Add(interlacedStrip);

            // Create some data with a peak in it
            NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.DataLabelStyle.Visible = false;

            // fill in some data so that it contains several peaks of data
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                bar.Values.Add(random.Next(30));
            }

            for (int i = 0; i < 5; i++)
            {
                bar.Values.Add(300 + random.Next(50));
            }

            for (int i = 0; i < 8; i++)
            {
                bar.Values.Add(random.Next(30));
            }

            nChartControl1.Refresh();

            // update form controls
            PatternComboBox.FillFromEnum(typeof(ScaleBreakPattern));
            PatternComboBox.SelectedIndex = 0;

            ScaleBreakStyleComboBox.Items.Add("Line");
            ScaleBreakStyleComboBox.Items.Add("Wave");
            ScaleBreakStyleComboBox.Items.Add("ZigZag");
            ScaleBreakStyleComboBox.SelectedIndex = 1; // use wave by default

            HorzStepNumericUpDown.Value = 20;
            VertStepNumericUpDown.Value = 3;
            LengthUpDown.Value = 10;
        }

        private void UpdateScaleBreak()
        {
            NChart chart = nChartControl1.Charts[0];
            NLinearScaleConfigurator scale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleBreakStyle oldScaleBreakStyle = null;
            if (scale.ScaleBreaks.Count > 0)
            {
                oldScaleBreakStyle = ((NScaleBreak)scale.ScaleBreaks[0]).Style;
            }
            scale.ScaleBreaks.Clear();

            NScaleBreakStyle newScaleBreakStyle = null;

            switch (ScaleBreakStyleComboBox.SelectedIndex)
            {
                case 0: // Line
                    newScaleBreakStyle = new NLineScaleBreakStyle();
                    break;
                case 1: // Waves
                    newScaleBreakStyle = new NWaveScaleBreakStyle();
                    break;
                case 2: // ZigZag
                    newScaleBreakStyle = new NZigZagScaleBreakStyle();
                    break;
            }

            // try to preserve fill and stroke settings
            if (newScaleBreakStyle != null)
            {
                if (oldScaleBreakStyle != null)
                {
                    newScaleBreakStyle.InitFrom(oldScaleBreakStyle);
                }
                else
                {
                    newScaleBreakStyle.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.LightGray, Color.White);
                }

                // update the length of the scale break
                newScaleBreakStyle.Length = new NLength((float)LengthUpDown.Value, NGraphicsUnit.Point);

                // update paramers relevant to pattern scale break appearance
                NPatternScaleBreakStyle patternScaleBreakStyle = newScaleBreakStyle as NPatternScaleBreakStyle;
                bool enablePatternControls = patternScaleBreakStyle != null;
                if (patternScaleBreakStyle != null)
                {
                    patternScaleBreakStyle.HorzStep = new NLength((float)HorzStepNumericUpDown.Value);
                    patternScaleBreakStyle.VertStep = new NLength((float)VertStepNumericUpDown.Value);
                    patternScaleBreakStyle.Pattern = (ScaleBreakPattern)PatternComboBox.SelectedIndex;
                }

                HorzStepNumericUpDown.Enabled = enablePatternControls;
                VertStepNumericUpDown.Enabled = enablePatternControls;
                PatternComboBox.Enabled = enablePatternControls;

                scale.ScaleBreaks.Add(new NAutoScaleBreak(newScaleBreakStyle, 0.4f));
            }

            nChartControl1.Refresh();
        }

        private void ScaleBreakStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();
        }

        private void HorzStepNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();
        }

        private void VertStepNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();
        }

        private void PatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();
        }

        private void LengthUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();
        }

        private void StrokeStyleButton_Click(object sender, EventArgs e)
        {
            NChart chart = nChartControl1.Charts[0];
            NLinearScaleConfigurator scale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleBreak scaleBreak = (NScaleBreak)scale.ScaleBreaks[0];

            NStrokeStyle result = null;
            if (NStrokeStyleTypeEditor.Edit(scaleBreak.Style.StrokeStyle, out result))
            {
                scaleBreak.Style.StrokeStyle = result;
                nChartControl1.Refresh();
            }
        }

        private void FillStyleButton_Click(object sender, EventArgs e)
        {
            NChart chart = nChartControl1.Charts[0];
            NLinearScaleConfigurator scale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
            NScaleBreak scaleBreak = (NScaleBreak)scale.ScaleBreaks[0];

            NFillStyle result = null;
            if (NFillStyleTypeEditor.Edit(scaleBreak.Style.FillStyle, out result))
            {
                scaleBreak.Style.FillStyle = result;
                nChartControl1.Refresh();
            }
        }
    }
}
