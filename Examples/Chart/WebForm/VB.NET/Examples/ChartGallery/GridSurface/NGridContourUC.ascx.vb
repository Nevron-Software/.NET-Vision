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
	Public Partial Class NGridContourUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Contour Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' disable the legend background and some of the gridlines
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterBottomBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterLeftBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterRightBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterTopBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.FillStyle = New NColorFillStyle(Color.Transparent)
			legend.Data.MarkSize = New NSizeL(New NLength(8, NGraphicsUnit.Pixel), New NLength(8, NGraphicsUnit.Pixel))

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 70.0f
			chart.Depth = 70.0f
			chart.Height = 5.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalTop)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.None)

			' setup chart walls
			chart.Wall(ChartWallType.Back).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False

			' setup Y axis
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY.Visible = False

			' setup X axis
			Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)
			CType(axisX.Anchor, NDockAxisAnchor).AxisDockZone = AxisDockZone.FrontTop
			Dim ordinalScaleConfigurator As NOrdinalScaleConfigurator = CType(axisX.ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor }
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScaleConfigurator.DisplayDataPointsBetweenTicks = False

			' setup Z axis
			Dim axisZ As NAxis = chart.Axis(StandardAxis.Depth)
			CType(axisZ.Anchor, NDockAxisAnchor).AxisDockZone = AxisDockZone.TopRight
			ordinalScaleConfigurator = CType(axisZ.ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor }
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScaleConfigurator.DisplayDataPointsBetweenTicks = False

			' add the surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Contour"
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			surface.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			surface.FillMode = SurfaceFillMode.Zone
			surface.FrameMode = SurfaceFrameMode.Contour
			surface.DrawFlat = True
			surface.Data.SetGridSize(30, 30)

			' setup the custom palette
			surface.AutomaticPalette = False
			surface.Palette.Clear()
			surface.Palette.Add(0.0, Color.Purple)
			surface.Palette.Add(1.5, Color.MediumSlateBlue)
			surface.Palette.Add(3.0, Color.CornflowerBlue)
			surface.Palette.Add(4.5, Color.LimeGreen)
			surface.Palette.Add(6.0, Color.LightGreen)
			surface.Palette.Add(7.5, Color.Yellow)
			surface.Palette.Add(9.0, Color.Orange)
			surface.Palette.Add(10.5, Color.Red)
			surface.Palette.Add(100, Color.Red)

			If PaletteFrameCheckBox.Checked Then
				surface.FrameColorMode = SurfaceFrameColorMode.Zone
			Else
				surface.FrameColorMode = SurfaceFrameColorMode.Uniform
			End If

			If SmoothPaletteCheckBox.Checked Then
				surface.SmoothPalette = True
				surface.Legend.Format = "<zone_value>"
			Else
				surface.SmoothPalette = False
				surface.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			If ShowFillingCheckBox.Checked Then
				surface.FillMode = SurfaceFillMode.Zone
			Else
				surface.FillMode = SurfaceFillMode.None
			End If

			If ShowFrameCheckBox.Checked Then
				surface.FrameMode = SurfaceFrameMode.Contour
				PaletteFrameCheckBox.Enabled = True
			Else
				surface.FrameMode = SurfaceFrameMode.None
				PaletteFrameCheckBox.Enabled = False
			End If

			' fill with data
			FillData(surface)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, legend)
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 10.0
			Const dIntervalZ As Double = 10.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = 10 - Math.Sqrt((x * x) + (z * z) + 2)
					y += 3.0 * Math.Sin(x) * Math.Cos(z)

					surface.Data.SetValue(i, j, y)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub
	End Class
End Namespace
