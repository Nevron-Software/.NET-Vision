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
	<ToolboxItem(False)>
	Public Class NBubbleLegendScaleUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
		Private WithEvents BubbleScaleModeCombo As UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private WithEvents BubbleScaleStepsUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label2 As Label
		Private WithEvents TextOffsetNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label3 As Label
		Private WithEvents TableCellOffsetNumericUpDown As UI.WinForm.Controls.NNumericUpDown
		Private label4 As Label
		Private WithEvents RoundValuesCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents StrokeStyleButton As UI.WinForm.Controls.NButton
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
			Me.BubbleScaleModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.BubbleScaleStepsUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.TextOffsetNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.TableCellOffsetNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.RoundValuesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.StrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			DirectCast(Me.BubbleScaleStepsUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TextOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.TableCellOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' BubbleScaleModeCombo
			' 
			Me.BubbleScaleModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BubbleScaleModeCombo.ListProperties.DataSource = Nothing
			Me.BubbleScaleModeCombo.ListProperties.DisplayMember = ""
			Me.BubbleScaleModeCombo.Location = New System.Drawing.Point(10, 20)
			Me.BubbleScaleModeCombo.Name = "BubbleScaleModeCombo"
			Me.BubbleScaleModeCombo.Size = New System.Drawing.Size(150, 21)
			Me.BubbleScaleModeCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleScaleModeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleScaleModeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(10, 3)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(150, 16)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Bubble Scale Mode:"
			' 
			' BubbleScaleStepsUpDown
			' 
			Me.BubbleScaleStepsUpDown.Location = New System.Drawing.Point(10, 193)
			Me.BubbleScaleStepsUpDown.Maximum = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.BubbleScaleStepsUpDown.Minimum = New Decimal(New Integer() { 2, 0, 0, 0})
			Me.BubbleScaleStepsUpDown.Name = "BubbleScaleStepsUpDown"
			Me.BubbleScaleStepsUpDown.Size = New System.Drawing.Size(150, 20)
			Me.BubbleScaleStepsUpDown.TabIndex = 5
			Me.BubbleScaleStepsUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleScaleStepsUpDown.ValueChanged += new System.EventHandler(this.BubbleScaleStepsUpDown_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(10, 175)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(150, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Bubble Scale Steps:"
			' 
			' TextOffsetNumericUpDown
			' 
			Me.TextOffsetNumericUpDown.Location = New System.Drawing.Point(10, 76)
			Me.TextOffsetNumericUpDown.Name = "TextOffsetNumericUpDown"
			Me.TextOffsetNumericUpDown.Size = New System.Drawing.Size(150, 20)
			Me.TextOffsetNumericUpDown.TabIndex = 7
			Me.TextOffsetNumericUpDown.Value = New Decimal(New Integer() { 70, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TextOffsetNumericUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(10, 58)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(147, 16)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Text Offset:"
			' 
			' TableCellOffsetNumericUpDown
			' 
			Me.TableCellOffsetNumericUpDown.Location = New System.Drawing.Point(12, 131)
			Me.TableCellOffsetNumericUpDown.Name = "TableCellOffsetNumericUpDown"
			Me.TableCellOffsetNumericUpDown.Size = New System.Drawing.Size(150, 20)
			Me.TableCellOffsetNumericUpDown.TabIndex = 9
			Me.TableCellOffsetNumericUpDown.Value = New Decimal(New Integer() { 70, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TableCellOffsetNumericUpDown.ValueChanged += new System.EventHandler(this.TableCellOffsetNumericUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(12, 113)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(147, 16)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Table Cell Offset:"
			' 
			' RoundValuesCheckBox
			' 
			Me.RoundValuesCheckBox.ButtonProperties.BorderOffset = 2
			Me.RoundValuesCheckBox.Location = New System.Drawing.Point(10, 219)
			Me.RoundValuesCheckBox.Name = "RoundValuesCheckBox"
			Me.RoundValuesCheckBox.Size = New System.Drawing.Size(150, 21)
			Me.RoundValuesCheckBox.TabIndex = 38
			Me.RoundValuesCheckBox.Text = "Round Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RoundValuesCheckBox.CheckedChanged += new System.EventHandler(this.RoundValuesCheckBox_CheckedChanged);
			' 
			' StrokeStyleButton
			' 
			Me.StrokeStyleButton.Location = New System.Drawing.Point(10, 322)
			Me.StrokeStyleButton.Name = "StrokeStyleButton"
			Me.StrokeStyleButton.Size = New System.Drawing.Size(154, 24)
			Me.StrokeStyleButton.TabIndex = 39
			Me.StrokeStyleButton.Text = "Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StrokeStyleButton.Click += new System.EventHandler(this.StrokeStyleButton_Click);
			' 
			' NBubbleScaleUC
			' 
			Me.Controls.Add(Me.StrokeStyleButton)
			Me.Controls.Add(Me.RoundValuesCheckBox)
			Me.Controls.Add(Me.TableCellOffsetNumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.TextOffsetNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.BubbleScaleStepsUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.BubbleScaleModeCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NBubbleScaleUC"
			Me.Size = New System.Drawing.Size(180, 389)
			DirectCast(Me.BubbleScaleStepsUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TextOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.TableCellOffsetNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bubble Scale")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' add a bubble series
			m_Bubble = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			m_Bubble.DataLabelStyle.VertAlign = VertAlign.Center
			m_Bubble.DataLabelStyle.Visible = False
			m_Bubble.MinSize = New NLength(7.0F, NRelativeUnit.ParentPercentage)
			m_Bubble.MaxSize = New NLength(16.0F, NRelativeUnit.ParentPercentage)

			For i As Integer = 0 To 9
				m_Bubble.Values.Add(i)
				m_Bubble.Sizes.Add(i * 10 + 10)
			Next i
			m_Bubble.InflateMargins = True

			Dim palette As New NPalette()
			palette.SmoothPalette = True
			palette.Clear()
			palette.Add(0, Color.Green)
			palette.Add(60, Color.Yellow)
			palette.Add(120, Color.Red)

			m_Bubble.Palette = palette

			nChartControl1.Legends(0).Header.Text = "Bubble Size"

			m_Bubble.Legend.Mode = SeriesLegendMode.SeriesLogic
			m_Bubble.BubbleSizeScale.TextOffset = New NLength(0)
			m_Bubble.BubbleSizeScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			m_Bubble.BubbleSizeScale.Mode = BubbleSizeScaleMode.ConcentricDown

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			BubbleScaleModeCombo.FillFromEnum(GetType(BubbleSizeScaleMode))
			BubbleScaleModeCombo.SelectedIndex = CInt(m_Bubble.BubbleSizeScale.Mode)
			TextOffsetNumericUpDown.Value = CDec(m_Bubble.BubbleSizeScale.TextOffset.Value)
			TableCellOffsetNumericUpDown.Value = CDec(m_Bubble.BubbleSizeScale.TableCellOffset.Value)
			BubbleScaleStepsUpDown.Value = CDec(m_Bubble.BubbleSizeScale.Steps)
			RoundValuesCheckBox.Checked = m_Bubble.BubbleSizeScale.RoundValues

			BubbleScaleModeCombo_SelectedIndexChanged(Nothing, Nothing)
		End Sub

		Private Sub BubbleScaleModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BubbleScaleModeCombo.SelectedIndexChanged
			If m_Bubble Is Nothing Then
				Return
			End If

			m_Bubble.BubbleSizeScale.Mode = CType(BubbleScaleModeCombo.SelectedIndex, BubbleSizeScaleMode)

			Select Case m_Bubble.BubbleSizeScale.Mode
				Case BubbleSizeScaleMode.ConcentricDown, BubbleSizeScaleMode.ConcentricUp
					m_Bubble.BubbleSizeScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
					TableCellOffsetNumericUpDown.Enabled = False
				Case BubbleSizeScaleMode.TableAscending, BubbleSizeScaleMode.TableDescending
					m_Bubble.BubbleSizeScale.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
					TableCellOffsetNumericUpDown.Enabled = True
			End Select

			nChartControl1.Refresh()
		End Sub

		Private Sub TextOffsetNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextOffsetNumericUpDown.ValueChanged
			If m_Bubble Is Nothing Then
				Return
			End If

			m_Bubble.BubbleSizeScale.TextOffset = New NLength(CInt(Math.Truncate(TextOffsetNumericUpDown.Value)))
			nChartControl1.Refresh()
		End Sub

		Private Sub TableCellOffsetNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TableCellOffsetNumericUpDown.ValueChanged
			If m_Bubble Is Nothing Then
				Return
			End If

			m_Bubble.BubbleSizeScale.TableCellOffset = New NLength(CInt(Math.Truncate(TableCellOffsetNumericUpDown.Value)))
			nChartControl1.Refresh()
		End Sub

		Private Sub BubbleScaleStepsUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BubbleScaleStepsUpDown.ValueChanged
			If m_Bubble Is Nothing Then
				Return
			End If
			m_Bubble.BubbleSizeScale.Steps = CInt(Math.Truncate(BubbleScaleStepsUpDown.Value))
			nChartControl1.Refresh()
		End Sub

		Private Sub RoundValuesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RoundValuesCheckBox.CheckedChanged
			If m_Bubble Is Nothing Then
				Return
			End If

			m_Bubble.BubbleSizeScale.RoundValues = RoundValuesCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub StrokeStyleButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StrokeStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Bubble.BubbleSizeScale.StrokeStyle, strokeStyleResult) Then
				m_Bubble.BubbleSizeScale.StrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
