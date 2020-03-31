using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardSmoothLineUC : NExampleBaseUC
	{
		private const int nValuesCount = 8;

		public NStandardSmoothLineUC()
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
				return "Smooth Line";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a 2D Smooth Line chart.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Smooth Line Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// no legend
			nChartControl1.Legends.Clear();

			// setup the chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);

			// add interlaced stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// add the line
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series.Add(SeriesType.SmoothLine);
			line.Name = "Smooth Line";
			line.Legend.Mode = SeriesLegendMode.Series;
			line.UseXValues = false;
			line.UseZValues = false;
			line.DataLabelStyle.Visible = false;
			line.MarkerStyle.Visible = true;
			line.MarkerStyle.PointShape = PointShape.Cylinder;
			line.MarkerStyle.AutoDepth = false;
			line.MarkerStyle.Width = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Height = new NLength(1.4f, NRelativeUnit.ParentPercentage);
			line.MarkerStyle.Depth = new NLength(1.4f, NRelativeUnit.ParentPercentage);

			GenreateYValues(nValuesCount);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			// apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
			styleSheet.Apply(nChartControl1.Document);

			// init form controls
			InflateMarginsCheckBox.IsChecked = true;
			LeftAxisRoundToTickCheckBox.IsChecked = true;
		}

		private void GenreateYValues(int nCount)
		{
			NChart chart = nChartControl1.Charts[0];
			NSeries series = (NSeries)chart.Series[0];

			series.Values.Clear();

			for (int i = 0; i < nCount; i++)
			{
				series.Values.Add(Random.NextDouble() * 20);
			}
		}

		private void InflateMarginsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];
			NSmoothLineSeries line = (NSmoothLineSeries)chart.Series[0];

			line.InflateMargins = (bool)InflateMarginsCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void LeftAxisRoundToTickCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NChart chart = nChartControl1.Charts[0];

			NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			standardScale.RoundToTickMin = (bool)LeftAxisRoundToTickCheckBox.IsChecked;
			standardScale.RoundToTickMax = (bool)LeftAxisRoundToTickCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

	}
}
