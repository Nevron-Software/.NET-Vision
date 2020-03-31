Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection
Imports System.Windows.Forms
Imports System.IO

Imports Nevron.Examples.Framework.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking
Imports Nevron.UI

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NUIExamplesConfig.
	''' </summary>
	Public Class NUIExamplesConfig
		Inherits NExamplesConfig
		#Region "Constructor"

		Public Sub New()
			SearchForVbSourceFiles = False
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Sub InitDefault()
			MyBase.InitDefault()

			ProductType = ENDotNetProductType.NETUserInterface

			Dim t As Type = GetType(MainForm)
			Dim path As String = "Nevron.Examples.UI.WinForm.Resources"

			PersistFormState = False
			'PersistPanelsState = false;
			WindowState = FormWindowState.Maximized

			'specify about box
			m_SplashImage = NResourceHelper.BitmapFromResource(t, "UISplash.png", path)

			ProductLogo = NResourceHelper.BitmapFromResource(t, "UILogo.png", path)
			ProductName = "Nevron UI for .NET"
			ProductAssemblies = New System.Reflection.Assembly(){GetType(NUIManager).Assembly, GetType(NDockManager).Assembly}

			m_FilterSearchResultsByParentTitles = New String() {"C# Examples", "All Examples", "What's New In Version 4.0"}

			m_EmbeddedResourcesAssembly = GetType(NUIExamplesConfig).Assembly
			m_sExamplesNamespace = "Nevron.Examples.UI.WinForm"
			m_sTreeResource = "ExamplesTree.xml"
			m_sTreeResourcePath = path

			m_FormIcon = NResourceHelper.IconFromResource(t, "UI.ico", path)
			m_sFormText = "Nevron User Interface - Part of Nevron .NET Vision - Examples"

			m_iExampleTreeNodeImageIndex = 13
			m_iExampleTreeNodeSelectedImageIndex = 14

			m_sFeedbackString = "mailto:support@nevron.com?subject=Nevron User Interface Feedback"

			m_LayoutStrategy = New NUIExamplesLayoutStrategy()
		End Sub

		#End Region
	End Class
End Namespace
