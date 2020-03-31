using System;
using System.Reflection;

using Nevron.UI;
using Nevron.Examples.Framework.WinForm;

using Nevron.Diagram.WinForm.Commands;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NDiagramExamplesConfig.
	/// </summary>
	public class NDiagramExamplesConfig : NExamplesConfig
	{
		#region Constructor

		public NDiagramExamplesConfig()
		{
		}


		#endregion

		#region Overrides

		public override void InitDefault()
		{
			base.InitDefault();

			m_SplashImage = NResourceHelper.BitmapFromResource(typeof(NMainForm), "DiagramSplash.png", "Nevron.Examples.Diagram.WinForm.Resources");

			m_sExamplesNamespace = "Nevron.Examples.Diagram.WinForm";
			m_sTreeResource = "ExamplesTree.xml";
			m_sTreeResourcePath = "Nevron.Examples.Diagram.WinForm.Resources";
			m_sFormText = "Nevron Diagram for Windows Forms - Part of Nevron .NET Vision - Examples";

			m_FormIcon = NResourceHelper.IconFromResource(typeof(NMainForm), "Diagram.ico", "Nevron.Examples.Diagram.WinForm.Resources");

			m_sFeedbackString = "mailto:support@nevron.com?subject=Diagram Feedback";

			m_iExampleTreeNodeImageIndex = 11;
			m_iExampleTreeNodeSelectedImageIndex = 12;
		
			m_EmbeddedResourcesAssembly = this.GetType().Assembly;
			m_LayoutStrategy = new NDiagramExamplesLayoutStrategy();

			ProductLogo = NResourceHelper.BitmapFromResource(typeof(NMainForm), "DiagramLogo.png", "Nevron.Examples.Diagram.WinForm.Resources");
			ProductName = "Nevron Diagram for .NET";
			ProductAssemblies = new System.Reflection.Assembly[]{typeof(NDiagramCommandBarsManager).Assembly};
		}


		#endregion
	}
}