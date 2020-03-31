Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NSymmetricalLayoutUC.
	''' </summary>
	Public Partial Class NSymmetricalLayoutUC
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
			document.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)

			' create a tree
			CreateTree(4, 3)

			' perform the layout
			PerformLayout(Nothing)
		End Sub
		Private Sub CreateTree(ByVal levels As Integer, ByVal branchNodes As Integer)
			' clean up the active layer
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren()

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
					NDrawingView1.Document.ActiveLayer.AddChild(cur)

					' connect with ancestor
					If level > 1 Then
						edge = New NLineShape()
						NDrawingView1.Document.ActiveLayer.AddChild(edge)

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
			Dim batchReorder As NBatchReorder = New NBatchReorder(NDrawingView1.Document)
			batchReorder.Build(NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape1D))
			batchReorder.SendToBack(False)
		End Sub
		Private Sub PerformLayout(ByVal args As Hashtable)
			' create a layout
			Dim layout As NSymmetricalLayout = New NSymmetricalLayout()

			' configure the optional forces
			layout.BounceBackForce.Padding = 100f
			layout.GravityForce.AttractionCoefficient = 0.2f
			layout.MagneticFieldForce.DistancePower = 0.6f
			layout.MagneticFieldForce.FieldDirection = MagneticFieldDirection.OrthogonalLeftwardDownward
			layout.MagneticFieldForce.MagnetizationType = MagnetizationType.Unidirectional
			layout.MagneticFieldForce.TorsionCoefficient = 2f

			' create a layout context
			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(NDrawingView1.Document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(NDrawingView1.Document)

			' configure layout
			If Not args Is Nothing Then
				layout.BounceBackForce.Enabled = Boolean.Parse(args("BounceBackForce").ToString())
				layout.GravityForce.Enabled = Boolean.Parse(args("GravityForce").ToString())
				layout.MagneticFieldForce.Enabled = Boolean.Parse(args("MagneticFieldForce").ToString())
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
				Case "btn1"
					CreateTree(4, 3)

				Case "btn2"
					CreateTree(5, 2)
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