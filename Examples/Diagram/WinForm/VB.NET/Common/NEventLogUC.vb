Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Dom

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NEventLogUC.
	''' </summary>
	Public Class NEventLogUC
		Inherits System.Windows.Forms.UserControl
		#Region "Constructors"
		Public Sub New()
			InitializeComponent()
		End Sub
		#End Region

		#Region "Component Overrides"
		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub
		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.clearLogButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.eventsList = New Nevron.UI.WinForm.Controls.NListBox()
			Me.trackDesignerEventsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.trackDocumentEventsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' clearLogButton
			' 
			Me.clearLogButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.clearLogButton.Location = New System.Drawing.Point(160, 8)
			Me.clearLogButton.Name = "clearLogButton"
			Me.clearLogButton.Size = New System.Drawing.Size(80, 23)
			Me.clearLogButton.TabIndex = 10
			Me.clearLogButton.Text = "Clear Log"
'			Me.clearLogButton.Click += New System.EventHandler(Me.clearLogButton_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 8)
			Me.label3.Name = "label3"
			Me.label3.TabIndex = 9
			Me.label3.Text = "Events:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' eventsList
			' 
			Me.eventsList.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.eventsList.ColumnOnLeft = False
			Me.eventsList.Location = New System.Drawing.Point(8, 40)
			Me.eventsList.Name = "eventsList"
			Me.eventsList.Size = New System.Drawing.Size(232, 364)
			Me.eventsList.TabIndex = 8
			' 
			' trackDesignerEventsCheckBox
			' 
			Me.trackDesignerEventsCheckBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.trackDesignerEventsCheckBox.Location = New System.Drawing.Point(8, 410)
			Me.trackDesignerEventsCheckBox.Name = "trackDesignerEventsCheckBox"
			Me.trackDesignerEventsCheckBox.Size = New System.Drawing.Size(136, 24)
			Me.trackDesignerEventsCheckBox.TabIndex = 11
			Me.trackDesignerEventsCheckBox.Text = "Track designer events"
'			Me.trackDesignerEventsCheckBox.CheckedChanged += New System.EventHandler(Me.trackDesignerEventsCheckBox_CheckedChanged);
			' 
			' trackDocumentEventsCheckBox
			' 
			Me.trackDocumentEventsCheckBox.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.trackDocumentEventsCheckBox.Location = New System.Drawing.Point(8, 434)
			Me.trackDocumentEventsCheckBox.Name = "trackDocumentEventsCheckBox"
			Me.trackDocumentEventsCheckBox.Size = New System.Drawing.Size(136, 24)
			Me.trackDocumentEventsCheckBox.TabIndex = 11
			Me.trackDocumentEventsCheckBox.Text = "Track document events"
'			Me.trackDocumentEventsCheckBox.CheckedChanged += New System.EventHandler(Me.trackDocumentEventsCheckBox_CheckedChanged);
			' 
			' NEventLogUC
			' 
			Me.Controls.Add(Me.trackDesignerEventsCheckBox)
			Me.Controls.Add(Me.clearLogButton)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.eventsList)
			Me.Controls.Add(Me.trackDocumentEventsCheckBox)
			Me.Name = "NEventLogUC"
			Me.Size = New System.Drawing.Size(248, 464)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Operations"

		Public Sub AttachToView()
			If Form Is Nothing OrElse Form.View Is Nothing Then
				Return
			End If

			AddHandler Form.View.EventSinkService.ToolsChanged, AddressOf DesignerEventSinkService_ControllerToolsCollectionChanged
			AddHandler Form.View.EventSinkService.NodeAttributeChanged, AddressOf DesignerEventSinkService_NodeAttributeChanged
			AddHandler Form.View.EventSinkService.NodeAttributePropertyChanged, AddressOf DesignerEventSinkService_NodeAttributePropertyChanged
			AddHandler Form.View.EventSinkService.NodeAttributePropertyChanging, AddressOf DesignerEventSinkService_NodeAttributePropertyChanging
			AddHandler Form.View.EventSinkService.NodeBoundsChanged, AddressOf DesignerEventSinkService_NodeBoundsChanged
			AddHandler Form.View.EventSinkService.NodeBoundsChanging, AddressOf DesignerEventSinkService_NodeBoundsChanging
			AddHandler Form.View.EventSinkService.NodeDeselected, AddressOf DesignerEventSinkService_NodeDeselected
			AddHandler Form.View.EventSinkService.NodeDeselecting, AddressOf DesignerEventSinkService_NodeDeselecting
			AddHandler Form.View.EventSinkService.NodeInserted, AddressOf DesignerEventSinkService_NodeInserted
			AddHandler Form.View.EventSinkService.NodePropertyChanged, AddressOf DesignerEventSinkService_NodePropertyChanged
			AddHandler Form.View.EventSinkService.NodePropertyChanging, AddressOf DesignerEventSinkService_NodePropertyChanging
			AddHandler Form.View.EventSinkService.NodeRemoved, AddressOf DesignerEventSinkService_NodeRemoved
			AddHandler Form.View.EventSinkService.NodeSelected, AddressOf DesignerEventSinkService_NodeSelected
			AddHandler Form.View.EventSinkService.NodeSelecting, AddressOf DesignerEventSinkService_NodeSelecting
			AddHandler Form.View.EventSinkService.NodeTransformChanged, AddressOf DesignerEventSinkService_NodeTransformChanged
			AddHandler Form.View.EventSinkService.NodeTransformChanging, AddressOf DesignerEventSinkService_NodeTransformChanging
			AddHandler Form.View.EventSinkService.ToolAborted, AddressOf DesignerEventSinkService_ToolAborted
			AddHandler Form.View.EventSinkService.ToolActivated, AddressOf DesignerEventSinkService_ToolActivated
			AddHandler Form.View.EventSinkService.ToolDeactivated, AddressOf DesignerEventSinkService_ToolDeactivated
			AddHandler Form.View.EventSinkService.ToolDisabled, AddressOf DesignerEventSinkService_ToolDisabled
			AddHandler Form.View.EventSinkService.ToolEnabled, AddressOf DesignerEventSinkService_ToolEnabled
			AddHandler Form.View.EventSinkService.TransformationsChanged, AddressOf DesignerEventSinkService_TransformationsChanged
		End Sub

		Public Sub DetachFromView()
			If Form Is Nothing OrElse Form.View Is Nothing Then
				Return
			End If

			RemoveHandler Form.View.EventSinkService.ToolsChanged, AddressOf DesignerEventSinkService_ControllerToolsCollectionChanged
			RemoveHandler Form.View.EventSinkService.NodeAttributeChanged, AddressOf DesignerEventSinkService_NodeAttributeChanged
			RemoveHandler Form.View.EventSinkService.NodeAttributePropertyChanged, AddressOf DesignerEventSinkService_NodeAttributePropertyChanged
			RemoveHandler Form.View.EventSinkService.NodeAttributePropertyChanging, AddressOf DesignerEventSinkService_NodeAttributePropertyChanging
			RemoveHandler Form.View.EventSinkService.NodeBoundsChanged, AddressOf DesignerEventSinkService_NodeBoundsChanged
			RemoveHandler Form.View.EventSinkService.NodeBoundsChanging, AddressOf DesignerEventSinkService_NodeBoundsChanging
			RemoveHandler Form.View.EventSinkService.NodeDeselected, AddressOf DesignerEventSinkService_NodeDeselected
			RemoveHandler Form.View.EventSinkService.NodeDeselecting, AddressOf DesignerEventSinkService_NodeDeselecting
			RemoveHandler Form.View.EventSinkService.NodeInserted, AddressOf DesignerEventSinkService_NodeInserted
			RemoveHandler Form.View.EventSinkService.NodePropertyChanged, AddressOf DesignerEventSinkService_NodePropertyChanged
			RemoveHandler Form.View.EventSinkService.NodePropertyChanging, AddressOf DesignerEventSinkService_NodePropertyChanging
			RemoveHandler Form.View.EventSinkService.NodeRemoved, AddressOf DesignerEventSinkService_NodeRemoved
			RemoveHandler Form.View.EventSinkService.NodeSelected, AddressOf DesignerEventSinkService_NodeSelected
			RemoveHandler Form.View.EventSinkService.NodeSelecting, AddressOf DesignerEventSinkService_NodeSelecting
			RemoveHandler Form.View.EventSinkService.NodeTransformChanged, AddressOf DesignerEventSinkService_NodeTransformChanged
			RemoveHandler Form.View.EventSinkService.NodeTransformChanging, AddressOf DesignerEventSinkService_NodeTransformChanging
			RemoveHandler Form.View.EventSinkService.ToolAborted, AddressOf DesignerEventSinkService_ToolAborted
			RemoveHandler Form.View.EventSinkService.ToolActivated, AddressOf DesignerEventSinkService_ToolActivated
			RemoveHandler Form.View.EventSinkService.ToolDeactivated, AddressOf DesignerEventSinkService_ToolDeactivated
			RemoveHandler Form.View.EventSinkService.ToolDisabled, AddressOf DesignerEventSinkService_ToolDisabled
			RemoveHandler Form.View.EventSinkService.ToolEnabled, AddressOf DesignerEventSinkService_ToolEnabled
			RemoveHandler Form.View.EventSinkService.TransformationsChanged, AddressOf DesignerEventSinkService_TransformationsChanged
		End Sub


		Public Sub AttachToDocument()
			If Form Is Nothing OrElse Form.Document Is Nothing Then
				Return
			End If

			AddHandler Form.Document.EventSinkService.Connected, AddressOf EventSinkService_Connected
			AddHandler Form.Document.EventSinkService.Connecting, AddressOf EventSinkService_Connecting
			AddHandler Form.Document.EventSinkService.Disconnected, AddressOf EventSinkService_Disconnected
			AddHandler Form.Document.EventSinkService.Disconnecting, AddressOf EventSinkService_Disconnecting
			AddHandler Form.Document.EventSinkService.NodeAttributeChanged, AddressOf EventSinkService_NodeAttributeChanged
			AddHandler Form.Document.EventSinkService.NodeAttributePropertyChanged, AddressOf EventSinkService_NodeAttributePropertyChanged
			AddHandler Form.Document.EventSinkService.NodeAttributePropertyChanging, AddressOf EventSinkService_NodeAttributePropertyChanging
			AddHandler Form.Document.EventSinkService.NodeBoundsChanged, AddressOf EventSinkService_NodeBoundsChanged
			AddHandler Form.Document.EventSinkService.NodeBoundsChanging, AddressOf EventSinkService_NodeBoundsChanging
			AddHandler Form.Document.EventSinkService.NodeInserted, AddressOf EventSinkService_NodeInserted
			AddHandler Form.Document.EventSinkService.NodePropertyChanged, AddressOf EventSinkService_NodePropertyChanged
			AddHandler Form.Document.EventSinkService.NodePropertyChanging, AddressOf EventSinkService_NodePropertyChanging
			AddHandler Form.Document.EventSinkService.NodeRemoved, AddressOf EventSinkService_NodeRemoved
			AddHandler Form.Document.EventSinkService.NodeTransformChanged, AddressOf EventSinkService_NodeTransformChanged
			AddHandler Form.Document.EventSinkService.NodeTransformChanging, AddressOf EventSinkService_NodeTransformChanging
		End Sub

		Public Sub DetachFromDocument()
			If Form Is Nothing OrElse Form.Document Is Nothing Then
				Return
			End If

			RemoveHandler Form.Document.EventSinkService.Connected, AddressOf EventSinkService_Connected
			RemoveHandler Form.Document.EventSinkService.Connecting, AddressOf EventSinkService_Connecting
			RemoveHandler Form.Document.EventSinkService.Disconnected, AddressOf EventSinkService_Disconnected
			RemoveHandler Form.Document.EventSinkService.Disconnecting, AddressOf EventSinkService_Disconnecting
			RemoveHandler Form.Document.EventSinkService.NodeAttributeChanged, AddressOf EventSinkService_NodeAttributeChanged
			RemoveHandler Form.Document.EventSinkService.NodeAttributePropertyChanged, AddressOf EventSinkService_NodeAttributePropertyChanged
			RemoveHandler Form.Document.EventSinkService.NodeAttributePropertyChanging, AddressOf EventSinkService_NodeAttributePropertyChanging
			RemoveHandler Form.Document.EventSinkService.NodeBoundsChanged, AddressOf EventSinkService_NodeBoundsChanged
			RemoveHandler Form.Document.EventSinkService.NodeBoundsChanging, AddressOf EventSinkService_NodeBoundsChanging
			RemoveHandler Form.Document.EventSinkService.NodeInserted, AddressOf EventSinkService_NodeInserted
			RemoveHandler Form.Document.EventSinkService.NodePropertyChanged, AddressOf EventSinkService_NodePropertyChanged
			RemoveHandler Form.Document.EventSinkService.NodePropertyChanging, AddressOf EventSinkService_NodePropertyChanging
			RemoveHandler Form.Document.EventSinkService.NodeRemoved, AddressOf EventSinkService_NodeRemoved
			RemoveHandler Form.Document.EventSinkService.NodeTransformChanged, AddressOf EventSinkService_NodeTransformChanged
			RemoveHandler Form.Document.EventSinkService.NodeTransformChanging, AddressOf EventSinkService_NodeTransformChanging
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub UpdateControlsState()
			If Form Is Nothing Then
				trackDocumentEventsCheckBox.Enabled = False
				trackDesignerEventsCheckBox.Enabled = False
				Return
			End If

			trackDocumentEventsCheckBox.Enabled = True
			trackDesignerEventsCheckBox.Enabled = True
		End Sub

		Private Sub LogEvent(ByVal eventText As String)
			eventsList.Items.Add(eventText)
			eventsList.SelectedIndex = Me.eventsList.Items.Count - 1
		End Sub
		#End Region

		#Region "Form Event Handlers"
		Private Sub trackDesignerEventsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trackDesignerEventsCheckBox.CheckedChanged
			If trackDesignerEventsCheckBox.Checked Then
				AttachToView()
				Return
			End If

			DetachFromView()
		End Sub

		Private Sub trackDocumentEventsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trackDocumentEventsCheckBox.CheckedChanged
			If trackDocumentEventsCheckBox.Checked Then
				AttachToDocument()
				Return
			End If

			DetachFromDocument()
		End Sub

		Private Sub clearLogButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles clearLogButton.Click
			eventsList.BeginUpdate()
			eventsList.Items.Clear()
			eventsList.EndUpdate()
		End Sub
		#End Region

		#Region "DesignerEventSinkService Event Handlers"
		Private Sub DesignerEventSinkService_ControllerToolsCollectionChanged(ByVal sender As Object, ByVal e As EventArgs)
			LogEvent("Designer: Controller Tools Collection Changed")
		End Sub

		Private Sub DesignerEventSinkService_NodeAttributeChanged(ByVal args As NNodeAttributeEventArgs)
			LogEvent("Designer: Node Attribute Changed")
		End Sub

		Private Sub DesignerEventSinkService_NodeAttributePropertyChanged(ByVal args As NNodeAttributePropertyEventArgs)
			LogEvent("Designer: Node Attribute Property Changed")
		End Sub

		Private Sub DesignerEventSinkService_NodeAttributePropertyChanging(ByVal args As NNodeAttributePropertyCancelEventArgs)
			LogEvent("Designer: Node Attribute Property Changing")
		End Sub

		Private Sub DesignerEventSinkService_NodeBoundsChanged(ByVal args As NNodeEventArgs)
'			if (! m_Form.View.Selection.Nodes.Contains(args.Node))
'				return;

			LogEvent("Designer: Node Bounds Changed")
		End Sub

		Private Sub DesignerEventSinkService_NodeBoundsChanging(ByVal args As NNodeBoundsCancelEventArgs)
			LogEvent("Designer: Node Bounds Changing")
		End Sub

		Private Sub DesignerEventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			LogEvent("Designer: Node Deselected")
		End Sub

		Private Sub DesignerEventSinkService_NodeDeselecting(ByVal args As NNodeCancelEventArgs)
			LogEvent("Designer: Node Deselecting")
		End Sub

		Private Sub DesignerEventSinkService_NodeInserted(ByVal args As NChildNodeEventArgs)
			LogEvent("Designer: Node Inserted")
		End Sub

		Private Sub DesignerEventSinkService_NodePointsChanged(ByVal args As NNodeEventArgs)
			LogEvent("Designer: Node Points Changed")
		End Sub

		Private Sub DesignerEventSinkService_NodePropertyChanged(ByVal args As NNodePropertyEventArgs)
			LogEvent("Designer: Node Property Changed")
		End Sub

		Private Sub DesignerEventSinkService_NodePropertyChanging(ByVal args As NNodePropertyCancelEventArgs)
			LogEvent("Designer: Node Property Changing")
		End Sub

		Private Sub DesignerEventSinkService_NodeRemoved(ByVal args As NChildNodeEventArgs)
			LogEvent("Designer: Node Removed")
		End Sub

		Private Sub DesignerEventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			LogEvent("Designer: Node Selected")
		End Sub

		Private Sub DesignerEventSinkService_NodeSelecting(ByVal args As NNodeCancelEventArgs)
			LogEvent("Designer: Node Selecting")
		End Sub

		Private Sub DesignerEventSinkService_NodeTransformChanged(ByVal args As NNodeEventArgs)
			LogEvent("Designer: Node Transform Changed")
		End Sub

		Private Sub DesignerEventSinkService_NodeTransformChanging(ByVal args As NNodeTransformCancelEventArgs)
			LogEvent("Designer: Node Transform Changing")
		End Sub

		Private Sub DesignerEventSinkService_ToolAborted(ByVal sender As Object, ByVal e As EventArgs)
			LogEvent("Designer: Tool Aborted")
		End Sub

		Private Sub DesignerEventSinkService_ToolActivated(ByVal sender As Object, ByVal e As EventArgs)
			LogEvent("Designer: Tool Activated")
		End Sub

		Private Sub DesignerEventSinkService_ToolDeactivated(ByVal sender As Object, ByVal e As EventArgs)
			LogEvent("Designer: Tool Deactivated")
		End Sub

		Private Sub DesignerEventSinkService_ToolDisabled(ByVal sender As Object, ByVal e As EventArgs)
			LogEvent("Designer: Tool Disabled")
		End Sub

		Private Sub DesignerEventSinkService_ToolEnabled(ByVal sender As Object, ByVal e As EventArgs)
			LogEvent("Designer: Tool Enabled")
		End Sub

		Private Sub DesignerEventSinkService_TransformationsChanged(ByVal sender As Object, ByVal e As EventArgs)
			LogEvent("Designer: World Transformations Changed")
		End Sub
		#End Region

		#Region "EventSinkService Event Handlers"
		Private Sub EventSinkService_Connected(ByVal args As NConnectionEventArgs)
			LogEvent("Document: Connected")
		End Sub

		Private Sub EventSinkService_Connecting(ByVal args As NConnectionCancelEventArgs)
			LogEvent("Document: Connecting")
		End Sub

		Private Sub EventSinkService_Disconnected(ByVal args As NConnectionEventArgs)
			LogEvent("Document: Disconnected")
		End Sub

		Private Sub EventSinkService_Disconnecting(ByVal args As NConnectionCancelEventArgs)
			LogEvent("Document: Disconnecting")
		End Sub

		Private Sub EventSinkService_NodeAttributeChanged(ByVal args As NNodeAttributeEventArgs)
			LogEvent("Document: Node Attribute Changed")
		End Sub

		Private Sub EventSinkService_NodeAttributePropertyChanged(ByVal args As NNodeAttributePropertyEventArgs)
			LogEvent("Document: Node Attribute Property Changed")
		End Sub

		Private Sub EventSinkService_NodeAttributePropertyChanging(ByVal args As NNodeAttributePropertyCancelEventArgs)
			LogEvent("Document: Node Attribute Property Changing")
		End Sub

		Private Sub EventSinkService_NodeBoundsChanged(ByVal args As NNodeEventArgs)
			LogEvent("Document: Node Bounds Changed")
		End Sub

		Private Sub EventSinkService_NodeBoundsChanging(ByVal args As NNodeBoundsCancelEventArgs)
			LogEvent("Document: Node Bounds Changing")
		End Sub

		Private Sub EventSinkService_NodeInserted(ByVal args As NChildNodeEventArgs)
			LogEvent("Document: Node Inserted")
		End Sub

		Private Sub EventSinkService_NodePropertyChanged(ByVal args As NNodePropertyEventArgs)
			LogEvent("Document: Node Property Changed")
		End Sub

		Private Sub EventSinkService_NodePropertyChanging(ByVal args As NNodePropertyCancelEventArgs)
			LogEvent("Document: Node Property Changing")
		End Sub

		Private Sub EventSinkService_NodeRemoved(ByVal args As NChildNodeEventArgs)
			LogEvent("Document: Node Removed")
		End Sub

		Private Sub EventSinkService_NodeTransformChanged(ByVal args As NNodeEventArgs)
			LogEvent("Document: Node Transform Changed")
		End Sub

		Private Sub EventSinkService_NodeTransformChanging(ByVal args As NNodeTransformCancelEventArgs)
			LogEvent("Document: Node Transform Changing")
		End Sub
		#End Region

		#Region "Designer Fields"
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private label3 As System.Windows.Forms.Label
		Private WithEvents clearLogButton As Nevron.UI.WinForm.Controls.NButton
		Private eventsList As Nevron.UI.WinForm.Controls.NListBox
		Private WithEvents trackDesignerEventsCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents trackDocumentEventsCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		#End Region

		#Region "Properties"
		<Browsable(False)> _
		Public Property Form() As NMainForm
			Get
				Return form_Renamed
			End Get
			Set
				form_Renamed = Value
				UpdateControlsState()
			End Set
		End Property
		#End Region

		#Region "Fields"
		Private form_Renamed As NMainForm = Nothing
		#End Region
	End Class
End Namespace