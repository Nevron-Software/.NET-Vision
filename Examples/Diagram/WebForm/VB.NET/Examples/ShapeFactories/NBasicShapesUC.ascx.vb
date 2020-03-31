Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NBasicShapesUC.
	''' </summary>
	Public Partial Class NBasicShapesUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' init document
			NDrawingView1.Document.BeginInit()
			InitDocument()
			NDrawingView1.Document.EndInit()

			' size view control to content
			NDrawingView1.SizeToContent()
		End Sub
		Protected Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document

			' set drawing preferences
			document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
			document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
			document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality

			document.Style.FillStyle = New NColorFillStyle(Color.Linen)
			document.Style.TextStyle.FontStyle.InitFromFont(New Font("Arial Narrow", 8))
			document.BackgroundStyle.FrameStyle.Visible = False

			' determine the shapes size and layout options
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim maxOrdinal As Integer = 0

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

			' create the basic shapes in the active layer
			Dim count As Integer = factory.ShapesCount
			Dim shape As NShape = Nothing
			Dim i As Integer = 0
			Do While i < count
				' create a basic shape
				shape = factory.CreateShape(i)
				shape.Text = shape.Name

				' add it to the active layer
				document.ActiveLayer.AddChild(shape)
				i += 1
			Loop

			' Add some content to the table shape
			Dim table As NTableShape = CType(shape, NTableShape)
			table.InitTable(2, 2)
			table.BeginUpdate()
			table.CellMargins = New Nevron.Diagram.NMargins(8)
			table(0, 0).Text = "Cell 1"
			table(1, 0).Text = "Cell 2"
			table(0, 1).Text = "Cell 3"
			table(1, 1).Text = "Cell 4"
			table.PortDistributionMode = TablePortDistributionMode.CellBased
			table.EndUpdate()

			' layout the shapes in the active layer using a table layout
			Dim layout As NTableLayout = New NTableLayout()

			layout.Direction = LayoutDirection.LeftToRight
			layout.ConstrainMode = CellConstrainMode.Ordinal
			layout.MaxOrdinal = maxOrdinal
			layout.VerticalSpacing = 20
			layout.HorizontalSpacing = 20
			layout.HorizontalContentPlacement = ContentPlacement.Center
			layout.VerticalContentPlacement = ContentPlacement.Center

			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			layout.Layout(document.ActiveLayer.Children(Nothing), layoutContext)

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
	End Class
End Namespace
