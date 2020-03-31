Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Resources
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAutoWallsAndAxesVisibilityUC
		Inherits NExampleBaseUC

		Private WithEvents AutoWallVisibilityCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents LightsInCameraSpaceCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AxisAnchorsModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As Label
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			AxisAnchorsModeCombo.Items.Add("Best Visibility")
			AxisAnchorsModeCombo.Items.Add("Auto Side")
			AxisAnchorsModeCombo.Items.Add("Manual")
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
			Me.AutoWallVisibilityCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LightsInCameraSpaceCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AxisAnchorsModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' AutoWallVisibilityCheck
			' 
			Me.AutoWallVisibilityCheck.ButtonProperties.BorderOffset = 2
			Me.AutoWallVisibilityCheck.Location = New System.Drawing.Point(12, 14)
			Me.AutoWallVisibilityCheck.Name = "AutoWallVisibilityCheck"
			Me.AutoWallVisibilityCheck.Size = New System.Drawing.Size(157, 21)
			Me.AutoWallVisibilityCheck.TabIndex = 0
			Me.AutoWallVisibilityCheck.Text = "Enable Auto Wall Visibility"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AutoWallVisibilityCheck.CheckedChanged += new System.EventHandler(this.AutoWallVisibilityCheck_CheckedChanged);
			' 
			' LightsInCameraSpaceCheck
			' 
			Me.LightsInCameraSpaceCheck.ButtonProperties.BorderOffset = 2
			Me.LightsInCameraSpaceCheck.Location = New System.Drawing.Point(12, 48)
			Me.LightsInCameraSpaceCheck.Name = "LightsInCameraSpaceCheck"
			Me.LightsInCameraSpaceCheck.Size = New System.Drawing.Size(157, 21)
			Me.LightsInCameraSpaceCheck.TabIndex = 2
			Me.LightsInCameraSpaceCheck.Text = "Lights in Camera Space"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LightsInCameraSpaceCheck.CheckedChanged += new System.EventHandler(this.LightsInCameraSpaceCheck_CheckedChanged);
			' 
			' AxisAnchorsModeCombo
			' 
			Me.AxisAnchorsModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.AxisAnchorsModeCombo.ListProperties.DataSource = Nothing
			Me.AxisAnchorsModeCombo.ListProperties.DisplayMember = ""
			Me.AxisAnchorsModeCombo.Location = New System.Drawing.Point(12, 99)
			Me.AxisAnchorsModeCombo.Name = "AxisAnchorsModeCombo"
			Me.AxisAnchorsModeCombo.Size = New System.Drawing.Size(142, 21)
			Me.AxisAnchorsModeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AxisAnchorsModeCombo.SelectedIndexChanged += new System.EventHandler(this.AxisAnchorsModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(12, 82)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(80, 14)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Axis Anchors Mode:"
			' 
			' NAutoWallsAndAxesVisibilityUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.AxisAnchorsModeCombo)
			Me.Controls.Add(Me.LightsInCameraSpaceCheck)
			Me.Controls.Add(Me.AutoWallVisibilityCheck)
			Me.Name = "NAutoWallsAndAxesVisibilityUC"
			Me.Size = New System.Drawing.Size(180, 238)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			nChartControl1.Legends.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Chart Walls")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 55
			chart.Height = 25
			chart.Depth = 40
			chart.BoundsMode = BoundsMode.Fit
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.GlobalAmbientLight = Color.FromArgb(20, 20, 20)

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Left, ChartWallType.Right, ChartWallType.Front }

			Dim scaleY As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleY.StripStyles.Add(stripStyle)

			' create several series
			For i As Integer = 0 To 3
				Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
				bar.Values.FillRandom(Random, 6)
				bar.DataLabelStyle.Visible = False
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			AutoWallVisibilityCheck.Checked = True
			LightsInCameraSpaceCheck.Checked = True
			AxisAnchorsModeCombo.SelectedIndex = 0
		End Sub

		Private Sub AutoWallVisibilityCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AutoWallVisibilityCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			If AutoWallVisibilityCheck.Checked Then
				For Each wall As NChartWall In chart.Walls
					wall.VisibilityMode = WallVisibilityMode.Auto
				Next wall
			Else
				chart.Wall(ChartWallType.Left).VisibilityMode = WallVisibilityMode.Visible
				chart.Wall(ChartWallType.Back).VisibilityMode = WallVisibilityMode.Visible
				chart.Wall(ChartWallType.Floor).VisibilityMode = WallVisibilityMode.Visible
				chart.Wall(ChartWallType.Front).VisibilityMode = WallVisibilityMode.Hidden
				chart.Wall(ChartWallType.Top).VisibilityMode = WallVisibilityMode.Hidden
				chart.Wall(ChartWallType.Right).VisibilityMode = WallVisibilityMode.Hidden
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub LightsInCameraSpaceCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LightsInCameraSpaceCheck.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim light As New NPointLightSource()
			light.Ambient = Color.FromArgb(64, 64, 64)
			light.Diffuse = Color.FromArgb(230, 230, 230)
			light.Specular = Color.FromArgb(10, 10, 10)

			If LightsInCameraSpaceCheck.Checked Then
				light.CoordinateMode = LightSourceCoordinateMode.Camera
				light.Position = New NVector3DF(0, 0, 50)
			Else
				light.CoordinateMode = LightSourceCoordinateMode.Model
				light.Position = New NVector3DF(30, 20, 50)
			End If

			chart.LightModel.LightSources.Clear()
			chart.LightModel.LightSources.Add(light)

			nChartControl1.Refresh()
		End Sub

		Private Sub AxisAnchorsModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AxisAnchorsModeCombo.SelectedIndexChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			Dim anchorY As NAxisAnchor = Nothing
			Dim anchorX As NAxisAnchor = Nothing
			Dim anchorZ As NAxisAnchor = Nothing

			Select Case AxisAnchorsModeCombo.SelectedIndex
				Case 0
					anchorY = New NBestVisibilityAxisAnchor(AxisOrientation.Vertical)
					anchorX = New NBestVisibilityAxisAnchor(AxisOrientation.Horizontal)
					anchorZ = New NBestVisibilityAxisAnchor(AxisOrientation.Depth)

				Case 1
					anchorY = New NAutoSideAxisAnchor(AxisOrientation.Vertical)
					anchorX = New NAutoSideAxisAnchor(AxisOrientation.Horizontal)
					anchorZ = New NAutoSideAxisAnchor(AxisOrientation.Depth)

				Case 2
					anchorY = New NDockAxisAnchor(AxisDockZone.FrontLeft)
					anchorX = New NDockAxisAnchor(AxisDockZone.FrontBottom)
					anchorZ = New NDockAxisAnchor(AxisDockZone.BottomRight)
			End Select

			chart.Axis(StandardAxis.PrimaryY).Anchor = anchorY
			chart.Axis(StandardAxis.PrimaryX).Anchor = anchorX
			chart.Axis(StandardAxis.Depth).Anchor = anchorZ

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
