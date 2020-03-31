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
	/// Summary description for NDockingStickersUC.
	/// </summary>
	public class NDockingStickersUC : NDockingPanelsBasicFeaturesUC
	{
		#region Constructor

		public NDockingStickersUC(MainForm f) : base(f)
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

			m_ExampleFormType = typeof(NDockingStickerForm);
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
	/// Summary description for NComplexLayoutForm.
	/// </summary>
	public class NDockingStickerForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NDockingStickerForm()
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
			base.InitPanels();

			NDockingPanelHost host = new NDockingPanelHost();

			NDockingPanel panel = new NDockingPanel();
			m_PropertyGrid.Dock = DockStyle.Fill;
			panel.Controls.Add(m_PropertyGrid);

			m_PropertyGrid.SelectedObject = m_DockManager.DockingHintStyle;

			host.AddChild(panel);
			m_Container.RootZone.AddChild(host);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			m_DockManager.Panels[2].Activate();
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
			this.Text = "Docking Stickers Example";
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
