Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Globalization
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NFileLookupUC.
	''' </summary>
	Public Class NFileLookupUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
			fileFilterEdit.Text = NFileDialogFilters.XmlFileFilter
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

		#Region "Event Handlers"

		Private Sub editableCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles editableCheck.CheckedChanged
			If nFileLookup1 Is Nothing Then
				Return
			End If

			If editableCheck.Checked Then
				nFileLookup1.EditorVisibility = EditorVisibility.Show
			Else
				nFileLookup1.EditorVisibility = EditorVisibility.Hide
			End If
		End Sub
		Private Sub indexNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles indexNumeric.ValueChanged
			If nFileLookup1 Is Nothing Then
				Return
			End If

			nFileLookup1.DisplayIndex = CInt(Fix(indexNumeric.Value))
		End Sub

		Private Sub fileFilterEdit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fileFilterEdit.TextChanged
			nFileLookup1.FileFilter = fileFilterEdit.Text
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nFileLookup1 = New Nevron.UI.WinForm.Controls.NFileLookup()
			Me.editableCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nEntryContainer1 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.fileFilterEdit = New System.Windows.Forms.TextBox()
			Me.nEntryContainer2 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.indexNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer1.SuspendLayout()
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer2.SuspendLayout()
			CType(Me.indexNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nFileLookup1
			' 
			Me.nFileLookup1.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nFileLookup1.ForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nFileLookup1.Location = New System.Drawing.Point(8, 8)
			Me.nFileLookup1.Name = "nFileLookup1"
			Me.nFileLookup1.Size = New System.Drawing.Size(280, 24)
			Me.nFileLookup1.TabIndex = 0
			' 
			' editableCheck
			' 
			Me.editableCheck.ButtonProperties.BorderOffset = 2
			Me.editableCheck.Checked = True
			Me.editableCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.editableCheck.Location = New System.Drawing.Point(8, 120)
			Me.editableCheck.Name = "editableCheck"
			Me.editableCheck.TabIndex = 3
			Me.editableCheck.Text = "Editable"
'			Me.editableCheck.CheckedChanged += New System.EventHandler(Me.editableCheck_CheckedChanged);
			' 
			' nEntryContainer1
			' 
			Me.nEntryContainer1.ClientPadding = New Nevron.UI.NPadding(0)
			Me.nEntryContainer1.EntryControl = Me.fileFilterEdit
			Me.nEntryContainer1.Item.Style.TextRenderMode = Nevron.UI.TextRenderMode.Gdi
			Me.nEntryContainer1.LabelSize = New System.Drawing.Size(80, 0)
			Me.nEntryContainer1.Location = New System.Drawing.Point(8, 40)
			Me.nEntryContainer1.Name = "nEntryContainer1"
			Me.nEntryContainer1.Size = New System.Drawing.Size(280, 32)
			Me.nEntryContainer1.StrokeInfo.Rounding = 5
			Me.nEntryContainer1.TabIndex = 1
			Me.nEntryContainer1.Text = "File Filter:"
			' 
			' fileFilterEdit
			' 
			Me.fileFilterEdit.BackColor = System.Drawing.Color.FromArgb((CByte(245)), (CByte(245)), (CByte(245)))
			Me.fileFilterEdit.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.fileFilterEdit.ForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.fileFilterEdit.Location = New System.Drawing.Point(92, 7)
			Me.fileFilterEdit.Name = "fileFilterEdit"
			Me.fileFilterEdit.Size = New System.Drawing.Size(177, 13)
			Me.fileFilterEdit.TabIndex = 0
			Me.fileFilterEdit.Text = ""
'			Me.fileFilterEdit.TextChanged += New System.EventHandler(Me.fileFilterEdit_TextChanged);
			' 
			' nEntryContainer2
			' 
			Me.nEntryContainer2.ClientPadding = New Nevron.UI.NPadding(0)
			Me.nEntryContainer2.EntryControl = Me.indexNumeric
			Me.nEntryContainer2.Item.Style.TextRenderMode = Nevron.UI.TextRenderMode.Gdi
			Me.nEntryContainer2.LabelSize = New System.Drawing.Size(80, 0)
			Me.nEntryContainer2.Location = New System.Drawing.Point(8, 80)
			Me.nEntryContainer2.Name = "nEntryContainer2"
			Me.nEntryContainer2.Size = New System.Drawing.Size(208, 32)
			Me.nEntryContainer2.StrokeInfo.Rounding = 5
			Me.nEntryContainer2.TabIndex = 2
			Me.nEntryContainer2.TabStop = False
			Me.nEntryContainer2.Text = "Display Index:"
			' 
			' indexNumeric
			' 
			Me.indexNumeric.Border.Style = Nevron.UI.BorderStyle3D.None
			Me.indexNumeric.Location = New System.Drawing.Point(92, 6)
			Me.indexNumeric.Name = "indexNumeric"
			Me.indexNumeric.Size = New System.Drawing.Size(105, 14)
			Me.indexNumeric.TabIndex = 0
'			Me.indexNumeric.ValueChanged += New System.EventHandler(Me.indexNumeric_ValueChanged);
			' 
			' NFileLookupUC
			' 
			Me.Controls.Add(Me.nEntryContainer2)
			Me.Controls.Add(Me.nEntryContainer1)
			Me.Controls.Add(Me.editableCheck)
			Me.Controls.Add(Me.nFileLookup1)
			Me.Name = "NFileLookupUC"
			Me.Size = New System.Drawing.Size(344, 216)
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer1.ResumeLayout(False)
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer2.ResumeLayout(False)
			CType(Me.indexNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nFileLookup1 As Nevron.UI.WinForm.Controls.NFileLookup
		Private WithEvents editableCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nEntryContainer1 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private WithEvents fileFilterEdit As System.Windows.Forms.TextBox
		Private nEntryContainer2 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private WithEvents indexNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown

		#End Region
	End Class
End Namespace
