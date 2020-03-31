using System;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NSimpleNetworkShapesUC.
	/// </summary>
	public partial class NSimpleNetworkShapesUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;

			// init document
			NDrawingView1.Document.BeginInit();

			NDrawingView1.ViewLayout = CanvasLayout.Normal;

			InitDocument(NDrawingView1.Document, new NSimpleNetworkShapesFactory(NDrawingView1.Document));
			NDrawingView1.SizeToContent();

			NDrawingView1.Document.EndInit();
		}

		protected void InitDocument(NDrawingDocument document, NShapesFactory factory)
		{
			NDrawingView1.Document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			NDrawingView1.Document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			NDrawingView1.Document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

			// set up visual formatting
			NDrawingView1.Document.Style.FillStyle = new NColorFillStyle(Color.Linen);

			NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = false;

			int maxOrdinal = 0;
			document.Style.TextStyle.FontStyle.InitFromFont(new Font("Arial Narrow", 8));
			switch(shapeSizeDropDownList.SelectedValue)
			{
				case "Small":
					factory.DefaultSize = new NSizeF(40, 30);
					maxOrdinal = 7;
					break;
				case "Medium":
					factory.DefaultSize = new NSizeF(80, 60);
					maxOrdinal = 4;
					break;
				case "Large":
					factory.DefaultSize = new NSizeF(200, 150);
					maxOrdinal = 1;
					break;
				default:
					throw new NotImplementedException(shapeSizeDropDownList.SelectedValue);
			}
			
			int count = factory.ShapesCount;
			for (int i = 0; i < count; i++)
			{
				// create a basic shape
				NShape shape = factory.CreateShape(i);
				shape.Style.InteractivityStyle = new NInteractivityStyle(shape.Name);

				// add it to the active layer
				document.ActiveLayer.AddChild(shape);
			}

			// layout the shapes in the active layer using a table layout
			NTableLayout layout = new NTableLayout();

			// setup the table layout
			layout.Direction = LayoutDirection.LeftToRight;
			layout.ConstrainMode = CellConstrainMode.Ordinal;
			layout.MaxOrdinal = maxOrdinal;
			layout.VerticalSpacing = 20;
			layout.HorizontalSpacing = 20;
            layout.HorizontalContentPlacement = ContentPlacement.Center;
            layout.VerticalContentPlacement = ContentPlacement.Center;

			// create a layout context
			NLayoutContext layoutContext = new NLayoutContext();
			layoutContext.GraphAdapter = new NShapeGraphAdapter();
			layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
			layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

			// layout the shapes
			layout.Layout(document.ActiveLayer.Children(null), layoutContext);

			// resize document to fit all shapes
			document.SizeToContent();
		}
	}
}
