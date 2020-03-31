Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NPolarVectorUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 15)
			End If

			' disable frame
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Range")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(60, 90, 108))
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim polarChart As NPolarChart = New NPolarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(polarChart)
			polarChart.DisplayOnLegend = nChartControl1.Legends(0)
			polarChart.DisplayAxesOnTop = True
			polarChart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			polarChart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(90, NRelativeUnit.ParentPercentage))


			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(polarChart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.ViewRangeInflateMode = ScaleViewRangeInflateMode.MajorTick
			linearScale.InflateViewRangeBegin = True
			linearScale.InflateViewRangeEnd = True

			Dim strip As NScaleStripStyle = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(125, Color.Beige))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			linearScale.StripStyles.Add(strip)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			strip = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(125, 192, 192, 192))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.StripStyles.Add(strip)

			' create a polar line series
			Dim vectorSeries As NPolarVectorSeries = New NPolarVectorSeries()
			polarChart.Series.Add(vectorSeries)
			vectorSeries.Name = "Series 1"
			vectorSeries.DataLabelStyle.Visible = False
			vectorSeries.ShadowStyle.Type = ShadowType.LinearBlur
			vectorSeries.ShadowStyle.Color = Color.Red

			Dim dataPointIndex As Integer = 0

			For i As Integer = 0 To 359 Step 30
				For j As Integer = 10 To 100 Step 10
					vectorSeries.Angles.Add(i)
					vectorSeries.Values.Add(j)

					vectorSeries.X2Values.Add(i + j / 10)
					vectorSeries.Y2Values.Add(j)

					vectorSeries.BorderStyles(dataPointIndex) = New NStrokeStyle(1.0f, ColorFromValue(j))
					dataPointIndex += 1
				Next j
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply settings
			polarChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 15.0f
		End Sub

		''' <summary>
		''' 
		''' </summary>
		''' <param name="value"></param>
		''' <returns></returns>
		Private Shared Function ColorFromValue(ByVal value As Double) As Color
			Dim color1 As Color = Color.Red
			Dim color2 As Color = Color.Blue

			Dim factor As Double = value / 100.0
			Dim oneMinusFactor As Double = 1 - factor

			Return Color.FromArgb(CByte(color1.A * oneMinusFactor + color2.A * factor), CByte(color1.R * oneMinusFactor + color2.R * factor), CByte(color1.G * oneMinusFactor + color2.G * factor), CByte(color1.B * oneMinusFactor + color2.B * factor))
		End Function

		Private Sub GenerateData(ByVal series As NPolarSeries, ByVal count As Integer, ByVal scale As Double)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			Dim i As Integer = 0
			Do While i < count
				Dim angle As Double = i * angleStep
				Dim c1 As Double = 1.0 * Math.Sin(angle * 3)
				Dim c2 As Double = 0.3 * Math.Sin(angle * 1.5)
				Dim c3 As Double = 0.05 * Math.Cos(angle * 26)
				Dim c4 As Double = 0.05 * (0.5 - Random.NextDouble())
				Dim value As Double = scale * (Math.Abs(c1 + c2 + c3) + c4)

				If value < 0 Then
					value = 0
				End If

				series.Values.Add(value)
				series.Angles.Add(angle * 180 / Math.PI)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
