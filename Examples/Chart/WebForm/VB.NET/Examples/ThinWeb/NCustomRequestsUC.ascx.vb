Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.Functions
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NCustomRequestsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not nChartControl1.Initialized) Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Panels.Clear()

				' Set manual ID so that it can be referenced in JavaScript
				nChartControl1.StateId = "Chart1"

				' set a chart title
				Dim header As NLabel = New NLabel("Custom Requests")
				header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				header.ContentAlignment = ContentAlignment.BottomRight
				header.DockMode = PanelDockMode.Top
				header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
				nChartControl1.Panels.Add(header)

				Dim chart As NCartesianChart = New NCartesianChart()
				InitChart(chart)

				' register a custom request callback
				nChartControl1.CustomRequestCallback = New CustomRequestCallback()

				nChartControl1.ServerSettings.EnableTiledZoom = True

				' configure toolbar
				nChartControl1.Toolbar.Visible = True
				nChartControl1.Controller.SetActivePanel(chart)

				' add a data zoom tool
				Dim dataZoomTool As NDataZoomTool = New NDataZoomTool()
				dataZoomTool.Exclusive = True
				dataZoomTool.Enabled = False
				dataZoomTool.AllowYAxisZoom = False
				nChartControl1.Controller.Tools.Add(dataZoomTool)

				' add a data pan tool
				Dim dataPanTool As NDataPanTool = New NDataPanTool()
				dataPanTool.Exclusive = True
				dataPanTool.Enabled = True
				nChartControl1.Controller.Tools.Add(dataPanTool)

				' add a tooltip tool
				nChartControl1.Controller.Tools.Add(New NTooltipTool())
				' add a cursor change tool
				nChartControl1.Controller.Tools.Add(New NCursorTool())

				nChartControl1.Toolbar.Visible = True
				nChartControl1.Toolbar.Items.Add(New NToolbarButton(New NSaveImageAction("Save as PNG", New NPngImageFormat(), True, New NSize(0, 0), 96)))
				nChartControl1.Toolbar.Items.Add(New NToolbarSeparator())

				nChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleDataZoomToolAction()))
				nChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleDataPanToolAction()))
			End If
		End Sub

		<Serializable> _
		Public Class CustomRequestCallback
            Implements INCustomRequestCallback
			#Region "INCustomRequestCallback Members"

			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim chartControl As NThinChartControl = CType(control, NThinChartControl)

				' make sure chart is recalculated
				chartControl.RecalcLayout()

				Dim chart As NChart = chartControl.Charts(0)
				Dim stock As NStockSeries = CType(chart.Series(0), NStockSeries)
				Select Case argument
					Case "LastWeek"
							Dim dt As DateTime = DateTime.FromOADate(CDbl(stock.XValues(stock.XValues.Count - 1)))
							chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(New NRange1DD(dt.AddDays(-7).ToOADate(), dt.ToOADate()), 0.00001)
					Case "LastMonth"
							Dim dt As DateTime = DateTime.FromOADate(CDbl(stock.XValues(stock.XValues.Count - 1)))
							chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(New NRange1DD(dt.AddMonths(-1).ToOADate(), dt.ToOADate()), 0.00001)
					Case "LastYear"
						chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = False
				End Select

				chartControl.Update()
			End Sub

			#End Region
		End Class

		Public Sub InitChart(ByVal chart As NCartesianChart)
			' set layout related properties
			chart.BoundsMode = BoundsMode.Stretch
			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(10, 0, 10, 10)
			nChartControl1.Panels.Add(chart)

			' add interlace stripes
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.StripStyles.Add(stripStyle)

			' show X axis zooming and scrolling
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True

			' apply work calendar to the X axis
			Dim calendar As NWorkCalendar = New NWorkCalendar()
			Dim weekDayRule As NWeekDayRule = New NWeekDayRule()
			Dim weekDays As WeekDayBit = WeekDayBit.None
			weekDays = weekDays Or WeekDayBit.Monday
			weekDays = weekDays Or WeekDayBit.Tuesday
			weekDays = weekDays Or WeekDayBit.Wednesday
			weekDays = weekDays Or WeekDayBit.Thursday
			weekDays = weekDays Or WeekDayBit.Friday
			weekDayRule.WeekDays = weekDays
			weekDayRule.Schedule.SetHourRange(0, 24, False)
			calendar.Rules.Add(weekDayRule)

			' apply calendar to scale
			Dim timeline As NRangeTimelineScaleConfigurator = New NRangeTimelineScaleConfigurator()
			timeline.FirstRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			timeline.FirstRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(225, 225, 225))
			timeline.FirstRow.UseGridStyle = True
			timeline.SecondRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			timeline.SecondRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(215, 215, 215))
			timeline.SecondRow.UseGridStyle = True
			timeline.ThirdRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			timeline.ThirdRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(205, 205, 205))
			timeline.ThirdRow.UseGridStyle = True

			timeline.EnableCalendar = False
			timeline.Calendar = calendar
			timeline.ThirdRow.EnableUnitSensitiveFormatting = False

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeline

			' generate data for this calendar
			AddData(chart, calendar)
		End Sub

		Private Sub AddData(ByVal chart As NCartesianChart, ByVal calendar As NWorkCalendar)
			Const nNumberOfWeeks As Integer = 20
			Const nWorkDaysInWeek As Integer = 5
			Const nTotalWorkDays As Integer = nNumberOfWeeks * nWorkDaysInWeek
			Const nHistoricalDays As Integer = 20

			Dim lineSMA As NLineSeries = New NLineSeries()

			lineSMA.Name = "SMA(20)"
			lineSMA.DataLabelStyle.Visible = False
			lineSMA.BorderStyle.Color = Color.DarkOrange
			lineSMA.UseXValues = True

			' create the stock series
			Dim stock As NStockSeries = New NStockSeries()

			chart.Series.Add(stock)
			stock.DisplayOnAxis(StandardAxis.PrimaryX, True)

			stock.Name = "Stock Data"
			stock.Legend.Mode = SeriesLegendMode.None
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Bar
			stock.CandleWidth = New NLength(0.8f, NRelativeUnit.ParentPercentage)
			stock.InflateMargins = True
			stock.UseXValues = True
			stock.UpFillStyle = New NColorFillStyle(Green)
			stock.UpStrokeStyle.Color = Color.Black
			stock.DownFillStyle = New NColorFillStyle(DarkOrange)
			stock.DownStrokeStyle.Color = Color.Black
			stock.OpenValues.Name = "open"
			stock.CloseValues.Name = "close"
			stock.HighValues.Name = "high"
			stock.LowValues.Name = "low"

			Dim period As Integer = 20

			' add the bollinger bands as high low area
			Dim highLow As NHighLowSeries = New NHighLowSeries()
			chart.Series.Add(highLow)
			highLow.DisplayOnAxis(StandardAxis.SecondaryX, True)

			highLow.Name = "BB(" & period.ToString() & ", 2)"
			highLow.DataLabelStyle.Visible = False
			highLow.HighFillStyle = New NColorFillStyle(Color.FromArgb(80, 130, 134, 168))
			highLow.HighBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

			highLow.UseXValues = True

			' generate some stock data
			GenerateData(stock, calendar, 300, nTotalWorkDays + nHistoricalDays)

			' create a function calculator
			Dim fc As NFunctionCalculator = New NFunctionCalculator()
			fc.Arguments.Add(stock.CloseValues)

			' calculate the bollinger bands
			fc.Expression = "BOLLINGER(close;" & period.ToString() & "; 2)"
			highLow.HighValues = fc.Calculate()
			highLow.HighValues.Name = "BollingerUpper"

			fc.Expression = "BOLLINGER(close; " & period.ToString() & "; -2)"
			highLow.LowValues = fc.Calculate()
			highLow.LowValues.Name = "BollingerLower"
			highLow.XValues.InsertRange(0, stock.XValues)

			' calculate the simple moving average
			fc.Expression = "SMA(close; " & period.ToString() & ")"
			lineSMA.Values = fc.Calculate()
			lineSMA.XValues.InsertRange(0, stock.XValues)

			' remove first period from line SMA
			lineSMA.Values.RemoveRange(0, period)
			lineSMA.XValues.RemoveRange(0, period)

			' remove first period from high low
			highLow.XValues.RemoveRange(0, period)
			highLow.HighValues.RemoveRange(0, period)
			highLow.LowValues.RemoveRange(0, period)

			' remove first period from stock
			stock.OpenValues.RemoveRange(0, period)
			stock.HighValues.RemoveRange(0, period)
			stock.LowValues.RemoveRange(0, period)
			stock.CloseValues.RemoveRange(0, period)
			stock.XValues.RemoveRange(0, period)
		End Sub

		Private Sub GenerateData(ByVal s As NStockSeries, ByVal calendar As NWorkCalendar, ByVal dPrevClose As Double, ByVal nCount As Integer)
			Dim now As DateTime = DateTime.Now
			Dim timeline As NTimeline = calendar.CreateTimeline(New NDateTimeRange(now, now.Add(New TimeSpan(730, 0, 0, 0, 0))))
			Dim open, high, low, close As Double

			s.ClearDataPoints()

			Dim nIndex As Integer = 0
			Do While nIndex < nCount
				open = dPrevClose

				If dPrevClose < 25 OrElse Random.NextDouble() > 0.5 Then
					' upward price change
					close = open + (2 + (Random.NextDouble() * 20))
					high = close + (Random.NextDouble() * 10)
					low = open - (Random.NextDouble() * 10)
				Else
					' downward price change
					close = open - (2 + (Random.NextDouble() * 20))
					high = open + (Random.NextDouble() * 10)
					low = close - (Random.NextDouble() * 10)
				End If

				If low < 1 Then
					low = 1
				End If

				dPrevClose = close

				s.OpenValues.Add(open)
				s.HighValues.Add(high)
				s.LowValues.Add(low)
				s.CloseValues.Add(close)
				s.XValues.Add(now.ToOADate())

				' advance to next working day
				now = timeline.AddTimeSpan(now, New NDateTimeSpan(1, NDateTimeUnit.Day))
				nIndex += 1
			Loop
		End Sub
	End Class
End Namespace
