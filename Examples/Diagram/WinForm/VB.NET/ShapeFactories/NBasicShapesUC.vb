Imports Microsoft.VisualBasic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NBasicShapesUC.
	''' </summary>
	Public Class NBasicShapesUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			' 
			' NBasicShapesUC
			' 
			Me.Name = "NBasicShapesUC"
			Me.Size = New System.Drawing.Size(248, 160)

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()
			view.Grid.Visible = False

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			document.Style.TextStyle.FontStyle.InitFromFont(New Font("Arial Narrow", 8))

			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			factory.DefaultSize = New NSizeF(80, 60)

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

			' setup the table layout
			layout.Direction = LayoutDirection.LeftToRight
			layout.ConstrainMode = CellConstrainMode.Ordinal
			layout.MaxOrdinal = 5
			layout.HorizontalContentPlacement = ContentPlacement.Center
			layout.VerticalContentPlacement = ContentPlacement.Center
			layout.VerticalSpacing = 20
			layout.HorizontalSpacing = 20

			' get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' layout the shapes
			layout.Layout(shapes, New NDrawingLayoutContext(document))

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
