using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NVisualTabNavigationForm.
	/// </summary>
	public class NVisualTabNavigationForm : NForm
	{
		#region Constructor

		public NVisualTabNavigationForm()
		{
			InitializeComponent();

            this.editorModeCombo.FillFromEnum(typeof(VisualTabEditorMode));
            this.editorModeCombo.SelectedItem = nDockManager1.VisualTabEditorMode;

			NDockingFrameworkCommand command = nDockManager1.Commander.GetCommandById(NDockingFrameworkCommands.VisualTabNavigation);

			if(command != null)
			{
				ArrayList shortcuts = command.Shortcuts;
				if(shortcuts.Count > 0)
				{
					shortcutEdit.SetShortcut((NShortcut)shortcuts[0]);
				}
			}

			nDockManager1.DocumentStyle.ImageList = imageList1;
			NDocumentManager docManager = nDockManager1.DocumentManager;

			docManager.Suspend();

			NUIDocument doc;
			int imageIndex = 0;

			for(int i = 0; i < 10; i++)
			{
				doc = new NUIDocument("Test Document " + i, imageIndex);
				docManager.AddDocument(doc);

				imageIndex++;
				if(imageIndex > 5)
				{
					imageIndex = 0;
				}
			}

			docManager.Resume();
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}

				if(nDockManager1 != null)
				{
					nDockManager1.Dispose();
					nDockManager1 = null;
				}
			}
			base.Dispose( disposing );
		}


		#endregion

		#region Event Handlers

		private void shortcutEdit_TextChanged(object sender, System.EventArgs e)
		{
			NDockingFrameworkCommand command = nDockManager1.Commander.GetCommandById(NDockingFrameworkCommands.VisualTabNavigation);
			if(command == null)
			{
				return;
			}

			command.Shortcuts.Clear();
			command.Shortcuts.Add(shortcutEdit.Shortcut);
		}
		private void editorModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nDockManager1.VisualTabEditorMode = (VisualTabEditorMode)editorModeCombo.SelectedItem;
        }


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Nevron.UI.WinForm.Docking.NDockZone nDockZone1 = new Nevron.UI.WinForm.Docking.NDockZone();
            Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone2 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
            Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone3 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NVisualTabNavigationForm));
            this.nDockManager1 = new Nevron.UI.WinForm.Docking.NDockManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nDockingPanel1 = new Nevron.UI.WinForm.Docking.NDockingPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.shortcutEdit = new Nevron.UI.WinForm.Controls.NShortcutTextBox();
            this.nDockingPanel2 = new Nevron.UI.WinForm.Docking.NDockingPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.nDockingPanel3 = new Nevron.UI.WinForm.Docking.NDockingPanel();
            this.nDockingPanel4 = new Nevron.UI.WinForm.Docking.NDockingPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.editorModeCombo = new Nevron.UI.WinForm.Controls.NComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).BeginInit();
            this.nDockingPanel1.SuspendLayout();
            this.nDockingPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nDockManager1
            // 
            this.nDockManager1.Form = this;
            this.nDockManager1.ImageList = this.imageList1;
            this.nDockManager1.RootContainerZIndex = 0;
            //  
            // Root Zone
            //  
            this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1);
            this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone3);
            this.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //  
            // nDockZone1
            //  
            nDockZone1.AddChild(this.nDockManager1.DocumentManager.DocumentViewHost);
            nDockZone1.AddChild(nDockZone2);
            nDockZone1.Name = "nDockZone1";
            nDockZone1.Orientation = System.Windows.Forms.Orientation.Vertical;
            nDockZone1.Index = 0;
            nDockZone1.SizeInfo.PrefferedSize = new System.Drawing.Size(573, 200);
            //  
            // nDockZone2
            //  
            nDockZone2.AddChild(this.nDockingPanel4);
            nDockZone2.AddChild(this.nDockingPanel2);
            nDockZone2.Name = "nDockZone2";
            nDockZone2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            nDockZone2.Index = 1;
            nDockZone2.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 199);
            //  
            // nDockZone3
            //  
            nDockZone3.AddChild(this.nDockingPanel1);
            nDockZone3.AddChild(this.nDockingPanel3);
            nDockZone3.Name = "nDockZone3";
            nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            nDockZone3.Index = 1;
            nDockZone3.SizeInfo.PrefferedSize = new System.Drawing.Size(241, 200);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // nDockingPanel1
            // 
            this.nDockingPanel1.Controls.Add(this.editorModeCombo);
            this.nDockingPanel1.Controls.Add(this.label3);
            this.nDockingPanel1.Controls.Add(this.label1);
            this.nDockingPanel1.Controls.Add(this.shortcutEdit);
            this.nDockingPanel1.Location = new System.Drawing.Point(1, 24);
            this.nDockingPanel1.Name = "nDockingPanel1";
            this.nDockingPanel1.Size = new System.Drawing.Size(235, 500);
            this.nDockingPanel1.SizeInfo.PrefferedSize = new System.Drawing.Size(241, 200);
            this.nDockingPanel1.TabIndex = 1;
            this.nDockingPanel1.TabInfo.ImageIndex = 5;
            this.nDockingPanel1.TabInfo.TooltipText = "";
            this.nDockingPanel1.Text = "Settings";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Visual Editor Shortcut:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // shortcutEdit
            // 
            this.shortcutEdit.Location = new System.Drawing.Point(16, 80);
            this.shortcutEdit.Name = "shortcutEdit";
            this.shortcutEdit.Size = new System.Drawing.Size(192, 18);
            this.shortcutEdit.TabIndex = 1;
            this.shortcutEdit.TextChanged += new System.EventHandler(this.shortcutEdit_TextChanged);
            // 
            // nDockingPanel2
            // 
            this.nDockingPanel2.Controls.Add(this.label2);
            this.nDockingPanel2.Location = new System.Drawing.Point(1, 24);
            this.nDockingPanel2.Name = "nDockingPanel2";
            this.nDockingPanel2.Size = new System.Drawing.Size(545, 527);
            this.nDockingPanel2.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 199);
            this.nDockingPanel2.TabIndex = 1;
            this.nDockingPanel2.TabInfo.ImageIndex = 4;
            this.nDockingPanel2.Text = "Testing Panel";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(56, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 72);
            this.label2.TabIndex = 0;
            this.label2.Text = "Press Control+Tab to trigger the visual tab editor.";
            // 
            // nDockingPanel3
            // 
            this.nDockingPanel3.Location = new System.Drawing.Point(1, 24);
            this.nDockingPanel3.Name = "nDockingPanel3";
            this.nDockingPanel3.Size = new System.Drawing.Size(235, 527);
            this.nDockingPanel3.TabIndex = 2;
            this.nDockingPanel3.TabInfo.ImageIndex = 3;
            this.nDockingPanel3.Text = "Testing Panel";
            // 
            // nDockingPanel4
            // 
            this.nDockingPanel4.Location = new System.Drawing.Point(1, 24);
            this.nDockingPanel4.Name = "nDockingPanel4";
            this.nDockingPanel4.Size = new System.Drawing.Size(530, 143);
            this.nDockingPanel4.TabIndex = 2;
            this.nDockingPanel4.TabInfo.ImageIndex = 0;
            this.nDockingPanel4.Text = "Testing Panel";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Visual Editor Mode:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editorModeCombo
            // 
            this.editorModeCombo.ListProperties.ColumnOnLeft = false;
            this.editorModeCombo.Location = new System.Drawing.Point(16, 31);
            this.editorModeCombo.Name = "editorModeCombo";
            this.editorModeCombo.Size = new System.Drawing.Size(192, 22);
            this.editorModeCombo.TabIndex = 4;
            this.editorModeCombo.Text = "nComboBox1";
            this.editorModeCombo.SelectedIndexChanged += new System.EventHandler(this.editorModeCombo_SelectedIndexChanged);
            // 
            // NVisualTabNavigationForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(773, 552);
            this.Name = "NVisualTabNavigationForm";
            this.Text = "Visual Tab Navigation Example";
            ((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).EndInit();
            this.nDockingPanel1.ResumeLayout(false);
            this.nDockingPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Docking.NDockManager nDockManager1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel2;
		private System.Windows.Forms.ImageList imageList1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel3;
        private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel4;
		private Nevron.UI.WinForm.Controls.NShortcutTextBox shortcutEdit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private NComboBox editorModeCombo;
        private Label label3;
		private System.ComponentModel.IContainer components;

		#endregion
	}
}
