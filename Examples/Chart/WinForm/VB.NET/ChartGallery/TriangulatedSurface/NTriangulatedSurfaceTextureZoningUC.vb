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
	Public Class NTriangulatedSurfaceTextureZoningUC
		Inherits NExampleBaseUC

		Private WithEvents smoothPaletteCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents paletteStepsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents paletteModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			paletteModeCombo.Items.Add("Use Fixed Number of Zones")
			paletteModeCombo.Items.Add("Synchronize Palette Zones with Y Axis")
			paletteModeCombo.Items.Add("Use Custom Palette")

			paletteStepsCombo.Items.Add("2")
			paletteStepsCombo.Items.Add("3")
			paletteStepsCombo.Items.Add("4")
			paletteStepsCombo.Items.Add("5")
			paletteStepsCombo.Items.Add("6")
			paletteStepsCombo.Items.Add("7")
			paletteStepsCombo.Items.Add("8")
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
			Me.paletteStepsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.paletteModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' smoothPaletteCheck
			' 
			Me.smoothPaletteCheck.ButtonProperties.BorderOffset = 2
			Me.smoothPaletteCheck.Location = New System.Drawing.Point(3, 135)
			Me.smoothPaletteCheck.Name = "smoothPaletteCheck"
			Me.smoothPaletteCheck.Size = New System.Drawing.Size(174, 21)
			Me.smoothPaletteCheck.TabIndex = 4
			Me.smoothPaletteCheck.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			' 
			' paletteStepsCombo
			' 
			Me.paletteStepsCombo.ListProperties.CheckBoxDataMember = ""
			Me.paletteStepsCombo.ListProperties.DataSource = Nothing
			Me.paletteStepsCombo.ListProperties.DisplayMember = ""
			Me.paletteStepsCombo.Location = New System.Drawing.Point(3, 89)
			Me.paletteStepsCombo.Name = "paletteStepsCombo"
			Me.paletteStepsCombo.Size = New System.Drawing.Size(174, 21)
			Me.paletteStepsCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.paletteStepsCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteStepsCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(3, 73)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(174, 14)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Palette Steps:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(3, 16)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(174, 14)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Palette Mode:"
			' 
			' paletteModeCombo
			' 
			Me.paletteModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.paletteModeCombo.ListProperties.DataSource = Nothing
			Me.paletteModeCombo.ListProperties.DisplayMember = ""
			Me.paletteModeCombo.Location = New System.Drawing.Point(3, 32)
			Me.paletteModeCombo.Name = "paletteModeCombo"
			Me.paletteModeCombo.Size = New System.Drawing.Size(174, 21)
			Me.paletteModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.paletteModeCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteModeCombo_SelectedIndexChanged);
			' 
			' NTriangulatedSurfaceTextureZoningUC
			' 
			Me.Controls.Add(Me.smoothPaletteCheck)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.paletteModeCombo)
			Me.Controls.Add(Me.paletteStepsCombo)
			Me.Name = "NTriangulatedSurfaceTextureZoningUC"
			Me.Size = New System.Drawing.Size(180, 300)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.RenderSurface = RenderSurface.Window
			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Triangulated Surface")
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
			Dim surface As New NTriangulatedSurfaceSeries()
			chart.Series.Add(surface)
			surface.ShadingMode = ShadingMode.Smooth
			surface.FillMode = SurfaceFillMode.ZoneTexture
			surface.FrameMode = SurfaceFrameMode.None

			' define a custom palette
			surface.Palette.Clear()
			surface.Palette.Add(0, DarkOrange)
			surface.Palette.Add(60, LightOrange)
			surface.Palette.Add(100, LightGreen)
			surface.Palette.Add(140, Turqoise)
			surface.Palette.Add(180, Blue)
			surface.Palette.Add(220, Purple)
			surface.Palette.Add(250, BeautifulRed)

			FillSurfaceData()

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' form controls
			paletteModeCombo.SelectedIndex = 0
			paletteStepsCombo.SelectedIndex = 6
			smoothPaletteCheck.Checked = False
		End Sub
		Private Sub FillSurfaceData()
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
		Private Sub UpdateSurface()
			Dim surface As NTriangulatedSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NTriangulatedSurfaceSeries)

			Select Case paletteModeCombo.SelectedIndex
				Case 0
					surface.AutomaticPalette = True
					surface.SyncPaletteWithAxisScale = False
					paletteStepsCombo.Enabled = True

				Case 1
					surface.AutomaticPalette = True
					surface.SyncPaletteWithAxisScale = True
					paletteStepsCombo.Enabled = False

				Case 2
					surface.AutomaticPalette = False
					paletteStepsCombo.Enabled = False
			End Select

			If smoothPaletteCheck.Checked Then
				surface.SmoothPalette = True
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 1
			Else
				surface.SmoothPalette = False
				surface.PaletteSteps = paletteStepsCombo.SelectedIndex + 2
			End If
		End Sub

		Private Sub PaletteModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles paletteModeCombo.SelectedIndexChanged
			UpdateSurface()

			nChartControl1.Refresh()
		End Sub
		Private Sub PaletteStepsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles paletteStepsCombo.SelectedIndexChanged
			UpdateSurface()

			nChartControl1.Refresh()
		End Sub
		Private Sub SmoothPaletteCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smoothPaletteCheck.CheckedChanged
			UpdateSurface()

			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace
