Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NBalloonTreeLayoutUC.
	''' </summary>
	Public Partial Class NBalloonTreeLayoutUC
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
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

			' Set up visual formatting
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			Dim sheet As NStyleSheet = New NStyleSheet("edges")
			sheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			sheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.StyleSheets.AddChild(sheet)

			' Create a tree
			CreateTree()

			' Create the layout
			Dim layout As NBalloonTreeLayout = New NBalloonTreeLayout()

			' Get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' Layout the shapes
			layout.Layout(shapes, New NDrawingLayoutContext(document))

			' Resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Protected Sub CreateTree()
			' Clear the document
			Dim document As NDrawingDocument = NThinDiagramControl1.Document
			document.ActiveLayer.RemoveAllChildren()

			' Create a tree
			Dim tree As NGenericTreeTemplate = New NGenericTreeTemplate()
			tree.LayoutScheme = TreeLayoutScheme.None
			tree.Levels = 4
			tree.BranchNodes = 4
			tree.HorizontalSpacing = 10
			tree.VerticalSpacing = 10
			tree.ConnectorType = ConnectorType.Line
			tree.VerticesShape = BasicShapes.Circle
			tree.VerticesSize = New NSizeF(40, 40)
			tree.EdgesStyleSheetName = "edges"
			tree.Create(document)
		End Sub

		#End Region

		#Region "Fields"

		Private m_bClientSideRedrawRequired As Boolean = False

		#End Region

		#Region "Nested Types"

		<Serializable> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
			#Region "INCustomRequestCallback Members"

			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim document As NDrawingDocument = diagramControl.Document

				' Create the layout
				Dim layout As NBalloonTreeLayout = New NBalloonTreeLayout()

				' Configure the layout
				Dim helper As NDrawingDocumentHelper = New NDrawingDocumentHelper(document)
				Dim settings As Dictionary(Of String, String) = helper.ParseSettings(argument)
				helper.ConfigureLayout(layout, settings)

				' Get the shapes to layout
				Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

				' Layout the shapes
				layout.Layout(shapes, New NDrawingLayoutContext(document))

				' Resize document to fit all shapes
				document.SizeToContent()

				' Update the view
				diagramControl.UpdateView()
			End Sub

			#End Region
		End Class

		#End Region
	End Class
End Namespace