Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NMeshSurfaceZoningUC
		Inherits NExampleBaseUC

		Private WithEvents paletteModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents smoothPaletteCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents paletteStepsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
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
			Me.label4 = New System.Windows.Forms.Label()
			Me.paletteModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.smoothPaletteCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.paletteStepsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 16)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(169, 14)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Palette Mode:"
			' 
			' paletteModeCombo
			' 
			Me.paletteModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.paletteModeCombo.ListProperties.DataSource = Nothing
			Me.paletteModeCombo.ListProperties.DisplayMember = ""
			Me.paletteModeCombo.Location = New System.Drawing.Point(6, 32)
			Me.paletteModeCombo.Name = "paletteModeCombo"
			Me.paletteModeCombo.Size = New System.Drawing.Size(169, 21)
			Me.paletteModeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.paletteModeCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteModeCombo_SelectedIndexChanged);
			' 
			' smoothPaletteCheck
			' 
			Me.smoothPaletteCheck.ButtonProperties.BorderOffset = 2
			Me.smoothPaletteCheck.Location = New System.Drawing.Point(6, 135)
			Me.smoothPaletteCheck.Name = "smoothPaletteCheck"
			Me.smoothPaletteCheck.Size = New System.Drawing.Size(169, 21)
			Me.smoothPaletteCheck.TabIndex = 4
			Me.smoothPaletteCheck.Text = "Smooth Palette"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothPaletteCheck.CheckedChanged += new System.EventHandler(this.SmoothPaletteCheck_CheckedChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(6, 73)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(169, 14)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Palette Steps:"
			' 
			' paletteStepsCombo
			' 
			Me.paletteStepsCombo.ListProperties.CheckBoxDataMember = ""
			Me.paletteStepsCombo.ListProperties.DataSource = Nothing
			Me.paletteStepsCombo.ListProperties.DisplayMember = ""
			Me.paletteStepsCombo.Location = New System.Drawing.Point(6, 89)
			Me.paletteStepsCombo.Name = "paletteStepsCombo"
			Me.paletteStepsCombo.Size = New System.Drawing.Size(169, 21)
			Me.paletteStepsCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.paletteStepsCombo.SelectedIndexChanged += new System.EventHandler(this.PaletteStepsCombo_SelectedIndexChanged);
			' 
			' NMeshSurfaceZoningUC
			' 
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.paletteStepsCombo)
			Me.Controls.Add(Me.paletteModeCombo)
			Me.Controls.Add(Me.smoothPaletteCheck)
			Me.Name = "NMeshSurfaceZoningUC"
			Me.Size = New System.Drawing.Size(180, 300)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Settings.RenderSurface = RenderSurface.Window
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Mesh Surface")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60.0F
			chart.Depth = 60.0F
			chart.Height = 25.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' setup axes
			Dim linearScale As New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale

			linearScale = New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale

			' setup surface series
			Dim surface As New NMeshSurfaceSeries()
			chart.Series.Add(surface)
			surface.ShadingMode = ShadingMode.Smooth
			surface.FillMode = SurfaceFillMode.ZoneTexture
			surface.FrameMode = SurfaceFrameMode.None
			surface.Data.SetGridSize(100, 100)

			' define a custom palette
			surface.Palette.Clear()
			surface.Palette.Add(-0.8, DarkOrange)
			surface.Palette.Add(-0.4, LightOrange)
			surface.Palette.Add(-0.2, LightGreen)
			surface.Palette.Add(0, Turqoise)
			surface.Palette.Add(0.4, Blue)
			surface.Palette.Add(0.8, Purple)
			surface.Palette.Add(1, BeautifulRed)

			' generate data
			GenerateSurfaceData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' form controls
			paletteModeCombo.SelectedIndex = 0
			paletteStepsCombo.SelectedIndex = 6
			smoothPaletteCheck.Checked = False
		End Sub

		Private Sub GenerateSurfaceData(ByVal surface As NMeshSurfaceSeries)
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Const dIntervalX As Double = 40.0
			Const dIntervalZ As Double = 40.0
			Dim dIncrementX As Double = (dIntervalX / nCountX)
			Dim dIncrementZ As Double = (dIntervalZ / nCountZ)

			Dim pz As Double = -(dIntervalZ / 2)

			Dim j As Integer = 0
			Do While j < nCountZ
				Dim px As Double = -(dIntervalX / 2)

				Dim i As Integer = 0
				Do While i < nCountX
					Dim x As Double = px + Math.Sin(pz) * 0.4
					Dim z As Double = pz + Math.Cos(px) * 0.4
					Dim y As Double = Math.Sin(px * 0.33) * Math.Sin(pz * 0.33)

					If y < 0 Then
						y = - y * 0.7
					End If

					Dim tmp As Double = (1 - x * x - z * z)
					y -= tmp * tmp * 0.000001

					surface.Data.SetValue(i, j, y, x, z)
					i += 1
					px += dIncrementX
				Loop
				j += 1
				pz += dIncrementZ
			Loop
		End Sub
		Private Sub UpdateSurface()
			Dim surface As NMeshSurfaceSeries = CType(nChartControl1.Charts(0).Series(0), NMeshSurfaceSeries)

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