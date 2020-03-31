Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPanelZoomAndDragToolsUC
		Inherits NExampleBaseUC

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
			' NPanelZoomAndDragToolsUC
			' 
			Me.Name = "NPanelZoomAndDragToolsUC"
			Me.Size = New System.Drawing.Size(180, 200)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Panel Zoom And Drag Tools")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As New NPolarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.DisplayOnLegend = nChartControl1.Legends(0)
			chart.Depth = 5
			chart.Width = 70.0F
			chart.Height = 70.0F

			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			Dim strip As New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.Beige))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			linearScale.StripStyles.Add(strip)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)
			strip = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(125, 192, 192, 192))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.StripStyles.Add(strip)

			' add a const line
			Dim line As NAxisConstLine = chart.Axis(StandardAxis.Polar).ConstLines.Add()
			line.Value = 50
			line.StrokeStyle.Color = Color.SlateBlue
			line.StrokeStyle.Width = New NLength(1, NGraphicsUnit.Pixel)

			' create a polar line series
			Dim series1 As New NPolarLineSeries()
			chart.Series.Add(series1)
			series1.Name = "Series 1"
			series1.CloseContour = True
			series1.DataLabelStyle.Visible = False
			series1.MarkerStyle.Visible = False
			series1.MarkerStyle.Width = New NLength(1, NRelativeUnit.ParentPercentage)
			series1.MarkerStyle.Height = New NLength(1, NRelativeUnit.ParentPercentage)
			Curve1(series1, 50)

			' create a polar line series
			Dim series2 As New NPolarLineSeries()
			chart.Series.Add(series2)
			series2.Name = "Series 2"
			series2.CloseContour = True
			series2.DataLabelStyle.Visible = False
			series2.MarkerStyle.Visible = False
			series2.MarkerStyle.Width = New NLength(1, NRelativeUnit.ParentPercentage)
			series2.MarkerStyle.Height = New NLength(1, NRelativeUnit.ParentPercentage)
			Curve2(series2, 100)

			' create a polar line series
			Dim series3 As New NPolarLineSeries()
			chart.Series.Add(series3)
			series3.Name = "Series 3"
			series3.CloseContour = False
			series3.DataLabelStyle.Visible = False
			series3.MarkerStyle.Visible = False
			series3.MarkerStyle.Width = New NLength(1, NRelativeUnit.ParentPercentage)
			series3.MarkerStyle.Height = New NLength(1, NRelativeUnit.ParentPercentage)
			Curve3(series3, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			nChartControl1.Controller.Selection.Add(chart)

			nChartControl1.Controller.Tools.Add(New NPanelZoomTool())
			nChartControl1.Controller.Tools.Add(New NPanelPanTool())
		End Sub

		Friend Shared Sub Curve1(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			For i As Integer = 0 To count - 1
				Dim angle As Double = i * angleStep
				Dim radius As Double = 1 + Math.Cos(angle)

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
			Next i
		End Sub
		Friend Shared Sub Curve2(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			For i As Integer = 0 To count - 1
				Dim angle As Double = i * angleStep
				Dim radius As Double = 0.2 + 1.7 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle)

				radius = Math.Abs(radius)

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
			Next i
		End Sub
		Friend Shared Sub Curve3(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 4 * Math.PI / count

			For i As Integer = 0 To count - 1
				Dim angle As Double = i * angleStep
				Dim radius As Double = 0.2 + angle / 5.0

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
			Next i
		End Sub
	End Class
End Namespace
