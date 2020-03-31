Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NBasicLayoutsUC.
	''' </summary>
	Public Class NBasicLayoutsUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.alignMiddlesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.alignLeftsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.alignBottomsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.alignToGridButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.alignCentersButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.alignTopsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.alignRightsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.sizeToGridButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.sameWidthButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.sameHeightButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.sameSizeButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.increaseHorizontalSpacingButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.decreaseHorizontalSpacingButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.removeHorizontalSpacingButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.horzontalSpacingEqualButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.verticalSpacingEqualButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.removeVerticalSpacingButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.decreaseVerticalSpacingButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.increaseVerticalSpacingButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.centerHorizontallyButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.centerVerticallyButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.hSpacingNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nGroupBox4 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.vSpacingNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nGroupBox5 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			CType(Me.hSpacingNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox4.SuspendLayout()
			CType(Me.vSpacingNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox5.SuspendLayout()
			Me.SuspendLayout()
			' 
			' alignMiddlesButton
			' 
			Me.alignMiddlesButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.alignMiddlesButton.Enabled = False
			Me.alignMiddlesButton.Location = New System.Drawing.Point(128, 48)
			Me.alignMiddlesButton.Name = "alignMiddlesButton"
			Me.alignMiddlesButton.Size = New System.Drawing.Size(112, 24)
			Me.alignMiddlesButton.TabIndex = 4
			Me.alignMiddlesButton.Text = "&Middles"
'			Me.alignMiddlesButton.Click += New System.EventHandler(Me.alignMiddlesButton_Click);
			' 
			' alignLeftsButton
			' 
			Me.alignLeftsButton.Enabled = False
			Me.alignLeftsButton.Location = New System.Drawing.Point(8, 20)
			Me.alignLeftsButton.Name = "alignLeftsButton"
			Me.alignLeftsButton.Size = New System.Drawing.Size(112, 24)
			Me.alignLeftsButton.TabIndex = 0
			Me.alignLeftsButton.Text = "Lefts"
'			Me.alignLeftsButton.Click += New System.EventHandler(Me.alignLeftsButton_Click);
			' 
			' alignBottomsButton
			' 
			Me.alignBottomsButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.alignBottomsButton.Enabled = False
			Me.alignBottomsButton.Location = New System.Drawing.Point(128, 20)
			Me.alignBottomsButton.Name = "alignBottomsButton"
			Me.alignBottomsButton.Size = New System.Drawing.Size(112, 24)
			Me.alignBottomsButton.TabIndex = 1
			Me.alignBottomsButton.Text = "&Bottoms"
'			Me.alignBottomsButton.Click += New System.EventHandler(Me.alignBottomsButton_Click);
			' 
			' alignToGridButton
			' 
			Me.alignToGridButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.alignToGridButton.Enabled = False
			Me.alignToGridButton.Location = New System.Drawing.Point(8, 104)
			Me.alignToGridButton.Name = "alignToGridButton"
			Me.alignToGridButton.Size = New System.Drawing.Size(234, 24)
			Me.alignToGridButton.TabIndex = 5
			Me.alignToGridButton.Text = "To Grid"
'			Me.alignToGridButton.Click += New System.EventHandler(Me.alignToGridButton_Click);
			' 
			' alignCentersButton
			' 
			Me.alignCentersButton.Enabled = False
			Me.alignCentersButton.Location = New System.Drawing.Point(8, 48)
			Me.alignCentersButton.Name = "alignCentersButton"
			Me.alignCentersButton.Size = New System.Drawing.Size(112, 24)
			Me.alignCentersButton.TabIndex = 2
			Me.alignCentersButton.Text = "&Centers"
'			Me.alignCentersButton.Click += New System.EventHandler(Me.alignCentersButton_Click);
			' 
			' alignTopsButton
			' 
			Me.alignTopsButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.alignTopsButton.Enabled = False
			Me.alignTopsButton.Location = New System.Drawing.Point(128, 76)
			Me.alignTopsButton.Name = "alignTopsButton"
			Me.alignTopsButton.Size = New System.Drawing.Size(112, 24)
			Me.alignTopsButton.TabIndex = 4
			Me.alignTopsButton.Text = "&Tops"
'			Me.alignTopsButton.Click += New System.EventHandler(Me.alignTopsButton_Click);
			' 
			' alignRightsButton
			' 
			Me.alignRightsButton.Enabled = False
			Me.alignRightsButton.Location = New System.Drawing.Point(8, 76)
			Me.alignRightsButton.Name = "alignRightsButton"
			Me.alignRightsButton.Size = New System.Drawing.Size(112, 24)
			Me.alignRightsButton.TabIndex = 3
			Me.alignRightsButton.Text = "&Rights"
'			Me.alignRightsButton.Click += New System.EventHandler(Me.alignRightsButton_Click);
			' 
			' sizeToGridButton
			' 
			Me.sizeToGridButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.sizeToGridButton.Enabled = False
			Me.sizeToGridButton.Location = New System.Drawing.Point(8, 104)
			Me.sizeToGridButton.Name = "sizeToGridButton"
			Me.sizeToGridButton.Size = New System.Drawing.Size(234, 24)
			Me.sizeToGridButton.TabIndex = 3
			Me.sizeToGridButton.Text = "To &Grid"
'			Me.sizeToGridButton.Click += New System.EventHandler(Me.sizeToGridButton_Click);
			' 
			' sameWidthButton
			' 
			Me.sameWidthButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.sameWidthButton.Enabled = False
			Me.sameWidthButton.Location = New System.Drawing.Point(8, 20)
			Me.sameWidthButton.Name = "sameWidthButton"
			Me.sameWidthButton.Size = New System.Drawing.Size(234, 24)
			Me.sameWidthButton.TabIndex = 0
			Me.sameWidthButton.Text = "Make Same Width"
'			Me.sameWidthButton.Click += New System.EventHandler(Me.sameWidthButton_Click);
			' 
			' sameHeightButton
			' 
			Me.sameHeightButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.sameHeightButton.Enabled = False
			Me.sameHeightButton.Location = New System.Drawing.Point(8, 48)
			Me.sameHeightButton.Name = "sameHeightButton"
			Me.sameHeightButton.Size = New System.Drawing.Size(234, 24)
			Me.sameHeightButton.TabIndex = 1
			Me.sameHeightButton.Text = "Make Same Height"
'			Me.sameHeightButton.Click += New System.EventHandler(Me.sameHeightButton_Click);
			' 
			' sameSizeButton
			' 
			Me.sameSizeButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.sameSizeButton.Enabled = False
			Me.sameSizeButton.Location = New System.Drawing.Point(8, 76)
			Me.sameSizeButton.Name = "sameSizeButton"
			Me.sameSizeButton.Size = New System.Drawing.Size(234, 24)
			Me.sameSizeButton.TabIndex = 2
			Me.sameSizeButton.Text = "Make Same Size"
'			Me.sameSizeButton.Click += New System.EventHandler(Me.sameSizeButton_Click);
			' 
			' increaseHorizontalSpacingButton
			' 
			Me.increaseHorizontalSpacingButton.Enabled = False
			Me.increaseHorizontalSpacingButton.Location = New System.Drawing.Point(8, 40)
			Me.increaseHorizontalSpacingButton.Name = "increaseHorizontalSpacingButton"
			Me.increaseHorizontalSpacingButton.Size = New System.Drawing.Size(112, 24)
			Me.increaseHorizontalSpacingButton.TabIndex = 2
			Me.increaseHorizontalSpacingButton.Text = "&Increase"
'			Me.increaseHorizontalSpacingButton.Click += New System.EventHandler(Me.increaseHorizontalSpacingButton_Click);
			' 
			' decreaseHorizontalSpacingButton
			' 
			Me.decreaseHorizontalSpacingButton.Enabled = False
			Me.decreaseHorizontalSpacingButton.Location = New System.Drawing.Point(8, 72)
			Me.decreaseHorizontalSpacingButton.Name = "decreaseHorizontalSpacingButton"
			Me.decreaseHorizontalSpacingButton.Size = New System.Drawing.Size(112, 24)
			Me.decreaseHorizontalSpacingButton.TabIndex = 3
			Me.decreaseHorizontalSpacingButton.Text = "&Decrease"
'			Me.decreaseHorizontalSpacingButton.Click += New System.EventHandler(Me.decreaseHorizontalSpacingButton_Click);
			' 
			' removeHorizontalSpacingButton
			' 
			Me.removeHorizontalSpacingButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.removeHorizontalSpacingButton.Enabled = False
			Me.removeHorizontalSpacingButton.Location = New System.Drawing.Point(128, 40)
			Me.removeHorizontalSpacingButton.Name = "removeHorizontalSpacingButton"
			Me.removeHorizontalSpacingButton.Size = New System.Drawing.Size(112, 24)
			Me.removeHorizontalSpacingButton.TabIndex = 4
			Me.removeHorizontalSpacingButton.Text = "&Remove"
'			Me.removeHorizontalSpacingButton.Click += New System.EventHandler(Me.removeHorizontalSpacingButton_Click);
			' 
			' horzontalSpacingEqualButton
			' 
			Me.horzontalSpacingEqualButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.horzontalSpacingEqualButton.Enabled = False
			Me.horzontalSpacingEqualButton.Location = New System.Drawing.Point(128, 72)
			Me.horzontalSpacingEqualButton.Name = "horzontalSpacingEqualButton"
			Me.horzontalSpacingEqualButton.Size = New System.Drawing.Size(112, 24)
			Me.horzontalSpacingEqualButton.TabIndex = 5
			Me.horzontalSpacingEqualButton.Text = "Make &Equal"
'			Me.horzontalSpacingEqualButton.Click += New System.EventHandler(Me.horizontalSpacingEqualButton_Click);
			' 
			' verticalSpacingEqualButton
			' 
			Me.verticalSpacingEqualButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.verticalSpacingEqualButton.Enabled = False
			Me.verticalSpacingEqualButton.Location = New System.Drawing.Point(128, 72)
			Me.verticalSpacingEqualButton.Name = "verticalSpacingEqualButton"
			Me.verticalSpacingEqualButton.Size = New System.Drawing.Size(112, 24)
			Me.verticalSpacingEqualButton.TabIndex = 5
			Me.verticalSpacingEqualButton.Text = "Make &Equal"
'			Me.verticalSpacingEqualButton.Click += New System.EventHandler(Me.verticalSpacingEqualButton_Click);
			' 
			' removeVerticalSpacingButton
			' 
			Me.removeVerticalSpacingButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.removeVerticalSpacingButton.Enabled = False
			Me.removeVerticalSpacingButton.Location = New System.Drawing.Point(128, 40)
			Me.removeVerticalSpacingButton.Name = "removeVerticalSpacingButton"
			Me.removeVerticalSpacingButton.Size = New System.Drawing.Size(112, 24)
			Me.removeVerticalSpacingButton.TabIndex = 3
			Me.removeVerticalSpacingButton.Text = "&Remove"
'			Me.removeVerticalSpacingButton.Click += New System.EventHandler(Me.removeVerticalSpacingButton_Click);
			' 
			' decreaseVerticalSpacingButton
			' 
			Me.decreaseVerticalSpacingButton.Enabled = False
			Me.decreaseVerticalSpacingButton.Location = New System.Drawing.Point(8, 72)
			Me.decreaseVerticalSpacingButton.Name = "decreaseVerticalSpacingButton"
			Me.decreaseVerticalSpacingButton.Size = New System.Drawing.Size(112, 24)
			Me.decreaseVerticalSpacingButton.TabIndex = 4
			Me.decreaseVerticalSpacingButton.Text = "&Decrease"
'			Me.decreaseVerticalSpacingButton.Click += New System.EventHandler(Me.decreaseVerticalSpacingButton_Click);
			' 
			' increaseVerticalSpacingButton
			' 
			Me.increaseVerticalSpacingButton.Enabled = False
			Me.increaseVerticalSpacingButton.Location = New System.Drawing.Point(8, 40)
			Me.increaseVerticalSpacingButton.Name = "increaseVerticalSpacingButton"
			Me.increaseVerticalSpacingButton.Size = New System.Drawing.Size(112, 24)
			Me.increaseVerticalSpacingButton.TabIndex = 2
			Me.increaseVerticalSpacingButton.Text = "&Increase"
'			Me.increaseVerticalSpacingButton.Click += New System.EventHandler(Me.increaseVerticalSpacingButton_Click);
			' 
			' centerHorizontallyButton
			' 
			Me.centerHorizontallyButton.Enabled = False
			Me.centerHorizontallyButton.Location = New System.Drawing.Point(8, 20)
			Me.centerHorizontallyButton.Name = "centerHorizontallyButton"
			Me.centerHorizontallyButton.Size = New System.Drawing.Size(112, 24)
			Me.centerHorizontallyButton.TabIndex = 0
			Me.centerHorizontallyButton.Text = "&Horizontally"
'			Me.centerHorizontallyButton.Click += New System.EventHandler(Me.centerHorizontallyButton_Click);
			' 
			' centerVerticallyButton
			' 
			Me.centerVerticallyButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.centerVerticallyButton.Enabled = False
			Me.centerVerticallyButton.Location = New System.Drawing.Point(128, 20)
			Me.centerVerticallyButton.Name = "centerVerticallyButton"
			Me.centerVerticallyButton.Size = New System.Drawing.Size(112, 24)
			Me.centerVerticallyButton.TabIndex = 1
			Me.centerVerticallyButton.Text = "&Vertically"
'			Me.centerVerticallyButton.Click += New System.EventHandler(Me.centerVerticallyButton_Click);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.alignLeftsButton)
			Me.nGroupBox1.Controls.Add(Me.alignCentersButton)
			Me.nGroupBox1.Controls.Add(Me.alignRightsButton)
			Me.nGroupBox1.Controls.Add(Me.alignMiddlesButton)
			Me.nGroupBox1.Controls.Add(Me.alignTopsButton)
			Me.nGroupBox1.Controls.Add(Me.alignBottomsButton)
			Me.nGroupBox1.Controls.Add(Me.alignToGridButton)
			Me.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(0, 0)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(250, 136)
			Me.nGroupBox1.TabIndex = 1
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Align"
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.sameHeightButton)
			Me.nGroupBox2.Controls.Add(Me.sizeToGridButton)
			Me.nGroupBox2.Controls.Add(Me.sameWidthButton)
			Me.nGroupBox2.Controls.Add(Me.sameSizeButton)
			Me.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(0, 136)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(250, 136)
			Me.nGroupBox2.TabIndex = 2
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Size"
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.hSpacingNumeric)
			Me.nGroupBox3.Controls.Add(Me.label1)
			Me.nGroupBox3.Controls.Add(Me.horzontalSpacingEqualButton)
			Me.nGroupBox3.Controls.Add(Me.removeHorizontalSpacingButton)
			Me.nGroupBox3.Controls.Add(Me.decreaseHorizontalSpacingButton)
			Me.nGroupBox3.Controls.Add(Me.increaseHorizontalSpacingButton)
			Me.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(0, 272)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(250, 104)
			Me.nGroupBox3.TabIndex = 3
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Horizontal Spacing"
			' 
			' hSpacingNumeric
			' 
			Me.hSpacingNumeric.Location = New System.Drawing.Point(152, 16)
			Me.hSpacingNumeric.Maximum = New System.Decimal(New Integer() { 1000, 0, 0, 0})
			Me.hSpacingNumeric.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.hSpacingNumeric.Name = "hSpacingNumeric"
			Me.hSpacingNumeric.Size = New System.Drawing.Size(64, 20)
			Me.hSpacingNumeric.TabIndex = 1
			Me.hSpacingNumeric.Value = New System.Decimal(New Integer() { 20, 0, 0, 0})
'			Me.hSpacingNumeric.ValueChanged += New System.EventHandler(Me.hSpacingNumeric_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(136, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Horizontal spacing step:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nGroupBox4
			' 
			Me.nGroupBox4.Controls.Add(Me.vSpacingNumeric)
			Me.nGroupBox4.Controls.Add(Me.label2)
			Me.nGroupBox4.Controls.Add(Me.removeVerticalSpacingButton)
			Me.nGroupBox4.Controls.Add(Me.verticalSpacingEqualButton)
			Me.nGroupBox4.Controls.Add(Me.increaseVerticalSpacingButton)
			Me.nGroupBox4.Controls.Add(Me.decreaseVerticalSpacingButton)
			Me.nGroupBox4.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox4.ImageIndex = 0
			Me.nGroupBox4.Location = New System.Drawing.Point(0, 376)
			Me.nGroupBox4.Name = "nGroupBox4"
			Me.nGroupBox4.Size = New System.Drawing.Size(250, 104)
			Me.nGroupBox4.TabIndex = 4
			Me.nGroupBox4.TabStop = False
			Me.nGroupBox4.Text = "Vertical Spacing"
			' 
			' vSpacingNumeric
			' 
			Me.vSpacingNumeric.Location = New System.Drawing.Point(152, 16)
			Me.vSpacingNumeric.Maximum = New System.Decimal(New Integer() { 1000, 0, 0, 0})
			Me.vSpacingNumeric.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.vSpacingNumeric.Name = "vSpacingNumeric"
			Me.vSpacingNumeric.Size = New System.Drawing.Size(64, 20)
			Me.vSpacingNumeric.TabIndex = 1
			Me.vSpacingNumeric.Value = New System.Decimal(New Integer() { 20, 0, 0, 0})
'			Me.vSpacingNumeric.ValueChanged += New System.EventHandler(Me.vSpacingNumeric_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 13)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(136, 23)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Vertical spacing step:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nGroupBox5
			' 
			Me.nGroupBox5.Controls.Add(Me.centerVerticallyButton)
			Me.nGroupBox5.Controls.Add(Me.centerHorizontallyButton)
			Me.nGroupBox5.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox5.ImageIndex = 0
			Me.nGroupBox5.Location = New System.Drawing.Point(0, 480)
			Me.nGroupBox5.Name = "nGroupBox5"
			Me.nGroupBox5.Size = New System.Drawing.Size(250, 56)
			Me.nGroupBox5.TabIndex = 5
			Me.nGroupBox5.TabStop = False
			Me.nGroupBox5.Text = "Center"
			' 
			' NBasicLayoutsUC
			' 
			Me.Controls.Add(Me.nGroupBox5)
			Me.Controls.Add(Me.nGroupBox4)
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NBasicLayoutsUC"
			Me.Size = New System.Drawing.Size(250, 700)
			Me.Controls.SetChildIndex(Me.nGroupBox1, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox2, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox3, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox4, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox5, 0)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			CType(Me.hSpacingNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox4.ResumeLayout(False)
			CType(Me.vSpacingNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox5.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form fields
			batchLayout = New NBatchLayout(document)
			grid = view.Grid

			view.BeginInit()

			view.Grid.Visible = True

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.DetachFromEvents()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			hSpacingNumeric.Value = CDec(document.Settings.HorizontalSpacingStep)
			vSpacingNumeric.Value = CDec(document.Settings.VerticalSpacingStep)

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			Dim rect1 As NRectangleShape = New NRectangleShape(New NRectangleF(310, 10, 100, 80))
			Dim rect2 As NRectangleShape = New NRectangleShape(New NRectangleF(10, 200, 150, 75))
			Dim rect3 As NRectangleShape = New NRectangleShape(New NRectangleF(200, 300, 200, 100))

			document.ActiveLayer.AddChild(rect1)
			document.ActiveLayer.AddChild(rect2)
			document.ActiveLayer.AddChild(rect3)
		End Sub

		Protected Function Build() As Boolean
			masterNode = Nothing
			Dim count As Integer = view.Selection.Nodes.Count
			If count = 0 Then
				Return False
			End If

			masterNode = view.Selection.LastNode
			batchLayout.Build(view.Selection.Nodes)
			Return True
		End Function

		Private Sub UpdateUserControlsState()
			Dim canAlignVertically As Boolean = view.Selection.BatchLayout.CanAlignVertically(view.Selection.AnchorNode, False)

			Dim canAlignHorizontally As Boolean = view.Selection.BatchLayout.CanAlignHorizontally(view.Selection.AnchorNode, False)

			alignLeftsButton.Enabled = canAlignVertically
			alignRightsButton.Enabled = canAlignVertically
			alignCentersButton.Enabled = canAlignVertically

			alignTopsButton.Enabled = canAlignHorizontally
			alignBottomsButton.Enabled = canAlignHorizontally
			alignMiddlesButton.Enabled = canAlignHorizontally

			decreaseHorizontalSpacingButton.Enabled = view.Selection.BatchLayout.CanDecreaseHorizontalSpacing(view.Selection.AnchorNode, document.Settings.HorizontalSpacingStep)

			decreaseVerticalSpacingButton.Enabled = view.Selection.BatchLayout.CanDecreaseVerticalSpacing(view.Selection.AnchorNode, document.Settings.VerticalSpacingStep)

			increaseHorizontalSpacingButton.Enabled = view.Selection.BatchLayout.CanIncreaseHorizontalSpacing(view.Selection.AnchorNode, document.Settings.HorizontalSpacingStep)

			increaseVerticalSpacingButton.Enabled = view.Selection.BatchLayout.CanIncreaseVerticalSpacing(view.Selection.AnchorNode, document.Settings.VerticalSpacingStep)

			horzontalSpacingEqualButton.Enabled = view.Selection.BatchLayout.CanMakeHorizontalSpacingEqual()
			verticalSpacingEqualButton.Enabled = view.Selection.BatchLayout.CanMakeVerticalSpacingEqual()
			centerHorizontallyButton.Enabled = view.Selection.BatchLayout.CanCenterInDocumentHorizontally(False)
			centerVerticallyButton.Enabled = view.Selection.BatchLayout.CanCenterInDocumentVertically(False)

			sameHeightButton.Enabled = view.Selection.BatchLayout.CanMakeSameHeight(view.Selection.AnchorNode, False)

			sameWidthButton.Enabled = view.Selection.BatchLayout.CanMakeSameWidth(view.Selection.AnchorNode, False)

			sameSizeButton.Enabled = view.Selection.BatchLayout.CanMakeSameSize(view.Selection.AnchorNode, False)

			removeHorizontalSpacingButton.Enabled = view.Selection.BatchLayout.CanRemoveHorizontalSpacing(view.Selection.AnchorNode)

			removeVerticalSpacingButton.Enabled = view.Selection.BatchLayout.CanRemoveVerticalSpacing(view.Selection.AnchorNode)

			alignToGridButton.Enabled = view.Selection.BatchLayout.CanAlignToGrid(view.Grid.Origin, view.Grid.GetUsedCellSize(), False)

			sizeToGridButton.Enabled = view.Selection.BatchLayout.CanSizeToGrid(view.Grid.Origin, view.Grid.GetUsedCellSize(), False)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub alignLeftsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles alignLeftsButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.AlignHorizontally(masterNode, HorzAlign.Left, False)
			view.Refresh()
		End Sub

		Private Sub alignToGridButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles alignToGridButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.AlignToGrid(grid.Origin, view.Grid.GetUsedCellSize(), False)
			view.Refresh()
		End Sub

		Private Sub alignCentersButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles alignCentersButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.AlignHorizontally(masterNode, HorzAlign.Center, False)
			view.Refresh()
		End Sub

		Private Sub alignTopsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles alignTopsButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.AlignVertically(masterNode, VertAlign.Top, False)
			view.Refresh()
		End Sub

		Private Sub alignMiddlesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles alignMiddlesButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.AlignVertically(masterNode, VertAlign.Center, False)
			view.Refresh()
		End Sub

		Private Sub alignRightsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles alignRightsButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.AlignHorizontally(masterNode, HorzAlign.Right, False)
			view.Refresh()
		End Sub

		Private Sub alignBottomsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles alignBottomsButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.AlignVertically(masterNode, VertAlign.Bottom, False)
			view.Refresh()
		End Sub


		Private Sub sameSizeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sameSizeButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.MakeSameSize(masterNode, False)
			view.Refresh()
		End Sub

		Private Sub sizeToGridButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sizeToGridButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.SizeToGrid(grid.Origin, grid.GetUsedCellSize(), False)
			view.Refresh()
		End Sub

		Private Sub sameWidthButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sameWidthButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.MakeSameWidth(masterNode, False)
			view.Refresh()
		End Sub

		Private Sub sameHeightButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sameHeightButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.MakeSameHeight(masterNode, False)
			view.Refresh()
		End Sub


		Private Sub horizontalSpacingEqualButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles horzontalSpacingEqualButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.MakeHorizontalSpacingEqual()
			view.Refresh()
		End Sub

		Private Sub increaseHorizontalSpacingButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles increaseHorizontalSpacingButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.IncreaseHorizontalSpacing(masterNode, document.Settings.HorizontalSpacingStep)
			view.Refresh()
		End Sub

		Private Sub decreaseHorizontalSpacingButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles decreaseHorizontalSpacingButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.DecreaseHorizontalSpacing(masterNode, document.Settings.HorizontalSpacingStep)
			view.Refresh()
		End Sub

		Private Sub removeHorizontalSpacingButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles removeHorizontalSpacingButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.RemoveHorizontalSpacing(masterNode)
			view.Refresh()
		End Sub


		Private Sub increaseVerticalSpacingButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles increaseVerticalSpacingButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.IncreaseVerticalSpacing(masterNode, document.Settings.VerticalSpacingStep)
			view.Refresh()
		End Sub

		Private Sub verticalSpacingEqualButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles verticalSpacingEqualButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.MakeVerticalSpacingEqual()
			view.Refresh()
		End Sub

		Private Sub removeVerticalSpacingButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles removeVerticalSpacingButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.RemoveVerticalSpacing(masterNode)
			view.Refresh()
		End Sub

		Private Sub decreaseVerticalSpacingButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles decreaseVerticalSpacingButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.DecreaseVerticalSpacing(masterNode, document.Settings.VerticalSpacingStep)
			view.Refresh()
		End Sub


		Private Sub centerHorizontallyButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles centerHorizontallyButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.CenterInDocumentHorizontally(False)
			view.Refresh()
		End Sub

		Private Sub centerVerticallyButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles centerVerticallyButton.Click
			If (Not Build()) Then
				Return
			End If

			batchLayout.CenterInDocumentVertically(False)
			view.Refresh()
		End Sub


		Private Sub hSpacingNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hSpacingNumeric.ValueChanged
			document.Settings.HorizontalSpacingStep = CSng(hSpacingNumeric.Value)
		End Sub

		Private Sub vSpacingNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vSpacingNumeric.ValueChanged
			document.Settings.VerticalSpacingStep = CSng(vSpacingNumeric.Value)
		End Sub

		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			UpdateUserControlsState()
		End Sub

		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			UpdateUserControlsState()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private label1 As System.Windows.Forms.Label
		Private WithEvents hSpacingNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As System.Windows.Forms.Label
		Private WithEvents vSpacingNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents increaseHorizontalSpacingButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents decreaseHorizontalSpacingButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents removeHorizontalSpacingButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents horzontalSpacingEqualButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents verticalSpacingEqualButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents removeVerticalSpacingButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents decreaseVerticalSpacingButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents increaseVerticalSpacingButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents centerHorizontallyButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents centerVerticallyButton As Nevron.UI.WinForm.Controls.NButton
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox4 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox5 As Nevron.UI.WinForm.Controls.NGroupBox

		Private WithEvents alignMiddlesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents alignLeftsButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents alignBottomsButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents alignToGridButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents alignCentersButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents alignTopsButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents alignRightsButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents sameWidthButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents sizeToGridButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents sameHeightButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents sameSizeButton As Nevron.UI.WinForm.Controls.NButton

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		#Region "Fields"

		Private grid As NGrid
		Private batchLayout As NBatchLayout
		Private masterNode As INNode

		#End Region
	End Class
End Namespace
