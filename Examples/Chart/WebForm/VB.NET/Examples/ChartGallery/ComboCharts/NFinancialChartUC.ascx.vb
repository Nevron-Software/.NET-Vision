Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Chart.Functions
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NFinancialChartUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				CandleStyleDropDownList.Items.Add("Candle")
				CandleStyleDropDownList.Items.Add("Stick")
				CandleStyleDropDownList.SelectedIndex = 0
			End If

			Const nNumberOfWeeks As Integer = 20
			Const nWorkDaysInWeek As Integer = 5
			Const nTotalWorkDays As Integer = nNumberOfWeeks * nWorkDaysInWeek

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Financial Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(84, NRelativeUnit.ParentPercentage))
			chart.Height = 30

			' setup y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.MajorGridStyle.LineStyle.Color = Color.Gray
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			' setup X axis
			Dim scaleX As NRangeTimelineScaleConfigurator = New NRangeTimelineScaleConfigurator()
			scaleX.FirstRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.FirstRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(225, 225, 225))
			scaleX.FirstRow.UseGridStyle = True
			scaleX.SecondRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.SecondRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(215, 215, 215))
			scaleX.SecondRow.UseGridStyle = True
			scaleX.ThirdRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.ThirdRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(205, 205, 205))
			scaleX.ThirdRow.UseGridStyle = True
			' calendar
			Dim wdr As NWeekDayRule = New NWeekDayRule(WeekDayBit.All)
			wdr.Saturday = False
			wdr.Sunday = False
			scaleX.Calendar.Rules.Add(wdr)
			scaleX.EnableCalendar = True
			' set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' create a line series for the simple moving average
			Dim lineSMA As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			lineSMA.Name = "SMA(20)"
			lineSMA.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			lineSMA.DataLabelStyle.Visible = False
			lineSMA.BorderStyle.Color = Color.DarkOrange
			lineSMA.UseXValues = True

			' create the stock series
			Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			stock.Name = "Stock Data"
			stock.Legend.Mode = SeriesLegendMode.None
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Bar
			stock.CandleWidth = New NLength(2, NGraphicsUnit.Point)
			stock.InflateMargins = True
			stock.UseXValues = True
			stock.UpFillStyle = New NColorFillStyle(Green)
			stock.UpStrokeStyle.Color = Color.Black
			stock.DownFillStyle = New NColorFillStyle(DarkOrange)
			stock.DownStrokeStyle.Color = Color.Black

			' add the bollinger bands as high low area
			Dim highLow As NHighLowSeries = CType(chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			highLow.Name = "BB(20, 2)"
			highLow.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			highLow.DataLabelStyle.Visible = False
			highLow.HighFillStyle = New NColorFillStyle(Color.FromArgb(80, 130, 134, 168))
			highLow.HighBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			highLow.UseXValues = True

			' generate some stock data
			WebExamplesUtilities.GenerateOHLCData(stock, 400, nTotalWorkDays + 20)
			FillStockDates(stock, nTotalWorkDays + 20)

			' create a function calculator
			Dim fc As NFunctionCalculator = New NFunctionCalculator()
			stock.CloseValues.Name = "close"
			fc.Arguments.Add(stock.CloseValues)

			' calculate the bollinger bands
			fc.Expression = "BOLLINGER(close; 20; 2)"
			highLow.HighValues = fc.Calculate()

			fc.Expression = "BOLLINGER(close; 20; -2)"
			highLow.LowValues = fc.Calculate()

			' calculate the simple moving average
			fc.Expression = "SMA(close; 20)"
			lineSMA.Values = fc.Calculate()

			' remove data that won't be charted
			stock.HighValues.RemoveRange(0, 20)
			stock.LowValues.RemoveRange(0, 20)
			stock.OpenValues.RemoveRange(0, 20)
			stock.CloseValues.RemoveRange(0, 20)
			stock.XValues.RemoveRange(0, 20)

			highLow.HighValues.RemoveRange(0, 20)
			highLow.LowValues.RemoveRange(0, 20)
			highLow.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)

			lineSMA.Values.RemoveRange(0, 20)
			lineSMA.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)

			stock.CandleStyle = CType(CandleStyleDropDownList.SelectedIndex, CandleStyle)
			lineSMA.Visible = SMACheckBox.Checked
			highLow.Visible = SBBCheckBox.Checked
		End Sub
	End Class
End Namespace
