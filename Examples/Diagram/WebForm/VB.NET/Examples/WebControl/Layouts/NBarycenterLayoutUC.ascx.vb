Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Reflection
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Imports Nevron.Diagram.Layout
Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.WebForm
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NBarycenterLayoutUC.
	''' </summary>
	Public Partial Class NBarycenterLayoutUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NDrawingView1.RequiresInitialization Then
				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit

				' init document
				NDrawingView1.Document.HistoryService.Stop()
				NDrawingView1.Document.BeginInit()
				InitDocument()
				NDrawingView1.Document.EndInit()

				PerformLayout(Nothing)
			End If
		End Sub

		#Region "Implementation"

		Private Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document

			' remove the standard frame
			document.BackgroundStyle.FrameStyle.Visible = False

			' adjust the graphics quality
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

			' set up visual formatting
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			Dim sheet As NStyleSheet = New NStyleSheet("edges")
			sheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			sheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.StyleSheets.AddChild(sheet)

			' create the initial diagram
			CreateRandomDiagram(15, 15)
			PerformLayout(Nothing)

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub CreateRandomDiagram(ByVal fixedCount As Integer, ByVal freeCount As Integer)
			If fixedCount < 3 Then
				Throw New ArgumentException("Needs at least three fixed vertices")
			End If

			Dim document As NDrawingDocument = NDrawingView1.Document

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
		Private Sub CreateTriangularGridDiagram(ByVal levels As Integer)
			Dim document As NDrawingDocument = NDrawingView1.Document

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
		Private Sub PerformLayout(ByVal args As Hashtable)
			' create a layout
			Dim layout As NBarycenterLayout = New NBarycenterLayout()

			' configure the optional forces
			layout.BounceBackForce.RepulsionCoefficient = 20f
			layout.GravityForce.AttractionCoefficient = 0.2f

			' free vertices are placed in the fixed vertices barycenter
			layout.FreeVertexPlacement.Mode = FreeVertexPlacementMode.FixedBarycenter

			' fixed vertices are placed on the rim of the specified ellipse
			layout.FixedVertexPlacement.Mode = FixedVertexPlacementMode.PredefinedEllipseRim
			layout.FixedVertexPlacement.PredefinedEllipseBounds = New NRectangleF(0, 0, 700, 700)

			' configure the layout
			If Not args Is Nothing Then
				layout.BounceBackForce.Enabled = Boolean.Parse(args("BounceBackForce").ToString())
				layout.GravityForce.Enabled = Boolean.Parse(args("GravityForce").ToString())
				layout.MinFixedVerticesCount = Int32.Parse(args("MinFixedVerticesCount").ToString())
			End If

			' get the shapes to layout
			Dim shapes As NNodeList = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D)

			' layout the shapes
			layout.Layout(shapes, New NDrawingLayoutContext(NDrawingView1.Document))

			' resize document to fit all shapes
			NDrawingView1.Document.SizeToContent()
		End Sub

		#End Region

		#Region "Event Handlers"

		Protected Sub NDrawingView1_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Select Case args.Command.Name
				Case "randomGrid1Button"
					CreateRandomDiagram(10, 10)

				Case "randomGrid2Button"
					CreateRandomDiagram(15, 15)

				Case "triangularGrid1Button"
					CreateTriangularGridDiagram(6)

				Case "triangularGrid2Button"
					CreateTriangularGridDiagram(8)
			End Select

			PerformLayout(args.Command.Arguments)
			m_bClientSideRedrawRequired = True
		End Sub
		Protected Sub NDrawingView1_AsyncQueryCommandResult(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackQueryCommandResultArgs = TryCast(e, NCallbackQueryCommandResultArgs)
			Dim resultBuilder As NAjaxXmlTransportBuilder = args.ResultBuilder
			If m_bClientSideRedrawRequired AndAlso (Not resultBuilder.ContainsRedrawDataSection()) Then
				resultBuilder.AddRedrawDataSection(NDrawingView1)
			End If
		End Sub

		#End Region

		#Region "Fields"

		Private m_bClientSideRedrawRequired As Boolean = False

		#End Region
	End Class
End Namespace