Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeListNotesUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dock = DockStyle.Fill

			m_List = New NTreeList()
			m_List.Dock = DockStyle.Fill
			m_List.NotesStyle = TreeListNodeNotesStyle.Show

			InitColumns()
			InitNodes()

			m_List.BestFitAllNodes()

			m_List.Parent = Me
		End Sub

		#End Region

		#Region "Implementation"

		Friend Sub InitColumns()
			Dim column As NTreeListColumn

			For i As Integer = 1 To 3
				column = New NTreeListColumn()
				column.Name = "Col" & i
				column.Header.Text = "Column " & i

				m_List.Columns.Add(column)
			Next i
		End Sub
		Friend Sub InitNodes()
			Dim node As NTreeListNode
			Dim item As NTreeListNodeStringSubItem

			Dim nodeCount As Integer = 1

			Dim customFill1 As NFillInfo = New NFillInfo()
			customFill1.Gradient1 = NUIManager.Palette.ControlLight
			customFill1.Gradient2 = NUIManager.Palette.ControlDark
			customFill1.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista

			Dim customTextFill1 As NFillInfo = New NFillInfo()
			customTextFill1.Gradient1 = Color.Orange
			customTextFill1.Gradient2 = Color.Black
			customTextFill1.GradientAngle = 0F

			Dim customFont As Font = New Font("Trebuchet MS", 9, FontStyle.Bold)

			For i As Integer = 1 To 20
				node = New NTreeListNode()

				If i Mod 2 = 0 Then
					node.NotesFillInfo = customFill1
					node.NotesTextFillInfo = customTextFill1
					node.NotesFont = customFont
					node.NotesFormat = New NGdiPlusTextFormat(StringAlignment.Near, StringAlignment.Center, HotkeyPrefix.Hide, StringTrimming.EllipsisCharacter, StringFormatFlags.NoWrap)
					node.Notes = "Customized node's notes. You may specify custom back fill, text fill and font for a note." & Constants.vbLf & "You may also control the text formatting of the notes using the 'NotesFormat' property - the notes of this node do not wrap."
				Else
					node.Notes = "Each NTreeListNode may be assigned notes. Notes are treated as a 'non-client' area and do not participate in the node's layout logic."
				End If

				For j As Integer = 1 To 5
					item = New NTreeListNodeStringSubItem()
					item.Text = "SubItem; Col: " & j & ", Row: " & nodeCount
					item.Column = m_List.Columns("Col" & j)

					node.SubItems.Add(item)
				Next j

				nodeCount += 1
				m_List.Nodes.Add(node)
			Next i
		End Sub

		#End Region

		#Region "Fields"

		Friend m_List As NTreeList

		#End Region
	End Class
End Namespace
