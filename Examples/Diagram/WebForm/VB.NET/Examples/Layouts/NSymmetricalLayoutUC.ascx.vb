Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NSymmetricalLayoutUC.
	''' </summary>
	Public Partial Class NSymmetricalLayoutUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized Then
				Return
			End If

			' Init the diagram control
			NThinDiagramControl1.StateId = "Diagram1"
			NThinDiagramControl1.CustomRequestCallback = New CustomRequestCallback()

			' Init the view
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit

			' Init the document
			Dim document As NDrawingDocument = NThinDiagramControl1.Document
			document.BeginInit()
			InitDocument(document)
			document.EndInit()
		End Sub

		#Region "Implementation"

		Private Sub InitDocument(ByVal document As NDrawingDocument)
			' Remove the standard frame
			document.BackgroundStyle.FrameStyle.Visible = False

			' Adjust the graphics quality
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

			' Set up visual formatting
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, String.Empty, NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, String.Empty, NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)

			' Create a tree
			Dim renderer As DiagramRenderer = New DiagramRenderer()
			renderer.CreateTree(document, 4, 3)

			' Apply the layout
			renderer.ApplyLayout(document, Nothing)

			' Resize document to fit all shapes
			document.SizeToContent()
		End Sub

		#End Region

		#Region "Nested Types"

		<Serializable> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim document As NDrawingDocument = diagramControl.Document

				Dim helper As NDrawingDocumentHelper = New NDrawingDocumentHelper(document)
				Dim settings As Dictionary(Of String, String) = helper.ParseSettings(argument)

				Dim renderer As DiagramRenderer = New DiagramRenderer()
				Select Case settings("command")
					Case "Tree4Levels"
						renderer.CreateTree(document, 4, 3)
					Case "Tree5Levels"
						renderer.CreateTree(document, 5, 2)
				End Select

				' Layout the diagram
				renderer.ApplyLayout(document, settings)

				' Resize document to fit all shapes
				document.SizeToContent()

				' Update the view
				diagramControl.UpdateView()
			End Sub
		End Class

		Private Class DiagramRenderer
			Public Sub CreateTree(ByVal document As NDrawingDocument, ByVal levels As Integer, ByVal branchNodes As Integer)
				' clean up the active layer
				document.ActiveLayer.RemoveAllChildren()

				' we will be using basic shapes with 40, 40 size
				Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
				basicShapesFactory.DefaultSize = New NSizeF(40, 40)

				Dim cur As NShape = Nothing
				Dim edge As NShape = Nothing

				Dim curRowNodes As List(Of NShape) = Nothing
				Dim prevRowNodes As List(Of NShape) = Nothing

				Dim i, level As Integer
				Dim levelNodesCount As Integer

				level = 1
				Do While level <= levels
					curRowNodes = New List(Of NShape)()

					'Create a balanced tree
					levelNodesCount = CInt(Fix(Math.Pow(branchNodes, level - 1)))
					i = 0
					Do While i < levelNodesCount
						' create the cur node
						cur = basicShapesFactory.CreateShape(BasicShapes.Circle)
						CType(cur.Ports.GetChildByName("Center", -1), NDynamicPort).GlueMode = DynamicPortGlueMode.GlueToLocation
						document.ActiveLayer.AddChild(cur)

						' connect with ancestor
						If level > 1 Then
							edge = New NLineShape()
							document.ActiveLayer.AddChild(edge)

							Dim parentIndex As Integer = CInt(Fix(Math.Floor(CDbl(i / branchNodes))))
							edge.FromShape = prevRowNodes(parentIndex)
							edge.ToShape = cur
						End If

						curRowNodes.Add(cur)
						i += 1
					Loop

					prevRowNodes = curRowNodes
					level += 1
				Loop

				' send links to back
				Dim batchReorder As NBatchReorder = New NBatchReorder(document)
				batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D))
				batchReorder.SendToBack(False)
			End Sub
			Public Sub ApplyLayout(ByVal document As NDrawingDocument, ByVal settings As Dictionary(Of String, String))
				' create a layout
				Dim layout As NSymmetricalLayout = New NSymmetricalLayout()

				' configure the optional forces
				layout.BounceBackForce.Padding = 100f
				layout.GravityForce.AttractionCoefficient = 0.2f
				layout.MagneticFieldForce.DistancePower = 0.6f
				layout.MagneticFieldForce.FieldDirection = MagneticFieldDirection.OrthogonalLeftwardDownward
				layout.MagneticFieldForce.MagnetizationType = MagnetizationType.Unidirectional
				layout.MagneticFieldForce.TorsionCoefficient = 2f

				' configure layout
				If Not settings Is Nothing Then
					layout.BounceBackForce.Enabled = Boolean.Parse(settings("BounceBackForce"))
					layout.GravityForce.Enabled = Boolean.Parse(settings("GravityForce"))
					layout.MagneticFieldForce.Enabled = Boolean.Parse(settings("MagneticFieldForce"))
				End If

				' get the shapes to layout
				Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

				' layout the shapes
				layout.Layout(shapes, New NDrawingLayoutContext(document))
			End Sub
		End Class

		#End Region
	End Class
End Namespace