Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms

Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NGroupEmptyBehaviourUC.
	''' </summary>
	Public Class NGroupEmptyBehaviourUC
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
			Me.groupPropertiesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.autoDestroyCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.canBeEmptyCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupPropertiesGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupPropertiesGroup
			' 
			Me.groupPropertiesGroup.Controls.Add(Me.autoDestroyCheckBox)
			Me.groupPropertiesGroup.Controls.Add(Me.canBeEmptyCheckBox)
			Me.groupPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupPropertiesGroup.Enabled = False
			Me.groupPropertiesGroup.ImageIndex = 0
			Me.groupPropertiesGroup.Location = New System.Drawing.Point(0, 0)
			Me.groupPropertiesGroup.Name = "groupPropertiesGroup"
			Me.groupPropertiesGroup.Size = New System.Drawing.Size(250, 72)
			Me.groupPropertiesGroup.TabIndex = 31
			Me.groupPropertiesGroup.TabStop = False
			Me.groupPropertiesGroup.Text = "Selected group properties"
			' 
			' autoDestroyCheckBox
			' 
			Me.autoDestroyCheckBox.Location = New System.Drawing.Point(8, 16)
			Me.autoDestroyCheckBox.Name = "autoDestroyCheckBox"
			Me.autoDestroyCheckBox.Size = New System.Drawing.Size(136, 24)
			Me.autoDestroyCheckBox.TabIndex = 28
			Me.autoDestroyCheckBox.Text = "Auto destroy if empty"
'			Me.autoDestroyCheckBox.CheckedChanged += New System.EventHandler(Me.autoDestroyCheckBox_CheckedChanged);
			' 
			' canBeEmptyCheckBox
			' 
			Me.canBeEmptyCheckBox.Location = New System.Drawing.Point(8, 40)
			Me.canBeEmptyCheckBox.Name = "canBeEmptyCheckBox"
			Me.canBeEmptyCheckBox.Size = New System.Drawing.Size(136, 24)
			Me.canBeEmptyCheckBox.TabIndex = 29
			Me.canBeEmptyCheckBox.Text = "Can be empty"
'			Me.canBeEmptyCheckBox.CheckedChanged += New System.EventHandler(Me.canBeEmptyCheckBox_CheckedChanged);
			' 
			' NGroupEmptyBehaviourUC
			' 
			Me.Controls.Add(Me.groupPropertiesGroup)
			Me.Name = "NGroupEmptyBehaviourUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.groupPropertiesGroup, 0)
			Me.groupPropertiesGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Overrides NDiagramExampleUC"

		Protected Overrides Sub LoadExample()
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

		Private Sub InitDocument()
			' change the default document style
			document.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, 0, &Haa, &Haa))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(0, &Haa, &Haa))

			' create the group
			Dim group As NGroup = New NGroup()

			' create ellipse1
			Dim ellipse1 As NEllipseShape = New NEllipseShape(0, 0, 100, 100)
			ellipse1.Text = "1"
			group.Shapes.AddChild(ellipse1)

			' create ellipse2
			Dim ellipse2 As NEllipseShape = New NEllipseShape(150, 0, 100, 100)
			ellipse2.Text = "2"
			group.Shapes.AddChild(ellipse2)

			' create ellipse3
			Dim ellipse3 As NEllipseShape = New NEllipseShape(0, 150, 100, 100)
			ellipse3.Text = "3"
			group.Shapes.AddChild(ellipse3)

			' update the model bounds of the group
			group.UpdateModelBounds()

			' translate the group 
			group.Translate(100, 100)

			' add the group to the active layer
			document.ActiveLayer.AddChild(group)
		End Sub

		Private Sub UpdateControlsState()
			If view.Selection.NodesCount <> 1 Then
				groupPropertiesGroup.Enabled = False
				Return
			End If

			Dim group As NGroup = (TryCast(view.Selection.AnchorNode, NGroup))
			If group Is Nothing Then
				groupPropertiesGroup.Enabled = False
				Return
			End If

			groupPropertiesGroup.Enabled = True

			' update the form controls from the selected group
			canBeEmptyCheckBox.Checked = group.CanBeEmpty
			autoDestroyCheckBox.Checked = group.AutoDestroy
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub autoDestroyCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles autoDestroyCheckBox.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			' update the selected group AutoDestroy property
			Dim group As NGroup = (TryCast(view.Selection.AnchorNode, NGroup))
			If Not group Is Nothing AndAlso group.Shapes.ChildrenCount(Nothing) <> 0 Then
				group.AutoDestroy = autoDestroyCheckBox.Checked
			End If

			ResumeEventsHandling()
		End Sub

		Private Sub canBeEmptyCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles canBeEmptyCheckBox.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			' update the selected group CanBeEmpty property
			Dim group As NGroup = (TryCast(view.Selection.AnchorNode, NGroup))
			If Not group Is Nothing AndAlso group.Shapes.ChildrenCount(Nothing) <> 0 Then
				group.CanBeEmpty = canBeEmptyCheckBox.Checked
			End If

			ResumeEventsHandling()
		End Sub

		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			UpdateControlsState()
			ResumeEventsHandling()
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			UpdateControlsState()
			ResumeEventsHandling()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private groupPropertiesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents autoDestroyCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents canBeEmptyCheckBox As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace