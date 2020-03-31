Imports Microsoft.VisualBasic
Imports System
Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeListFilteringUC
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
			Me.containerPanel = New System.Windows.Forms.Panel()
			Me.nSplitter1 = New Nevron.UI.WinForm.Controls.NSplitter()
			Me.panel2 = New System.Windows.Forms.Panel()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.amountFilterNum2 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.amountFilterNum1 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.removeNumericFilterBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.applyNumericFilterBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.numericOptionsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.disableFromFilterBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.enableFromFilterBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.stringOptionsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.fromColumnFilterText1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.panel2.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			CType(Me.amountFilterNum2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.amountFilterNum1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' containerPanel
			' 
			Me.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.containerPanel.Location = New System.Drawing.Point(0, 0)
			Me.containerPanel.Name = "containerPanel"
			Me.containerPanel.Size = New System.Drawing.Size(328, 275)
			Me.containerPanel.TabIndex = 0
			' 
			' nSplitter1
			' 
			Me.nSplitter1.Dock = System.Windows.Forms.DockStyle.Right
			Me.nSplitter1.Location = New System.Drawing.Point(328, 0)
			Me.nSplitter1.MinimumSize = New System.Drawing.Size(5, 34)
			Me.nSplitter1.Name = "nSplitter1"
			Me.nSplitter1.Size = New System.Drawing.Size(5, 275)
			Me.nSplitter1.TabIndex = 1
			Me.nSplitter1.TabStop = False
			' 
			' panel2
			' 
			Me.panel2.Controls.Add(Me.nGroupBox2)
			Me.panel2.Controls.Add(Me.nGroupBox1)
			Me.panel2.Dock = System.Windows.Forms.DockStyle.Right
			Me.panel2.Location = New System.Drawing.Point(333, 0)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(236, 275)
			Me.panel2.TabIndex = 2
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nGroupBox2.Controls.Add(Me.amountFilterNum2)
			Me.nGroupBox2.Controls.Add(Me.amountFilterNum1)
			Me.nGroupBox2.Controls.Add(Me.label4)
			Me.nGroupBox2.Controls.Add(Me.removeNumericFilterBtn)
			Me.nGroupBox2.Controls.Add(Me.applyNumericFilterBtn)
			Me.nGroupBox2.Controls.Add(Me.numericOptionsCombo)
			Me.nGroupBox2.Controls.Add(Me.label5)
			Me.nGroupBox2.Controls.Add(Me.label6)
			Me.nGroupBox2.Location = New System.Drawing.Point(3, 113)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(230, 130)
			Me.nGroupBox2.TabIndex = 1
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "'PurchaseAmount' Column Filter"
			' 
			' amountFilterNum2
			' 
			Me.amountFilterNum2.Location = New System.Drawing.Point(84, 45)
			Me.amountFilterNum2.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
			Me.amountFilterNum2.Name = "amountFilterNum2"
			Me.amountFilterNum2.Size = New System.Drawing.Size(90, 20)
			Me.amountFilterNum2.TabIndex = 9
			' 
			' amountFilterNum1
			' 
			Me.amountFilterNum1.Location = New System.Drawing.Point(84, 19)
			Me.amountFilterNum1.Maximum = New Decimal(New Integer() { 1000, 0, 0, 0})
			Me.amountFilterNum1.Name = "amountFilterNum1"
			Me.amountFilterNum1.Size = New System.Drawing.Size(90, 20)
			Me.amountFilterNum1.TabIndex = 8
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 45)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(72, 18)
			Me.label4.TabIndex = 7
			Me.label4.Text = "Number 2:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' removeNumericFilterBtn
			' 
			Me.removeNumericFilterBtn.Location = New System.Drawing.Point(156, 99)
			Me.removeNumericFilterBtn.Name = "removeNumericFilterBtn"
			Me.removeNumericFilterBtn.Size = New System.Drawing.Size(68, 23)
			Me.removeNumericFilterBtn.TabIndex = 5
			Me.removeNumericFilterBtn.Text = "Remove"
'			Me.removeNumericFilterBtn.Click += New System.EventHandler(Me.removeNumericFilterBtn_Click);
			' 
			' applyNumericFilterBtn
			' 
			Me.applyNumericFilterBtn.Location = New System.Drawing.Point(84, 99)
			Me.applyNumericFilterBtn.Name = "applyNumericFilterBtn"
			Me.applyNumericFilterBtn.Size = New System.Drawing.Size(69, 23)
			Me.applyNumericFilterBtn.TabIndex = 4
			Me.applyNumericFilterBtn.Text = "Apply"
'			Me.applyNumericFilterBtn.Click += New System.EventHandler(Me.applyNumericFilterBtn_Click);
			' 
			' numericOptionsCombo
			' 
			Me.numericOptionsCombo.Location = New System.Drawing.Point(84, 71)
			Me.numericOptionsCombo.Name = "numericOptionsCombo"
			Me.numericOptionsCombo.Size = New System.Drawing.Size(140, 22)
			Me.numericOptionsCombo.TabIndex = 3
'			Me.numericOptionsCombo.SelectedIndexChanged += New System.EventHandler(Me.numericOptionsCombo_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(22, 71)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(56, 18)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Options:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(6, 19)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(72, 18)
			Me.label6.TabIndex = 1
			Me.label6.Text = "Number 1:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nGroupBox1.Controls.Add(Me.disableFromFilterBtn)
			Me.nGroupBox1.Controls.Add(Me.enableFromFilterBtn)
			Me.nGroupBox1.Controls.Add(Me.stringOptionsCombo)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.label1)
			Me.nGroupBox1.Controls.Add(Me.fromColumnFilterText1)
			Me.nGroupBox1.Location = New System.Drawing.Point(3, 3)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(230, 104)
			Me.nGroupBox1.TabIndex = 0
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "'From' Column Filter"
			' 
			' disableFromFilterBtn
			' 
			Me.disableFromFilterBtn.Location = New System.Drawing.Point(156, 71)
			Me.disableFromFilterBtn.Name = "disableFromFilterBtn"
			Me.disableFromFilterBtn.Size = New System.Drawing.Size(68, 23)
			Me.disableFromFilterBtn.TabIndex = 5
			Me.disableFromFilterBtn.Text = "Remove"
'			Me.disableFromFilterBtn.Click += New System.EventHandler(Me.disableFromFilterBtn_Click);
			' 
			' enableFromFilterBtn
			' 
			Me.enableFromFilterBtn.Location = New System.Drawing.Point(84, 71)
			Me.enableFromFilterBtn.Name = "enableFromFilterBtn"
			Me.enableFromFilterBtn.Size = New System.Drawing.Size(69, 23)
			Me.enableFromFilterBtn.TabIndex = 4
			Me.enableFromFilterBtn.Text = "Apply"
'			Me.enableFromFilterBtn.Click += New System.EventHandler(Me.enableFromFilterBtn_Click);
			' 
			' stringOptionsCombo
			' 
			Me.stringOptionsCombo.Location = New System.Drawing.Point(84, 43)
			Me.stringOptionsCombo.Name = "stringOptionsCombo"
			Me.stringOptionsCombo.Size = New System.Drawing.Size(140, 22)
			Me.stringOptionsCombo.TabIndex = 3
'			Me.stringOptionsCombo.SelectedIndexChanged += New System.EventHandler(Me.stringOptionsCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(22, 43)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(56, 18)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Options:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 19)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 18)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Filter Text:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' fromColumnFilterText1
			' 
			Me.fromColumnFilterText1.Location = New System.Drawing.Point(84, 19)
			Me.fromColumnFilterText1.Name = "fromColumnFilterText1"
			Me.fromColumnFilterText1.Size = New System.Drawing.Size(140, 18)
			Me.fromColumnFilterText1.TabIndex = 0
			' 
			' NTreeListFilteringUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.containerPanel)
			Me.Controls.Add(Me.nSplitter1)
			Me.Controls.Add(Me.panel2)
			Me.Name = "NTreeListFilteringUC"
			Me.Size = New System.Drawing.Size(569, 275)
			Me.panel2.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			CType(Me.amountFilterNum2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.amountFilterNum1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private containerPanel As System.Windows.Forms.Panel
		Private nSplitter1 As Nevron.UI.WinForm.Controls.NSplitter
		Private panel2 As System.Windows.Forms.Panel
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents disableFromFilterBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents enableFromFilterBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents stringOptionsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private fromColumnFilterText1 As Nevron.UI.WinForm.Controls.NTextBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private amountFilterNum1 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label4 As System.Windows.Forms.Label
		Private WithEvents removeNumericFilterBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents applyNumericFilterBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents numericOptionsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private amountFilterNum2 As Nevron.UI.WinForm.Controls.NNumericUpDown
	End Class
End Namespace
