using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Dom;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NEventLogUC.
	/// </summary>
	public class NEventLogUC : System.Windows.Forms.UserControl
	{
		#region Constructors
		public NEventLogUC()
		{
			InitializeComponent();
		}
		#endregion

		#region Component Overrides
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.clearLogButton = new Nevron.UI.WinForm.Controls.NButton();
			this.label3 = new System.Windows.Forms.Label();
			this.eventsList = new Nevron.UI.WinForm.Controls.NListBox();
			this.trackDesignerEventsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.trackDocumentEventsCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// clearLogButton
			// 
			this.clearLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.clearLogButton.Location = new System.Drawing.Point(160, 8);
			this.clearLogButton.Name = "clearLogButton";
			this.clearLogButton.Size = new System.Drawing.Size(80, 23);
			this.clearLogButton.TabIndex = 10;
			this.clearLogButton.Text = "Clear Log";
			this.clearLogButton.Click += new System.EventHandler(this.clearLogButton_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.TabIndex = 9;
			this.label3.Text = "Events:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// eventsList
			// 
			this.eventsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.eventsList.ColumnOnLeft = false;
			this.eventsList.Location = new System.Drawing.Point(8, 40);
			this.eventsList.Name = "eventsList";
			this.eventsList.Size = new System.Drawing.Size(232, 364);
			this.eventsList.TabIndex = 8;
			// 
			// trackDesignerEventsCheckBox
			// 
			this.trackDesignerEventsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.trackDesignerEventsCheckBox.Location = new System.Drawing.Point(8, 410);
			this.trackDesignerEventsCheckBox.Name = "trackDesignerEventsCheckBox";
			this.trackDesignerEventsCheckBox.Size = new System.Drawing.Size(136, 24);
			this.trackDesignerEventsCheckBox.TabIndex = 11;
			this.trackDesignerEventsCheckBox.Text = "Track designer events";
			this.trackDesignerEventsCheckBox.CheckedChanged += new System.EventHandler(this.trackDesignerEventsCheckBox_CheckedChanged);
			// 
			// trackDocumentEventsCheckBox
			// 
			this.trackDocumentEventsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.trackDocumentEventsCheckBox.Location = new System.Drawing.Point(8, 434);
			this.trackDocumentEventsCheckBox.Name = "trackDocumentEventsCheckBox";
			this.trackDocumentEventsCheckBox.Size = new System.Drawing.Size(136, 24);
			this.trackDocumentEventsCheckBox.TabIndex = 11;
			this.trackDocumentEventsCheckBox.Text = "Track document events";
			this.trackDocumentEventsCheckBox.CheckedChanged += new System.EventHandler(this.trackDocumentEventsCheckBox_CheckedChanged);
			// 
			// NEventLogUC
			// 
			this.Controls.Add(this.trackDesignerEventsCheckBox);
			this.Controls.Add(this.clearLogButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.eventsList);
			this.Controls.Add(this.trackDocumentEventsCheckBox);
			this.Name = "NEventLogUC";
			this.Size = new System.Drawing.Size(248, 464);
			this.ResumeLayout(false);

		}
		#endregion

		#region Operations

		public void AttachToView()
		{
			if (Form == null || Form.View == null)
				return;

			Form.View.EventSinkService.ToolsChanged += new EventHandler(DesignerEventSinkService_ControllerToolsCollectionChanged);
			Form.View.EventSinkService.NodeAttributeChanged += new NodeAttributeEventHandler(DesignerEventSinkService_NodeAttributeChanged);
			Form.View.EventSinkService.NodeAttributePropertyChanged += new NodeAttributePropertyEventHandler(DesignerEventSinkService_NodeAttributePropertyChanged);
			Form.View.EventSinkService.NodeAttributePropertyChanging += new NodeAttributePropertyCancelEventHandler(DesignerEventSinkService_NodeAttributePropertyChanging);
			Form.View.EventSinkService.NodeBoundsChanged += new NodeEventHandler(DesignerEventSinkService_NodeBoundsChanged);
			Form.View.EventSinkService.NodeBoundsChanging += new NodeBoundsCancelEventHandler(DesignerEventSinkService_NodeBoundsChanging);
			Form.View.EventSinkService.NodeDeselected += new NodeEventHandler(DesignerEventSinkService_NodeDeselected);
			Form.View.EventSinkService.NodeDeselecting += new NodeCancelEventHandler(DesignerEventSinkService_NodeDeselecting);
			Form.View.EventSinkService.NodeInserted += new ChildNodeEventHandler(DesignerEventSinkService_NodeInserted);
			Form.View.EventSinkService.NodePropertyChanged += new NodePropertyEventHandler(DesignerEventSinkService_NodePropertyChanged);
			Form.View.EventSinkService.NodePropertyChanging += new NodePropertyCancelEventHandler(DesignerEventSinkService_NodePropertyChanging);
			Form.View.EventSinkService.NodeRemoved += new ChildNodeEventHandler(DesignerEventSinkService_NodeRemoved);
			Form.View.EventSinkService.NodeSelected += new NodeEventHandler(DesignerEventSinkService_NodeSelected);
			Form.View.EventSinkService.NodeSelecting += new NodeCancelEventHandler(DesignerEventSinkService_NodeSelecting);
			Form.View.EventSinkService.NodeTransformChanged += new NodeEventHandler(DesignerEventSinkService_NodeTransformChanged);
			Form.View.EventSinkService.NodeTransformChanging += new NodeTransformCancelEventHandler(DesignerEventSinkService_NodeTransformChanging);
			Form.View.EventSinkService.ToolAborted += new EventHandler(DesignerEventSinkService_ToolAborted);
			Form.View.EventSinkService.ToolActivated += new EventHandler(DesignerEventSinkService_ToolActivated);
			Form.View.EventSinkService.ToolDeactivated += new EventHandler(DesignerEventSinkService_ToolDeactivated);
			Form.View.EventSinkService.ToolDisabled += new EventHandler(DesignerEventSinkService_ToolDisabled);
			Form.View.EventSinkService.ToolEnabled += new EventHandler(DesignerEventSinkService_ToolEnabled);
			Form.View.EventSinkService.TransformationsChanged += new EventHandler(DesignerEventSinkService_TransformationsChanged);
		}

		public void DetachFromView()
		{
			if (Form == null || Form.View == null)
				return;

			Form.View.EventSinkService.ToolsChanged -= new EventHandler(DesignerEventSinkService_ControllerToolsCollectionChanged);
			Form.View.EventSinkService.NodeAttributeChanged -= new NodeAttributeEventHandler(DesignerEventSinkService_NodeAttributeChanged);
			Form.View.EventSinkService.NodeAttributePropertyChanged -= new NodeAttributePropertyEventHandler(DesignerEventSinkService_NodeAttributePropertyChanged);
			Form.View.EventSinkService.NodeAttributePropertyChanging -= new NodeAttributePropertyCancelEventHandler(DesignerEventSinkService_NodeAttributePropertyChanging);
			Form.View.EventSinkService.NodeBoundsChanged -= new NodeEventHandler(DesignerEventSinkService_NodeBoundsChanged);
			Form.View.EventSinkService.NodeBoundsChanging -= new NodeBoundsCancelEventHandler(DesignerEventSinkService_NodeBoundsChanging);
			Form.View.EventSinkService.NodeDeselected -= new NodeEventHandler(DesignerEventSinkService_NodeDeselected);
			Form.View.EventSinkService.NodeDeselecting -= new NodeCancelEventHandler(DesignerEventSinkService_NodeDeselecting);
			Form.View.EventSinkService.NodeInserted -= new ChildNodeEventHandler(DesignerEventSinkService_NodeInserted);
			Form.View.EventSinkService.NodePropertyChanged -= new NodePropertyEventHandler(DesignerEventSinkService_NodePropertyChanged);
			Form.View.EventSinkService.NodePropertyChanging -= new NodePropertyCancelEventHandler(DesignerEventSinkService_NodePropertyChanging);
			Form.View.EventSinkService.NodeRemoved -= new ChildNodeEventHandler(DesignerEventSinkService_NodeRemoved);
			Form.View.EventSinkService.NodeSelected -= new NodeEventHandler(DesignerEventSinkService_NodeSelected);
			Form.View.EventSinkService.NodeSelecting -= new NodeCancelEventHandler(DesignerEventSinkService_NodeSelecting);
			Form.View.EventSinkService.NodeTransformChanged -= new NodeEventHandler(DesignerEventSinkService_NodeTransformChanged);
			Form.View.EventSinkService.NodeTransformChanging -= new NodeTransformCancelEventHandler(DesignerEventSinkService_NodeTransformChanging);
			Form.View.EventSinkService.ToolAborted -= new EventHandler(DesignerEventSinkService_ToolAborted);
			Form.View.EventSinkService.ToolActivated -= new EventHandler(DesignerEventSinkService_ToolActivated);
			Form.View.EventSinkService.ToolDeactivated -= new EventHandler(DesignerEventSinkService_ToolDeactivated);
			Form.View.EventSinkService.ToolDisabled -= new EventHandler(DesignerEventSinkService_ToolDisabled);
			Form.View.EventSinkService.ToolEnabled -= new EventHandler(DesignerEventSinkService_ToolEnabled);
			Form.View.EventSinkService.TransformationsChanged -= new EventHandler(DesignerEventSinkService_TransformationsChanged);
		}


		public void AttachToDocument()
		{
			if (Form == null || Form.Document == null)
				return;

			Form.Document.EventSinkService.Connected += new ConnectionEventHandler(EventSinkService_Connected);
			Form.Document.EventSinkService.Connecting += new ConnectionCancelEventHandler(EventSinkService_Connecting);
			Form.Document.EventSinkService.Disconnected += new ConnectionEventHandler(EventSinkService_Disconnected);
			Form.Document.EventSinkService.Disconnecting += new ConnectionCancelEventHandler(EventSinkService_Disconnecting);
			Form.Document.EventSinkService.NodeAttributeChanged += new NodeAttributeEventHandler(EventSinkService_NodeAttributeChanged);
			Form.Document.EventSinkService.NodeAttributePropertyChanged += new NodeAttributePropertyEventHandler(EventSinkService_NodeAttributePropertyChanged);
			Form.Document.EventSinkService.NodeAttributePropertyChanging += new NodeAttributePropertyCancelEventHandler(EventSinkService_NodeAttributePropertyChanging);
			Form.Document.EventSinkService.NodeBoundsChanged += new NodeEventHandler(EventSinkService_NodeBoundsChanged);
			Form.Document.EventSinkService.NodeBoundsChanging += new NodeBoundsCancelEventHandler(EventSinkService_NodeBoundsChanging);
			Form.Document.EventSinkService.NodeInserted += new ChildNodeEventHandler(EventSinkService_NodeInserted);
			Form.Document.EventSinkService.NodePropertyChanged += new NodePropertyEventHandler(EventSinkService_NodePropertyChanged);
			Form.Document.EventSinkService.NodePropertyChanging += new NodePropertyCancelEventHandler(EventSinkService_NodePropertyChanging);
			Form.Document.EventSinkService.NodeRemoved += new ChildNodeEventHandler(EventSinkService_NodeRemoved);
			Form.Document.EventSinkService.NodeTransformChanged += new NodeEventHandler(EventSinkService_NodeTransformChanged);
			Form.Document.EventSinkService.NodeTransformChanging += new NodeTransformCancelEventHandler(EventSinkService_NodeTransformChanging);
		}
		
		public void DetachFromDocument()
		{
			if (Form == null || Form.Document == null)
				return;

			Form.Document.EventSinkService.Connected -= new ConnectionEventHandler(EventSinkService_Connected);
			Form.Document.EventSinkService.Connecting -= new ConnectionCancelEventHandler(EventSinkService_Connecting);
			Form.Document.EventSinkService.Disconnected -= new ConnectionEventHandler(EventSinkService_Disconnected);
			Form.Document.EventSinkService.Disconnecting -= new ConnectionCancelEventHandler(EventSinkService_Disconnecting);
			Form.Document.EventSinkService.NodeAttributeChanged -= new NodeAttributeEventHandler(EventSinkService_NodeAttributeChanged);
			Form.Document.EventSinkService.NodeAttributePropertyChanged -= new NodeAttributePropertyEventHandler(EventSinkService_NodeAttributePropertyChanged);
			Form.Document.EventSinkService.NodeAttributePropertyChanging -= new NodeAttributePropertyCancelEventHandler(EventSinkService_NodeAttributePropertyChanging);
			Form.Document.EventSinkService.NodeBoundsChanged -= new NodeEventHandler(EventSinkService_NodeBoundsChanged);
			Form.Document.EventSinkService.NodeBoundsChanging -= new NodeBoundsCancelEventHandler(EventSinkService_NodeBoundsChanging);
			Form.Document.EventSinkService.NodeInserted -= new ChildNodeEventHandler(EventSinkService_NodeInserted);
			Form.Document.EventSinkService.NodePropertyChanged -= new NodePropertyEventHandler(EventSinkService_NodePropertyChanged);
			Form.Document.EventSinkService.NodePropertyChanging -= new NodePropertyCancelEventHandler(EventSinkService_NodePropertyChanging);
			Form.Document.EventSinkService.NodeRemoved -= new ChildNodeEventHandler(EventSinkService_NodeRemoved);
			Form.Document.EventSinkService.NodeTransformChanged -= new NodeEventHandler(EventSinkService_NodeTransformChanged);
			Form.Document.EventSinkService.NodeTransformChanging -= new NodeTransformCancelEventHandler(EventSinkService_NodeTransformChanging);
		}


		#endregion

		#region Implementation

		private void UpdateControlsState()
		{
			if (Form == null)
			{
				trackDocumentEventsCheckBox.Enabled = false;
				trackDesignerEventsCheckBox.Enabled = false;
				return;
			}

			trackDocumentEventsCheckBox.Enabled = true;
			trackDesignerEventsCheckBox.Enabled = true;
		}

		private void LogEvent(string eventText)
		{
			eventsList.Items.Add(eventText);
			eventsList.SelectedIndex = this.eventsList.Items.Count - 1;
		}
		#endregion
		
		#region Form Event Handlers
		private void trackDesignerEventsCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (trackDesignerEventsCheckBox.Checked)
			{
				AttachToView();
				return;
			}

			DetachFromView();
		}
		
		private void trackDocumentEventsCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if (trackDocumentEventsCheckBox.Checked)
			{
				AttachToDocument();
				return;
			}

			DetachFromDocument();
		}

		private void clearLogButton_Click(object sender, System.EventArgs e)
		{
			eventsList.BeginUpdate();
			eventsList.Items.Clear();
			eventsList.EndUpdate();
		}
		#endregion

		#region DesignerEventSinkService Event Handlers
		private void DesignerEventSinkService_ControllerToolsCollectionChanged(object sender, EventArgs e)
		{
			LogEvent(
				"Designer: Controller Tools Collection Changed"
				);
		}

		private void DesignerEventSinkService_NodeAttributeChanged(NNodeAttributeEventArgs args)
		{
			LogEvent(
				"Designer: Node Attribute Changed"
				);
		}

		private void DesignerEventSinkService_NodeAttributePropertyChanged(NNodeAttributePropertyEventArgs args)
		{
			LogEvent(
				"Designer: Node Attribute Property Changed"
				);
		}

		private void DesignerEventSinkService_NodeAttributePropertyChanging(NNodeAttributePropertyCancelEventArgs args)
		{
			LogEvent(
				"Designer: Node Attribute Property Changing"
				);
		}

		private void DesignerEventSinkService_NodeBoundsChanged(NNodeEventArgs args)
		{
//			if (! m_Form.View.Selection.Nodes.Contains(args.Node))
//				return;

			LogEvent(
				"Designer: Node Bounds Changed"
				);
		}

		private void DesignerEventSinkService_NodeBoundsChanging(NNodeBoundsCancelEventArgs args)
		{
			LogEvent(
				"Designer: Node Bounds Changing"
				);
		}

		private void DesignerEventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			LogEvent(
				"Designer: Node Deselected"
				);
		}

		private void DesignerEventSinkService_NodeDeselecting(NNodeCancelEventArgs args)
		{
			LogEvent(
				"Designer: Node Deselecting"
				);
		}

		private void DesignerEventSinkService_NodeInserted(NChildNodeEventArgs args)
		{
			LogEvent(
				"Designer: Node Inserted"
				);
		}

		private void DesignerEventSinkService_NodePointsChanged(NNodeEventArgs args)
		{
			LogEvent(
				"Designer: Node Points Changed"
				);
		}

		private void DesignerEventSinkService_NodePropertyChanged(NNodePropertyEventArgs args)
		{
			LogEvent(
				"Designer: Node Property Changed"
				);
		}

		private void DesignerEventSinkService_NodePropertyChanging(NNodePropertyCancelEventArgs args)
		{
			LogEvent(
				"Designer: Node Property Changing"
				);
		}

		private void DesignerEventSinkService_NodeRemoved(NChildNodeEventArgs args)
		{
			LogEvent(
				"Designer: Node Removed"
				);
		}

		private void DesignerEventSinkService_NodeSelected(NNodeEventArgs args)
		{
			LogEvent(
				"Designer: Node Selected"
				);
		}

		private void DesignerEventSinkService_NodeSelecting(NNodeCancelEventArgs args)
		{
			LogEvent(
				"Designer: Node Selecting"
				);
		}

		private void DesignerEventSinkService_NodeTransformChanged(NNodeEventArgs args)
		{
			LogEvent(
				"Designer: Node Transform Changed"
				);
		}

		private void DesignerEventSinkService_NodeTransformChanging(NNodeTransformCancelEventArgs args)
		{
			LogEvent(
				"Designer: Node Transform Changing"
				);
		}

		private void DesignerEventSinkService_ToolAborted(object sender, EventArgs e)
		{
			LogEvent(
				"Designer: Tool Aborted"
				);
		}

		private void DesignerEventSinkService_ToolActivated(object sender, EventArgs e)
		{
			LogEvent(
				"Designer: Tool Activated"
				);
		}

		private void DesignerEventSinkService_ToolDeactivated(object sender, EventArgs e)
		{
			LogEvent(
				"Designer: Tool Deactivated"
				);
		}

		private void DesignerEventSinkService_ToolDisabled(object sender, EventArgs e)
		{
			LogEvent(
				"Designer: Tool Disabled"
				);
		}

		private void DesignerEventSinkService_ToolEnabled(object sender, EventArgs e)
		{
			LogEvent(
				"Designer: Tool Enabled"
				);
		}

		private void DesignerEventSinkService_TransformationsChanged(object sender, EventArgs e)
		{
			LogEvent(
				"Designer: World Transformations Changed"
				);
		}
		#endregion

		#region EventSinkService Event Handlers
		private void EventSinkService_Connected(NConnectionEventArgs args)
		{
			LogEvent(
				"Document: Connected"
				);
		}

		private void EventSinkService_Connecting(NConnectionCancelEventArgs args)
		{
			LogEvent(
				"Document: Connecting"
				);
		}

		private void EventSinkService_Disconnected(NConnectionEventArgs args)
		{
			LogEvent(
				"Document: Disconnected"
				);
		}

		private void EventSinkService_Disconnecting(NConnectionCancelEventArgs args)
		{
			LogEvent(
				"Document: Disconnecting"
				);
		}

		private void EventSinkService_NodeAttributeChanged(NNodeAttributeEventArgs args)
		{
			LogEvent(
				"Document: Node Attribute Changed"
				);
		}

		private void EventSinkService_NodeAttributePropertyChanged(NNodeAttributePropertyEventArgs args)
		{
			LogEvent(
				"Document: Node Attribute Property Changed"
				);
		}

		private void EventSinkService_NodeAttributePropertyChanging(NNodeAttributePropertyCancelEventArgs args)
		{
			LogEvent(
				"Document: Node Attribute Property Changing"
				);
		}

		private void EventSinkService_NodeBoundsChanged(NNodeEventArgs args)
		{
			LogEvent(
				"Document: Node Bounds Changed"
				);
		}

		private void EventSinkService_NodeBoundsChanging(NNodeBoundsCancelEventArgs args)
		{
			LogEvent(
				"Document: Node Bounds Changing"
				);
		}

		private void EventSinkService_NodeInserted(NChildNodeEventArgs args)
		{
			LogEvent(
				"Document: Node Inserted"
				);
		}

		private void EventSinkService_NodePropertyChanged(NNodePropertyEventArgs args)
		{
			LogEvent(
				"Document: Node Property Changed"
				);
		}

		private void EventSinkService_NodePropertyChanging(NNodePropertyCancelEventArgs args)
		{
			LogEvent(
				"Document: Node Property Changing"
				);
		}

		private void EventSinkService_NodeRemoved(NChildNodeEventArgs args)
		{
			LogEvent(
				"Document: Node Removed"
				);
		}

		private void EventSinkService_NodeTransformChanged(NNodeEventArgs args)
		{
			LogEvent(
				"Document: Node Transform Changed"
				);
		}

		private void EventSinkService_NodeTransformChanging(NNodeTransformCancelEventArgs args)
		{
			LogEvent(
				"Document: Node Transform Changing"
				);
		}
		#endregion

		#region Designer Fields
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label3;
		private Nevron.UI.WinForm.Controls.NButton clearLogButton;
		private Nevron.UI.WinForm.Controls.NListBox eventsList;
		private Nevron.UI.WinForm.Controls.NCheckBox trackDesignerEventsCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox trackDocumentEventsCheckBox;
		#endregion

		#region Properties
		[Browsable(false)]
		public NMainForm Form
		{
			get { return form; }
			set
			{
				form = value;
				UpdateControlsState();
			}
		}
		#endregion

		#region Fields
		private NMainForm form = null;
		#endregion
	}
}