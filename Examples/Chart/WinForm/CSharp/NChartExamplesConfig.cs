using System;
using System.Reflection;
using Nevron.UI;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.Chart.WinForm
{
	public class NChartExamplesConfig : NExamplesConfig
	{
		#region Constructor

		public NChartExamplesConfig()
		{
		}

		#endregion

		#region Overrides

		public override void InitDefault()
		{
			base.InitDefault();

			m_SplashImage = NResourceHelper.BitmapFromResource(this.GetType(), "ChartSplash.png", "Nevron.Examples.Chart.WinForm.Resources");

			m_sExamplesNamespace = "Nevron.Examples.Chart.WinForm";
			m_sTreeResource = "ExamplesTree.xml";
			m_sTreeResourcePath = "Nevron.Examples.Chart.WinForm.Resources";

			m_FilterSearchResultsByParentTitles = new string[] { "C# Examples", "All Examples", "What's New" };
			m_EmbeddedResourcesAssembly = typeof(NChartExamplesConfig).Assembly;

			m_FormIcon = NResourceHelper.IconFromResource(this.GetType(), "Chart.ico", "Nevron.Examples.Chart.WinForm.Resources");
			m_sFormText = "Nevron Chart for Windows Forms - Part of Nevron .NET Vision - Examples";

			m_bSearchForVbSourceFiles = false;
			m_iExampleTreeNodeImageIndex = 0;
			m_iExampleTreeNodeSelectedImageIndex = 1;

			m_sReportBugString = "mailto:support@nevron.com?subject=Chart Bug Report";
			m_sFeedbackString = "mailto:support@nevron.com?subject=Chart Feedback";

			this.LayoutStrategy = new NExamplesLayoutStrategy();

			ProductName = "Nevron Chart for .NET";
			ProductLogo = NResourceHelper.BitmapFromResource(this.GetType(), "ChartLogo.png", "Nevron.Examples.Chart.WinForm.Resources");
			ProductAssemblies = new System.Reflection.Assembly[]{ typeof(Nevron.Chart.WinForm.NChartControl).Assembly };
		}

		#endregion
	}
}
