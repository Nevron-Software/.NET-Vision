using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using Nevron.Examples.Framework.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.Functions;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NRangeIndicatorsUC : NExampleUC 
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddHeader("Bollinger Bands /\n Envelopes");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.LightModel.EnableLighting = false;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Wall(ChartWallType.Floor).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Height = 40;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(25, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage), 
				new NLength(73, NRelativeUnit.ParentPercentage));

			// setup X axis
			NRangeTimelineScaleConfigurator scaleX = new NRangeTimelineScaleConfigurator();
			scaleX.FirstRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.FirstRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(225, 225, 225));
			scaleX.FirstRow.UseGridStyle = true;
			scaleX.SecondRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.SecondRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(215, 215, 215));
			scaleX.SecondRow.UseGridStyle = true;
			scaleX.ThirdRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.ThirdRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(205, 205, 205));
			scaleX.ThirdRow.UseGridStyle = true;
			// calendar
			NWeekDayRule wdr = new NWeekDayRule(WeekDayBit.All);
			wdr.Saturday = false;
			wdr.Sunday = false;
			scaleX.Calendar.Rules.Add(wdr);
			scaleX.EnableCalendar = true;
			// set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Y axis
			NAxis axis = chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScale = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			linearScale.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			linearScale.InnerMajorTickStyle.Length = new NLength(0);

			// Add line series for the upper band
			NLineSeries lineUpper = (NLineSeries)chart.Series.Add(SeriesType.Line);
			lineUpper.DataLabelStyle.Visible = false;
			lineUpper.BorderStyle.Color = Color.Green;

			// Add line series for lower band
			NLineSeries lineLower = (NLineSeries)chart.Series.Add(SeriesType.Line);
			lineLower.DataLabelStyle.Visible = false;
			lineLower.BorderStyle.Color = Color.Green;

			// Add line series for Simple Moving Average
			NLineSeries lineSMA = (NLineSeries)chart.Series.Add(SeriesType.Line);
			lineSMA.DataLabelStyle.Visible = false;
			lineSMA.BorderStyle.Color = Color.Orange;
			lineSMA.Name = "Simple Moving Average";

			Color color1 = Color.FromArgb(100, 100, 150);
			Color color2 = Color.FromArgb(200, 120, 120);

			// Setup the stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Stick;
			stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			stock.UpStrokeStyle.Color = color1;
			stock.DownStrokeStyle.Color = color2;
			stock.Legend.Mode = SeriesLegendMode.None;
			stock.CloseValues.Name = "close";
			stock.UseXValues = true;
			stock.InflateMargins = true;

			// Add arguments
            NFunctionCalculator upperCalculator = new NFunctionCalculator();
            NFunctionCalculator lowerCalculator = new NFunctionCalculator();
            NFunctionCalculator SMACalculator = new NFunctionCalculator();

			upperCalculator.Arguments.Add(stock.CloseValues);
			lowerCalculator.Arguments.Add(stock.CloseValues);
			SMACalculator.Arguments.Add(stock.CloseValues);

			GenerateData(stock);

			// form controls
			if (!IsPostBack)
			{
				FunctionDropDownList.Items.Add("Bollinger Bands");
				FunctionDropDownList.Items.Add("Envelopes");
				FunctionDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(PeriodDropDownList, 0, 100, 10);
				PeriodDropDownList.SelectedIndex = 2;

				WebExamplesUtilities.FillComboWithValues(DeviationDropDownList, 0, 20, 1);
				DeviationDropDownList.SelectedIndex = 2;

				ShowPricesCheckBox.Checked = true;
				ShowSMACheckBox.Checked = true;
			}

            UpdateExpressions(lineUpper, lineLower, upperCalculator, lowerCalculator, SMACalculator);
			CalculateFunctions(stock, lineUpper, lineLower, lineSMA, upperCalculator, lowerCalculator, SMACalculator);
			stock.Visible = ShowPricesCheckBox.Checked;
			lineSMA.Visible = ShowSMACheckBox.Checked;
		}

		private void GenerateData(NStockSeries stock)
		{
			const double initialPrice = 500;
			const int numDataPoits = 200;

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits);
			FillStockDates(stock, numDataPoits, new DateTime(2010, 1, 11));
		}

        private void UpdateExpressions(NSeries lineUpper, NSeries lineLower, NFunctionCalculator upperCalculator,
            NFunctionCalculator lowerCalculator, NFunctionCalculator SMACalculator)
		{
			int nPeriod = PeriodDropDownList.SelectedIndex * 10;
			int nDeviation = DeviationDropDownList.SelectedIndex;

			SMACalculator.Expression = String.Format("SMA(close; {0})", nPeriod);

			if(FunctionDropDownList.SelectedIndex == 0)
			{
				lineUpper.Name = "Bollinger Band - Upper";
				lineLower.Name = "Bollinger Band - Lower";

				upperCalculator.Expression = String.Format("BOLLINGER(close; {0}; {1})", nPeriod, nDeviation);
				lowerCalculator.Expression = String.Format("BOLLINGER(close; {0}; {1})", nPeriod, -nDeviation);
			}
			else
			{
				lineUpper.Name = "Envelopes - Upper Line";
				lineLower.Name = "Envelopes - Lower Line";

				upperCalculator.Expression = String.Format("ENV(close; {0}; {1})", nPeriod, nDeviation);
				lowerCalculator.Expression = String.Format("ENV(close; {0}; {1})", nPeriod, -nDeviation);
			}
		}

        private void CalculateFunctions(NStockSeries stock, NLineSeries lineUpper, NLineSeries lineLower, NLineSeries lineSMA, NFunctionCalculator upperCalculator,
            NFunctionCalculator lowerCalculator, NFunctionCalculator SMACalculator)
		{
			lineUpper.Values = upperCalculator.Calculate();
			lineLower.Values = lowerCalculator.Calculate();
			lineSMA.Values = SMACalculator.Calculate();

            lineUpper.XValues = (NDataSeriesDouble)stock.XValues.Clone();
            lineUpper.UseXValues = true;
            lineLower.XValues = (NDataSeriesDouble)stock.XValues.Clone();
            lineLower.UseXValues = true;
            lineSMA.XValues = (NDataSeriesDouble)stock.XValues.Clone();
            lineSMA.UseXValues = true;
		}
	}
}
