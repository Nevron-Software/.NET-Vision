Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NVectorLegendScaleUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = New NLabel("Vector Legend Scale")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Width = 55.0f
			chart.Height = 55.0f

			chart.Width = 55.0f
			chart.Height = 55.0f

			' setup X axis
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.RoundToTickMin = False
			linearScale.RoundToTickMax = False
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { }
			linearScale.InnerMajorTickStyle.Visible = False

			' setup Y axis
			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.RoundToTickMin = False
			linearScale.RoundToTickMax = False
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { }
			linearScale.InnerMajorTickStyle.Visible = False

			' setup shape series
			Dim vector As NVectorSeries = CType(chart.Series.Add(SeriesType.Vector), NVectorSeries)
			vector.FillStyle = New NColorFillStyle(Color.Red)
			vector.BorderStyle.Color = Color.DarkRed
			vector.DataLabelStyle.Visible = False
			vector.InflateMargins = True
			vector.UseXValues = True
			vector.MinArrowHeadSize = New NSizeL(2, 3)
			vector.MaxArrowHeadSize = New NSizeL(4, 6)
			vector.MinVectorLength = New NLength(8)
			vector.MaxVectorLength = New NLength(30)
			vector.Mode = VectorSeriesMode.Direction
			vector.Legend.Mode = SeriesLegendMode.SeriesLogic

			' fill data
			FillData(vector)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub FillData(ByVal vectorSeries As NVectorSeries)
			Dim x As Double = 0, y As Double = 0
			Dim k As Integer = 0

			For i As Integer = 0 To 9
				x = 1
				y += 1

				For j As Integer = 0 To 9
					x += 1

					Dim dx As Double = Math.Sin(x / 3.0) * Math.Cos((x - y) / 4.0)
					Dim dy As Double = Math.Cos(y / 8.0) * Math.Cos(y / 4.0)

					vectorSeries.XValues.Add(x)
					vectorSeries.Values.Add(y)
					vectorSeries.X2Values.Add(dx)
					vectorSeries.Y2Values.Add(dy)

					vectorSeries.ZValues.Add(y)
					vectorSeries.Z2Values.Add(dy)

					vectorSeries.BorderStyles(k) = New NStrokeStyle(1, ColorFromVector(dx, dy))
					k += 1
				Next j
			Next i
		End Sub

		Private Function ColorFromVector(ByVal dx As Double, ByVal dy As Double) As Color
			Dim length As Double = Math.Sqrt(dx * dx + dy * dy)

			Dim sq2 As Double = Math.Sqrt(2)

			Dim r As Integer = CInt(Fix((255 / sq2) * length))
			Dim g As Integer = 20
			Dim b As Integer = CInt(Fix((255 / sq2) * (sq2 - length)))

			Return Color.FromArgb(r, g, b)
		End Function

	End Class
End Namespace