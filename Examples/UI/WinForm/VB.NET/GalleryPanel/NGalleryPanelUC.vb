Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NGalleryPanelUC.
	''' </summary>
	Public Class NGalleryPanelUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			Dock = DockStyle.Fill
			DockPadding.All = 10

			m_Panel = New NGalleryPanel()
			m_Panel.Location = New Point(8, 8)
			m_Panel.ClientPadding = New NPadding(1)
			m_Panel.Parent = Me

			m_iSuspendUpdate += 1

			layoutCombo.FillFromEnum(GetType(GalleryPanelLayout))
			layoutCombo.SelectedItem = m_Panel.ItemLayout

			selectionModeCombo.FillFromEnum(GetType(GalleryPanelSelectionMode))
			selectionModeCombo.SelectedItem = m_Panel.SelectionMode

			Dim sz As NSize = m_Panel.ItemSize
			itemSizeWidthNumeric.Value = sz.Width
			itemSizeHeightNumeric.Value = sz.Height

			hScrollVisibilityCombo.FillFromEnum(GetType(ScrollVisibility))
			hScrollVisibilityCombo.SelectedItem = m_Panel.HScrollVisibility

			vScrollVisibilityCombo.FillFromEnum(GetType(ScrollVisibility))
			vScrollVisibilityCombo.SelectedItem = m_Panel.VScrollVisibility

			hideSelCheck.Checked = m_Panel.HideSelection
			nCheckBox1.Checked = m_Panel.EnableElementTooltips
			skinBodyCheck.Checked = m_Panel.UseBodySkinning
			showFocusCheck.Checked = m_Panel.ShowFocusRect

			m_iSuspendUpdate -= 1

			InitItems()
		End Sub


		#End Region

		#Region "Implementation"

		Friend Sub InitItems()
			m_Panel.Suspend()

			Dim item As NGalleryItem
			Dim label As NLabelElement

			For i As Integer = 1 To 50
				item = New NGalleryItem()
				label = item.Label

				label.Suspend()

				label.ImageSize = New NSize(32, 32)
				label.Image = NSystemImages.Warning
				label.ContentAlign = ContentAlignment.MiddleCenter
				label.TreatAsOneEntity = False
				label.ImageAlign = ContentAlignment.MiddleLeft
				label.TextAlign = ContentAlignment.MiddleCenter
				label.Text = "<b>Item " & i & "</b><br/><font size='7' face='Tahoma' color='Navy'>Second text line</font>"
				label.TooltipText = "Tooltip over item " & i

				label.Resume(False)
				m_Panel.Items.Add(item)
			Next i

			m_Panel.Resume(False)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub layoutCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles layoutCombo.SelectedIndexChanged
			If m_Panel Is Nothing Then
				Return
			End If

			m_Panel.ItemLayout = CType(layoutCombo.SelectedItem, GalleryPanelLayout)
		End Sub
		Private Sub selectionModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectionModeCombo.SelectedIndexChanged
			If m_Panel Is Nothing Then
				Return
			End If
			m_Panel.SelectionMode = CType(selectionModeCombo.SelectedItem, GalleryPanelSelectionMode)
		End Sub
		Private Sub itemSizeWidthNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles itemSizeWidthNumeric.ValueChanged
			If m_iSuspendUpdate > 0 OrElse m_Panel Is Nothing Then
				Return
			End If

			Dim width As Integer = CInt(Fix(itemSizeWidthNumeric.Value))
			Dim height As Integer = CInt(Fix(itemSizeHeightNumeric.Value))

			m_Panel.ItemSize = New NSize(width, height)
		End Sub
		Private Sub itemSizeHeightNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles itemSizeHeightNumeric.ValueChanged
			If m_iSuspendUpdate > 0 OrElse m_Panel Is Nothing Then
				Return
			End If

			Dim width As Integer = CInt(Fix(itemSizeWidthNumeric.Value))
			Dim height As Integer = CInt(Fix(itemSizeHeightNumeric.Value))

			m_Panel.ItemSize = New NSize(width, height)
		End Sub

		Private Sub hideSelCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hideSelCheck.CheckedChanged
			If m_Panel Is Nothing Then
				Return
			End If
			m_Panel.HideSelection = hideSelCheck.Checked
		End Sub
		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			If m_Panel Is Nothing Then
				Return
			End If
			m_Panel.EnableElementTooltips = nCheckBox1.Checked
		End Sub
		Private Sub customScrollsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles customScrollsCheck.CheckedChanged
			If m_Panel Is Nothing Then
				Return
			End If
			m_Panel.UseCustomScrollbars = customScrollsCheck.Checked
		End Sub
		Private Sub showFocusCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showFocusCheck.CheckedChanged
			If m_Panel Is Nothing Then
				Return
			End If
			m_Panel.ShowFocusRect = showFocusCheck.Checked
		End Sub
		Private Sub skinBodyCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles skinBodyCheck.CheckedChanged
			If m_Panel Is Nothing Then
				Return
			End If
			m_Panel.UseBodySkinning = skinBodyCheck.Checked
		End Sub
		Private Sub hScrollVisibilityCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hScrollVisibilityCombo.SelectedIndexChanged
			If m_Panel Is Nothing Then
				Return
			End If
			m_Panel.HScrollVisibility = CType(hScrollVisibilityCombo.SelectedItem, ScrollVisibility)
		End Sub
		Private Sub vScrollVisibilityCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vScrollVisibilityCombo.SelectedIndexChanged
			If m_Panel Is Nothing Then
				Return
			End If
			m_Panel.VScrollVisibility = CType(vScrollVisibilityCombo.SelectedItem, ScrollVisibility)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label2 = New System.Windows.Forms.Label()
			Me.layoutCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.selectionModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.itemSizeHeightNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.itemSizeWidthNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.hideSelCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.hScrollVisibilityCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.vScrollVisibilityCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.showFocusCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.skinBodyCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.customScrollsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1.SuspendLayout()
			CType(Me.itemSizeHeightNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.itemSizeWidthNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(312, 8)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(100, 23)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Layout:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' layoutCombo
			' 
			Me.layoutCombo.Location = New System.Drawing.Point(312, 32)
			Me.layoutCombo.Name = "layoutCombo"
			Me.layoutCombo.Size = New System.Drawing.Size(200, 22)
			Me.layoutCombo.TabIndex = 1
			Me.layoutCombo.Text = "nComboBox1"
'			Me.layoutCombo.SelectedIndexChanged += New System.EventHandler(Me.layoutCombo_SelectedIndexChanged);
			' 
			' selectionModeCombo
			' 
			Me.selectionModeCombo.Location = New System.Drawing.Point(312, 80)
			Me.selectionModeCombo.Name = "selectionModeCombo"
			Me.selectionModeCombo.Size = New System.Drawing.Size(200, 22)
			Me.selectionModeCombo.TabIndex = 3
			Me.selectionModeCombo.Text = "nComboBox1"
'			Me.selectionModeCombo.SelectedIndexChanged += New System.EventHandler(Me.selectionModeCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(312, 56)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(100, 23)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Selection Mode:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.itemSizeHeightNumeric)
			Me.nGroupBox1.Controls.Add(Me.label5)
			Me.nGroupBox1.Controls.Add(Me.itemSizeWidthNumeric)
			Me.nGroupBox1.Controls.Add(Me.label4)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(312, 208)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(200, 80)
			Me.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox1.TabIndex = 8
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Item Size"
			' 
			' itemSizeHeightNumeric
			' 
			Me.itemSizeHeightNumeric.Location = New System.Drawing.Point(72, 48)
			Me.itemSizeHeightNumeric.Maximum = New Decimal(New Integer() { 256, 0, 0, 0})
			Me.itemSizeHeightNumeric.Minimum = New Decimal(New Integer() { 16, 0, 0, 0})
			Me.itemSizeHeightNumeric.Name = "itemSizeHeightNumeric"
			Me.itemSizeHeightNumeric.Size = New System.Drawing.Size(80, 20)
			Me.itemSizeHeightNumeric.TabIndex = 3
			Me.itemSizeHeightNumeric.Value = New Decimal(New Integer() { 16, 0, 0, 0})
'			Me.itemSizeHeightNumeric.ValueChanged += New System.EventHandler(Me.itemSizeHeightNumeric_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 48)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(56, 23)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Height:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' itemSizeWidthNumeric
			' 
			Me.itemSizeWidthNumeric.Location = New System.Drawing.Point(72, 24)
			Me.itemSizeWidthNumeric.Maximum = New Decimal(New Integer() { 256, 0, 0, 0})
			Me.itemSizeWidthNumeric.Minimum = New Decimal(New Integer() { 16, 0, 0, 0})
			Me.itemSizeWidthNumeric.Name = "itemSizeWidthNumeric"
			Me.itemSizeWidthNumeric.Size = New System.Drawing.Size(80, 20)
			Me.itemSizeWidthNumeric.TabIndex = 1
			Me.itemSizeWidthNumeric.Value = New Decimal(New Integer() { 16, 0, 0, 0})
'			Me.itemSizeWidthNumeric.ValueChanged += New System.EventHandler(Me.itemSizeWidthNumeric_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 24)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(56, 23)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Width:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' hideSelCheck
			' 
			Me.hideSelCheck.ButtonProperties.BorderOffset = 2
			Me.hideSelCheck.Location = New System.Drawing.Point(312, 320)
			Me.hideSelCheck.Name = "hideSelCheck"
			Me.hideSelCheck.Size = New System.Drawing.Size(200, 24)
			Me.hideSelCheck.TabIndex = 9
			Me.hideSelCheck.Text = "Hide Selection"
'			Me.hideSelCheck.CheckedChanged += New System.EventHandler(Me.hideSelCheck_CheckedChanged);
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.ButtonProperties.BorderOffset = 2
			Me.nCheckBox1.Location = New System.Drawing.Point(312, 368)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(200, 24)
			Me.nCheckBox1.TabIndex = 10
			Me.nCheckBox1.Text = "Enable Item Tooltips"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' hScrollVisibilityCombo
			' 
			Me.hScrollVisibilityCombo.Location = New System.Drawing.Point(312, 128)
			Me.hScrollVisibilityCombo.Name = "hScrollVisibilityCombo"
			Me.hScrollVisibilityCombo.Size = New System.Drawing.Size(200, 22)
			Me.hScrollVisibilityCombo.TabIndex = 5
			Me.hScrollVisibilityCombo.Text = "nComboBox1"
'			Me.hScrollVisibilityCombo.SelectedIndexChanged += New System.EventHandler(Me.hScrollVisibilityCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(312, 104)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 23)
			Me.label1.TabIndex = 4
			Me.label1.Text = "HScroll Visibility:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' vScrollVisibilityCombo
			' 
			Me.vScrollVisibilityCombo.Location = New System.Drawing.Point(312, 176)
			Me.vScrollVisibilityCombo.Name = "vScrollVisibilityCombo"
			Me.vScrollVisibilityCombo.Size = New System.Drawing.Size(200, 22)
			Me.vScrollVisibilityCombo.TabIndex = 7
			Me.vScrollVisibilityCombo.Text = "nComboBox1"
'			Me.vScrollVisibilityCombo.SelectedIndexChanged += New System.EventHandler(Me.vScrollVisibilityCombo_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(312, 152)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(100, 23)
			Me.label6.TabIndex = 6
			Me.label6.Text = "VScroll Visibility:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' showFocusCheck
			' 
			Me.showFocusCheck.ButtonProperties.BorderOffset = 2
			Me.showFocusCheck.Location = New System.Drawing.Point(312, 344)
			Me.showFocusCheck.Name = "showFocusCheck"
			Me.showFocusCheck.Size = New System.Drawing.Size(200, 24)
			Me.showFocusCheck.TabIndex = 11
			Me.showFocusCheck.Text = "Show Focus Rect"
'			Me.showFocusCheck.CheckedChanged += New System.EventHandler(Me.showFocusCheck_CheckedChanged);
			' 
			' skinBodyCheck
			' 
			Me.skinBodyCheck.ButtonProperties.BorderOffset = 2
			Me.skinBodyCheck.Location = New System.Drawing.Point(312, 296)
			Me.skinBodyCheck.Name = "skinBodyCheck"
			Me.skinBodyCheck.Size = New System.Drawing.Size(200, 24)
			Me.skinBodyCheck.TabIndex = 12
			Me.skinBodyCheck.Text = "Use Body Skinning"
'			Me.skinBodyCheck.CheckedChanged += New System.EventHandler(Me.skinBodyCheck_CheckedChanged);
			' 
			' customScrollsCheck
			' 
			Me.customScrollsCheck.ButtonProperties.BorderOffset = 2
			Me.customScrollsCheck.Checked = True
			Me.customScrollsCheck.Location = New System.Drawing.Point(312, 392)
			Me.customScrollsCheck.Name = "customScrollsCheck"
			Me.customScrollsCheck.Size = New System.Drawing.Size(200, 24)
			Me.customScrollsCheck.TabIndex = 13
			Me.customScrollsCheck.Text = "Use Custom Scrollbars"
'			Me.customScrollsCheck.CheckedChanged += New System.EventHandler(Me.customScrollsCheck_CheckedChanged);
			' 
			' NGalleryPanelUC
			' 
			Me.Controls.Add(Me.customScrollsCheck)
			Me.Controls.Add(Me.skinBodyCheck)
			Me.Controls.Add(Me.showFocusCheck)
			Me.Controls.Add(Me.vScrollVisibilityCombo)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.hScrollVisibilityCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.hideSelCheck)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.selectionModeCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.layoutCombo)
			Me.Controls.Add(Me.label2)
			Me.Name = "NGalleryPanelUC"
			Me.Size = New System.Drawing.Size(528, 424)
			Me.nGroupBox1.ResumeLayout(False)
			CType(Me.itemSizeHeightNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.itemSizeWidthNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_Panel As NGalleryPanel
		Private components As System.ComponentModel.Container = Nothing
		Private label2 As System.Windows.Forms.Label
		Private WithEvents layoutCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents selectionModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label3 As System.Windows.Forms.Label
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents itemSizeWidthNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents itemSizeHeightNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents hideSelCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents hScrollVisibilityCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents vScrollVisibilityCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label6 As System.Windows.Forms.Label
		Private WithEvents showFocusCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents skinBodyCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents customScrollsCheck As NCheckBox
		Private label5 As System.Windows.Forms.Label

		#End Region
	End Class
End Namespace
