using System;
using System.Drawing;
using System.Windows.Forms;

using Nevron.UI.WinForm.Docking;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NDiagramExamplesLayoutStrategy.
	/// </summary>
	public class NDiagramExamplesLayoutStrategy : NExamplesLayoutStrategy
	{
		#region Constructor

		public NDiagramExamplesLayoutStrategy()
		{
		}

		#endregion

		#region Overrides

		protected override INDockZone GetMainZone(NExamplesDockManager dockManager)
		{
			INDockZone zone = new NDockZone(Orientation.Vertical);

			WideScreenExampleZone = new NDockZone();
			WideScreenExampleZone.Referenced = true;
			zone.AddChild(WideScreenExampleZone);

			INDockZone host = new NDockingPanelHost();
			host.SizeInfo.SizeLogic = SizeLogic.FillInterior;
//			NDockingPanel panel = new NDockingPanel();

			host.AddChild((dockManager as NDiagramExamplesDockManager).DiagramDesignerPanel);
			
			host.AddChild(dockManager.m_DescriptionPanel);
			host.AddChild(dockManager.m_ViewSourcePanel);

			zone.AddChild(host);

			return zone;
		}

		protected override INDockZone GetExampleZone(NExamplesDockManager dockManager)
		{
			INDockZone host = base.GetExampleZone(dockManager);
			host.AddChild((dockManager as NDiagramExamplesDockManager).EventLogPanel);
			host.AddChild((dockManager as NDiagramExamplesDockManager).DiagramExplorerPanel);

			return host;
		}

		#endregion

		#region Fields
		public INDockZone WideScreenExampleZone = null;
		#endregion
	}
}
