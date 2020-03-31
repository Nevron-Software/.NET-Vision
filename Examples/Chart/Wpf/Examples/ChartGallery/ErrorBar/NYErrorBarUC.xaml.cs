using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NYErrorBarUC : NExampleBaseUC
	{
		private NChart m_Chart;

		public NYErrorBarUC()
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
				return "Y Error Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a vertical Error Bar chart. Error bars are used to indicate the estimated error in a measurement. The most common error bar plot is one in which the errors are in the Y values. You can use the controls to modify different properties of the error bar series like error whisker size, upper / lower error visibility etc.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Error Bar Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// remove the legend
			nChartControl1.Legends.Clear();

			// setup chart
			m_Chart = nChartControl1.Charts[0];
			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			NLinearScaleConfigurator linearScale = m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator as NLinearScaleConfigurator;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series.Add(SeriesType.ErrorBar);
			series.DataLabelStyle.Visible = false;
			series.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Visible = true;
			series.MarkerStyle.AutoDepth = false;
			series.MarkerStyle.FillStyle = new NColorFillStyle(DarkOrange);
			series.MarkerStyle.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Depth = new NLength(1.2f, NRelativeUnit.ParentPercentage);

			GenerateData(series);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// init form controls
			ErrorWhiskerSizeScrollBar.Value = series.SizeY.Value / 5.0f;
			ShowLowerErrorCheckBox.IsChecked = series.ShowLowerErrorY;
			ShowUpperErrorCheckBox.IsChecked = series.ShowUpperErrorY;
			LeftAxisRoundToTickCheckBox.IsChecked = true;
			InflateMarginsCheckBox.IsChecked = true;
		}

		private void GenerateData(NErrorBarSeries series)
		{
			series.ClearDataPoints();

			double y = 20.0;
			double p = Random.NextDouble() * 10;

			for (int i = 0; i < 15; i++)
			{
				y = Math.Sin(p + i / 6.0) * 8 + Random.NextDouble();

				series.Values.Add(y);
				series.LowerErrorsY.Add(1 + Random.NextDouble());
				series.UpperErrorsY.Add(1 + Random.NextDouble());
			}
		}

		private void ErrorWhiskerSizeScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];

			series.SizeY = new NLength((float)ErrorWhiskerSizeScrollBar.Value * 5.0f, NRelativeUnit.ParentPercentage);

			nChartControl1.Refresh();
		}

		private void ShowUpperErrorCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowUpperErrorY = (bool)ShowUpperErrorCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void ShowLowerErrorCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowLowerErrorY = (bool)ShowLowerErrorCheckBox.IsChecked;
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
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;

			linearScale.RoundToTickMin = (bool)LeftAxisRoundToTickCheckBox.IsChecked;
			linearScale.RoundToTickMax = (bool)LeftAxisRoundToTickCheckBox.IsChecked;

			nChartControl1.Refresh();
		}

		private void GenerateDataButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			GenerateData(series);
			nChartControl1.Refresh();
		}
	}
}
