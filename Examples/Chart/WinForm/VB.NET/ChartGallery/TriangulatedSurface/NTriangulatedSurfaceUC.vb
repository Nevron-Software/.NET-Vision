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
	Public Class NTriangulatedSurfaceUC
		Inherits NExampleBaseUC

		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents smoothPaletteCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents drawFlatCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents positionModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents customValueScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents frameModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents fillModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents frameColorModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private nGroupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			fillModeCombo.Items.Add("None")
			fillModeCombo.Items.Add("Uniform")
			fillModeCombo.Items.Add("Zone")

			frameModeCombo.Items.Add("None")
			frameModeCombo.Items.Add("Mesh")
			frameModeCombo.Items.Add("Contour")
			frameModeCombo.Items.Add("Mesh-Contour")
			frameModeCombo.Items.Add("Dots")

			frameColorModeCombo.Items.Add("Uniform")
			frameColorModeCombo.Items.Add("Zone")

			positionModeCombo.Items.Add("Axis Begin")
			positionModeCombo.Items.Add("Axis End")
			positionModeCombo.Items.Add("Custom Value")
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
			Me.smoothPaletteCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.drawFlatCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.frameModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.customValueScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.positionModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.frameColorModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.smoothShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.fillModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox4.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' smoothPaletteCheck
			' 
			Me.smoothPaletteCheck.ButtonProperties.BorderOffset = 2
			Me.smoothPaletteCheck.Location = New System.Drawing.Point(15, 32)
			Me.smoothPaletteCheck.Name = "smoothPaletteCheck"
			Me.smoothPaletteCheck.Size = New System.Drawing.Size(108, 21)
			Me.smoothPaletteCheck.TabIndex = 0
			Me.smoothPaletteCheck.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			' 
			' drawFlatCheck
			' 
			Me.drawFlatCheck.ButtonProperties.BorderOffset = 2
			Me.drawFlatCheck.Location = New System.Drawing.Point(15, 24)
			Me.drawFlatCheck.Name = "drawFlatCheck"
			Me.drawFlatCheck.Size = New System.Drawing.Size(118, 20)
			Me.drawFlatCheck.TabIndex = 0
			Me.drawFlatCheck.Text = "Draw Flat"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.drawFlatCheck.CheckedChanged += new System.EventHandler(this.DrawFlatCheck_CheckedChanged);
			' 
			' frameModeCombo
			' 
			Me.frameModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.frameModeCombo.ListProperties.DataSource = Nothing
			Me.frameModeCombo.ListProperties.DisplayMember = ""
			Me.frameModeCombo.Location = New System.Drawing.Point(15, 40)
			Me.frameModeCombo.Name = "frameModeCombo"
			Me.frameModeCombo.Size = New System.Drawing.Size(139, 21)
			Me.frameModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.frameModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameModeCombo_SelectedIndexChanged);
			' 
			' nGroupBox4
			' 
			Me.nGroupBox4.Controls.Add(Me.label3)
			Me.nGroupBox4.Controls.Add(Me.customValueScroll)
			Me.nGroupBox4.Controls.Add(Me.label1)
			Me.nGroupBox4.Controls.Add(Me.positionModeCombo)
			Me.nGroupBox4.Controls.Add(Me.drawFlatCheck)
			Me.nGroupBox4.ImageIndex = 0
			Me.nGroupBox4.Location = New System.Drawing.Point(3, 331)
			Me.nGroupBox4.Name = "nGroupBox4"
			Me.nGroupBox4.Size = New System.Drawing.Size(175, 136)
			Me.nGroupBox4.TabIndex = 3
			Me.nGroupBox4.TabStop = False
			Me.nGroupBox4.Text = "Flat Mode"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(15, 96)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(118, 15)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Custom Value:"
			' 
			' customValueScroll
			' 
			Me.customValueScroll.Enabled = False
			Me.customValueScroll.LargeChange = 1
			Me.customValueScroll.Location = New System.Drawing.Point(15, 112)
			Me.customValueScroll.Maximum = 250
			Me.customValueScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.customValueScroll.Name = "customValueScroll"
			Me.customValueScroll.Size = New System.Drawing.Size(140, 17)
			Me.customValueScroll.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.customValueScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.CustomValueScroll_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(15, 48)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(118, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Position Mode:"
			' 
			' positionModeCombo
			' 
			Me.positionModeCombo.Enabled = False
			Me.positionModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.positionModeCombo.ListProperties.DataSource = Nothing
			Me.positionModeCombo.ListProperties.DisplayMember = ""
			Me.positionModeCombo.Location = New System.Drawing.Point(15, 64)
			Me.positionModeCombo.Name = "positionModeCombo"
			Me.positionModeCombo.Size = New System.Drawing.Size(140, 21)
			Me.positionModeCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.positionModeCombo.SelectedIndexChanged += new System.EventHandler(this.PositionModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(15, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(139, 14)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Frame Mode:"
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label5)
			Me.nGroupBox1.Controls.Add(Me.frameColorModeCombo)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.frameModeCombo)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(3, 115)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(175, 120)
			Me.nGroupBox1.TabIndex = 1
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Surface Frame"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(15, 72)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(139, 14)
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
			Me.frameColorModeCombo.Size = New System.Drawing.Size(139, 21)
			Me.frameColorModeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.frameColorModeCombo.SelectedIndexChanged += new System.EventHandler(this.FrameColorModeCombo_SelectedIndexChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.smoothShadingCheck)
			Me.nGroupBox2.Controls.Add(Me.label4)
			Me.nGroupBox2.Controls.Add(Me.fillModeCombo)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(3, 3)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(174, 96)
			Me.nGroupBox2.TabIndex = 0
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Surface Filling"
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(15, 72)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(124, 20)
			Me.smoothShadingCheck.TabIndex = 2
			Me.smoothShadingCheck.Text = "Smooth Shading"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(15, 24)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(124, 14)
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
			Me.fillModeCombo.Size = New System.Drawing.Size(140, 21)
			Me.fillModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.fillModeCombo.SelectedIndexChanged += new System.EventHandler(this.FillModeCombo_SelectedIndexChanged);
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.smoothPaletteCheck)
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(3, 251)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(175, 64)
			Me.nGroupBox3.TabIndex = 2
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Palette"
			' 
			' NTriangulatedSurfaceUC
			' 
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nGroupBox4)
			Me.Name = "NTriangulatedSurfaceUC"
			Me.Size = New System.Drawing.Size(180, 496)
			Me.nGroupBox4.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Surface Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.BoundsMode = BoundsMode.Fit
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 10.0F
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
			surface.Legend.Mode = SeriesLegendMode.None
			surface.SyncPaletteWithAxisScale = False
			surface.ValueFormatter.FormatSpecifier = "0.00"
			surface.FillStyle = New NColorFillStyle(Color.YellowGreen)

			FillData()

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' form controls
			fillModeCombo.SelectedIndex = 2
			smoothShadingCheck.Checked = True
			frameModeCombo.SelectedIndex = 0
			frameColorModeCombo.SelectedIndex = 0
			smoothPaletteCheck.Checked = True
			positionModeCombo.SelectedIndex = 0
			customValueScroll.Value = 100
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

				' fill Y values
				For i As Integer = 0 To nDataPointsCount - 1
					surface.Values.Add(reader.ReadSingle())
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
					surface.FillMode = SurfaceFillMode.Zone
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
					surface.FrameColorMode = SurfaceFrameColorMode.Zone
			End Select

			nChartControl1.Refresh()
		End Sub
		Private Sub SmoothPaletteCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothPaletteCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			If smoothPaletteCheck.Checked Then
				surface.SmoothPalette = True
				surface.PaletteSteps = 7
				surface.Legend.Format = "<zone_value>"
			Else
				surface.SmoothPalette = False
				surface.PaletteSteps = 8
				surface.Legend.Format = "<zone_begin> - <zone_end>"
			End If

			nChartControl1.Refresh()
		End Sub
		Private Sub DrawFlatCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drawFlatCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			surface.DrawFlat = drawFlatCheck.Checked
			nChartControl1.Refresh()

			' form controls
			positionModeCombo.Enabled = drawFlatCheck.Checked
			customValueScroll.Enabled = drawFlatCheck.Checked
		End Sub
		Private Sub PositionModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles positionModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			surface.PositionMode = CType(positionModeCombo.SelectedIndex, SurfacePositionMode)
			nChartControl1.Refresh()
		End Sub
		Private Sub CustomValueScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles customValueScroll.ValueChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NTriangulatedSurfaceSeries = CType(chart.Series(0), NTriangulatedSurfaceSeries)

			surface.PositionValue = customValueScroll.Value
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
