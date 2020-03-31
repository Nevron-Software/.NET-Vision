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
	Public Class NAxisLabelsOrientationUC
		Inherits NExampleBaseUC

		Private Const categoriesCount As Integer = 6
		Private m_Chart As NCartesianChart
		Private WithEvents RotationScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents ElevationScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents Use3DCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AllowTextFlipCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents CustomAngleNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents AngleModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents Fit3DChartCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.AllowTextFlipCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.CustomAngleNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.AngleModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.RotationScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.ElevationScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.Use3DCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.Fit3DChartCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.CustomAngleNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' AllowTextFlipCheckBox
			' 
			Me.AllowTextFlipCheckBox.AutoSize = True
			Me.AllowTextFlipCheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowTextFlipCheckBox.Location = New System.Drawing.Point(11, 108)
			Me.AllowTextFlipCheckBox.Name = "AllowTextFlipCheckBox"
			Me.AllowTextFlipCheckBox.Size = New System.Drawing.Size(109, 17)
			Me.AllowTextFlipCheckBox.TabIndex = 4
			Me.AllowTextFlipCheckBox.Text = "Allow labels to flip"
			Me.AllowTextFlipCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowTextFlipCheckBox.CheckedChanged += new System.EventHandler(this.AllowTextFlipCheckBox_CheckedChanged);
			' 
			' CustomAngleNumericUpDown
			' 
			Me.CustomAngleNumericUpDown.Increment = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.CustomAngleNumericUpDown.Location = New System.Drawing.Point(11, 71)
			Me.CustomAngleNumericUpDown.Maximum = New Decimal(New Integer() { 360, 0, 0, 0})
			Me.CustomAngleNumericUpDown.Name = "CustomAngleNumericUpDown"
			Me.CustomAngleNumericUpDown.Size = New System.Drawing.Size(154, 20)
			Me.CustomAngleNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CustomAngleNumericUpDown.ValueChanged += new System.EventHandler(this.CustomAngleNumericUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(11, 54)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(75, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Custom Angle:"
			' 
			' AngleModeComboBox
			' 
			Me.AngleModeComboBox.Location = New System.Drawing.Point(11, 26)
			Me.AngleModeComboBox.Name = "AngleModeComboBox"
			Me.AngleModeComboBox.Size = New System.Drawing.Size(154, 21)
			Me.AngleModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AngleModeComboBox.SelectedIndexChanged += new System.EventHandler(this.AngleModeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(11, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(67, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Angle Mode:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(11, 198)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(50, 13)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Rotation:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(11, 247)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(54, 13)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Elevation:"
			' 
			' RotationScrollBar
			' 
			Me.RotationScrollBar.Location = New System.Drawing.Point(11, 217)
			Me.RotationScrollBar.Maximum = 360
			Me.RotationScrollBar.Minimum = -360
			Me.RotationScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.RotationScrollBar.Name = "RotationScrollBar"
			Me.RotationScrollBar.Size = New System.Drawing.Size(154, 16)
			Me.RotationScrollBar.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RotationScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.RotationScrollBar_ValueChanged);
			' 
			' ElevationScrollBar
			' 
			Me.ElevationScrollBar.Location = New System.Drawing.Point(11, 265)
			Me.ElevationScrollBar.Maximum = 360
			Me.ElevationScrollBar.Minimum = -360
			Me.ElevationScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.ElevationScrollBar.Name = "ElevationScrollBar"
			Me.ElevationScrollBar.Size = New System.Drawing.Size(154, 16)
			Me.ElevationScrollBar.TabIndex = 9
			Me.ElevationScrollBar.Value = -360
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ElevationScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.ElevationScrollBar_ValueChanged);
			' 
			' Use3DCheckBox
			' 
			Me.Use3DCheckBox.AutoSize = True
			Me.Use3DCheckBox.ButtonProperties.BorderOffset = 2
			Me.Use3DCheckBox.Location = New System.Drawing.Point(11, 135)
			Me.Use3DCheckBox.Name = "Use3DCheckBox"
			Me.Use3DCheckBox.Size = New System.Drawing.Size(90, 17)
			Me.Use3DCheckBox.TabIndex = 5
			Me.Use3DCheckBox.Text = "Use 3D Chart"
			Me.Use3DCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Use3DCheckBox.CheckedChanged += new System.EventHandler(this.Use3DCheckBox_CheckedChanged);
			' 
			' Fit3DChartCheckBox
			' 
			Me.Fit3DChartCheckBox.AutoSize = True
			Me.Fit3DChartCheckBox.ButtonProperties.BorderOffset = 2
			Me.Fit3DChartCheckBox.Location = New System.Drawing.Point(11, 163)
			Me.Fit3DChartCheckBox.Name = "Fit3DChartCheckBox"
			Me.Fit3DChartCheckBox.Size = New System.Drawing.Size(113, 17)
			Me.Fit3DChartCheckBox.TabIndex = 10
			Me.Fit3DChartCheckBox.Text = "Fit 3D Chart in box"
			Me.Fit3DChartCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Fit3DChartCheckBox.CheckedChanged += new System.EventHandler(this.Fit3DChartCheckBox_CheckedChanged);
			' 
			' NAxisLabelsOrientationUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.Fit3DChartCheckBox)
			Me.Controls.Add(Me.Use3DCheckBox)
			Me.Controls.Add(Me.ElevationScrollBar)
			Me.Controls.Add(Me.RotationScrollBar)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.AllowTextFlipCheckBox)
			Me.Controls.Add(Me.CustomAngleNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.AngleModeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NAxisLabelsOrientationUC"
			Me.Size = New System.Drawing.Size(178, 323)
			DirectCast(Me.CustomAngleNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' configure the trackball
			Dim trackballTool As New NTrackballTool()
			AddHandler trackballTool.ProjectionChanged, AddressOf OnProjectionChanged
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(trackballTool)

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Labels Orientation")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(10, 10, 10, 10)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			title.SendToBack()

			' no legend
			nChartControl1.Legends.Clear()

			' setup the chart
			m_Chart = CType(nChartControl1.Charts(0), NCartesianChart)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.Depth = 50
			m_Chart.Width = 50
			m_Chart.Height = 50
			m_Chart.BorderStyle = New NStrokeBorderStyle(BorderShape.RoundedRect)
			m_Chart.BoundsMode = BoundsMode.Fit
			m_Chart.DockMode = PanelDockMode.Fill
			m_Chart.Margins = New NMarginsL(30, 0, 30, 30)
			m_Chart.Padding = New NMarginsL(5, 5, 5, 5)
			m_Chart.BackgroundFillStyle = New NGradientFillStyle(Color.White, Color.LightGray)

			' setup Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.Title.Text = "Values"

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Left }
			stripStyle.Interlaced = True
			scaleY.StripStyles.Add(stripStyle)

			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' configure the x axis labels (categories)
			Dim scaleX As NOrdinalScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.Title.Text = "Categories Title"
			scaleX.MajorTickMode = MajorTickMode.CustomStep
			scaleX.LabelFitModes = New LabelFitMode() { LabelFitMode.Stagger2, LabelFitMode.AutoScale }

			For j As Integer = 0 To categoriesCount - 1
				scaleX.Labels.Add("Category " & j.ToString())
			Next j

			' configure the depth axis labels (series)
			Dim scaleZ As NOrdinalScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleZ.AutoLabels = False
			scaleZ.Title.Text = "Series Title"
			scaleZ.MajorTickMode = MajorTickMode.CustomStep
			scaleZ.Labels.Add("Series 1")
			scaleZ.Labels.Add("Series 2")
			scaleZ.Labels.Add("Series 3")
			scaleZ.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			scaleZ.LabelFitModes = New LabelFitMode() { LabelFitMode.Stagger2, LabelFitMode.AutoScale }

			' add series
			For i As Integer = 0 To 2
				Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
				bar.InflateMargins = True
				bar.BarShape = BarShape.SmoothEdgeBar
				bar.DataLabelStyle.Visible = False
				bar.Name = "Series " & i.ToString()
				bar.Values.FillRandomRange(Random, categoriesCount, 10, 30)
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' initialize controls on the form
			AngleModeComboBox.FillFromEnum(GetType(ScaleLabelAngleMode))
			AngleModeComboBox.SelectedIndex = CInt(ScaleLabelAngleMode.Scale)
			Use3DCheckBox.Checked = True

			OnProjectionChanged(Nothing, Nothing)
		End Sub

		Private Sub OnProjectionChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim elevation As Single = m_Chart.Projection.Elevation
			Dim rotation As Single = m_Chart.Projection.Rotation

			ElevationScrollBar.Value = CInt(Math.Truncate(elevation))
			RotationScrollBar.Value = CInt(Math.Truncate(rotation))
		End Sub

		Private Sub UpdateScaleLabelAngle()
			If m_Chart IsNot Nothing Then
				Dim count As Integer = m_Chart.Axes.Count

				Dim angle As New NScaleLabelAngle(CType(AngleModeComboBox.SelectedIndex, ScaleLabelAngleMode), CSng(CustomAngleNumericUpDown.Value), AllowTextFlipCheckBox.Checked)

				' update the x axis
				Dim axis As NAxis = DirectCast(m_Chart.Axes(CInt(StandardAxis.PrimaryX)), NAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim scale_Renamed As NStandardScaleConfigurator = TryCast(axis.ScaleConfigurator, NStandardScaleConfigurator)
				scale_Renamed.LabelStyle.Angle = angle

				' update the depth axis
				axis = DirectCast(m_Chart.Axes(CInt(StandardAxis.Depth)), NAxis)
				scale_Renamed = TryCast(axis.ScaleConfigurator, NStandardScaleConfigurator)
				scale_Renamed.LabelStyle.Angle = angle

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub UpdateProjection()
			If m_Chart IsNot Nothing Then
				m_Chart.Projection.Rotation = CSng(RotationScrollBar.Value)
				m_Chart.Projection.Elevation = CSng(ElevationScrollBar.Value)

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub AngleModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AngleModeComboBox.SelectedIndexChanged
			UpdateScaleLabelAngle()
		End Sub

		Private Sub CustomAngleNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CustomAngleNumericUpDown.ValueChanged
			UpdateScaleLabelAngle()
		End Sub

		Private Sub AllowTextFlipCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AllowTextFlipCheckBox.CheckedChanged
			UpdateScaleLabelAngle()
		End Sub

		Private Sub ElevationScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles ElevationScrollBar.ValueChanged
			UpdateProjection()
		End Sub

		Private Sub RotationScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles RotationScrollBar.ValueChanged
			UpdateProjection()
		End Sub

		Private Sub Use3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Use3DCheckBox.CheckedChanged
			m_Chart.Enable3D = Use3DCheckBox.Checked

			RotationScrollBar.Enabled = Use3DCheckBox.Checked
			ElevationScrollBar.Enabled = Use3DCheckBox.Checked
			Fit3DChartCheckBox.Enabled = Use3DCheckBox.Checked
		End Sub

		Private Sub Fit3DChartCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Fit3DChartCheckBox.CheckedChanged
			m_Chart.Fit3DAxisContent = Fit3DChartCheckBox.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
