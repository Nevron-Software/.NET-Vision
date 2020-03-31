Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NProjectedContourUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Contour Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.Enable3D = True
			chart.Width = 55.0f
			chart.Depth = 55.0f
			chart.Height = 45.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyCameraLight)

			SetupAxisAnchorsAndWalls(chart)

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.RoundToTickMax = False
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY.View = New NRangeAxisView(New NRange1DD(0, 100), True, False)
			axisY.ScaleConfigurator = scaleY

			' setup X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.RoundToTickMin = False
			scaleX.RoundToTickMax = False
			Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)
			axisX.ScaleConfigurator = scaleX

			' setup Z axis
			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType(){}
			scaleZ.RoundToTickMin = False
			scaleZ.RoundToTickMax = False
			Dim axisZ As NAxis = chart.Axis(StandardAxis.Depth)
			axisZ.ScaleConfigurator = scaleZ

			' add a surface series
			Dim surface As NGridSurfaceSeries = New NGridSurfaceSeries()
			chart.Series.Add(surface)
			surface.Name = "Surface"
			surface.Legend.Mode = SeriesLegendMode.None
			surface.FillStyle = New NColorFillStyle(Color.FromArgb(160, 170, 212))
			surface.FillMode = SurfaceFillMode.Uniform
			surface.FrameMode = SurfaceFrameMode.None
			surface.DrawFlat = False
			surface.ShadingMode = ShadingMode.Smooth
			SetupCommonSurfaceProperties(surface)

			' add a surface series
			Dim contour As NGridSurfaceSeries = New NGridSurfaceSeries()
			chart.Series.Add(contour)
			contour.Name = "Contour"
			contour.Legend.Mode = SeriesLegendMode.SeriesLogic
			contour.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			contour.FillMode = SurfaceFillMode.Zone
			contour.FrameMode = SurfaceFrameMode.Contour
			contour.DrawFlat = True
			contour.ShadingMode = ShadingMode.Flat
			SetupCommonSurfaceProperties(contour)

			contour.AutomaticPalette = False
			contour.Palette.Clear()
			contour.Palette.Add(250, Color.FromArgb(112, 211, 162))
			contour.Palette.Add(311, Color.FromArgb(113, 197, 212))
			contour.Palette.Add(328, Color.FromArgb(114, 162, 212))
			contour.Palette.Add(344, Color.FromArgb(196, 185, 206))
			contour.Palette.Add(358, Color.FromArgb(161, 130, 191))
			contour.Palette.Add(370, Color.FromArgb(198, 170, 165))
			contour.Palette.Add(400, Color.FromArgb(255, 0, 0))

			' fill both surfaces with the same data
			FillData(surface, contour)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries, ByVal contour As NGridSurfaceSeries)
			Dim stream As Stream = Nothing
			Dim reader As BinaryReader = Nothing

			Try
				' fill the XYZ data from a binary resource
				Dim path As String = MapPathSecure(TemplateSourceDirectory) & "\DataY.bin"
				stream = New FileStream(path, FileMode.Open, FileAccess.Read)
				reader = New BinaryReader(stream)

				Dim dataPointsCount As Integer = CInt(Fix(stream.Length / 4))
				Dim sizeX As Integer = CInt(Fix(Math.Sqrt(dataPointsCount)))
				Dim sizeZ As Integer = sizeX

				surface.Data.SetGridSize(sizeX, sizeZ)
				contour.Data.SetGridSize(sizeX, sizeZ)

				Dim z As Integer = 0
				Do While z < sizeZ
					Dim x As Integer = 0
					Do While x < sizeX
						Dim value As Double = 300 + 0.3 * CDbl(reader.ReadSingle())
						surface.Data.SetValue(x, z, value)
						contour.Data.SetValue(x, z, value)
						x += 1
					Loop
					z += 1
				Loop
			Finally
				If Not reader Is Nothing Then
					reader.Close()
				End If

				If Not stream Is Nothing Then
					stream.Close()
				End If
			End Try
		End Sub

		Private Sub SetupCommonSurfaceProperties(ByVal surface As NGridSurfaceSeries)
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 6
			surface.UseCustomXOriginAndStep = True
			surface.OriginX = -150
			surface.StepX = 10
			surface.UseCustomZOriginAndStep = True
			surface.OriginZ = -150
			surface.StepZ = 10
		End Sub

		Private Sub SetupAxisAnchorsAndWalls(ByVal chart As NCartesianChart)
			For Each axis As NAxis In chart.Axes
				Dim orientation As AxisOrientation = axis.AxisOrientation
				axis.Anchor = New NBestVisibilityAxisAnchor(orientation)
			Next axis

			For Each wall As NChartWall In chart.Walls
				wall.VisibilityMode = WallVisibilityMode.Auto
			Next wall
		End Sub
	End Class
End Namespace
