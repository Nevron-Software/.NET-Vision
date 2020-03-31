Imports Microsoft.VisualBasic
Imports System.Drawing
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' 
	''' </summary>
	Public Partial Class NImageMapToolsUC
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
				rect.Style.InteractivityStyle = CreateInteractivityStyle("Rectangle", "http://en.wikipedia.org/wiki/Rectangle")
				rect.Tag = True
				document.ActiveLayer.AddChild(rect)

				Dim triangle As NShape = factory.CreateShape(BasicShapes.Triangle)
				triangle.Bounds = New NRectangleF(121f, 57f, 60f, 55f)
				triangle.Style.FillStyle = New NColorFillStyle(Color.LightBlue)
				triangle.Style.InteractivityStyle = CreateInteractivityStyle("Triangle", "http://en.wikipedia.org/wiki/Triangle")
				triangle.Tag = True
				document.ActiveLayer.AddChild(triangle)

				Dim pentagon As NShape = factory.CreateShape(BasicShapes.Pentagon)
				pentagon.Bounds = New NRectangleF(60f, 120f, 54f, 50f)
				pentagon.Style.FillStyle = New NColorFillStyle(Color.LightBlue)
				pentagon.Style.InteractivityStyle = CreateInteractivityStyle("Pentagon", "http://en.wikipedia.org/wiki/Pentagon")
				pentagon.Tag = True
				document.ActiveLayer.AddChild(pentagon)

				document.SizeToContent()
				document.EndInit()

				' add tooltip, browser redirect and cursor tools
				Dim tooltipTool As NTooltipTool = New NTooltipTool()
				NThinDiagramControl1.Controller.Tools.Add(tooltipTool)

				Dim browserRedirectTool As NBrowserRedirectTool = New NBrowserRedirectTool()
				NThinDiagramControl1.Controller.Tools.Add(browserRedirectTool)

				Dim cursorTool As NCursorTool = New NCursorTool()
				NThinDiagramControl1.Controller.Tools.Add(cursorTool)

				' configure the toolbar
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleTooltipToolAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleBrowserRedirectToolAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleCursorToolAction()))
			End If
		End Sub

		Private Function CreateInteractivityStyle(ByVal shapeName As String, ByVal url As String) As NInteractivityStyle
			Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()

			interactivityStyle.Tooltip.Text = shapeName
			interactivityStyle.UrlLink.Url = url
			interactivityStyle.Cursor.Type = CursorType.Hand

			Return interactivityStyle
		End Function
	End Class
End Namespace