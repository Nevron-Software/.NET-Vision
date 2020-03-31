using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Dom;
using Nevron.Examples.Framework.WebForm;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NStockCandleUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithColorNames(UpCandleColorDropDownList, KnownColor.White);
				WebExamplesUtilities.FillComboWithColorNames(UpCandleLineColorDropDownList, KnownColor.Black);
				WebExamplesUtilities.FillComboWithColorNames(DownCandleColorDropDownList, KnownColor.Crimson);
				WebExamplesUtilities.FillComboWithColorNames(DownCandleLineColorDropDownList, KnownColor.Crimson);
				WebExamplesUtilities.FillComboWithColorNames(HowLowLineColorDropDownList, KnownColor.Black);

				ShowHiLowLineCheckBox.Checked = true;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel title = nChartControl1.Labels.AddHeader("Candle Stock Chart");
			title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;

			// no legend
			nChartControl1.Legends.Clear();

			// setup chart
			NChart chart = nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;

			// setup X axis
			NValueTimelineScaleConfigurator scaleX = new NValueTimelineScaleConfigurator();
			scaleX.FirstRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.FirstRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(225, 225, 225));
			scaleX.FirstRow.UseGridStyle = true;
			scaleX.FirstRow.InnerTickStyle.Visible = false;
			scaleX.SecondRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.SecondRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(215, 215, 215));
			scaleX.SecondRow.UseGridStyle = true;
			scaleX.SecondRow.InnerTickStyle.Visible = false;
			scaleX.ThirdRow.GridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleX.ThirdRow.GridStyle.LineStyle = new NStrokeStyle(1, Color.FromArgb(205, 205, 205));
			scaleX.ThirdRow.UseGridStyle = true;
			scaleX.ThirdRow.InnerTickStyle.Visible = false;
			// calendar
			NWeekDayRule wdr = new NWeekDayRule(WeekDayBit.All);
			wdr.Saturday = false;
			wdr.Sunday = false;
			scaleX.Calendar.Rules.Add(wdr);
			scaleX.EnableCalendar = true;
			// set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup Y axis
			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator;
			scaleY.OuterMajorTickStyle.Length = new NLength(3, NGraphicsUnit.Point);
			scaleY.InnerMajorTickStyle.Visible = false;

			NFillStyle stripFill = new NColorFillStyle(Color.FromArgb(234, 233, 237));
			NScaleStripStyle stripStyle = new NScaleStripStyle(stripFill, null, true, 1, 0, 1, 1);
			stripStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			stripStyle.Interlaced = true;
			scaleY.StripStyles.Add(stripStyle);

			// setup stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.DataLabelStyle.Visible = false;
			stock.CandleWidth = new NLength(1.2f, NRelativeUnit.ParentPercentage);
			stock.UseXValues = true;
			stock.InflateMargins = true;
			stock.DownFillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(DownCandleColorDropDownList));
			stock.UpFillStyle = new NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(UpCandleColorDropDownList));
			stock.DownStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(DownCandleLineColorDropDownList);
			stock.UpStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(UpCandleLineColorDropDownList);
			stock.HighLowStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(HowLowLineColorDropDownList);
			stock.ShowHighLow = ShowHiLowLineCheckBox.Checked;

			// add some stock items
			const int count = 40;
			GenerateOHLCData(stock, count);
			FillStockDates(stock, count);

			// apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, null);
		}

		private void GenerateOHLCData(NStockSeries s, int nCount)
		{
			double prevclose = 300;
			double open, high, low, close;

			s.ClearDataPoints();

			for(int nIndex = 0; nIndex < nCount; nIndex++)
			{
				open = prevclose;

				if(prevclose < 25 || Random.NextDouble()  > 0.5)
				{
					// upward price change
					close = open + (2 + (Random.NextDouble() * 20));
					high = close + (Random.NextDouble() * 10);
					low = open - (Random.NextDouble() * 10);
				}
				else
				{
					// downward price change
					close = open - (2 + (Random.NextDouble() * 20));
					high = open + (Random.NextDouble() * 10);
					low = close - (Random.NextDouble() * 10);
				}

				if(low < 1){ low = 1; }

				prevclose = close;

				s.OpenValues.Add(open);
				s.HighValues.Add(high);
				s.LowValues.Add(low);
				s.CloseValues.Add(close);
			}
		}
	}
}