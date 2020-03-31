Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NMouseEvents.
	''' </summary>
	Public Partial Class NMouseEventsUC
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

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseDoubleClickCallbackTool(False))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseMoveCallbackTool(False))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseDownCallbackTool(False))
			NDrawingView1.AjaxTools.Add(New NAjaxMouseUpCallbackTool(False))
		End Sub

		Protected Sub simulatePostbackButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			'	select the default enabled state of the mouse tools
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseClickCallbackTool)).DefaultEnabled = (Not Request("mouseClickCheckbox") Is Nothing)
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseDoubleClickCallbackTool)).DefaultEnabled = (Not Request("mouseDoubleClickCheckbox") Is Nothing)
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseMoveCallbackTool)).DefaultEnabled = (Not Request("mouseMoveCheckbox") Is Nothing)
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseDownCallbackTool)).DefaultEnabled = (Not Request("mouseDownCheckbox") Is Nothing)
			NDrawingView1.AjaxTools.GetToolByType(GetType(NAjaxMouseUpCallbackTool)).DefaultEnabled = (Not Request("mouseUpCheckbox") Is Nothing)

			'	select the default enabled state of client side services
			NDrawingView1.AsyncRequestWaitCursorEnabled = (Not Request("waitCursorCheckbox") Is Nothing)

			simulatePostbackLabel.Text = "Postback simulated!"
		End Sub


		Protected Sub NDrawingView1_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			OnMouseEvent(sender, e)
		End Sub

		Protected Sub NDrawingView1_AsyncDoubleClick(ByVal sender As Object, ByVal e As EventArgs)
			OnMouseEvent(sender, e)
		End Sub

		Protected Sub NDrawingView1_AsyncMouseDown(ByVal sender As Object, ByVal e As EventArgs)
			OnMouseEvent(sender, e)
		End Sub

		Protected Sub NDrawingView1_AsyncMouseMove(ByVal sender As Object, ByVal e As EventArgs)
			OnMouseEvent(sender, e)
		End Sub

		Protected Sub NDrawingView1_AsyncMouseUp(ByVal sender As Object, ByVal e As EventArgs)
			OnMouseEvent(sender, e)
		End Sub

		#Region "Implementation"

		Protected Sub InitDocument()
			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False
			NDrawingView1.Document.AutoBoundsPadding = New Nevron.Diagram.NMargins(10f, 10f, 10f, 10f)
			NDrawingView1.Document.Style.FillStyle = New NColorFillStyle(Color.White)

			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(NDrawingView1.Document)

			Dim outerCircle As NShape = factory.CreateShape(BasicShapes.Circle)
			outerCircle.Bounds = New NRectangleF(0f, 0f, 200f, 200f)
			NDrawingView1.Document.ActiveLayer.AddChild(outerCircle)

			Dim rect As NShape = factory.CreateShape(BasicShapes.Rectangle)
			rect.Bounds = New NRectangleF(42f, 42f, 50f, 50f)
			rect.Style.FillStyle = New NColorFillStyle(Color.Orange)
			NDrawingView1.Document.ActiveLayer.AddChild(rect)

			Dim triangle As NShape = factory.CreateShape(BasicShapes.Triangle)
			triangle.Bounds = New NRectangleF(121f, 57f, 60f, 55f)
			triangle.Style.FillStyle = New NColorFillStyle(Color.LightGray)
			NDrawingView1.Document.ActiveLayer.AddChild(triangle)

			Dim pentagon As NShape = factory.CreateShape(BasicShapes.Pentagon)
			pentagon.Bounds = New NRectangleF(60f, 120f, 54f, 50f)
			pentagon.Style.FillStyle = New NColorFillStyle(Color.WhiteSmoke)
			NDrawingView1.Document.ActiveLayer.AddChild(pentagon)

			NDrawingView1.Document.SizeToContent()
		End Sub

		Protected Sub OnMouseEvent(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)

			Dim allShapes As NNodeList = NDrawingView1.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)

			Dim affectedNodes As NNodeList = NDrawingView1.HitTest(args)
			Dim affectedShapes As NNodeList = affectedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)

			Dim length As Integer

			length = allShapes.Count
			Dim i As Integer = 0
			Do While i < length
				Dim shape As NShape = TryCast(allShapes(i), NShape)
				shape.Style.ShadowStyle = Nothing
				If Not shape.Tag Is Nothing Then
					shape.Style.FillStyle = New NColorFillStyle(CType(shape.Tag, Color))
				End If
				i += 1
			Loop

			length = affectedShapes.Count
			i = 0
			Do While i < length
				Dim shape As NShape = TryCast(affectedShapes(i), NShape)
				shape.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(96, Color.Black), New NPointL(3, 3), 1, New NLength(10))
				Dim fs As NColorFillStyle = TryCast(shape.Style.FillStyle, NColorFillStyle)
				If Not fs Is Nothing AndAlso fs.Color <> Color.White Then
					shape.Tag = fs.Color
					shape.Style.FillStyle = New NColorFillStyle(Color.YellowGreen)
				End If
				i += 1
			Loop
		End Sub

		#End Region
	End Class
End Namespace
