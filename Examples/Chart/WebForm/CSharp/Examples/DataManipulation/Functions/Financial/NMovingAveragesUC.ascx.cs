using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nevron.Examples.Framework.WebForm;
using Nevron.Chart.Functions;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NMovingAveragesUC : NExampleUC
	{
		private NFunctionCalculator nFunction;

		protected void Page_Load(object sender, EventArgs e)
		{
			nFunction = new NFunctionCalculator();

			if (!IsPostBack)
			{
				FunctionDropDownList.Items.Add("Simple Moving Average");
				FunctionDropDownList.Items.Add("Weighted Moving Average");
				FunctionDropDownList.Items.Add("Exponential Moving Average");
				FunctionDropDownList.Items.Add("Modified Moving Average");
				FunctionDropDownList.SelectedIndex = 0;

				// form controls
				ApplyFunctionToDropDownList.Items.Add("Open");
				ApplyFunctionToDropDownList.Items.Add("High");
				ApplyFunctionToDropDownList.Items.Add("Low");
				ApplyFunctionToDropDownList.Items.Add("Close");
				ApplyFunctionToDropDownList.SelectedIndex = 3;

				WebExamplesUtilities.FillComboWithFloatValues(PeriodDropDownList, 0, 50, 1);
				PeriodDropDownList.SelectedIndex = 10;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

            // add header
            NLabel header = nChartControl1.Labels.AddHeader("Moving Averages");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

            NLegend legend = nChartControl1.Legends[0];
            legend.Location = new NPointL(
                new NLength(98, NRelativeUnit.ParentPercentage),
                new NLength(12, NRelativeUnit.ParentPercentage));

            NChart chart = nChartControl1.Charts[0];
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.LightModel.EnableLighting = false;
			chart.Axis(StandardAxis.Depth).Visible = false;
			chart.Wall(ChartWallType.Floor).Visible = false;
			chart.Wall(ChartWallType.Left).Visible = false;
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(20, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(75, NRelativeUnit.ParentPercentage));

			// align the chart and the legend
			NSideGuideline guideline = new NSideGuideline(PanelSide.Right);
			guideline.Targets.Add(legend);
			guideline.Targets.Add(chart);
			nChartControl1.Document.RootPanel.Guidelines.Add(guideline);

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

			// setup primary Y axis
			NAxis axis = chart.Axis(StandardAxis.PrimaryY);
			NLinearScaleConfigurator linearScaleConfigurator = (NLinearScaleConfigurator)axis.ScaleConfigurator;
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
			linearScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);
			linearScaleConfigurator.InnerMajorTickStyle.LineStyle.Width = new NLength(0, NGraphicsUnit.Pixel);

			// line series for the function
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.DataLabelStyle.Visible = false;
			line.BorderStyle.Color = Color.Red;
			line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			line.UseXValues = true;

			Color customColor = Color.FromArgb(100, 100, 150);

			// setup the stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Bar;
			stock.CandleWidth = new NLength(1, NRelativeUnit.ParentPercentage);
			stock.HighLowStrokeStyle.Color = customColor;
			stock.UpStrokeStyle.Color = customColor;
			stock.DownStrokeStyle.Color = customColor;
			stock.UpFillStyle = new NColorFillStyle(Color.White);
			stock.DownFillStyle = new NColorFillStyle(customColor);
			stock.Legend.Mode = SeriesLegendMode.None;
			stock.OpenValues.Name = "open";
			stock.HighValues.Name = "high";
			stock.LowValues.Name = "low";
			stock.CloseValues.Name = "close";
            stock.UseXValues = true;
			stock.InflateMargins = true;

			GenerateData(stock);
			BuildExpression(stock, line);

            line.XValues = (NDataSeriesDouble)stock.XValues.Clone();
			line.Values = nFunction.Calculate();
		}

		private void GenerateData(NStockSeries stock)
		{
			const double initialPrice = 100;
			const int numDataPoits = 50;

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits);
			FillStockDates(stock, numDataPoits, new DateTime(2010, 1, 11));
		}

		private void BuildExpression(NStockSeries stock, NSeries line)
		{
            NDataSeriesDouble arg;
			StringBuilder sb = new StringBuilder();
			int nPeriod = PeriodDropDownList.SelectedIndex;

			arg = stock.OpenValues;

			switch(ApplyFunctionToDropDownList.SelectedIndex)
			{
				case 0:
					arg = stock.OpenValues;
					break;
				case 1:
					arg = stock.HighValues;
					break;
				case 2:
					arg = stock.LowValues;
					break;
				case 3:
					arg = stock.CloseValues;
					break;
			}

			switch(FunctionDropDownList.SelectedIndex)
			{
				case 0:
					sb.AppendFormat("SMA({0}; {1})", arg.Name, nPeriod);
					line.Name = "Simple Moving Average";
					break;
				case 1:
					sb.AppendFormat("WMA({0}; {1})", arg.Name, nPeriod);
					line.Name = "Weighted Moving Average";
					break;
				case 2:
					sb.AppendFormat("EMA({0}; {1})", arg.Name, nPeriod);
					line.Name = "Exponential Moving Average";
					break;
				case 3:
					sb.AppendFormat("MMA({0}; {1})", arg.Name, nPeriod);
					line.Name = "Modified Moving Average";
					break;
			}

			nFunction.Arguments.Clear();
			nFunction.Arguments.Add(arg);
			nFunction.Expression = sb.ToString();

			// form controls
			ExpressionTextBox.Text = nFunction.Expression;
		}
	}
}
