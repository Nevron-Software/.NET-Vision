Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Partial Public Class NGraphicsPathSeriesUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

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
			Me.Name = "NHeatMapUC"
			Me.Size = New System.Drawing.Size(186, 321)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Graphics Path Series")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.BoundsMode = BoundsMode.Stretch

			Dim shapeIndex As Integer = 0
			Dim cellSize As Double = 100
			Dim shapePadding As Double = 10
			Dim palette As New NChartPalette(ChartPredefinedPalette.Nevron)

			For x As Integer = 0 To 1
				For y As Integer = 0 To 1
					Dim graphicsPathSeries As New NGraphicsPathSeries()

					Dim xmin As Double = x * cellSize + shapePadding
					Dim ymin As Double = y * cellSize + shapePadding

					Dim xmax As Double = xmin + cellSize - shapePadding
					Dim ymax As Double = ymin + cellSize - shapePadding
					Dim shapeSize As Double = cellSize - 2 * shapePadding

					Dim path As New NGraphicsPath()

					Select Case shapeIndex
						Case 0
							' rectangle
							graphicsPathSeries.Name = "Rectangle"
							path.AddRectangle(xmin, ymin, xmax - xmin, ymax - ymin)
							graphicsPathSeries.InteractivityStyle = New NInteractivityStyle("Rectangle")

						Case 1
							' ellipse
							graphicsPathSeries.Name = "Ellipse"
							path.AddEllipse(xmin, ymin, xmax - xmin, ymax - ymin)
							graphicsPathSeries.InteractivityStyle = New NInteractivityStyle("Ellipse")

						Case 2
							' triangle
							graphicsPathSeries.Name = "Triangle"
							graphicsPathSeries.InteractivityStyle = New NInteractivityStyle("Triangle")
							path.StartFigure((xmin + xmax) / 2.0, ymin)
							path.LineTo(xmin, ymax)
							path.LineTo(xmax, ymax)
							path.CloseFigure()


						Case 3
							' polygon
							graphicsPathSeries.Name = "Polygon"
							graphicsPathSeries.InteractivityStyle = New NInteractivityStyle("Polygon")
							Dim xcenter As Double = (xmin + xmax) / 2.0
							Dim ycenter As Double = (ymin + ymax) / 2.0

							Dim count As Integer = 8
							Dim radius As Double = shapeSize / 2

							For i As Integer = 0 To count - 1
								Dim angle As Double = Math.PI * 2 * CDbl(i) / CDbl(count)


								If i = 0 Then
									path.StartFigure(xcenter + Math.Cos(angle) * radius, ycenter + Math.Sin(angle) * radius)
								Else
									path.LineTo(xcenter + Math.Cos(angle) * radius, ycenter + Math.Sin(angle) * radius)
								End If
							Next i

							path.CloseFigure()
					End Select

					graphicsPathSeries.FillStyle = New NColorFillStyle(palette.SeriesColors(shapeIndex))
					graphicsPathSeries.GraphicsPath = path

					chart.Series.Add(graphicsPathSeries)

					shapeIndex += 1
				Next y
			Next x

			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			nChartControl1.Controller.Tools.Add(New NTooltipTool())



			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub
	End Class
End Namespace
