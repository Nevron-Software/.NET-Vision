Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDragToolsUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private WithEvents DragModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private ProjectionParametersGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private WithEvents RotationUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ElevationUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ZoomUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ViewerRotationUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents UseWindowRenderSurfaceCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.DragModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ProjectionParametersGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ViewerRotationUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label9 = New System.Windows.Forms.Label()
			Me.ZoomUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ElevationUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.RotationUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.UseWindowRenderSurfaceCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ProjectionParametersGroupBox.SuspendLayout()
			DirectCast(Me.ViewerRotationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ZoomUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ElevationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.RotationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Drag mode:"
			' 
			' DragModeComboBox
			' 
			Me.DragModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.DragModeComboBox.ListProperties.DataSource = Nothing
			Me.DragModeComboBox.ListProperties.DisplayMember = ""
			Me.DragModeComboBox.Location = New System.Drawing.Point(4, 30)
			Me.DragModeComboBox.Name = "DragModeComboBox"
			Me.DragModeComboBox.Size = New System.Drawing.Size(172, 21)
			Me.DragModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DragModeComboBox.SelectedIndexChanged += new System.EventHandler(this.DragModeComboBox_SelectedIndexChanged);
			' 
			' ProjectionParametersGroupBox
			' 
			Me.ProjectionParametersGroupBox.Controls.Add(Me.ViewerRotationUpDown)
			Me.ProjectionParametersGroupBox.Controls.Add(Me.label9)
			Me.ProjectionParametersGroupBox.Controls.Add(Me.ZoomUpDown)
			Me.ProjectionParametersGroupBox.Controls.Add(Me.ElevationUpDown)
			Me.ProjectionParametersGroupBox.Controls.Add(Me.RotationUpDown)
			Me.ProjectionParametersGroupBox.Controls.Add(Me.label4)
			Me.ProjectionParametersGroupBox.Controls.Add(Me.label3)
			Me.ProjectionParametersGroupBox.Controls.Add(Me.label2)
			Me.ProjectionParametersGroupBox.ImageIndex = 0
			Me.ProjectionParametersGroupBox.Location = New System.Drawing.Point(4, 58)
			Me.ProjectionParametersGroupBox.Name = "ProjectionParametersGroupBox"
			Me.ProjectionParametersGroupBox.Size = New System.Drawing.Size(172, 120)
			Me.ProjectionParametersGroupBox.TabIndex = 2
			Me.ProjectionParametersGroupBox.TabStop = False
			Me.ProjectionParametersGroupBox.Text = "Projection parameters"
			' 
			' ViewerRotationUpDown
			' 
			Me.ViewerRotationUpDown.DecimalPlaces = 2
			Me.ViewerRotationUpDown.Location = New System.Drawing.Point(94, 88)
			Me.ViewerRotationUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.ViewerRotationUpDown.Name = "ViewerRotationUpDown"
			Me.ViewerRotationUpDown.Size = New System.Drawing.Size(64, 20)
			Me.ViewerRotationUpDown.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ViewerRotationUpDown.ValueChanged += new System.EventHandler(this.ViewerRotationUpDown_ValueChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(6, 92)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(88, 16)
			Me.label9.TabIndex = 8
			Me.label9.Text = "Viewer rotation:"
			' 
			' ZoomUpDown
			' 
			Me.ZoomUpDown.DecimalPlaces = 2
			Me.ZoomUpDown.Location = New System.Drawing.Point(94, 64)
			Me.ZoomUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.ZoomUpDown.Name = "ZoomUpDown"
			Me.ZoomUpDown.Size = New System.Drawing.Size(64, 20)
			Me.ZoomUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZoomUpDown.ValueChanged += new System.EventHandler(this.ZoomUpDown_ValueChanged);
			' 
			' ElevationUpDown
			' 
			Me.ElevationUpDown.DecimalPlaces = 2
			Me.ElevationUpDown.Location = New System.Drawing.Point(94, 40)
			Me.ElevationUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.ElevationUpDown.Minimum = New Decimal(New Integer() { 10000, 0, 0, -2147483648})
			Me.ElevationUpDown.Name = "ElevationUpDown"
			Me.ElevationUpDown.Size = New System.Drawing.Size(64, 20)
			Me.ElevationUpDown.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ElevationUpDown.ValueChanged += new System.EventHandler(this.ElevationUpDown_ValueChanged);
			' 
			' RotationUpDown
			' 
			Me.RotationUpDown.Cursor = System.Windows.Forms.Cursors.Default
			Me.RotationUpDown.DecimalPlaces = 2
			Me.RotationUpDown.Location = New System.Drawing.Point(94, 16)
			Me.RotationUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.RotationUpDown.Minimum = New Decimal(New Integer() { 10000, 0, 0, -2147483648})
			Me.RotationUpDown.Name = "RotationUpDown"
			Me.RotationUpDown.Size = New System.Drawing.Size(64, 20)
			Me.RotationUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RotationUpDown.ValueChanged += new System.EventHandler(this.RotationUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 68)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(48, 16)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Zoom:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 44)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(56, 16)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Elevation:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 20)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(64, 16)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Rotation:"
			' 
			' UseWindowRenderSurfaceCheckBox
			' 
			Me.UseWindowRenderSurfaceCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseWindowRenderSurfaceCheckBox.Location = New System.Drawing.Point(4, 186)
			Me.UseWindowRenderSurfaceCheckBox.Name = "UseWindowRenderSurfaceCheckBox"
			Me.UseWindowRenderSurfaceCheckBox.Size = New System.Drawing.Size(120, 24)
			Me.UseWindowRenderSurfaceCheckBox.TabIndex = 15
			Me.UseWindowRenderSurfaceCheckBox.Text = "Render to window"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseWindowRenderSurfaceCheckBox.CheckedChanged += new System.EventHandler(this.UseWindowRenderSurfaceCheckBox_CheckedChanged);
			' 
			' NDragToolsUC
			' 
			Me.Controls.Add(Me.UseWindowRenderSurfaceCheckBox)
			Me.Controls.Add(Me.ProjectionParametersGroupBox)
			Me.Controls.Add(Me.DragModeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NDragToolsUC"
			Me.Size = New System.Drawing.Size(180, 221)
			Me.ProjectionParametersGroupBox.ResumeLayout(False)
			DirectCast(Me.ViewerRotationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ZoomUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ElevationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.RotationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Drag Operations")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' disable legend
			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			' configure chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.DataLabelStyle.Visible = True

			' add some data to the bar series
			bar.AddDataPoint(New NDataPoint(18, "C++"))
			bar.AddDataPoint(New NDataPoint(15, "Ruby"))
			bar.AddDataPoint(New NDataPoint(21, "Python"))
			bar.AddDataPoint(New NDataPoint(23, "Java"))
			bar.AddDataPoint(New NDataPoint(27, "Javascript"))
			bar.AddDataPoint(New NDataPoint(29, "C#"))
			bar.AddDataPoint(New NDataPoint(26, "PHP"))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.AutumnMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			DragModeComboBox.Items.Add("Disabled")
			DragModeComboBox.Items.Add("Trackball")
			DragModeComboBox.Items.Add("Zoom")
			DragModeComboBox.Items.Add("Offset")
			DragModeComboBox.SelectedIndex = 0

			nChartControl1.Controller.Selection.Add(chart)

			UpdateControlsFromChart()
		End Sub


		Private Sub OnViewChange(ByVal sender As Object, ByVal eventArgs As EventArgs)
			UpdateControlsFromChart()
		End Sub

		Private Sub UpdateControlsFromChart()
			Dim projection As NProjection = nChartControl1.Charts(0).Projection

			RotationUpDown.Value = CDec(projection.Rotation)
			ElevationUpDown.Value = CDec(projection.Elevation)
			ZoomUpDown.Value = CDec(projection.Zoom)
			ViewerRotationUpDown.Value = CDec(projection.ViewerRotation)
		End Sub

		Private Sub ViewerRotationUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewerRotationUpDown.ValueChanged
			nChartControl1.Charts(0).Projection.ViewerRotation = CSng(ViewerRotationUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub ZoomUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ZoomUpDown.ValueChanged
			nChartControl1.Charts(0).Projection.Zoom = CSng(ZoomUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub ElevationUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ElevationUpDown.ValueChanged
			nChartControl1.Charts(0).Projection.Elevation = CSng(ElevationUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub RotationUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RotationUpDown.ValueChanged
			nChartControl1.Charts(0).Projection.Rotation = CSng(RotationUpDown.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub DragModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DragModeComboBox.SelectedIndexChanged
			Dim dragTool As NDragTool = Nothing

			If nChartControl1.Controller.Tools.Count > 0 Then
				dragTool = TryCast(nChartControl1.Controller.Tools(0), NDragTool)
			End If

			If dragTool IsNot Nothing Then
				RemoveHandler dragTool.Drag, AddressOf OnViewChange
				dragTool = Nothing
			End If

			nChartControl1.Controller.Tools.Clear()

			Select Case DragModeComboBox.SelectedIndex
				' Trackball
				Case 1
					dragTool = New NTrackballTool()
				' Zoom 
				Case 2
					dragTool = New NZoomTool()
				' Offset
				Case 3
					dragTool = New NOffsetTool()
			End Select

			If dragTool IsNot Nothing Then
				AddHandler dragTool.Drag, AddressOf OnViewChange
				nChartControl1.Controller.Tools.Add(dragTool)
			End If
		End Sub

		Private Sub UseWindowRenderSurfaceCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseWindowRenderSurfaceCheckBox.CheckedChanged
			If UseWindowRenderSurfaceCheckBox.Checked Then
				nChartControl1.Settings.RenderSurface = RenderSurface.Window
			Else
				nChartControl1.Settings.RenderSurface = RenderSurface.Bitmap
			End If
		End Sub

	End Class
End Namespace
