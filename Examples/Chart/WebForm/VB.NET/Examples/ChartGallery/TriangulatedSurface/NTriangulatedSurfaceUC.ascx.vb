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
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTriangulatedSurfaceUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not Page.IsPostBack) Then
				'Setup dropdown lists and check boxes states.
				fillDropDownList.Items.Add("None")
				fillDropDownList.Items.Add("Uniform")
				fillDropDownList.Items.Add("Zone")
				fillDropDownList.SelectedIndex = 2

				frameModeDropDownList.Items.Add("None")
				frameModeDropDownList.Items.Add("Mesh")
				frameModeDropDownList.Items.Add("Contour")
				frameModeDropDownList.Items.Add("Mesh-Contour")
				frameModeDropDownList.Items.Add("Dots")
				frameModeDropDownList.SelectedIndex = 0

				frameColorModeDropDownList.Items.Add("Uniform")
				frameColorModeDropDownList.Items.Add("Zone")
				frameColorModeDropDownList.SelectedIndex = 0

				positionModeDropDownList.Items.Add("Axis Begin")
				positionModeDropDownList.Items.Add("Axis End")
				positionModeDropDownList.Items.Add("Custom Value")
				positionModeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(customValueDropDownList, 0, 250, 50)

				smoothShadingCheck.Checked = True
				smoothPaletteCheck.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Triangulated Surface Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Data.MarkSize = New NSizeL(5, 5)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0f
			chart.Depth = 60.0f
			chart.Height = 10.0f
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Projection.Elevation = 30

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.RoundToTickMax = False
			scaleY.RoundToTickMin = False
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
			surface.Legend.Mode = SeriesLegendMode.SeriesLogic
			surface.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			surface.PositionValue = 10.0
			surface.SyncPaletteWithAxisScale = False
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FillStyle = New NColorFillStyle(Color.YellowGreen)

			FillData()

			Select Case fillDropDownList.SelectedIndex
				Case 0
					surface.FillMode = SurfaceFillMode.None
					smoothShadingCheck.Enabled = False

				Case 1
					surface.FillMode = SurfaceFillMode.Uniform
					smoothShadingCheck.Enabled = True

				Case 2
					surface.FillMode = SurfaceFillMode.Zone
					smoothShadingCheck.Enabled = True
			End Select

			If smoothPaletteCheck.Checked Then
				surface.SmoothPalette = True
				surface.PaletteSteps = 7
				surface.Legend.Format = "<zone_value>"
			Else
				surface.SmoothPalette = False
				surface.PaletteSteps = 8
				surface.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			surface.DrawFlat = drawFlatCheck.Checked
			positionModeDropDownList.Enabled = drawFlatCheck.Checked
			customValueDropDownList.Enabled = drawFlatCheck.Checked
			surface.FrameMode = CType(frameModeDropDownList.SelectedIndex, SurfaceFrameMode)
			frameColorModeDropDownList.Enabled = (surface.FrameMode <> SurfaceFrameMode.None)
			surface.PositionMode = CType(positionModeDropDownList.SelectedIndex, SurfacePositionMode)
			surface.PositionValue = Convert.ToDouble(customValueDropDownList.SelectedValue)

			Select Case frameColorModeDropDownList.SelectedIndex
				Case 0
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform

				Case 1
					surface.FrameColorMode = SurfaceFrameColorMode.Zone
			End Select

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, legend)
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

				'surface.Data.SetCapacity(nDataPointsCount);
				Dim data(nDataPointsCount - 1) As NVector3DF

				' fill Y values
				For i As Integer = 0 To nDataPointsCount - 1
					data(i).Y = reader.ReadSingle()
				Next i

				' fill X values
				For i As Integer = 0 To nDataPointsCount - 1
					data(i).X = reader.ReadSingle()
				Next i

				' fill Z values
				For i As Integer = 0 To nDataPointsCount - 1
					data(i).Z = reader.ReadSingle()
				Next i

				surface.Data.Clear()
				surface.Data.AddValues(data)
			Finally
				If Not reader Is Nothing Then
					reader.Close()
				End If

				If Not stream Is Nothing Then
					stream.Close()
				End If
			End Try
		End Sub
	End Class
End Namespace
