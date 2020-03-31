using System;
using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Templates;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NCompactDepthTreeLayoutUC.
	/// </summary>
	public partial class NCompactDepthTreeLayoutUC : NDiagramExampleUC
	{
        protected void Page_Load(object sender, System.EventArgs e)
        {
			if (NThinDiagramControl1.Initialized)
				return;

			// Init the diagram control
			NThinDiagramControl1.StateId = "Diagram1";
			NThinDiagramControl1.CustomRequestCallback = new CustomRequestCallback();

			// Init the view
			NThinDiagramControl1.View.Layout = CanvasLayout.Fit;

			// Init the document
			NDrawingDocument document = NThinDiagramControl1.Document;
			document.BeginInit();
			InitDocument(document);
			document.EndInit();
        }

        #region Implementation

        protected void InitDocument(NDrawingDocument document)
        {
            // Remove the standard frame
            document.BackgroundStyle.FrameStyle.Visible = false;

            // Adjust the graphics quality
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            // Set up visual formatting
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

            // Create a tree
			DiagramRenderer renderer = new DiagramRenderer();
            renderer.CreateTree(document, 6, 3);

            // Apply the layout
            renderer.ApplyLayout(document, null);

			// Resize document to fit all shapes
			document.SizeToContent();
        }

        #endregion

		#region Nested Types

		[Serializable]
		private class CustomRequestCallback : INCustomRequestCallback
		{
			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NDrawingDocument document = diagramControl.Document;

				NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);
				Dictionary<string, string> settings = helper.ParseSettings(argument);

				DiagramRenderer renderer = new DiagramRenderer();
				switch (settings["command"])
				{
					case "RandomTree6Levels":
						renderer.CreateTree(document, 6, 3);
						break;
					case "RandomTree8Levels":
						renderer.CreateTree(document, 8, 2);
						break;
				}

				// Layout the diagram
				renderer.ApplyLayout(document, settings);

				// Resize document to fit all shapes
				document.SizeToContent();

				// Update the view
				diagramControl.UpdateView();
			}
		}

		private class DiagramRenderer
		{
			public void CreateTree(NDrawingDocument document, int levels, int branchNodes)
			{
				// Clear the document
				document.ActiveLayer.RemoveAllChildren();

				// Create a tree
				NGenericTreeTemplate tree = new NGenericTreeTemplate();
				tree.Balanced = false;
				tree.Levels = levels;
				tree.BranchNodes = branchNodes;
				tree.HorizontalSpacing = 10;
				tree.VerticalSpacing = 10;
				tree.VerticesSize = new NSizeF(50, 50);
				tree.VertexSizeDeviation = 1;
				tree.EdgesStyleSheetName = "edges";
				tree.Create(document);
			}
			public void ApplyLayout(NDrawingDocument document, Dictionary<string, string> settings)
			{
				// Create the layout
				NCompactDepthTreeLayout layout = new NCompactDepthTreeLayout();

				// Configure the layout
				if (settings != null)
				{
					NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);
					helper.ConfigureLayout(layout, settings);
				}

				// Get the shapes to layout
				NNodeList shapes =document.ActiveLayer.Children(NFilters.Shape2D);

				// Layout the shapes
				layout.Layout(shapes, new NDrawingLayoutContext(document));
			}
		}

		#endregion
	}
}