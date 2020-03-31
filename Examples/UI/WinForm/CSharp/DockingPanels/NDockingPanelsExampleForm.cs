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
	/// Summary description for NDockingPanelsExampleForm.
	/// </summary>
	public class NDockingPanelsExampleForm : NForm
	{
		#region Constructor

		public NDockingPanelsExampleForm()
		{
			m_iLockUpdate++;

			InitializeComponent();

			m_DockManager = new NDockManager();
            m_DockManager.DisposePanelsOnClose = false;
			m_DockManager.Palette.Copy(NUIManager.Palette);
			m_DockManager.Form = this;
			m_Container = m_DockManager.RootContainer;
			m_DockManager.ImageList = MainForm.DockingImages;

			nCommandBarsManager1.ImageList = MainForm.DockingImages;
			nCommandBarsManager1.AllowCustomize = false;
			nMenuBar1.HasGripper = false;
			nCommand2.Properties.ID = -5;

			InitPanels();
			InitDocumentView();

			m_Container.BringToFront();

			m_ClickEH = new CommandEventHandler(OnPanelCommandClicked);

			SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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

				m_DockManager.Dispose();
			}
			base.Dispose( disposing );
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			NPalette pall = NUIManager.Palette;
			nCommandBarsManager1.Palette.Copy(pall);
			ApplyPalette(pall);

			InitCommandBars();

			m_iLockUpdate--;
		}


		#endregion

		#region Overridables

		protected virtual void InitCommandBars()
		{
			NMenuBar menu = nCommandBarsManager1.Toolbars.GetMenu();
			menu.AllowHide = false;
			menu.AllowDelete = false;
			menu.AllowReset = false;

			nCommandBarsManager1.CommandClicked += new CommandEventHandler(nCommandBarsManager1_CommandClicked);
			nCommandBarsManager1.QueryCommandUIState += new QueryCommandUIStateEventHandler(nCommandBarsManager1_QueryCommandUIState);
		}
		protected virtual void InitPanels()
		{
			NDockZone zone;
			NDockingPanel panel;
			NDockingPanelHost panelHost;

			zone = new NDockZone(Orientation.Vertical);
			panelHost = new NDockingPanelHost();
			panelHost.AddChild(GetGenericPanel());
			zone.AddChild(panelHost);

			m_Container.RootZone.AddChild(zone);

			panel = GetGenericPanel();
			panel.TabInfo.ImageIndex = 1;

			panelHost = new NDockingPanelHost();
			panelHost.AddChild(panel);
			zone.AddChild(panelHost);
		}
		protected virtual NDockingPanel InitPropertyBrowser()
		{
			NDockingPanel panel = new NDockingPanel();
			panel.Text = "Properties";
			panel.TabInfo.Text = "Properties";
			panel.TabInfo.ImageIndex = 3;
			m_PropertyBrowser.Dock = DockStyle.Fill;
			panel.Controls.Add(m_PropertyBrowser);

			return panel;
		}


		#endregion

		#region Implementation

		internal static TextBox GetTextBox()
		{
			TextBox tb = new TextBox();
			tb.Multiline = true;
			tb.Dock = DockStyle.Fill;
			tb.BorderStyle = BorderStyle.None;

			return tb;
		}
		internal NDockingPanel GetGenericPanel()
		{
			NDockingPanel panel = new NDockingPanel();
			panel.Controls.Add(GetTextBox());
			panel.TabInfo.ImageIndex = 0;
			panel.Key = "Docking Panel " + m_iIndex.ToString();

			m_iIndex++;

			return panel;
		}

		internal void InitDocumentView()
		{
			m_Client.Dock = DockStyle.Fill;

			NUIDocument doc = new NUIDocument();
			doc.Client = m_Client;
			m_DockManager.DocumentManager.AddDocument(doc);
		}


		#endregion

		#region Event Handlers

		private void nCommandBarsManager1_CommandPopup(object sender, CommandEventArgs e)
		{
			NCommand comm = e.Command;
			if(comm.Properties.ID != -5)
				return;

			comm.Commands.DisposeChildren();

			INDockingPanel[] panels = m_DockManager.Panels;
			INDockingPanel panel;
			NCommand comm1;
			int length = panels.Length;

			for(int i = 0; i < length; i++)
			{
				panel = panels[i];

				comm1 = new NCommand();
				comm1.Properties.Text = panel.Text;
				comm1.Properties.ImageList = MainForm.DockingImages;
				comm1.Properties.ImageIndex = panel.TabInfo.ImageIndex;
				comm1.Properties.Tag = panel;
                comm1.Checked = panel.DockState != DockState.Hidden;                
				comm1.Click += m_ClickEH;

				comm.Commands.Add(comm1);
			}
		}

		protected virtual void nCommandBarsManager1_CommandClicked(object sender, CommandEventArgs e)
		{
		}
		protected virtual void nCommandBarsManager1_QueryCommandUIState(object sender, QueryCommandUIStateEventArgs e)
		{
		}
		private void OnPanelCommandClicked(object sender, CommandEventArgs args)
		{
			NCommand comm = args.Command;
			INDockingPanel panel = comm.Properties.Tag as INDockingPanel;
			if(panel == null)
				return;

			if(comm.Checked)
				panel.Close();
			else
				panel.Display();
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
			this.m_PropertyBrowser = new System.Windows.Forms.Panel();
			this.m_PropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.panel2 = new System.Windows.Forms.Panel();
			this.nComboBox1 = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_Client = new System.Windows.Forms.TextBox();
			this.nCommandBarsManager1 = new Nevron.UI.WinForm.Controls.NCommandBarsManager(this.components);
			this.nMenuBar1 = new Nevron.UI.WinForm.Controls.NMenuBar();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommandContext1 = new Nevron.UI.WinForm.Controls.NCommandContext();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.m_PropertyBrowser.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nCommandBarsManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// m_PropertyBrowser
			// 
			this.m_PropertyBrowser.Controls.Add(this.m_PropertyGrid);
			this.m_PropertyBrowser.Controls.Add(this.panel2);
			this.m_PropertyBrowser.Location = new System.Drawing.Point(224, 104);
			this.m_PropertyBrowser.Name = "m_PropertyBrowser";
			this.m_PropertyBrowser.Size = new System.Drawing.Size(128, 120);
			this.m_PropertyBrowser.TabIndex = 0;
			this.m_PropertyBrowser.Visible = false;
			// 
			// m_PropertyGrid
			// 
			this.m_PropertyGrid.CommandsVisibleIfAvailable = true;
			this.m_PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_PropertyGrid.LargeButtons = false;
			this.m_PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.m_PropertyGrid.Location = new System.Drawing.Point(0, 24);
			this.m_PropertyGrid.Name = "m_PropertyGrid";
			this.m_PropertyGrid.Size = new System.Drawing.Size(128, 96);
			this.m_PropertyGrid.TabIndex = 2;
			this.m_PropertyGrid.Text = "propertyGrid1";
			this.m_PropertyGrid.ToolbarVisible = false;
			this.m_PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.m_PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.nComboBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(128, 24);
			this.panel2.TabIndex = 1;
			// 
			// nComboBox1
			// 
			this.nComboBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nComboBox1.Location = new System.Drawing.Point(0, 0);
			this.nComboBox1.Name = "nComboBox1";
			this.nComboBox1.Size = new System.Drawing.Size(128, 22);
			this.nComboBox1.TabIndex = 0;
			this.nComboBox1.Text = "nComboBox1";
			// 
			// m_Client
			// 
			this.m_Client.Location = new System.Drawing.Point(8, 136);
			this.m_Client.Multiline = true;
			this.m_Client.Name = "m_Client";
			this.m_Client.Size = new System.Drawing.Size(128, 40);
			this.m_Client.TabIndex = 1;
			this.m_Client.Text = "";
			this.m_Client.Visible = false;
			// 
			// nCommandBarsManager1
			// 
			this.nCommandBarsManager1.ParentControl = this;
			this.nCommandBarsManager1.Toolbars.Add(this.nMenuBar1);
			this.nCommandBarsManager1.CommandPopup += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.nCommandBarsManager1_CommandPopup);
			// 
			// nMenuBar1
			// 
			this.nMenuBar1.AutoDropDownDelay = false;
			this.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent;
			this.nMenuBar1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand2});
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
			// nCommand2
			// 
			this.nCommand2.Properties.DropDownBehavior = Nevron.UI.WinForm.Controls.DropDownBehavior.AlwaysDropDown;
			this.nCommand2.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
			this.nCommand2.Properties.Text = "Panels";
			// 
			// NDockingPanelsExampleForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(794, 567);
			this.Controls.Add(this.m_Client);
			this.Controls.Add(this.m_PropertyBrowser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "NDockingPanelsExampleForm";
			this.Text = "NDockingPanelsExampleForm";
			this.m_PropertyBrowser.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nCommandBarsManager1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.IContainer components;
		internal System.Windows.Forms.Panel m_PropertyBrowser;
		internal Nevron.UI.WinForm.Controls.NComboBox nComboBox1;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.PropertyGrid m_PropertyGrid;
		internal System.Windows.Forms.TextBox m_Client;
		internal Nevron.UI.WinForm.Controls.NCommandBarsManager nCommandBarsManager1;
		private Nevron.UI.WinForm.Controls.NCommandContext nCommandContext1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;

		int m_iIndex;

		internal NDockManager m_DockManager;
		internal int m_iLockUpdate;
		internal NDockingPanelContainer m_Container;
		private Nevron.UI.WinForm.Controls.NMenuBar nMenuBar1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		CommandEventHandler m_ClickEH;

		#endregion
	}
}
