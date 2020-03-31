Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NMeshIntersectedUC
		Inherits NExampleUC
		Protected Label3 As Label

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not nChartControl1.Initialized) Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Settings.JitterMode = JitterMode.Enabled

				' set a chart title
				Dim title As NLabel = nChartControl1.Labels.AddHeader("Intersected Surfaces")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

				' no legend
				nChartControl1.Legends.Clear()

				' setup chart
				Dim chart As NChart = nChartControl1.Charts(0)
				chart.Enable3D = True
				chart.Width = 65.0f
				chart.Depth = 65.0f
				chart.Height = 30.0f
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

				' setup Y axis
				Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
				linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)

				' add interlace stripe
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
				stripStyle.Interlaced = True
				stripStyle.SetShowAtWall(ChartWallType.Back, True)
				stripStyle.SetShowAtWall(ChartWallType.Left, True)
				linearScaleConfigurator.StripStyles.Add(stripStyle)

				' setup X axis
				linearScaleConfigurator = New NLinearScaleConfigurator()
				linearScaleConfigurator.RoundToTickMin = False
				linearScaleConfigurator.RoundToTickMax = False
				linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
				linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Back }
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

				' setup Z axis
				linearScaleConfigurator = New NLinearScaleConfigurator()
				linearScaleConfigurator.RoundToTickMin = False
				linearScaleConfigurator.RoundToTickMax = False
				linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
				linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Left }
				chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

				' setup surface series 1
				Dim surface1 As NMeshSurfaceSeries = CType(chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
				surface1.Name = "Surface 1"
				surface1.FillMode = SurfaceFillMode.Zone
				surface1.FrameMode = SurfaceFrameMode.MeshContour
				surface1.FrameColorMode = SurfaceFrameColorMode.Zone
				surface1.SmoothPalette = True
				surface1.Legend.Mode = SeriesLegendMode.None
				surface1.FillStyle.SetTransparencyPercent(50)
				surface1.Data.SetGridSize(20, 20)
				surface1.ShadingMode = ShadingMode.Smooth
				FillData1(surface1)

				' setup surface series 2
				Dim surface2 As NMeshSurfaceSeries = CType(chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
				surface2.Name = "Surface 2"
				surface2.FillMode = SurfaceFillMode.Zone
				surface2.FrameMode = SurfaceFrameMode.MeshContour
				surface2.FrameColorMode = SurfaceFrameColorMode.Zone
				surface2.SmoothPalette = True
				surface2.Legend.Mode = SeriesLegendMode.None
				surface2.Data.SetGridSize(20, 20)
				surface2.ShadingMode = ShadingMode.Smooth
				FillData2(surface2)

				nChartControl1.Controller.SetActivePanel(chart)
				nChartControl1.Controller.Tools.Add(New NTrackballTool())
			End If

			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithPercents(TransparencyDropDownList, 10)
				TransparencyDropDownList.SelectedIndex = 5
			End If

			UpdateSurface()
		End Sub

		Private Sub UpdateSurface()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim title As NLabel = nChartControl1.Labels(0)
			Dim surface1 As NSurfaceSeriesBase = CType(chart.Series(0), NSurfaceSeriesBase)
			Dim surface2 As NSurfaceSeriesBase = CType(chart.Series(1), NSurfaceSeriesBase)

			If Surface1ShowFrameCheckBox.Checked Then
				surface1.FrameMode = SurfaceFrameMode.MeshContour
			Else
				surface1.FrameMode = SurfaceFrameMode.None
			End If

			If Surface2ShowFrameCheckBox.Checked Then
				surface2.FrameMode = SurfaceFrameMode.MeshContour
			Else
				surface2.FrameMode = SurfaceFrameMode.None
			End If

			surface1.FillStyle.SetTransparencyPercent(TransparencyDropDownList.SelectedIndex * 10)
			surface1.SmoothPalette = Surface1SmoothPaletteCheckBox.Checked
			surface2.SmoothPalette = Surface2SmoothPaletteCheckBox.Checked

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub FillData1(ByVal surface As NMeshSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 20.0
			Const dIntervalZ As Double = 20.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = Math.Sqrt((x * x) + (z * z) + 2)
					y -= 0.08 * Math.Sqrt(Math.Abs(Math.Sinh(x)))

					If x < 0 Then
						y += 0.11 * x * x
					End If

					surface.Data.SetValue(i, j, y, x, z)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

		Private Sub FillData2(ByVal surface As NMeshSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 20.0
			Const dIntervalZ As Double = 20.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					If (x > 0) AndAlso (x < 10) AndAlso (z > -7) AndAlso (z < 7) Then
						y = 15 * Math.Abs(Math.Sin(x / 4) * Math.Cos(z / 4))
					Else
						y = 2 * Math.Sin(x / 2) * Math.Cos(z / 2)
					End If

					surface.Data.SetValue(i, j, y, x, z)
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

	End Class
End Namespace