using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Nevron.Diagram.Layout;
using Nevron.Editors;
using Nevron.Dom;
using Nevron.Diagram.Batches;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NWinFormControlHostingUC.
	/// </summary>
	public class NWinFormControlHostingUC : NDiagramExampleUC
	{
		#region Constructor

		public NWinFormControlHostingUC(NMainForm form) : base(form)
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


		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init view
			view.Grid.Visible = false;
			view.Selection.Mode = DiagramSelectionMode.Single;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;

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
		    // create a button
            Button button = CreateButton();
            NWinFormControlHostShape buttonShape = new NWinFormControlHostShape(button);
            buttonShape.DeactiveOnLostFocus = false;
            document.ActiveLayer.AddChild(buttonShape);

            // create a check box
            CheckBox check = CreateCheckBox();
            NWinFormControlHostShape checkShape = new NWinFormControlHostShape(check);
            checkShape.DeactiveOnLostFocus = false;
            document.ActiveLayer.AddChild(checkShape);

            // create a combo box
            ComboBox combo = CreateComboBox();
            NWinFormControlHostShape comboShape = new NWinFormControlHostShape(combo);
            comboShape.DeactiveOnLostFocus = false;
            document.ActiveLayer.AddChild(comboShape);

            // create a list box
            ListBox listBox = CreateListBox();
            NWinFormControlHostShape listShape = new NWinFormControlHostShape(listBox);
            listShape.DeactiveOnLostFocus = false;
            document.ActiveLayer.AddChild(listShape);

            // create a tree view
            TreeView treeView = CreateTreeView();
            NWinFormControlHostShape treeViewShape = new NWinFormControlHostShape(treeView);
            treeViewShape.DeactiveOnLostFocus = false;
            document.ActiveLayer.AddChild(treeViewShape);

            // layout the shapes
            buttonShape.Location = new NPointF(10, 10);
            comboShape.Location = new NPointF(210, 10);
            checkShape.Location = new NPointF(410, 10);
            listShape.Location = new NPointF(10, 210);
            treeViewShape.Location = new NPointF(210, 210);

            // create ports on all shapes
            foreach (NShape shape in document.ActiveLayer.Children(null))
            {
                shape.CreateShapeElements(ShapeElementsMask.Ports);
                shape.Ports.AddChild(new NDynamicPort(new NContentAlignment(0, 0), DynamicPortGlueMode.GlueToContour));
            }

            // activate all shapes
            foreach (NShape shape in document.ActiveLayer.Children(null))
            {
                view.StartInplaceEditing(shape);
            }

            // link some of the shapes
            NRoutableConnector connector1 = new NRoutableConnector();
            connector1.StyleSheetName = "Connectors";
            document.ActiveLayer.AddChild(connector1);
            connector1.FromShape = buttonShape;
            connector1.ToShape = comboShape;
            connector1.Reroute();

            NRoutableConnector connector2 = new NRoutableConnector();
            connector2.StyleSheetName = "Connectors";
            document.ActiveLayer.AddChild(connector2);
            connector2.FromShape = buttonShape;
            connector2.ToShape = treeViewShape;
            connector2.Reroute();
                        
            // mimic default control background
            document.BackgroundStyle.FillStyle = new NColorFillStyle(SystemColors.Control); 
		}

        Button CreateButton()
        {
            Button button = new Button();
            
            button.Text = "Click Me";
            button.Width = 100;
            button.Height = 50;
            button.Click += new EventHandler(button_Click);

            return button;
        }
        CheckBox CreateCheckBox()
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Text = "Check";
            return checkBox;
        }
        ComboBox CreateComboBox()
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Items.Add("Item1");
            comboBox.Items.Add("Item2");
            comboBox.Items.Add("Item3");
            return comboBox;
        }
        ListBox CreateListBox()
        {
            ListBox listBox = new ListBox();
            listBox.IntegralHeight = false;
            listBox.Items.Add("Item1");
            listBox.Items.Add("Item2");
            listBox.Items.Add("Item3");
            return listBox;
        }        
        TreeView CreateTreeView()
        {
            TreeView treeView = new TreeView();
            treeView.Width = 100;
            treeView.Height = 100;

            TreeNode node1 = new TreeNode("Node1");
            treeView.Nodes.Add(node1);
            node1.Nodes.Add("Node11");
            node1.Nodes.Add("Node12");

            TreeNode node2 = new TreeNode("Node2");
            treeView.Nodes.Add(node1);
            node2.Nodes.Add("Node21");
            node2.Nodes.Add("Node22");

            treeView.ExpandAll();
            return treeView;
        }        

        void button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button was clicked");
        }

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		
		#endregion
	}
}