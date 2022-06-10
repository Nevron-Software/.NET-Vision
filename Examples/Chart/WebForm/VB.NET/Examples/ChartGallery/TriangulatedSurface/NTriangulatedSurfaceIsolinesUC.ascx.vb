Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Web.UI.WebControls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTriangulatedSurfaceIsolinesUC
		Inherits NExampleUC
		Protected Label3 As Label
		Protected DrawFlatCheckBoxBox As CheckBox
		Protected ShowFillingCheckBox As CheckBox
		Protected ShowFrameCheckBox As CheckBox

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Triangulated Surface Isolines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.BoundsMode = BoundsMode.Fit
			chart.Width = 60.0f
			chart.Depth = 60.0f
			chart.Height = 10.0f
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Projection.Elevation = 45
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.RoundToTickMax = False
			scaleY.RoundToTickMin = False
			scaleY.MinTickDistance = New NLength(10, NGraphicsUnit.Point)
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Left, ChartWallType.Back }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' setup X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.RoundToTickMax = False
			scaleX.RoundToTickMin = False
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Back }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Z axis
			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleZ.RoundToTickMax = False
			scaleZ.RoundToTickMin = False
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Left }
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			' add the surface series
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series.Add(SeriesType.TriangulatedSurface), NTriangulatedSurfaceSeries)
			surface.Name = "Surface"
			surface.Legend.Mode = SeriesLegendMode.None
			surface.SyncPaletteWithAxisScale = False
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FrameMode = SurfaceFrameMode.None
			surface.Palette.SmoothPalette = True
			surface.FillStyle = New NColorFillStyle(Color.YellowGreen)

			FillData()

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

				Dim nDataPointsCount As Integer = CInt(Fix(stream.Length)) / 12

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
