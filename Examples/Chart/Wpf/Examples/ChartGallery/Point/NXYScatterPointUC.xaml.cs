using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NXYScatterPointUC : NExampleBaseUC
	{
		public NXYScatterPointUC()
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
				return "XY Scatter Point";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "XY Scatter point charts are created by instructing the point series to use custom x values for the data points. The X axis is in numeric scale mode.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Scatter Point Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// configure the chart
			NChart chart = nChartControl1.Charts[0];

			// setup X axis
			NLinearScaleConfigurator scaleX = new NLinearScaleConfigurator();
			scaleX.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY;

			// add a point series
			NPointSeries point = (NPointSeries)chart.Series.Add(SeriesType.Point);
			point.Name = "Point Series";
			point.DataLabelStyle.Visible = false;
			point.FillStyle = new NColorFillStyle(Color.FromArgb(160, DarkOrange));
			point.BorderStyle.Width = new NLength(0);
			point.Size = new NLength(1, NRelativeUnit.ParentPercentage);
			point.PointShape = PointShape.Ellipse;
			point.UseXValues = true;

			GenerateXYData(point);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// init form controls
			AxesRoundToTickCheckBox.IsChecked = true;
			InflateMarginsCheckBox.IsChecked = true;
		}

		private void GenerateXYData(NPointSeries series)
		{
			series.ClearDataPoints();

			for (int i = 0; i < 1000; i++)
			{
				double u1 = Random.NextDouble();
				double u2 = Random.NextDouble();

				if (u1 == 0)
					u1 += 0.0001;

				if (u2 == 0)
					u2 += 0.0001;

				double z0 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
				double z1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);

				series.XValues.Add(z0);
				series.Values.Add(z1);
			}
		}

		private void InflateMarginsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NSeries series = (NSeries)nChartControl1.Charts[0].Series[0];
			series.InflateMargins = (bool)InflateMarginsCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void AxesRoundToTickCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			NStandardScaleConfigurator linearScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator;
			linearScale.RoundToTickMin = (bool)AxesRoundToTickCheckBox.IsChecked;
			linearScale.RoundToTickMax = (bool)AxesRoundToTickCheckBox.IsChecked;

			linearScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.RoundToTickMin = (bool)AxesRoundToTickCheckBox.IsChecked;
			linearScale.RoundToTickMax = (bool)AxesRoundToTickCheckBox.IsChecked;

			nChartControl1.Refresh();

		}

		private void NewDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			NPointSeries point = (NPointSeries)nChartControl1.Charts[0].Series[0];
			GenerateXYData(point);
			nChartControl1.Refresh();		
		}
	}
}
