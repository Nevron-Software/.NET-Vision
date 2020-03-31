using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Layout;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
    public class NGroupLayoutUC : NDiagramExampleUC
    {
 		#region Constructor

        public NGroupLayoutUC(NMainForm form)
            : base(form)
		{
			InitializeComponent();
		}

		#endregion

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.btnLayoutGroupA = new Nevron.UI.WinForm.Controls.NButton();
            this.btnLayoutGroupB = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // btnLayoutGroupA
            // 
            this.btnLayoutGroupA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLayoutGroupA.Location = new System.Drawing.Point(8, 15);
            this.btnLayoutGroupA.Name = "btnLayoutGroupA";
            this.btnLayoutGroupA.Size = new System.Drawing.Size(244, 23);
            this.btnLayoutGroupA.TabIndex = 1;
            this.btnLayoutGroupA.Text = "Layout Group A";
            this.btnLayoutGroupA.UseVisualStyleBackColor = true;
            this.btnLayoutGroupA.Click += new System.EventHandler(this.btnLayoutGroupA_Click);
            // 
            // btnLayoutGroupB
            // 
            this.btnLayoutGroupB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLayoutGroupB.Location = new System.Drawing.Point(8, 44);
            this.btnLayoutGroupB.Name = "btnLayoutGroupB";
            this.btnLayoutGroupB.Size = new System.Drawing.Size(244, 23);
            this.btnLayoutGroupB.TabIndex = 2;
            this.btnLayoutGroupB.Text = "Layout Group B";
            this.btnLayoutGroupB.UseVisualStyleBackColor = true;
            this.btnLayoutGroupB.Click += new System.EventHandler(this.btnLayoutGroupB_Click);
            // 
            // NGroupLayoutUC
            // 
            this.Controls.Add(this.btnLayoutGroupA);
            this.Controls.Add(this.btnLayoutGroupB);
            this.Name = "NGroupLayoutUC";
            this.Controls.SetChildIndex(this.btnLayoutGroupB, 0);
            this.Controls.SetChildIndex(this.btnLayoutGroupA, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region Overrides NDiagramExampleUC

        protected override void LoadExample()
        {
            // begin view init
            view.BeginInit();

            // init view
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;

            // init document
            document.BeginInit();
            InitDocument();
            document.EndInit();

            // end view init
            view.EndInit();
        }

        #endregion

        #region Implementation

        private void InitDocument()
        {
            // create the groups
            Group1 = CreateGroup("A");
            Group2 = CreateGroup("B");

            // apply default styles
            Group1.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 204, 0, 0));
            Group2.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0, 204, 0));

            // create the root shape
            NShape root = new NRectangleShape(0, 0, 40, 40);
            root.Name = "treeRoot";
            root.Text = "0";
            document.ActiveLayer.AddChild(root);
            CreateShapePorts(root);

            NRoutableConnector connector = new NRoutableConnector(RoutableConnectorType.DynamicPolyline);
            document.ActiveLayer.AddChild(connector);
            connector.Name = "leftEdge";
            connector.FromShape = root;
            connector.ToShape = Group1;

            connector = new NRoutableConnector(RoutableConnectorType.DynamicPolyline);
            connector.Name = "rightEdge";
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = root;
            connector.ToShape = Group2;

            // do layout
            LayoutGroups();
            Group1.UpdateModelBounds();
            Group2.UpdateModelBounds();
        }
        private void CreateShapePorts(NShape shape)
        {
            shape.CreateShapeElements(ShapeElementsMask.Ports);

            // create a dynamic port anchored to the center of the shape
            NDynamicPort port = new NDynamicPort(new NContentAlignment(ContentAlignment.MiddleCenter), DynamicPortGlueMode.GlueToContour);
            port.Name = "port";
            shape.Ports.AddChild(port);
        }
        private void CreateTree(NGroup group)
        {
            NRectangleShape shape1 = new NRectangleShape(50, 0, 40, 40);
            NRectangleShape shape2 = new NRectangleShape(0, 0, 40, 40);
            NRectangleShape shape3 = new NRectangleShape(50, 50, 40, 40);
            NRectangleShape shape4 = new NRectangleShape(100, 0, 40, 40);
            shape1.Name = "root";

            CreateShapePorts(shape1);
            CreateShapePorts(shape2);
            CreateShapePorts(shape3);
            CreateShapePorts(shape4);

            group.Shapes.AddChild(shape1);
            group.Shapes.AddChild(shape2);
            group.Shapes.AddChild(shape3);
            group.Shapes.AddChild(shape4);

			shape1.Name = group.Name;
            shape1.Text = shape1.Name;

			shape2.Name = group.Name + "1";
			shape2.Text = shape2.Name;

			shape3.Name = group.Name + "2";
			shape3.Text = shape3.Name;

			shape4.Name = group.Name + "3";
			shape4.Text = shape4.Name;

            NRoutableConnector connector = new NRoutableConnector(RoutableConnectorType.DynamicPolyline);
            group.Shapes.AddChild(connector);
            connector.FromShape = shape1;
            connector.ToShape = shape2;

            connector = new NRoutableConnector(RoutableConnectorType.DynamicPolyline);
            group.Shapes.AddChild(connector);
            connector.FromShape = shape1;
            connector.ToShape = shape3;

            connector = new NRoutableConnector(RoutableConnectorType.DynamicPolyline);
            group.Shapes.AddChild(connector);
            connector.FromShape = shape1;
            connector.ToShape = shape4;
        }
        private NGroup CreateGroup(string name)
        {
            NGroup group = new NGroup();
            group.Name = name;
            document.ActiveLayer.AddChild(group);
            CreateTree(group);
            CreateGroupPorts(group);
            group.UpdateModelBounds();

            return group;
        }
        private void CreateGroupPorts(NGroup group)
        {
            group.CreateShapeElements(ShapeElementsMask.Ports);

            // create a dynamic port anchored to the center of the shape
			NRotatedBoundsPort port = new NRotatedBoundsPort(new NContentAlignment(ContentAlignment.TopCenter));
            port.Name = "port";
            group.Ports.AddChild(port);
        }
        private void LayoutGroups()
        {
            NLayeredTreeLayout layout = new NLayeredTreeLayout();
            layout.PlugSpacing.Mode = PlugSpacingMode.None;

            NNodeList shapes = new NNodeList();
            shapes.Add(document.ActiveLayer.GetChildByName("treeRoot"));
            shapes.Add(document.ActiveLayer.GetChildByName("leftEdge"));
            shapes.Add(document.ActiveLayer.GetChildByName("rightEdge"));
            shapes.Add(Group1);
            shapes.Add(Group2);

            layout.Layout(shapes, new NDrawingLayoutContext(document, shapes));
            Group1.UpdateModelBounds();
            Group2.UpdateModelBounds();
        }

        #endregion

        #region Event Handlers

        private void btnLayoutGroupA_Click(object sender, System.EventArgs e)
        {
            NLayeredTreeLayout layout = new NLayeredTreeLayout();
            layout.PlugSpacing.Mode = PlugSpacingMode.None;
            layout.Layout(Group1.Shapes.Children(null), new NDrawingLayoutContext(document, Group1));
            Group1.UpdateModelBounds();
            LayoutGroups();
        }
        private void btnLayoutGroupB_Click(object sender, System.EventArgs e)
        {
            NLayeredTreeLayout layout = new NLayeredTreeLayout();
            layout.PlugSpacing.Mode = PlugSpacingMode.None;
            layout.Layout(Group2.Shapes.Children(null), new NDrawingLayoutContext(document, Group2));
            Group2.UpdateModelBounds();
            LayoutGroups();
        }

        #endregion

        #region Designer Fields

        private NButton btnLayoutGroupA;
        private NButton btnLayoutGroupB;

        #endregion

        #region Fields

        private NGroup Group1;
        private NGroup Group2;

        #endregion
    }
}