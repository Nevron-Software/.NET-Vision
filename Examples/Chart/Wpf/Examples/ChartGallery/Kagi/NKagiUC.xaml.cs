using System;
using System.Drawing;
using Nevron.Chart;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Chart.Wpf
{
	/// <summary>
	/// 
	/// </summary>
	public partial class NKagiUC : NExampleBaseUC
	{
		public NKagiUC()
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
				return "Kagi";
			}
		}

		/// <summary>
		/// Gets the description of this example
		/// </summary>
		public override string Description
		{
			get
			{
				return "Kagi charts display series of vertical lines to illustrate general levels of supply and demand for certain assets. The thickness and direction of the lines are dependent on the price action. Thick lines are drawn when the price breaks above the previous high price and is interpreted as an increase in demand. Thin lines are used to represent increased supply when the price falls below the previous low. Kagi charts ignore the passage of time.";
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
			NLabel title = nChartControl1.Labels.AddHeader("Kagi Chart");
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

			// setup Kagi series
			NKagiSeries kagi = (NKagiSeries)chart.Series.Add(SeriesType.Kagi);
			kagi.UpStrokeStyle.Color = Color.MidnightBlue;
			kagi.DownStrokeStyle.Color = Color.MidnightBlue;
			kagi.UseXValues = true;

			GenerateData(kagi);

			// apply layout
			ConfigureStandardLayout(chart, title, null);

			ReversalAmountComboBox.Items.Add("0.5");
			ReversalAmountComboBox.Items.Add("1");
			ReversalAmountComboBox.Items.Add("2"); 
			ReversalAmountComboBox.Items.Add("1%");
			ReversalAmountComboBox.Items.Add("2%"); 
			ReversalAmountComboBox.Items.Add("5%");
			ReversalAmountComboBox.SelectedIndex = 0;
			ReversalAmountComboBox_SelectionChanged(null, null);
		}

		private void GenerateData(NKagiSeries series)
		{
			NStockDataGenerator dataGenerator = new NStockDataGenerator(new NRange1DD(50, 350), 0.002, 2);
			dataGenerator.Reset();

			DateTime dt = new DateTime(2022, 1, 1);

			for (int i = 0; i < 100; i++)
			{
				series.Values.Add(dataGenerator.GetNextValue());
				series.XValues.Add(dt);

				dt = dt.AddDays(1);
			}
		}

		private void ReversalAmountComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			NKagiSeries kagi = (NKagiSeries)nChartControl1.Charts[0].Series[0];

			switch (ReversalAmountComboBox.SelectedIndex)
			{
				case 0:
					kagi.ReversalAmount = 0.5;
					kagi.ReversalAmountInPercents = false;
					break;

				case 1:
					kagi.ReversalAmount = 1;
					kagi.ReversalAmountInPercents = false;
					break;

				case 2:
					kagi.ReversalAmount = 2;
					kagi.ReversalAmountInPercents = false;
					break;

				case 3:
					kagi.ReversalAmount = 1;
					kagi.ReversalAmountInPercents = true;
					break;

				case 4:
					kagi.ReversalAmount = 2;
					kagi.ReversalAmountInPercents = true;
					break;

				case 5:
					kagi.ReversalAmount = 5;
					kagi.ReversalAmountInPercents = true;
					break;
			}

			nChartControl1.Refresh();
		}
	}
}
