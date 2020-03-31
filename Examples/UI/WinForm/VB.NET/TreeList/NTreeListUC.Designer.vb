Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeListUC
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
			Me.mainPanel = New System.Windows.Forms.Panel()
			Me.propertiesPanel = New System.Windows.Forms.Panel()
			Me.nSplitter1 = New Nevron.UI.WinForm.Controls.NSplitter()
			Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
			Me.actionPanel = New System.Windows.Forms.Panel()
			Me.containerPanel = New System.Windows.Forms.Panel()
			Me.nSplitter2 = New Nevron.UI.WinForm.Controls.NSplitter()
			Me.mainPanel.SuspendLayout()
			Me.propertiesPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' mainPanel
			' 
			Me.mainPanel.Controls.Add(Me.containerPanel)
			Me.mainPanel.Controls.Add(Me.nSplitter2)
			Me.mainPanel.Controls.Add(Me.actionPanel)
			Me.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.mainPanel.Location = New System.Drawing.Point(0, 0)
			Me.mainPanel.Name = "mainPanel"
			Me.mainPanel.Size = New System.Drawing.Size(450, 350)
			Me.mainPanel.TabIndex = 0
			' 
			' propertiesPanel
			' 
			Me.propertiesPanel.Controls.Add(Me.propertyGrid1)
			Me.propertiesPanel.Dock = System.Windows.Forms.DockStyle.Right
			Me.propertiesPanel.Location = New System.Drawing.Point(455, 0)
			Me.propertiesPanel.Name = "propertiesPanel"
			Me.propertiesPanel.Size = New System.Drawing.Size(228, 350)
			Me.propertiesPanel.TabIndex = 1
			' 
			' nSplitter1
			' 
			Me.nSplitter1.Dock = System.Windows.Forms.DockStyle.Right
			Me.nSplitter1.Location = New System.Drawing.Point(450, 0)
			Me.nSplitter1.MinimumSize = New System.Drawing.Size(5, 34)
			Me.nSplitter1.Name = "nSplitter1"
			Me.nSplitter1.Size = New System.Drawing.Size(5, 350)
			Me.nSplitter1.TabIndex = 2
			Me.nSplitter1.TabStop = False
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.CommandsVisibleIfAvailable = False
			Me.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.propertyGrid1.Location = New System.Drawing.Point(0, 0)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.Size = New System.Drawing.Size(228, 350)
			Me.propertyGrid1.TabIndex = 0
			Me.propertyGrid1.ToolbarVisible = False
			' 
			' actionPanel
			' 
			Me.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.actionPanel.Location = New System.Drawing.Point(0, 300)
			Me.actionPanel.Name = "actionPanel"
			Me.actionPanel.Size = New System.Drawing.Size(450, 50)
			Me.actionPanel.TabIndex = 0
			' 
			' containerPanel
			' 
			Me.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.containerPanel.Location = New System.Drawing.Point(0, 0)
			Me.containerPanel.Name = "containerPanel"
			Me.containerPanel.Size = New System.Drawing.Size(450, 295)
			Me.containerPanel.TabIndex = 1
			' 
			' nSplitter2
			' 
			Me.nSplitter2.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.nSplitter2.Location = New System.Drawing.Point(0, 295)
			Me.nSplitter2.MinimumSize = New System.Drawing.Size(34, 5)
			Me.nSplitter2.Name = "nSplitter2"
			Me.nSplitter2.Size = New System.Drawing.Size(450, 5)
			Me.nSplitter2.TabIndex = 2
			Me.nSplitter2.TabStop = False
			' 
			' NTreeListUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.mainPanel)
			Me.Controls.Add(Me.nSplitter1)
			Me.Controls.Add(Me.propertiesPanel)
			Me.Name = "NTreeListUC"
			Me.Size = New System.Drawing.Size(683, 350)
			Me.mainPanel.ResumeLayout(False)
			Me.propertiesPanel.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private mainPanel As System.Windows.Forms.Panel
		Private propertiesPanel As System.Windows.Forms.Panel
		Private nSplitter1 As Nevron.UI.WinForm.Controls.NSplitter
		Private actionPanel As System.Windows.Forms.Panel
		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private containerPanel As System.Windows.Forms.Panel
		Private nSplitter2 As Nevron.UI.WinForm.Controls.NSplitter
	End Class
End Namespace
