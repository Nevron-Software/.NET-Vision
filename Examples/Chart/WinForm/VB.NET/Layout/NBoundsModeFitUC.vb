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
	Public Class NBoundsModeFitUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private LeftMarginLabel As System.Windows.Forms.Label
		Private TopMarginLabel As System.Windows.Forms.Label
		Private RightMarginLabel As System.Windows.Forms.Label
		Private BottomMarginLabel As System.Windows.Forms.Label
		Private WithEvents LeftMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents TopMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents RightMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents BottomMarginScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
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
			Me.LeftMarginScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.TopMarginScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.RightMarginScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.BottomMarginScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomMarginLabel = New System.Windows.Forms.Label()
			Me.RightMarginLabel = New System.Windows.Forms.Label()
			Me.TopMarginLabel = New System.Windows.Forms.Label()
			Me.LeftMarginLabel = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' LeftMarginScrollBar
			' 
			Me.LeftMarginScrollBar.Location = New System.Drawing.Point(7, 37)
			Me.LeftMarginScrollBar.Maximum = 110
			Me.LeftMarginScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.LeftMarginScrollBar.Name = "LeftMarginScrollBar"
			Me.LeftMarginScrollBar.Size = New System.Drawing.Size(100, 16)
			Me.LeftMarginScrollBar.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.LeftMarginScrollBar_Scroll);
			' 
			' TopMarginScrollBar
			' 
			Me.TopMarginScrollBar.Location = New System.Drawing.Point(7, 86)
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
			Me.RightMarginScrollBar.Location = New System.Drawing.Point(7, 135)
			Me.RightMarginScrollBar.Maximum = 110
			Me.RightMarginScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.RightMarginScrollBar.Name = "RightMarginScrollBar"
			Me.RightMarginScrollBar.Size = New System.Drawing.Size(100, 16)
			Me.RightMarginScrollBar.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RightMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.RightMarginScrollBar_Scroll);
			' 
			' BottomMarginScrollBar
			' 
			Me.BottomMarginScrollBar.Location = New System.Drawing.Point(7, 184)
			Me.BottomMarginScrollBar.Maximum = 110
			Me.BottomMarginScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.BottomMarginScrollBar.Name = "BottomMarginScrollBar"
			Me.BottomMarginScrollBar.Size = New System.Drawing.Size(100, 16)
			Me.BottomMarginScrollBar.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomMarginScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.BottomMarginScrollBar_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 21)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(146, 16)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Left:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 70)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(146, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Top:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 119)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(146, 16)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Right:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(7, 168)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(146, 16)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Bottom:"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.BottomMarginLabel)
			Me.groupBox1.Controls.Add(Me.RightMarginLabel)
			Me.groupBox1.Controls.Add(Me.TopMarginLabel)
			Me.groupBox1.Controls.Add(Me.BottomMarginScrollBar)
			Me.groupBox1.Controls.Add(Me.TopMarginScrollBar)
			Me.groupBox1.Controls.Add(Me.RightMarginScrollBar)
			Me.groupBox1.Controls.Add(Me.LeftMarginScrollBar)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.LeftMarginLabel)
			Me.groupBox1.Location = New System.Drawing.Point(7, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(165, 214)
			Me.groupBox1.TabIndex = 9
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Margins"
			' 
			' BottomMarginLabel
			' 
			Me.BottomMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.BottomMarginLabel.Location = New System.Drawing.Point(115, 184)
			Me.BottomMarginLabel.Name = "BottomMarginLabel"
			Me.BottomMarginLabel.Size = New System.Drawing.Size(42, 16)
			Me.BottomMarginLabel.TabIndex = 12
			' 
			' RightMarginLabel
			' 
			Me.RightMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.RightMarginLabel.Location = New System.Drawing.Point(115, 135)
			Me.RightMarginLabel.Name = "RightMarginLabel"
			Me.RightMarginLabel.Size = New System.Drawing.Size(42, 16)
			Me.RightMarginLabel.TabIndex = 11
			' 
			' TopMarginLabel
			' 
			Me.TopMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.TopMarginLabel.Location = New System.Drawing.Point(115, 86)
			Me.TopMarginLabel.Name = "TopMarginLabel"
			Me.TopMarginLabel.Size = New System.Drawing.Size(42, 16)
			Me.TopMarginLabel.TabIndex = 10
			' 
			' LeftMarginLabel
			' 
			Me.LeftMarginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.LeftMarginLabel.Location = New System.Drawing.Point(115, 37)
			Me.LeftMarginLabel.Name = "LeftMarginLabel"
			Me.LeftMarginLabel.Size = New System.Drawing.Size(42, 16)
			Me.LeftMarginLabel.TabIndex = 9
			' 
			' NBoundsModeFitUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NBoundsModeFitUC"
			Me.Size = New System.Drawing.Size(180, 244)
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' clear all panels
			nChartControl1.Panels.Clear()

			' create a new chart
			Dim chart As NChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			chart.Padding = New NMarginsL(3, 7, 3, 0)
			chart.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(220, 220, 235))
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.InnerMajorTickStyle.Visible = False
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.InnerMajorTickStyle.Visible = False

			' add a line series
			Dim line As New NLineSeries()
			chart.Series.Add(line)
			line.MarkerStyle.Visible = True
			line.MarkerStyle.Width = New NLength(1.1F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.1F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.BorderStyle = New NStrokeStyle(2, Color.Peru)
			line.MarkerStyle.FillStyle = New NColorFillStyle(Color.Gold)
			line.BorderStyle = New NStrokeStyle(2, Color.Peru)
			line.DataLabelStyle.Visible = False
			line.ShadowStyle.Type = ShadowType.GaussianBlur
			line.ShadowStyle.Offset = New NPointL(2, 2)
			line.ShadowStyle.Color = Color.FromArgb(120, 0, 0, 0)
			line.ShadowStyle.FadeLength = New NLength(5)
			line.Values.FillRandomRange(Random, 10, 5, 10)

			' add a bar series
			Dim bar As New NBarSeries()
			chart.Series.Add(bar)
			bar.DataLabelStyle.Visible = False
			bar.BorderStyle.Width = New NLength(0)
			bar.FillStyle = New NColorFillStyle(Color.DarkKhaki)
			bar.Values.FillRandomRange(Random, 10, 1, 7)

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
