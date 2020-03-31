Imports System
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
	Public Class NBoundsModeStretchUC
		Inherits NExampleBaseUC

		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private BottomMarginLabel As System.Windows.Forms.Label
		Private RightMarginLabel As System.Windows.Forms.Label
		Private TopMarginLabel As System.Windows.Forms.Label
		Private LeftMarginLabel As System.Windows.Forms.Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents BottomMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents TopMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents RightMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LeftMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private components As System.ComponentModel.IContainer = Nothing

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
			Me.groupBox1.SuspendLayout()
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
			Me.groupBox1.Location = New System.Drawing.Point(7, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(156, 175)
			Me.groupBox1.TabIndex = 10
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
			' NBoundsModeStretchUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NBoundsModeStretchUC"
			Me.Size = New System.Drawing.Size(180, 225)
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' clear all panels
			nChartControl1.Panels.Clear()

			' setup chart
			Dim chart As NChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			chart.Padding = New NMarginsL(3, 7, 9, 0)
			chart.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(220, 220, 235))

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.InnerMajorTickStyle.Visible = False
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.InnerMajorTickStyle.Visible = False

			' add a line series
			Dim line1 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line1.DataLabelStyle.Visible = False
			line1.BorderStyle = New NStrokeStyle(2, Color.Peru)
			line1.FillStyle = New NColorFillStyle(Color.Peru)

			' add another line series
			Dim line2 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
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
			TopMarginScrollBar.Value = 10
			RightMarginScrollBar.Value = 90
			BottomMarginScrollBar.Value = 90
		End Sub

		Private Sub UpdateMargins()
			Dim nLeft As Integer = LeftMarginScrollBar.Value
			Dim nTop As Integer = TopMarginScrollBar.Value
			Dim nRight As Integer = RightMarginScrollBar.Value
			Dim nBottom As Integer = BottomMarginScrollBar.Value

			If nRight > 100 Then
				nRight = 100
			End If

			If nBottom > 100 Then
				nBottom = 100
			End If

			If nLeft > nRight Then
				nLeft = nRight
			End If

			If nTop > nBottom Then
				nTop = nBottom
			End If

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Location = New NPointL(New NLength(nLeft, NRelativeUnit.ParentPercentage), New NLength(nTop, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(nRight - nLeft, NRelativeUnit.ParentPercentage), New NLength(nBottom - nTop, NRelativeUnit.ParentPercentage))
			nChartControl1.Refresh()
		End Sub
		Private Sub UpdateMarginLabels()
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
	End Class
End Namespace
