Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NSelectionUC.
	''' </summary>
	Public Class NSelectionUC
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.selectionAnchorCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.selectionModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.permissionsGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.deleteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.copyCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.selectCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.permissionsGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 152)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 24)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Selection anchor:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' selectionAnchorCombo
			' 
			Me.selectionAnchorCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.selectionAnchorCombo.Location = New System.Drawing.Point(120, 152)
			Me.selectionAnchorCombo.Name = "selectionAnchorCombo"
			Me.selectionAnchorCombo.Size = New System.Drawing.Size(120, 21)
			Me.selectionAnchorCombo.TabIndex = 4
'			Me.selectionAnchorCombo.SelectedIndexChanged += New System.EventHandler(Me.selectionAnchorCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 118)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(88, 24)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Selection mode:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' selectionModeCombo
			' 
			Me.selectionModeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.selectionModeCombo.Location = New System.Drawing.Point(120, 120)
			Me.selectionModeCombo.Name = "selectionModeCombo"
			Me.selectionModeCombo.Size = New System.Drawing.Size(122, 21)
			Me.selectionModeCombo.TabIndex = 2
'			Me.selectionModeCombo.SelectedIndexChanged += New System.EventHandler(Me.selectionModeCombo_SelectedIndexChanged);
			' 
			' permissionsGroupBox
			' 
			Me.permissionsGroupBox.Controls.Add(Me.deleteCheckBox)
			Me.permissionsGroupBox.Controls.Add(Me.copyCheckBox)
			Me.permissionsGroupBox.Controls.Add(Me.selectCheckBox)
			Me.permissionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.permissionsGroupBox.ImageIndex = 0
			Me.permissionsGroupBox.Location = New System.Drawing.Point(8, 8)
			Me.permissionsGroupBox.Name = "permissionsGroupBox"
			Me.permissionsGroupBox.Size = New System.Drawing.Size(234, 104)
			Me.permissionsGroupBox.TabIndex = 0
			Me.permissionsGroupBox.TabStop = False
			Me.permissionsGroupBox.Text = "Selected shape protection"
			' 
			' deleteCheckBox
			' 
			Me.deleteCheckBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.deleteCheckBox.Location = New System.Drawing.Point(8, 72)
			Me.deleteCheckBox.Name = "deleteCheckBox"
			Me.deleteCheckBox.Size = New System.Drawing.Size(218, 24)
			Me.deleteCheckBox.TabIndex = 2
			Me.deleteCheckBox.Text = "From delete"
'			Me.deleteCheckBox.CheckStateChanged += New System.EventHandler(Me.protectionCheckBox_CheckStateChanged);
			' 
			' copyCheckBox
			' 
			Me.copyCheckBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.copyCheckBox.Location = New System.Drawing.Point(8, 44)
			Me.copyCheckBox.Name = "copyCheckBox"
			Me.copyCheckBox.Size = New System.Drawing.Size(218, 24)
			Me.copyCheckBox.TabIndex = 1
			Me.copyCheckBox.Text = "From copy"
'			Me.copyCheckBox.CheckStateChanged += New System.EventHandler(Me.protectionCheckBox_CheckStateChanged);
			' 
			' selectCheckBox
			' 
			Me.selectCheckBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.selectCheckBox.Location = New System.Drawing.Point(8, 16)
			Me.selectCheckBox.Name = "selectCheckBox"
			Me.selectCheckBox.Size = New System.Drawing.Size(218, 24)
			Me.selectCheckBox.TabIndex = 0
			Me.selectCheckBox.Text = "From select"
'			Me.selectCheckBox.CheckStateChanged += New System.EventHandler(Me.protectionCheckBox_CheckStateChanged);
			' 
			' NSelectionUC
			' 
			Me.Controls.Add(Me.permissionsGroupBox)
			Me.Controls.Add(Me.selectionModeCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.selectionAnchorCombo)
			Me.Controls.Add(Me.label1)
			Me.DockPadding.All = 8
			Me.Name = "NSelectionUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.selectionAnchorCombo, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.Controls.SetChildIndex(Me.selectionModeCombo, 0)
			Me.Controls.SetChildIndex(Me.permissionsGroupBox, 0)
			Me.permissionsGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init document
			document.BeginInit()
			CreateDefaultFlowDiagram()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub ResetExample()
			view.Reset()
			MyBase.ResetExample()
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

		Private Sub InitFormControls()
			PauseEventsHandling()

			selectionAnchorCombo.ListProperties.ColumnOnLeft = False
			selectionModeCombo.ListProperties.ColumnOnLeft = False

			selectionAnchorCombo.FillFromEnum(GetType(SelectionAnchorMode))
			selectionAnchorCombo.SelectedItem = view.Selection.AnchorMode

			selectionModeCombo.FillFromEnum(GetType(DiagramSelectionMode))
			selectionModeCombo.SelectedItem = view.Selection.Mode

			ResumeEventsHandling()
		End Sub

		Private Sub UpdateControlsState()
			If view.Selection.NodesCount <> 1 Then
				permissionsGroupBox.Enabled = False
				Return
			End If

			permissionsGroupBox.Enabled = True
		End Sub

		Private Sub UpdateFromSelectedNode()
			' get the selected element
			Dim element As NDiagramElement = (TryCast(view.Selection.AnchorNode, NDiagramElement))
			If element Is Nothing Then
				Return
			End If

			' update the protection checks
			Dim protection As NAbilities = element.Protection

			copyCheckBox.Checked = protection.Copy
			deleteCheckBox.Checked = protection.Delete
			selectCheckBox.Checked = protection.Select
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub selectionAnchorCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectionAnchorCombo.SelectedIndexChanged
			' change the view selection anchor mode
			view.Selection.AnchorMode = CType(selectionAnchorCombo.SelectedIndex, SelectionAnchorMode)
			view.Refresh()
		End Sub

		Private Sub selectionModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectionModeCombo.SelectedIndexChanged
			' change the view selection mode
			view.Selection.Mode = CType(selectionModeCombo.SelectedIndex, DiagramSelectionMode)
			view.Refresh()
		End Sub

		Private Sub protectionCheckBox_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles deleteCheckBox.CheckStateChanged, copyCheckBox.CheckStateChanged, selectCheckBox.CheckStateChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected element
			Dim element As NDiagramElement = (TryCast(view.Selection.AnchorNode, NDiagramElement))
			If element Is Nothing Then
				Return
			End If

			PauseEventsHandling()

			' update the element protection
			Dim protection As NAbilities = element.Protection

			protection.Copy = copyCheckBox.Checked
			protection.Delete = deleteCheckBox.Checked
			protection.Select = selectCheckBox.Checked

			element.Protection = protection

			document.SmartRefreshAllViews()
			ResumeEventsHandling()
		End Sub


		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			Try
				UpdateControlsState()
				UpdateFromSelectedNode()
			Finally
				ResumeEventsHandling()
			End Try
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			Try
				UpdateControlsState()
				UpdateFromSelectedNode()
			Finally
				ResumeEventsHandling()
			End Try
		End Sub


		#End Region

		#Region "Designer Fields"

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents selectionAnchorCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents selectionModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents copyCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents deleteCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents selectCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private permissionsGroupBox As Nevron.UI.WinForm.Controls.NGroupBox

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
