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
    public class NOrthogonalGraphLayoutUC : NDiagramExampleUC
    {
        #region Constructor

        public NOrthogonalGraphLayoutUC(NMainForm form)
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
            this.RandomGraphButton2 = new Nevron.UI.WinForm.Controls.NButton();
            this.RandomGraphButton1 = new Nevron.UI.WinForm.Controls.NButton();
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
            this.propertyGrid1.Size = new System.Drawing.Size(244, 402);
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
            // RandomGraphButton2
            // 
            this.RandomGraphButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomGraphButton2.Location = new System.Drawing.Point(8, 440);
            this.RandomGraphButton2.Name = "RandomGraphButton2";
            this.RandomGraphButton2.Size = new System.Drawing.Size(244, 23);
            this.RandomGraphButton2.TabIndex = 10;
            this.RandomGraphButton2.Text = "Random Graph (20 vertices, 25 edges)";
            this.RandomGraphButton2.UseVisualStyleBackColor = true;
            this.RandomGraphButton2.Click += new System.EventHandler(this.RandomGraphButton2_Click);
            // 
            // RandomGraphButton1
            // 
            this.RandomGraphButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomGraphButton1.Location = new System.Drawing.Point(8, 411);
            this.RandomGraphButton1.Name = "RandomGraphButton1";
            this.RandomGraphButton1.Size = new System.Drawing.Size(244, 23);
            this.RandomGraphButton1.TabIndex = 9;
            this.RandomGraphButton1.Text = "Random Graph (10 vertices, 15 edges)";
            this.RandomGraphButton1.UseVisualStyleBackColor = true;
            this.RandomGraphButton1.Click += new System.EventHandler(this.RandomGraphButton1_Click);
            // 
            // NOrthogonalGraphLayoutUC
            // 
            this.Controls.Add(this.RandomGraphButton2);
            this.Controls.Add(this.RandomGraphButton1);
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "NOrthogonalGraphLayoutUC";
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.LayoutButton, 0);
            this.Controls.SetChildIndex(this.RandomGraphButton1, 0);
            this.Controls.SetChildIndex(this.RandomGraphButton2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // create a stylesheet for the CustomConnectors
            NStyleSheet styleSheet = new NStyleSheet("CustomConnectors");
            styleSheet.Style.StartArrowheadStyle = new NArrowheadStyle(ArrowheadShape.Circle, "CustomConnectorStart", new NSizeL(6, 6), new NColorFillStyle(Color.FromArgb(247, 150, 56)), new NStrokeStyle(1, Color.FromArgb(68, 90, 108)));
            styleSheet.Style.EndArrowheadStyle = new NArrowheadStyle(ArrowheadShape.Arrow, "CustomConnectorStart", new NSizeL(6, 6), new NColorFillStyle(Color.FromArgb(247, 150, 56)), new NStrokeStyle(1, Color.FromArgb(68, 90, 108)));
            styleSheet.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.StyleSheets.AddChild(styleSheet);

            // init form fields
            m_Layout = new NOrthogonalGraphLayout();
            propertyGrid1.SelectedObject = m_Layout;

            view.BeginInit();
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
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

        private void CreateDiagram()
        {
            const int width = 40, height = 40, distance = 80;
            NBasicShapesFactory f = new NBasicShapesFactory(document);
            NRoutableConnector edge;
            int[] from = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 6 };
            int[] to = new int[] { 2, 3, 4, 4, 5, 8, 6, 7, 5, 8, 10, 8, 9, 10 };
            NShape[] shapes = new NShape[10];
            int vertexCount = shapes.Length;
            int edgeCount = from.Length;
            int count = vertexCount + edgeCount;

            for (int i = 0; i < count; i++)
            {
                if (i < vertexCount)
                {
                    int j = vertexCount % 2 == 0 ? i : i + 1;
                    shapes[i] = f.CreateShape((int)BasicShapes.Rectangle);

                    if (vertexCount % 2 != 0 && i == 0)
                    {
                        shapes[i].Bounds = new NRectangleF((int)(width + (distance * 1.5)) / 2,
                            distance + (j / 2) * (int)(distance * 1.5), width, height);
                    }
                    else
                    {
                        shapes[i].Bounds = new NRectangleF(width / 2 + (j % 2) * (int)(distance * 1.5),
                            height + (j / 2) * (int)(distance * 1.5), width, height);
                    }

                    document.ActiveLayer.AddChild(shapes[i]);
                }
                else
                {
                    edge = new NRoutableConnector();
                    edge.ConnectorType = RoutableConnectorType.DynamicPolyline;
                    edge.StyleSheetName = "CustomConnectors";
                    document.ActiveLayer.AddChild(edge);
                    edge.FromShape = shapes[from[i - vertexCount] - 1];
                    edge.ToShape = shapes[to[i - vertexCount] - 1];
                }
            }
        }
        private void InitFormControls()
        {
            PauseEventsHandling();
            ResumeEventsHandling();
        }
        private void InitDocument()
        {
            CreateDiagram();
            LayoutButton.PerformClick();
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

            NDrawingBodyContainerAdapter adapter = new NDrawingBodyContainerAdapter(document);
            adapter.SetLayoutArea(new NRectangleF(0, 0, 800, 800));
            layoutContext.BodyContainerAdapter = adapter;

            // layout the shapes
            if(m_Layout != null)
                m_Layout.Layout(shapes, layoutContext);

            // resize document to fit all shapes
            document.SizeToContent();
        }
        private void RandomGraphButton1_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;
            document.ActiveLayer.RemoveAllChildren();

            NRandomGraphTemplate randomGraph = new NRandomGraphTemplate();
            randomGraph.EdgesStyleSheetName = "CustomConnectors";
            randomGraph.VertexCount = 10;
            randomGraph.EdgeCount = 15;
            randomGraph.Create(document);
            LayoutButton.PerformClick();

            //Layout the graph
            view.LockRefresh = false;
        }
        private void RandomGraphButton2_Click(object sender, EventArgs e)
        {
            view.LockRefresh = true;
            document.ActiveLayer.RemoveAllChildren();

            NRandomGraphTemplate randomGraph = new NRandomGraphTemplate();
            randomGraph.EdgesStyleSheetName = "CustomConnectors";
            randomGraph.VertexCount = 20;
            randomGraph.EdgeCount = 25;
            randomGraph.Create(document);
            LayoutButton.PerformClick();

            //Layout the graph
            view.LockRefresh = false;
        }

        #endregion

        #region Designer Fields

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Nevron.UI.WinForm.Controls.NButton LayoutButton;
        private Nevron.UI.WinForm.Controls.NButton RandomGraphButton2;
        private Nevron.UI.WinForm.Controls.NButton RandomGraphButton1;

        #endregion

        #region Fields

        private NOrthogonalGraphLayout m_Layout;

        #endregion
    }
}