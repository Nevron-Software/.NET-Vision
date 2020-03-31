Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NPopupDropDownUC.
	''' </summary>
	Public Class NPopupDropDownUC
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

			FillCombos()

			m_DropDownControl = GetDropDownControl()
			If m_DropDownControl Is Nothing Then
				Return
			End If

			InitFromDropDown()
		End Sub


		#End Region

		#Region "Internal Implementation"

		Friend Overridable Function GetDropDownControl() As NPopupDropDownControl
			Return Nothing
		End Function
		Friend Sub FillCombos()
			sizeStyleCombo.FillFromEnum(GetType(PopupSizeStyle))
			directionCombo.FillFromEnum(GetType(Direction))
			halignCombo.FillFromEnum(GetType(PopupHAlignment))
			valignCombo.FillFromEnum(GetType(PopupVAlignment))
		End Sub
		Friend Sub InitFromDropDown()
			Dim p As NPopup = m_DropDownControl.Popup

			directionCombo.SelectedItem = m_DropDownControl.DropDownDirection
			sizeStyleCombo.SelectedItem = p.SizeStyle
			halignCombo.SelectedItem = p.PlacementInfo.HAlign
			valignCombo.SelectedItem = p.PlacementInfo.VAlign

			useDefPlacementCheck.Checked = m_DropDownControl.UseDefaultPopupPlacement
			fadeInCheck.Checked = p.AnimationInfo.FadeIn
			fadeOutCheck.Checked = p.AnimationInfo.FadeOut
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub directionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles directionCombo.SelectedIndexChanged
			If m_DropDownControl Is Nothing Then
				Return
			End If

			m_DropDownControl.DropDownDirection = CType(directionCombo.SelectedItem, Direction)
		End Sub
		Private Sub sizeStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sizeStyleCombo.SelectedIndexChanged
			If m_DropDownControl Is Nothing Then
				Return
			End If

			m_DropDownControl.Popup.SizeStyle = CType(sizeStyleCombo.SelectedItem, PopupSizeStyle)
		End Sub
		Private Sub halignCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles halignCombo.SelectedIndexChanged
			If m_DropDownControl Is Nothing Then
				Return
			End If

			m_DropDownControl.Popup.PlacementInfo.HAlign = CType(halignCombo.SelectedItem, PopupHAlignment)
		End Sub
		Private Sub valignCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles valignCombo.SelectedIndexChanged
			If m_DropDownControl Is Nothing Then
				Return
			End If

			m_DropDownControl.Popup.PlacementInfo.VAlign = CType(valignCombo.SelectedItem, PopupVAlignment)
		End Sub
		Private Sub useDefPlacementCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles useDefPlacementCheck.CheckedChanged
			If m_DropDownControl Is Nothing Then
				Return
			End If

			Dim isChecked As Boolean = useDefPlacementCheck.Checked
			m_DropDownControl.UseDefaultPopupPlacement = isChecked

			Dim enable As Boolean = Not isChecked

			nEntryContainer2.Enabled = enable
			nEntryContainer3.Enabled = enable

			If (Not enable) Then
				Return
			End If

			m_DropDownControl.Popup.PlacementInfo.HAlign = CType(halignCombo.SelectedItem, PopupHAlignment)
			m_DropDownControl.Popup.PlacementInfo.VAlign = CType(valignCombo.SelectedItem, PopupVAlignment)
		End Sub
		Private Sub fadeInCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fadeInCheck.CheckedChanged
			If m_DropDownControl Is Nothing Then
				Return
			End If

			Dim info As NPopupAnimationInfo = m_DropDownControl.Popup.AnimationInfo
			info.FadeIn = fadeInCheck.Checked

			m_DropDownControl.Popup.AnimationInfo = info
		End Sub
		Private Sub fadeOutCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fadeOutCheck.CheckedChanged
			If m_DropDownControl Is Nothing Then
				Return
			End If

			Dim info As NPopupAnimationInfo = m_DropDownControl.Popup.AnimationInfo
			info.FadeOut = fadeOutCheck.Checked

			m_DropDownControl.Popup.AnimationInfo = info
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.popupInstancePanel = New System.Windows.Forms.Panel()
			Me.propertiesPanel = New System.Windows.Forms.Panel()
			Me.nEntryContainer4 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.sizeStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.fadeOutCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.fadeInCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.useDefPlacementCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nEntryContainer3 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.valignCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nEntryContainer2 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.halignCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nEntryContainer1 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.directionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.propertiesPanel.SuspendLayout()
			CType(Me.nEntryContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer4.SuspendLayout()
			CType(Me.nEntryContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer3.SuspendLayout()
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer2.SuspendLayout()
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' popupInstancePanel
			' 
			Me.popupInstancePanel.Dock = System.Windows.Forms.DockStyle.Top
			Me.popupInstancePanel.Location = New System.Drawing.Point(0, 0)
			Me.popupInstancePanel.Name = "popupInstancePanel"
			Me.popupInstancePanel.Size = New System.Drawing.Size(336, 40)
			Me.popupInstancePanel.TabIndex = 2
			' 
			' propertiesPanel
			' 
			Me.propertiesPanel.Controls.Add(Me.nEntryContainer4)
			Me.propertiesPanel.Controls.Add(Me.fadeOutCheck)
			Me.propertiesPanel.Controls.Add(Me.fadeInCheck)
			Me.propertiesPanel.Controls.Add(Me.useDefPlacementCheck)
			Me.propertiesPanel.Controls.Add(Me.nEntryContainer3)
			Me.propertiesPanel.Controls.Add(Me.nEntryContainer2)
			Me.propertiesPanel.Controls.Add(Me.nEntryContainer1)
			Me.propertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.propertiesPanel.Location = New System.Drawing.Point(0, 40)
			Me.propertiesPanel.Name = "propertiesPanel"
			Me.propertiesPanel.Size = New System.Drawing.Size(336, 224)
			Me.propertiesPanel.TabIndex = 1
			' 
			' nEntryContainer4
			' 
			Me.nEntryContainer4.ClientPadding = New Nevron.UI.NPadding(2)
			Me.nEntryContainer4.EntryControl = Me.sizeStyleCombo
			Me.nEntryContainer4.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nEntryContainer4.LabelSize = New System.Drawing.Size(120, 0)
			Me.nEntryContainer4.Location = New System.Drawing.Point(8, 40)
			Me.nEntryContainer4.Name = "nEntryContainer4"
			Me.nEntryContainer4.Size = New System.Drawing.Size(320, 32)
			Me.nEntryContainer4.TabIndex = 6
			Me.nEntryContainer4.Text = "Size style:"
			' 
			' sizeStyleCombo
			' 
			Me.sizeStyleCombo.Location = New System.Drawing.Point(129, 3)
			Me.sizeStyleCombo.Name = "sizeStyleCombo"
			Me.sizeStyleCombo.Size = New System.Drawing.Size(183, 21)
			Me.sizeStyleCombo.TabIndex = 1
			Me.sizeStyleCombo.Text = "nComboBox1"
'			Me.sizeStyleCombo.SelectedIndexChanged += New System.EventHandler(Me.sizeStyleCombo_SelectedIndexChanged);
			' 
			' fadeOutCheck
			' 
			Me.fadeOutCheck.ButtonProperties.BorderOffset = 2
			Me.fadeOutCheck.Checked = True
			Me.fadeOutCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.fadeOutCheck.Location = New System.Drawing.Point(136, 192)
			Me.fadeOutCheck.Name = "fadeOutCheck"
			Me.fadeOutCheck.Size = New System.Drawing.Size(192, 24)
			Me.fadeOutCheck.TabIndex = 5
			Me.fadeOutCheck.Text = "Fade out"
'			Me.fadeOutCheck.CheckedChanged += New System.EventHandler(Me.fadeOutCheck_CheckedChanged);
			' 
			' fadeInCheck
			' 
			Me.fadeInCheck.ButtonProperties.BorderOffset = 2
			Me.fadeInCheck.Checked = True
			Me.fadeInCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.fadeInCheck.Location = New System.Drawing.Point(136, 168)
			Me.fadeInCheck.Name = "fadeInCheck"
			Me.fadeInCheck.Size = New System.Drawing.Size(192, 24)
			Me.fadeInCheck.TabIndex = 4
			Me.fadeInCheck.Text = "Fade in"
'			Me.fadeInCheck.CheckedChanged += New System.EventHandler(Me.fadeInCheck_CheckedChanged);
			' 
			' useDefPlacementCheck
			' 
			Me.useDefPlacementCheck.ButtonProperties.BorderOffset = 2
			Me.useDefPlacementCheck.Checked = True
			Me.useDefPlacementCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.useDefPlacementCheck.Location = New System.Drawing.Point(136, 144)
			Me.useDefPlacementCheck.Name = "useDefPlacementCheck"
			Me.useDefPlacementCheck.Size = New System.Drawing.Size(192, 24)
			Me.useDefPlacementCheck.TabIndex = 3
			Me.useDefPlacementCheck.Text = "Use default placement"
'			Me.useDefPlacementCheck.CheckedChanged += New System.EventHandler(Me.useDefPlacementCheck_CheckedChanged);
			' 
			' nEntryContainer3
			' 
			Me.nEntryContainer3.ClientPadding = New Nevron.UI.NPadding(2)
			Me.nEntryContainer3.Enabled = False
			Me.nEntryContainer3.EntryControl = Me.valignCombo
			Me.nEntryContainer3.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nEntryContainer3.LabelSize = New System.Drawing.Size(120, 0)
			Me.nEntryContainer3.Location = New System.Drawing.Point(8, 104)
			Me.nEntryContainer3.Name = "nEntryContainer3"
			Me.nEntryContainer3.Size = New System.Drawing.Size(320, 32)
			Me.nEntryContainer3.TabIndex = 2
			Me.nEntryContainer3.Text = "VAlign:"
			' 
			' valignCombo
			' 
			Me.valignCombo.Location = New System.Drawing.Point(129, 3)
			Me.valignCombo.Name = "valignCombo"
			Me.valignCombo.Size = New System.Drawing.Size(183, 21)
			Me.valignCombo.TabIndex = 1
			Me.valignCombo.Text = "nComboBox1"
'			Me.valignCombo.SelectedIndexChanged += New System.EventHandler(Me.valignCombo_SelectedIndexChanged);
			' 
			' nEntryContainer2
			' 
			Me.nEntryContainer2.ClientPadding = New Nevron.UI.NPadding(2)
			Me.nEntryContainer2.Enabled = False
			Me.nEntryContainer2.EntryControl = Me.halignCombo
			Me.nEntryContainer2.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nEntryContainer2.LabelSize = New System.Drawing.Size(120, 0)
			Me.nEntryContainer2.Location = New System.Drawing.Point(8, 72)
			Me.nEntryContainer2.Name = "nEntryContainer2"
			Me.nEntryContainer2.Size = New System.Drawing.Size(320, 32)
			Me.nEntryContainer2.TabIndex = 1
			Me.nEntryContainer2.Text = "HAlign:"
			' 
			' halignCombo
			' 
			Me.halignCombo.Location = New System.Drawing.Point(129, 3)
			Me.halignCombo.Name = "halignCombo"
			Me.halignCombo.Size = New System.Drawing.Size(183, 21)
			Me.halignCombo.TabIndex = 1
			Me.halignCombo.Text = "nComboBox1"
'			Me.halignCombo.SelectedIndexChanged += New System.EventHandler(Me.halignCombo_SelectedIndexChanged);
			' 
			' nEntryContainer1
			' 
			Me.nEntryContainer1.ClientPadding = New Nevron.UI.NPadding(2)
			Me.nEntryContainer1.EntryControl = Me.directionCombo
			Me.nEntryContainer1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nEntryContainer1.LabelSize = New System.Drawing.Size(120, 0)
			Me.nEntryContainer1.Location = New System.Drawing.Point(8, 8)
			Me.nEntryContainer1.Name = "nEntryContainer1"
			Me.nEntryContainer1.Size = New System.Drawing.Size(320, 32)
			Me.nEntryContainer1.TabIndex = 0
			Me.nEntryContainer1.Text = "Drop-down direction:"
			' 
			' directionCombo
			' 
			Me.directionCombo.Location = New System.Drawing.Point(129, 3)
			Me.directionCombo.Name = "directionCombo"
			Me.directionCombo.Size = New System.Drawing.Size(183, 21)
			Me.directionCombo.TabIndex = 1
			Me.directionCombo.Text = "nComboBox1"
'			Me.directionCombo.SelectedIndexChanged += New System.EventHandler(Me.directionCombo_SelectedIndexChanged);
			' 
			' NPopupDropDownUC
			' 
			Me.Controls.Add(Me.propertiesPanel)
			Me.Controls.Add(Me.popupInstancePanel)
			Me.Name = "NPopupDropDownUC"
			Me.Size = New System.Drawing.Size(336, 264)
			Me.propertiesPanel.ResumeLayout(False)
			CType(Me.nEntryContainer4, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer4.ResumeLayout(False)
			CType(Me.nEntryContainer3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer3.ResumeLayout(False)
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer2.ResumeLayout(False)
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_DropDownControl As NPopupDropDownControl

		Private components As System.ComponentModel.Container = Nothing
		Protected popupInstancePanel As System.Windows.Forms.Panel
		Private propertiesPanel As System.Windows.Forms.Panel
		Private nEntryContainer1 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private WithEvents directionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private nEntryContainer2 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private WithEvents halignCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private nEntryContainer3 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private WithEvents fadeOutCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents fadeInCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents useDefPlacementCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nEntryContainer4 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private WithEvents sizeStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents valignCombo As Nevron.UI.WinForm.Controls.NComboBox

		#End Region
	End Class
End Namespace
