using System;
using System.Collections.Generic;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.UI;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NHeatMapWaferChartUC : NExampleBaseUC
	{
		NHeatMapSeries m_HeatMap;

		public NHeatMapWaferChartUC()
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
				return "Heat Map Wafer Chart";
			}
		}
		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
                return "The example demonstrates the capabilities of the heat map series to render contour lines.";
			}
		}
		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Wafer Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// configure chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];

			m_HeatMap = new NHeatMapSeries();
			chart.Series.Add(m_HeatMap);

			NHeatMapData data = m_HeatMap.Data;

			m_HeatMap.Palette.Mode = PaletteMode.AutoFixedEntryCount;
			m_HeatMap.Palette.AutoPaletteColors = new NArgbColorValue[] { new NArgbColorValue(Color.Green), new NArgbColorValue(Color.Red) };
			m_HeatMap.Palette.SmoothPalette = true;

			int gridSizeX = 100;
			int gridSizeY = 100;
			data.SetGridSize(gridSizeX, gridSizeY);

			int centerX = gridSizeX / 2;
			int centerY = gridSizeY / 2;

			int radius = gridSizeX / 2;
			Random rand = new Random();

			for (int y = 0; y < gridSizeY; y++)
			{
				for (int x = 0; x < gridSizeX; x++)
				{
					int dx = x - centerX;
					int dy = y - centerY;

					double pointDistance = Math.Sqrt(dx * dx + dy * dy);

					if (pointDistance < radius)
					{
						// assign value
						data.SetValue(x, y, pointDistance + rand.Next(20));
					}
					else
					{
						data.SetValue(x, y, double.NaN);
					}
				}
			}
		}

		private void InterpolateImageCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			m_HeatMap.InterpolateImage = InterpolateImageCheckBox.IsChecked.Value;
			this.nChartControl1.Refresh();
		}
	}
}
