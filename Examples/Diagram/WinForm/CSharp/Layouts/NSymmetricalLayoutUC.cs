using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Batches;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Templates;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NSymmetricalLayout.
    /// </summary>
    public class NSymmetricalLayoutUC : NDiagramExampleUC
    {
        #region Constructor

        public NSymmetricalLayoutUC(NMainForm form)
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
            this.UpdateDrawingWhileLayouting = new System.Windows.Forms.CheckBox();
            this.Tree2Button = new Nevron.UI.WinForm.Controls.NButton();
            this.Tree1Button = new Nevron.UI.WinForm.Controls.NButton();
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
            this.propertyGrid1.Size = new System.Drawing.Size(244, 364);
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
            // UpdateDrawingWhileLayouting
            // 
            this.UpdateDrawingWhileLayouting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateDrawingWhileLayouting.Location = new System.Drawing.Point(8, 456);
            this.UpdateDrawingWhileLayouting.Name = "UpdateDrawingWhileLayouting";
            this.UpdateDrawingWhileLayouting.Size = new System.Drawing.Size(244, 17);
            this.UpdateDrawingWhileLayouting.TabIndex = 8;
            this.UpdateDrawingWhileLayouting.Text = "Update drawing while layouting";
            this.UpdateDrawingWhileLayouting.UseVisualStyleBackColor = true;
            // 
            // Tree2Button
            // 
            this.Tree2Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Tree2Button.Location = new System.Drawing.Point(8, 402);
            this.Tree2Button.Name = "Tree2Button";
            this.Tree2Button.Size = new System.Drawing.Size(244, 23);
            this.Tree2Button.TabIndex = 9;
            this.Tree2Button.Text = "Tree 2(levels 5, degree 2)";
            this.Tree2Button.UseVisualStyleBackColor = true;
            this.Tree2Button.Click += new System.EventHandler(this.TreeButton2_Click);
            // 
            // Tree1Button
            // 
            this.Tree1Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Tree1Button.Location = new System.Drawing.Point(8, 373);
            this.Tree1Button.Name = "Tree1Button";
            this.Tree1Button.Size = new System.Drawing.Size(244, 23);
            this.Tree1Button.TabIndex = 10;
            this.Tree1Button.Text = "Tree 1(levels 4, degree 3)";
            this.Tree1Button.UseVisualStyleBackColor = true;
            this.Tree1Button.Click += new System.EventHandler(this.TreeButton1_Click);
            // 
            // NSymmetricalLayoutUC
            // 
            this.Controls.Add(this.Tree1Button);
            this.Controls.Add(this.Tree2Button);
            this.Controls.Add(this.UpdateDrawingWhileLayouting);
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "NSymmetricalLayoutUC";
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.LayoutButton, 0);
            this.Controls.SetChildIndex(this.UpdateDrawingWhileLayouting, 0);
            this.Controls.SetChildIndex(this.Tree2Button, 0);
            this.Controls.SetChildIndex(this.Tree1Button, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // create and configure the spring layout
            m_Layout = new NSymmetricalLayout();

            // hook the iteration completed event
            m_Layout.IterationCompleted += new GraphLayoutCancelEventHandler(OnLayoutIterationCompleted);

            // select it in the property grid
            propertyGrid1.SelectedObject = m_Layout;
            
            view.BeginInit();
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.GlobalVisibility.ShowArrowheads = false; 
            view.ViewLayout = ViewLayout.Fit;

            // init document
            document.BeginInit();
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            InitDocument();
            document.EndInit();

            // end view init
            view.EndInit();
        }

        protected override void AttachToEvents()
        {
            base.AttachToEvents();
        }

        protected override void DetachFromEvents()
        {
            base.DetachFromEvents();
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Creates a balanced tree diagram with the specified levels and degree
        /// </summary>
        /// <param name="levels"></param>
        /// <param name="branchNodes"></param>
        private void CreateTree(int levels, int branchNodes)
        {
            // clean up the active layer
            document.ActiveLayer.RemoveAllChildren();

            // we will be using basic shapes with 40, 40 size
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
            basicShapesFactory.DefaultSize = new NSizeF(40, 40);

            NShape cur = null;
            NShape edge = null;

            List<NShape> curRowNodes = null;
            List<NShape> prevRowNodes = null;

            int i, level, levelNodesCount;
            Random rnd = new Random();

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
                    document.ActiveLayer.AddChild(cur);

                    // connect with ancestor
                    if (level > 1)
                    {
                        edge = new NLineShape();
                        document.ActiveLayer.AddChild(edge);

                        int parentIndex = (int)Math.Floor((double)(i / branchNodes));
                        edge.FromShape = prevRowNodes[parentIndex];
                        edge.ToShape = cur;
                    }

                    curRowNodes.Add(cur);
                }

                prevRowNodes = curRowNodes;
            }

            // send links to back
            NBatchReorder batchReorder = new NBatchReorder(document);
            batchReorder.Build(document.ActiveLayer.Children(NFilters.Shape1D));
            batchReorder.SendToBack(false);
        }

        private void InitDocument()
        {
            // create a tree with 4 levels and 3 branch nodes
            CreateTree(4, 3);

            // resize document to fit all shapes
            LayoutButton.PerformClick();
            document.SizeToContent();
        }

        #endregion

        #region Event Handlers

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

            // resize document to fit all shapes
            document.SizeToContent();
        }

        /// <summary>
        /// Invoked on each successfully completed iteration of the layout
        /// </summary>
        /// <param name="args"></param>
        private void OnLayoutIterationCompleted(NGraphLayoutCancelEventArguments args)
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

        private void TreeButton1_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;

            // create a random tree
            CreateTree(4, 3);

            // lay it out
            LayoutButton.PerformClick();

            view.LockRefresh = false;
        }

        private void TreeButton2_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;

            // create a random tree
            CreateTree(5, 2);

            // lay it out
            LayoutButton.PerformClick();

            view.LockRefresh = false;
        }

        #endregion

        #region Designer Fields

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Nevron.UI.WinForm.Controls.NButton LayoutButton;
        private System.Windows.Forms.CheckBox UpdateDrawingWhileLayouting;
        private Nevron.UI.WinForm.Controls.NButton Tree2Button;
        private Nevron.UI.WinForm.Controls.NButton Tree1Button;

        #endregion

        #region Fields

        private NSymmetricalLayout m_Layout;

        #endregion
    }
}