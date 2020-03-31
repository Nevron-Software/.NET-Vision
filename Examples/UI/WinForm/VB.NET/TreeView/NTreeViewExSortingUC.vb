Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExSortingUC
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

			m_Tree = New NTreeViewEx()
			m_Tree.Dock = DockStyle.Fill

			NTreeViewExUC.AddTestNodes(m_Tree, 5, 2)

			m_Tree.ExpandAll()

			m_Tree.Parent = containerPanel
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub sortAscendingBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles sortAscendingBtn.Click
			m_Tree.Nodes.Sort(True, Me.recursiveSortCheck.Checked)
		End Sub
		Private Sub sortDescendingBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles sortDescendingBtn.Click
			m_Tree.Nodes.Sort(False, Me.recursiveSortCheck.Checked)
		End Sub

		#End Region

		#Region "Fields"

		Friend m_Tree As NTreeViewEx

		#End Region
	End Class
End Namespace
