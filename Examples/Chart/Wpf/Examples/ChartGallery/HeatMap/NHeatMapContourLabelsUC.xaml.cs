using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NHeatMapContourLabelsUC : NExampleBaseUC
	{
		NHeatMapSeries m_HeatMap;

		public NHeatMapContourLabelsUC()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Gets the title of this example
		/// </summary>
		public override string Title
		{
			get
			{
				return "Heat Map Contour Labels";
			}
		}
		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "The example demonstrates the capabilities of the heat map to display labels at each contour line.";
			}
		}
		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Heat Map Contour");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
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

			m_HeatMap.ContourLabelStyle.Visible = true;;
			m_HeatMap.ContourLabelStyle.AllowLabelToFlip = false;
			m_HeatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible = false;
			m_HeatMap.ContourLabelStyle.ClipContour = true;

			ShowContourLabelsCheckBox.IsChecked = true;
			AllowLabelsToFlipCheckBox.IsChecked = false;
			ShowLabelBackgroundCheckBox.IsChecked = false;
			ClipContourCheckBox.IsChecked = true;

			GenerateData();

			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);
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

		private void ShowContourLabelsCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_HeatMap.ContourLabelStyle.Visible = ShowContourLabelsCheckBox.IsChecked.Value;
			nChartControl1.Refresh();
		}

		private void AllowLabelsToFlipCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_HeatMap.ContourLabelStyle.AllowLabelToFlip = AllowLabelsToFlipCheckBox.IsChecked.Value;
			nChartControl1.Refresh();
		}

		private void ShowLabelBackgroundCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_HeatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible = ShowLabelBackgroundCheckBox.IsChecked.Value;
			nChartControl1.Refresh();
		}

		private void ClipContourCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_HeatMap.ContourLabelStyle.ClipContour = ClipContourCheckBox.IsChecked.Value;
			nChartControl1.Refresh();

		}
	}
}
