Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NMaskedTextBoxUC
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
			Me.nMaskedTextBox1 = New Nevron.UI.WinForm.Controls.NMaskedTextBox()
			Me.enableSkinningCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.borderBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.paletteBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' nMaskedTextBox1
			' 
			Me.nMaskedTextBox1.Location = New System.Drawing.Point(3, 3)
			Me.nMaskedTextBox1.Mask = "00/00/0000"
			Me.nMaskedTextBox1.Name = "maskedTextBox1"
			Me.nMaskedTextBox1.Size = New System.Drawing.Size(275, 20)
			Me.nMaskedTextBox1.TabIndex = 0
			Me.nMaskedTextBox1.ValidatingType = GetType(System.DateTime)
			' 
			' enableSkinningCheck
			' 
			Me.enableSkinningCheck.AutoSize = True
			Me.enableSkinningCheck.ButtonProperties.BorderOffset = 2
			Me.enableSkinningCheck.Checked = True
			Me.enableSkinningCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.enableSkinningCheck.Location = New System.Drawing.Point(3, 58)
			Me.enableSkinningCheck.Name = "enableSkinningCheck"
			Me.enableSkinningCheck.Size = New System.Drawing.Size(103, 17)
			Me.enableSkinningCheck.TabIndex = 1
			Me.enableSkinningCheck.Text = "Enable Skinning"
'			Me.enableSkinningCheck.CheckedChanged += New System.EventHandler(Me.enableSkinningCheck_CheckedChanged);
			' 
			' borderBtn
			' 
			Me.borderBtn.Enabled = False
			Me.borderBtn.Location = New System.Drawing.Point(3, 29)
			Me.borderBtn.Name = "borderBtn"
			Me.borderBtn.Size = New System.Drawing.Size(75, 23)
			Me.borderBtn.TabIndex = 2
			Me.borderBtn.Text = "Border..."
'			Me.borderBtn.Click += New System.EventHandler(Me.borderBtn_Click);
			' 
			' paletteBtn
			' 
			Me.paletteBtn.Enabled = False
			Me.paletteBtn.Location = New System.Drawing.Point(84, 29)
			Me.paletteBtn.Name = "paletteBtn"
			Me.paletteBtn.Size = New System.Drawing.Size(75, 23)
			Me.paletteBtn.TabIndex = 3
			Me.paletteBtn.Text = "Palette..."
'			Me.paletteBtn.Click += New System.EventHandler(Me.paletteBtn_Click);
			' 
			' NMaskedTextBoxUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.paletteBtn)
			Me.Controls.Add(Me.borderBtn)
			Me.Controls.Add(Me.enableSkinningCheck)
			Me.Controls.Add(Me.nMaskedTextBox1)
			Me.Name = "NMaskedTextBoxUC"
			Me.Size = New System.Drawing.Size(337, 239)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private nMaskedTextBox1 As Nevron.UI.WinForm.Controls.NMaskedTextBox
		Private WithEvents enableSkinningCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents borderBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents paletteBtn As Nevron.UI.WinForm.Controls.NButton
	End Class
End Namespace
