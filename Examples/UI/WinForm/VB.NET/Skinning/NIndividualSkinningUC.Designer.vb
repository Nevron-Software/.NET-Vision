Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NIndividualSkinningUC
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
			Me.components = New System.ComponentModel.Container()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.buttonsSkinCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nRadioButton1 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nhScrollBar2 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.scrollSkinCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nvScrollBar1 = New Nevron.UI.WinForm.Controls.NVScrollBar()
			Me.nhScrollBar1 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.commandBarsSkinCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.nCommandBarsManager1 = New Nevron.UI.WinForm.Controls.NCommandBarsManager(Me.components)
			Me.nCommandContext1 = New Nevron.UI.WinForm.Controls.NCommandContext()
			Me.nDockingToolbar1 = New Nevron.UI.WinForm.Controls.NDockingToolbar()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand8 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand3 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nDockingToolbar2 = New Nevron.UI.WinForm.Controls.NDockingToolbar()
			Me.nCommand6 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand10 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand7 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nDockingToolbar3 = New Nevron.UI.WinForm.Controls.NDockingToolbar()
			Me.nCommand12 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand11 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nDockingToolbar4 = New Nevron.UI.WinForm.Controls.NDockingToolbar()
			Me.nCommand5 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand9 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand4 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.panel1.SuspendLayout()
			CType(Me.nCommandBarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nButton1
			' 
			Me.nButton1.Location = New System.Drawing.Point(6, 19)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.Size = New System.Drawing.Size(103, 23)
			Me.nButton1.TabIndex = 0
			Me.nButton1.Text = "nButton1"
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.buttonsSkinCombo)
			Me.nGroupBox1.Controls.Add(Me.label1)
			Me.nGroupBox1.Controls.Add(Me.nRadioButton1)
			Me.nGroupBox1.Controls.Add(Me.nCheckBox1)
			Me.nGroupBox1.Controls.Add(Me.nButton1)
			Me.nGroupBox1.Location = New System.Drawing.Point(3, 3)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(185, 148)
			Me.nGroupBox1.TabIndex = 1
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Buttons"
			' 
			' buttonsSkinCombo
			' 
			Me.buttonsSkinCombo.Location = New System.Drawing.Point(9, 120)
			Me.buttonsSkinCombo.Name = "buttonsSkinCombo"
			Me.buttonsSkinCombo.Size = New System.Drawing.Size(166, 22)
			Me.buttonsSkinCombo.TabIndex = 4
			Me.buttonsSkinCombo.Text = "nComboBox1"
'			Me.buttonsSkinCombo.SelectedIndexChanged += New System.EventHandler(Me.buttonsSkinCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 94)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(45, 23)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Skin:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nRadioButton1
			' 
			Me.nRadioButton1.AutoSize = True
			Me.nRadioButton1.ButtonProperties.BorderOffset = 2
			Me.nRadioButton1.Location = New System.Drawing.Point(6, 71)
			Me.nRadioButton1.Name = "nRadioButton1"
			Me.nRadioButton1.Size = New System.Drawing.Size(96, 17)
			Me.nRadioButton1.TabIndex = 2
			Me.nRadioButton1.Text = "nRadioButton1"
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.AutoSize = True
			Me.nCheckBox1.ButtonProperties.BorderOffset = 2
			Me.nCheckBox1.Location = New System.Drawing.Point(6, 48)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(87, 17)
			Me.nCheckBox1.TabIndex = 1
			Me.nCheckBox1.Text = "nCheckBox1"
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.nhScrollBar2)
			Me.nGroupBox2.Controls.Add(Me.scrollSkinCombo)
			Me.nGroupBox2.Controls.Add(Me.label2)
			Me.nGroupBox2.Controls.Add(Me.nvScrollBar1)
			Me.nGroupBox2.Controls.Add(Me.nhScrollBar1)
			Me.nGroupBox2.Location = New System.Drawing.Point(194, 3)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(200, 148)
			Me.nGroupBox2.TabIndex = 2
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Scrollbars"
			' 
			' nhScrollBar2
			' 
			Me.nhScrollBar2.Location = New System.Drawing.Point(32, 42)
			Me.nhScrollBar2.Maximum = 50
			Me.nhScrollBar2.MinimumSize = New System.Drawing.Size(32, 16)
			Me.nhScrollBar2.Name = "nhScrollBar2"
			Me.nhScrollBar2.Size = New System.Drawing.Size(162, 17)
			Me.nhScrollBar2.TabIndex = 6
			Me.nhScrollBar2.Text = "nhScrollBar2"
			' 
			' scrollSkinCombo
			' 
			Me.scrollSkinCombo.Location = New System.Drawing.Point(32, 120)
			Me.scrollSkinCombo.Name = "scrollSkinCombo"
			Me.scrollSkinCombo.Size = New System.Drawing.Size(162, 22)
			Me.scrollSkinCombo.TabIndex = 5
			Me.scrollSkinCombo.Text = "nComboBox1"
'			Me.scrollSkinCombo.SelectedIndexChanged += New System.EventHandler(Me.scrollSkinCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(29, 94)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(45, 23)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Skin:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nvScrollBar1
			' 
			Me.nvScrollBar1.Location = New System.Drawing.Point(6, 42)
			Me.nvScrollBar1.Maximum = 30
			Me.nvScrollBar1.MinimumSize = New System.Drawing.Size(16, 32)
			Me.nvScrollBar1.Name = "nvScrollBar1"
			Me.nvScrollBar1.Size = New System.Drawing.Size(17, 100)
			Me.nvScrollBar1.TabIndex = 1
			Me.nvScrollBar1.Text = "nvScrollBar1"
			' 
			' nhScrollBar1
			' 
			Me.nhScrollBar1.Location = New System.Drawing.Point(6, 19)
			Me.nhScrollBar1.Maximum = 50
			Me.nhScrollBar1.MinimumSize = New System.Drawing.Size(32, 16)
			Me.nhScrollBar1.Name = "nhScrollBar1"
			Me.nhScrollBar1.Size = New System.Drawing.Size(188, 17)
			Me.nhScrollBar1.TabIndex = 0
			Me.nhScrollBar1.Text = "nhScrollBar1"
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.panel1)
			Me.nGroupBox3.Location = New System.Drawing.Point(3, 157)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(391, 202)
			Me.nGroupBox3.TabIndex = 3
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Command bars"
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.commandBarsSkinCombo)
			Me.panel1.Controls.Add(Me.label3)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panel1.Location = New System.Drawing.Point(3, 16)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(385, 183)
			Me.panel1.TabIndex = 0
			' 
			' commandBarsSkinCombo
			' 
			Me.commandBarsSkinCombo.Location = New System.Drawing.Point(125, 85)
			Me.commandBarsSkinCombo.Name = "commandBarsSkinCombo"
			Me.commandBarsSkinCombo.Size = New System.Drawing.Size(166, 22)
			Me.commandBarsSkinCombo.TabIndex = 9
			Me.commandBarsSkinCombo.Text = "nComboBox1"
'			Me.commandBarsSkinCombo.SelectedIndexChanged += New System.EventHandler(Me.commandBarsSkinCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(125, 59)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(47, 23)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Skin:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nCommandBarsManager1
			' 
			Me.nCommandBarsManager1.Contexts.AddRange(New Nevron.UI.WinForm.Controls.NCommandContext() { Me.nCommandContext1})
			Me.nCommandBarsManager1.ParentControl = Me.panel1
			Me.nCommandBarsManager1.Toolbars.Add(Me.nDockingToolbar1)
			Me.nCommandBarsManager1.Toolbars.Add(Me.nDockingToolbar2)
			Me.nCommandBarsManager1.Toolbars.Add(Me.nDockingToolbar3)
			Me.nCommandBarsManager1.Toolbars.Add(Me.nDockingToolbar4)

			' 
			' nDockingToolbar1
			' 
			Me.nDockingToolbar1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand1, Me.nCommand8, Me.nCommand3})
			Me.nDockingToolbar1.DefaultLocation = New System.Drawing.Point(0, 0)
			Me.nDockingToolbar1.Name = "nDockingToolbar1"
			Me.nDockingToolbar1.PrefferedRowIndex = 0
			Me.nDockingToolbar1.RowIndex = 0
			Me.nDockingToolbar1.Text = "Custom 1"
			' 
			' nCommand1
			' 
			Me.nCommand1.Context = Me.nCommandContext1
			' 
			' nCommand8
			' 
			Me.nCommand8.Context = Me.nCommandContext1
			' 
			' nCommand3
			' 
			Me.nCommand3.Context = Me.nCommandContext1
			' 
			' nDockingToolbar2
			' 
			Me.nDockingToolbar2.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand6, Me.nCommand10, Me.nCommand7})
			Me.nDockingToolbar2.DefaultLocation = New System.Drawing.Point(0, 0)
			Me.nDockingToolbar2.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.nDockingToolbar2.Name = "nDockingToolbar2"
			Me.nDockingToolbar2.PrefferedRowIndex = 0
			Me.nDockingToolbar2.RowIndex = 0
			Me.nDockingToolbar2.Text = "Custom 2"
			' 
			' nCommand6
			' 
			Me.nCommand6.Context = Me.nCommandContext1
			' 
			' nCommand10
			' 
			Me.nCommand10.Context = Me.nCommandContext1
			' 
			' nCommand7
			' 
			Me.nCommand7.Context = Me.nCommandContext1
			' 
			' nDockingToolbar3
			' 
			Me.nDockingToolbar3.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand12, Me.nCommand2, Me.nCommand11})
			Me.nDockingToolbar3.DefaultLocation = New System.Drawing.Point(0, 0)
			Me.nDockingToolbar3.Dock = System.Windows.Forms.DockStyle.Left
			Me.nDockingToolbar3.Name = "nDockingToolbar3"
			Me.nDockingToolbar3.PrefferedRowIndex = 0
			Me.nDockingToolbar3.RowIndex = 0
			Me.nDockingToolbar3.Text = "Custom 3"
			' 
			' nCommand12
			' 
			Me.nCommand12.Context = Me.nCommandContext1
			' 
			' nCommand2
			' 
			Me.nCommand2.Context = Me.nCommandContext1
			' 
			' nCommand11
			' 
			Me.nCommand11.Context = Me.nCommandContext1
			' 
			' nDockingToolbar4
			' 
			Me.nDockingToolbar4.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand5, Me.nCommand9, Me.nCommand4})
			Me.nDockingToolbar4.DefaultLocation = New System.Drawing.Point(0, 0)
			Me.nDockingToolbar4.Dock = System.Windows.Forms.DockStyle.Right
			Me.nDockingToolbar4.Name = "nDockingToolbar4"
			Me.nDockingToolbar4.PrefferedRowIndex = 0
			Me.nDockingToolbar4.RowIndex = 0
			Me.nDockingToolbar4.Text = "Custom 4"
			' 
			' nCommand5
			' 
			Me.nCommand5.Context = Me.nCommandContext1
			' 
			' nCommand9
			' 
			Me.nCommand9.Context = Me.nCommandContext1
			' 
			' nCommand4
			' 
			Me.nCommand4.Context = Me.nCommandContext1
			' 
			' NIndividualSkinningUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NIndividualSkinningUC"
			Me.Size = New System.Drawing.Size(438, 362)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox1.PerformLayout()
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.panel1.ResumeLayout(False)
			CType(Me.nCommandBarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private nRadioButton1 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents buttonsSkinCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nhScrollBar2 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents scrollSkinCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private nvScrollBar1 As Nevron.UI.WinForm.Controls.NVScrollBar
		Private nhScrollBar1 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private panel1 As System.Windows.Forms.Panel
		Private nCommandBarsManager1 As Nevron.UI.WinForm.Controls.NCommandBarsManager
		Private nCommandContext1 As Nevron.UI.WinForm.Controls.NCommandContext
		Private nDockingToolbar1 As Nevron.UI.WinForm.Controls.NDockingToolbar
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private nDockingToolbar2 As Nevron.UI.WinForm.Controls.NDockingToolbar
		Private nDockingToolbar3 As Nevron.UI.WinForm.Controls.NDockingToolbar
		Private nDockingToolbar4 As Nevron.UI.WinForm.Controls.NDockingToolbar
		Private WithEvents commandBarsSkinCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label3 As System.Windows.Forms.Label
		Private nCommand8 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand3 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand6 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand10 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand7 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand12 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand11 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand5 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand9 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand4 As Nevron.UI.WinForm.Controls.NCommand
	End Class
End Namespace
