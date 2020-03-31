using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.Collections;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NBoxAndWhiskers2DUC : NExampleBaseUC
	{
		private NChart m_Chart;

		public NBoxAndWhiskers2DUC()
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
				return "Box and Whiskers";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "Box and whiskers plots are very helpful in interpreting the distribution of data. Each box and whiskers item represents a set of values and displays statistical information for it like minimum, maximum and median values, upper and lower quartiles, outliers and optionally a mean value.\r\n" +
						"Use the controls on the right to modify some comonnly used properties.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Box and Whiskers");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// remove the legend
			nChartControl1.Legends.Clear();

			// setup the chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)m_Chart.Series.Add(SeriesType.BoxAndWhiskers);
			series.FillStyle = new NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant4, LightOrange, DarkOrange);
			series.DataLabelStyle.Visible = false;
			series.MedianStrokeStyle = new NStrokeStyle(Color.Indigo);
			series.AverageStrokeStyle = new NStrokeStyle(1, Color.DarkRed, LinePattern.Dot);
			series.OutliersBorderStyle = new NStrokeStyle(BeautifulRed);
			series.OutliersFillStyle = new NColorFillStyle(Red);

			GenerateData(series, 7);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			BoxWidthScrollBar.Value = 0.7;
			WhiskersWidthScrollBar.Value = 0.5;
			LeftAxisRoundToTickCheckBox.IsChecked = true;
			InflateMarginsCheckBox.IsChecked = true;
		}

		private void GenerateData(NBoxAndWhiskersSeries series, int nCount)
		{
			series.ClearDataPoints();

			for (int i = 0; i < nCount; i++)
			{
				double boxLower = 1000 + Random.NextDouble() * 200;
				double boxUpper = boxLower + 200 + Random.NextDouble() * 200;
				double whiskersLower = boxLower - (20 + Random.NextDouble() * 300);
				double whiskersUpper = boxUpper + (20 + Random.NextDouble() * 300);

				double IQR = (boxUpper - boxLower);
				double median = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5;
				double average = boxLower + IQR * 0.25 + Random.NextDouble() * IQR * 0.5;

				series.UpperBoxValues.Add(boxUpper);
				series.LowerBoxValues.Add(boxLower);
				series.UpperWhiskerValues.Add(whiskersUpper);
				series.LowerWhiskerValues.Add(whiskersLower);
				series.MedianValues.Add(median);
				series.AverageValues.Add(average);

				int outliersCount = Random.Next(5);

				NDoubleList outliers = new NDoubleList();

				for (int k = 0; k < outliersCount; k++)
				{
					double dOutlier = 0;

					if (Random.NextDouble() > 0.5)
					{
						dOutlier = boxUpper + IQR * 1.5 + Random.NextDouble() * 100;
					}
					else
					{
						dOutlier = boxLower - IQR * 1.5 - Random.NextDouble() * 100;
					}

					outliers.Add(dOutlier);
				}

				series.OutlierValues.Add(outliers);
			}
		}

		private void BoxWidthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)nChartControl1.Charts[0].Series[0];

			series.BoxWidthPercent = (float)BoxWidthScrollBar.Value * 100.0f;

			nChartControl1.Refresh();
		}

		private void WhiskersWidthScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)nChartControl1.Charts[0].Series[0];

			series.WhiskersWidthPercent = (float)WhiskersWidthScrollBar.Value * 100.0f;

			nChartControl1.Refresh();
		}

		private void InflateMarginsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NSeries series = (NSeries)m_Chart.Series[0];
			series.InflateMargins = (bool)InflateMarginsCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void LeftAxisRoundToTickCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			linearScale.RoundToTickMin = (bool)LeftAxisRoundToTickCheckBox.IsChecked;
			linearScale.RoundToTickMax = (bool)LeftAxisRoundToTickCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void GenerateDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			NBoxAndWhiskersSeries series = (NBoxAndWhiskersSeries)m_Chart.Series[0];
			GenerateData(series, 7);
			nChartControl1.Refresh();
		}
	}
}
