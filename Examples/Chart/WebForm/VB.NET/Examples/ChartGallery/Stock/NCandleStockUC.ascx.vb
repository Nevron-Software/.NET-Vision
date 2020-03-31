Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Dom
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStockCandleUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithColorNames(UpCandleColorDropDownList, KnownColor.White)
				WebExamplesUtilities.FillComboWithColorNames(UpCandleLineColorDropDownList, KnownColor.Black)
				WebExamplesUtilities.FillComboWithColorNames(DownCandleColorDropDownList, KnownColor.Crimson)
				WebExamplesUtilities.FillComboWithColorNames(DownCandleLineColorDropDownList, KnownColor.Crimson)
				WebExamplesUtilities.FillComboWithColorNames(HowLowLineColorDropDownList, KnownColor.Black)

				ShowHiLowLineCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Candle Stock Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

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
			Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			stock.DataLabelStyle.Visible = False
			stock.CandleWidth = New NLength(1.2f, NRelativeUnit.ParentPercentage)
			stock.UseXValues = True
			stock.InflateMargins = True
			stock.DownFillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(DownCandleColorDropDownList))
			stock.UpFillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(UpCandleColorDropDownList))
			stock.DownStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(DownCandleLineColorDropDownList)
			stock.UpStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(UpCandleLineColorDropDownList)
			stock.HighLowStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(HowLowLineColorDropDownList)
			stock.ShowHighLow = ShowHiLowLineCheckBox.Checked

			' add some stock items
			Const count As Integer = 40
			GenerateOHLCData(stock, count)
			FillStockDates(stock, count)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateOHLCData(ByVal s As NStockSeries, ByVal nCount As Integer)
			Dim prevclose As Double = 300
			Dim open, high, low, close As Double

			s.ClearDataPoints()

			Dim nIndex As Integer = 0
			Do While nIndex < nCount
				open = prevclose

				If prevclose < 25 OrElse Random.NextDouble() > 0.5 Then
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

				prevclose = close

				s.OpenValues.Add(open)
				s.HighValues.Add(high)
				s.LowValues.Add(low)
				s.CloseValues.Add(close)
				nIndex += 1
			Loop
		End Sub
	End Class
End Namespace