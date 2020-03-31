Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Docking

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NComplexLayoutForm.
	''' </summary>
	Public Class NComplexLayoutForm
		Inherits NDockingPanelsExampleForm
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub
		Protected Overrides Sub InitPanels()
			Dim zone As NDockZone
			Dim panelHost As NDockingPanelHost

			zone = New NDockZone(Orientation.Vertical)
			panelHost = New NDockingPanelHost()
			panelHost.AddChild(GetGenericPanel())
			zone.AddChild(panelHost)

			panelHost = New NDockingPanelHost()
			panelHost.AddChild(GetGenericPanel())
			zone.AddChild(panelHost)

			m_Container.RootZone.AddChild(zone)

			zone = New NDockZone(Orientation.Vertical)

			panelHost = New NDockingPanelHost()
			panelHost.AddChild(GetGenericPanel())
			panelHost.AddChild(GetGenericPanel())
			zone.AddChild(panelHost)

			m_Container.RootZone.AddChild(zone)

			zone = New NDockZone(Orientation.Vertical)
			panelHost = New NDockingPanelHost()
			panelHost.AddChild(GetGenericPanel())
			panelHost.AddChild(GetGenericPanel())
			zone.AddChild(panelHost)

			panelHost = New NDockingPanelHost()
			panelHost.AddChild(GetGenericPanel())
			zone.AddChild(panelHost)

			panelHost = New NDockingPanelHost()
			panelHost.AddChild(GetGenericPanel())
			panelHost.AddChild(GetGenericPanel())
			zone.AddChild(panelHost)

			m_Container.RootZone.AddChild(zone)
		End Sub

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)

			m_DockManager.Panels(0).AutoHide()
			m_DockManager.Panels(2).AutoHide()
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.Text = "Complex Layout Example"
		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
