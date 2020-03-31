Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NDockingPanelsExampleForm.
	''' </summary>
	Public Class NDockingPanelsExampleForm
		Inherits NForm
		#Region "Constructor"

		Public Sub New()
			m_iLockUpdate += 1

			InitializeComponent()

			m_DockManager = New NDockManager()
			m_DockManager.DisposePanelsOnClose = False
			m_DockManager.Palette.Copy(NUIManager.Palette)
			m_DockManager.Form = Me
			m_Container = m_DockManager.RootContainer
			m_DockManager.ImageList = MainForm.DockingImages

			nCommandBarsManager1.ImageList = MainForm.DockingImages
			nCommandBarsManager1.AllowCustomize = False
			nMenuBar1.HasGripper = False
			nCommand2.Properties.ID = -5

			InitPanels()
			InitDocumentView()

			m_Container.BringToFront()

			m_ClickEH = New CommandEventHandler(AddressOf OnPanelCommandClicked)

			SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				m_DockManager.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)

			Dim pall As NPalette = NUIManager.Palette
			nCommandBarsManager1.Palette.Copy(pall)
			ApplyPalette(pall)

			InitCommandBars()

			m_iLockUpdate -= 1
		End Sub


		#End Region

		#Region "Overridables"

		Protected Overridable Sub InitCommandBars()
			Dim menu As NMenuBar = nCommandBarsManager1.Toolbars.GetMenu()
			menu.AllowHide = False
			menu.AllowDelete = False
			menu.AllowReset = False

			AddHandler nCommandBarsManager1.CommandClicked, AddressOf nCommandBarsManager1_CommandClicked
			AddHandler nCommandBarsManager1.QueryCommandUIState, AddressOf nCommandBarsManager1_QueryCommandUIState
		End Sub
		Protected Overridable Sub InitPanels()
			Dim zone As NDockZone
			Dim panel As NDockingPanel
			Dim panelHost As NDockingPanelHost

			zone = New NDockZone(Orientation.Vertical)
			panelHost = New NDockingPanelHost()
			panelHost.AddChild(GetGenericPanel())
			zone.AddChild(panelHost)

			m_Container.RootZone.AddChild(zone)

			panel = GetGenericPanel()
			panel.TabInfo.ImageIndex = 1

			panelHost = New NDockingPanelHost()
			panelHost.AddChild(panel)
			zone.AddChild(panelHost)
		End Sub
		Protected Overridable Function InitPropertyBrowser() As NDockingPanel
			Dim panel As NDockingPanel = New NDockingPanel()
			panel.Text = "Properties"
			panel.TabInfo.Text = "Properties"
			panel.TabInfo.ImageIndex = 3
			m_PropertyBrowser.Dock = DockStyle.Fill
			panel.Controls.Add(m_PropertyBrowser)

			Return panel
		End Function


		#End Region

		#Region "Implementation"

		Friend Shared Function GetTextBox() As TextBox
			Dim tb As TextBox = New TextBox()
			tb.Multiline = True
			tb.Dock = DockStyle.Fill
			tb.BorderStyle = BorderStyle.None

			Return tb
		End Function
		Friend Function GetGenericPanel() As NDockingPanel
			Dim panel As NDockingPanel = New NDockingPanel()
			panel.Controls.Add(GetTextBox())
			panel.TabInfo.ImageIndex = 0
			panel.Key = "Docking Panel " & m_iIndex.ToString()

			m_iIndex += 1

			Return panel
		End Function

		Friend Sub InitDocumentView()
			m_Client.Dock = DockStyle.Fill

			Dim doc As NUIDocument = New NUIDocument()
			doc.Client = m_Client
			m_DockManager.DocumentManager.AddDocument(doc)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nCommandBarsManager1_CommandPopup(ByVal sender As Object, ByVal e As CommandEventArgs) Handles nCommandBarsManager1.CommandPopup
			Dim comm As NCommand = e.Command
			If comm.Properties.ID <> -5 Then
				Return
			End If

			comm.Commands.DisposeChildren()

			Dim panels As INDockingPanel() = m_DockManager.Panels
			Dim panel As INDockingPanel
			Dim comm1 As NCommand
			Dim length As Integer = panels.Length

			Dim i As Integer = 0
			Do While i < length
				panel = panels(i)

				comm1 = New NCommand()
				comm1.Properties.Text = panel.Text
				comm1.Properties.ImageList = MainForm.DockingImages
				comm1.Properties.ImageIndex = panel.TabInfo.ImageIndex
				comm1.Properties.Tag = panel
				comm1.Checked = panel.DockState <> DockState.Hidden
				AddHandler comm1.Click, m_ClickEH

				comm.Commands.Add(comm1)
				i += 1
			Loop
		End Sub

		Protected Overridable Sub nCommandBarsManager1_CommandClicked(ByVal sender As Object, ByVal e As CommandEventArgs)
		End Sub
		Protected Overridable Sub nCommandBarsManager1_QueryCommandUIState(ByVal sender As Object, ByVal e As QueryCommandUIStateEventArgs)
		End Sub
		Private Sub OnPanelCommandClicked(ByVal sender As Object, ByVal args As CommandEventArgs)
			Dim comm As NCommand = args.Command
			Dim panel As INDockingPanel = TryCast(comm.Properties.Tag, INDockingPanel)
			If panel Is Nothing Then
				Return
			End If

			If comm.Checked Then
				panel.Close()
			Else
				panel.Display()
			End If
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.m_PropertyBrowser = New System.Windows.Forms.Panel()
			Me.m_PropertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.panel2 = New System.Windows.Forms.Panel()
			Me.nComboBox1 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_Client = New System.Windows.Forms.TextBox()
			Me.nCommandBarsManager1 = New Nevron.UI.WinForm.Controls.NCommandBarsManager(Me.components)
			Me.nMenuBar1 = New Nevron.UI.WinForm.Controls.NMenuBar()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommandContext1 = New Nevron.UI.WinForm.Controls.NCommandContext()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.m_PropertyBrowser.SuspendLayout()
			Me.panel2.SuspendLayout()
			CType(Me.nCommandBarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' m_PropertyBrowser
			' 
			Me.m_PropertyBrowser.Controls.Add(Me.m_PropertyGrid)
			Me.m_PropertyBrowser.Controls.Add(Me.panel2)
			Me.m_PropertyBrowser.Location = New System.Drawing.Point(224, 104)
			Me.m_PropertyBrowser.Name = "m_PropertyBrowser"
			Me.m_PropertyBrowser.Size = New System.Drawing.Size(128, 120)
			Me.m_PropertyBrowser.TabIndex = 0
			Me.m_PropertyBrowser.Visible = False
			' 
			' m_PropertyGrid
			' 
			Me.m_PropertyGrid.CommandsVisibleIfAvailable = True
			Me.m_PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
			Me.m_PropertyGrid.LargeButtons = False
			Me.m_PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.m_PropertyGrid.Location = New System.Drawing.Point(0, 24)
			Me.m_PropertyGrid.Name = "m_PropertyGrid"
			Me.m_PropertyGrid.Size = New System.Drawing.Size(128, 96)
			Me.m_PropertyGrid.TabIndex = 2
			Me.m_PropertyGrid.Text = "propertyGrid1"
			Me.m_PropertyGrid.ToolbarVisible = False
			Me.m_PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window
			Me.m_PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' panel2
			' 
			Me.panel2.Controls.Add(Me.nComboBox1)
			Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel2.Location = New System.Drawing.Point(0, 0)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(128, 24)
			Me.panel2.TabIndex = 1
			' 
			' nComboBox1
			' 
			Me.nComboBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nComboBox1.Location = New System.Drawing.Point(0, 0)
			Me.nComboBox1.Name = "nComboBox1"
			Me.nComboBox1.Size = New System.Drawing.Size(128, 22)
			Me.nComboBox1.TabIndex = 0
			Me.nComboBox1.Text = "nComboBox1"
			' 
			' m_Client
			' 
			Me.m_Client.Location = New System.Drawing.Point(8, 136)
			Me.m_Client.Multiline = True
			Me.m_Client.Name = "m_Client"
			Me.m_Client.Size = New System.Drawing.Size(128, 40)
			Me.m_Client.TabIndex = 1
			Me.m_Client.Text = ""
			Me.m_Client.Visible = False
			' 
			' nCommandBarsManager1
			' 
			Me.nCommandBarsManager1.ParentControl = Me
			Me.nCommandBarsManager1.Toolbars.Add(Me.nMenuBar1)
'			Me.nCommandBarsManager1.CommandPopup += New Nevron.UI.WinForm.Controls.CommandEventHandler(Me.nCommandBarsManager1_CommandPopup);
			' 
			' nMenuBar1
			' 
			Me.nMenuBar1.AutoDropDownDelay = False
			Me.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent
			Me.nMenuBar1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand2})
			Me.nMenuBar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.Text
			Me.nMenuBar1.DefaultLocation = New System.Drawing.Point(0, 0)
			Me.nMenuBar1.HasGripper = False
			Me.nMenuBar1.HasPendantCommand = False
			Me.nMenuBar1.Name = "nMenuBar1"
			Me.nMenuBar1.PrefferedRowIndex = 0
			Me.nMenuBar1.RowIndex = 0
			Me.nMenuBar1.ShowTooltips = False
			Me.nMenuBar1.Text = "Menu Bar"
			' 
			' nCommand2
			' 
			Me.nCommand2.Properties.DropDownBehavior = Nevron.UI.WinForm.Controls.DropDownBehavior.AlwaysDropDown
			Me.nCommand2.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never
			Me.nCommand2.Properties.Text = "Panels"
			' 
			' NDockingPanelsExampleForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(794, 567)
			Me.Controls.Add(Me.m_Client)
			Me.Controls.Add(Me.m_PropertyBrowser)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
			Me.Name = "NDockingPanelsExampleForm"
			Me.Text = "NDockingPanelsExampleForm"
			Me.m_PropertyBrowser.ResumeLayout(False)
			Me.panel2.ResumeLayout(False)
			CType(Me.nCommandBarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.IContainer
		Friend m_PropertyBrowser As System.Windows.Forms.Panel
		Friend nComboBox1 As Nevron.UI.WinForm.Controls.NComboBox
		Private panel2 As System.Windows.Forms.Panel
		Friend m_PropertyGrid As System.Windows.Forms.PropertyGrid
		Friend m_Client As System.Windows.Forms.TextBox
		Friend WithEvents nCommandBarsManager1 As Nevron.UI.WinForm.Controls.NCommandBarsManager
		Private nCommandContext1 As Nevron.UI.WinForm.Controls.NCommandContext
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand

		Private m_iIndex As Integer

		Friend m_DockManager As NDockManager
		Friend m_iLockUpdate As Integer
		Friend m_Container As NDockingPanelContainer
		Private nMenuBar1 As Nevron.UI.WinForm.Controls.NMenuBar
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private m_ClickEH As CommandEventHandler

		#End Region
	End Class
End Namespace
