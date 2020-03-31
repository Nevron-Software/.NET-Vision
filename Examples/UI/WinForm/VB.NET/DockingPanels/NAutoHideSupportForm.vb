Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NComplexLayoutForm.
	''' </summary>
	Public Class NAutoHideSupportForm
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
			MyBase.InitPanels()

			Dim host As NDockingPanelHost = New NDockingPanelHost()

			Dim panel As NDockingPanel = New NDockingPanel()

			m_PropertyGrid.Dock = DockStyle.Fill
			panel.Controls.Add(m_PropertyGrid)

			m_PropertyGrid.SelectedObject = panel.TabInfo

			host.AddChild(panel)
			m_Container.RootZone.AddChild(host)
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.Text = "Auto Hide Support Example"
		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
