Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NToolStripSkinRendererUC
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (Not components Is Nothing) Then
				components.Dispose()

				System.Windows.Forms.ToolStripManager.Renderer = Nothing
				m_Renderer = Nothing
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NToolStripSkinRendererUC))
			Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
			Me.toolStrip2 = New System.Windows.Forms.ToolStrip()
			Me.newToolStripButton1 = New System.Windows.Forms.ToolStripButton()
			Me.openToolStripButton1 = New System.Windows.Forms.ToolStripButton()
			Me.saveToolStripButton1 = New System.Windows.Forms.ToolStripButton()
			Me.printToolStripButton1 = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
			Me.cutToolStripButton1 = New System.Windows.Forms.ToolStripButton()
			Me.copyToolStripButton1 = New System.Windows.Forms.ToolStripButton()
			Me.pasteToolStripButton1 = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
			Me.helpToolStripButton1 = New System.Windows.Forms.ToolStripButton()
			Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
			Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
			Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.saveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
			Me.printToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.printPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
			Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.undoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.redoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
			Me.cutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.pasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
			Me.selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.customizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
			Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.contentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.indexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.searchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
			Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
			Me.newToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.openToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.saveToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.printToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
			Me.cutToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.copyToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.pasteToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
			Me.helpToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
			Me.toolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
			Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
			Me.toolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
			Me.label1 = New System.Windows.Forms.Label()
			Me.skinCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.toolStripContainer1.BottomToolStripPanel.SuspendLayout()
			Me.toolStripContainer1.ContentPanel.SuspendLayout()
			Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
			Me.toolStripContainer1.SuspendLayout()
			Me.toolStrip2.SuspendLayout()
			Me.menuStrip1.SuspendLayout()
			Me.toolStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' toolStripContainer1
			' 
			' 
			' toolStripContainer1.BottomToolStripPanel
			' 
			Me.toolStripContainer1.BottomToolStripPanel.Controls.Add(Me.toolStrip2)
			' 
			' toolStripContainer1.ContentPanel
			' 
			Me.toolStripContainer1.ContentPanel.Controls.Add(Me.skinCombo)
			Me.toolStripContainer1.ContentPanel.Controls.Add(Me.label1)
			Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(416, 209)
			Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
			Me.toolStripContainer1.Name = "toolStripContainer1"
			Me.toolStripContainer1.Size = New System.Drawing.Size(416, 283)
			Me.toolStripContainer1.TabIndex = 0
			Me.toolStripContainer1.Text = "toolStripContainer1"
			' 
			' toolStripContainer1.TopToolStripPanel
			' 
			Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.menuStrip1)
			Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStrip1)
			' 
			' toolStrip2
			' 
			Me.toolStrip2.Dock = System.Windows.Forms.DockStyle.None
			Me.toolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.newToolStripButton1, Me.openToolStripButton1, Me.saveToolStripButton1, Me.printToolStripButton1, Me.toolStripSeparator2, Me.cutToolStripButton1, Me.copyToolStripButton1, Me.pasteToolStripButton1, Me.toolStripSeparator3, Me.helpToolStripButton1})
			Me.toolStrip2.Location = New System.Drawing.Point(3, 0)
			Me.toolStrip2.Name = "toolStrip2"
			Me.toolStrip2.Size = New System.Drawing.Size(208, 25)
			Me.toolStrip2.TabIndex = 1
			' 
			' newToolStripButton1
			' 
			Me.newToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.newToolStripButton1.Image = (CType(resources.GetObject("newToolStripButton1.Image"), System.Drawing.Image))
			Me.newToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.newToolStripButton1.Name = "newToolStripButton1"
			Me.newToolStripButton1.Size = New System.Drawing.Size(23, 22)
			Me.newToolStripButton1.Text = "&New"
			' 
			' openToolStripButton1
			' 
			Me.openToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.openToolStripButton1.Image = (CType(resources.GetObject("openToolStripButton1.Image"), System.Drawing.Image))
			Me.openToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.openToolStripButton1.Name = "openToolStripButton1"
			Me.openToolStripButton1.Size = New System.Drawing.Size(23, 22)
			Me.openToolStripButton1.Text = "&Open"
			' 
			' saveToolStripButton1
			' 
			Me.saveToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.saveToolStripButton1.Image = (CType(resources.GetObject("saveToolStripButton1.Image"), System.Drawing.Image))
			Me.saveToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.saveToolStripButton1.Name = "saveToolStripButton1"
			Me.saveToolStripButton1.Size = New System.Drawing.Size(23, 22)
			Me.saveToolStripButton1.Text = "&Save"
			' 
			' printToolStripButton1
			' 
			Me.printToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.printToolStripButton1.Image = (CType(resources.GetObject("printToolStripButton1.Image"), System.Drawing.Image))
			Me.printToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.printToolStripButton1.Name = "printToolStripButton1"
			Me.printToolStripButton1.Size = New System.Drawing.Size(23, 22)
			Me.printToolStripButton1.Text = "&Print"
			' 
			' toolStripSeparator2
			' 
			Me.toolStripSeparator2.Name = "toolStripSeparator2"
			Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
			' 
			' cutToolStripButton1
			' 
			Me.cutToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.cutToolStripButton1.Image = (CType(resources.GetObject("cutToolStripButton1.Image"), System.Drawing.Image))
			Me.cutToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.cutToolStripButton1.Name = "cutToolStripButton1"
			Me.cutToolStripButton1.Size = New System.Drawing.Size(23, 22)
			Me.cutToolStripButton1.Text = "C&ut"
			' 
			' copyToolStripButton1
			' 
			Me.copyToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.copyToolStripButton1.Image = (CType(resources.GetObject("copyToolStripButton1.Image"), System.Drawing.Image))
			Me.copyToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.copyToolStripButton1.Name = "copyToolStripButton1"
			Me.copyToolStripButton1.Size = New System.Drawing.Size(23, 22)
			Me.copyToolStripButton1.Text = "&Copy"
			' 
			' pasteToolStripButton1
			' 
			Me.pasteToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.pasteToolStripButton1.Image = (CType(resources.GetObject("pasteToolStripButton1.Image"), System.Drawing.Image))
			Me.pasteToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.pasteToolStripButton1.Name = "pasteToolStripButton1"
			Me.pasteToolStripButton1.Size = New System.Drawing.Size(23, 22)
			Me.pasteToolStripButton1.Text = "&Paste"
			' 
			' toolStripSeparator3
			' 
			Me.toolStripSeparator3.Name = "toolStripSeparator3"
			Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
			' 
			' helpToolStripButton1
			' 
			Me.helpToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.helpToolStripButton1.Image = (CType(resources.GetObject("helpToolStripButton1.Image"), System.Drawing.Image))
			Me.helpToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.helpToolStripButton1.Name = "helpToolStripButton1"
			Me.helpToolStripButton1.Size = New System.Drawing.Size(23, 22)
			Me.helpToolStripButton1.Text = "He&lp"
			' 
			' menuStrip1
			' 
			Me.menuStrip1.Dock = System.Windows.Forms.DockStyle.None
			Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.toolsToolStripMenuItem, Me.helpToolStripMenuItem})
			Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip1.Name = "menuStrip1"
			Me.menuStrip1.Size = New System.Drawing.Size(416, 24)
			Me.menuStrip1.TabIndex = 1
			Me.menuStrip1.Text = "menuStrip1"
			' 
			' fileToolStripMenuItem
			' 
			Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.toolStripSeparator4, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripSeparator5, Me.printToolStripMenuItem, Me.printPreviewToolStripMenuItem, Me.toolStripSeparator6, Me.exitToolStripMenuItem})
			Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
			Me.fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
			Me.fileToolStripMenuItem.Text = "&File"
			' 
			' newToolStripMenuItem
			' 
			Me.newToolStripMenuItem.Image = (CType(resources.GetObject("newToolStripMenuItem.Image"), System.Drawing.Image))
			Me.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
			Me.newToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys))
			Me.newToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
			Me.newToolStripMenuItem.Text = "&New"
			' 
			' openToolStripMenuItem
			' 
			Me.openToolStripMenuItem.Image = (CType(resources.GetObject("openToolStripMenuItem.Image"), System.Drawing.Image))
			Me.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
			Me.openToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys))
			Me.openToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
			Me.openToolStripMenuItem.Text = "&Open"
			' 
			' toolStripSeparator4
			' 
			Me.toolStripSeparator4.Name = "toolStripSeparator4"
			Me.toolStripSeparator4.Size = New System.Drawing.Size(148, 6)
			' 
			' saveToolStripMenuItem
			' 
			Me.saveToolStripMenuItem.Image = (CType(resources.GetObject("saveToolStripMenuItem.Image"), System.Drawing.Image))
			Me.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
			Me.saveToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys))
			Me.saveToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
			Me.saveToolStripMenuItem.Text = "&Save"
			' 
			' saveAsToolStripMenuItem
			' 
			Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
			Me.saveAsToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
			Me.saveAsToolStripMenuItem.Text = "Save &As"
			' 
			' toolStripSeparator5
			' 
			Me.toolStripSeparator5.Name = "toolStripSeparator5"
			Me.toolStripSeparator5.Size = New System.Drawing.Size(148, 6)
			' 
			' printToolStripMenuItem
			' 
			Me.printToolStripMenuItem.Image = (CType(resources.GetObject("printToolStripMenuItem.Image"), System.Drawing.Image))
			Me.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.printToolStripMenuItem.Name = "printToolStripMenuItem"
			Me.printToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys))
			Me.printToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
			Me.printToolStripMenuItem.Text = "&Print"
			' 
			' printPreviewToolStripMenuItem
			' 
			Me.printPreviewToolStripMenuItem.Image = (CType(resources.GetObject("printPreviewToolStripMenuItem.Image"), System.Drawing.Image))
			Me.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem"
			Me.printPreviewToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
			Me.printPreviewToolStripMenuItem.Text = "Print Pre&view"
			' 
			' toolStripSeparator6
			' 
			Me.toolStripSeparator6.Name = "toolStripSeparator6"
			Me.toolStripSeparator6.Size = New System.Drawing.Size(148, 6)
			' 
			' exitToolStripMenuItem
			' 
			Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
			Me.exitToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
			Me.exitToolStripMenuItem.Text = "E&xit"
			' 
			' editToolStripMenuItem
			' 
			Me.editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.undoToolStripMenuItem, Me.redoToolStripMenuItem, Me.toolStripSeparator7, Me.cutToolStripMenuItem, Me.copyToolStripMenuItem, Me.pasteToolStripMenuItem, Me.toolStripSeparator8, Me.selectAllToolStripMenuItem})
			Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
			Me.editToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
			Me.editToolStripMenuItem.Text = "&Edit"
			' 
			' undoToolStripMenuItem
			' 
			Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
			Me.undoToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys))
			Me.undoToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
			Me.undoToolStripMenuItem.Text = "&Undo"
			' 
			' redoToolStripMenuItem
			' 
			Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
			Me.redoToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys))
			Me.redoToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
			Me.redoToolStripMenuItem.Text = "&Redo"
			' 
			' toolStripSeparator7
			' 
			Me.toolStripSeparator7.Name = "toolStripSeparator7"
			Me.toolStripSeparator7.Size = New System.Drawing.Size(147, 6)
			' 
			' cutToolStripMenuItem
			' 
			Me.cutToolStripMenuItem.Image = (CType(resources.GetObject("cutToolStripMenuItem.Image"), System.Drawing.Image))
			Me.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
			Me.cutToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys))
			Me.cutToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
			Me.cutToolStripMenuItem.Text = "Cu&t"
			' 
			' copyToolStripMenuItem
			' 
			Me.copyToolStripMenuItem.Image = (CType(resources.GetObject("copyToolStripMenuItem.Image"), System.Drawing.Image))
			Me.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
			Me.copyToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys))
			Me.copyToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
			Me.copyToolStripMenuItem.Text = "&Copy"
			' 
			' pasteToolStripMenuItem
			' 
			Me.pasteToolStripMenuItem.Image = (CType(resources.GetObject("pasteToolStripMenuItem.Image"), System.Drawing.Image))
			Me.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
			Me.pasteToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys))
			Me.pasteToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
			Me.pasteToolStripMenuItem.Text = "&Paste"
			' 
			' toolStripSeparator8
			' 
			Me.toolStripSeparator8.Name = "toolStripSeparator8"
			Me.toolStripSeparator8.Size = New System.Drawing.Size(147, 6)
			' 
			' selectAllToolStripMenuItem
			' 
			Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
			Me.selectAllToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
			Me.selectAllToolStripMenuItem.Text = "Select &All"
			' 
			' toolsToolStripMenuItem
			' 
			Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.customizeToolStripMenuItem, Me.optionsToolStripMenuItem, Me.toolStripMenuItem1})
			Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
			Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
			Me.toolsToolStripMenuItem.Text = "&Tools"
			' 
			' customizeToolStripMenuItem
			' 
			Me.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem"
			Me.customizeToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
			Me.customizeToolStripMenuItem.Text = "&Customize"
			' 
			' optionsToolStripMenuItem
			' 
			Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
			Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
			Me.optionsToolStripMenuItem.Text = "&Options"
			' 
			' toolStripMenuItem1
			' 
			Me.toolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5})
			Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
			Me.toolStripMenuItem1.Size = New System.Drawing.Size(187, 22)
			Me.toolStripMenuItem1.Text = "Test Drop-down Item"
			' 
			' toolStripMenuItem2
			' 
			Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
			Me.toolStripMenuItem2.Size = New System.Drawing.Size(179, 22)
			Me.toolStripMenuItem2.Text = "toolStripMenuItem2"
			' 
			' toolStripMenuItem3
			' 
			Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
			Me.toolStripMenuItem3.Size = New System.Drawing.Size(179, 22)
			Me.toolStripMenuItem3.Text = "toolStripMenuItem3"
			' 
			' toolStripMenuItem4
			' 
			Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
			Me.toolStripMenuItem4.Size = New System.Drawing.Size(179, 22)
			Me.toolStripMenuItem4.Text = "toolStripMenuItem4"
			' 
			' toolStripMenuItem5
			' 
			Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
			Me.toolStripMenuItem5.Size = New System.Drawing.Size(179, 22)
			Me.toolStripMenuItem5.Text = "toolStripMenuItem5"
			' 
			' helpToolStripMenuItem
			' 
			Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.contentsToolStripMenuItem, Me.indexToolStripMenuItem, Me.searchToolStripMenuItem, Me.toolStripSeparator9, Me.aboutToolStripMenuItem})
			Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
			Me.helpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
			Me.helpToolStripMenuItem.Text = "&Help"
			' 
			' contentsToolStripMenuItem
			' 
			Me.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem"
			Me.contentsToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
			Me.contentsToolStripMenuItem.Text = "&Contents"
			' 
			' indexToolStripMenuItem
			' 
			Me.indexToolStripMenuItem.Name = "indexToolStripMenuItem"
			Me.indexToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
			Me.indexToolStripMenuItem.Text = "&Index"
			' 
			' searchToolStripMenuItem
			' 
			Me.searchToolStripMenuItem.Name = "searchToolStripMenuItem"
			Me.searchToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
			Me.searchToolStripMenuItem.Text = "&Search"
			' 
			' toolStripSeparator9
			' 
			Me.toolStripSeparator9.Name = "toolStripSeparator9"
			Me.toolStripSeparator9.Size = New System.Drawing.Size(126, 6)
			' 
			' aboutToolStripMenuItem
			' 
			Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
			Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
			Me.aboutToolStripMenuItem.Text = "&About..."
			' 
			' toolStrip1
			' 
			Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
			Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.newToolStripButton, Me.openToolStripButton, Me.saveToolStripButton, Me.printToolStripButton, Me.toolStripSeparator, Me.cutToolStripButton, Me.copyToolStripButton, Me.pasteToolStripButton, Me.toolStripSeparator1, Me.helpToolStripButton, Me.toolStripSeparator10, Me.toolStripSplitButton1, Me.toolStripDropDownButton1})
			Me.toolStrip1.Location = New System.Drawing.Point(3, 24)
			Me.toolStrip1.Name = "toolStrip1"
			Me.toolStrip1.Size = New System.Drawing.Size(275, 25)
			Me.toolStrip1.TabIndex = 0
			' 
			' newToolStripButton
			' 
			Me.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.newToolStripButton.Image = (CType(resources.GetObject("newToolStripButton.Image"), System.Drawing.Image))
			Me.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.newToolStripButton.Name = "newToolStripButton"
			Me.newToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.newToolStripButton.Text = "&New"
			' 
			' openToolStripButton
			' 
			Me.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.openToolStripButton.Image = (CType(resources.GetObject("openToolStripButton.Image"), System.Drawing.Image))
			Me.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.openToolStripButton.Name = "openToolStripButton"
			Me.openToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.openToolStripButton.Text = "&Open"
			' 
			' saveToolStripButton
			' 
			Me.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.saveToolStripButton.Image = (CType(resources.GetObject("saveToolStripButton.Image"), System.Drawing.Image))
			Me.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.saveToolStripButton.Name = "saveToolStripButton"
			Me.saveToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.saveToolStripButton.Text = "&Save"
			' 
			' printToolStripButton
			' 
			Me.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.printToolStripButton.Image = (CType(resources.GetObject("printToolStripButton.Image"), System.Drawing.Image))
			Me.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.printToolStripButton.Name = "printToolStripButton"
			Me.printToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.printToolStripButton.Text = "&Print"
			' 
			' toolStripSeparator
			' 
			Me.toolStripSeparator.Name = "toolStripSeparator"
			Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
			' 
			' cutToolStripButton
			' 
			Me.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.cutToolStripButton.Image = (CType(resources.GetObject("cutToolStripButton.Image"), System.Drawing.Image))
			Me.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.cutToolStripButton.Name = "cutToolStripButton"
			Me.cutToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.cutToolStripButton.Text = "C&ut"
			' 
			' copyToolStripButton
			' 
			Me.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.copyToolStripButton.Image = (CType(resources.GetObject("copyToolStripButton.Image"), System.Drawing.Image))
			Me.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.copyToolStripButton.Name = "copyToolStripButton"
			Me.copyToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.copyToolStripButton.Text = "&Copy"
			' 
			' pasteToolStripButton
			' 
			Me.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.pasteToolStripButton.Image = (CType(resources.GetObject("pasteToolStripButton.Image"), System.Drawing.Image))
			Me.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.pasteToolStripButton.Name = "pasteToolStripButton"
			Me.pasteToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.pasteToolStripButton.Text = "&Paste"
			' 
			' toolStripSeparator1
			' 
			Me.toolStripSeparator1.Name = "toolStripSeparator1"
			Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
			' 
			' helpToolStripButton
			' 
			Me.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.helpToolStripButton.Image = (CType(resources.GetObject("helpToolStripButton.Image"), System.Drawing.Image))
			Me.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.helpToolStripButton.Name = "helpToolStripButton"
			Me.helpToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.helpToolStripButton.Text = "He&lp"
			' 
			' toolStripSeparator10
			' 
			Me.toolStripSeparator10.Name = "toolStripSeparator10"
			Me.toolStripSeparator10.Size = New System.Drawing.Size(6, 25)
			' 
			' toolStripSplitButton1
			' 
			Me.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.toolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripMenuItem6, Me.toolStripMenuItem7})
			Me.toolStripSplitButton1.Image = (CType(resources.GetObject("toolStripSplitButton1.Image"), System.Drawing.Image))
			Me.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.toolStripSplitButton1.Name = "toolStripSplitButton1"
			Me.toolStripSplitButton1.Size = New System.Drawing.Size(32, 22)
			Me.toolStripSplitButton1.Text = "toolStripSplitButton1"
			' 
			' toolStripMenuItem6
			' 
			Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
			Me.toolStripMenuItem6.Size = New System.Drawing.Size(179, 22)
			Me.toolStripMenuItem6.Text = "toolStripMenuItem6"
			' 
			' toolStripMenuItem7
			' 
			Me.toolStripMenuItem7.Name = "toolStripMenuItem7"
			Me.toolStripMenuItem7.Size = New System.Drawing.Size(179, 22)
			Me.toolStripMenuItem7.Text = "toolStripMenuItem7"
			' 
			' toolStripDropDownButton1
			' 
			Me.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.toolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripMenuItem8, Me.toolStripMenuItem9, Me.toolStripMenuItem10})
			Me.toolStripDropDownButton1.Image = (CType(resources.GetObject("toolStripDropDownButton1.Image"), System.Drawing.Image))
			Me.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.toolStripDropDownButton1.Name = "toolStripDropDownButton1"
			Me.toolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
			Me.toolStripDropDownButton1.Text = "toolStripDropDownButton1"
			' 
			' toolStripMenuItem8
			' 
			Me.toolStripMenuItem8.Name = "toolStripMenuItem8"
			Me.toolStripMenuItem8.Size = New System.Drawing.Size(185, 22)
			Me.toolStripMenuItem8.Text = "toolStripMenuItem8"
			' 
			' toolStripMenuItem9
			' 
			Me.toolStripMenuItem9.Name = "toolStripMenuItem9"
			Me.toolStripMenuItem9.Size = New System.Drawing.Size(185, 22)
			Me.toolStripMenuItem9.Text = "toolStripMenuItem9"
			' 
			' toolStripMenuItem10
			' 
			Me.toolStripMenuItem10.Name = "toolStripMenuItem10"
			Me.toolStripMenuItem10.Size = New System.Drawing.Size(185, 22)
			Me.toolStripMenuItem10.Text = "toolStripMenuItem10"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(48, 28)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Select Skin:"
			' 
			' skinCombo
			' 
			Me.skinCombo.Location = New System.Drawing.Point(51, 44)
			Me.skinCombo.Name = "skinCombo"
			Me.skinCombo.Size = New System.Drawing.Size(188, 22)
			Me.skinCombo.TabIndex = 1
			Me.skinCombo.Text = "nComboBox1"
			' 
			' NToolStripSkinRendererUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.toolStripContainer1)
			Me.Name = "NToolStripSkinRendererUC"
			Me.Size = New System.Drawing.Size(416, 283)
			Me.toolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
			Me.toolStripContainer1.BottomToolStripPanel.PerformLayout()
			Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
			Me.toolStripContainer1.ContentPanel.PerformLayout()
			Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
			Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
			Me.toolStripContainer1.ResumeLayout(False)
			Me.toolStripContainer1.PerformLayout()
			Me.toolStrip2.ResumeLayout(False)
			Me.toolStrip2.PerformLayout()
			Me.menuStrip1.ResumeLayout(False)
			Me.menuStrip1.PerformLayout()
			Me.toolStrip1.ResumeLayout(False)
			Me.toolStrip1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
		Private toolStrip2 As System.Windows.Forms.ToolStrip
		Private toolStrip1 As System.Windows.Forms.ToolStrip
		Private newToolStripButton1 As System.Windows.Forms.ToolStripButton
		Private openToolStripButton1 As System.Windows.Forms.ToolStripButton
		Private saveToolStripButton1 As System.Windows.Forms.ToolStripButton
		Private printToolStripButton1 As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
		Private cutToolStripButton1 As System.Windows.Forms.ToolStripButton
		Private copyToolStripButton1 As System.Windows.Forms.ToolStripButton
		Private pasteToolStripButton1 As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
		Private helpToolStripButton1 As System.Windows.Forms.ToolStripButton
		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
		Private saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private saveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
		Private printToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private printPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
		Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private undoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private redoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
		Private cutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private pasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
		Private selectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private customizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private contentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private indexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private searchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
		Private aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private newToolStripButton As System.Windows.Forms.ToolStripButton
		Private openToolStripButton As System.Windows.Forms.ToolStripButton
		Private saveToolStripButton As System.Windows.Forms.ToolStripButton
		Private printToolStripButton As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator As System.Windows.Forms.ToolStripSeparator
		Private cutToolStripButton As System.Windows.Forms.ToolStripButton
		Private copyToolStripButton As System.Windows.Forms.ToolStripButton
		Private pasteToolStripButton As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private helpToolStripButton As System.Windows.Forms.ToolStripButton
		Private toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
		Private toolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
		Private toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
		Private toolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
		Private toolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
		Private skinCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
	End Class
End Namespace
