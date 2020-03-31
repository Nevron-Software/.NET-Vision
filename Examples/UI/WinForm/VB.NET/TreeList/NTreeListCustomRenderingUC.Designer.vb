Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeListCustomRenderingUC
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
			Me.autoSizeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.subItemRendererCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.headerRendererCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.containerPanel = New System.Windows.Forms.Panel()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.autoSizeCheck)
			Me.panel1.Controls.Add(Me.subItemRendererCheck)
			Me.panel1.Controls.Add(Me.headerRendererCheck)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 319)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(609, 47)
			Me.panel1.TabIndex = 0
			' 
			' autoSizeCheck
			' 
			Me.autoSizeCheck.AutoSize = True
			Me.autoSizeCheck.ButtonProperties.BorderOffset = 2
			Me.autoSizeCheck.Location = New System.Drawing.Point(313, 6)
			Me.autoSizeCheck.Name = "autoSizeCheck"
			Me.autoSizeCheck.Size = New System.Drawing.Size(112, 17)
			Me.autoSizeCheck.TabIndex = 2
			Me.autoSizeCheck.Text = "Auto-size Columns"
'			Me.autoSizeCheck.CheckedChanged += New System.EventHandler(Me.autoSizeCheck_CheckedChanged);
			' 
			' subItemRendererCheck
			' 
			Me.subItemRendererCheck.AutoSize = True
			Me.subItemRendererCheck.ButtonProperties.BorderOffset = 2
			Me.subItemRendererCheck.Checked = True
			Me.subItemRendererCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.subItemRendererCheck.Location = New System.Drawing.Point(155, 6)
			Me.subItemRendererCheck.Name = "subItemRendererCheck"
			Me.subItemRendererCheck.Size = New System.Drawing.Size(152, 17)
			Me.subItemRendererCheck.TabIndex = 1
			Me.subItemRendererCheck.Text = "Custom Sub-item Renderer"
'			Me.subItemRendererCheck.CheckedChanged += New System.EventHandler(Me.subItemRendererCheck_CheckedChanged);
			' 
			' headerRendererCheck
			' 
			Me.headerRendererCheck.AutoSize = True
			Me.headerRendererCheck.ButtonProperties.BorderOffset = 2
			Me.headerRendererCheck.Checked = True
			Me.headerRendererCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.headerRendererCheck.Location = New System.Drawing.Point(3, 6)
			Me.headerRendererCheck.Name = "headerRendererCheck"
			Me.headerRendererCheck.Size = New System.Drawing.Size(146, 17)
			Me.headerRendererCheck.TabIndex = 0
			Me.headerRendererCheck.Text = "Custom Header Renderer"
'			Me.headerRendererCheck.CheckedChanged += New System.EventHandler(Me.headerRendererCheck_CheckedChanged);
			' 
			' containerPanel
			' 
			Me.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.containerPanel.Location = New System.Drawing.Point(0, 0)
			Me.containerPanel.Name = "containerPanel"
			Me.containerPanel.Size = New System.Drawing.Size(609, 319)
			Me.containerPanel.TabIndex = 1
			' 
			' NTreeListCustomRenderingUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.containerPanel)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NTreeListCustomRenderingUC"
			Me.Size = New System.Drawing.Size(609, 366)
			Me.panel1.ResumeLayout(False)
			Me.panel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panel1 As System.Windows.Forms.Panel
		Private WithEvents headerRendererCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private containerPanel As System.Windows.Forms.Panel
		Private WithEvents subItemRendererCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents autoSizeCheck As Nevron.UI.WinForm.Controls.NCheckBox
	End Class
End Namespace
