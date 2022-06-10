Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.Editors
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Partial Public Class NHeatMapCrossSectionXYUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Private m_HeatMap As NHeatMapSeries
		Private m_XCrossLineSeries As NLineSeries
		Private m_YCrossLineSeries As NLineSeries
		Private m_XCursor As NAxisCursor
		Private m_YCursor As NAxisCursor
		Private m_GridSizeX As Integer = 500
		Private m_GridSizeY As Integer = 500

		Public Sub New()
			InitializeComponent()
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

		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' NHeatMapCrossSectionXYUC
			' 
			Me.Name = "NHeatMapCrossSectionXYUC"
			Me.Size = New System.Drawing.Size(179, 516)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As New NLabel("Heat Map Cross Section")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.DockMode = PanelDockMode.Top
			nChartControl1.Panels.Add(title)

			If True Then
				Dim heatMapChart As New NCartesianChart()
				nChartControl1.Panels.Add(heatMapChart)

				heatMapChart.DockMode = PanelDockMode.Left
				heatMapChart.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(0))
				heatMapChart.BoundsMode = BoundsMode.Stretch
				heatMapChart.Margins = New NMarginsL(10)
				heatMapChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
				heatMapChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "X Value"
				heatMapChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Y Value"

				' create the heat map 
				m_HeatMap = New NHeatMapSeries()
				heatMapChart.Series.Add(m_HeatMap)

				m_HeatMap.Palette.Add(0.0, Color.Purple)
				m_HeatMap.Palette.Add(1.5, Color.MediumSlateBlue)
				m_HeatMap.Palette.Add(3.0, Color.CornflowerBlue)
				m_HeatMap.Palette.Add(4.5, Color.LimeGreen)
				m_HeatMap.Palette.Add(6.0, Color.LightGreen)
				m_HeatMap.Palette.Add(7.5, Color.Yellow)
				m_HeatMap.Palette.Add(9.0, Color.Orange)
				m_HeatMap.Palette.Add(10.5, Color.Red)
				m_HeatMap.XValuesMode = HeatMapValuesMode.OriginAndStep
				m_HeatMap.YValuesMode = HeatMapValuesMode.OriginAndStep
				m_HeatMap.InterpolateImage = True

				m_HeatMap.ContourDisplayMode = ContourDisplayMode.None
				m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic
				m_HeatMap.Legend.Format = "<zone_value>"

				m_XCursor = New NAxisCursor()
				m_XCursor.BeginEndAxis = CInt(StandardAxis.PrimaryY)
				m_XCursor.StrokeStyle.Width = New NLength(2)
				heatMapChart.Axis(StandardAxis.PrimaryX).Cursors.Add(m_XCursor)
				AddHandler m_XCursor.ValueChanged, AddressOf OnXCursorValueChanged

				m_YCursor = New NAxisCursor()
				m_YCursor.BeginEndAxis = CInt(StandardAxis.PrimaryX)
				m_YCursor.StrokeStyle.Width = New NLength(2)
				heatMapChart.Axis(StandardAxis.PrimaryY).Cursors.Add(m_YCursor)
				AddHandler m_YCursor.ValueChanged, AddressOf OnYCursorValueChanged

				GenerateData()
			End If

			If True Then
				Dim dockPanel As New NDockPanel()
				dockPanel.DockMode = PanelDockMode.Fill
				dockPanel.PositionChildPanelsInContentBounds = True
				dockPanel.Margins = New NMarginsL(10)

				Dim xCrossSectionChart As NCartesianChart = Nothing
				CreateCrossSectionChart(xCrossSectionChart, m_XCrossLineSeries)
				xCrossSectionChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "X Value"
				xCrossSectionChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Value"
				dockPanel.ChildPanels.Add(xCrossSectionChart)

				Dim yCrossSectionChart As NCartesianChart = Nothing
				CreateCrossSectionChart(yCrossSectionChart, m_YCrossLineSeries)
				yCrossSectionChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "Y Value"
				yCrossSectionChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Value"
				dockPanel.ChildPanels.Add(yCrossSectionChart)

				nChartControl1.Panels.Add(dockPanel)

				' align the two charts
				Dim guideline As New NSideGuideline(PanelSide.Left)

				guideline.Targets.Add(xCrossSectionChart)
				guideline.Targets.Add(yCrossSectionChart)

				nChartControl1.Document.RootPanel.Guidelines.Add(guideline)
			End If

			m_XCursor.Value = m_GridSizeX / 2.0
			m_YCursor.Value = m_GridSizeY / 2.0

			nChartControl1.Controller.Tools.Add(New NSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisCursorDragTool())
		End Sub

		Private Sub CreateCrossSectionChart(ByRef chart As NCartesianChart, ByRef lineSeries As NLineSeries)
			chart = New NCartesianChart()
			chart.DockMode = PanelDockMode.Top
			chart.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			chart.BoundsMode = BoundsMode.Stretch

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			lineSeries = New NLineSeries()
			lineSeries.DataLabelStyle.Visible = False
			lineSeries.UseXValues = True
			chart.Series.Add(lineSeries)
		End Sub

		Private Sub OnYCursorValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim yCursor As NAxisCursor = DirectCast(sender, NAxisCursor)

			Dim intersections As List(Of NVector2DD) = m_HeatMap.Get2DIntersections(New NPointD(0, yCursor.Value), New NPointD(m_HeatMap.Data.GridSizeX, yCursor.Value))

			m_YCrossLineSeries.Values.Clear()
			m_YCrossLineSeries.XValues.Clear()

			For i As Integer = 0 To intersections.Count - 1
				m_YCrossLineSeries.Values.Add(intersections(i).Y)
				m_YCrossLineSeries.XValues.Add(intersections(i).X)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub OnXCursorValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim xCursor As NAxisCursor = DirectCast(sender, NAxisCursor)

			Dim intersections As List(Of NVector2DD) = m_HeatMap.Get2DIntersections(New NPointD(xCursor.Value, 0), New NPointD(xCursor.Value, m_HeatMap.Data.GridSizeY))

			m_XCrossLineSeries.Values.Clear()
			m_XCrossLineSeries.XValues.Clear()

			For i As Integer = 0 To intersections.Count - 1
				m_XCrossLineSeries.Values.Add(intersections(i).Y)
				m_XCrossLineSeries.XValues.Add(intersections(i).X)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub GenerateData()
			Dim data As NHeatMapData = m_HeatMap.Data
			data.SetGridSize(m_GridSizeX, m_GridSizeY)

			Const dIntervalX As Double = 10.0
			Const dIntervalZ As Double = 10.0
			Dim dIncrementX As Double = (dIntervalX / m_GridSizeX)
			Dim dIncrementZ As Double = (dIntervalZ / m_GridSizeY)

			Dim y, x, z As Double

			z = -(dIntervalZ / 2)

			Dim col As Integer = 0
			Do While col < m_GridSizeX
				x = -(dIntervalX / 2)

				Dim row As Integer = 0
				Do While row < m_GridSizeY
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2)
					y += 3.0 * Math.Sin(x) * Math.Cos(z)

					Dim value As Double = y

					data.SetValue(row, col, value)
					row += 1
					x += dIncrementX
				Loop
				col += 1
				z += dIncrementZ
			Loop
		End Sub
	End Class
End Namespace
