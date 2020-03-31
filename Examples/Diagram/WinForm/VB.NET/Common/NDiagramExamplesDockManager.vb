Imports Microsoft.VisualBasic
Imports System
Imports System.Collections

Imports Nevron.UI.WinForm.Docking
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NDiagramExamplesDockManager.
	''' </summary>
	Public Class NDiagramExamplesDockManager
		Inherits NExamplesDockManager
		#Region "Constructors"

		Public Sub New()
		End Sub

		#End Region

		#Region "Overrides"

		Protected Overrides Sub CreatePredefinedPanels()
			MyBase.CreatePredefinedPanels()

			EventLogPanel = New NDockingPanel()
			EventLogPanel.Key = "EventLogPanel"
			EventLogPanel.Text = "Event log"
			EventLogPanel.TabInfo.Text = "Event log"
			EventLogPanel.TabInfo.ImageIndex = 18
			m_arrPredefinedPanels.Add(EventLogPanel)

			DiagramExplorerPanel = New NDockingPanel()
			DiagramExplorerPanel.Key = "DiagramExplorerPanel"
			DiagramExplorerPanel.Text = "Diagram explorer"
			DiagramExplorerPanel.TabInfo.Text = "Diagram explorer"
			DiagramExplorerPanel.TabInfo.ImageIndex = 19
			m_arrPredefinedPanels.Add(DiagramExplorerPanel)

			DiagramDesignerPanel = New NDockingPanel()
			DiagramDesignerPanel.Key = "DiagramDesignerPanel"
			DiagramDesignerPanel.Text = "Diagram designer"
			DiagramDesignerPanel.TabInfo.Text = "Diagram designer"
			DiagramDesignerPanel.TabInfo.ImageIndex = 20
			DiagramDesignerPanel.SizeInfo.SizeLogic = SizeLogic.FillInterior
			m_arrPredefinedPanels.Add(DiagramDesignerPanel)
		End Sub

		#End Region

		#Region "Fields"

		Public EventLogPanel As NDockingPanel
		Public DiagramExplorerPanel As NDockingPanel
		Public DiagramDesignerPanel As NDockingPanel

		#End Region
	End Class
End Namespace
