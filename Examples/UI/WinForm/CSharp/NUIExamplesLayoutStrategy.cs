using System;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Docking;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NUIExamplesLayout.
	/// </summary>
	public class NUIExamplesLayoutStrategy : NExamplesLayoutStrategy
	{
		#region Constructor

		public NUIExamplesLayoutStrategy()
		{
		}


		#endregion

		#region Overrides

		public override void InitialLayout(NExamplesDockManager dockManager)
		{
			INDockZone root = dockManager.m_Container.RootZone;
			dockManager.m_ExamplePanel.SizeInfo.SizeLogic = SizeLogic.FillInterior;

			//add navigation zone to the root one
			root.AddChild(GetNavigationZone(dockManager));

			//the ui examples does not have main app control, so we do not need right zone
			root.AddChild(GetMainZone(dockManager));
		}
		protected override INDockZone GetMainZone(NExamplesDockManager dockManager)
		{
			NDockZone zone;
			NDockingPanelHost host;

			//create a zone with vertical orientation which will hold main control host and description/source/web panels
			zone = new NDockZone(Orientation.Vertical);

			//create a host for the example/source panel
			host = new NDockingPanelHost();
			host.SizeInfo.SizeLogic = SizeLogic.FillInterior;
			host.AddChild(dockManager.m_ExamplePanel);
			host.AddChild(dockManager.m_ViewSourcePanel);
			//add it to the zone with vertical orientation
			zone.AddChild(host);

			//create a host for description/web panels
			host = new NDockingPanelHost();
			host.AddChild(dockManager.m_DescriptionPanel);

			//add the host to the zone
			zone.AddChild(host);

			return zone;
		}


		#endregion
	}
}

