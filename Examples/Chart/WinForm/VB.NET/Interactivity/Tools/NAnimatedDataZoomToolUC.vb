Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAnimatedDataZoomToolUC
		Inherits NExampleBaseUC

		Private WithEvents ResetAxesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents AnimateZoomingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents AnimationStepsNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label5 As Label
		Private WithEvents AnimationIntervalNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label6 As Label
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
			Me.ResetAxesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.AnimateZoomingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AnimationStepsNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.AnimationIntervalNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			DirectCast(Me.AnimationStepsNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.AnimationIntervalNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ResetAxesButton
			' 
			Me.ResetAxesButton.Location = New System.Drawing.Point(11, 104)
			Me.ResetAxesButton.Name = "ResetAxesButton"
			Me.ResetAxesButton.Size = New System.Drawing.Size(160, 23)
			Me.ResetAxesButton.TabIndex = 20
			Me.ResetAxesButton.Text = "Reset axes"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ResetAxesButton.Click += new System.EventHandler(this.ResetAxesButton_Click);
			' 
			' AnimateZoomingCheckBox
			' 
			Me.AnimateZoomingCheckBox.ButtonProperties.BorderOffset = 2
			Me.AnimateZoomingCheckBox.Location = New System.Drawing.Point(11, 11)
			Me.AnimateZoomingCheckBox.Name = "AnimateZoomingCheckBox"
			Me.AnimateZoomingCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.AnimateZoomingCheckBox.TabIndex = 11
			Me.AnimateZoomingCheckBox.Text = "Animate Zooming"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AnimateZoomingCheckBox.CheckedChanged += new System.EventHandler(this.AnimateZoomingCheckBox_CheckedChanged);
			' 
			' AnimationStepsNumericUpDown
			' 
			Me.AnimationStepsNumericUpDown.Location = New System.Drawing.Point(109, 40)
			Me.AnimationStepsNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.AnimationStepsNumericUpDown.Name = "AnimationStepsNumericUpDown"
			Me.AnimationStepsNumericUpDown.Size = New System.Drawing.Size(62, 20)
			Me.AnimationStepsNumericUpDown.TabIndex = 0
			Me.AnimationStepsNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AnimationStepsNumericUpDown.ValueChanged += new System.EventHandler(this.AnimationStepsNumericUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(11, 44)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(92, 16)
			Me.label5.TabIndex = 12
			Me.label5.Text = "Steps:"
			' 
			' AnimationIntervalNumericUpDown
			' 
			Me.AnimationIntervalNumericUpDown.Location = New System.Drawing.Point(109, 66)
			Me.AnimationIntervalNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.AnimationIntervalNumericUpDown.Name = "AnimationIntervalNumericUpDown"
			Me.AnimationIntervalNumericUpDown.Size = New System.Drawing.Size(62, 20)
			Me.AnimationIntervalNumericUpDown.TabIndex = 15
			Me.AnimationIntervalNumericUpDown.Value = New Decimal(New Integer() { 50, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AnimationIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.AnimationIntervalNumericUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(11, 70)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(92, 16)
			Me.label6.TabIndex = 14
			Me.label6.Text = "Interval (ms):"
			' 
			' NAnimatedDataZoomToolUC
			' 
			Me.Controls.Add(Me.AnimationIntervalNumericUpDown)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.AnimationStepsNumericUpDown)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.AnimateZoomingCheckBox)
			Me.Controls.Add(Me.ResetAxesButton)
			Me.Name = "NAnimatedDataZoomToolUC"
			Me.Size = New System.Drawing.Size(180, 664)
			DirectCast(Me.AnimationStepsNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.AnimationIntervalNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Animated Data Zoom")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)

			chart.RangeSelections.Add(New NRangeSelection())

			' 2D line chart
			chart.BoundsMode = BoundsMode.Stretch

			' configure axis pagin and set a mimimum range length on the axis
			' this will prevent the user from zooming too much
			chart.Axis(StandardAxis.PrimaryX).PagingView = New NNumericAxisPagingView()
			chart.Axis(StandardAxis.PrimaryX).PagingView.MinPageLength = 0.00001
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = CreateLinearScale()

			chart.Axis(StandardAxis.PrimaryY).PagingView = New NNumericAxisPagingView()
			chart.Axis(StandardAxis.PrimaryY).PagingView.MinPageLength = 0.00001F
			chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = True
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = CreateLinearScale()

			' add point series
			chart.Series.Clear()
			Dim point1 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point1.Name = "Point 1"
			point1.PointShape = PointShape.Bar
			point1.Size = New NLength(5, NGraphicsUnit.Point)
			point1.FillStyle = New NColorFillStyle(Color.Red)
			point1.BorderStyle.Color = Color.Pink
			point1.DataLabelStyle.Visible = False
			point1.UseXValues = True
			point1.UseZValues = True
			point1.InflateMargins = True

			Dim point2 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point2.Name = "Point 2"
			point2.PointShape = PointShape.Bar
			point2.Size = New NLength(5, NGraphicsUnit.Point)
			point2.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
			point2.BorderStyle.Color = Color.LightCyan
			point2.DataLabelStyle.Visible = False
			point2.UseXValues = True
			point2.UseZValues = True
			point2.InflateMargins = True

			Dim point3 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point3.Name = "Point 3"
			point3.PointShape = PointShape.Bar
			point3.Size = New NLength(5, NGraphicsUnit.Point)
			point3.FillStyle = New NColorFillStyle(Color.Green)
			point3.BorderStyle.Color = Color.Chartreuse
			point3.DataLabelStyle.Visible = False
			point3.UseXValues = True
			point3.UseZValues = True
			point3.InflateMargins = True

			' fill with random data
			point1.Values.FillRandomRange(Random, 10, 0, 50)
			point1.XValues.FillRandomRange(Random, 10, 0, 50)
			point1.ZValues.FillRandomRange(Random, 10, 0, 50)

			point2.Values.FillRandomRange(Random, 10, 25, 75)
			point2.XValues.FillRandomRange(Random, 10, 25, 75)
			point2.ZValues.FillRandomRange(Random, 10, 25, 75)

			point3.Values.FillRandomRange(Random, 10, 75, 125)
			point3.XValues.FillRandomRange(Random, 10, 75, 125)
			point3.ZValues.FillRandomRange(Random, 10, 75, 125)

			AnimateZoomingCheckBox.Checked = True

			UpdateDataZoomTool()
		End Sub

		Private Sub UpdateDataZoomTool()
			If nChartControl1 Is Nothing Then
				Return
			End If

			nChartControl1.Controller.Tools.Clear()
			Dim dataZoomTool As New NDataZoomTool()

			dataZoomTool.AnimateZooming = AnimateZoomingCheckBox.Checked
			dataZoomTool.AnimationSteps = CInt(Math.Truncate(AnimationStepsNumericUpDown.Value))

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(dataZoomTool)
		End Sub

		Private Function CreateLinearScale() As NLinearScaleConfigurator
			Dim linearScale As New NLinearScaleConfigurator()

			linearScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)
			linearScale.MinorTickCount = 4

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			Return linearScale
		End Function

		Private Sub ResetAxesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResetAxesButton.Click
			Dim chart As NChart = CType(nChartControl1.Charts(0), NChart)

			chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = False
			chart.Axis(StandardAxis.PrimaryY).PagingView.Enabled = False
			chart.Axis(StandardAxis.Depth).PagingView.Enabled = False

			nChartControl1.Refresh()
		End Sub

		Private Sub AnimateZoomingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AnimateZoomingCheckBox.CheckedChanged
			UpdateDataZoomTool()
		End Sub

		Private Sub AnimationStepsNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AnimationStepsNumericUpDown.ValueChanged
			UpdateDataZoomTool()
		End Sub

		Private Sub AnimationIntervalNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AnimationIntervalNumericUpDown.ValueChanged
			UpdateDataZoomTool()
		End Sub
	End Class
End Namespace
