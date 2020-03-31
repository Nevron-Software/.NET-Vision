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
	Public Class NEvaluatingDataUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private m_Subset As NDataSeriesSubset
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private FunctionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents AddRange As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents AddIndex As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RemoveIndex As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RemoveRange As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Evaluate As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private Index As Nevron.UI.WinForm.Controls.NTextBox
		Private Subset As Nevron.UI.WinForm.Controls.NTextBox
		Private Result As Nevron.UI.WinForm.Controls.NTextBox
		Private From As Nevron.UI.WinForm.Controls.NTextBox
		Private [To] As Nevron.UI.WinForm.Controls.NTextBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_Subset = New NDataSeriesSubset()

			FunctionCombo.Items.Add("MIN")
			FunctionCombo.Items.Add("MAX")
			FunctionCombo.Items.Add("AVE")
			FunctionCombo.Items.Add("SUM")
			FunctionCombo.Items.Add("ABSSUM")
			FunctionCombo.Items.Add("FIRST")
			FunctionCombo.Items.Add("LAST")
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
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.Subset = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.RemoveRange = New Nevron.UI.WinForm.Controls.NButton()
			Me.RemoveIndex = New Nevron.UI.WinForm.Controls.NButton()
			Me.AddIndex = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.To = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.From = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.AddRange = New Nevron.UI.WinForm.Controls.NButton()
			Me.Index = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.Result = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.Evaluate = New Nevron.UI.WinForm.Controls.NButton()
			Me.FunctionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.groupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.groupBox4.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.groupBox4)
			Me.groupBox1.Controls.Add(Me.groupBox3)
			Me.groupBox1.Controls.Add(Me.Subset)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Location = New System.Drawing.Point(8, 8)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(226, 225)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Subset"
			' 
			' Subset
			' 
			Me.Subset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.Subset.Location = New System.Drawing.Point(5, 193)
			Me.Subset.Name = "Subset"
			Me.Subset.ReadOnly = True
			Me.Subset.Size = New System.Drawing.Size(215, 20)
			Me.Subset.TabIndex = 11
			Me.Subset.Text = ""
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 174)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(88, 16)
			Me.label4.TabIndex = 10
			Me.label4.Text = "Current Subset:"
			' 
			' RemoveRange
			' 
			Me.RemoveRange.Location = New System.Drawing.Point(106, 40)
			Me.RemoveRange.Name = "RemoveRange"
			Me.RemoveRange.Size = New System.Drawing.Size(99, 23)
			Me.RemoveRange.TabIndex = 9
			Me.RemoveRange.Text = "Remove Range"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RemoveRange.Click += new System.EventHandler(this.RemoveRange_Click);
			' 
			' RemoveIndex
			' 
			Me.RemoveIndex.Location = New System.Drawing.Point(106, 43)
			Me.RemoveIndex.Name = "RemoveIndex"
			Me.RemoveIndex.Size = New System.Drawing.Size(99, 23)
			Me.RemoveIndex.TabIndex = 8
			Me.RemoveIndex.Text = "Remove Index"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RemoveIndex.Click += new System.EventHandler(this.RemoveIndex_Click);
			' 
			' AddIndex
			' 
			Me.AddIndex.Location = New System.Drawing.Point(106, 14)
			Me.AddIndex.Name = "AddIndex"
			Me.AddIndex.Size = New System.Drawing.Size(99, 23)
			Me.AddIndex.TabIndex = 7
			Me.AddIndex.Text = "Add Index"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AddIndex.Click += new System.EventHandler(this.AddIndex_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 43)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(40, 16)
			Me.label3.TabIndex = 6
			Me.label3.Text = "To:"
			' 
			' To
			' 
			Me.To.Location = New System.Drawing.Point(51, 41)
			Me.To.Name = "To"
			Me.To.Size = New System.Drawing.Size(50, 20)
			Me.To.TabIndex = 5
			Me.To.Text = "1"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 16)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(40, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "From:"
			' 
			' From
			' 
			Me.From.Location = New System.Drawing.Point(51, 15)
			Me.From.Name = "From"
			Me.From.Size = New System.Drawing.Size(50, 20)
			Me.From.TabIndex = 3
			Me.From.Text = "0"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 17)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(40, 16)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Index:"
			' 
			' AddRange
			' 
			Me.AddRange.Location = New System.Drawing.Point(106, 14)
			Me.AddRange.Name = "AddRange"
			Me.AddRange.Size = New System.Drawing.Size(99, 23)
			Me.AddRange.TabIndex = 1
			Me.AddRange.Text = "Add Range"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AddRange.Click += new System.EventHandler(this.AddRange_Click);
			' 
			' Index
			' 
			Me.Index.Location = New System.Drawing.Point(52, 15)
			Me.Index.Name = "Index"
			Me.Index.Size = New System.Drawing.Size(50, 20)
			Me.Index.TabIndex = 0
			Me.Index.Text = "0"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.Result)
			Me.groupBox2.Controls.Add(Me.label6)
			Me.groupBox2.Controls.Add(Me.Evaluate)
			Me.groupBox2.Controls.Add(Me.FunctionCombo)
			Me.groupBox2.Controls.Add(Me.label5)
			Me.groupBox2.Location = New System.Drawing.Point(8, 253)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(226, 178)
			Me.groupBox2.TabIndex = 1
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Subset Evaluation"
			' 
			' Result
			' 
			Me.Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.Result.Location = New System.Drawing.Point(8, 120)
			Me.Result.Name = "Result"
			Me.Result.ReadOnly = True
			Me.Result.Size = New System.Drawing.Size(136, 20)
			Me.Result.TabIndex = 4
			Me.Result.Text = ""
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 96)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(48, 16)
			Me.label6.TabIndex = 3
			Me.label6.Text = "Result:"
			' 
			' Evaluate
			' 
			Me.Evaluate.Location = New System.Drawing.Point(8, 64)
			Me.Evaluate.Name = "Evaluate"
			Me.Evaluate.Size = New System.Drawing.Size(136, 23)
			Me.Evaluate.TabIndex = 2
			Me.Evaluate.Text = "Evaluate"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Evaluate.Click += new System.EventHandler(this.Evaluate_Click);
			' 
			' FunctionCombo
			' 
			Me.FunctionCombo.Location = New System.Drawing.Point(8, 32)
			Me.FunctionCombo.Name = "FunctionCombo"
			Me.FunctionCombo.Size = New System.Drawing.Size(136, 21)
			Me.FunctionCombo.TabIndex = 1
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 16)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(56, 16)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Function:"
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.RemoveRange)
			Me.groupBox3.Controls.Add(Me.AddRange)
			Me.groupBox3.Controls.Add(Me.From)
			Me.groupBox3.Controls.Add(Me.label2)
			Me.groupBox3.Controls.Add(Me.To)
			Me.groupBox3.Controls.Add(Me.label3)
			Me.groupBox3.Location = New System.Drawing.Point(5, 95)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(215, 71)
			Me.groupBox3.TabIndex = 12
			Me.groupBox3.TabStop = False
			' 
			' groupBox4
			' 
			Me.groupBox4.Controls.Add(Me.RemoveIndex)
			Me.groupBox4.Controls.Add(Me.AddIndex)
			Me.groupBox4.Controls.Add(Me.Index)
			Me.groupBox4.Controls.Add(Me.label1)
			Me.groupBox4.Location = New System.Drawing.Point(5, 13)
			Me.groupBox4.Name = "groupBox4"
			Me.groupBox4.Size = New System.Drawing.Size(215, 75)
			Me.groupBox4.TabIndex = 13
			Me.groupBox4.TabStop = False
			' 
			' NEvaluatingDataUC
			' 
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NEvaluatingDataUC"
			Me.Size = New System.Drawing.Size(242, 443)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox4.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.Values.FillRandom(Random, 10)
			m_Bar.Legend.Mode = SeriesLegendMode.None

			m_Subset.AddRange(0, 9)
			Subset.Text = m_Subset.ToString()
			FunctionCombo.SelectedIndex = 0

			ApplyColorToSubset()

			' add a label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Evaluating data")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(Color.MidnightBlue)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
		End Sub

		Private Sub AddIndex_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddIndex.Click
			Dim nIndex As Integer = 0

			Try
				nIndex = Int32.Parse(Index.Text)
			Catch
				Return
			End Try

			m_Subset.AddIndex(nIndex)
			Subset.Text = m_Subset.ToString()

			ApplyColorToSubset()
		End Sub

		Private Sub RemoveIndex_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoveIndex.Click
			Dim nIndex As Integer = 0

			Try
				nIndex = Int32.Parse(Index.Text)
			Catch
				Return
			End Try

			m_Subset.RemoveIndex(nIndex)
			Subset.Text = m_Subset.ToString()

			ApplyColorToSubset()
		End Sub

		Private Sub AddRange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddRange.Click
			Dim nFrom As Integer = 0
			Dim nTo As Integer = 0

			Try
				nFrom = Int32.Parse(From.Text)
				nTo = Int32.Parse([To].Text)
			Catch
				Return
			End Try

			m_Subset.AddRange(nFrom, nTo)
			Subset.Text = m_Subset.ToString()

			ApplyColorToSubset()
		End Sub

		Private Sub RemoveRange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoveRange.Click
			Dim nFrom As Integer = 0
			Dim nTo As Integer = 0

			Try
				nFrom = Int32.Parse(From.Text)
				nTo = Int32.Parse([To].Text)
			Catch
				Return
			End Try

			m_Subset.RemoveRange(nFrom, nTo)
			Subset.Text = m_Subset.ToString()

			ApplyColorToSubset()
		End Sub

		Private Sub Evaluate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Evaluate.Click
			Dim dResult As Double = m_Bar.Values.Evaluate(FunctionCombo.Text, m_Subset)
			Result.Text = dResult.ToString()
		End Sub

		Private Sub ApplyColorToSubset()
			For i As Integer = 0 To 9
				m_Bar.FillStyles(i) = New NColorFillStyle(Color.Blue)
			Next i

			For Each subsetIndex As Integer In m_Subset
				m_Bar.FillStyles(subsetIndex) = New NColorFillStyle(Color.Red)
			Next subsetIndex

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace