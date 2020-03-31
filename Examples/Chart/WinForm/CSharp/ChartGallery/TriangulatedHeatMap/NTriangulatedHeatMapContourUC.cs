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
	public partial class NTriangulatedHeatMapContourUC : NExampleBaseUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
		private UI.WinForm.Controls.NCheckBox ClipContourCheckBox;
		private UI.WinForm.Controls.NCheckBox ShowLabelBackgroundCheckBox;
		private UI.WinForm.Controls.NCheckBox AllowLabelsToFlipCheckBox;
		private Label label9;
		private UI.WinForm.Controls.NNumericUpDown LabelDistanceUpDown;
		private UI.WinForm.Controls.NCheckBox ShowContourLabelsCheckBox;
		NTriangulatedHeatMapSeries m_HeatMap;

        public NTriangulatedHeatMapContourUC()
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
			this.ClipContourCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ShowLabelBackgroundCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.AllowLabelsToFlipCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.LabelDistanceUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
			this.ShowContourLabelsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.LabelDistanceUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// ClipContourCheckBox
			// 
			this.ClipContourCheckBox.ButtonProperties.BorderOffset = 2;
			this.ClipContourCheckBox.Location = new System.Drawing.Point(13, 114);
			this.ClipContourCheckBox.Name = "ClipContourCheckBox";
			this.ClipContourCheckBox.Size = new System.Drawing.Size(150, 24);
			this.ClipContourCheckBox.TabIndex = 10;
			this.ClipContourCheckBox.Text = "Clip Contour";
			this.ClipContourCheckBox.CheckedChanged += new System.EventHandler(this.ClipContourCheckBox_CheckedChanged);
			// 
			// ShowLabelBackgroundCheckBox
			// 
			this.ShowLabelBackgroundCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowLabelBackgroundCheckBox.Location = new System.Drawing.Point(13, 81);
			this.ShowLabelBackgroundCheckBox.Name = "ShowLabelBackgroundCheckBox";
			this.ShowLabelBackgroundCheckBox.Size = new System.Drawing.Size(150, 24);
			this.ShowLabelBackgroundCheckBox.TabIndex = 9;
			this.ShowLabelBackgroundCheckBox.Text = "Show Label Background";
			this.ShowLabelBackgroundCheckBox.CheckedChanged += new System.EventHandler(this.ShowLabelBackgroundCheckBox_CheckedChanged);
			// 
			// AllowLabelsToFlipCheckBox
			// 
			this.AllowLabelsToFlipCheckBox.ButtonProperties.BorderOffset = 2;
			this.AllowLabelsToFlipCheckBox.Location = new System.Drawing.Point(13, 48);
			this.AllowLabelsToFlipCheckBox.Name = "AllowLabelsToFlipCheckBox";
			this.AllowLabelsToFlipCheckBox.Size = new System.Drawing.Size(150, 24);
			this.AllowLabelsToFlipCheckBox.TabIndex = 8;
			this.AllowLabelsToFlipCheckBox.Text = "Allow Labels To Flip";
			this.AllowLabelsToFlipCheckBox.CheckedChanged += new System.EventHandler(this.AllowLabelsToFlipCheckBox_CheckedChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(13, 144);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 20);
			this.label9.TabIndex = 11;
			this.label9.Text = "Label Distance:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LabelDistanceUpDown
			// 
			this.LabelDistanceUpDown.Location = new System.Drawing.Point(114, 144);
			this.LabelDistanceUpDown.Name = "LabelDistanceUpDown";
			this.LabelDistanceUpDown.Size = new System.Drawing.Size(62, 20);
			this.LabelDistanceUpDown.TabIndex = 12;
			this.LabelDistanceUpDown.ValueChanged += new System.EventHandler(this.LabelDistanceUpDown_ValueChanged);
			// 
			// ShowContourLabelsCheckBox
			// 
			this.ShowContourLabelsCheckBox.ButtonProperties.BorderOffset = 2;
			this.ShowContourLabelsCheckBox.Location = new System.Drawing.Point(13, 15);
			this.ShowContourLabelsCheckBox.Name = "ShowContourLabelsCheckBox";
			this.ShowContourLabelsCheckBox.Size = new System.Drawing.Size(150, 24);
			this.ShowContourLabelsCheckBox.TabIndex = 7;
			this.ShowContourLabelsCheckBox.Text = "Show Contour Labels";
			this.ShowContourLabelsCheckBox.CheckedChanged += new System.EventHandler(this.ShowContourLabelsCheckBox_CheckedChanged);
			// 
			// NTriangulatedHeatMapContourUC
			// 
			this.Controls.Add(this.ClipContourCheckBox);
			this.Controls.Add(this.ShowLabelBackgroundCheckBox);
			this.Controls.Add(this.AllowLabelsToFlipCheckBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.LabelDistanceUpDown);
			this.Controls.Add(this.ShowContourLabelsCheckBox);
			this.Name = "NTriangulatedHeatMapContourUC";
			this.Size = new System.Drawing.Size(179, 516);
			((System.ComponentModel.ISupportInitialize)(this.LabelDistanceUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public override void Initialize()
		{
			base.Initialize();

			// set a chart title
			NLabel title = new NLabel("Triangulated Heat Map Contour Labels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			NChart chart = nChartControl1.Charts[0];

			chart.BoundsMode = BoundsMode.Stretch;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = new NLinearScaleConfigurator();

			// create the heat map 
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

			ShowContourLabelsCheckBox.Checked = true;
			AllowLabelsToFlipCheckBox.Checked = m_HeatMap.ContourLabelStyle.AllowLabelToFlip;
			LabelDistanceUpDown.Value = (decimal)m_HeatMap.ContourLabelStyle.LabelDistance.Value;
			ShowLabelBackgroundCheckBox.Checked = m_HeatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible;
			ClipContourCheckBox.Checked = m_HeatMap.ContourLabelStyle.ClipContour;
		}

		private void GenerateData()
		{
			NPointD[] points = new NPointD[] { new NPointD(3.1, 0.1), new NPointD(1.5, 2.0), new NPointD(1.5, 0.5), new NPointD(2, 0), new NPointD(1.5, 3.4), new NPointD(1.3, 3) };
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
