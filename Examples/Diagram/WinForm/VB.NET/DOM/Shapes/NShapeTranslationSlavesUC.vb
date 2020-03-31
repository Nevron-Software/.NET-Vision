Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.Templates

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NShapeTranslationSlavesUC.
	''' </summary>
	Public Class NShapeTranslationSlavesUC
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
			Me.shapeTranslationSlavesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.reflexiveShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.successorShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.predecessorShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.accessibleShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.destinationShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.sourceShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.neighbourShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.connectedShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.outgoingShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.incommingShapesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.toShapeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.fromShapeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.shapeTranslationSlavesGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' shapeTranslationSlavesGroup
			' 
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.reflexiveShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.successorShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.predecessorShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.accessibleShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.destinationShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.sourceShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.neighbourShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.connectedShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.outgoingShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.incommingShapesCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.toShapeCheck)
			Me.shapeTranslationSlavesGroup.Controls.Add(Me.fromShapeCheck)
			Me.shapeTranslationSlavesGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.shapeTranslationSlavesGroup.Enabled = False
			Me.shapeTranslationSlavesGroup.ImageIndex = 0
			Me.shapeTranslationSlavesGroup.Location = New System.Drawing.Point(0, 0)
			Me.shapeTranslationSlavesGroup.Name = "shapeTranslationSlavesGroup"
			Me.shapeTranslationSlavesGroup.Size = New System.Drawing.Size(248, 424)
			Me.shapeTranslationSlavesGroup.TabIndex = 0
			Me.shapeTranslationSlavesGroup.TabStop = False
			Me.shapeTranslationSlavesGroup.Text = "Selected shape translation slaves"
			' 
			' reflexiveShapesCheck
			' 
			Me.reflexiveShapesCheck.Location = New System.Drawing.Point(40, 48)
			Me.reflexiveShapesCheck.Name = "reflexiveShapesCheck"
			Me.reflexiveShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.reflexiveShapesCheck.TabIndex = 1
			Me.reflexiveShapesCheck.Text = "Reflexive shapes"
'			Me.reflexiveShapesCheck.CheckedChanged += New System.EventHandler(Me.reflexiveShapesCheck_CheckedChanged);
			' 
			' successorShapesCheck
			' 
			Me.successorShapesCheck.Location = New System.Drawing.Point(40, 264)
			Me.successorShapesCheck.Name = "successorShapesCheck"
			Me.successorShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.successorShapesCheck.TabIndex = 10
			Me.successorShapesCheck.Text = "Successor shapes"
'			Me.successorShapesCheck.CheckedChanged += New System.EventHandler(Me.successorShapesCheck_CheckedChanged);
			' 
			' predecessorShapesCheck
			' 
			Me.predecessorShapesCheck.Location = New System.Drawing.Point(40, 288)
			Me.predecessorShapesCheck.Name = "predecessorShapesCheck"
			Me.predecessorShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.predecessorShapesCheck.TabIndex = 11
			Me.predecessorShapesCheck.Text = "Predecessor shapes"
'			Me.predecessorShapesCheck.CheckedChanged += New System.EventHandler(Me.predecessorShapesCheck_CheckedChanged);
			' 
			' accessibleShapesCheck
			' 
			Me.accessibleShapesCheck.Location = New System.Drawing.Point(8, 240)
			Me.accessibleShapesCheck.Name = "accessibleShapesCheck"
			Me.accessibleShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.accessibleShapesCheck.TabIndex = 9
			Me.accessibleShapesCheck.Text = "Accessible shapes"
'			Me.accessibleShapesCheck.CheckedChanged += New System.EventHandler(Me.accessibleShapesCheck_CheckedChanged);
			' 
			' destinationShapesCheck
			' 
			Me.destinationShapesCheck.Location = New System.Drawing.Point(40, 192)
			Me.destinationShapesCheck.Name = "destinationShapesCheck"
			Me.destinationShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.destinationShapesCheck.TabIndex = 7
			Me.destinationShapesCheck.Text = "Destination shapes"
'			Me.destinationShapesCheck.CheckedChanged += New System.EventHandler(Me.destinationShapesCheck_CheckedChanged);
			' 
			' sourceShapesCheck
			' 
			Me.sourceShapesCheck.Location = New System.Drawing.Point(40, 216)
			Me.sourceShapesCheck.Name = "sourceShapesCheck"
			Me.sourceShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.sourceShapesCheck.TabIndex = 8
			Me.sourceShapesCheck.Text = "Source shapes"
'			Me.sourceShapesCheck.CheckedChanged += New System.EventHandler(Me.sourceShapesCheck_CheckedChanged);
			' 
			' neighbourShapesCheck
			' 
			Me.neighbourShapesCheck.Location = New System.Drawing.Point(8, 168)
			Me.neighbourShapesCheck.Name = "neighbourShapesCheck"
			Me.neighbourShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.neighbourShapesCheck.TabIndex = 6
			Me.neighbourShapesCheck.Text = "Neighbour shapes"
'			Me.neighbourShapesCheck.CheckedChanged += New System.EventHandler(Me.neighbourShapesCheck_CheckedChanged);
			' 
			' connectedShapesCheck
			' 
			Me.connectedShapesCheck.Location = New System.Drawing.Point(8, 24)
			Me.connectedShapesCheck.Name = "connectedShapesCheck"
			Me.connectedShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.connectedShapesCheck.TabIndex = 0
			Me.connectedShapesCheck.Text = "Connected shapes"
'			Me.connectedShapesCheck.CheckedChanged += New System.EventHandler(Me.connectedShapesCheck_CheckedChanged);
			' 
			' outgoingShapesCheck
			' 
			Me.outgoingShapesCheck.Location = New System.Drawing.Point(40, 96)
			Me.outgoingShapesCheck.Name = "outgoingShapesCheck"
			Me.outgoingShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.outgoingShapesCheck.TabIndex = 3
			Me.outgoingShapesCheck.Text = "Outgoing shapes"
'			Me.outgoingShapesCheck.CheckedChanged += New System.EventHandler(Me.outgoingShapesCheck_CheckedChanged);
			' 
			' incommingShapesCheck
			' 
			Me.incommingShapesCheck.Location = New System.Drawing.Point(40, 72)
			Me.incommingShapesCheck.Name = "incommingShapesCheck"
			Me.incommingShapesCheck.Size = New System.Drawing.Size(152, 16)
			Me.incommingShapesCheck.TabIndex = 2
			Me.incommingShapesCheck.Text = "Incomming shapes"
'			Me.incommingShapesCheck.CheckedChanged += New System.EventHandler(Me.incommingShapesCheck_CheckedChanged);
			' 
			' toShapeCheck
			' 
			Me.toShapeCheck.Location = New System.Drawing.Point(40, 144)
			Me.toShapeCheck.Name = "toShapeCheck"
			Me.toShapeCheck.Size = New System.Drawing.Size(152, 16)
			Me.toShapeCheck.TabIndex = 5
			Me.toShapeCheck.Text = "To shape"
'			Me.toShapeCheck.CheckedChanged += New System.EventHandler(Me.toShapeCheck_CheckedChanged);
			' 
			' fromShapeCheck
			' 
			Me.fromShapeCheck.Location = New System.Drawing.Point(40, 120)
			Me.fromShapeCheck.Name = "fromShapeCheck"
			Me.fromShapeCheck.Size = New System.Drawing.Size(152, 16)
			Me.fromShapeCheck.TabIndex = 4
			Me.fromShapeCheck.Text = "From shape"
'			Me.fromShapeCheck.CheckedChanged += New System.EventHandler(Me.fromShapeCheck_CheckedChanged);
			' 
			' NShapeTranslationSlavesUC
			' 
			Me.Controls.Add(Me.shapeTranslationSlavesGroup)
			Me.Name = "NShapeTranslationSlavesUC"
			Me.Size = New System.Drawing.Size(248, 560)
			Me.Controls.SetChildIndex(Me.shapeTranslationSlavesGroup, 0)
			Me.shapeTranslationSlavesGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form members
			highlightFillStyle = New NColorFillStyle(Color.FromArgb(80, Color.Red))
			highlightStrokeStyle = New NStrokeStyle(2, Color.Red)

			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.Selection.Mode = DiagramSelectionMode.Single
			view.InteractiveAppearance.SelectedStrokeStyle = New NStrokeStyle(2, Color.Blue)
			view.InteractiveAppearance.SelectedFillStyle = New NColorFillStyle(Color.FromArgb(80, Color.Blue))

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_OnNodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_OnNodeDeselected

			MyBase.DetachFromEvents()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			incommingShapesCheck.Checked = False
			outgoingShapesCheck.Checked = False
			connectedShapesCheck.Checked = False
			neighbourShapesCheck.Checked = False
			sourceShapesCheck.Checked = False
			destinationShapesCheck.Checked = False
			accessibleShapesCheck.Checked = False
			predecessorShapesCheck.Checked = False
			successorShapesCheck.Checked = False
			fromShapeCheck.Checked = False
			toShapeCheck.Checked = False

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			document.Style.TextStyle = New NTextStyle(New Font("Arial", 9), Color.Black)

			Dim template As NGraphTemplate

			' create rectangular grid template
			template = New NRectangularGridTemplate()
			template.Origin = New NPointF(10, 23)
			template.VerticesShape = BasicShapes.Rectangle
			template.Create(document)

			' create tree template
			template = New NGenericTreeTemplate()
			template.Origin = New NPointF(250, 23)
			template.VerticesShape = BasicShapes.Triangle
			template.Create(document)

			' create elliptical grid template
			template = New NEllipticalGridTemplate()
			template.Origin = New NPointF(10, 250)
			template.VerticesShape = BasicShapes.Ellipse
			template.Create(document)

			' create a shape with a 1D shape which reflexes it
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(BasicShapes.Rectangle)))
			shape.Bounds = New NRectangleF(350, 350, 100, 100)
			document.ActiveLayer.AddChild(shape)

			Dim bezier As NBezierCurveShape = New NBezierCurveShape()
			bezier.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(bezier)

			bezier.FromShape = shape
			bezier.ToShape = shape
			bezier.Reflex()
		End Sub

		Private Sub UpdateTranslationSlaves()
			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			Dim slaves As NTranslationSlaves = shape.TranslationSlaves

			slaves.ConnectedShapes = connectedShapesCheck.Checked
			slaves.IncomingShapes = incommingShapesCheck.Checked
			slaves.OutgoingShapes = outgoingShapesCheck.Checked
			slaves.ReflexiveShapes = reflexiveShapesCheck.Checked
			slaves.FromShape = fromShapeCheck.Checked
			slaves.ToShape = toShapeCheck.Checked

			slaves.NeighbourShapes = neighbourShapesCheck.Checked
			slaves.SourceShapes = sourceShapesCheck.Checked
			slaves.DestinationShapes = destinationShapesCheck.Checked

			slaves.AccessibleShapes = accessibleShapesCheck.Checked
			slaves.PredecessorShapes = predecessorShapesCheck.Checked
			slaves.SuccessorShapes = successorShapesCheck.Checked

			shape.TranslationSlaves = slaves
		End Sub

		Private Sub UpdateHighlights()
			ClearHighlights()

			Dim shape As NShape = (TryCast(view.Selection.AnchorNode, NShape))
			If shape Is Nothing Then
				Return
			End If

			Dim nodes As NNodeList = New NNodeList()
			shape.AccumulateTranslationSlaves(nodes, Nothing, False)

			For Each slave As NShape In nodes
				slave.Style.FillStyle = CType(highlightFillStyle.Clone(), NFillStyle)
				slave.Style.StrokeStyle = CType(highlightStrokeStyle.Clone(), NStrokeStyle)
			Next slave
		End Sub

		Private Sub ClearHighlights()
			Dim en As NNodeEnumerator = document.ActiveLayer.GetEnumerator(NFilters.TypeNShape)
			Do While en.MoveNext()
				Dim shape As NShape = (TryCast(en.Current, NShape))

				shape.Style.FillStyle = Nothing
				shape.Style.StrokeStyle = Nothing
			Loop
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub EventSinkService_OnNodeSelected(ByVal args As NNodeEventArgs)
			PauseEventsHandling()

			Dim shape As NShape = (TryCast(args.Node, NShape))
			If shape Is Nothing Then
				shapeTranslationSlavesGroup.Enabled = False
				Return
			End If

			' update form controls
			shapeTranslationSlavesGroup.Enabled = True

			Dim slaves As NTranslationSlaves = shape.TranslationSlaves

			 connectedShapesCheck.Checked = slaves.ConnectedShapes
			incommingShapesCheck.Checked = slaves.IncomingShapes
			outgoingShapesCheck.Checked = slaves.OutgoingShapes
			reflexiveShapesCheck.Checked = slaves.ReflexiveShapes

			neighbourShapesCheck.Checked = slaves.NeighbourShapes
			sourceShapesCheck.Checked = slaves.NeighbourShapes
			destinationShapesCheck.Checked = slaves.DestinationShapes

			accessibleShapesCheck.Checked = slaves.AccessibleShapes
			predecessorShapesCheck.Checked = slaves.PredecessorShapes
			successorShapesCheck.Checked = slaves.SuccessorShapes

			fromShapeCheck.Checked = slaves.FromShape
			toShapeCheck.Checked = slaves.ToShape

			ResumeEventsHandling()

			' update highligts
			UpdateHighlights()
			document.SmartRefreshAllViews()
		End Sub

		Private Sub EventSinkService_OnNodeDeselected(ByVal args As NNodeEventArgs)
			shapeTranslationSlavesGroup.Enabled = False

			' clear highligts
			ClearHighlights()
			document.SmartRefreshAllViews()
		End Sub


		Private Sub connectedShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles connectedShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			incommingShapesCheck.Checked = connectedShapesCheck.Checked
			outgoingShapesCheck.Checked = connectedShapesCheck.Checked
			reflexiveShapesCheck.Checked = connectedShapesCheck.Checked
			fromShapeCheck.Checked = connectedShapesCheck.Checked
			toShapeCheck.Checked = connectedShapesCheck.Checked

			ResumeEventsHandling()

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub reflexiveShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles reflexiveShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub incommingShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles incommingShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub outgoingShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles outgoingShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub neighbourShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles neighbourShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			sourceShapesCheck.Checked = neighbourShapesCheck.Checked
			destinationShapesCheck.Checked = neighbourShapesCheck.Checked

			ResumeEventsHandling()

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub sourceShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sourceShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub destinationShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles destinationShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub accessibleShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles accessibleShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()

			successorShapesCheck.Checked = accessibleShapesCheck.Checked
			predecessorShapesCheck.Checked = accessibleShapesCheck.Checked

			ResumeEventsHandling()

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub predecessorShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles predecessorShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub successorShapesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles successorShapesCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub fromShapeCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fromShapeCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub

		Private Sub toShapeCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles toShapeCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			UpdateTranslationSlaves()
			UpdateHighlights()

			document.SmartRefreshAllViews()
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		#Region "Fields"

		Private highlightFillStyle As NColorFillStyle = Nothing
		Private highlightStrokeStyle As NStrokeStyle = Nothing
		Private WithEvents incommingShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents outgoingShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents connectedShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents neighbourShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents sourceShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents destinationShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents accessibleShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents predecessorShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents successorShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents fromShapeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents toShapeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private shapeTranslationSlavesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents reflexiveShapesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private selectedStrokeStyle As NStrokeStyle = Nothing

		#End Region
	End Class
End Namespace
