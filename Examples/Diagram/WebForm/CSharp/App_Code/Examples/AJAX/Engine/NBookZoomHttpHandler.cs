using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Dom;

using Nevron.Diagram;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Batches;
using Nevron.Diagram.WebForm;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.DataStructures;

namespace Nevron.Examples.Diagram.Webform
{
	public class NBookZoomHttpHandler : IHttpHandler
	{
		public NBookZoomHttpHandler()
		{
		}

		#region IHttpHandler Implementation

		void IHttpHandler.ProcessRequest(HttpContext context)
		{
			int bookId = -1;
			if (context.Request["id"] != null)
			{
				int.TryParse(context.Request["id"], out bookId);
			}

			NDrawingDocument document = CreateDocument(bookId);
			NCanvas canvas = CreateCanvas(document);

			document.RefreshAllViews();
			canvas.DoLayout();

			MemoryStream ms = new MemoryStream();

			NPngImageFormat imageFormet = new NPngImageFormat();
			using (INImage image = CreateImage(document, canvas, canvas.Size, imageFormet))
			{
				image.SaveToStream(ms, imageFormet);
			}

			byte[] bytes = ms.GetBuffer();
			context.Response.ContentType = "image/png";
			context.Response.OutputStream.Write(bytes, 0, bytes.Length);
			context.Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
		}

		bool IHttpHandler.IsReusable
		{
			get
			{
				return true;
			}
		}

		#endregion

		NDrawingDocument CreateDocument(int bookId)
		{
			NDrawingDocument document = new NDrawingDocument();

			//	setup the document
			document.AutoBoundsPadding = new Nevron.Diagram.NMargins(0f, 7f, 7f, 7f);
			document.Style.FillStyle = new NColorFillStyle(Color.White);
			document.Style.TextStyle.FillStyle = new NColorFillStyle(Color.DarkGray);
			document.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left;
			document.Style.StrokeStyle = new NStrokeStyle(0, Color.White);
			NStandardFrameStyle frame = document.BackgroundStyle.FrameStyle as NStandardFrameStyle;
			frame.InnerBorderColor = Color.Gray;
			document.MeasurementUnit = NGraphicsUnit.Pixel;

			//	set up the shape factories
			NBasicShapesFactory bookItemsFactory = new NBasicShapesFactory(document);
			bookItemsFactory.DefaultSize = new NSizeF(320, 200);

			NCustomToolsData.NBookEntry[] books = NCustomToolsData.CreateBooks();
			NCustomToolsData.NBookEntry book = null;
			int length = books.Length;
			for (int i = 0; i < length; i++)
			{
				if (books[i].Id == bookId)
				{
					book = books[i];
					break;
				}
			}
			if (bookId == -1 || book == null)
			{
				document.Style.StrokeStyle = new NStrokeStyle(1, Color.Red);
				document.ActiveLayer.AddChild(bookItemsFactory.CreateShape(BasicShapes.Pentagram));
				document.SizeToContent();
				return document;
			}

			//	create a table layout, which will align te thumbnail and the text lines
			//	in two columns
			NTableLayout mainLayout = new NTableLayout();
			mainLayout.Direction = LayoutDirection.LeftToRight;
			mainLayout.ConstrainMode = CellConstrainMode.Ordinal;
			mainLayout.MaxOrdinal = 2;
			mainLayout.VerticalContentPlacement = ContentPlacement.Near;

			//	create a stack layout, which will align the text lines in rows
			NStackLayout textLayout = new NStackLayout();
			textLayout.Direction = LayoutDirection.TopToBottom;
			textLayout.HorizontalContentPlacement = ContentPlacement.Near;
			textLayout.VerticalSpacing = 13;

			//	create a stack layout, which will align the stars in 5 columns
			NStackLayout starsLayout = new NStackLayout();
			starsLayout.Direction = LayoutDirection.LeftToRight;
			starsLayout.VerticalContentPlacement = ContentPlacement.Center;
			starsLayout.HorizontalSpacing = 1;

			NLayoutContext layoutContext = new NLayoutContext();
			layoutContext.GraphAdapter = new NShapeGraphAdapter();
			layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
			layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

			//	create the shapes for the book image and text lines
			NShape bookImageShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle);
			bookImageShape.Width = 240f;
			bookImageShape.Height = 240f;
			NImageFillStyle fs1 = new NImageFillStyle(HttpContext.Current.Server.MapPath(@"~\Images\CustomTools\" + book.ImageFile));
			fs1.TextureMappingStyle.MapLayout = MapLayout.Centered;
			NStyle.SetFillStyle(bookImageShape, fs1);

			NShape bookTitleShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle);
			bookTitleShape.Text = book.Title;
			bookTitleShape.Width = 160f;
			bookTitleShape.Height = 32f;

			NShape bookAuthorShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle);
			bookAuthorShape.Text = "by " + book.Author;
			bookAuthorShape.Width = 160f;
			bookAuthorShape.Height = 32f;

			NShape bookPriceShape = bookItemsFactory.CreateShape(BasicShapes.Rectangle);
			bookPriceShape.Text = "Price: $" + book.Price.ToString();
			bookPriceShape.Width = 160f;
			bookPriceShape.Height = 32f;

			//	create the star shapes
			NNodeList starShapes = new NNodeList();
			for (int i = 0; i < 5; i++)
			{
				NShape star = bookItemsFactory.CreateShape(BasicShapes.Pentagram);
				star.Width = 10f;
				star.Height = 10f;
				if (i < book.Rating)
				{
					star.Style.FillStyle = new NColorFillStyle(Color.Orange);
				}
				else
				{
					star.Style.FillStyle = new NColorFillStyle(Color.LightGray);
				}
				starShapes.Add(star);
			}

			//	prepare to layout
			NBatchGroup bgroup = new NBatchGroup(document);

			//	create the stars group
			NGroup starsGroup = new NGroup();

			// group the star shapes
			bgroup.Build(starShapes);
			bgroup.Group(null, false, out starsGroup);

			// collect the text shapes
			NNodeList textShapes = new NNodeList();
			textShapes.Add(bookTitleShape);
			textShapes.Add(bookAuthorShape);
			textShapes.Add(bookPriceShape);
			textShapes.Add(starsGroup);

			//	create the text group
			NGroup textGroup = new NGroup();

			// group the text shapes
			bgroup.Build(textShapes);
			bgroup.Group(null, false, out textGroup);

			// collect the main layout shapes
			NNodeList mainElements = new NNodeList();
			mainElements.Add(bookImageShape);
			mainElements.Add(textGroup);

			//	create the main group
			NGroup mainGroup = new NGroup();

			// group the main elements
			bgroup.Build(mainElements);
			bgroup.Group(null, false, out mainGroup);

			document.ActiveLayer.AddChild(mainGroup);

			// size all text shapes to text
			bookTitleShape.SizeToText(new NMarginsF(6f, 0f, 6f, 0f));
			bookAuthorShape.SizeToText(new NMarginsF(6f, 0f, 6f, 0f));
			bookPriceShape.SizeToText(new NMarginsF(6f, 0f, 6f, 0f));

			// layout the star shapes
			starsLayout.Layout(starShapes, layoutContext);
			starsGroup.UpdateModelBounds();

			// perform layout on the text
			textLayout.Layout(textShapes, layoutContext);
			textGroup.UpdateModelBounds();

			// layout all elements
			mainLayout.Layout(mainElements, layoutContext);
			mainGroup.UpdateModelBounds();

			// correct the text left padding
			bookTitleShape.Location = new NPointF(bookTitleShape.Location.X - 6f, bookTitleShape.Location.Y);
			bookAuthorShape.Location = new NPointF(bookAuthorShape.Location.X - 6f, bookAuthorShape.Location.Y);
			bookPriceShape.Location = new NPointF(bookPriceShape.Location.X - 6f, bookPriceShape.Location.Y);

			document.SizeToContent();
			return document;
		}

		NCanvas CreateCanvas(NDrawingDocument document)
		{
			NCanvas canvas = new NCanvas(document);
			canvas.Layout = CanvasLayout.Normal;
			canvas.ScaleX = 1;
			canvas.ScaleY = 1;
			canvas.GlobalVisibility = new NGlobalVisibility();
			canvas.GlobalVisibility.ShowPorts = false;
			canvas.Size = new NSize((int)document.Width, (int)document.Height);
			canvas.GraphicsSettings = document.GraphicsSettings;

			return canvas;
		}

		protected INImage CreateImage(NDrawingDocument document, NCanvas canvas, NSize size, NPngImageFormat imageFormat)
		{
			INImageFormatProvider imageFormatProvider = new NDiagramRasterImageFormatProvider(document, canvas);
			return imageFormatProvider.ProvideImage(size, NResolution.ScreenResolution, imageFormat);
		}
	}
}
