using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.Serialization;
using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking; 

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NDockingPanelPersistency.
	/// </summary>
	public class NDockingPanelsPersistencyUC :  NDockingPanelsBasicFeaturesUC
	{
		#region Constructor

		public NDockingPanelsPersistencyUC(MainForm f) : base(f)
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

			m_ExampleFormType = typeof(NPersistencyForm);
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
	/// Summary description for NPersistencyForm.
	/// </summary>
	public class NPersistencyForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NPersistencyForm()
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

		protected override void InitPanels()
		{
			INDockZone root = m_DockManager.RootContainer.RootZone;
			INDockZone target;
			NDockingPanel panel;

			panel = GetGenericPanel();
			panel.PerformDock(root, DockStyle.Left);

			target = panel.ParentZone;
			panel = GetGenericPanel();
			panel.PerformDock(target, DockStyle.Bottom);

			target = m_DockManager.DocumentManager.DocumentViewHost;
			panel = GetGenericPanel();
			panel.PerformDock(target, DockStyle.Bottom);

			panel = new NDockingPanel();
			panel.Controls.Add(m_PropertyGrid);
			m_PropertyGrid.SelectedObject = m_DockManager;
			panel.PerformDock(root, DockStyle.Right);

			//add some documents to the doc view

			for(int i = 0; i < 5; i++)
			{
				NUIDocument doc = new NUIDocument();
				doc.Client = GetTextBox();
				m_DockManager.DocumentManager.AddDocument(doc);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
		}


		protected override void InitCommandBars()
		{
			base.InitCommandBars ();

			NCommand comm, comm1, comm2;
			NMenuBar bar = nCommandBarsManager1.Toolbars.GetMenu();

			comm = new NCommand();
			comm.Properties.Text = "Per&sistency";
			bar.Commands.Insert(0, comm);

			comm1 = new NCommand();
			comm1.Properties.Text = "&Save...";
			comm1.Properties.ID = 0;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.Text = "&Load...";
			comm1.Properties.ID = 1;
			comm.Commands.Add(comm1);

			comm1 = new NCommand();
			comm1.Properties.BeginGroup = true;
			comm1.Properties.Text = "Format";
			comm.Commands.Add(comm1);

			foreach(PersistencyFormat format in Enum.GetValues(typeof(PersistencyFormat)))
			{
				comm2 = new NCommand();
				comm2.Properties.Tag = format;
				comm2.Properties.ID = 2;
				comm2.Properties.Text = format.ToString();
				comm1.Commands.Add(comm2);
			}
		}

		protected override void nCommandBarsManager1_CommandClicked(object sender, CommandEventArgs e)
		{
			NCommand comm = e.Command;
			int id = comm.Properties.ID;

			NDockingFrameworkState state = new NDockingFrameworkState(m_DockManager);

			state.ResolveDocumentClient += new ResolveClientEventHandler(state_ResolveDocumentClient);
			state.Format = m_Format;

			switch(id)
			{
				case 0:
					state.Save();
					break;
				case 1:
					state.Load();
					break;
				case 2:
					m_Format = (PersistencyFormat)comm.Properties.Tag;
					break;
			}

			state.ResolveDocumentClient -= new ResolveClientEventHandler(state_ResolveDocumentClient);
		}

		protected override void nCommandBarsManager1_QueryCommandUIState(object sender, QueryCommandUIStateEventArgs e)
		{
			NCommand comm = e.UIState.Command;
			if(!(comm.Properties.Tag is PersistencyFormat))
				return;

			PersistencyFormat pf = (PersistencyFormat)comm.Properties.Tag;
			e.UIState.Checked = m_Format == pf;
			e.UIState.Handled = true;
		}


		#endregion

		#region Event Handlers

		private void state_ResolveDocumentClient(object sender, DocumentEventArgs e)
		{
			e.Document.Client = GetTextBox();
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
			this.Size = new System.Drawing.Size(600,600);
			this.Text = "Docking Panel Persistency Example";
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
		internal PersistencyFormat m_Format;

		#endregion
	}
}
