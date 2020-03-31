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

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAutoLabelsPolarUC
		Inherits NExampleBaseUC

		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private label8 As Label
		Private WithEvents SafeguardSizeNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents EnableDataPointSafeguardCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents RemoveOverlappedLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableInitialPositioningCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableLabelAdjustmentCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label8 = New System.Windows.Forms.Label()
			Me.SafeguardSizeNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.EnableDataPointSafeguardCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.RemoveOverlappedLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableInitialPositioningCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableLabelAdjustmentCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.SafeguardSizeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(3, 9)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(175, 24)
			Me.GenerateDataButton.TabIndex = 4
			Me.GenerateDataButton.Text = "Generate Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(3, 186)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(175, 20)
			Me.label8.TabIndex = 22
			Me.label8.Text = "Safeguard Size (in points):"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' SafeguardSizeNumericUpDown
			' 
			Me.SafeguardSizeNumericUpDown.Location = New System.Drawing.Point(3, 209)
			Me.SafeguardSizeNumericUpDown.Name = "SafeguardSizeNumericUpDown"
			Me.SafeguardSizeNumericUpDown.Size = New System.Drawing.Size(175, 20)
			Me.SafeguardSizeNumericUpDown.TabIndex = 23
			Me.SafeguardSizeNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SafeguardSizeNumericUpDown.ValueChanged += new System.EventHandler(this.SafeguardSizeNumericUpDown_ValueChanged);
			' 
			' EnableDataPointSafeguardCheck
			' 
			Me.EnableDataPointSafeguardCheck.ButtonProperties.BorderOffset = 2
			Me.EnableDataPointSafeguardCheck.Location = New System.Drawing.Point(3, 152)
			Me.EnableDataPointSafeguardCheck.Name = "EnableDataPointSafeguardCheck"
			Me.EnableDataPointSafeguardCheck.Size = New System.Drawing.Size(169, 21)
			Me.EnableDataPointSafeguardCheck.TabIndex = 21
			Me.EnableDataPointSafeguardCheck.Text = "Enable Data Point Safeguard"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableDataPointSafeguardCheck.CheckedChanged += new System.EventHandler(this.EnableDataPointSafeguardCheck_CheckedChanged);
			' 
			' RemoveOverlappedLabelsCheck
			' 
			Me.RemoveOverlappedLabelsCheck.ButtonProperties.BorderOffset = 2
			Me.RemoveOverlappedLabelsCheck.ButtonProperties.WrapText = True
			Me.RemoveOverlappedLabelsCheck.Location = New System.Drawing.Point(3, 68)
			Me.RemoveOverlappedLabelsCheck.Name = "RemoveOverlappedLabelsCheck"
			Me.RemoveOverlappedLabelsCheck.Size = New System.Drawing.Size(169, 41)
			Me.RemoveOverlappedLabelsCheck.TabIndex = 20
			Me.RemoveOverlappedLabelsCheck.Text = "Remove Overlapped Labels After Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RemoveOverlappedLabelsCheck.CheckedChanged += new System.EventHandler(this.RemoveOverlappedLabelsCheck_CheckedChanged);
			' 
			' EnableInitialPositioningCheck
			' 
			Me.EnableInitialPositioningCheck.ButtonProperties.BorderOffset = 2
			Me.EnableInitialPositioningCheck.Location = New System.Drawing.Point(3, 47)
			Me.EnableInitialPositioningCheck.Name = "EnableInitialPositioningCheck"
			Me.EnableInitialPositioningCheck.Size = New System.Drawing.Size(169, 21)
			Me.EnableInitialPositioningCheck.TabIndex = 19
			Me.EnableInitialPositioningCheck.Text = "Enable Initial Positioning"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableInitialPositioningCheck.CheckedChanged += new System.EventHandler(this.EnableInitialPositioningCheck_CheckedChanged);
			' 
			' EnableLabelAdjustmentCheck
			' 
			Me.EnableLabelAdjustmentCheck.ButtonProperties.BorderOffset = 2
			Me.EnableLabelAdjustmentCheck.Location = New System.Drawing.Point(3, 115)
			Me.EnableLabelAdjustmentCheck.Name = "EnableLabelAdjustmentCheck"
			Me.EnableLabelAdjustmentCheck.Size = New System.Drawing.Size(169, 21)
			Me.EnableLabelAdjustmentCheck.TabIndex = 18
			Me.EnableLabelAdjustmentCheck.Text = "Enable Label Adjustment"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableLabelAdjustmentCheck.CheckedChanged += new System.EventHandler(this.EnableLabelAdjustmentCheck_CheckedChanged);
			' 
			' NAutoLabelsPolarUC
			' 
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.SafeguardSizeNumericUpDown)
			Me.Controls.Add(Me.EnableDataPointSafeguardCheck)
			Me.Controls.Add(Me.RemoveOverlappedLabelsCheck)
			Me.Controls.Add(Me.EnableInitialPositioningCheck)
			Me.Controls.Add(Me.EnableLabelAdjustmentCheck)
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Name = "NAutoLabelsPolarUC"
			Me.Size = New System.Drawing.Size(180, 284)
			DirectCast(Me.SafeguardSizeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Polar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As New NPolarChart()
			nChartControl1.Charts.Add(chart)

			chart.LabelLayout.EnableInitialPositioning = True
			chart.LabelLayout.EnableLabelAdjustment = True

			' setup polar value axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.Polar).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			' setup polar angle axis
			Dim angularScale As NAngularScaleConfigurator = CType(chart.Axis(StandardAxis.PolarAngle).ScaleConfigurator, NAngularScaleConfigurator)
			angularScale.MajorGridStyle.SetShowAtWall(ChartWallType.Polar, True)

			' polar point series
			Dim series1 As NPolarPointSeries = CType(chart.Series.Add(SeriesType.PolarPoint), NPolarPointSeries)
			series1.PointShape = PointShape.Ellipse
			series1.Size = New NLength(1.2F, NRelativeUnit.ParentPercentage)
			series1.InflateMargins = True
			series1.FillStyle = New NColorFillStyle(DarkOrange)

			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Center
			series1.DataLabelStyle.ArrowLength = New NLength(12)
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange

			series1.LabelLayout.EnableDataPointSafeguard = True
			series1.LabelLayout.DataPointSafeguardSize = New NSizeL(New NLength(1.3F, NRelativeUnit.ParentPercentage), New NLength(1.3F, NRelativeUnit.ParentPercentage))
			series1.LabelLayout.UseLabelLocations = True
			series1.LabelLayout.OutOfBoundsLocationMode = OutOfBoundsLocationMode.PushWithinBounds
			series1.LabelLayout.InvertLocationsIfIgnored = True

			' fill with random data
			GenerateData(series1)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' init form controls
			EnableLabelAdjustmentCheck.Checked = True
			RemoveOverlappedLabelsCheck.Checked = False
			EnableInitialPositioningCheck.Checked = True
			EnableDataPointSafeguardCheck.Checked = True
			SafeguardSizeNumericUpDown.Value = 12
		End Sub

		Private Sub GenerateData(ByVal series As NPolarPointSeries)
			series.Values.FillRandomRange(Random, 25, 0.0, 100.0)
			series.Angles.FillRandomRange(Random, 25, 0.0, 360.0)
		End Sub

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NPolarPointSeries = CType(chart.Series(0), NPolarPointSeries)

			GenerateData(series)

			nChartControl1.Refresh()
		End Sub
		Private Sub EnableInitialPositioningCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableInitialPositioningCheck.CheckedChanged
			RemoveOverlappedLabelsCheck.Enabled = EnableInitialPositioningCheck.Checked

			If nChartControl1 Is Nothing Then
				Return
			End If

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
		Private Sub EnableLabelAdjustmentCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableLabelAdjustmentCheck.CheckedChanged
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

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace