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
	Public Partial Class NPolarAreaUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 15)
				AngleStepDropDownList.Items.Add("15")
				AngleStepDropDownList.Items.Add("30")
				AngleStepDropDownList.Items.Add("45")
				AngleStepDropDownList.Items.Add("90")
				AngleStepDropDownList.SelectedIndex = 0
			End If

			' disable frame
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Area")
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
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)
			Dim strip As NScaleStripStyle = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(64, 192, 192, 192))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.StripStyles.Add(strip)

			' polar area series 1
			Dim series1 As NPolarAreaSeries = New NPolarAreaSeries()
			polarChart.Series.Add(series1)
			series1.Name = "Theoretical"
			series1.DataLabelStyle.Visible = False
			GenerateData(series1, 100, 15.0)

			' polar area series 2
			Dim series2 As NPolarAreaSeries = New NPolarAreaSeries()
			polarChart.Series.Add(series2)
			series2.Name = "Experimental"
			series2.DataLabelStyle.Visible = False
			GenerateData(series2, 100, 10.0)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply settings
			polarChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 15.0f

			Dim angleScale As NAngularScaleConfigurator = TryCast(polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			angleScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			Select Case AngleStepDropDownList.SelectedIndex
				Case 0
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(15, NAngleUnit.Degree)

				Case 1
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(30, NAngleUnit.Degree)

				Case 2
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(45, NAngleUnit.Degree)

				Case 3
					angleScale.MajorTickMode = MajorTickMode.CustomStep
					angleScale.CustomStep = New NAngle(90, NAngleUnit.Degree)
			End Select
		End Sub

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
