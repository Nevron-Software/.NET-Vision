Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NNonoverlappingLabelsUC
		Inherits NExampleBaseUC

		Private m_PieSeries As NPieSeries
		Private m_PieChart As NPieChart
		Private WithEvents ChangeDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ClockwiseCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents PieStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
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
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ClockwiseCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.PieStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(4, 9)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(172, 24)
			Me.ChangeDataButton.TabIndex = 0
			Me.ChangeDataButton.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' ClockwiseCheckBox
			' 
			Me.ClockwiseCheckBox.ButtonProperties.BorderOffset = 2
			Me.ClockwiseCheckBox.Location = New System.Drawing.Point(4, 116)
			Me.ClockwiseCheckBox.Name = "ClockwiseCheckBox"
			Me.ClockwiseCheckBox.Size = New System.Drawing.Size(165, 23)
			Me.ClockwiseCheckBox.TabIndex = 3
			Me.ClockwiseCheckBox.Text = "Clockwise"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClockwiseCheckBox.CheckedChanged += new System.EventHandler(this.ClockwiseCheckBox_CheckedChanged);
			' 
			' PieStyleCombo
			' 
			Me.PieStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.PieStyleCombo.ListProperties.DataSource = Nothing
			Me.PieStyleCombo.ListProperties.DisplayMember = ""
			Me.PieStyleCombo.Location = New System.Drawing.Point(4, 69)
			Me.PieStyleCombo.Name = "PieStyleCombo"
			Me.PieStyleCombo.Size = New System.Drawing.Size(172, 21)
			Me.PieStyleCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PieStyleCombo.SelectedIndexChanged += new System.EventHandler(this.PieStyleCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 53)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(165, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Pie Style:"
			' 
			' NNonoverlappingLabelsUC
			' 
			Me.Controls.Add(Me.PieStyleCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ClockwiseCheckBox)
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Name = "NNonoverlappingLabelsUC"
			Me.Size = New System.Drawing.Size(180, 206)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Clear()
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Nonoverlapping Pie Labels")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_PieChart = New NPieChart()
			m_PieChart.Enable3D = True
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(m_PieChart)
			m_PieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
			m_PieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.VividCameraLight)
			m_PieChart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_PieChart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			' setup pie series
			m_PieSeries = CType(m_PieChart.Series.Add(SeriesType.Pie), NPieSeries)
			m_PieSeries.LabelMode = PieLabelMode.SpiderNoOverlap
			m_PieSeries.DataLabelStyle.Format = "<label>" & ControlChars.Lf & "<percent>"
			m_PieSeries.Values.ValueFormatter = New NNumericValueFormatter("0.##")

			Dim arrValues() As Double = { 4.17, 7.19, 5.62, 7.91, 15.28, 0.97, 1.3, 1.12, 8.54, 9.84, 2.05, 5.02, 1.42, 0.63, 3.01 }

			For i As Integer = 0 To arrValues.Length - 1
				m_PieSeries.Values.Add(arrValues(i))
			Next i

			SetTexts()

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			PieStyleCombo.FillFromEnum(GetType(PieStyle))
			PieStyleCombo.SelectedIndex = 2
		End Sub

		Private Sub GenerateRandomValues(ByVal count As Integer)
			m_PieSeries.Values.Clear()

			For i As Integer = 0 To count - 1
				m_PieSeries.Values.Add(Random.NextDouble() * 10)
			Next i
		End Sub
		Private Sub SetTexts()
			Dim arrTexts() As String = { "Athletics", "Basketball", "Boxing", "Cycling", "Football", "Golf", "Handball", "Ice Hockey", "Motorsports", "Rugby", "Sailing", "Snooker", "Swimming", "Tennis", "Volleyball" }

			For i As Integer = 0 To arrTexts.Length - 1
				m_PieSeries.Labels.Add(arrTexts(i))
			Next i
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeDataButton.Click
			GenerateRandomValues(15)
			nChartControl1.Refresh()
		End Sub
		Private Sub ClockwiseCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ClockwiseCheckBox.CheckedChanged
			m_PieChart.ClockwiseDirection = ClockwiseCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub PieStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PieStyleCombo.SelectedIndexChanged
			m_PieSeries.PieStyle = CType(PieStyleCombo.SelectedIndex, PieStyle)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
