Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Docking
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NUIExamplesLayout.
	''' </summary>
	Public Class NUIExamplesLayoutStrategy
		Inherits NExamplesLayoutStrategy
		#Region "Constructor"

		Public Sub New()
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Sub InitialLayout(ByVal dockManager As NExamplesDockManager)
			Dim root As INDockZone = dockManager.m_Container.RootZone
			dockManager.m_ExamplePanel.SizeInfo.SizeLogic = SizeLogic.FillInterior

			'add navigation zone to the root one
			root.AddChild(GetNavigationZone(dockManager))

			'the ui examples does not have main app control, so we do not need right zone
			root.AddChild(GetMainZone(dockManager))
		End Sub
		Protected Overrides Function GetMainZone(ByVal dockManager As NExamplesDockManager) As INDockZone
			Dim zone As NDockZone
			Dim host As NDockingPanelHost

			'create a zone with vertical orientation which will hold main control host and description/source/web panels
			zone = New NDockZone(Orientation.Vertical)

			'create a host for the example/source panel
			host = New NDockingPanelHost()
			host.SizeInfo.SizeLogic = SizeLogic.FillInterior
			host.AddChild(dockManager.m_ExamplePanel)
			host.AddChild(dockManager.m_ViewSourcePanel)
			'add it to the zone with vertical orientation
			zone.AddChild(host)

			'create a host for description/web panels
			host = New NDockingPanelHost()
			host.AddChild(dockManager.m_DescriptionPanel)

			'add the host to the zone
			zone.AddChild(host)

			Return zone
		End Function


		#End Region
	End Class
End Namespace

