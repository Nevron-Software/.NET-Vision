using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using Nevron.Dom;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NDateTimeFloatBarUC : NExampleBaseUC
	{
		public NDateTimeFloatBarUC()
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
				return "Date / Time Float Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a Floating Bar chart with custom DateTime values along the X axis.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = new NLabel("DateTime Float Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup Y axis
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, true);

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			stripStyle.Interlaced = true;
			linearScale.StripStyles.Add(stripStyle);

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale;

			// setup x axis
			NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
			dateTimeScale.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale;

			// create the float bar series
			NFloatBarSeries floatBar = new NFloatBarSeries();
			chart.Series.Add(floatBar);
			floatBar.UseXValues = true;
			floatBar.UseZValues = false;
			floatBar.InflateMargins = true;
			floatBar.DataLabelStyle.Visible = false;

			// bar appearance
			floatBar.BorderStyle.Color = Color.Bisque;
			floatBar.ShadowStyle.Type = ShadowType.Solid;
			floatBar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0);

			floatBar.Values.ValueFormatter = new NNumericValueFormatter("0.00");
			floatBar.EndValues.ValueFormatter = new NNumericValueFormatter("0.00");

			// show the begin end values in the legend
			floatBar.Legend.Format = "<begin> - <end>";
			floatBar.Legend.Mode = SeriesLegendMode.DataPoints;

			GenerateData(floatBar);

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
			styleSheet.Apply(nChartControl1.Document);
		}
		private void GenerateData(NFloatBarSeries floatBar)
		{
			const int nCount = 6;

			floatBar.Values.Clear();
			floatBar.EndValues.Clear();
			floatBar.XValues.Clear();

			// generate Y values
			for (int i = 0; i < nCount; i++)
			{
				double dBeginValue = Random.NextDouble() * 5;
				double dEndValue = dBeginValue + 2 + Random.NextDouble();
				floatBar.Values.Add(dBeginValue);
				floatBar.EndValues.Add(dEndValue);
			}

			// generate X values
			DateTime dt = new DateTime(2007, 5, 24, 11, 0, 0);

			for (int i = 0; i < nCount; i++)
			{
				dt = dt.AddHours(12 + Random.NextDouble() * 60);

				floatBar.XValues.Add(dt);
			}
		}

		private void GenerateDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			NFloatBarSeries floatBar = (NFloatBarSeries)nChartControl1.Charts[0].Series[0];
			GenerateData(floatBar);
			nChartControl1.Refresh();
		}
	}
}
