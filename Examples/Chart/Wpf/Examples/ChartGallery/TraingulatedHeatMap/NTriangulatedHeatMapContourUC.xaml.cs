using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NTriangulatedHeatMapContourUC : NExampleBaseUC
	{
		NTriangulatedHeatMapSeries m_HeatMap;

		public NTriangulatedHeatMapContourUC()
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
                return "The example demonstrates the capabilities of the triangulated heat map series to render annotated contour lines.";
			}
		}
		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Triangulated Heat Map Contour Labels");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
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

			m_HeatMap.ContourLabelStyle.Visible = true;
			m_HeatMap.ContourLabelStyle.AllowLabelToFlip = false;
			m_HeatMap.ContourLabelStyle.TextStyle.BackplaneStyle.Visible = false;
			m_HeatMap.ContourLabelStyle.ClipContour = true;

			GenerateData();
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			ShowContourLabelsCheckBox.IsChecked = true;
			AllowLabelsToFlipCheckBox.IsChecked = false;
			ShowLabelBackgroundCheckBox.IsChecked = false;
			ClipContourCheckBox.IsChecked = true;
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
