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
    public class NAutomaticScaleBreaksUC : NExampleBaseUC
    {
        private Nevron.UI.WinForm.Controls.NComboBox PositionModeComboBox;
        private Label label6;
        private Nevron.UI.WinForm.Controls.NNumericUpDown LengthUpDown;
        private Label label7;
        private Nevron.UI.WinForm.Controls.NNumericUpDown ThresholdUpDown;
        private Nevron.UI.WinForm.Controls.NCheckBox EnableScaleBreaksCheckBox;
        private Label label1;
        private Label label2;
        private Nevron.UI.WinForm.Controls.NNumericUpDown MaxBreaksUpDown;
        private Label label3;
        private Nevron.UI.WinForm.Controls.NNumericUpDown PositionPercentUpDown;
        private Nevron.UI.WinForm.Controls.NButton ChangeDataButton;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NAutomaticScaleBreaksUC()
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
            this.PositionModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LengthUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.ThresholdUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.EnableScaleBreaksCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxBreaksUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.PositionPercentUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.ChangeDataButton = new Nevron.UI.WinForm.Controls.NButton();
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBreaksUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PositionPercentUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PositionModeComboBox
            // 
            this.PositionModeComboBox.Location = new System.Drawing.Point(15, 162);
            this.PositionModeComboBox.Name = "PositionModeComboBox";
            this.PositionModeComboBox.Size = new System.Drawing.Size(169, 21);
            this.PositionModeComboBox.TabIndex = 8;
            this.PositionModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PositionModeComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Length:";
            // 
            // LengthUpDown
            // 
            this.LengthUpDown.Location = new System.Drawing.Point(118, 82);
            this.LengthUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LengthUpDown.Name = "LengthUpDown";
            this.LengthUpDown.Size = new System.Drawing.Size(66, 20);
            this.LengthUpDown.TabIndex = 4;
            this.LengthUpDown.ValueChanged += new System.EventHandler(this.LengthUpDown_ValueChanged);
            // 
            // ThresholdUpDown
            // 
            this.ThresholdUpDown.Cursor = System.Windows.Forms.Cursors.Default;
            this.ThresholdUpDown.DecimalPlaces = 2;
            this.ThresholdUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.ThresholdUpDown.Location = new System.Drawing.Point(118, 57);
            this.ThresholdUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThresholdUpDown.Name = "ThresholdUpDown";
            this.ThresholdUpDown.Size = new System.Drawing.Size(66, 20);
            this.ThresholdUpDown.TabIndex = 2;
            this.ThresholdUpDown.ValueChanged += new System.EventHandler(this.ThresholdUpDown_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Threshold:";
            // 
            // EnableScaleBreaksCheckBox
            // 
            this.EnableScaleBreaksCheckBox.AutoSize = true;
            this.EnableScaleBreaksCheckBox.Location = new System.Drawing.Point(15, 26);
            this.EnableScaleBreaksCheckBox.Name = "EnableScaleBreaksCheckBox";
            this.EnableScaleBreaksCheckBox.Size = new System.Drawing.Size(175, 17);
            this.EnableScaleBreaksCheckBox.TabIndex = 0;
            this.EnableScaleBreaksCheckBox.Text = "Enable Automatic Scale Breaks";
            this.EnableScaleBreaksCheckBox.UseVisualStyleBackColor = true;
            this.EnableScaleBreaksCheckBox.CheckedChanged += new System.EventHandler(this.EnableScaleBreaksCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Position Mode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max Breaks:";
            // 
            // MaxBreaksUpDown
            // 
            this.MaxBreaksUpDown.Location = new System.Drawing.Point(118, 107);
            this.MaxBreaksUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.MaxBreaksUpDown.Name = "MaxBreaksUpDown";
            this.MaxBreaksUpDown.Size = new System.Drawing.Size(66, 20);
            this.MaxBreaksUpDown.TabIndex = 6;
            this.MaxBreaksUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxBreaksUpDown.ValueChanged += new System.EventHandler(this.MaxBreaksUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Position percent:";
            // 
            // PositionPercentUpDown
            // 
            this.PositionPercentUpDown.Location = new System.Drawing.Point(118, 188);
            this.PositionPercentUpDown.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.PositionPercentUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PositionPercentUpDown.Name = "PositionPercentUpDown";
            this.PositionPercentUpDown.Size = new System.Drawing.Size(66, 20);
            this.PositionPercentUpDown.TabIndex = 10;
            this.PositionPercentUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PositionPercentUpDown.ValueChanged += new System.EventHandler(this.PositionPercentUpDown_ValueChanged);
            // 
            // ChangeDataButton
            // 
            this.ChangeDataButton.Location = new System.Drawing.Point(18, 266);
            this.ChangeDataButton.Name = "ChangeDataButton";
            this.ChangeDataButton.Size = new System.Drawing.Size(166, 23);
            this.ChangeDataButton.TabIndex = 11;
            this.ChangeDataButton.Text = "Change Data";
            this.ChangeDataButton.UseVisualStyleBackColor = true;
            this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
            // 
            // NAutomaticScaleBreaksUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChangeDataButton);
            this.Controls.Add(this.PositionPercentUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MaxBreaksUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PositionModeComboBox);
            this.Controls.Add(this.EnableScaleBreaksCheckBox);
            this.Controls.Add(this.LengthUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ThresholdUpDown);
            this.Controls.Add(this.label7);
            this.Name = "NAutomaticScaleBreaksUC";
            this.Size = new System.Drawing.Size(203, 732);
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBreaksUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PositionPercentUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public override void Initialize()
        {
            base.Initialize();

            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Automatic Scale Breaks<br/> <font size = '9pt'>Demonstrates how to apply automatic scale breaks to the chart axes</font>");
			title.TextStyle.TextFormat = TextFormat.XML;
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // turn off the legend
            NLegend legend = nChartControl1.Legends[0];
            legend.Mode = LegendMode.Disabled;

            NChart chart = nChartControl1.Charts[0];

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

            // update form controls
            EnableScaleBreaksCheckBox.Checked = true;
            LengthUpDown.Value = 5;
            ThresholdUpDown.Value = (decimal)0.25; // this is relatively low factor
            MaxBreaksUpDown.Value = (decimal)1;
            PositionPercentUpDown.Value = (decimal)50;

            PositionModeComboBox.Items.Add("Range");
            PositionModeComboBox.Items.Add("Percent");
            PositionModeComboBox.Items.Add("Content");
            PositionModeComboBox.SelectedIndex = 2; // use content mode by default

            // feed some random data
            ChangeDataButton_Click(null, null);
        }

        private void UpdateScaleBreak()
        {
            if (nChartControl1 == null)
                return;

            NChart chart = nChartControl1.Charts[0];
            NStandardScaleConfigurator scale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NStandardScaleConfigurator;
            scale.ScaleBreaks.Clear();

            if (EnableScaleBreaksCheckBox.Checked)
            {
                NAutoScaleBreak scaleBreak = new NAutoScaleBreak((float)ThresholdUpDown.Value);
                scaleBreak.Style = new NLineScaleBreakStyle();
                scaleBreak.Style.Length = new NLength((float)LengthUpDown.Value, NGraphicsUnit.Point);
                scaleBreak.MaxScaleBreakCount = (int)MaxBreaksUpDown.Value;

                NScaleBreakPosition scaleBreakPosition = new NRangeScaleBreakPosition();
                switch (PositionModeComboBox.SelectedIndex)
                {
                    case 0: // Range
                        scaleBreakPosition = new NRangeScaleBreakPosition();
                        break;
                    case 1: // percent
                        scaleBreakPosition = new NPercentScaleBreakPosition((float)PositionPercentUpDown.Value);
                        break;
                    case 2: // content
                        scaleBreakPosition = new NContentScaleBreakPosition();
                        break;
                }

                scaleBreak.Position = scaleBreakPosition;
                scale.ScaleBreaks.Add(scaleBreak);
            }

            nChartControl1.Refresh();
        }


        private void EnableScaleBreaksCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();

            bool enableControls = EnableScaleBreaksCheckBox.Checked;
            ThresholdUpDown.Enabled = enableControls;
            LengthUpDown.Enabled = enableControls;
            MaxBreaksUpDown.Enabled = enableControls;
            PositionModeComboBox.Enabled = enableControls;
            PositionPercentUpDown.Enabled = enableControls && PositionModeComboBox.SelectedIndex == 1;
        }

        private void ThresholdUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();
        }

        private void LengthUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();
        }

        private void MaxBreaksUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();
        }

        private void PositionModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();

            PositionPercentUpDown.Enabled = PositionModeComboBox.SelectedIndex == 1;
        }

        private void PositionPercentUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateScaleBreak();
        }

        private void ChangeDataButton_Click(object sender, EventArgs e)
        {
            NChart chart = nChartControl1.Charts[0];

            chart.Series.Clear();

            // setup bar series
            NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
            bar.DataLabelStyle.Visible = false;
            bar.BorderStyle.Width = new NLength(1.5f);
            bar.BorderStyle.Color = Color.DarkGreen;

            // fill in some data so that it contains several peaks of data
            Random random = new Random();
            double value = 0;

            for (int i = 0; i < 25; i++)
            {
                if (i < 6)
                {
                    value = 600 + random.Next(30);
                }
                else if (i < 11)
                {
                    value = 200 + random.Next(50);
                }
                else if (i < 16)
                {
                    value = 400 + random.Next(50);
                }
                else if (i < 21)
                {
                    value = random.Next(30);
                }
                else
                {
                    value = random.Next(50);
                }

                bar.Values.Add(value);
                bar.FillStyles[i] = new NGradientFillStyle(ColorFromValue(value), Color.DarkSlateBlue);
            }

            nChartControl1.Refresh();
        }

        private Color ColorFromValue(double value)
        {
            Color beginColor = Color.LightBlue;
            Color endColor = Color.DarkSlateBlue;

            float factor = (float)(value / 650.0f);
            float oneMinusFactor = 1.0f - factor;

            return Color.FromArgb((byte)((float)beginColor.R * factor + (float)endColor.R * oneMinusFactor),
                                    (byte)((float)beginColor.G * factor + (float)endColor.G * oneMinusFactor),
                                    (byte)((float)beginColor.B * factor + (float)endColor.B * oneMinusFactor));
        }
    }
}

