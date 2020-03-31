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
	Public Partial Class NMeshFillEffectUC
		Inherits NExampleUC
		Protected Label3 As Label

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Surface Fill Styles")
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
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			If (Not IsPostBack) Then
				RotationTextBox.Text = chart.Projection.Rotation.ToString()
				ElevationTextBox.Text = chart.Projection.Elevation.ToString()
			Else
				chart.Projection.Rotation = CSng(Convert.ToDouble(RotationTextBox.Text))
				chart.Projection.Elevation = CSng(Convert.ToDouble(ElevationTextBox.Text))
			End If

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
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
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup Z axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.RoundToTickMin = False
			linearScaleConfigurator.RoundToTickMax = False
			linearScaleConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Left }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScaleConfigurator

			' setup mesh surface series
			Dim surface As NMeshSurfaceSeries = CType(chart.Series.Add(SeriesType.MeshSurface), NMeshSurfaceSeries)
			surface.Name = "Surface"
			surface.FrameMode = SurfaceFrameMode.None
			surface.FillMode = SurfaceFillMode.Uniform
			surface.AutomaticPalette = False
			surface.Data.SetGridSize(50, 50)
			surface.ShadingMode = ShadingMode.Smooth

			Select Case SurfaceFillEffectDropDownList.SelectedIndex
				Case 0 ' Color
					surface.FillStyle = New NColorFillStyle(Red)
				Case 1 ' Gradient
					surface.FillStyle = New NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.White, DarkOrange)
				Case 2 ' Image
					surface.FillStyle = New NImageFillStyle(Me.MapPathSecure(Me.TemplateSourceDirectory & "\SurfaceTexture.jpg"))
				Case 3 ' Pattern
					surface.FillStyle = New NHatchFillStyle(HatchStyle.HorizontalBrick, Color.White, DarkOrange)
				Case 4
					surface.FillStyle = New NAdvancedGradientFillStyle(AdvancedGradientScheme.Fire1, 12)
			End Select

			FillDataXY(surface)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub FillDataXY(ByVal surface As NMeshSurfaceSeries)
			Dim x, y, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 4.4
			Const dIntervalZ As Double = 4.4
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			Dim j As Integer = 0
			Do While j < nCountZ
				Dim i As Integer = 0
				Do While i < nCountX
					x = -(dIntervalX / 2) + (i * dIncrementX)
					z = -(dIntervalZ / 2) + (j * dIncrementZ)

					y = 8 * Math.Cos(x * x) + 5 * Math.Sin(z * z)

					x += Math.Sin(j / 4.0) / 4.0
					z += Math.Cos(i / 4.0) / 4.0

					surface.Data.SetValue(i, j, y, x, z)
					i += 1
				Loop
				j += 1
			Loop
		End Sub
	End Class
End Namespace
