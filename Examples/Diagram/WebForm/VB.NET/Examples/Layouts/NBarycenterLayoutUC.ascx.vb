Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
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
	'''	Summary description for NBarycenterLayoutUC.
	''' </summary>
	Public Partial Class NBarycenterLayoutUC
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

			Dim sheet As NStyleSheet = New NStyleSheet("edges")
			sheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			sheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.StyleSheets.AddChild(sheet)

			' Create the initial diagram
			Dim renderer As DiagramRenderer = New DiagramRenderer()
			renderer.CreateRandomDiagram(document, 15, 15)

			' Layout the diagram
			renderer.ApplyLayout(document, Nothing)

			' Resize document to fit all shapes
			document.SizeToContent()
		End Sub

		#End Region

		#Region "Nested Types"

		<Serializable> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
			#Region "INCustomRequestCallback Members"

			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim document As NDrawingDocument = diagramControl.Document

				Dim helper As NDrawingDocumentHelper = New NDrawingDocumentHelper(document)
				Dim settings As Dictionary(Of String, String) = helper.ParseSettings(argument)

				Dim renderer As DiagramRenderer = New DiagramRenderer()
				Select Case settings("command")
					Case "randomGrid1Button"
						renderer.CreateRandomDiagram(document, 10, 10)
					Case "randomGrid2Button"
						renderer.CreateRandomDiagram(document, 15, 15)
					Case "triangularGrid1Button"
						renderer.CreateTriangularGridDiagram(document, 6)
					Case "triangularGrid2Button"
						renderer.CreateTriangularGridDiagram(document, 8)
				End Select

				' Layout the diagram
				renderer.ApplyLayout(document, settings)

				' Resize document to fit all shapes
				document.SizeToContent()

				' Update the view
				diagramControl.UpdateView()
			End Sub

			#End Region
		End Class

		Private Class DiagramRenderer
			Public Sub CreateRandomDiagram(ByVal document As NDrawingDocument, ByVal fixedCount As Integer, ByVal freeCount As Integer)
				If fixedCount < 3 Then
					Throw New ArgumentException("Needs at least three fixed vertices")
				End If

				' clean up the layers
				document.ActiveLayer.RemoveAllChildren()

				' we will be using basic circle shapes with default size of (30, 30)
				Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
				basicShapesFactory.DefaultSize = New NSizeF(30, 30)

				' create the fixed vertices
				Dim fixedShapes As NShape() = New NShape(fixedCount - 1){}

				Dim i As Integer = 0
				Do While i < fixedCount
					fixedShapes(i) = basicShapesFactory.CreateShape(BasicShapes.Circle)
					CType(fixedShapes(i).Ports.GetChildByName("Center", -1), NDynamicPort).GlueMode = DynamicPortGlueMode.GlueToLocation
					fixedShapes(i).Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
					fixedShapes(i).Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

					' setting the ForceXMoveable and ForceYMoveable properties to false
					' specifies that the layout cannot move the shape in both X and Y directions
					fixedShapes(i).LayoutData.ForceXMoveable = False
					fixedShapes(i).LayoutData.ForceYMoveable = False

					document.ActiveLayer.AddChild(fixedShapes(i))
					i += 1
				Loop

				' create the free vertices
				Dim freeShapes As NShape() = New NShape(freeCount - 1){}
				i = 0
				Do While i < freeCount
					freeShapes(i) = basicShapesFactory.CreateShape(BasicShapes.Circle)
					CType(freeShapes(i).Ports.GetChildByName("Center", -1), NDynamicPort).GlueMode = DynamicPortGlueMode.GlueToLocation
					freeShapes(i).Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
					freeShapes(i).Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
					document.ActiveLayer.AddChild(freeShapes(i))
					i += 1
				Loop

				' link the fixed shapes in a circle
				i = 0
				Do While i < fixedCount
					Dim lineShape As NLineShape = New NLineShape()
					document.ActiveLayer.AddChild(lineShape)

					If i = 0 Then
						lineShape.FromShape = fixedShapes(fixedCount - 1)
						lineShape.ToShape = fixedShapes(0)
					Else
						lineShape.FromShape = fixedShapes(i - 1)
						lineShape.ToShape = fixedShapes(i)
					End If
					i += 1
				Loop

				' link each free shape with two different random fixed shapes
				Dim rnd As Random = New Random()
				i = 0
				Do While i < freeCount
					Dim firstFixed As Integer = rnd.Next(fixedCount)
					Dim secondFixed As Integer = (firstFixed + rnd.Next(fixedCount / 3) + 1) Mod fixedCount

					' link with first fixed
					Dim lineShape As NLineShape = New NLineShape()
					document.ActiveLayer.AddChild(lineShape)

					lineShape.FromShape = freeShapes(i)
					lineShape.ToShape = fixedShapes(firstFixed)

					' link with second fixed
					lineShape = New NLineShape()
					document.ActiveLayer.AddChild(lineShape)

					lineShape.FromShape = freeShapes(i)
					lineShape.ToShape = fixedShapes(secondFixed)
					i += 1
				Loop

				' link each free shape with another free shape
				i = 1
				Do While i < freeCount
					Dim lineShape As NLineShape = New NLineShape()
					document.ActiveLayer.AddChild(lineShape)

					lineShape.FromShape = freeShapes(i - 1)
					lineShape.ToShape = freeShapes(i)
					i += 1
				Loop

				Dim batchReorder As NBatchReorder = New NBatchReorder(document)
				batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D))
				batchReorder.SendToBack(False)
			End Sub
			Public Sub CreateTriangularGridDiagram(ByVal document As NDrawingDocument, ByVal levels As Integer)
				' clean up the active layer 
				document.ActiveLayer.RemoveAllChildren()

				' we will be using basic circle shapes with default size of (30, 30)
				Dim basicShapesFactory As NBasicShapesFactory = New NBasicShapesFactory()
				basicShapesFactory.DefaultSize = New NSizeF(30, 30)

				Dim cur As NShape = Nothing, prev As NShape = Nothing
				Dim edge As NShape = Nothing
				Dim curRowShapes As List(Of NShape) = Nothing
				Dim prevRowShapes As List(Of NShape) = Nothing

				Dim level As Integer = 1
				Do While level < levels
					curRowShapes = New List(Of NShape)()

					Dim i As Integer = 0
					Do While i < level
						cur = basicShapesFactory.CreateShape(BasicShapes.Circle)
						CType(cur.Ports.GetChildByName("Center", -1), NDynamicPort).GlueMode = DynamicPortGlueMode.GlueToLocation
						cur.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
						cur.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
						document.ActiveLayer.AddChild(cur)

						' connect with prev
						If i > 0 Then
							edge = New NLineShape()
							document.ActiveLayer.AddChild(edge)

							edge.FromShape = prev
							edge.ToShape = cur
						End If

						' connect with ancestors
						If level > 1 Then
							If i < prevRowShapes.Count Then
								edge = New NLineShape()
								document.ActiveLayer.AddChild(edge)

								edge.FromShape = prevRowShapes(i)
								edge.ToShape = cur
							End If

							If i > 0 Then
								edge = New NLineShape()
								document.ActiveLayer.AddChild(edge)

								edge.FromShape = prevRowShapes(i - 1)
								edge.ToShape = cur
							End If
						End If

						' fix the three corner vertices
						If level = 1 OrElse (level = levels - 1 AndAlso (i = 0 OrElse i = level - 1)) Then
							cur.LayoutData.ForceXMoveable = False
							cur.LayoutData.ForceYMoveable = False
							cur.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
							cur.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
						End If

						curRowShapes.Add(cur)
						prev = cur
						i += 1
					Loop

					prevRowShapes = curRowShapes
					level += 1
				Loop

				Dim batchReorder As NBatchReorder = New NBatchReorder(document)
				batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D))
				batchReorder.SendToBack(False)
			End Sub
			Public Sub ApplyLayout(ByVal document As NDrawingDocument, ByVal settings As Dictionary(Of String, String))
				' Create the layout
				Dim layout As NBarycenterLayout = New NBarycenterLayout()

				' Configure the optional forces
				layout.BounceBackForce.RepulsionCoefficient = 20f
				layout.GravityForce.AttractionCoefficient = 0.2f

				' Free vertices are placed in the fixed vertices barycenter
				layout.FreeVertexPlacement.Mode = FreeVertexPlacementMode.FixedBarycenter

				' Fixed vertices are placed on the rim of the specified ellipse
				layout.FixedVertexPlacement.Mode = FixedVertexPlacementMode.PredefinedEllipseRim
				layout.FixedVertexPlacement.PredefinedEllipseBounds = New NRectangleF(0, 0, 700, 700)

				' Configure the layout
				If Not settings Is Nothing Then
					layout.BounceBackForce.Enabled = Boolean.Parse(settings("BounceBackForce"))
					layout.GravityForce.Enabled = Boolean.Parse(settings("GravityForce"))
					layout.MinFixedVerticesCount = Int32.Parse(settings("MinFixedVerticesCount"))
				End If

				' Get the shapes to layout
				Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

				' Layout the shapes
				layout.Layout(shapes, New NDrawingLayoutContext(document))
			End Sub
		End Class

		#End Region
	End Class
End Namespace