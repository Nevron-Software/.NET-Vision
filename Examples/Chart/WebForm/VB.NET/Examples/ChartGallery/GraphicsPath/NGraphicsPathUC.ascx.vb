Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NGraphicsPathUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Graphics Path Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Visible = False

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.BoundsMode = BoundsMode.Stretch

			Dim shapeIndex As Integer = 0
			Dim cellSize As Double = 100
			Dim shapePadding As Double = 10
			Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)

			For x As Integer = 0 To 1
				For y As Integer = 0 To 1
					Dim graphicsPathSeries As NGraphicsPathSeries = New NGraphicsPathSeries()

					Dim xmin As Double = x * cellSize + shapePadding
					Dim ymin As Double = y * cellSize + shapePadding

					Dim xmax As Double = xmin + cellSize - shapePadding
					Dim ymax As Double = ymin + cellSize - shapePadding
					Dim shapeSize As Double = cellSize - 2 * shapePadding

					Dim path As NGraphicsPath = New NGraphicsPath()

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

							Dim i As Integer = 0
							Do While i < count
								Dim angle As Double = Math.PI * 2 * CDbl(i) / CDbl(count)


								If i = 0 Then
									path.StartFigure(xcenter + Math.Cos(angle) * radius, ycenter + Math.Sin(angle) * radius)
								Else
									path.LineTo(xcenter + Math.Cos(angle) * radius, ycenter + Math.Sin(angle) * radius)
								End If
								i += 1
							Loop

							path.CloseFigure()
					End Select

					graphicsPathSeries.FillStyle = New NColorFillStyle(palette.SeriesColors(shapeIndex))
					graphicsPathSeries.GraphicsPath = path

					chart.Series.Add(graphicsPathSeries)

					shapeIndex += 1
				Next y
			Next x

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Nevron)
			styleSheet.Apply(nChartControl1.Document)
		End Sub
	End Class
End Namespace
