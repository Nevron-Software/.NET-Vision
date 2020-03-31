Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NLineStudiesUC
		Inherits NExampleUC
		Protected DropDownList1 As System.Web.UI.WebControls.DropDownList
		Protected DropDownList2 As System.Web.UI.WebControls.DropDownList

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				LineStudyDropDownList.Items.Add("Fibonacci Arcs")
				LineStudyDropDownList.Items.Add("Fibonacci Fans")
				LineStudyDropDownList.Items.Add("Fibonacci Retracements")
				LineStudyDropDownList.Items.Add("Speed Resistance Lines")
				LineStudyDropDownList.Items.Add("Quadrant Lines")
				LineStudyDropDownList.Items.Add("Trend Line")

				WebExamplesUtilities.FillComboWithEnumValues(TrendlineModeDropDownList, GetType(TrendLineMode))

				' form controls
				LineStudyDropDownList.SelectedIndex = 0
				TrendlineModeDropDownList.SelectedIndex = 1
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = New NLabel()
			title.Text = "Line Studies - " & LineStudyDropDownList.SelectedItem.Text
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			nChartControl1.Panels.Add(title)

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			Dim timeScaleConfigurator As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()
			axis.ScaleConfigurator = timeScaleConfigurator
			timeScaleConfigurator.EnableUnitSensitiveFormatting = False
			timeScaleConfigurator.LabelValueFormatter = New NDateTimeValueFormatter("MMM yy")
			timeScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			timeScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			timeScaleConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			timeScaleConfigurator.RoundToTickMin = False
			timeScaleConfigurator.RoundToTickMax = False
			timeScaleConfigurator.LabelGenerationMode = LabelGenerationMode.SingleLevel

			' setup Y axis
			axis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)
			linearScaleConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			Dim customColor As Color = Color.FromArgb(150, 150, 200)

			' setup the stock series
			Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Bar
			stock.CandleWidth = New NLength(0.3f, NRelativeUnit.ParentPercentage)
			stock.HighLowStrokeStyle.Color = customColor
			stock.UpStrokeStyle.Width = New NLength(0)
			stock.DownStrokeStyle.Width = New NLength(0)
			stock.UpFillStyle = New NColorFillStyle(Color.LightGreen)
			stock.DownFillStyle = New NColorFillStyle(customColor)
			stock.UseXValues = True
			stock.InflateMargins = True

			GenerateData(stock)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			' create line study
			Dim lineStudy As NLineStudy = Nothing
			Dim lineColor As Color = Color.Crimson

			Select Case LineStudyDropDownList.SelectedIndex
				Case 0
					lineStudy = New NFibonacciArcs()

				Case 1
					lineStudy = New NFibonacciFans()

				Case 2
					lineStudy = New NFibonacciRetracements()
					CType(lineStudy, NFibonacciRetracements).RetracementsStrokeStyle.Color = lineColor

				Case 3
					lineStudy = New NSpeedResistanceLines()

				Case 4
					lineStudy = New NQuadrantLines()
					CType(lineStudy, NQuadrantLines).CentralLineStrokeStyle.Color = lineColor

				Case 5
					lineStudy = New NTrendLine()

				Case Else
					Return
			End Select

			' attach the line study to the stock series
			lineStudy.BeginPoint = GetLowPointFromStock(stock, 20)
			lineStudy.EndPoint = GetHighPointFromStock(stock, 80)

			' set the primary line color
			lineStudy.StrokeStyle.Color = lineColor

			InsertFinancialMarker(chart, lineStudy)
			TrendlineModeDropDownList.Enabled = TypeOf lineStudy Is NTrendLine


			' set trend line mode
			Dim trend As NTrendLine = TryCast(chart.Series(0), NTrendLine)

			lineStudy.TrendLineMode = CType(TrendlineModeDropDownList.SelectedIndex, TrendLineMode)

			' set text visibility
			lineStudy.ShowTexts = ShowTextsCheckBox.Checked
		End Sub

		Private Function GetHighPointFromStock(ByVal stock As NStockSeries, ByVal dataPointIndex As Integer) As NPointD
			Dim result As NPointD

			result.X = CDbl(stock.XValues(dataPointIndex))
			result.Y = CDbl(stock.HighValues(dataPointIndex))

			Return result
		End Function

		Private Function GetLowPointFromStock(ByVal stock As NStockSeries, ByVal dataPointIndex As Integer) As NPointD
			Dim result As NPointD

			result.X = CDbl(stock.XValues(dataPointIndex))
			result.Y = CDbl(stock.LowValues(dataPointIndex))

			Return result
		End Function

		Private Sub InsertFinancialMarker(ByVal chart As NChart, ByVal ls As NLineStudy)
			If chart.Series.Count > 1 Then
				chart.Series.RemoveAt(0)
			End If

			chart.Series.Insert(0, ls)
		End Sub

		Private Sub GenerateData(ByVal stock As NStockSeries)
			GenerateOHLCData(stock, 200)

			Dim dt As DateTime = New DateTime(2006, 5, 15)

			For i As Integer = 0 To 199
				stock.XValues.Add(dt.ToOADate())

				dt = dt.Add(New TimeSpan(1, 0, 0, 0))
			Next i

			Dim ms1 As NMarkerStyle = New NMarkerStyle()
			ms1.Visible = True
			ms1.PointShape = PointShape.Ellipse
			ms1.FillStyle = New NColorFillStyle(Color.Red)
			ms1.Width = New NLength(0.4f, NRelativeUnit.ParentPercentage)

			ms1.Height = New NLength(0.4f, NRelativeUnit.ParentPercentage)

			ms1.VertAlign = VertAlign.Bottom
			stock.MarkerStyles(20) = ms1

			Dim ms2 As NMarkerStyle = New NMarkerStyle()
			ms2.Visible = True
			ms2.PointShape = PointShape.Ellipse
			ms2.FillStyle = New NColorFillStyle(Color.Red)
			ms2.Width = New NLength(0.4f, NRelativeUnit.ParentPercentage)

			ms2.Height = New NLength(0.4f, NRelativeUnit.ParentPercentage)

			ms2.VertAlign = VertAlign.Top
			stock.MarkerStyles(80) = ms2
		End Sub

		Private Sub SetTrendlineMode()
		End Sub


		Private Sub GenerateOHLCData(ByVal stock As NStockSeries, ByVal dPrevClose As Double)
			Dim dGrowProbability As Double = 0.0
			Dim open, high, low, close As Double

			stock.ClearDataPoints()
			Dim random As Random = New Random()

			For nIndex As Integer = 0 To 199
				open = dPrevClose

				If dPrevClose < 25 Then
					dGrowProbability = 1.0
				Else
					If ((nIndex >= 20) AndAlso (nIndex <= 80)) OrElse ((nIndex >= 120) AndAlso (nIndex <= 180)) Then
						dGrowProbability = 0.75
					Else
						dGrowProbability = 0.25
					End If
				End If

				If Random.NextDouble() < dGrowProbability Then
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

				stock.OpenValues.Add(open)
				stock.HighValues.Add(high)
				stock.LowValues.Add(low)
				stock.CloseValues.Add(close)
			Next nIndex
		End Sub
	End Class
End Namespace
