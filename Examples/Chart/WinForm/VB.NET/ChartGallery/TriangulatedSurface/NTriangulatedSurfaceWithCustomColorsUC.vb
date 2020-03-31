Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports Nevron.UI
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NTriangulatedSurfaceWithCustomColorsUC
		Inherits NExampleBaseUC

		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents fillModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label5 As System.Windows.Forms.Label
		Private WithEvents frameColorModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents frameModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			fillModeCombo.Items.Add("None")
			fillModeCombo.Items.Add("Uniform")
			fillModeCombo.Items.Add("Custom Colors")

			frameModeCombo.Items.Add("None")
			frameModeCombo.Items.Add("Mesh")
			frameModeCombo.Items.Add("Contour")
			frameModeCombo.Items.Add("Mesh-Contour")
			frameModeCombo.Items.Add("Dots")

			frameColorModeCombo.Items.Add("Uniform")
			frameColorModeCombo.Items.Add("Custom Colors")
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
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.smoothShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.fillModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.frameColorModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.frameModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.smoothShadingCheck)
			Me.nGroupBox2.Controls.Add(Me.label4)
			Me.nGroupBox2.Controls.Add(Me.fillModeCombo)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(4, 3)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(176, 96)
			Me.nGroupBox2.TabIndex = 0
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Surface Filling"
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(15, 72)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(116, 20)
			Me.smoothShadingCheck.TabIndex = 2
			Me.smoothShadingCheck.Text = "Smooth Shading"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(15, 24)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(116, 14)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Fill Mode:"
			' 
			' fillModeCombo
			' 
			Me.fillModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.fillModeCombo.ListProperties.DataSource = Nothing
			Me.fillModeCombo.ListProperties.DisplayMember = ""
			Me.fillModeCombo.Location = New System.Drawing.Point(15, 40)
			Me.fillModeCombo.Name = "fillModeCombo"
			Me.fillModeCombo.Size = New System.Drawing.Size(132, 21)
			Me.fillModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.FillModeCombo_SelectedIndexChanged);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label5)
			Me.nGroupBox1.Controls.Add(Me.frameColorModeCombo)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.frameModeCombo)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(4, 115)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(177, 120)
			Me.nGroupBox1.TabIndex = 1
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Surface Frame"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(15, 72)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(131, 14)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Frame Color Mode:"
			' 
			' frameColorModeCombo
			' 
			Me.frameColorModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.frameColorModeCombo.ListProperties.DataSource = Nothing
			Me.frameColorModeCombo.ListProperties.DisplayMember = ""
			Me.frameColorModeCombo.Location = New System.Drawing.Point(15, 88)
			Me.frameColorModeCombo.Name = "frameColorModeCombo"
			Me.frameColorModeCombo.Size = New System.Drawing.Size(131, 21)
			Me.frameColorModeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.frameColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameColorModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(15, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(131, 14)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Frame Mode:"
			' 
			' frameModeCombo
			' 
			Me.frameModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.frameModeCombo.ListProperties.DataSource = Nothing
			Me.frameModeCombo.ListProperties.DisplayMember = ""
			Me.frameModeCombo.Location = New System.Drawing.Point(15, 40)
			Me.frameModeCombo.Name = "frameModeCombo"
			Me.frameModeCombo.Size = New System.Drawing.Size(131, 21)
			Me.frameModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.frameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			' 
			' NTriangulatedSurfaceWithCustomColorsUC
			' 
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Name = "NTriangulatedSurfaceWithCustomColorsUC"
			Me.Size = New System.Drawing.Size(180, 264)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Triangulated Surface with Custom Colors")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' remove legends
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 10.0F
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

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' form controls
			smoothShadingCheck.Checked = True
			fillModeCombo.SelectedIndex = 2
			frameModeCombo.SelectedIndex = 0
			frameColorModeCombo.SelectedIndex = 0
		End Sub

		Private Sub FillData()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			Dim stream As Stream = Nothing
			Dim reader As BinaryReader = Nothing

			Try
				' fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(Me.GetType().Assembly, "DataXYZ.bin", "Nevron.Examples.Chart.WinForm.Resources")
				reader = New BinaryReader(stream)

				Dim nDataPointsCount As Integer = CInt(stream.Length) \ 12

				' fill Y values and colors
				For i As Integer = 0 To nDataPointsCount - 1
					Dim y As Single = 300 - reader.ReadSingle()

					surface.Values.Add(y)
					surface.Colors.Add(GetColorFromValue(y))
				Next i

				' fill X values
				For i As Integer = 0 To nDataPointsCount - 1
					surface.XValues.Add(reader.ReadSingle())
				Next i

				' fill Z values
				For i As Integer = 0 To nDataPointsCount - 1
					surface.ZValues.Add(reader.ReadSingle())
				Next i
			Finally
				If reader IsNot Nothing Then
					reader.Close()
				End If

				If stream IsNot Nothing Then
					stream.Close()
				End If
			End Try
		End Sub
		Private Function GetColorFromValue(ByVal y As Single) As Color
			Dim color As Color = System.Drawing.Color.Black

			If y < 100 Then
				color = System.Drawing.Color.FromArgb(20, 30, 180)
			ElseIf y < 150 Then
				color = System.Drawing.Color.FromArgb(20, 100, 100)
			ElseIf y < 200 Then
				color = System.Drawing.Color.FromArgb(20, 140, 80)
			ElseIf y < 250 Then
				color = System.Drawing.Color.FromArgb(80, 140, 60)
			ElseIf y < 300 Then
				color = System.Drawing.Color.FromArgb(140, 140, 40)
			End If

			Return System.Drawing.Color.FromArgb(color.R + CInt(Math.Truncate(Random.NextDouble() * 50)), color.G + CInt(Math.Truncate(Random.NextDouble() * 50)), color.B + CInt(Math.Truncate(Random.NextDouble() * 50)))
		End Function

		Private Sub SmoothShadingCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothShadingCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			If smoothShadingCheck.Checked Then
				surface.ShadingMode = ShadingMode.Smooth
			Else
				surface.ShadingMode = ShadingMode.Flat
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub FillModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fillModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			Select Case fillModeCombo.SelectedIndex
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

			nChartControl1.Refresh()
		End Sub
		Private Sub FrameModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frameModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			surface.FrameMode = CType(frameModeCombo.SelectedIndex, SurfaceFrameMode)
			nChartControl1.Refresh()

			' form controls
			frameColorModeCombo.Enabled = (surface.FrameMode <> SurfaceFrameMode.None)
		End Sub
		Private Sub FrameColorModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frameColorModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			Select Case frameColorModeCombo.SelectedIndex
				Case 0
					surface.FrameColorMode = SurfaceFrameColorMode.Uniform

				Case 1
					surface.FrameColorMode = SurfaceFrameColorMode.CustomColors
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
