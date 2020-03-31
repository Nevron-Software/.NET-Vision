Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeListOutlookReportUC
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
				m_Helper.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.actionPanel = New System.Windows.Forms.Panel()
			Me.containerPanel = New System.Windows.Forms.Panel()
			Me.SuspendLayout()
			' 
			' actionPanel
			' 
			Me.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.actionPanel.Location = New System.Drawing.Point(0, 235)
			Me.actionPanel.Name = "actionPanel"
			Me.actionPanel.Size = New System.Drawing.Size(474, 50)
			Me.actionPanel.TabIndex = 0
			' 
			' containerPanel
			' 
			Me.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.containerPanel.Location = New System.Drawing.Point(0, 0)
			Me.containerPanel.Name = "containerPanel"
			Me.containerPanel.Size = New System.Drawing.Size(474, 235)
			Me.containerPanel.TabIndex = 1
			' 
			' NTreeListOutlookReportUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.containerPanel)
			Me.Controls.Add(Me.actionPanel)
			Me.Name = "NTreeListOutlookReportUC"
			Me.Size = New System.Drawing.Size(474, 285)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private actionPanel As System.Windows.Forms.Panel
		Private containerPanel As System.Windows.Forms.Panel
	End Class
End Namespace
