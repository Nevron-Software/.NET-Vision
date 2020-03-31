using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

using Nevron.Diagram.Layout;
using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NBarycenterLayoutUC.
    /// </summary>
    public class NBarycenterLayoutUC : NDiagramExampleUC
    {
        #region Constructor

        public NBarycenterLayoutUC(NMainForm form)
            : base(form)
		{
			InitializeComponent();
		}

		#endregion

        #region Component Designer Generated Code

        private void InitializeComponent()
        {
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.LayoutButton = new Nevron.UI.WinForm.Controls.NButton();
            this.TriangularGridButton1 = new Nevron.UI.WinForm.Controls.NButton();
            this.TriangularGridButton2 = new Nevron.UI.WinForm.Controls.NButton();
            this.Random1 = new Nevron.UI.WinForm.Controls.NButton();
            this.Random2 = new Nevron.UI.WinForm.Controls.NButton();
            this.UpdateDrawingWhileLayouting = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(8, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(244, 327);
            this.propertyGrid1.TabIndex = 1;
            // 
            // LayoutButton
            // 
            this.LayoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutButton.Location = new System.Drawing.Point(8, 491);
            this.LayoutButton.Name = "LayoutButton";
            this.LayoutButton.Size = new System.Drawing.Size(244, 23);
            this.LayoutButton.TabIndex = 2;
            this.LayoutButton.Text = "Layout";
            this.LayoutButton.UseVisualStyleBackColor = true;
            this.LayoutButton.Click += new System.EventHandler(this.LayoutButton_Click);
            // 
            // TriangularGridButton1
            // 
            this.TriangularGridButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TriangularGridButton1.Location = new System.Drawing.Point(8, 339);
            this.TriangularGridButton1.Name = "TriangularGridButton1";
            this.TriangularGridButton1.Size = new System.Drawing.Size(244, 23);
            this.TriangularGridButton1.TabIndex = 3;
            this.TriangularGridButton1.Text = "Triangular Grid (levels 6)";
            this.TriangularGridButton1.UseVisualStyleBackColor = true;
            this.TriangularGridButton1.Click += new System.EventHandler(this.TriangularGridButton1_Click);
            // 
            // TriangularGridButton2
            // 
            this.TriangularGridButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TriangularGridButton2.Location = new System.Drawing.Point(8, 368);
            this.TriangularGridButton2.Name = "TriangularGridButton2";
            this.TriangularGridButton2.Size = new System.Drawing.Size(244, 23);
            this.TriangularGridButton2.TabIndex = 4;
            this.TriangularGridButton2.Text = "Triangular Grid (levels 8)";
            this.TriangularGridButton2.UseVisualStyleBackColor = true;
            this.TriangularGridButton2.Click += new System.EventHandler(this.TriangularGridButton2_Click);
            // 
            // Random1
            // 
            this.Random1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Random1.Location = new System.Drawing.Point(8, 397);
            this.Random1.Name = "Random1";
            this.Random1.Size = new System.Drawing.Size(244, 23);
            this.Random1.TabIndex = 5;
            this.Random1.Text = "Random (fixed 10, free 10)";
            this.Random1.UseVisualStyleBackColor = true;
            this.Random1.Click += new System.EventHandler(this.Random1_Click);
            // 
            // Random2
            // 
            this.Random2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Random2.Location = new System.Drawing.Point(8, 426);
            this.Random2.Name = "Random2";
            this.Random2.Size = new System.Drawing.Size(244, 23);
            this.Random2.TabIndex = 6;
            this.Random2.Text = "Random (fixed 15, free 15)";
            this.Random2.UseVisualStyleBackColor = true;
            this.Random2.Click += new System.EventHandler(this.Random2_Click);
            // 
            // UpdateDrawingWhileLayouting
            // 
            this.UpdateDrawingWhileLayouting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateDrawingWhileLayouting.Location = new System.Drawing.Point(8, 455);
            this.UpdateDrawingWhileLayouting.Name = "UpdateDrawingWhileLayouting";
            this.UpdateDrawingWhileLayouting.Size = new System.Drawing.Size(244, 17);
            this.UpdateDrawingWhileLayouting.TabIndex = 7;
            this.UpdateDrawingWhileLayouting.Text = "Update drawing while layouting";
            this.UpdateDrawingWhileLayouting.UseVisualStyleBackColor = true;
            this.UpdateDrawingWhileLayouting.CheckedChanged += new System.EventHandler(this.UpdateDrawingWhileLayouting_CheckedChanged);
            // 
            // NBarycenterLayoutUC
            // 
            this.Controls.Add(this.UpdateDrawingWhileLayouting);
            this.Controls.Add(this.Random2);
            this.Controls.Add(this.Random1);
            this.Controls.Add(this.TriangularGridButton2);
            this.Controls.Add(this.TriangularGridButton1);
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "NBarycenterLayoutUC";
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.LayoutButton, 0);
            this.Controls.SetChildIndex(this.TriangularGridButton1, 0);
            this.Controls.SetChildIndex(this.TriangularGridButton2, 0);
            this.Controls.SetChildIndex(this.Random1, 0);
            this.Controls.SetChildIndex(this.Random2, 0);
            this.Controls.SetChildIndex(this.UpdateDrawingWhileLayouting, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // create the barycenter layout
            m_Layout = new NBarycenterLayout();

            // free vertices are placed in the fixed vertices barycenter
            m_Layout.FreeVertexPlacement.Mode = FreeVertexPlacementMode.FixedBarycenter;

            // fixed vertices are placed on the rim of the specified ellipse
            m_Layout.FixedVertexPlacement.Mode = FixedVertexPlacementMode.PredefinedEllipseRim;
            m_Layout.FixedVertexPlacement.PredefinedEllipseBounds = new NRectangleF(0, 0, 700, 700);

            // hook the iteration completed event
            m_Layout.IterationCompleted += new GraphLayoutCancelEventHandler(layout_IterationCompleted);

            // select the layout for edit in the property grid
            propertyGrid1.SelectedObject = m_Layout;

            view.BeginInit();

            // init view
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.TrackersManager.ShowRotatatedBoundsTrackers = false;
            view.TrackersManager.ShowPinPointTrackers = false;
            view.TrackersManager.ShowRotationTrackers = false; 
            view.ViewLayout = ViewLayout.Fit;

            // init document
            document.BeginInit();
            InitDocument();
            document.EndInit();

            // init form controls
            InitFormControls();

            // end view init
            view.EndInit();
        }
    
        #endregion

        #region Event Handlers

        private void TriangularGridButton1_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;
            
            CreateTriangularGridDiagram(6);
            LayoutButton.PerformClick();

            view.LockRefresh = false;
        }

        private void TriangularGridButton2_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;

            CreateTriangularGridDiagram(8);
            LayoutButton.PerformClick();

            view.LockRefresh = false;
        }

        private void Random1_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;

            CreateRandomDiagram(10, 10);
            LayoutButton.PerformClick();

            view.LockRefresh = false;
        }

        private void Random2_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;

            CreateRandomDiagram(15, 15);
            LayoutButton.PerformClick();

            view.LockRefresh = false;
        }

        /// <summary>
        /// Invoked on each successfully completed iteration of the layout
        /// </summary>
        /// <param name="args"></param>
        private void layout_IterationCompleted(NGraphLayoutCancelEventArguments args)
        {
            if (UpdateDrawingWhileLayouting.Checked)
            {
                bool refreshLocked = view.LockRefresh;
                if (refreshLocked)
                {
                    view.LockRefresh = false;
                }
                
                NShapeBodyAdapter shapeBodyAdaptor = new NShapeBodyAdapter(document);

                IEnumerator<NGraphPart> en = args.Graph.GetPartsEnumerator();
                while (en.MoveNext())
                {
                    NGraphVertex vertex = en.Current as NGraphVertex;
                    if (vertex != null)
                    {
                        NBody2D body = vertex.Tag as NBody2D;
                        shapeBodyAdaptor.UpdateObjectFromBody2D(body);
                    }
                }

                document.SizeToContent();

                view.Invalidate();
                view.Update();

                if (refreshLocked)
                {
                    view.LockRefresh = true;
                }

                Application.DoEvents();
            }
        }

        private void LayoutButton_Click(object sender, EventArgs e)
        {
            // get the shapes to layout
            NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

            // layout the shapes
            if(m_Layout != null)
                m_Layout.Layout(shapes, layoutContext);

            document.SizeToContent();
        }

        private void UpdateDrawingWhileLayouting_CheckedChanged(object sender, EventArgs e)
        {
        }

        #endregion

        #region Implementation

        private void InitFormControls()
        {
            PauseEventsHandling();
            ResumeEventsHandling();
        }

        private void InitDocument()
        {
            // disable history
            document.HistoryService.Pause();

            // create a random diagram
            CreateRandomDiagram(15, 15);

            // do the layout
            LayoutButton.PerformClick();
        }

        /// <summary>
        /// Creates a random barycenter diagram with the specified settings
        /// </summary>
        /// <param name="fixedCount">number of fixed vertices (must be larger than 3)</param>
        /// <param name="freeCount">number of free vertices</param>
        private void CreateRandomDiagram(int fixedCount, int freeCount)
        {
            if (fixedCount < 3)
                throw new ArgumentException("Needs at least three fixed vertices");

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
                ((NDynamicPort)freeShapes[i].Ports.GetChildByName("Center", - 1)).GlueMode = DynamicPortGlueMode.GlueToLocation;
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
        /// <summary>
        /// Creates a triangular grid diagram with the specified count of levels
        /// </summary>
        /// <param name="levels"></param>
        private void CreateTriangularGridDiagram(int levels)
        {
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

        #endregion

        #region Designer Fields

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Nevron.UI.WinForm.Controls.NButton LayoutButton;
        private Nevron.UI.WinForm.Controls.NButton TriangularGridButton1;
        private Nevron.UI.WinForm.Controls.NButton TriangularGridButton2;
        private Nevron.UI.WinForm.Controls.NButton Random1;
        private Nevron.UI.WinForm.Controls.NButton Random2;
        private System.Windows.Forms.CheckBox UpdateDrawingWhileLayouting;

        #endregion
        
        #region Fields

        private NBarycenterLayout m_Layout;

        #endregion
    }
}