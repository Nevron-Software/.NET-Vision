Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Reflection
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NCustomDragDropUC.
	''' </summary>
	Public Class NCustomDragDropUC
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
			Me.treeView = New System.Windows.Forms.TreeView()
			Me.SuspendLayout()
			' 
			' treeView
			' 
			Me.treeView.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeView.ImageIndex = -1
			Me.treeView.Location = New System.Drawing.Point(0, 0)
			Me.treeView.Name = "treeView"
			Me.treeView.SelectedImageIndex = -1
			Me.treeView.Size = New System.Drawing.Size(240, 496)
			Me.treeView.TabIndex = 1
'			Me.treeView.ItemDrag += New System.Windows.Forms.ItemDragEventHandler(Me.treeView_ItemDrag);
			' 
			' NCustomDragDropUC
			' 
			Me.Controls.Add(Me.treeView)
			Me.Name = "NCustomDragDropUC"
			Me.Size = New System.Drawing.Size(240, 576)
			Me.Controls.SetChildIndex(Me.treeView, 0)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.DocumentPadding = New Nevron.Diagram.NMargins(20)
			view.Grid.Visible = False

			' replace the default drag drop target tool with your own one
			' to extend the drop capabilities of the view
			Dim tool As NTool = view.Controller.Tools.GetToolByName(NDWFR.ToolDragDropTarget)
			Dim index As Integer = view.Controller.Tools.IndexOf(tool)
			view.Controller.Tools.Remove(tool)

			tool = New NMyDragDropTargetTool()
			tool.Enabled = True
			view.Controller.Tools.Insert(index, tool)

			' init document
			document.BeginInit()

			' create and add your own data object adaptor
			' to extend the default set of supported data object formats
			document.DataObjectAdaptors.Add(New NMyDataObjectAdaptor())

			' create a simple group for demonstration
			Dim group As NGroup = New NGroup()

			group.Shapes.AddChild(New NRectangleShape(100, 100, 200, 200))
			group.CreateShapeElements(ShapeElementsMask.Labels)

			Dim label As NRotatedBoundsLabel = New NRotatedBoundsLabel("Drop items from the tree view in me", group.UniqueId, New Nevron.Diagram.NMargins(0))
			group.Labels.AddChild(label)
			group.Labels.DefaultLabelUniqueId = label.UniqueId

			group.Text = "Drop items from the tree view in me"
			group.UpdateModelBounds()

			document.ActiveLayer.AddChild(group)

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


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			' string items
			Dim stringItems As TreeNode = New TreeNode("String items")

			Dim string1 As TreeNode = New TreeNode("Nevron Diagram for .NET")
			string1.Tag = "Dragged and dropped text"
			stringItems.Nodes.Add(string1)

			Dim string2 As TreeNode = New TreeNode("Text2")
			string1.Tag = "Nevron Diagram for .NET"
			stringItems.Nodes.Add(string1)

			treeView.Nodes.Add(stringItems)

			' image items
			Dim imageItems As TreeNode = New TreeNode("Image items")

			Dim image1 As TreeNode = New TreeNode("Man")
			image1.Tag = NResourceHelper.BitmapFromResource(Me.GetType(), "man7.jpg", "Nevron.Examples.Diagram.WinForm.Resources")
			imageItems.Nodes.Add(image1)

			Dim image2 As TreeNode = New TreeNode("Woman")
			image2.Tag = NResourceHelper.BitmapFromResource(Me.GetType(), "woman1.jpg", "Nevron.Examples.Diagram.WinForm.Resources")
			imageItems.Nodes.Add(image2)

			treeView.Nodes.Add(imageItems)

			' shape items
			Dim shapeItems As TreeNode = New TreeNode("Shape items")

			Dim shape1 As TreeNode = New TreeNode("Rectangle")
			shape1.Tag = New NMyDataObject("Rectangle", New NSizeF(20, 30))
			shapeItems.Nodes.Add(shape1)

			Dim shape2 As TreeNode = New TreeNode("Ellipse")
			shape2.Tag = New NMyDataObject("Ellipse", New NSizeF(30, 20))
			shapeItems.Nodes.Add(shape2)

			treeView.Nodes.Add(shapeItems)

			ResumeEventsHandling()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub treeView_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles treeView.ItemDrag
			Dim node As TreeNode = CType(e.Item, TreeNode)
			If node Is Nothing OrElse node.Tag Is Nothing Then
				Return
			End If

			' create a data object
			Dim data As DataObject
			If TypeOf node.Tag Is String Then
				data = New DataObject(DataFormats.Text, node.Tag)
			ElseIf TypeOf node.Tag Is Bitmap Then
				data = New DataObject(DataFormats.Bitmap, node.Tag)
			ElseIf TypeOf node.Tag Is NMyDataObject Then
				data = New DataObject("My Custom Format", node.Tag)
			Else
				Return
			End If

			treeView.DoDragDrop(data, DragDropEffects.Copy)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents treeView As System.Windows.Forms.TreeView

		#End Region

		#Region "Nested Types"

		''' <summary>
		''' The NMyDataObject class represents custom data object which is transferred by drag and drop
		''' </summary>
		<Serializable> _
		Public Class NMyDataObject
			Public Sub New(ByVal shapeType As String, ByVal shapeSize As NSizeF)
				Me.shapeType = shapeType
				Me.shapeSize = shapeSize
			End Sub
			Public shapeType As String
			Public shapeSize As NSizeF
		End Class
		''' <summary>
		''' The NMyDataObjectAdaptor is used to adapt the bitmap and custom data objects formats
		''' </summary>
		<Serializable> _
		Public Class NMyDataObjectAdaptor
			Inherits NDataObjectAdaptor
			Public Sub New()
			End Sub

			Public ReadOnly Property Document() As NDrawingDocument
				Get
					Return Me.m_Document
				End Get
			End Property

			Public Overrides Sub UpdateReferences(ByVal provider As INReferenceProvider)
				If Not provider Is Nothing Then
					m_Document = (TryCast(provider.ProvideReference(GetType(NDrawingDocument)), NDrawingDocument))
				Else
					m_Document = Nothing
				End If

				MyBase.UpdateReferences(provider)
			End Sub
			Public Overrides Function CanAdapt(ByVal dataObject As IDataObject) As Boolean
				If dataObject Is Nothing Then
					Throw New ArgumentNullException("dataObject")
				End If

				If dataObject.GetDataPresent(DataFormats.Bitmap) Then
					Return True
				End If

				If dataObject.GetDataPresent("My Custom Format") Then
					Return True
				End If

				Return False
			End Function
			Public Overrides Function Adapt(ByVal dataObject As IDataObject) As Object
				If CanAdapt(dataObject) = False Then
					Return Nothing
				End If

				' adapt bitmap
				If dataObject.GetDataPresent(DataFormats.Bitmap) Then
					Dim bmp As Bitmap = (TryCast(dataObject.GetData(DataFormats.Bitmap), Bitmap))
					If bmp Is Nothing Then
						Return Nothing
					End If

					Return AdaptBitmap(bmp)
				End If

				' adapt my custom format
				If dataObject.GetDataPresent("My Custom Format") Then
					Dim myDataObject As NMyDataObject = (TryCast(dataObject.GetData("My Custom Format"), NMyDataObject))
					If myDataObject Is Nothing Then
						Return Nothing
					End If

					Return AdaptMyCustomFormat(myDataObject)
				End If

				Return Nothing
			End Function

			Protected Overridable Function AdaptBitmap(ByVal bmp As Bitmap) As NDrawingDataObject
				If bmp Is Nothing Then
					Throw New ArgumentNullException("bmp")
				End If

				' create a rectangle shape with the proper dimensions
				' and fill it with the bitmap
				Dim shape As NRectangleShape = New NRectangleShape(0, 0, bmp.Width, bmp.Height)
				shape.Style.FillStyle = New NImageFillStyle(bmp)

				' create a drawing data object, which encapsulates the shape
				Dim ddo As NDrawingDataObject = New NDrawingDataObject(Nothing, New INDiagramElement(){shape})
				Return ddo
			End Function
			Protected Overridable Function AdaptMyCustomFormat(ByVal myDataObject As NMyDataObject) As NDrawingDataObject
				If myDataObject Is Nothing Then
					Throw New ArgumentNullException("myDataObject")
				End If

				' create the respective shape with the specified size
				Dim shape As NShape
				If myDataObject.shapeType = "Rectangle" Then
					shape = New NRectangleShape(New NPointF(0, 0), myDataObject.shapeSize)
				ElseIf myDataObject.shapeType = "Ellipse" Then
					shape = New NEllipseShape(New NPointF(0, 0), myDataObject.shapeSize)
				Else
					Return Nothing
				End If

				' create a drawing data object, which encapsulates the shape
				Dim ddo As NDrawingDataObject = New NDrawingDataObject(Nothing, New INDiagramElement(){shape})
				Return ddo
			End Function

			<NonSerialized, NReferenceField> _
			Friend m_Document As NDrawingDocument
		End Class
		''' <summary>
		''' The NMyDragDropTargetTool class represents a tool, which drops shapes in the group below the mouse pointer.
		''' Otherwise it uses the default implementation which drops the shape in the active layer.
		''' </summary>
		<Serializable> _
		Public Class NMyDragDropTargetTool
			Inherits NDragDropTargetTool
			#Region "Constructors"

			''' <summary>
			''' Default constructor
			''' </summary>
			Public Sub New()
			End Sub


			#End Region

			#Region "Interface implementations"

			#Region "INDragDropEventProcessor"

			''' <summary>
			''' Processes the drag drop event 
			''' </summary>
			''' <remarks>
			''' Overriden to the drag drop data object in the document active layer
			''' </remarks>
			''' <param name="e"></param>
			''' <returns>true if the event was processed, otherwise false</returns> 
			Public Overrides Function ProcessDragDrop(ByVal e As DragEventArgs) As Boolean
				' check whether a group is hit, and if not use base implementation
				' which adds shapes to the active layer
				Dim mouseInDevice As NPointF = View.GetMousePositionInDevice()
				Dim group As NGroup = TryCast(View.LastActiveDocumentContentHit(mouseInDevice, -1, NFilters.TypeNGroup), NGroup)

				If group Is Nothing Then
					Return MyBase.ProcessDragDrop(e)
				End If

				' a group was hit - check desired effect
				If e.Effect <> DragDropEffects.Copy AndAlso e.Effect <> DragDropEffects.Move Then
					Return False
				End If

				' need to manually instruct that the move has ended
				EndMove(False)

				' make a custom transaction, which simply modifies the group text
				' this code can be extended to perform group specific tasks
				Document.StartTransaction("Drop elements in group")

				Try
					group.Text += Constants.vbLf & " data in: " & e.Data.GetFormats()(0) & " format dropped"
					View.Focus()
				Catch ex As Exception
					Trace.WriteLine("Failed to drop. Exception was: " & ex.Message)
					Document.Rollback()
					Return False
				End Try

				Document.Commit()
				Document.SmartRefreshAllViews()

				Return True
			End Function

			#End Region

			#End Region
		End Class

		#End Region
	End Class
End Namespace