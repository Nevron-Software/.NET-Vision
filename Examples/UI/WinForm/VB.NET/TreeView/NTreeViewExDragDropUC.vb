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
	Public Partial Class NTreeViewExDragDropUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dock = DockStyle.Fill

			NTreeViewExUC.AddTestNodes(nTreeViewEx1, 5, 3)

			Me.enableDragCheck.Checked = True
			Me.showHintsCheck.Checked = True
			Me.autoScrollCheck.Checked = True
			Me.expandNodeCheck.Checked = True
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub enableDragCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles enableDragCheck.CheckedChanged
			If enableDragCheck.Checked Then
				nTreeViewEx1.ItemDragDropMode = ItemDragDropMode.Local
			Else
				nTreeViewEx1.ItemDragDropMode = ItemDragDropMode.None
			End If
		End Sub
		Private Sub showHintsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles showHintsCheck.CheckedChanged
			nTreeViewEx1.ShowDragDropHints = showHintsCheck.Checked
		End Sub
		Private Sub autoScrollCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles autoScrollCheck.CheckedChanged
			nTreeViewEx1.EnableDragDropAutoScroll = autoScrollCheck.Checked
		End Sub
		Private Sub expandNodeCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles expandNodeCheck.CheckedChanged
			nTreeViewEx1.ExpandNodeOnDragOver = expandNodeCheck.Checked
		End Sub
		Private Sub expandAllBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles expandAllBtn.Click
			nTreeViewEx1.ExpandAll()
		End Sub
		Private Sub collapseAllBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles collapseAllBtn.Click
			nTreeViewEx1.CollapseAll()
		End Sub

		#End Region
	End Class
End Namespace
