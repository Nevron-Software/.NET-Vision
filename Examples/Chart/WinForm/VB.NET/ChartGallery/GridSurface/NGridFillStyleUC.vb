Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Resources
Imports System.Windows.Forms
Imports System.IO
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NGridFillStyleUC
		Inherits NExampleBaseUC

		Private WithEvents FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents texturePlaneCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			texturePlaneCombo.Items.Add("XZ")
			texturePlaneCombo.Items.Add("XY")
			texturePlaneCombo.Items.Add("ZY")
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
			Me.FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.smoothShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.texturePlaneCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' FillStyleButton
			' 
			Me.FillStyleButton.Location = New System.Drawing.Point(10, 10)
			Me.FillStyleButton.Name = "FillStyleButton"
			Me.FillStyleButton.Size = New System.Drawing.Size(151, 27)
			Me.FillStyleButton.TabIndex = 0
			Me.FillStyleButton.Text = "Surface Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FillStyleButton.Click += new System.EventHandler(this.FillStyleButton_Click);
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(10, 45)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(143, 20)
			Me.smoothShadingCheck.TabIndex = 1
			Me.smoothShadingCheck.Text = "Smooth Shading"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(10, 87)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(131, 14)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Texture Plane:"
			' 
			' texturePlaneCombo
			' 
			Me.texturePlaneCombo.ListProperties.CheckBoxDataMember = ""
			Me.texturePlaneCombo.ListProperties.DataSource = Nothing
			Me.texturePlaneCombo.ListProperties.DisplayMember = ""
			Me.texturePlaneCombo.Location = New System.Drawing.Point(10, 103)
			Me.texturePlaneCombo.Name = "texturePlaneCombo"
			Me.texturePlaneCombo.Size = New System.Drawing.Size(151, 21)
			Me.texturePlaneCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.texturePlaneCombo.SelectedIndexChanged += new System.EventHandler(this.TexturePlaneCombo_SelectedIndexChanged);
			' 
			' NGridFillStyleUC
			' 
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.texturePlaneCombo)
			Me.Controls.Add(Me.smoothShadingCheck)
			Me.Controls.Add(Me.FillStyleButton)
			Me.Name = "NGridFillStyleUC"
			Me.Size = New System.Drawing.Size(180, 211)
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
			Dim title As New NLabel("Surface With Texture")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' no legends
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 15.0F
			chart.BoundsMode = BoundsMode.Fit
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.Projection.Elevation = 45
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.RoundToTickMax = False
			scaleY.RoundToTickMin = False
			scaleY.MinTickDistance = New NLength(10, NGraphicsUnit.Point)
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Left, ChartWallType.Back }
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' setup X axis
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.RoundToTickMax = False
			scaleX.RoundToTickMin = False
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Back }
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Z axis
			Dim scaleZ As New NLinearScaleConfigurator()
			scaleZ.RoundToTickMax = False
			scaleZ.RoundToTickMin = False
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Floor, ChartWallType.Left }
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			' add the surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.FrameMode = SurfaceFrameMode.None
			surface.FillMode = SurfaceFillMode.Uniform
			surface.Data.SetGridSize(60, 60)

			FillData()

			Dim bitmap As Bitmap = NResourceHelper.BitmapFromResource(Me.GetType(), "Marble.jpg", "Nevron.Examples.Chart.WinForm.Resources")

			Dim imageFillStyle As New NImageFillStyle(bitmap)
			imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled
			imageFillStyle.TextureMappingStyle.HorizontalScale = 0.1F
			imageFillStyle.TextureMappingStyle.VerticalScale = 0.1F

			imageFillStyle.MaterialStyle.Diffuse = Color.FromArgb(204, 204, 0)
			imageFillStyle.MaterialStyle.Ambient = Color.FromArgb(51, 102, 153)
			imageFillStyle.MaterialStyle.Specular = Color.DarkGray

			surface.FillStyle = imageFillStyle

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' form controls
			smoothShadingCheck.Checked = True
			texturePlaneCombo.SelectedIndex = 0
		End Sub

		Private Sub FillData()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

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
						surface.Data.SetValue(x, z, reader.ReadSingle())
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

		Private Sub FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FillStyleButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(surface.FillStyle, fillStyleResult) Then
				surface.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SmoothShadingCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothShadingCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub TexturePlaneCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles texturePlaneCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			Select Case texturePlaneCombo.SelectedIndex
				Case 0
					surface.TexturePlaneMode = SurfaceTexturePlaneMode.XZ

				Case 1
					surface.TexturePlaneMode = SurfaceTexturePlaneMode.XY

				Case 2
					surface.TexturePlaneMode = SurfaceTexturePlaneMode.ZY
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace