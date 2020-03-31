using Nevron.Chart;
using Nevron.GraphicsCore;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NStandardBar3DUC : NExampleBaseUC
	{
		public NStandardBar3DUC()
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
				return "Bar 3D";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a standard 3D bar chart.\r\n" +
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
			NLabel title = new NLabel("3D Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);

			// configure chart
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.Enable3D = true;
			chart.Width = 65;
			chart.Height = 40;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1);
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft);

			// add interlaced stripe
			NLinearScaleConfigurator linearScale = chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			// setup a bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar Series";
			bar.DataLabelStyle.Visible = true;
			bar.HasBottomEdge = false;

			// add some data to the bar series
			bar.AddDataPoint(new NDataPoint(18, "C++"));
			bar.AddDataPoint(new NDataPoint(15, "Ruby"));
			bar.AddDataPoint(new NDataPoint(21, "Python"));
			bar.AddDataPoint(new NDataPoint(23, "Java"));
			bar.AddDataPoint(new NDataPoint(27, "Javascript"));
			bar.AddDataPoint(new NDataPoint(29, "C#"));
			bar.AddDataPoint(new NDataPoint(26, "PHP"));

			// apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends[0]);

			// init form controls
			NExampleHelpers.FillComboWithEnumValues(BarStyleComboBox, typeof(BarShape));
			BarStyleComboBox.SelectedIndex = 0;

			NExampleHelpers.FillComboWithValues(BarEdgePercentComboBox, 0, 50, 10);
			BarEdgePercentComboBox.SelectedIndex = 5;

			HasTopEdgeCheckBox.IsChecked = bar.HasTopEdge;
			HasBottomEdgeCheckBox.IsChecked = bar.HasBottomEdge;
			DifferentFIllStylesCheckBox.IsChecked = true;
			DifferentFillStylesCheckBox_Checked(null, null);
		}

		private void HasTopEdgeCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.HasTopEdge = (bool)HasTopEdgeCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void HasBottomEdgeCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.HasBottomEdge = (bool)HasBottomEdgeCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void DifferentFillStylesCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];

			if ((bool)DifferentFIllStylesCheckBox.IsChecked)
			{
				bar.Legend.Mode = SeriesLegendMode.DataPoints;

				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
				styleSheet.Apply(nChartControl1.Document);
			}
			else
			{
				bar.Legend.Mode = SeriesLegendMode.Series;

				NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh);
				styleSheet.Apply(nChartControl1.Document);
			}

			nChartControl1.Refresh();
		}

		private void BarEdgePercentComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.BarEdgePercent = BarEdgePercentComboBox.SelectedIndex * 10;
			nChartControl1.Refresh();
		}

		private void BarStyleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NBarSeries bar = (NBarSeries)nChartControl1.Charts[0].Series[0];
			bar.BarShape = (BarShape)BarStyleComboBox.SelectedIndex;

			bool bHasEdge = (bar.BarShape == BarShape.SmoothEdgeBar || bar.BarShape == BarShape.CutEdgeBar);
			BarEdgePercentComboBox.IsEnabled = bHasEdge;
			HasTopEdgeCheckBox.IsEnabled = bHasEdge;
			HasBottomEdgeCheckBox.IsEnabled = bHasEdge;

			nChartControl1.Refresh();
		}
	}
}
