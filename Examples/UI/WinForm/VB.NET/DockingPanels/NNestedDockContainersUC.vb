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
	''' Summary description for NNestedContainersUC.
	''' </summary>
	Public Class NNestedDockContainersUC
		Inherits NDockingPanelsBasicFeaturesUC
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
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
		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_ExampleFormType = GetType(NNestedContainersForm)
		End Sub



		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			components = New System.ComponentModel.Container()
		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class

	''' <summary>
	''' Summary description for NComplexLayoutForm.
	''' </summary>
	Public Class NNestedContainersForm
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

			Dim panel As NDockingPanel = New NDockingPanel()
			panelHost = New NDockingPanelHost()
			panelHost.AddChild(panel)

			m_Container.RootZone.AddChild(panelHost)

			Dim container As NDockingPanelContainer = m_DockManager.AddContainer(DockStyle.Fill)
			container.RootZone.Orientation = Orientation.Vertical
			container.BackColor = Color.Red
			container.DockPadding.All = 10
			panel.Controls.Add(container)

			panelHost = New NDockingPanelHost()
			panelHost.AddChild(GetGenericPanel())
			panelHost.AddChild(GetGenericPanel())
			container.RootZone.AddChild(panelHost)
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.Text = "Nested Containers Example"
		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
