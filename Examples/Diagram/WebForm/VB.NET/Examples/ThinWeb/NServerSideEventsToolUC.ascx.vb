Imports Microsoft.VisualBasic
Imports System
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
	Public Partial Class NServerSideEventsToolUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			Dim serverMouseEventTool As NServerMouseEventTool

			If (Not NThinDiagramControl1.Initialized) Then
				' begin view init
				Dim document As NDrawingDocument = NThinDiagramControl1.Document

				' init NThinDiagramControl1.Document.
				document.BeginInit()
				InitDocument(document)
				document.EndInit()

				NThinDiagramControl1.View.Layout = CanvasLayout.Fit
				NThinDiagramControl1.Toolbar.Visible = True
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomInAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomOutAction()))

				' configure the controller
				serverMouseEventTool = New NServerMouseEventTool()
				NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool)
			Else
				serverMouseEventTool = TryCast(NThinDiagramControl1.Controller.Tools(0), NServerMouseEventTool)
			End If

			' subscribe / unsubscribe to mouse down
			If MouseDownCheckBox.Checked Then
				serverMouseEventTool.MouseDown = New NMouseEventCallback()
			Else
				serverMouseEventTool.MouseDown = Nothing
			End If

			' subscribe / unsubscribe to mouse move
			If MouseMoveCheckBox.Checked Then
				serverMouseEventTool.MouseMove = New NMouseEventCallback()
			Else
				serverMouseEventTool.MouseMove = Nothing
			End If

			' subscribe / unsubscribe to mouse up
			If MouseUpCheckBox.Checked Then
				serverMouseEventTool.MouseUp = New NMouseEventCallback()
			Else
				serverMouseEventTool.MouseUp = Nothing
			End If

			''' // subscribe / unsubscribe to mouse hover
			If MouseOverCheckBox.Checked Then
				serverMouseEventTool.MouseOver = New NMouseEventCallback()
			Else
				serverMouseEventTool.MouseOver = Nothing
			End If

			' subscribe / unsubscribe to mouse leave
			If MouseLeaveCheckBox.Checked Then
				serverMouseEventTool.MouseLeave = New NMouseEventCallback()
			Else
				serverMouseEventTool.MouseLeave = Nothing
			End If

			' subscribe / unsubscribe to mouse enter
			If MouseEnterCheckBox.Checked Then
				serverMouseEventTool.MouseEnter = New NMouseEventCallback()
			Else
				serverMouseEventTool.MouseEnter = Nothing
			End If

			' subscribe / unsubscribe to mouse click
			If MouseClickCheckBox.Checked Then
				serverMouseEventTool.MouseClick = New NMouseEventCallback()
			Else
				serverMouseEventTool.MouseClick = Nothing
			End If

			' subscribe / unsubscribe to mouse click
			If MouseDoubleClickCheckBox.Checked Then
				serverMouseEventTool.MouseDoubleClick = New NMouseEventCallback()
			Else
				serverMouseEventTool.MouseDoubleClick = Nothing
			End If

		End Sub

		<Serializable> _
		Private Class NMouseEventCallback
			Implements INMouseEventCallback
			#Region "INMouseEventCallback Members"

			Private Sub OnMouseEvent(ByVal control As NAspNetThinWebControl, ByVal e As NBrowserMouseEventArgs) Implements INMouseEventCallback.OnMouseEvent
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim allShapes As NNodeList = diagramControl.Document.ActiveLayer.Children(Nevron.Diagram.Filters.NFilters.Shape2D)

				Dim affectedNodes As NNodeList = diagramControl.HitTest(New NPointF(e.X, e.Y))
				Dim affectedShapes As NNodeList = affectedNodes.Filter(Nevron.Diagram.Filters.NFilters.Shape2D)

				Dim length As Integer
				Dim fillChanged As Boolean = False

				length = allShapes.Count
				Dim i As Integer = 0
				Do While i < length
					Dim shape As NShape = TryCast(allShapes(i), NShape)
					shape.Style.ShadowStyle = Nothing
					If Not shape.Tag Is Nothing Then
						Dim newFill As NColorFillStyle = New NColorFillStyle(CType(shape.Tag, Color))
						fillChanged = fillChanged OrElse Not shape.Style.FillStyle.Equals(newFill)
						shape.Style.FillStyle = newFill
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
						Dim newFill As NColorFillStyle = New NColorFillStyle(Color.YellowGreen)
						fillChanged = fillChanged OrElse Not shape.Style.FillStyle.Equals(newFill)

						shape.Style.FillStyle = newFill
					End If
					i += 1
				Loop

				If fillChanged Then
					diagramControl.UpdateView()
				Else
					diagramControl.ClearResponse()
				End If
			End Sub

			#End Region
		End Class

		#Region "Implementation"

		Protected Sub InitDocument(ByVal document As NDrawingDocument)
			document.BackgroundStyle.FrameStyle.Visible = False
			document.AutoBoundsPadding = New Nevron.Diagram.NMargins(10f, 10f, 10f, 10f)
			document.Style.FillStyle = New NColorFillStyle(Color.White)

			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)

			Dim outerCircle As NShape = factory.CreateShape(BasicShapes.Circle)
			outerCircle.Bounds = New NRectangleF(0f, 0f, 200f, 200f)
			document.ActiveLayer.AddChild(outerCircle)

			Dim rect As NShape = factory.CreateShape(BasicShapes.Rectangle)
			rect.Bounds = New NRectangleF(42f, 42f, 50f, 50f)
			rect.Style.FillStyle = New NColorFillStyle(Color.Orange)
			document.ActiveLayer.AddChild(rect)

			Dim triangle As NShape = factory.CreateShape(BasicShapes.Triangle)
			triangle.Bounds = New NRectangleF(121f, 57f, 60f, 55f)
			triangle.Style.FillStyle = New NColorFillStyle(Color.LightGray)
			document.ActiveLayer.AddChild(triangle)

			Dim pentagon As NShape = factory.CreateShape(BasicShapes.Pentagon)
			pentagon.Bounds = New NRectangleF(60f, 120f, 54f, 50f)
			pentagon.Style.FillStyle = New NColorFillStyle(Color.WhiteSmoke)
			document.ActiveLayer.AddChild(pentagon)

			document.SizeToContent()
		End Sub

		#End Region
	End Class
End Namespace