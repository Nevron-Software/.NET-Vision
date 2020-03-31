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
	''' Summary description for NCommandModelForm.
	''' </summary>
	Public Class NCommandModelForm
		Inherits NForm
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Size = New Size(800, 600)

			AddCustomCommands()
			PopulateAvailableCommands()
			AddDocuments()

			nCommandBarsManager1.Palette.Copy(NUIManager.Palette)
			nDockManager1.Palette.Copy(NUIManager.Palette)
			Palette.Copy(NUIManager.Palette)

			m_ClickEH = New CommandEventHandler(AddressOf OnPanelCommandClicked)
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)
		End Sub

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				If Not nDockManager1 Is Nothing Then
					nDockManager1.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub PopulateAvailableCommands()
			m_AvailableCommandsCombo.Items.Clear()
			'm_AvailableCommandsCombo.DropDownWidth = 300;

			Dim commands As NDockingFrameworkCommand() = nDockManager1.Commander.Commands
			Dim length As Integer = commands.Length

			Dim comm As NDockingFrameworkCommand
			Dim item As NListBoxItem

			Dim i As Integer = 0
			Do While i < length
				comm = commands(i)

				item = New NListBoxItem()
				item.Text = comm.Name & " - ID: " & comm.ID
				item.Tag = comm
				m_AvailableCommandsCombo.Items.Add(item)
				i += 1
			Loop
		End Sub

		Private Sub AddCustomCommands()
			Dim comm As NDockingFrameworkCommand

			Dim eh As EventHandler = New EventHandler(AddressOf comm_Executed)

			comm = New NDockingFrameworkCommand(101, "Custom Command 1")
			AddHandler comm.Executed, eh
			nDockManager1.Commander.RegisterCommand(comm)

			comm = New NDockingFrameworkCommand(102, "Custom Command 2")
			AddHandler comm.Executed, eh
			nDockManager1.Commander.RegisterCommand(comm)
		End Sub
		Private Sub AddDocuments()
			Dim doc As NUIDocument

			For i As Integer = 1 To 4
				doc = New NUIDocument("Document " & i.ToString(), -1, NDockingPanelsExampleForm.GetTextBox())
				nDockManager1.DocumentManager.AddDocument(doc)
			Next i
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_AvailableCommandsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_AvailableCommandsCombo.SelectedIndexChanged
		End Sub

		Private Sub m_ExecuteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ExecuteButton.Click
			Dim comm As NDockingFrameworkCommand = TryCast(m_AvailableCommandsCombo.SelectedItem, NDockingFrameworkCommand)
			If comm Is Nothing Then
				Return
			End If

			comm.Execute(Nothing)
		End Sub

		Private Sub comm_Executed(ByVal sender As Object, ByVal e As EventArgs)
			Dim comm As NDockingFrameworkCommand = TryCast(sender, NDockingFrameworkCommand)
			MessageBox.Show("Custom command executed:" & Constants.vbLf + comm.Name)
		End Sub

		Private Sub nCommandBarsManager1_CommandPopup(ByVal sender As Object, ByVal e As CommandEventArgs) Handles nCommandBarsManager1.CommandPopup
			Dim comm As NCommand = e.Command
			If comm.Properties.ID <> 1 Then
				Return
			End If

			comm.Commands.DisposeChildren()

			Dim panels As INDockingPanel() = nDockManager1.Panels
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

		Private Sub nButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles nButton1.Click
			nDockManager1.Commander.ShowKeyboardEditor()
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim nDockZone0 As Nevron.UI.WinForm.Docking.NDockZone = New Nevron.UI.WinForm.Docking.NDockZone()
			Dim nDockZone1 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone3 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Me.nDockManager1 = New Nevron.UI.WinForm.Docking.NDockManager()
			Me.nDockingPanel1 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_AvailableCommandsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_ExecuteButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nCommandBarsManager1 = New Nevron.UI.WinForm.Controls.NCommandBarsManager(Me.components)
			Me.nMenuBar1 = New Nevron.UI.WinForm.Controls.NMenuBar()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand3 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nDockingPanel2 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDockingPanel1.SuspendLayout()
			' 
			' nDockManager1
			' 
			Me.nDockManager1.DocumentStyle.DocumentViewStyle = Nevron.UI.WinForm.Docking.DocumentViewStyle.MdiStandard
			Me.nDockManager1.Form = Me
			Me.nDockManager1.RootContainerZIndex = 0
			'  
			' Root Zone
			'  
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0)
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone3)
			Me.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Vertical
			'  
			' nDockZone0
			'  
			nDockZone0.AddChild(nDockZone1)
			nDockZone0.AddChild(Me.nDockManager1.DocumentManager.DocumentViewHost)
			nDockZone0.Name = "nDockZone0"
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone0.Index = 0
			nDockZone0.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 338)
			'  
			' nDockZone1
			'  
			nDockZone1.AddChild(Me.nDockingPanel1)
			nDockZone1.Name = "nDockZone1"
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone1.Index = 0
			nDockZone1.SizeInfo.PrefferedSize = New System.Drawing.Size(240, 200)
			'  
			' nDockZone3
			'  
			nDockZone3.AddChild(Me.nDockingPanel2)
			nDockZone3.Name = "nDockZone3"
			nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone3.Index = 1
			nDockZone3.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 135)
			' 
			' nDockingPanel1
			' 
			Me.nDockingPanel1.Controls.Add(Me.nButton1)
			Me.nDockingPanel1.Controls.Add(Me.label1)
			Me.nDockingPanel1.Controls.Add(Me.m_AvailableCommandsCombo)
			Me.nDockingPanel1.Controls.Add(Me.m_ExecuteButton)
			Me.nDockingPanel1.Name = "nDockingPanel1"
			Me.nDockingPanel1.SizeInfo.PrefferedSize = New System.Drawing.Size(240, 200)
			Me.nDockingPanel1.TabIndex = 1
			Me.nDockingPanel1.Text = "Properties"
			' 
			' nButton1
			' 
			Me.nButton1.Location = New System.Drawing.Point(8, 112)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.Size = New System.Drawing.Size(224, 32)
			Me.nButton1.TabIndex = 3
			Me.nButton1.Text = "Keyboard..."
'			Me.nButton1.Click += New System.EventHandler(Me.nButton1_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(144, 23)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Available Commands:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' m_AvailableCommandsCombo
			' 
			Me.m_AvailableCommandsCombo.DropDownWidth = 300
			Me.m_AvailableCommandsCombo.Location = New System.Drawing.Point(8, 32)
			Me.m_AvailableCommandsCombo.Name = "m_AvailableCommandsCombo"
			Me.m_AvailableCommandsCombo.Size = New System.Drawing.Size(224, 22)
			Me.m_AvailableCommandsCombo.TabIndex = 1
			Me.m_AvailableCommandsCombo.Text = "nComboBox1"
'			Me.m_AvailableCommandsCombo.SelectedIndexChanged += New System.EventHandler(Me.m_AvailableCommandsCombo_SelectedIndexChanged);
			' 
			' m_ExecuteButton
			' 
			Me.m_ExecuteButton.Location = New System.Drawing.Point(160, 64)
			Me.m_ExecuteButton.Name = "m_ExecuteButton"
			Me.m_ExecuteButton.Size = New System.Drawing.Size(72, 24)
			Me.m_ExecuteButton.TabIndex = 0
			Me.m_ExecuteButton.Text = "Execute"
'			Me.m_ExecuteButton.Click += New System.EventHandler(Me.m_ExecuteButton_Click);
			' 
			' nCommandBarsManager1
			' 
			Me.nCommandBarsManager1.ParentControl = Me
			Me.nCommandBarsManager1.Toolbars.Add(Me.nMenuBar1)
'			Me.nCommandBarsManager1.CommandPopup += New Nevron.UI.WinForm.Controls.CommandEventHandler(Me.nCommandBarsManager1_CommandPopup);
			' 
			' nMenuBar1
			' 
			Me.nMenuBar1.AllowDelete = False
			Me.nMenuBar1.AllowHide = False
			Me.nMenuBar1.AllowRename = False
			Me.nMenuBar1.AutoDropDownDelay = False
			Me.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent
			Me.nMenuBar1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand1, Me.nCommand3})
			Me.nMenuBar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.Text
			Me.nMenuBar1.DefaultLocation = New System.Drawing.Point(0, 0)
			Me.nMenuBar1.HasPendantCommand = False
			Me.nMenuBar1.Name = "nMenuBar1"
			Me.nMenuBar1.PrefferedRowIndex = 0
			Me.nMenuBar1.RowIndex = 0
			Me.nMenuBar1.ShowTooltips = False
			Me.nMenuBar1.Text = "Menu Bar"
			' 
			' nCommand1
			' 
			Me.nCommand1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand2})
			Me.nCommand1.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never
			Me.nCommand1.Properties.Text = "&File"
			' 
			' nCommand2
			' 
			Me.nCommand2.Properties.ID = 0
			Me.nCommand2.Properties.Text = "E&xit"
			' 
			' nCommand3
			' 
			Me.nCommand3.Properties.DropDownBehavior = Nevron.UI.WinForm.Controls.DropDownBehavior.AlwaysDropDown
			Me.nCommand3.Properties.ID = 1
			Me.nCommand3.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never
			Me.nCommand3.Properties.Text = "&Panels"
			' 
			' nDockingPanel2
			' 
			Me.nDockingPanel2.Name = "nDockingPanel2"
			Me.nDockingPanel2.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 135)
			Me.nDockingPanel2.TabIndex = 1
			' 
			' NCommandModelForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(816, 462)
			Me.Name = "NCommandModelForm"
			Me.Text = "Command Model Example"
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDockingPanel1.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nDockManager1 As Nevron.UI.WinForm.Docking.NDockManager
		Private nDockingPanel1 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private WithEvents nCommandBarsManager1 As Nevron.UI.WinForm.Controls.NCommandBarsManager
		Private nMenuBar1 As Nevron.UI.WinForm.Controls.NMenuBar
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand3 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents m_ExecuteButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_AvailableCommandsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private nDockingPanel2 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private components As System.ComponentModel.IContainer
		Private WithEvents nButton1 As Nevron.UI.WinForm.Controls.NButton

		Private m_ClickEH As CommandEventHandler

		#End Region
	End Class
End Namespace
