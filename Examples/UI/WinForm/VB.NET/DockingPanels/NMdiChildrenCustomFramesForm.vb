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
	''' Summary description for NMdiChildrenCustomFramesForm.
	''' </summary>
	Public Class NMdiChildrenCustomFramesForm
		Inherits System.Windows.Forms.Form
		#Region "Constructor"

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			Dim manager As NDocumentManager = nDockManager1.DocumentManager

			For i As Integer = 1 To 4
				manager.AddDocument(New NUIDocument("Document " & i.ToString()))
			Next i
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

		'protected override void OnLoad(EventArgs e)
'{
'base.OnLoad (e);

'NUIManager.ApplyPalette();
'}


		#End Region

		#Region "Event Handlers"

		Private Sub nCommand2_Click(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.CommandEventArgs) Handles nCommand2.Click
			Close()
		End Sub

		Private Sub m_StickyChildrenCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StickyChildrenCheck.CheckedChanged
			nDockManager1.DocumentStyle.StickyChildren = m_StickyChildrenCheck.Checked
		End Sub
		Private Sub m_StickToClientEdgesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StickToClientEdgesCheck.CheckedChanged
			nDockManager1.DocumentStyle.StickToMdiClientEdges = m_StickToClientEdgesCheck.Checked
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
			Me.nDockingPanel1 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nDockManager1 = New Nevron.UI.WinForm.Docking.NDockManager()
			Me.nDockingPanel2 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nDockingPanel3 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.m_StickToClientEdgesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_StickyChildrenCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCommandBarsManager1 = New Nevron.UI.WinForm.Controls.NCommandBarsManager(Me.components)
			Me.nMenuBar1 = New Nevron.UI.WinForm.Controls.NMenuBar()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDockingPanel3.SuspendLayout()
			CType(Me.nCommandBarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' nDockingPanel1
			' 
			Me.nDockingPanel1.Name = "nDockingPanel1"
			Me.nDockingPanel1.TabIndex = 1
			' 
			' nDockManager1
			' 
			Me.nDockManager1.DocumentStyle.DocumentViewStyle = Nevron.UI.WinForm.Docking.DocumentViewStyle.MdiStandard
			Me.nDockManager1.Form = Me
			Me.nDockManager1.RootContainerZIndex = 0
			Me.nDockManager1.StickyOptions.StickyInflate = 21
			'  
			' Root Zone
			'  
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0)
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1)
			Me.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal
			'  
			' nDockZone0
			'  
			nDockZone0.AddChild(Me.nDockingPanel3)
			nDockZone0.Name = "nDockZone0"
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone0.Index = 0
			'  
			' nDockZone1
			'  
			nDockZone1.AddChild(Me.nDockManager1.DocumentManager.DocumentViewHost)
			nDockZone1.AddChild(nDockZone3)
			nDockZone1.Name = "nDockZone1"
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Vertical
			nDockZone1.Index = 1
			'  
			' nDockZone3
			'  
			nDockZone3.AddChild(Me.nDockingPanel2)
			nDockZone3.Name = "nDockZone3"
			nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone3.Index = 1
			' 
			' nDockingPanel2
			' 
			Me.nDockingPanel2.Name = "nDockingPanel2"
			Me.nDockingPanel2.TabIndex = 1
			' 
			' nDockingPanel3
			' 
			Me.nDockingPanel3.Controls.Add(Me.m_StickToClientEdgesCheck)
			Me.nDockingPanel3.Controls.Add(Me.m_StickyChildrenCheck)
			Me.nDockingPanel3.Name = "nDockingPanel3"
			Me.nDockingPanel3.TabIndex = 1
			' 
			' m_StickToClientEdgesCheck
			' 
			Me.m_StickToClientEdgesCheck.Checked = True
			Me.m_StickToClientEdgesCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_StickToClientEdgesCheck.Location = New System.Drawing.Point(8, 40)
			Me.m_StickToClientEdgesCheck.Name = "m_StickToClientEdgesCheck"
			Me.m_StickToClientEdgesCheck.Size = New System.Drawing.Size(176, 24)
			Me.m_StickToClientEdgesCheck.TabIndex = 1
			Me.m_StickToClientEdgesCheck.Text = "Stick To Client Edges"
'			Me.m_StickToClientEdgesCheck.CheckedChanged += New System.EventHandler(Me.m_StickToClientEdgesCheck_CheckedChanged);
			' 
			' m_StickyChildrenCheck
			' 
			Me.m_StickyChildrenCheck.Checked = True
			Me.m_StickyChildrenCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_StickyChildrenCheck.Location = New System.Drawing.Point(8, 16)
			Me.m_StickyChildrenCheck.Name = "m_StickyChildrenCheck"
			Me.m_StickyChildrenCheck.Size = New System.Drawing.Size(176, 24)
			Me.m_StickyChildrenCheck.TabIndex = 0
			Me.m_StickyChildrenCheck.Text = "Sticky Children"
'			Me.m_StickyChildrenCheck.CheckedChanged += New System.EventHandler(Me.m_StickyChildrenCheck_CheckedChanged);
			' 
			' nCommandBarsManager1
			' 
			Me.nCommandBarsManager1.AllowCustomize = False
			Me.nCommandBarsManager1.ParentControl = Me
			Me.nCommandBarsManager1.Toolbars.Add(Me.nMenuBar1)
			' 
			' nMenuBar1
			' 
			Me.nMenuBar1.AutoDropDownDelay = False
			Me.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent
			Me.nMenuBar1.CanFloat = False
			Me.nMenuBar1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand1})
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
			' NMdiChildrenCustomFramesForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(840, 566)
			Me.Name = "NMdiChildrenCustomFramesForm"
			Me.Text = "Mdi Children - Custom Frames Example"
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDockingPanel3.ResumeLayout(False)
			CType(Me.nCommandBarsManager1, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		#End Region

		#Region "Fields"

		Private nDockingPanel1 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockManager1 As Nevron.UI.WinForm.Docking.NDockManager
		Private nDockingPanel2 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel3 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nCommandBarsManager1 As Nevron.UI.WinForm.Controls.NCommandBarsManager
		Private nMenuBar1 As Nevron.UI.WinForm.Controls.NMenuBar
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents m_StickyChildrenCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_StickToClientEdgesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.IContainer

		#End Region
	End Class
End Namespace
