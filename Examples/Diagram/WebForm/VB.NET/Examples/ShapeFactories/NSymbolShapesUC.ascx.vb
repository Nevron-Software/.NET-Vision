Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NSymbolShapesUC.
	''' </summary>
	Public Partial Class NSymbolShapesUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim imageMapResponse As NHtmlImageMapResponse = New NHtmlImageMapResponse()
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse

			' init document
			NDrawingView1.Document.BeginInit()

			NDrawingView1.ViewLayout = CanvasLayout.Normal

			InitDocument(NDrawingView1.Document, New NSymbolShapesFactory(NDrawingView1.Document))
			NDrawingView1.SizeToContent()

			NDrawingView1.Document.EndInit()
		End Sub

		Protected Sub InitDocument(ByVal document As NDrawingDocument, ByVal factory As NShapesFactory)
			NDrawingView1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
			NDrawingView1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
			NDrawingView1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality

			' set up visual formatting
			NDrawingView1.Document.Style.FillStyle = New NColorFillStyle(Color.Linen)

			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False

			Dim maxOrdinal As Integer = 0
			document.Style.TextStyle.FontStyle.InitFromFont(New Font("Arial Narrow", 8))
			Select Case shapeSizeDropDownList.SelectedValue
				Case "Small"
					factory.DefaultSize = New NSizeF(40, 30)
					maxOrdinal = 7
				Case "Medium"
					factory.DefaultSize = New NSizeF(80, 60)
					maxOrdinal = 4
				Case "Large"
					factory.DefaultSize = New NSizeF(200, 150)
					maxOrdinal = 1
				Case Else
					Throw New NotImplementedException(shapeSizeDropDownList.SelectedValue)
			End Select

			Dim count As Integer = factory.ShapesCount
			Dim i As Integer = 0
			Do While i < count
				' create a basic shape
				Dim shape As NShape = factory.CreateShape(i)
				shape.Style.InteractivityStyle = New NInteractivityStyle(shape.Name)

				' add it to the active layer
				document.ActiveLayer.AddChild(shape)
				i += 1
			Loop

			' layout the shapes in the active layer using a table layout
			Dim layout As NTableLayout = New NTableLayout()

			' setup the table layout
			layout.Direction = LayoutDirection.LeftToRight
			layout.ConstrainMode = CellConstrainMode.Ordinal
			layout.MaxOrdinal = maxOrdinal
			layout.VerticalSpacing = 20
			layout.HorizontalSpacing = 20
			layout.HorizontalContentPlacement = ContentPlacement.Center
			layout.VerticalContentPlacement = ContentPlacement.Center

			' create a layout context
			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			' layout the shapes
			layout.Layout(document.ActiveLayer.Children(Nothing), layoutContext)

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
	End Class
End Namespace
