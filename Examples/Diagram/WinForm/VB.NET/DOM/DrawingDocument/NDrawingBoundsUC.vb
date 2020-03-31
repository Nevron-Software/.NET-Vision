Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NDrawingBoundsUC.
	''' </summary>
	Public Class NDrawingBoundsUC
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
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.autoBoundsModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.sizeToContentButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.inflateToContentButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.customBoundsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.boundsHeightTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.boundsWidthTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.boundsYTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.boundsXTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.automaticBoundsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.minWidthTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.minHeightTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.autoBoundsPaddingGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label11 = New System.Windows.Forms.Label()
			Me.paddingLeftTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label9 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.label10 = New System.Windows.Forms.Label()
			Me.paddingTopTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.paddingBottomTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.paddingRightTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.panel1.SuspendLayout()
			Me.customBoundsGroup.SuspendLayout()
			Me.automaticBoundsGroup.SuspendLayout()
			Me.autoBoundsPaddingGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.autoBoundsModeComboBox)
			Me.panel1.Controls.Add(Me.label1)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(250, 56)
			Me.panel1.TabIndex = 0
			' 
			' autoBoundsModeComboBox
			' 
			Me.autoBoundsModeComboBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.autoBoundsModeComboBox.Location = New System.Drawing.Point(8, 24)
			Me.autoBoundsModeComboBox.Name = "autoBoundsModeComboBox"
			Me.autoBoundsModeComboBox.Size = New System.Drawing.Size(234, 21)
			Me.autoBoundsModeComboBox.TabIndex = 1
'			Me.autoBoundsModeComboBox.SelectedIndexChanged += New System.EventHandler(Me.autoBoundsModeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(107, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Auto bounds mode:"
			' 
			' sizeToContentButton
			' 
			Me.sizeToContentButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.sizeToContentButton.Location = New System.Drawing.Point(8, 88)
			Me.sizeToContentButton.Name = "sizeToContentButton"
			Me.sizeToContentButton.Size = New System.Drawing.Size(232, 23)
			Me.sizeToContentButton.TabIndex = 4
			Me.sizeToContentButton.Text = "Size to content"
'			Me.sizeToContentButton.Click += New System.EventHandler(Me.sizeToContentButton_Click);
			' 
			' inflateToContentButton
			' 
			Me.inflateToContentButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.inflateToContentButton.Location = New System.Drawing.Point(8, 120)
			Me.inflateToContentButton.Name = "inflateToContentButton"
			Me.inflateToContentButton.Size = New System.Drawing.Size(232, 23)
			Me.inflateToContentButton.TabIndex = 5
			Me.inflateToContentButton.Text = "Inflate to content"
'			Me.inflateToContentButton.Click += New System.EventHandler(Me.inflateToContentButton_Click);
			' 
			' customBoundsGroup
			' 
			Me.customBoundsGroup.Controls.Add(Me.label5)
			Me.customBoundsGroup.Controls.Add(Me.label4)
			Me.customBoundsGroup.Controls.Add(Me.label3)
			Me.customBoundsGroup.Controls.Add(Me.label2)
			Me.customBoundsGroup.Controls.Add(Me.boundsHeightTextBox)
			Me.customBoundsGroup.Controls.Add(Me.boundsWidthTextBox)
			Me.customBoundsGroup.Controls.Add(Me.boundsYTextBox)
			Me.customBoundsGroup.Controls.Add(Me.boundsXTextBox)
			Me.customBoundsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.customBoundsGroup.ImageIndex = 0
			Me.customBoundsGroup.Location = New System.Drawing.Point(0, 56)
			Me.customBoundsGroup.Name = "customBoundsGroup"
			Me.customBoundsGroup.Size = New System.Drawing.Size(250, 136)
			Me.customBoundsGroup.TabIndex = 1
			Me.customBoundsGroup.TabStop = False
			Me.customBoundsGroup.Text = "Custom bounds"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 111)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(64, 15)
			Me.label5.TabIndex = 6
			Me.label5.Text = "Height:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 83)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(64, 15)
			Me.label4.TabIndex = 4
			Me.label4.Text = "Width:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 55)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(64, 15)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Y:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 27)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(64, 15)
			Me.label2.TabIndex = 0
			Me.label2.Text = "X:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' boundsHeightTextBox
			' 
			Me.boundsHeightTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.boundsHeightTextBox.ErrorMessage = Nothing
			Me.boundsHeightTextBox.Location = New System.Drawing.Point(80, 108)
			Me.boundsHeightTextBox.Name = "boundsHeightTextBox"
			Me.boundsHeightTextBox.Size = New System.Drawing.Size(160, 20)
			Me.boundsHeightTextBox.TabIndex = 7
'			Me.boundsHeightTextBox.TextChanged += New System.EventHandler(Me.boundsHeightTextBox_TextChanged);
			' 
			' boundsWidthTextBox
			' 
			Me.boundsWidthTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.boundsWidthTextBox.ErrorMessage = Nothing
			Me.boundsWidthTextBox.Location = New System.Drawing.Point(80, 80)
			Me.boundsWidthTextBox.Name = "boundsWidthTextBox"
			Me.boundsWidthTextBox.Size = New System.Drawing.Size(160, 20)
			Me.boundsWidthTextBox.TabIndex = 5
'			Me.boundsWidthTextBox.TextChanged += New System.EventHandler(Me.boundsWidthTextBox_TextChanged);
			' 
			' boundsYTextBox
			' 
			Me.boundsYTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.boundsYTextBox.ErrorMessage = Nothing
			Me.boundsYTextBox.Location = New System.Drawing.Point(80, 52)
			Me.boundsYTextBox.Name = "boundsYTextBox"
			Me.boundsYTextBox.Size = New System.Drawing.Size(160, 20)
			Me.boundsYTextBox.TabIndex = 3
'			Me.boundsYTextBox.TextChanged += New System.EventHandler(Me.boundsYTextBox_TextChanged);
			' 
			' boundsXTextBox
			' 
			Me.boundsXTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.boundsXTextBox.ErrorMessage = Nothing
			Me.boundsXTextBox.Location = New System.Drawing.Point(80, 24)
			Me.boundsXTextBox.Name = "boundsXTextBox"
			Me.boundsXTextBox.Size = New System.Drawing.Size(160, 20)
			Me.boundsXTextBox.TabIndex = 1
'			Me.boundsXTextBox.TextChanged += New System.EventHandler(Me.boundsXTextBox_TextChanged);
			' 
			' automaticBoundsGroup
			' 
			Me.automaticBoundsGroup.Controls.Add(Me.label7)
			Me.automaticBoundsGroup.Controls.Add(Me.label6)
			Me.automaticBoundsGroup.Controls.Add(Me.minWidthTextBox)
			Me.automaticBoundsGroup.Controls.Add(Me.minHeightTextBox)
			Me.automaticBoundsGroup.Controls.Add(Me.sizeToContentButton)
			Me.automaticBoundsGroup.Controls.Add(Me.inflateToContentButton)
			Me.automaticBoundsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.automaticBoundsGroup.ImageIndex = 0
			Me.automaticBoundsGroup.Location = New System.Drawing.Point(0, 328)
			Me.automaticBoundsGroup.Name = "automaticBoundsGroup"
			Me.automaticBoundsGroup.Size = New System.Drawing.Size(250, 152)
			Me.automaticBoundsGroup.TabIndex = 3
			Me.automaticBoundsGroup.TabStop = False
			Me.automaticBoundsGroup.Text = "Automatic bounds"
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 59)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(64, 15)
			Me.label7.TabIndex = 2
			Me.label7.Text = "Min height:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 27)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(64, 15)
			Me.label6.TabIndex = 0
			Me.label6.Text = "Min width:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' minWidthTextBox
			' 
			Me.minWidthTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.minWidthTextBox.ErrorMessage = Nothing
			Me.minWidthTextBox.Location = New System.Drawing.Point(80, 24)
			Me.minWidthTextBox.Name = "minWidthTextBox"
			Me.minWidthTextBox.Size = New System.Drawing.Size(160, 20)
			Me.minWidthTextBox.TabIndex = 1
'			Me.minWidthTextBox.TextChanged += New System.EventHandler(Me.minWidthTextBox_TextChanged);
			' 
			' minHeightTextBox
			' 
			Me.minHeightTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.minHeightTextBox.ErrorMessage = Nothing
			Me.minHeightTextBox.Location = New System.Drawing.Point(80, 56)
			Me.minHeightTextBox.Name = "minHeightTextBox"
			Me.minHeightTextBox.Size = New System.Drawing.Size(160, 20)
			Me.minHeightTextBox.TabIndex = 3
'			Me.minHeightTextBox.TextChanged += New System.EventHandler(Me.minHeightTextBox_TextChanged);
			' 
			' autoBoundsPaddingGroup
			' 
			Me.autoBoundsPaddingGroup.Controls.Add(Me.label11)
			Me.autoBoundsPaddingGroup.Controls.Add(Me.paddingLeftTextBox)
			Me.autoBoundsPaddingGroup.Controls.Add(Me.label9)
			Me.autoBoundsPaddingGroup.Controls.Add(Me.label8)
			Me.autoBoundsPaddingGroup.Controls.Add(Me.label10)
			Me.autoBoundsPaddingGroup.Controls.Add(Me.paddingTopTextBox)
			Me.autoBoundsPaddingGroup.Controls.Add(Me.paddingBottomTextBox)
			Me.autoBoundsPaddingGroup.Controls.Add(Me.paddingRightTextBox)
			Me.autoBoundsPaddingGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.autoBoundsPaddingGroup.ImageIndex = 0
			Me.autoBoundsPaddingGroup.Location = New System.Drawing.Point(0, 192)
			Me.autoBoundsPaddingGroup.Name = "autoBoundsPaddingGroup"
			Me.autoBoundsPaddingGroup.Size = New System.Drawing.Size(250, 136)
			Me.autoBoundsPaddingGroup.TabIndex = 2
			Me.autoBoundsPaddingGroup.TabStop = False
			Me.autoBoundsPaddingGroup.Text = "Automatic bounds padding"
			' 
			' label11
			' 
			Me.label11.Location = New System.Drawing.Point(8, 111)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(64, 15)
			Me.label11.TabIndex = 6
			Me.label11.Text = "Bottom:"
			Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' paddingLeftTextBox
			' 
			Me.paddingLeftTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.paddingLeftTextBox.ErrorMessage = Nothing
			Me.paddingLeftTextBox.Location = New System.Drawing.Point(80, 52)
			Me.paddingLeftTextBox.Name = "paddingLeftTextBox"
			Me.paddingLeftTextBox.Size = New System.Drawing.Size(160, 20)
			Me.paddingLeftTextBox.TabIndex = 3
'			Me.paddingLeftTextBox.TextChanged += New System.EventHandler(Me.paddingLeftTextBox_TextChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(8, 55)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(64, 15)
			Me.label9.TabIndex = 2
			Me.label9.Text = "Left:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 27)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(64, 15)
			Me.label8.TabIndex = 0
			Me.label8.Text = "Top:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(8, 83)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(64, 15)
			Me.label10.TabIndex = 4
			Me.label10.Text = "Right:"
			Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' paddingTopTextBox
			' 
			Me.paddingTopTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.paddingTopTextBox.ErrorMessage = Nothing
			Me.paddingTopTextBox.Location = New System.Drawing.Point(80, 24)
			Me.paddingTopTextBox.Name = "paddingTopTextBox"
			Me.paddingTopTextBox.Size = New System.Drawing.Size(160, 20)
			Me.paddingTopTextBox.TabIndex = 1
'			Me.paddingTopTextBox.TextChanged += New System.EventHandler(Me.paddingTopTextBox_TextChanged);
			' 
			' paddingBottomTextBox
			' 
			Me.paddingBottomTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.paddingBottomTextBox.ErrorMessage = Nothing
			Me.paddingBottomTextBox.Location = New System.Drawing.Point(80, 108)
			Me.paddingBottomTextBox.Name = "paddingBottomTextBox"
			Me.paddingBottomTextBox.Size = New System.Drawing.Size(160, 20)
			Me.paddingBottomTextBox.TabIndex = 7
'			Me.paddingBottomTextBox.TextChanged += New System.EventHandler(Me.paddingBottomTextBox_TextChanged);
			' 
			' paddingRightTextBox
			' 
			Me.paddingRightTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.paddingRightTextBox.ErrorMessage = Nothing
			Me.paddingRightTextBox.Location = New System.Drawing.Point(80, 80)
			Me.paddingRightTextBox.Name = "paddingRightTextBox"
			Me.paddingRightTextBox.Size = New System.Drawing.Size(160, 20)
			Me.paddingRightTextBox.TabIndex = 5
'			Me.paddingRightTextBox.TextChanged += New System.EventHandler(Me.paddingRightTextBox_TextChanged);
			' 
			' NDrawingBoundsUC
			' 
			Me.Controls.Add(Me.automaticBoundsGroup)
			Me.Controls.Add(Me.autoBoundsPaddingGroup)
			Me.Controls.Add(Me.customBoundsGroup)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NDrawingBoundsUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.panel1, 0)
			Me.Controls.SetChildIndex(Me.customBoundsGroup, 0)
			Me.Controls.SetChildIndex(Me.autoBoundsPaddingGroup, 0)
			Me.Controls.SetChildIndex(Me.automaticBoundsGroup, 0)
			Me.panel1.ResumeLayout(False)
			Me.customBoundsGroup.ResumeLayout(False)
			Me.automaticBoundsGroup.ResumeLayout(False)
			Me.autoBoundsPaddingGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			' custom bounds
			boundsXTextBox.Text = document.Bounds.X.ToString()
			boundsYTextBox.Text = document.Bounds.Y.ToString()
			boundsWidthTextBox.Text = document.Bounds.Width.ToString()
			boundsHeightTextBox.Text = document.Bounds.Height.ToString()

			' autobounds
			minWidthTextBox.Text = document.AutoBoundsMinSize.Width.ToString()
			minHeightTextBox.Text = document.AutoBoundsMinSize.Height.ToString()

			paddingLeftTextBox.Text = document.AutoBoundsPadding.Left.ToString()
			paddingRightTextBox.Text = document.AutoBoundsPadding.Right.ToString()
			paddingTopTextBox.Text = document.AutoBoundsPadding.Top.ToString()
			paddingBottomTextBox.Text = document.AutoBoundsPadding.Bottom.ToString()

			autoBoundsModeComboBox.FillFromEnum(GetType(AutoBoundsMode))
			autoBoundsModeComboBox.SelectedItem = CType(document.AutoBoundsMode, AutoBoundsMode)

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			Dim rect1 As NRectangleShape = New NRectangleShape(New NRectangleF(10, 10, 200, 200))
			rect1.Text = "Change the Auto Bounds Mode and move Me"
			document.ActiveLayer.AddChild(rect1)

			Dim rect2 As NRectangleShape = New NRectangleShape(New NRectangleF(310, 310, 200, 200))
			rect2.Text = "Change the Auto Bounds Mode and move Me"
			document.ActiveLayer.AddChild(rect2)
		End Sub


		Private Sub ChangePadding()
			Dim margins As Nevron.Diagram.NMargins = New Nevron.Diagram.NMargins(0)

			Try
				margins.Left = Single.Parse(paddingLeftTextBox.Text)
				margins.Right = Single.Parse(paddingRightTextBox.Text)
				margins.Top = Single.Parse(paddingTopTextBox.Text)
				margins.Bottom = Single.Parse(paddingBottomTextBox.Text)
			Catch ex As Exception
				Debug.WriteLine("Change padding failed with exception: " & ex.Message)
				Return
			End Try

			document.AutoBoundsPadding = margins
		End Sub

		Private Sub ChangeBounds()
			Dim x As Single = 0, y As Single = 0, width As Single = 0, height As Single = 0

			Try
				x = Single.Parse(boundsXTextBox.Text)
				y = Single.Parse(boundsYTextBox.Text)
				width = Single.Parse(boundsWidthTextBox.Text)
				height = Single.Parse(boundsHeightTextBox.Text)
			Catch ex As Exception
				Debug.WriteLine("Change bounds failed with exception: " & ex.Message)
				Return
			End Try

			document.Bounds = New NRectangleF(x, y, width, height)
		End Sub

		Private Sub ChangeMinSize()
			Dim minWidth As Single = 0, minHeight As Single = 0

			Try
				minWidth = Single.Parse(minWidthTextBox.Text)
				minHeight = Single.Parse(minHeightTextBox.Text)
			Catch ex As Exception
				Debug.WriteLine("Change min size failed with exception: " & ex.Message)
				Return
			End Try

			document.AutoBoundsMinSize = New NSizeF(minWidth, minHeight)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub autoBoundsModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles autoBoundsModeComboBox.SelectedIndexChanged
			document.AutoBoundsMode = CType(autoBoundsModeComboBox.SelectedIndex, AutoBoundsMode)

			Select Case document.AutoBoundsMode
				Case AutoBoundsMode.CustomConstrained, AutoBoundsMode.CustomNonConstrained
					customBoundsGroup.Enabled = True
					minWidthTextBox.Enabled = False
					minHeightTextBox.Enabled = False
					sizeToContentButton.Enabled = True
					inflateToContentButton.Enabled = True
				Case AutoBoundsMode.AutoInflateToContent
					customBoundsGroup.Enabled = False
					minWidthTextBox.Enabled = True
					minHeightTextBox.Enabled = True
					inflateToContentButton.Enabled = False
					sizeToContentButton.Enabled = True
				Case AutoBoundsMode.AutoSizeToContent
					customBoundsGroup.Enabled = False
					minWidthTextBox.Enabled = True
					minHeightTextBox.Enabled = True
					sizeToContentButton.Enabled = False
					inflateToContentButton.Enabled = False
			End Select
		End Sub

		Private Sub sizeToContentButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sizeToContentButton.Click
			document.SizeToContent()
		End Sub

		Private Sub inflateToContentButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles inflateToContentButton.Click
			document.InflateToContent()
		End Sub

		Private Sub minWidthTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles minWidthTextBox.TextChanged
			ChangeMinSize()
		End Sub

		Private Sub minHeightTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles minHeightTextBox.TextChanged
			ChangeMinSize()
		End Sub


		Private Sub paddingTopTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles paddingTopTextBox.TextChanged
			ChangePadding()
		End Sub

		Private Sub paddingLeftTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles paddingLeftTextBox.TextChanged
			ChangePadding()
		End Sub

		Private Sub paddingRightTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles paddingRightTextBox.TextChanged
			ChangePadding()
		End Sub

		Private Sub paddingBottomTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles paddingBottomTextBox.TextChanged
			ChangePadding()
		End Sub


		Private Sub boundsXTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles boundsXTextBox.TextChanged
			ChangeBounds()
		End Sub

		Private Sub boundsYTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles boundsYTextBox.TextChanged
			ChangeBounds()
		End Sub

		Private Sub boundsWidthTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles boundsWidthTextBox.TextChanged
			ChangeBounds()
		End Sub

		Private Sub boundsHeightTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles boundsHeightTextBox.TextChanged
			ChangeBounds()
		End Sub

		#End Region

		#Region "Designer Fields"

		Private panel1 As System.Windows.Forms.Panel
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private WithEvents autoBoundsModeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents boundsXTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents boundsWidthTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents boundsHeightTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents minWidthTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents minHeightTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents inflateToContentButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents sizeToContentButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents paddingTopTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents paddingLeftTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents paddingRightTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents paddingBottomTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents boundsYTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private customBoundsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private automaticBoundsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private autoBoundsPaddingGroup As Nevron.UI.WinForm.Controls.NGroupBox

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		#End Region
	End Class
End Namespace
