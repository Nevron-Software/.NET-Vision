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
	Public Class NFindingDataUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private WithEvents FindMinValue As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FindMaxValue As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FindValue As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FindString As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeData As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private ValueEdit As Nevron.UI.WinForm.Controls.NTextBox
		Private StringEdit As Nevron.UI.WinForm.Controls.NTextBox
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
			Me.FindMinValue = New Nevron.UI.WinForm.Controls.NButton()
			Me.FindMaxValue = New Nevron.UI.WinForm.Controls.NButton()
			Me.FindValue = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ValueEdit = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.StringEdit = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FindString = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' FindMinValue
			' 
			Me.FindMinValue.Location = New System.Drawing.Point(8, 61)
			Me.FindMinValue.Name = "FindMinValue"
			Me.FindMinValue.Size = New System.Drawing.Size(199, 23)
			Me.FindMinValue.TabIndex = 0
			Me.FindMinValue.Text = "Find Min Value"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FindMinValue.Click += new System.EventHandler(this.FindMinValue_Click);
			' 
			' FindMaxValue
			' 
			Me.FindMaxValue.Location = New System.Drawing.Point(8, 93)
			Me.FindMaxValue.Name = "FindMaxValue"
			Me.FindMaxValue.Size = New System.Drawing.Size(199, 23)
			Me.FindMaxValue.TabIndex = 1
			Me.FindMaxValue.Text = "Find Max Value"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FindMaxValue.Click += new System.EventHandler(this.FindMaxValue_Click);
			' 
			' FindValue
			' 
			Me.FindValue.Location = New System.Drawing.Point(132, 128)
			Me.FindValue.Name = "FindValue"
			Me.FindValue.Size = New System.Drawing.Size(75, 20)
			Me.FindValue.TabIndex = 2
			Me.FindValue.Text = "Find Value"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FindValue.Click += new System.EventHandler(this.FindValue_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 131)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(40, 16)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Value:"
			' 
			' ValueEdit
			' 
			Me.ValueEdit.Location = New System.Drawing.Point(47, 128)
			Me.ValueEdit.Name = "ValueEdit"
			Me.ValueEdit.Size = New System.Drawing.Size(79, 20)
			Me.ValueEdit.TabIndex = 4
			Me.ValueEdit.Text = "12"
			' 
			' StringEdit
			' 
			Me.StringEdit.Location = New System.Drawing.Point(47, 160)
			Me.StringEdit.Name = "StringEdit"
			Me.StringEdit.Size = New System.Drawing.Size(79, 20)
			Me.StringEdit.TabIndex = 7
			Me.StringEdit.Text = "str1"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 163)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(40, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "String:"
			' 
			' FindString
			' 
			Me.FindString.Location = New System.Drawing.Point(132, 160)
			Me.FindString.Name = "FindString"
			Me.FindString.Size = New System.Drawing.Size(75, 20)
			Me.FindString.TabIndex = 5
			Me.FindString.Text = "Find String"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FindString.Click += new System.EventHandler(this.FindString_Click);
			' 
			' ChangeData
			' 
			Me.ChangeData.Location = New System.Drawing.Point(8, 8)
			Me.ChangeData.Name = "ChangeData"
			Me.ChangeData.Size = New System.Drawing.Size(199, 23)
			Me.ChangeData.TabIndex = 8
			Me.ChangeData.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeData.Click += new System.EventHandler(this.ChangeData_Click);
			' 
			' NFindingDataUC
			' 
			Me.Controls.Add(Me.ChangeData)
			Me.Controls.Add(Me.StringEdit)
			Me.Controls.Add(Me.FindString)
			Me.Controls.Add(Me.ValueEdit)
			Me.Controls.Add(Me.FindValue)
			Me.Controls.Add(Me.FindMaxValue)
			Me.Controls.Add(Me.FindMinValue)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label2)
			Me.Name = "NFindingDataUC"
			Me.Size = New System.Drawing.Size(215, 201)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' add a label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Finding Data")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create a bar chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' setup bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.Legend.Mode = SeriesLegendMode.None

			' generate random values and labels
			GenerateValues(6)
			m_Bar.Labels.FillRandom(Random, 6)

			' init form controls
			ValueEdit.Text = m_Bar.Values(3).ToString()
			StringEdit.Text = DirectCast(m_Bar.Labels(4), String)
		End Sub

		Private Sub GenerateValues(ByVal count As Integer)
			m_Bar.Values.Clear()

			For i As Integer = 0 To count - 1
				Dim value As Double = 1 + Random.NextDouble() * 99
				value = Math.Round(value, 2)
				m_Bar.Values.Add(value)
			Next i
		End Sub

		Private Sub ChangeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeData.Click
			' generate random values and labels
			GenerateValues(6)
			m_Bar.Labels.FillRandom(Random, 6)

			' all bars must be filled with the default color
			m_Bar.FillStyles.Clear()

			nChartControl1.Refresh()
		End Sub

		Private Sub FindMinValue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FindMinValue.Click
			Dim index As Integer = m_Bar.Values.FindMinValue()

			m_Bar.FillStyles.Clear()
			m_Bar.FillStyles(index) = New NColorFillStyle(Color.Red)

			nChartControl1.Refresh()
		End Sub

		Private Sub FindMaxValue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FindMaxValue.Click
			Dim index As Integer = m_Bar.Values.FindMaxValue()

			m_Bar.FillStyles.Clear()
			m_Bar.FillStyles(index) = New NColorFillStyle(Color.Red)

			nChartControl1.Refresh()
		End Sub

		Private Sub FindValue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FindValue.Click
			Dim dValue As Double

			Try
				dValue = Double.Parse(ValueEdit.Text)
			Catch
				Return
			End Try

			Dim index As Integer = m_Bar.Values.FindValue(dValue)
			If index = -1 Then
				MessageBox.Show("The specified value was not found in the bar Values series")
				Return
			End If

			m_Bar.FillStyles.Clear()
			m_Bar.FillStyles(index) = New NColorFillStyle(Color.Red)

			nChartControl1.Refresh()
		End Sub

		Private Sub FindString_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FindString.Click
			Dim index As Integer = m_Bar.Labels.FindString(StringEdit.Text)
			If index = -1 Then
				MessageBox.Show("The specified string was not found in the bar Labels series")
				Return
			End If

			m_Bar.FillStyles.Clear()
			m_Bar.FillStyles(index) = New NColorFillStyle(Color.Red)
			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace