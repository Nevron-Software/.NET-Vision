using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NBalloonTreeLayoutUC.
	/// </summary>
	public partial class NBalloonTreeLayoutUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (NDrawingView1.RequiresInitialization)
            {
                // begin view init
                NDrawingView1.ViewLayout = CanvasLayout.Fit;

                // init document
                NDrawingView1.Document.HistoryService.Stop();
                NDrawingView1.Document.BeginInit();
                InitDocument();
                NDrawingView1.Document.EndInit();

                PerformLayout(null);
            }
        }

        #region Implementation

        protected void InitDocument()
		{
            NDrawingDocument document = NDrawingView1.Document;

			// remove the standard frame
			document.BackgroundStyle.FrameStyle.Visible = false;

			// adjust the graphics quality
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			// set up visual formatting
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

			// create a tree
			CreateTree();

			// perform the layout
			PerformLayout(null);
		}
		protected void CreateTree()
		{
			// clear the document
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren();

			// create a tree
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
			tree.Create(NDrawingView1.Document);

			// resize document to fit all shapes
			NDrawingView1.Document.SizeToContent();
        }
		protected void PerformLayout(Hashtable args)
		{
			// Create the layout
			NBalloonTreeLayout layout = new NBalloonTreeLayout();

            // Configure the layout
            NLayoutsHelper.ConfigureLayout(layout, args);

			// Get the shapes to layout
			NNodeList shapes = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D);

			// Layout the shapes
			layout.Layout(shapes, new NDrawingLayoutContext(NDrawingView1.Document));

			// Resize document to fit all shapes
			NDrawingView1.Document.SizeToContent();
		}

        #endregion

        #region Event Handlers

        protected void NDrawingView1_AsyncCustomCommand(object sender, EventArgs e)
        {
            NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
            PerformLayout(args.Command.Arguments);
            m_bClientSideRedrawRequired = true;
        }
        protected void NDrawingView1_AsyncQueryCommandResult(object sender, EventArgs e)
        {
            NCallbackQueryCommandResultArgs args = e as NCallbackQueryCommandResultArgs;
            NAjaxXmlTransportBuilder resultBuilder = args.ResultBuilder;
            if (m_bClientSideRedrawRequired && !resultBuilder.ContainsRedrawDataSection())
            {
                resultBuilder.AddRedrawDataSection(NDrawingView1);
            }
        }

        #endregion

        #region Fields

        private bool m_bClientSideRedrawRequired = false;

        #endregion
	}
}
