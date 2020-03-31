Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Threading

Imports Nevron.Interop.Win32
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NListViewUC.
	''' </summary>
	Public Class NListViewUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Me.nListView1.HideSelection = False
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

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			Me.headerStyleCombo.FillFromEnum(GetType(ColumnHeaderStyle))
			Me.headerStyleCombo.SelectedItem = Me.nListView1.HeaderStyle

			headerSizeNumeric.Value = nListView1.HeaderHeight

			nListView1.BeginUpdate()
			Dim item As ListViewItem

			Dim dt As DateTime
			Dim dateNow As DateTime = DateTime.Now
			Dim text As String
			Dim randomNum As Integer
			Dim asciiA As Integer = &H41
			Dim asciiZ As Integer = &H5A

			For i As Integer = 1 To 20
				If i Mod 2 = 0 Then
					text = "sTrinG ItEM"
				Else
					text = "String Item"
				End If

				item = New ListViewItem(text)

				'case-insensitive column
				randomNum = Random.Next(asciiA, asciiZ)
				item.SubItems.Add(text & " " & randomNum.ToString())

				'numeric column
				item.SubItems.Add((Random.Next(1, 500) * 2).ToString())

				'date-time column
				dt = New DateTime(dateNow.Year, Random.Next(1, 11), Random.Next(1, 28))
				item.SubItems.Add(dt.ToShortDateString())

				nListView1.Items.Add(item)
			Next i

			nListView1.EndUpdate()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub customScrollCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles customScrollCheck.CheckedChanged
			nListView1.UseCustomScrollBars = customScrollCheck.Checked
		End Sub
		Private Sub customHeaderCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles customHeaderCheck.CheckedChanged
			nListView1.HeaderCustomDraw = customHeaderCheck.Checked
		End Sub
		Private Sub addBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim lvi As ListViewItem = New ListViewItem("Test Item " & nListView1.Items.Count)
			nListView1.Items.Add(lvi)
		End Sub
		Private Sub headerStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles headerStyleCombo.SelectedIndexChanged
			Me.nListView1.HeaderStyle = CType(Me.headerStyleCombo.SelectedItem, ColumnHeaderStyle)
		End Sub

		Private Sub headerSizeNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles headerSizeNumeric.ValueChanged
			nListView1.HeaderHeight = CInt(Fix(headerSizeNumeric.Value))
		End Sub

		Private Sub customItemsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles customItemsCheck.CheckedChanged
			nListView1.ItemCustomDraw = customItemsCheck.Checked
		End Sub

		Private Sub shadeColorCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles shadeColorCheck.CheckedChanged
			If (Not shadeColorCheck.Checked) Then
				nListView1.SortedColumnBackColor = Color.Empty
				shadeColorButton.Enabled = False
			Else
				nListView1.SortedColumnBackColor = shadeColorButton.Color
				shadeColorButton.Enabled = True
			End If
		End Sub

		Private Sub shadeColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles shadeColorButton.ColorChanged
			If shadeColorCheck.Checked Then
				nListView1.SortedColumnBackColor = shadeColorButton.Color
			End If
		End Sub

		Private Sub alternateRowsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles alternateRowsCheck.CheckedChanged
			nListView1.AlternateRows = alternateRowsCheck.Checked
		End Sub

		Private Sub alternateRowColorCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles alternateRowColorCheck.CheckedChanged
			If (Not alternateRowColorCheck.Checked) Then
				nListView1.AlternateRowColorBackColor = Color.Empty
				rowColorButton.Enabled = False
			Else
				nListView1.AlternateRowColorBackColor = rowColorButton.Color
				rowColorButton.Enabled = True
			End If
		End Sub

		Private Sub rowColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rowColorButton.ColorChanged
			If alternateRowColorCheck.Checked Then
				nListView1.AlternateRowColorBackColor = rowColorButton.Color
			End If
		End Sub

		Private Sub columnShadingCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles columnShadingCheck.CheckedChanged
			nListView1.SortedColumnShading = columnShadingCheck.Checked
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nListView1 = New Nevron.UI.WinForm.Controls.NListView()
			Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader4 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
			Me.customScrollCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.customHeaderCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.headerSizeNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.customItemsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.shadeColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.columnShadingCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.alternateRowsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.headerStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.alternateRowColorCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.rowColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.shadeColorCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			CType(Me.headerSizeNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nListView1
			' 
			Me.nListView1.AllowColumnReorder = True
			Me.nListView1.AlternateRowColorBackColor = System.Drawing.Color.Empty
			Me.nListView1.BackColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(245))))), (CInt(Fix((CByte(245))))), (CInt(Fix((CByte(245))))))
			Me.nListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader4, Me.columnHeader2, Me.columnHeader3})
			Me.nListView1.ExtendedColumns.AddRange(New Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo() { New Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo(Me.columnHeader1, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, Nevron.UI.ImageTextRelation.ImageBeforeText, Nothing, New Nevron.UI.NPadding(4, 2, 2, 4), True, Nevron.UI.WinForm.Controls.SortMode.String, False), New Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo(Me.columnHeader4, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, Nevron.UI.ImageTextRelation.ImageBeforeText, Nothing, New Nevron.UI.NPadding(4, 2, 2, 4), True, Nevron.UI.WinForm.Controls.SortMode.StringCaseInsensitive, False), New Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo(Me.columnHeader2, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, Nevron.UI.ImageTextRelation.ImageBeforeText, Nothing, New Nevron.UI.NPadding(4, 2, 2, 4), True, Nevron.UI.WinForm.Controls.SortMode.Numeric, False), New Nevron.UI.WinForm.Controls.NHeaderColumnExtendedInfo(Me.columnHeader3, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.MiddleLeft, Nevron.UI.ImageTextRelation.ImageBeforeText, Nothing, New Nevron.UI.NPadding(4, 2, 2, 4), True, Nevron.UI.WinForm.Controls.SortMode.DateTime, False)})
			Me.nListView1.ForeColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(0))))), (CInt(Fix((CByte(0))))), (CInt(Fix((CByte(0))))))
			Me.nListView1.FullRowSelect = True
			Me.nListView1.Location = New System.Drawing.Point(8, 8)
			Me.nListView1.Name = "nListView1"
			Me.nListView1.Size = New System.Drawing.Size(512, 208)
			Me.nListView1.TabIndex = 0
			Me.nListView1.View = System.Windows.Forms.View.Details
			' 
			' columnHeader1
			' 
			Me.columnHeader1.Text = "String Column"
			Me.columnHeader1.Width = 100
			' 
			' columnHeader4
			' 
			Me.columnHeader4.Text = "String Column Case Insensitive"
			Me.columnHeader4.Width = 179
			' 
			' columnHeader2
			' 
			Me.columnHeader2.Text = "Numeric Column"
			Me.columnHeader2.Width = 107
			' 
			' columnHeader3
			' 
			Me.columnHeader3.Text = "DateTime Column"
			Me.columnHeader3.Width = 115
			' 
			' customScrollCheck
			' 
			Me.customScrollCheck.ButtonProperties.BorderOffset = 2
			Me.customScrollCheck.Checked = True
			Me.customScrollCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.customScrollCheck.Location = New System.Drawing.Point(16, 24)
			Me.customScrollCheck.Name = "customScrollCheck"
			Me.customScrollCheck.Size = New System.Drawing.Size(168, 24)
			Me.customScrollCheck.TabIndex = 1
			Me.customScrollCheck.Text = "Custom Scrollbars"
'			Me.customScrollCheck.CheckedChanged += New System.EventHandler(Me.customScrollCheck_CheckedChanged);
			' 
			' customHeaderCheck
			' 
			Me.customHeaderCheck.ButtonProperties.BorderOffset = 2
			Me.customHeaderCheck.Checked = True
			Me.customHeaderCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.customHeaderCheck.Location = New System.Drawing.Point(16, 48)
			Me.customHeaderCheck.Name = "customHeaderCheck"
			Me.customHeaderCheck.Size = New System.Drawing.Size(168, 24)
			Me.customHeaderCheck.TabIndex = 3
			Me.customHeaderCheck.Text = "Custom Header"
'			Me.customHeaderCheck.CheckedChanged += New System.EventHandler(Me.customHeaderCheck_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(80, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 23)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Header Size:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' headerSizeNumeric
			' 
			Me.headerSizeNumeric.Location = New System.Drawing.Point(160, 24)
			Me.headerSizeNumeric.Maximum = New Decimal(New Integer() { 30, 0, 0, 0})
			Me.headerSizeNumeric.Minimum = New Decimal(New Integer() { 17, 0, 0, 0})
			Me.headerSizeNumeric.Name = "headerSizeNumeric"
			Me.headerSizeNumeric.Size = New System.Drawing.Size(88, 20)
			Me.headerSizeNumeric.TabIndex = 6
			Me.headerSizeNumeric.Value = New Decimal(New Integer() { 20, 0, 0, 0})
'			Me.headerSizeNumeric.ValueChanged += New System.EventHandler(Me.headerSizeNumeric_ValueChanged);
			' 
			' customItemsCheck
			' 
			Me.customItemsCheck.ButtonProperties.BorderOffset = 2
			Me.customItemsCheck.Checked = True
			Me.customItemsCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.customItemsCheck.Location = New System.Drawing.Point(16, 72)
			Me.customItemsCheck.Name = "customItemsCheck"
			Me.customItemsCheck.Size = New System.Drawing.Size(168, 24)
			Me.customItemsCheck.TabIndex = 7
			Me.customItemsCheck.Text = "Custom Draw Items"
'			Me.customItemsCheck.CheckedChanged += New System.EventHandler(Me.customItemsCheck_CheckedChanged);
			' 
			' shadeColorButton
			' 
			Me.shadeColorButton.ArrowClickOptions = False
			Me.shadeColorButton.ArrowWidth = 14
			Me.shadeColorButton.Color = System.Drawing.Color.LightGray
			Me.shadeColorButton.Enabled = False
			Me.shadeColorButton.Location = New System.Drawing.Point(160, 77)
			Me.shadeColorButton.Name = "shadeColorButton"
			Me.shadeColorButton.Size = New System.Drawing.Size(88, 24)
			Me.shadeColorButton.TabIndex = 8
'			Me.shadeColorButton.ColorChanged += New System.EventHandler(Me.shadeColorButton_ColorChanged);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.columnShadingCheck)
			Me.nGroupBox1.Controls.Add(Me.alternateRowsCheck)
			Me.nGroupBox1.Controls.Add(Me.customScrollCheck)
			Me.nGroupBox1.Controls.Add(Me.customHeaderCheck)
			Me.nGroupBox1.Controls.Add(Me.customItemsCheck)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 224)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(200, 152)
			Me.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox1.TabIndex = 9
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Custom Behavior Flags"
			' 
			' columnShadingCheck
			' 
			Me.columnShadingCheck.ButtonProperties.BorderOffset = 2
			Me.columnShadingCheck.Checked = True
			Me.columnShadingCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.columnShadingCheck.Location = New System.Drawing.Point(16, 96)
			Me.columnShadingCheck.Name = "columnShadingCheck"
			Me.columnShadingCheck.Size = New System.Drawing.Size(168, 24)
			Me.columnShadingCheck.TabIndex = 9
			Me.columnShadingCheck.Text = "Sorted Column Shading"
'			Me.columnShadingCheck.CheckedChanged += New System.EventHandler(Me.columnShadingCheck_CheckedChanged);
			' 
			' alternateRowsCheck
			' 
			Me.alternateRowsCheck.ButtonProperties.BorderOffset = 2
			Me.alternateRowsCheck.Location = New System.Drawing.Point(16, 120)
			Me.alternateRowsCheck.Name = "alternateRowsCheck"
			Me.alternateRowsCheck.Size = New System.Drawing.Size(168, 24)
			Me.alternateRowsCheck.TabIndex = 8
			Me.alternateRowsCheck.Text = "Alternating Rows"
'			Me.alternateRowsCheck.CheckedChanged += New System.EventHandler(Me.alternateRowsCheck_CheckedChanged);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.headerStyleCombo)
			Me.nGroupBox2.Controls.Add(Me.label2)
			Me.nGroupBox2.Controls.Add(Me.alternateRowColorCheck)
			Me.nGroupBox2.Controls.Add(Me.rowColorButton)
			Me.nGroupBox2.Controls.Add(Me.shadeColorCheck)
			Me.nGroupBox2.Controls.Add(Me.label1)
			Me.nGroupBox2.Controls.Add(Me.headerSizeNumeric)
			Me.nGroupBox2.Controls.Add(Me.shadeColorButton)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(224, 224)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(296, 152)
			Me.nGroupBox2.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox2.TabIndex = 10
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Additional Settings"
			' 
			' headerStyleCombo
			' 
			Me.headerStyleCombo.ListProperties.ColumnOnLeft = False
			Me.headerStyleCombo.Location = New System.Drawing.Point(160, 49)
			Me.headerStyleCombo.Name = "headerStyleCombo"
			Me.headerStyleCombo.Size = New System.Drawing.Size(130, 22)
			Me.headerStyleCombo.TabIndex = 13
			Me.headerStyleCombo.Text = "nComboBox1"
'			Me.headerStyleCombo.SelectedIndexChanged += New System.EventHandler(Me.headerStyleCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(80, 49)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(72, 23)
			Me.label2.TabIndex = 12
			Me.label2.Text = "Header Style:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' alternateRowColorCheck
			' 
			Me.alternateRowColorCheck.ButtonProperties.BorderOffset = 2
			Me.alternateRowColorCheck.Location = New System.Drawing.Point(8, 109)
			Me.alternateRowColorCheck.Name = "alternateRowColorCheck"
			Me.alternateRowColorCheck.Size = New System.Drawing.Size(144, 24)
			Me.alternateRowColorCheck.TabIndex = 11
			Me.alternateRowColorCheck.Text = "Alternate Row Color"
'			Me.alternateRowColorCheck.CheckedChanged += New System.EventHandler(Me.alternateRowColorCheck_CheckedChanged);
			' 
			' rowColorButton
			' 
			Me.rowColorButton.ArrowClickOptions = False
			Me.rowColorButton.ArrowWidth = 14
			Me.rowColorButton.Color = System.Drawing.Color.LightGray
			Me.rowColorButton.Enabled = False
			Me.rowColorButton.Location = New System.Drawing.Point(160, 109)
			Me.rowColorButton.Name = "rowColorButton"
			Me.rowColorButton.Size = New System.Drawing.Size(88, 24)
			Me.rowColorButton.TabIndex = 10
'			Me.rowColorButton.ColorChanged += New System.EventHandler(Me.rowColorButton_ColorChanged);
			' 
			' shadeColorCheck
			' 
			Me.shadeColorCheck.ButtonProperties.BorderOffset = 2
			Me.shadeColorCheck.Location = New System.Drawing.Point(64, 77)
			Me.shadeColorCheck.Name = "shadeColorCheck"
			Me.shadeColorCheck.Size = New System.Drawing.Size(88, 24)
			Me.shadeColorCheck.TabIndex = 9
			Me.shadeColorCheck.Text = "Shade Color"
'			Me.shadeColorCheck.CheckedChanged += New System.EventHandler(Me.shadeColorCheck_CheckedChanged);
			' 
			' NListViewUC
			' 
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nListView1)
			Me.Name = "NListViewUC"
			Me.Size = New System.Drawing.Size(536, 436)
			CType(Me.headerSizeNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nListView1 As NListView
		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
		Private WithEvents customScrollCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents customHeaderCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents headerSizeNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private columnHeader4 As System.Windows.Forms.ColumnHeader
		Private WithEvents customItemsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents shadeColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents shadeColorCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents alternateRowsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents rowColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private WithEvents alternateRowColorCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents columnShadingCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents headerStyleCombo As NComboBox
		Private label2 As Label
		Private columnHeader3 As System.Windows.Forms.ColumnHeader

		#End Region
	End Class
End Namespace
