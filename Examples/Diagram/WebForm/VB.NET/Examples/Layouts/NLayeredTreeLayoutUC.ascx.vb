Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NLayeredTreeLayoutUC.
	''' </summary>
	Public Partial Class NLayeredTreeLayoutUC
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

		Protected Sub InitDocument(ByVal document As NDrawingDocument)
			' Remove the standard frame
			document.BackgroundStyle.FrameStyle.Visible = False

			' Adjust the graphics quality
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed

			' Set up visual formatting
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			Dim sheet As NStyleSheet = New NStyleSheet("edges")
			sheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			sheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.StyleSheets.AddChild(sheet)

			' Create a tree
			Dim renderer As DiagramRenderer = New DiagramRenderer()
			renderer.CreateTree(document, 6, 3)

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
					Case "RandomTree6Levels"
						renderer.CreateTree(document, 6, 3)
					Case "RandomTree8Levels"
						renderer.CreateTree(document, 8, 2)
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
				' Clear the document
				document.ActiveLayer.RemoveAllChildren()

				' Create a tree
				Dim tree As NGenericTreeTemplate = New NGenericTreeTemplate()
				tree.Balanced = False
				tree.Levels = levels
				tree.BranchNodes = branchNodes
				tree.HorizontalSpacing = 10
				tree.VerticalSpacing = 10
				tree.VerticesSize = New NSizeF(50, 50)
				tree.VertexSizeDeviation = 1
				tree.EdgesStyleSheetName = "edges"
				tree.Create(document)
			End Sub
			Public Sub ApplyLayout(ByVal document As NDrawingDocument, ByVal settings As Dictionary(Of String, String))
				' Create the layout
				Dim layout As NLayeredTreeLayout = New NLayeredTreeLayout()

				' Configure the layout
				If Not settings Is Nothing Then
					Dim helper As NDrawingDocumentHelper = New NDrawingDocumentHelper(document)
					helper.ConfigureLayout(layout, settings)
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