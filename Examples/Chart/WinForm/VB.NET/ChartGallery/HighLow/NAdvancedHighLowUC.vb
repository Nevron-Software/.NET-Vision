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
	Public Class NAdvancedHighLowUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_HighLow As NHighLowSeries
		Private WithEvents HighLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents LowLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents ChangeValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeXValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DropLinesCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.ChangeValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.HighLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.LowLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.DropLinesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ChangeValues
			' 
			Me.ChangeValues.Location = New System.Drawing.Point(8, 8)
			Me.ChangeValues.Name = "ChangeValues"
			Me.ChangeValues.Size = New System.Drawing.Size(163, 27)
			Me.ChangeValues.TabIndex = 0
			Me.ChangeValues.Text = "Change Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeValues.Click += new System.EventHandler(this.ChangeValues_Click);
			' 
			' ChangeXValues
			' 
			Me.ChangeXValues.Location = New System.Drawing.Point(8, 41)
			Me.ChangeXValues.Name = "ChangeXValues"
			Me.ChangeXValues.Size = New System.Drawing.Size(163, 27)
			Me.ChangeXValues.TabIndex = 1
			Me.ChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			' 
			' HighLabel
			' 
			Me.HighLabel.Location = New System.Drawing.Point(8, 102)
			Me.HighLabel.Name = "HighLabel"
			Me.HighLabel.Size = New System.Drawing.Size(163, 18)
			Me.HighLabel.TabIndex = 2
			Me.HighLabel.Text = "high"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HighLabel.TextChanged += new System.EventHandler(this.HighLabel_TextChanged);
			' 
			' LowLabel
			' 
			Me.LowLabel.Location = New System.Drawing.Point(8, 158)
			Me.LowLabel.Name = "LowLabel"
			Me.LowLabel.Size = New System.Drawing.Size(163, 18)
			Me.LowLabel.TabIndex = 3
			Me.LowLabel.Text = "low"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LowLabel.TextChanged += new System.EventHandler(this.LowLabel_TextChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 81)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(163, 15)
			Me.label1.TabIndex = 4
			Me.label1.Text = "High Label:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 140)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(163, 15)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Low Label:"
			' 
			' DropLinesCheck
			' 
			Me.DropLinesCheck.ButtonProperties.BorderOffset = 2
			Me.DropLinesCheck.Location = New System.Drawing.Point(8, 209)
			Me.DropLinesCheck.Name = "DropLinesCheck"
			Me.DropLinesCheck.Size = New System.Drawing.Size(163, 21)
			Me.DropLinesCheck.TabIndex = 41
			Me.DropLinesCheck.Text = "Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DropLinesCheck.CheckedChanged += new System.EventHandler(this.DropLinesCheck_CheckedChanged);
			' 
			' NAdvancedHighLowUC
			' 
			Me.Controls.Add(Me.DropLinesCheck)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.LowLabel)
			Me.Controls.Add(Me.HighLabel)
			Me.Controls.Add(Me.ChangeXValues)
			Me.Controls.Add(Me.ChangeValues)
			Me.Name = "NAdvancedHighLowUC"
			Me.Size = New System.Drawing.Size(180, 252)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Advanced High Low Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' create the series
			m_HighLow = CType(m_Chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			m_HighLow.Name = "High-Low Series"
			m_HighLow.HighFillStyle = New NColorFillStyle(GreyBlue)
			m_HighLow.LowFillStyle = New NColorFillStyle(DarkOrange)
			m_HighLow.UseXValues = True
			m_HighLow.DataLabelStyle.Format = "<high_label><low_label>"
			m_HighLow.Legend.Mode = SeriesLegendMode.SeriesLogic

			' fill with values
			GenerateValuesY(8)
			GenerateValuesX(8)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub GenerateValuesY(ByVal nCount As Integer)
			Dim dPhase1 As Double = Random.Next(5)
			Dim dPhase2 As Double = dPhase1 + 1

			m_HighLow.HighValues.Clear()
			m_HighLow.LowValues.Clear()

			For i As Integer = 0 To nCount - 1
				Dim d1 As Double = 10 + Math.Sin(dPhase1 + 0.8 * i) + 0.5 * Random.NextDouble()
				Dim d2 As Double = 10 + Math.Cos(dPhase2 + 0.8 * i) + 0.5 * Random.NextDouble()

				m_HighLow.HighValues.Add(d1)
				m_HighLow.LowValues.Add(d2)
			Next i
		End Sub
		Private Sub GenerateValuesX(ByVal nCount As Integer)
			m_HighLow.XValues.Clear()

			Dim dValue As Double = CDbl(Random.Next(100))

			For i As Integer = 0 To nCount - 1
				m_HighLow.XValues.Add(dValue)

				dValue = dValue + Random.Next(5, 10)
			Next i
		End Sub

		Private Sub ChangeValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeValues.Click
			GenerateValuesY(8)

			nChartControl1.Refresh()
		End Sub
		Private Sub ChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeXValues.Click
			GenerateValuesX(8)

			nChartControl1.Refresh()
		End Sub
		Private Sub HighLabel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HighLabel.TextChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_HighLow.HighLabel = HighLabel.Text
			nChartControl1.Refresh()
		End Sub
		Private Sub LowLabel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LowLabel.TextChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_HighLow.LowLabel = LowLabel.Text
			nChartControl1.Refresh()
		End Sub
		Private Sub DropLinesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLinesCheck.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_HighLow.DropLines = DropLinesCheck.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
