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
	<ToolboxItem(False)> _
	Partial Public Class NHeatMapCrossSectionUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Private m_HeatMap As NHeatMapSeries
		Private m_BeginEndPointSeries As NPointSeries
		Private m_BeginEndLineSeries As NLineSeries
		Private m_CrossLineSeries As NLineSeries
		Private m_GridSizeX As Integer = 500
		Private m_GridSizeY As Integer = 500
		Private ValueTextBox As UI.WinForm.Controls.NTextBox
		Private label4 As Label




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
			Me.ValueTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' ValueTextBox
			' 
			Me.ValueTextBox.Location = New System.Drawing.Point(3, 35)
			Me.ValueTextBox.Name = "ValueTextBox"
			Me.ValueTextBox.ReadOnly = True
			Me.ValueTextBox.Size = New System.Drawing.Size(169, 18)
			Me.ValueTextBox.TabIndex = 25
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(3, 11)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(169, 16)
			Me.label4.TabIndex = 24
			Me.label4.Text = "Value:"
			' 
			' NHeatMapCrossSectionUC
			' 
			Me.Controls.Add(Me.ValueTextBox)
			Me.Controls.Add(Me.label4)
			Me.Name = "NHeatMapCrossSectionUC"
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
				heatMapChart.Margins = New NMarginsL(10)
				heatMapChart.BoundsMode = BoundsMode.Stretch
				heatMapChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()

				m_BeginEndPointSeries = New NPointSeries()

				m_BeginEndPointSeries.Legend.Mode = SeriesLegendMode.None
				m_BeginEndPointSeries.UseXValues = True
				m_BeginEndPointSeries.DataLabelStyle.Visible = False
				m_BeginEndPointSeries.MarkerStyle.Visible = False
				m_BeginEndPointSeries.Size = New NLength(8)
				m_BeginEndPointSeries.PointShape = PointShape.Ellipse
				m_BeginEndPointSeries.BorderStyle.Width = New NLength(0)

				m_BeginEndPointSeries.Values.Add(m_GridSizeY \ 4)
				m_BeginEndPointSeries.XValues.Add(m_GridSizeX \ 4)
				m_BeginEndPointSeries.FillStyles.Add(0, New NColorFillStyle(Color.Red))

				m_BeginEndPointSeries.Values.Add(m_GridSizeY * 3 \ 4)
				m_BeginEndPointSeries.XValues.Add(m_GridSizeX * 3 \ 4)
				m_BeginEndPointSeries.FillStyles.Add(1, New NColorFillStyle(Color.Blue))

				heatMapChart.Series.Add(m_BeginEndPointSeries)

				m_BeginEndLineSeries = New NLineSeries()
				m_BeginEndLineSeries.UseXValues = True
				m_BeginEndLineSeries.DataLabelStyle.Visible = False
				heatMapChart.Series.Add(m_BeginEndLineSeries)

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
				m_HeatMap.InterpolateImage = False

				m_HeatMap.ContourDisplayMode = ContourDisplayMode.None
				m_HeatMap.Legend.Mode = SeriesLegendMode.SeriesLogic
				m_HeatMap.Legend.Format = "<zone_value>"

				GenerateData()
			End If

			If True Then
				Dim crossSectionLineChart As New NCartesianChart()

				nChartControl1.Panels.Add(crossSectionLineChart)

				crossSectionLineChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
				crossSectionLineChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "Distance"
				crossSectionLineChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Value"

				crossSectionLineChart.DockMode = PanelDockMode.Left
				crossSectionLineChart.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(0))
				crossSectionLineChart.Margins = New NMarginsL(10)
				crossSectionLineChart.BoundsMode = BoundsMode.Stretch

				m_CrossLineSeries = New NLineSeries()
				m_CrossLineSeries.DataLabelStyle.Visible = False
				m_CrossLineSeries.UseXValues = True
				crossSectionLineChart.Series.Add(m_CrossLineSeries)
			End If

			nChartControl1.Controller.Tools.Add(New NSelectorTool())

			AddHandler nChartControl1.MouseMove, AddressOf nChartControl1_MouseMove

			Dim dataPointDragTool As New NDataPointDragTool()

			AddHandler dataPointDragTool.DataPointChanged, AddressOf OnDataPointDragToolDataPointChanged
			dataPointDragTool.DragOutsideAxisRangeMode = DragOutsideAxisRangeMode.Disabled
			nChartControl1.Controller.Tools.Add(dataPointDragTool)

			OnDataPointDragToolDataPointChanged(Nothing, Nothing)
		End Sub

		Private Sub nChartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim view2Scale As New NViewToScale2DTransformation(nChartControl1.Charts(0), CInt(StandardAxis.PrimaryX), CInt(StandardAxis.PrimaryY))

			Dim pointScale As New NVector2DD()
			view2Scale.Transform(New NPointF(e.X, e.Y), pointScale)

			Me.ValueTextBox.Text = m_HeatMap.GetValueFromPosition(New NPointD(pointScale.X, pointScale.Y)).ToString()
		End Sub

		Private Sub OnDataPointDragToolDataPointChanged(ByVal sender As Object, ByVal e As EventArgs)
			' copy the point values to the line series
			m_BeginEndLineSeries.Values.Clear()
			m_BeginEndLineSeries.XValues.Clear()

			For i As Integer = 0 To m_BeginEndPointSeries.Values.Count - 1
				m_BeginEndLineSeries.Values.Add(m_BeginEndPointSeries.Values(i))
				m_BeginEndLineSeries.XValues.Add(m_BeginEndPointSeries.XValues(i))
			Next i

			Dim intersections As List(Of NVector2DD) = m_HeatMap.Get2DIntersections(New NPointD(DirectCast(m_BeginEndPointSeries.XValues(0), Double), DirectCast(m_BeginEndPointSeries.Values(0), Double)), New NPointD(DirectCast(m_BeginEndPointSeries.XValues(1), Double), DirectCast(m_BeginEndPointSeries.Values(1), Double)))

			Dim count As Integer = intersections.Count

			m_CrossLineSeries.Values.Clear()
			m_CrossLineSeries.XValues.Clear()

			For i As Integer = 0 To count - 1
				Dim intersection As NVector2DD = intersections(i)

				m_CrossLineSeries.Values.Add(intersection.Y)
				m_CrossLineSeries.XValues.Add(intersection.X)
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
