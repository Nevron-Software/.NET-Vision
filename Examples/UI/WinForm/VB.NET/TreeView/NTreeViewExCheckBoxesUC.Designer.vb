Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExCheckBoxesUC
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
			Me.autoCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.checkStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.checkedItemsBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.indeterminateBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nTreeViewEx1
			' 
			Me.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nTreeViewEx1.Location = New System.Drawing.Point(0, 0)
			Me.nTreeViewEx1.Name = "nTreeViewEx1"
			Me.nTreeViewEx1.Size = New System.Drawing.Size(650, 360)
			Me.nTreeViewEx1.TabIndex = 0
			Me.nTreeViewEx1.Text = "nTreeViewEx1"
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.indeterminateBtn)
			Me.panel1.Controls.Add(Me.checkedItemsBtn)
			Me.panel1.Controls.Add(Me.autoCheck)
			Me.panel1.Controls.Add(Me.checkStyleCombo)
			Me.panel1.Controls.Add(Me.label1)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 360)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(650, 68)
			Me.panel1.TabIndex = 1
			' 
			' autoCheck
			' 
			Me.autoCheck.AutoSize = True
			Me.autoCheck.ButtonProperties.BorderOffset = 2
			Me.autoCheck.Location = New System.Drawing.Point(105, 31)
			Me.autoCheck.Name = "autoCheck"
			Me.autoCheck.Size = New System.Drawing.Size(118, 17)
			Me.autoCheck.TabIndex = 2
			Me.autoCheck.Text = "Enable Auto-Check"
'			Me.autoCheck.CheckedChanged += New System.EventHandler(Me.autoCheck_CheckedChanged);
			' 
			' checkStyleCombo
			' 
			Me.checkStyleCombo.Location = New System.Drawing.Point(105, 3)
			Me.checkStyleCombo.Name = "checkStyleCombo"
			Me.checkStyleCombo.Size = New System.Drawing.Size(167, 22)
			Me.checkStyleCombo.TabIndex = 1
			Me.checkStyleCombo.Text = "nComboBox1"
'			Me.checkStyleCombo.SelectedIndexChanged += New System.EventHandler(Me.checkStyleCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(3, 3)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(96, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Check Style:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' checkedItemsBtn
			' 
			Me.checkedItemsBtn.Location = New System.Drawing.Point(301, 31)
			Me.checkedItemsBtn.Name = "checkedItemsBtn"
			Me.checkedItemsBtn.Size = New System.Drawing.Size(107, 23)
			Me.checkedItemsBtn.TabIndex = 3
			Me.checkedItemsBtn.Text = "Checked Items"
'			Me.checkedItemsBtn.Click += New System.EventHandler(Me.checkedItemsBtn_Click);
			' 
			' indeterminateBtn
			' 
			Me.indeterminateBtn.Location = New System.Drawing.Point(414, 31)
			Me.indeterminateBtn.Name = "indeterminateBtn"
			Me.indeterminateBtn.Size = New System.Drawing.Size(107, 23)
			Me.indeterminateBtn.TabIndex = 4
			Me.indeterminateBtn.Text = "Indeterminate Items"
'			Me.indeterminateBtn.Click += New System.EventHandler(Me.indeterminateBtn_Click);
			' 
			' NTreeViewExCheckBoxesUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nTreeViewEx1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NTreeViewExCheckBoxesUC"
			Me.Size = New System.Drawing.Size(650, 428)
			Me.panel1.ResumeLayout(False)
			Me.panel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private nTreeViewEx1 As Nevron.UI.WinForm.Controls.NTreeViewEx
		Private panel1 As System.Windows.Forms.Panel
		Private WithEvents checkStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents autoCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents indeterminateBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents checkedItemsBtn As Nevron.UI.WinForm.Controls.NButton
	End Class
End Namespace
