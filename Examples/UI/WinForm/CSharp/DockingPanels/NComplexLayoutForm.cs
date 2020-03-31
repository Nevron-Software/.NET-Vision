using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Docking;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NComplexLayoutForm.
	/// </summary>
	public class NComplexLayoutForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NComplexLayoutForm()
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
			NDockZone zone;
			NDockingPanelHost panelHost;

			zone = new NDockZone(Orientation.Vertical);
			panelHost = new NDockingPanelHost();
			panelHost.AddChild(GetGenericPanel());
			zone.AddChild(panelHost);

			panelHost = new NDockingPanelHost();
			panelHost.AddChild(GetGenericPanel());
			zone.AddChild(panelHost);

			m_Container.RootZone.AddChild(zone);

			zone = new NDockZone(Orientation.Vertical);

			panelHost = new NDockingPanelHost();
			panelHost.AddChild(GetGenericPanel());
			panelHost.AddChild(GetGenericPanel());
			zone.AddChild(panelHost);

			m_Container.RootZone.AddChild(zone);

			zone = new NDockZone(Orientation.Vertical);
			panelHost = new NDockingPanelHost();
			panelHost.AddChild(GetGenericPanel());
			panelHost.AddChild(GetGenericPanel());
			zone.AddChild(panelHost);

			panelHost = new NDockingPanelHost();
			panelHost.AddChild(GetGenericPanel());
			zone.AddChild(panelHost);

			panelHost = new NDockingPanelHost();
			panelHost.AddChild(GetGenericPanel());
			panelHost.AddChild(GetGenericPanel());
			zone.AddChild(panelHost);

			m_Container.RootZone.AddChild(zone);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			m_DockManager.Panels[0].AutoHide();
			m_DockManager.Panels[2].AutoHide();
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
			this.Text = "Complex Layout Example";
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
