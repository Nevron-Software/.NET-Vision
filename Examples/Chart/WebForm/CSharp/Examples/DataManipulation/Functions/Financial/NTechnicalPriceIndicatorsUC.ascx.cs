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
	public partial class NTechnicalPriceIndicatorsUC : NExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddFooter("Technical Price Indicators");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

			SetupTimeScale(chart.Axis(StandardAxis.PrimaryX));
			SetupStockChart(chart);
			SetupIndicatorChart(chart);

			NStockSeries stock = (NStockSeries)chart.Series[0];
			NLineSeries line = (NLineSeries)chart.Series[1];

			// generate data
			GenerateData(stock);

			if (!IsPostBack)
			{
				// form controls
				FunctionDropDownList.Items.Add("Average True Range");
				FunctionDropDownList.Items.Add("Chaikin's Volatility");
				FunctionDropDownList.Items.Add("Commodity Channel Index");
				FunctionDropDownList.Items.Add("Detrended Price Oscillator");
				FunctionDropDownList.Items.Add("MACD");
				FunctionDropDownList.Items.Add("Mass Index");
				FunctionDropDownList.Items.Add("Momentum");
				FunctionDropDownList.Items.Add("Momentum Div");
				FunctionDropDownList.Items.Add("Performance");
				FunctionDropDownList.Items.Add("Rate Of Change");
				FunctionDropDownList.Items.Add("Relative Strength Index");
				FunctionDropDownList.Items.Add("Standard Deviation");
				FunctionDropDownList.Items.Add("Stochastic");
				FunctionDropDownList.Items.Add("TRIX");
				FunctionDropDownList.Items.Add("William's %R");

				FunctionDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(PeriodDropDownList, 0, 100, 10);
				PeriodDropDownList.SelectedIndex = 1;
			}

            NFunctionCalculator function = new NFunctionCalculator();
            
            UpdateFunction(stock, line, function);

            line.Values = function.Calculate();
            line.XValues = (NDataSeriesDouble)stock.XValues.Clone();
		}

		private void SetupStockChart(NCartesianChart chart)
		{
			// setup Y axis
			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 40, 100);

			NLinearScaleConfigurator scaleY = (NLinearScaleConfigurator)axisY.ScaleConfigurator;
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);

			Color color1 = Color.FromArgb(100, 100, 150);
			Color color2 = Color.FromArgb(200, 120, 120);

			// setup the stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.Name = "Price";
			stock.Legend.Mode = SeriesLegendMode.None;
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Bar;
			stock.HighLowStrokeStyle.Color = color1;
			stock.UpStrokeStyle.Color = color1;
			stock.DownStrokeStyle.Color = color2;
			stock.UpFillStyle = new NColorFillStyle(color1);
			stock.DownFillStyle = new NColorFillStyle(color2);
			stock.OpenValues.Name = "open";
			stock.HighValues.Name = "high";
			stock.LowValues.Name = "low";
			stock.CloseValues.Name = "close";
			stock.CandleWidth = new NLength(0.4f, NRelativeUnit.ParentPercentage);
			stock.UseXValues = true;
			stock.InflateMargins = true;
		}
		private void SetupIndicatorChart(NCartesianChart chart)
		{
			// setup Y axis
			NAxis axisY2 = chart.Axis(StandardAxis.SecondaryY);
			axisY2.Visible = true;
			axisY2.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 0, 35);

			NLinearScaleConfigurator scaleY2 = (NLinearScaleConfigurator)axisY2.ScaleConfigurator;
			scaleY2.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY2.InnerMajorTickStyle.Length = new NLength(0);

			// Add line series for function
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.DataLabelStyle.Visible = false;
			line.BorderStyle.Color = Color.Blue;
			line.UseXValues = true;
			line.DisplayOnAxis(StandardAxis.PrimaryY, false);
			line.DisplayOnAxis(StandardAxis.SecondaryY, true);
		}
		private void SetupTimeScale(NAxis axis)
		{
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

			axis.ScaleConfigurator = scaleX;
		}
		private void GenerateData(NStockSeries stock)
		{
			const double initialPrice = 100;
			const int numDataPoits = 200;

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits);
			FillStockDates(stock, numDataPoits, new DateTime(2010, 1, 11));
		}

		private void UpdateFunction(NStockSeries stock, NLineSeries line, NFunctionCalculator function)
		{
			int nPeriod = PeriodDropDownList.SelectedIndex * 10;
			StringBuilder sb = new StringBuilder();
			
			function.Arguments.Clear();

			switch(FunctionDropDownList.SelectedIndex)
			{
				case 0: // Average True Range
					function.Arguments.Add(stock.CloseValues);
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.AppendFormat("MMA(TR(close; high; low); {0})", nPeriod);
					line.Name = "Average True Range";
					PeriodDropDownList.Enabled = true;
					break;

				case 1: // Chaikin's Volatility
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.AppendFormat("CHV(high; low; 10; {0})", nPeriod);
					line.Name = "Chaikin's Volatility";
					PeriodDropDownList.Enabled = true;
					break;

				case 2: // Commodity Channel Index
					function.Arguments.Add(stock.CloseValues);
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.AppendFormat("CCI(close; high; low; {0})", nPeriod);
					line.Name = "Commodity Channel Index";
					PeriodDropDownList.Enabled = true;
					break;

				case 3: // Detrended Price Oscillator
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("DPO(close; {0})", nPeriod);
					line.Name = "Detrended Price Oscillator";
					PeriodDropDownList.Enabled = true;
					break;

				case 4: // Moving Average Convergence Divergence
					function.Arguments.Add(stock.CloseValues);
					sb.Append("SUB( EMA(close;12) ; EMA(close;26) )");
					line.Name = "MACD";
					PeriodDropDownList.Enabled = false;
					break;

				case 5: // Mass Index
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.AppendFormat("MI(high; low; 15; {0})", nPeriod);
					line.Name = "Mass Index";
					PeriodDropDownList.Enabled = true;
					break;

				case 6: // Momentum
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("MOMENTUM(close; {0})", nPeriod);
					line.Name = "Momentum";
					PeriodDropDownList.Enabled = true;
					break;

				case 7: // Momentum Div
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("MOMENTUMDIV(close; {0})", nPeriod);
					line.Name = "Momentum Div";
					PeriodDropDownList.Enabled = true;
					break;

				case 8: // Performance
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("PERFORMANCE(close)");
					line.Name = "Performance";
					PeriodDropDownList.Enabled = false;
					break;

				case 9: // Rate Of Change
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("ROC(close; {0})", nPeriod);
					line.Name = "Rate Of Change";
					PeriodDropDownList.Enabled = true;
					break;

				case 10: // Relative Strength Index
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("RSI(close; {0})", nPeriod);
					line.Name = "Relative Strength Index";
					PeriodDropDownList.Enabled = true;
					break;

				case 11: // Standard Deviation
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("STDDEV(close; {0})", nPeriod);
					line.Name = "Standard Deviation";
					PeriodDropDownList.Enabled = true;
					break;

				case 12: // Stochastic Oscillator
					function.Arguments.Add(stock.CloseValues);
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.AppendFormat("STOCHASTIC(close; high; low; {0})", nPeriod);
					line.Name = "Stochastic Oscillator";
					PeriodDropDownList.Enabled = true;
					break;

				case 13: // TRIX
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("TRIX(close; {0})", nPeriod);
					line.Name = "TRIX";
					PeriodDropDownList.Enabled = true;
					break;

				case 14: // William's %R
					function.Arguments.Add(stock.CloseValues);
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.AppendFormat("WILLIAMSR(close; high; low; {0})", nPeriod);
					line.Name = "William's %R";
					PeriodDropDownList.Enabled = true;
					break;

				default:
					return;
			}

			function.Expression = sb.ToString();
			ExpressionLabel.Text = function.Expression;
		}
	}
}
