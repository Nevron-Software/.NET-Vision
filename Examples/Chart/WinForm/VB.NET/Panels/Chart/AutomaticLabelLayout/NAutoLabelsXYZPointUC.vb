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
	Public Class NAutoLabelsXYZPointUC
		Inherits NExampleBaseUC

		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents EnableLabelAdjustmentCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableInitialPositioningCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RemoveOverlappedLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableDataPointSafeguardCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label8 As Label
		Private WithEvents SafeguardSizeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
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
			Me.EnableLabelAdjustmentCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.EnableInitialPositioningCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RemoveOverlappedLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableDataPointSafeguardCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label8 = New System.Windows.Forms.Label()
			Me.SafeguardSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			DirectCast(Me.SafeguardSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' EnableLabelAdjustmentCheck
			' 
			Me.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2
			Me.EnableLabelAdjustmentCheck.Location = New System.Drawing.Point(6, 115)
			Me.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck"
			Me.EnableLabelAdjustmentCheck.Size = New System.Drawing.Size(155, 21)
			Me.EnableLabelAdjustmentCheck.TabIndex = 6
			Me.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(6, 9)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(168, 24)
			Me.GenerateDataButton.TabIndex = 4
			Me.GenerateDataButton.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' EnableInitialPositioningCheck
			' 
			Me.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2
			Me.EnableInitialPositioningCheck.Location = New System.Drawing.Point(6, 47)
			Me.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck"
			Me.EnableInitialPositioningCheck.Size = New System.Drawing.Size(169, 21)
			Me.EnableInitialPositioningCheck.TabIndex = 7
			Me.EnableInitialPositioningCheck.Text = "Enable Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			' 
			' RemoveOverlappedLabelsCheck
			' 
			Me.RemoveOverlappedLabelsCheck.ButtonProperties.BorderOffset = 2
			Me.RemoveOverlappedLabelsCheck.ButtonProperties.WrapText = True
			Me.RemoveOverlappedLabelsCheck.Location = New System.Drawing.Point(6, 68)
			Me.RemoveOverlappedLabelsCheck.Name = "RemoveOverlappedLabelsCheck"
			Me.RemoveOverlappedLabelsCheck.Size = New System.Drawing.Size(168, 41)
			Me.RemoveOverlappedLabelsCheck.TabIndex = 8
			Me.RemoveOverlappedLabelsCheck.Text = "Remove Overlapped Labels After Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RemoveOverlappedLabelsCheck.CheckedChanged += new System.EventHandler(this.RemoveOverlappedLabelsCheck_CheckedChanged);
			' 
			' EnableDataPointSafeguardCheck
			' 
			Me.EnableDataPointSafeguardCheck.ButtonProperties.BorderOffset = 2
			Me.EnableDataPointSafeguardCheck.Location = New System.Drawing.Point(6, 152)
			Me.EnableDataPointSafeguardCheck.Name = "EnableDataPointSafeguardCheck"
			Me.EnableDataPointSafeguardCheck.Size = New System.Drawing.Size(168, 21)
			Me.EnableDataPointSafeguardCheck.TabIndex = 9
			Me.EnableDataPointSafeguardCheck.Text = "Enable Data Point Safeguard"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableDataPointSafeguardCheck.CheckedChanged += new System.EventHandler(this.EnableDataPointSafeguardCheck_CheckedChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(6, 186)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(161, 20)
			Me.label8.TabIndex = 10
			Me.label8.Text = "Safeguard Size (in points):"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' SafeguardSizeNumericUpDown
			' 
			Me.SafeguardSizeNumericUpDown.Location = New System.Drawing.Point(6, 209)
			Me.SafeguardSizeNumericUpDown.Name = "SafeguardSizeNumericUpDown"
			Me.SafeguardSizeNumericUpDown.Size = New System.Drawing.Size(161, 20)
			Me.SafeguardSizeNumericUpDown.TabIndex = 11
			Me.SafeguardSizeNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SafeguardSizeNumericUpDown.ValueChanged += new System.EventHandler(this.SafeguardSizeNumericUpDown_ValueChanged);
			' 
			' NAutoLabelsXYZPointUC
			' 
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.SafeguardSizeNumericUpDown)
			Me.Controls.Add(Me.EnableDataPointSafeguardCheck)
			Me.Controls.Add(Me.RemoveOverlappedLabelsCheck)
			Me.Controls.Add(Me.EnableInitialPositioningCheck)
			Me.Controls.Add(Me.EnableLabelAdjustmentCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Name = "NAutoLabelsXYZPointUC"
			Me.Size = New System.Drawing.Size(180, 390)
			DirectCast(Me.SafeguardSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight)
			chart.Depth = 55.0F
			chart.Width = 55.0F
			chart.Height = 55.0F

			' set automatic walls
			For Each wall As NChartWall In chart.Walls
				wall.VisibilityMode = WallVisibilityMode.Auto
			Next wall

			' set auto axis anchors
			chart.Axis(StandardAxis.PrimaryX).Anchor = New NBestVisibilityAxisAnchor(AxisOrientation.Horizontal)
			chart.Axis(StandardAxis.PrimaryY).Anchor = New NBestVisibilityAxisAnchor(AxisOrientation.Vertical)
			chart.Axis(StandardAxis.Depth).Anchor = New NBestVisibilityAxisAnchor(AxisOrientation.Depth)

			' configure X axis
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Floor, ChartWallType.Top, ChartWallType.Front }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' configure Y axis
			Dim scaleY As New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left, ChartWallType.Right, ChartWallType.Front }
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' add interlaced stripe for Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left, ChartWallType.Front, ChartWallType.Right }
			scaleY.StripStyles.Add(stripStyle)

			' configure Z axis
			Dim scaleZ As New NLinearScaleConfigurator()
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Top, ChartWallType.Left, ChartWallType.Right }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			' point series 1
			Dim series1 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			series1.Name = "Point 1"
			series1.PointShape = PointShape.Bar
			series1.Size = New NLength(2.4F, NRelativeUnit.ParentPercentage)
			series1.UseXValues = True
			series1.UseZValues = True
			series1.InflateMargins = True
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Center
			series1.DataLabelStyle.ArrowLength = New NLength(12)
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange

			' point series 2
			Dim series2 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			series2.Name = "Point 2"
			series2.PointShape = PointShape.Bar
			series2.Size = New NLength(2.4F, NRelativeUnit.ParentPercentage)
			series2.UseXValues = True
			series2.UseZValues = True
			series2.InflateMargins = True
			series2.FillStyle = New NColorFillStyle(LightOrange)
			series2.DataLabelStyle.Visible = True
			series2.DataLabelStyle.VertAlign = VertAlign.Center
			series2.DataLabelStyle.ArrowLength = New NLength(12)
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = LightOrange

			' fill with random data
			GenerateData(chart)

			' label layout settings
			chart.LabelLayout.EnableInitialPositioning = True
			chart.LabelLayout.EnableLabelAdjustment = True

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' init form controls
			EnableLabelAdjustmentCheck.Checked = True
			RemoveOverlappedLabelsCheck.Checked = False
			EnableInitialPositioningCheck.Checked = True
			EnableDataPointSafeguardCheck.Checked = True
			SafeguardSizeNumericUpDown.Value = 12
		End Sub

		Private Sub GenerateData(ByVal chart As NChart)
			Dim series0 As NPointSeries = CType(chart.Series(0), NPointSeries)
			Dim series1 As NPointSeries = CType(chart.Series(1), NPointSeries)

			Const count As Integer = 12

			series0.Values.FillRandomRange(Random, count, 0, 50)
			series0.XValues.FillRandomRange(Random, count, 0, 50)
			series0.ZValues.FillRandomRange(Random, count, 0, 50)

			series1.Values.FillRandomRange(Random, count, 25, 75)
			series1.XValues.FillRandomRange(Random, count, 25, 75)
			series1.ZValues.FillRandomRange(Random, count, 25, 75)
		End Sub

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			GenerateData(nChartControl1.Charts(0))
			nChartControl1.Refresh()
		End Sub
		Private Sub EnableInitialPositioningCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableInitialPositioningCheck.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			RemoveOverlappedLabelsCheck.Enabled = EnableInitialPositioningCheck.Checked

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub RemoveOverlappedLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RemoveOverlappedLabelsCheck.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub EnableLabelAdjustmentCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableLabelAdjustmentCheck.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub EnableDataPointSafeguardCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableDataPointSafeguardCheck.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			SafeguardSizeNumericUpDown.Enabled = EnableDataPointSafeguardCheck.Checked

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series(0).LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheck.Checked
			chart.Series(1).LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheck.Checked

			nChartControl1.Refresh()
		End Sub
		Private Sub SafeguardSizeNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SafeguardSizeNumericUpDown.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim sizeValue As Single = CSng(SafeguardSizeNumericUpDown.Value)

'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed As New NSizeL(New NLength(sizeValue, NGraphicsUnit.Point), New NLength(sizeValue, NGraphicsUnit.Point))

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Series(0).LabelLayout.DataPointSafeguardSize = size_Renamed
			chart.Series(1).LabelLayout.DataPointSafeguardSize = size_Renamed

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace