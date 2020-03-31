using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Editors;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Filters;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.Templates;

namespace Nevron.Examples.Diagram.WinForm
{
    /// <summary>
    /// Summary description for NGraphTraversalUC.
    /// </summary>
    public class NGraphTraversalUC : NDiagramExampleUC
    {
        #region Constructor

        public NGraphTraversalUC(NMainForm form)
            : base(form)
        {
            InitializeComponent();
        }

        #endregion

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphPartCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.directedGraphRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.undirectedGraphRadioButton = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.traversalMethodComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphPartCheck
            // 
            this.graphPartCheck.Location = new System.Drawing.Point(8, 144);
            this.graphPartCheck.Name = "graphPartCheck";
            this.graphPartCheck.Size = new System.Drawing.Size(216, 24);
            this.graphPartCheck.TabIndex = 32;
            this.graphPartCheck.Text = "Graph part";
            this.graphPartCheck.CheckedChanged += new System.EventHandler(this.graphPartCheck_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.directedGraphRadioButton);
            this.groupBox1.Controls.Add(this.undirectedGraphRadioButton);
            this.groupBox1.Controls.Add(this.traversalMethodComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 136);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph traversal";
            // 
            // directedGraphRadioButton
            // 
            this.directedGraphRadioButton.Location = new System.Drawing.Point(8, 104);
            this.directedGraphRadioButton.Name = "directedGraphRadioButton";
            this.directedGraphRadioButton.TabIndex = 3;
            this.directedGraphRadioButton.Text = "Directed graph";
            this.directedGraphRadioButton.CheckedChanged += new System.EventHandler(this.directedGraphRadioButton_CheckedChanged);
            // 
            // undirectedGraphRadioButton
            // 
            this.undirectedGraphRadioButton.Location = new System.Drawing.Point(8, 80);
            this.undirectedGraphRadioButton.Name = "undirectedGraphRadioButton";
            this.undirectedGraphRadioButton.Size = new System.Drawing.Size(136, 24);
            this.undirectedGraphRadioButton.TabIndex = 2;
            this.undirectedGraphRadioButton.Text = "Undirected graph";
            this.undirectedGraphRadioButton.CheckedChanged += new System.EventHandler(this.undirectedGraphRadioButton_CheckedChanged);
            // 
            // traversalMethodComboBox
            // 
            this.traversalMethodComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.traversalMethodComboBox.Location = new System.Drawing.Point(8, 48);
            this.traversalMethodComboBox.Name = "traversalMethodComboBox";
            this.traversalMethodComboBox.Size = new System.Drawing.Size(232, 21);
            this.traversalMethodComboBox.TabIndex = 1;
            this.traversalMethodComboBox.SelectedIndexChanged += new System.EventHandler(this.traversalMethodComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Traversal method:";
            // 
            // NGraphTraversalUC
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.graphPartCheck);
            this.Name = "NGraphTraversalUC";
            this.Size = new System.Drawing.Size(248, 560);
            this.Controls.SetChildIndex(this.graphPartCheck, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // init form members
            highlightFillStyle = new NColorFillStyle(Color.FromArgb(80, Color.Red));
            highlightStrokeStyle = new NStrokeStyle(2, Color.Red);

            // begin view init
            view.BeginInit();

            view.Grid.Visible = false;
            view.Selection.Mode = DiagramSelectionMode.Single;
            view.InteractiveAppearance.SelectedStrokeStyle = new NStrokeStyle(2, Color.Blue);
            view.InteractiveAppearance.SelectedFillStyle = new NColorFillStyle(Color.FromArgb(80, Color.Blue));

            // init document
            document.BeginInit();

            document.Style.TextStyle = new NTextStyle(new Font("Arial", 9), Color.Black);
            InitDocument();

            document.EndInit();

            // init form controls
            InitFormControls();

            // end view init
            view.EndInit();
        }

        protected override void AttachToEvents()
        {
            view.EventSinkService.NodeSelected += new NodeEventHandler(EventSinkService_OnNodeSelected);
            view.EventSinkService.NodeDeselected += new NodeEventHandler(EventSinkService_OnNodeDeselected);

            base.AttachToEvents();
        }

        protected override void DetachFromEvents()
        {
            view.EventSinkService.NodeSelected -= new NodeEventHandler(EventSinkService_OnNodeSelected);
            view.EventSinkService.NodeDeselected -= new NodeEventHandler(EventSinkService_OnNodeDeselected);

            base.DetachFromEvents();
        }


        #endregion

        #region Implementation

        private void InitFormControls()
        {
            PauseEventsHandling();

            view.GlobalVisibility.ShowPorts = false;
            traversalMethodComboBox.Items.Clear();
            traversalMethodComboBox.Items.Add("Depth First Traversal");
            traversalMethodComboBox.Items.Add("Breadth First Traversal");
            traversalMethodComboBox.Items.Add("Topological Order Traversal");
            traversalMethodComboBox.SelectedIndex = 0;
            undirectedGraphRadioButton.Checked = true;

            ResumeEventsHandling();
        }

        private void InitDocument()
        {
            NGraphTemplate template;

            // create rectangular grid template
            template = new NRectangularGridTemplate();
            template.Origin = new NPointF(10, 23);
            template.VerticesShape = BasicShapes.Rectangle;
            template.Create(document);

            // create tree template
            template = new NGenericTreeTemplate();
            template.Origin = new NPointF(250, 23);
            template.VerticesShape = BasicShapes.Triangle;
            template.Create(document);

            // create elliptical grid template
            template = new NEllipticalGridTemplate();
            template.Origin = new NPointF(10, 250);
            template.VerticesShape = BasicShapes.Ellipse;
            template.Create(document);
        }

        private void UpdateHighlights()
        {
            ClearHighlights();

            // get the selected shape
            NShape shape = (view.Selection.AnchorNode as NShape);
            if (shape == null)
            {
                document.SmartRefreshAllViews();
                return;
            }

            // get the graph in which the shape resides
            NGraphBuilder graphBuilder = new NGraphBuilder(new NShapeGraphAdapter(), new NGraphPartFactory());

            NObjectGraphPartMap map;
            NGraph graph = graphBuilder.BuildGraph(shape, out map);
            if (graph == null)
            {
                document.SmartRefreshAllViews();
                return;
            }

            // get the vertex which represents the shape in the graph
            NGraphVertex vertex = (map.GetPartFromObject(shape) as NGraphVertex);
            if (vertex == null)
                return;

            // create a visitor which will visit and highlight the graph parts
            NHighlightingVisitor visitor = new NHighlightingVisitor(this);
            visitor.objectMap = map;
            GraphType graphType = (undirectedGraphRadioButton.Checked ? GraphType.Undirected : GraphType.Directed);

            switch (traversalMethodComboBox.SelectedIndex)
            {
                case 0: // Depth First Traversal
                    graph.DepthFirstTraversal(graphType, visitor, vertex);
                    break;

                case 1: // Breadth First Traversal
                    graph.BreadthFirstTraversal(graphType, visitor, vertex);
                    break;

                case 2: // Topological Order Traversal (applicable for directed graphs only)
                    graph.TopologicalOrderTraversal(visitor);
                    break;
            }

            // smart refresh all views
            document.SmartRefreshAllViews();
        }

        private void ClearHighlights()
        {
            NNodeEnumerator en = document.ActiveLayer.GetEnumerator(null);
            while (en.MoveNext())
            {
                NShape shape = (en.Current as NShape);
                if (shape != null)
                {
                    shape.Style.FillStyle = null;
                    shape.Style.StrokeStyle = null;
                    shape.Text = "";
                }
            }
        }

        #endregion

        #region Event Handlers

        private void EventSinkService_OnNodeSelected(NNodeEventArgs args)
        {
            NShape shape = (args.Node as NShape);
            if (shape != null)
            {
                base.PauseEventsHandling();

                graphPartCheck.Enabled = true;
                graphPartCheck.Checked = shape.GraphPart;

                base.ResumeEventsHandling();
            }

            UpdateHighlights();
        }

        private void EventSinkService_OnNodeDeselected(NNodeEventArgs args)
        {
            ClearHighlights();
            graphPartCheck.Enabled = false;

            document.SmartRefreshAllViews();
        }


        private void directedGraphRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateHighlights();
        }

        private void undirectedGraphRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateHighlights();
        }

        private void traversalMethodComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateHighlights();
        }

        private void graphPartCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            if (EventsHandlingPaused)
                return;

            NShape shape = (view.Selection.AnchorNode as NShape);
            if (shape == null)
                return;

            shape.GraphPart = graphPartCheck.Checked;
            if (shape.GraphPart == false)
            {
                shape.Text = "No";
            }
            else
            {
                shape.Text = "";
            }

            UpdateHighlights();
        }


        #endregion

        #region Designer Fields

        private System.ComponentModel.Container components = null;

        #endregion

        #region Fields

        internal NColorFillStyle highlightFillStyle = null;
        internal NStrokeStyle highlightStrokeStyle = null;

        private Nevron.UI.WinForm.Controls.NCheckBox graphPartCheck;
        private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NComboBox traversalMethodComboBox;
        private Nevron.UI.WinForm.Controls.NRadioButton undirectedGraphRadioButton;
        private Nevron.UI.WinForm.Controls.NRadioButton directedGraphRadioButton;
        private NStrokeStyle selectedStrokeStyle = null;

        #endregion
    }

    /// <summary>
    /// The NHighlightingVisitor class is used to highlight the visited graph parts 
    /// </summary>
    public class NHighlightingVisitor : NGraphPartVisitor
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc"></param>
        public NHighlightingVisitor(NGraphTraversalUC uc)
        {
            userControl = uc;
            vertexCounter = 0;
        }


        #endregion

        #region Overrides

        /// <summary>
        /// Overriden to highlight the graph part
        /// </summary>
        /// <param name="part"></param>
        /// <returns>true if visiting must continue, otherwise false</returns>
        public override bool Visit(NGraphPart part)
        {
            if (part is NGraphVertex)
            {
                NShape shape = (NShape)objectMap.GetObjectFromPart(part);
                shape.Text = vertexCounter.ToString();
                shape.Style.FillStyle = (NFillStyle)userControl.highlightFillStyle.Clone();
                shape.Style.StrokeStyle = (NStrokeStyle)userControl.highlightStrokeStyle.Clone();
                vertexCounter++;
            }

            return true;
        }

        #endregion

        #region Fields

        private int vertexCounter;
        private NGraphTraversalUC userControl;
        internal NObjectGraphPartMap objectMap;

        #endregion
    }
}