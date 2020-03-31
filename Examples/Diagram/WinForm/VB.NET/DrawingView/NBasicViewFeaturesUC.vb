Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Editors
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NBasicViewFeaturesUC.
	''' </summary>
	Public Class NBasicViewFeaturesUC
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.viewStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.scalingGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.scaleYPercentLabel = New System.Windows.Forms.Label()
			Me.scaleXPercentLabel = New System.Windows.Forms.Label()
			Me.zoomPercentLabel = New System.Windows.Forms.Label()
			Me.scaleYScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.scaleXScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.zoomScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.scrollbarsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.autoScrollTimeNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label11 = New System.Windows.Forms.Label()
			Me.autoScrollDelayNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label10 = New System.Windows.Forms.Label()
			Me.smallScrollChangeNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nonScrollSceneAlignmentCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.scrollBarsCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.nNumericUpDown1 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.generalGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.viewportOriginXNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.viewportOriginYNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.globalVisibilityButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.documentShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label8 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.documentPaddingButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.scalingGroup.SuspendLayout()
			Me.scrollbarsGroup.SuspendLayout()
			CType(Me.autoScrollTimeNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.autoScrollDelayNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.smallScrollChangeNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.generalGroup.SuspendLayout()
			CType(Me.viewportOriginXNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.viewportOriginYNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 20)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 24)
			Me.label1.TabIndex = 0
			Me.label1.Text = "View style:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' viewStyleCombo
			' 
			Me.viewStyleCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.viewStyleCombo.Location = New System.Drawing.Point(80, 22)
			Me.viewStyleCombo.Name = "viewStyleCombo"
			Me.viewStyleCombo.Size = New System.Drawing.Size(152, 21)
			Me.viewStyleCombo.TabIndex = 1
'			Me.viewStyleCombo.SelectedIndexChanged += New System.EventHandler(Me.viewStyleCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 49)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(64, 14)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Zoom:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 73)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(64, 14)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Scale X:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 98)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(64, 12)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Scale Y:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' scalingGroup
			' 
			Me.scalingGroup.Controls.Add(Me.scaleYPercentLabel)
			Me.scalingGroup.Controls.Add(Me.scaleXPercentLabel)
			Me.scalingGroup.Controls.Add(Me.zoomPercentLabel)
			Me.scalingGroup.Controls.Add(Me.scaleYScroll)
			Me.scalingGroup.Controls.Add(Me.scaleXScroll)
			Me.scalingGroup.Controls.Add(Me.zoomScroll)
			Me.scalingGroup.Controls.Add(Me.label4)
			Me.scalingGroup.Controls.Add(Me.label1)
			Me.scalingGroup.Controls.Add(Me.viewStyleCombo)
			Me.scalingGroup.Controls.Add(Me.label2)
			Me.scalingGroup.Controls.Add(Me.label3)
			Me.scalingGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.scalingGroup.ImageIndex = 0
			Me.scalingGroup.Location = New System.Drawing.Point(0, 176)
			Me.scalingGroup.Name = "scalingGroup"
			Me.scalingGroup.Size = New System.Drawing.Size(240, 128)
			Me.scalingGroup.TabIndex = 2
			Me.scalingGroup.TabStop = False
			Me.scalingGroup.Text = "Scaling"
			' 
			' scaleYPercentLabel
			' 
			Me.scaleYPercentLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.scaleYPercentLabel.Location = New System.Drawing.Point(192, 96)
			Me.scaleYPercentLabel.Name = "scaleYPercentLabel"
			Me.scaleYPercentLabel.Size = New System.Drawing.Size(40, 16)
			Me.scaleYPercentLabel.TabIndex = 10
			Me.scaleYPercentLabel.Text = "100%"
			Me.scaleYPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' scaleXPercentLabel
			' 
			Me.scaleXPercentLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.scaleXPercentLabel.Location = New System.Drawing.Point(192, 72)
			Me.scaleXPercentLabel.Name = "scaleXPercentLabel"
			Me.scaleXPercentLabel.Size = New System.Drawing.Size(40, 16)
			Me.scaleXPercentLabel.TabIndex = 7
			Me.scaleXPercentLabel.Text = "100%"
			Me.scaleXPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' zoomPercentLabel
			' 
			Me.zoomPercentLabel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.zoomPercentLabel.Location = New System.Drawing.Point(192, 48)
			Me.zoomPercentLabel.Name = "zoomPercentLabel"
			Me.zoomPercentLabel.Size = New System.Drawing.Size(40, 16)
			Me.zoomPercentLabel.TabIndex = 4
			Me.zoomPercentLabel.Text = "100%"
			Me.zoomPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' scaleYScroll
			' 
			Me.scaleYScroll.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.scaleYScroll.Location = New System.Drawing.Point(80, 96)
			Me.scaleYScroll.Minimum = 1
			Me.scaleYScroll.Name = "scaleYScroll"
			Me.scaleYScroll.Size = New System.Drawing.Size(104, 17)
			Me.scaleYScroll.TabIndex = 9
			Me.scaleYScroll.Value = 1
'			Me.scaleYScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.scaleYScroll_ValueChanged);
			' 
			' scaleXScroll
			' 
			Me.scaleXScroll.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.scaleXScroll.Location = New System.Drawing.Point(80, 72)
			Me.scaleXScroll.Minimum = 1
			Me.scaleXScroll.Name = "scaleXScroll"
			Me.scaleXScroll.Size = New System.Drawing.Size(104, 17)
			Me.scaleXScroll.TabIndex = 6
			Me.scaleXScroll.Value = 1
'			Me.scaleXScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.scaleXScroll_ValueChanged);
			' 
			' zoomScroll
			' 
			Me.zoomScroll.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.zoomScroll.Location = New System.Drawing.Point(80, 48)
			Me.zoomScroll.Minimum = 1
			Me.zoomScroll.Name = "zoomScroll"
			Me.zoomScroll.Size = New System.Drawing.Size(104, 17)
			Me.zoomScroll.TabIndex = 3
			Me.zoomScroll.Value = 1
'			Me.zoomScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.zoomScroll_ValueChanged);
			' 
			' scrollbarsGroup
			' 
			Me.scrollbarsGroup.Controls.Add(Me.autoScrollTimeNumeric)
			Me.scrollbarsGroup.Controls.Add(Me.label11)
			Me.scrollbarsGroup.Controls.Add(Me.autoScrollDelayNumeric)
			Me.scrollbarsGroup.Controls.Add(Me.label10)
			Me.scrollbarsGroup.Controls.Add(Me.smallScrollChangeNumeric)
			Me.scrollbarsGroup.Controls.Add(Me.nonScrollSceneAlignmentCombo)
			Me.scrollbarsGroup.Controls.Add(Me.label7)
			Me.scrollbarsGroup.Controls.Add(Me.label9)
			Me.scrollbarsGroup.Controls.Add(Me.scrollBarsCombo)
			Me.scrollbarsGroup.Controls.Add(Me.label5)
			Me.scrollbarsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.scrollbarsGroup.ImageIndex = 0
			Me.scrollbarsGroup.Location = New System.Drawing.Point(0, 304)
			Me.scrollbarsGroup.Name = "scrollbarsGroup"
			Me.scrollbarsGroup.Size = New System.Drawing.Size(240, 176)
			Me.scrollbarsGroup.TabIndex = 3
			Me.scrollbarsGroup.TabStop = False
			Me.scrollbarsGroup.Text = "Scrolling"
			' 
			' autoScrollTimeNumeric
			' 
			Me.autoScrollTimeNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.autoScrollTimeNumeric.Location = New System.Drawing.Point(128, 136)
			Me.autoScrollTimeNumeric.Maximum = New System.Decimal(New Integer() { 10000, 0, 0, 0})
			Me.autoScrollTimeNumeric.Name = "autoScrollTimeNumeric"
			Me.autoScrollTimeNumeric.Size = New System.Drawing.Size(100, 22)
			Me.autoScrollTimeNumeric.TabIndex = 9
			Me.autoScrollTimeNumeric.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'			Me.autoScrollTimeNumeric.ValueChanged += New System.EventHandler(Me.autoScrollTimeNumeric_ValueChanged);
			' 
			' label11
			' 
			Me.label11.Location = New System.Drawing.Point(8, 136)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(112, 16)
			Me.label11.TabIndex = 8
			Me.label11.Text = "Auto scroll  time:"
			Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' autoScrollDelayNumeric
			' 
			Me.autoScrollDelayNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.autoScrollDelayNumeric.Location = New System.Drawing.Point(128, 112)
			Me.autoScrollDelayNumeric.Maximum = New System.Decimal(New Integer() { 10000, 0, 0, 0})
			Me.autoScrollDelayNumeric.Name = "autoScrollDelayNumeric"
			Me.autoScrollDelayNumeric.Size = New System.Drawing.Size(100, 22)
			Me.autoScrollDelayNumeric.TabIndex = 7
			Me.autoScrollDelayNumeric.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'			Me.autoScrollDelayNumeric.ValueChanged += New System.EventHandler(Me.autoScrollDelayNumeric_ValueChanged);
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(8, 112)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(112, 16)
			Me.label10.TabIndex = 6
			Me.label10.Text = "Auto scroll  delay:"
			Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' smallScrollChangeNumeric
			' 
			Me.smallScrollChangeNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.smallScrollChangeNumeric.Location = New System.Drawing.Point(128, 88)
			Me.smallScrollChangeNumeric.Maximum = New System.Decimal(New Integer() { 10000, 0, 0, 0})
			Me.smallScrollChangeNumeric.Name = "smallScrollChangeNumeric"
			Me.smallScrollChangeNumeric.Size = New System.Drawing.Size(100, 22)
			Me.smallScrollChangeNumeric.TabIndex = 5
'			Me.smallScrollChangeNumeric.ValueChanged += New System.EventHandler(Me.smallScrollChangeNumeric_ValueChanged);
			' 
			' nonScrollSceneAlignmentCombo
			' 
			Me.nonScrollSceneAlignmentCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nonScrollSceneAlignmentCombo.Location = New System.Drawing.Point(80, 56)
			Me.nonScrollSceneAlignmentCombo.Name = "nonScrollSceneAlignmentCombo"
			Me.nonScrollSceneAlignmentCombo.Size = New System.Drawing.Size(152, 21)
			Me.nonScrollSceneAlignmentCombo.TabIndex = 3
'			Me.nonScrollSceneAlignmentCombo.SelectedIndexChanged += New System.EventHandler(Me.nonScrollSceneAlignmentCombo_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 48)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(72, 32)
			Me.label7.TabIndex = 2
			Me.label7.Text = "Non scroll alignment:"
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(8, 16)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(72, 32)
			Me.label9.TabIndex = 0
			Me.label9.Text = "Scroll bars:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' scrollBarsCombo
			' 
			Me.scrollBarsCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.scrollBarsCombo.Location = New System.Drawing.Point(80, 22)
			Me.scrollBarsCombo.Name = "scrollBarsCombo"
			Me.scrollBarsCombo.Size = New System.Drawing.Size(152, 21)
			Me.scrollBarsCombo.TabIndex = 1
'			Me.scrollBarsCombo.SelectedIndexChanged += New System.EventHandler(Me.scrollBarsCombo_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 88)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(120, 16)
			Me.label5.TabIndex = 4
			Me.label5.Text = "Small scroll change:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nNumericUpDown1
			' 
			Me.nNumericUpDown1.Location = New System.Drawing.Point(0, 0)
			Me.nNumericUpDown1.Name = "nNumericUpDown1"
			Me.nNumericUpDown1.Size = New System.Drawing.Size(120, 22)
			Me.nNumericUpDown1.TabIndex = 0
			' 
			' generalGroup
			' 
			Me.generalGroup.Controls.Add(Me.viewportOriginXNumeric)
			Me.generalGroup.Controls.Add(Me.viewportOriginYNumeric)
			Me.generalGroup.Controls.Add(Me.globalVisibilityButton)
			Me.generalGroup.Controls.Add(Me.documentShadowButton)
			Me.generalGroup.Controls.Add(Me.label8)
			Me.generalGroup.Controls.Add(Me.label6)
			Me.generalGroup.Controls.Add(Me.documentPaddingButton)
			Me.generalGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.generalGroup.ImageIndex = 0
			Me.generalGroup.Location = New System.Drawing.Point(0, 0)
			Me.generalGroup.Name = "generalGroup"
			Me.generalGroup.Size = New System.Drawing.Size(240, 176)
			Me.generalGroup.TabIndex = 1
			Me.generalGroup.TabStop = False
			Me.generalGroup.Text = "General"
			' 
			' viewportOriginXNumeric
			' 
			Me.viewportOriginXNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.viewportOriginXNumeric.Location = New System.Drawing.Point(128, 25)
			Me.viewportOriginXNumeric.Maximum = New System.Decimal(New Integer() { 100000, 0, 0, 0})
			Me.viewportOriginXNumeric.Minimum = New System.Decimal(New Integer() { 100000, 0, 0, -2147483648})
			Me.viewportOriginXNumeric.Name = "viewportOriginXNumeric"
			Me.viewportOriginXNumeric.Size = New System.Drawing.Size(100, 22)
			Me.viewportOriginXNumeric.TabIndex = 1
'			Me.viewportOriginXNumeric.ValueChanged += New System.EventHandler(Me.viewportOriginXNumeric_ValueChanged);
			' 
			' viewportOriginYNumeric
			' 
			Me.viewportOriginYNumeric.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.viewportOriginYNumeric.Location = New System.Drawing.Point(128, 49)
			Me.viewportOriginYNumeric.Maximum = New System.Decimal(New Integer() { 100000, 0, 0, 0})
			Me.viewportOriginYNumeric.Minimum = New System.Decimal(New Integer() { 100000, 0, 0, -2147483648})
			Me.viewportOriginYNumeric.Name = "viewportOriginYNumeric"
			Me.viewportOriginYNumeric.Size = New System.Drawing.Size(100, 22)
			Me.viewportOriginYNumeric.TabIndex = 3
'			Me.viewportOriginYNumeric.ValueChanged += New System.EventHandler(Me.viewportOriginYNumeric_ValueChanged);
			' 
			' globalVisibilityButton
			' 
			Me.globalVisibilityButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.globalVisibilityButton.Location = New System.Drawing.Point(8, 80)
			Me.globalVisibilityButton.Name = "globalVisibilityButton"
			Me.globalVisibilityButton.Size = New System.Drawing.Size(224, 23)
			Me.globalVisibilityButton.TabIndex = 4
			Me.globalVisibilityButton.Text = "Global visibility..."
'			Me.globalVisibilityButton.Click += New System.EventHandler(Me.globalVisibilityButton_Click);
			' 
			' documentShadowButton
			' 
			Me.documentShadowButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.documentShadowButton.Location = New System.Drawing.Point(8, 144)
			Me.documentShadowButton.Name = "documentShadowButton"
			Me.documentShadowButton.Size = New System.Drawing.Size(224, 23)
			Me.documentShadowButton.TabIndex = 6
			Me.documentShadowButton.Text = "Document shadow..."
'			Me.documentShadowButton.Click += New System.EventHandler(Me.documentShadowButton_Click);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 48)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(96, 23)
			Me.label8.TabIndex = 2
			Me.label8.Text = "Viewport origin Y:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 24)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(96, 23)
			Me.label6.TabIndex = 0
			Me.label6.Text = "Viewport origin X:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' documentPaddingButton
			' 
			Me.documentPaddingButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.documentPaddingButton.Location = New System.Drawing.Point(8, 112)
			Me.documentPaddingButton.Name = "documentPaddingButton"
			Me.documentPaddingButton.Size = New System.Drawing.Size(224, 23)
			Me.documentPaddingButton.TabIndex = 5
			Me.documentPaddingButton.Text = "Document padding..."
'			Me.documentPaddingButton.Click += New System.EventHandler(Me.documentPaddingButton_Click);
			' 
			' NBasicViewFeaturesUC
			' 
			Me.Controls.Add(Me.scrollbarsGroup)
			Me.Controls.Add(Me.scalingGroup)
			Me.Controls.Add(Me.generalGroup)
			Me.Name = "NBasicViewFeaturesUC"
			Me.Size = New System.Drawing.Size(240, 576)
			Me.Controls.SetChildIndex(Me.generalGroup, 0)
			Me.Controls.SetChildIndex(Me.scalingGroup, 0)
			Me.Controls.SetChildIndex(Me.scrollbarsGroup, 0)
			Me.scalingGroup.ResumeLayout(False)
			Me.scrollbarsGroup.ResumeLayout(False)
			CType(Me.autoScrollTimeNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.autoScrollDelayNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.smallScrollChangeNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.generalGroup.ResumeLayout(False)
			CType(Me.viewportOriginXNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.viewportOriginYNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			view.DocumentPadding = New Nevron.Diagram.NMargins(20)
			view.ViewportOrigin = New NPointF(-12, -12)
			view.Grid.Visible = False

			' init document
			document.BeginInit()
			CreateDefaultFlowDiagram()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub ResetExample()
			view.Reset()
			MyBase.ResetExample()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			viewportOriginXNumeric.Value = CInt(Fix(view.ViewportOrigin.X))
			viewportOriginYNumeric.Value = CInt(Fix(view.ViewportOrigin.Y))

			viewStyleCombo.FillFromEnum(GetType(ViewLayout))
			viewStyleCombo.SelectedItem = view.ViewLayout

			Dim scaleX As Integer = CInt(Fix(Math.Round(view.ScaleX * 10)))
			scaleXScroll.Value = scaleX
			zoomScroll.Value = scaleX

			Dim scaleY As Integer = CInt(Fix(Math.Round(view.ScaleY * 10)))
			scaleYScroll.Value = scaleY

			scrollBarsCombo.FillFromEnum(GetType(ScrollBars))
			scrollBarsCombo.SelectedItem = view.ScrollBars

			nonScrollSceneAlignmentCombo.FillFromEnum(GetType(ContentAlignment))
			nonScrollSceneAlignmentCombo.SelectedItem = view.NonScrollableSceneAlignment

			smallScrollChangeNumeric.Value = view.SmallScrollChange.Height
			autoScrollDelayNumeric.Value = view.AutoScroller.Delay
			autoScrollTimeNumeric.Value = view.AutoScroller.Time

			ResumeEventsHandling()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub viewportOriginXNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles viewportOriginXNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim x As Single = CSng(viewportOriginXNumeric.Value)
			Dim y As Single = view.ViewportOrigin.Y
			view.ViewportOrigin = New NPointF(x, y)

			view.Refresh()
		End Sub

		Private Sub viewportOriginYNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles viewportOriginYNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim x As Single = view.ViewportOrigin.X
			Dim y As Single = CSng(viewportOriginYNumeric.Value)
			view.ViewportOrigin = New NPointF(x, y)

			view.Refresh()
		End Sub


		Private Sub globalVisibilityButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles globalVisibilityButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			Dim visibility As NGlobalVisibility
			If NGlobalVisibilityTypeEditor.Edit(view.GlobalVisibility, visibility) Then
				view.GlobalVisibility = visibility
			End If
		End Sub

		Private Sub documentShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles documentShadowButton.Click
			If EventsHandlingPaused Then
				Return
			End If

			Dim shadow As NShadowStyle
			If NShadowStyleTypeEditor.Edit(view.DocumentShadow, shadow) Then
				view.DocumentShadow = shadow
			End If
		End Sub

		Private Sub documentPaddingButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles documentPaddingButton.Click
			Dim result As Nevron.Diagram.NMargins = New Nevron.Diagram.NMargins()
			If Nevron.Diagram.Editors.NMarginsTypeEditor.Edit(view.DocumentPadding, result) = False Then
				Return
			End If

			view.DocumentPadding = result
			view.Refresh()
		End Sub


		Private Sub viewStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles viewStyleCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			view.ViewLayout = CType(viewStyleCombo.SelectedItem, ViewLayout)

			Dim enable As Boolean = (view.ViewLayout = ViewLayout.Normal)
			zoomScroll.Enabled = enable
			scaleXScroll.Enabled = enable
			scaleYScroll.Enabled = enable

			view.Refresh()
		End Sub

		Private Sub zoomScroll_ValueChanged(ByVal sender As Object, ByVal e As ScrollBarEventArgs) Handles zoomScroll.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim value As Single = CSng(zoomScroll.Value)
			view.Zoom(CSng(value) / 10)
			zoomPercentLabel.Text = Convert.ToString(value * 10) & "%"

			scaleXScroll.Value = CInt(Fix(value))
			scaleYScroll.Value = CInt(Fix(value))

			view.Refresh()
		End Sub

		Private Sub scaleXScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles scaleXScroll.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim value As Single = CSng(scaleXScroll.Value)
			view.ScaleX = (CSng(value) / 10)
			scaleXPercentLabel.Text = Convert.ToString(value * 10) & "%"

			view.Refresh()
		End Sub

		Private Sub scaleYScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles scaleYScroll.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim value As Single = CSng(scaleYScroll.Value)
			view.ScaleY = (CSng(value) / 10)
			scaleYPercentLabel.Text = Convert.ToString(value * 10) & "%"

			view.Refresh()
		End Sub


		Private Sub scrollBarsCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles scrollBarsCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			view.ScrollBars = CType(scrollBarsCombo.SelectedItem, ScrollBars)
		End Sub

		Private Sub nonScrollSceneAlignmentCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nonScrollSceneAlignmentCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			view.NonScrollableSceneAlignment = CType(nonScrollSceneAlignmentCombo.SelectedItem, ContentAlignment)
		End Sub

		Private Sub smallScrollChangeNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles smallScrollChangeNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim change As Integer = CInt(Fix(smallScrollChangeNumeric.Value))
			view.SmallScrollChange = New NSize(change, change)
		End Sub

		Private Sub autoScrollDelayNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles autoScrollDelayNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim delay As Integer = CInt(Fix(autoScrollDelayNumeric.Value))
			view.AutoScroller.Delay = delay
		End Sub

		Private Sub autoScrollTimeNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles autoScrollTimeNumeric.ValueChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim time As Integer = CInt(Fix(autoScrollTimeNumeric.Value))
			view.AutoScroller.Time = time
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents documentPaddingButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents viewStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents scaleYScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents scaleXScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents zoomScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents scrollBarsCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private nNumericUpDown1 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label6 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private scalingGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private scrollbarsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private generalGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents documentShadowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents globalVisibilityButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents smallScrollChangeNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents viewportOriginYNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents viewportOriginXNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents nonScrollSceneAlignmentCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents autoScrollDelayNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents autoScrollTimeNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label10 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private zoomPercentLabel As System.Windows.Forms.Label
		Private scaleXPercentLabel As System.Windows.Forms.Label
		Private scaleYPercentLabel As System.Windows.Forms.Label

		#End Region
	End Class
End Namespace