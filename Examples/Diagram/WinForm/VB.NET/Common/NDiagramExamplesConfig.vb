Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection

Imports Nevron.UI
Imports Nevron.Examples.Framework.WinForm

Imports Nevron.Diagram.WinForm.Commands

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NDiagramExamplesConfig.
	''' </summary>
	Public Class NDiagramExamplesConfig
		Inherits NExamplesConfig
		#Region "Constructor"

		Public Sub New()
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Sub InitDefault()
			MyBase.InitDefault()

			m_SplashImage = NResourceHelper.BitmapFromResource(GetType(NMainForm), "DiagramSplash.png", "Nevron.Examples.Diagram.WinForm.Resources")

			m_sExamplesNamespace = "Nevron.Examples.Diagram.WinForm"
			m_sTreeResource = "ExamplesTree.xml"
			m_sTreeResourcePath = "Nevron.Examples.Diagram.WinForm.Resources"
			m_sFormText = "Nevron Diagram for Windows Forms - Part of Nevron .NET Vision - Examples"

			m_FormIcon = NResourceHelper.IconFromResource(GetType(NMainForm), "Diagram.ico", "Nevron.Examples.Diagram.WinForm.Resources")

			m_sFeedbackString = "mailto:support@nevron.com?subject=Diagram Feedback"

			m_iExampleTreeNodeImageIndex = 11
			m_iExampleTreeNodeSelectedImageIndex = 12

			m_EmbeddedResourcesAssembly = Me.GetType().Assembly
			m_LayoutStrategy = New NDiagramExamplesLayoutStrategy()

			ProductLogo = NResourceHelper.BitmapFromResource(GetType(NMainForm), "DiagramLogo.png", "Nevron.Examples.Diagram.WinForm.Resources")
			ProductName = "Nevron Diagram for .NET"
			ProductAssemblies = New System.Reflection.Assembly(){GetType(NDiagramCommandBarsManager).Assembly}
		End Sub


		#End Region
	End Class
End Namespace