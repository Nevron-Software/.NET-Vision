using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NThreeLineBreakUC : NExampleBaseUC
	{
		private NThreeLineBreakSeries m_ThreeLineBreak;

		public NThreeLineBreakUC()
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
				return "Three Line Break";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "Three Line Break charts display a series of vertical boxes (\"lines\") that are based on changes in prices. A new rising line is drawn if the closing price is higher than the previous one. A new falling line is drawn if the closing price is lower than the previous one. If a rally or a sell-off is powerful enough to form several consecutive lines with the same direction, then prices must reverse by the extreme price of the last several lines in order to create a new line. Usually three consecutive lines are used for the reversal criterion, hence the name Three Line Break. As with Kagi, Point and Figure, and Renko charts, Three Line Break charts ignore the passage of time.";
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
			NLabel title = new NLabel("Three Line Break");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);

			NChart chart = nChartControl1.Charts[0];

			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			// add interlace stripe
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			scaleY.StripStyles.Add(stripStyle);

			// setup X axis
			NPriceScaleConfigurator priceConfigurator = new NPriceScaleConfigurator();
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);
			priceConfigurator.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator;

			// setup line break series
			m_ThreeLineBreak = new NThreeLineBreakSeries();
			chart.Series.Add(m_ThreeLineBreak);
			m_ThreeLineBreak.UseXValues = true;

			GenerateData(m_ThreeLineBreak);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			NExampleHelpers.FillComboWithValues(BarWidthPercentComboBox, 0, 100, 10);
			BarWidthPercentComboBox.SelectedIndex = 2;

			NExampleHelpers.FillComboWithValues(NumberOfLinesToBreakComboBox, 1, 10, 1);
			NumberOfLinesToBreakComboBox.SelectedIndex = 4;

		}

		private void GenerateData(NThreeLineBreakSeries threeLineBreak)
		{
			NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.002, 2);
			dataGenerator.Reset();

			DateTime dt = new DateTime(2022, 1, 1);

			for (int i = 0; i < 100; i++)
			{
				threeLineBreak.Values.Add(dataGenerator.GetNextValue());
				threeLineBreak.XValues.Add(dt);

				dt = dt.AddDays(1);
			}
		}

		private void NumberOfLinesToBreakComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_ThreeLineBreak.NumberOfLinesToBreak = (int)NumberOfLinesToBreakComboBox.SelectedIndex + 1;
			nChartControl1.Refresh();
		}

		private void BarWidthPercentComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			m_ThreeLineBreak.BoxWidthPercent = BarWidthPercentComboBox.SelectedIndex * 10;
            nChartControl1.Refresh();
		}
	}
}
