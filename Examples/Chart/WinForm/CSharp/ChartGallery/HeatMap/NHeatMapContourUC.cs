using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.Editors;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public partial class NHeatMapContourUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

		NHeatMapSeries m_HeatMap;

        private UI.WinForm.Controls.NNumericUpDown OriginXUpDown;
        private Label label9;
        private UI.WinForm.Controls.NNumericUpDown OriginYUpDown;
        private Label label1;
        private UI.WinForm.Controls.NNumericUpDown StepXUpDown;
        private Label label2;
        private UI.WinForm.Controls.NNumericUpDown StepYUpDown;
        private Label label3;
        private UI.WinForm.Controls.NComboBox ContourDisplayModeCombo;
        private Label label4;
        private UI.WinForm.Controls.NComboBox ContourColorModeCombo;
        private Label label5;
        private UI.WinForm.Controls.NCheckBox ShowFillCheckBox;
        private UI.WinForm.Controls.NCheckBox SmoothPaletteCheckBox;
        private UI.WinForm.Controls.NCheckBox InterpolateImageCheckBox;
        private UI.WinForm.Controls.NComboBox GridDisplayModeComboBox;
        private Label label6;
        private UI.WinForm.Controls.NButton ContourStrokeStyleButton;
        private UI.WinForm.Controls.NNumericUpDown ContourDotSizeNumericUpDown;
        private Label label7;
        private UI.WinForm.Controls.NNumericUpDown GridDotSizeNumericUpDown;
        private Label label8;
        private UI.WinForm.Controls.NButton GridStrokeStyleButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;

        public NHeatMapContourUC()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}

			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		private void InitializeComponent()
		{
            this.OriginXUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.OriginYUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.StepXUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.StepYUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ContourDisplayModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ContourColorModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ShowFillCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SmoothPaletteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.InterpolateImageCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.GridDisplayModeComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ContourStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.ContourDotSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.GridDotSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.GridStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.OriginXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepXUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepYUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContourDotSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDotSizeNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginXUpDown
            // 
            this.OriginXUpDown.Location = new System.Drawing.Point(93, 16);
            this.OriginXUpDown.Name = "OriginXUpDown";
            this.OriginXUpDown.Size = new System.Drawing.Size(72, 20);
            this.OriginXUpDown.TabIndex = 1;
            this.OriginXUpDown.ValueChanged += new System.EventHandler(this.OriginXUpDown_ValueChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Origin X:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OriginYUpDown
            // 
            this.OriginYUpDown.Location = new System.Drawing.Point(93, 42);
            this.OriginYUpDown.Name = "OriginYUpDown";
            this.OriginYUpDown.Size = new System.Drawing.Size(72, 20);
            this.OriginYUpDown.TabIndex = 3;
            this.OriginYUpDown.ValueChanged += new System.EventHandler(this.OriginYUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Origin Y:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StepXUpDown
            // 
            this.StepXUpDown.Location = new System.Drawing.Point(93, 68);
            this.StepXUpDown.Name = "StepXUpDown";
            this.StepXUpDown.Size = new System.Drawing.Size(72, 20);
            this.StepXUpDown.TabIndex = 5;
            this.StepXUpDown.ValueChanged += new System.EventHandler(this.StepXUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Step X:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StepYUpDown
            // 
            this.StepYUpDown.Location = new System.Drawing.Point(93, 94);
            this.StepYUpDown.Name = "StepYUpDown";
            this.StepYUpDown.Size = new System.Drawing.Size(72, 20);
            this.StepYUpDown.TabIndex = 7;
            this.StepYUpDown.ValueChanged += new System.EventHandler(this.StepYUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Step Y:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ContourDisplayModeCombo
            // 
            this.ContourDisplayModeCombo.ListProperties.CheckBoxDataMember = "";
            this.ContourDisplayModeCombo.ListProperties.DataSource = null;
            this.ContourDisplayModeCombo.ListProperties.DisplayMember = "";
            this.ContourDisplayModeCombo.Location = new System.Drawing.Point(6, 32);
            this.ContourDisplayModeCombo.Name = "ContourDisplayModeCombo";
            this.ContourDisplayModeCombo.Size = new System.Drawing.Size(159, 21);
            this.ContourDisplayModeCombo.TabIndex = 9;
            this.ContourDisplayModeCombo.SelectedIndexChanged += new System.EventHandler(this.ContourDisplayModeCombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Contour Display Mode:";
            // 
            // ContourColorModeCombo
            // 
            this.ContourColorModeCombo.ListProperties.CheckBoxDataMember = "";
            this.ContourColorModeCombo.ListProperties.DataSource = null;
            this.ContourColorModeCombo.ListProperties.DisplayMember = "";
            this.ContourColorModeCombo.Location = new System.Drawing.Point(6, 70);
            this.ContourColorModeCombo.Name = "ContourColorModeCombo";
            this.ContourColorModeCombo.Size = new System.Drawing.Size(159, 21);
            this.ContourColorModeCombo.TabIndex = 11;
            this.ContourColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.ContourColorModeCombo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Contour Color Mode:";
            // 
            // ShowFillCheckBox
            // 
            this.ShowFillCheckBox.ButtonProperties.BorderOffset = 2;
            this.ShowFillCheckBox.Location = new System.Drawing.Point(6, 437);
            this.ShowFillCheckBox.Name = "ShowFillCheckBox";
            this.ShowFillCheckBox.Size = new System.Drawing.Size(150, 24);
            this.ShowFillCheckBox.TabIndex = 12;
            this.ShowFillCheckBox.Text = "Show Fill";
            this.ShowFillCheckBox.CheckedChanged += new System.EventHandler(this.ShowFillCheckBox_CheckedChanged);
            // 
            // SmoothPaletteCheckBox
            // 
            this.SmoothPaletteCheckBox.ButtonProperties.BorderOffset = 2;
            this.SmoothPaletteCheckBox.Location = new System.Drawing.Point(6, 458);
            this.SmoothPaletteCheckBox.Name = "SmoothPaletteCheckBox";
            this.SmoothPaletteCheckBox.Size = new System.Drawing.Size(150, 24);
            this.SmoothPaletteCheckBox.TabIndex = 13;
            this.SmoothPaletteCheckBox.Text = "Smooth Palette";
            this.SmoothPaletteCheckBox.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheckBox_CheckedChanged);
            // 
            // InterpolateImageCheckBox
            // 
            this.InterpolateImageCheckBox.ButtonProperties.BorderOffset = 2;
            this.InterpolateImageCheckBox.Location = new System.Drawing.Point(6, 479);
            this.InterpolateImageCheckBox.Name = "InterpolateImageCheckBox";
            this.InterpolateImageCheckBox.Size = new System.Drawing.Size(150, 24);
            this.InterpolateImageCheckBox.TabIndex = 14;
            this.InterpolateImageCheckBox.Text = "Interpolate Image";
            this.InterpolateImageCheckBox.CheckedChanged += new System.EventHandler(this.InterpolateImageCheckBox_CheckedChanged);
            // 
            // GridDisplayModeComboBox
            // 
            this.GridDisplayModeComboBox.ListProperties.CheckBoxDataMember = "";
            this.GridDisplayModeComboBox.ListProperties.DataSource = null;
            this.GridDisplayModeComboBox.ListProperties.DisplayMember = "";
            this.GridDisplayModeComboBox.Location = new System.Drawing.Point(6, 32);
            this.GridDisplayModeComboBox.Name = "GridDisplayModeComboBox";
            this.GridDisplayModeComboBox.Size = new System.Drawing.Size(162, 21);
            this.GridDisplayModeComboBox.TabIndex = 16;
            this.GridDisplayModeComboBox.SelectedIndexChanged += new System.EventHandler(this.GridDisplayModeComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "Grid Display Mode:";
            // 
            // ContourStrokeStyleButton
            // 
            this.ContourStrokeStyleButton.Location = new System.Drawing.Point(6, 109);
            this.ContourStrokeStyleButton.Name = "ContourStrokeStyleButton";
            this.ContourStrokeStyleButton.Size = new System.Drawing.Size(159, 24);
            this.ContourStrokeStyleButton.TabIndex = 17;
            this.ContourStrokeStyleButton.Text = "Contour Stroke Style ...";
            this.ContourStrokeStyleButton.Click += new System.EventHandler(this.ContourStrokeStyleButton_Click);
            // 
            // ContourDotSizeNumericUpDown
            // 
            this.ContourDotSizeNumericUpDown.Location = new System.Drawing.Point(106, 139);
            this.ContourDotSizeNumericUpDown.Name = "ContourDotSizeNumericUpDown";
            this.ContourDotSizeNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.ContourDotSizeNumericUpDown.TabIndex = 19;
            this.ContourDotSizeNumericUpDown.ValueChanged += new System.EventHandler(this.ContourDotSizeNumericUpDown_ValueChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Contour Dot Size:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GridDotSizeNumericUpDown
            // 
            this.GridDotSizeNumericUpDown.Location = new System.Drawing.Point(109, 89);
            this.GridDotSizeNumericUpDown.Name = "GridDotSizeNumericUpDown";
            this.GridDotSizeNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.GridDotSizeNumericUpDown.TabIndex = 22;
            this.GridDotSizeNumericUpDown.ValueChanged += new System.EventHandler(this.GridDotSizeNumericUpDown_ValueChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Grid Dot Size:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GridStrokeStyleButton
            // 
            this.GridStrokeStyleButton.Location = new System.Drawing.Point(6, 59);
            this.GridStrokeStyleButton.Name = "GridStrokeStyleButton";
            this.GridStrokeStyleButton.Size = new System.Drawing.Size(162, 24);
            this.GridStrokeStyleButton.TabIndex = 20;
            this.GridStrokeStyleButton.Text = "Grid Stroke Style ...";
            this.GridStrokeStyleButton.Click += new System.EventHandler(this.GridStrokeStyleButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.OriginXUpDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.OriginYUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.StepXUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.StepYUpDown);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 124);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ContourDisplayModeCombo);
            this.groupBox2.Controls.Add(this.ContourColorModeCombo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ContourStrokeStyleButton);
            this.groupBox2.Controls.Add(this.ContourDotSizeNumericUpDown);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 182);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contour";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GridDisplayModeComboBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.GridStrokeStyleButton);
            this.groupBox3.Controls.Add(this.GridDotSizeNumericUpDown);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 306);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(179, 124);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grid";
            // 
            // NHeatMapContourUC
            // 
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InterpolateImageCheckBox);
            this.Controls.Add(this.SmoothPaletteCheckBox);
            this.Controls.Add(this.ShowFillCheckBox);
            this.Name = "NHeatMapContourUC";
            this.Size = new System.Drawing.Size(179, 516);
            ((System.ComponentModel.ISupportInitialize)(this.OriginXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepXUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepYUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContourDotSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDotSizeNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		
		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Heat Map Contour");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			NChart chart = nChartControl1.Charts[0];

			chart.BoundsMode = BoundsMode.Stretch;
            chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();

			// create the heat map 
            m_HeatMap = new NHeatMapSeries();
            chart.Series.Add(m_HeatMap);

            m_HeatMap.Palette.Add(0.0, Color.Purple);
            m_HeatMap.Palette.Add(1.5, Color.MediumSlateBlue);
            m_HeatMap.Palette.Add(3.0, Color.CornflowerBlue);
            m_HeatMap.Palette.Add(4.5, Color.LimeGreen);
            m_HeatMap.Palette.Add(6.0, Color.LightGreen);
            m_HeatMap.Palette.Add(7.5, Color.Yellow);
            m_HeatMap.Palette.Add(9.0, Color.Orange);
            m_HeatMap.Palette.Add(10.5, Color.Red);
            m_HeatMap.XValuesMode = HeatMapValuesMode.OriginAndStep;
            m_HeatMap.YValuesMode = HeatMapValuesMode.OriginAndStep;

            m_HeatMap.ContourDisplayMode = ContourDisplayMode.Contour;
            m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic;
            m_HeatMap.Legend.Format = "<zone_value>";

            GenerateData();

			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

            // init form controls
            OriginXUpDown.Value = 0;
            OriginYUpDown.Value = 0;
            StepXUpDown.Value = 1;
            StepYUpDown.Value = 1;

            ContourDisplayModeCombo.FillFromEnum(typeof(ContourDisplayMode));
            ContourColorModeCombo.FillFromEnum(typeof(ContourColorMode));
            GridDisplayModeComboBox.FillFromEnum(typeof(HeatMapGridDisplayMode));

            ContourDisplayModeCombo.SelectedIndex = (int)ContourDisplayMode.Contour;
            GridDisplayModeComboBox.SelectedIndex = (int)HeatMapGridDisplayMode.None;
            GridDotSizeNumericUpDown.Value = (decimal)2;
            ContourColorModeCombo.SelectedIndex = (int)ContourColorMode.Uniform;
            ContourDotSizeNumericUpDown.Value = (decimal)2;
            
            ShowFillCheckBox.Checked = true;
            SmoothPaletteCheckBox.Checked = true;
		}

        private void GenerateData()
        {
            NHeatMapData data = m_HeatMap.Data;

            int GridStepX = 60;
            int GridStepY = 60;
            data.SetGridSize(GridStepX, GridStepY);

            const double dIntervalX = 10.0;
            const double dIntervalZ = 10.0;
            double dIncrementX = (dIntervalX / GridStepX);
            double dIncrementZ = (dIntervalZ / GridStepY);

            double y, x, z;

            z = -(dIntervalZ / 2);

            for (int col = 0; col < GridStepX; col++, z += dIncrementZ)
            {
                x = -(dIntervalX / 2);

                for (int row = 0; row < GridStepY; row++, x += dIncrementX)
                {
                    y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
					y += 3.0 * Math.Sin(x) * Math.Cos(z);

                    double value = y;

                    data.SetValue(row, col, value);
                }
            }
        }
        
        private void UpdateHeatMapSeries()
        {
            // position
            m_HeatMap.OriginX = (double)OriginXUpDown.Value;
            m_HeatMap.OriginY = (double)OriginYUpDown.Value;
            m_HeatMap.StepX = (double)StepXUpDown.Value;
            m_HeatMap.StepY = (double)StepYUpDown.Value;

            // contour
            m_HeatMap.ContourDisplayMode = (ContourDisplayMode)ContourDisplayModeCombo.SelectedIndex;
            m_HeatMap.ContourColorMode = (ContourColorMode)ContourColorModeCombo.SelectedIndex;
            m_HeatMap.ContourDotSize = new NSizeL((float)ContourDotSizeNumericUpDown.Value, (float)ContourDotSizeNumericUpDown.Value);

            // grid
            m_HeatMap.GridDisplayMode = (HeatMapGridDisplayMode)GridDisplayModeComboBox.SelectedIndex;
            m_HeatMap.GridDotSize = new NSizeL((float)GridDotSizeNumericUpDown.Value, (float)GridDotSizeNumericUpDown.Value);

            m_HeatMap.ShowFill = ShowFillCheckBox.Checked;
            m_HeatMap.Palette.SmoothPalette = SmoothPaletteCheckBox.Checked;
            m_HeatMap.InterpolateImage = InterpolateImageCheckBox.Checked;

            if (m_HeatMap.Palette.SmoothPalette)
            {
                m_HeatMap.Legend.Format = "<zone_value>";
            }
            else
            {
                m_HeatMap.Legend.Format = "<zone_begin> - <zone_end>";
            }

            nChartControl1.Refresh();
        }

        private void OriginXUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void OriginYUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void StepXUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void StepYUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void ContourDisplayModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void ContourColorModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void ShowFillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void SmoothPaletteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void InterpolateImageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void ContourDotSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void GridDisplayModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void GridDotSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateHeatMapSeries();
        }

        private void ContourStrokeStyleButton_Click(object sender, EventArgs e)
        {
            if (m_HeatMap != null)
            {
                NStrokeStyle strokeStyleResult;

                if (NStrokeStyleTypeEditor.Edit(m_HeatMap.ContourStrokeStyle, out strokeStyleResult))
                {
                    m_HeatMap.ContourStrokeStyle = strokeStyleResult;
                    nChartControl1.Refresh();
                }
            }
        }

        private void GridStrokeStyleButton_Click(object sender, EventArgs e)
        {
            if (m_HeatMap != null)
            {
                NStrokeStyle strokeStyleResult;

                if (NStrokeStyleTypeEditor.Edit(m_HeatMap.GridStrokeStyle, out strokeStyleResult))
                {
                    m_HeatMap.GridStrokeStyle = strokeStyleResult;
                    nChartControl1.Refresh();
                }
            }

        }
	}
}
