Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Templates
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NRadialGraphLayoutUC.
	''' </summary>
	Public Partial Class NRadialGraphLayoutUC
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
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality

			' set up visual formatting
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			Dim sheet As NStyleSheet = New NStyleSheet("edges")
			sheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			sheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.StyleSheets.AddChild(sheet)

			' create a tree
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
			tree.Create(NDrawingView1.Document)

			' perform the layout
			PerformLayout(Nothing)
		End Sub
		Private Sub PerformLayout(ByVal args As Hashtable)
			' create a layout
			Dim layout As NRadialGraphLayout = New NRadialGraphLayout()

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