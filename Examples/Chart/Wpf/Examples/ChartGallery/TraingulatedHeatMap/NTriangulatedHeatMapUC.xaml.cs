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
	public partial class NTriangulatedHeatMapUC : NRealTimeExampleBaseUC
	{
		NTriangulatedHeatMapSeries m_HeatMap;
		NPointSeries m_Points;

		public NTriangulatedHeatMapUC()
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
				return "Triangulated Heat Map";
			}
		}
		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "The example demonstrates the capabilities of the triangulated heat map series. This series accepts an input of arbitrary XYZ points and renders them as a heat map where the Z value is treated as elevation and the XY values define the location of the point.";
			}
		}
		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Triangulated Heat Map");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
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

			NExampleHelpers.FillComboWithEnumValues(ContourDisplayModeComboBox, typeof(ContourDisplayMode));
			NExampleHelpers.FillComboWithEnumValues(ContourColorModeComboBox, typeof(ContourColorMode));

			GenerateData();

			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			ContourDisplayModeComboBox.SelectedIndex = (int)ContourDisplayMode.Contour;
			ContourColorModeComboBox.SelectedIndex = (int)ContourColorMode.Uniform;
			ShowFillCheckBox.IsChecked = true;
			SmoothPaletteCheckBox.IsChecked = true;

			UpdateChart();
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
			m_HeatMap.ContourDisplayMode = (ContourDisplayMode)ContourDisplayModeComboBox.SelectedIndex;
			m_HeatMap.ContourColorMode = (ContourColorMode)ContourColorModeComboBox.SelectedIndex;

			m_HeatMap.ShowFill = ShowFillCheckBox.IsChecked.Value;
			m_HeatMap.Palette.SmoothPalette = SmoothPaletteCheckBox.IsChecked.Value;

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

			if (ShowPointsCheckBox.IsChecked.Value)
			{
				m_Points.Values.AddRange(m_HeatMap.YValues);
				m_Points.XValues.AddRange(m_HeatMap.XValues);
			}

			nChartControl1.Refresh();
		}

		private void ShowFillCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}

		private void SmoothPaletteCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}

		private void ShowPointsCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}

		private void ContourDisplayModeComboBox_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}

		private void ContourColorModeComboBox_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
		{
			UpdateChart();
		}

	}
}
