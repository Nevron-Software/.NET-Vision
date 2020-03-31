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
    /// Summary description for NLayeredGraphLayoutUC.
    /// </summary>
    public class NLayeredGraphLayoutUC : NDiagramExampleUC
    {
        #region Constructor

        public NLayeredGraphLayoutUC(NMainForm form)
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
            this.chkRandomSizes = new System.Windows.Forms.CheckBox();
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
            // RandomGraphButton2
            // 
            this.RandomGraphButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomGraphButton2.Location = new System.Drawing.Point(8, 440);
            this.RandomGraphButton2.Name = "RandomGraphButton2";
            this.RandomGraphButton2.Size = new System.Drawing.Size(244, 23);
            this.RandomGraphButton2.TabIndex = 8;
            this.RandomGraphButton2.Text = "Random Graph (20 vertices, 30 edges)";
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
            this.RandomGraphButton1.TabIndex = 7;
            this.RandomGraphButton1.Text = "Random Graph (10 vertices, 15 edges)";
            this.RandomGraphButton1.UseVisualStyleBackColor = true;
            this.RandomGraphButton1.Click += new System.EventHandler(this.RandomGraphButton1_Click);
            // 
            // chkRandomSizes
            // 
            this.chkRandomSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRandomSizes.AutoSize = true;
            this.chkRandomSizes.Location = new System.Drawing.Point(8, 388);
            this.chkRandomSizes.Name = "chkRandomSizes";
            this.chkRandomSizes.Size = new System.Drawing.Size(119, 17);
            this.chkRandomSizes.TabIndex = 9;
            this.chkRandomSizes.Text = "Random node sizes";
            this.chkRandomSizes.UseVisualStyleBackColor = true;
            // 
            // NLayeredGraphLayoutUC
            // 
            this.Controls.Add(this.chkRandomSizes);
            this.Controls.Add(this.RandomGraphButton2);
            this.Controls.Add(this.RandomGraphButton1);
            this.Controls.Add(this.LayoutButton);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "NLayeredGraphLayoutUC";
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.LayoutButton, 0);
            this.Controls.SetChildIndex(this.RandomGraphButton1, 0);
            this.Controls.SetChildIndex(this.RandomGraphButton2, 0);
            this.Controls.SetChildIndex(this.chkRandomSizes, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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
            m_Layout = new NLayeredGraphLayout();
            propertyGrid1.SelectedObject = m_Layout;

            view.BeginInit();
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.ViewLayout = ViewLayout.Fit;

            // init document
            document.BeginInit();
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant3, Color.FromArgb(192, 194, 194), Color.FromArgb(129, 133, 133));
            document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(68, 90, 108));
            document.Style.EndArrowheadStyle.FillStyle = new NColorFillStyle(Color.FromArgb(247, 150, 56));
            document.Style.StartArrowheadStyle.FillStyle = new NColorFillStyle(Color.FromArgb(247, 150, 56));
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
            int[] from = new int[] { 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 6 };
            int[] to = new int[]   { 2, 3, 4, 4, 5, 6, 7, 5, 9, 8, 9 };
            NShape[] shapes = new NShape[9];
            int vertexCount = shapes.Length, edgeCount = from.Length;
            int i, j, count = vertexCount + edgeCount;

            for(i = 0; i < count; i++)
            {
                if(i < vertexCount)
                {
                    j = vertexCount % 2 == 0 ? i : i + 1;
                    shapes[i] = f.CreateShape((int)BasicShapes.Rectangle);

                    if(vertexCount % 2 != 0 && i == 0)
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

            // resize document to fit all shapes
            document.SizeToContent();
        }

        #endregion

        #region Event Handlers

        private void LayoutButton_Click(object sender, EventArgs e)
        {
            // get the shapes to layout
            NNodeList shapes = document.ActiveLayer.Children(NFilters.Shape2D);

            // layout the shapes
            if (m_Layout != null)
            {
                m_Layout.Layout(shapes, new NDrawingLayoutContext(document));
            }

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
            if (chkRandomSizes.Checked)
            {//Init the max size
                randomGraph.MaxVerticesSize = new NSizeF(randomGraph.MinVerticesSize.Width * 3,
                    randomGraph.MinVerticesSize.Height * 3);
            }

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
            randomGraph.EdgeCount = 30;
            if (chkRandomSizes.Checked)
            {//Init the max size
                randomGraph.MaxVerticesSize = new NSizeF(randomGraph.MinVerticesSize.Width * 3,
                    randomGraph.MinVerticesSize.Height * 3);
            }

            randomGraph.Create(document);
            LayoutButton.PerformClick();

            //Layout the graph
            view.LockRefresh = false;
        }

        #endregion

        #region Designer Fields

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.CheckBox chkRandomSizes;
        private Nevron.UI.WinForm.Controls.NButton LayoutButton;
        private Nevron.UI.WinForm.Controls.NButton RandomGraphButton2;
        private Nevron.UI.WinForm.Controls.NButton RandomGraphButton1;

        #endregion

        #region Fields

        private NLayeredGraphLayout m_Layout;

        #endregion
    }
}