using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

using Nevron.Editors;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NGroupEmptyBehaviourUC.
	/// </summary>
	public class NGroupEmptyBehaviourUC : NDiagramExampleUC
	{
		#region Constructor

		public NGroupEmptyBehaviourUC(NMainForm form) : base(form)
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
			this.autoDestroyCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.canBeEmptyCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.groupPropertiesGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupPropertiesGroup
			// 
			this.groupPropertiesGroup.Controls.Add(this.autoDestroyCheckBox);
			this.groupPropertiesGroup.Controls.Add(this.canBeEmptyCheckBox);
			this.groupPropertiesGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupPropertiesGroup.Enabled = false;
			this.groupPropertiesGroup.ImageIndex = 0;
			this.groupPropertiesGroup.Location = new System.Drawing.Point(0, 0);
			this.groupPropertiesGroup.Name = "groupPropertiesGroup";
			this.groupPropertiesGroup.Size = new System.Drawing.Size(250, 72);
			this.groupPropertiesGroup.TabIndex = 31;
			this.groupPropertiesGroup.TabStop = false;
			this.groupPropertiesGroup.Text = "Selected group properties";
			// 
			// autoDestroyCheckBox
			// 
			this.autoDestroyCheckBox.Location = new System.Drawing.Point(8, 16);
			this.autoDestroyCheckBox.Name = "autoDestroyCheckBox";
			this.autoDestroyCheckBox.Size = new System.Drawing.Size(136, 24);
			this.autoDestroyCheckBox.TabIndex = 28;
			this.autoDestroyCheckBox.Text = "Auto destroy if empty";
			this.autoDestroyCheckBox.CheckedChanged += new System.EventHandler(this.autoDestroyCheckBox_CheckedChanged);
			// 
			// canBeEmptyCheckBox
			// 
			this.canBeEmptyCheckBox.Location = new System.Drawing.Point(8, 40);
			this.canBeEmptyCheckBox.Name = "canBeEmptyCheckBox";
			this.canBeEmptyCheckBox.Size = new System.Drawing.Size(136, 24);
			this.canBeEmptyCheckBox.TabIndex = 29;
			this.canBeEmptyCheckBox.Text = "Can be empty";
			this.canBeEmptyCheckBox.CheckedChanged += new System.EventHandler(this.canBeEmptyCheckBox_CheckedChanged);
			// 
			// NGroupEmptyBehaviourUC
			// 
			this.Controls.Add(this.groupPropertiesGroup);
			this.Name = "NGroupEmptyBehaviourUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.groupPropertiesGroup, 0);
			this.groupPropertiesGroup.ResumeLayout(false);
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

		private void InitDocument()
		{
			// change the default document style
			document.Style.FillStyle = new NColorFillStyle(Color.FromArgb(50, 0, 0xaa, 0xaa));
			document.Style.StrokeStyle = new NStrokeStyle(1, Color.FromArgb(0, 0xaa, 0xaa));

			// create the group
			NGroup group = new NGroup();

			// create ellipse1
			NEllipseShape ellipse1 = new NEllipseShape(0, 0, 100, 100);
			ellipse1.Text = "1";
			group.Shapes.AddChild(ellipse1); 
			
			// create ellipse2
			NEllipseShape ellipse2 = new NEllipseShape(150, 0, 100, 100);
			ellipse2.Text = "2";
			group.Shapes.AddChild(ellipse2);
			
			// create ellipse3
			NEllipseShape ellipse3 = new NEllipseShape(0, 150, 100, 100);
			ellipse3.Text = "3";
			group.Shapes.AddChild(ellipse3);
		
			// update the model bounds of the group
			group.UpdateModelBounds();

			// translate the group 
			group.Translate(100, 100);

			// add the group to the active layer
			document.ActiveLayer.AddChild(group);
		}
		
		private void UpdateControlsState()
		{
			if (view.Selection.NodesCount != 1)
			{
				groupPropertiesGroup.Enabled = false;
				return;
			}
			
			NGroup group = (view.Selection.AnchorNode as NGroup);
			if (group == null)
			{
				groupPropertiesGroup.Enabled = false;
				return;
			}

			groupPropertiesGroup.Enabled = true;

			// update the form controls from the selected group
			canBeEmptyCheckBox.Checked = group.CanBeEmpty;
			autoDestroyCheckBox.Checked = group.AutoDestroy;
		}
		

		#endregion

		#region Event Handlers

		private void autoDestroyCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			PauseEventsHandling();
			
			// update the selected group AutoDestroy property
			NGroup group = (view.Selection.AnchorNode as NGroup);
			if (group != null && group.Shapes.ChildrenCount(null) != 0)
			{
				group.AutoDestroy = autoDestroyCheckBox.Checked;
			}
			
			ResumeEventsHandling();
		}

		private void canBeEmptyCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (EventsHandlingPaused)
				return;
			
			PauseEventsHandling();

			// update the selected group CanBeEmpty property
			NGroup group = (view.Selection.AnchorNode as NGroup);
			if (group != null && group.Shapes.ChildrenCount(null) != 0)
			{
				group.CanBeEmpty = canBeEmptyCheckBox.Checked;
			}

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
		private Nevron.UI.WinForm.Controls.NCheckBox autoDestroyCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox canBeEmptyCheckBox;

		#endregion
	}
}