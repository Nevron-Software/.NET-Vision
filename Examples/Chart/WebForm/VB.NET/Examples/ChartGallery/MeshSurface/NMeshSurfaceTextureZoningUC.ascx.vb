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
	Public Partial Class NMeshSurfaceTextureZoningUC
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

				' init form controls
				PaletteModeDropDownList.SelectedIndex = 0
				PaletteStepsDropDownList.SelectedIndex = 6
				SmoothPaletteCheckBox.Checked = False
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface")
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
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale

			linearScale = New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale

			' setup surface series
			Dim surface As NMeshSurfaceSeries = New NMeshSurfaceSeries()
			chart.Series.Add(surface)
			surface.ShadingMode = ShadingMode.Smooth
			surface.FillMode = SurfaceFillMode.ZoneTexture
			surface.FrameMode = SurfaceFrameMode.None
			surface.Data.SetGridSize(100, 100)

			' define a custom palette
			surface.Palette.Clear()
			surface.Palette.Add(-0.8, Color.FromArgb(112, 211, 162))
			surface.Palette.Add(-0.4, Color.FromArgb(113, 197, 212))
			surface.Palette.Add(-0.2, Color.FromArgb(114, 162, 212))
			surface.Palette.Add(0, Color.FromArgb(196, 185, 206))
			surface.Palette.Add(0.4, Color.FromArgb(161, 130, 191))
			surface.Palette.Add(0.8, Color.FromArgb(198, 170, 165))
			surface.Palette.Add(1, Color.FromArgb(160, 130, 80))

			' generate data
			GenerateSurfaceData(surface)


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

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateSurfaceData(ByVal surface As NMeshSurfaceSeries)
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 40.0
			Const dIntervalZ As Double = 40.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			Dim pz As Double = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				Dim px As Double = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					Dim x As Double = px + Math.Sin(pz) * 0.4
					Dim z As Double = pz + Math.Cos(px) * 0.4
					Dim y As Double = Math.Sin(px * 0.33) * Math.Sin(pz * 0.33)

					If y < 0 Then
						y = - y * 0.7
					End If

					Dim tmp As Double = (1 - x * x - z * z)
					y -= tmp * tmp * 0.000001

					surface.Data.SetValue(i, j, y, x, z)
					i += 1
					px += dIncrementX
				Loop
				j += 1
				pz += dIncrementZ
			Loop
		End Sub
	End Class
End Namespace
