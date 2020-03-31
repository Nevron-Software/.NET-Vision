Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NRangeIndicatorsUC
		Inherits NExampleUC
		Protected DropDownList1 As System.Web.UI.WebControls.DropDownList
		Protected DropDownList2 As System.Web.UI.WebControls.DropDownList
		Protected DropDownList3 As System.Web.UI.WebControls.DropDownList

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Bollinger Bands /" & Constants.vbLf & " Envelopes")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.LightModel.EnableLighting = False
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Wall(ChartWallType.Floor).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.Height = 40
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(25, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(73, NRelativeUnit.ParentPercentage))

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

			' setup Y axis
			Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.InnerMajorTickStyle.Length = New NLength(0)

			' Add line series for the upper band
			Dim lineUpper As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			lineUpper.DataLabelStyle.Visible = False
			lineUpper.BorderStyle.Color = Color.Green

			' Add line series for lower band
			Dim lineLower As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			lineLower.DataLabelStyle.Visible = False
			lineLower.BorderStyle.Color = Color.Green

			' Add line series for Simple Moving Average
			Dim lineSMA As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			lineSMA.DataLabelStyle.Visible = False
			lineSMA.BorderStyle.Color = Color.Orange
			lineSMA.Name = "Simple Moving Average"

			Dim color1 As Color = Color.FromArgb(100, 100, 150)
			Dim color2 As Color = Color.FromArgb(200, 120, 120)

			' Setup the stock series
			Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Stick
			stock.CandleWidth = New NLength(0.5f, NRelativeUnit.ParentPercentage)
			stock.UpStrokeStyle.Color = color1
			stock.DownStrokeStyle.Color = color2
			stock.Legend.Mode = SeriesLegendMode.None
			stock.CloseValues.Name = "close"
			stock.UseXValues = True
			stock.InflateMargins = True

			' Add arguments
			Dim upperCalculator As NFunctionCalculator = New NFunctionCalculator()
			Dim lowerCalculator As NFunctionCalculator = New NFunctionCalculator()
			Dim SMACalculator As NFunctionCalculator = New NFunctionCalculator()

			upperCalculator.Arguments.Add(stock.CloseValues)
			lowerCalculator.Arguments.Add(stock.CloseValues)
			SMACalculator.Arguments.Add(stock.CloseValues)

			GenerateData(stock)

			' form controls
			If (Not IsPostBack) Then
				FunctionDropDownList.Items.Add("Bollinger Bands")
				FunctionDropDownList.Items.Add("Envelopes")
				FunctionDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(PeriodDropDownList, 0, 100, 10)
				PeriodDropDownList.SelectedIndex = 2

				WebExamplesUtilities.FillComboWithValues(DeviationDropDownList, 0, 20, 1)
				DeviationDropDownList.SelectedIndex = 2

				ShowPricesCheckBox.Checked = True
				ShowSMACheckBox.Checked = True
			End If

			UpdateExpressions(lineUpper, lineLower, upperCalculator, lowerCalculator, SMACalculator)
			CalculateFunctions(stock, lineUpper, lineLower, lineSMA, upperCalculator, lowerCalculator, SMACalculator)
			stock.Visible = ShowPricesCheckBox.Checked
			lineSMA.Visible = ShowSMACheckBox.Checked
		End Sub

		Private Sub GenerateData(ByVal stock As NStockSeries)
			Const initialPrice As Double = 500
			Const numDataPoits As Integer = 200

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits)
			FillStockDates(stock, numDataPoits, New DateTime(2010, 1, 11))
		End Sub

		Private Sub UpdateExpressions(ByVal lineUpper As NSeries, ByVal lineLower As NSeries, ByVal upperCalculator As NFunctionCalculator, ByVal lowerCalculator As NFunctionCalculator, ByVal SMACalculator As NFunctionCalculator)
			Dim nPeriod As Integer = PeriodDropDownList.SelectedIndex * 10
			Dim nDeviation As Integer = DeviationDropDownList.SelectedIndex

			SMACalculator.Expression = String.Format("SMA(close; {0})", nPeriod)

			If FunctionDropDownList.SelectedIndex = 0 Then
				lineUpper.Name = "Bollinger Band - Upper"
				lineLower.Name = "Bollinger Band - Lower"

				upperCalculator.Expression = String.Format("BOLLINGER(close; {0}; {1})", nPeriod, nDeviation)
				lowerCalculator.Expression = String.Format("BOLLINGER(close; {0}; {1})", nPeriod, -nDeviation)
			Else
				lineUpper.Name = "Envelopes - Upper Line"
				lineLower.Name = "Envelopes - Lower Line"

				upperCalculator.Expression = String.Format("ENV(close; {0}; {1})", nPeriod, nDeviation)
				lowerCalculator.Expression = String.Format("ENV(close; {0}; {1})", nPeriod, -nDeviation)
			End If
		End Sub

		Private Sub CalculateFunctions(ByVal stock As NStockSeries, ByVal lineUpper As NLineSeries, ByVal lineLower As NLineSeries, ByVal lineSMA As NLineSeries, ByVal upperCalculator As NFunctionCalculator, ByVal lowerCalculator As NFunctionCalculator, ByVal SMACalculator As NFunctionCalculator)
			lineUpper.Values = upperCalculator.Calculate()
			lineLower.Values = lowerCalculator.Calculate()
			lineSMA.Values = SMACalculator.Calculate()

			lineUpper.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
			lineUpper.UseXValues = True
			lineLower.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
			lineLower.UseXValues = True
			lineSMA.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
			lineSMA.UseXValues = True
		End Sub
	End Class
End Namespace
