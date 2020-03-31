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
	Public Class NBookZoomHttpHandler
		Implements IHttpHandler
		Public Sub New()
		End Sub

		#Region "IHttpHandler Implementation"

		Private Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
			Dim bookId As Integer = -1
			If Not context.Request("id") Is Nothing Then
				Integer.TryParse(context.Request("id"), bookId)
			End If

			Dim document As NDrawingDocument = CreateDocument(bookId)
			Dim canvas As NCanvas = CreateCanvas(document)

			document.RefreshAllViews()
			canvas.DoLayout()

			Dim ms As MemoryStream = New MemoryStream()

			Dim imageFormet As NPngImageFormat = New NPngImageFormat()
			Using image As INImage = CreateImage(document, canvas, canvas.Size, imageFormet)
				image.SaveToStream(ms, imageFormet)
			End Using

			Dim bytes As Byte() = ms.GetBuffer()
			context.Response.ContentType = "image/png"
			context.Response.OutputStream.Write(bytes, 0, bytes.Length)
			context.Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate)
		End Sub

		Private ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
			Get
				Return True
			End Get
		End Property

		#End Region

		Private Function CreateDocument(ByVal bookId As Integer) As NDrawingDocument
			Dim document As NDrawingDocument = New NDrawingDocument()

			'	setup the document
			document.AutoBoundsPadding = New Nevron.Diagram.NMargins(0f, 7f, 7f, 7f)
			document.Style.FillStyle = New NColorFillStyle(Color.White)
			document.Style.TextStyle.FillStyle = New NColorFillStyle(Color.DarkGray)
			document.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			document.Style.StrokeStyle = New NStrokeStyle(0, Color.White)
			Dim frame As NStandardFrameStyle = TryCast(document.BackgroundStyle.FrameStyle, NStandardFrameStyle)
			frame.InnerBorderColor = Color.Gray
			document.MeasurementUnit = NGraphicsUnit.Pixel

			'	set up the shape factories
			Dim bookItemsFactory As NBasicShapesFactory = New NBasicShapesFactory(document)
			bookItemsFactory.DefaultSize = New NSizeF(320, 200)

			Dim books As NCustomToolsData.NBookEntry() = NCustomToolsData.CreateBooks()
			Dim book As NCustomToolsData.NBookEntry = Nothing
			Dim length As Integer = books.Length
			Dim i As Integer = 0
			Do While i < length
				If books(i).Id = bookId Then
					book = books(i)
					Exit Do
				End If
				i += 1
			Loop
			If bookId = -1 OrElse book Is Nothing Then
				document.Style.StrokeStyle = New NStrokeStyle(1, Color.Red)
				document.ActiveLayer.AddChild(bookItemsFactory.CreateShape(BasicShapes.Pentagram))
				document.SizeToContent()
				Return document
			End If

			'	create a table layout, which will align te thumbnail and the text lines
			'	in two columns
			Dim mainLayout As NTableLayout = New NTableLayout()
			mainLayout.Direction = LayoutDirection.LeftToRight
			mainLayout.ConstrainMode = CellConstrainMode.Ordinal
			mainLayout.MaxOrdinal = 2
			mainLayout.VerticalContentPlacement = ContentPlacement.Near

			'	create a stack layout, which will align the text lines in rows
			Dim textLayout As NStackLayout = New NStackLayout()
			textLayout.Direction = LayoutDirection.TopToBottom
			textLayout.HorizontalContentPlacement = ContentPlacement.Near
			textLayout.VerticalSpacing = 13

			'	create a stack layout, which will align the stars in 5 columns
			Dim starsLayout As NStackLayout = New NStackLayout()
			starsLayout.Direction = LayoutDirection.LeftToRight
			starsLayout.VerticalContentPlacement = ContentPlacement.Center
			starsLayout.HorizontalSpacing = 1

			Dim layoutContext As NLayoutContext = New NLayoutContext()
			layoutContext.GraphAdapter = New NShapeGraphAdapter()
			layoutContext.BodyAdapter = New NShapeBodyAdapter(document)
			layoutContext.BodyContainerAdapter = New NDrawingBodyContainerAdapter(document)

			'	create the shapes for the book image and text lines
			Dim bookImageShape As NShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle)
			bookImageShape.Width = 240f
			bookImageShape.Height = 240f
			Dim fs1 As NImageFillStyle = New NImageFillStyle(HttpContext.Current.Server.MapPath("~\Images\CustomTools\" & book.ImageFile))
			fs1.TextureMappingStyle.MapLayout = MapLayout.Centered
			NStyle.SetFillStyle(bookImageShape, fs1)

			Dim bookTitleShape As NShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle)
			bookTitleShape.Text = book.Title
			bookTitleShape.Width = 160f
			bookTitleShape.Height = 32f

			Dim bookAuthorShape As NShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle)
			bookAuthorShape.Text = "by " & book.Author
			bookAuthorShape.Width = 160f
			bookAuthorShape.Height = 32f

			Dim bookPriceShape As NShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle)
			bookPriceShape.Text = "Price: $" & book.Price.ToString()
			bookPriceShape.Width = 160f
			bookPriceShape.Height = 32f

			'	create the star shapes
			Dim starShapes As NNodeList = New NNodeList()
			For i = 0 To 4
				Dim star As NShape = bookItemsFactory.CreateShape(BasicShapes.Pentagram)
				star.Width = 10f
				star.Height = 10f
				If i < book.Rating Then
					star.Style.FillStyle = New NColorFillStyle(Color.Orange)
				Else
					star.Style.FillStyle = New NColorFillStyle(Color.LightGray)
				End If
				starShapes.Add(star)
			Next i

			'	prepare to layout
			Dim bgroup As NBatchGroup = New NBatchGroup(document)

			'	create the stars group
			Dim starsGroup As NGroup = New NGroup()

			' group the star shapes
			bgroup.Build(starShapes)
			bgroup.Group(Nothing, False, starsGroup)

			' collect the text shapes
			Dim textShapes As NNodeList = New NNodeList()
			textShapes.Add(bookTitleShape)
			textShapes.Add(bookAuthorShape)
			textShapes.Add(bookPriceShape)
			textShapes.Add(starsGroup)

			'	create the text group
			Dim textGroup As NGroup = New NGroup()

			' group the text shapes
			bgroup.Build(textShapes)
			bgroup.Group(Nothing, False, textGroup)

			' collect the main layout shapes
			Dim mainElements As NNodeList = New NNodeList()
			mainElements.Add(bookImageShape)
			mainElements.Add(textGroup)

			'	create the main group
			Dim mainGroup As NGroup = New NGroup()

			' group the main elements
			bgroup.Build(mainElements)
			bgroup.Group(Nothing, False, mainGroup)

			document.ActiveLayer.AddChild(mainGroup)

			' size all text shapes to text
			bookTitleShape.SizeToText(New NMarginsF(6f, 0f, 6f, 0f))
			bookAuthorShape.SizeToText(New NMarginsF(6f, 0f, 6f, 0f))
			bookPriceShape.SizeToText(New NMarginsF(6f, 0f, 6f, 0f))

			' layout the star shapes
			starsLayout.Layout(starShapes, layoutContext)
			starsGroup.UpdateModelBounds()

			' perform layout on the text
			textLayout.Layout(textShapes, layoutContext)
			textGroup.UpdateModelBounds()

			' layout all elements
			mainLayout.Layout(mainElements, layoutContext)
			mainGroup.UpdateModelBounds()

			' correct the text left padding
			bookTitleShape.Location = New NPointF(bookTitleShape.Location.X - 6f, bookTitleShape.Location.Y)
			bookAuthorShape.Location = New NPointF(bookAuthorShape.Location.X - 6f, bookAuthorShape.Location.Y)
			bookPriceShape.Location = New NPointF(bookPriceShape.Location.X - 6f, bookPriceShape.Location.Y)

			document.SizeToContent()
			Return document
		End Function

		Private Function CreateCanvas(ByVal document As NDrawingDocument) As NCanvas
			Dim canvas As NCanvas = New NCanvas(document)
			canvas.Layout = CanvasLayout.Normal
			canvas.ScaleX = 1
			canvas.ScaleY = 1
			canvas.GlobalVisibility = New NGlobalVisibility()
			canvas.GlobalVisibility.ShowPorts = False
			canvas.Size = New NSize(CInt(Fix(document.Width)), CInt(Fix(document.Height)))
			canvas.GraphicsSettings = document.GraphicsSettings

			Return canvas
		End Function

		Protected Function CreateImage(ByVal document As NDrawingDocument, ByVal canvas As NCanvas, ByVal size As NSize, ByVal imageFormat As NPngImageFormat) As INImage
			Dim imageFormatProvider As INImageFormatProvider = New NDiagramRasterImageFormatProvider(document, canvas)
			Return imageFormatProvider.ProvideImage(size, NResolution.ScreenResolution, imageFormat)
		End Function
	End Class
End Namespace
