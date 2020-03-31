﻿Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStackedChartsUC
		Inherits NExampleBaseUC

		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents BottomMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents TopMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents RightMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LeftMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents GapPercentUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private BottomMarginLabel As System.Windows.Forms.Label
		Private RightMarginLabel As System.Windows.Forms.Label
		Private TopMarginLabel As System.Windows.Forms.Label
		Private LeftMarginLabel As System.Windows.Forms.Label
		Private label1 As Label
		Private components As System.ComponentModel.IContainer

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
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomMarginLabel = New System.Windows.Forms.Label()
			Me.RightMarginLabel = New System.Windows.Forms.Label()
			Me.TopMarginLabel = New System.Windows.Forms.Label()
			Me.LeftMarginLabel = New System.Windows.Forms.Label()
			Me.BottomMarginScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.TopMarginScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.RightMarginScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.LeftMarginScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.GapPercentUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.GapPercentUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.BottomMarginLabel)
			Me.groupBox1.Controls.Add(Me.RightMarginLabel)
			Me.groupBox1.Controls.Add(Me.TopMarginLabel)
			Me.groupBox1.Controls.Add(Me.LeftMarginLabel)
			Me.groupBox1.Controls.Add(Me.BottomMarginScrollBar)
			Me.groupBox1.Controls.Add(Me.TopMarginScrollBar)
			Me.groupBox1.Controls.Add(Me.RightMarginScrollBar)
			Me.groupBox1.Controls.Add(Me.LeftMarginScrollBar)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(7, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(156, 175)
			Me.groupBox1.TabIndex = 22
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Margins"
			' 
			' BottomMarginLabel
			' 
			Me.BottomMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.BottomMarginLabel.Location = New System.Drawing.Point(116, 148)
			Me.BottomMarginLabel.Name = "BottomMarginLabel"
			Me.BottomMarginLabel.Size = New System.Drawing.Size(32, 16)
			Me.BottomMarginLabel.TabIndex = 12
			' 
			' RightMarginLabel
			' 
			Me.RightMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.RightMarginLabel.Location = New System.Drawing.Point(116, 110)
			Me.RightMarginLabel.Name = "RightMarginLabel"
			Me.RightMarginLabel.Size = New System.Drawing.Size(32, 16)
			Me.RightMarginLabel.TabIndex = 11
			' 
			' TopMarginLabel
			' 
			Me.TopMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.TopMarginLabel.Location = New System.Drawing.Point(116, 72)
			Me.TopMarginLabel.Name = "TopMarginLabel"
			Me.TopMarginLabel.Size = New System.Drawing.Size(32, 16)
			Me.TopMarginLabel.TabIndex = 10
			' 
			' LeftMarginLabel
			' 
			Me.LeftMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.LeftMarginLabel.Location = New System.Drawing.Point(116, 34)
			Me.LeftMarginLabel.Name = "LeftMarginLabel"
			Me.LeftMarginLabel.Size = New System.Drawing.Size(32, 16)
			Me.LeftMarginLabel.TabIndex = 9
			' 
			' BottomMarginScrollBar
			' 
			Me.BottomMarginScrollBar.Location = New System.Drawing.Point(8, 148)
			Me.BottomMarginScrollBar.Maximum = 110
			Me.BottomMarginScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomMarginScrollBar.Name = "BottomMarginScrollBar"
			Me.BottomMarginScrollBar.Size = New System.Drawing.Size(100, 16)
			Me.BottomMarginScrollBar.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomMarginScrollBar_Scroll);
			' 
			' TopMarginScrollBar
			' 
			Me.TopMarginScrollBar.Location = New System.Drawing.Point(8, 72)
			Me.TopMarginScrollBar.Maximum = 110
			Me.TopMarginScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.TopMarginScrollBar.Name = "TopMarginScrollBar"
			Me.TopMarginScrollBar.Size = New System.Drawing.Size(100, 16)
			Me.TopMarginScrollBar.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TopMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TopMarginScrollBar_Scroll);
			' 
			' RightMarginScrollBar
			' 
			Me.RightMarginScrollBar.Location = New System.Drawing.Point(8, 110)
			Me.RightMarginScrollBar.Maximum = 110
			Me.RightMarginScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.RightMarginScrollBar.Name = "RightMarginScrollBar"
			Me.RightMarginScrollBar.Size = New System.Drawing.Size(100, 16)
			Me.RightMarginScrollBar.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RightMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.RightMarginScrollBar_Scroll);
			' 
			' LeftMarginScrollBar
			' 
			Me.LeftMarginScrollBar.Location = New System.Drawing.Point(8, 34)
			Me.LeftMarginScrollBar.Maximum = 110
			Me.LeftMarginScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftMarginScrollBar.Name = "LeftMarginScrollBar"
			Me.LeftMarginScrollBar.Size = New System.Drawing.Size(100, 16)
			Me.LeftMarginScrollBar.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftMarginScrollBar_Scroll);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 132)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(47, 16)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Bottom:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 94)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(47, 16)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Right:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(47, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Top:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 19)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(47, 16)
			Me.label5.TabIndex = 5
			Me.label5.Text = "Left:"
			' 
			' GapPercentUpDown
			' 
			Me.GapPercentUpDown.Location = New System.Drawing.Point(15, 242)
			Me.GapPercentUpDown.Name = "GapPercentUpDown"
			Me.GapPercentUpDown.Size = New System.Drawing.Size(63, 20)
			Me.GapPercentUpDown.TabIndex = 16
			Me.GapPercentUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GapPercentUpDown.ValueChanged += new System.EventHandler(this.GapPercentUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(15, 221)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(38, 13)
			Me.label1.TabIndex = 23
			Me.label1.Text = "Gap %"
			' 
			' NStackedChartsUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.GapPercentUpDown)
			Me.Name = "NStackedChartsUC"
			Me.Size = New System.Drawing.Size(180, 283)
			Me.groupBox1.ResumeLayout(False)
			DirectCast(Me.GapPercentUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' setup chart 1
			Dim chart1 As NChart = New NCartesianChart()
			nChartControl1.Charts.Add(chart1)
			chart1.BoundsMode = BoundsMode.Stretch
			chart1.Wall(ChartWallType.Back).FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.FromArgb(220, 220, 235))

			' setup X axis
			Dim axisX As NAxis = chart1.Axis(StandardAxis.PrimaryX)
			Dim scaleX As New NLinearScaleConfigurator()
			scaleX.InnerMajorTickStyle.Visible = False
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			axisX.ScaleConfigurator = scaleX
			CType(axisX.Anchor, NDockAxisAnchor).AxisDockZone = AxisDockZone.FrontTop

			' setup Y axis
			chart1.Axis(StandardAxis.PrimaryY).ScaleConfigurator.InnerMajorTickStyle.Visible = False

			' add a line series
			Dim line1 As New NLineSeries()
			chart1.Series.Add(line1)
			line1.DataLabelStyle.Visible = False
			line1.BorderStyle = New NStrokeStyle(2, Color.Peru)
			line1.FillStyle = New NColorFillStyle(Color.Peru)

			' setup chart 2
			Dim chart2 As NChart = New NCartesianChart()
			nChartControl1.Charts.Add(chart2)
			chart2.BoundsMode = BoundsMode.Stretch
			chart2.Wall(ChartWallType.Back).FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.FromArgb(220, 220, 235))

			' setup X axis
			scaleX = New NLinearScaleConfigurator()
			scaleX.InnerMajorTickStyle.Visible = False
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			chart2.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Y axis
			chart2.Axis(StandardAxis.PrimaryY).ScaleConfigurator.InnerMajorTickStyle.Visible = False

			' add a line series
			Dim line2 As New NLineSeries()
			chart2.Series.Add(line2)
			line2.DataLabelStyle.Visible = False
			line2.BorderStyle = New NStrokeStyle(2, Color.Olive)
			line2.FillStyle = New NColorFillStyle(Color.Olive)

			' fill some data
			For i As Integer = 0 To 99
				line1.Values.Add(Math.Sin(i * 0.05) * (Random.NextDouble() + 1.0))
				line2.Values.Add(Math.Cos(i * 0.1) * (Random.NextDouble() + 1.0))
			Next i

			' init form controls
			LeftMarginScrollBar.Value = 10
			TopMarginScrollBar.Value = 12
			RightMarginScrollBar.Value = 90
			BottomMarginScrollBar.Value = 88
		End Sub

		Private Sub UpdateMargins()
			If nChartControl1 Is Nothing Then
				Return
			End If

'INSTANT VB NOTE: The variable left was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim left_Renamed As Single = LeftMarginScrollBar.Value
'INSTANT VB NOTE: The variable top was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim top_Renamed As Single = TopMarginScrollBar.Value
'INSTANT VB NOTE: The variable right was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim right_Renamed As Single = RightMarginScrollBar.Value
'INSTANT VB NOTE: The variable bottom was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim bottom_Renamed As Single = BottomMarginScrollBar.Value
			Dim gapPercent As Single = CInt(Math.Truncate(GapPercentUpDown.Value))

			If right_Renamed > 100.0F Then
				right_Renamed = 100.0F
			End If

			If bottom_Renamed > 100.0F Then
				bottom_Renamed = 100.0F
			End If

			If left_Renamed > right_Renamed Then
				right_Renamed = left_Renamed
			End If

			Dim panelHeight As Single = (bottom_Renamed - top_Renamed - gapPercent) * 0.5F

			If panelHeight < 0.0F Then
				panelHeight = 0.0F
			End If

			Dim chart1 As NChart = nChartControl1.Charts(0)
			chart1.Location = New NPointL(New NLength(left_Renamed, NRelativeUnit.ParentPercentage), New NLength(top_Renamed, NRelativeUnit.ParentPercentage))
			chart1.Size = New NSizeL(New NLength(right_Renamed - left_Renamed, NRelativeUnit.ParentPercentage), New NLength(panelHeight, NRelativeUnit.ParentPercentage))

			Dim chart2 As NChart = nChartControl1.Charts(1)
			chart2.Location = New NPointL(New NLength(left_Renamed, NRelativeUnit.ParentPercentage), New NLength(top_Renamed + panelHeight + gapPercent, NRelativeUnit.ParentPercentage))
			chart2.Size = New NSizeL(New NLength(right_Renamed - left_Renamed, NRelativeUnit.ParentPercentage), New NLength(panelHeight, NRelativeUnit.ParentPercentage))

			nChartControl1.Refresh()
		End Sub
		Private Sub UpdateMarginLabels()
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim nLeft As Integer = LeftMarginScrollBar.Value
			Dim nTop As Integer = TopMarginScrollBar.Value
			Dim nRight As Integer = RightMarginScrollBar.Value
			Dim nBottom As Integer = BottomMarginScrollBar.Value

			LeftMarginLabel.Text = System.Convert.ToString(nLeft) & "%"
			TopMarginLabel.Text = System.Convert.ToString(nTop) & "%"
			RightMarginLabel.Text = System.Convert.ToString(nRight) & "%"
			BottomMarginLabel.Text = System.Convert.ToString(nBottom) & "%"
		End Sub

		Private Sub LeftMarginScrollBar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles LeftMarginScrollBar.ValueChanged
			UpdateMargins()
			UpdateMarginLabels()
		End Sub
		Private Sub TopMarginScrollBar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles TopMarginScrollBar.ValueChanged
			UpdateMargins()
			UpdateMarginLabels()
		End Sub
		Private Sub RightMarginScrollBar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles RightMarginScrollBar.ValueChanged
			UpdateMargins()
			UpdateMarginLabels()
		End Sub
		Private Sub BottomMarginScrollBar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles BottomMarginScrollBar.ValueChanged
			UpdateMargins()
			UpdateMarginLabels()
		End Sub
		Private Sub GapPercentUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GapPercentUpDown.ValueChanged
			UpdateMargins()
			UpdateMarginLabels()
		End Sub
	End Class
End Namespace