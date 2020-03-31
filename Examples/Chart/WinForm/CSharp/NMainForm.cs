using System;
using System.Drawing;
using System.Windows.Forms;
using Nevron.Chart.WinForm;
using Nevron.Examples.Framework.WinForm;
using Nevron.UI.WinForm.Docking;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Chart.WinForm
{
	public class NMainForm : NExamplesForm
	{
		#region Fields

		internal NChartControl chartControl;
		internal NChartCommandBarsManager chartCommandBarsManager;
		internal ExampleLayout m_CurrentLayout = ExampleLayout.Standard;

		#endregion

		#region Constructors

		public NMainForm()
		{
			InitializeComponent();

			InitFromConfig(new NChartExamplesConfig());

			this.StartPosition = FormStartPosition.CenterScreen;
			this.WindowState = FormWindowState.Maximized;

			this.chartControl = new Nevron.Chart.WinForm.NChartControl();

			this.chartCommandBarsManager = new NChartCommandBarsManager();
			this.chartCommandBarsManager.ChartControl = chartControl;
			this.chartCommandBarsManager.ParentControl = this.MainControlHost;
			this.chartCommandBarsManager.AllowCustomize = false;
			this.chartCommandBarsManager.ContextMenuEnabled = true;
			SetupToolbarCommands();

			this.MainControlHost.Controls.Add(chartControl);

			this.chartControl.Dock = DockStyle.Fill;
			this.chartControl.BringToFront();

		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Name = "MainForm";
			this.Text = "Nevron Chart for .NET - C# examples";
		}

		#endregion

		#region Main
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			NMainForm form = new NMainForm();

			Application.Run(form);
		}

		#endregion

		#region Overrides

		protected override void OnFormLoading()
		{
			base.OnFormLoading();

			this.DockManager.m_ControlHost.SizeInfo.SizeLogic = SizeLogic.FillInterior;
		}

		protected override void ClearExample(bool clearAll)
		{
			base.ClearExample(clearAll);

			this.chartControl.Clear();
			this.chartControl.ServiceManager.LegendUpdateService.Start();
			this.chartControl.DisposeEvents();
		}

		protected override void LoadExample(NExampleEntity example)
		{
			base.LoadExample(example);
			this.chartControl.Refresh();
		}

		protected override void LayoutExample()
		{
			NExampleBaseUC uc = CurrentExampleControl as NExampleBaseUC;

			if(uc == null)
				return;

			int nWidth = uc.Width + 10;
			int nHeight = uc.Height + 60;

			ExampleLayout newLayout = (nWidth > 330) ? ExampleLayout.WideScreen : ExampleLayout.Standard;

			if (m_CurrentLayout == newLayout)
			{
				if (ExamplePanel.ParentZone != null)
				{
					if (newLayout == ExampleLayout.WideScreen)
					{
						ExamplePanel.SizeInfo.AbsoluteSize = new Size(0, nHeight);
					}
					else if(newLayout == ExampleLayout.Standard)
					{
						ExamplePanel.SizeInfo.AbsoluteSize = new Size(nWidth, 0);
					}
				}
			}
			else
			{
				m_CurrentLayout = newLayout;

				NDockingPanelContainer mainContainer = DockManager.MainContainer;

				if(newLayout == ExampleLayout.WideScreen)
				{
					INDockZone zone = DockManager.m_ControlHost.ParentZone;
					NDockingPanelHost dpHost = FindDockingPanelHostInZone(zone);

					if(dpHost != null)
					{
						ExamplePanel.PerformDock(dpHost, DockStyle.Fill, 0);
					}
					else
					{
						ExamplePanel.PerformDock(zone, DockStyle.Bottom, 0);
					}

					ExamplePanel.SizeInfo.AbsoluteSize = new Size(0, nHeight);
				}
				else if(newLayout == ExampleLayout.Standard)
				{
					ExamplePanel.PerformDock(mainContainer.RootZone, DockStyle.Right, 0);
					ExamplePanel.SizeInfo.AbsoluteSize = new Size(nWidth, 0);
				}
			}
		}

		protected override NExampleUserControl CreateExampleControl(NExampleEntity example)
		{
			NExampleBaseUC uc = (NExampleBaseUC)base.CreateExampleControl(example);

			uc.nChartControl1 = chartControl;

			return uc;
		}

		#endregion

		#region Implementation

		private NDockingPanelHost FindDockingPanelHostInZone(INDockZone zone)
		{
			if(zone == null)
				return null;

			if(zone.LayoutInfo.Orientation != Orientation.Vertical)
				return null;

			foreach(INDockZoneChild child in zone.Children)
			{
				NDockingPanelHost host = child as NDockingPanelHost;

				if(host != null)
					return host;
			}

			return null;
		}
		private void SetupToolbarCommands()
		{
			return;

/*			chartCommandBarsManager.Toolbars["Aspect"].Visible = false;
			chartCommandBarsManager.Toolbars["Panel"].Visible = false;
			chartCommandBarsManager.Toolbars["Format"].Visible = false;

			NCommandCollection standardCommands = chartCommandBarsManager.Toolbars["Standard"].Commands;
			standardCommands.RemoveAt(7);
			standardCommands.RemoveAt(6);
			standardCommands.RemoveAt(5);
			standardCommands.RemoveAt(1);
			standardCommands.RemoveAt(0);

			NCommandCollection toolsCommands = chartCommandBarsManager.Toolbars["Tools"].Commands;
			toolsCommands.RemoveAt(3);
			toolsCommands.RemoveAt(2);

			NCommandCollection projectionCommands = chartCommandBarsManager.Toolbars["Projection"].Commands;
			projectionCommands.RemoveAt(12);
			projectionCommands.RemoveAt(8);
			projectionCommands.RemoveAt(7);
			projectionCommands.RemoveAt(6);
			projectionCommands.RemoveAt(5);
			projectionCommands.RemoveAt(4);
			projectionCommands.RemoveAt(3);
			projectionCommands.RemoveAt(2);
			projectionCommands.RemoveAt(1);

			for (int i = 0; i < chartCommandBarsManager.Toolbars.Count; i++)
			{
				NDockingToolbar toolbar = chartCommandBarsManager.Toolbars[i];
				toolbar.HasPendantCommand = false;
				toolbar.AllowHide = false;
				toolbar.AllowDelete = false;
				toolbar.RowIndex = 0;
			}*/
		}

		#endregion
	}
}