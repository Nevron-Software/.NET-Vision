Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NShowHideSubtreeDecoratorUC.
	''' </summary>
	Partial Public Class NShowHideSubtreeDecoratorUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized = False Then
				' Init the thin diagram control
				NThinDiagramControl1.CustomRequestCallback = New CustomRequestCallback()

				' Set manual ID so that it can be referenced in JavaScript
				NThinDiagramControl1.StateId = "Diagram1"

				' Configure the controller
				Dim serverMouseEventTool As NServerMouseEventTool = New NServerMouseEventTool()
				NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool)
				serverMouseEventTool.MouseDown = New NMouseDownEventCallback()

				' Init the document
				Dim document As NDrawingDocument = NThinDiagramControl1.Document
				document.BeginInit()
				InitDocument(document)
				document.EndInit()
			End If
		End Sub

#Region "Implementation"

		Private Sub InitDocument(ByVal document As NDrawingDocument)
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

#Region "Fields"

		Private m_bClientSideRedrawRequired As Boolean = False

#End Region

#Region "Constants"

		Private Shared ReadOnly ShowHideSubtreeDecoratorFilter As NFilter = New NInstanceOfTypeFilter(GetType(NShowHideSubtreeDecorator))

#End Region

#Region "Nested Types"

		<Serializable()> _
		Private Class NMouseDownEventCallback
			Implements INMouseEventCallback
#Region "INMouseEventCallback Members"

			Private Sub OnMouseEvent(ByVal control As NAspNetThinWebControl, ByVal e As NBrowserMouseEventArgs) Implements INMouseEventCallback.OnMouseEvent
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim nodes As NNodeList = diagramControl.HitTest(New NPointF(e.X, e.Y))
				Dim decorators As NNodeList = nodes.Filter(ShowHideSubtreeDecoratorFilter)

				If decorators.Count > 0 Then
					CType(decorators(0), NShowHideSubtreeDecorator).ToggleState()
					diagramControl.UpdateView()
				End If
			End Sub

#End Region
		End Class

		<Serializable()> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
#Region "INCustomRequestCallback Members"

			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim decorators As NNodeList = diagramControl.Document.ActiveLayer.Descendants(ShowHideSubtreeDecoratorFilter, -1)

				Dim i As Integer, count As Integer = decorators.Count
				Dim data As String() = argument.Split("="c)
				Dim name As String = data(0)
				Dim value As String = data(1)

				Select Case name
					Case "background"
						Dim background As ToggleDecoratorBackgroundShape = CType(System.Enum.Parse(GetType(ToggleDecoratorBackgroundShape), value), ToggleDecoratorBackgroundShape)
						i = 0
						Do While i < count
							CType(decorators(i), NToggleDecorator).Background.Shape = background
							i += 1
						Loop

					Case "symbol"
						Dim symbol As ToggleDecoratorSymbolShape = CType(System.Enum.Parse(GetType(ToggleDecoratorSymbolShape), value), ToggleDecoratorSymbolShape)
						i = 0
						Do While i < count
							CType(decorators(i), NToggleDecorator).Symbol.Shape = symbol
							i += 1
						Loop

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
				End Select

				control.UpdateView()
			End Sub

#End Region
		End Class

#End Region
	End Class
End Namespace