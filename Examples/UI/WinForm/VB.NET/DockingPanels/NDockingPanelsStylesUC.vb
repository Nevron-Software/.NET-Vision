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
	''' Summary description for NDockingPanelsStylesUC.
	''' </summary>
	Public Class NDockingPanelsStylesUC
		Inherits NDockingPanelsBasicFeaturesUC
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			' This call is required by the Windows.Forms Form Designer.
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

			m_ExampleFormType = GetType(NStylesForm)
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
	''' Summary description for NStylesForm.
	''' </summary>
	Public Class NStylesForm
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
			panel.Text = "Properties"
			panel.TabInfo.Text = "Properties"
			panel.TabInfo.ImageIndex = 3

			m_PropertyBrowser.Visible = True

			m_PropertyBrowser.Dock = DockStyle.Fill
			panel.Controls.Add(m_PropertyBrowser)
			host.AddChild(panel)
			m_Container.RootZone.AddChild(host)
		End Sub

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)

			PopulateStylesCombo()
		End Sub


		#End Region

		#Region "Implementation"

		Friend Sub PopulateStylesCombo()
			nComboBox1.Items.Clear()
			AddHandler nComboBox1.SelectedIndexChanged, AddressOf OnComboSelectedIndexChanged

			nComboBox1.Items.Add(m_DockManager.CaptionStyle)
			nComboBox1.Items.Add(m_DockManager.SplitterStyle)
			nComboBox1.Items.Add(m_DockManager.TabStyle)

			nComboBox1.SelectedIndex = 0
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub OnComboSelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
			m_PropertyGrid.SelectedObject = nComboBox1.SelectedItem
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.Text = "Appearance Styles Example"
		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
