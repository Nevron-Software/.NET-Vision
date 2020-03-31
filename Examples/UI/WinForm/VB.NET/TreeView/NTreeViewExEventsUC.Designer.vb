Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExEventsUC
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
			Me.trackNotificationsList = New Nevron.UI.WinForm.Controls.NListBox()
			Me.clearLogBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.cancelNotificationList = New Nevron.UI.WinForm.Controls.NListBox()
			Me.panel6 = New System.Windows.Forms.Panel()
			Me.label3 = New System.Windows.Forms.Label()
			Me.panel5 = New System.Windows.Forms.Panel()
			Me.label2 = New System.Windows.Forms.Label()
			Me.panel2 = New System.Windows.Forms.Panel()
			Me.batchUpdatesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.panel3 = New System.Windows.Forms.Panel()
			Me.nTextBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.panel4 = New System.Windows.Forms.Panel()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nSplitter1 = New Nevron.UI.WinForm.Controls.NSplitter()
			Me.nSplitter2 = New Nevron.UI.WinForm.Controls.NSplitter()
			Me.panel1.SuspendLayout()
			Me.panel6.SuspendLayout()
			Me.panel5.SuspendLayout()
			Me.panel2.SuspendLayout()
			Me.panel3.SuspendLayout()
			Me.panel4.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nTreeViewEx1
			' 
			Me.nTreeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nTreeViewEx1.Location = New System.Drawing.Point(0, 0)
			Me.nTreeViewEx1.Name = "nTreeViewEx1"
			Me.nTreeViewEx1.Size = New System.Drawing.Size(492, 254)
			Me.nTreeViewEx1.TabIndex = 0
			Me.nTreeViewEx1.Text = "nTreeViewEx1"
			' 
			' trackNotificationsList
			' 
			Me.trackNotificationsList.ColumnOnLeft = False
			Me.trackNotificationsList.Dock = System.Windows.Forms.DockStyle.Top
			Me.trackNotificationsList.Location = New System.Drawing.Point(0, 23)
			Me.trackNotificationsList.Name = "trackNotificationsList"
			Me.trackNotificationsList.Size = New System.Drawing.Size(246, 164)
			Me.trackNotificationsList.TabIndex = 1
			' 
			' clearLogBtn
			' 
			Me.clearLogBtn.Location = New System.Drawing.Point(6, 26)
			Me.clearLogBtn.Name = "clearLogBtn"
			Me.clearLogBtn.Size = New System.Drawing.Size(75, 23)
			Me.clearLogBtn.TabIndex = 0
			Me.clearLogBtn.Text = "Clear Log"
'			Me.clearLogBtn.Click += New System.EventHandler(Me.clearLogBtn_Click);
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.cancelNotificationList)
			Me.panel1.Controls.Add(Me.panel6)
			Me.panel1.Controls.Add(Me.trackNotificationsList)
			Me.panel1.Controls.Add(Me.panel5)
			Me.panel1.Controls.Add(Me.panel2)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Right
			Me.panel1.Location = New System.Drawing.Point(497, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(246, 445)
			Me.panel1.TabIndex = 4
			' 
			' cancelNotificationList
			' 
			Me.cancelNotificationList.ColumnOnLeft = False
			Me.cancelNotificationList.Dock = System.Windows.Forms.DockStyle.Fill
			Me.cancelNotificationList.Location = New System.Drawing.Point(0, 210)
			Me.cancelNotificationList.Name = "cancelNotificationList"
			Me.cancelNotificationList.Size = New System.Drawing.Size(246, 183)
			Me.cancelNotificationList.TabIndex = 4
			' 
			' panel6
			' 
			Me.panel6.Controls.Add(Me.label3)
			Me.panel6.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel6.Location = New System.Drawing.Point(0, 187)
			Me.panel6.Name = "panel6"
			Me.panel6.Size = New System.Drawing.Size(246, 23)
			Me.panel6.TabIndex = 5
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(3, 5)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(104, 13)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Cancel Notifications:"
			' 
			' panel5
			' 
			Me.panel5.Controls.Add(Me.label2)
			Me.panel5.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel5.Location = New System.Drawing.Point(0, 0)
			Me.panel5.Name = "panel5"
			Me.panel5.Size = New System.Drawing.Size(246, 23)
			Me.panel5.TabIndex = 3
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(3, 5)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(99, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Track Notifications:"
			' 
			' panel2
			' 
			Me.panel2.Controls.Add(Me.batchUpdatesCheck)
			Me.panel2.Controls.Add(Me.clearLogBtn)
			Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel2.Location = New System.Drawing.Point(0, 393)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(246, 52)
			Me.panel2.TabIndex = 2
			' 
			' batchUpdatesCheck
			' 
			Me.batchUpdatesCheck.AutoSize = True
			Me.batchUpdatesCheck.ButtonProperties.BorderOffset = 2
			Me.batchUpdatesCheck.Location = New System.Drawing.Point(6, 3)
			Me.batchUpdatesCheck.Name = "batchUpdatesCheck"
			Me.batchUpdatesCheck.Size = New System.Drawing.Size(133, 17)
			Me.batchUpdatesCheck.TabIndex = 1
			Me.batchUpdatesCheck.Text = "Enable Batch Updates"
'			Me.batchUpdatesCheck.CheckedChanged += New System.EventHandler(Me.batchUpdatesCheck_CheckedChanged);
			' 
			' panel3
			' 
			Me.panel3.Controls.Add(Me.nTextBox1)
			Me.panel3.Controls.Add(Me.panel4)
			Me.panel3.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel3.Location = New System.Drawing.Point(0, 259)
			Me.panel3.Name = "panel3"
			Me.panel3.Size = New System.Drawing.Size(497, 186)
			Me.panel3.TabIndex = 5
			' 
			' nTextBox1
			' 
			Me.nTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nTextBox1.Location = New System.Drawing.Point(0, 25)
			Me.nTextBox1.Multiline = True
			Me.nTextBox1.Name = "nTextBox1"
			Me.nTextBox1.Size = New System.Drawing.Size(497, 161)
			Me.nTextBox1.TabIndex = 2
			' 
			' panel4
			' 
			Me.panel4.Controls.Add(Me.label1)
			Me.panel4.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel4.Location = New System.Drawing.Point(0, 0)
			Me.panel4.Name = "panel4"
			Me.panel4.Size = New System.Drawing.Size(497, 25)
			Me.panel4.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(3, 3)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(78, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Event Log List:"
			' 
			' nSplitter1
			' 
			Me.nSplitter1.Dock = System.Windows.Forms.DockStyle.Right
			Me.nSplitter1.Location = New System.Drawing.Point(492, 0)
			Me.nSplitter1.Name = "nSplitter1"
			Me.nSplitter1.Size = New System.Drawing.Size(5, 259)
			Me.nSplitter1.TabIndex = 6
			Me.nSplitter1.TabStop = False
			' 
			' nSplitter2
			' 
			Me.nSplitter2.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.nSplitter2.Location = New System.Drawing.Point(0, 254)
			Me.nSplitter2.Name = "nSplitter2"
			Me.nSplitter2.Size = New System.Drawing.Size(492, 5)
			Me.nSplitter2.TabIndex = 7
			Me.nSplitter2.TabStop = False
			' 
			' NTreeViewExEventsUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nTreeViewEx1)
			Me.Controls.Add(Me.nSplitter2)
			Me.Controls.Add(Me.nSplitter1)
			Me.Controls.Add(Me.panel3)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NTreeViewExEventsUC"
			Me.Size = New System.Drawing.Size(743, 445)
			Me.panel1.ResumeLayout(False)
			Me.panel6.ResumeLayout(False)
			Me.panel6.PerformLayout()
			Me.panel5.ResumeLayout(False)
			Me.panel5.PerformLayout()
			Me.panel2.ResumeLayout(False)
			Me.panel2.PerformLayout()
			Me.panel3.ResumeLayout(False)
			Me.panel4.ResumeLayout(False)
			Me.panel4.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private nTreeViewEx1 As Nevron.UI.WinForm.Controls.NTreeViewEx
		Private trackNotificationsList As Nevron.UI.WinForm.Controls.NListBox
		Private WithEvents clearLogBtn As Nevron.UI.WinForm.Controls.NButton
		Private panel1 As System.Windows.Forms.Panel
		Private panel2 As System.Windows.Forms.Panel
		Private panel3 As System.Windows.Forms.Panel
		Private panel4 As System.Windows.Forms.Panel
		Private label1 As System.Windows.Forms.Label
		Private nSplitter1 As Nevron.UI.WinForm.Controls.NSplitter
		Private nSplitter2 As Nevron.UI.WinForm.Controls.NSplitter
		Private panel5 As System.Windows.Forms.Panel
		Private label2 As System.Windows.Forms.Label
		Private WithEvents batchUpdatesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nTextBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private cancelNotificationList As Nevron.UI.WinForm.Controls.NListBox
		Private panel6 As System.Windows.Forms.Panel
		Private label3 As System.Windows.Forms.Label
	End Class
End Namespace
