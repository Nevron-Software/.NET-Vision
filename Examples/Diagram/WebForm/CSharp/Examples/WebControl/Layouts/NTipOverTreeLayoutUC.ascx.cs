using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Templates;
using Nevron.Diagram.WebForm;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NTipOverTreeLayoutUC.
	/// </summary>
	public partial class NTipOverTreeLayoutUC : NDiagramExampleUC
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

        private void InitDocument()
		{
            NDrawingDocument document = NDrawingView1.Document;

            // remove the standard frame
            document.BackgroundStyle.FrameStyle.Visible = false;

            // adjust the graphics quality
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            // set up visual formatting
            NDrawingView1.Document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            NDrawingView1.Document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NStyleSheet styleSheet = new NStyleSheet("orange");
            styleSheet.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
            styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.StyleSheets.AddChild(styleSheet);

            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

            // adjust the text properties
            NDrawingView1.Document.Style.TextStyle.FontStyle = new NFontStyle("arial", 13f);

            // create the predefined org chart
			CreatePredefinedOrgChart();

			// perform the layout
			PerformLayout(null);
		}
		private void PerformLayout(Hashtable args)
		{
			// Create the layout
			NTipOverTreeLayout layout = new NTipOverTreeLayout();

            // Configure the layout
            NLayoutsHelper.ConfigureLayout(layout, args);

            // Get the shapes to layout
            NNodeList shapes = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D);

            // Layout the shapes
			layout.Layout(shapes, new NDrawingLayoutContext(NDrawingView1.Document));

            // Resize document to fit all shapes
            NDrawingView1.Document.SizeToContent();

		}
		private void CreatePredefinedOrgChart()
		{
			// clear the document
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren();

			// we will be using basic shapes with default size of 120, 60
			NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
			basicShapesFactory.DefaultSize = new NSizeF(120, 60);

			// create the president
			NShape president = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			president.Text = "President";
			NDrawingView1.Document.ActiveLayer.AddChild(president);

			// create the VPs. 
			// NOTE: The child nodes of the VPs are layed out in cols
			NShape vpMarketing = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			vpMarketing.Text = "VP Marketing";
			NDrawingView1.Document.ActiveLayer.AddChild(vpMarketing);

			NShape vpSales = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			vpSales.Text = "VP Sales";
			NDrawingView1.Document.ActiveLayer.AddChild(vpSales);

			NShape vpProduction = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			vpProduction.Text = "VP Production";
			NDrawingView1.Document.ActiveLayer.AddChild(vpProduction);

			// connect president with VP
			NRoutableConnector connector = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = president;
			connector.ToShape = vpMarketing;

			connector = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = president;
			connector.ToShape = vpSales;

			connector = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = president;
			connector.ToShape = vpProduction;

			// crete the marketing managers
			NShape marketingManager1 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			marketingManager1.Text = "Manager1";
			NDrawingView1.Document.ActiveLayer.AddChild(marketingManager1);

			NShape marketingManager2 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			marketingManager2.Text = "Manager2";
			NDrawingView1.Document.ActiveLayer.AddChild(marketingManager2);

			// connect the marketing manager with the marketing VP
			connector = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = vpMarketing;
			connector.ToShape = marketingManager1;

			connector = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = vpMarketing;
			connector.ToShape = marketingManager2;

			// crete the sales managers
			NShape salesManager1 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			salesManager1.Text = "Manager1";
			NDrawingView1.Document.ActiveLayer.AddChild(salesManager1);

			NShape salesManager2 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			salesManager2.Text = "Manager2";
			NDrawingView1.Document.ActiveLayer.AddChild(salesManager2);

			// connect the sales manager with the sales VP
			connector = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = vpSales;
			connector.ToShape = salesManager1;

			connector = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = vpSales;
			connector.ToShape = salesManager2;

			// create the production managers
			NShape productionManager1 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			productionManager1.Text = "Manager1";
			NDrawingView1.Document.ActiveLayer.AddChild(productionManager1);

			NShape productionManager2 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
			productionManager2.Text = "Manager2";
			NDrawingView1.Document.ActiveLayer.AddChild(productionManager2);

			// connect the production manager with the production VP
			connector = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = vpProduction;
			connector.ToShape = productionManager1;

			connector = new NRoutableConnector();
			NDrawingView1.Document.ActiveLayer.AddChild(connector);
			connector.FromShape = vpProduction;
			connector.ToShape = productionManager2;
		}
		private void CreateTree(int maxShapes)
		{
			// clear the document
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren();

			// create a tree
			NGenericTreeTemplate tree = new NGenericTreeTemplate();
			tree.Balanced = false;
			tree.Levels = 6;
			tree.BranchNodes = 3;
			tree.HorizontalSpacing = 10;
			tree.VerticalSpacing = 10;
			tree.VerticesSize = new NSizeF(50, 50);
			tree.VertexSizeDeviation = 0;
            tree.EdgesStyleSheetName = "edges";
			tree.Create(NDrawingView1.Document);

			// make the subtrees of maxShapes random shapes vertically arranged
			NNodeList shapes = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D);
			Random rnd = new Random();
            List<int> usedNumbers = new List<int>();
            int i, index;

			for (i = 0; i < maxShapes; i++)
			{
                do
                {
                    index = rnd.Next(shapes.Count);
                }
                while (usedNumbers.Contains(index));

                usedNumbers.Add(index);
				NShape shape = (NShape)shapes[index];
                shape.StyleSheetName = "orange";
				shape.LayoutData.TipOverChildrenPlacement = TipOverChildrenPlacement.ColRight;
			}

			// resize document to fit all shapes
			NDrawingView1.Document.SizeToContent();
        }

        #endregion

        #region Event Handlers

        protected void NDrawingView1_AsyncCustomCommand(object sender, EventArgs e)
        {
            NCallbackCustomCommandArgs args = e as NCallbackCustomCommandArgs;
            switch (args.Command.Name)
            {
                case "btn1":
                    CreatePredefinedOrgChart();
                    break;

                case "btn2":
                    CreateTree(5);
                    break;

                case "btn3":
                    CreateTree(7);
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