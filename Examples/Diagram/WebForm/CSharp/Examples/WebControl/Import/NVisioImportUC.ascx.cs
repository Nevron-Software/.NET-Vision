using System;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.GraphicsCore;
using Nevron.Diagram.Visio;
using Nevron.Dom;
using Nevron.Diagram.Filters;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
    /// <summary>
    ///	Summary description for NVisioImportUC.
    /// </summary>
	public partial class NVisioImportUC : NDiagramExampleUC
    {
        protected void Page_Load(object sender, System.EventArgs e)
		{
			NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;

			// init document
            NDrawingView1.Document.BeginInit();
			InitDocument();
            NDrawingView1.Document.EndInit();

            // size view control to content
            NDrawingView1.SizeToContent();
		}
        protected void InitDocument()
        {
            NDrawingDocument document = NDrawingView1.Document;

			// Import the Visio stencil
			NLibraryDocument libDocument = new NLibraryDocument();
			NVisioImporter importer = new NVisioImporter(libDocument);
			importer.Import(Server.MapPath(@"~\Examples\Import\Computers.vsx"));

            // Set drawing preferences
            document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            document.BackgroundStyle.FrameStyle.Visible = false;

			// Determine the shape size
			int maxOrdinal = 0;
			int scale = 1;
			switch (shapeSizeDropDownList.SelectedValue)
			{
				case "Small":
					scale = 1;
					maxOrdinal = 5;
					break;

				case "Medium":
					scale = 2;
					maxOrdinal = 3;
					break;

				case "Large":
					scale = 4;
					maxOrdinal = 1;
					break;

				default:
					throw new NotImplementedException(shapeSizeDropDownList.SelectedValue);
			}

            // Determine the shapes size and layout options
			NNodeList masters = libDocument.Children(NFilters.TypeNMaster);
			for (int i = 0, count = masters.Count; i < count; i++)
			{
				NMaster master = (NMaster)masters[i];
				NNodeList shapes = master.CreateInstance(document, new NPointF(0, 0));

				NShape shape = (NShape)shapes[0];
				shape.Width *= scale;
				shape.Height *= scale;
				NStyle.SetInteractivityStyle(shape, new NInteractivityStyle(master.Name));
			}

            // Layout the shapes in the active layer using a table layout
            NTableLayout layout = new NTableLayout();

            layout.Direction = LayoutDirection.LeftToRight;
            layout.ConstrainMode = CellConstrainMode.Ordinal;
            layout.MaxOrdinal = maxOrdinal;
            layout.VerticalSpacing = 20;
            layout.HorizontalSpacing = 20;
            layout.HorizontalContentPlacement = ContentPlacement.Center;
            layout.VerticalContentPlacement = ContentPlacement.Center;

            layout.Layout(document.ActiveLayer.Children(null), new NDrawingLayoutContext(document));

            // Resize document to fit all shapes
            document.SizeToContent();
        }
    }
}
