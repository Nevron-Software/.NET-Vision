using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NTreeViewUC.
	/// </summary>
	public class NTreeViewUC : NExampleUserControl
	{
		#region Constructor

		public NTreeViewUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
			nTreeView1.LabelEdit = true;
		}


		#endregion

		#region Implementation

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		public override void Initialize()
		{
			base.Initialize ();

			nTreeView1.ImageList = MainForm.TestImages;
			TreeNode node1, node2;

			for(int i = 0; i < 20; i++)
			{
				node1 = new TreeNode("NTreeNode "+i.ToString());
				node1.ImageIndex = i;
				node1.SelectedImageIndex = i;
				for(int j = 0; j < 20; j++)
				{
					node2 = new TreeNode("Sub-NTreeNode "+j.ToString());
					node2.ImageIndex = j;
					node2.SelectedImageIndex = j;
					node1.Nodes.Add(node2);
				}
				nTreeView1.Nodes.Add(node1);
			}

			++m_iSuspendUpdate;

			m_LineColorButton.Color = nTreeView1.LineColor;

			--m_iSuspendUpdate;
		}
		

		#endregion

		#region Event Handlers

		private void m_CheckBoxesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nTreeView1.CheckBoxes = m_CheckBoxesCheck.Checked;
		}

		private void m_CustomDrawCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nTreeView1.CustomDraw = m_CustomDrawCheck.Checked;
		}

		private void m_BorderButton_Click(object sender, System.EventArgs e)
		{
			nTreeView1.Border.ShowEditor();
		}

		private void m_LineColorButton_ColorChanged(object sender, System.EventArgs e)
		{
			if(m_iSuspendUpdate != 0)
				return;

			nTreeView1.LineColor = m_LineColorButton.Color;
		}

		private void m_HideSelectionCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nTreeView1.HideSelection = m_HideSelectionCheck.Checked;
		}

		private void hotTrackCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nTreeView1.HotTracking = hotTrackCheck.Checked;
		}

		private void boldTextCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			if(boldTextCheck.Checked)
			{
				nTreeView1.Font = new Font(nTreeView1.Font, FontStyle.Bold);
			}
			else
			{
				nTreeView1.Font = new Font(nTreeView1.Font, FontStyle.Regular);
			}
		}


		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nTreeView1 = new Nevron.UI.WinForm.Controls.NTreeView();
			this.m_CheckBoxesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_CustomDrawCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_BorderButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_LineColorButton = new Nevron.UI.WinForm.Controls.NColorButton();
			this.label1 = new System.Windows.Forms.Label();
			this.m_HideSelectionCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.hotTrackCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.boldTextCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.SuspendLayout();
			// 
			// nTreeView1
			// 
			this.nTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.nTreeView1.ImageIndex = -1;
			this.nTreeView1.Location = new System.Drawing.Point(8, 8);
			this.nTreeView1.Name = "nTreeView1";
			this.nTreeView1.SelectedImageIndex = -1;
			this.nTreeView1.Size = new System.Drawing.Size(424, 216);
			this.nTreeView1.TabIndex = 0;
			// 
			// m_CheckBoxesCheck
			// 
			this.m_CheckBoxesCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_CheckBoxesCheck.ButtonProperties.BorderOffset = 2;
			this.m_CheckBoxesCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_CheckBoxesCheck.Location = new System.Drawing.Point(8, 232);
			this.m_CheckBoxesCheck.Name = "m_CheckBoxesCheck";
			this.m_CheckBoxesCheck.Size = new System.Drawing.Size(103, 24);
			this.m_CheckBoxesCheck.TabIndex = 5;
			this.m_CheckBoxesCheck.Text = "CheckBoxes";
			this.m_CheckBoxesCheck.CheckedChanged += new System.EventHandler(this.m_CheckBoxesCheck_CheckedChanged);
			// 
			// m_CustomDrawCheck
			// 
			this.m_CustomDrawCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_CustomDrawCheck.ButtonProperties.BorderOffset = 2;
			this.m_CustomDrawCheck.Checked = true;
			this.m_CustomDrawCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_CustomDrawCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_CustomDrawCheck.Location = new System.Drawing.Point(112, 232);
			this.m_CustomDrawCheck.Name = "m_CustomDrawCheck";
			this.m_CustomDrawCheck.Size = new System.Drawing.Size(103, 24);
			this.m_CustomDrawCheck.TabIndex = 6;
			this.m_CustomDrawCheck.Text = "Custom Draw";
			this.m_CustomDrawCheck.CheckedChanged += new System.EventHandler(this.m_CustomDrawCheck_CheckedChanged);
			// 
			// m_BorderButton
			// 
			this.m_BorderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_BorderButton.Location = new System.Drawing.Point(120, 264);
			this.m_BorderButton.Name = "m_BorderButton";
			this.m_BorderButton.Size = new System.Drawing.Size(88, 24);
			this.m_BorderButton.TabIndex = 24;
			this.m_BorderButton.Text = "Border...";
			this.m_BorderButton.Click += new System.EventHandler(this.m_BorderButton_Click);
			// 
			// m_LineColorButton
			// 
			this.m_LineColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_LineColorButton.ArrowClickOptions = false;
			this.m_LineColorButton.ArrowWidth = 14;
			this.m_LineColorButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_LineColorButton.Location = new System.Drawing.Point(120, 296);
			this.m_LineColorButton.Name = "m_LineColorButton";
			this.m_LineColorButton.Size = new System.Drawing.Size(88, 24);
			this.m_LineColorButton.TabIndex = 25;
			this.m_LineColorButton.ColorChanged += new System.EventHandler(this.m_LineColorButton_ColorChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(48, 296);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 26;
			this.label1.Text = "Line Color:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_HideSelectionCheck
			// 
			this.m_HideSelectionCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_HideSelectionCheck.ButtonProperties.BorderOffset = 2;
			this.m_HideSelectionCheck.Checked = true;
			this.m_HideSelectionCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_HideSelectionCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_HideSelectionCheck.Location = new System.Drawing.Point(216, 232);
			this.m_HideSelectionCheck.Name = "m_HideSelectionCheck";
			this.m_HideSelectionCheck.Size = new System.Drawing.Size(103, 24);
			this.m_HideSelectionCheck.TabIndex = 27;
			this.m_HideSelectionCheck.Text = "Hide Selection";
			this.m_HideSelectionCheck.CheckedChanged += new System.EventHandler(this.m_HideSelectionCheck_CheckedChanged);
			// 
			// hotTrackCheck
			// 
			this.hotTrackCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.hotTrackCheck.ButtonProperties.BorderOffset = 2;
			this.hotTrackCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.hotTrackCheck.Location = new System.Drawing.Point(320, 232);
			this.hotTrackCheck.Name = "hotTrackCheck";
			this.hotTrackCheck.Size = new System.Drawing.Size(103, 24);
			this.hotTrackCheck.TabIndex = 28;
			this.hotTrackCheck.Text = "Hot Track";
			this.hotTrackCheck.CheckedChanged += new System.EventHandler(this.hotTrackCheck_CheckedChanged);
			// 
			// boldTextCheck
			// 
			this.boldTextCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.boldTextCheck.ButtonProperties.BorderOffset = 2;
			this.boldTextCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.boldTextCheck.Location = new System.Drawing.Point(320, 264);
			this.boldTextCheck.Name = "boldTextCheck";
			this.boldTextCheck.Size = new System.Drawing.Size(103, 24);
			this.boldTextCheck.TabIndex = 29;
			this.boldTextCheck.Text = "Bold Text";
			this.boldTextCheck.CheckedChanged += new System.EventHandler(this.boldTextCheck_CheckedChanged);
			// 
			// NTreeViewUC
			// 
			this.Controls.Add(this.boldTextCheck);
			this.Controls.Add(this.hotTrackCheck);
			this.Controls.Add(this.m_HideSelectionCheck);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_LineColorButton);
			this.Controls.Add(this.m_BorderButton);
			this.Controls.Add(this.m_CustomDrawCheck);
			this.Controls.Add(this.m_CheckBoxesCheck);
			this.Controls.Add(this.nTreeView1);
			this.Name = "NTreeViewUC";
			this.Size = new System.Drawing.Size(440, 328);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields


		private System.ComponentModel.Container components = null;
		private Nevron.UI.WinForm.Controls.NButton m_BorderButton;
		private Nevron.UI.WinForm.Controls.NCheckBox m_CheckBoxesCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_CustomDrawCheck;
		private Nevron.UI.WinForm.Controls.NColorButton m_LineColorButton;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_HideSelectionCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox hotTrackCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox boldTextCheck;
		private Nevron.UI.WinForm.Controls.NTreeView nTreeView1;

		#endregion
	}
}
