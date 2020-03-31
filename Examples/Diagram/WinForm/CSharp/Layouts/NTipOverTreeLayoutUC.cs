using System;
using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Templates;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NTipOverTreeLayoutUC.
    /// </summary>
    public class NTipOverTreeLayoutUC : NDiagramExampleUC
    {
        #region Constructor

        public NTipOverTreeLayoutUC(NMainForm form)
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
            this.PredefinedOrgChartButton = new Nevron.UI.WinForm.Controls.NButton();
            this.RandomTreeButton1 = new Nevron.UI.WinForm.Controls.NButton();
            this.RandomTreeButton2 = new Nevron.UI.WinForm.Controls.NButton();
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
            this.propertyGrid1.Size = new System.Drawing.Size(244, 379);
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
            // PredefinedOrgChartButton
            // 
            this.PredefinedOrgChartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PredefinedOrgChartButton.Location = new System.Drawing.Point(8, 388);
            this.PredefinedOrgChartButton.Name = "PredefinedOrgChartButton";
            this.PredefinedOrgChartButton.Size = new System.Drawing.Size(244, 23);
            this.PredefinedOrgChartButton.TabIndex = 3;
            this.PredefinedOrgChartButton.Text = "Predefined Org Chart";
            this.PredefinedOrgChartButton.UseVisualStyleBackColor = true;
            this.PredefinedOrgChartButton.Click += new System.EventHandler(this.PredefinedOrgChartButton_Click);
            // 
            // RandomTreeButton1
            // 
            this.RandomTreeButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomTreeButton1.Location = new System.Drawing.Point(8, 417);
            this.RandomTreeButton1.Name = "RandomTreeButton1";
            this.RandomTreeButton1.Size = new System.Drawing.Size(244, 23);
            this.RandomTreeButton1.TabIndex = 4;
            this.RandomTreeButton1.Text = "Random Tree (5 col shapes)";
            this.RandomTreeButton1.UseVisualStyleBackColor = true;
            this.RandomTreeButton1.Click += new System.EventHandler(this.RandomTreeButton1_Click);
            // 
            // RandomTreeButton2
            // 
            this.RandomTreeButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomTreeButton2.Location = new System.Drawing.Point(8, 446);
            this.RandomTreeButton2.Name = "RandomTreeButton2";
            this.RandomTreeButton2.Size = new System.Drawing.Size(244, 23);
            this.RandomTreeButton2.TabIndex = 5;
            this.RandomTreeButton2.Text = "Random Tree (7 col shapes)";
            this.RandomTreeButton2.UseVisualStyleBackColor = true;
            this.RandomTreeButton2.Click += new System.EventHandler(this.RandomTreeButton2_Click);
            // 
            // NTipOverTreeLayoutUC
            // 
            this.Controls.Add(this.RandomTreeButton2);
            this.Controls.Add(this.RandomTreeButton1);
            this.Controls.Add(this.PredefinedOrgChartButton);
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "NTipOverTreeLayoutUC";
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.LayoutButton, 0);
            this.Controls.SetChildIndex(this.PredefinedOrgChartButton, 0);
            this.Controls.SetChildIndex(this.RandomTreeButton1, 0);
            this.Controls.SetChildIndex(this.RandomTreeButton2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // init form fields
            m_Layout = new NTipOverTreeLayout();
            propertyGrid1.SelectedObject = m_Layout;

            view.BeginInit();
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.GlobalVisibility.ShowArrowheads = false;
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

            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));

            NStyleSheet styleSheet = new NStyleSheet("orange");
            styleSheet.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(251, 203, 156), Color.FromArgb(247, 150, 56));
            styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.StyleSheets.AddChild(styleSheet);

            CreatePredefinedOrgChart();

            // resize document to fit all shapes
            LayoutButton.PerformClick();
        }
        private void CreatePredefinedOrgChart()
        {
            // we will be using basic shapes with default size of 120, 60
            NBasicShapesFactory basicShapesFactory = new NBasicShapesFactory();
            basicShapesFactory.DefaultSize = new NSizeF(120, 60);

            // create the president
            NShape president = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            president.Text = "President";
            document.ActiveLayer.AddChild(president);

            // create the VPs. 
            // NOTE: The child nodes of the VPs are layed out in cols
            NShape vpMarketing = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            vpMarketing.Text = "VP Marketing";
            vpMarketing.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.ActiveLayer.AddChild(vpMarketing);

            NShape vpSales = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            vpSales.Text = "VP Sales";
            vpSales.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.ActiveLayer.AddChild(vpSales);

            NShape vpProduction = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            vpProduction.Text = "VP Production";
            vpProduction.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.ActiveLayer.AddChild(vpProduction);

            // connect president with VP
            NRoutableConnector connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = president;
            connector.ToShape = vpMarketing;

            connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = president;
            connector.ToShape = vpSales;

            connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = president;
            connector.ToShape = vpProduction;

            // crete the marketing managers
            NShape marketingManager1 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            marketingManager1.Text = "Manager1";
            document.ActiveLayer.AddChild(marketingManager1);

            NShape marketingManager2 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            marketingManager2.Text = "Manager2";
            document.ActiveLayer.AddChild(marketingManager2);

            // connect the marketing manager with the marketing VP
            connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = vpMarketing;
            connector.ToShape = marketingManager1;

            connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = vpMarketing;
            connector.ToShape = marketingManager2;

            // crete the sales managers
            NShape salesManager1 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            salesManager1.Text = "Manager1";
            document.ActiveLayer.AddChild(salesManager1);

            NShape salesManager2 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            salesManager2.Text = "Manager2";
            document.ActiveLayer.AddChild(salesManager2);

            // connect the sales manager with the sales VP
            connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = vpSales;
            connector.ToShape = salesManager1;

            connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = vpSales;
            connector.ToShape = salesManager2;

            // crete the production managers
            NShape productionManager1 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            productionManager1.Text = "Manager1";
            document.ActiveLayer.AddChild(productionManager1);

            NShape productionManager2 = basicShapesFactory.CreateShape(BasicShapes.Rectangle);
            productionManager2.Text = "Manager2";
            document.ActiveLayer.AddChild(productionManager2);

            // connect the production manager with the production VP
            connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = vpProduction;
            connector.ToShape = productionManager1;

            connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = vpProduction;
            connector.ToShape = productionManager2;
        }
        private void CreateTree(int maxShapes)
        {
            // clear the document
            document.ActiveLayer.RemoveAllChildren();

            // create a tree
            NGenericTreeTemplate tree = new NGenericTreeTemplate();
            tree.Balanced = false;
            tree.Levels = 6;
            tree.BranchNodes = 3;
            tree.HorizontalSpacing = 10;
            tree.VerticalSpacing = 10;
            tree.VerticesSize = new NSizeF(50, 50);
            tree.VertexSizeDeviation = 0;
            tree.Create(document);

            // make the subtrees of maxShapes random shapes vertically arranged
            NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);
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
        private void PredefinedOrgChartButton_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;
            document.ActiveLayer.RemoveAllChildren();

            // create the predefined org chart tree
            CreatePredefinedOrgChart();

            // layout the tree
            LayoutButton.PerformClick();
            view.LockRefresh = false;
        }
        private void RandomTreeButton1_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;
            CreateTree(5);
            LayoutButton.PerformClick();
            view.LockRefresh = false;

        }
        private void RandomTreeButton2_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;
            CreateTree(7);
            LayoutButton.PerformClick();
            view.LockRefresh = false;
        }

        #endregion

        #region Designer Fields

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Nevron.UI.WinForm.Controls.NButton LayoutButton;
        private Nevron.UI.WinForm.Controls.NButton PredefinedOrgChartButton;
        private Nevron.UI.WinForm.Controls.NButton RandomTreeButton1;
        private Nevron.UI.WinForm.Controls.NButton RandomTreeButton2;

        #endregion

        #region Fields

        private NTipOverTreeLayout m_Layout;

        #endregion
    }
}