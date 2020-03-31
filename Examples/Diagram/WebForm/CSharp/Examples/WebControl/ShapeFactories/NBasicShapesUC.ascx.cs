using System;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
    /// <summary>
    ///	Summary description for NBasicShapesUC.
    /// </summary>
    public partial class NBasicShapesUC : NDiagramExampleUC
    {
        protected void Page_Load(object sender, System.EventArgs e)
		{
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

            // set drawing preferences
            document.GraphicsSettings.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            document.GraphicsSettings.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            document.Style.FillStyle = new NColorFillStyle(Color.Linen);
            document.Style.TextStyle.FontStyle.InitFromFont(new Font("Arial Narrow", 8));
            document.BackgroundStyle.FrameStyle.Visible = false;

            // determine the shapes size and layout options
            NBasicShapesFactory factory = new NBasicShapesFactory(document);
            int maxOrdinal = 0;
            
            switch (shapeSizeDropDownList.SelectedValue)
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

            // create the basic shapes in the active layer
            int count = factory.ShapesCount;
			NShape shape = null;
			for (int i = 0; i < count; i++)
			{
				// create a basic shape
				shape = factory.CreateShape(i);
				shape.Text = shape.Name;

				// add it to the active layer
				document.ActiveLayer.AddChild(shape);
			}

			// Add some content to the table shape
			NTableShape table = (NTableShape)shape;
			table.InitTable(2, 2);
			table.BeginUpdate();
			table.CellMargins = new Nevron.Diagram.NMargins(8);
			table[0, 0].Text = "Cell 1";
			table[1, 0].Text = "Cell 2";
			table[0, 1].Text = "Cell 3";
			table[1, 1].Text = "Cell 4";
			table.PortDistributionMode = TablePortDistributionMode.CellBased;
			table.EndUpdate();

            // layout the shapes in the active layer using a table layout
            NTableLayout layout = new NTableLayout();

            layout.Direction = LayoutDirection.LeftToRight;
            layout.ConstrainMode = CellConstrainMode.Ordinal;
            layout.MaxOrdinal = maxOrdinal;
            layout.VerticalSpacing = 20;
            layout.HorizontalSpacing = 20;
            layout.HorizontalContentPlacement = ContentPlacement.Center;
            layout.VerticalContentPlacement = ContentPlacement.Center;

            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

            layout.Layout(document.ActiveLayer.Children(null), layoutContext);

            // resize document to fit all shapes
            document.SizeToContent();
        }
    }
}
