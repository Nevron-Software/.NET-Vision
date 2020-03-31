Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NRefreshUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If nChartControl1.RequiresInitialization Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Panels.Clear()
				Dim frame As NStandardFrameStyle = TryCast(nChartControl1.BackgroundStyle.FrameStyle, NStandardFrameStyle)
				frame.InnerBorderWidth = New NLength(0)

				' set a chart title
				Dim header As NLabel = nChartControl1.Labels.AddFooter("Auto Refresh")
				header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				header.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(60, 90, 108))
				header.ContentAlignment = ContentAlignment.BottomRight
				header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

				' setup Line chart
				Dim chart As NCartesianChart = New NCartesianChart()

				chart.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(65, NRelativeUnit.ParentPercentage))
				chart.BoundsMode = BoundsMode.Stretch

				chart.Margins = New NMarginsL(5, 10, 5, 10)
				SetupLineChart(chart)

				nChartControl1.Panels.Add(chart)

				Dim minRadialGauge As NRadialGaugePanel = CreateGaugePanel()
				minRadialGauge.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(35, NRelativeUnit.ParentPercentage))
				minRadialGauge.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(63, NRelativeUnit.ParentPercentage))
				Dim minIndicator As NNeedleValueIndicator = CreateIndicator()
				DecorateGaugeAxis(minRadialGauge, New NRange1DD(0, 100), Color.Blue, Color.DarkBlue)
				minRadialGauge.Indicators.Add(minIndicator)
				minRadialGauge.ChildPanels.Add(CreateGaugeLabel("Min"))
				nChartControl1.Panels.Add(minRadialGauge)

				Dim maxRadialGauge As NRadialGaugePanel = CreateGaugePanel()
				maxRadialGauge.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(35, NRelativeUnit.ParentPercentage))
				maxRadialGauge.Location = New NPointL(New NLength(35, NRelativeUnit.ParentPercentage), New NLength(63, NRelativeUnit.ParentPercentage))
				DecorateGaugeAxis(maxRadialGauge, New NRange1DD(300, 400), Color.Red, Color.DarkRed)
				Dim maxIndicator As NNeedleValueIndicator = CreateIndicator()
				maxRadialGauge.Indicators.Add(maxIndicator)
				maxRadialGauge.ChildPanels.Add(CreateGaugeLabel("Max"))
				nChartControl1.Panels.Add(maxRadialGauge)

				Dim avgRadialGauge As NRadialGaugePanel = CreateGaugePanel()
				avgRadialGauge.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(35, NRelativeUnit.ParentPercentage))
				avgRadialGauge.Location = New NPointL(New NLength(68, NRelativeUnit.ParentPercentage), New NLength(63, NRelativeUnit.ParentPercentage))
				DecorateGaugeAxis(avgRadialGauge, New NRange1DD(100, 300), Color.Green, Color.DarkGreen)
				Dim avgIndicator As NNeedleValueIndicator = CreateIndicator()
				avgRadialGauge.Indicators.Add(avgIndicator)
				avgRadialGauge.ChildPanels.Add(CreateGaugeLabel("Avg"))
				nChartControl1.Panels.Add(avgRadialGauge)

				' generate some data
				GenerateNewData()
			End If
		End Sub

		Protected Sub nChartControl1_AsyncRefresh(ByVal sender As Object, ByVal e As EventArgs)
			Dim line As NLineSeries = CType(nChartControl1.Charts(0).Series(0), NLineSeries)

			If line Is Nothing Then
				Return
			End If

			If line.Values.Count = 0 Then
				Return
			End If

			Dim dPrev As Double = CDbl(line.Values(line.Values.Count - 1))

			Dim value As Double
			GenerateDataPoint(dPrev, New NRange1DD(50, 350), value)
			line.Values.RemoveAt(0)
			line.XValues.RemoveAt(0)

			line.Values.Add(value)

			Dim nLast As Integer
			If line.XValues.Count > 0 Then
				nLast = (line.XValues.Count - 1)
			Else
				nLast = (0)
			End If

			Dim dLastValue As Double = CDbl(line.XValues(nLast))
			line.XValues.Add(DateTime.Now)
			UpdateIndicators(nChartControl1.Document)
		End Sub

		Private Sub GenerateNewData()
			Dim line As NLineSeries = CType(nChartControl1.Charts(0).Series(0), NLineSeries)
			GenerateDateTimeData(line, 100)
			UpdateIndicators(nChartControl1.Document)
		End Sub

		Private Sub GenerateDateTimeData(ByVal s As NLineSeries, ByVal nCount As Integer)
			s.ClearDataPoints()
			Dim dateTime As DateTime = DateTime.Now.AddMilliseconds(-nCount * nChartControl1.AsyncRefreshInterval)
			Dim dPrev As Double = 100
			Dim value As Double
			Dim dataPoint As NDataPoint
			Dim i As Integer = 0
			Do While i < nCount
				GenerateDataPoint(dPrev, New NRange1DD(50, 350), value)
				dataPoint = New NDataPoint(value)
				s.AddDataPoint(dataPoint)
				dPrev = CDbl(s.Values(s.Values.Count - 1))
				dateTime = dateTime.AddMilliseconds(nChartControl1.AsyncRefreshInterval)
				s.XValues.Add(dateTime)
				i += 1
			Loop
		End Sub

		Protected Shared Sub UpdateIndicators(ByVal document As NDocument)
			Dim line As NLineSeries = CType(document.RootPanel.Charts(0).Series(0), NLineSeries)

			Dim min As Double = CDbl(line.Values(line.Values.FindMinValue()))
			Dim max As Double = CDbl(line.Values(line.Values.FindMaxValue()))

			Dim panel1 As NGaugePanel = TryCast(document.RootPanel.ChildPanels(2), NGaugePanel)
			Dim panel2 As NGaugePanel = TryCast(document.RootPanel.ChildPanels(3), NGaugePanel)
			Dim panel3 As NGaugePanel = TryCast(document.RootPanel.ChildPanels(4), NGaugePanel)

			Dim minIndicator As NNeedleValueIndicator = TryCast(panel1.Indicators(1), NNeedleValueIndicator)
			Dim maxIndicator As NNeedleValueIndicator = TryCast(panel2.Indicators(1), NNeedleValueIndicator)
			Dim avgIndicator As NNeedleValueIndicator = TryCast(panel3.Indicators(1), NNeedleValueIndicator)

			minIndicator.Value = min
			maxIndicator.Value = max

			Dim count As Integer = line.Values.Count
			Dim sum As Double = 0

			Dim i As Integer = 0
			Do While i < count
				sum += CDbl(line.Values(i))
				i += 1
			Loop

			If count > 0 Then
				avgIndicator.Value = sum / count
			Else
				avgIndicator.Value = 0
			End If
		End Sub

		Protected Function CreateGaugeLabel(ByVal text As String) As NLabel
			Dim label As NLabel = New NLabel(text)

			label.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			label.TextStyle.FontStyle.EmSize = New NLength(8)
			label.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(90, NRelativeUnit.ParentPercentage))
			label.ContentAlignment = ContentAlignment.TopCenter
			label.BoundsMode = BoundsMode.Fit

			Return label
		End Function

		Protected Function CreateIndicator() As NNeedleValueIndicator
			Dim indicator As NNeedleValueIndicator = New NNeedleValueIndicator()

			indicator.Shape.FillStyle = New NGradientFillStyle(Color.White, Color.Red)
			indicator.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleBegin
			indicator.OffsetFromScale = New NLength(4)

			Return indicator
		End Function

		Protected Sub DecorateGaugeAxis(ByVal panel As NRadialGaugePanel, ByVal range As NRange1DD, ByVal colorLight As Color, ByVal colorDark As Color)
			Dim axis As NGaugeAxis = CType(panel.Axes(0), NGaugeAxis)
			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			Dim rangeIndicator As NRangeIndicator = New NRangeIndicator()
			rangeIndicator.OriginMode = OriginMode.Custom
			rangeIndicator.OffsetFromScale = New NLength(10)
			rangeIndicator.Value = range.Begin
			rangeIndicator.Origin = range.End

			rangeIndicator.FillStyle = New NColorFillStyle(Color.FromArgb(30, colorLight))
			rangeIndicator.StrokeStyle.Width = New NLength(0)
			panel.Indicators.Add(rangeIndicator)

			Dim scaleSection As NScaleSectionStyle = New NScaleSectionStyle()
			scaleSection.Range = range
			scaleSection.MajorTickFillStyle = New NColorFillStyle(colorLight)
			scaleSection.MinorTickFillStyle = New NColorFillStyle(colorLight)

			Dim labelStyle As NTextStyle = New NTextStyle()
			labelStyle.FillStyle = New NColorFillStyle(colorDark)
			labelStyle.FontStyle.Style = FontStyle.Bold
			labelStyle.FontStyle.EmSize = New NLength(6)
			scaleSection.LabelTextStyle = labelStyle

			scale.Sections.Add(scaleSection)
		End Sub

		Protected Function CreateGaugePanel() As NRadialGaugePanel
			' create the radial gauge
			Dim radialGauge As NRadialGaugePanel = New NRadialGaugePanel()
			radialGauge.ContentAlignment = ContentAlignment.BottomRight
			radialGauge.BackgroundFillStyle = New NAdvancedGradientFillStyle(AdvancedGradientScheme.WhiteOnBlack, 0)
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.PaintEffect = New NGlassEffectStyle()

			Dim axis As NGaugeAxis = CType(radialGauge.Axes(0), NGaugeAxis)
			axis.Anchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, True, RulerOrientation.Right, 0, 100)
			axis.Range = New NRange1DD(0, 400)

			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale.LabelFitModes = New LabelFitMode(){}
			scale.MinorTickCount = 4
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.WhiteSmoke))
			scale.LabelStyle.TextStyle.FontStyle.EmSize = New NLength(6)
			scale.MinTickDistance = New NLength(15)

			radialGauge.BeginAngle = -240
			radialGauge.SweepAngle = 300

			Return radialGauge
		End Function

		Protected Function CreateBackgroundPanel() As NBackgroundDecoratorPanel
			Dim backroundStyle As NBackgroundStyle = New NBackgroundStyle()
			backroundStyle.FillStyle = New NColorFillStyle(Color.Transparent)
			Dim frameStyle As NImageFrameStyle = New NImageFrameStyle()
			frameStyle.BackgroundColor = Color.Transparent
			frameStyle.Type = ImageFrameType.Raised
			frameStyle.BorderStyle.Width = New NLength(0)
			backroundStyle.FrameStyle = frameStyle

			Dim backgroundPanel As NBackgroundDecoratorPanel = New NBackgroundDecoratorPanel()
			backgroundPanel.DockMargins = New NMarginsL(New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point), New NLength(5, NGraphicsUnit.Point))
			backgroundPanel.BackgroundStyle = CType(backroundStyle.Clone(), NBackgroundStyle)

			Return backgroundPanel
		End Function

		Private Sub SetupLineChart(ByVal chart As NCartesianChart)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.LightModel.EnableLighting = False
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Wall(ChartWallType.Floor).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False
			chart.DockMargins = New NMarginsL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			Dim dateTimeScale As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()
			dateTimeScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, False)
			dateTimeScale.InnerMajorTickStyle.Length = New NLength(0)
			dateTimeScale.MaxTickCount = 8
			dateTimeScale.MajorTickMode = MajorTickMode.AutoMaxCount
			dateTimeScale.AutoDateTimeUnits = New NDateTimeUnit() { NDateTimeUnit.Second }
			dateTimeScale.RoundToTickMin = False
			dateTimeScale.RoundToTickMax = False
			dateTimeScale.EnableUnitSensitiveFormatting = False
			dateTimeScale.LabelValueFormatter = New NDateTimeValueFormatter("T")
			axis.ScaleConfigurator = dateTimeScale

			' setup Y axis
			axis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)
			linearScale.InnerMajorTickStyle.Length = New NLength(0)

			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup the line series
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Price"
			line.Legend.Mode = SeriesLegendMode.None
			line.DataLabelStyle.Visible = False
			line.FillStyle = New NColorFillStyle(Color.RoyalBlue)
			line.UseXValues = True
		End Sub

		Protected Shared Sub GenerateDataPoint(ByVal dPrev As Double, ByVal range As NRange1DD, <System.Runtime.InteropServices.Out()> ByRef value As Double)
			value = dPrev
			Dim upward As Boolean = False
			If dPrev <= range.Begin Then
				upward = True
			Else
				If dPrev >= range.End Then
					upward = False
				Else
					upward = WebExamplesUtilities.rand.NextDouble() > 0.5
				End If
			End If
			If upward Then
				' upward value change
				value = value + (2 + (WebExamplesUtilities.rand.NextDouble() * 10))
			Else
				' downward value change
				value = value - (2 + (WebExamplesUtilities.rand.NextDouble() * 10))
			End If
		End Sub
	End Class
End Namespace
