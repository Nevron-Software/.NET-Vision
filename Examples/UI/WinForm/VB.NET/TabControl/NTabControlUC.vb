Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NTabControlUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
		End Sub


		#End Region

		#Region "Implementation"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
				m_DefRenderer.Dispose()
				m_CustomRenderer.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_XPBackgroundCheck.Checked = nTabControl1.DrawThemeBackground

			m_TabStyleCombo.FillFromEnum(GetType(TabStyle), False)
			m_TabStyleCombo.SelectedItem = TabStyle.Standard

			m_TabAlignCombo.FillFromEnum(GetType(TabAlign), False)
			m_TabAlignCombo.SelectedItem = TabAlign.Top

			m_TextOrientationCombo.FillFromEnum(GetType(TextOrientation), False)
			m_TextOrientationCombo.SelectedItem = TextOrientation.Automatic

			m_DefRenderer = New NTabControlRenderer(nTabControl1)
			m_CustomRenderer = New NCustomTabControlRenderer(nTabControl1)

			Dim item As NListBoxItem

			item = New NListBoxItem(m_DefRenderer)
			item.Text = "Default Renderer"
			m_RenderersCombo.Items.Add(item)

			item = New NListBoxItem(m_CustomRenderer)
			item.Text = "Custom Renderer"
			m_RenderersCombo.Items.Add(item)
			m_RenderersCombo.SelectedIndex = 0

			'nTabPage1.Text = "Long text tab page";
			nTabControl1.HasClose = True
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_TabAlignCombo.SelectedIndexChanged
			Me.nTabControl1.TabAlign = CType(Me.m_TabAlignCombo.SelectedIndex, TabAlign)
		End Sub

		Private Sub m_CurveWidth_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_CurveWidth.ValueChanged
			Me.nTabControl1.TabCurveWidth = CInt(Fix(m_CurveWidth.Value))
		End Sub
		Private Sub m_HotTrack_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_HotTrack.CheckedChanged
			nTabControl1.HotTrack = m_HotTrack.Checked
		End Sub
		Private Sub m_TabStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_TabStyleCombo.SelectedIndexChanged
			nTabControl1.TabStyle = CType(Me.m_TabStyleCombo.SelectedIndex, TabStyle)
		End Sub
		Private Sub nComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_TextOrientationCombo.SelectedIndexChanged
			nTabControl1.TextOrientation = CType(m_TextOrientationCombo.SelectedIndex, TextOrientation)
		End Sub

		Private Sub m_RenderersCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_RenderersCombo.SelectedIndexChanged
			If m_RenderersCombo.Items.Count = 0 Then
				Return
			End If
			Try
				Dim r As NTabControlRenderer = TryCast(m_RenderersCombo.SelectedItem, NTabControlRenderer)
				If Not r Is Nothing AndAlso Not r Is nTabControl1.Renderer Then
					nTabControl1.Renderer = r
				End If
			Catch
			End Try
		End Sub

		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox2.CheckedChanged
			nTabControl1.HasArrows = nCheckBox2.Checked
		End Sub
		Private Sub nCheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_HasCloseCheck.CheckedChanged
			nTabControl1.HasClose = m_HasCloseCheck.Checked
		End Sub

		Private Sub nCheckBox4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_AllowTabReorderCheck.CheckedChanged
			nTabControl1.AllowTabReorder = m_AllowTabReorderCheck.Checked
		End Sub

		Private Sub m_SelectableCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_SelectableCheck.CheckedChanged
			nTabControl1.Selectable = m_SelectableCheck.Checked
		End Sub

		Private Sub m_ShowFocusRectCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowFocusRectCheck.CheckedChanged
			nTabControl1.ShowFocusRect = m_ShowFocusRectCheck.Checked
		End Sub

		Private Sub m_AddPageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_AddPageButton.Click
			Dim page As NTabPage = New NTabPage()

			Dim index As Integer = nTabControl1.Controls.Count
			'page.Text = "Tab Page " + nTabControl1.Controls.Count + "!!!!!";
			page.Text = "Tab &Page " & "1" & "!!!!!"

			Dim maxIndex As Integer = imageList1.Images.Count - 1
			If index > maxIndex Then
				index = 0
			End If

			page.ImageIndex = index

			nTabControl1.TabPages.Add(page)
		End Sub

		Private Sub m_XPBackgroundCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_XPBackgroundCheck.CheckedChanged
			nTabControl1.DrawThemeBackground = m_XPBackgroundCheck.Checked
		End Sub

		Private Sub m_FontButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FontButton.Click
			Dim dlg As FontDialog = New FontDialog()
			dlg.Font = Me.nTabControl1.Font
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Me.nTabControl1.Font = dlg.Font
			End If
		End Sub
		Private Sub removePageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles removePageButton.Click
			Me.nTabControl1.TabPages.RemoveAt(Me.nTabControl1.SelectedIndex)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NTabControlUC))
			Me.nTabControl1 = New Nevron.UI.WinForm.Controls.NTabControl()
			Me.nTabPage1 = New Nevron.UI.WinForm.Controls.NTabPage()
			Me.nTabPage2 = New Nevron.UI.WinForm.Controls.NTabPage()
			Me.nTabPage3 = New Nevron.UI.WinForm.Controls.NTabPage()
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nColorBar1 = New Nevron.UI.WinForm.Controls.NColorBar()
			Me.nColorButton1 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.nColorPool1 = New Nevron.UI.WinForm.Controls.NColorPool()
			Me.m_TabAlignCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_CurveWidth = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_HotTrack = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_TabStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_TextOrientationCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.m_RenderersCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_HasCloseCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_AllowTabReorderCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_SelectableCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_ShowFocusRectCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_AddPageButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_XPBackgroundCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_FontButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.removePageButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nTabControl1.SuspendLayout()
			CType(Me.m_CurveWidth, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nTabControl1
			' 
			Me.nTabControl1.Controls.Add(Me.nTabPage1)
			Me.nTabControl1.Controls.Add(Me.nTabPage2)
			Me.nTabControl1.Controls.Add(Me.nTabPage3)
			Me.nTabControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nTabControl1.HasClose = True
			Me.nTabControl1.ImageList = Me.imageList1
			Me.nTabControl1.Location = New System.Drawing.Point(10, 10)
			Me.nTabControl1.Name = "nTabControl1"
			Me.nTabControl1.Selectable = True
			Me.nTabControl1.SelectedIndex = 0
			Me.nTabControl1.Size = New System.Drawing.Size(708, 342)
			Me.nTabControl1.TabIndex = 0
			' 
			' nTabPage1
			' 
			Me.nTabPage1.ImageIndex = 0
			Me.nTabPage1.Location = New System.Drawing.Point(4, 29)
			Me.nTabPage1.Name = "nTabPage1"
			Me.nTabPage1.Size = New System.Drawing.Size(700, 309)
			Me.nTabPage1.TabIndex = 1
			Me.nTabPage1.Text = "nTabPage1"
			' 
			' nTabPage2
			' 
			Me.nTabPage2.ImageIndex = 1
			Me.nTabPage2.Location = New System.Drawing.Point(4, 29)
			Me.nTabPage2.Name = "nTabPage2"
			Me.nTabPage2.Size = New System.Drawing.Size(700, 309)
			Me.nTabPage2.TabIndex = 2
			Me.nTabPage2.Text = "nTabPage2"
			' 
			' nTabPage3
			' 
			Me.nTabPage3.ImageIndex = 9
			Me.nTabPage3.Location = New System.Drawing.Point(4, 29)
			Me.nTabPage3.Name = "nTabPage3"
			Me.nTabPage3.Size = New System.Drawing.Size(700, 309)
			Me.nTabPage3.TabIndex = 3
			Me.nTabPage3.Text = "nTabPage3"
			' 
			' imageList1
			' 
			Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			' 
			' nButton1
			' 
			Me.nButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nButton1.Location = New System.Drawing.Point(216, 136)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.Size = New System.Drawing.Size(75, 23)
			Me.nButton1.TabIndex = 4
			Me.nButton1.Text = "nButton1"
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.ButtonProperties.BorderOffset = 2
			Me.nCheckBox1.Location = New System.Drawing.Point(112, 136)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(104, 24)
			Me.nCheckBox1.TabIndex = 3
			Me.nCheckBox1.Text = "nCheckBox1"
			' 
			' nColorBar1
			' 
			Me.nColorBar1.Location = New System.Drawing.Point(208, 8)
			Me.nColorBar1.Name = "nColorBar1"
			Me.nColorBar1.Size = New System.Drawing.Size(50, 112)
			Me.nColorBar1.TabIndex = 2
			Me.nColorBar1.Text = "nColorBar1"
			' 
			' nColorButton1
			' 
			Me.nColorButton1.ArrowClickOptions = False
			Me.nColorButton1.ArrowWidth = 14
			Me.nColorButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nColorButton1.Location = New System.Drawing.Point(8, 128)
			Me.nColorButton1.Name = "nColorButton1"
			Me.nColorButton1.Size = New System.Drawing.Size(75, 23)
			Me.nColorButton1.TabIndex = 1
			' 
			' nColorPool1
			' 
			Me.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.nColorPool1.Color = System.Drawing.Color.Empty
			Me.nColorPool1.Hue = 0F
			Me.nColorPool1.Location = New System.Drawing.Point(8, 8)
			Me.nColorPool1.Luminance = 0.5F
			Me.nColorPool1.Name = "nColorPool1"
			Me.nColorPool1.Saturation = 0F
			Me.nColorPool1.Size = New System.Drawing.Size(192, 112)
			Me.nColorPool1.TabIndex = 0
			' 
			' m_TabAlignCombo
			' 
			Me.m_TabAlignCombo.Location = New System.Drawing.Point(112, 360)
			Me.m_TabAlignCombo.Name = "m_TabAlignCombo"
			Me.m_TabAlignCombo.Size = New System.Drawing.Size(152, 22)
			Me.m_TabAlignCombo.TabIndex = 1
			Me.m_TabAlignCombo.Text = "nComboBox1"
'			Me.m_TabAlignCombo.SelectedIndexChanged += New System.EventHandler(Me.nComboBox1_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(48, 360)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(56, 23)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Tab Align:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_CurveWidth
			' 
			Me.m_CurveWidth.Location = New System.Drawing.Point(376, 360)
			Me.m_CurveWidth.Maximum = New Decimal(New Integer() { 10, 0, 0, 0})
			Me.m_CurveWidth.Name = "m_CurveWidth"
			Me.m_CurveWidth.Size = New System.Drawing.Size(88, 20)
			Me.m_CurveWidth.TabIndex = 3
			Me.m_CurveWidth.Value = New Decimal(New Integer() { 4, 0, 0, 0})
'			Me.m_CurveWidth.ValueChanged += New System.EventHandler(Me.m_CurveWidth_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(272, 360)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(96, 23)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Tab Curve Width:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_HotTrack
			' 
			Me.m_HotTrack.ButtonProperties.BorderOffset = 2
			Me.m_HotTrack.Checked = True
			Me.m_HotTrack.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_HotTrack.Location = New System.Drawing.Point(112, 456)
			Me.m_HotTrack.Name = "m_HotTrack"
			Me.m_HotTrack.Size = New System.Drawing.Size(88, 24)
			Me.m_HotTrack.TabIndex = 5
			Me.m_HotTrack.Text = "Hot &Track"
'			Me.m_HotTrack.CheckedChanged += New System.EventHandler(Me.m_HotTrack_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(40, 392)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(64, 23)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Tab Style:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_TabStyleCombo
			' 
			Me.m_TabStyleCombo.Location = New System.Drawing.Point(112, 392)
			Me.m_TabStyleCombo.Name = "m_TabStyleCombo"
			Me.m_TabStyleCombo.Size = New System.Drawing.Size(152, 22)
			Me.m_TabStyleCombo.TabIndex = 7
			Me.m_TabStyleCombo.Text = "nComboBox2"
'			Me.m_TabStyleCombo.SelectedIndexChanged += New System.EventHandler(Me.m_TabStyleCombo_SelectedIndexChanged);
			' 
			' m_TextOrientationCombo
			' 
			Me.m_TextOrientationCombo.Location = New System.Drawing.Point(112, 424)
			Me.m_TextOrientationCombo.Name = "m_TextOrientationCombo"
			Me.m_TextOrientationCombo.Size = New System.Drawing.Size(152, 22)
			Me.m_TextOrientationCombo.TabIndex = 8
			Me.m_TextOrientationCombo.Text = "nComboBox2"
'			Me.m_TextOrientationCombo.SelectedIndexChanged += New System.EventHandler(Me.nComboBox2_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 424)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(96, 23)
			Me.label4.TabIndex = 9
			Me.label4.Text = "Text Orientation:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_RenderersCombo
			' 
			Me.m_RenderersCombo.Location = New System.Drawing.Point(376, 384)
			Me.m_RenderersCombo.Name = "m_RenderersCombo"
			Me.m_RenderersCombo.Size = New System.Drawing.Size(184, 22)
			Me.m_RenderersCombo.TabIndex = 12
			Me.m_RenderersCombo.Text = "nComboBox3"
'			Me.m_RenderersCombo.SelectedIndexChanged += New System.EventHandler(Me.m_RenderersCombo_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(272, 384)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(96, 23)
			Me.label6.TabIndex = 13
			Me.label6.Text = "Select Renderer:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.ButtonProperties.BorderOffset = 2
			Me.nCheckBox2.Checked = True
			Me.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox2.Location = New System.Drawing.Point(208, 456)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(88, 24)
			Me.nCheckBox2.TabIndex = 14
			Me.nCheckBox2.Text = "Has &Arrows"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' m_HasCloseCheck
			' 
			Me.m_HasCloseCheck.ButtonProperties.BorderOffset = 2
			Me.m_HasCloseCheck.Checked = True
			Me.m_HasCloseCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_HasCloseCheck.Location = New System.Drawing.Point(336, 456)
			Me.m_HasCloseCheck.Name = "m_HasCloseCheck"
			Me.m_HasCloseCheck.Size = New System.Drawing.Size(88, 24)
			Me.m_HasCloseCheck.TabIndex = 15
			Me.m_HasCloseCheck.Text = "Has &Close"
'			Me.m_HasCloseCheck.CheckedChanged += New System.EventHandler(Me.nCheckBox3_CheckedChanged);
			' 
			' m_AllowTabReorderCheck
			' 
			Me.m_AllowTabReorderCheck.ButtonProperties.BorderOffset = 2
			Me.m_AllowTabReorderCheck.Location = New System.Drawing.Point(208, 480)
			Me.m_AllowTabReorderCheck.Name = "m_AllowTabReorderCheck"
			Me.m_AllowTabReorderCheck.Size = New System.Drawing.Size(120, 24)
			Me.m_AllowTabReorderCheck.TabIndex = 16
			Me.m_AllowTabReorderCheck.Text = "Allow Tab &Reorder"
'			Me.m_AllowTabReorderCheck.CheckedChanged += New System.EventHandler(Me.nCheckBox4_CheckedChanged);
			' 
			' m_SelectableCheck
			' 
			Me.m_SelectableCheck.ButtonProperties.BorderOffset = 2
			Me.m_SelectableCheck.Checked = True
			Me.m_SelectableCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_SelectableCheck.Location = New System.Drawing.Point(112, 480)
			Me.m_SelectableCheck.Name = "m_SelectableCheck"
			Me.m_SelectableCheck.Size = New System.Drawing.Size(80, 24)
			Me.m_SelectableCheck.TabIndex = 17
			Me.m_SelectableCheck.Text = "Selectable"
'			Me.m_SelectableCheck.CheckedChanged += New System.EventHandler(Me.m_SelectableCheck_CheckedChanged);
			' 
			' m_ShowFocusRectCheck
			' 
			Me.m_ShowFocusRectCheck.ButtonProperties.BorderOffset = 2
			Me.m_ShowFocusRectCheck.Checked = True
			Me.m_ShowFocusRectCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_ShowFocusRectCheck.Location = New System.Drawing.Point(336, 480)
			Me.m_ShowFocusRectCheck.Name = "m_ShowFocusRectCheck"
			Me.m_ShowFocusRectCheck.Size = New System.Drawing.Size(120, 24)
			Me.m_ShowFocusRectCheck.TabIndex = 18
			Me.m_ShowFocusRectCheck.Text = "Show Focus Rect"
'			Me.m_ShowFocusRectCheck.CheckedChanged += New System.EventHandler(Me.m_ShowFocusRectCheck_CheckedChanged);
			' 
			' m_AddPageButton
			' 
			Me.m_AddPageButton.Location = New System.Drawing.Point(112, 512)
			Me.m_AddPageButton.Name = "m_AddPageButton"
			Me.m_AddPageButton.Size = New System.Drawing.Size(91, 23)
			Me.m_AddPageButton.TabIndex = 19
			Me.m_AddPageButton.Text = "Add Page"
'			Me.m_AddPageButton.Click += New System.EventHandler(Me.m_AddPageButton_Click);
			' 
			' m_XPBackgroundCheck
			' 
			Me.m_XPBackgroundCheck.ButtonProperties.BorderOffset = 2
			Me.m_XPBackgroundCheck.Location = New System.Drawing.Point(462, 456)
			Me.m_XPBackgroundCheck.Name = "m_XPBackgroundCheck"
			Me.m_XPBackgroundCheck.Size = New System.Drawing.Size(176, 24)
			Me.m_XPBackgroundCheck.TabIndex = 20
			Me.m_XPBackgroundCheck.Text = "Render XP Background"
'			Me.m_XPBackgroundCheck.CheckedChanged += New System.EventHandler(Me.m_XPBackgroundCheck_CheckedChanged);
			' 
			' m_FontButton
			' 
			Me.m_FontButton.Location = New System.Drawing.Point(306, 512)
			Me.m_FontButton.Name = "m_FontButton"
			Me.m_FontButton.Size = New System.Drawing.Size(75, 23)
			Me.m_FontButton.TabIndex = 21
			Me.m_FontButton.Text = "Font..."
'			Me.m_FontButton.Click += New System.EventHandler(Me.m_FontButton_Click);
			' 
			' removePageButton
			' 
			Me.removePageButton.Location = New System.Drawing.Point(209, 512)
			Me.removePageButton.Name = "removePageButton"
			Me.removePageButton.Size = New System.Drawing.Size(91, 23)
			Me.removePageButton.TabIndex = 22
			Me.removePageButton.Text = "Remove Page"
'			Me.removePageButton.Click += New System.EventHandler(Me.removePageButton_Click);
			' 
			' NTabControlUC
			' 
			Me.Controls.Add(Me.removePageButton)
			Me.Controls.Add(Me.m_FontButton)
			Me.Controls.Add(Me.m_XPBackgroundCheck)
			Me.Controls.Add(Me.m_AddPageButton)
			Me.Controls.Add(Me.m_ShowFocusRectCheck)
			Me.Controls.Add(Me.m_SelectableCheck)
			Me.Controls.Add(Me.m_AllowTabReorderCheck)
			Me.Controls.Add(Me.m_HasCloseCheck)
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.m_RenderersCombo)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.m_TextOrientationCombo)
			Me.Controls.Add(Me.m_TabStyleCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_HotTrack)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.m_CurveWidth)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_TabAlignCombo)
			Me.Controls.Add(Me.nTabControl1)
			Me.Name = "NTabControlUC"
			Me.DockPadding.All = 10
			Me.Size = New System.Drawing.Size(728, 552)
			Me.nTabControl1.ResumeLayout(False)
			CType(Me.m_CurveWidth, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nTabControl1 As Nevron.UI.WinForm.Controls.NTabControl
		Private imageList1 As System.Windows.Forms.ImageList
		Private nColorPool1 As Nevron.UI.WinForm.Controls.NColorPool
		Private nColorButton1 As Nevron.UI.WinForm.Controls.NColorButton
		Private nColorBar1 As Nevron.UI.WinForm.Controls.NColorBar
		Private nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents m_CurveWidth As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As System.Windows.Forms.Label
		Private WithEvents m_HotTrack As Nevron.UI.WinForm.Controls.NCheckBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents m_TabStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents m_RenderersCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label6 As System.Windows.Forms.Label
		Private components As System.ComponentModel.IContainer

		Friend m_DefRenderer As NTabControlRenderer
		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_SelectableCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_ShowFocusRectCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_TabAlignCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_TextOrientationCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_HasCloseCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_AllowTabReorderCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nTabPage1 As Nevron.UI.WinForm.Controls.NTabPage
		Private nTabPage2 As Nevron.UI.WinForm.Controls.NTabPage
		Private nTabPage3 As Nevron.UI.WinForm.Controls.NTabPage
		Private WithEvents m_AddPageButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_XPBackgroundCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_FontButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents removePageButton As NButton
		Friend m_CustomRenderer As NCustomTabControlRenderer


		#End Region
	End Class

	Public Class NCustomTabControlRenderer
		Inherits NTabControlRenderer
		Public Sub New(ByVal tab As NTabControl)
			MyBase.New(tab)
		End Sub

		#Region "Overrides"

		Protected Overrides Sub DrawTabBackground(ByVal g As Graphics)
			If m_Tab.Selected Then
				Brush.Color = Color.Chocolate
			Else
				Brush.Color = Color.Silver
			End If
			If m_Tab.Hovered Then
				Brush.Color = Color.BlanchedAlmond
			End If
			g.FillRectangle(Brush, m_TabBounds)
		End Sub
		Protected Overrides Sub DrawTabWinDefBackground(ByVal g As Graphics)
			If m_Tab.Selected Then
				Brush.Color = Color.Chocolate
			Else
				Brush.Color = Color.Silver
			End If
			If m_Tab.Hovered Then
				Brush.Color = Color.BlanchedAlmond
			End If
			g.FillRectangle(Brush, m_TabBounds)
		End Sub

		Protected Overrides Sub DrawTabBorder(ByVal g As Graphics)
			Pen.Color = Color.Black
			g.DrawRectangle(Pen, m_TabBounds)
		End Sub


		#End Region
	End Class
End Namespace
