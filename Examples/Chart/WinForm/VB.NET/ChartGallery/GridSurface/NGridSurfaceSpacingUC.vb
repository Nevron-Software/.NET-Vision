Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NGridSurfaceSpacingUC
		Inherits NExampleBaseUC

		Private WithEvents smoothShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents GenerateDataButton As UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents SpacingModeComboBox As UI.WinForm.Controls.NComboBox
		Private WithEvents XGridStepNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label2 As System.Windows.Forms.Label
		Private WithEvents XGridOriginNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label3 As System.Windows.Forms.Label
		Private WithEvents YGridStepNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label4 As System.Windows.Forms.Label
		Private WithEvents YGridOriginNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label5 As System.Windows.Forms.Label
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
			Me.smoothShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SpacingModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.XGridStepNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.XGridOriginNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.YGridStepNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.YGridOriginNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			DirectCast(Me.XGridStepNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.XGridOriginNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.YGridStepNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.YGridOriginNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' smoothShadingCheck
			' 
			Me.smoothShadingCheck.ButtonProperties.BorderOffset = 2
			Me.smoothShadingCheck.Location = New System.Drawing.Point(9, 48)
			Me.smoothShadingCheck.Name = "smoothShadingCheck"
			Me.smoothShadingCheck.Size = New System.Drawing.Size(158, 20)
			Me.smoothShadingCheck.TabIndex = 3
			Me.smoothShadingCheck.Text = "Smooth Shading"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.smoothShadingCheck.CheckedChanged += new System.EventHandler(this.SmoothShadingCheck_CheckedChanged);
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(9, 9)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(158, 23)
			Me.GenerateDataButton.TabIndex = 4
			Me.GenerateDataButton.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 85)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 13)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Spacing Mode:"
			' 
			' SpacingModeComboBox
			' 
			Me.SpacingModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.SpacingModeComboBox.ListProperties.DataSource = Nothing
			Me.SpacingModeComboBox.ListProperties.DisplayMember = ""
			Me.SpacingModeComboBox.Location = New System.Drawing.Point(9, 102)
			Me.SpacingModeComboBox.Name = "SpacingModeComboBox"
			Me.SpacingModeComboBox.Size = New System.Drawing.Size(158, 21)
			Me.SpacingModeComboBox.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SpacingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.SpacingModeComboBox_SelectedIndexChanged);
			' 
			' XGridStepNumericUpDown
			' 
			Me.XGridStepNumericUpDown.Location = New System.Drawing.Point(12, 200)
			Me.XGridStepNumericUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.XGridStepNumericUpDown.Name = "XGridStepNumericUpDown"
			Me.XGridStepNumericUpDown.Size = New System.Drawing.Size(120, 20)
			Me.XGridStepNumericUpDown.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XGridStepNumericUpDown.ValueChanged += new System.EventHandler(this.XGridStepNumericUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(9, 183)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(64, 13)
			Me.label2.TabIndex = 10
			Me.label2.Text = "X Grid Step:"
			' 
			' XGridOriginNumericUpDown
			' 
			Me.XGridOriginNumericUpDown.Location = New System.Drawing.Point(12, 154)
			Me.XGridOriginNumericUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.XGridOriginNumericUpDown.Name = "XGridOriginNumericUpDown"
			Me.XGridOriginNumericUpDown.Size = New System.Drawing.Size(120, 20)
			Me.XGridOriginNumericUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XGridOriginNumericUpDown.ValueChanged += new System.EventHandler(this.XGridOriginNumericUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(9, 137)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(69, 13)
			Me.label3.TabIndex = 8
			Me.label3.Text = "X Grid Origin:"
			' 
			' YGridStepNumericUpDown
			' 
			Me.YGridStepNumericUpDown.Location = New System.Drawing.Point(12, 308)
			Me.YGridStepNumericUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.YGridStepNumericUpDown.Name = "YGridStepNumericUpDown"
			Me.YGridStepNumericUpDown.Size = New System.Drawing.Size(120, 20)
			Me.YGridStepNumericUpDown.TabIndex = 15
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YGridStepNumericUpDown.ValueChanged += new System.EventHandler(this.YGridStepNumericUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(9, 291)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(64, 13)
			Me.label4.TabIndex = 14
			Me.label4.Text = "Y Grid Step:"
			' 
			' YGridOriginNumericUpDown
			' 
			Me.YGridOriginNumericUpDown.Location = New System.Drawing.Point(12, 262)
			Me.YGridOriginNumericUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.YGridOriginNumericUpDown.Name = "YGridOriginNumericUpDown"
			Me.YGridOriginNumericUpDown.Size = New System.Drawing.Size(120, 20)
			Me.YGridOriginNumericUpDown.TabIndex = 13
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YGridOriginNumericUpDown.ValueChanged += new System.EventHandler(this.YGridOriginNumericUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(9, 245)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(69, 13)
			Me.label5.TabIndex = 12
			Me.label5.Text = "Y Grid Origin:"
			' 
			' NGridSurfaceSpacingUC
			' 
			Me.Controls.Add(Me.YGridStepNumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.YGridOriginNumericUpDown)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.XGridStepNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.XGridOriginNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.SpacingModeComboBox)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Controls.Add(Me.smoothShadingCheck)
			Me.Name = "NGridSurfaceSpacingUC"
			Me.Size = New System.Drawing.Size(176, 378)
			DirectCast(Me.XGridStepNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.XGridOriginNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.YGridStepNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.YGridOriginNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As New NLabel("Surface Grid Spacing")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 50.0F
			chart.Depth = 50.0F
			chart.Height = 30.0F
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight)

			' setup axes
			Dim scaleX As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Back }
			scaleX.InflateViewRangeBegin = False
			scaleX.InflateViewRangeEnd = False

			Dim scaleZ As New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Left }
			scaleZ.InflateViewRangeBegin = False
			scaleZ.InflateViewRangeEnd = False

			' add the surface series
			Dim surface As NGridSurfaceSeries = CType(chart.Series.Add(SeriesType.GridSurface), NGridSurfaceSeries)
			surface.Name = "Surface"
			surface.PositionValue = 10.0
			surface.SyncPaletteWithAxisScale = False
			surface.PaletteSteps = 8
			surface.ValueFormatter.FormatSpecifier = "0.000"
			surface.FillMode = SurfaceFillMode.Uniform
			surface.FrameMode = SurfaceFrameMode.Mesh
			surface.ShadingMode = ShadingMode.Flat
			surface.FillStyle = New NColorFillStyle(Color.FromArgb(190, 210, 230))

			' specify that the surface should use custom X and Z values
			surface.XValuesMode = GridSurfaceValuesMode.CustomValues
			surface.ZValuesMode = GridSurfaceValuesMode.CustomValues

			surface.Data.SetGridSize(40, 40)

			GenerateXValues(surface)
			GenerateZValues(surface)
			FillData(surface)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			smoothShadingCheck.Checked = True
			SpacingModeComboBox.FillFromEnum(GetType(GridSurfaceValuesMode))
			SpacingModeComboBox.SelectedIndex = CInt(GridSurfaceValuesMode.CustomValues)

			XGridOriginNumericUpDown.Value = 0
			XGridStepNumericUpDown.Value = 1
			YGridOriginNumericUpDown.Value = 0
			YGridStepNumericUpDown.Value = 1
		End Sub

		Private Sub GenerateXValues(ByVal surface As NGridSurfaceSeries)
			Dim sizeX As Integer = surface.Data.GridSizeX
			surface.XValues.Clear()

			Dim x As Double = 0

			For i As Integer = 0 To sizeX - 1
				surface.XValues.Add(x)
				x += Random.NextDouble() * 10
			Next i
		End Sub

		Private Sub GenerateZValues(ByVal surface As NGridSurfaceSeries)
			Dim sizeZ As Integer = surface.Data.GridSizeZ
			surface.ZValues.Clear()

			Dim z As Double = 0

			For i As Integer = 0 To sizeZ - 1
				surface.ZValues.Add(z)
				z += Random.NextDouble() * 10
			Next i
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
			Dim nCountX As Integer = surface.Data.GridSizeX
			Dim nCountZ As Integer = surface.Data.GridSizeZ

			Dim sizeXOrigin As Double = -2.3
			Dim sizeXScale As Double = 4.6 / nCountX


			For z As Integer = 0 To nCountZ - 1
				For x As Integer = 0 To nCountX - 1
					Dim xVal As Double = (x * sizeXScale) + sizeXOrigin
					Dim yVal As Double = (z * sizeXScale) + sizeXOrigin

					Dim zVal As Double = xVal * Math.Exp(-(xVal * xVal + yVal * yVal))

					surface.Data.SetValue(x, z, zVal)
				Next x
			Next z
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

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GenerateDataButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			GenerateXValues(surface)
			GenerateZValues(surface)

			nChartControl1.Refresh()
		End Sub

		Private Sub SpacingModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SpacingModeComboBox.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)
			surface.XValuesMode = CType(SpacingModeComboBox.SelectedIndex, GridSurfaceValuesMode)
			surface.ZValuesMode = CType(SpacingModeComboBox.SelectedIndex, GridSurfaceValuesMode)

			Dim originAndStepMode As Boolean = SpacingModeComboBox.SelectedIndex = CInt(GridSurfaceValuesMode.OriginAndStep)

			XGridOriginNumericUpDown.Enabled = originAndStepMode
			XGridStepNumericUpDown.Enabled = originAndStepMode
			YGridOriginNumericUpDown.Enabled = originAndStepMode
			YGridStepNumericUpDown.Enabled = originAndStepMode

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateSurfaceOriginAndStep()
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim surface As NGridSurfaceSeries = CType(chart.Series(0), NGridSurfaceSeries)

			surface.OriginX = CSng(XGridOriginNumericUpDown.Value)
			surface.StepX = CSng(XGridStepNumericUpDown.Value)
			surface.OriginZ = CSng(YGridOriginNumericUpDown.Value)
			surface.StepZ = CSng(YGridStepNumericUpDown.Value)

			nChartControl1.Refresh()
		End Sub

		Private Sub XGridOriginNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles XGridOriginNumericUpDown.ValueChanged
			UpdateSurfaceOriginAndStep()
		End Sub

		Private Sub XGridStepNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles XGridStepNumericUpDown.ValueChanged
			UpdateSurfaceOriginAndStep()
		End Sub

		Private Sub YGridOriginNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles YGridOriginNumericUpDown.ValueChanged
			UpdateSurfaceOriginAndStep()
		End Sub

		Private Sub YGridStepNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles YGridStepNumericUpDown.ValueChanged
			UpdateSurfaceOriginAndStep()
		End Sub
	End Class
End Namespace