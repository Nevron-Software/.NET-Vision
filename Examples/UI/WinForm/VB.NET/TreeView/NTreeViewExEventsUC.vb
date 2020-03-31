Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExEventsUC
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
			batchUpdatesCheck.Checked = True
			nTreeViewEx1.EnableItemEdit = True

			NTreeViewExUC.AddTestNodes(nTreeViewEx1, 5, 3)
			nTreeViewEx1.ItemCheckStyle = ItemCheckStyle.CheckBox
			AddHandler nTreeViewEx1.ItemNotify, AddressOf nTreeViewEx1_ItemNotify
			nTreeViewEx1.SelectionMode = ItemSelectionMode.MultiExtended

			nTextBox1.WordWrap = False
			nTextBox1.ScrollBars = ScrollBars.Both

			PopulateEventsList(trackNotificationsList, True)
			PopulateEventsList(cancelNotificationList, False)
		End Sub

		#End Region

		#Region "Implementation"

		Friend Sub PopulateEventsList(ByVal list As NListBox, ByVal track As Boolean)
			list.BeginUpdate()
			list.CheckBoxes = True
			list.CheckOnClick = True

			Dim item As NListBoxItem

			item = New NListBoxItem(NTreeViewEx.ItemMouseStateChangingNotifyCode)
			item.Text = "ItemMouseStateChangingNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemMouseStateChangedNotifyCode)
			item.Text = "ItemMouseStateChangedNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemLabelClickNotifyCode)
			item.Checked = track
			item.Text = "ItemLabelClickNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemLabelDoubleClickNotifyCode)
			item.Checked = track
			item.Text = "ItemLabelDoubleClickNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemCheckBoxClickNotifyCode)
			item.Checked = track
			item.Text = "ItemCheckBoxClickNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemCheckStateChangedNotifyCode)
			item.Checked = track
			item.Text = "ItemCheckStateChangedNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemCheckStateChangingNotifyCode)
			item.Checked = track
			item.Text = "ItemCheckStateChangingNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemBeginEditNotifyCode)
			item.Checked = track
			item.Text = "ItemBeginEditNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemEndEditNotifyCode)
			item.Checked = track
			item.Text = "ItemEndEditNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemSelectionRequestNotifyCode)
			item.Text = "ItemSelectionRequestNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemSelectionChangingNotifyCode)
			item.Checked = track
			item.Text = "ItemSelectionChangingNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.ItemSelectionChangedNotifyCode)
			item.Checked = track
			item.Text = "ItemSelectionChangedNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.NodeCollapsedNotifyCode)
			item.Checked = track
			item.Text = "NodeCollapsedNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.NodeCollapsingNotifyCode)
			item.Checked = track
			item.Text = "NodeCollapsingNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.NodeExpandedNotifyCode)
			item.Checked = track
			item.Text = "NodeExpandedNotifyCode"
			list.Items.Add(item)

			item = New NListBoxItem(NTreeViewEx.NodeExpandingNotifyCode)
			item.Checked = track
			item.Text = "NodeExpandingNotifyCode"
			list.Items.Add(item)

			list.EndUpdate()
		End Sub
		Friend Function GetItemByCode(ByVal coll As NListBoxItemCollection, ByVal code As Integer) As NListBoxItem
			Dim count As Integer = coll.Count
			Dim item As NListBoxItem
			Dim itemCode As Integer

			Dim i As Integer = 0
			Do While i < count
				item = coll(i)
				itemCode = CInt(Fix(item.Tag))

				If itemCode = code Then
					Return item
				End If
				i += 1
			Loop

			Return Nothing
		End Function

		#End Region

		#Region "Event Handlers"

		Private Sub clearLogBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearLogBtn.Click
			nTextBox1.Text = String.Empty
		End Sub
		Private Sub batchUpdatesCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles batchUpdatesCheck.CheckedChanged
			nTreeViewEx1.EnableBatchUpdates = batchUpdatesCheck.Checked
		End Sub
		Private Sub nTreeViewEx1_ItemNotify(ByVal sender As Object, ByVal data As NLightUIItemNotifyData)
			Dim codeItem As NListBoxItem = GetItemByCode(cancelNotificationList.Items, data.NotifyCode)
			If Not codeItem Is Nothing Then
				data.Cancel = codeItem.Checked
			End If

			codeItem = GetItemByCode(trackNotificationsList.Items, data.NotifyCode)
			If codeItem Is Nothing OrElse codeItem.Checked = False Then
				Return
			End If

			Dim messageLog As String = "Notification code: " & codeItem.Text
			messageLog &= "; sender: " & data.Sender.ToString()
			messageLog &= "; canceled: " & data.Cancel.ToString()
			messageLog &= Constants.vbCrLf

			Me.nTextBox1.Text += messageLog
		End Sub

		#End Region
	End Class
End Namespace
