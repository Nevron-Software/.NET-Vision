using System;
using System.Collections;
using System.Drawing;

using Nevron.Editors;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.Filters;
using Nevron.Diagram.Batches;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NGroupsUC.
	/// </summary>
	public class NGroupAndUngroupUC : NDiagramExampleUC
	{
		#region Constructor

		public NGroupAndUngroupUC(NMainForm form) : base(form)
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
			this.selectedGroupsActionsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.protectFromUngroupCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.ungroupToParentGroupButton = new Nevron.UI.WinForm.Controls.NButton();
			this.ungroupToLayerButton = new Nevron.UI.WinForm.Controls.NButton();
			this.groupButton = new Nevron.UI.WinForm.Controls.NButton();
			this.protectFromGroupCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.selectedShapesActionsGroup = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.selectedGroupsActionsGroup.SuspendLayout();
			this.selectedShapesActionsGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// selectedGroupsActionsGroup
			// 
			this.selectedGroupsActionsGroup.Controls.Add(this.protectFromUngroupCheckBox);
			this.selectedGroupsActionsGroup.Controls.Add(this.ungroupToParentGroupButton);
			this.selectedGroupsActionsGroup.Controls.Add(this.ungroupToLayerButton);
			this.selectedGroupsActionsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectedGroupsActionsGroup.ImageIndex = 0;
			this.selectedGroupsActionsGroup.Location = new System.Drawing.Point(0, 0);
			this.selectedGroupsActionsGroup.Name = "selectedGroupsActionsGroup";
			this.selectedGroupsActionsGroup.Size = new System.Drawing.Size(250, 144);
			this.selectedGroupsActionsGroup.TabIndex = 0;
			this.selectedGroupsActionsGroup.TabStop = false;
			this.selectedGroupsActionsGroup.Text = "Selected group actions";
			// 
			// protectFromUngroupCheckBox
			// 
			this.protectFromUngroupCheckBox.Location = new System.Drawing.Point(8, 96);
			this.protectFromUngroupCheckBox.Name = "protectFromUngroupCheckBox";
			this.protectFromUngroupCheckBox.Size = new System.Drawing.Size(170, 24);
			this.protectFromUngroupCheckBox.TabIndex = 2;
			this.protectFromUngroupCheckBox.Text = "Protect from ungroup";
			this.protectFromUngroupCheckBox.CheckedChanged += new System.EventHandler(this.protectFromUngroupCheckBox_CheckedChanged);
			// 
			// ungroupToParentGroupButton
			// 
			this.ungroupToParentGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ungroupToParentGroupButton.Enabled = false;
			this.ungroupToParentGroupButton.Location = new System.Drawing.Point(8, 60);
			this.ungroupToParentGroupButton.Name = "ungroupToParentGroupButton";
			this.ungroupToParentGroupButton.Size = new System.Drawing.Size(232, 24);
			this.ungroupToParentGroupButton.TabIndex = 1;
			this.ungroupToParentGroupButton.Text = "Ungroup to Parent Group";
			this.ungroupToParentGroupButton.Click += new System.EventHandler(this.ungroupToParentGroupButton_Click);
			// 
			// ungroupToLayerButton
			// 
			this.ungroupToLayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ungroupToLayerButton.Enabled = false;
			this.ungroupToLayerButton.Location = new System.Drawing.Point(8, 24);
			this.ungroupToLayerButton.Name = "ungroupToLayerButton";
			this.ungroupToLayerButton.Size = new System.Drawing.Size(232, 24);
			this.ungroupToLayerButton.TabIndex = 0;
			this.ungroupToLayerButton.Text = "Ungroup to Active Layer";
			this.ungroupToLayerButton.Click += new System.EventHandler(this.ungroupToLayerButton_Click);
			// 
			// groupButton
			// 
			this.groupButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupButton.Enabled = false;
			this.groupButton.Location = new System.Drawing.Point(8, 24);
			this.groupButton.Name = "groupButton";
			this.groupButton.Size = new System.Drawing.Size(232, 24);
			this.groupButton.TabIndex = 0;
			this.groupButton.Text = "Group";
			this.groupButton.Click += new System.EventHandler(this.groupButton_Click);
			// 
			// protectFromGroupCheckBox
			// 
			this.protectFromGroupCheckBox.Location = new System.Drawing.Point(8, 56);
			this.protectFromGroupCheckBox.Name = "protectFromGroupCheckBox";
			this.protectFromGroupCheckBox.Size = new System.Drawing.Size(170, 24);
			this.protectFromGroupCheckBox.TabIndex = 1;
			this.protectFromGroupCheckBox.Text = "Protect from group";
			this.protectFromGroupCheckBox.CheckedChanged += new System.EventHandler(this.protectFromGroupCheckBox_CheckedChanged);
			// 
			// selectedShapesActionsGroup
			// 
			this.selectedShapesActionsGroup.Controls.Add(this.protectFromGroupCheckBox);
			this.selectedShapesActionsGroup.Controls.Add(this.groupButton);
			this.selectedShapesActionsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectedShapesActionsGroup.ImageIndex = 0;
			this.selectedShapesActionsGroup.Location = new System.Drawing.Point(0, 144);
			this.selectedShapesActionsGroup.Name = "selectedShapesActionsGroup";
			this.selectedShapesActionsGroup.Size = new System.Drawing.Size(250, 88);
			this.selectedShapesActionsGroup.TabIndex = 1;
			this.selectedShapesActionsGroup.TabStop = false;
			this.selectedShapesActionsGroup.Text = "Selected shapes actions";
			// 
			// NGroupAndUngroupUC
			// 
			this.Controls.Add(this.selectedShapesActionsGroup);
			this.Controls.Add(this.selectedGroupsActionsGroup);
			this.Name = "NGroupAndUngroupUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.selectedGroupsActionsGroup, 0);
			this.Controls.SetChildIndex(this.selectedShapesActionsGroup, 0);
			this.selectedGroupsActionsGroup.ResumeLayout(false);
			this.selectedShapesActionsGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		#region NDiagramExampleUC Overrides

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
			
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;
			
			InitDocument();

			// end document initialization
			document.EndInit();			

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

		private void UpdateControlsState()
		{
			PauseEventsHandling();

			// get the selected nodes
			NNodeList selectedNodes = view.Selection.Nodes;
			
			if (selectedNodes.Count == 0)
			{
				// if not nodes are selected - disable form controls
				selectedGroupsActionsGroup.Enabled = false;
				selectedShapesActionsGroup.Enabled = false;
			}
			else if (selectedNodes.Count == 1)
			{
				// if the selected node is a group
				NGroup group = (view.Selection.AnchorNode as NGroup);
				if (group != null)
				{
					selectedGroupsActionsGroup.Enabled = true;

					// check whether the group can be ungrouped to layer
					NBatchUngroup batchUngroup = new NBatchUngroup(document, selectedNodes);
					ungroupToLayerButton.Enabled = batchUngroup.CanUngroup(document.ActiveLayer, false);

					// check whether the group can be ungrouped to a parent group
					NGroup parentGroup = group.Group;
					if (parentGroup != null)
					{
						ungroupToParentGroupButton.Enabled = batchUngroup.CanUngroup(parentGroup, false);
					}
					else
					{
						ungroupToParentGroupButton.Enabled = false;
					}
					
					// update the protect from ungroup check button
					protectFromUngroupCheckBox.Enabled = true;
					protectFromUngroupCheckBox.Checked = group.Protection.Ungroup;
				}
				else
				{
					selectedGroupsActionsGroup.Enabled = false;
				}

				// if the selected node is a shape
				NShape shape = (view.Selection.AnchorNode as NShape);
				if (shape != null)
				{
					selectedShapesActionsGroup.Enabled = true;

					// check whether the selected shape can be grouped
					NBatchGroup batchGroup = new NBatchGroup(document, selectedNodes);
					groupButton.Enabled = batchGroup.CanGroup(document.ActiveLayer, false);

					// update the protect from group check button
					protectFromGroupCheckBox.Enabled = true;
					protectFromGroupCheckBox.Checked = shape.Protection.Group; 
				}
				else
				{
					selectedShapesActionsGroup.Enabled = false;
				}
			}
			else 
			{
				// multiple nodes are selected
				selectedGroupsActionsGroup.Enabled = true;
				selectedShapesActionsGroup.Enabled = true;

				// update ungroup buttons
				NBatchUngroup batchUngroup = new NBatchUngroup(document, selectedNodes);
				ungroupToLayerButton.Enabled = batchUngroup.CanUngroup(document.ActiveLayer, false);
				ungroupToParentGroupButton.Enabled = false;

				// update group button
				NBatchGroup batchGroup = new NBatchGroup(document, selectedNodes);
				groupButton.Enabled = batchGroup.CanGroup(document.ActiveLayer, false);
				
				// disable protection checks
				protectFromUngroupCheckBox.Enabled = true;
				protectFromGroupCheckBox.Enabled = false;
			}
			
			base.ResumeEventsHandling();
		}

		private void InitDocument()
		{
			Color color1 = Color.FromArgb(25, 0, 0xaa, 0xaa);
			Color color2 = Color.FromArgb(150, 0, 0, 204);

			NGroup group = new NGroup();

			// create the group frame
			NRectangleF bounds = base.GetGridCell(0, 0, 2, 3);
			NRectangleShape frame = new NRectangleShape(bounds);
			frame.Protection = new NAbilities(AbilitiesMask.Select);
			frame.Style.FillStyle = new NColorFillStyle(color1);
			group.Shapes.AddChild(frame);

			// add some shape to the group
			group.Shapes.AddChild(new NRectangleShape(base.GetGridCell(0, 2)));
			group.Shapes.AddChild(new NEllipseShape(base.GetGridCell(0, 3)));
			group.Shapes.AddChild(new NTextShape("Parent group", GetGridCell(2, 0, 0, 3)));

			// add the child group in the group
			group.Shapes.AddChild(CreateChildGroup());

			// update the group model bounds
			group.UpdateModelBounds();

			// apply styles to the group
			group.Style.FillStyle = new NColorFillStyle(color2);
			group.Style.StrokeStyle = new NStrokeStyle(color2);
			group.Style.TextStyle = new NTextStyle(new Font("Arial", 10), color2);

			// add the parent group to the active layer
			document.ActiveLayer.AddChild(group);
		}
				
		protected NGroup CreateChildGroup()
		{
			Color color1 = Color.FromArgb(25, 0, 0xbb, 0xbb);
			Color color2 = Color.FromArgb(150, 0, 204, 0);

			NGroup group = new NGroup();

			// create the group frame
			NRectangleF bounds = base.GetGridCell(0, 0, 1, 1);
			NRectangleShape frame = new NRectangleShape(bounds);
			frame.Protection = new NAbilities(AbilitiesMask.Select);
			frame.Style.FillStyle = new NColorFillStyle(color1);
			group.Shapes.AddChild(frame);
			
			// create the group shapes
			group.Shapes.AddChild(new NRectangleShape(base.GetGridCell(0, 0))); 
			group.Shapes.AddChild(new NEllipseShape(base.GetGridCell(0, 1)));
			group.Shapes.AddChild(new NTextShape("Child group", base.GetGridCell(1, 0, 0, 1)));

			// update the group model bounds
			group.UpdateModelBounds();

			// apply styles to the group
			group.Style.FillStyle = new NColorFillStyle(color2);
			group.Style.StrokeStyle = new NStrokeStyle(1, color2);
			group.Style.TextStyle = new NTextStyle(new Font("Arial", 10), color2);

			return group;
		}


		#endregion

		#region Event Handlers

		private void ungroupToLayerButton_Click(object sender, System.EventArgs e)
		{
			// create a new batch ungroup and check whether it can be executed
			NBatchUngroup batchUngroup = new NBatchUngroup(document, view.Selection.Nodes);
			if (batchUngroup.CanUngroup(document.ActiveLayer, false) == false)
				return;

			// ungroup the selected groups to the active layer
			NNodeList shapes; 
			NTransactionResult res = batchUngroup.Ungroup(document.ActiveLayer, false, out shapes);
			
			// single select the ungrouped shapes if the ungroup was successful
			if (res.Succeeded)
			{
				view.Selection.SingleSelect(shapes);
			}

			// ask the view to display any information about the transaction status (if it was not completed)
			view.ProcessTransactionResult(res); 
		}

		private void ungroupToParentGroupButton_Click(object sender, System.EventArgs e)
		{
			// get the group and its parent group
			NGroup group = (view.Selection.AnchorNode as NGroup);
			if (group == null)
				return;

			NGroup parentGroup = group.Group; 
			if (parentGroup == null)
				return;

			// create a new batch ungroup and check whether it can be executed
			NBatchUngroup batchUngroup = new NBatchUngroup(document, view.Selection.Nodes);
			if (batchUngroup.CanUngroup(parentGroup, false) == false)
				return;

			// ungroup the selected groups to the active layer
			NNodeList shapes; 
			NTransactionResult res = batchUngroup.Ungroup(parentGroup, false, out shapes);
			
			// single select the parent group if the ungroup was successful
			if (res.Succeeded)
			{
				view.Selection.SingleSelect(parentGroup);
			}

			// ask the view to display any information about the transaction status (if it was not completed)
			view.ProcessTransactionResult(res); 
		}

		private void groupButton_Click(object sender, System.EventArgs e)
		{
			// get the selected nodes
			NNodeList selectedNodes = view.Selection.Nodes;

			// determine whether they can be grouped
			NBatchGroup batchGroup = new NBatchGroup(document, selectedNodes);
			if (batchGroup.CanGroup(document.ActiveLayer, false) == false)
				return;

			// group them 
			NGroup group;
			NTransactionResult res = batchGroup.Group(document.ActiveLayer, false, out group);

			// single select the new group if the group was successful
			if (res.Succeeded)
			{
				view.Selection.SingleSelect(group);
			}

			// ask the view to display any information about the transaction status (if it was not completed)
			view.ProcessTransactionResult(res); 
		}

		
		private void protectFromUngroupCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused) 
				return;

			// get the selected group
			NGroup group = (view.Selection.AnchorNode as NGroup);
			if (group == null)
				return;

			// change the ungroup protection
			NAbilities protection = group.Protection; 
			protection.Ungroup = protectFromUngroupCheckBox.Checked;
			group.Protection = protection;

			// update form control
			UpdateControlsState();
		}

		private void protectFromGroupCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused) 
				return;

			// get the selected shape
			NShape shape = (view.Selection.AnchorNode as NShape);
			if (shape == null)
				return;

			// change the ungroup protection
			NAbilities protection = shape.Protection; 
			protection.Group = protectFromGroupCheckBox.Checked;
			shape.Protection = protection;

			// update form control
			UpdateControlsState();
		}

		
		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			UpdateControlsState();
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			UpdateControlsState();
		}


		#endregion

		#region Designer Fields

		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NGroupBox selectedGroupsActionsGroup;
		private Nevron.UI.WinForm.Controls.NButton ungroupToLayerButton;
		private Nevron.UI.WinForm.Controls.NButton ungroupToParentGroupButton;
		private Nevron.UI.WinForm.Controls.NButton groupButton;
		private Nevron.UI.WinForm.Controls.NCheckBox protectFromUngroupCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox protectFromGroupCheckBox;
		private Nevron.UI.WinForm.Controls.NGroupBox selectedShapesActionsGroup;

		#endregion
	}
}