using System;
using System.Collections;
using System.Drawing;
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
	///		Summary description for NLayeredTreeLayoutUC.
	/// </summary>
	public partial class NLayeredTreeLayoutUC : NDiagramExampleUC
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
            }
		}

        #region Implementation

        protected void InitDocument()
		{
            NDrawingDocument document = NDrawingView1.Document;

			// remove the standard frame
			document.BackgroundStyle.FrameStyle.Visible = false;

			// adjust the graphics quality
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

			// set up visual formatting
            NDrawingView1.Document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            NDrawingView1.Document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            
            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

			// create a tree
			CreateTree(6, 3);

			// perform the layout
			PerformLayout(null);
		}
		protected void CreateTree(int levels, int branchNodes)
		{
			// clear the document
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren();

			// create a tree
			NGenericTreeTemplate tree = new NGenericTreeTemplate();
			tree.Balanced = false;
			tree.Levels = levels;
			tree.BranchNodes = branchNodes;
			tree.HorizontalSpacing = 10;
			tree.VerticalSpacing = 10;
			tree.VerticesSize = new NSizeF(50, 50);
			tree.VertexSizeDeviation = 1;
            tree.EdgesStyleSheetName = "edges";
			tree.Create(NDrawingView1.Document);
        }
		protected void PerformLayout(Hashtable args)
		{
			// Create the layout
			NLayeredTreeLayout layout = new NLayeredTreeLayout();

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
            switch (args.Command.Name)
            {
                case "btn1":
                    CreateTree(6, 3);
                    break;

                case "btn2":
                    CreateTree(8, 2);
                    break;
            }

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