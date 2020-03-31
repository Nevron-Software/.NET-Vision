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
	''' Summary description for NMdiMenuMergeForm.
	''' </summary>
	Public Class NMdiMenuMergeForm
		Inherits System.Windows.Forms.Form
		#Region "Constructor"

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			m_UpdateFormCaption.Checked = True

			nCommandBarsManager1.Palette.Copy(NUIManager.Palette)
			nDockManager1.Palette.Copy(NUIManager.Palette)
			nDockManager1.DocumentStyle.DocumentViewStyle = DocumentViewStyle.MdiStandard

			Dim doc As NUIDocument

			For i As Integer = 1 To 4
				doc = New NUIDocument("Document " & i.ToString())
				doc.Client = NDockingPanelsExampleForm.GetTextBox()
				nDockManager1.DocumentManager.AddDocument(doc)
			Next i

			Dim host As INUIDocumentHost = TryCast(nDockManager1.DocumentManager.Documents(3).Host, NMdiChild)
			If host Is Nothing Then
				Return
			End If

			host.Activate()

			Dim child As NMdiChild = TryCast(host, NMdiChild)
			If Not child Is Nothing Then
				child.WindowState = FormWindowState.Maximized
			End If
		End Sub


		#End Region

		#Region "Overrides"

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

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nCommand2_Click(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.CommandEventArgs) Handles nCommand2.Click
			Close()
		End Sub

		Private Sub m_UpdateFormCaption_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_UpdateFormCaption.CheckedChanged
			nMenuBar1.UpdateFormCaption = m_UpdateFormCaption.Checked
		End Sub

		Private Sub m_AddDocumentButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim nDockZone0 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone1 As Nevron.UI.WinForm.Docking.NDockZone = New Nevron.UI.WinForm.Docking.NDockZone()
			Dim nDockZone3 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Me.nDockManager1 = New Nevron.UI.WinForm.Docking.NDockManager()
			Me.nDockingPanel1 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.nDockingPanel2 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.m_UpdateFormCaption = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCommandBarsManager1 = New Nevron.UI.WinForm.Controls.NCommandBarsManager(Me.components)
			Me.nMenuBar1 = New Nevron.UI.WinForm.Controls.NMenuBar()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDockingPanel1.SuspendLayout()
			Me.nDockingPanel2.SuspendLayout()
			' 
			' nDockManager1
			' 
			Me.nDockManager1.Form = Me
			Me.nDockManager1.RootContainerZIndex = 0
			'  
			' Root Zone
			'  
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0)
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1)
			Me.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal
			'  
			' nDockZone0
			'  
			nDockZone0.AddChild(Me.nDockingPanel2)
			nDockZone0.Name = "nDockZone0"
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone0.Index = 0
			nDockZone0.SizeInfo.PrefferedSize = New System.Drawing.Size(172, 200)
			'  
			' nDockZone1
			'  
			nDockZone1.AddChild(Me.nDockManager1.DocumentManager.DocumentViewHost)
			nDockZone1.AddChild(nDockZone3)
			nDockZone1.Name = "nDockZone1"
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Vertical
			nDockZone1.Index = 1
			nDockZone1.SizeInfo.PrefferedSize = New System.Drawing.Size(666, 200)
			'  
			' nDockZone3
			'  
			nDockZone3.AddChild(Me.nDockingPanel1)
			nDockZone3.Name = "nDockZone3"
			nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone3.Index = 1
			nDockZone3.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 163)
			' 
			' nDockingPanel1
			' 
			Me.nDockingPanel1.Controls.Add(Me.textBox1)
			Me.nDockingPanel1.Name = "nDockingPanel1"
			Me.nDockingPanel1.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 163)
			Me.nDockingPanel1.TabIndex = 1
			' 
			' textBox1
			' 
			Me.textBox1.BackColor = System.Drawing.SystemColors.Window
			Me.textBox1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.textBox1.ForeColor = System.Drawing.SystemColors.WindowText
			Me.textBox1.Location = New System.Drawing.Point(0, 0)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(648, 137)
			Me.textBox1.TabIndex = 0
			Me.textBox1.Text = "textBox1"
			' 
			' nDockingPanel2
			' 
			Me.nDockingPanel2.Controls.Add(Me.m_UpdateFormCaption)
			Me.nDockingPanel2.Name = "nDockingPanel2"
			Me.nDockingPanel2.SizeInfo.PrefferedSize = New System.Drawing.Size(172, 200)
			Me.nDockingPanel2.TabIndex = 1
			Me.nDockingPanel2.Text = "Example"
			' 
			' m_UpdateFormCaption
			' 
			Me.m_UpdateFormCaption.Location = New System.Drawing.Point(8, 8)
			Me.m_UpdateFormCaption.Name = "m_UpdateFormCaption"
			Me.m_UpdateFormCaption.Size = New System.Drawing.Size(144, 24)
			Me.m_UpdateFormCaption.TabIndex = 0
			Me.m_UpdateFormCaption.Text = "&Update Form Caption"
'			Me.m_UpdateFormCaption.CheckedChanged += New System.EventHandler(Me.m_UpdateFormCaption_CheckedChanged);
			' 
			' nCommandBarsManager1
			' 
			Me.nCommandBarsManager1.AllowCustomize = False
			Me.nCommandBarsManager1.ParentControl = Me
			Me.nCommandBarsManager1.Toolbars.Add(Me.nMenuBar1)
			' 
			' nMenuBar1
			' 
			Me.nMenuBar1.AllowDelete = False
			Me.nMenuBar1.AllowHide = False
			Me.nMenuBar1.AllowRename = False
			Me.nMenuBar1.AutoDropDownDelay = False
			Me.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent
			Me.nMenuBar1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand1})
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
			Me.nCommand2.Properties.Text = "E&xit"
'			Me.nCommand2.Click += New Nevron.UI.WinForm.Controls.CommandEventHandler(Me.nCommand2_Click);
			' 
			' NMdiMenuMergeForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(824, 454)
			Me.Name = "NMdiMenuMergeForm"
			Me.Text = "Mdi Menu Merge Example"
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDockingPanel1.ResumeLayout(False)
			Me.nDockingPanel2.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nDockManager1 As Nevron.UI.WinForm.Docking.NDockManager
		Private nDockingPanel1 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel2 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nCommandBarsManager1 As Nevron.UI.WinForm.Controls.NCommandBarsManager
		Private nMenuBar1 As Nevron.UI.WinForm.Controls.NMenuBar
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private textBox1 As System.Windows.Forms.TextBox
		Private WithEvents m_UpdateFormCaption As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.IContainer

		#End Region
	End Class
End Namespace
