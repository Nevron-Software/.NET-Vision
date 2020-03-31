Imports Microsoft.VisualBasic
Imports System.Drawing

Imports Nevron.Diagram
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NFilesAndFoldersShapesUC.
	''' </summary>
	Public Class NFilesAndFoldersShapesUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "IDisposable"

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

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

			Dim factory As NFilesAndFoldersFactory = New NFilesAndFoldersFactory(document)
			factory.DefaultSize = New NSizeF(80, 60)

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
			layout.MaxOrdinal = 5
			layout.HorizontalContentPlacement = ContentPlacement.Center
			layout.VerticalContentPlacement = ContentPlacement.Center
			layout.VerticalSpacing = 20
			layout.HorizontalSpacing = 20

			' get the shapes to layout
			Dim shapes As NNodeList = document.ActiveLayer.Children(NFilters.Shape2D)

			' create a layout context
			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			' layout the shapes
			layout.Layout(shapes, layoutContext)

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			' 
			' NTravelShapesUC
			' 
			Me.Name = "NWeatherShapesUC"
			Me.Size = New System.Drawing.Size(240, 200)

		End Sub
		#End Region

		#Region "Designer Fields"

		''' <summary>
		''' Required designer variable
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
