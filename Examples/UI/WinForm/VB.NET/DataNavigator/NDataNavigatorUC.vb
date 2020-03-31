Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Interop.Win32
Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NDataNavigatorUC.
	''' </summary>
	Public Class NDataNavigatorUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Dock = DockStyle.Fill

			CreateDataSources()
			InitDataSourceCombo()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Implementation"

		Friend Sub CreateDataSources()
			m_DataSource1 = New ArrayList()
			For i As Integer = 0 To 999
				m_DataSource1.Add("Record " & (i + 1).ToString())
			Next i

			m_DataSource2 = New DataTable()
			m_DataSource2.BeginInit()

			'populate the datatable with sample data
			For i As Integer = 0 To 9
				m_DataSource2.Columns.Add("Sample data column " & (i + 1).ToString())

				For j As Integer = 0 To 9
					m_DataSource2.Rows.Add(New Object() {})
				Next j
			Next i

			m_DataSource2.EndInit()
		End Sub

		Friend Sub InitDataSourceCombo()
			Dim item As NListBoxItem

			item = New NListBoxItem("None")
			dataSourceCombo.Items.Add(item)

			item = New NListBoxItem("Array List")
			dataSourceCombo.Items.Add(item)

			item = New NListBoxItem("Data Set")
			dataSourceCombo.Items.Add(item)

			dataSourceCombo.SelectedIndex = 0
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nNumericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nNumericUpDown1.ValueChanged
			If nDataNavigator1 Is Nothing Then
				Return
			End If

			nDataNavigator1.DataNavigatorElement.DisplayIndex = CInt(Fix(nNumericUpDown1.Value))
			nDataNavigator2.DataNavigatorElement.DisplayIndex = CInt(Fix(nNumericUpDown1.Value))
		End Sub

		Private Sub dataSourceCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataSourceCombo.SelectedIndexChanged
			Dim index As Integer = dataSourceCombo.SelectedIndex
			Dim dataSource As Object = Nothing

			Select Case index
				Case 1
					dataSource = m_DataSource1
				Case 2
					dataSource = m_DataSource2
			End Select

			nDataNavigator1.DataNavigatorElement.DataSource = dataSource
			nDataNavigator2.DataNavigatorElement.DataSource = dataSource
		End Sub

		Private Sub tootipsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tootipsCheck.CheckedChanged
			Dim enable As Boolean = tootipsCheck.Checked

			nDataNavigator1.EnableElementTooltips = enable
			nDataNavigator2.EnableElementTooltips = enable
		End Sub

		Private Sub autoRepeatCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles autoRepeatCheck.CheckedChanged
			Dim interval As Integer
			If autoRepeatCheck.Checked Then
				interval = 10
			Else
				interval = 0
			End If

			nDataNavigator1.DataNavigatorElement.RepeatInterval = interval
			nDataNavigator2.DataNavigatorElement.RepeatInterval = interval
		End Sub

		Private Sub showDisplayCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showDisplayCheck.CheckedChanged
			Dim show As Boolean = showDisplayCheck.Checked

			nDataNavigator1.DataNavigatorElement.ShowDisplay = show
			nDataNavigator2.DataNavigatorElement.ShowDisplay = show
		End Sub
		Private Sub borderBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles borderBtn.Click
			nDataNavigator1.Border.ShowEditor()
			nDataNavigator2.Border.Copy(nDataNavigator1.Border)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nDataNavigator1 = New Nevron.UI.WinForm.Controls.NDataNavigator()
			Me.nNumericUpDown1 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nDataNavigator2 = New Nevron.UI.WinForm.Controls.NDataNavigator()
			Me.label2 = New System.Windows.Forms.Label()
			Me.dataSourceCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.tootipsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.autoRepeatCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.borderBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.showDisplayCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			CType(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nDataNavigator1
			' 
			Me.nDataNavigator1.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nDataNavigator1.ForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nDataNavigator1.Location = New System.Drawing.Point(8, 8)
			Me.nDataNavigator1.Name = "nDataNavigator1"
			Me.nDataNavigator1.Size = New System.Drawing.Size(229, 24)
			Me.nDataNavigator1.TabIndex = 0
			Me.nDataNavigator1.Text = "nDataNavigator1"
			' 
			' nNumericUpDown1
			' 
			Me.nNumericUpDown1.Location = New System.Drawing.Point(152, 48)
			Me.nNumericUpDown1.Maximum = New System.Decimal(New Integer() { 6, 0, 0, 0})
			Me.nNumericUpDown1.Name = "nNumericUpDown1"
			Me.nNumericUpDown1.Size = New System.Drawing.Size(64, 20)
			Me.nNumericUpDown1.TabIndex = 3
'			Me.nNumericUpDown1.ValueChanged += New System.EventHandler(Me.nNumericUpDown1_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(48, 48)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 24)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Label Index:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nDataNavigator2
			' 
			Me.nDataNavigator2.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nDataNavigator2.DataNavigatorElement.Orientation = System.Windows.Forms.Orientation.Vertical
			Me.nDataNavigator2.ForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nDataNavigator2.Location = New System.Drawing.Point(8, 40)
			Me.nDataNavigator2.Name = "nDataNavigator2"
			Me.nDataNavigator2.Size = New System.Drawing.Size(24, 228)
			Me.nDataNavigator2.TabIndex = 1
			Me.nDataNavigator2.Text = "nDataNavigator2"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(48, 80)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(100, 24)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Data Source:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' dataSourceCombo
			' 
			Me.dataSourceCombo.Location = New System.Drawing.Point(152, 80)
			Me.dataSourceCombo.Name = "dataSourceCombo"
			Me.dataSourceCombo.Size = New System.Drawing.Size(168, 22)
			Me.dataSourceCombo.TabIndex = 5
			Me.dataSourceCombo.Text = "nComboBox1"
'			Me.dataSourceCombo.SelectedIndexChanged += New System.EventHandler(Me.dataSourceCombo_SelectedIndexChanged);
			' 
			' tootipsCheck
			' 
			Me.tootipsCheck.ButtonProperties.BorderOffset = 2
			Me.tootipsCheck.Checked = True
			Me.tootipsCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.tootipsCheck.Location = New System.Drawing.Point(152, 136)
			Me.tootipsCheck.Name = "tootipsCheck"
			Me.tootipsCheck.Size = New System.Drawing.Size(168, 24)
			Me.tootipsCheck.TabIndex = 7
			Me.tootipsCheck.Text = "Enable tooltips"
'			Me.tootipsCheck.CheckedChanged += New System.EventHandler(Me.tootipsCheck_CheckedChanged);
			' 
			' autoRepeatCheck
			' 
			Me.autoRepeatCheck.ButtonProperties.BorderOffset = 2
			Me.autoRepeatCheck.Checked = True
			Me.autoRepeatCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.autoRepeatCheck.Location = New System.Drawing.Point(152, 160)
			Me.autoRepeatCheck.Name = "autoRepeatCheck"
			Me.autoRepeatCheck.Size = New System.Drawing.Size(168, 24)
			Me.autoRepeatCheck.TabIndex = 8
			Me.autoRepeatCheck.Text = "Enable auto-repeat"
'			Me.autoRepeatCheck.CheckedChanged += New System.EventHandler(Me.autoRepeatCheck_CheckedChanged);
			' 
			' borderBtn
			' 
			Me.borderBtn.Location = New System.Drawing.Point(152, 192)
			Me.borderBtn.Name = "borderBtn"
			Me.borderBtn.Size = New System.Drawing.Size(88, 24)
			Me.borderBtn.TabIndex = 9
			Me.borderBtn.Text = "Border..."
'			Me.borderBtn.Click += New System.EventHandler(Me.borderBtn_Click);
			' 
			' showDisplayCheck
			' 
			Me.showDisplayCheck.ButtonProperties.BorderOffset = 2
			Me.showDisplayCheck.Checked = True
			Me.showDisplayCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.showDisplayCheck.Location = New System.Drawing.Point(152, 112)
			Me.showDisplayCheck.Name = "showDisplayCheck"
			Me.showDisplayCheck.Size = New System.Drawing.Size(168, 24)
			Me.showDisplayCheck.TabIndex = 6
			Me.showDisplayCheck.Text = "Show Display"
'			Me.showDisplayCheck.CheckedChanged += New System.EventHandler(Me.showDisplayCheck_CheckedChanged);
			' 
			' NDataNavigatorUC
			' 
			Me.Controls.Add(Me.showDisplayCheck)
			Me.Controls.Add(Me.borderBtn)
			Me.Controls.Add(Me.autoRepeatCheck)
			Me.Controls.Add(Me.tootipsCheck)
			Me.Controls.Add(Me.dataSourceCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.nDataNavigator2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nNumericUpDown1)
			Me.Controls.Add(Me.nDataNavigator1)
			Me.Name = "NDataNavigatorUC"
			Me.Size = New System.Drawing.Size(376, 328)
			CType(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_DataSource1 As ArrayList
		Friend m_DataSource2 As DataTable

		Private nDataNavigator1 As Nevron.UI.WinForm.Controls.NDataNavigator
		Private WithEvents nNumericUpDown1 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As System.Windows.Forms.Label
		Private nDataNavigator2 As Nevron.UI.WinForm.Controls.NDataNavigator
		Private label2 As System.Windows.Forms.Label
		Private WithEvents dataSourceCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents tootipsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents autoRepeatCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents borderBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents showDisplayCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
