Imports Microsoft.VisualBasic
Imports System.Drawing
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NThinWebGeneral.
	''' </summary>
	Public Partial Class NPostbackToolUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			Dim document As NDrawingDocument = NThinDiagramControl1.Document

			If (Not NThinDiagramControl1.Initialized) Then
				NThinDiagramControl1.View.Layout = CanvasLayout.Fit
				' add the client mouse event tool
				NThinDiagramControl1.Controller.Tools.Add(New NPostbackTool())

				document.BeginInit()

				document.BackgroundStyle.FrameStyle.Visible = False
				document.AutoBoundsPadding = New Nevron.Diagram.NMargins(10f, 10f, 10f, 10f)
				document.Style.FillStyle = New NColorFillStyle(Color.White)

				Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)

				Dim outerCircle As NShape = factory.CreateShape(BasicShapes.Circle)
				outerCircle.Bounds = New NRectangleF(0f, 0f, 200f, 200f)
				document.ActiveLayer.AddChild(outerCircle)

				Dim rect As NShape = factory.CreateShape(BasicShapes.Rectangle)
				rect.Bounds = New NRectangleF(42f, 42f, 50f, 50f)
				rect.Style.FillStyle = New NColorFillStyle(Color.LightBlue)
				rect.Style.InteractivityStyle = CreateInteractivityStyle("Rectangle")
				rect.Tag = True
				document.ActiveLayer.AddChild(rect)

				Dim triangle As NShape = factory.CreateShape(BasicShapes.Triangle)
				triangle.Bounds = New NRectangleF(121f, 57f, 60f, 55f)
				triangle.Style.FillStyle = New NColorFillStyle(Color.LightBlue)
				triangle.Style.InteractivityStyle = CreateInteractivityStyle("Triangle")
				triangle.Tag = True
				document.ActiveLayer.AddChild(triangle)

				Dim pentagon As NShape = factory.CreateShape(BasicShapes.Pentagon)
				pentagon.Bounds = New NRectangleF(60f, 120f, 54f, 50f)
				pentagon.Style.FillStyle = New NColorFillStyle(Color.LightBlue)
				pentagon.Style.InteractivityStyle = CreateInteractivityStyle("Pentagon")
				pentagon.Tag = True
				document.ActiveLayer.AddChild(pentagon)

				document.SizeToContent()
				document.EndInit()
			End If

			' Create a few simple shapes with attached client mouse event interactivity
			AddHandler NThinDiagramControl1.Postback, AddressOf NThinDiagramControl1_Postback
			NThinDiagramControl1.Controller.Tools.Clear()

			Dim tooltipTool As NTooltipTool = New NTooltipTool()
			NThinDiagramControl1.Controller.Tools.Add(tooltipTool)

			Dim postbackTool As NPostbackTool = New NPostbackTool()
'          postbackTool.PostbackOnlyOnInteractiveItems = PostbackOnlyOnInteractiveItemsCheckBox.Checked;
			NThinDiagramControl1.Controller.Tools.Add(postbackTool)
		End Sub

		Private Sub NThinDiagramControl1_Postback(ByVal sender As Object, ByVal e As ThinWeb.NPostbackEventArgs)
			Dim diagramControl As NThinDiagramControl = CType(sender, NThinDiagramControl)
			Dim allShapes As NNodeList = diagramControl.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)
			Dim hitNodes As NNodeList = diagramControl.HitTest(e.MousePosition.ToNPointF())
			hitNodes = hitNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)

			For Each shape As NShape In allShapes
				If NSystem.SafeEquals(shape.Tag, True) Then
					shape.Style.FillStyle = New NColorFillStyle(Color.LightBlue)
				End If
			Next shape

			For Each shape As NShape In hitNodes
				If NSystem.SafeEquals(shape.Tag, True) Then
					shape.Style.FillStyle = New NColorFillStyle(Color.Red)
				End If
			Next shape
		End Sub


		Private Function CreateInteractivityStyle(ByVal shapeName As String) As NInteractivityStyle
			Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle("Click on me to make me Red")
			Return interactivityStyle
		End Function
	End Class
End Namespace