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
Imports System.Text

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NThreeLineBreakUC
		Inherits NExampleBaseUC

		Private WithEvents UpStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DownStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents UpFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DownFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private WithEvents LinesToBreakNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BoxWidthPercentCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing
		Private textBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private label3 As Label
		Private m_ThreeLineBreak As NThreeLineBreakSeries

		Public Sub New()
			InitializeComponent()

			BoxWidthPercentCombo.Items.AddRange(New String(){ "50%", "75%", "100%" })
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
			Me.UpStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DownStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.UpFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DownFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.LinesToBreakNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.BoxWidthPercentCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.textBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label3 = New System.Windows.Forms.Label()
			DirectCast(Me.LinesToBreakNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' UpStrokeStyleButton
			' 
			Me.UpStrokeStyleButton.Location = New System.Drawing.Point(10, 10)
			Me.UpStrokeStyleButton.Name = "UpStrokeStyleButton"
			Me.UpStrokeStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.UpStrokeStyleButton.TabIndex = 0
			Me.UpStrokeStyleButton.Text = "Up Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UpStrokeStyleButton.Click += new System.EventHandler(this.UpStrokeStyleButton_Click);
			' 
			' DownStrokeStyleButton
			' 
			Me.DownStrokeStyleButton.Location = New System.Drawing.Point(10, 41)
			Me.DownStrokeStyleButton.Name = "DownStrokeStyleButton"
			Me.DownStrokeStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.DownStrokeStyleButton.TabIndex = 1
			Me.DownStrokeStyleButton.Text = "Down Border Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DownStrokeStyleButton.Click += new System.EventHandler(this.DownStrokeStyleButton_Click);
			' 
			' UpFillStyleButton
			' 
			Me.UpFillStyleButton.Location = New System.Drawing.Point(10, 73)
			Me.UpFillStyleButton.Name = "UpFillStyleButton"
			Me.UpFillStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.UpFillStyleButton.TabIndex = 2
			Me.UpFillStyleButton.Text = "Up Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UpFillStyleButton.Click += new System.EventHandler(this.UpFillStyleButton_Click);
			' 
			' DownFillStyleButton
			' 
			Me.DownFillStyleButton.Location = New System.Drawing.Point(10, 104)
			Me.DownFillStyleButton.Name = "DownFillStyleButton"
			Me.DownFillStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.DownFillStyleButton.TabIndex = 3
			Me.DownFillStyleButton.Text = "Down Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DownFillStyleButton.Click += new System.EventHandler(this.DownFillStyleButton_Click);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(10, 195)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(144, 15)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Number of Lines to Break:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' LinesToBreakNumericUpDown
			' 
			Me.LinesToBreakNumericUpDown.Location = New System.Drawing.Point(10, 213)
			Me.LinesToBreakNumericUpDown.Maximum = New Decimal(New Integer() { 4, 0, 0, 0})
			Me.LinesToBreakNumericUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.LinesToBreakNumericUpDown.Name = "LinesToBreakNumericUpDown"
			Me.LinesToBreakNumericUpDown.Size = New System.Drawing.Size(56, 20)
			Me.LinesToBreakNumericUpDown.TabIndex = 7
			Me.LinesToBreakNumericUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LinesToBreakNumericUpDown.ValueChanged += new System.EventHandler(this.LinesToBreakNumericUpDown_ValueChanged);
			' 
			' BoxWidthPercentCombo
			' 
			Me.BoxWidthPercentCombo.ListProperties.CheckBoxDataMember = ""
			Me.BoxWidthPercentCombo.ListProperties.DataSource = Nothing
			Me.BoxWidthPercentCombo.ListProperties.DisplayMember = ""
			Me.BoxWidthPercentCombo.Location = New System.Drawing.Point(10, 160)
			Me.BoxWidthPercentCombo.Name = "BoxWidthPercentCombo"
			Me.BoxWidthPercentCombo.Size = New System.Drawing.Size(151, 21)
			Me.BoxWidthPercentCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BoxWidthPercentCombo.SelectedIndexChanged += new System.EventHandler(this.BoxWidthPercentCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(10, 142)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(104, 16)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Box Width Percent:"
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(10, 257)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(154, 213)
			Me.textBox1.TabIndex = 9
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(10, 240)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(70, 13)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Current Data:"
			' 
			' NThreeLineBreakUC
			' 
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.BoxWidthPercentCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.LinesToBreakNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.DownFillStyleButton)
			Me.Controls.Add(Me.UpFillStyleButton)
			Me.Controls.Add(Me.DownStrokeStyleButton)
			Me.Controls.Add(Me.UpStrokeStyleButton)
			Me.Name = "NThreeLineBreakUC"
			Me.Size = New System.Drawing.Size(180, 536)
			DirectCast(Me.LinesToBreakNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' remove all legends
			nChartControl1.Legends.Clear()

			' set a chart title
			Dim title As New NLabel("Three Line Break")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			Dim chart As NChart = nChartControl1.Charts(0)

			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			scaleY.StripStyles.Add(stripStyle)

			' setup X axis
			Dim priceConfigurator As New NPriceScaleConfigurator()
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0)
			priceConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator

			' setup line break series
			m_ThreeLineBreak = CType(chart.Series.Add(SeriesType.ThreeLineBreak), NThreeLineBreakSeries)
			m_ThreeLineBreak.UseXValues = True

			GenerateData(m_ThreeLineBreak)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			BoxWidthPercentCombo.SelectedIndex = 2
			LinesToBreakNumericUpDown.Value = 3

			AddHandler nChartControl1.MouseMove, AddressOf nChartControl1_MouseMove
		End Sub

		Private Sub nChartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			If result.ChartElement = ChartElement.LineBreakData Then
				Dim lineBreakData As NLineBreakData = result.LineBreakData
				Dim builder As New StringBuilder()

				builder.AppendLine("HighY:" & lineBreakData.HighY.ToString())
				builder.AppendLine("LowY:" & lineBreakData.LowY.ToString())
				builder.AppendLine("Direction:" & lineBreakData.Direction.ToString())
				builder.AppendLine("DirectionChanged:" & lineBreakData.DirectionChanged.ToString())

				textBox1.Text = builder.ToString()
			Else
				textBox1.Text = String.Empty
			End If
		End Sub

		Private Sub GenerateData(ByVal threeLineBreak As NThreeLineBreakSeries)
			Dim dataGenerator As New NStockDataGenerator(New NRange1DD(50, 350), 0.002, 2)
			dataGenerator.Reset()

			Dim dt As New Date(2007, 1, 1)

			For i As Integer = 0 To 99
				threeLineBreak.Values.Add(dataGenerator.GetNextValue())
				threeLineBreak.XValues.Add(dt)

				dt = dt.AddDays(1)
			Next i
		End Sub

		Private Sub UpStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpStrokeStyleButton.Click
			If m_ThreeLineBreak IsNot Nothing Then
				Dim strokeStyleResult As NStrokeStyle = Nothing

				If NStrokeStyleTypeEditor.Edit(m_ThreeLineBreak.UpStrokeStyle, strokeStyleResult) Then
					m_ThreeLineBreak.UpStrokeStyle = strokeStyleResult
					nChartControl1.Refresh()
				End If
			End If
		End Sub

		Private Sub DownStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownStrokeStyleButton.Click
			If m_ThreeLineBreak IsNot Nothing Then
				Dim strokeStyleResult As NStrokeStyle = Nothing

				If NStrokeStyleTypeEditor.Edit(m_ThreeLineBreak.DownStrokeStyle, strokeStyleResult) Then
					m_ThreeLineBreak.DownStrokeStyle = strokeStyleResult
					nChartControl1.Refresh()
				End If
			End If
		End Sub

		Private Sub UpFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpFillStyleButton.Click
			If m_ThreeLineBreak IsNot Nothing Then
				Dim fillStyleResult As NFillStyle = Nothing

				If NFillStyleTypeEditor.Edit(m_ThreeLineBreak.UpFillStyle, fillStyleResult) Then
					m_ThreeLineBreak.UpFillStyle = fillStyleResult
					nChartControl1.Refresh()
				End If
			End If
		End Sub

		Private Sub DownFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownFillStyleButton.Click
			If m_ThreeLineBreak IsNot Nothing Then
				Dim fillStyleResult As NFillStyle = Nothing

				If NFillStyleTypeEditor.Edit(m_ThreeLineBreak.DownFillStyle, fillStyleResult) Then
					m_ThreeLineBreak.DownFillStyle = fillStyleResult
					nChartControl1.Refresh()
				End If
			End If
		End Sub

		Private Sub LinesToBreakNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinesToBreakNumericUpDown.ValueChanged
			If m_ThreeLineBreak IsNot Nothing Then
				m_ThreeLineBreak.NumberOfLinesToBreak = CInt(Math.Truncate(LinesToBreakNumericUpDown.Value))
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BoxWidthPercentCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BoxWidthPercentCombo.SelectedIndexChanged
			If m_ThreeLineBreak IsNot Nothing Then
				Select Case BoxWidthPercentCombo.SelectedIndex
					Case 0
						m_ThreeLineBreak.BoxWidthPercent = 50

					Case 1
						m_ThreeLineBreak.BoxWidthPercent = 75

					Case 2
						m_ThreeLineBreak.BoxWidthPercent = 100
				End Select

				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace