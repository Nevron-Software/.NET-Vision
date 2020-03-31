using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NXYErrorBarUC : NExampleBaseUC
	{
		private NChart m_Chart;

		public NXYErrorBarUC()
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
				return "XY Error Bar";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "This example demonstrates a XY Error Bar chart. XY Errors bars indicate the uncertainty in the X and/or Y values. You can use the controls to modify different properties of the error bar series like error whisker size, upper / lower error visibility etc.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("XY Error Bar");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			// remove the legend
			nChartControl1.Legends.Clear();

			m_Chart = nChartControl1.Charts[0];

			// setup axes
			NLinearScaleConfigurator linearScale = new NLinearScaleConfigurator();
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Floor };
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale;

			linearScale = (NLinearScaleConfigurator)m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back, ChartWallType.Left };
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;

			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			stripStyle.SetShowAtWall(ChartWallType.Left, true);
			linearScale.StripStyles.Add(stripStyle);

			m_Chart.Axis(StandardAxis.Depth).Visible = false;

			// add an error bar series
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series.Add(SeriesType.ErrorBar);
			series.DataLabelStyle.Visible = false;
			series.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Visible = true;
			series.MarkerStyle.PointShape = PointShape.Ellipse;
			series.MarkerStyle.AutoDepth = false;
			series.MarkerStyle.FillStyle = new NColorFillStyle(DarkOrange);
			series.MarkerStyle.BorderStyle = new NStrokeStyle(GreyBlue);
			series.MarkerStyle.Width = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Height = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.MarkerStyle.Depth = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			series.ShowLowerErrorX = true;
			series.ShowUpperErrorX = true;
			series.UseXValues = true;

			GenerateData(series);

			// apply layout
			ConfigureStandardLayout(m_Chart, title, null);

			// init form controls
			YErrorWhiskerSizeScrollBar.Value = series.SizeY.Value / 5.0f;
			ShowLowerYErrorCheckBox.IsChecked = series.ShowLowerErrorY;
			ShowUpperYErrorCheckBox.IsChecked = series.ShowUpperErrorY;

			XErrorWhiskerSizeScrollBar.Value = series.SizeX.Value / 5.0f;
			ShowLowerXErrorCheckBox.IsChecked = series.ShowLowerErrorX;
			ShowUpperXErrorCheckBox.IsChecked = series.ShowUpperErrorX;


			LeftAxisRoundToTickCheckBox.IsChecked = true;
			InflateMarginsCheckBox.IsChecked = true;
		}

		void GenerateData(NErrorBarSeries series)
		{
			series.ClearDataPoints();

			double y;
			double x = 50.0;

			for (int i = 0; i < 15; i++)
			{
				y = 20 + Random.NextDouble() * 30;
				x += 2.0 + Random.NextDouble() * 2;

				series.Values.Add(y);
				series.LowerErrorsY.Add(1 + Random.NextDouble());
				series.UpperErrorsY.Add(1 + Random.NextDouble());

				series.XValues.Add(x);
				series.LowerErrorsX.Add(1 + Random.NextDouble());
				series.UpperErrorsX.Add(1 + Random.NextDouble());
			}
		}

		private void YErrorWhiskerSizeScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];

			series.SizeY = new NLength((float)YErrorWhiskerSizeScrollBar.Value * 5.0f, NRelativeUnit.ParentPercentage);

			nChartControl1.Refresh();
		}

		private void ShowUpperYErrorCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowUpperErrorY = (bool)ShowUpperYErrorCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void ShowLowerYErrorCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowLowerErrorY = (bool)ShowLowerYErrorCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void XErrorWhiskerSizeScrollBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];

			series.SizeX = new NLength((float)XErrorWhiskerSizeScrollBar.Value * 5.0f, NRelativeUnit.ParentPercentage);

			nChartControl1.Refresh();
		}

		private void ShowUpperXErrorCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowUpperErrorX = (bool)ShowUpperXErrorCheckBox.IsChecked;
			nChartControl1.Refresh();
		}

		private void ShowLowerXErrorCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			NErrorBarSeries series = (NErrorBarSeries)m_Chart.Series[0];
			series.ShowLowerErrorX = (bool)ShowLowerXErrorCheckBox.IsChecked;
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
