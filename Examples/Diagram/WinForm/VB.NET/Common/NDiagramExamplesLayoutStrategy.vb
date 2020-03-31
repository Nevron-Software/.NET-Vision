Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Docking
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NDiagramExamplesLayoutStrategy.
	''' </summary>
	Public Class NDiagramExamplesLayoutStrategy
		Inherits NExamplesLayoutStrategy
		#Region "Constructor"

		Public Sub New()
		End Sub

		#End Region

		#Region "Overrides"

		Protected Overrides Function GetMainZone(ByVal dockManager As NExamplesDockManager) As INDockZone
			Dim zone As INDockZone = New NDockZone(Orientation.Vertical)

			WideScreenExampleZone = New NDockZone()
			WideScreenExampleZone.Referenced = True
			zone.AddChild(WideScreenExampleZone)

			Dim host As INDockZone = New NDockingPanelHost()
			host.SizeInfo.SizeLogic = SizeLogic.FillInterior
'			NDockingPanel panel = new NDockingPanel();

			host.AddChild((TryCast(dockManager, NDiagramExamplesDockManager)).DiagramDesignerPanel)

			host.AddChild(dockManager.m_DescriptionPanel)
			host.AddChild(dockManager.m_ViewSourcePanel)

			zone.AddChild(host)

			Return zone
		End Function

		Protected Overrides Function GetExampleZone(ByVal dockManager As NExamplesDockManager) As INDockZone
			Dim host As INDockZone = MyBase.GetExampleZone(dockManager)
			host.AddChild((TryCast(dockManager, NDiagramExamplesDockManager)).EventLogPanel)
			host.AddChild((TryCast(dockManager, NDiagramExamplesDockManager)).DiagramExplorerPanel)

			Return host
		End Function

		#End Region

		#Region "Fields"
		Public WideScreenExampleZone As INDockZone = Nothing
		#End Region
	End Class
End Namespace
