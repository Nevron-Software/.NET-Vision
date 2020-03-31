Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExUC
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
			Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
			Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
			Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
			Me.addChildBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.addSiblingBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.removeNodeBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.expandAllBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.collapseAllBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.addTestNodesBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.splitContainer1.Panel1.SuspendLayout()
			Me.splitContainer1.Panel2.SuspendLayout()
			Me.splitContainer1.SuspendLayout()
			Me.splitContainer2.Panel1.SuspendLayout()
			Me.splitContainer2.Panel2.SuspendLayout()
			Me.splitContainer2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nTreeViewEx1
			' 
			Me.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nTreeViewEx1.IndicatorLength = 20
			Me.nTreeViewEx1.Location = New System.Drawing.Point(0, 0)
			Me.nTreeViewEx1.Name = "nTreeViewEx1"
			Me.nTreeViewEx1.Size = New System.Drawing.Size(433, 406)
			Me.nTreeViewEx1.TabIndex = 0
			Me.nTreeViewEx1.Text = "nTreeViewEx1"
			' 
			' splitContainer1
			' 
			Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
			Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
			Me.splitContainer1.Name = "splitContainer1"
			' 
			' splitContainer1.Panel1
			' 
			Me.splitContainer1.Panel1.Controls.Add(Me.splitContainer2)
			Me.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
			' 
			' splitContainer1.Panel2
			' 
			Me.splitContainer1.Panel2.Controls.Add(Me.propertyGrid1)
			Me.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.splitContainer1.Size = New System.Drawing.Size(686, 474)
			Me.splitContainer1.SplitterDistance = 433
			Me.splitContainer1.TabIndex = 1
			' 
			' splitContainer2
			' 
			Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
			Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
			Me.splitContainer2.Name = "splitContainer2"
			Me.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
			' 
			' splitContainer2.Panel1
			' 
			Me.splitContainer2.Panel1.Controls.Add(Me.nTreeViewEx1)
			' 
			' splitContainer2.Panel2
			' 
			Me.splitContainer2.Panel2.Controls.Add(Me.addTestNodesBtn)
			Me.splitContainer2.Panel2.Controls.Add(Me.collapseAllBtn)
			Me.splitContainer2.Panel2.Controls.Add(Me.expandAllBtn)
			Me.splitContainer2.Panel2.Controls.Add(Me.removeNodeBtn)
			Me.splitContainer2.Panel2.Controls.Add(Me.addSiblingBtn)
			Me.splitContainer2.Panel2.Controls.Add(Me.addChildBtn)
			Me.splitContainer2.Size = New System.Drawing.Size(433, 474)
			Me.splitContainer2.SplitterDistance = 406
			Me.splitContainer2.TabIndex = 1
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.propertyGrid1.Location = New System.Drawing.Point(0, 0)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.Size = New System.Drawing.Size(249, 474)
			Me.propertyGrid1.TabIndex = 0
			Me.propertyGrid1.ToolbarVisible = False
			' 
			' addChildBtn
			' 
			Me.addChildBtn.Location = New System.Drawing.Point(3, 3)
			Me.addChildBtn.Name = "addChildBtn"
			Me.addChildBtn.Size = New System.Drawing.Size(75, 24)
			Me.addChildBtn.TabIndex = 0
			Me.addChildBtn.Text = "Add Child"
'			Me.addChildBtn.Click += New System.EventHandler(Me.addChildBtn_Click);
			' 
			' addSiblingBtn
			' 
			Me.addSiblingBtn.Location = New System.Drawing.Point(84, 3)
			Me.addSiblingBtn.Name = "addSiblingBtn"
			Me.addSiblingBtn.Size = New System.Drawing.Size(75, 24)
			Me.addSiblingBtn.TabIndex = 1
			Me.addSiblingBtn.Text = "Add Sibling"
'			Me.addSiblingBtn.Click += New System.EventHandler(Me.addSiblingBtn_Click);
			' 
			' removeNodeBtn
			' 
			Me.removeNodeBtn.Location = New System.Drawing.Point(263, 3)
			Me.removeNodeBtn.Name = "removeNodeBtn"
			Me.removeNodeBtn.Size = New System.Drawing.Size(92, 24)
			Me.removeNodeBtn.TabIndex = 2
			Me.removeNodeBtn.Text = "Remove Node(s)"
'			Me.removeNodeBtn.Click += New System.EventHandler(Me.removeNodeBtn_Click);
			' 
			' expandAllBtn
			' 
			Me.expandAllBtn.Location = New System.Drawing.Point(3, 33)
			Me.expandAllBtn.Name = "expandAllBtn"
			Me.expandAllBtn.Size = New System.Drawing.Size(75, 24)
			Me.expandAllBtn.TabIndex = 3
			Me.expandAllBtn.Text = "Expand All"
'			Me.expandAllBtn.Click += New System.EventHandler(Me.expandAllBtn_Click);
			' 
			' collapseAllBtn
			' 
			Me.collapseAllBtn.Location = New System.Drawing.Point(84, 33)
			Me.collapseAllBtn.Name = "collapseAllBtn"
			Me.collapseAllBtn.Size = New System.Drawing.Size(75, 24)
			Me.collapseAllBtn.TabIndex = 4
			Me.collapseAllBtn.Text = "Collapse All"
'			Me.collapseAllBtn.Click += New System.EventHandler(Me.collapseAllBtn_Click);
			' 
			' addTestNodesBtn
			' 
			Me.addTestNodesBtn.Location = New System.Drawing.Point(165, 3)
			Me.addTestNodesBtn.Name = "addTestNodesBtn"
			Me.addTestNodesBtn.Size = New System.Drawing.Size(92, 24)
			Me.addTestNodesBtn.TabIndex = 5
			Me.addTestNodesBtn.Text = "Add Test Nodes"
'			Me.addTestNodesBtn.Click += New System.EventHandler(Me.addTestNodesBtn_Click);
			' 
			' NTreeViewExUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.splitContainer1)
			Me.Name = "NTreeViewExUC"
			Me.Size = New System.Drawing.Size(686, 474)
			Me.splitContainer1.Panel1.ResumeLayout(False)
			Me.splitContainer1.Panel2.ResumeLayout(False)
			Me.splitContainer1.ResumeLayout(False)
			Me.splitContainer2.Panel1.ResumeLayout(False)
			Me.splitContainer2.Panel2.ResumeLayout(False)
			Me.splitContainer2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private nTreeViewEx1 As Nevron.UI.WinForm.Controls.NTreeViewEx
		Private splitContainer1 As System.Windows.Forms.SplitContainer
		Private splitContainer2 As System.Windows.Forms.SplitContainer
		Private WithEvents removeNodeBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents addSiblingBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents addChildBtn As Nevron.UI.WinForm.Controls.NButton
		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private WithEvents addTestNodesBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents collapseAllBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents expandAllBtn As Nevron.UI.WinForm.Controls.NButton

	End Class
End Namespace
