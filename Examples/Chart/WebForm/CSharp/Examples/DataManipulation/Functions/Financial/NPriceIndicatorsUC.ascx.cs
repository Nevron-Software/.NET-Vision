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
	public partial class NPriceIndicatorsUC : NExampleUC 
	{	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddFooter("Price Indicators");
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
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage), 
				new NLength(80, NRelativeUnit.ParentPercentage));

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

			// line series for the function
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.DataLabelStyle.Visible = false;
			line.BorderStyle.Color = Color.Red;
			line.BorderStyle.Width = new NLength(2, NGraphicsUnit.Pixel);
			line.ShadowStyle.Type = ShadowType.GaussianBlur;
			line.UseXValues = true;

			Color customColor = Color.FromArgb(100, 100, 150);

			// setup the stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Stick;
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
			stock.CandleWidth = new NLength(1, NRelativeUnit.ParentPercentage);
			stock.InflateMargins = true;
			stock.UseXValues = true;

			GenerateData(stock);

			if (!IsPostBack)
			{
				FunctionDropDownList.Items.Add("Median Price");
				FunctionDropDownList.Items.Add("Typical Price");
				FunctionDropDownList.Items.Add("Weighted Close");
				FunctionDropDownList.SelectedIndex = 0;
			}

			CalculateFunction(stock, line);
		}

		private void GenerateData(NStockSeries stock)
		{
			const double initialPrice = 100;
			const int numDataPoits = 50;

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits);
			FillStockDates(stock, numDataPoits, new DateTime(2010, 1, 11));
		}

		private void CalculateFunction(NStockSeries stock, NLineSeries line)
		{
			StringBuilder sb = new StringBuilder();

			NFunctionCalculator function = new NFunctionCalculator();

			function.Arguments.Clear();

			switch(FunctionDropDownList.SelectedIndex)
			{
				case 0:
					sb.AppendFormat("MEDIANPRICE({0}; {1})", stock.HighValues.Name, stock.LowValues.Name);
					line.Name = "Median Price";
					break;

				case 1:
					sb.AppendFormat("TYPICALPRICE({0}; {1}; {2})", stock.CloseValues.Name, stock.HighValues.Name, stock.LowValues.Name);
					line.Name = "Typical Price";
					break;

				case 2:
					sb.AppendFormat("WEIGHTEDCLOSE({0}; {1}; {2})", stock.CloseValues.Name, stock.HighValues.Name, stock.LowValues.Name);
					line.Name = "Weighted Close";
					break;
				default:
					return;
			}

			function.Expression = sb.ToString();
			function.Arguments.Clear();
			function.Arguments.Add(stock.CloseValues);
			function.Arguments.Add(stock.HighValues);
			function.Arguments.Add(stock.LowValues);

            line.XValues = (NDataSeriesDouble)stock.XValues.Clone();
            line.UseXValues = true;
			line.Values = function.Calculate();

			// form controls
			ExpressionLabel.Text = function.Expression;
		}

	}
}
