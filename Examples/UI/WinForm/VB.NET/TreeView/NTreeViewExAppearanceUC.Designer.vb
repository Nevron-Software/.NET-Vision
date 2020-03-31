Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExAppearanceUC
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
			Me.settings1Btn = New Nevron.UI.WinForm.Controls.NButton()
			Me.settings2Btn = New Nevron.UI.WinForm.Controls.NButton()
			Me.expandAllBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.collapseAllBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.expandToRightCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.multiSelectCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.imageHighlightCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nTreeViewEx1
			' 
			Me.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nTreeViewEx1.Location = New System.Drawing.Point(0, 0)
			Me.nTreeViewEx1.Name = "nTreeViewEx1"
			Me.nTreeViewEx1.Size = New System.Drawing.Size(510, 401)
			Me.nTreeViewEx1.TabIndex = 0
			Me.nTreeViewEx1.Text = "nTreeViewEx1"
			' 
			' settings1Btn
			' 
			Me.settings1Btn.Location = New System.Drawing.Point(3, 3)
			Me.settings1Btn.Name = "settings1Btn"
			Me.settings1Btn.Size = New System.Drawing.Size(75, 23)
			Me.settings1Btn.TabIndex = 1
			Me.settings1Btn.Text = "Settings 1"
'			Me.settings1Btn.Click += New System.EventHandler(Me.settings1Btn_Click);
			' 
			' settings2Btn
			' 
			Me.settings2Btn.Location = New System.Drawing.Point(84, 3)
			Me.settings2Btn.Name = "settings2Btn"
			Me.settings2Btn.Size = New System.Drawing.Size(75, 23)
			Me.settings2Btn.TabIndex = 2
			Me.settings2Btn.Text = "Settings 2"
'			Me.settings2Btn.Click += New System.EventHandler(Me.settings2Btn_Click);
			' 
			' expandAllBtn
			' 
			Me.expandAllBtn.Location = New System.Drawing.Point(180, 3)
			Me.expandAllBtn.Name = "expandAllBtn"
			Me.expandAllBtn.Size = New System.Drawing.Size(75, 23)
			Me.expandAllBtn.TabIndex = 3
			Me.expandAllBtn.Text = "Expand All"
'			Me.expandAllBtn.Click += New System.EventHandler(Me.expandAllBtn_Click);
			' 
			' collapseAllBtn
			' 
			Me.collapseAllBtn.Location = New System.Drawing.Point(261, 3)
			Me.collapseAllBtn.Name = "collapseAllBtn"
			Me.collapseAllBtn.Size = New System.Drawing.Size(75, 23)
			Me.collapseAllBtn.TabIndex = 4
			Me.collapseAllBtn.Text = "Collapse All"
'			Me.collapseAllBtn.Click += New System.EventHandler(Me.collapseAllBtn_Click);
			' 
			' expandToRightCheck
			' 
			Me.expandToRightCheck.AutoSize = True
			Me.expandToRightCheck.ButtonProperties.BorderOffset = 2
			Me.expandToRightCheck.Location = New System.Drawing.Point(3, 32)
			Me.expandToRightCheck.Name = "expandToRightCheck"
			Me.expandToRightCheck.Size = New System.Drawing.Size(97, 17)
			Me.expandToRightCheck.TabIndex = 5
			Me.expandToRightCheck.Text = "Expand to right"
'			Me.expandToRightCheck.CheckedChanged += New System.EventHandler(Me.expandToRightCheck_CheckedChanged);
			' 
			' multiSelectCheck
			' 
			Me.multiSelectCheck.AutoSize = True
			Me.multiSelectCheck.ButtonProperties.BorderOffset = 2
			Me.multiSelectCheck.Location = New System.Drawing.Point(106, 32)
			Me.multiSelectCheck.Name = "multiSelectCheck"
			Me.multiSelectCheck.Size = New System.Drawing.Size(76, 17)
			Me.multiSelectCheck.TabIndex = 6
			Me.multiSelectCheck.Text = "Multiselect"
'			Me.multiSelectCheck.CheckedChanged += New System.EventHandler(Me.multiSelectCheck_CheckedChanged);
			' 
			' imageHighlightCheck
			' 
			Me.imageHighlightCheck.AutoSize = True
			Me.imageHighlightCheck.ButtonProperties.BorderOffset = 2
			Me.imageHighlightCheck.Location = New System.Drawing.Point(188, 32)
			Me.imageHighlightCheck.Name = "imageHighlightCheck"
			Me.imageHighlightCheck.Size = New System.Drawing.Size(97, 17)
			Me.imageHighlightCheck.TabIndex = 7
			Me.imageHighlightCheck.Text = "Image highlight"
'			Me.imageHighlightCheck.CheckedChanged += New System.EventHandler(Me.imageHighlightCheck_CheckedChanged);
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.settings1Btn)
			Me.panel1.Controls.Add(Me.imageHighlightCheck)
			Me.panel1.Controls.Add(Me.settings2Btn)
			Me.panel1.Controls.Add(Me.multiSelectCheck)
			Me.panel1.Controls.Add(Me.expandAllBtn)
			Me.panel1.Controls.Add(Me.expandToRightCheck)
			Me.panel1.Controls.Add(Me.collapseAllBtn)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 401)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(510, 60)
			Me.panel1.TabIndex = 8
			' 
			' NTreeViewExAppearanceUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nTreeViewEx1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NTreeViewExAppearanceUC"
			Me.Size = New System.Drawing.Size(510, 461)
			Me.panel1.ResumeLayout(False)
			Me.panel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Friend nTreeViewEx1 As Nevron.UI.WinForm.Controls.NTreeViewEx
		Private WithEvents settings1Btn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents settings2Btn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents expandAllBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents collapseAllBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents expandToRightCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents multiSelectCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents imageHighlightCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private panel1 As System.Windows.Forms.Panel
	End Class
End Namespace
