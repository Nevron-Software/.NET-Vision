using Nevron.Chart;
using Nevron.Dom;
using Nevron.GraphicsCore;
using System;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NPointAndFigureUC : NExampleBaseUC
	{
		private NPointAndFigureSeries m_PointAndFigure;

		public NPointAndFigureUC()
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
				return "Point and Figure";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "Point and Figure charts display series of columns that are made up of 'X' or 'O' signs. A column of X's represents an uptrend, while a column of O's represents a downtrend. The charts ignore the time factor and focus on price movements. Point and Figure charts are used to identify support levels, resistance levels and chart patterns.";
			}
		}

		/// <summary>
		/// Called to initialize the example
		/// </summary>
		/// <param name="chartControl"></param>
		public override void Create()
		{
			// remove all legends
			nChartControl1.Legends.Clear();

			// set a chart title
			NLabel title = new NLabel("Point and Figure");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			const int nInitialBoxSize = 5;

			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup X axis
			NPriceScaleConfigurator priceConfigurator = new NPriceScaleConfigurator();
			priceConfigurator.LabelValueFormatter = new NDateTimeValueFormatter(DateTimeValueFormat.Date);
			priceConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount;
			priceConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);
			priceConfigurator.MaxTickCount = 8;

			NNumericRangeSamplerProvider provider = new NNumericRangeSamplerProvider();
			provider.SamplingMode = SamplingMode.CustomStep;
			provider.CustomStep = 1;
			provider.UseOrigin = true;
			provider.Origin = -0.5;
			priceConfigurator.MajorGridStyle.RangeSamplerProvider = provider;

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorTickMode = MajorTickMode.CustomStep;
			scaleY.CustomStep = nInitialBoxSize;
			scaleY.OuterMajorTickStyle.Width = new NLength(0);
			scaleY.InnerMajorTickStyle.Width = new NLength(0);
			scaleY.AutoMinorTicks = true;
			scaleY.MinorTickCount = 1;
			scaleY.RoundToTickMin = false;
			scaleY.RoundToTickMax = false;
			scaleY.MajorGridStyle.LineStyle.Width = new NLength(0);
			scaleY.MinorGridStyle.LineStyle.Width = new NLength(1);
			scaleY.MinorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };

			float[] highValues = new float[20] { 21.3F, 42.4F, 11.2F, 65.7F, 38.0F, 71.3F, 49.54F, 83.7F, 13.9F, 56.12F, 27.43F, 23.1F, 31.0F, 75.4F, 9.3F, 39.12F, 10.0F, 44.23F, 21.76F, 49.2F };
			float[] lowValues = new float[20] { 12.1F, 14.32F, 8.43F, 36.0F, 13.5F, 47.34F, 24.54F, 68.11F, 6.87F, 23.3F, 12.12F, 14.54F, 25.0F, 37.2F, 3.9F, 23.11F, 1.9F, 14.0F, 8.23F, 34.21F };

			// setup Point & Figure series
			m_PointAndFigure = (NPointAndFigureSeries)chart.Series.Add(SeriesType.PointAndFigure);
			m_PointAndFigure.UseXValues = true;

			// fill data
			m_PointAndFigure.HighValues.AddRange(highValues);
			m_PointAndFigure.LowValues.AddRange(lowValues);

			DateTime dt = new DateTime(2022, 1, 1);

			for (int i = 0; i < 20; i++)
			{
				m_PointAndFigure.XValues.Add(dt);
				dt = dt.AddDays(1);
			}

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			NExampleHelpers.FillComboWithValues(BoxSizeComboBox, 1, 10, 1);
			BoxSizeComboBox.SelectedIndex = nInitialBoxSize + 1;

			NExampleHelpers.FillComboWithValues(ReversalAmountComboBox, 1, 10, 1);
			ReversalAmountComboBox.SelectedIndex = 3;
		}

		private void ProportionalXCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				m_PointAndFigure.ProportionalX = (bool)ProportionalXCheckBox.IsChecked;
				nChartControl1.Refresh();
			}
		}

		private void ProportionalYCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				m_PointAndFigure.ProportionalY = (bool)ProportionalYCheckBox.IsChecked;
				nChartControl1.Refresh();
			}
		}

		private void BoxSizeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				double dBoxSize = BoxSizeComboBox.SelectedIndex + 1;

				NChart chart = nChartControl1.Charts[0];
				m_PointAndFigure.BoxSize = dBoxSize;

				NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
				scaleY.CustomStep = dBoxSize;

				nChartControl1.Refresh();
			}
		}

		private void ReversalAmountComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (m_PointAndFigure != null)
			{
				m_PointAndFigure.ReversalAmount = ReversalAmountComboBox.SelectedIndex + 1;
				nChartControl1.Refresh();
			}
		}
	}
}
