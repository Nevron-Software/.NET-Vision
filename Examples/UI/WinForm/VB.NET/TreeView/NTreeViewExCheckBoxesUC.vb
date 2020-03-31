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
	Public Partial Class NTreeViewExCheckBoxesUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nTreeViewEx1.ItemCheckStyle = ItemCheckStyle.CheckBox
			checkStyleCombo.FillFromEnum(GetType(ItemCheckStyle))
			checkStyleCombo.SelectedItem = nTreeViewEx1.ItemCheckStyle
			autoCheck.Checked = nTreeViewEx1.AutoUpdateCheckState

			NTreeViewExUC.AddTestNodes(nTreeViewEx1, 10, 3)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub checkStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkStyleCombo.SelectedIndexChanged
			nTreeViewEx1.ItemCheckStyle = CType(checkStyleCombo.SelectedItem, ItemCheckStyle)
		End Sub
		Private Sub autoCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles autoCheck.CheckedChanged
			nTreeViewEx1.AutoUpdateCheckState = autoCheck.Checked
		End Sub
		Private Sub checkedItemsBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles checkedItemsBtn.Click
			Dim checkedItems As NLightUIItem() = nTreeViewEx1.Nodes.GetItemsByCheckState(ItemCheckState.Checked, True)

			Dim form As NForm = New NForm()
			Dim lb As NListBox = New NListBox()
			lb.Dock = DockStyle.Fill
			lb.Parent = form
			lb.Items.AddRange(checkedItems)
			form.StartPosition = FormStartPosition.CenterParent
			form.ShowDialog(nTreeViewEx1)

			form.Dispose()
		End Sub
		Private Sub indeterminateBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles indeterminateBtn.Click
			Dim checkedItems As NLightUIItem() = nTreeViewEx1.Nodes.GetItemsByCheckState(ItemCheckState.Indeterminate, True)

			Dim form As NForm = New NForm()
			Dim lb As NListBox = New NListBox()
			lb.Dock = DockStyle.Fill
			lb.Parent = form
			lb.Items.AddRange(checkedItems)
			form.StartPosition = FormStartPosition.CenterParent
			form.ShowDialog(nTreeViewEx1)

			form.Dispose()
		End Sub

		#End Region
	End Class
End Namespace
