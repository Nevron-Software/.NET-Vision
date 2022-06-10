Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NProjectedContourUC
		Inherits NExampleBaseUC

		Private WithEvents UseHardwareAccelerationCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableShaderRenderingCheckBox As UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.UseHardwareAccelerationCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableShaderRenderingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' UseHardwareAccelerationCheckBox
			' 
			Me.UseHardwareAccelerationCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseHardwareAccelerationCheckBox.Location = New System.Drawing.Point(3, 5)
			Me.UseHardwareAccelerationCheckBox.Name = "UseHardwareAccelerationCheckBox"
			Me.UseHardwareAccelerationCheckBox.Size = New System.Drawing.Size(171, 20)
			Me.UseHardwareAccelerationCheckBox.TabIndex = 1
			Me.UseHardwareAccelerationCheckBox.Text = "Use Hardware Acceleration"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseHardwareAccelerationCheckBox.CheckedChanged += new System.EventHandler(this.UseHardwareAccelerationCheckBox_CheckedChanged);
			' 
			' EnableShaderRenderingCheckBox
			' 
			Me.EnableShaderRenderingCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableShaderRenderingCheckBox.Location = New System.Drawing.Point(3, 31)
			Me.EnableShaderRenderingCheckBox.Name = "EnableShaderRenderingCheckBox"
			Me.EnableShaderRenderingCheckBox.Size = New System.Drawing.Size(171, 20)
			Me.EnableShaderRenderingCheckBox.TabIndex = 2
			Me.EnableShaderRenderingCheckBox.Text = "Enable Shader Rendering"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableShaderRenderingCheckBox.CheckedChanged += new System.EventHandler(this.EnableShaderRenderingCheckBox_CheckedChanged);
			' 
			' NFastProjectedContourUC
			' 
			Me.Controls.Add(Me.EnableShaderRenderingCheckBox)
			Me.Controls.Add(Me.UseHardwareAccelerationCheckBox)
			Me.Name = "NFastProjectedContourUC"
			Me.Size = New System.Drawing.Size(169, 116)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Contour Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.Enable3D = True
			chart.Width = 55.0F
			chart.Depth = 55.0F
			chart.Height = 45.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyCameraLight)

			SetupAxisAnchorsAndWalls(chart)

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.RoundToTickMax = False
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY.View = New NRangeAxisView(New NRange1DD(0, 100), True, False)
			axisY.ScaleConfigurator = scaleY

			' setup X axis
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.RoundToTickMin = False
			scaleX.RoundToTickMax = False
			Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)
			axisX.ScaleConfigurator = scaleX

			' setup Z axis
			Dim scaleZ As New NLinearScaleConfigurator()
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType(){}
			scaleZ.RoundToTickMin = False
			scaleZ.RoundToTickMax = False
			Dim axisZ As NAxis = chart.Axis(StandardAxis.Depth)
			axisZ.ScaleConfigurator = scaleZ

			' add a surface series
			Dim surface As New NGridSurfaceSeries()
			chart.Series.Add(surface)
			surface.Name = "Surface"
			surface.Legend.Mode = SeriesLegendMode.None
			surface.FillStyle = New NColorFillStyle(Color.FromArgb(160, 170, 212))
			surface.FillMode = SurfaceFillMode.Uniform
			surface.FrameMode = SurfaceFrameMode.None
			surface.DrawFlat = False
			surface.ShadingMode = ShadingMode.Smooth
			SetupCommonSurfaceProperties(surface)

			' fill both surfaces with the same data
			FillData(surface)

			' add a surface series
			Dim contour As New NGridSurfaceSeries()
			chart.Series.Add(contour)
			contour.Name = "Contour"
			contour.Legend.Mode = SeriesLegendMode.SeriesLogic
			contour.FillMode = SurfaceFillMode.Zone
			contour.FrameMode = SurfaceFrameMode.Contour
			contour.DrawFlat = True
			contour.ShadingMode = ShadingMode.Flat
			SetupCommonSurfaceProperties(contour)

			' fill both surfaces with the same data
			FillData(contour)

			Dim palette As NPalette = contour.Palette
			palette.Mode = PaletteMode.Custom

			contour.AutomaticPalette = False
			contour.Palette.Clear()
			contour.Palette.Add(250, Color.FromArgb(112, 211, 162))
			contour.Palette.Add(311, Color.FromArgb(113, 197, 212))
			contour.Palette.Add(328, Color.FromArgb(114, 162, 212))
			contour.Palette.Add(344, Color.FromArgb(196, 185, 206))
			contour.Palette.Add(358, Color.FromArgb(161, 130, 191))
			contour.Palette.Add(370, Color.FromArgb(198, 170, 165))
			contour.Palette.Add(400, Color.FromArgb(255, 0, 0))

			contour.Palette.Add(0, Color.Red)
			contour.Palette.Add(100, Color.Blue)

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			UseHardwareAccelerationCheckBox.Checked = True
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
			Dim stream As Stream = Nothing
			Dim reader As BinaryReader = Nothing

			Try
				' fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(Me.GetType().Assembly, "DataY.bin", "Nevron.Examples.Chart.WinForm.Resources")
				reader = New BinaryReader(stream)

				Dim dataPointsCount As Integer = CInt(stream.Length \ 4)
				Dim sizeX As Integer = CInt(Math.Truncate(Math.Sqrt(dataPointsCount)))
				Dim sizeZ As Integer = sizeX

				surface.Data.SetGridSize(sizeX, sizeZ)

				For z As Integer = 0 To sizeZ - 1
					For x As Integer = 0 To sizeX - 1
						Dim value As Double = 300 + 0.3 * CDbl(reader.ReadSingle())
						surface.Data.SetValue(x, z, value)
					Next x
				Next z
			Finally
				If reader IsNot Nothing Then
					reader.Close()
				End If

				If stream IsNot Nothing Then
					stream.Close()
				End If
			End Try
		End Sub

		Private Sub SetupCommonSurfaceProperties(ByVal surface As NGridSurfaceSeries)
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 6
			surface.UseCustomXOriginAndStep = True
			surface.OriginX = -150
			surface.StepX = 10
			surface.UseCustomZOriginAndStep = True
			surface.OriginZ = -150
			surface.StepZ = 10
		End Sub

		Private Sub SetupAxisAnchorsAndWalls(ByVal chart As NCartesianChart)
			For Each axis As NAxis In chart.Axes
				Dim orientation As AxisOrientation = axis.AxisOrientation
				axis.Anchor = New NBestVisibilityAxisAnchor(orientation)
			Next axis

			For Each wall As NChartWall In chart.Walls
				wall.VisibilityMode = WallVisibilityMode.Auto
			Next wall
		End Sub

		Private Sub EnableShaderRenderingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableShaderRenderingCheckBox.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			For Each surface As NGridSurfaceSeries In chart.Series
				surface.EnableShaderRendering = EnableShaderRenderingCheckBox.Checked
			Next surface

			nChartControl1.Refresh()
		End Sub

		Private Sub UseHardwareAccelerationCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UseHardwareAccelerationCheckBox.CheckedChanged
			nChartControl1.Settings.RenderSurface = If(UseHardwareAccelerationCheckBox.Checked, RenderSurface.Window, RenderSurface.Bitmap)
			EnableShaderRenderingCheckBox.Enabled = UseHardwareAccelerationCheckBox.Checked
		End Sub
	End Class
End Namespace