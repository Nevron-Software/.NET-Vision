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
	''' Summary description for NVisualTabNavigationForm.
	''' </summary>
	Public Class NVisualTabNavigationForm
		Inherits NForm
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Me.editorModeCombo.FillFromEnum(GetType(VisualTabEditorMode))
			Me.editorModeCombo.SelectedItem = nDockManager1.VisualTabEditorMode

			Dim command As NDockingFrameworkCommand = nDockManager1.Commander.GetCommandById(NDockingFrameworkCommands.VisualTabNavigation)

			If Not command Is Nothing Then
				Dim shortcuts As ArrayList = command.Shortcuts
				If shortcuts.Count > 0 Then
					shortcutEdit.SetShortcut(CType(shortcuts(0), NShortcut))
				End If
			End If

			nDockManager1.DocumentStyle.ImageList = imageList1
			Dim docManager As NDocumentManager = nDockManager1.DocumentManager

			docManager.Suspend()

			Dim doc As NUIDocument
			Dim imageIndex As Integer = 0

			For i As Integer = 0 To 9
				doc = New NUIDocument("Test Document " & i, imageIndex)
				docManager.AddDocument(doc)

				imageIndex += 1
				If imageIndex > 5 Then
					imageIndex = 0
				End If
			Next i

			docManager.Resume()
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
					nDockManager1 = Nothing
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub shortcutEdit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles shortcutEdit.TextChanged
			Dim command As NDockingFrameworkCommand = nDockManager1.Commander.GetCommandById(NDockingFrameworkCommands.VisualTabNavigation)
			If command Is Nothing Then
				Return
			End If

			command.Shortcuts.Clear()
			command.Shortcuts.Add(shortcutEdit.Shortcut)
		End Sub
		Private Sub editorModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles editorModeCombo.SelectedIndexChanged
			nDockManager1.VisualTabEditorMode = CType(editorModeCombo.SelectedItem, VisualTabEditorMode)
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim nDockZone1 As Nevron.UI.WinForm.Docking.NDockZone = New Nevron.UI.WinForm.Docking.NDockZone()
			Dim nDockZone2 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone3 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NVisualTabNavigationForm))
			Me.nDockManager1 = New Nevron.UI.WinForm.Docking.NDockManager(Me.components)
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.nDockingPanel1 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.label1 = New System.Windows.Forms.Label()
			Me.shortcutEdit = New Nevron.UI.WinForm.Controls.NShortcutTextBox()
			Me.nDockingPanel2 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nDockingPanel3 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nDockingPanel4 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.label3 = New System.Windows.Forms.Label()
			Me.editorModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDockingPanel1.SuspendLayout()
			Me.nDockingPanel2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nDockManager1
			' 
			Me.nDockManager1.Form = Me
			Me.nDockManager1.ImageList = Me.imageList1
			Me.nDockManager1.RootContainerZIndex = 0
			'  
			' Root Zone
			'  
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1)
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone3)
			Me.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal
			'  
			' nDockZone1
			'  
			nDockZone1.AddChild(Me.nDockManager1.DocumentManager.DocumentViewHost)
			nDockZone1.AddChild(nDockZone2)
			nDockZone1.Name = "nDockZone1"
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Vertical
			nDockZone1.Index = 0
			nDockZone1.SizeInfo.PrefferedSize = New System.Drawing.Size(573, 200)
			'  
			' nDockZone2
			'  
			nDockZone2.AddChild(Me.nDockingPanel4)
			nDockZone2.AddChild(Me.nDockingPanel2)
			nDockZone2.Name = "nDockZone2"
			nDockZone2.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone2.Index = 1
			nDockZone2.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 199)
			'  
			' nDockZone3
			'  
			nDockZone3.AddChild(Me.nDockingPanel1)
			nDockZone3.AddChild(Me.nDockingPanel3)
			nDockZone3.Name = "nDockZone3"
			nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone3.Index = 1
			nDockZone3.SizeInfo.PrefferedSize = New System.Drawing.Size(241, 200)
			' 
			' imageList1
			' 
			Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			' 
			' nDockingPanel1
			' 
			Me.nDockingPanel1.Controls.Add(Me.editorModeCombo)
			Me.nDockingPanel1.Controls.Add(Me.label3)
			Me.nDockingPanel1.Controls.Add(Me.label1)
			Me.nDockingPanel1.Controls.Add(Me.shortcutEdit)
			Me.nDockingPanel1.Location = New System.Drawing.Point(1, 24)
			Me.nDockingPanel1.Name = "nDockingPanel1"
			Me.nDockingPanel1.Size = New System.Drawing.Size(235, 500)
			Me.nDockingPanel1.SizeInfo.PrefferedSize = New System.Drawing.Size(241, 200)
			Me.nDockingPanel1.TabIndex = 1
			Me.nDockingPanel1.TabInfo.ImageIndex = 5
			Me.nDockingPanel1.TabInfo.TooltipText = ""
			Me.nDockingPanel1.Text = "Settings"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 56)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(128, 23)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Visual Editor Shortcut:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' shortcutEdit
			' 
			Me.shortcutEdit.Location = New System.Drawing.Point(16, 80)
			Me.shortcutEdit.Name = "shortcutEdit"
			Me.shortcutEdit.Size = New System.Drawing.Size(192, 18)
			Me.shortcutEdit.TabIndex = 1
'			Me.shortcutEdit.TextChanged += New System.EventHandler(Me.shortcutEdit_TextChanged);
			' 
			' nDockingPanel2
			' 
			Me.nDockingPanel2.Controls.Add(Me.label2)
			Me.nDockingPanel2.Location = New System.Drawing.Point(1, 24)
			Me.nDockingPanel2.Name = "nDockingPanel2"
			Me.nDockingPanel2.Size = New System.Drawing.Size(545, 527)
			Me.nDockingPanel2.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 199)
			Me.nDockingPanel2.TabIndex = 1
			Me.nDockingPanel2.TabInfo.ImageIndex = 4
			Me.nDockingPanel2.Text = "Testing Panel"
			' 
			' label2
			' 
			Me.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.label2.Location = New System.Drawing.Point(56, 32)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(416, 72)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Press Control+Tab to trigger the visual tab editor."
			' 
			' nDockingPanel3
			' 
			Me.nDockingPanel3.Location = New System.Drawing.Point(1, 24)
			Me.nDockingPanel3.Name = "nDockingPanel3"
			Me.nDockingPanel3.Size = New System.Drawing.Size(235, 527)
			Me.nDockingPanel3.TabIndex = 2
			Me.nDockingPanel3.TabInfo.ImageIndex = 3
			Me.nDockingPanel3.Text = "Testing Panel"
			' 
			' nDockingPanel4
			' 
			Me.nDockingPanel4.Location = New System.Drawing.Point(1, 24)
			Me.nDockingPanel4.Name = "nDockingPanel4"
			Me.nDockingPanel4.Size = New System.Drawing.Size(530, 143)
			Me.nDockingPanel4.TabIndex = 2
			Me.nDockingPanel4.TabInfo.ImageIndex = 0
			Me.nDockingPanel4.Text = "Testing Panel"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(16, 9)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(128, 23)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Visual Editor Mode:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' editorModeCombo
			' 
			Me.editorModeCombo.ListProperties.ColumnOnLeft = False
			Me.editorModeCombo.Location = New System.Drawing.Point(16, 31)
			Me.editorModeCombo.Name = "editorModeCombo"
			Me.editorModeCombo.Size = New System.Drawing.Size(192, 22)
			Me.editorModeCombo.TabIndex = 4
			Me.editorModeCombo.Text = "nComboBox1"
'			Me.editorModeCombo.SelectedIndexChanged += New System.EventHandler(Me.editorModeCombo_SelectedIndexChanged);
			' 
			' NVisualTabNavigationForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(773, 552)
			Me.Name = "NVisualTabNavigationForm"
			Me.Text = "Visual Tab Navigation Example"
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDockingPanel1.ResumeLayout(False)
			Me.nDockingPanel2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nDockManager1 As Nevron.UI.WinForm.Docking.NDockManager
		Private nDockingPanel1 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel2 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private imageList1 As System.Windows.Forms.ImageList
		Private nDockingPanel3 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel4 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private WithEvents shortcutEdit As Nevron.UI.WinForm.Controls.NShortcutTextBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents editorModeCombo As NComboBox
		Private label3 As Label
		Private components As System.ComponentModel.IContainer

		#End Region
	End Class
End Namespace
