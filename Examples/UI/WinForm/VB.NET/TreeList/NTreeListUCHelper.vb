Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm


Namespace Nevron.Examples.UI.WinForm
	Friend Class NTreeListUCHelper
		#Region "Constructor"

		Friend Sub New()
			m_Images = NResourceHelper.ImageListFromBitmap(Me.GetType(), New Size(16, 16), Color.Transparent, "Outlook.jpg", "Nevron.Examples.UI.WinForm.TreeList.Images")
			m_arrNames = New String() { "John Doe", "support@nevron.com", "sales@nevron.com", "mail@nevron.com" }
			m_arrSubjects = New String() { "NTreeList Question", "Re: Help Needed", "Licensing Question", "Nevron UI General Support" }
		End Sub

		#End Region

		#Region "Implementation"

		Friend Sub Dispose()
			m_Images.Dispose()
		End Sub
		Friend Sub Populate(ByVal list As NTreeList)
			m_List = list
			m_List.Suspend()

			InitData()

			m_List.GroupBy(m_List.Columns("Received"))
			m_List.SortColumn(m_List.Columns("Received"), TreeListSortMode.Descending)
			m_List.SortColumn(m_List.Columns("From"), TreeListSortMode.Ascending)

			m_List.ExpandAll()
			m_List.BestFitAllColumns()
			m_List.BestFitAllNodes()


			m_List.Resume(True)
		End Sub

		Friend Sub InitData()
			InitColumns()
			InitRows()
		End Sub
		Friend Sub InitColumns()
			Dim col As NTreeListColumn

			'importance columns
			col = New NTreeListColumn()
			col.Name = "Importance"
			col.Header.Image = m_Images.Images(1)
			col.Header.ImageAlign = ContentAlignment.MiddleCenter
			col.ContentAlign = ContentAlignment.MiddleCenter
			col.AutoSizable = False
			col.Header.TooltipInfo.ContentText = "Importance"
			m_List.Columns.Add(col)

			'icon column
			col = New NTreeListColumn()
			col.Name = "Icon"
			col.Header.TooltipInfo.ContentText = "Message Class"
			col.Header.Image = m_Images.Images(0)
			col.Header.ImageAlign = ContentAlignment.MiddleCenter
			col.AutoSizable = False
			m_List.Columns.Add(col)

			'from column
			col = New NTreeListColumn()
			col.Name = "From"
			col.Header.Text = "From"
			col.Header.TooltipInfo.ContentText = "From"
			m_List.Columns.Add(col)

			'subject column
			col = New NTreeListColumn()
			col.Name = "Subject"
			col.Header.Text = "Subject"
			col.Header.TooltipInfo.ContentText = "Subject"
			m_List.Columns.Add(col)

			'received column
			col = New NTreeListColumn()
			col.Name = "Received"
			col.Header.Text = "Received"
			col.Header.TooltipInfo.ContentText = "Received"
			m_List.Columns.Add(col)

			'follow-up column
			col = New NTreeListColumn()
			col.AutoSizable = False
			col.Header.Image = m_Images.Images(2)
			col.Header.ImageAlign = ContentAlignment.MiddleCenter
			col.Name = "FollowUp"
			col.Header.Text = "Follow-up"
			col.Header.TooltipInfo.ContentText = "Follow-up"
			m_List.Columns.Add(col)

			'test column
			col = New NTreeListColumn()
			col.AutoSizable = False
			col.Width = 150
			col.Name = "PurchaseAmount"
			col.Header.Text = "Purchase Amount"
			col.Header.TooltipInfo.ContentText = "Purchase Amount"
			m_List.Columns.Add(col)
		End Sub
		Friend Sub InitRows()
			Dim node As NTreeListNode
			Dim date1 As DateTime = New DateTime(2007, 11, 12)
			Dim date2 As DateTime = New DateTime(2007, 11, 13)

			Dim testFont As Font = New Font("Segoe UI", 9, FontStyle.Italic Or FontStyle.Bold)
			Dim testFont1 As Font = New Font("Calibri", 8, FontStyle.Italic Or FontStyle.Underline)
			Dim testFill As NFillInfo = New NFillInfo()
			testFill.Gradient1 = Color.OrangeRed
			testFill.Gradient2 = Color.Yellow
			testFill.GradientStyle = GradientStyle.SigmaBell

			Dim testTextFill As NFillInfo = New NFillInfo()
			testTextFill.FillStyle = FillStyle.Solid
			testTextFill.Color = Color.Navy

			For i As Integer = 1 To 200
				node = New NTreeListNode()

				'init items
				'importance sub-item
				Dim importanceItem As NTreeListNodeImageSubItem = New NTreeListNodeImageSubItem()
				If (i Mod 2 = 0) Then
					importanceItem.Image = m_Images.Images(6)
				Else
					importanceItem.Image = m_Images.Images(1)
				End If
				importanceItem.Column = m_List.Columns("Importance")
				importanceItem.CompareData = i Mod 2
				importanceItem.GroupByData = i Mod 2
				If i Mod 2 = 0 Then
					importanceItem.GroupByTitle = "Importance: High"
				Else
					importanceItem.GroupByTitle = "Importance: Normal"
				End If
				node.SubItems.Add(importanceItem)

				'icon sub-item
				Dim iconItem As NTreeListNodeImageSubItem = New NTreeListNodeImageSubItem()
				iconItem.Image = m_Images.Images(3 + (i Mod 2))
				iconItem.Column = m_List.Columns("Icon")
				iconItem.CompareData = i Mod 2
				iconItem.GroupByData = i Mod 2
				If i Mod 2 = 0 Then
					iconItem.GroupByTitle = "Message class: New Message"
				Else
					iconItem.GroupByTitle = "Message class: Message"
				End If
				node.SubItems.Add(iconItem)

				'from sub-item
				Dim fromItem As NTreeListNodeStringSubItem = New NTreeListNodeStringSubItem()
				fromItem.Text = m_arrNames(i Mod 4)
				fromItem.Column = m_List.Columns("From")
				fromItem.Font = testFont
				'fromItem.FillInfo = testFill;
				fromItem.TextFillInfo = testTextFill
				node.SubItems.Add(fromItem)

				'subject sub-item
				Dim subjectItem As NTreeListNodeStringSubItem = New NTreeListNodeStringSubItem()
				subjectItem.Text = m_arrSubjects(i Mod 4)
				subjectItem.Column = m_List.Columns("Subject")
				node.SubItems.Add(subjectItem)

				'received sub-item
				Dim receivedItem As NTreeListNodeDateTimeSubItem = New NTreeListNodeDateTimeSubItem()
				If i Mod 2 = 0 Then
					receivedItem.Value = date1
					receivedItem.GroupByTitle = "Date: Yesterday"
				Else
					receivedItem.Value = date2
					receivedItem.GroupByTitle = "Date: Today"
				End If
				receivedItem.FormatString = "F"
				receivedItem.Column = m_List.Columns("Received")
				receivedItem.Font = testFont1
				node.SubItems.Add(receivedItem)

				'follow-up sub-item
				Dim followItem As NTreeListNodeBooleanSubItem = New NTreeListNodeBooleanSubItem()
				If i Mod 2 = 0 Then
					followItem.Value = False
					followItem.GroupByTitle = "Follow-up: No"
				Else
					followItem.Value = True
					followItem.GroupByTitle = "Follow-up: Yes"
				End If
				followItem.Column = m_List.Columns("FollowUp")
				node.SubItems.Add(followItem)

				'numeric sub-item
				Dim numItem As NTreeListNodeNumericSubItem = New NTreeListNodeNumericSubItem()
				numItem.Value = i * 10
				numItem.FormatString = "$#,###0.00"
				numItem.Column = m_List.Columns("PurchaseAmount")
				node.SubItems.Add(numItem)

				m_List.Nodes.Add(node)
			Next i
		End Sub

		#End Region

		#Region "Fields"

		Friend m_List As NTreeList
		Friend m_Images As ImageList
		Friend m_arrNames As String()
		Friend m_arrSubjects As String()

		#End Region
	End Class
End Namespace
