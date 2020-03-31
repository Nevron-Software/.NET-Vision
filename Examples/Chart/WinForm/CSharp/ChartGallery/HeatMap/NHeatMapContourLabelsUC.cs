using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public partial class NHeatMapContourLabelsUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

		NHeatMapSeries m_HeatMap;
		private Label label9;
		private UI.WinForm.Controls.NNumericUpDown LabelDistanceUpDown;
		private UI.WinForm.Controls.NCheckBox AllowLabelsToFlipCheckBox;
		private UI.WinForm.Controls.NCheckBox ShowLabelBackgroundCheckBox;
		private UI.WinForm.Controls.NCheckBox ClipContourCheckBox;
		private UI.WinForm.Controls.NCheckBox ShowContourLabelsCheckBox;

        public NHeatMapContourLabelsUC()
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
			this.ShowContourLabelsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.LabelDistanceUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.AllowLabelsToFlipCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowLabelBackgroundCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ClipContourCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.LabelDistanceUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// ShowContourLabelsCheckBox
			// 
			this.ShowContourLabelsCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowContourLabelsCheckBox.Location = new System.Drawing.Point(3, -1);
			this.ShowContourLabelsCheckBox.Name = "ShowContourLabelsCheckBox";
			this.ShowContourLabelsCheckBox.Size = new System.Drawing.Size(150, 24);
			this.ShowContourLabelsCheckBox.TabIndex = 0;
			this.ShowContourLabelsCheckBox.Text = "Show Contour Labels";
			this.ShowContourLabelsCheckBox.CheckedChanged += new System.EventHandler(this.ShowContourLabelsCheckBox_CheckedChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(3, 128);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 20);
			this.label9.TabIndex = 5;
			this.label9.Text = "Label Distance:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LabelDistanceUpDown
			// 
			this.LabelDistanceUpDown.Location = new System.Drawing.Point(104, 128);
			this.LabelDistanceUpDown.Name = "LabelDistanceUpDown";
			this.LabelDistanceUpDown.Size = new System.Drawing.Size(62, 20);
			this.LabelDistanceUpDown.TabIndex = 6;
			this.LabelDistanceUpDown.ValueChanged += new System.EventHandler(this.LabelDistanceUpDown_ValueChanged);
			// 
			// AllowLabelsToFlipCheckBox
			// 
			this.AllowLabelsToFlipCheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowLabelsToFlipCheckBox.Location = new System.Drawing.Point(3, 32);
			this.AllowLabelsToFlipCheckBox.Name = "AllowLabelsToFlipCheckBox";
			this.AllowLabelsToFlipCheckBox.Size = new System.Drawing.Size(150, 24);
			this.AllowLabelsToFlipCheckBox.TabIndex = 1;
			this.AllowLabelsToFlipCheckBox.Text = "Allow Labels To Flip";
			this.AllowLabelsToFlipCheckBox.CheckedChanged += new System.EventHandler(this.AllowLabelsToFlipCheckBox_CheckedChanged);
			// 
			// ShowLabelBackgroundCheckBox
			// 
			this.ShowLabelBackgroundCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowLabelBackgroundCheckBox.Location = new System.Drawing.Point(3, 65);
			this.ShowLabelBackgroundCheckBox.Name = "ShowLabelBackgroundCheckBox";
			this.ShowLabelBackgroundCheckBox.Size = new System.Drawing.Size(150, 24);
			this.ShowLabelBackgroundCheckBox.TabIndex = 2;
			this.ShowLabelBackgroundCheckBox.Text = "Show Label Background";
			this.ShowLabelBackgroundCheckBox.CheckedChanged += new System.EventHandler(this.ShowLabelBackgroundCheckBox_CheckedChanged);
			// 
			// ClipContourCheckBox
			// 
			this.ClipContourCheckBox.ButtonProperties.BorderOffset = 2;
			this.ClipContourCheckBox.Location = new System.Drawing.Point(3, 98);
			this.ClipContourCheckBox.Name = "ClipContourCheckBox";
			this.ClipContourCheckBox.Size = new System.Drawing.Size(150, 24);
			this.ClipContourCheckBox.TabIndex = 3;
			this.ClipContourCheckBox.Text = "Clip Contour";
			this.ClipContourCheckBox.CheckedChanged += new System.EventHandler(this.ClipContourCheckBox_CheckedChanged);
			// 
			// NHeatMapContourLabelsUC
			// 
			this.Controls.Add(this.ClipContourCheckBox);
			this.Controls.Add(this.ShowLabelBackgroundCheckBox);
			this.Controls.Add(this.AllowLabelsToFlipCheckBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.LabelDistanceUpDown);
			this.Controls.Add(this.ShowContourLabelsCheckBox);
			this.Name = "NHeatMapContourLabelsUC";
			this.Size = new System.Drawing.Size(179, 516);
			((System.ComponentModel.ISupportInitialize)(this.LabelDistanceUpDown)).EndInit();
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
			m_HeatMap.Palette.SmoothPalette = true;
			m_HeatMap.XValuesMode = HeatMapValuesMode.OriginAndStep;
            m_HeatMap.YValuesMode = HeatMapValuesMode.OriginAndStep;

            m_HeatMap.ContourDisplayMode = ContourDisplayMode.Contour;
            m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic;
            m_HeatMap.Legend.Format = "<zone_value>";

            GenerateData();

			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			ShowContourLabelsCheckBox.Checked = true;
			AllowLabelsToFlipCheckBox.Checked = m_HeatMap.ContourLabelStyle.AllowLabelToFlip;
			LabelDistanceUpDown.Value = (decimal)m_HeatMap.ContourLabelStyle.LabelDistance.Value;
			ShowLabelBackgroundCheckBox.Checked = m_HeatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible;
			ClipContourCheckBox.Checked = m_HeatMap.ContourLabelStyle.ClipContour;
		}

        private void GenerateData()
        {
            NHeatMapData data = m_HeatMap.Data;

            int GridStepX = 100;
            int GridStepY = 100;
            data.SetGridSize(GridStepX, GridStepY);

            const double dIntervalX = 10.0;
            const double dIntervalZ = 10.0;
            double dIncrementX = (dIntervalX / GridStepX);
            double dIncrementZ = (dIntervalZ / GridStepY);

            double y, x, z;

            z = -(dIntervalZ / 2);

			int centerX = (int)(GridStepX / 2.0);
			int centerY = (int)(GridStepY / 2.0);

			for (int col = 0; col < GridStepX; col++, z += dIncrementZ)
            {
                x = -(dIntervalX / 2);

                for (int row = 0; row < GridStepY; row++, x += dIncrementX)
                {
                    y = 10 - Math.Sqrt((x * x) + (z * z) + 2);
					y += 3.0 * Math.Sin(x) * Math.Cos(z);

                    data.SetValue(row, col, y);
                }
            }
        }

		private void ShowContourLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_HeatMap.ContourLabelStyle.Visible = ShowContourLabelsCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void LabelDistanceUpDown_ValueChanged(object sender, EventArgs e)
		{
			m_HeatMap.ContourLabelStyle.LabelDistance = new NLength((float)LabelDistanceUpDown.Value, NGraphicsUnit.Point);
			nChartControl1.Refresh();
		}
		private void AllowLabelsToFlipCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_HeatMap.ContourLabelStyle.AllowLabelToFlip = AllowLabelsToFlipCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ShowLabelBackgroundCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_HeatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible = ShowLabelBackgroundCheckBox.Checked;
			nChartControl1.Refresh();
		}

		private void ClipContourCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			m_HeatMap.ContourLabelStyle.ClipContour = ClipContourCheckBox.Checked;
			nChartControl1.Refresh();
		}
	}
}
