Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Dock = DockStyle.Fill
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Padding = New Padding(2)
			propertyGrid1.SelectedObject = nTreeViewEx1

			AddTestNodes(nTreeViewEx1, 10, 3)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub addChildBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addChildBtn.Click
			Dim focused As NTreeNode = TryCast(nTreeViewEx1.FocusedItem, NTreeNode)
			If focused Is Nothing Then
				Return
			End If

			nTreeViewEx1.Suspend()

			Dim child As NTreeNode = New NTreeNode()
			child.Text = "Child Node " & focused.Nodes.Count
			focused.Nodes.Add(child)
			child.Selected = True

			nTreeViewEx1.Resume(True)
		End Sub
		Private Sub addSiblingBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addSiblingBtn.Click
			Dim focused As NTreeNode = TryCast(nTreeViewEx1.FocusedItem, NTreeNode)
			If focused Is Nothing Then
				Return
			End If

			Dim ownerNodes As NTreeNodeCollection = TryCast(focused.OwnerCollection, NTreeNodeCollection)
			If ownerNodes Is Nothing Then
				Return
			End If

			Dim sibling As NTreeNode = New NTreeNode()
			sibling.Text = "Sibling " & ownerNodes.Count
			ownerNodes.Insert(focused.Index + 1, sibling)
			sibling.Selected = True
		End Sub
		Private Sub addTestNodesBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addTestNodesBtn.Click
			AddTestNodes(nTreeViewEx1, 10, 3)
		End Sub
		Private Sub removeNodeBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles removeNodeBtn.Click
			nTreeViewEx1.Suspend()

			Dim selected As NTreeNode() = nTreeViewEx1.SelectedNodes
			Dim owner As NTreeNodeCollection

			Dim length As Integer = selected.Length
			Dim current As NTreeNode

			Dim i As Integer = 0
			Do While i < length
				current = selected(i)
				owner = TryCast(current.OwnerCollection, NTreeNodeCollection)

				If owner Is Nothing Then
					Continue Do
				End If

				owner.Remove(current)
				i += 1
			Loop

			nTreeViewEx1.Resume(True)
		End Sub
		Private Sub expandAllBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles expandAllBtn.Click
			nTreeViewEx1.ExpandAll()
		End Sub
		Private Sub collapseAllBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles collapseAllBtn.Click
			nTreeViewEx1.CollapseAll()
		End Sub

		#End Region

		#Region "Static"

		Friend Shared Sub AddTestNodes(ByVal tree As NTreeViewEx, ByVal siblingCount As Integer, ByVal depth As Integer)
			tree.Suspend()
			tree.Nodes.Clear()

			Dim node As NTreeNode
			Dim currDepth As Integer = 0
			Dim currCollection As NTreeNodeCollection = tree.Nodes

			Dim i As Integer = 0
			Do While i < siblingCount
				node = New NTreeNode()
				node.Text = "Sample Tree Node " & i & "; Depth: " & currDepth

				currDepth += 1
				AddChildNodes(node.Nodes, siblingCount, currDepth, depth)
				currDepth -= 1

				currCollection.Add(node)
				i += 1
			Loop

			tree.Resume(True)
		End Sub
		Friend Shared Sub AddChildNodes(ByVal collection As NTreeNodeCollection, ByVal siblingCount As Integer, ByRef currDepth As Integer, ByVal depth As Integer)
			Dim node As NTreeNode

			Dim i As Integer = 0
			Do While i < siblingCount
				node = New NTreeNode()
				node.Text = "Sample Tree Node " & i & "; Depth: " & currDepth
				collection.Add(node)

				If currDepth < depth Then
					currDepth += 1
					AddChildNodes(node.Nodes, siblingCount, currDepth, depth)
					currDepth -= 1
				End If
				i += 1
			Loop
		End Sub

		#End Region
	End Class
End Namespace
