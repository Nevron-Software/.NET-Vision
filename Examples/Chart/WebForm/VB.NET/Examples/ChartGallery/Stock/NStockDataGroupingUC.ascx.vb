Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStockDataGroupingUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim stock As NStockSeries

			If (Not IsPostBack) Then
				' set a chart title
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False

				Dim title As NLabel = nChartControl1.Labels.AddHeader("Stock Data Grouping")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

				' no legend
				nChartControl1.Legends.Clear()

				' setup chart
				Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
				chart.BoundsMode = BoundsMode.Stretch

				Dim rs As NRangeSelection = New NRangeSelection()
				rs.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
				chart.RangeSelections.Add(rs)

				' setup X axis
				Dim scaleX As NValueTimelineScaleConfigurator = New NValueTimelineScaleConfigurator()
				scaleX.FirstRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
				scaleX.FirstRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(225, 225, 225))
				scaleX.FirstRow.UseGridStyle = True
				scaleX.FirstRow.InnerTickStyle.Visible = False
				scaleX.SecondRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
				scaleX.SecondRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(215, 215, 215))
				scaleX.SecondRow.UseGridStyle = True
				scaleX.SecondRow.InnerTickStyle.Visible = False
				scaleX.ThirdRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
				scaleX.ThirdRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(205, 205, 205))
				scaleX.ThirdRow.UseGridStyle = True
				scaleX.ThirdRow.InnerTickStyle.Visible = False

				' calendar
				Dim wdr As NWeekDayRule = New NWeekDayRule(WeekDayBit.All)
				wdr.Saturday = False
				wdr.Sunday = False
				scaleX.Calendar.Rules.Add(wdr)
				scaleX.EnableCalendar = True

				' set configurator
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
				chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True

				' setup Y axis
				Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
				scaleY.OuterMajorTickStyle.Length = New NLength(3, NGraphicsUnit.Point)
				scaleY.InnerMajorTickStyle.Visible = False

				Dim stripFill As NFillStyle = New NColorFillStyle(Color.FromArgb(234, 233, 237))
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(stripFill, Nothing, True, 1, 0, 1, 1)
				stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
				stripStyle.Interlaced = True
				scaleY.StripStyles.Add(stripStyle)

				' setup stock series
				stock = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
				stock.DataLabelStyle.Visible = False
				stock.UpFillStyle = New NColorFillStyle(Color.White)
				stock.UpStrokeStyle.Color = Color.Black
				stock.DownFillStyle = New NColorFillStyle(Color.Crimson)
				stock.DownStrokeStyle.Color = Color.Crimson
				stock.HighLowStrokeStyle.Color = Color.Black
				stock.CandleWidth = New NLength(1.2f, NRelativeUnit.ParentPercentage)
				stock.UseXValues = True
				stock.InflateMargins = True
				stock.DataLabelStyle.Format = "open - <open>" & Constants.vbCrLf & "close - <close>"

				' add some stock items
				Const numDataPoints As Integer = 1000
				WebExamplesUtilities.GenerateOHLCData(stock, 100.0, numDataPoints, New NRange1DD(60, 140))
				FillStockDates(stock, numDataPoints, DateTime.Now - New TimeSpan(CInt(Fix(numDataPoints * 1.2)), 0, 0, 0))

				' apply layout
				ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

				' update form controls
				CustomDateTimeSpanDropDownList.Items.Add("1 Week")
				CustomDateTimeSpanDropDownList.Items.Add("2 Weeks")
				CustomDateTimeSpanDropDownList.Items.Add("1 Month")
				CustomDateTimeSpanDropDownList.Items.Add("3 Months")

				WebExamplesUtilities.FillComboWithEnumNames(GroupingModeDropDownList, GetType(StockGroupingMode))

				CustomDateTimeSpanDropDownList.SelectedIndex = 2
				GroupingModeDropDownList.SelectedIndex = CInt(Fix(StockGroupingMode.SynchronizeWithMajorTick))

				WebExamplesUtilities.FillComboWithPercents(GroupPercendWidthDropDownList, 10)
				GroupPercendWidthDropDownList.SelectedIndex = 2

				WebExamplesUtilities.FillComboWithValues(MinGroupDistanceDropDownList, 2, 20, 2)
				MinGroupDistanceDropDownList.SelectedIndex = 2
			Else
				stock = CType(nChartControl1.Charts(0).Series(0), NStockSeries)
			End If

			MinGroupDistanceDropDownList.Enabled = False
			CustomDateTimeSpanDropDownList.Enabled = False
			GroupPercendWidthDropDownList.Enabled = True

			Select Case GroupingModeDropDownList.SelectedIndex
				Case CInt(Fix(StockGroupingMode.None))
					stock.GroupingMode = StockGroupingMode.None
					GroupPercendWidthDropDownList.Enabled = False
				Case CInt(Fix(StockGroupingMode.AutoDateTimeSpan))
					stock.GroupingMode = StockGroupingMode.AutoDateTimeSpan
					MinGroupDistanceDropDownList.Enabled = True
				Case CInt(Fix(StockGroupingMode.CustomDateTimeSpan))
					stock.GroupingMode = StockGroupingMode.CustomDateTimeSpan
					CustomDateTimeSpanDropDownList.Enabled = True
				Case CInt(Fix(StockGroupingMode.SynchronizeWithMajorTick))
					stock.GroupingMode = StockGroupingMode.SynchronizeWithMajorTick
				Case Else
			End Select

			stock.MinAutoGroupLength = New NLength(CSng(MinGroupDistanceDropDownList.SelectedIndex) * 2 + 2, NGraphicsUnit.Point)

			Select Case CustomDateTimeSpanDropDownList.SelectedIndex
				Case 0 ' 1 Week
					stock.CustomGroupStep = New NDateTimeSpan(1, NDateTimeUnit.Week)
				Case 1 ' 2 Weeks
					stock.CustomGroupStep = New NDateTimeSpan(2, NDateTimeUnit.Week)
				Case 2 ' 1 Month
					stock.CustomGroupStep = New NDateTimeSpan(1, NDateTimeUnit.Month)
				Case 3 ' 3 Months
					stock.CustomGroupStep = New NDateTimeSpan(3, NDateTimeUnit.Month)
			End Select

			stock.GroupPercentWidth = CSng(GroupPercendWidthDropDownList.SelectedIndex) * 10
		End Sub
	End Class
End Namespace
