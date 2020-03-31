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
using Nevron.Diagram.Batches;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Templates;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.WebForm;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///	Summary description for NSymmetricalLayoutUC.
	/// </summary>
	public partial class NSymmetricalLayoutUC : NDiagramExampleUC
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
            document.GraphicsSettings.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // set up visual formatting
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);

			// create a tree
			CreateTree(4, 3);

			// perform the layout
			PerformLayout(null);
        }
		private void CreateTree(int levels, int branchNodes)
		{
			// clean up the active layer
			NDrawingView1.Document.ActiveLayer.RemoveAllChildren();

			// we will be using basic shapes with 40, 40 size
			NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
			basicShapesFactory.DefaultSize = new NSizeF(40, 40);

			NShape cur = null;
			NShape edge = null;

			List<NShape> curRowNodes = null;
			List<NShape> prevRowNodes = null;

			int i, level;
			int levelNodesCount;

			for (level = 1; level <= levels; level++)
			{
				curRowNodes = new List<NShape>();

				//Create a balanced tree
				levelNodesCount = (int)Math.Pow(branchNodes, level - 1);
				for (i = 0; i < levelNodesCount; i++)
				{
					// create the cur node
					cur = basicShapesFactory.CreateShape(BasicShapes.Circle);
					((NDynamicPort)cur.Ports.GetChildByName("Center", -1)).GlueMode = DynamicPortGlueMode.GlueToLocation;
					NDrawingView1.Document.ActiveLayer.AddChild(cur);

					// connect with ancestor
					if (level > 1)
					{
						edge = new NLineShape();
						NDrawingView1.Document.ActiveLayer.AddChild(edge);

						int parentIndex = (int)Math.Floor((double)(i / branchNodes));
						edge.FromShape = prevRowNodes[parentIndex];
						edge.ToShape = cur;
					}

					curRowNodes.Add(cur);
				}

				prevRowNodes = curRowNodes;
			}

			// send links to back
			NBatchReorder batchReorder = new NBatchReorder(NDrawingView1.Document);
			batchReorder.Build(NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape1D));
			batchReorder.SendToBack(false);
		}
        private void PerformLayout(Hashtable args)
		{
			// create a layout
			NSymmetricalLayout layout = new NSymmetricalLayout();

			// configure the optional forces
			layout.BounceBackForce.Padding = 100f;
			layout.GravityForce.AttractionCoefficient = 0.2f;
			layout.MagneticFieldForce.DistancePower = 0.6f;
			layout.MagneticFieldForce.FieldDirection = MagneticFieldDirection.OrthogonalLeftwardDownward;
			layout.MagneticFieldForce.MagnetizationType = MagnetizationType.Unidirectional;
			layout.MagneticFieldForce.TorsionCoefficient = 2f;

			// create a layout context
			NLayoutContext layoutContext = new NLayoutContext();
			layoutContext.GraphAdapter = new NShapeGraphAdapter();
			layoutContext.BodyAdapter = new NShapeBodyAdapter(NDrawingView1.Document);
			layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(NDrawingView1.Document);

			// configure layout
            if (args != null)
            {
                layout.BounceBackForce.Enabled = Boolean.Parse(args["BounceBackForce"].ToString());
                layout.GravityForce.Enabled = Boolean.Parse(args["GravityForce"].ToString());
                layout.MagneticFieldForce.Enabled = Boolean.Parse(args["MagneticFieldForce"].ToString());
            }

			// get the shapes to layout
			NNodeList shapes = NDrawingView1.Document.ActiveLayer.Children(NFilters.Shape2D);
			
			// layout the shapes
			layout.Layout(shapes, new NDrawingLayoutContext(NDrawingView1.Document));

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
                    CreateTree(4, 3);
                    break;

                case "btn2":
                    CreateTree(5, 2);
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