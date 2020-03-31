using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using Nevron.Editors;
using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;
using Nevron.Diagram.Templates;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NLayersUC.
	/// </summary>
	public class NLayersUC : NDiagramExampleUC
	{
		#region Constructor

		public NLayersUC(NMainForm form) : base(form)
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
			this.layersGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.groupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.editLayerShadowStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.layerVisibleCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.editLayerStrokeStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.editLayerFillStyleButton = new Nevron.UI.WinForm.Controls.NButton();
			this.activeLayerComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.zOrderComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.shadowsZOrderCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.layersGroup.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.nGroupBox1.SuspendLayout();
			this.nGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// layersGroup
			// 
			this.layersGroup.Controls.Add(this.groupBox1);
			this.layersGroup.Controls.Add(this.activeLayerComboBox);
			this.layersGroup.Controls.Add(this.label2);
			this.layersGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.layersGroup.ImageIndex = 0;
			this.layersGroup.Location = new System.Drawing.Point(0, 88);
			this.layersGroup.Name = "layersGroup";
			this.layersGroup.Size = new System.Drawing.Size(250, 256);
			this.layersGroup.TabIndex = 1;
			this.layersGroup.TabStop = false;
			this.layersGroup.Text = "Active layer";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.editLayerShadowStyleButton);
			this.groupBox1.Controls.Add(this.layerVisibleCheckBox);
			this.groupBox1.Controls.Add(this.editLayerStrokeStyleButton);
			this.groupBox1.Controls.Add(this.editLayerFillStyleButton);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.ImageIndex = 0;
			this.groupBox1.Location = new System.Drawing.Point(3, 93);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(244, 160);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Active layer properties";
			// 
			// editLayerShadowStyleButton
			// 
			this.editLayerShadowStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editLayerShadowStyleButton.Location = new System.Drawing.Point(8, 120);
			this.editLayerShadowStyleButton.Name = "editLayerShadowStyleButton";
			this.editLayerShadowStyleButton.Size = new System.Drawing.Size(224, 23);
			this.editLayerShadowStyleButton.TabIndex = 3;
			this.editLayerShadowStyleButton.Text = "Shadow style ...";
			this.editLayerShadowStyleButton.Click += new System.EventHandler(this.editLayerShadowStyleButton_Click);
			// 
			// layerVisibleCheckBox
			// 
			this.layerVisibleCheckBox.Checked = true;
			this.layerVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.layerVisibleCheckBox.Location = new System.Drawing.Point(8, 24);
			this.layerVisibleCheckBox.Name = "layerVisibleCheckBox";
			this.layerVisibleCheckBox.Size = new System.Drawing.Size(200, 24);
			this.layerVisibleCheckBox.TabIndex = 0;
			this.layerVisibleCheckBox.Text = "Visible";
			this.layerVisibleCheckBox.CheckedChanged += new System.EventHandler(this.layerVisibleCheckBox_CheckedChanged);
			// 
			// editLayerStrokeStyleButton
			// 
			this.editLayerStrokeStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editLayerStrokeStyleButton.Location = new System.Drawing.Point(8, 88);
			this.editLayerStrokeStyleButton.Name = "editLayerStrokeStyleButton";
			this.editLayerStrokeStyleButton.Size = new System.Drawing.Size(224, 23);
			this.editLayerStrokeStyleButton.TabIndex = 2;
			this.editLayerStrokeStyleButton.Text = "Stroke style ...";
			this.editLayerStrokeStyleButton.Click += new System.EventHandler(this.editLayerStrokeStyleButton_Click);
			// 
			// editLayerFillStyleButton
			// 
			this.editLayerFillStyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.editLayerFillStyleButton.Location = new System.Drawing.Point(8, 56);
			this.editLayerFillStyleButton.Name = "editLayerFillStyleButton";
			this.editLayerFillStyleButton.Size = new System.Drawing.Size(224, 23);
			this.editLayerFillStyleButton.TabIndex = 1;
			this.editLayerFillStyleButton.Text = "Fill style ...";
			this.editLayerFillStyleButton.Click += new System.EventHandler(this.editLayerFillStyleButton_Click);
			// 
			// activeLayerComboBox
			// 
			this.activeLayerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.activeLayerComboBox.Location = new System.Drawing.Point(8, 56);
			this.activeLayerComboBox.Name = "activeLayerComboBox";
			this.activeLayerComboBox.Size = new System.Drawing.Size(234, 22);
			this.activeLayerComboBox.TabIndex = 1;
			this.activeLayerComboBox.Text = "nComboBox1";
			this.activeLayerComboBox.SelectedIndexChanged += new System.EventHandler(this.activeLayerComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Select active layer:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nGroupBox1
			// 
			this.nGroupBox1.Controls.Add(this.label1);
			this.nGroupBox1.Controls.Add(this.zOrderComboBox);
			this.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox1.ImageIndex = 0;
			this.nGroupBox1.Location = new System.Drawing.Point(0, 0);
			this.nGroupBox1.Name = "nGroupBox1";
			this.nGroupBox1.Size = new System.Drawing.Size(250, 88);
			this.nGroupBox1.TabIndex = 0;
			this.nGroupBox1.TabStop = false;
			this.nGroupBox1.Text = "Change layers Z-Order";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Predefined Z-Order:";
			// 
			// zOrderComboBox
			// 
			this.zOrderComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.zOrderComboBox.Location = new System.Drawing.Point(8, 48);
			this.zOrderComboBox.Name = "zOrderComboBox";
			this.zOrderComboBox.Size = new System.Drawing.Size(234, 22);
			this.zOrderComboBox.TabIndex = 1;
			this.zOrderComboBox.Text = "nComboBox1";
			this.zOrderComboBox.SelectedIndexChanged += new System.EventHandler(this.zOrderComboBox_SelectedIndexChanged);
			// 
			// nGroupBox2
			// 
			this.nGroupBox2.Controls.Add(this.shadowsZOrderCombo);
			this.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.nGroupBox2.ImageIndex = 0;
			this.nGroupBox2.Location = new System.Drawing.Point(0, 344);
			this.nGroupBox2.Name = "nGroupBox2";
			this.nGroupBox2.Size = new System.Drawing.Size(250, 56);
			this.nGroupBox2.TabIndex = 3;
			this.nGroupBox2.TabStop = false;
			this.nGroupBox2.Text = "Shadows Z-Order";
			// 
			// shadowsZOrderCombo
			// 
			this.shadowsZOrderCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.shadowsZOrderCombo.Location = new System.Drawing.Point(8, 24);
			this.shadowsZOrderCombo.Name = "shadowsZOrderCombo";
			this.shadowsZOrderCombo.Size = new System.Drawing.Size(234, 22);
			this.shadowsZOrderCombo.TabIndex = 1;
			this.shadowsZOrderCombo.Text = "nComboBox1";
			this.shadowsZOrderCombo.SelectedIndexChanged += new System.EventHandler(this.shadowsZOrderCombo_SelectedIndexChanged);
			// 
			// NLayersUC
			// 
			this.Controls.Add(this.nGroupBox2);
			this.Controls.Add(this.layersGroup);
			this.Controls.Add(this.nGroupBox1);
			this.Name = "NLayersUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.nGroupBox1, 0);
			this.Controls.SetChildIndex(this.layersGroup, 0);
			this.Controls.SetChildIndex(this.nGroupBox2, 0);
			this.layersGroup.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.nGroupBox1.ResumeLayout(false);
			this.nGroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

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
			
			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();
		}


		#endregion

		#region Implementation

		private void InitDocument()
		{
			document.Layers.RemoveAllChildren();
			CreateGraphLayer();
			CreateShapesLayer();
			CreateTreeLayer();
		}

		private void InitFormControls()
		{
			PauseEventsHandling();

			// init the Z Order combo
			zOrderComboBox.Items.Clear();
			
			zOrderComboBox.Items.Add("1.Tree - 2.Shapes - 3.Graph");
			zOrderComboBox.Items.Add("1.Shapes - 2.Graph - 3.Tree");
			zOrderComboBox.Items.Add("1.Graph - 2.Tree - 3.Shapes");

			// initially the Z order is the order of layers creation
			zOrderComboBox.SelectedIndex = 0;

			// init the active layer combo
			activeLayerComboBox.Items.Clear();

			NNodeList layers = document.Layers.Children(null);
			foreach (NLayer layer in layers)
			{
				activeLayerComboBox.Items.Add(layer);
			}

			// initially the last added layer is the active one
			if (layers.Count != 0)
			{
				activeLayerComboBox.SelectedIndex = (layers.Count - 1);
			}

			// init the shadows Z Order combo
			shadowsZOrderCombo.FillFromEnum(typeof(ShadowsZOrder));
			shadowsZOrderCombo.SelectedIndex = (int)document.ShadowsZOrder;

			ResumeEventsHandling();
		}

		private void CreateTreeLayer()
		{
			// create the tree layer and modify its styles
			treeLayer = new NLayer();
			treeLayer.Name = "Tree Layer";
			
			treeLayer.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(30, 30, 0));
			treeLayer.Style.FillStyle = new NColorFillStyle(Color.FromArgb(0xaa, 0xaa, 0));
			treeLayer.Style.ShadowStyle = new NShadowStyle(
				ShadowType.Solid, 
				Color.FromArgb(50, 0, 0, 0), 
				new NPointL(3, 3), 
				1, 
				new NLength(1));

			// add it to the document and make it the active one
			document.Layers.AddChild(treeLayer);
			document.ActiveLayerUniqueId = treeLayer.UniqueId;

			// create a tree template with pentagons in it
			NGenericTreeTemplate treeTemplate = new NGenericTreeTemplate(); 
			treeTemplate.VerticesShape = BasicShapes.Pentagon;
			treeTemplate.Origin = new NPointF(10, 10); 

			// create it
			treeTemplate.Create(document);
		}

		private void CreateShapesLayer()
		{
			// create the shapes layer and modify its styles
			shapesLayer = new NLayer();
			shapesLayer.Name = "Shapes Layer";

			shapesLayer.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(0x00, 0x00, 0xaa));
			shapesLayer.Style.FillStyle = new NColorFillStyle(Color.FromArgb(0xaa, 0xaa, 0xff));
			shapesLayer.Style.ShadowStyle = new NShadowStyle(
				ShadowType.Solid, 
				Color.FromArgb(80, 0, 0, 0), 
				new NPointL(3, 3), 1, 
				new NLength(1));

			// add it to the document and make it the active one
			document.Layers.AddChild(shapesLayer);
			document.ActiveLayerUniqueId = shapesLayer.UniqueId;

			// create two shapes in it
			NRectangleShape rect = new NRectangleShape(new NRectangleF(60, 60, 70, 70));
			shapesLayer.AddChild(rect);

			NEllipseShape ellipse = new NEllipseShape(new NRectangleF(120, 120, 70, 70));
			shapesLayer.AddChild(ellipse);
		}

		private void CreateGraphLayer()
		{
			// create the graph layer and modify its styles
			graphLayer = new NLayer();
			graphLayer.Name = "Graph Layer";
			
			graphLayer.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(0xaa, 0x00, 0x00));
			graphLayer.Style.FillStyle = new NColorFillStyle(Color.FromArgb(0xff, 0x99, 0x77));
			graphLayer.Style.ShadowStyle = new NShadowStyle(
				ShadowType.Solid, 
				Color.FromArgb(80, 0, 0, 0), 
				new NPointL(3, 3), 
				1, 
				new NLength(1));
			
			// add it to the document and make it the active one
			document.Layers.AddChild(graphLayer);
			document.ActiveLayerUniqueId = graphLayer.UniqueId;

			// create an elliptical grid template with pentagrams in it
			NEllipticalGridTemplate ellipticalGrid = new NEllipticalGridTemplate();
			ellipticalGrid.VerticesShape = BasicShapes.Pentagram;
			ellipticalGrid.Origin = new NPointF(60, 60);

			// create it
			ellipticalGrid.Create(document);
		}

		
		#endregion

		#region Event Handlers
		
		private void activeLayerComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (activeLayerComboBox.SelectedItem == null)
				return;
			
			PauseEventsHandling();

			// change the active layer
			document.ActiveLayerUniqueId = (activeLayerComboBox.SelectedItem as NLayer).UniqueId;

			// select the selectable layer children
			view.Selection.SingleSelect(document.ActiveLayer.Children(NFilters.PermissionSelect));
			view.SmartRefresh();
			
			// update the layer visibility check box
			layerVisibleCheckBox.Checked = document.ActiveLayer.Visible;
			
			ResumeEventsHandling();
		}

		private void layerVisibleCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			if (activeLayerComboBox.SelectedIndex == -1 || document.ActiveLayer == null)
				return;
			
			PauseEventsHandling();

			// show/hide the active layer
			document.ActiveLayer.Visible = layerVisibleCheckBox.Checked;
			document.SmartRefreshAllViews();
			
			ResumeEventsHandling();
		}

		private void zOrderComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			if (zOrderComboBox.SelectedIndex == -1)
				return;

			// reorder layers
			document.StartTransaction("Change layers Z Order");
			
			switch (zOrderComboBox.SelectedIndex)
			{
				case 0:		//	1.Tree - 2.Shapes - 3.Graph
					treeLayer.BringToFront();
					graphLayer.SendToBack();
					break;
				case 1:		// 1.Shapes - 2.Graph - 3.Tree
					shapesLayer.BringToFront();
					treeLayer.SendToBack();
					break;
				case 2:		//	1.Graph - 2.Tree - 3.Shapes 
					graphLayer.BringToFront();
					shapesLayer.SendToBack();
					break;
			}

			document.Commit();
			document.SmartRefreshAllViews();
		}

		private void shadowsZOrderCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			if (shadowsZOrderCombo.SelectedIndex == -1)
				return;

			// change the shadows ZOrder
			document.ShadowsZOrder = (ShadowsZOrder)shadowsZOrderCombo.SelectedIndex;
			document.SmartRefreshAllViews();
		}


		private void editLayerFillStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowFillStyleEditor(document.ActiveLayer);
		}

		private void editLayerStrokeStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowStrokeStyleEditor(document.ActiveLayer);
		}

		private void editLayerShadowStyleButton_Click(object sender, System.EventArgs e)
		{
			base.ShowShadowStyleEditor(document.ActiveLayer);
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NGroupBox layersGroup;
		private Nevron.UI.WinForm.Controls.NComboBox activeLayerComboBox;

		#endregion

		#region Fields

		private NLayer treeLayer = null;
		private NLayer shapesLayer = null;
		private NLayer graphLayer = null;

		private Nevron.UI.WinForm.Controls.NCheckBox layerVisibleCheckBox;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox zOrderComboBox;
		private Nevron.UI.WinForm.Controls.NButton editLayerShadowStyleButton;
		private Nevron.UI.WinForm.Controls.NButton editLayerStrokeStyleButton;
		private Nevron.UI.WinForm.Controls.NButton editLayerFillStyleButton;
		private Nevron.UI.WinForm.Controls.NGroupBox groupBox1;
		private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
		private Nevron.UI.WinForm.Controls.NComboBox shadowsZOrderCombo;
				
		#endregion
	}
}