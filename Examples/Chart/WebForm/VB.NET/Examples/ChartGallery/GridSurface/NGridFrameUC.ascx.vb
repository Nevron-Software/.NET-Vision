Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NGridFrameUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Wireframe Surface")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 70.0f
			chart.Depth = 70.0f
			chart.Height = 30.0f
			chart.Projection.Type = ProjectionType.Perspective
			chart.Projection.Elevation = 28
			chart.Projection.Rotation = -18
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			If (Not IsPostBack) Then
				RotationTextBox.Text = chart.Projection.Rotation.ToString()
				ElevationTextBox.Text = chart.Projection.Elevation.ToString()

				WebExamplesUtilities.FillComboWithColorNames(LineColorDropDownList, KnownColor.Black)
				WebExamplesUtilities.FillComboWithValues(LineWidhtDropDownList, 1, 5, 1)
			Else
				chart.Projection.Rotation = CSng(Convert.ToDouble(RotationTextBox.Text))
				chart.Projection.Elevation = CSng(Convert.ToDouble(ElevationTextBox.Text))
			End If

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
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Back }
			scaleX.RoundToTickMin = False
			scaleX.RoundToTickMax = False
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Z axis
			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Left }
			scaleZ.RoundToTickMin = False
			scaleZ.RoundToTickMax = False
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			' add the surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.FillMode = SurfaceFillMode.None
			surface.FrameMode = SurfaceFrameMode.Mesh
			surface.Data.SetGridSize(30, 30)
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.0"
			surface.Legend.Mode = SeriesLegendMode.None

			If PaletteFrameCheckBox.Checked Then
				surface.FrameColorMode = SurfaceFrameColorMode.Zone
			Else
				surface.FrameColorMode = SurfaceFrameColorMode.Uniform
			End If

			SmoothPaletteCheckBox.Enabled = PaletteFrameCheckBox.Checked

			If SmoothPaletteCheckBox.Checked Then
				surface.SmoothPalette = True
				surface.Legend.Format = "<zone_value>"
			Else
				surface.SmoothPalette = False
				surface.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			surface.FrameStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList)
			surface.FrameStrokeStyle.Width = New NLength(LineWidhtDropDownList.SelectedIndex + 1, NGraphicsUnit.Pixel)

			FillData(surface)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 30.0
			Const dIntervalZ As Double = 30.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = (x * x) - (z * z)
					y += 200 * Math.Sin(x / 4.0) * Math.Cos(z / 4.0)

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
