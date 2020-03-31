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
	Public Partial Class NMeshGeneralUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.HighSpeed

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup legend
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
			chart.Height = 30.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			If (Not IsPostBack) Then
				' form controls
				FrameStyleDropDownList.Items.Add("None")
				FrameStyleDropDownList.Items.Add("Mesh")
				FrameStyleDropDownList.Items.Add("Contour")
				FrameStyleDropDownList.Items.Add("Mesh-Contour")
				FrameStyleDropDownList.Items.Add("Dots")
				FrameStyleDropDownList.SelectedIndex = 2

				PositionModeDropDownList.Items.Add("Axis Begin")
				PositionModeDropDownList.Items.Add("Axis End")
				PositionModeDropDownList.Items.Add("Custom Value")
				PositionModeDropDownList.SelectedIndex = 0

				RotationTextBox.Text = chart.Projection.Rotation.ToString()
				ElevationTextBox.Text = chart.Projection.Elevation.ToString()

				WebExamplesUtilities.FillComboWithPercents(TransparencyDropDownList, 10)
				WebExamplesUtilities.FillComboWithFloatValues(CustomValueDropDownList, 0, 1, 0.1f)
				CustomValueDropDownList.SelectedIndex = 5
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
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.RoundToTickMin = False
			linearScaleConfigurator.RoundToTickMax = False
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup Z axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.RoundToTickMin = False
			linearScaleConfigurator.RoundToTickMax = False
			linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Left }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

			' setup mesh surface series
			Dim surface As NMeshSurfaceSeries = CType(chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
			surface.Name = "Surface"
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			surface.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			surface.FillMode = SurfaceFillMode.Zone
			surface.PositionValue = 0.5
			surface.Data.SetGridSize(20, 20)
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.ShadingMode = ShadingMode.Smooth

			FillDataXY(surface)

			If PaletteFrameCheckBox.Checked Then
				surface.FrameColorMode = SurfaceFrameColorMode.Zone
			Else
				surface.FrameColorMode = SurfaceFrameColorMode.Uniform
			End If
			surface.DrawFlat = DrawFlatCheckBox.Checked
			surface.PositionMode = CType(PositionModeDropDownList.SelectedIndex, SurfacePositionMode)
			surface.PositionValue = CustomValueDropDownList.SelectedIndex / 10.0
			surface.FrameMode = CType(FrameStyleDropDownList.SelectedIndex, SurfaceFrameMode)
			surface.FillStyle.SetTransparencyPercent(TransparencyDropDownList.SelectedIndex * 10)

			If SmoothPaletteCheckBox.Checked Then
				surface.SmoothPalette = True
				surface.Legend.Format = "<zone_value>"
			Else
				surface.SmoothPalette = False
				surface.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			PositionModeDropDownList.Enabled = DrawFlatCheckBox.Checked
			CustomValueDropDownList.Enabled = DrawFlatCheckBox.Checked
			PaletteFrameCheckBox.Enabled = (surface.FrameMode <> SurfaceFrameMode.None)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, legend)
		End Sub

		Private Sub FillDataXY(ByVal surface As NMeshSurfaceSeries)
			Dim x, y, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Dim j As Integer = 0
			Do While j < nCountZ
				Dim i As Integer = 0
				Do While i < nCountX
					x = 2 + i + Math.Sin(j / 4.0) * 2
					z = 1 + j + Math.Cos(i / 4.0)

					y = Math.Sin(i / 3.0) * Math.Sin(j / 3.0)

					If y < 0 Then
						y = Math.Abs(y / 2.0)
					End If

					surface.Data.SetValue(i, j, y, x, z)
					i += 1
				Loop
				j += 1
			Loop
		End Sub
	End Class
End Namespace