using Nevron.Chart;
using Nevron.GraphicsCore;
using System;
using System.Drawing;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NRenkoUC : NExampleBaseUC
	{
		public NRenkoUC()
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
				return "Renko";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "Renko charts display series of white and black boxes (bricks) to illustrate general price movement and trend reversals. A Renko chart is constructed by placing a brick in the next column once the price surpasses the top or bottom of the previous brick by a predefined amount. White bricks are used when the direction of the trend is up, black bricks are used when the trend is down. All bricks are equal in size. This type of chart helps traders to identify key support/resistance levels.";
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
			NLabel title = nChartControl1.Labels.AddHeader("Renko Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, System.Drawing.FontStyle.Italic);
			title.TextStyle.FillStyle = new NColorFillStyle(GreyBlue);
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			NChart chart = nChartControl1.Charts[0];

			// setup X axis
			NPriceScaleConfigurator priceConfigurator = new NPriceScaleConfigurator();
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0);
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator;

			// setup Y axis
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
			stripStyle.Interlaced = true;
			stripStyle.SetShowAtWall(ChartWallType.Back, true);
			linearScale.StripStyles.Add(stripStyle);

			// setup Renko series
			NRenkoSeries renko = (NRenkoSeries)chart.Series.Add(SeriesType.Renko);
			renko.UseXValues = true;

			GenerateData(renko);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			BoxSizeComboBox.Items.Add("0.5");
			BoxSizeComboBox.Items.Add("1");
			BoxSizeComboBox.Items.Add("2");
			BoxSizeComboBox.Items.Add("2%");
			BoxSizeComboBox.Items.Add("5%");
			BoxSizeComboBox.Items.Add("10%");

			BoxWidthPercentComboBox.Items.Add("50%");
			BoxWidthPercentComboBox.Items.Add("75%");
			BoxWidthPercentComboBox.Items.Add("100%");

			BoxSizeComboBox.SelectedIndex = 1;
			BoxWidthPercentComboBox.SelectedIndex = 2;
		}

		private void GenerateData(NRenkoSeries renko)
		{
			NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.02, 10);
			dataGenerator.Reset();

			DateTime dt = new DateTime(2022, 1, 1);

			for (int i = 0; i < 20; i++)
			{
				renko.Values.Add(dataGenerator.GetNextValue());
				renko.XValues.Add(dt);

				dt = dt.AddDays(1);
			}
		}

		private void BoxSizeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NRenkoSeries renko = (NRenkoSeries)nChartControl1.Charts[0].Series[0];

			switch (BoxSizeComboBox.SelectedIndex)
			{
				case 0:
					renko.BoxSize = 0.5;
					renko.BoxSizeInPercents = false;
					break;

				case 1:
					renko.BoxSize = 1;
					renko.BoxSizeInPercents = false;
					break;

				case 2:
					renko.BoxSize = 2;
					renko.BoxSizeInPercents = false;
					break;

				case 3:
					renko.BoxSize = 2;
					renko.BoxSizeInPercents = true;
					break;

				case 4:
					renko.BoxSize = 5;
					renko.BoxSizeInPercents = true;
					break;

				case 5:
					renko.BoxSize = 10;
					renko.BoxSizeInPercents = true;
					break;
			}

			nChartControl1.Refresh();
		}

		private void BoxWidthPercentComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NRenkoSeries renko = (NRenkoSeries)nChartControl1.Charts[0].Series[0];

			switch (BoxWidthPercentComboBox.SelectedIndex)
			{
				case 0:
					renko.BoxWidthPercent = 50;
					break;

				case 1:
					renko.BoxWidthPercent = 75;
					break;

				case 2:
					renko.BoxWidthPercent = 100;
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
