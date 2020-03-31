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
	///	Summary description for NFloorPlanShapesUC.
	/// </summary>
	public partial class NFloorPlanShapesUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			NHtmlImageMapResponse imageMapResponse = new NHtmlImageMapResponse();
			NDrawingView1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse;

			// init document
			NDrawingView1.Document.BeginInit();

			NDrawingView1.ViewLayout = CanvasLayout.Normal;

			// IMPORTANT: the floor plan shapes are defined with they real size in millimeters
			// that is why we must use drawing scale to display the content of this library
			NDrawingView1.Document.DrawingScaleMode = DrawingScaleMode.CustomScale;
			NDrawingView1.Document.MeasurementUnit = NGraphicsUnit.Millimeter;
			NDrawingView1.Document.CustomWorldMeasurementUnit = NGraphicsUnit.Millimeter;
			NDrawingView1.Document.CustomScale = 0.01f;

			InitDocument(NDrawingView1.Document, new NFloorPlanShapesFactory());
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
					NDrawingView1.ScaleX = 0.5f;
					NDrawingView1.ScaleY = NDrawingView1.ScaleX;
					maxOrdinal = 6;
					break;
				case "Medium":
					NDrawingView1.ScaleX = 1f;
					NDrawingView1.ScaleY = NDrawingView1.ScaleX;
					maxOrdinal = 3;
					break;
				case "Large":
					NDrawingView1.ScaleX = 2f;
					NDrawingView1.ScaleY = NDrawingView1.ScaleX;
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
			layout.Resolution = NDrawingView1.Document.Resolution;
			layout.MeasurementUnit = NDrawingView1.Document.MeasurementUnit;

			// setup the table layout
			layout.Direction = LayoutDirection.LeftToRight;
			layout.ConstrainMode = CellConstrainMode.Ordinal;
			layout.MaxOrdinal = maxOrdinal;
			layout.VerticalSpacing = 120;
			layout.HorizontalSpacing = 120;
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
