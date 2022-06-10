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
	<ToolboxItem(False)>
	Public Class NPointAndFigureUC
		Inherits NExampleBaseUC

		Private m_PointAndFigure As NPointAndFigureSeries
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents UpStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DownStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ProportionalXCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ProportionalYCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BoxSizeUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ReversalAmountUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private textBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private label3 As Label
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
			Me.UpStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DownStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ReversalAmountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ProportionalXCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ProportionalYCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.BoxSizeUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.textBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label3 = New System.Windows.Forms.Label()
			DirectCast(Me.ReversalAmountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.BoxSizeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' UpStrokeStyleButton
			' 
			Me.UpStrokeStyleButton.Location = New System.Drawing.Point(5, 10)
			Me.UpStrokeStyleButton.Name = "UpStrokeStyleButton"
			Me.UpStrokeStyleButton.Size = New System.Drawing.Size(169, 24)
			Me.UpStrokeStyleButton.TabIndex = 0
			Me.UpStrokeStyleButton.Text = "Up Stroke Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UpStrokeStyleButton.Click += new System.EventHandler(this.UpStrokeStyleButton_Click);
			' 
			' DownStrokeStyleButton
			' 
			Me.DownStrokeStyleButton.Location = New System.Drawing.Point(5, 41)
			Me.DownStrokeStyleButton.Name = "DownStrokeStyleButton"
			Me.DownStrokeStyleButton.Size = New System.Drawing.Size(169, 24)
			Me.DownStrokeStyleButton.TabIndex = 1
			Me.DownStrokeStyleButton.Text = "Down Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DownStrokeStyleButton.Click += new System.EventHandler(this.DownStrokeStyleButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 207)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(115, 23)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Reversal Amount:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ReversalAmountUpDown
			' 
			Me.ReversalAmountUpDown.Location = New System.Drawing.Point(8, 233)
			Me.ReversalAmountUpDown.Maximum = New Decimal(New Integer() { 5, 0, 0, 0})
			Me.ReversalAmountUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.ReversalAmountUpDown.Name = "ReversalAmountUpDown"
			Me.ReversalAmountUpDown.Size = New System.Drawing.Size(155, 20)
			Me.ReversalAmountUpDown.TabIndex = 7
			Me.ReversalAmountUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ReversalAmountUpDown.ValueChanged += new System.EventHandler(this.ReversalAmountUpDown_ValueChanged);
			' 
			' ProportionalXCheckBox
			' 
			Me.ProportionalXCheckBox.ButtonProperties.BorderOffset = 2
			Me.ProportionalXCheckBox.Location = New System.Drawing.Point(5, 84)
			Me.ProportionalXCheckBox.Name = "ProportionalXCheckBox"
			Me.ProportionalXCheckBox.Size = New System.Drawing.Size(165, 24)
			Me.ProportionalXCheckBox.TabIndex = 2
			Me.ProportionalXCheckBox.Text = "Proportional X"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ProportionalXCheckBox.CheckedChanged += new System.EventHandler(this.ProportionalXCheckBox_CheckedChanged);
			' 
			' ProportionalYCheckBox
			' 
			Me.ProportionalYCheckBox.ButtonProperties.BorderOffset = 2
			Me.ProportionalYCheckBox.Location = New System.Drawing.Point(5, 109)
			Me.ProportionalYCheckBox.Name = "ProportionalYCheckBox"
			Me.ProportionalYCheckBox.Size = New System.Drawing.Size(165, 24)
			Me.ProportionalYCheckBox.TabIndex = 3
			Me.ProportionalYCheckBox.Text = "Proportional Y"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ProportionalYCheckBox.CheckedChanged += new System.EventHandler(this.ProportionalYCheckBox_CheckedChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 146)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(119, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Box Size:"
			' 
			' BoxSizeUpDown
			' 
			Me.BoxSizeUpDown.DecimalPlaces = 2
			Me.BoxSizeUpDown.Increment = New Decimal(New Integer() { 5, 0, 0, 65536})
			Me.BoxSizeUpDown.Location = New System.Drawing.Point(8, 164)
			Me.BoxSizeUpDown.Maximum = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.BoxSizeUpDown.Minimum = New Decimal(New Integer() { 5, 0, 0, 65536})
			Me.BoxSizeUpDown.Name = "BoxSizeUpDown"
			Me.BoxSizeUpDown.Size = New System.Drawing.Size(154, 20)
			Me.BoxSizeUpDown.TabIndex = 5
			Me.BoxSizeUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BoxSizeUpDown.ValueChanged += new System.EventHandler(this.BoxSizeUpDown_ValueChanged);
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(8, 278)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(167, 213)
			Me.textBox1.TabIndex = 9
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(8, 261)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(70, 13)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Current Data:"
			' 
			' NPointAndFigureUC
			' 
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.BoxSizeUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.ProportionalYCheckBox)
			Me.Controls.Add(Me.ProportionalXCheckBox)
			Me.Controls.Add(Me.ReversalAmountUpDown)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.DownStrokeStyleButton)
			Me.Controls.Add(Me.UpStrokeStyleButton)
			Me.Name = "NPointAndFigureUC"
			Me.Size = New System.Drawing.Size(180, 515)
			DirectCast(Me.ReversalAmountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.BoxSizeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' remove all legends
			nChartControl1.Legends.Clear()

			' set a chart title
			Dim title As New NLabel("Point and Figure")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			Const nInitialBoxSize As Integer = 5

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim priceConfigurator As New NPriceScaleConfigurator()
			priceConfigurator.LabelValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			priceConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount
			priceConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back }
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0)
			priceConfigurator.MaxTickCount = 8

			Dim provider As New NNumericRangeSamplerProvider()
			provider.SamplingMode = SamplingMode.CustomStep
			provider.CustomStep = 1
			provider.UseOrigin = True
			provider.Origin = -0.5
			priceConfigurator.MajorGridStyle.RangeSamplerProvider = provider

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorTickMode = MajorTickMode.CustomStep
			scaleY.CustomStep = nInitialBoxSize
			scaleY.OuterMajorTickStyle.Width = New NLength(0)
			scaleY.InnerMajorTickStyle.Width = New NLength(0)
			scaleY.AutoMinorTicks = True
			scaleY.MinorTickCount = 1
			scaleY.RoundToTickMin = False
			scaleY.RoundToTickMax = False
			scaleY.MajorGridStyle.LineStyle.Width = New NLength(0)
			scaleY.MinorGridStyle.LineStyle.Width = New NLength(1)
			scaleY.MinorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }

			Dim highValues() As Single = { 21.3F, 42.4F, 11.2F, 65.7F, 38.0F, 71.3F, 49.54F, 83.7F, 13.9F, 56.12F, 27.43F, 23.1F, 31.0F, 75.4F, 9.3F, 39.12F, 10.0F, 44.23F, 21.76F, 49.2F }
			Dim lowValues() As Single = { 12.1F, 14.32F, 8.43F, 36.0F, 13.5F, 47.34F, 24.54F, 68.11F, 6.87F, 23.3F, 12.12F, 14.54F, 25.0F, 37.2F, 3.9F, 23.11F, 1.9F, 14.0F, 8.23F, 34.21F }

			' setup Point & Figure series
			m_PointAndFigure = CType(chart.Series.Add(SeriesType.PointAndFigure), NPointAndFigureSeries)
			m_PointAndFigure.UseXValues = True

			' fill data
			m_PointAndFigure.HighValues.AddRange(highValues)
			m_PointAndFigure.LowValues.AddRange(lowValues)

			Dim dt As New Date(2007, 1, 1)

			For i As Integer = 0 To 19
				m_PointAndFigure.XValues.Add(dt)
				dt = dt.AddDays(1)
			Next i

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			BoxSizeUpDown.Value = nInitialBoxSize
			ReversalAmountUpDown.Value = 3

			AddHandler nChartControl1.MouseMove, AddressOf nChartControl1_MouseMove
		End Sub

		Private Sub nChartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			If result.ChartElement = ChartElement.PointAndFigureData Then
				Dim pointAndFigureData As NPointAndFigureData = result.PointAndFigureData

				Dim builder As New StringBuilder()

				builder.AppendLine("DataIndex:" & pointAndFigureData.DataIndex.ToString())
				builder.AppendLine("ColumnIndex:" & pointAndFigureData.ColumnIndex.ToString())
				builder.AppendLine("ColumnDirection:" & pointAndFigureData.ColumnDirection.ToString())
				builder.AppendLine("HiValueIndex:" & pointAndFigureData.HiValueIndex.ToString())
				builder.AppendLine("LowValueIndexv:" & pointAndFigureData.LowValueIndex.ToString())

				textBox1.Text = builder.ToString()
			Else
				textBox1.Text = String.Empty
			End If
		End Sub

		Private Sub UpStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpStrokeStyleButton.Click
			If m_PointAndFigure IsNot Nothing Then
				Dim strokeStyleResult As NStrokeStyle = Nothing

				If NStrokeStyleTypeEditor.Edit(m_PointAndFigure.UpStrokeStyle, strokeStyleResult) Then
					m_PointAndFigure.UpStrokeStyle = strokeStyleResult
					nChartControl1.Refresh()
				End If
			End If
		End Sub

		Private Sub DownStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownStrokeStyleButton.Click
			If m_PointAndFigure IsNot Nothing Then
				Dim strokeStyleResult As NStrokeStyle = Nothing

				If NStrokeStyleTypeEditor.Edit(m_PointAndFigure.DownStrokeStyle, strokeStyleResult) Then
					m_PointAndFigure.DownStrokeStyle = strokeStyleResult
					nChartControl1.Refresh()
				End If
			End If
		End Sub

		Private Sub ProportionalXCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProportionalXCheckBox.CheckedChanged
			If m_PointAndFigure IsNot Nothing Then
				m_PointAndFigure.ProportionalX = ProportionalXCheckBox.Checked
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ProportionalYCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProportionalYCheckBox.CheckedChanged
			If m_PointAndFigure IsNot Nothing Then
				m_PointAndFigure.ProportionalY = ProportionalYCheckBox.Checked
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ReversalAmountUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReversalAmountUpDown.ValueChanged
			If m_PointAndFigure IsNot Nothing Then
				m_PointAndFigure.ReversalAmount = CInt(Math.Truncate(ReversalAmountUpDown.Value))
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BoxSizeUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BoxSizeUpDown.ValueChanged
			If m_PointAndFigure IsNot Nothing Then
				Dim dBoxSize As Double = CDbl(BoxSizeUpDown.Value)

				Dim chart As NChart = nChartControl1.Charts(0)
				m_PointAndFigure.BoxSize = dBoxSize

				Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
				scaleY.CustomStep = dBoxSize

				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace