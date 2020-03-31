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
	/// Summary description for NNestedContainersUC.
	/// </summary>
	public class NNestedDockContainersUC : NDockingPanelsBasicFeaturesUC
	{
		#region Constructor

		public NNestedDockContainersUC(MainForm f) : base(f)
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

			m_ExampleFormType = typeof(NNestedContainersForm);
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
	public class NNestedContainersForm : NDockingPanelsExampleForm
	{
		#region Constructor

		public NNestedContainersForm()
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

			NDockingPanel panel = new NDockingPanel();
			panelHost = new NDockingPanelHost();
			panelHost.AddChild(panel);

			m_Container.RootZone.AddChild(panelHost);

			NDockingPanelContainer container = m_DockManager.AddContainer(DockStyle.Fill);
			container.RootZone.Orientation = Orientation.Vertical;
			container.BackColor = Color.Red;
			container.DockPadding.All = 10;
			panel.Controls.Add(container);

			panelHost = new NDockingPanelHost();
			panelHost.AddChild(GetGenericPanel());
			panelHost.AddChild(GetGenericPanel());
			container.RootZone.AddChild(panelHost);
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
			this.Text = "Nested Containers Example";
		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;

		#endregion
	}
}
