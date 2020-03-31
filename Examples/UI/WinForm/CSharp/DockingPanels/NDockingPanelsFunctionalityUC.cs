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
	/// Summary description for NDockingPanelsFunctionality.
	/// </summary>
	public class NDockingPanelsFunctionalityUC : NDockingPanelsBasicFeaturesUC
	{
		#region Constructor

		public NDockingPanelsFunctionalityUC(MainForm f) : base(f)
		{
			InitializeComponent();
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
			}
			base.Dispose( disposing );
		}

		public override void Initialize()
		{
			base.Initialize ();

			m_ExampleFormType = typeof(NFunctionalityForm);
		}



		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}

	/// <summary>
	/// Summary description for NFunctionalityForm.
	/// </summary>
	public class NFunctionalityForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NFunctionalityForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			}
			base.Dispose( disposing );
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			Control c = m_DockManager.Panels[0] as Control;
			m_Panel.Dock = DockStyle.Fill;
			c.Controls.Add(m_Panel);

			m_DockManager.LockPanels();
			m_DockManager.PanelActivated += new PanelEventHandler(m_DockManager_PanelActivated);

			UpdateFunctionalityButtons();
		}

		protected override void InitPanels()
		{
			NDockingPanelHost panelHost;

			panelHost = new NDockingPanelHost();
			panelHost.SizeInfo.SizeLogic = SizeLogic.Absolute;
			panelHost.SizeInfo.AbsoluteSize = new Size(200, 0);
			panelHost.AddChild(new NDockingPanel());

			m_Container.RootZone.AddChild(panelHost);
		}


		#endregion

		#region Implementation

		internal INDockingPanel SelectedPanel
		{
			get
			{
				INDockingPanel panel = m_DockManager.Panels[0];
				return panel;
			}
		}
		internal void UpdateFunctionalityButtons()
		{
			INDockingPanel selected = SelectedPanel;
			DockState state = selected.DockState;

			switch(state)
			{
				case DockState.AutoHide:
					m_FloatButton.Enabled = false;
					m_HideButton.Enabled = true;
					m_DockButton.Enabled = true;
					m_AutoHideButton.Enabled = false;
					break;
				case DockState.Docked:
					m_DockButton.Enabled = false;
					m_AutoHideButton.Enabled = true;
					m_FloatButton.Enabled = true;
					m_HideButton.Enabled = true;
					break;
				case DockState.Floating:
					m_DockButton.Enabled = true;
					m_HideButton.Enabled = true;
					m_AutoHideButton.Enabled = false;
					m_FloatButton.Enabled = false;
					break;
				case DockState.Unknown:
					m_DockButton.Enabled = false;
					m_HideButton.Enabled = false;
					m_AutoHideButton.Enabled = false;
					m_FloatButton.Enabled = false;
					break;
			}
		}


		#endregion

		#region Event Handlers

		private void m_DockButton_Click(object sender, System.EventArgs e)
		{
			INDockingPanel selected = SelectedPanel;
			if(selected == null)
				return;

			DockState state = selected.DockState;
			if(state != DockState.Docked)
				selected.Redock();

			UpdateFunctionalityButtons();
		}

		private void m_FloatButton_Click(object sender, System.EventArgs e)
		{
			INDockingPanel selected = SelectedPanel;
			if(selected == null)
				return;

			DockState state = selected.DockState;
			if(state != DockState.Floating)
				selected.Float();

			UpdateFunctionalityButtons();
		}

		private void m_HideButton_Click(object sender, System.EventArgs e)
		{
			INDockingPanel selected = SelectedPanel;
			if(selected == null)
				return;

			selected.Close();
			UpdateFunctionalityButtons();
		}

		private void m_AutoHideButton_Click(object sender, System.EventArgs e)
		{
			INDockingPanel selected = SelectedPanel;
			if(selected == null)
				return;

			DockState state = selected.DockState;
			if(state != DockState.AutoHide)
				selected.AutoHide();

			UpdateFunctionalityButtons();
		}

		private void m_DockManager_PanelActivated(object sender, PanelEventArgs e)
		{
			UpdateFunctionalityButtons();
		}


		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_Panel = new System.Windows.Forms.Panel();
			this.m_FunctionalityPanel = new System.Windows.Forms.Panel();
			this.m_AutoHideButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_HideButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_FloatButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_DockButton = new Nevron.UI.WinForm.Controls.NButton();
			this.m_Panel.SuspendLayout();
			this.m_FunctionalityPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_Panel
			// 
			this.m_Panel.Controls.Add(this.m_FunctionalityPanel);
			this.m_Panel.Location = new System.Drawing.Point(288, 240);
			this.m_Panel.Name = "m_Panel";
			this.m_Panel.Size = new System.Drawing.Size(104, 152);
			this.m_Panel.TabIndex = 4;
			// 
			// m_FunctionalityPanel
			// 
			this.m_FunctionalityPanel.Controls.Add(this.m_AutoHideButton);
			this.m_FunctionalityPanel.Controls.Add(this.m_HideButton);
			this.m_FunctionalityPanel.Controls.Add(this.m_FloatButton);
			this.m_FunctionalityPanel.Controls.Add(this.m_DockButton);
			this.m_FunctionalityPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_FunctionalityPanel.Location = new System.Drawing.Point(0, 0);
			this.m_FunctionalityPanel.Name = "m_FunctionalityPanel";
			this.m_FunctionalityPanel.Size = new System.Drawing.Size(104, 152);
			this.m_FunctionalityPanel.TabIndex = 2;
			// 
			// m_AutoHideButton
			// 
			this.m_AutoHideButton.Location = new System.Drawing.Point(8, 112);
			this.m_AutoHideButton.Name = "m_AutoHideButton";
			this.m_AutoHideButton.Size = new System.Drawing.Size(88, 24);
			this.m_AutoHideButton.TabIndex = 3;
			this.m_AutoHideButton.Text = "Auto Hide";
			this.m_AutoHideButton.Click += new System.EventHandler(this.m_AutoHideButton_Click);
			// 
			// m_HideButton
			// 
			this.m_HideButton.Location = new System.Drawing.Point(8, 80);
			this.m_HideButton.Name = "m_HideButton";
			this.m_HideButton.Size = new System.Drawing.Size(88, 24);
			this.m_HideButton.TabIndex = 2;
			this.m_HideButton.Text = "Hide";
			this.m_HideButton.Click += new System.EventHandler(this.m_HideButton_Click);
			// 
			// m_FloatButton
			// 
			this.m_FloatButton.Location = new System.Drawing.Point(8, 48);
			this.m_FloatButton.Name = "m_FloatButton";
			this.m_FloatButton.Size = new System.Drawing.Size(88, 24);
			this.m_FloatButton.TabIndex = 1;
			this.m_FloatButton.Text = "Float";
			this.m_FloatButton.Click += new System.EventHandler(this.m_FloatButton_Click);
			// 
			// m_DockButton
			// 
			this.m_DockButton.Location = new System.Drawing.Point(8, 16);
			this.m_DockButton.Name = "m_DockButton";
			this.m_DockButton.Size = new System.Drawing.Size(88, 24);
			this.m_DockButton.TabIndex = 0;
			this.m_DockButton.Text = "Dock";
			this.m_DockButton.Click += new System.EventHandler(this.m_DockButton_Click);
			// 
			// NFunctionalityForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(760, 414);
			this.Controls.Add(this.m_Panel);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Name = "NFunctionalityForm";
			this.Text = "Programmable Functionality Example";
			this.Controls.SetChildIndex(this.m_Panel, 0);
			this.m_Panel.ResumeLayout(false);
			this.m_FunctionalityPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.Windows.Forms.Panel m_Panel;
		private System.Windows.Forms.Panel m_FunctionalityPanel;
		private Nevron.UI.WinForm.Controls.NButton m_DockButton;
		private Nevron.UI.WinForm.Controls.NButton m_FloatButton;
		private Nevron.UI.WinForm.Controls.NButton m_HideButton;
		private Nevron.UI.WinForm.Controls.NButton m_AutoHideButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion
	}
}
