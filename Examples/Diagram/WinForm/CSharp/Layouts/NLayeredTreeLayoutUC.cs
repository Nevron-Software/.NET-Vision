using System;
using System.Drawing;
using System.Collections.Generic;

using Nevron.Diagram.Layout;
using Nevron.Diagram;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Templates;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NLayeredTreeLayoutUC.
    /// </summary>
    public class NLayeredTreeLayoutUC : NDiagramExampleUC
    {
        #region Constructor

        public NLayeredTreeLayoutUC(NMainForm form)
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
            this.RandomButton2 = new Nevron.UI.WinForm.Controls.NButton();
            this.RandomButton1 = new Nevron.UI.WinForm.Controls.NButton();
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
            this.propertyGrid1.Size = new System.Drawing.Size(244, 391);
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
            // RandomButton2
            // 
            this.RandomButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomButton2.Location = new System.Drawing.Point(8, 429);
            this.RandomButton2.Name = "RandomButton2";
            this.RandomButton2.Size = new System.Drawing.Size(244, 23);
            this.RandomButton2.TabIndex = 6;
            this.RandomButton2.Text = "Random Tree (max 8 levels, max 2 branch nodes)";
            this.RandomButton2.UseVisualStyleBackColor = true;
            this.RandomButton2.Click += new System.EventHandler(this.RandomButton2_Click);
            // 
            // RandomButton1
            // 
            this.RandomButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomButton1.Location = new System.Drawing.Point(8, 400);
            this.RandomButton1.Name = "RandomButton1";
            this.RandomButton1.Size = new System.Drawing.Size(244, 23);
            this.RandomButton1.TabIndex = 5;
            this.RandomButton1.Text = "Random Tree (max 6 levels, max 3 branch nodes)";
            this.RandomButton1.UseVisualStyleBackColor = true;
            this.RandomButton1.Click += new System.EventHandler(this.RandomButton1_Click);
            // 
            // NLayeredTreeLayoutUC
            // 
            this.Controls.Add(this.RandomButton2);
            this.Controls.Add(this.RandomButton1);
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "NLayeredTreeLayoutUC";
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.LayoutButton, 0);
            this.Controls.SetChildIndex(this.RandomButton1, 0);
            this.Controls.SetChildIndex(this.RandomButton2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // init form fields
            m_Layout = new NLayeredTreeLayout();

            // instruct the layout to perform HV layout of the edges 
            m_Layout.OrthogonalEdgeRouting = true;

            // show the layout properties in the property grid
            propertyGrid1.SelectedObject = m_Layout;

            view.BeginInit();
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.GlobalVisibility.ShowArrowheads = false;
            view.ViewLayout = ViewLayout.Fit;

            // init document
            document.BeginInit();
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            InitDocument();
            document.EndInit();

            // init form controls
            InitFormControls();

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

        private void InitFormControls()
        {
            PauseEventsHandling();
            ResumeEventsHandling();
        }

        private void InitDocument()
        {
            // we do not need history for this example
            document.HistoryService.Pause();

            // create a tree
            NGenericTreeTemplate tree = new NGenericTreeTemplate();
            tree.Balanced = false;
            tree.Levels = 6;
            tree.BranchNodes = 3;
            tree.HorizontalSpacing = 10;
            tree.VerticalSpacing = 10;
            tree.VerticesSize = new NSizeF(50, 50);
            tree.VertexSizeDeviation = 1;
            tree.Create(document);

            // resize document to fit all shapes
            LayoutButton.PerformClick();
            document.SizeToContent();
        }

        private void RandomButton1_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;

            document.ActiveLayer.RemoveAllChildren();

            // create a test tree
            NGenericTreeTemplate tree = new NGenericTreeTemplate();
            tree.Balanced = false;
            tree.Levels = 6;
            tree.BranchNodes = 3;
            tree.HorizontalSpacing = 10;
            tree.VerticalSpacing = 10;
            tree.VerticesSize = new NSizeF(50, 50);
            tree.VertexSizeDeviation = 1;
            tree.Create(document);

            // layout the tree
            LayoutButton.PerformClick();

            view.LockRefresh = false;
        }

        private void RandomButton2_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;

            document.ActiveLayer.RemoveAllChildren();

            // create a test tree
            NGenericTreeTemplate tree = new NGenericTreeTemplate();
            tree.Balanced = false;
            tree.Levels = 8;
            tree.BranchNodes = 2;
            tree.HorizontalSpacing = 10;
            tree.VerticalSpacing = 10;
            tree.VerticesSize = new NSizeF(50, 50);
            tree.VertexSizeDeviation = 1;
            tree.Create(document);

            // layout the tree
            LayoutButton.PerformClick();

            view.LockRefresh = false;
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

            // resize document to fit all shapes
            document.SizeToContent();
        }
  
        #endregion

        #region Designer Fields

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Nevron.UI.WinForm.Controls.NButton LayoutButton;
        private Nevron.UI.WinForm.Controls.NButton RandomButton2;
        private Nevron.UI.WinForm.Controls.NButton RandomButton1;        

        #endregion

        #region Fields

        private NLayeredTreeLayout m_Layout;

        #endregion
    }
}