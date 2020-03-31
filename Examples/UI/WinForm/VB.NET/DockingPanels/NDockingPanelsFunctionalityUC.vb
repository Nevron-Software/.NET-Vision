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
	''' Summary description for NDockingPanelsFunctionality.
	''' </summary>
	Public Class NDockingPanelsFunctionalityUC
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

			m_ExampleFormType = GetType(NFunctionalityForm)
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
	''' Summary description for NFunctionalityForm.
	''' </summary>
	Public Class NFunctionalityForm
		Inherits NDockingPanelsExampleForm
		#Region "Constructor"

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
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

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)

			Dim c As Control = TryCast(m_DockManager.Panels(0), Control)
			m_Panel.Dock = DockStyle.Fill
			c.Controls.Add(m_Panel)

			m_DockManager.LockPanels()
			AddHandler m_DockManager.PanelActivated, AddressOf m_DockManager_PanelActivated

			UpdateFunctionalityButtons()
		End Sub

		Protected Overrides Sub InitPanels()
			Dim panelHost As NDockingPanelHost

			panelHost = New NDockingPanelHost()
			panelHost.SizeInfo.SizeLogic = SizeLogic.Absolute
			panelHost.SizeInfo.AbsoluteSize = New Size(200, 0)
			panelHost.AddChild(New NDockingPanel())

			m_Container.RootZone.AddChild(panelHost)
		End Sub


		#End Region

		#Region "Implementation"

		Friend ReadOnly Property SelectedPanel() As INDockingPanel
			Get
				Dim panel As INDockingPanel = m_DockManager.Panels(0)
				Return panel
			End Get
		End Property
		Friend Sub UpdateFunctionalityButtons()
			Dim selected As INDockingPanel = SelectedPanel
			Dim state As DockState = selected.DockState

			Select Case state
				Case DockState.AutoHide
					m_FloatButton.Enabled = False
					m_HideButton.Enabled = True
					m_DockButton.Enabled = True
					m_AutoHideButton.Enabled = False
				Case DockState.Docked
					m_DockButton.Enabled = False
					m_AutoHideButton.Enabled = True
					m_FloatButton.Enabled = True
					m_HideButton.Enabled = True
				Case DockState.Floating
					m_DockButton.Enabled = True
					m_HideButton.Enabled = True
					m_AutoHideButton.Enabled = False
					m_FloatButton.Enabled = False
				Case DockState.Unknown
					m_DockButton.Enabled = False
					m_HideButton.Enabled = False
					m_AutoHideButton.Enabled = False
					m_FloatButton.Enabled = False
			End Select
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_DockButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_DockButton.Click
			Dim selected As INDockingPanel = SelectedPanel
			If selected Is Nothing Then
				Return
			End If

			Dim state As DockState = selected.DockState
			If state <> DockState.Docked Then
				selected.Redock()
			End If

			UpdateFunctionalityButtons()
		End Sub

		Private Sub m_FloatButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FloatButton.Click
			Dim selected As INDockingPanel = SelectedPanel
			If selected Is Nothing Then
				Return
			End If

			Dim state As DockState = selected.DockState
			If state <> DockState.Floating Then
				selected.Float()
			End If

			UpdateFunctionalityButtons()
		End Sub

		Private Sub m_HideButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_HideButton.Click
			Dim selected As INDockingPanel = SelectedPanel
			If selected Is Nothing Then
				Return
			End If

			selected.Close()
			UpdateFunctionalityButtons()
		End Sub

		Private Sub m_AutoHideButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_AutoHideButton.Click
			Dim selected As INDockingPanel = SelectedPanel
			If selected Is Nothing Then
				Return
			End If

			Dim state As DockState = selected.DockState
			If state <> DockState.AutoHide Then
				selected.AutoHide()
			End If

			UpdateFunctionalityButtons()
		End Sub

		Private Sub m_DockManager_PanelActivated(ByVal sender As Object, ByVal e As PanelEventArgs)
			UpdateFunctionalityButtons()
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_Panel = New System.Windows.Forms.Panel()
			Me.m_FunctionalityPanel = New System.Windows.Forms.Panel()
			Me.m_AutoHideButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_HideButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_FloatButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_DockButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_Panel.SuspendLayout()
			Me.m_FunctionalityPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' m_Panel
			' 
			Me.m_Panel.Controls.Add(Me.m_FunctionalityPanel)
			Me.m_Panel.Location = New System.Drawing.Point(288, 240)
			Me.m_Panel.Name = "m_Panel"
			Me.m_Panel.Size = New System.Drawing.Size(104, 152)
			Me.m_Panel.TabIndex = 4
			' 
			' m_FunctionalityPanel
			' 
			Me.m_FunctionalityPanel.Controls.Add(Me.m_AutoHideButton)
			Me.m_FunctionalityPanel.Controls.Add(Me.m_HideButton)
			Me.m_FunctionalityPanel.Controls.Add(Me.m_FloatButton)
			Me.m_FunctionalityPanel.Controls.Add(Me.m_DockButton)
			Me.m_FunctionalityPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.m_FunctionalityPanel.Location = New System.Drawing.Point(0, 0)
			Me.m_FunctionalityPanel.Name = "m_FunctionalityPanel"
			Me.m_FunctionalityPanel.Size = New System.Drawing.Size(104, 152)
			Me.m_FunctionalityPanel.TabIndex = 2
			' 
			' m_AutoHideButton
			' 
			Me.m_AutoHideButton.Location = New System.Drawing.Point(8, 112)
			Me.m_AutoHideButton.Name = "m_AutoHideButton"
			Me.m_AutoHideButton.Size = New System.Drawing.Size(88, 24)
			Me.m_AutoHideButton.TabIndex = 3
			Me.m_AutoHideButton.Text = "Auto Hide"
'			Me.m_AutoHideButton.Click += New System.EventHandler(Me.m_AutoHideButton_Click);
			' 
			' m_HideButton
			' 
			Me.m_HideButton.Location = New System.Drawing.Point(8, 80)
			Me.m_HideButton.Name = "m_HideButton"
			Me.m_HideButton.Size = New System.Drawing.Size(88, 24)
			Me.m_HideButton.TabIndex = 2
			Me.m_HideButton.Text = "Hide"
'			Me.m_HideButton.Click += New System.EventHandler(Me.m_HideButton_Click);
			' 
			' m_FloatButton
			' 
			Me.m_FloatButton.Location = New System.Drawing.Point(8, 48)
			Me.m_FloatButton.Name = "m_FloatButton"
			Me.m_FloatButton.Size = New System.Drawing.Size(88, 24)
			Me.m_FloatButton.TabIndex = 1
			Me.m_FloatButton.Text = "Float"
'			Me.m_FloatButton.Click += New System.EventHandler(Me.m_FloatButton_Click);
			' 
			' m_DockButton
			' 
			Me.m_DockButton.Location = New System.Drawing.Point(8, 16)
			Me.m_DockButton.Name = "m_DockButton"
			Me.m_DockButton.Size = New System.Drawing.Size(88, 24)
			Me.m_DockButton.TabIndex = 0
			Me.m_DockButton.Text = "Dock"
'			Me.m_DockButton.Click += New System.EventHandler(Me.m_DockButton_Click);
			' 
			' NFunctionalityForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(760, 414)
			Me.Controls.Add(Me.m_Panel)
			Me.ForeColor = System.Drawing.SystemColors.ControlText
			Me.Name = "NFunctionalityForm"
			Me.Text = "Programmable Functionality Example"
			Me.Controls.SetChildIndex(Me.m_Panel, 0)
			Me.m_Panel.ResumeLayout(False)
			Me.m_FunctionalityPanel.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private m_Panel As System.Windows.Forms.Panel
		Private m_FunctionalityPanel As System.Windows.Forms.Panel
		Private WithEvents m_DockButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_FloatButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_HideButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_AutoHideButton As Nevron.UI.WinForm.Controls.NButton
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
