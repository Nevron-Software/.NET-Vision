Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Dom

Imports Nevron.Diagram
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.WebForm
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.DataStructures

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NCustomToolsUC.
	''' </summary>
	Public Partial Class NCustomToolsUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			NDrawingView1.AjaxToolsFactoryType = "NCustomToolFactory"

			If NDrawingView1.RequiresInitialization Then
				' init document
				NDrawingView1.Document.BeginInit()
				InitDocument()
				NDrawingView1.Document.EndInit()
			End If
		End Sub

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxDynamicCursorTool(True))
			NDrawingView1.AjaxTools.Add(New NAjaxCustomTool(True))
		End Sub

		#Region "Implementation"

		Private Sub InitDocument()
			' set up visual formatting
			NDrawingView1.Document.Style.FillStyle = New NColorFillStyle(Color.White)
			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False

			Dim books As NCustomToolsData.NBookEntry() = NCustomToolsData.CreateBooks()

			'	set up the shape factories
			Dim bookItemsFactory As NBasicShapesFactory = New NBasicShapesFactory(NDrawingView1.Document)
			bookItemsFactory.DefaultSize = New NSizeF(150, 100)

			'	create a table layout, which will align te thumbnail and the text within a group
			Dim bookThumbLayout As NTableLayout = New NTableLayout()
			bookThumbLayout.Direction = LayoutDirection.LeftToRight
			bookThumbLayout.ConstrainMode = CellConstrainMode.Ordinal
			bookThumbLayout.MaxOrdinal = 1

			'	create a table layout, which will align all books in a grid
			Dim tableLayout As NTableLayout = New NTableLayout()
			tableLayout.Direction = LayoutDirection.LeftToRight
			tableLayout.ConstrainMode = CellConstrainMode.Ordinal
			tableLayout.MaxOrdinal = 4
			tableLayout.HorizontalSpacing = 7
			tableLayout.VerticalSpacing = 7

			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(NDrawingView1.Document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(NDrawingView1.Document)

			Dim length As Integer = books.Length
			Dim i As Integer = 0
			Do While i < length
				Dim book As NCustomToolsData.NBookEntry = books(i)

				Dim bookThumbnailShape As NShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle)
				Dim fs1 As NImageFillStyle = New NImageFillStyle(Me.MapPathSecure("..\..\..\..\Images\CustomTools\" & book.ThumbnailFile))
				fs1.TextureMappingStyle.MapLayout = MapLayout.Centered
				NStyle.SetFillStyle(bookThumbnailShape, fs1)
				NStyle.SetStrokeStyle(bookThumbnailShape, New NStrokeStyle(0, Color.White))

				Dim bookTextShape As NShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle)
				NStyle.SetStrokeStyle(bookTextShape, New NStrokeStyle(0, Color.White))
				bookTextShape.Text = book.Title
				bookTextShape.Height = 50f

				bookThumbnailShape.Style.InteractivityStyle = New NInteractivityStyle(True, book.Id.ToString(), Nothing, CursorType.Hand)
				bookTextShape.Style.InteractivityStyle = New NInteractivityStyle(True, book.Id.ToString(), Nothing, CursorType.Hand)

				'	create the book tumbnail group
				Dim g As NGroup = New NGroup()
				Dim bgroup As NBatchGroup = New NBatchGroup(NDrawingView1.Document)
				Dim shapes As NNodeList = New NNodeList()

				shapes.Add(bookThumbnailShape)
				shapes.Add(bookTextShape)

				' perform layout
				bookThumbLayout.Layout(shapes, layoutContext)

				' group shapes
				bgroup.Build(shapes)
				bgroup.Group(Nothing, False, g)

				NDrawingView1.Document.ActiveLayer.AddChild(g)
				i += 1
			Loop

			' layout the books
			tableLayout.Layout(NDrawingView1.Document.ActiveLayer.Children(Nothing), layoutContext)
		End Sub

		#End Region
	End Class

	''' <summary>
	''' Provides configuration for the client side NAjaxCustomTool tool.
	''' </summary>
	<Serializable> _
	Public Class NAjaxCustomTool
		Inherits NAjaxToolDefinition
		#Region "Constructors"

		''' <summary>
		''' Initializes a new instance of NAjaxCustomTool with a given default enabled value.
		''' </summary>
		''' <param name="defaultEnabled">
		''' Selects the initial enabled state of the tool.
		''' </param>
		Public Sub New(ByVal defaultEnabled As Boolean)
			MyBase.New("NCustomTool", defaultEnabled)
		End Sub

		#End Region

		#Region "Overrides"

		''' <summary>
		''' Generates JavaScript that will create a new tool configuration object at the client.
		''' </summary>
		''' <returns>Returns a JavaScript that will create a new tool configuration object at the client.</returns>
		Protected Overrides Function GetConfigurationObjectJavaScript() As String
			Return "new NCustomToolConfig()"
		End Function

		#End Region
	End Class
End Namespace
