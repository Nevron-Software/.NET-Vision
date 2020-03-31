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
	/// Summary description for NComplexLayoutForm.
	/// </summary>
	public class NAutoHideSupportForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NAutoHideSupportForm()
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

			m_PropertyGrid.SelectedObject = panel.TabInfo;

			host.AddChild(panel);
			m_Container.RootZone.AddChild(host);
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
			this.Text = "Auto Hide Support Example";
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
