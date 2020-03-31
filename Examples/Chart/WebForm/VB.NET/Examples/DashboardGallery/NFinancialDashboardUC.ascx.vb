Imports Microsoft.VisualBasic
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	''' <summary>
	'''		
	''' </summary>
	Public Partial Class NFinancialDashboardUC
		Inherits NExampleUC
		Private m_Stock As NStockSeries
		Private m_MinRadialGauge As NRadialGaugePanel
		Private m_MaxRadialGauge As NRadialGaugePanel
		Private m_AvgRadialGauge As NRadialGaugePanel
		Private m_MinIndicator As NNeedleValueIndicator
		Private m_MaxIndicator As NNeedleValueIndicator
		Private m_AvgIndicator As NNeedleValueIndicator

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.Panels.Clear()
			nChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(Color.White, Color.Black)

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddFooter("Financial Dashboard")
			header.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))
			header.DockMode = PanelDockMode.Top
			header.TextStyle.ShadowStyle.Type = ShadowType.Solid
			header.TextStyle.ShadowStyle.Color = Color.White
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 13, FontStyle.Italic)
			header.TextStyle.FillStyle = New NColorFillStyle(Color.MidnightBlue)
			header.DockMargins = New NMarginsL(5, 5, 5, 0)

			' setup Stock chart
			nChartControl1.Panels.Add(CreateStockChart())

			Dim gaugeContainerPanel As NDockPanel = New NDockPanel()
			gaugeContainerPanel.DockMode = PanelDockMode.Fill
			gaugeContainerPanel.Margins = New NMarginsL(5, 0, 5, 5)
			gaugeContainerPanel.PositionChildPanelsInContentBounds = True
			nChartControl1.Panels.Add(gaugeContainerPanel)

			m_MinRadialGauge = CreateGaugePanel("Minimum")
			m_MinRadialGauge.Location = New NPointL(New NLength(0, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
			m_MinIndicator = CreateIndicator()

			DecorateGaugeAxis(m_MinRadialGauge, New NRange1DD(0, 100), Color.Blue, Color.DarkBlue)
			m_MinRadialGauge.Indicators.Add(m_MinIndicator)
			gaugeContainerPanel.ChildPanels.Add(m_MinRadialGauge)

			m_MaxRadialGauge = CreateGaugePanel("Maximum")
			m_MaxRadialGauge.Location = New NPointL(New NLength(34, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
			DecorateGaugeAxis(m_MaxRadialGauge, New NRange1DD(300, 400), Color.Red, Color.DarkRed)
			m_MaxIndicator = CreateIndicator()
			m_MaxRadialGauge.Indicators.Add(m_MaxIndicator)
			gaugeContainerPanel.ChildPanels.Add(m_MaxRadialGauge)

			m_AvgRadialGauge = CreateGaugePanel("Average")
			m_AvgRadialGauge.Location = New NPointL(New NLength(68, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))
			DecorateGaugeAxis(m_AvgRadialGauge, New NRange1DD(100, 300), Color.Green, Color.DarkGreen)
			m_AvgIndicator = CreateIndicator()
			m_AvgRadialGauge.Indicators.Add(m_AvgIndicator)
			gaugeContainerPanel.ChildPanels.Add(m_AvgRadialGauge)

			' generate some data
			GenerateData()
		End Sub

		Private Sub GenerateData()
			WebExamplesUtilities.GenerateOHLCData(m_Stock, 100, 200, New NRange1DD(50, 350))

			Dim min As Double = CDbl(m_Stock.LowValues(m_Stock.LowValues.FindMinValue()))
			Dim max As Double = CDbl(m_Stock.HighValues(m_Stock.HighValues.FindMaxValue()))

			m_MinIndicator.Value = min
			m_MaxIndicator.Value = max

			Dim count As Integer = m_Stock.CloseValues.Count
			Dim sum As Double = 0

			Dim i As Integer = 0
			Do While i < count
				sum += CDbl(m_Stock.CloseValues(i))
				i += 1
			Loop

			If count > 0 Then
				m_AvgIndicator.Value = sum / count
			Else
				m_AvgIndicator.Value = 0
			End If
		End Sub

		Private Function CreateGaugeLabel(ByVal text As String) As NLabel
			Dim label As NLabel = New NLabel(text)

			label.DockMode = PanelDockMode.Bottom
			label.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			label.TextStyle.FontStyle.EmSize = New NLength(9)
			label.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			label.ContentAlignment = ContentAlignment.TopCenter
			label.BoundsMode = BoundsMode.None
			label.Padding = New NMarginsL(2, 2, 2, 2)
			label.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))

			Return label
		End Function

		Private Function CreateGaugePanel(ByVal labelText As String) As NRadialGaugePanel
			' create the radial gauge
			Dim radialGauge As NRadialGaugePanel = New NRadialGaugePanel()
			radialGauge.Size = New NSizeL(New NLength(32, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			radialGauge.BoundsMode = BoundsMode.Fit
			radialGauge.BeginAngle = -180
			radialGauge.SweepAngle = 180
			radialGauge.ContentAlignment = ContentAlignment.BottomRight
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.AutoBorder = RadialGaugeAutoBorder.CutCircle
			radialGauge.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))

			' apply effects
			Dim gelEffect As NGelEffectStyle = New NGelEffectStyle(PaintEffectShape.RoundedRect)
			gelEffect.CornerRounding = New NLength(10)
			gelEffect.Margins = New NMarginsL(New NLength(0), New NLength(0), New NLength(0), New NLength(60, NRelativeUnit.ParentPercentage))
			radialGauge.PaintEffect = gelEffect

			' apply margins in order to leave room for the label
			radialGauge.Margins = New NMarginsL(2, 2, 2, 20)

			Dim axis As NGaugeAxis = CType(radialGauge.Axes(0), NGaugeAxis)

			' apply anchor
			Dim anchor As NDockGaugeAxisAnchor = New NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, False)
			anchor.RulerOrientation = RulerOrientation.Right
			anchor.SynchronizeRulerOrientation = False
			axis.Anchor = anchor

			axis.Range = New NRange1DD(0, 400)

			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation)
			scale.LabelFitModes = New LabelFitMode(){}
			scale.MinorTickCount = 2
			scale.RulerStyle.BorderStyle.Width = New NLength(0)
			scale.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.LightGray))
			scale.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 6, FontStyle.Bold)

			radialGauge.ChildPanels.Add(CreateGaugeLabel(labelText))

			Return radialGauge
		End Function

		Private Function CreateStockChart() As NCartesianChart
			Dim chart As NCartesianChart = New NCartesianChart()
			chart.DockMode = PanelDockMode.Top
			chart.Size = New NSizeL(New NLength(0), New NLength(55, NRelativeUnit.ParentPercentage))
			chart.Margins = New NMarginsL(5, 5, 5, 0)
			chart.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))
			chart.BoundsMode = BoundsMode.Stretch
			chart.Padding = New NMarginsL(5, 5, 5, 0)

			' setup X axis
			Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			Dim ordinalScale As NOrdinalScaleConfigurator = CType(axis.ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, False)
			ordinalScale.InnerMajorTickStyle.Length = New NLength(0)

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

			' setup the stock series
			m_Stock = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.Name = "Price"
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Stick
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue
			m_Stock.OpenValues.Name = "open"
			m_Stock.HighValues.Name = "high"
			m_Stock.LowValues.Name = "low"
			m_Stock.CloseValues.Name = "close"
			m_Stock.CandleWidth = New NLength(0.5f, NRelativeUnit.ParentPercentage)

			Return chart
		End Function

		Private Function CreateIndicator() As NNeedleValueIndicator
			Dim indicator As NNeedleValueIndicator = New NNeedleValueIndicator()

			indicator.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleBegin
			indicator.OffsetFromScale = New NLength(5)
			indicator.Shape.FillStyle = New NGradientFillStyle(Color.White, Color.Red)

			Return indicator
		End Function

		Private Sub DecorateGaugeAxis(ByVal panel As NRadialGaugePanel, ByVal range As NRange1DD, ByVal colorLight As Color, ByVal colorDark As Color)
			Dim axis As NGaugeAxis = CType(panel.Axes(0), NGaugeAxis)
			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			' create a range indicator
			Dim rangeIndicator As NRangeIndicator = New NRangeIndicator()
			rangeIndicator.OriginMode = OriginMode.Custom
			rangeIndicator.Value = range.Begin
			rangeIndicator.Origin = range.End
			rangeIndicator.BeginWidth = New NLength(10)
			rangeIndicator.EndWidth = New NLength(10)

			rangeIndicator.FillStyle = New NColorFillStyle(Color.FromArgb(100, colorLight))
			rangeIndicator.StrokeStyle.Color = colorLight
			panel.Indicators.Add(rangeIndicator)

			' create a scale section
			Dim scaleSection As NScaleSectionStyle = New NScaleSectionStyle()
			scaleSection.Range = range
			scaleSection.MajorTickStrokeStyle = New NStrokeStyle(colorLight)
			scaleSection.MinorTickStrokeStyle = New NStrokeStyle(1, colorLight, LinePattern.Dot, 0, 2)

			Dim labelStyle As NTextStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(colorLight, colorDark)
			labelStyle.FontStyle = New NFontStyle("Arial", 6, FontStyle.Bold)
			scaleSection.LabelTextStyle = labelStyle

			scale.Sections.Add(scaleSection)
		End Sub
	End Class
End Namespace
