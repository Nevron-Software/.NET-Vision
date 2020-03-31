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
	Public Partial Class NTechnicalPriceIndicatorsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddFooter("Technical Price Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			SetupTimeScale(chart.Axis(StandardAxis.PrimaryX))
			SetupStockChart(chart)
			SetupIndicatorChart(chart)

			Dim stock As NStockSeries = CType(chart.Series(0), NStockSeries)
			Dim line As NLineSeries = CType(chart.Series(1), NLineSeries)

			' generate data
			GenerateData(stock)

			If (Not IsPostBack) Then
				' form controls
				FunctionDropDownList.Items.Add("Average True Range")
				FunctionDropDownList.Items.Add("Chaikin's Volatility")
				FunctionDropDownList.Items.Add("Commodity Channel Index")
				FunctionDropDownList.Items.Add("Detrended Price Oscillator")
				FunctionDropDownList.Items.Add("MACD")
				FunctionDropDownList.Items.Add("Mass Index")
				FunctionDropDownList.Items.Add("Momentum")
				FunctionDropDownList.Items.Add("Momentum Div")
				FunctionDropDownList.Items.Add("Performance")
				FunctionDropDownList.Items.Add("Rate Of Change")
				FunctionDropDownList.Items.Add("Relative Strength Index")
				FunctionDropDownList.Items.Add("Standard Deviation")
				FunctionDropDownList.Items.Add("Stochastic")
				FunctionDropDownList.Items.Add("TRIX")
				FunctionDropDownList.Items.Add("William's %R")

				FunctionDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(PeriodDropDownList, 0, 100, 10)
				PeriodDropDownList.SelectedIndex = 1
			End If

			Dim [function] As NFunctionCalculator = New NFunctionCalculator()

			UpdateFunction(stock, line, [function])

			line.Values = [function].Calculate()
			line.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
		End Sub

		Private Sub SetupStockChart(ByVal chart As NCartesianChart)
			' setup Y axis
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 40, 100)

			Dim scaleY As NLinearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)

			Dim color1 As Color = Color.FromArgb(100, 100, 150)
			Dim color2 As Color = Color.FromArgb(200, 120, 120)

			' setup the stock series
			Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			stock.Name = "Price"
			stock.Legend.Mode = SeriesLegendMode.None
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Bar
			stock.HighLowStrokeStyle.Color = color1
			stock.UpStrokeStyle.Color = color1
			stock.DownStrokeStyle.Color = color2
			stock.UpFillStyle = New NColorFillStyle(color1)
			stock.DownFillStyle = New NColorFillStyle(color2)
			stock.OpenValues.Name = "open"
			stock.HighValues.Name = "high"
			stock.LowValues.Name = "low"
			stock.CloseValues.Name = "close"
			stock.CandleWidth = New NLength(0.4f, NRelativeUnit.ParentPercentage)
			stock.UseXValues = True
			stock.InflateMargins = True
		End Sub
		Private Sub SetupIndicatorChart(ByVal chart As NCartesianChart)
			' setup Y axis
			Dim axisY2 As NAxis = chart.Axis(StandardAxis.SecondaryY)
			axisY2.Visible = True
			axisY2.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 0, 35)

			Dim scaleY2 As NLinearScaleConfigurator = CType(axisY2.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY2.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY2.InnerMajorTickStyle.Length = New NLength(0)

			' Add line series for function
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.DataLabelStyle.Visible = False
			line.BorderStyle.Color = Color.Blue
			line.UseXValues = True
			line.DisplayOnAxis(StandardAxis.PrimaryY, False)
			line.DisplayOnAxis(StandardAxis.SecondaryY, True)
		End Sub
		Private Sub SetupTimeScale(ByVal axis As NAxis)
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

			axis.ScaleConfigurator = scaleX
		End Sub
		Private Sub GenerateData(ByVal stock As NStockSeries)
			Const initialPrice As Double = 100
			Const numDataPoits As Integer = 200

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits)
			FillStockDates(stock, numDataPoits, New DateTime(2010, 1, 11))
		End Sub

		Private Sub UpdateFunction(ByVal stock As NStockSeries, ByVal line As NLineSeries, ByVal [function] As NFunctionCalculator)
			Dim nPeriod As Integer = PeriodDropDownList.SelectedIndex * 10
			Dim sb As StringBuilder = New StringBuilder()

			[function].Arguments.Clear()

			Select Case FunctionDropDownList.SelectedIndex
				Case 0 ' Average True Range
					[function].Arguments.Add(stock.CloseValues)
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.AppendFormat("MMA(TR(close; high; low); {0})", nPeriod)
					line.Name = "Average True Range"
					PeriodDropDownList.Enabled = True

				Case 1 ' Chaikin's Volatility
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.AppendFormat("CHV(high; low; 10; {0})", nPeriod)
					line.Name = "Chaikin's Volatility"
					PeriodDropDownList.Enabled = True

				Case 2 ' Commodity Channel Index
					[function].Arguments.Add(stock.CloseValues)
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.AppendFormat("CCI(close; high; low; {0})", nPeriod)
					line.Name = "Commodity Channel Index"
					PeriodDropDownList.Enabled = True

				Case 3 ' Detrended Price Oscillator
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("DPO(close; {0})", nPeriod)
					line.Name = "Detrended Price Oscillator"
					PeriodDropDownList.Enabled = True

				Case 4 ' Moving Average Convergence Divergence
					[function].Arguments.Add(stock.CloseValues)
					sb.Append("SUB( EMA(close;12) ; EMA(close;26) )")
					line.Name = "MACD"
					PeriodDropDownList.Enabled = False

				Case 5 ' Mass Index
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.AppendFormat("MI(high; low; 15; {0})", nPeriod)
					line.Name = "Mass Index"
					PeriodDropDownList.Enabled = True

				Case 6 ' Momentum
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("MOMENTUM(close; {0})", nPeriod)
					line.Name = "Momentum"
					PeriodDropDownList.Enabled = True

				Case 7 ' Momentum Div
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("MOMENTUMDIV(close; {0})", nPeriod)
					line.Name = "Momentum Div"
					PeriodDropDownList.Enabled = True

				Case 8 ' Performance
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("PERFORMANCE(close)")
					line.Name = "Performance"
					PeriodDropDownList.Enabled = False

				Case 9 ' Rate Of Change
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("ROC(close; {0})", nPeriod)
					line.Name = "Rate Of Change"
					PeriodDropDownList.Enabled = True

				Case 10 ' Relative Strength Index
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("RSI(close; {0})", nPeriod)
					line.Name = "Relative Strength Index"
					PeriodDropDownList.Enabled = True

				Case 11 ' Standard Deviation
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("STDDEV(close; {0})", nPeriod)
					line.Name = "Standard Deviation"
					PeriodDropDownList.Enabled = True

				Case 12 ' Stochastic Oscillator
					[function].Arguments.Add(stock.CloseValues)
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.AppendFormat("STOCHASTIC(close; high; low; {0})", nPeriod)
					line.Name = "Stochastic Oscillator"
					PeriodDropDownList.Enabled = True

				Case 13 ' TRIX
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("TRIX(close; {0})", nPeriod)
					line.Name = "TRIX"
					PeriodDropDownList.Enabled = True

				Case 14 ' William's %R
					[function].Arguments.Add(stock.CloseValues)
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.AppendFormat("WILLIAMSR(close; high; low; {0})", nPeriod)
					line.Name = "William's %R"
					PeriodDropDownList.Enabled = True

				Case Else
					Return
			End Select

			[function].Expression = sb.ToString()
			ExpressionLabel.Text = [function].Expression
		End Sub
	End Class
End Namespace
