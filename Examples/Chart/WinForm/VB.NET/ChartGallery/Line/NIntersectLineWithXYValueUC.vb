Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports System.Collections.Generic
Imports Nevron.Chart.Windows


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NIntersectLineWithXYValueUC
		Inherits NExampleBaseUC

		Private m_HorizontalAxisCursor As NAxisCursor
		Private m_VerticalAxisCursor As NAxisCursor
		Private m_Line As NLineSeries
		Private m_Point As NPointSeries

		Private components As System.ComponentModel.Container = Nothing

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
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' NIntersectLineWithXYValueUC
			' 
			Me.Name = "NIntersectLineWithXYValueUC"
			Me.Size = New System.Drawing.Size(180, 50)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' turn off the legend
			nChartControl1.Legends(0).Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Intersect Line with X/Y Value")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			Dim m_Chart As NChart = nChartControl1.Charts(0)

			m_HorizontalAxisCursor = New NAxisCursor()
			m_HorizontalAxisCursor.BeginEndAxis = CInt(StandardAxis.PrimaryY)
			AddHandler m_HorizontalAxisCursor.ValueChanged, AddressOf OnAxisCursorValueChanged

			m_VerticalAxisCursor = New NAxisCursor()
			m_VerticalAxisCursor.BeginEndAxis = CInt(StandardAxis.PrimaryX)
			AddHandler m_VerticalAxisCursor.ValueChanged, AddressOf OnAxisCursorValueChanged

			m_Chart.Axis(StandardAxis.PrimaryX).Cursors.Add(m_HorizontalAxisCursor)
			m_Chart.Axis(StandardAxis.PrimaryY).Cursors.Add(m_VerticalAxisCursor)

			m_HorizontalAxisCursor.SynchronizeOnMouseAction = m_HorizontalAxisCursor.SynchronizeOnMouseAction Or MouseAction.Move
			m_VerticalAxisCursor.SynchronizeOnMouseAction = m_VerticalAxisCursor.SynchronizeOnMouseAction Or MouseAction.Move

			' 2D line chart
			m_Chart.Series.Clear()
			m_Chart.BoundsMode = BoundsMode.Stretch

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim axes As NAxisCollection = m_Chart.Axes

			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(78, NRelativeUnit.ParentPercentage))

			' add point series
			m_Point = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point.UseXValues = True
			m_Point.FillStyle = New NColorFillStyle(Color.Red)
			m_Point.DataLabelStyle.Visible = False
			m_Point.Size = New NLength(2)

			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.Name = "Point 1"
			m_Line.FillStyle = New NColorFillStyle(Color.Red)
			m_Line.BorderStyle.Color = Color.Pink
			m_Line.DataLabelStyle.Visible = False
			m_Line.UseXValues = True
			m_Line.InflateMargins = True

			' fill with random data
			Dim rand As New Random()
			Dim radius As Double = 1000
			Dim angle As Double = 0

			Dim rStep As Double = 10
			Dim aStep As Double = 10

			For i As Integer = 0 To 999
				Dim y As Double = Math.Sin(angle * 0.0174533F) * radius
				Dim x As Double = Math.Cos(angle * 0.0174533F) * radius

				m_Line.XValues.Add(x)
				m_Line.Values.Add(y)

				radius += rStep
				angle += aStep
			Next i

			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Selection.SelectedObjects.Add(m_Chart)
			nChartControl1.Controller.Tools.Add(New NDataCursorTool())
		End Sub

		Private Sub OnAxisCursorValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			m_Point.XValues.Clear()
			m_Point.Values.Clear()

			Dim xValue As Double = m_HorizontalAxisCursor.Value
			Dim intersections As List(Of Double) = m_Line.IntersectWithXValue(xValue)

			For i As Integer = 0 To intersections.Count - 1
				m_Point.XValues.Add(xValue)
				m_Point.Values.Add(intersections(i))
			Next i

			Dim yValue As Double = m_VerticalAxisCursor.Value
			intersections = m_Line.IntersectWithYValue(yValue)

			For i As Integer = 0 To intersections.Count - 1
				m_Point.XValues.Add(intersections(i))
				m_Point.Values.Add(yValue)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Function GetScaleConfigurator() As NLinearScaleConfigurator
			Dim linearScale As New NLinearScaleConfigurator()

			linearScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)
			linearScale.MinorTickCount = 4

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			Return linearScale
		End Function
	End Class
End Namespace
