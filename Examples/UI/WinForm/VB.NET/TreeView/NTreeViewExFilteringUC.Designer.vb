Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExFilteringUC
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.filterCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.descriptionLabel = New System.Windows.Forms.Label()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nTreeViewEx1
			' 
			Me.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nTreeViewEx1.Location = New System.Drawing.Point(0, 0)
			Me.nTreeViewEx1.Name = "nTreeViewEx1"
			Me.nTreeViewEx1.Size = New System.Drawing.Size(608, 228)
			Me.nTreeViewEx1.TabIndex = 0
			Me.nTreeViewEx1.Text = "nTreeViewEx1"
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.descriptionLabel)
			Me.panel1.Controls.Add(Me.label2)
			Me.panel1.Controls.Add(Me.filterCombo)
			Me.panel1.Controls.Add(Me.label1)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 228)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(608, 117)
			Me.panel1.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(26, 3)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(65, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Select Filter:"
			' 
			' filterCombo
			' 
			Me.filterCombo.Location = New System.Drawing.Point(97, 3)
			Me.filterCombo.Name = "filterCombo"
			Me.filterCombo.Size = New System.Drawing.Size(212, 22)
			Me.filterCombo.TabIndex = 1
			Me.filterCombo.Text = "nComboBox1"
'			Me.filterCombo.SelectedIndexChanged += New System.EventHandler(Me.filterCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(3, 37)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(88, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Filter Description:"
			' 
			' descriptionLabel
			' 
			Me.descriptionLabel.Location = New System.Drawing.Point(97, 37)
			Me.descriptionLabel.Name = "descriptionLabel"
			Me.descriptionLabel.Size = New System.Drawing.Size(212, 80)
			Me.descriptionLabel.TabIndex = 3
			' 
			' NTreeViewExFilteringUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nTreeViewEx1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NTreeViewExFilteringUC"
			Me.Size = New System.Drawing.Size(608, 345)
			Me.panel1.ResumeLayout(False)
			Me.panel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private nTreeViewEx1 As Nevron.UI.WinForm.Controls.NTreeViewEx
		Private panel1 As System.Windows.Forms.Panel
		Private descriptionLabel As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents filterCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
	End Class
End Namespace
