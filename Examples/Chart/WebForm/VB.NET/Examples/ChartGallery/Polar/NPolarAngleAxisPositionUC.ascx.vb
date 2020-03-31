Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Configuration
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
	Public Partial Class NPolarAngleAxisPositionUC
		Inherits NExampleUC
		Private m_CustomAxisId As Integer

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 15)
				DockDegreeAxisCheckBox.Checked = True
				DockGradAxisCheckBox.Checked = False
			End If

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Angle Axis Position")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim polarChart As NPolarChart = New NPolarChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(polarChart)
			polarChart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			polarChart.DisplayOnLegend = nChartControl1.Legends(0)
			polarChart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			polarChart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(87, NRelativeUnit.ParentPercentage))

			' create a polar line series
			Dim series1 As NPolarLineSeries = New NPolarLineSeries()
			polarChart.Series.Add(series1)
			series1.Name = "Series 1"
			series1.CloseContour = True
			series1.DataLabelStyle.Visible = False
			series1.MarkerStyle.Visible = False
			series1.MarkerStyle.Width = New NLength(1, NRelativeUnit.ParentPercentage)
			series1.MarkerStyle.Height = New NLength(1, NRelativeUnit.ParentPercentage)
			Curve1(series1, 50)

			' create a polar line series
			Dim series2 As NPolarLineSeries = New NPolarLineSeries()
			polarChart.Series.Add(series2)
			series2.Name = "Series 2"
			series2.CloseContour = True
			series2.DataLabelStyle.Visible = False
			series2.MarkerStyle.Visible = False
			series2.MarkerStyle.Width = New NLength(1, NRelativeUnit.ParentPercentage)
			series2.MarkerStyle.Height = New NLength(1, NRelativeUnit.ParentPercentage)
			Curve2(series2, 100)

			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(polarChart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			Dim strip As NScaleStripStyle = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.Beige)
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			linearScale.StripStyles.Add(strip)

			' setup polar angle axis
			Dim degreeScale As NAngularScaleConfigurator = CType(polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			degreeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)
			degreeScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			degreeScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)

			' add a second value axes
			Dim valueAxis As NPolarAxis = CType(polarChart.Axis(StandardAxis.Polar), NPolarAxis)

			Dim degreeAxis As NPolarAxis = CType(polarChart.Axis(StandardAxis.PolarAngle), NPolarAxis)
			Dim gradAxis As NPolarAxis = (CType(polarChart.Axes, NPolarAxisCollection)).AddCustomAxis(PolarAxisOrientation.Angle)

			Dim gradScale As NAngularScaleConfigurator = New NAngularScaleConfigurator()
			gradScale.AngleUnit = NAngleUnit.Grad
			gradScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)
			gradScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)
			gradAxis.ScaleConfigurator = gradScale
			m_CustomAxisId = gradAxis.AxisId

			Dim secondaryAnchor As NCrossPolarAxisAnchor = New NCrossPolarAxisAnchor(PolarAxisOrientation.Angle)
			secondaryAnchor.Crossings.Add(New NValueAxisCrossing(valueAxis, 10))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' color code the axes and series after the stylesheet is applied
			ApplyColorToAxis(degreeAxis, Color.Red)
			ApplyColorToAxis(gradAxis, Color.Green)

			series1.BorderStyle.Width = New NLength(2)
			series2.BorderStyle.Width = New NLength(2)

			' set the begin angle
			polarChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 15

			' configure axis docking / crossing
			If DockDegreeAxisCheckBox.Checked Then
				degreeAxis.Anchor = New NDockPolarAxisAnchor()
			Else
				degreeAxis.Anchor = New NCrossPolarAxisAnchor(PolarAxisOrientation.Angle, New NValueAxisCrossing(valueAxis, 0.0))
			End If

			If DockGradAxisCheckBox.Checked Then
				gradAxis.Anchor = New NDockPolarAxisAnchor()
			Else
				gradAxis.Anchor = New NCrossPolarAxisAnchor(PolarAxisOrientation.Angle, New NValueAxisCrossing(valueAxis, 100.0))
			End If
		End Sub

		Private Sub ApplyColorToAxis(ByVal axis As NAxis, ByVal color As Color)
			Dim scale As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)

			scale.RulerStyle.BorderStyle.Color = color
			scale.OuterMajorTickStyle.LineStyle.Color = color
			scale.OuterMinorTickStyle.LineStyle.Color = color
			scale.InnerMajorTickStyle.LineStyle.Color = color
			scale.InnerMinorTickStyle.LineStyle.Color = color
			scale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(color)

			axis.InvalidateScale()
		End Sub

		Friend Shared Sub Curve1(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			Dim i As Integer = 0
			Do While i < count
				Dim angle As Double = i * angleStep
				Dim radius As Double = 100 * Math.Cos(angle)

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
				i += 1
			Loop
		End Sub

		Friend Shared Sub Curve2(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			Dim i As Integer = 0
			Do While i < count
				Dim angle As Double = i * angleStep
				Dim radius As Double = 33 + 100 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle)

				radius = Math.Abs(radius)

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
