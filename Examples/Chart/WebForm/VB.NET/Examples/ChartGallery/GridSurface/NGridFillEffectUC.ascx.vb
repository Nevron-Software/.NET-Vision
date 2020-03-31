Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NGridFillEffectUC
		Inherits NExampleUC
		Protected Label3 As Label

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Surface With Texture")
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
			chart.Projection.Type = ProjectionType.Perspective
			chart.Projection.Elevation = 28
			chart.Projection.Rotation = -18

			If (Not IsPostBack) Then
				SurfaceFillEffectDropDownList.Items.Add("Color")
				SurfaceFillEffectDropDownList.Items.Add("Gradient")
				SurfaceFillEffectDropDownList.Items.Add("Image")
				SurfaceFillEffectDropDownList.Items.Add("Pattern")
				SurfaceFillEffectDropDownList.Items.Add("Advanced gradient")
				SurfaceFillEffectDropDownList.SelectedIndex = 0

				RotationTextBox.Text = chart.Projection.Rotation.ToString()
				ElevationTextBox.Text = chart.Projection.Elevation.ToString()
				smoothShadingCheck.Checked = True
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
			surface.FrameMode = SurfaceFrameMode.None
			surface.FillMode = SurfaceFillMode.Uniform
			surface.AutomaticPalette = False
			surface.Data.SetGridSize(60, 60)

			Select Case SurfaceFillEffectDropDownList.SelectedIndex
				Case 0 ' Color
					surface.FillStyle = New NColorFillStyle(Red)
				Case 1 ' Gradient
					surface.FillStyle = New NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.WhiteSmoke, Color.Goldenrod)
				Case 2 ' Image
					surface.FillStyle = New NImageFillStyle(Me.MapPathSecure(Me.TemplateSourceDirectory & "\SurfaceTexture.jpg"))
				Case 3 ' Pattern
					surface.FillStyle = New NHatchFillStyle(HatchStyle.HorizontalBrick, Color.Yellow, Color.Orange)
				Case 4
					surface.FillStyle = New NAdvancedGradientFillStyle(AdvancedGradientScheme.Fire1, 12)
			End Select

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			FillData()

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub FillData()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			Dim stream As Stream = Nothing
			Dim reader As BinaryReader = Nothing

			Try
				' fill the XYZ data from a binary resource
				Dim path As String = MapPathSecure(TemplateSourceDirectory) & "\DataY.bin"
				stream = New FileStream(path, FileMode.Open, FileAccess.Read)
				reader = New BinaryReader(stream)

				Dim dataPointsCount As Integer = CInt(Fix(stream.Length / 4))
				Dim sizeX As Integer = CInt(Fix(Math.Sqrt(dataPointsCount)))
				Dim sizeZ As Integer = sizeX

				surface.Data.SetGridSize(sizeX, sizeZ)

				Dim z As Integer = 0
				Do While z < sizeZ
					Dim x As Integer = 0
					Do While x < sizeX
						surface.Data.SetValue(x, z, reader.ReadSingle())
						x += 1
					Loop
					z += 1
				Loop
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
