using System;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

using Nevron.Examples.Framework.WinForm;
using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;
using Nevron.UI;

namespace Nevron.Examples.UI.WinForm
{
	/// <summary>
	/// Summary description for NUIExamplesConfig.
	/// </summary>
	public class NUIExamplesConfig : NExamplesConfig
	{
		#region Constructor

		public NUIExamplesConfig()
		{
			SearchForVbSourceFiles = false;
		}


		#endregion

		#region Overrides

		public override void InitDefault()
		{
			base.InitDefault();

			ProductType = ENDotNetProductType.NETUserInterface;

			Type t = typeof(MainForm);
			string path = "Nevron.Examples.UI.WinForm.Resources";

			PersistFormState = false;
			//PersistPanelsState = false;
			WindowState = FormWindowState.Maximized;

			//specify about box
			m_SplashImage = NResourceHelper.BitmapFromResource(t, "UISplash.png", path);
			ProductLogo = NResourceHelper.BitmapFromResource(t, "UILogo.png", path);
			ProductName = "Nevron UI for .NET";
			ProductAssemblies = new System.Reflection.Assembly[]{typeof(NUIManager).Assembly, typeof(NDockManager).Assembly};

			m_FilterSearchResultsByParentTitles = new string[] {"C# Examples", "All Examples", "What's New"};

			m_EmbeddedResourcesAssembly = typeof(NUIExamplesConfig).Assembly;
			m_sExamplesNamespace = "Nevron.Examples.UI.WinForm";
			m_sTreeResource = "ExamplesTree.xml";
			m_sTreeResourcePath = path;

			m_FormIcon = NResourceHelper.IconFromResource(t, "UI.ico", path);
			m_sFormText = "Nevron User Interface - Part of Nevron .NET Vision - Examples";

			m_iExampleTreeNodeImageIndex = 13;
			m_iExampleTreeNodeSelectedImageIndex = 14;

			m_sFeedbackString = "mailto:support@nevron.com?subject=Nevron User Interface Feedback";

			m_LayoutStrategy = new NUIExamplesLayoutStrategy();
		}

		#endregion
	}
}
