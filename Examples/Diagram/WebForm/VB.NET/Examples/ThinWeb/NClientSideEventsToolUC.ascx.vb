Imports Microsoft.VisualBasic
Imports System.Drawing
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NThinWebGeneral.
	''' </summary>
	Public Partial Class NClientSideEventsToolUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				CaptureMouseEventDropDownList.Items.Add("Mouse Down")
				CaptureMouseEventDropDownList.Items.Add("Mouse Up")
				CaptureMouseEventDropDownList.Items.Add("Click")
				CaptureMouseEventDropDownList.Items.Add("Double Click")
				CaptureMouseEventDropDownList.Items.Add("Mouse Enter")
				CaptureMouseEventDropDownList.Items.Add("Mouse Leave")
				CaptureMouseEventDropDownList.SelectedIndex = 0
			End If

			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			Dim document As NDrawingDocument = NThinDiagramControl1.Document

			If (Not NThinDiagramControl1.Initialized) Then
				NThinDiagramControl1.View.Layout = CanvasLayout.Fit
				' add the client mouse event tool
				NThinDiagramControl1.Controller.Tools.Add(New NClientMouseEventTool())
			End If

			' Create a few simple shapes with attached client mouse event interactivity
			document.Reset()
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
			rect.Style.FillStyle = New NColorFillStyle(Color.Orange)
			rect.Style.InteractivityStyle = CreateInteractivityStyle("Rectangle")
			document.ActiveLayer.AddChild(rect)

			Dim triangle As NShape = factory.CreateShape(BasicShapes.Triangle)
			triangle.Bounds = New NRectangleF(121f, 57f, 60f, 55f)
			triangle.Style.FillStyle = New NColorFillStyle(Color.LightGray)
			triangle.Style.InteractivityStyle = CreateInteractivityStyle("Triangle")
			document.ActiveLayer.AddChild(triangle)

			Dim pentagon As NShape = factory.CreateShape(BasicShapes.Pentagon)
			pentagon.Bounds = New NRectangleF(60f, 120f, 54f, 50f)
			pentagon.Style.FillStyle = New NColorFillStyle(Color.WhiteSmoke)
			pentagon.Style.InteractivityStyle = CreateInteractivityStyle("Pentagon")
			document.ActiveLayer.AddChild(pentagon)

			document.SizeToContent()
			document.EndInit()
		End Sub

		Private Function CreateInteractivityStyle(ByVal shapeName As String) As NInteractivityStyle
			Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()
			Dim script As String = "alert(""Mouse Event [" & CaptureMouseEventDropDownList.SelectedValue.ToString() & "]. Captured for bar [" & shapeName & "])"");"

			Select Case CaptureMouseEventDropDownList.SelectedIndex
				Case 0 ' Mouse down
					interactivityStyle.ClientMouseEventAttribute.MouseDown = script
				Case 1 ' Mouse up
					interactivityStyle.ClientMouseEventAttribute.MouseUp = script
				Case 2 ' Click
					interactivityStyle.ClientMouseEventAttribute.Click = script
				Case 3 ' Double clicks
					interactivityStyle.ClientMouseEventAttribute.DoubleClick = script
				Case 4 ' MouseEnter
					interactivityStyle.ClientMouseEventAttribute.MouseEnter = script
				Case 5 ' MouseLeave
					interactivityStyle.ClientMouseEventAttribute.MouseLeave = script
			End Select

			Return interactivityStyle
		End Function
	End Class
End Namespace