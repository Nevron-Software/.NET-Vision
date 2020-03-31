Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Chart.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NGridSurfaceCustomColorsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If IsPostBack Then
				Dim surface As NGridSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NGridSurfaceSeries)

				If SmoothShadingCheckBox.Checked Then
					surface.ShadingMode = ShadingMode.Smooth
				Else
					surface.ShadingMode = ShadingMode.Flat
				End If
				If HasFillingCheckBox.Checked Then
					surface.FillMode = SurfaceFillMode.CustomColors
				Else
					surface.FillMode = SurfaceFillMode.None
				End If

				Select Case FrameModeDropDownList.SelectedIndex
					Case 0 ' none
						surface.FrameMode = SurfaceFrameMode.None
					Case 1 ' mesh
						surface.FrameMode = SurfaceFrameMode.Mesh
					Case 2 ' dots
						surface.FrameMode = SurfaceFrameMode.Dots
				End Select
			Else
				SmoothShadingCheckBox.Checked = True
				HasFillingCheckBox.Checked = True
				WebExamplesUtilities.FillComboWithEnumNames(FrameModeDropDownList, GetType(SurfaceFrameMode))
				FrameModeDropDownList.SelectedIndex = 0

				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Settings.JitterMode = JitterMode.Enabled
				nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed

				nChartControl1.Controller.Tools.Clear()
				nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
				nChartControl1.Controller.Tools.Add(New NTrackballTool())

				' set a chart title
				Dim title As NLabel = nChartControl1.Labels.AddHeader("Grid Surface with Custom Colors")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
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
				surface.FillMode = SurfaceFillMode.CustomColors
				surface.FrameMode = SurfaceFrameMode.None
				surface.FrameColorMode = SurfaceFrameColorMode.CustomColors
				surface.FrameStrokeStyle.Color = Color.Red
				surface.FrameStrokeStyle.Width = New NLength(4)

				surface.Data.UseColors = True
				surface.Data.SetGridSize(50, 50)

				' define a custom palette
				surface.Palette.Clear()
				surface.Palette.Add(-3, DarkOrange)
				surface.Palette.Add(-2.5, LightOrange)
				surface.Palette.Add(-1, LightGreen)
				surface.Palette.Add(0, Turqoise)
				surface.Palette.Add(2, Blue)
				surface.Palette.Add(3, Purple)
				surface.Palette.Add(4, BeautifulRed)

				' generate data
				GenerateSurfaceData(surface)

				' apply layout
				ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
			End If


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

			Dim semiWidth As Single = CSng(Math.Min(nCountX / 2, nCountZ / 2))
			Dim startColor As Color = Color.Red
			Dim endColor As Color = Color.Green

			Dim centerX As Integer = nCountX / 2
			Dim centerZ As Integer = nCountZ / 2

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

					Dim dx As Integer = centerX - i
					Dim dz As Integer = centerZ - j
					Dim distance As Single = CSng(Math.Sqrt(dx * dx + dz * dz))
					surface.Data.SetColor(i, j, InterpolateColors(startColor, endColor, distance / semiWidth))
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub

		Public Shared Function InterpolateColors(ByVal color1 As Color, ByVal color2 As Color, ByVal factor As Single) As Color
			If factor > 1.0f Then
				factor = 1.0f
			End If

			Dim num1 As Integer = (CInt(Fix(color1.R)))
			Dim num2 As Integer = (CInt(Fix(color1.G)))
			Dim num3 As Integer = (CInt(Fix(color1.B)))

			Dim num4 As Integer = (CInt(Fix(color2.R)))
			Dim num5 As Integer = (CInt(Fix(color2.G)))
			Dim num6 As Integer = (CInt(Fix(color2.B)))

			Dim num7 As Byte = CByte(((CSng(num1)) + ((CSng(num4 - num1)) * factor)))
			Dim num8 As Byte = CByte(((CSng(num2)) + ((CSng(num5 - num2)) * factor)))
			Dim num9 As Byte = CByte(((CSng(num3)) + ((CSng(num6 - num3)) * factor)))

			Return Color.FromArgb(num7, num8, num9)
		End Function
	End Class
End Namespace
