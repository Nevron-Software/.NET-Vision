using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Chart.Functions;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NFinancialChartUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				CandleStyleDropDownList.Items.Add("Candle");
				CandleStyleDropDownList.Items.Add("Stick");
				CandleStyleDropDownList.SelectedIndex = 0;
			}

			const int nNumberOfWeeks = 20;
			const int nWorkDaysInWeek = 5;
			const int nTotalWorkDays = nNumberOfWeeks * nWorkDaysInWeek;

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set chart title
			NLabel title = nChartControl1.Labels.AddHeader("Financial Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
			title.ContentAlignment = ContentAlignment.BottomCenter;
			title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(12, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(84, NRelativeUnit.ParentPercentage));
			chart.Height = 30;

			// setup y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			scaleY.MajorGridStyle.LineStyle.Color = Color.Gray;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };

            // add interlaced stripe
            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.StripStyles.Add(stripStyle);

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

			// create a line series for the simple moving average
			NLineSeries lineSMA = (NLineSeries)chart.Series.Add(SeriesType.Line);
			lineSMA.Name = "SMA(20)";
			lineSMA.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			lineSMA.DataLabelStyle.Visible = false;
			lineSMA.BorderStyle.Color = Color.DarkOrange;
			lineSMA.UseXValues = true;

			// create the stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.Name = "Stock Data";
			stock.Legend.Mode = SeriesLegendMode.None;
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Bar;
			stock.CandleWidth = new NLength(2, NGraphicsUnit.Point);
			stock.InflateMargins = true;
			stock.UseXValues = true;
			stock.UpFillStyle = new NColorFillStyle(Green);
			stock.UpStrokeStyle.Color = Color.Black;
			stock.DownFillStyle = new NColorFillStyle(DarkOrange);
			stock.DownStrokeStyle.Color = Color.Black;

			// add the bollinger bands as high low area
			NHighLowSeries highLow = (NHighLowSeries)chart.Series.Add(SeriesType.HighLow);
			highLow.Name = "BB(20, 2)";
			highLow.Legend.TextStyle.FontStyle.EmSize = new NLength(8, NGraphicsUnit.Point);
			highLow.DataLabelStyle.Visible = false;
			highLow.HighFillStyle = new NColorFillStyle(Color.FromArgb(80, 130, 134, 168));
			highLow.HighBorderStyle.Width = new NLength(0, NGraphicsUnit.Pixel);
			highLow.UseXValues = true;

			// generate some stock data
			WebExamplesUtilities.GenerateOHLCData(stock, 400, nTotalWorkDays + 20);
			FillStockDates(stock, nTotalWorkDays + 20);

			// create a function calculator
			NFunctionCalculator fc = new NFunctionCalculator();
			stock.CloseValues.Name = "close";
			fc.Arguments.Add(stock.CloseValues);

			// calculate the bollinger bands
			fc.Expression = "BOLLINGER(close; 20; 2)";
			highLow.HighValues = fc.Calculate();

			fc.Expression = "BOLLINGER(close; 20; -2)";
			highLow.LowValues = fc.Calculate();

			// calculate the simple moving average
			fc.Expression = "SMA(close; 20)";
			lineSMA.Values = fc.Calculate();

			// remove data that won't be charted
			stock.HighValues.RemoveRange(0, 20);
			stock.LowValues.RemoveRange(0, 20);
			stock.OpenValues.RemoveRange(0, 20);
			stock.CloseValues.RemoveRange(0, 20);
			stock.XValues.RemoveRange(0, 20);

			highLow.HighValues.RemoveRange(0, 20);
			highLow.LowValues.RemoveRange(0, 20);
            highLow.XValues = (NDataSeriesDouble)stock.XValues.Clone();

			lineSMA.Values.RemoveRange(0, 20);
            lineSMA.XValues = (NDataSeriesDouble)stock.XValues.Clone();

			stock.CandleStyle = (CandleStyle)CandleStyleDropDownList.SelectedIndex;
			lineSMA.Visible = SMACheckBox.Checked;
			highLow.Visible = SBBCheckBox.Checked;
		}
	}
}
