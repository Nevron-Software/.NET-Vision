Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NFinancialDashboardUC
		Inherits NExampleBaseUC

		Private WithEvents NewDataButton As Nevron.UI.WinForm.Controls.NButton
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private m_Stock As NStockSeries
		Private m_MinRadialGauge As NRadialGaugePanel
		Private m_MaxRadialGauge As NRadialGaugePanel
		Private m_AvgRadialGauge As NRadialGaugePanel
		Private m_MinIndicator As NNeedleValueIndicator
		Private m_MaxIndicator As NNeedleValueIndicator
		Private m_AvgIndicator As NNeedleValueIndicator

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
		End Sub

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()
			nChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(Color.White, Color.Black)

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Financial Dashboard")
			title.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))
			title.DockMode = PanelDockMode.Top
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(Color.MidnightBlue)
			title.DockMargins = New NMarginsL(10, 10, 10, 0)

			' setup Stock chart
			nChartControl1.Panels.Add(CreateStockChart())

			Dim gaugeContainerPanel As New NDockPanel()
			gaugeContainerPanel.DockMode = PanelDockMode.Fill
			gaugeContainerPanel.Margins = New NMarginsL(10, 0, 10, 10)
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
			NewDataButton_Click(Nothing, Nothing)
		End Sub

		Private Function CreateGaugeLabel(ByVal text As String) As NLabel
			Dim label As New NLabel(text)

			label.DockMode = PanelDockMode.Bottom
			label.TextStyle.FillStyle = New NColorFillStyle(Color.White)
			label.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			label.ContentAlignment = ContentAlignment.TopCenter
			label.BoundsMode = BoundsMode.None
			label.Padding = New NMarginsL(2, 2, 2, 2)
			label.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))

			Return label
		End Function

		Private Function CreateGaugePanel(ByVal labelText As String) As NRadialGaugePanel
			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()
			radialGauge.Size = New NSizeL(New NLength(32, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			radialGauge.BoundsMode = BoundsMode.Fit
			radialGauge.BeginAngle = -180
			radialGauge.SweepAngle = 180
			radialGauge.ContentAlignment = ContentAlignment.BottomRight
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.AutoBorder = RadialGaugeAutoBorder.RoundedOutline
			radialGauge.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))

			' apply effects
			Dim gelEffect As New NGelEffectStyle(PaintEffectShape.RoundedRect)
			gelEffect.CornerRounding = New NLength(10)
			gelEffect.Margins = New NMarginsL(New NLength(0), New NLength(0), New NLength(0), New NLength(60, NRelativeUnit.ParentPercentage))
			radialGauge.PaintEffect = gelEffect

			' apply padding in order to leave room for the axis labels that touch the border
			radialGauge.Padding = New NMarginsL(2, 2, 2, 2)

			' apply margins in order to leave room for the label
			radialGauge.Margins = New NMarginsL(2, 2, 2, 30)

			Dim axis As NGaugeAxis = DirectCast(radialGauge.Axes(0), NGaugeAxis)
			axis.Range = New NRange1DD(0, 400)

'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.Presentation)
			scale_Renamed.LabelFitModes = New LabelFitMode(){}
			scale_Renamed.MinorTickCount = 2
			scale_Renamed.RulerStyle.BorderStyle.Width = New NLength(0)
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.LightGray))
			scale_Renamed.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)

			radialGauge.ChildPanels.Add(CreateGaugeLabel(labelText))

			Return radialGauge
		End Function

		Private Function CreateStockChart() As NCartesianChart
			Dim chart As New NCartesianChart()
			chart.DockMode = PanelDockMode.Top
			chart.Size = New NSizeL(New NLength(0), New NLength(60, NRelativeUnit.ParentPercentage))
			chart.DockMargins = New NMarginsL(10, 10, 10, 10)
			chart.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(125, Color.White))
			chart.BoundsMode = BoundsMode.Stretch
			chart.Padding = New NMarginsL(10, 10, 10, 10)

			' setup X axis
			Dim scaleX As New NRangeTimelineScaleConfigurator()
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
			Dim wdr As New NWeekDayRule(WeekDayBit.All)
			wdr.Saturday = False
			wdr.Sunday = False
			scaleX.Calendar.Rules.Add(wdr)
			scaleX.EnableCalendar = True
			' set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Y axis
			Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim scaleY As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)
			scaleY.InnerMajorTickStyle.Length = New NLength(0)

			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			scaleY.StripStyles.Add(stripStyle)

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
			m_Stock.CandleWidth = New NLength(0.5F, NRelativeUnit.ParentPercentage)
			m_Stock.UseXValues = True
			m_Stock.InflateMargins = True

			Return chart
		End Function

		Private Function CreateIndicator() As NNeedleValueIndicator
			Dim indicator As New NNeedleValueIndicator()

			indicator.Shape.FillStyle = New NGradientFillStyle(Color.White, Color.Red)

			Return indicator
		End Function

		Private Sub DecorateGaugeAxis(ByVal panel As NRadialGaugePanel, ByVal range As NRange1DD, ByVal colorLight As Color, ByVal colorDark As Color)
			Dim axis As NGaugeAxis = DirectCast(panel.Axes(0), NGaugeAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			' create a range indicator
			Dim rangeIndicator As New NRangeIndicator()
			rangeIndicator.OriginMode = OriginMode.Custom
			rangeIndicator.Value = range.Begin
			rangeIndicator.Origin = range.End
			rangeIndicator.BeginWidth = New NLength(10)
			rangeIndicator.EndWidth = New NLength(10)

			rangeIndicator.FillStyle = New NColorFillStyle(Color.FromArgb(100, colorLight))
			rangeIndicator.StrokeStyle.Color = colorLight
			panel.Indicators.Add(rangeIndicator)

			' create a scale section
			Dim scaleSection As New NScaleSectionStyle()
			scaleSection.Range = range
			scaleSection.MajorTickStrokeStyle = New NStrokeStyle(colorLight)
			scaleSection.MinorTickStrokeStyle = New NStrokeStyle(1, colorLight, LinePattern.Dot, 0, 2)

			Dim labelStyle As New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(colorLight, colorDark)
			labelStyle.FontStyle = New NFontStyle("Arial", 10, FontStyle.Bold)
			scaleSection.LabelTextStyle = labelStyle

			scale_Renamed.Sections.Add(scaleSection)
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.NewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' NewDataButton
			' 
			Me.NewDataButton.Location = New System.Drawing.Point(5, 24)
			Me.NewDataButton.Name = "NewDataButton"
			Me.NewDataButton.Size = New System.Drawing.Size(171, 23)
			Me.NewDataButton.TabIndex = 0
			Me.NewDataButton.Text = "Generate New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			' 
			' NFinancialDashboardUC
			' 
			Me.Controls.Add(Me.NewDataButton)
			Me.Name = "NFinancialDashboardUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub NewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewDataButton.Click
			Const count As Integer = 200

			GenerateOHLCData(m_Stock, 100, count, New NRange1DD(50, 350))
			FillStockDates(m_Stock, count)

			Dim min As Double = DirectCast(m_Stock.LowValues(m_Stock.LowValues.FindMinValue()), Double)
			Dim max As Double = DirectCast(m_Stock.HighValues(m_Stock.HighValues.FindMaxValue()), Double)

			m_MinIndicator.Value = min
			m_MaxIndicator.Value = max

			Dim sum As Double = 0

			For i As Integer = 0 To count - 1
				sum += DirectCast(m_Stock.CloseValues(i), Double)
			Next i

			If count > 0 Then
				m_AvgIndicator.Value = sum / count
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
