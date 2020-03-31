Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Templates
Imports Nevron.Dom
Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NShowHideSubtreeDecoratorUC.
	''' </summary>
	Public Partial Class NShowHideSubtreeDecoratorUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NDrawingView1.RequiresInitialization Then
				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Normal

				' init document
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

			' set up visual formatting
			document.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133))
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))

			' create a stylesheet for the edges
			Dim sheet As NStyleSheet = New NStyleSheet("edges")
			sheet.Style.StartArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			sheet.Style.EndArrowheadStyle = New NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty, document.Style.FillStyle, document.Style.StrokeStyle)
			document.StyleSheets.AddChild(sheet)

			' generate a simple tree
			Dim tree As NGenericTreeTemplate = New NGenericTreeTemplate()
			tree.VerticesSize = New NSizeF(80, 80)
			tree.EdgesStyleSheetName = "edges"
			tree.Create(document)

			' create a show/hide decorator for all shapes that have children
			Dim shapes As NNodeList = document.ActiveLayer.Descendants(NFilters.Shape2D, -1)
			Dim i As Integer, count As Integer = shapes.Count
			i = 0
			Do While i < count
				Dim shape As NShape = CType(shapes(i), NShape)
				If shape.GetOutgoingShapes().Count = 0 Then
					Continue Do
				End If

				shape.CreateShapeElements(ShapeElementsMask.Decorators)
				Dim decorator As NShowHideSubtreeDecorator = New NShowHideSubtreeDecorator()
				decorator.Name = "ShowHideSubtree"
				shape.Decorators.AddChild(New NShowHideSubtreeDecorator())
				i += 1
			Loop

			' size the document to the content
			document.SizeToContent()
		End Sub

		#End Region

		#Region "Event Handlers"

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			' configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
		End Sub
		Protected Sub NDrawingView1_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)
			Dim nodes As NNodeList = NDrawingView1.HitTest(args)
			Dim decorators As NNodeList = nodes.Filter(DecoratorFilter)
			If decorators.Count > 0 Then
				CType(decorators(0), NShowHideSubtreeDecorator).ToggleState()
			End If

			NDrawingView1.Document.SmartRefreshAllViews()
		End Sub
		Protected Sub NDrawingView1_AsyncCustomCommand(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackCustomCommandArgs = TryCast(e, NCallbackCustomCommandArgs)
			Dim command As NCallbackCommand = args.Command
			Dim value As String = command.Arguments("value").ToString()

			Dim decorators As NNodeList = NDrawingView1.Document.ActiveLayer.Descendants(DecoratorFilter, -1)
			Dim i As Integer, count As Integer = decorators.Count

			Select Case command.Name
				Case "background"
					Dim background As ToggleDecoratorBackgroundShape = CType(System.Enum.Parse(GetType(ToggleDecoratorBackgroundShape), value), ToggleDecoratorBackgroundShape)
					i = 0
					Do While i < count
						CType(decorators(i), NToggleDecorator).Background.Shape = background
						i += 1
					Loop

					m_bClientSideRedrawRequired = True

				Case "symbol"
					Dim symbol As ToggleDecoratorSymbolShape = CType(System.Enum.Parse(GetType(ToggleDecoratorSymbolShape), value), ToggleDecoratorSymbolShape)
					i = 0
					Do While i < count
						CType(decorators(i), NToggleDecorator).Symbol.Shape = symbol
						i += 1
					Loop

					m_bClientSideRedrawRequired = True

				Case "position"
					Dim alignment As NContentAlignment
					Dim offset As NSizeF

					If value = "Left" Then
						alignment = New NContentAlignment(ContentAlignment.TopLeft)
						offset = New NSizeF(11, 11)
					Else
						alignment = New NContentAlignment(ContentAlignment.TopRight)
						offset = New NSizeF(-11, 11)
					End If

					i = 0
					Do While i < count
						Dim decorator As NToggleDecorator = CType(decorators(i), NToggleDecorator)
						decorator.Alignment = alignment
						decorator.Offset = offset
						i += 1
					Loop

					m_bClientSideRedrawRequired = True
			End Select
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

		#Region "Constants"

		Private Shared ReadOnly DecoratorFilter As NFilter = New NInstanceOfTypeFilter(GetType(NShowHideSubtreeDecorator))

		#End Region
	End Class
End Namespace