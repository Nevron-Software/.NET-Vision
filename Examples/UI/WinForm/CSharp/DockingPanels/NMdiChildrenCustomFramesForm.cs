using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NMdiChildrenCustomFramesForm.
	/// </summary>
	public class NMdiChildrenCustomFramesForm : System.Windows.Forms.Form
	{
		#region Constructor

		public NMdiChildrenCustomFramesForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			NDocumentManager manager = nDockManager1.DocumentManager;

			for(int i = 1; i < 5; i++)
			{
				manager.AddDocument(new NUIDocument("Document " + i.ToString()));
			}
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
				}
			}
			base.Dispose( disposing );
		}

		/*protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			NUIManager.ApplyPalette();
		}*/


		#endregion

		#region Event Handlers

		private void nCommand2_Click(object sender, Nevron.UI.WinForm.Controls.CommandEventArgs e)
		{
			Close();
		}

		private void m_StickyChildrenCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nDockManager1.DocumentStyle.StickyChildren = m_StickyChildrenCheck.Checked;
		}
		private void m_StickToClientEdgesCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			nDockManager1.DocumentStyle.StickToMdiClientEdges = m_StickToClientEdgesCheck.Checked;
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
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone0 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			Nevron.UI.WinForm.Docking.NDockZone nDockZone1 = new Nevron.UI.WinForm.Docking.NDockZone();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone3 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			this.nDockingPanel1 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nDockManager1 = new Nevron.UI.WinForm.Docking.NDockManager();
			this.nDockingPanel2 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nDockingPanel3 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.m_StickToClientEdgesCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.m_StickyChildrenCheck = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCommandBarsManager1 = new Nevron.UI.WinForm.Controls.NCommandBarsManager(this.components);
			this.nMenuBar1 = new Nevron.UI.WinForm.Controls.NMenuBar();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).BeginInit();
			this.nDockingPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nCommandBarsManager1)).BeginInit();
			// 
			// nDockingPanel1
			// 
			this.nDockingPanel1.Name = "nDockingPanel1";
			this.nDockingPanel1.TabIndex = 1;
			// 
			// nDockManager1
			// 
			this.nDockManager1.DocumentStyle.DocumentViewStyle = Nevron.UI.WinForm.Docking.DocumentViewStyle.MdiStandard;
			this.nDockManager1.Form = this;
			this.nDockManager1.RootContainerZIndex = 0;
			this.nDockManager1.StickyOptions.StickyInflate = 21;
			//  
			// Root Zone
			//  
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0);
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1);
			this.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//  
			// nDockZone0
			//  
			nDockZone0.AddChild(this.nDockingPanel3);
			nDockZone0.Name = "nDockZone0";
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone0.Index = 0;
			//  
			// nDockZone1
			//  
			nDockZone1.AddChild(this.nDockManager1.DocumentManager.DocumentViewHost);
			nDockZone1.AddChild(nDockZone3);
			nDockZone1.Name = "nDockZone1";
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Vertical;
			nDockZone1.Index = 1;
			//  
			// nDockZone3
			//  
			nDockZone3.AddChild(this.nDockingPanel2);
			nDockZone3.Name = "nDockZone3";
			nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone3.Index = 1;
			// 
			// nDockingPanel2
			// 
			this.nDockingPanel2.Name = "nDockingPanel2";
			this.nDockingPanel2.TabIndex = 1;
			// 
			// nDockingPanel3
			// 
			this.nDockingPanel3.Controls.Add(this.m_StickToClientEdgesCheck);
			this.nDockingPanel3.Controls.Add(this.m_StickyChildrenCheck);
			this.nDockingPanel3.Name = "nDockingPanel3";
			this.nDockingPanel3.TabIndex = 1;
			// 
			// m_StickToClientEdgesCheck
			// 
			this.m_StickToClientEdgesCheck.Checked = true;
			this.m_StickToClientEdgesCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_StickToClientEdgesCheck.Location = new System.Drawing.Point(8, 40);
			this.m_StickToClientEdgesCheck.Name = "m_StickToClientEdgesCheck";
			this.m_StickToClientEdgesCheck.Size = new System.Drawing.Size(176, 24);
			this.m_StickToClientEdgesCheck.TabIndex = 1;
			this.m_StickToClientEdgesCheck.Text = "Stick To Client Edges";
			this.m_StickToClientEdgesCheck.CheckedChanged += new System.EventHandler(this.m_StickToClientEdgesCheck_CheckedChanged);
			// 
			// m_StickyChildrenCheck
			// 
			this.m_StickyChildrenCheck.Checked = true;
			this.m_StickyChildrenCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_StickyChildrenCheck.Location = new System.Drawing.Point(8, 16);
			this.m_StickyChildrenCheck.Name = "m_StickyChildrenCheck";
			this.m_StickyChildrenCheck.Size = new System.Drawing.Size(176, 24);
			this.m_StickyChildrenCheck.TabIndex = 0;
			this.m_StickyChildrenCheck.Text = "Sticky Children";
			this.m_StickyChildrenCheck.CheckedChanged += new System.EventHandler(this.m_StickyChildrenCheck_CheckedChanged);
			// 
			// nCommandBarsManager1
			// 
			this.nCommandBarsManager1.AllowCustomize = false;
			this.nCommandBarsManager1.ParentControl = this;
			this.nCommandBarsManager1.Toolbars.Add(this.nMenuBar1);
			// 
			// nMenuBar1
			// 
			this.nMenuBar1.AutoDropDownDelay = false;
			this.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent;
			this.nMenuBar1.CanFloat = false;
			this.nMenuBar1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand1});
			this.nMenuBar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.Text;
			this.nMenuBar1.DefaultLocation = new System.Drawing.Point(0, 0);
			this.nMenuBar1.HasGripper = false;
			this.nMenuBar1.HasPendantCommand = false;
			this.nMenuBar1.Name = "nMenuBar1";
			this.nMenuBar1.PrefferedRowIndex = 0;
			this.nMenuBar1.RowIndex = 0;
			this.nMenuBar1.ShowTooltips = false;
			this.nMenuBar1.Text = "Menu Bar";
			// 
			// nCommand1
			// 
			this.nCommand1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand2});
			this.nCommand1.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
			this.nCommand1.Properties.Text = "&File";
			// 
			// nCommand2
			// 
			this.nCommand2.Properties.Text = "E&xit";
			this.nCommand2.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.nCommand2_Click);
			// 
			// NMdiChildrenCustomFramesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(840, 566);
			this.Name = "NMdiChildrenCustomFramesForm";
			this.Text = "Mdi Children - Custom Frames Example";
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).EndInit();
			this.nDockingPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nCommandBarsManager1)).EndInit();

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel1;
		private Nevron.UI.WinForm.Docking.NDockManager nDockManager1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel2;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel3;
		private Nevron.UI.WinForm.Controls.NCommandBarsManager nCommandBarsManager1;
		private Nevron.UI.WinForm.Controls.NMenuBar nMenuBar1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Controls.NCheckBox m_StickyChildrenCheck;
		private Nevron.UI.WinForm.Controls.NCheckBox m_StickToClientEdgesCheck;
		private System.ComponentModel.IContainer components;

		#endregion
	}
}
