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
	/// Summary description for NCommandModelForm.
	/// </summary>
	public class NCommandModelForm : NForm
	{
		#region Constructor

		public NCommandModelForm()
		{
			InitializeComponent();

			Size = new Size(800, 600);

			AddCustomCommands();
			PopulateAvailableCommands();
			AddDocuments();

			nCommandBarsManager1.Palette.Copy(NUIManager.Palette);
			nDockManager1.Palette.Copy(NUIManager.Palette);
			Palette.Copy(NUIManager.Palette);

			m_ClickEH = new CommandEventHandler(OnPanelCommandClicked);
		}


		#endregion

		#region Overrides

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
		}

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


		#endregion

		#region Implementation

		void PopulateAvailableCommands()
		{
			m_AvailableCommandsCombo.Items.Clear();
			//m_AvailableCommandsCombo.DropDownWidth = 300;

			NDockingFrameworkCommand[] commands = nDockManager1.Commander.Commands;
			int length = commands.Length;

			NDockingFrameworkCommand comm;
			NListBoxItem item;

			for(int i = 0; i < length; i++)
			{
				comm = commands[i];

				item = new NListBoxItem();
				item.Text = comm.Name + " - ID: " + comm.ID;
				item.Tag = comm;
				m_AvailableCommandsCombo.Items.Add(item);
			}
		}

		void AddCustomCommands()
		{
			NDockingFrameworkCommand comm;

			EventHandler eh = new EventHandler(comm_Executed);

			comm = new NDockingFrameworkCommand(101, "Custom Command 1");
			comm.Executed += eh;
			nDockManager1.Commander.RegisterCommand(comm);

			comm = new NDockingFrameworkCommand(102, "Custom Command 2");
			comm.Executed += eh;
			nDockManager1.Commander.RegisterCommand(comm);
		}
		void AddDocuments()
		{
			NUIDocument doc;

			for(int i = 1; i < 5; i++)
			{
				doc = new NUIDocument("Document " + i.ToString(), -1, NDockingPanelsExampleForm.GetTextBox());
				nDockManager1.DocumentManager.AddDocument(doc);
			}
		}


		#endregion

		#region Event Handlers

		private void m_AvailableCommandsCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		private void m_ExecuteButton_Click(object sender, System.EventArgs e)
		{
			NDockingFrameworkCommand comm = m_AvailableCommandsCombo.SelectedItem as NDockingFrameworkCommand;
			if(comm == null)
				return;

			comm.Execute(null);
		}

		private void comm_Executed(object sender, EventArgs e)
		{
			NDockingFrameworkCommand comm = sender as NDockingFrameworkCommand;
			MessageBox.Show("Custom command executed:\n" + comm.Name);
		}

		private void nCommandBarsManager1_CommandPopup(object sender, CommandEventArgs e)
		{
			NCommand comm = e.Command;
			if(comm.Properties.ID != 1)
				return;

			comm.Commands.DisposeChildren();

			INDockingPanel[] panels = nDockManager1.Panels;
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

		private void nButton1_Click(object sender, System.EventArgs e)
		{
			nDockManager1.Commander.ShowKeyboardEditor();
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
			Nevron.UI.WinForm.Docking.NDockZone nDockZone0 = new Nevron.UI.WinForm.Docking.NDockZone();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone1 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			Nevron.UI.WinForm.Docking.NDockingPanelHost nDockZone3 = new Nevron.UI.WinForm.Docking.NDockingPanelHost();
			this.nDockManager1 = new Nevron.UI.WinForm.Docking.NDockManager();
			this.nDockingPanel1 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
			this.label1 = new System.Windows.Forms.Label();
			this.m_AvailableCommandsCombo = new Nevron.UI.WinForm.Controls.NComboBox();
			this.m_ExecuteButton = new Nevron.UI.WinForm.Controls.NButton();
			this.nCommandBarsManager1 = new Nevron.UI.WinForm.Controls.NCommandBarsManager(this.components);
			this.nMenuBar1 = new Nevron.UI.WinForm.Controls.NMenuBar();
			this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nCommand3 = new Nevron.UI.WinForm.Controls.NCommand();
			this.nDockingPanel2 = new Nevron.UI.WinForm.Docking.NDockingPanel();
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).BeginInit();
			this.nDockingPanel1.SuspendLayout();
			// 
			// nDockManager1
			// 
			this.nDockManager1.DocumentStyle.DocumentViewStyle = Nevron.UI.WinForm.Docking.DocumentViewStyle.MdiStandard;
			this.nDockManager1.Form = this;
			this.nDockManager1.RootContainerZIndex = 0;
			//  
			// Root Zone
			//  
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0);
			this.nDockManager1.RootContainer.RootZone.AddChild(nDockZone3);
			this.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Vertical;
			//  
			// nDockZone0
			//  
			nDockZone0.AddChild(nDockZone1);
			nDockZone0.AddChild(this.nDockManager1.DocumentManager.DocumentViewHost);
			nDockZone0.Name = "nDockZone0";
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone0.Index = 0;
			nDockZone0.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 338);
			//  
			// nDockZone1
			//  
			nDockZone1.AddChild(this.nDockingPanel1);
			nDockZone1.Name = "nDockZone1";
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone1.Index = 0;
			nDockZone1.SizeInfo.PrefferedSize = new System.Drawing.Size(240, 200);
			//  
			// nDockZone3
			//  
			nDockZone3.AddChild(this.nDockingPanel2);
			nDockZone3.Name = "nDockZone3";
			nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			nDockZone3.Index = 1;
			nDockZone3.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 135);
			// 
			// nDockingPanel1
			// 
			this.nDockingPanel1.Controls.Add(this.nButton1);
			this.nDockingPanel1.Controls.Add(this.label1);
			this.nDockingPanel1.Controls.Add(this.m_AvailableCommandsCombo);
			this.nDockingPanel1.Controls.Add(this.m_ExecuteButton);
			this.nDockingPanel1.Name = "nDockingPanel1";
			this.nDockingPanel1.SizeInfo.PrefferedSize = new System.Drawing.Size(240, 200);
			this.nDockingPanel1.TabIndex = 1;
			this.nDockingPanel1.Text = "Properties";
			// 
			// nButton1
			// 
			this.nButton1.Location = new System.Drawing.Point(8, 112);
			this.nButton1.Name = "nButton1";
			this.nButton1.Size = new System.Drawing.Size(224, 32);
			this.nButton1.TabIndex = 3;
			this.nButton1.Text = "Keyboard...";
			this.nButton1.Click += new System.EventHandler(this.nButton1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Available Commands:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_AvailableCommandsCombo
			// 
			this.m_AvailableCommandsCombo.DropDownWidth = 300;
			this.m_AvailableCommandsCombo.Location = new System.Drawing.Point(8, 32);
			this.m_AvailableCommandsCombo.Name = "m_AvailableCommandsCombo";
			this.m_AvailableCommandsCombo.Size = new System.Drawing.Size(224, 22);
			this.m_AvailableCommandsCombo.TabIndex = 1;
			this.m_AvailableCommandsCombo.Text = "nComboBox1";
			this.m_AvailableCommandsCombo.SelectedIndexChanged += new System.EventHandler(this.m_AvailableCommandsCombo_SelectedIndexChanged);
			// 
			// m_ExecuteButton
			// 
			this.m_ExecuteButton.Location = new System.Drawing.Point(160, 64);
			this.m_ExecuteButton.Name = "m_ExecuteButton";
			this.m_ExecuteButton.Size = new System.Drawing.Size(72, 24);
			this.m_ExecuteButton.TabIndex = 0;
			this.m_ExecuteButton.Text = "Execute";
			this.m_ExecuteButton.Click += new System.EventHandler(this.m_ExecuteButton_Click);
			// 
			// nCommandBarsManager1
			// 
			this.nCommandBarsManager1.ParentControl = this;
			this.nCommandBarsManager1.Toolbars.Add(this.nMenuBar1);
			this.nCommandBarsManager1.CommandPopup += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.nCommandBarsManager1_CommandPopup);
			// 
			// nMenuBar1
			// 
			this.nMenuBar1.AllowDelete = false;
			this.nMenuBar1.AllowHide = false;
			this.nMenuBar1.AllowRename = false;
			this.nMenuBar1.AutoDropDownDelay = false;
			this.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent;
			this.nMenuBar1.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
																						   this.nCommand1,
																						   this.nCommand3});
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
			this.nCommand2.Properties.ID = 0;
			this.nCommand2.Properties.Text = "E&xit";
			// 
			// nCommand3
			// 
			this.nCommand3.Properties.DropDownBehavior = Nevron.UI.WinForm.Controls.DropDownBehavior.AlwaysDropDown;
			this.nCommand3.Properties.ID = 1;
			this.nCommand3.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
			this.nCommand3.Properties.Text = "&Panels";
			// 
			// nDockingPanel2
			// 
			this.nDockingPanel2.Name = "nDockingPanel2";
			this.nDockingPanel2.SizeInfo.PrefferedSize = new System.Drawing.Size(200, 135);
			this.nDockingPanel2.TabIndex = 1;
			// 
			// NCommandModelForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 462);
			this.Name = "NCommandModelForm";
			this.Text = "Command Model Example";
			((System.ComponentModel.ISupportInitialize)(this.nDockManager1)).EndInit();
			this.nDockingPanel1.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private Nevron.UI.WinForm.Docking.NDockManager nDockManager1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel1;
		private Nevron.UI.WinForm.Controls.NCommandBarsManager nCommandBarsManager1;
		private Nevron.UI.WinForm.Controls.NMenuBar nMenuBar1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand1;
		private Nevron.UI.WinForm.Controls.NCommand nCommand2;
		private Nevron.UI.WinForm.Controls.NCommand nCommand3;
		private Nevron.UI.WinForm.Controls.NButton m_ExecuteButton;
		private Nevron.UI.WinForm.Controls.NComboBox m_AvailableCommandsCombo;
		private System.Windows.Forms.Label label1;
		private Nevron.UI.WinForm.Docking.NDockingPanel nDockingPanel2;
		private System.ComponentModel.IContainer components;
		private Nevron.UI.WinForm.Controls.NButton nButton1;

		CommandEventHandler m_ClickEH;

		#endregion
	}
}
