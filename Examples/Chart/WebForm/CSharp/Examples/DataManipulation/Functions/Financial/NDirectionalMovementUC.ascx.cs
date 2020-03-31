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
	public partial class NDirectionalMovementUC : NExampleUC
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				WebExamplesUtilities.FillComboWithValues(PeriodDropDownList, 0, 100, 10);
				PeriodDropDownList.SelectedIndex = 2;
			}

            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			NFunctionCalculator calc = new NFunctionCalculator();
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None;

			NChart chart = nChartControl1.Charts[0];
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(20, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(75, NRelativeUnit.ParentPercentage));

			NLegend legend = nChartControl1.Legends[0];
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly;
			legend.Location = new NPointL(
				new NLength(98, NRelativeUnit.ParentPercentage),
				new NLength(12, NRelativeUnit.ParentPercentage));

			// align the chart and the legend
			NSideGuideline guideline = new NSideGuideline(PanelSide.Right);
			guideline.Targets.Add(legend);
			guideline.Targets.Add(chart);
			nChartControl1.Document.RootPanel.Guidelines.Add(guideline);

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
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX;

			// setup primary Y axis
			NAxis axisY1 = chart.Axis(StandardAxis.PrimaryY);
			axisY1.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 45, 100);

			NLinearScaleConfigurator scaleY1 = (NLinearScaleConfigurator)axisY1.ScaleConfigurator;
			scaleY1.RulerStyle.Height = new NLength(2, NGraphicsUnit.Pixel);
			scaleY1.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY1.InnerMajorTickStyle.LineStyle.Width = new NLength(0);

			// setup secondary Y axis
			NAxis axisY2 = chart.Axis(StandardAxis.SecondaryY);
			axisY2.Visible = true;
			axisY2.Anchor = new NDockAxisAnchor(AxisDockZone.FrontLeft, false, 0, 40);

			NLinearScaleConfigurator scaleY2 = (NLinearScaleConfigurator)axisY2.ScaleConfigurator;
			scaleY2.RulerStyle.Height = new NLength(2, NGraphicsUnit.Pixel);
			scaleY2.MajorGridStyle.ShowAtWalls = new ChartWallType[] { ChartWallType.Back };
			scaleY2.InnerMajorTickStyle.LineStyle.Width = new NLength(0);

			Color color1 = Color.FromArgb(100, 100, 150);
			Color color2 = Color.FromArgb(200, 120, 120);
			Color color3 = Color.FromArgb(100, 150, 100);

			// setup the stock series
			NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
			stock.DataLabelStyle.Visible = false;
			stock.CandleStyle = CandleStyle.Stick;
			stock.UpStrokeStyle.Color = color1;
			stock.DownStrokeStyle.Color = color2;
			stock.Legend.Mode = SeriesLegendMode.None;
			stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
			stock.UseXValues = true;
			stock.InflateMargins = true;

			// Add line series for ADX
			NLineSeries lineADX = (NLineSeries)chart.Series.Add(SeriesType.Line);
			lineADX.DisplayOnAxis(StandardAxis.PrimaryY, false);
			lineADX.DisplayOnAxis(StandardAxis.SecondaryY, true);
			lineADX.BorderStyle.Color = Color.LimeGreen;
			lineADX.Name = "ADX";
			lineADX.DataLabelStyle.Visible = false;

			// Add line series for +DI
			NLineSeries lineDIPos = (NLineSeries)chart.Series.Add(SeriesType.Line);
			lineDIPos.MultiLineMode = MultiLineMode.Overlapped;
			lineDIPos.DisplayOnAxis(StandardAxis.PrimaryY, false);
			lineDIPos.DisplayOnAxis(StandardAxis.SecondaryY, true);
			lineDIPos.BorderStyle.Color = Color.Red;
			lineDIPos.Name = "+DI";
			lineDIPos.DataLabelStyle.Visible = false;

			// Add line series for -DI
			NLineSeries lineDINeg = (NLineSeries)chart.Series.Add(SeriesType.Line);
			lineDINeg.MultiLineMode = MultiLineMode.Overlapped;
			lineDINeg.DisplayOnAxis(StandardAxis.PrimaryY, false);
			lineDINeg.DisplayOnAxis(StandardAxis.SecondaryY, true);
			lineDINeg.BorderStyle.Color  = Color.Blue;
			lineDINeg.Name = "-DI";
			lineDINeg.DataLabelStyle.Visible = false;

			// add arguments for function calculator
			stock.CloseValues.Name = "close";
			stock.HighValues.Name = "high";
			stock.LowValues.Name = "low";
			calc.Arguments.Add(stock.CloseValues);
			calc.Arguments.Add(stock.HighValues);
			calc.Arguments.Add(stock.LowValues);

			// form controls
			lineDIPos.Visible = ShowPosDICheckBox.Checked;
			lineDINeg.Visible = ShowNegDICheckBox.Checked;
			lineADX.Visible = ShowADXCheckBox.Checked;

			// add header
			NLabel header = nChartControl1.Labels.AddHeader("Directional Movement");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			GenerateData(stock);

			UpdateFunctions(stock, lineDIPos, lineDINeg, lineADX, calc);
		}

		private void GenerateData(NStockSeries stock)
		{
			const double initialPrice = 400;
			const int numDataPoits = 100;

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits);
			FillStockDates(stock, numDataPoits, new DateTime(2010, 1, 11));
		}

        private void UpdateFunctions(NStockSeries stock, NLineSeries lineDIPos, NLineSeries lineDINeg, NLineSeries lineADX, NFunctionCalculator calc)
		{
			StringBuilder sb = new StringBuilder();
			int nPeriod = PeriodDropDownList.SelectedIndex * 10;

			sb.AppendFormat("DI_POS(close; high; low; {0})", nPeriod);
			calc.Expression = sb.ToString();
			lineDIPos.Values = calc.Calculate();
            lineDIPos.XValues = (NDataSeriesDouble)stock.XValues.Clone();
            lineDIPos.UseXValues = true;
			PosDITextBox.Text = calc.Expression;

			sb.Remove(0, sb.Length);
			sb.AppendFormat("DI_NEG(close; high; low; {0})", nPeriod);
			calc.Expression = sb.ToString();
			lineDINeg.Values = calc.Calculate();
            lineDINeg.XValues = (NDataSeriesDouble)stock.XValues.Clone();
            lineDINeg.UseXValues = true;
			NegDITextBox.Text = calc.Expression;

			sb.Remove(0, sb.Length);
			sb.AppendFormat("MMA(DMI(close; high; low; {0}); {0})", nPeriod);
			calc.Expression = sb.ToString();
			lineADX.Values = calc.Calculate();
            lineADX.XValues = (NDataSeriesDouble)stock.XValues.Clone();
            lineADX.UseXValues = true;
			ADXTextBox.Text = calc.Expression;
		}
	}
}
