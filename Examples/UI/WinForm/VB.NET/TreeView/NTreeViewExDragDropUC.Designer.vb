Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExDragDropUC
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
			Me.expandNodeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.autoScrollCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.showHintsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.enableDragCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.expandAllBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.collapseAllBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nTreeViewEx1
			' 
			Me.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nTreeViewEx1.Location = New System.Drawing.Point(0, 0)
			Me.nTreeViewEx1.Name = "nTreeViewEx1"
			Me.nTreeViewEx1.Size = New System.Drawing.Size(631, 269)
			Me.nTreeViewEx1.TabIndex = 0
			Me.nTreeViewEx1.Text = "nTreeViewEx1"
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.collapseAllBtn)
			Me.panel1.Controls.Add(Me.expandAllBtn)
			Me.panel1.Controls.Add(Me.expandNodeCheck)
			Me.panel1.Controls.Add(Me.autoScrollCheck)
			Me.panel1.Controls.Add(Me.showHintsCheck)
			Me.panel1.Controls.Add(Me.enableDragCheck)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 269)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(631, 53)
			Me.panel1.TabIndex = 1
			' 
			' expandNodeCheck
			' 
			Me.expandNodeCheck.AutoSize = True
			Me.expandNodeCheck.ButtonProperties.BorderOffset = 2
			Me.expandNodeCheck.Location = New System.Drawing.Point(210, 26)
			Me.expandNodeCheck.Name = "expandNodeCheck"
			Me.expandNodeCheck.Size = New System.Drawing.Size(156, 17)
			Me.expandNodeCheck.TabIndex = 3
			Me.expandNodeCheck.Text = "Expand Node on Drag-over"
'			Me.expandNodeCheck.CheckedChanged += New System.EventHandler(Me.expandNodeCheck_CheckedChanged);
			' 
			' autoScrollCheck
			' 
			Me.autoScrollCheck.AutoSize = True
			Me.autoScrollCheck.ButtonProperties.BorderOffset = 2
			Me.autoScrollCheck.Location = New System.Drawing.Point(210, 3)
			Me.autoScrollCheck.Name = "autoScrollCheck"
			Me.autoScrollCheck.Size = New System.Drawing.Size(182, 17)
			Me.autoScrollCheck.TabIndex = 2
			Me.autoScrollCheck.Text = "Enable Drag-and-drop Auto-scroll"
'			Me.autoScrollCheck.CheckedChanged += New System.EventHandler(Me.autoScrollCheck_CheckedChanged);
			' 
			' showHintsCheck
			' 
			Me.showHintsCheck.AutoSize = True
			Me.showHintsCheck.ButtonProperties.BorderOffset = 2
			Me.showHintsCheck.Location = New System.Drawing.Point(3, 26)
			Me.showHintsCheck.Name = "showHintsCheck"
			Me.showHintsCheck.Size = New System.Drawing.Size(151, 17)
			Me.showHintsCheck.TabIndex = 1
			Me.showHintsCheck.Text = "Show Drag-and-drop Hints"
'			Me.showHintsCheck.CheckedChanged += New System.EventHandler(Me.showHintsCheck_CheckedChanged);
			' 
			' enableDragCheck
			' 
			Me.enableDragCheck.AutoSize = True
			Me.enableDragCheck.ButtonProperties.BorderOffset = 2
			Me.enableDragCheck.Location = New System.Drawing.Point(3, 3)
			Me.enableDragCheck.Name = "enableDragCheck"
			Me.enableDragCheck.Size = New System.Drawing.Size(130, 17)
			Me.enableDragCheck.TabIndex = 0
			Me.enableDragCheck.Text = "Enable Drag-and-drop"
'			Me.enableDragCheck.CheckedChanged += New System.EventHandler(Me.enableDragCheck_CheckedChanged);
			' 
			' expandAllBtn
			' 
			Me.expandAllBtn.Location = New System.Drawing.Point(422, 3)
			Me.expandAllBtn.Name = "expandAllBtn"
			Me.expandAllBtn.Size = New System.Drawing.Size(75, 23)
			Me.expandAllBtn.TabIndex = 4
			Me.expandAllBtn.Text = "Expand All"
'			Me.expandAllBtn.Click += New System.EventHandler(Me.expandAllBtn_Click);
			' 
			' collapseAllBtn
			' 
			Me.collapseAllBtn.Location = New System.Drawing.Point(503, 3)
			Me.collapseAllBtn.Name = "collapseAllBtn"
			Me.collapseAllBtn.Size = New System.Drawing.Size(75, 23)
			Me.collapseAllBtn.TabIndex = 5
			Me.collapseAllBtn.Text = "Collapse All"
'			Me.collapseAllBtn.Click += New System.EventHandler(Me.collapseAllBtn_Click);
			' 
			' NTreeViewExDragDropUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nTreeViewEx1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NTreeViewExDragDropUC"
			Me.Size = New System.Drawing.Size(631, 322)
			Me.panel1.ResumeLayout(False)
			Me.panel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private nTreeViewEx1 As Nevron.UI.WinForm.Controls.NTreeViewEx
		Private panel1 As System.Windows.Forms.Panel
		Private WithEvents showHintsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents enableDragCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents autoScrollCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents expandNodeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents collapseAllBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents expandAllBtn As Nevron.UI.WinForm.Controls.NButton
	End Class
End Namespace
