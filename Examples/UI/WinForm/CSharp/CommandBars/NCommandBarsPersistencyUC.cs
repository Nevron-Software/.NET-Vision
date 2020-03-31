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
	public class NCommandBarsPersistencyUC : NExampleUserControl
	{
		#region Constructor

		public NCommandBarsPersistencyUC(MainForm f) : base(f)
		{
			InitializeComponent();

			Dock = DockStyle.Fill;
			Init();

			m_State = new NCommandBarsState();
			m_State.Manager = m_Manager;
			m_State.PersistencyFlags = NCommandBarsStateFlags.All;
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
				if(m_Manager != null)
					m_Manager.Dispose();
			}
			base.Dispose( disposing );
		}


		#endregion

		#region Implementation

		internal void Init()
		{
			InitManager();
			InitToolbars();
		}
		internal void InitManager()
		{
			m_Manager = new NCommandBarsManager(this);
			m_Manager.Palette.Copy(NUIManager.Palette);
			m_Manager.ImageLists.Add(MainForm.StandardImages);
			m_Manager.CommandClicked += new CommandEventHandler(OnCommandClicked);
		}


		#region Toolbars

		internal void InitToolbars()
		{
			InitStandandardToolbar();
		}

		internal void InitStandandardToolbar()
		{
			NDockingToolbar tb = new NDockingToolbar();
			tb.Text = "Standard";
			tb.ImageList = MainForm.StandardImages;

			NCommand comm, comm1;

			comm = new NCommand();
            comm.Properties.Text = "File";
			comm.Properties.Style = CommandStyle.Text;
			comm.Properties.MenuOptions.ImageSize = new Size(32, 32);
			tb.Commands.Add(comm);

			comm1 = new NCommand();
			comm1.Properties.Style = CommandStyle.ImageAndText;
			comm1.Properties.Text = "Load State";
			comm1.Properties.ImageIndex = 1;
			comm1.Properties.ID = (int)Contexts.Open;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.Style = CommandStyle.ImageAndText;
			comm1.Properties.Text = "Save State";
			comm1.Properties.ImageIndex = 2;
			comm1.Properties.ID = (int)Contexts.Save;
			comm.Commands.Add(comm1);

			m_Manager.Toolbars.Add(tb);
		}


		#endregion


		#endregion

		#region Event Handlers

		private void OnCommandClicked(object sender, CommandEventArgs e)
		{
			switch(e.Command.Properties.ID)
			{
				case (int)Contexts.Open:
					m_State.Load();
					break;
				case (int)Contexts.Save:
					m_State.Save();
					break;
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
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		internal NCommandBarsManager m_Manager;
		internal NCommandBarsState m_State;

		#endregion
	}
}
