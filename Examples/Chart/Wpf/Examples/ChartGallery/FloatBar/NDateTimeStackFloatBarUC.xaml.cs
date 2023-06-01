using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NDateTimeStackFloatBarUC : NExampleBaseUC
	{
		private const int dataPointCount = 5;

		public NDateTimeStackFloatBarUC()
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
				return "DateTime Stack Float Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates Stack Floating Bars with custom DateTime positions over the X axis.Stack Float Bar chart is created by stacking one or more Bar series over a FloatBar series.The bars with positive values are stacked on top of the floating bars, while the ones with negative values are stacked under the floating bars. The positions of the bars over the X axis are determined by the X values of the Float Bar series.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("Date Time Stack Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// add interlaced stripe
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;

			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

			// setup the floatbar series
			NFloatBarSeries floatbar = (NFloatBarSeries)chart.Series.Add(SeriesType.FloatBar);
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Series;
			floatbar.Name = "Floatbar series";
			floatbar.DataLabelStyle.Visible = false;
			floatbar.UseXValues = true;
			floatbar.InflateMargins = true;

			// setup the bar series
			NBarSeries bar1 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar1.Name = "Bar series";
			bar1.MultiBarMode = MultiBarMode.Stacked;
			bar1.DataLabelStyle.Visible = false;

			// setup the bar series
			NBarSeries bar2 = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar2.Name = "Bar series";
			bar2.MultiBarMode = MultiBarMode.Stacked;
			bar2.DataLabelStyle.Visible = false;

			GeneratePosData();
			GenerateXData();

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			nChartControl1.Controller.Tools.Add(new NPanelSelectorTool());
			nChartControl1.Controller.Tools.Add(new NTrackballTool());
		}
		double GetRandValue(double min, double max)
		{
			if (max < min)
			{
				double temp = min;
				min = max;
				max = temp;
			}

			return min + Random.NextDouble() * (max - min);
		}

		double SetRandSign(double val)
		{
			if (Random.NextDouble() > 0.5)
				return val;

			return -val;
		}
		private void GeneratePosData()
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			NBarSeries bar1 = (NBarSeries)nChartControl1.Charts[0].Series[1];
			NBarSeries bar2 = (NBarSeries)nChartControl1.Charts[0].Series[2];

			floatbar.BeginValues.Clear();
			floatbar.EndValues.Clear();
			bar1.Values.Clear();
			bar2.Values.Clear();

			for (int i = 0; i < dataPointCount; i++)
			{
				floatbar.BeginValues.Add(GetRandValue(1, 4));
				floatbar.EndValues.Add(GetRandValue(6, 9));
				bar1.Values.Add(GetRandValue(3, 7));
				bar2.Values.Add(GetRandValue(3, 7));
			}
		}

		private void GeneratePosNegData()
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			NBarSeries bar1 = (NBarSeries)nChartControl1.Charts[0].Series[1];
			NBarSeries bar2 = (NBarSeries)nChartControl1.Charts[0].Series[2];

			floatbar.BeginValues.Clear();
			floatbar.EndValues.Clear();
			bar1.Values.Clear();
			bar2.Values.Clear();

			for (int i = 0; i < dataPointCount; i++)
			{
				floatbar.BeginValues.Add(GetRandValue(-10, 10));
				floatbar.EndValues.Add(SetRandSign(GetRandValue(10, 20)));
				bar1.Values.Add(SetRandSign(GetRandValue(5, 10)));
				bar2.Values.Add(SetRandSign(GetRandValue(5, 10)));
			}
		}

		private void GenerateXData()
		{
			NFloatBarSeries floatbar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];

			floatbar.XValues.Clear();

			// generate X values
			DateTime dt = new DateTime(2022, 5, 24, 11, 0, 0);

			for (int i = 0; i < dataPointCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				floatbar.XValues.Add(dt);
			}
		}
		private void GeneratePositiveDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GeneratePosData();
			nChartControl1.Refresh();
		}

		private void GeneratePositiveNegativeDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GeneratePosData();
			nChartControl1.Refresh();
		}
	}
}
