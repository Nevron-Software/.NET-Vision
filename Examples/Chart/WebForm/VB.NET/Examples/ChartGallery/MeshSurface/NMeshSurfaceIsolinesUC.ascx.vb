Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports System
Imports System.Drawing
Imports System.Web.UI.WebControls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NMeshSurfaceIsolinesUC
		Inherits NExampleUC
		Protected Label3 As Label
		Protected DrawFlatCheckBoxBox As CheckBox
		Protected ShowFillingCheckBox As CheckBox
		Protected ShowFrameCheckBox As CheckBox

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface Isolines")
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
			surface.Palette.SmoothPalette = True
			surface.Legend.Mode = SeriesLegendMode.None

			' generate data
			GenerateSurfaceData(surface)

			' add the isolines
			Dim redIsoline As NSurfaceIsoline = New NSurfaceIsoline()
			redIsoline.StrokeStyle = New NStrokeStyle(2.0f, Color.Red)
			redIsoline.Value = 100
			surface.Isolines.Add(redIsoline)

			Dim blueIsoline As NSurfaceIsoline = New NSurfaceIsoline()
			blueIsoline.StrokeStyle = New NStrokeStyle(2.0f, Color.Blue)
			blueIsoline.Value = 50
			surface.Isolines.Add(blueIsoline)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
		Private Sub GenerateSurfaceData(ByVal surface As NMeshSurfaceSeries)
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 20.0
			Const dIntervalZ As Double = 20.0
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
					Dim y As Double = Math.Sin(px * 0.33) * Math.Sin(pz * 0.33) * 200

					If y < 0 Then
						y = -y * 0.7
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
