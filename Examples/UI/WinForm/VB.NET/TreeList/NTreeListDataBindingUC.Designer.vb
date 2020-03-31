Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeListDataBindingUC
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

				m_List.GroupNodeDefaultState.Font.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.containerPanel = New System.Windows.Forms.Panel()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 293)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(588, 62)
			Me.panel1.TabIndex = 0
			' 
			' containerPanel
			' 
			Me.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.containerPanel.Location = New System.Drawing.Point(0, 0)
			Me.containerPanel.Name = "containerPanel"
			Me.containerPanel.Size = New System.Drawing.Size(588, 293)
			Me.containerPanel.TabIndex = 1
			' 
			' NTreeListDataBindingUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.containerPanel)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NTreeListDataBindingUC"
			Me.Size = New System.Drawing.Size(588, 355)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panel1 As System.Windows.Forms.Panel
		Private containerPanel As System.Windows.Forms.Panel
	End Class
End Namespace
