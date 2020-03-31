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
	Public Partial Class NGridSurfaceTextureZoningUC
		Inherits NExampleUC
		Protected Label3 As Label
		Protected DrawFlatCheckBoxBox As CheckBox
		Protected ShowFillingCheckBox As CheckBox
		Protected ShowFrameCheckBox As CheckBox

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				PaletteModeDropDownList.Items.Add("Use Fixed Number of Zones")
				PaletteModeDropDownList.Items.Add("Synchronize Palette Zones with Y Axis")
				PaletteModeDropDownList.Items.Add("Use Custom Palette")

				WebExamplesUtilities.FillComboWithValues(PaletteStepsDropDownList, 2, 8, 1)

				' form controls
				PaletteModeDropDownList.SelectedIndex = 0
				PaletteStepsDropDownList.SelectedIndex = 6
				SmoothPaletteCheckBox.Checked = False
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Disabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Grid Surface")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0f
			chart.Depth = 60.0f
			chart.Height = 25.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' setup axes
			Dim ordinalScale As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			ordinalScale = CType(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			' add the surface series
			Dim surface As NGridSurfaceSeries = New NGridSurfaceSeries()
			chart.Series.Add(surface)
			surface.ShadingMode = ShadingMode.Smooth
			surface.FillMode = SurfaceFillMode.ZoneTexture
			surface.FrameMode = SurfaceFrameMode.None
			surface.Data.SetGridSize(200, 200)

			' define a custom palette
			surface.Palette.Clear()
			surface.Palette.Add(-3, Color.FromArgb(112, 211, 162))
			surface.Palette.Add(-2.5, Color.FromArgb(113, 197, 212))
			surface.Palette.Add(-1, Color.FromArgb(114, 162, 212))
			surface.Palette.Add(0, Color.FromArgb(196, 185, 206))
			surface.Palette.Add(2, Color.FromArgb(161, 130, 191))
			surface.Palette.Add(3, Color.FromArgb(198, 170, 165))
			surface.Palette.Add(4, Color.FromArgb(160, 130, 80))

			' generate data
			GenerateSurfaceData(surface)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			Select Case PaletteModeDropDownList.SelectedIndex
				Case 0
					surface.AutomaticPalette = True
					surface.SyncPaletteWithAxisScale = False
					PaletteStepsDropDownList.Enabled = True

				Case 1
					surface.AutomaticPalette = True
					surface.SyncPaletteWithAxisScale = True
					PaletteStepsDropDownList.Enabled = False

				Case 2
					surface.AutomaticPalette = False
					PaletteStepsDropDownList.Enabled = False
			End Select

			surface.SmoothPalette = SmoothPaletteCheckBox.Checked
			surface.PaletteSteps = PaletteStepsDropDownList.SelectedIndex + 2
		End Sub

		Private Sub GenerateSurfaceData(ByVal surface As NGridSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 50.0
			Const dIntervalZ As Double = 50.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = (x * z / 64.0) - Math.Sin(z / 2.4) * Math.Cos(x / 2.4)
					y = Math.Abs(y)
					Dim tmp As Double = (1 - x * x - z * z)
					y -= tmp * tmp * 0.000006

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
