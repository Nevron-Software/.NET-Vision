Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NImageResponseUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				ImageTypeDropDownList.Items.Add("PNG")
				ImageTypeDropDownList.Items.Add("JPEG")
				ImageTypeDropDownList.Items.Add("GIF")
				ImageTypeDropDownList.Items.Add("Bitmap")
				ImageTypeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(JPEGQualityDropDownList, 10, 100, 10)
				JPEGQualityDropDownList.SelectedIndex = 9
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None

			' override any settings we may have inherited from the web config file
			nChartControl1.ServerSettings.BrowserResponseSettings.BrowserResponsePairs.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Static Image")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0f
			chart.Depth = 60.0f
			chart.Height = 40.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup axes
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Left, ChartWallType.Back }

			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() {}
			scaleX.RoundToTickMin = False
			scaleX.RoundToTickMax = False

			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ
			scaleZ.RoundToTickMin = False
			scaleZ.RoundToTickMax = False

			' setup series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.FillMode = SurfaceFillMode.Zone
			surface.FrameMode = SurfaceFrameMode.None
			surface.FrameColorMode = SurfaceFrameColorMode.Zone
			surface.SmoothPalette = True
			surface.ShadingMode = ShadingMode.Smooth
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 7
			surface.Data.SetGridSize(20, 20)
			FillData(surface)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			Dim response As NImageResponse = New NImageResponse()

			JPEGQualityDropDownList.Enabled = False

			Select Case ImageTypeDropDownList.SelectedIndex
			Case 0 ' PNG
				response.ImageFormat = New NPngImageFormat()
			Case 1 ' JPEG
				Dim jpegImageFormat As NJpegImageFormat = New NJpegImageFormat()

				JPEGQualityDropDownList.Enabled = True
				jpegImageFormat.Quality = JPEGQualityDropDownList.SelectedIndex * 10 + 10
				response.ImageFormat = jpegImageFormat
			Case 2 ' GIF
				response.ImageFormat = New NGifImageFormat()
			Case 3 ' BMP
				response.ImageFormat = New NBitmapImageFormat()
			End Select

			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = response
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
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
