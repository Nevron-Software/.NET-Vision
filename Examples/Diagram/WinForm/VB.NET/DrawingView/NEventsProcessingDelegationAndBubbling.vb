Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Enumerates the currently supported tool configurations
	''' </summary>
	Public Enum ToolsConfiguration
		''' <summary>
		''' Enabled are only EventDelagators tools
		''' </summary>
		OnlyEventDelagators
		''' <summary>
		''' Enabled are only Pointer tools
		''' </summary>
		OnlyPointer
		''' <summary>
		''' Pointer tools are with higher priority than event delegators
		''' </summary>
		PointerBeforeEventDelagators
		''' <summary>
		''' Event delegator tools are with higher priority than pointer tools
		''' </summary>
		EventDelagatorsBeforePointer
	End Enum

	''' <summary>
	''' Summary description for NEventsProcessingDelegationAndBubbling.
	''' </summary>
	Public Class NEventsProcessingDelegationAndBubbling
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
			Me.toolsConfigCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.markEventsAsProcessedCheck = New System.Windows.Forms.CheckBox()
			Me.SuspendLayout()
			' 
			' toolsConfigCombo
			' 
			Me.toolsConfigCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.toolsConfigCombo.Location = New System.Drawing.Point(8, 40)
			Me.toolsConfigCombo.Name = "toolsConfigCombo"
			Me.toolsConfigCombo.Size = New System.Drawing.Size(240, 21)
			Me.toolsConfigCombo.TabIndex = 1
			Me.toolsConfigCombo.Text = "comboBox1"
			'			Me.toolsConfigCombo.SelectedIndexChanged += New System.EventHandler(Me.toolsConfigCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(104, 23)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Tools configuration:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' markEventsAsProcessedCheck
			' 
			Me.markEventsAsProcessedCheck.Location = New System.Drawing.Point(8, 72)
			Me.markEventsAsProcessedCheck.Name = "markEventsAsProcessedCheck"
			Me.markEventsAsProcessedCheck.Size = New System.Drawing.Size(232, 24)
			Me.markEventsAsProcessedCheck.TabIndex = 3
			Me.markEventsAsProcessedCheck.Text = "Mark events as processed"
			' 
			' NEventsProcessingDelegationAndBubbling
			' 
			Me.Controls.Add(Me.markEventsAsProcessedCheck)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.toolsConfigCombo)
			Me.Name = "NEventsProcessingDelegationAndBubbling"
			Me.Size = New System.Drawing.Size(256, 576)
			Me.Controls.SetChildIndex(Me.toolsConfigCombo, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.markEventsAsProcessedCheck, 0)
			Me.ResumeLayout(False)

		End Sub
#End Region

#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			MyBase.DefaultGridCellSize = New NSizeF(100, 100)

			' init view
			view.BeginInit()
			view.GlobalVisibility.ShowPorts = False

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' initial config
			InitFormControls()
			ConfigureTools(ToolsConfiguration.PointerBeforeEventDelagators)

			' end desinger init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler document.EventSinkService.NodeMouseDown, AddressOf EventSinkService_NodeMouseDown
			AddHandler document.EventSinkService.NodeMouseEnter, AddressOf EventSinkService_NodeMouseEnter
			AddHandler document.EventSinkService.NodeMouseLeave, AddressOf EventSinkService_NodeMouseLeave
			AddHandler document.EventSinkService.NodeMouseUp, AddressOf EventSinkService_NodeMouseUp
			AddHandler document.EventSinkService.NodeKeyUp, AddressOf EventSinkService_NodeKeyUp
			AddHandler document.EventSinkService.NodeKeyPress, AddressOf EventSinkService_NodeKeyPress

			Debug.WriteLineIf(Not document.EventSinkService.IsInputChar Is Nothing, "document.DelegateIsInputChar has been already assigned.")
			Debug.WriteLineIf(Not document.EventSinkService.IsInputKey Is Nothing, "document.DelegateIsInputKey has been already assigned.")

			document.EventSinkService.IsInputChar = New IsInputChar(AddressOf document_IsInputChar)
			document.EventSinkService.IsInputKey = New IsInputKey(AddressOf document_IsInputKey)

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler document.EventSinkService.NodeMouseDown, AddressOf EventSinkService_NodeMouseDown
			RemoveHandler document.EventSinkService.NodeMouseEnter, AddressOf EventSinkService_NodeMouseEnter
			RemoveHandler document.EventSinkService.NodeMouseLeave, AddressOf EventSinkService_NodeMouseLeave
			RemoveHandler document.EventSinkService.NodeMouseUp, AddressOf EventSinkService_NodeMouseUp
			RemoveHandler document.EventSinkService.NodeKeyUp, AddressOf EventSinkService_NodeKeyUp
			RemoveHandler document.EventSinkService.NodeKeyPress, AddressOf EventSinkService_NodeKeyPress

			document.EventSinkService.IsInputChar = Nothing
			document.EventSinkService.IsInputKey = Nothing

			MyBase.DetachFromEvents()
		End Sub


#End Region

#Region "Implementation"

		Private Sub InitDocument()
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)

			' create interactive rect
			Dim rect As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Rectangle)))
			rect.Bounds = MyBase.GetGridCell(0, 0)
			rect.Text = InitialShapeText
			rect.Name = "Interactive Rectangle"
			rect.Style.InteractivityStyle = New NInteractivityStyle("I am a rectangle with hand cursor", CursorType.Hand)
			document.ActiveLayer.AddChild(rect)

			' create interactive ellipse
			Dim ellipse As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Ellipse)))
			ellipse.Bounds = MyBase.GetGridCell(0, 1)
			ellipse.Text = InitialShapeText
			ellipse.Name = "Interactive Ellipse"
			ellipse.Style.InteractivityStyle = New NInteractivityStyle("I am an ellipse with wait cursor", CursorType.WaitCursor)
			document.ActiveLayer.AddChild(ellipse)

			' create interactive rounded rect
			Dim roundedRect As NShape = factory.CreateShape(CInt(Fix(BasicShapes.RoundedRectangle)))
			roundedRect.Bounds = MyBase.GetGridCell(1, 0)
			roundedRect.Text = InitialShapeText
			roundedRect.Name = "Interactive Rounded Rectangle"
			roundedRect.Style.InteractivityStyle = New NInteractivityStyle("I am a rounded rectangle with cross cursor", CursorType.Cross)
			document.ActiveLayer.AddChild(roundedRect)

			' create interactive hexagram
			Dim hexagram As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Hexagram)))
			hexagram.Bounds = MyBase.GetGridCell(1, 1)
			hexagram.Text = InitialShapeText
			hexagram.Name = "Interactive Hexagram"
			hexagram.Style.InteractivityStyle = New NInteractivityStyle("I am a hexagram with help cursor", CursorType.Help)
			document.ActiveLayer.AddChild(hexagram)

			' initially focus the rect
			FocusShape(rect)
		End Sub

		Private Sub InitFormControls()
			PauseEventsHandling()

			markEventsAsProcessedCheck.Checked = True

			toolsConfigCombo.FillFromEnum(GetType(ToolsConfiguration))
			toolsConfigCombo.SelectedIndex = CInt(Fix(ToolsConfiguration.PointerBeforeEventDelagators))

			ResumeEventsHandling()
		End Sub


		Private Sub ProcessDocumentKey(ByVal args As NNodeKeyEventArgs)
			' the only key the document processes is the tab
			If args.KeyCode <> Keys.Tab Then
				Return
			End If

			Dim newFocusedShape As NShape = Nothing
			Dim curFocusedShape As NShape = (TryCast(document.FocusedElement, NShape))

			' if there is no currently focused shape
			If curFocusedShape Is Nothing Then
				curFocusedShape = (TryCast(document.ActiveLayer.GetChildAt(0), NShape))
			Else
				' get focused shape index
				Dim index As Integer = document.ActiveLayer.IndexOfChild(curFocusedShape)

				' increase or decrease depending on whether the shift was pressed
				If args.Shift Then
					index -= 1
				Else
					index += 1
				End If

				' clamp to valid index
				If index < 0 Then
					index = document.ActiveLayer.ChildrenCount(Nothing) - 1
				ElseIf index >= document.ActiveLayer.ChildrenCount(Nothing) Then
					index = 0
				End If

				' get new focused node
				newFocusedShape = (TryCast(document.ActiveLayer.GetChildAt(index), NShape))
			End If

			' focus the new node
			FocusShape(newFocusedShape)

			' mark event as handled and processed
			args.Handled = True
			args.Processed = markEventsAsProcessedCheck.Checked
		End Sub

		Private Sub ProcessShapeKey(ByVal args As NNodeKeyEventArgs)
			If args.KeyData <> Keys.Left AndAlso args.KeyData <> Keys.Right AndAlso args.KeyData <> Keys.Up AndAlso args.KeyData <> Keys.Down Then
				Return
			End If

			Dim shape As NShape = (TryCast(args.Node, NShape))
			Dim bounds As NRectangleF = shape.Bounds

			Select Case args.KeyData
				Case Keys.Left
					bounds.Translate(-5, 0)
				Case Keys.Right
					bounds.Translate(5, 0)
				Case Keys.Up
					bounds.Translate(0, -5)
				Case Keys.Down
					bounds.Translate(0, 5)
			End Select

			shape.Bounds = bounds
			document.SmartRefreshAllViews()

			' mark event as handled and processed
			args.Handled = True
			args.Processed = markEventsAsProcessedCheck.Checked
		End Sub

		Private Sub ProcessShapeChar(ByVal args As NNodeKeyPressEventArgs)
			If (Not Char.IsLetterOrDigit(args.KeyChar)) AndAlso (Not Char.IsWhiteSpace(args.KeyChar)) AndAlso (Not Char.IsPunctuation(args.KeyChar)) Then
				Return
			End If

			' the shape processes all chars and adds them to the shape text
			Dim shape As NShape = (TryCast(args.Node, NShape))

			If shape.Text = InitialShapeText Then
				shape.Text = ""
			End If

			shape.Text += args.KeyChar

			' mark as handled and processed to stop bubbling and processing
			args.Handled = True
			args.Processed = markEventsAsProcessedCheck.Checked
		End Sub


		Private Sub FocusShape(ByVal newFocusedShape As NShape)
			' force current focused shape to use default stroke style
			Dim curFocusedShape As NShape = (TryCast(document.FocusedElement, NShape))
			If Not curFocusedShape Is Nothing Then
				curFocusedShape.Style.StrokeStyle = Nothing
			End If

			' if null -> remove any focus
			If newFocusedShape Is Nothing Then
				document.FocusedElementUniqueId = Guid.Empty
				Return
			End If

			' focus the new element
			document.FocusedElementUniqueId = newFocusedShape.UniqueId
			newFocusedShape.Style.StrokeStyle = New NStrokeStyle(2, Color.Red)

			document.SmartRefreshAllViews()
		End Sub

		Private Sub ConfigureTools(ByVal config As ToolsConfiguration)
			' initially remove all tools from the view tools collection
			view.Controller.Tools.Clear()

			' determine which tools must be created and in what order
			Dim createPointer As Boolean = False
			Dim createDelegators As Boolean = False
			Dim pointerBeforeDelegator As Boolean = False

			Select Case config
				Case ToolsConfiguration.OnlyEventDelagators
					createPointer = False
					createDelegators = True

				Case ToolsConfiguration.OnlyPointer
					createPointer = True
					createDelegators = False

				Case ToolsConfiguration.PointerBeforeEventDelagators
					createPointer = True
					createDelegators = True
					pointerBeforeDelegator = True

				Case ToolsConfiguration.EventDelagatorsBeforePointer
					createPointer = True
					createDelegators = True
					pointerBeforeDelegator = False

				Case Else
					Debug.Assert(False, "New tools config?")
			End Select

			' create the needed tools
			Dim pointerTools As NTool() = Nothing, delegatorTools As NTool() = Nothing
			If createPointer Then
				pointerTools = New NTool() {New NCreateGuidelineTool(), New NHandleTool(), New NMoveTool(), New NSelectorTool(), New NContextMenuTool(), New NKeyboardTool(), New NInplaceEditTool()}
			End If

			If createDelegators Then
				delegatorTools = New NTool() {New NMouseEventDelegatorTool(), New NKeyboardEventDelegatorTool(), New NDragDropEventDelegatorTool()}
			End If

			' add them in the proper order
			If pointerBeforeDelegator Then
				If Not pointerTools Is Nothing Then
					For Each tool As NTool In pointerTools
						view.Controller.Tools.Add(tool)
					Next tool
				End If

				If Not delegatorTools Is Nothing Then
					For Each tool As NTool In delegatorTools
						view.Controller.Tools.Add(tool)
					Next tool
				End If
			Else
				If Not delegatorTools Is Nothing Then
					For Each tool As NTool In delegatorTools
						view.Controller.Tools.Add(tool)
					Next tool
				End If

				If Not pointerTools Is Nothing Then
					For Each tool As NTool In pointerTools
						view.Controller.Tools.Add(tool)
					Next tool
				End If
			End If

			' enable all tools
			view.Controller.Tools.EnableAllTools()
		End Sub


#End Region

#Region "Delegate Handlers"

		Protected Function document_IsInputChar(ByVal node As INNode, ByVal inputChar As Char) As Boolean
			' in this example we have no special characters we want to process
			Return False
		End Function

		Protected Function document_IsInputKey(ByVal node As INNode, ByVal keyData As Keys) As Boolean
			' the document wants to process the TAB key
			If TypeOf node Is NDrawingDocument Then
				Return (keyData And Keys.Tab) = Keys.Tab
			End If

			' focused shapes want to process the ARROW Keys
			If TypeOf node Is NShape Then
				If keyData = Keys.Left OrElse keyData = Keys.Right OrElse keyData = Keys.Up OrElse keyData = Keys.Down Then
					Return True
				End If
			End If

			Return False
		End Function


#End Region

#Region "Event Handlers"

		Private Sub EventSinkService_NodeMouseDown(ByVal args As NNodeMouseEventArgs)
			' if left mouse down and node is shape -> focus it and stop bubbling and processing
			If args.Button = MouseButtons.Left AndAlso (TypeOf args.Node Is NShape) Then
				FocusShape(TryCast(args.Node, NShape))

				' mark as handled and processed to stop bubbling and processing
				args.Handled = True
				args.Processed = markEventsAsProcessedCheck.Checked
			End If
		End Sub

		Private Sub EventSinkService_NodeMouseUp(ByVal args As NNodeMouseEventArgs)
			' if right mouse up and node is active layer child -> show message box and stop bubbling and processing
			If args.Button = MouseButtons.Right AndAlso (args.Node.ParentNode Is document.ActiveLayer) Then
				Dim viewCoordinates As PointF = New PointF(args.X, args.Y)
				Dim sceneCoordinates As PointF = view.SceneToWorld.InvertPoint(viewCoordinates)

				MessageBox.Show(String.Format("Mouse up event data" & Constants.vbLf & "Node: {0};" & Constants.vbLf & "View coordinates: (in px) {1};" & Constants.vbLf & "Scene coordinates: (in {2}) {3};" & Constants.vbLf & "Mouse Button: {4}.", (TryCast(args.Node, INDiagramElement)).Name, viewCoordinates.ToString(), document.MeasurementUnit.Abbreviation, sceneCoordinates.ToString(), args.Button.ToString()))

				' mark as handled and processed to stop bubbling and processing
				args.Handled = True
				args.Processed = markEventsAsProcessedCheck.Checked
			End If
		End Sub

		Private Sub EventSinkService_NodeMouseEnter(ByVal args As NNodeViewEventArgs)
			' highlight shapes on mouse enter
			Dim shape As NShape = (TryCast(args.Node, NShape))
			If shape Is Nothing Then
				Return
			End If

			shape.Style.FillStyle = New NColorFillStyle(SystemColors.HotTrack)

			' mark as handled and processed to stop bubbling and processing
			args.Handled = True
			args.Processed = markEventsAsProcessedCheck.Checked
		End Sub

		Private Sub EventSinkService_NodeMouseLeave(ByVal args As NNodeViewEventArgs)
			' remove highlighting on mouse leave 
			Dim shape As NShape = (TryCast(args.Node, NShape))
			If shape Is Nothing Then
				Return
			End If

			shape.Style.FillStyle = Nothing

			' mark as handled and processed to stop bubbling and processing
			args.Handled = True
			args.Processed = markEventsAsProcessedCheck.Checked
		End Sub

		Private Sub EventSinkService_NodeKeyUp(ByVal args As NNodeKeyEventArgs)
			' process document key
			If TypeOf args.Node Is NDrawingDocument Then
				ProcessDocumentKey(args)
				document.SmartRefreshAllViews()
				Return
			End If

			' process shape key
			If TypeOf args.Node Is NShape Then
				ProcessShapeKey(args)
				document.SmartRefreshAllViews()
				Return
			End If
		End Sub

		Private Sub EventSinkService_NodeKeyPress(ByVal args As NNodeKeyPressEventArgs)
			' process shape char
			If TypeOf args.Node Is NShape Then
				ProcessShapeChar(args)
				document.SmartRefreshAllViews()
				Return
			End If
		End Sub

		Private Sub toolsConfigCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolsConfigCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim config As ToolsConfiguration = CType(toolsConfigCombo.SelectedIndex, ToolsConfiguration)
			ConfigureTools(config)
		End Sub


#End Region

#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents toolsConfigCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private markEventsAsProcessedCheck As System.Windows.Forms.CheckBox

#End Region

#Region "Fields"

		Private Const InitialShapeText As String = "Click me and type. Use Tab/Shift-Tab to move to next/prev shape."

#End Region
	End Class
End Namespace