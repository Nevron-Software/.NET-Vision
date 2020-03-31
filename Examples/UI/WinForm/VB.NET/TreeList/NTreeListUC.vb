Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeListUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Dock = DockStyle.Fill

			m_List = New NTreeList()
			m_List.Dock = DockStyle.Fill
			m_List.Parent = containerPanel
		End Sub

		#End Region

		#Region "Public Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_List.Suspend()

			InitColumns()
			InitNodes()

			propertyGrid1.SelectedObject = m_List

			m_List.AutoSizeColumns = False
			m_List.NotesStyle = TreeListNodeNotesStyle.Show

			m_List.BestFitAllColumns()
			m_List.BestFitAllNodes()

			m_List.Resume(True)
		End Sub

		#End Region

		#Region "Implementation"

		Friend Sub InitColumns()
			Dim column As NTreeListColumn

			For i As Integer = 1 To 5
				column = New NTreeListColumn()
				If i = 1 Then
					column.PinMode = TreeListColumnPinMode.Left
				End If

				column.Name = "Col" & i
				column.Header.Text = "Column " & i

				m_List.Columns.Add(column)
			Next i
		End Sub
		Friend Sub InitNodes()
			Dim node1 As NTreeListNode
			Dim item As NTreeListNodeStringSubItem

			Dim nodeCount As Integer = 1

			For i As Integer = 1 To 100
				node1 = New NTreeListNode()

				For j As Integer = 1 To 5
					item = New NTreeListNodeStringSubItem()
					item.Text = "SubItem; Col: " & j & ", Row: " & nodeCount
					item.Column = m_List.Columns("Col" & j)

					node1.SubItems.Add(item)
				Next j

				nodeCount += 1
				m_List.Nodes.Add(node1)
			Next i
		End Sub

		#End Region

		#Region "Static"

		Friend Shared Sub InitDefaultColumns(ByVal list As NTreeList)
			Dim column As NTreeListColumn

			'text column
			column = New NTreeListColumn()
			column.Name = "StringColumn"
			column.Header.Text = "String Column"
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 150
			list.Columns.Add(column)

			'image column
			column = New NTreeListColumn()
			column.Name = "ImageColumn"
			column.Header.Text = "Image Column"
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 100
			list.Columns.Add(column)

			'numeric column
			column = New NTreeListColumn()
			column.Name = "NumColumn"
			column.Header.Text = "Numeric Column"
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 100
			list.Columns.Add(column)

			'date-time column
			column = New NTreeListColumn()
			column.Name = "DateColumn"
			column.Header.Text = "Date Column"
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 200
			list.Columns.Add(column)

			'boolean column
			column = New NTreeListColumn()
			column.Name = "BoolColumn"
			column.Header.Text = "Boolean Column"
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 100
			list.Columns.Add(column)
		End Sub
		Friend Shared Sub InitDefaultNodes(ByVal list As NTreeList, ByVal nodeCount As Integer)
			Dim node As NTreeListNode

			Dim ticks As Long = DateTime.Now.Ticks

			Dim i As Integer = 1
			Do While i < nodeCount
				node = New NTreeListNode()

				'text sub-item
				Dim stringItem As NTreeListNodeStringSubItem = New NTreeListNodeStringSubItem()
				stringItem.Text = "String SubItem " & i
				stringItem.Column = list.Columns(0)
				node.SubItems.Add(stringItem)

				'image sub-item
				Dim imageItem As NTreeListNodeImageSubItem = New NTreeListNodeImageSubItem()
				imageItem.Image = NSystemImages.Information
				imageItem.Column = list.Columns(1)
				node.SubItems.Add(imageItem)

				'numeric sub-item
				Dim numItem As NTreeListNodeNumericSubItem = New NTreeListNodeNumericSubItem()
				numItem.Value = i * 10
				numItem.FormatString = "$#,###0.00"
				numItem.Column = list.Columns(2)
				node.SubItems.Add(numItem)

				'date sub-item
				Dim dateItem As NTreeListNodeDateTimeSubItem = New NTreeListNodeDateTimeSubItem()
				dateItem.Value = New DateTime(ticks + i * 10000000)
				dateItem.FormatString = "F"
				dateItem.Column = list.Columns(3)
				node.SubItems.Add(dateItem)

				'bool sub-item
				Dim boolItem As NTreeListNodeBooleanSubItem = New NTreeListNodeBooleanSubItem()
				boolItem.Value = (i Mod 2) = 0
				boolItem.Column = list.Columns(4)
				node.SubItems.Add(boolItem)

				list.Nodes.Add(node)
				i += 1
			Loop
		End Sub
		Friend Shared Sub InitDefaultList(ByVal list As NTreeList, ByVal nodeCount As Integer)
			InitDefaultColumns(list)
			InitDefaultNodes(list, nodeCount)
		End Sub

		#End Region

		#Region "Fields"

		Friend m_List As NTreeList

		#End Region
	End Class
End Namespace
