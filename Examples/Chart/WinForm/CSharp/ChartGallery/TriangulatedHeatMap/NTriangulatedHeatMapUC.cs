using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI;
using Nevron.Editors;
using Nevron.Chart.Windows;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public partial class NTriangulatedHeatMapUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

		NTriangulatedHeatMapSeries m_HeatMap;
		NPointSeries m_Points;
        private UI.WinForm.Controls.NComboBox ContourDisplayModeCombo;
        private Label label4;
        private UI.WinForm.Controls.NComboBox ContourColorModeCombo;
        private Label label5;
        private UI.WinForm.Controls.NCheckBox ShowFillCheckBox;
        private UI.WinForm.Controls.NCheckBox SmoothPaletteCheckBox;
        private UI.WinForm.Controls.NCheckBox InterpolateImageCheckBox;
        private UI.WinForm.Controls.NButton ContourStrokeStyleButton;
        private UI.WinForm.Controls.NNumericUpDown ContourDotSizeNumericUpDown;
        private Label label7;
		private UI.WinForm.Controls.NCheckBox ShowPointsCheckBox;
		private GroupBox groupBox2;

        public NTriangulatedHeatMapUC()
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
			this.ContourDisplayModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ContourColorModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ShowFillCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SmoothPaletteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.InterpolateImageCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ContourStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ContourDotSizeNumericUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ShowPointsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.ContourDotSizeNumericUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ContourDisplayModeCombo
			// 
			this.ContourDisplayModeCombo.ListProperties.CheckBoxDataMember = "";
			this.ContourDisplayModeCombo.ListProperties.DataSource = null;
			this.ContourDisplayModeCombo.ListProperties.DisplayMember = "";
			this.ContourDisplayModeCombo.Location = new System.Drawing.Point(6, 32);
			this.ContourDisplayModeCombo.Name = "ContourDisplayModeCombo";
			this.ContourDisplayModeCombo.Size = new System.Drawing.Size(159, 21);
			this.ContourDisplayModeCombo.TabIndex = 1;
			this.ContourDisplayModeCombo.SelectedIndexChanged += new System.EventHandler(this.ContourDisplayModeCombo_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(159, 21);
			this.label4.TabIndex = 0;
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
			this.ContourColorModeCombo.TabIndex = 3;
			this.ContourColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.ContourColorModeCombo_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(159, 21);
			this.label5.TabIndex = 2;
			this.label5.Text = "Contour Color Mode:";
			// 
			// ShowFillCheckBox
			// 
			this.ShowFillCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowFillCheckBox.Location = new System.Drawing.Point(6, 200);
			this.ShowFillCheckBox.Name = "ShowFillCheckBox";
			this.ShowFillCheckBox.Size = new System.Drawing.Size(150, 24);
			this.ShowFillCheckBox.TabIndex = 1;
			this.ShowFillCheckBox.Text = "Show Fill";
			this.ShowFillCheckBox.CheckedChanged += new System.EventHandler(this.ShowFillCheckBox_CheckedChanged);
			// 
			// SmoothPaletteCheckBox
			// 
			this.SmoothPaletteCheckBox.ButtonProperties.BorderOffset = 2;
			this.SmoothPaletteCheckBox.Location = new System.Drawing.Point(6, 224);
			this.SmoothPaletteCheckBox.Name = "SmoothPaletteCheckBox";
			this.SmoothPaletteCheckBox.Size = new System.Drawing.Size(150, 24);
			this.SmoothPaletteCheckBox.TabIndex = 2;
			this.SmoothPaletteCheckBox.Text = "Smooth Palette";
			this.SmoothPaletteCheckBox.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheckBox_CheckedChanged);
			// 
			// InterpolateImageCheckBox
			// 
			this.InterpolateImageCheckBox.ButtonProperties.BorderOffset = 2;
			this.InterpolateImageCheckBox.Location = new System.Drawing.Point(6, 248);
			this.InterpolateImageCheckBox.Name = "InterpolateImageCheckBox";
			this.InterpolateImageCheckBox.Size = new System.Drawing.Size(150, 24);
			this.InterpolateImageCheckBox.TabIndex = 3;
			this.InterpolateImageCheckBox.Text = "Interpolate Image";
			this.InterpolateImageCheckBox.CheckedChanged += new System.EventHandler(this.InterpolateImageCheckBox_CheckedChanged);
			// 
			// ContourStrokeStyleButton
			// 
			this.ContourStrokeStyleButton.Location = new System.Drawing.Point(6, 109);
			this.ContourStrokeStyleButton.Name = "ContourStrokeStyleButton";
			this.ContourStrokeStyleButton.Size = new System.Drawing.Size(159, 24);
			this.ContourStrokeStyleButton.TabIndex = 4;
			this.ContourStrokeStyleButton.Text = "Contour Stroke Style ...";
			this.ContourStrokeStyleButton.Click += new System.EventHandler(this.ContourStrokeStyleButton_Click);
			// 
			// ContourDotSizeNumericUpDown
			// 
			this.ContourDotSizeNumericUpDown.Location = new System.Drawing.Point(106, 139);
			this.ContourDotSizeNumericUpDown.Name = "ContourDotSizeNumericUpDown";
			this.ContourDotSizeNumericUpDown.Size = new System.Drawing.Size(59, 20);
			this.ContourDotSizeNumericUpDown.TabIndex = 6;
			this.ContourDotSizeNumericUpDown.ValueChanged += new System.EventHandler(this.ContourDotSizeNumericUpDown_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 139);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 20);
			this.label7.TabIndex = 5;
			this.label7.Text = "Contour Dot Size:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(179, 182);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Contour";
			// 
			// ShowPointsCheckBox
			// 
			this.ShowPointsCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowPointsCheckBox.Location = new System.Drawing.Point(6, 272);
			this.ShowPointsCheckBox.Name = "ShowPointsCheckBox";
			this.ShowPointsCheckBox.Size = new System.Drawing.Size(150, 24);
			this.ShowPointsCheckBox.TabIndex = 4;
			this.ShowPointsCheckBox.Text = "Show Points";
			this.ShowPointsCheckBox.CheckedChanged += new System.EventHandler(this.ShowPointsCheckBox_CheckedChanged);
			// 
			// NTriangulatedHeatMapUC
			// 
			this.Controls.Add(this.ShowPointsCheckBox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.InterpolateImageCheckBox);
			this.Controls.Add(this.SmoothPaletteCheckBox);
			this.Controls.Add(this.ShowFillCheckBox);
			this.Name = "NTriangulatedHeatMapUC";
			this.Size = new System.Drawing.Size(179, 516);
			((System.ComponentModel.ISupportInitialize)(this.ContourDotSizeNumericUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		
		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Triangulated Heat Map");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.RangeSelections.Add(new NRangeSelection());

			chart.BoundsMode = BoundsMode.Stretch;

			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.RoundToTickMin = false;
			scaleX.RoundToTickMax = false;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.RoundToTickMin = false;
			scaleY.RoundToTickMax = false;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// create a point series (used to show the incoming points XY values)
			m_Points = new NPointSeries();
			chart.Series.Add(m_Points);
			m_Points.UseXValues = true;
			m_Points.BorderStyle.Width = new NLength(0);
			m_Points.FillStyle = new NColorFillStyle(Color.Black);
			m_Points.Size = new NLength(2);
			m_Points.DataLabelStyle.Visible = false;

			// create the heat map 
			m_HeatMap = new NTriangulatedHeatMapSeries();
            chart.Series.Add(m_HeatMap);

            m_HeatMap.Palette.Add(0.0, Color.Purple);
            m_HeatMap.Palette.Add(1.5, Color.MediumSlateBlue);
            m_HeatMap.Palette.Add(3.0, Color.CornflowerBlue);
            m_HeatMap.Palette.Add(4.5, Color.LimeGreen);
            m_HeatMap.Palette.Add(6.0, Color.LightGreen);
            m_HeatMap.Palette.Add(7.5, Color.Yellow);
            m_HeatMap.Palette.Add(9.0, Color.Orange);
            m_HeatMap.Palette.Add(10.5, Color.Red);

            m_HeatMap.ContourDisplayMode = ContourDisplayMode.Contour;
            m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic;
            m_HeatMap.Legend.Format = "<zone_value>";


			GenerateData();

			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NDataZoomTool());

			// init form controls
			ContourDisplayModeCombo.FillFromEnum(typeof(ContourDisplayMode));
            ContourColorModeCombo.FillFromEnum(typeof(ContourColorMode));

            ContourDisplayModeCombo.SelectedIndex = (int)ContourDisplayMode.Contour;
            ContourColorModeCombo.SelectedIndex = (int)ContourColorMode.Uniform;
            ContourDotSizeNumericUpDown.Value = (decimal)2;
            
            ShowFillCheckBox.Checked = true;
            SmoothPaletteCheckBox.Checked = true;
		}
		/// <summary>
		/// Generates random data
		/// </summary>
		private void GenerateData()
		{
			NPointD[] points = new NPointD[] { new NPointD(0.1, 0.1), new NPointD(1.5, 1.0), new NPointD(2.5, 5), new NPointD(4, 0), new NPointD(2.5, 3.4), new NPointD(1.3, 5) };
			double[] pointsIntensity = new double[] { 30, 10, 30, 20, 40, 20 };

			Random rand = new Random();

			for (double x = 0.0; x <= 5; x += 0.5)
			{
				for (double y = 0.0; y <= 5; y += 0.5)
				{
					double pointX;
					double pointY;

					if (x == 0 || y == 0 || x == 5 || y == 5)
					{
						pointX = x;
						pointY = y;
					}
					else
					{
						pointX = x + rand.NextDouble() * 0.2;
						pointY = y + rand.NextDouble() * 0.2;
					}

					double intensity = 0;
					for (int i = 0; i < points.Length; i++)
					{
						double dx = points[i].X - pointX;
						double dy = points[i].Y - pointY;

						double distance = Math.Sqrt(dx * dx + dy * dy);
						intensity += pointsIntensity[i] / (1 + distance * distance);
					}

					m_HeatMap.Values.Add(intensity);
					m_HeatMap.XValues.Add(pointX);
					m_HeatMap.YValues.Add(pointY);
				}
			}
		}

		private void UpdateChart()
        {
            // contour
            m_HeatMap.ContourDisplayMode = (ContourDisplayMode)ContourDisplayModeCombo.SelectedIndex;
            m_HeatMap.ContourColorMode = (ContourColorMode)ContourColorModeCombo.SelectedIndex;
            m_HeatMap.ContourDotSize = new NSizeL((float)ContourDotSizeNumericUpDown.Value, (float)ContourDotSizeNumericUpDown.Value);

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

			m_Points.Values.Clear();
			m_Points.XValues.Clear();

			if (ShowPointsCheckBox.Checked)
			{
				m_Points.Values.AddRange(m_HeatMap.YValues);
				m_Points.XValues.AddRange(m_HeatMap.XValues);
			}

            nChartControl1.Refresh();
        }

		private void ContourDisplayModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void ContourColorModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void ShowFillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void SmoothPaletteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void InterpolateImageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void ContourDotSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateChart();
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

		private void ShowPointsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateChart();
		}
	}
}
