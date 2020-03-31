using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Nevron.GraphicsCore;
using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NSelectionUC.
	/// </summary>
	public class NSelectionUC : NDiagramExampleUC
	{
		#region Constructor

		public NSelectionUC(NMainForm form) : base(form)
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
			this.label1 = new System.Windows.Forms.Label();
			this.selectionAnchorCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.selectionModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.permissionsGroupBox = new Nevron.UI.WinForm.Controls.NGroupBox();
			this.deleteCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.copyCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.selectCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.permissionsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "Selection anchor:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// selectionAnchorCombo
			// 
			this.selectionAnchorCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.selectionAnchorCombo.Location = new System.Drawing.Point(120, 152);
			this.selectionAnchorCombo.Name = "selectionAnchorCombo";
			this.selectionAnchorCombo.Size = new System.Drawing.Size(120, 21);
			this.selectionAnchorCombo.TabIndex = 4;
			this.selectionAnchorCombo.SelectedIndexChanged += new System.EventHandler(this.selectionAnchorCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 118);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Selection mode:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// selectionModeCombo
			// 
			this.selectionModeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.selectionModeCombo.Location = new System.Drawing.Point(120, 120);
			this.selectionModeCombo.Name = "selectionModeCombo";
			this.selectionModeCombo.Size = new System.Drawing.Size(122, 21);
			this.selectionModeCombo.TabIndex = 2;
			this.selectionModeCombo.SelectedIndexChanged += new System.EventHandler(this.selectionModeCombo_SelectedIndexChanged);
			// 
			// permissionsGroupBox
			// 
			this.permissionsGroupBox.Controls.Add(this.deleteCheckBox);
			this.permissionsGroupBox.Controls.Add(this.copyCheckBox);
			this.permissionsGroupBox.Controls.Add(this.selectCheckBox);
			this.permissionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.permissionsGroupBox.ImageIndex = 0;
			this.permissionsGroupBox.Location = new System.Drawing.Point(8, 8);
			this.permissionsGroupBox.Name = "permissionsGroupBox";
			this.permissionsGroupBox.Size = new System.Drawing.Size(234, 104);
			this.permissionsGroupBox.TabIndex = 0;
			this.permissionsGroupBox.TabStop = false;
			this.permissionsGroupBox.Text = "Selected shape protection";
			// 
			// deleteCheckBox
			// 
			this.deleteCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.deleteCheckBox.Location = new System.Drawing.Point(8, 72);
			this.deleteCheckBox.Name = "deleteCheckBox";
			this.deleteCheckBox.Size = new System.Drawing.Size(218, 24);
			this.deleteCheckBox.TabIndex = 2;
			this.deleteCheckBox.Text = "From delete";
			this.deleteCheckBox.CheckStateChanged += new System.EventHandler(this.protectionCheckBox_CheckStateChanged);
			// 
			// copyCheckBox
			// 
			this.copyCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.copyCheckBox.Location = new System.Drawing.Point(8, 44);
			this.copyCheckBox.Name = "copyCheckBox";
			this.copyCheckBox.Size = new System.Drawing.Size(218, 24);
			this.copyCheckBox.TabIndex = 1;
			this.copyCheckBox.Text = "From copy";
			this.copyCheckBox.CheckStateChanged += new System.EventHandler(this.protectionCheckBox_CheckStateChanged);
			// 
			// selectCheckBox
			// 
			this.selectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.selectCheckBox.Location = new System.Drawing.Point(8, 16);
			this.selectCheckBox.Name = "selectCheckBox";
			this.selectCheckBox.Size = new System.Drawing.Size(218, 24);
			this.selectCheckBox.TabIndex = 0;
			this.selectCheckBox.Text = "From select";
			this.selectCheckBox.CheckStateChanged += new System.EventHandler(this.protectionCheckBox_CheckStateChanged);
			// 
			// NSelectionUC
			// 
			this.Controls.Add(this.permissionsGroupBox);
			this.Controls.Add(this.selectionModeCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.selectionAnchorCombo);
			this.Controls.Add(this.label1);
			this.DockPadding.All = 8;
			this.Name = "NSelectionUC";
			this.Size = new System.Drawing.Size(250, 600);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.selectionAnchorCombo, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.selectionModeCombo, 0);
			this.Controls.SetChildIndex(this.permissionsGroupBox, 0);
			this.permissionsGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();

			// init document
			document.BeginInit();
			CreateDefaultFlowDiagram();
			document.EndInit();

			// init form controls
			InitFormControls();

			// end view init
			view.EndInit();
		}

		protected override void ResetExample()
		{
			view.Reset();
			base.ResetExample();
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

			selectionAnchorCombo.ListProperties.ColumnOnLeft = false;
			selectionModeCombo.ListProperties.ColumnOnLeft = false;

			selectionAnchorCombo.FillFromEnum(typeof(SelectionAnchorMode));
			selectionAnchorCombo.SelectedItem = view.Selection.AnchorMode;

			selectionModeCombo.FillFromEnum(typeof(DiagramSelectionMode));
			selectionModeCombo.SelectedItem = view.Selection.Mode;

			ResumeEventsHandling();
		}

		private void UpdateControlsState()
		{
			if (view.Selection.NodesCount != 1)
			{
				permissionsGroupBox.Enabled = false;
				return;
			}

			permissionsGroupBox.Enabled = true;
		}

		private void UpdateFromSelectedNode()
		{
			// get the selected element
			NDiagramElement element = (view.Selection.AnchorNode as NDiagramElement);
			if (element == null)
				return;

			// update the protection checks
			NAbilities protection = element.Protection;

			copyCheckBox.Checked = protection.Copy;
			deleteCheckBox.Checked = protection.Delete;
			selectCheckBox.Checked = protection.Select;
		}

		#endregion

		#region Event Handlers

		private void selectionAnchorCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// change the view selection anchor mode
			view.Selection.AnchorMode = (SelectionAnchorMode)selectionAnchorCombo.SelectedIndex;
			view.Refresh();
		}

		private void selectionModeCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// change the view selection mode
			view.Selection.Mode = (DiagramSelectionMode)selectionModeCombo.SelectedIndex;
			view.Refresh();
		}

		private void protectionCheckBox_CheckStateChanged(object sender, EventArgs e)
		{
			if (EventsHandlingPaused)
				return;

			// get the selected element
			NDiagramElement element = (view.Selection.AnchorNode as NDiagramElement);
			if (element == null)
				return;

			PauseEventsHandling();

			// update the element protection
			NAbilities protection = element.Protection;

			protection.Copy = copyCheckBox.Checked;
			protection.Delete = deleteCheckBox.Checked;
			protection.Select = selectCheckBox.Checked;

			element.Protection = protection;

			document.SmartRefreshAllViews();
			ResumeEventsHandling();
		}


		private void EventSinkService_NodeSelected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;
			
			PauseEventsHandling();
			try
			{
				UpdateControlsState();
				UpdateFromSelectedNode();
			}
			finally
			{
				ResumeEventsHandling();
			}
		}

		private void EventSinkService_NodeDeselected(NNodeEventArgs args)
		{
			if (EventsHandlingPaused)
				return;
			
			PauseEventsHandling();
			try
			{
				UpdateControlsState();
				UpdateFromSelectedNode();
			}
			finally
			{
				ResumeEventsHandling();
			}
		}


		#endregion

		#region Designer Fields
	
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Nevron.UI.WinForm.Controls.NComboBox selectionAnchorCombo;
		private Nevron.UI.WinForm.Controls.NComboBox selectionModeCombo;
		private Nevron.UI.WinForm.Controls.NCheckBox copyCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox deleteCheckBox;
		private Nevron.UI.WinForm.Controls.NCheckBox selectCheckBox;
		private Nevron.UI.WinForm.Controls.NGroupBox permissionsGroupBox;

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
