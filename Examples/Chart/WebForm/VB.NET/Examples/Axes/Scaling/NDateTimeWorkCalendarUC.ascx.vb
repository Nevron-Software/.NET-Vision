Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.Functions
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDateTimeWorkCalendarUC
		Inherits NExampleUC
		Private m_Calendar As NWorkCalendar

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' init form controls
			If (Not IsPostBack) Then
				EnableWeekRuleCheckBox.Checked = True

				MondayCheckBox.Checked = True
				TuesdayCheckBox.Checked = True
				WednesdayCheckBox.Checked = True
				ThursdayCheckBox.Checked = True
				FridayCheckBox.Checked = True

				EnableMonthDayRuleCheckBox.Checked = True

				WebExamplesUtilities.FillComboWithValues(MonthDayDropDownList, 1, 31, 1)
				MonthDayWorkingCheckBox.Checked = False

				ZoomModeDropDownList.Items.Add("First 7 Days")
				ZoomModeDropDownList.Items.Add("First 31 Days")
				ZoomModeDropDownList.SelectedIndex = 0
			Else
				Dim enableWeekDays As Boolean = EnableWeekRuleCheckBox.Checked

				MondayCheckBox.Enabled = enableWeekDays
				TuesdayCheckBox.Enabled = enableWeekDays
				WednesdayCheckBox.Enabled = enableWeekDays
				ThursdayCheckBox.Enabled = enableWeekDays
				FridayCheckBox.Enabled = enableWeekDays
				SaturdayCheckBox.Enabled = enableWeekDays
				SundayCheckBox.Enabled = enableWeekDays

				Dim enableMonthDayRules As Boolean = EnableMonthDayRuleCheckBox.Checked

				MonthDayDropDownList.Enabled = enableMonthDayRules
				MonthDayWorkingCheckBox.Enabled = enableMonthDayRules
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = New NLabel("Date Time Work Calendar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			nChartControl1.Panels.Add(title)

			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' enable range selection
			Dim rangeSelection As NRangeSelection = New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			chart.RangeSelections.Add(rangeSelection)

			' enable zooming and scrolling
			chart.Axis(StandardAxis.PrimaryX).PagingView = New NDateTimeAxisPagingView()

			' apply calendar to scale
			Dim timeline As NRangeTimelineScaleConfigurator = New NRangeTimelineScaleConfigurator()
			timeline.EnableCalendar = True
			m_Calendar = CreateWorkCalendar()
			timeline.Calendar = m_Calendar
			timeline.ThirdRow.EnableUnitSensitiveFormatting = False

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeline

			' generate data for this calendar
			AddData(chart)

			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Function CreateWorkCalendar() As NWorkCalendar
			' create calendar
			Dim m_Calendar As NWorkCalendar = New NWorkCalendar()

			' use week days
			If EnableWeekRuleCheckBox.Checked Then
				Dim weekDayRule As NWeekDayRule = New NWeekDayRule()

				Dim weekDays As WeekDayBit = WeekDayBit.None
				If MondayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Monday
				End If

				If TuesdayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Tuesday
				End If

				If WednesdayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Wednesday
				End If

				If ThursdayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Thursday
				End If

				If FridayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Friday
				End If

				If SaturdayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Saturday
				End If

				If SundayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Sunday
				End If

				If Not(weekDays.Equals(WeekDayBit.None)) Then
					' cannot select all week days as non working as this leads to a scale with no
					' working days...
					weekDayRule.WeekDays = weekDays
					weekDayRule.Schedule.SetHourRange(0, 24, False)
					m_Calendar.Rules.Add(weekDayRule)
				End If
			End If

			If EnableMonthDayRuleCheckBox.Checked Then
				Dim monthDayRule As NMonthDayRule = New NMonthDayRule()

				monthDayRule.Months = MonthBit.January Or MonthBit.February Or MonthBit.March Or MonthBit.April Or MonthBit.May Or MonthBit.June Or MonthBit.July Or MonthBit.August Or MonthBit.September Or MonthBit.October Or MonthBit.November Or MonthBit.December

				monthDayRule.Day = MonthDayDropDownList.SelectedIndex + 1
				monthDayRule.Working = MonthDayWorkingCheckBox.Checked
				m_Calendar.Rules.Add(monthDayRule)
			End If

			Return m_Calendar
		End Function

		Private Sub AddData(ByVal chart As NCartesianChart)
			Const nHistoricalDays As Integer = 20

			' first clear all series
			chart.Series.Clear()
			' create a line series for the simple moving average
			Dim lineSMA As NLineSeries = New NLineSeries()
			chart.Series.Add(lineSMA)

			lineSMA.Name = "SMA(20)"
			lineSMA.DataLabelStyle.Visible = False
			lineSMA.BorderStyle.Color = Color.DarkOrange
			lineSMA.UseXValues = True

			' create the stock series
			Dim stock As NStockSeries = New NStockSeries()
			chart.Series.Add(stock)
			stock.Name = "Stock Data"
			stock.Legend.Mode = SeriesLegendMode.None
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Bar
			stock.CandleWidth = New NLength(5, NGraphicsUnit.Point)
			stock.InflateMargins = False
			stock.UpFillStyle = New NColorFillStyle(Green)
			stock.UpStrokeStyle.Color = Color.Black
			stock.DownFillStyle = New NColorFillStyle(DarkOrange)
			stock.DownStrokeStyle.Color = Color.Black
			stock.DisplayOnAxis(StandardAxis.PrimaryX, True)
			stock.InflateMargins = True
			stock.OpenValues.Name = "open"
			stock.CloseValues.Name = "close"
			stock.HighValues.Name = "high"
			stock.LowValues.Name = "low"
			stock.UseXValues = True

			Dim period As Integer = 20

			' add the bollinger bands as high low area
			Dim highLow As NHighLowSeries = New NHighLowSeries()
			chart.Series.Add(highLow)
			highLow.Name = "BB(" & period.ToString() & ", 2)"
			highLow.DataLabelStyle.Visible = False
			highLow.HighFillStyle = New NColorFillStyle(Color.FromArgb(80, 130, 134, 168))
			highLow.HighBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			highLow.DisplayOnAxis(StandardAxis.SecondaryX, True)
			highLow.UseXValues = True

			' generate some stock data
			GenerateOHLCData(stock, 300, nHistoricalDays)

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

		Friend Sub GenerateOHLCData(ByVal s As NStockSeries, ByVal dPrevClose As Double, ByVal historicalDays As Integer)
			Dim now As DateTime = DateTime.Now
			Dim timeline As NTimeline = m_Calendar.CreateTimeline(New NDateTimeRange(now, now.Add(New TimeSpan(360, 0, 0, 0, 0))))
			Dim open, high, low, close As Double

			s.ClearDataPoints()

			Dim numberOfWorkingDays As Integer = historicalDays
			If ZoomModeDropDownList.SelectedIndex = 0 Then
				numberOfWorkingDays += 7
			Else
				numberOfWorkingDays += 31
			End If

			Do While numberOfWorkingDays > 0
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
				numberOfWorkingDays -= 1
			Loop
		End Sub
	End Class
End Namespace
