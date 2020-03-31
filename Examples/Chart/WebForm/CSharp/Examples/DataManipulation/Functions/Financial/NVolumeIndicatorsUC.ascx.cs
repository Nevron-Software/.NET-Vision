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
	public partial class NVolumeIndicatorsUC : NExampleUC
	{
		protected System.Web.UI.WebControls.Button ChangeDataButton;
		const int numDataPoits = 200;
		const double prevCloseValue = 100;
		const double prevVolumeValue = 100;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			// set a chart title
			NLabel header = nChartControl1.Labels.AddFooter("Volume Indicators");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			// setup charts
			NCartesianChart chart = (NCartesianChart)nChartControl1.Charts[0];
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(new NLength(5, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(new NLength(90, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));

			SetupTimeScale(chart.Axis(StandardAxis.PrimaryX));
			NStockSeries stock = SetupStockChart(chart);
			NAreaSeries volume = SetupVolumeChart(chart);
			NLineSeries line = SetupIndicatorChart(chart);

			// form controls
			if (!IsPostBack)
			{
				FunctionDropDownList.Items.Add("Accumulation Distribution");
				FunctionDropDownList.Items.Add("Chaikin Oscillator");
				FunctionDropDownList.Items.Add("Ease of Movement");
				FunctionDropDownList.Items.Add("Money Flow Index");
				FunctionDropDownList.Items.Add("Negative Volume Index");
				FunctionDropDownList.Items.Add("On Balance Volume");
				FunctionDropDownList.Items.Add("Positive Volume Index");
				FunctionDropDownList.Items.Add("Price and Volume Trend");

				FunctionDropDownList.SelectedIndex = 0;

				WebExamplesUtilities.FillComboWithValues(ParameterDropDownList, 0, 100, 10);
				ParameterDropDownList.SelectedIndex = 1;
			}

            NFunctionCalculator function = new NFunctionCalculator();

			// generate data
            GenerateData(stock, volume, line);
			GenerateVolumeData(volume, prevVolumeValue, numDataPoits);

            UpdateFunction(stock, volume, line, function);

			line.Values = function.Calculate();
            line.XValues = (NDataSeriesDouble)stock.XValues.Clone();
            volume.XValues = (NDataSeriesDouble)stock.XValues.Clone();
		}

		private NStockSeries SetupStockChart(NCartesianChart chart)
		{
			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);

			NAxis axisY = chart.Axis(StandardAxis.PrimaryY);
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 50, 100);
			axisY.ScaleConfigurator = scaleY;
			axisY.Visible = true;

			// setup the stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.Name = "Price";
			stock.Legend.Mode = SeriesLegendMode.None;
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Stick;

			stock.UpStrokeStyle.Color = Color.RoyalBlue;
			stock.OpenValues.Name = "open";
			stock.HighValues.Name = "high";
			stock.LowValues.Name = "low";
			stock.CloseValues.Name = "close";
			stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			stock.UseXValues = true;
			stock.InflateMargins = true;

			return stock;
		}
		private NAreaSeries SetupVolumeChart(NCartesianChart chart)
		{
			// setup Y axis
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);

			NAxis axisY = chart.Axis(StandardAxis.SecondaryY);
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 25, 45);
			axisY.ScaleConfigurator = scaleY;
			axisY.Visible = true;

			// setup the volume series
			NAreaSeries volume = (NAreaSeries)chart.Series.Add(SeriesType.Area);
			volume.Name = "Volume";
			volume.Legend.Mode = SeriesLegendMode.None;
			volume.FillStyle = new NColorFillStyle(Color.YellowGreen);
			volume.DataLabelStyle.Visible = false;
			volume.Values.Name = "volume";
			volume.DisplayOnAxis(StandardAxis.PrimaryY, false);
			volume.DisplayOnAxis(axisY.AxisId, true);
			volume.UseXValues = true;

			return volume;
		}
		private NLineSeries SetupIndicatorChart(NCartesianChart chart)
		{
			NLinearScaleConfigurator scaleY = new NLinearScaleConfigurator();
			scaleY.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY.InnerMajorTickStyle.Length = new NLength(0);

			NCartesianAxisCollection axes = (NCartesianAxisCollection)chart.Axes;
			NAxis axisY = axes.AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft);
			axisY.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 0, 20);
			axisY.ScaleConfigurator = scaleY;
			axisY.Visible = true;

			// Add line series for function
			NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
			line.DataLabelStyle.Visible = false;
			line.BorderStyle.Color = Color.Blue;
			line.DisplayOnAxis(StandardAxis.PrimaryY, false);
			line.DisplayOnAxis(axisY.AxisId, true);
			line.UseXValues = true;

			return line;
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

		private void GenerateData(NStockSeries stock, NAreaSeries volume, NLineSeries line)
		{
			WebExamplesUtilities.GenerateOHLCData(stock, prevCloseValue, numDataPoits);
			FillStockDates(stock, numDataPoits, new DateTime(2010, 1, 11));
			GenerateVolumeData(volume, prevVolumeValue, numDataPoits);

			volume.XValues.Clear();
			volume.XValues.AddRange(stock.XValues);

			line.XValues.Clear();
			line.XValues.AddRange(stock.XValues);
		}
		private void GenerateVolumeData(NSeries series, double dValue, int nCount)
		{
			series.ClearDataPoints();

			for (int i = 0; i < nCount; i++)
			{
				if (dValue <= 0)
					dValue += 15;

				series.Values.Add(dValue);

				dValue += 10 * (0.5 - Random.NextDouble());
			}
		}

        private void UpdateFunction(NStockSeries stock, NAreaSeries volume, NLineSeries line, NFunctionCalculator function)
		{
			int nParam = ParameterDropDownList.SelectedIndex * 10;
			StringBuilder sb = new StringBuilder();

			switch(FunctionDropDownList.SelectedIndex)
			{
				case 0:
					function.Arguments.Add(volume.Values);
					function.Arguments.Add(stock.CloseValues);
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.Append("ACCDIST(close; high; low; volume)");
					line.Name = "Accumulation Distribution";
					ParameterDropDownList.Enabled = false;
					break;

				case 1:
					function.Arguments.Add(volume.Values);
					function.Arguments.Add(stock.CloseValues);
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.Append("CHOSC(close; high; low; volume; 3; 10)");
					line.Name = "Chaikin Oscillator";
					ParameterDropDownList.Enabled = false;
					break;

				case 2:
					function.Arguments.Add(volume.Values);
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.Append("EMV(high; low; volume)");
					line.Name = "Ease of Movement";
					ParameterDropDownList.Enabled = false;
					break;

				case 3:
					function.Arguments.Add(volume.Values);
					function.Arguments.Add(stock.CloseValues);
					function.Arguments.Add(stock.HighValues);
					function.Arguments.Add(stock.LowValues);
					sb.AppendFormat("MFI(close; high; low; volume; {0})", nParam);
					line.Name = "Money Flow Index";
					ParameterDropDownList.Enabled = true;
					break;

				case 4:
					function.Arguments.Add(volume.Values);
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("NVI(close; volume; {0})", nParam);
					line.Name = "Negative Volume Index";
					ParameterDropDownList.Enabled = true;
					break;

				case 5:
					function.Arguments.Add(volume.Values);
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("OBV(close; volume; {0})", prevVolumeValue);
					line.Name = "On Balance Volume";
					ParameterDropDownList.Enabled = false;
					break;

				case 6:
					function.Arguments.Add(volume.Values);
					function.Arguments.Add(stock.CloseValues);
					sb.AppendFormat("PVI(close; volume; {0})", nParam);
					line.Name = "Positive Volume Index";
					ParameterDropDownList.Enabled = true;
					break;

				case 7:
					function.Arguments.Add(volume.Values);
					function.Arguments.Add(stock.CloseValues);
					sb.Append("PVT(close; volume; 0)");
					line.Name = "Price and Volume Trend";
					ParameterDropDownList.Enabled = false;
					break;

				default:
					return;
			}

			function.Expression = sb.ToString();

			ExpressionLabel.Text = function.Expression;
		}
	}
}
