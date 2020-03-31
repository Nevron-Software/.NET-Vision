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
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NOrthogonalGraphLayoutUC.
	''' </summary>
	Public Partial Class NOrthogonalGraphLayoutUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NDrawingView1.RequiresInitialization Then
				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit
				NDrawingView1.GlobalVisibility.ShowPorts = False
				NDrawingView1.GlobalVisibility.ShowArrowheads = False

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
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed

			' set up visual formatting
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			Dim sheet As NStyleSheet = New NStyleSheet("edges")
			sheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			sheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.StyleSheets.AddChild(sheet)

			' create a tree
			CreateDiagram()

			' perform the layout
			PerformLayout(Nothing)
		End Sub
		Private Sub CreateDiagram()
			Const width As Integer = 100, height As Integer = 100, distance As Integer = 200
			Dim f As NBasicShapesFactory = New NBasicShapesFactory(NDrawingView1.Document)
			Dim edge As NRoutableConnector
			Dim from As Integer() = New Integer() { 1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 6 }
			Dim [to] As Integer() = New Integer() { 2, 3, 4, 4, 5, 8, 6, 7, 5, 8, 10, 8, 9, 10 }
			Dim shapes As NShape() = New NShape(9){}
			Dim vertexCount As Integer = shapes.Length
			Dim edgeCount As Integer = from.Length
			Dim count As Integer = vertexCount + edgeCount

			Dim i As Integer = 0
			Do While i < count
				If i < vertexCount Then
					Dim j As Integer
					If vertexCount Mod 2 = 0 Then
						j = i
					Else
						j = i + 1
					End If
					shapes(i) = f.CreateShape(CInt(Fix(BasicShapes.Rectangle)))

					If vertexCount Mod 2 <> 0 AndAlso i = 0 Then
						shapes(i).Bounds = New NRectangleF(CInt(Fix(width + (distance * 1.5))) / 2, distance + (j / 2) * CInt(Fix(distance * 1.5)), width, height)
					Else
						shapes(i).Bounds = New NRectangleF(width / 2 + (j Mod 2) * CInt(Fix(distance * 1.5)), height + (j / 2) * CInt(Fix(distance * 1.5)), width, height)
					End If

					NDrawingView1.Document.ActiveLayer.AddChild(shapes(i))
				Else
					edge = New NRoutableConnector()
					edge.ConnectorType = RoutableConnectorType.DynamicPolyline
					edge.StyleSheetName = "edges"
					NDrawingView1.Document.ActiveLayer.AddChild(edge)
					edge.FromShape = shapes(from(i - vertexCount) - 1)
					edge.ToShape = shapes([to](i - vertexCount) - 1)
				End If
				i += 1
			Loop
		End Sub
		Private Sub CreateGraph(ByVal vertexCount As Integer, ByVal edgeCount As Integer)
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren()

			Dim randomGraph As NRandomGraphTemplate = New NRandomGraphTemplate()
			randomGraph.EdgesStyleSheetName = "edges"
			randomGraph.VertexCount = vertexCount
			randomGraph.EdgeCount = edgeCount
			randomGraph.Create(NDrawingView1.Document)
		End Sub
		Private Sub PerformLayout(ByVal args As Hashtable)
			' Create the layout
			Dim layout As NOrthogonalGraphLayout = New NOrthogonalGraphLayout()

			' Configure the layout
			NLayoutsHelper.ConfigureLayout(layout, args)

			' Get the shapes to layout
			Dim shapes As NNodeList = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D)

			' Layout the shapes
			layout.Layout(shapes, New NDrawingLayoutContext(NDrawingView1.Document))

			' Resize document to fit all shapes
			NDrawingView1.Document.SizeToContent()
		End Sub

		#End Region 

		#Region "Event Handlers"

		Protected Sub NDrawingView1_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Select Case args.Command.Name
				Case "btn1"
					CreateGraph(10, 15)

				Case "btn2"
					CreateGraph(20, 25)
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