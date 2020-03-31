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
	Public Partial Class NPolarPointUC
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
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Point")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(60, 90, 108))
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim polarChart As NPolarChart = New NPolarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(polarChart)
			polarChart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			polarChart.DisplayOnLegend = nChartControl1.Legends(0)
			polarChart.DisplayAxesOnTop = True
			polarChart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			polarChart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(90, NRelativeUnit.ParentPercentage))

			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(polarChart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True

			Dim strip As NScaleStripStyle = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(128, Color.Beige))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			linearScale.StripStyles.Add(strip)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			strip = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(64, 192, 192, 192))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.StripStyles.Add(strip)

			' create three polar point series
			Dim s1 As NSeries = CreatePolarPointSeries("Sample 1", PointShape.Sphere)
			Dim s2 As NSeries = CreatePolarPointSeries("Sample 2", PointShape.Bar)
			Dim s3 As NSeries = CreatePolarPointSeries("Sample 3", PointShape.Pyramid)

			' add the series to the chart
			polarChart.Series.Add(s1)
			polarChart.Series.Add(s2)
			polarChart.Series.Add(s3)

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

		Private Function CreatePolarPointSeries(ByVal name As String, ByVal shape As PointShape) As NSeries
			Dim series As NPolarPointSeries = New NPolarPointSeries()
			series.Name = name
			series.Angles.ValueFormatter = New NNumericValueFormatter("0.00")
			series.DataLabelStyle.Visible = False
			series.DataLabelStyle.Format = "<value> - <angle_in_degrees>"
			series.PointShape = shape
			series.Size = New NLength(1.5f, NRelativeUnit.ParentPercentage)

			' add data
			series.Values.FillRandomRange(Random, 10, 0, 100)
			series.Angles.FillRandomRange(Random, 10, 0, 360)

			Return series
		End Function
	End Class
End Namespace
