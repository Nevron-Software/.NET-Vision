using System;
using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Templates;
using Nevron.Diagram.ThinWeb;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.ThinWeb;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NBalloonTreeLayoutUC.
	/// </summary>
	public partial class NBalloonTreeLayoutUC : NDiagramExampleUC
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
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			// Set up visual formatting
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

			// Create a tree
			CreateTree();

			// Create the layout
			NBalloonTreeLayout layout = new NBalloonTreeLayout();

			// Get the shapes to layout
			NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

			// Layout the shapes
			layout.Layout(shapes, new NDrawingLayoutContext(document));

			// Resize document to fit all shapes
			document.SizeToContent();
		}
		protected void CreateTree()
		{
			// Clear the document
			NDrawingDocument document = NThinDiagramControl1.Document;
			document.ActiveLayer.RemoveAllChildren();

			// Create a tree
			NGenericTreeTemplate tree = new NGenericTreeTemplate();
            tree.LayoutScheme = TreeLayoutScheme.None;
            tree.Levels = 4;
			tree.BranchNodes = 4;
			tree.HorizontalSpacing = 10;
			tree.VerticalSpacing = 10;
			tree.ConnectorType = ConnectorType.Line;
			tree.VerticesShape = BasicShapes.Circle;
			tree.VerticesSize = new NSizeF(40, 40);
            tree.EdgesStyleSheetName = "edges";
			tree.Create(document);
        }

        #endregion

        #region Fields

        private bool m_bClientSideRedrawRequired = false;

        #endregion

		#region Nested Types

		[Serializable]
		class CustomRequestCallback : INCustomRequestCallback
		{
			#region INCustomRequestCallback Members

			void INCustomRequestCallback.OnCustomRequestCallback(NAspNetThinWebControl control, NRequestContext context, string argument)
			{
				NThinDiagramControl diagramControl = (NThinDiagramControl)control;
				NDrawingDocument document = diagramControl.Document;

				// Create the layout
				NBalloonTreeLayout layout = new NBalloonTreeLayout();

				// Configure the layout
				NDrawingDocumentHelper helper = new NDrawingDocumentHelper(document);
				Dictionary<string, string> settings = helper.ParseSettings(argument);
				helper.ConfigureLayout(layout, settings);

				// Get the shapes to layout
				NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

				// Layout the shapes
				layout.Layout(shapes, new NDrawingLayoutContext(document));

				// Resize document to fit all shapes
				document.SizeToContent();

				// Update the view
				diagramControl.UpdateView();
			}

			#endregion
		}

		#endregion
	}
}