using System;
using System.Collections.Generic;
using System.Drawing;

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
    /// Summary description for NOrthogonalLayoutUC.
    /// </summary>
    public class NSingleCycleLayoutUC : NDiagramExampleUC
    {
        #region Constructor

        public NSingleCycleLayoutUC(NMainForm form)
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
            this.propertyGrid1.Size = new System.Drawing.Size(244, 482);
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
            // NOrthogonalLayoutUC
            // 
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "NOrthogonalLayoutUC";
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.LayoutButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // init form fields
            m_Layout = new NSingleCycleLayout();
            propertyGrid1.SelectedObject = m_Layout;

            view.BeginInit();
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.ViewLayout = ViewLayout.Fit;

            // init document
            document.BeginInit();
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
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
            // create a tree
            NGenericTreeTemplate tree = new NGenericTreeTemplate();
            tree.LayoutScheme = TreeLayoutScheme.None;
            tree.ConnectorType = ConnectorType.Line;
            tree.VerticesShape = BasicShapes.Circle;
            tree.Levels = 6;
            tree.BranchNodes = 2;
            tree.HorizontalSpacing = 10;
            tree.VerticalSpacing = 10;
            tree.VerticesSize = new NSizeF(40, 40);
            tree.EdgesStyle.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.Circle, "CustomConnectorStart", new NSizeL(6, 6), new NColorFillStyle(Color.FromArgb(129, 133, 133)), new NStrokeStyle(1, Color.FromArgb(68, 90, 108)));
            tree.EdgesStyle.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.Circle, "CustomConnectorEnd", new NSizeL(6, 6), new NColorFillStyle(Color.FromArgb(129, 133, 133)), new NStrokeStyle(1, Color.FromArgb(68, 90, 108)));
            tree.Create(document);

            // resize document to fit all shapes
            LayoutButton.PerformClick();
            document.SizeToContent();
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

        #endregion

        #region Fields

        private NSingleCycleLayout m_Layout;

        #endregion
    }
}