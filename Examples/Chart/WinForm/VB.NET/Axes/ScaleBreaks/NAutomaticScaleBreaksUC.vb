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
	Public Class NAutomaticScaleBreaksUC
		Inherits NExampleBaseUC

		Private WithEvents PositionModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label6 As Label
		Private WithEvents LengthUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label7 As Label
		Private WithEvents ThresholdUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents EnableScaleBreaksCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As Label
		Private label2 As Label
		Private WithEvents MaxBreaksUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private WithEvents PositionPercentUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ChangeDataButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.PositionModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.LengthUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ThresholdUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.EnableScaleBreaksCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.MaxBreaksUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.PositionPercentUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.LengthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ThresholdUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.MaxBreaksUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.PositionPercentUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' PositionModeComboBox
			' 
			Me.PositionModeComboBox.Location = New System.Drawing.Point(15, 162)
			Me.PositionModeComboBox.Name = "PositionModeComboBox"
			Me.PositionModeComboBox.Size = New System.Drawing.Size(169, 21)
			Me.PositionModeComboBox.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositionModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PositionModeComboBox_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(15, 89)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(43, 13)
			Me.label6.TabIndex = 3
			Me.label6.Text = "Length:"
			' 
			' LengthUpDown
			' 
			Me.LengthUpDown.Location = New System.Drawing.Point(118, 82)
			Me.LengthUpDown.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
			Me.LengthUpDown.Name = "LengthUpDown"
			Me.LengthUpDown.Size = New System.Drawing.Size(66, 20)
			Me.LengthUpDown.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LengthUpDown.ValueChanged += new System.EventHandler(this.LengthUpDown_ValueChanged);
			' 
			' ThresholdUpDown
			' 
			Me.ThresholdUpDown.Cursor = System.Windows.Forms.Cursors.Default
			Me.ThresholdUpDown.DecimalPlaces = 2
			Me.ThresholdUpDown.Increment = New Decimal(New Integer() { 5, 0, 0, 131072})
			Me.ThresholdUpDown.Location = New System.Drawing.Point(118, 57)
			Me.ThresholdUpDown.Maximum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.ThresholdUpDown.Name = "ThresholdUpDown"
			Me.ThresholdUpDown.Size = New System.Drawing.Size(66, 20)
			Me.ThresholdUpDown.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThresholdUpDown.ValueChanged += new System.EventHandler(this.ThresholdUpDown_ValueChanged);
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(15, 64)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(57, 13)
			Me.label7.TabIndex = 1
			Me.label7.Text = "Threshold:"
			' 
			' EnableScaleBreaksCheckBox
			' 
			Me.EnableScaleBreaksCheckBox.AutoSize = True
			Me.EnableScaleBreaksCheckBox.Location = New System.Drawing.Point(15, 26)
			Me.EnableScaleBreaksCheckBox.Name = "EnableScaleBreaksCheckBox"
			Me.EnableScaleBreaksCheckBox.Size = New System.Drawing.Size(175, 17)
			Me.EnableScaleBreaksCheckBox.TabIndex = 0
			Me.EnableScaleBreaksCheckBox.Text = "Enable Automatic Scale Breaks"
			Me.EnableScaleBreaksCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableScaleBreaksCheckBox.CheckedChanged += new System.EventHandler(this.EnableScaleBreaksCheckBox_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(15, 143)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(77, 13)
			Me.label1.TabIndex = 7
			Me.label1.Text = "Position Mode:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(15, 114)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(66, 13)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Max Breaks:"
			' 
			' MaxBreaksUpDown
			' 
			Me.MaxBreaksUpDown.Location = New System.Drawing.Point(118, 107)
			Me.MaxBreaksUpDown.Maximum = New Decimal(New Integer() { 3, 0, 0, 0})
			Me.MaxBreaksUpDown.Name = "MaxBreaksUpDown"
			Me.MaxBreaksUpDown.Size = New System.Drawing.Size(66, 20)
			Me.MaxBreaksUpDown.TabIndex = 6
			Me.MaxBreaksUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaxBreaksUpDown.ValueChanged += new System.EventHandler(this.MaxBreaksUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(15, 195)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(86, 13)
			Me.label3.TabIndex = 9
			Me.label3.Text = "Position percent:"
			' 
			' PositionPercentUpDown
			' 
			Me.PositionPercentUpDown.Location = New System.Drawing.Point(118, 188)
			Me.PositionPercentUpDown.Maximum = New Decimal(New Integer() { 95, 0, 0, 0})
			Me.PositionPercentUpDown.Minimum = New Decimal(New Integer() { 5, 0, 0, 0})
			Me.PositionPercentUpDown.Name = "PositionPercentUpDown"
			Me.PositionPercentUpDown.Size = New System.Drawing.Size(66, 20)
			Me.PositionPercentUpDown.TabIndex = 10
			Me.PositionPercentUpDown.Value = New Decimal(New Integer() { 5, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositionPercentUpDown.ValueChanged += new System.EventHandler(this.PositionPercentUpDown_ValueChanged);
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(18, 266)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(166, 23)
			Me.ChangeDataButton.TabIndex = 11
			Me.ChangeDataButton.Text = "Change Data"
			Me.ChangeDataButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' NAutomaticScaleBreaksUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Controls.Add(Me.PositionPercentUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.MaxBreaksUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.PositionModeComboBox)
			Me.Controls.Add(Me.EnableScaleBreaksCheckBox)
			Me.Controls.Add(Me.LengthUpDown)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.ThresholdUpDown)
			Me.Controls.Add(Me.label7)
			Me.Name = "NAutomaticScaleBreaksUC"
			Me.Size = New System.Drawing.Size(203, 732)
			DirectCast(Me.LengthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ThresholdUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.MaxBreaksUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.PositionPercentUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Automatic Scale Breaks<br/> <font size = '9pt'>Demonstrates how to apply automatic scale breaks to the chart axes</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Mode = LegendMode.Disabled

			Dim chart As NChart = nChartControl1.Charts(0)

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

			' update form controls
			EnableScaleBreaksCheckBox.Checked = True
			LengthUpDown.Value = 5
			ThresholdUpDown.Value = CDec(0.25) ' this is relatively low factor
			MaxBreaksUpDown.Value = CDec(1)
			PositionPercentUpDown.Value = CDec(50)

			PositionModeComboBox.Items.Add("Range")
			PositionModeComboBox.Items.Add("Percent")
			PositionModeComboBox.Items.Add("Content")
			PositionModeComboBox.SelectedIndex = 2 ' use content mode by default

			' feed some random data
			ChangeDataButton_Click(Nothing, Nothing)
		End Sub

		Private Sub UpdateScaleBreak()
			If nChartControl1 Is Nothing Then
				Return
			End If

			Dim chart As NChart = nChartControl1.Charts(0)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NStandardScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scale_Renamed.ScaleBreaks.Clear()

			If EnableScaleBreaksCheckBox.Checked Then
				Dim scaleBreak As New NAutoScaleBreak(CSng(ThresholdUpDown.Value))
				scaleBreak.Style = New NLineScaleBreakStyle()
				scaleBreak.Style.Length = New NLength(CSng(LengthUpDown.Value), NGraphicsUnit.Point)
				scaleBreak.MaxScaleBreakCount = CInt(Math.Truncate(MaxBreaksUpDown.Value))

				Dim scaleBreakPosition As NScaleBreakPosition = New NRangeScaleBreakPosition()
				Select Case PositionModeComboBox.SelectedIndex
					Case 0 ' Range
						scaleBreakPosition = New NRangeScaleBreakPosition()
					Case 1 ' percent
						scaleBreakPosition = New NPercentScaleBreakPosition(CSng(PositionPercentUpDown.Value))
					Case 2 ' content
						scaleBreakPosition = New NContentScaleBreakPosition()
				End Select

				scaleBreak.Position = scaleBreakPosition
				scale_Renamed.ScaleBreaks.Add(scaleBreak)
			End If

			nChartControl1.Refresh()
		End Sub


		Private Sub EnableScaleBreaksCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableScaleBreaksCheckBox.CheckedChanged
			UpdateScaleBreak()

			Dim enableControls As Boolean = EnableScaleBreaksCheckBox.Checked
			ThresholdUpDown.Enabled = enableControls
			LengthUpDown.Enabled = enableControls
			MaxBreaksUpDown.Enabled = enableControls
			PositionModeComboBox.Enabled = enableControls
			PositionPercentUpDown.Enabled = enableControls AndAlso PositionModeComboBox.SelectedIndex = 1
		End Sub

		Private Sub ThresholdUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ThresholdUpDown.ValueChanged
			UpdateScaleBreak()
		End Sub

		Private Sub LengthUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LengthUpDown.ValueChanged
			UpdateScaleBreak()
		End Sub

		Private Sub MaxBreaksUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MaxBreaksUpDown.ValueChanged
			UpdateScaleBreak()
		End Sub

		Private Sub PositionModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PositionModeComboBox.SelectedIndexChanged
			UpdateScaleBreak()

			PositionPercentUpDown.Enabled = PositionModeComboBox.SelectedIndex = 1
		End Sub

		Private Sub PositionPercentUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PositionPercentUpDown.ValueChanged
			UpdateScaleBreak()
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ChangeDataButton.Click
			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Series.Clear()

			' setup bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.DataLabelStyle.Visible = False
			bar.BorderStyle.Width = New NLength(1.5F)
			bar.BorderStyle.Color = Color.DarkGreen

			' fill in some data so that it contains several peaks of data
'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As New Random()
			Dim value As Double = 0

			For i As Integer = 0 To 24
				If i < 6 Then
					value = 600 + random_Renamed.Next(30)
				ElseIf i < 11 Then
					value = 200 + random_Renamed.Next(50)
				ElseIf i < 16 Then
					value = 400 + random_Renamed.Next(50)
				ElseIf i < 21 Then
					value = random_Renamed.Next(30)
				Else
					value = random_Renamed.Next(50)
				End If

				bar.Values.Add(value)
				bar.FillStyles(i) = New NGradientFillStyle(ColorFromValue(value), Color.DarkSlateBlue)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Function ColorFromValue(ByVal value As Double) As Color
			Dim beginColor As Color = Color.LightBlue
			Dim endColor As Color = Color.DarkSlateBlue

			Dim factor As Single = CSng(value / 650.0F)
			Dim oneMinusFactor As Single = 1.0F - factor

			Return Color.FromArgb(CByte(CSng(beginColor.R) * factor + CSng(endColor.R) * oneMinusFactor), CByte(CSng(beginColor.G) * factor + CSng(endColor.G) * oneMinusFactor), CByte(CSng(beginColor.B) * factor + CSng(endColor.B) * oneMinusFactor))
		End Function
	End Class
End Namespace

