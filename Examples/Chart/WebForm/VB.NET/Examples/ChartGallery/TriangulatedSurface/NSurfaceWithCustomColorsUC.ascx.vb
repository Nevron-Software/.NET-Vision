Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NSurfaceWithCustomColorsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not Page.IsPostBack) Then
				'Setup dropdown lists and check boxes states.
				fillModeDropDownList.Items.Add("None")
				fillModeDropDownList.Items.Add("Uniform")
				fillModeDropDownList.Items.Add("Custom Colors")
				fillModeDropDownList.SelectedIndex = 2

				frameModeDropDownList.Items.Add("None")
				frameModeDropDownList.Items.Add("Mesh")
				frameModeDropDownList.Items.Add("Contour")
				frameModeDropDownList.Items.Add("Mesh-Contour")
				frameModeDropDownList.Items.Add("Dots")
				frameModeDropDownList.SelectedIndex = 0

				frameColorModeDropDownList.Items.Add("Uniform")
				frameColorModeDropDownList.Items.Add("Custom Colors")
				frameColorModeDropDownList.SelectedIndex = 0

				smoothShadingCheck.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Triangulated Surface with Custom Colors")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' remove legends
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0f
			chart.Depth = 60.0f
			chart.Height = 10.0f
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Projection.Elevation = 45

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.RoundToTickMax = False
			scaleY.RoundToTickMin = False
			scaleY.MinTickDistance = New NLength(10, NGraphicsUnit.Point)
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Back }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' setup X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.RoundToTickMax = False
			scaleX.RoundToTickMin = False
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Back }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Z axis
			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleZ.RoundToTickMax = False
			scaleZ.RoundToTickMin = False
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Left }
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			' add the surface series
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series.Add(SeriesType.TriangulatedSurface), NTriangulatedSurfaceSeries)
			surface.Name = "Surface"
			surface.SyncPaletteWithAxisScale = False
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FillStyle = New NColorFillStyle(Color.YellowGreen)
			surface.PaletteSteps = 8

			surface.FillMode = SurfaceFillMode.CustomColors
			surface.FrameMode = SurfaceFrameMode.None
			surface.FrameColorMode = SurfaceFrameColorMode.CustomColors
			surface.ShadingMode = ShadingMode.Smooth

			FillData()

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			Select Case fillModeDropDownList.SelectedIndex
				Case 0
					surface.FillMode = SurfaceFillMode.None
					smoothShadingCheck.Enabled = False

				Case 1
					surface.FillMode = SurfaceFillMode.Uniform
					smoothShadingCheck.Enabled = True

				Case 2
					surface.FillMode = SurfaceFillMode.CustomColors
					smoothShadingCheck.Enabled = True
			End Select

			surface.FrameMode = CType(frameModeDropDownList.SelectedIndex, SurfaceFrameMode)
			frameColorModeDropDownList.Enabled = (surface.FrameMode <> SurfaceFrameMode.None)

			Select Case frameColorModeDropDownList.SelectedIndex
				Case 0
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform

				Case 1
					surface.FrameColorMode = SurfaceFrameColorMode.CustomColors
			End Select

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub FillData()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			Dim stream As Stream = Nothing
			Dim reader As BinaryReader = Nothing

			Try
				' fill the XYZ data from a binary resource
				Dim path As String = MapPathSecure(TemplateSourceDirectory) & "\DataXYZ.bin"
				stream = New FileStream(path, FileMode.Open, FileAccess.Read)
				reader = New BinaryReader(stream)

				Dim nDataPointsCount As Integer = CInt(stream.Length) \ 12

				surface.Data.SetCount(nDataPointsCount)
				surface.Data.UseColors = True

				' fill Y values and colors
				For i As Integer = 0 To nDataPointsCount - 1
					Dim y As Single = 300 - reader.ReadSingle()

					surface.Data.SetYValue(i, y)
					surface.Data.SetColor(i, GetColorFromValue(y))
				Next i

				' fill X values
				For i As Integer = 0 To nDataPointsCount - 1
					surface.Data.SetXValue(i, reader.ReadSingle())
				Next i

				' fill Z values
				For i As Integer = 0 To nDataPointsCount - 1
					surface.Data.SetZValue(i, reader.ReadSingle())
				Next i
			Finally
				If Not reader Is Nothing Then
					reader.Close()
				End If

				If Not stream Is Nothing Then
					stream.Close()
				End If
			End Try
		End Sub

		Private Function GetColorFromValue(ByVal y As Single) As Color
			Dim color As Color = Color.Black

			If y < 100 Then
				color = Color.FromArgb(20, 30, 180)
			ElseIf y < 150 Then
				color = Color.FromArgb(20, 100, 100)
			ElseIf y < 200 Then
				color = Color.FromArgb(20, 140, 80)
			ElseIf y < 250 Then
				color = Color.FromArgb(80, 140, 60)
			ElseIf y < 300 Then
				color = Color.FromArgb(140, 140, 40)
			End If

			Return Color.FromArgb(color.R + CInt(Fix(Random.NextDouble() * 50)), color.G + CInt(Fix(Random.NextDouble() * 50)), color.B + CInt(Fix(Random.NextDouble() * 50)))
		End Function
	End Class
End Namespace
