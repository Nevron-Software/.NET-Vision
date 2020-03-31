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
	Public Partial Class NLargeSurfaceUC
		Inherits NExampleUC
		Protected Label3 As Label
		Protected DrawFlatCheckBoxBox As CheckBox
		Protected ShowFillingCheckBox As CheckBox
		Protected ShowFrameCheckBox As CheckBox

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				FillModeDropDownList.Items.Add("Uniform")
				FillModeDropDownList.Items.Add("Zone Texture")
				FillModeDropDownList.Items.Add("Zone Texture - Smooth")

				FillModeDropDownList.SelectedIndex = 1
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Disabled

			' setup the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Large Surface")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 55.0f
			chart.Depth = 55.0f
			chart.Height = 4.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft)

			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.AutoLabels = False
			scaleY.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleY.MaxTickCount = 5

			Dim ordinalScale As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			ordinalScale = CType(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			' add the surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.FrameMode = SurfaceFrameMode.None
			surface.FillMode = SurfaceFillMode.Uniform
			surface.PositionValue = 10.0
			surface.ShadingMode = ShadingMode.Smooth
			surface.CellTriangulationMode = SurfaceCellTriangulationMode.Diagonal1

			Dim fill As NColorFillStyle = New NColorFillStyle()
			fill.MaterialStyle.Ambient = Color.FromArgb(100, 100, 90)
			fill.MaterialStyle.Diffuse = Color.FromArgb(100, 100, 90)
			fill.MaterialStyle.Specular = Color.DimGray
			surface.FillStyle = fill

			Using bitmap As Bitmap = New Bitmap(Me.MapPathSecure("~\Images\HeightMap0500.png"))
				surface.Data.InitFromBitmap(bitmap)
			End Using

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))


			Select Case FillModeDropDownList.SelectedIndex
				Case 0
					surface.FillMode = SurfaceFillMode.Uniform

				Case 1
					surface.FillMode = SurfaceFillMode.ZoneTexture
					surface.SmoothPalette = False
					surface.PaletteSteps = 8

				Case 2
					surface.FillMode = SurfaceFillMode.ZoneTexture
					surface.SmoothPalette = True
					surface.PaletteSteps = 7
			End Select
		End Sub
	End Class
End Namespace
