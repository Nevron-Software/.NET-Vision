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
	Public Partial Class NPolarValueAxisPositionUC
		Inherits NExampleUC
		Private m_CustomAxisId As Integer

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(BeginAngleDropDownList, 0, 360, 15)

				DockRedAxisCheckBox.Checked = False
				PaintReflectionOfRedAxisCheckBox.Checked = False
				DockGreenAxisCheckBox.Checked = True
				PaintReflectionOfGreenAxisCheckBox.Checked = True
			End If

			'
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Value Axis Position")
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
			polarChart.Size = New NSizeL(New NLength(95, NRelativeUnit.ParentPercentage), New NLength(87, NRelativeUnit.ParentPercentage))


			' setup polar axis
			Dim linearScale As NLinearScaleConfigurator = CType(polarChart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(polarChart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.MinTickDistance = New NLength(50)
			angularScale.LabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)
			Dim strip As NScaleStripStyle = New NScaleStripStyle()
			strip.FillStyle = New NColorFillStyle(Color.FromArgb(64, 192, 192, 192))
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Polar, True)
			angularScale.StripStyles.Add(strip)

			' add a const line
			Dim line As NAxisConstLine = polarChart.Axis(StandardAxis.Polar).ConstLines.Add()
			line.Value = 50
			line.StrokeStyle.Color = Color.SlateBlue
			line.StrokeStyle.Width = New NLength(1, NGraphicsUnit.Pixel)

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

			' add a second value axes
			Dim primaryAxis As NPolarAxis = CType(polarChart.Axis(StandardAxis.Polar), NPolarAxis)
			Dim secondaryAxis As NPolarAxis = (CType(polarChart.Axes, NPolarAxisCollection)).AddCustomAxis(PolarAxisOrientation.Value)
			m_CustomAxisId = secondaryAxis.AxisId

			Dim secondaryAnchor As NCrossPolarAxisAnchor = TryCast(secondaryAxis.Anchor, NCrossPolarAxisAnchor)
			secondaryAnchor.Crossings.Clear()
			secondaryAnchor.Crossings.Add(New NValueAxisCrossing(primaryAxis, 90))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' color code the axes and series after the stylesheet is applied
			ApplyColorToAxis(primaryAxis, Color.Red)
			ApplyColorToAxis(secondaryAxis, Color.Green)

			series1.BorderStyle.Color = Color.DarkRed
			series1.BorderStyle.Width = New NLength(2)

			series2.BorderStyle.Color = Color.DarkGreen
			series2.BorderStyle.Width = New NLength(2)

			series2.DisplayOnAxis(StandardAxis.Polar, False)
			series2.DisplayOnAxis(m_CustomAxisId, True)

			' apply the polar orientation
			polarChart.BeginAngle = BeginAngleDropDownList.SelectedIndex * 15

			' set angle of axis labels
			Dim angleAxis As NAxis = polarChart.Axis(StandardAxis.PolarAngle)
			Dim scale As NStandardScaleConfigurator = CType(angleAxis.ScaleConfigurator, NStandardScaleConfigurator)
			scale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 0)

			' configure the red axis
			Dim redAxis As NAxis = polarChart.Axis(StandardAxis.Polar)
			Dim redAnchor As NPolarAxisAnchor

			If DockRedAxisCheckBox.Checked Then
				redAnchor = New NDockPolarAxisAnchor(PolarAxisDockZone.Bottom)
			Else
				Dim crossAnchor As NCrossPolarAxisAnchor = New NCrossPolarAxisAnchor()
				crossAnchor.Crossings.Add(New NValueAxisCrossing(angleAxis, 0))
				redAnchor = crossAnchor
			End If

			redAnchor.PaintReflection = PaintReflectionOfRedAxisCheckBox.Checked
			redAxis.Anchor = redAnchor

			' configure the green axis
			Dim greenAxis As NAxis = polarChart.Axis(m_CustomAxisId)
			Dim greenAnchor As NPolarAxisAnchor

			If DockGreenAxisCheckBox.Checked Then
				Dim dockAnchor As NDockPolarAxisAnchor = New NDockPolarAxisAnchor(PolarAxisDockZone.Left)
				greenAnchor = dockAnchor
			Else
				Dim crossAnchor As NCrossPolarAxisAnchor = New NCrossPolarAxisAnchor()
				crossAnchor.Crossings.Add(New NValueAxisCrossing(angleAxis, 90))
				greenAnchor = crossAnchor
			End If

			greenAnchor.PaintReflection = PaintReflectionOfGreenAxisCheckBox.Checked
			greenAxis.Anchor = greenAnchor
		End Sub

		Private Sub ApplyColorToAxis(ByVal axis As NAxis, ByVal color As Color)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.RulerStyle.BorderStyle.Color = color
			linearScale.OuterMajorTickStyle.LineStyle.Color = color
			linearScale.OuterMinorTickStyle.LineStyle.Color = color
			linearScale.InnerMajorTickStyle.LineStyle.Color = color
			linearScale.InnerMinorTickStyle.LineStyle.Color = color
			linearScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(color)

			axis.InvalidateScale()
		End Sub

		Friend Shared Sub Curve1(ByVal series As NPolarSeries, ByVal count As Integer)
			series.Values.Clear()
			series.Angles.Clear()

			Dim angleStep As Double = 2 * Math.PI / count

			Dim i As Integer = 0
			Do While i < count
				Dim angle As Double = i * angleStep
				Dim radius As Double = 1 + Math.Cos(angle)

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
				Dim radius As Double = 0.2 + 1.7 * Math.Sin(2 * angle) + 1.7 * Math.Cos(2 * angle)

				radius = Math.Abs(radius)

				series.Values.Add(radius)
				series.Angles.Add(angle * 180 / Math.PI)
				i += 1
			Loop
		End Sub
	End Class
End Namespace