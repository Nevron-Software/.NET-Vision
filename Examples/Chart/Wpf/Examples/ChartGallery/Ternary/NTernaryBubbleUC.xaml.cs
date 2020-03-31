using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using Nevron.Chart.Windows;
using System;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NTernaryBubbleUC : NExampleBaseUC
	{

		public NTernaryBubbleUC()
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
				return "Ternary Bubble";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates how to create a ternary bubble chart.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			nChartControl1.Panels.Clear();

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Ternary Bubble Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			NLegend legend = new NLegend();
			nChartControl1.Panels.Add(legend);

			// setup chart
			NTernaryChart ternaryChart = new NTernaryChart();
			nChartControl1.Panels.Add(ternaryChart);
			ternaryChart.DisplayOnLegend = legend;

			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryA));
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryB));
			ConfigureAxis(ternaryChart.Axis(StandardAxis.TernaryC));

			// add a bubble series
			NTernaryBubbleSeries bubbleSeries = new NTernaryBubbleSeries();
			ternaryChart.Series.Add(bubbleSeries);
			bubbleSeries.DataLabelStyle.VertAlign = VertAlign.Center;
			bubbleSeries.DataLabelStyle.Visible = false;
			bubbleSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			bubbleSeries.MinSize = new NLength(2.0f, NGraphicsUnit.Point);
			bubbleSeries.MaxSize = new NLength(20, NGraphicsUnit.Point);
			bubbleSeries.Legend.Mode = SeriesLegendMode.DataPoints;
			bubbleSeries.Legend.Format = "<size>";

			Random rand = new Random();
			for (int i = 0; i < 20; i++)
			{
				// will be automatically normalized so that the sum of a, b, c value is 100
				double aValue = rand.Next(100);
				double bValue = rand.Next(100);
				double cValue = rand.Next(100);

				bubbleSeries.AValues.Add(aValue);
				bubbleSeries.BValues.Add(bValue);
				bubbleSeries.CValues.Add(cValue);
				bubbleSeries.Sizes.Add(10 + rand.Next(90));
			}

			// apply layout
			ConfigureStandardLayout(ternaryChart, title, nChartControl1.Legends[0]);
		}
		private void ConfigureAxis(NAxis axis)
		{
			NLinearScaleConfigurator linearScale = axis.ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.FromArgb(25, Color.Beige)), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Ternary, true);
			linearScale.StripStyles.Add(stripStyle);

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Ternary, true);
		}
	}
}
