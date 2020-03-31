Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomScaleBreaksUC
		Inherits NExampleBaseUC

		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label2 As Label
		Private label1 As Label
		Private WithEvents FirstHorzBreakEndUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents FirstHorzBreakBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label3 As Label
		Private label4 As Label
		Private WithEvents SecondHorzBreakEndUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents SecondHorzBreakBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label5 As Label
		Private label6 As Label
		Private WithEvents FirstVertBreakEndUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents FirstVertBreakBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private groupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label7 As Label
		Private label8 As Label
		Private WithEvents SecondVertBreakEndUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents SecondVertBreakBeginUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown

		Private m_FirstHorzScaleBreak As NCustomScaleBreak
		Private m_SecondHorzScaleBreak As NCustomScaleBreak
		Private m_FirstVertScaleBreak As NCustomScaleBreak
		Private m_SecondVertScaleBreak As NCustomScaleBreak

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

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
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.FirstHorzBreakEndUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.FirstHorzBreakBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SecondHorzBreakEndUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.SecondHorzBreakBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.FirstVertBreakEndUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.FirstVertBreakBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.groupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.SecondVertBreakEndUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.SecondVertBreakBeginUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.FirstHorzBreakEndUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.FirstHorzBreakBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.SecondHorzBreakEndUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.SecondHorzBreakBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox3.SuspendLayout()
			DirectCast(Me.FirstVertBreakEndUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.FirstVertBreakBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox4.SuspendLayout()
			DirectCast(Me.SecondVertBreakEndUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.SecondVertBreakBeginUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.FirstHorzBreakEndUpDown)
			Me.groupBox1.Controls.Add(Me.FirstHorzBreakBeginUpDown)
			Me.groupBox1.Location = New System.Drawing.Point(10, 2)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(171, 84)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "First Horizontal Scale Break"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(17, 59)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(29, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "End:"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(17, 32)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(37, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Begin:"
			' 
			' FirstHorzBreakEndUpDown
			' 
			Me.FirstHorzBreakEndUpDown.Location = New System.Drawing.Point(74, 52)
			Me.FirstHorzBreakEndUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.FirstHorzBreakEndUpDown.Minimum = New Decimal(New Integer() { 200, 0, 0, -2147483648})
			Me.FirstHorzBreakEndUpDown.Name = "FirstHorzBreakEndUpDown"
			Me.FirstHorzBreakEndUpDown.Size = New System.Drawing.Size(90, 20)
			Me.FirstHorzBreakEndUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstHorzBreakEndUpDown.ValueChanged += new System.EventHandler(this.FirstHorzBreakEndUpDown_ValueChanged);
			' 
			' FirstHorzBreakBeginUpDown
			' 
			Me.FirstHorzBreakBeginUpDown.Location = New System.Drawing.Point(74, 25)
			Me.FirstHorzBreakBeginUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.FirstHorzBreakBeginUpDown.Minimum = New Decimal(New Integer() { 200, 0, 0, -2147483648})
			Me.FirstHorzBreakBeginUpDown.Name = "FirstHorzBreakBeginUpDown"
			Me.FirstHorzBreakBeginUpDown.Size = New System.Drawing.Size(90, 20)
			Me.FirstHorzBreakBeginUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstHorzBreakBeginUpDown.ValueChanged += new System.EventHandler(this.FirstHorzBreakBeginUpDown_ValueChanged);
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.label3)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Controls.Add(Me.SecondHorzBreakEndUpDown)
			Me.groupBox2.Controls.Add(Me.SecondHorzBreakBeginUpDown)
			Me.groupBox2.Location = New System.Drawing.Point(10, 86)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(171, 84)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Second Horizontal Scale Break"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(17, 62)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(29, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "End:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(17, 35)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(37, 13)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Begin:"
			' 
			' SecondHorzBreakEndUpDown
			' 
			Me.SecondHorzBreakEndUpDown.Location = New System.Drawing.Point(74, 55)
			Me.SecondHorzBreakEndUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.SecondHorzBreakEndUpDown.Minimum = New Decimal(New Integer() { 200, 0, 0, -2147483648})
			Me.SecondHorzBreakEndUpDown.Name = "SecondHorzBreakEndUpDown"
			Me.SecondHorzBreakEndUpDown.Size = New System.Drawing.Size(90, 20)
			Me.SecondHorzBreakEndUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondHorzBreakEndUpDown.ValueChanged += new System.EventHandler(this.SecondHorzBreakEndUpDown_ValueChanged);
			' 
			' SecondHorzBreakBeginUpDown
			' 
			Me.SecondHorzBreakBeginUpDown.Location = New System.Drawing.Point(74, 28)
			Me.SecondHorzBreakBeginUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.SecondHorzBreakBeginUpDown.Minimum = New Decimal(New Integer() { 200, 0, 0, -2147483648})
			Me.SecondHorzBreakBeginUpDown.Name = "SecondHorzBreakBeginUpDown"
			Me.SecondHorzBreakBeginUpDown.Size = New System.Drawing.Size(90, 20)
			Me.SecondHorzBreakBeginUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondHorzBreakBeginUpDown.ValueChanged += new System.EventHandler(this.SecondHorzBreakBeginUpDown_ValueChanged);
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.label5)
			Me.groupBox3.Controls.Add(Me.label6)
			Me.groupBox3.Controls.Add(Me.FirstVertBreakEndUpDown)
			Me.groupBox3.Controls.Add(Me.FirstVertBreakBeginUpDown)
			Me.groupBox3.Location = New System.Drawing.Point(10, 170)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(171, 84)
			Me.groupBox3.TabIndex = 2
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "First Vertical Scale Break"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(17, 62)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(29, 13)
			Me.label5.TabIndex = 2
			Me.label5.Text = "End:"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(17, 35)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(37, 13)
			Me.label6.TabIndex = 0
			Me.label6.Text = "Begin:"
			' 
			' FirstVertBreakEndUpDown
			' 
			Me.FirstVertBreakEndUpDown.Location = New System.Drawing.Point(74, 55)
			Me.FirstVertBreakEndUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.FirstVertBreakEndUpDown.Minimum = New Decimal(New Integer() { 200, 0, 0, -2147483648})
			Me.FirstVertBreakEndUpDown.Name = "FirstVertBreakEndUpDown"
			Me.FirstVertBreakEndUpDown.Size = New System.Drawing.Size(90, 20)
			Me.FirstVertBreakEndUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstVertBreakEndUpDown.ValueChanged += new System.EventHandler(this.FirstVertBreakEndUpDown_ValueChanged);
			' 
			' FirstVertBreakBeginUpDown
			' 
			Me.FirstVertBreakBeginUpDown.Location = New System.Drawing.Point(74, 28)
			Me.FirstVertBreakBeginUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.FirstVertBreakBeginUpDown.Minimum = New Decimal(New Integer() { 200, 0, 0, -2147483648})
			Me.FirstVertBreakBeginUpDown.Name = "FirstVertBreakBeginUpDown"
			Me.FirstVertBreakBeginUpDown.Size = New System.Drawing.Size(90, 20)
			Me.FirstVertBreakBeginUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FirstVertBreakBeginUpDown.ValueChanged += new System.EventHandler(this.FirstVertBreakBeginUpDown_ValueChanged);
			' 
			' groupBox4
			' 
			Me.groupBox4.Controls.Add(Me.label7)
			Me.groupBox4.Controls.Add(Me.label8)
			Me.groupBox4.Controls.Add(Me.SecondVertBreakEndUpDown)
			Me.groupBox4.Controls.Add(Me.SecondVertBreakBeginUpDown)
			Me.groupBox4.Location = New System.Drawing.Point(10, 254)
			Me.groupBox4.Name = "groupBox4"
			Me.groupBox4.Size = New System.Drawing.Size(171, 84)
			Me.groupBox4.TabIndex = 3
			Me.groupBox4.TabStop = False
			Me.groupBox4.Text = "Second Vertical Scale Break"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(17, 60)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(29, 13)
			Me.label7.TabIndex = 2
			Me.label7.Text = "End:"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(17, 33)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(37, 13)
			Me.label8.TabIndex = 0
			Me.label8.Text = "Begin:"
			' 
			' SecondVertBreakEndUpDown
			' 
			Me.SecondVertBreakEndUpDown.Location = New System.Drawing.Point(74, 53)
			Me.SecondVertBreakEndUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.SecondVertBreakEndUpDown.Minimum = New Decimal(New Integer() { 200, 0, 0, -2147483648})
			Me.SecondVertBreakEndUpDown.Name = "SecondVertBreakEndUpDown"
			Me.SecondVertBreakEndUpDown.Size = New System.Drawing.Size(90, 20)
			Me.SecondVertBreakEndUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondVertBreakEndUpDown.ValueChanged += new System.EventHandler(this.SecondVertBreakEndUpDown_ValueChanged);
			' 
			' SecondVertBreakBeginUpDown
			' 
			Me.SecondVertBreakBeginUpDown.Location = New System.Drawing.Point(74, 26)
			Me.SecondVertBreakBeginUpDown.Maximum = New Decimal(New Integer() { 200, 0, 0, 0})
			Me.SecondVertBreakBeginUpDown.Minimum = New Decimal(New Integer() { 200, 0, 0, -2147483648})
			Me.SecondVertBreakBeginUpDown.Name = "SecondVertBreakBeginUpDown"
			Me.SecondVertBreakBeginUpDown.Size = New System.Drawing.Size(90, 20)
			Me.SecondVertBreakBeginUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondVertBreakBeginUpDown.ValueChanged += new System.EventHandler(this.SecondVertBreakBeginUpDown_ValueChanged);
			' 
			' NCustomScaleBreaksUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.groupBox4)
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NCustomScaleBreaksUC"
			Me.Size = New System.Drawing.Size(193, 483)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			DirectCast(Me.FirstHorzBreakEndUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.FirstHorzBreakBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			DirectCast(Me.SecondHorzBreakEndUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.SecondHorzBreakBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox3.PerformLayout()
			DirectCast(Me.FirstVertBreakEndUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.FirstVertBreakBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox4.ResumeLayout(False)
			Me.groupBox4.PerformLayout()
			DirectCast(Me.SecondVertBreakEndUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.SecondVertBreakBeginUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Custom Scale Breaks<br/> <font size = '9pt'>Demonstrates how to apply custom scale breaks to the chart axes</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Mode = LegendMode.Disabled

			Dim chart As NChart = nChartControl1.Charts(0)
'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As New Random()

			' create three random point series
			For i As Integer = 0 To 2
				Dim point As New NPointSeries()
				point.UseXValues = True
				point.UseZValues = True
				point.DataLabelStyle.Visible = False
				point.Size = New NLength(5)
				point.BorderStyle.Width = New NLength(0)

				' fill in some random data
				For j As Integer = 0 To 29
					point.Values.Add(5 + random_Renamed.Next(90))
					point.XValues.Add(5 + random_Renamed.Next(90))
					point.ZValues.Add(5 + random_Renamed.Next(90))
				Next j

				chart.Series.Add(point)
			Next i

			' create scale breaks
			m_FirstHorzScaleBreak = New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Orange)), Nothing, New NLength(10)), New NRange1DD(10, 20))
			m_SecondHorzScaleBreak = New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Green)), Nothing, New NLength(10)), New NRange1DD(80, 90))
			m_FirstVertScaleBreak = New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Red)), Nothing, New NLength(10)), New NRange1DD(10, 20))
			m_SecondVertScaleBreak = New NCustomScaleBreak(New NLineScaleBreakStyle(New NColorFillStyle(Color.FromArgb(124, Color.Blue)), Nothing, New NLength(10)), New NRange1DD(80, 90))

			' initalize form controls
			FirstHorzBreakBeginUpDown.Value = CDec(10)
			FirstHorzBreakEndUpDown.Value = CDec(20)

			SecondHorzBreakBeginUpDown.Value = CDec(80)
			SecondHorzBreakEndUpDown.Value = CDec(90)

			FirstVertBreakBeginUpDown.Value = CDec(10)
			FirstVertBreakEndUpDown.Value = CDec(20)

			SecondVertBreakBeginUpDown.Value = CDec(80)
			SecondVertBreakEndUpDown.Value = CDec(90)

			' configure scales
			Dim xScale As New NLinearScaleConfigurator()
			xScale.RoundToTickMax = True
			xScale.RoundToTickMin = True
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			xScale.ScaleBreaks.Add(m_FirstHorzScaleBreak)
			xScale.ScaleBreaks.Add(m_SecondHorzScaleBreak)

			' add an interlaced strip to the X axis
			Dim xInterlacedStrip As New NScaleStripStyle()
			xInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			xInterlacedStrip.Interlaced = True
			xInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			xScale.StripStyles.Add(xInterlacedStrip)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale
			chart.Axis(StandardAxis.PrimaryX).View = New NRangeAxisView(New NRange1DD(0, 100))

			Dim yScale As New NLinearScaleConfigurator()
			yScale.RoundToTickMax = True
			yScale.RoundToTickMin = True
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScale.ScaleBreaks.Add(m_FirstVertScaleBreak)
			yScale.ScaleBreaks.Add(m_SecondVertScaleBreak)

			' add an interlaced strip to the Y axis
			Dim yInterlacedStrip As New NScaleStripStyle()
			yInterlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			yInterlacedStrip.Interlaced = True
			yInterlacedStrip.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.LightGray))
			yScale.StripStyles.Add(yInterlacedStrip)
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(0, 100))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Function CreateScaleBreakStyle(ByVal color As Color) As NScaleBreakStyle
			Dim style As New NWaveScaleBreakStyle()
			style.VertStep = New NLength(20)
			style.FillStyle = New NColorFillStyle(color)
			Return style
		End Function

		Private Sub UpdateScaleBreaks()
			m_FirstHorzScaleBreak.Range = New NRange1DD(CDbl(FirstHorzBreakBeginUpDown.Value), CDbl(FirstHorzBreakEndUpDown.Value))
			m_SecondHorzScaleBreak.Range = New NRange1DD(CDbl(SecondHorzBreakBeginUpDown.Value), CDbl(SecondHorzBreakEndUpDown.Value))
			m_FirstVertScaleBreak.Range = New NRange1DD(CDbl(FirstVertBreakBeginUpDown.Value), CDbl(FirstVertBreakEndUpDown.Value))
			m_SecondVertScaleBreak.Range = New NRange1DD(CDbl(SecondVertBreakBeginUpDown.Value), CDbl(SecondVertBreakEndUpDown.Value))

			nChartControl1.Refresh()
		End Sub

		Private Sub FirstHorzBreakBeginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstHorzBreakBeginUpDown.ValueChanged
			UpdateScaleBreaks()
		End Sub

		Private Sub FirstHorzBreakEndUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstHorzBreakEndUpDown.ValueChanged
			UpdateScaleBreaks()
		End Sub

		Private Sub SecondHorzBreakBeginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SecondHorzBreakBeginUpDown.ValueChanged
			UpdateScaleBreaks()
		End Sub

		Private Sub SecondHorzBreakEndUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SecondHorzBreakEndUpDown.ValueChanged
			UpdateScaleBreaks()
		End Sub

		Private Sub FirstVertBreakBeginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstVertBreakBeginUpDown.ValueChanged
			UpdateScaleBreaks()
		End Sub

		Private Sub FirstVertBreakEndUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FirstVertBreakEndUpDown.ValueChanged
			UpdateScaleBreaks()
		End Sub

		Private Sub SecondVertBreakBeginUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SecondVertBreakBeginUpDown.ValueChanged
			UpdateScaleBreaks()
		End Sub

		Private Sub SecondVertBreakEndUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SecondVertBreakEndUpDown.ValueChanged
			UpdateScaleBreaks()
		End Sub
	End Class
End Namespace
