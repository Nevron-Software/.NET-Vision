Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.UI
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTriangulatedSurfaceSimplificationUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not nChartControl1.Initialized) Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Settings.JitterMode = JitterMode.Enabled

				' set a chart title
				Dim title As NLabel = nChartControl1.Labels.AddHeader("Triangulated Surface Chart")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

				' hide the legend
				Dim legend As NLegend = nChartControl1.Legends(0)
				legend.Visible = False

				' setup chart
				Dim chart As NChart = nChartControl1.Charts(0)
				chart.Enable3D = True
				chart.Width = 60.0F
				chart.Depth = 60.0F
				chart.Height = 30.0F
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
				chart.Projection.Elevation = 30

				nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
				nChartControl1.Settings.EnableJittering = False
				nChartControl1.Controller.SetActivePanel(chart)
				nChartControl1.Controller.Tools.Add(New NTrackballTool())

				' setup Y axis
				Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
				scaleY.RoundToTickMax = False
				scaleY.RoundToTickMin = False
				scaleY.MinTickDistance = New NLength(10, NGraphicsUnit.Point)
				scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() {ChartWallType.Left, ChartWallType.Back}
				scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
				chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

				' setup X axis
				Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
				scaleX.RoundToTickMax = False
				scaleX.RoundToTickMin = False
				scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() {ChartWallType.Floor, ChartWallType.Back}
				scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

				' setup Z axis
				Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
				scaleZ.RoundToTickMax = False
				scaleZ.RoundToTickMin = False
				scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType() {ChartWallType.Floor, ChartWallType.Left}
				scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
				chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

				' add the surface series
				Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series.Add(SeriesType.TriangulatedSurface), NTriangulatedSurfaceSeries)
				surface.Name = "Surface"
				surface.Legend.Mode = SeriesLegendMode.SeriesLogic
				surface.SyncPaletteWithAxisScale = False
				surface.PaletteSteps = 10
				surface.ValueFormatter.FormatSpecifier = "0.00"
				surface.FillStyle = New NColorFillStyle(Color.YellowGreen)
			End If

			FillData()

		End Sub

		Private Sub FillData()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			Dim rand As Random = New Random()

			Const countX As Integer = 100
			Const countZ As Integer = 100

			Dim rangeX As NRange1DD = New NRange1DD(-10, 10)
			Dim rangeZ As NRange1DD = New NRange1DD(-10, 10)

			Dim stepX As Double = rangeX.GetLength() / (countX - 1)
			Dim stepZ As Double = rangeZ.GetLength() / (countZ - 1)

			Dim cx As Double = -3.0
			Dim cz As Double = -5.0

			Dim vectorData((countZ * countX) - 1) As NVector3DD
			Dim index As Integer = 0

			For n As Integer = 0 To countZ - 1
				Dim z As Double = rangeZ.Begin + n * stepZ

				For m As Integer = 0 To countX - 1
					Dim x As Double = rangeX.Begin + m * stepX
					Dim dx As Double = cx - x
					Dim dz As Double = cz - z
					Dim distance As Double = Math.Sqrt(dx * dx + dz * dz)

					vectorData(index) = New NVector3DD(x, Math.Sin(distance) * Math.Exp(-distance * 0.1), z)
					index += 1
				Next m
			Next n

			If SimplifySurfaceCheckBox.Checked Then
				Dim simplifier As New NPointSetSimplifier3D()
				simplifier.DistanceFactor = 0.01

				vectorData = simplifier.Simplify(vectorData)
			End If

			surface.Data.Clear()
			surface.Data.AddValues(vectorData)
		End Sub
	End Class
End Namespace
