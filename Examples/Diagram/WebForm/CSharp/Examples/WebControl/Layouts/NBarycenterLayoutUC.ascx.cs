using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Diagram.Layout;
using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NBarycenterLayoutUC.
	/// </summary>
	public partial class NBarycenterLayoutUC : NDiagramExampleUC
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

            NStyleSheet sheet = new NStyleSheet("edges");
            sheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            sheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.None, "", NSizeL.Empty,
                document.Style.FillStyle, document.Style.StrokeStyle);
            document.StyleSheets.AddChild(sheet);

			// create the initial diagram
			CreateRandomDiagram(15, 15);
			PerformLayout(null);

			// resize document to fit all shapes
			document.SizeToContent();
		}
        private void CreateRandomDiagram(int fixedCount, int freeCount)
        {
            if (fixedCount < 3)
                throw new ArgumentException("Needs at least three fixed vertices");

            NDrawingDocument document = NDrawingView1.Document;

            // clean up the layers
            document.ActiveLayer.RemoveAllChildren();

            // we will be using basic circle shapes with default size of (30, 30)
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
            basicShapesFactory.DefaultSize = new NSizeF(30, 30);

            // create the fixed vertices
            NShape[] fixedShapes = new NShape[fixedCount];

            for (int i = 0; i < fixedCount; i++)
            {
                fixedShapes[i] = basicShapesFactory.CreateShape(BasicShapes.Circle);
                ((NDynamicPort)fixedShapes[i].Ports.GetChildByName("Center", -1)).GlueMode = DynamicPortGlueMode.GlueToLocation;
                fixedShapes[i].Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
                fixedShapes[i].Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

                // setting the ForceXMoveable and ForceYMoveable properties to false
                // specifies that the layout cannot move the shape in both X and Y directions
                fixedShapes[i].LayoutData.ForceXMoveable = false;
                fixedShapes[i].LayoutData.ForceYMoveable = false;

                document.ActiveLayer.AddChild(fixedShapes[i]);
            }

            // create the free vertices
            NShape[] freeShapes = new NShape[freeCount];
            for (int i = 0; i < freeCount; i++)
            {
                freeShapes[i] = basicShapesFactory.CreateShape(BasicShapes.Circle);
                ((NDynamicPort)freeShapes[i].Ports.GetChildByName("Center", -1)).GlueMode = DynamicPortGlueMode.GlueToLocation;
                freeShapes[i].Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
                freeShapes[i].Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
                document.ActiveLayer.AddChild(freeShapes[i]);
            }

            // link the fixed shapes in a circle
            for (int i = 0; i < fixedCount; i++)
            {
                NLineShape lineShape = new NLineShape();
                document.ActiveLayer.AddChild(lineShape);

                if (i == 0)
                {
                    lineShape.FromShape = fixedShapes[fixedCount - 1];
                    lineShape.ToShape = fixedShapes[0];
                }
                else
                {
                    lineShape.FromShape = fixedShapes[i - 1];
                    lineShape.ToShape = fixedShapes[i];
                }
            }

            // link each free shape with two different random fixed shapes
            Random rnd = new Random();
            for (int i = 0; i < freeCount; i++)
            {
                int firstFixed = rnd.Next(fixedCount);
                int secondFixed = (firstFixed + rnd.Next(fixedCount / 3) + 1) % fixedCount;

                // link with first fixed
                NLineShape lineShape = new NLineShape();
                document.ActiveLayer.AddChild(lineShape);

                lineShape.FromShape = freeShapes[i];
                lineShape.ToShape = fixedShapes[firstFixed];

                // link with second fixed
                lineShape = new NLineShape();
                document.ActiveLayer.AddChild(lineShape);

                lineShape.FromShape = freeShapes[i];
                lineShape.ToShape = fixedShapes[secondFixed];
            }

            // link each free shape with another free shape
            for (int i = 1; i < freeCount; i++)
            {
                NLineShape lineShape = new NLineShape();
                document.ActiveLayer.AddChild(lineShape);

                lineShape.FromShape = freeShapes[i - 1];
                lineShape.ToShape = freeShapes[i];
            }

            NBatchReorder batchReorder = new NBatchReorder(document);
            batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D));
            batchReorder.SendToBack(false);
        }
        private void CreateTriangularGridDiagram(int levels)
        {
            NDrawingDocument document = NDrawingView1.Document;

            // clean up the active layer 
            document.ActiveLayer.RemoveAllChildren();

            // we will be using basic circle shapes with default size of (30, 30)
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
            basicShapesFactory.DefaultSize = new NSizeF(30, 30);

            NShape cur = null, prev = null;
            NShape edge = null;
            List<NShape> curRowShapes = null;
            List<NShape> prevRowShapes = null;

            for (int level = 1; level < levels; level++)
            {
                curRowShapes = new List<NShape>();

                for (int i = 0; i < level; i++)
                {
                    cur = basicShapesFactory.CreateShape(BasicShapes.Circle);
                    ((NDynamicPort)cur.Ports.GetChildByName("Center", -1)).GlueMode = DynamicPortGlueMode.GlueToLocation;
                    cur.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
                    cur.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
                    document.ActiveLayer.AddChild(cur);

                    // connect with prev
                    if (i > 0)
                    {
                        edge = new NLineShape();
                        document.ActiveLayer.AddChild(edge);

                        edge.FromShape = prev;
                        edge.ToShape = cur;
                    }

                    // connect with ancestors
                    if (level > 1)
                    {
                        if (i < prevRowShapes.Count)
                        {
                            edge = new NLineShape();
                            document.ActiveLayer.AddChild(edge);

                            edge.FromShape = prevRowShapes[i];
                            edge.ToShape = cur;
                        }

                        if (i > 0)
                        {
                            edge = new NLineShape();
                            document.ActiveLayer.AddChild(edge);

                            edge.FromShape = prevRowShapes[i - 1];
                            edge.ToShape = cur;
                        }
                    }

                    // fix the three corner vertices
                    if (level == 1 || (level == levels - 1 && (i == 0 || i == level - 1)))
                    {
                        cur.LayoutData.ForceXMoveable = false;
                        cur.LayoutData.ForceYMoveable = false;
                        cur.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
                        cur.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
                    }

                    curRowShapes.Add(cur);
                    prev = cur;
                }

                prevRowShapes = curRowShapes;
            }

            NBatchReorder batchReorder = new NBatchReorder(document);
            batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D));
            batchReorder.SendToBack(false);
        }
        private void PerformLayout(Hashtable args)
		{
			// create a layout
			NBarycenterLayout layout = new NBarycenterLayout();

            // configure the optional forces
			layout.BounceBackForce.RepulsionCoefficient = 20f;
			layout.GravityForce.AttractionCoefficient = 0.2f;

			// free vertices are placed in the fixed vertices barycenter
			layout.FreeVertexPlacement.Mode = FreeVertexPlacementMode.FixedBarycenter;

			// fixed vertices are placed on the rim of the specified ellipse
			layout.FixedVertexPlacement.Mode = FixedVertexPlacementMode.PredefinedEllipseRim;
			layout.FixedVertexPlacement.PredefinedEllipseBounds = new NRectangleF(0, 0, 700, 700);

			// configure the layout
            if (args != null)
            {
                layout.BounceBackForce.Enabled = Boolean.Parse(args["BounceBackForce"].ToString());
                layout.GravityForce.Enabled = Boolean.Parse(args["GravityForce"].ToString());
                layout.MinFixedVerticesCount = Int32.Parse(args["MinFixedVerticesCount"].ToString());
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
                case "randomGrid1Button":
			        CreateRandomDiagram(10, 10);
                    break;

                case "randomGrid2Button":
			        CreateRandomDiagram(15, 15);
                    break;

                case "triangularGrid1Button":
			        CreateTriangularGridDiagram(6);
                    break;

                case "triangularGrid2Button":
			        CreateTriangularGridDiagram(8);
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