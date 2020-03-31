Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NXYZSCatterSmoothLineUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Scatter Smooth Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Depth = 55.0f
			chart.Width = 55.0f
			chart.Height = 55.0f

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Floor }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup Z axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Floor }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

			' setup the smooth line series
			Dim line As NSmoothLineSeries = CType(chart.Series.Add(SeriesType.SmoothLine), NSmoothLineSeries)
			line.Name = "Smooth Line"
			line.InflateMargins = True
			line.Legend.Mode = SeriesLegendMode.None
			line.DataLabelStyle.Visible = False
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Sphere
			line.MarkerStyle.AutoDepth = False
			line.MarkerStyle.Width = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Depth = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			line.UseXValues = True
			line.UseZValues = True

			ChangeData(line)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub ChangeData(ByVal line As NSmoothLineSeries)
			Dim fSpringHeight As Single = 10
			Dim nWindings As Integer = CInt(Fix(3))
			Dim nComplexity As Integer = CInt(Fix(4))

			Dim dCurrentAngle As Double = 0
			Dim dCurrentHeight As Double = 0
			Dim dCurrentRadius As Double = 5
			Dim dX As Double = 0, dY As Double = 0, dZ As Double = 0

			Dim fHeightStep As Single = fSpringHeight / (nWindings * nComplexity)
			Dim fAngleStepRad As Single = CSng(((360 / nComplexity) * 3.1415926535f) / 180.0f)

			line.Values.Clear()
			line.XValues.Clear()
			line.ZValues.Clear()

			Do While nWindings > 0
				Dim i As Integer = 0
				Do While i < nComplexity
					dX = Math.Cos(dCurrentAngle) * dCurrentRadius
					dZ = Math.Sin(dCurrentAngle) * dCurrentRadius
					dY = dCurrentHeight

					line.Values.Add(dY)
					line.XValues.Add(dX)
					line.ZValues.Add(dZ)

					dCurrentAngle += fAngleStepRad
					dCurrentHeight += fHeightStep
					dCurrentRadius = 2 + Random.NextDouble() * 5
					i += 1
				Loop

				nWindings -= 1
			Loop
		End Sub
	End Class
End Namespace
