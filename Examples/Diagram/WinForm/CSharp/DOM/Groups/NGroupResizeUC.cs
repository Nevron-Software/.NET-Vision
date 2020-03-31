using System;
using System.Collections;
using System.Drawing;

using Nevron.Editors;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.DataStructures;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NGroupBehaviourUC.
	/// </summary>
	public class NGroupResizeUC : NDiagramExampleUC
	{
		#region Constructor

		public NGroupResizeUC(NMainForm form) : base(form)
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
			this.groupPropertiesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.updateModelBoundsButton = new Nevron.UI.WinForm.Controls.NButton();
			this.autoUpdateModelBoundsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.shapePropertiesGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.resizeInAggregateComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.resizeAggregatedModelsComboBox = new Nevron.UI.WinForm.Controls.NComboBox();
			this.groupPropertiesGroup.SuspendLayout();
			this.shapePropertiesGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupPropertiesGroup
			// 
			this.groupPropertiesGroup.Controls.Add(this.label2);
			this.groupPropertiesGroup.Controls.Add(this.updateModelBoundsButton);
			this.groupPropertiesGroup.Controls.Add(this.autoUpdateModelBoundsCheckBox);
			this.groupPropertiesGroup.Controls.Add(this.resizeAggregatedModelsComboBox);
			this.groupPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupPropertiesGroup.Enabled = false;
			this.groupPropertiesGroup.ImageIndex = 0;
			this.groupPropertiesGroup.Location = new System.Drawing.Point(0, 88);
			this.groupPropertiesGroup.Name = "groupPropertiesGroup";
			this.groupPropertiesGroup.Size = new System.Drawing.Size(250, 144);
			this.groupPropertiesGroup.TabIndex = 1;
			this.groupPropertiesGroup.TabStop = false;
			this.groupPropertiesGroup.Text = "Selected group properties";
			// 
			// updateModelBoundsButton
			// 
			this.updateModelBoundsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.updateModelBoundsButton.Location = new System.Drawing.Point(8, 112);
			this.updateModelBoundsButton.Name = "updateModelBoundsButton";
			this.updateModelBoundsButton.Size = new System.Drawing.Size(234, 23);
			this.updateModelBoundsButton.TabIndex = 3;
			this.updateModelBoundsButton.Text = "Update model bounds manually";
			this.updateModelBoundsButton.Click += new System.EventHandler(this.updateModelBoundsButton_Click);
			// 
			// autoUpdateModelBoundsCheckBox
			// 
			this.autoUpdateModelBoundsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.autoUpdateModelBoundsCheckBox.Location = new System.Drawing.Point(8, 80);
			this.autoUpdateModelBoundsCheckBox.Name = "autoUpdateModelBoundsCheckBox";
			this.autoUpdateModelBoundsCheckBox.Size = new System.Drawing.Size(234, 24);
			this.autoUpdateModelBoundsCheckBox.TabIndex = 2;
			this.autoUpdateModelBoundsCheckBox.Text = "Auto update model bounds";
			this.autoUpdateModelBoundsCheckBox.CheckedChanged += new System.EventHandler(this.autoUpdateModelBoundsCheckBox_CheckedChanged);
			// 
			// shapePropertiesGroup
			// 
			this.shapePropertiesGroup.Controls.Add(this.resizeInAggregateComboBox);
			this.shapePropertiesGroup.Controls.Add(this.label1);
			this.shapePropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.shapePropertiesGroup.Enabled = false;
			this.shapePropertiesGroup.ImageIndex = 0;
			this.shapePropertiesGroup.Location = new System.Drawing.Point(0, 0);
			this.shapePropertiesGroup.Name = "shapePropertiesGroup";
			this.shapePropertiesGroup.Size = new System.Drawing.Size(250, 88);
			this.shapePropertiesGroup.TabIndex = 0;
			this.shapePropertiesGroup.TabStop = false;
			this.shapePropertiesGroup.Text = "Selected shape properties";
			// 
			// resizeInAggregateComboBox
			// 
			this.resizeInAggregateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.resizeInAggregateComboBox.Location = new System.Drawing.Point(8, 48);
			this.resizeInAggregateComboBox.Name = "resizeInAggregateComboBox";
			this.resizeInAggregateComboBox.Size = new System.Drawing.Size(234, 22);
			this.resizeInAggregateComboBox.TabIndex = 1;
			this.resizeInAggregateComboBox.Text = "nComboBox1";
			this.resizeInAggregateComboBox.SelectedIndexChanged += new System.EventHandler(this.resizeInAggregateComboBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(234, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Resize in group:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Resize shapes:";
			// 
			// resizeAggregatedModelsComboBox
			// 
			this.resizeAggregatedModelsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.resizeAggregatedModelsComboBox.Location = new System.Drawing.Point(8, 48);
			this.resizeAggregatedModelsComboBox.Name = "resizeAggregatedModelsComboBox";
			this.resizeAggregatedModelsComboBox.Size = new System.Drawing.Size(234, 22);
			this.resizeAggregatedModelsComboBox.TabIndex = 1;
			this.resizeAggregatedModelsComboBox.Text = "nComboBox1";
			this.resizeAggregatedModelsComboBox.SelectedIndexChanged += new System.EventHandler(this.resizeAggregatedModelsComboBox_SelectedIndexChanged);
			// 
			// NGroupResizeUC
			// 
			this.Controls.Add(this.groupPropertiesGroup);
			this.Controls.Add(this.shapePropertiesGroup);
			this.Name = "NGroupResizeUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.shapePropertiesGroup, 0);
			this.Controls.SetChildIndex(this.groupPropertiesGroup, 0);
			this.groupPropertiesGroup.ResumeLayout(false);
			this.shapePropertiesGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Overrides NDiagramExampleUC

		protected override void LoadExample()
		{
			base.DefaultGridOrigin = new NPointF(40, 40);
			base.DefaultGridCellSize = new NSizeF(70, 60);

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

			UpdateControlsState();
		}

		protected override void AttachToEvents()
		{
			view.EventSinkService.NodeSelected += new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected += new NodeEventHandler(EventSinkService_NodeDeselected);
		
			base.AttachToEvents();
		}

		protected override void DetachFromEvents()
		{
			view.EventSinkService.NodeSelected -= new NodeEventHandler(EventSinkService_NodeSelected);
			view.EventSinkService.NodeDeselected -= new NodeEventHandler(EventSinkService_NodeDeselected);
		
			base.DetachFromEvents();
		}


		#endregion

		#region Implementation

		private void InitFormControls()
		{
			PauseEventsHandling();

			resizeInAggregateComboBox.FillFromEnum(typeof(ResizeInAggregate));
			resizeAggregatedModelsComboBox.FillFromEnum(typeof(ResizeAggregatedModels));

			ResumeEventsHandling();
		}
		
		private void InitDocument()
		{
			// create the groups
			NGroup group1 = CreateAffineScaleGroup(); 
			NGroup group2 = CreateCartesianScaleGroup();
			NGroup group3 = CreateReposionGroup();
			NGroup group4 = CreateScale1DGroup();

            // apply default styles
			group1.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 204, 0, 0)); 
			group2.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0, 204, 0));
			group3.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0, 0, 204));
			group4.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 255, 255, 0));

            // layout the groups in 2 cols
			NTableLayout layout = new NTableLayout();

            // setup table layout
			layout.Direction = LayoutDirection.LeftToRight;
			layout.ConstrainMode = CellConstrainMode.Ordinal; 
			layout.MaxOrdinal = 2;
			layout.VerticalSpacing = 20; 
			layout.HorizontalSpacing = 20;

            // create a list of shapes to layout
            NNodeList groups = new NNodeList();
            groups.Add(group1);
            groups.Add(group2);
            groups.Add(group3);
            groups.Add(group4);
            
            // create a layout context
            NLayoutContext layoutContext = new NLayoutContext();
            layoutContext.GraphAdapter = new NShapeGraphAdapter();
            layoutContext.BodyAdapter = new NShapeBodyAdapter(document);
            layoutContext.BodyContainerAdapter = new NDrawingBodyContainerAdapter(document);

            // do layout
            layout.Layout(groups, layoutContext);
		}

		protected NGroup CreateAffineScaleGroup()
		{
			NGroup group = new NGroup();

			// rect 1 uses affine scaling
			NRectangleShape rect1 = new NRectangleShape(0, 0, 75, 75);
			rect1.Rotate(CoordinateSystem.Scene, 45, rect1.PinPoint);
			rect1.ResizeInAggregate = ResizeInAggregate.AffineScale; 
			rect1.Text = "Affine Scale";
			group.Shapes.AddChild(rect1);

			// rect 2 uses affine X scaling and Y reposition
			NRectangleShape rect2 = new NRectangleShape(150, 0, 75, 75);
			rect2.Rotate(CoordinateSystem.Scene, 45, rect2.PinPoint);
			rect2.ResizeInAggregate = ResizeInAggregate.AffineScaleXRepositionY; 
			rect2.Text = "Affine Scale X and Reposition Y";
			group.Shapes.AddChild(rect2);

			// rect 3 uses affine Y scaling and X reposition
			NRectangleShape rect3 = new NRectangleShape(0, 150, 75, 75);
			rect3.Rotate(CoordinateSystem.Scene, 45, rect3.PinPoint);
			rect3.ResizeInAggregate = ResizeInAggregate.AffineScaleYRepositionX;
			rect3.Text = "Affine Scale Y and Reposition X";
			group.Shapes.AddChild(rect3);
					
			// update the group model bounds
			group.UpdateModelBounds();

			// in order to demonstrate the reposition, all shapes 
			// are pinned to the bottom rigth corner of the group
			NPointF pin = new NPointF(group.Bounds.Right, group.Bounds.Bottom);
			foreach (NShape shape in group.Shapes)
			{
				shape.PinPoint = pin;
			}

			// add the group to the active layer
			document.ActiveLayer.AddChild(group);
			return group;
		}

		protected NGroup CreateCartesianScaleGroup()
		{
			NGroup group = new NGroup();

			// rect 1 uses cartesian scaling
			NRectangleShape rect1 = new NRectangleShape(0, 0, 75, 75);
			rect1.Rotate(CoordinateSystem.Scene, 45, rect1.PinPoint);
			rect1.ResizeInAggregate = ResizeInAggregate.CartesianScale; 
			rect1.Text = "Cartesian Scale";
			group.Shapes.AddChild(rect1);

			// rect 2 uses cartesian X scaling and Y reposition
			NRectangleShape rect2 = new NRectangleShape(150, 0, 75, 75);
			rect2.Rotate(CoordinateSystem.Scene, 45, rect2.PinPoint);
			rect2.ResizeInAggregate = ResizeInAggregate.CartesianScaleXRepositionY;
			rect2.Text = "Cartesian Scale X and Reposition Y";
			group.Shapes.AddChild(rect2);

			// rect 3 uses cartesian Y scaling and X reposition
			NRectangleShape rect3 = new NRectangleShape(0, 150, 75, 75);
			rect3.Rotate(CoordinateSystem.Scene, 45, rect3.PinPoint);
			rect3.ResizeInAggregate = ResizeInAggregate.CartesianScaleYRepositionX;
			rect3.Text = "Cartesian Scale Y and Reposition X";
			group.Shapes.AddChild(rect3);

			// rect 4 uses cartesian scale and reposition
			NRectangleShape rect4 = new NRectangleShape(150, 150, 75, 75);
			rect4.Rotate(CoordinateSystem.Scene, 45, rect4.PinPoint);
			rect4.ResizeInAggregate = ResizeInAggregate.CartesianScaleAndReposition;
			rect4.Text = "Cartesian Scale and Reposition";
			group.Shapes.AddChild(rect4);
					
			// update the group model bounds
			group.UpdateModelBounds();

			// in order to demonstrate the reposition, all shapes 
			// are pinned to the bottom rigth corner of the group
			NPointF pin = new NPointF(group.Bounds.Right, group.Bounds.Bottom);
			foreach (NShape shape in group.Shapes)
			{
				shape.PinPoint = pin;
			}

			// add the group to the active layer
			document.ActiveLayer.AddChild(group);
			return group;
		}

		protected NGroup CreateReposionGroup()
		{
			NGroup group = new NGroup();

			// rect 1 uses repositon only
			NRectangleShape rect1 = new NRectangleShape(0, 0, 75, 75);
			rect1.Rotate(CoordinateSystem.Scene, 45, rect1.PinPoint);
			rect1.ResizeInAggregate = ResizeInAggregate.RepositionOnly; 
			rect1.Text = "Reposition only";
			group.Shapes.AddChild(rect1);

			// rect 2 uses repositon X only
			NRectangleShape rect2 = new NRectangleShape(150, 0, 75, 75);
			rect2.Rotate(CoordinateSystem.Scene, 45, rect2.PinPoint);
			rect2.ResizeInAggregate = ResizeInAggregate.RepositionXOnly;
			rect2.Text = "Reposition X only";
			group.Shapes.AddChild(rect2);

			// rect 3 uses repositon Y only
			NRectangleShape rect3 = new NRectangleShape(0, 150, 75, 75);
			rect3.Rotate(CoordinateSystem.Scene, 45, rect3.PinPoint);
			rect3.ResizeInAggregate = ResizeInAggregate.RepositionYOnly;
			rect3.Text = "Reposition Y only";
			group.Shapes.AddChild(rect3);

			// update the group model bounds
			group.UpdateModelBounds();

			// in order to demonstrate the reposition, all shapes 
			// are pinned to the bottom rigth corner of the group
			NPointF pin = new NPointF(group.Bounds.Right, group.Bounds.Bottom);
			foreach (NShape shape in group.Shapes)
			{
				shape.PinPoint = pin;
			}

			// add the group to the active layer
			document.ActiveLayer.AddChild(group);
			return group;

		}

		protected NGroup CreateScale1DGroup()
		{
			NGroup group = new NGroup();

			// arrow 
			NArrowShape arrow = new NArrowShape(ArrowType.SingleArrow, new NPointF(0, 0), new NPointF(75, 75), 10, 45, 30);
			arrow.ResizeInAggregate = ResizeInAggregate.Scale1D; 
			arrow.Text = "Scale 1D";
			group.Shapes.AddChild(arrow);

			// line 
			NLineShape line = new NLineShape(new NPointF(150, 0), new NPointF(150 + 100, 100));
			line.StyleSheetName = NDR.NameConnectorsStyleSheet;
			line.ResizeInAggregate = ResizeInAggregate.Scale1D; 
			line.Text = "Scale 1D";
			group.Shapes.AddChild(line);

			// polyline 
			NPolylineShape polyline = new NPolylineShape(base.GetRandomPoints(new NRectangleF(0, 150, 100, 100), 3));
			polyline.StyleSheetName = NDR.NameConnectorsStyleSheet;
			polyline.ResizeInAggregate = ResizeInAggregate.Scale1D; 
			polyline.Text = "Scale 1D";
			group.Shapes.AddChild(polyline);			

			// rect 
			NRectangleShape rect = new NRectangleShape(150, 150, 75, 75);
			rect.Rotate(CoordinateSystem.Scene, 45, rect.PinPoint);
			rect.ResizeInAggregate = ResizeInAggregate.Scale1D;
			rect.Text = "Scale 1D";
			group.Shapes.AddChild(rect);

			// update the group model bounds
			group.UpdateModelBounds();

			// add the group to the active layer
			document.ActiveLayer.AddChild(group);
			return group;

		}


		private void UpdateControlsState()
		{
			// handle single selected node only
			if (view.Selection.NodesCount != 1)
			{
				groupPropertiesGroup.Enabled = false;
				shapePropertiesGroup.Enabled = false;
				return;
			}

			// if the selected node is a group -> update group controls
			NGroup group = (view.Selection.AnchorNode as NGroup);
			if (group != null)
			{
				groupPropertiesGroup.Enabled = true;
				shapePropertiesGroup.Enabled = false;
				autoUpdateModelBoundsCheckBox.Checked = group.AutoUpdateModelBounds;
				resizeAggregatedModelsComboBox.SelectedItem = group.ResizeAggregatedModels; 
				return;
			}

			// if the selected node is a simple shape -> update shape controls
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape != null)
			{
				groupPropertiesGroup.Enabled = false;
				shapePropertiesGroup.Enabled = true;
				resizeInAggregateComboBox.SelectedItem = shape.ResizeInAggregate;
				return;
			}
		}


		#endregion

		#region Event Handlers

		private void autoUpdateModelBoundsCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NGroup group = view.Selection.AnchorNode as NGroup;
			if (group == null)
				return;

			PauseEventsHandling();
			
			group.AutoUpdateModelBounds = autoUpdateModelBoundsCheckBox.Checked;
			document.SmartRefreshAllViews();
			
			ResumeEventsHandling();
		}

		private void resizeAggregatedModelsComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NGroup group = (view.Selection.AnchorNode as NGroup);
			if (group == null)
				return;

			PauseEventsHandling();
			
			group.ResizeAggregatedModels = (ResizeAggregatedModels)resizeAggregatedModelsComboBox.SelectedItem;
			document.SmartRefreshAllViews();

			ResumeEventsHandling();
		}

		private void resizeInAggregateComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			PauseEventsHandling();
			
			shape.ResizeInAggregate = (ResizeInAggregate)resizeInAggregateComboBox.SelectedItem;
			document.SmartRefreshAllViews();

			ResumeEventsHandling();
		}

		private void updateModelBoundsButton_Click(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			NGroup group = view.Selection.AnchorNode as NGroup;
			if (group == null)
				return;

			PauseEventsHandling();
			
			group.UpdateModelBounds(); 
			document.SmartRefreshAllViews();
			
			ResumeEventsHandling();
		}
		
		
		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();
			UpdateControlsState();
			ResumeEventsHandling();
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;

			PauseEventsHandling();
			UpdateControlsState();
			ResumeEventsHandling();
		}

		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;

		private Nevron.UI.WinForm.Controls.NGroupBox groupPropertiesGroup;
		private Nevron.UI.WinForm.Controls.NCheckBox autoUpdateModelBoundsCheckBox;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NComboBox resizeInAggregateComboBox;
		private Nevron.UI.WinForm.Controls.NGroupBox shapePropertiesGroup;
		private Nevron.UI.WinForm.Controls.NButton updateModelBoundsButton;

		#endregion

		#region Fields

		private NNodeList groupNodes = null;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox resizeAggregatedModelsComboBox;
		private NGroup group = null;

		#endregion
	}
}