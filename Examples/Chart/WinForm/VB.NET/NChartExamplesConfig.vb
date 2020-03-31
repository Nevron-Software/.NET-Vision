Imports System
Imports System.Reflection
Imports Nevron.UI
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.Chart.WinForm
	Public Class NChartExamplesConfig
		Inherits NExamplesConfig

		#Region "Constructor"

		Public Sub New()
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub InitDefault()
			MyBase.InitDefault()

			m_SplashImage = NResourceHelper.BitmapFromResource(Me.GetType(), "ChartSplash.png", "Nevron.Examples.Chart.WinForm.Resources")

			m_sExamplesNamespace = "Nevron.Examples.Chart.WinForm"
			m_sTreeResource = "ExamplesTree.xml"
			m_sTreeResourcePath = "Nevron.Examples.Chart.WinForm.Resources"

			m_FilterSearchResultsByParentTitles = New String() {"VB.NET Examples", "All Examples", "What's New"}
			m_EmbeddedResourcesAssembly = GetType(NChartExamplesConfig).Assembly

			m_FormIcon = NResourceHelper.IconFromResource(Me.GetType(), "Chart.ico", "Nevron.Examples.Chart.WinForm.Resources")
			m_sFormText = "Nevron Chart for Windows Forms - Part of Nevron .NET Vision - Examples"

			m_bSearchForVbSourceFiles = False
			m_iExampleTreeNodeImageIndex = 0
			m_iExampleTreeNodeSelectedImageIndex = 1

			m_sReportBugString = "mailto:support@nevron.com?subject=Chart Bug Report"
			m_sFeedbackString = "mailto:support@nevron.com?subject=Chart Feedback"

			Me.LayoutStrategy = New NExamplesLayoutStrategy()

			ProductName = "Nevron Chart for .NET"
			ProductLogo = NResourceHelper.BitmapFromResource(Me.GetType(), "ChartLogo.png", "Nevron.Examples.Chart.WinForm.Resources")
			ProductAssemblies = New System.Reflection.Assembly(){ GetType(Nevron.Chart.WinForm.NChartControl).Assembly }
		End Sub

		#End Region
	End Class
End Namespace
