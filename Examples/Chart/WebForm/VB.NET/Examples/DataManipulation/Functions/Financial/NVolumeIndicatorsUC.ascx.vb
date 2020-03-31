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
	Public Partial Class NVolumeIndicatorsUC
		Inherits NExampleUC
		Protected ChangeDataButton As System.Web.UI.WebControls.Button
		Private Const numDataPoits As Integer = 200
		Private Const prevCloseValue As Double = 100
		Private Const prevVolumeValue As Double = 100

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddFooter("Volume Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup charts
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			SetupTimeScale(chart.Axis(StandardAxis.PrimaryX))
			Dim stock As NStockSeries = SetupStockChart(chart)
			Dim volume As NAreaSeries = SetupVolumeChart(chart)
			Dim line As NLineSeries = SetupIndicatorChart(chart)

			' form controls
			If (Not IsPostBack) Then
				FunctionDropDownList.Items.Add("Accumulation Distribution")
				FunctionDropDownList.Items.Add("Chaikin Oscillator")
				FunctionDropDownList.Items.Add("Ease of Movement")
				FunctionDropDownList.Items.Add("Money Flow Index")
				FunctionDropDownList.Items.Add("Negative Volume Index")
				FunctionDropDownList.Items.Add("On Balance Volume")
				FunctionDropDownList.Items.Add("Positive Volume Index")
				FunctionDropDownList.Items.Add("Price and Volume Trend")

				FunctionDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(ParameterDropDownList, 0, 100, 10)
				ParameterDropDownList.SelectedIndex = 1
			End If

			Dim [function] As NFunctionCalculator = New NFunctionCalculator()

			' generate data
			GenerateData(stock, volume, line)
			GenerateVolumeData(volume, prevVolumeValue, numDataPoits)

			UpdateFunction(stock, volume, line, [function])

			line.Values = [function].Calculate()
			line.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
			volume.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
		End Sub

		Private Function SetupStockChart(ByVal chart As NCartesianChart) As NStockSeries
			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)

			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 50, 100)
			axisY.ScaleConfigurator = scaleY
			axisY.Visible = True

			' setup the stock series
			Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			stock.Name = "Price"
			stock.Legend.Mode = SeriesLegendMode.None
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Stick

			stock.UpStrokeStyle.Color = Color.RoyalBlue
			stock.OpenValues.Name = "open"
			stock.HighValues.Name = "high"
			stock.LowValues.Name = "low"
			stock.CloseValues.Name = "close"
			stock.CandleWidth = New NLength(0.5f, NRelativeUnit.ParentPercentage)
			stock.UseXValues = True
			stock.InflateMargins = True

			Return stock
		End Function
		Private Function SetupVolumeChart(ByVal chart As NCartesianChart) As NAreaSeries
			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)

			Dim axisY As NAxis = chart.Axis(StandardAxis.SecondaryY)
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 25, 45)
			axisY.ScaleConfigurator = scaleY
			axisY.Visible = True

			' setup the volume series
			Dim volume As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			volume.Name = "Volume"
			volume.Legend.Mode = SeriesLegendMode.None
			volume.FillStyle = New NColorFillStyle(Color.YellowGreen)
			volume.DataLabelStyle.Visible = False
			volume.Values.Name = "volume"
			volume.DisplayOnAxis(StandardAxis.PrimaryY, False)
			volume.DisplayOnAxis(axisY.AxisId, True)
			volume.UseXValues = True

			Return volume
		End Function
		Private Function SetupIndicatorChart(ByVal chart As NCartesianChart) As NLineSeries
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)

			Dim axes As NCartesianAxisCollection = CType(chart.Axes, NCartesianAxisCollection)
			Dim axisY As NAxis = axes.AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft)
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 0, 20)
			axisY.ScaleConfigurator = scaleY
			axisY.Visible = True

			' Add line series for function
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.DataLabelStyle.Visible = False
			line.BorderStyle.Color = Color.Blue
			line.DisplayOnAxis(StandardAxis.PrimaryY, False)
			line.DisplayOnAxis(axisY.AxisId, True)
			line.UseXValues = True

			Return line
		End Function
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

		Private Sub GenerateData(ByVal stock As NStockSeries, ByVal volume As NAreaSeries, ByVal line As NLineSeries)
			WebExamplesUtilities.GenerateOHLCData(stock, prevCloseValue, numDataPoits)
			FillStockDates(stock, numDataPoits, New DateTime(2010, 1, 11))
			GenerateVolumeData(volume, prevVolumeValue, numDataPoits)

			volume.XValues.Clear()
			volume.XValues.AddRange(stock.XValues)

			line.XValues.Clear()
			line.XValues.AddRange(stock.XValues)
		End Sub
		Private Sub GenerateVolumeData(ByVal series As NSeries, ByVal dValue As Double, ByVal nCount As Integer)
			series.ClearDataPoints()

			Dim i As Integer = 0
			Do While i < nCount
				If dValue <= 0 Then
					dValue += 15
				End If

				series.Values.Add(dValue)

				dValue += 10 * (0.5 - Random.NextDouble())
				i += 1
			Loop
		End Sub

		Private Sub UpdateFunction(ByVal stock As NStockSeries, ByVal volume As NAreaSeries, ByVal line As NLineSeries, ByVal [function] As NFunctionCalculator)
			Dim nParam As Integer = ParameterDropDownList.SelectedIndex * 10
			Dim sb As StringBuilder = New StringBuilder()

			Select Case FunctionDropDownList.SelectedIndex
				Case 0
					[function].Arguments.Add(volume.Values)
					[function].Arguments.Add(stock.CloseValues)
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.Append("ACCDIST(close; high; low; volume)")
					line.Name = "Accumulation Distribution"
					ParameterDropDownList.Enabled = False

				Case 1
					[function].Arguments.Add(volume.Values)
					[function].Arguments.Add(stock.CloseValues)
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.Append("CHOSC(close; high; low; volume; 3; 10)")
					line.Name = "Chaikin Oscillator"
					ParameterDropDownList.Enabled = False

				Case 2
					[function].Arguments.Add(volume.Values)
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.Append("EMV(high; low; volume)")
					line.Name = "Ease of Movement"
					ParameterDropDownList.Enabled = False

				Case 3
					[function].Arguments.Add(volume.Values)
					[function].Arguments.Add(stock.CloseValues)
					[function].Arguments.Add(stock.HighValues)
					[function].Arguments.Add(stock.LowValues)
					sb.AppendFormat("MFI(close; high; low; volume; {0})", nParam)
					line.Name = "Money Flow Index"
					ParameterDropDownList.Enabled = True

				Case 4
					[function].Arguments.Add(volume.Values)
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("NVI(close; volume; {0})", nParam)
					line.Name = "Negative Volume Index"
					ParameterDropDownList.Enabled = True

				Case 5
					[function].Arguments.Add(volume.Values)
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("OBV(close; volume; {0})", prevVolumeValue)
					line.Name = "On Balance Volume"
					ParameterDropDownList.Enabled = False

				Case 6
					[function].Arguments.Add(volume.Values)
					[function].Arguments.Add(stock.CloseValues)
					sb.AppendFormat("PVI(close; volume; {0})", nParam)
					line.Name = "Positive Volume Index"
					ParameterDropDownList.Enabled = True

				Case 7
					[function].Arguments.Add(volume.Values)
					[function].Arguments.Add(stock.CloseValues)
					sb.Append("PVT(close; volume; 0)")
					line.Name = "Price and Volume Trend"
					ParameterDropDownList.Enabled = False

				Case Else
					Return
			End Select

			[function].Expression = sb.ToString()

			ExpressionLabel.Text = [function].Expression
		End Sub
	End Class
End Namespace
