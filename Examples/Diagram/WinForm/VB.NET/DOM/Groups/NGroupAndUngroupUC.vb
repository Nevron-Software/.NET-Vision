Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing

Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NGroupsUC.
	''' </summary>
	Public Class NGroupAndUngroupUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.selectedGroupsActionsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.protectFromUngroupCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ungroupToParentGroupButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ungroupToLayerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.protectFromGroupCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.selectedShapesActionsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.selectedGroupsActionsGroup.SuspendLayout()
			Me.selectedShapesActionsGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' selectedGroupsActionsGroup
			' 
			Me.selectedGroupsActionsGroup.Controls.Add(Me.protectFromUngroupCheckBox)
			Me.selectedGroupsActionsGroup.Controls.Add(Me.ungroupToParentGroupButton)
			Me.selectedGroupsActionsGroup.Controls.Add(Me.ungroupToLayerButton)
			Me.selectedGroupsActionsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectedGroupsActionsGroup.ImageIndex = 0
			Me.selectedGroupsActionsGroup.Location = New System.Drawing.Point(0, 0)
			Me.selectedGroupsActionsGroup.Name = "selectedGroupsActionsGroup"
			Me.selectedGroupsActionsGroup.Size = New System.Drawing.Size(250, 144)
			Me.selectedGroupsActionsGroup.TabIndex = 0
			Me.selectedGroupsActionsGroup.TabStop = False
			Me.selectedGroupsActionsGroup.Text = "Selected group actions"
			' 
			' protectFromUngroupCheckBox
			' 
			Me.protectFromUngroupCheckBox.Location = New System.Drawing.Point(8, 96)
			Me.protectFromUngroupCheckBox.Name = "protectFromUngroupCheckBox"
			Me.protectFromUngroupCheckBox.Size = New System.Drawing.Size(170, 24)
			Me.protectFromUngroupCheckBox.TabIndex = 2
			Me.protectFromUngroupCheckBox.Text = "Protect from ungroup"
'			Me.protectFromUngroupCheckBox.CheckedChanged += New System.EventHandler(Me.protectFromUngroupCheckBox_CheckedChanged);
			' 
			' ungroupToParentGroupButton
			' 
			Me.ungroupToParentGroupButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ungroupToParentGroupButton.Enabled = False
			Me.ungroupToParentGroupButton.Location = New System.Drawing.Point(8, 60)
			Me.ungroupToParentGroupButton.Name = "ungroupToParentGroupButton"
			Me.ungroupToParentGroupButton.Size = New System.Drawing.Size(232, 24)
			Me.ungroupToParentGroupButton.TabIndex = 1
			Me.ungroupToParentGroupButton.Text = "Ungroup to Parent Group"
'			Me.ungroupToParentGroupButton.Click += New System.EventHandler(Me.ungroupToParentGroupButton_Click);
			' 
			' ungroupToLayerButton
			' 
			Me.ungroupToLayerButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ungroupToLayerButton.Enabled = False
			Me.ungroupToLayerButton.Location = New System.Drawing.Point(8, 24)
			Me.ungroupToLayerButton.Name = "ungroupToLayerButton"
			Me.ungroupToLayerButton.Size = New System.Drawing.Size(232, 24)
			Me.ungroupToLayerButton.TabIndex = 0
			Me.ungroupToLayerButton.Text = "Ungroup to Active Layer"
'			Me.ungroupToLayerButton.Click += New System.EventHandler(Me.ungroupToLayerButton_Click);
			' 
			' groupButton
			' 
			Me.groupButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.groupButton.Enabled = False
			Me.groupButton.Location = New System.Drawing.Point(8, 24)
			Me.groupButton.Name = "groupButton"
			Me.groupButton.Size = New System.Drawing.Size(232, 24)
			Me.groupButton.TabIndex = 0
			Me.groupButton.Text = "Group"
'			Me.groupButton.Click += New System.EventHandler(Me.groupButton_Click);
			' 
			' protectFromGroupCheckBox
			' 
			Me.protectFromGroupCheckBox.Location = New System.Drawing.Point(8, 56)
			Me.protectFromGroupCheckBox.Name = "protectFromGroupCheckBox"
			Me.protectFromGroupCheckBox.Size = New System.Drawing.Size(170, 24)
			Me.protectFromGroupCheckBox.TabIndex = 1
			Me.protectFromGroupCheckBox.Text = "Protect from group"
'			Me.protectFromGroupCheckBox.CheckedChanged += New System.EventHandler(Me.protectFromGroupCheckBox_CheckedChanged);
			' 
			' selectedShapesActionsGroup
			' 
			Me.selectedShapesActionsGroup.Controls.Add(Me.protectFromGroupCheckBox)
			Me.selectedShapesActionsGroup.Controls.Add(Me.groupButton)
			Me.selectedShapesActionsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectedShapesActionsGroup.ImageIndex = 0
			Me.selectedShapesActionsGroup.Location = New System.Drawing.Point(0, 144)
			Me.selectedShapesActionsGroup.Name = "selectedShapesActionsGroup"
			Me.selectedShapesActionsGroup.Size = New System.Drawing.Size(250, 88)
			Me.selectedShapesActionsGroup.TabIndex = 1
			Me.selectedShapesActionsGroup.TabStop = False
			Me.selectedShapesActionsGroup.Text = "Selected shapes actions"
			' 
			' NGroupAndUngroupUC
			' 
			Me.Controls.Add(Me.selectedShapesActionsGroup)
			Me.Controls.Add(Me.selectedGroupsActionsGroup)
			Me.Name = "NGroupAndUngroupUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.selectedGroupsActionsGroup, 0)
			Me.Controls.SetChildIndex(Me.selectedShapesActionsGroup, 0)
			Me.selectedGroupsActionsGroup.ResumeLayout(False)
			Me.selectedShapesActionsGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			MyBase.DefaultGridOrigin = New NPointF(40, 40)
			MyBase.DefaultGridCellSize = New NSizeF(70, 60)

			' begin view init
			view.BeginInit()

			' init view
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

			' init document
			document.BeginInit()

			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None

			InitDocument()

			' end document initialization
			document.EndInit()

			' end view init
			view.EndInit()

			UpdateControlsState()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.DetachFromEvents()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub UpdateControlsState()
			PauseEventsHandling()

			' get the selected nodes
			Dim selectedNodes As NNodeList = view.Selection.Nodes

			If selectedNodes.Count = 0 Then
				' if not nodes are selected - disable form controls
				selectedGroupsActionsGroup.Enabled = False
				selectedShapesActionsGroup.Enabled = False
			ElseIf selectedNodes.Count = 1 Then
				' if the selected node is a group
				Dim group As NGroup = (TryCast(view.Selection.AnchorNode, NGroup))
				If Not group Is Nothing Then
					selectedGroupsActionsGroup.Enabled = True

					' check whether the group can be ungrouped to layer
					Dim batchUngroup As NBatchUngroup = New NBatchUngroup(document, selectedNodes)
					ungroupToLayerButton.Enabled = batchUngroup.CanUngroup(document.ActiveLayer, False)

					' check whether the group can be ungrouped to a parent group
					Dim parentGroup As NGroup = group.Group
					If Not parentGroup Is Nothing Then
						ungroupToParentGroupButton.Enabled = batchUngroup.CanUngroup(parentGroup, False)
					Else
						ungroupToParentGroupButton.Enabled = False
					End If

					' update the protect from ungroup check button
					protectFromUngroupCheckBox.Enabled = True
					protectFromUngroupCheckBox.Checked = group.Protection.Ungroup
				Else
					selectedGroupsActionsGroup.Enabled = False
				End If

				' if the selected node is a shape
				Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
				If Not shape Is Nothing Then
					selectedShapesActionsGroup.Enabled = True

					' check whether the selected shape can be grouped
					Dim batchGroup As NBatchGroup = New NBatchGroup(document, selectedNodes)
					groupButton.Enabled = batchGroup.CanGroup(document.ActiveLayer, False)

					' update the protect from group check button
					protectFromGroupCheckBox.Enabled = True
					protectFromGroupCheckBox.Checked = shape.Protection.Group
				Else
					selectedShapesActionsGroup.Enabled = False
				End If
			Else
				' multiple nodes are selected
				selectedGroupsActionsGroup.Enabled = True
				selectedShapesActionsGroup.Enabled = True

				' update ungroup buttons
				Dim batchUngroup As NBatchUngroup = New NBatchUngroup(document, selectedNodes)
				ungroupToLayerButton.Enabled = batchUngroup.CanUngroup(document.ActiveLayer, False)
				ungroupToParentGroupButton.Enabled = False

				' update group button
				Dim batchGroup As NBatchGroup = New NBatchGroup(document, selectedNodes)
				groupButton.Enabled = batchGroup.CanGroup(document.ActiveLayer, False)

				' disable protection checks
				protectFromUngroupCheckBox.Enabled = True
				protectFromGroupCheckBox.Enabled = False
			End If

			MyBase.ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			Dim color1 As Color = Color.FromArgb(25, 0, &Haa, &Haa)
			Dim color2 As Color = Color.FromArgb(150, 0, 0, 204)

			Dim group As NGroup = New NGroup()

			' create the group frame
			Dim bounds As NRectangleF = MyBase.GetGridCell(0, 0, 2, 3)
			Dim frame As NRectangleShape = New NRectangleShape(bounds)
			frame.Protection = New NAbilities(AbilitiesMask.Select)
			frame.Style.FillStyle = New NColorFillStyle(color1)
			group.Shapes.AddChild(frame)

			' add some shape to the group
			group.Shapes.AddChild(New NRectangleShape(MyBase.GetGridCell(0, 2)))
			group.Shapes.AddChild(New NEllipseShape(MyBase.GetGridCell(0, 3)))
			group.Shapes.AddChild(New NTextShape("Parent group", GetGridCell(2, 0, 0, 3)))

			' add the child group in the group
			group.Shapes.AddChild(CreateChildGroup())

			' update the group model bounds
			group.UpdateModelBounds()

			' apply styles to the group
			group.Style.FillStyle = New NColorFillStyle(color2)
			group.Style.StrokeStyle = New NStrokeStyle(color2)
			group.Style.TextStyle = New NTextStyle(New Font("Arial", 10), color2)

			' add the parent group to the active layer
			document.ActiveLayer.AddChild(group)
		End Sub

		Protected Function CreateChildGroup() As NGroup
			Dim color1 As Color = Color.FromArgb(25, 0, &Hbb, &Hbb)
			Dim color2 As Color = Color.FromArgb(150, 0, 204, 0)

			Dim group As NGroup = New NGroup()

			' create the group frame
			Dim bounds As NRectangleF = MyBase.GetGridCell(0, 0, 1, 1)
			Dim frame As NRectangleShape = New NRectangleShape(bounds)
			frame.Protection = New NAbilities(AbilitiesMask.Select)
			frame.Style.FillStyle = New NColorFillStyle(color1)
			group.Shapes.AddChild(frame)

			' create the group shapes
			group.Shapes.AddChild(New NRectangleShape(MyBase.GetGridCell(0, 0)))
			group.Shapes.AddChild(New NEllipseShape(MyBase.GetGridCell(0, 1)))
			group.Shapes.AddChild(New NTextShape("Child group", MyBase.GetGridCell(1, 0, 0, 1)))

			' update the group model bounds
			group.UpdateModelBounds()

			' apply styles to the group
			group.Style.FillStyle = New NColorFillStyle(color2)
			group.Style.StrokeStyle = New NStrokeStyle(1, color2)
			group.Style.TextStyle = New NTextStyle(New Font("Arial", 10), color2)

			Return group
		End Function


		#End Region

		#Region "Event Handlers"

		Private Sub ungroupToLayerButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ungroupToLayerButton.Click
			' create a new batch ungroup and check whether it can be executed
			Dim batchUngroup As NBatchUngroup = New NBatchUngroup(document, view.Selection.Nodes)
			If batchUngroup.CanUngroup(document.ActiveLayer, False) = False Then
				Return
			End If

			' ungroup the selected groups to the active layer
			Dim shapes As NNodeList
			Dim res As NTransactionResult = batchUngroup.Ungroup(document.ActiveLayer, False, shapes)

			' single select the ungrouped shapes if the ungroup was successful
			If res.Succeeded Then
				view.Selection.SingleSelect(shapes)
			End If

			' ask the view to display any information about the transaction status (if it was not completed)
			view.ProcessTransactionResult(res)
		End Sub

		Private Sub ungroupToParentGroupButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ungroupToParentGroupButton.Click
			' get the group and its parent group
			Dim group As NGroup = (TryCast(view.Selection.AnchorNode, NGroup))
			If group Is Nothing Then
				Return
			End If

			Dim parentGroup As NGroup = group.Group
			If parentGroup Is Nothing Then
				Return
			End If

			' create a new batch ungroup and check whether it can be executed
			Dim batchUngroup As NBatchUngroup = New NBatchUngroup(document, view.Selection.Nodes)
			If batchUngroup.CanUngroup(parentGroup, False) = False Then
				Return
			End If

			' ungroup the selected groups to the active layer
			Dim shapes As NNodeList
			Dim res As NTransactionResult = batchUngroup.Ungroup(parentGroup, False, shapes)

			' single select the parent group if the ungroup was successful
			If res.Succeeded Then
				view.Selection.SingleSelect(parentGroup)
			End If

			' ask the view to display any information about the transaction status (if it was not completed)
			view.ProcessTransactionResult(res)
		End Sub

		Private Sub groupButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles groupButton.Click
			' get the selected nodes
			Dim selectedNodes As NNodeList = view.Selection.Nodes

			' determine whether they can be grouped
			Dim batchGroup As NBatchGroup = New NBatchGroup(document, selectedNodes)
			If batchGroup.CanGroup(document.ActiveLayer, False) = False Then
				Return
			End If

			' group them 
			Dim group As NGroup
			Dim res As NTransactionResult = batchGroup.Group(document.ActiveLayer, False, group)

			' single select the new group if the group was successful
			If res.Succeeded Then
				view.Selection.SingleSelect(group)
			End If

			' ask the view to display any information about the transaction status (if it was not completed)
			view.ProcessTransactionResult(res)
		End Sub


		Private Sub protectFromUngroupCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles protectFromUngroupCheckBox.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected group
			Dim group As NGroup = (TryCast(view.Selection.AnchorNode, NGroup))
			If group Is Nothing Then
				Return
			End If

			' change the ungroup protection
			Dim protection As NAbilities = group.Protection
			protection.Ungroup = protectFromUngroupCheckBox.Checked
			group.Protection = protection

			' update form control
			UpdateControlsState()
		End Sub

		Private Sub protectFromGroupCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles protectFromGroupCheckBox.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected shape
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			' change the ungroup protection
			Dim protection As NAbilities = shape.Protection
			protection.Group = protectFromGroupCheckBox.Checked
			shape.Protection = protection

			' update form control
			UpdateControlsState()
		End Sub


		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			UpdateControlsState()
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			UpdateControlsState()
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private selectedGroupsActionsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents ungroupToLayerButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ungroupToParentGroupButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents groupButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents protectFromUngroupCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents protectFromGroupCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private selectedShapesActionsGroup As Nevron.UI.WinForm.Controls.NGroupBox

		#End Region
	End Class
End Namespace