Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExSortingUC
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
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.sortDescendingBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.sortAscendingBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.recursiveSortCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.containerPanel = New System.Windows.Forms.Panel()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.sortDescendingBtn)
			Me.panel1.Controls.Add(Me.sortAscendingBtn)
			Me.panel1.Controls.Add(Me.recursiveSortCheck)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 268)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(537, 57)
			Me.panel1.TabIndex = 0
			' 
			' sortDescendingBtn
			' 
			Me.sortDescendingBtn.Location = New System.Drawing.Point(105, 26)
			Me.sortDescendingBtn.Name = "sortDescendingBtn"
			Me.sortDescendingBtn.Size = New System.Drawing.Size(96, 23)
			Me.sortDescendingBtn.TabIndex = 2
			Me.sortDescendingBtn.Text = "Sort Descending"
'			Me.sortDescendingBtn.Click += New System.EventHandler(Me.sortDescendingBtn_Click);
			' 
			' sortAscendingBtn
			' 
			Me.sortAscendingBtn.Location = New System.Drawing.Point(3, 26)
			Me.sortAscendingBtn.Name = "sortAscendingBtn"
			Me.sortAscendingBtn.Size = New System.Drawing.Size(96, 23)
			Me.sortAscendingBtn.TabIndex = 1
			Me.sortAscendingBtn.Text = "Sort Ascending"
'			Me.sortAscendingBtn.Click += New System.EventHandler(Me.sortAscendingBtn_Click);
			' 
			' recursiveSortCheck
			' 
			Me.recursiveSortCheck.AutoSize = True
			Me.recursiveSortCheck.ButtonProperties.BorderOffset = 2
			Me.recursiveSortCheck.Checked = True
			Me.recursiveSortCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.recursiveSortCheck.Location = New System.Drawing.Point(3, 3)
			Me.recursiveSortCheck.Name = "recursiveSortCheck"
			Me.recursiveSortCheck.Size = New System.Drawing.Size(96, 17)
			Me.recursiveSortCheck.TabIndex = 0
			Me.recursiveSortCheck.Text = "Recursive Sort"
			' 
			' containerPanel
			' 
			Me.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.containerPanel.Location = New System.Drawing.Point(0, 0)
			Me.containerPanel.Name = "containerPanel"
			Me.containerPanel.Size = New System.Drawing.Size(537, 268)
			Me.containerPanel.TabIndex = 1
			' 
			' NTreeViewExSortingUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.containerPanel)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NTreeViewExSortingUC"
			Me.Size = New System.Drawing.Size(537, 325)
			Me.panel1.ResumeLayout(False)
			Me.panel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panel1 As System.Windows.Forms.Panel
		Private recursiveSortCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents sortDescendingBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents sortAscendingBtn As Nevron.UI.WinForm.Controls.NButton
		Private containerPanel As System.Windows.Forms.Panel
	End Class
End Namespace
