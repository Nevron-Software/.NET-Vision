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
	Public Partial Class NGridEmptyDataPointsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Surface With Empty Data Points")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup legend
			Dim legend As NLegend =nChartControl1.Legends(0)
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
			chart.Projection.Type = ProjectionType.Perspective
			chart.Projection.Elevation = 28
			chart.Projection.Rotation = -18
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)
			chart.Width = 70.0f
			chart.Depth = 70.0f
			chart.Height = 30.0f

			If IsPostBack Then
				chart.Projection.Rotation = CSng(Convert.ToDouble(RotationTextBox.Text))
				chart.Projection.Elevation = CSng(Convert.ToDouble(ElevationTextBox.Text))
			Else
				RotationTextBox.Text = chart.Projection.Rotation.ToString()
				ElevationTextBox.Text = chart.Projection.Elevation.ToString()
				smoothShadingCheck.Checked = True
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
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			surface.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			surface.PositionValue = 10.0
			surface.Data.SetGridSize(40, 40)
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.0"

			FillData(surface)

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, legend)
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
			Dim y, x, z As Double
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 8.0
			Const dIntervalZ As Double = 8.0

			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			z = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				x = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					y = Math.Log(Math.Abs(x) * Math.Abs(z))

					If y > -3 Then
						surface.Data.SetValue(i, j, y)
					Else
						surface.Data.SetValue(i, j, DBNull.Value)
					End If
					i += 1
					x += dIncrementX
				Loop
				j += 1
				z += dIncrementZ
			Loop
		End Sub
	End Class
End Namespace
