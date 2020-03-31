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
	/// Summary description for NMdiMenuMergeForm.
	/// </summary>
	public class NMdiMenuMergeForm : System.Windows.Forms.Form
	{
		#region Constructor

		public NMdiMenuMergeForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_UpdateFormCaption.Checked = true;

			nCommandBarsManager1.Palette.Copy(NUIManager.Palette);
			nDockManager1.Palette.Copy(NUIManager.Palette);
			nDockManager1.DocumentStyle.DocumentViewStyle = DocumentViewStyle.MdiStandard;

			NUIDocument doc;

			for(int i = 1; i < 5; i++)
			{
				doc = new NUIDocument("Document " + i.ToString());
				doc.Client = NDockingPanelsExampleForm.GetTextBox();
				nDockManager1.DocumentManager.AddDocument(doc);
			}

			INUIDocumentHost host = nDockManager1.DocumentManager.Documents[3].Host as NMdiChild;
			if(host == null)
				return;

			host.Activate();

			NMdiChild child = host as NMdiChild;
			if(child != null)
			{
				child.WindowState = FormWindowState.Maximized;
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

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
		}


		#endregion

		#region Event Handlers

		private void nCommand2_Click(object sender, Nevron.UI.WinForm.Controls.CommandEventArgs e)
		{
			Close();
		}

		private void m_UpdateFormCaption_CheckedChanged(object sender, System.EventArgs e)
		{
			nMenuBar1.UpdateFormCaption = m_UpdateFormCaption.Checked;
		}

		private void m_AddDocumentButton_Click(object sender, System.EventArgs e)
		{
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
			this.nDockManager1 = new Nevron.UI.WinForm.Docking.NDockManager();
			this.nDockingPanel1 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.nDockingPanel2 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.m_UpdateFormCaption = new Nevron.UI.WinForm.Controls.NCheckBox();
			this.nCommandBarsManager1 = new Nevron.UI.WinForm.Controls.NCommandBarsManager(this.components);
			this.nMenuBar1 = new Nevron.UI.WinForm.Controls.NMenuBar();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).BeginInit();
			this.nDockingPanel1.SuspendLayout();
			this.nDockingPanel2.SuspendLayout();
			// 
			// nDockManager1
			// 
			this.nDockManager1.Form = this;
			this.nDockManager1.RootContainerZIndex = 0;
			//  
			// Root Zone
			//  
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0);
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1);
			this.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//  
			// nDockZone0
			//  
			nDockZone0.AddChild(this.nDockingPanel2);
			nDockZone0.Name = "nDockZone0";
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone0.Index = 0;
			nDockZone0.SizeInfo.PrefferedSize = new System.Drawing.Size(172, 200);
			//  
			// nDockZone1
			//  
			nDockZone1.AddChild(this.nDockManager1.DocumentManager.DocumentViewHost);
			nDockZone1.AddChild(nDockZone3);
			nDockZone1.Name = "nDockZone1";
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Vertical;
			nDockZone1.Index = 1;
			nDockZone1.SizeInfo.PrefferedSize = new System.Drawing.Size(666, 200);
			//  
			// nDockZone3
			//  
			nDockZone3.AddChild(this.nDockingPanel1);
			nDockZone3.Name = "nDockZone3";
			nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone3.Index = 1;
			nDockZone3.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 163);
			// 
			// nDockingPanel1
			// 
			this.nDockingPanel1.Controls.Add(this.textBox1);
			this.nDockingPanel1.Name = "nDockingPanel1";
			this.nDockingPanel1.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 163);
			this.nDockingPanel1.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Window;
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(648, 137);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// nDockingPanel2
			// 
			this.nDockingPanel2.Controls.Add(this.m_UpdateFormCaption);
			this.nDockingPanel2.Name = "nDockingPanel2";
			this.nDockingPanel2.SizeInfo.PrefferedSize = new System.Drawing.Size(172, 200);
			this.nDockingPanel2.TabIndex = 1;
			this.nDockingPanel2.Text = "Example";
			// 
			// m_UpdateFormCaption
			// 
			this.m_UpdateFormCaption.Location = new System.Drawing.Point(8, 8);
			this.m_UpdateFormCaption.Name = "m_UpdateFormCaption";
			this.m_UpdateFormCaption.Size = new System.Drawing.Size(144, 24);
			this.m_UpdateFormCaption.TabIndex = 0;
			this.m_UpdateFormCaption.Text = "&Update Form Caption";
			this.m_UpdateFormCaption.CheckedChanged += new System.EventHandler(this.m_UpdateFormCaption_CheckedChanged);
			// 
			// nCommandBarsManager1
			// 
			this.nCommandBarsManager1.AllowCustomize = false;
			this.nCommandBarsManager1.ParentControl = this;
			this.nCommandBarsManager1.Toolbars.Add(this.nMenuBar1);
			// 
			// nMenuBar1
			// 
			this.nMenuBar1.AllowDelete = false;
			this.nMenuBar1.AllowHide = false;
			this.nMenuBar1.AllowRename = false;
			this.nMenuBar1.AutoDropDownDelay = false;
			this.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent;
			this.nMenuBar1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand1});
			this.nMenuBar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.Text;
			this.nMenuBar1.DefaultLocation = new System.Drawing.Point(0, 0);
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
			// NMdiMenuMergeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(824, 454);
			this.Name = "NMdiMenuMergeForm";
			this.Text = "Mdi Menu Merge Example";
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).EndInit();
			this.nDockingPanel1.ResumeLayout(false);
			this.nDockingPanel2.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Docking.NDockManager nDockManager1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel2;
		private Nevron.UI.WinForm.Controls.NCommandBarsManager nCommandBarsManager1;
		private Nevron.UI.WinForm.Controls.NMenuBar nMenuBar1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private System.Windows.Forms.TextBox textBox1;
		private Nevron.UI.WinForm.Controls.NCheckBox m_UpdateFormCaption;
		private System.ComponentModel.IContainer components;

		#endregion
	}
}
