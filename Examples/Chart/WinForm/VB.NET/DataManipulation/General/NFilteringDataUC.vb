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
	Public Class NFilteringDataUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private m_SubsetAll As NDataSeriesSubset
		Private m_SubsetFilter As NDataSeriesSubset
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private Value As Nevron.UI.WinForm.Controls.NTextBox
		Private CurrentFilter As Nevron.UI.WinForm.Controls.NTextBox
		Private OperationList As Nevron.UI.WinForm.Controls.NListBox
		Private compareMethodCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private subsetOperationCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents btnApplyFilter As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnResetFilter As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnChangeData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnExtractSubset As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnRemoveSubset As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_SubsetAll = New NDataSeriesSubset()
			m_SubsetFilter = New NDataSeriesSubset()

			compareMethodCombo.FillFromEnum(GetType(Nevron.Chart.CompareMethod))

			subsetOperationCombo.Items.Add("Replace")
			subsetOperationCombo.Items.Add("Combine")
			subsetOperationCombo.Items.Add("Intersect")
			subsetOperationCombo.Items.Add("Subtract")
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
			Dim resources As New System.Resources.ResourceManager(GetType(NFilteringDataUC))
			Me.label1 = New System.Windows.Forms.Label()
			Me.compareMethodCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.Value = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.btnApplyFilter = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnResetFilter = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.subsetOperationCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.btnChangeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.CurrentFilter = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.OperationList = New Nevron.UI.WinForm.Controls.NListBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.btnRemoveSubset = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnExtractSubset = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(10, 74)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 24)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Compare Method:"
			' 
			' compareMethodCombo
			' 
			Me.compareMethodCombo.Location = New System.Drawing.Point(82, 79)
			Me.compareMethodCombo.Name = "compareMethodCombo"
			Me.compareMethodCombo.Size = New System.Drawing.Size(96, 21)
			Me.compareMethodCombo.TabIndex = 1
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(10, 55)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(64, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Value:"
			' 
			' Value
			' 
			Me.Value.Location = New System.Drawing.Point(82, 52)
			Me.Value.Name = "Value"
			Me.Value.Size = New System.Drawing.Size(96, 20)
			Me.Value.TabIndex = 3
			Me.Value.Text = "50"
			' 
			' btnApplyFilter
			' 
			Me.btnApplyFilter.Location = New System.Drawing.Point(10, 137)
			Me.btnApplyFilter.Name = "btnApplyFilter"
			Me.btnApplyFilter.Size = New System.Drawing.Size(168, 24)
			Me.btnApplyFilter.TabIndex = 4
			Me.btnApplyFilter.Text = "Apply Filter"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnApplyFilter.Click += new System.EventHandler(this.ApplyFilter_Click);
			' 
			' btnResetFilter
			' 
			Me.btnResetFilter.Location = New System.Drawing.Point(10, 21)
			Me.btnResetFilter.Name = "btnResetFilter"
			Me.btnResetFilter.Size = New System.Drawing.Size(167, 23)
			Me.btnResetFilter.TabIndex = 5
			Me.btnResetFilter.Text = "Reset Filter"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnResetFilter.Click += new System.EventHandler(this.ResetFilter_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(10, 105)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(64, 32)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Subset Operation:"
			' 
			' subsetOperationCombo
			' 
			Me.subsetOperationCombo.Location = New System.Drawing.Point(82, 107)
			Me.subsetOperationCombo.Name = "subsetOperationCombo"
			Me.subsetOperationCombo.Size = New System.Drawing.Size(96, 21)
			Me.subsetOperationCombo.TabIndex = 7
			' 
			' btnChangeData
			' 
			Me.btnChangeData.Location = New System.Drawing.Point(10, 22)
			Me.btnChangeData.Name = "btnChangeData"
			Me.btnChangeData.Size = New System.Drawing.Size(168, 23)
			Me.btnChangeData.TabIndex = 1
			Me.btnChangeData.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnChangeData.Click += new System.EventHandler(this.ChangeData_Click);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.CurrentFilter)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.OperationList)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.compareMethodCombo)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.Value)
			Me.groupBox1.Controls.Add(Me.btnApplyFilter)
			Me.groupBox1.Controls.Add(Me.btnResetFilter)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.subsetOperationCombo)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(7, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(190, 345)
			Me.groupBox1.TabIndex = 9
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Filter Operations"
			' 
			' CurrentFilter
			' 
			Me.CurrentFilter.Location = New System.Drawing.Point(10, 283)
			Me.CurrentFilter.Multiline = True
			Me.CurrentFilter.Name = "CurrentFilter"
			Me.CurrentFilter.Size = New System.Drawing.Size(168, 51)
			Me.CurrentFilter.TabIndex = 3
			Me.CurrentFilter.Text = "textBox1"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(10, 265)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(168, 16)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Current Filter:"
			' 
			' OperationList
			' 
			Me.OperationList.Location = New System.Drawing.Point(10, 185)
			Me.OperationList.Name = "OperationList"
			Me.OperationList.Size = New System.Drawing.Size(168, 69)
			Me.OperationList.TabIndex = 0
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(10, 169)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(168, 16)
			Me.label4.TabIndex = 1
			Me.label4.Text = "Operation List:"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.btnRemoveSubset)
			Me.groupBox2.Controls.Add(Me.btnExtractSubset)
			Me.groupBox2.Controls.Add(Me.btnChangeData)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(7, 359)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(190, 120)
			Me.groupBox2.TabIndex = 10
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Data Series Operations"
			' 
			' btnRemoveSubset
			' 
			Me.btnRemoveSubset.Location = New System.Drawing.Point(10, 86)
			Me.btnRemoveSubset.Name = "btnRemoveSubset"
			Me.btnRemoveSubset.Size = New System.Drawing.Size(168, 23)
			Me.btnRemoveSubset.TabIndex = 0
			Me.btnRemoveSubset.Text = "Remove Subset"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnRemoveSubset.Click += new System.EventHandler(this.RemoveSubset_Click);
			' 
			' btnExtractSubset
			' 
			Me.btnExtractSubset.Location = New System.Drawing.Point(10, 54)
			Me.btnExtractSubset.Name = "btnExtractSubset"
			Me.btnExtractSubset.Size = New System.Drawing.Size(168, 23)
			Me.btnExtractSubset.TabIndex = 0
			Me.btnExtractSubset.Text = "Extract Subset"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnExtractSubset.Click += new System.EventHandler(this.ExtractSubset_Click);
			' 
			' NFilteringDataUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.groupBox2)
			Me.Name = "NFilteringDataUC"
			Me.Size = New System.Drawing.Size(207, 490)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' add a label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Filtering Data")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.Legend.Mode = SeriesLegendMode.None
			m_Bar.DataLabelStyle.Format = "<value>"
			m_Bar.Values.FillRandom(Random, 10)

			ResetFilter()

			compareMethodCombo.SelectedIndex = 0
			subsetOperationCombo.SelectedIndex = 0
		End Sub

		Private Sub ResetFilter()
			m_SubsetAll.Clear()
			m_SubsetFilter.Clear()

			If m_Bar.Values.Count > 0 Then
				m_SubsetAll.AddRange(0, m_Bar.Values.Count - 1)
				m_SubsetFilter.AddRange(0, m_Bar.Values.Count - 1)
			End If

			OperationList.Items.Clear()
			OperationList.Items.Add("f = all")
			CurrentFilter.Text = m_SubsetFilter.ToString()

			ApplyColorToSubset(m_SubsetFilter, Color.Red)
		End Sub

		Private Sub ApplyColorToSubset(ByVal subset As NDataSeriesSubset, ByVal color As Color)
			m_Bar.FillStyles.Clear()

			For Each index As Integer In subset
				m_Bar.FillStyles(index) = New NColorFillStyle(color)
			Next index
		End Sub

		Private Sub ResetFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetFilter.Click
			ResetFilter()

			nChartControl1.Refresh()
		End Sub

		Private Sub ApplyFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyFilter.Click
			Dim dValue As Double
			Dim sFilter As String = ""
			Dim sOperation As String = ""

			' make all colors blue
			ApplyColorToSubset(m_SubsetAll, Color.Blue)

			Try
				dValue = Double.Parse(Value.Text)
			Catch
				Return
			End Try

			Dim compareMethod As Nevron.Chart.CompareMethod = CType(compareMethodCombo.SelectedIndex, Nevron.Chart.CompareMethod)

			Dim subset As NDataSeriesSubset = m_Bar.Values.Filter(compareMethod, dValue)

			Select Case compareMethodCombo.SelectedIndex
				Case 0
					sFilter = "(> " & dValue.ToString() & ")"
				Case 1
					sFilter = "(< " & dValue.ToString() & ")"
				Case 2
					sFilter = "(==" & dValue.ToString() & ")"
				Case 3
					sFilter = "(>=" & dValue.ToString() & ")"
				Case 4
					sFilter = "(<=" & dValue.ToString() & ")"
				Case 5
					sFilter = "(!=" & dValue.ToString() & ")"
			End Select

			Select Case subsetOperationCombo.SelectedIndex
				Case 0 ' replace
					m_SubsetFilter = subset
					OperationList.Items.Clear()
					sOperation = "f = "

				Case 1 ' combine
					m_SubsetFilter.Combine(subset)
					sOperation = "f = f combine "
				Case 2 ' intersect
					m_SubsetFilter.Intersect(subset)
					sOperation = "f = f intersect "
				Case 3 ' subtract
					m_SubsetFilter.Subtract(subset)
					sOperation = "f = f subtract "
			End Select

			OperationList.Items.Add(sOperation & sFilter)
			CurrentFilter.Text = m_SubsetFilter.ToString()

			' apply red color only on the bars in the filter subset
			ApplyColorToSubset(m_SubsetFilter, Color.Red)

			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeData.Click
			m_Bar.Values.FillRandom(Random, 10)

			ResetFilter()

			nChartControl1.Refresh()
		End Sub

		Private Sub ExtractSubset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExtractSubset.Click
			m_Bar.Values.ExtractSubset(m_SubsetFilter)

			ResetFilter()

			nChartControl1.Refresh()
		End Sub

		Private Sub RemoveSubset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveSubset.Click
			m_Bar.Values.RemoveSubset(m_SubsetFilter)

			ResetFilter()

			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace