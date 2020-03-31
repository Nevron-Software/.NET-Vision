Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExXmlViewerUC
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
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nTreeViewEx1 = New Nevron.UI.WinForm.Controls.NTreeViewEx()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.collapseAllBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.expandAllBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.loadFileBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.embeddedFileBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nTreeViewEx1
			' 
			Me.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nTreeViewEx1.Location = New System.Drawing.Point(0, 0)
			Me.nTreeViewEx1.Name = "nTreeViewEx1"
			Me.nTreeViewEx1.Size = New System.Drawing.Size(564, 335)
			Me.nTreeViewEx1.TabIndex = 0
			Me.nTreeViewEx1.Text = "nTreeViewEx1"
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.collapseAllBtn)
			Me.panel1.Controls.Add(Me.expandAllBtn)
			Me.panel1.Controls.Add(Me.loadFileBtn)
			Me.panel1.Controls.Add(Me.embeddedFileBtn)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 335)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(564, 39)
			Me.panel1.TabIndex = 1
			' 
			' collapseAllBtn
			' 
			Me.collapseAllBtn.Location = New System.Drawing.Point(360, 3)
			Me.collapseAllBtn.Name = "collapseAllBtn"
			Me.collapseAllBtn.Size = New System.Drawing.Size(72, 26)
			Me.collapseAllBtn.TabIndex = 3
			Me.collapseAllBtn.Text = "Collapse All"
'			Me.collapseAllBtn.Click += New System.EventHandler(Me.collapseAllBtn_Click);
			' 
			' expandAllBtn
			' 
			Me.expandAllBtn.Location = New System.Drawing.Point(282, 3)
			Me.expandAllBtn.Name = "expandAllBtn"
			Me.expandAllBtn.Size = New System.Drawing.Size(72, 26)
			Me.expandAllBtn.TabIndex = 2
			Me.expandAllBtn.Text = "Expand All"
'			Me.expandAllBtn.Click += New System.EventHandler(Me.expandAllBtn_Click);
			' 
			' loadFileBtn
			' 
			Me.loadFileBtn.Location = New System.Drawing.Point(126, 3)
			Me.loadFileBtn.Name = "loadFileBtn"
			Me.loadFileBtn.Size = New System.Drawing.Size(117, 26)
			Me.loadFileBtn.TabIndex = 1
			Me.loadFileBtn.Text = "Load File..."
'			Me.loadFileBtn.Click += New System.EventHandler(Me.loadFileBtn_Click);
			' 
			' embeddedFileBtn
			' 
			Me.embeddedFileBtn.Location = New System.Drawing.Point(3, 3)
			Me.embeddedFileBtn.Name = "embeddedFileBtn"
			Me.embeddedFileBtn.Size = New System.Drawing.Size(117, 26)
			Me.embeddedFileBtn.TabIndex = 0
			Me.embeddedFileBtn.Text = "Embedded File"
'			Me.embeddedFileBtn.Click += New System.EventHandler(Me.embeddedFileBtn_Click);
			' 
			' NTreeViewExXmlViewerUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nTreeViewEx1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NTreeViewExXmlViewerUC"
			Me.Size = New System.Drawing.Size(564, 374)
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private nTreeViewEx1 As Nevron.UI.WinForm.Controls.NTreeViewEx
		Private panel1 As System.Windows.Forms.Panel
		Private WithEvents loadFileBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents embeddedFileBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents collapseAllBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents expandAllBtn As Nevron.UI.WinForm.Controls.NButton
	End Class
End Namespace
