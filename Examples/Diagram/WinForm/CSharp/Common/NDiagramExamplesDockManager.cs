using System;
using System.Collections;

using Nevron.UI.WinForm.Docking;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NDiagramExamplesDockManager.
	/// </summary>
	public class NDiagramExamplesDockManager : NExamplesDockManager
	{
		#region Constructors

		public NDiagramExamplesDockManager()
		{
		}

		#endregion

		#region Overrides

		protected override void CreatePredefinedPanels()
		{
			base.CreatePredefinedPanels();

			EventLogPanel = new NDockingPanel();
			EventLogPanel.Key = "EventLogPanel";
			EventLogPanel.Text = "Event log";
			EventLogPanel.TabInfo.Text = "Event log";
			EventLogPanel.TabInfo.ImageIndex = 18;
			m_arrPredefinedPanels.Add(EventLogPanel);

			DiagramExplorerPanel = new NDockingPanel();
			DiagramExplorerPanel.Key = "DiagramExplorerPanel";
			DiagramExplorerPanel.Text = "Diagram explorer";
			DiagramExplorerPanel.TabInfo.Text = "Diagram explorer";
			DiagramExplorerPanel.TabInfo.ImageIndex = 19;
			m_arrPredefinedPanels.Add(DiagramExplorerPanel);

			DiagramDesignerPanel = new NDockingPanel();
			DiagramDesignerPanel.Key = "DiagramDesignerPanel";
			DiagramDesignerPanel.Text = "Diagram designer";
			DiagramDesignerPanel.TabInfo.Text = "Diagram designer";
			DiagramDesignerPanel.TabInfo.ImageIndex = 20;
			DiagramDesignerPanel.SizeInfo.SizeLogic = SizeLogic.FillInterior;
			m_arrPredefinedPanels.Add(DiagramDesignerPanel);
		}

		#endregion

		#region Fields

		public NDockingPanel EventLogPanel;
		public NDockingPanel DiagramExplorerPanel;
		public NDockingPanel DiagramDesignerPanel;

		#endregion
	}
}
