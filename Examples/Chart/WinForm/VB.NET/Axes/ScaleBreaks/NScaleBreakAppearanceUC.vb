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
	Public Class NScaleBreakAppearanceUC
		Inherits NExampleBaseUC

		Public Sub New()
			InitializeComponent()
		End Sub

		Private label1 As Label
		Private WithEvents ScaleBreakStyleComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As Label
		Private label3 As Label
		Private WithEvents HorzStepNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents VertStepNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents StrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PatternComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As Label
		Private WithEvents FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LengthUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label5 As Label
		Private label6 As Label
		Private label7 As Label
		Private label8 As Label

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
			Me.label1 = New System.Windows.Forms.Label()
			Me.ScaleBreakStyleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.HorzStepNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.VertStepNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.StrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PatternComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.LengthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			DirectCast(Me.HorzStepNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.VertStepNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.LengthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 19)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(33, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Style:"
			' 
			' ScaleBreakStyleComboBox
			' 
			Me.ScaleBreakStyleComboBox.Location = New System.Drawing.Point(15, 35)
			Me.ScaleBreakStyleComboBox.Name = "ScaleBreakStyleComboBox"
			Me.ScaleBreakStyleComboBox.Size = New System.Drawing.Size(156, 21)
			Me.ScaleBreakStyleComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ScaleBreakStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.ScaleBreakStyleComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(15, 127)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(57, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Horz Step:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(15, 154)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(54, 13)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Vert Step:"
			' 
			' HorzStepNumericUpDown
			' 
			Me.HorzStepNumericUpDown.Location = New System.Drawing.Point(78, 120)
			Me.HorzStepNumericUpDown.Maximum = New Decimal(New Integer() { 50, 0, 0, 0})
			Me.HorzStepNumericUpDown.Name = "HorzStepNumericUpDown"
			Me.HorzStepNumericUpDown.Size = New System.Drawing.Size(68, 20)
			Me.HorzStepNumericUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorzStepNumericUpDown.ValueChanged += new System.EventHandler(this.HorzStepNumericUpDown_ValueChanged);
			' 
			' VertStepNumericUpDown
			' 
			Me.VertStepNumericUpDown.Location = New System.Drawing.Point(78, 147)
			Me.VertStepNumericUpDown.Maximum = New Decimal(New Integer() { 50, 0, 0, 0})
			Me.VertStepNumericUpDown.Name = "VertStepNumericUpDown"
			Me.VertStepNumericUpDown.Size = New System.Drawing.Size(68, 20)
			Me.VertStepNumericUpDown.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VertStepNumericUpDown.ValueChanged += new System.EventHandler(this.VertStepNumericUpDown_ValueChanged);
			' 
			' StrokeStyleButton
			' 
			Me.StrokeStyleButton.Location = New System.Drawing.Point(18, 214)
			Me.StrokeStyleButton.Name = "StrokeStyleButton"
			Me.StrokeStyleButton.Size = New System.Drawing.Size(156, 23)
			Me.StrokeStyleButton.TabIndex = 13
			Me.StrokeStyleButton.Text = "Stroke Style..."
			Me.StrokeStyleButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StrokeStyleButton.Click += new System.EventHandler(this.StrokeStyleButton_Click);
			' 
			' PatternComboBox
			' 
			Me.PatternComboBox.Location = New System.Drawing.Point(15, 91)
			Me.PatternComboBox.Name = "PatternComboBox"
			Me.PatternComboBox.Size = New System.Drawing.Size(156, 21)
			Me.PatternComboBox.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PatternComboBox.SelectedIndexChanged += new System.EventHandler(this.PatternComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(15, 72)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(44, 13)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Pattern:"
			' 
			' FillStyleButton
			' 
			Me.FillStyleButton.Location = New System.Drawing.Point(18, 243)
			Me.FillStyleButton.Name = "FillStyleButton"
			Me.FillStyleButton.Size = New System.Drawing.Size(156, 23)
			Me.FillStyleButton.TabIndex = 14
			Me.FillStyleButton.Text = "Fill Style..."
			Me.FillStyleButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FillStyleButton.Click += new System.EventHandler(this.FillStyleButton_Click);
			' 
			' LengthUpDown
			' 
			Me.LengthUpDown.Location = New System.Drawing.Point(78, 173)
			Me.LengthUpDown.Maximum = New Decimal(New Integer() { 50, 0, 0, 0})
			Me.LengthUpDown.Name = "LengthUpDown"
			Me.LengthUpDown.Size = New System.Drawing.Size(68, 20)
			Me.LengthUpDown.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LengthUpDown.ValueChanged += new System.EventHandler(this.LengthUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(15, 180)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(43, 13)
			Me.label5.TabIndex = 10
			Me.label5.Text = "Length:"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(152, 127)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(16, 13)
			Me.label6.TabIndex = 6
			Me.label6.Text = "pt"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(152, 154)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(16, 13)
			Me.label7.TabIndex = 9
			Me.label7.Text = "pt"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(152, 180)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(16, 13)
			Me.label8.TabIndex = 12
			Me.label8.Text = "pt"
			' 
			' NScaleBreakAppearanceUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.LengthUpDown)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.FillStyleButton)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.PatternComboBox)
			Me.Controls.Add(Me.StrokeStyleButton)
			Me.Controls.Add(Me.VertStepNumericUpDown)
			Me.Controls.Add(Me.HorzStepNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.ScaleBreakStyleComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NScaleBreakAppearanceUC"
			Me.Size = New System.Drawing.Size(186, 325)
			DirectCast(Me.HorzStepNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.VertStepNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.LengthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Scale Break Appearance<br/> <font size = '9pt'>Demonstrates how to change the scale break appearance</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Mode = LegendMode.Disabled

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Wall(ChartWallType.Back).FillStyle = New NGradientFillStyle(Color.White, Color.DarkGray)

			' configure scale
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = True
			linearScale.RoundToTickMin = True
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MinTickDistance = New NLength(15)

			' add an interlaced strip to the Y axis
			Dim interlacedStrip As New NScaleStripStyle()
			interlacedStrip.SetShowAtWall(ChartWallType.Back, True)
			interlacedStrip.Interlaced = True
			interlacedStrip.FillStyle = New NColorFillStyle(Color.Beige)
			linearScale.StripStyles.Add(interlacedStrip)

			' Create some data with a peak in it
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.DataLabelStyle.Visible = False

			' fill in some data so that it contains several peaks of data
'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As New Random()
			For i As Integer = 0 To 7
				bar.Values.Add(random_Renamed.Next(30))
			Next i

			For i As Integer = 0 To 4
				bar.Values.Add(300 + random_Renamed.Next(50))
			Next i

			For i As Integer = 0 To 7
				bar.Values.Add(random_Renamed.Next(30))
			Next i

			nChartControl1.Refresh()

			' update form controls
			PatternComboBox.FillFromEnum(GetType(ScaleBreakPattern))
			PatternComboBox.SelectedIndex = 0

			ScaleBreakStyleComboBox.Items.Add("Line")
			ScaleBreakStyleComboBox.Items.Add("Wave")
			ScaleBreakStyleComboBox.Items.Add("ZigZag")
			ScaleBreakStyleComboBox.SelectedIndex = 1 ' use wave by default

			HorzStepNumericUpDown.Value = 20
			VertStepNumericUpDown.Value = 3
			LengthUpDown.Value = 10
		End Sub

		Private Sub UpdateScaleBreak()
			Dim chart As NChart = nChartControl1.Charts(0)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim oldScaleBreakStyle As NScaleBreakStyle = Nothing
			If scale_Renamed.ScaleBreaks.Count > 0 Then
				oldScaleBreakStyle = DirectCast(scale_Renamed.ScaleBreaks(0), NScaleBreak).Style
			End If
			scale_Renamed.ScaleBreaks.Clear()

			Dim newScaleBreakStyle As NScaleBreakStyle = Nothing

			Select Case ScaleBreakStyleComboBox.SelectedIndex
				Case 0 ' Line
					newScaleBreakStyle = New NLineScaleBreakStyle()
				Case 1 ' Waves
					newScaleBreakStyle = New NWaveScaleBreakStyle()
				Case 2 ' ZigZag
					newScaleBreakStyle = New NZigZagScaleBreakStyle()
			End Select

			' try to preserve fill and stroke settings
			If newScaleBreakStyle IsNot Nothing Then
				If oldScaleBreakStyle IsNot Nothing Then
					newScaleBreakStyle.InitFrom(oldScaleBreakStyle)
				Else
					newScaleBreakStyle.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.LightGray, Color.White)
				End If

				' update the length of the scale break
				newScaleBreakStyle.Length = New NLength(CSng(LengthUpDown.Value), NGraphicsUnit.Point)

				' update paramers relevant to pattern scale break appearance
				Dim patternScaleBreakStyle As NPatternScaleBreakStyle = TryCast(newScaleBreakStyle, NPatternScaleBreakStyle)
				Dim enablePatternControls As Boolean = patternScaleBreakStyle IsNot Nothing
				If patternScaleBreakStyle IsNot Nothing Then
					patternScaleBreakStyle.HorzStep = New NLength(CSng(HorzStepNumericUpDown.Value))
					patternScaleBreakStyle.VertStep = New NLength(CSng(VertStepNumericUpDown.Value))
					patternScaleBreakStyle.Pattern = CType(PatternComboBox.SelectedIndex, ScaleBreakPattern)
				End If

				HorzStepNumericUpDown.Enabled = enablePatternControls
				VertStepNumericUpDown.Enabled = enablePatternControls
				PatternComboBox.Enabled = enablePatternControls

				scale_Renamed.ScaleBreaks.Add(New NAutoScaleBreak(newScaleBreakStyle, 0.4F))
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub ScaleBreakStyleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ScaleBreakStyleComboBox.SelectedIndexChanged
			UpdateScaleBreak()
		End Sub

		Private Sub HorzStepNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HorzStepNumericUpDown.ValueChanged
			UpdateScaleBreak()
		End Sub

		Private Sub VertStepNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles VertStepNumericUpDown.ValueChanged
			UpdateScaleBreak()
		End Sub

		Private Sub PatternComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PatternComboBox.SelectedIndexChanged
			UpdateScaleBreak()
		End Sub

		Private Sub LengthUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LengthUpDown.ValueChanged
			UpdateScaleBreak()
		End Sub

		Private Sub StrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StrokeStyleButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim scaleBreak As NScaleBreak = DirectCast(scale_Renamed.ScaleBreaks(0), NScaleBreak)

			Dim result As NStrokeStyle = Nothing
			If NStrokeStyleTypeEditor.Edit(scaleBreak.Style.StrokeStyle, result) Then
				scaleBreak.Style.StrokeStyle = result
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub FillStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FillStyleButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim scaleBreak As NScaleBreak = DirectCast(scale_Renamed.ScaleBreaks(0), NScaleBreak)

			Dim result As NFillStyle = Nothing
			If NFillStyleTypeEditor.Edit(scaleBreak.Style.FillStyle, result) Then
				scaleBreak.Style.FillStyle = result
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
