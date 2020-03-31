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
	''' Summary description for NPopupComboUC.
	''' </summary>
	Public Class NPopupComboUC
		Inherits NPopupDropDownUC
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			nPopupCombo2.Text = "Drop-down explorer bar"
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


		#End Region

		#Region "Internal Implementation"

		Friend Overrides Function GetDropDownControl() As NPopupDropDownControl
			Return nPopupCombo2
		End Function


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NPopupComboUC))
			Me.nPopupCombo2 = New Nevron.UI.WinForm.Controls.NPopupCombo()
			Me.nPopup1 = New Nevron.UI.WinForm.Controls.NPopup()
			Me.nExplorerBar1 = New Nevron.UI.WinForm.Controls.NExplorerBar()
			Me.nExpander5 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.nRichTextLabel10 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.nRichTextLabel11 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.nRichTextLabel12 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.nExpander4 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.nRichTextLabel7 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.nRichTextLabel8 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.nRichTextLabel9 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.nExpander6 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.nRichTextLabel13 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.popupInstancePanel.SuspendLayout()
			CType(Me.nExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExplorerBar1.SuspendLayout()
			CType(Me.nExpander5, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander5.SuspendLayout()
			CType(Me.nRichTextLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nRichTextLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nRichTextLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nExpander4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander4.SuspendLayout()
			CType(Me.nRichTextLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nRichTextLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nRichTextLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nExpander6, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander6.SuspendLayout()
			CType(Me.nRichTextLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' popupInstancePanel
			' 
			Me.popupInstancePanel.Controls.Add(Me.nExplorerBar1)
			Me.popupInstancePanel.Controls.Add(Me.nPopupCombo2)
			Me.popupInstancePanel.Name = "popupInstancePanel"
			' 
			' nPopupCombo2
			' 
			Me.nPopupCombo2.Location = New System.Drawing.Point(8, 8)
			Me.nPopupCombo2.Name = "nPopupCombo2"
			Me.nPopupCombo2.Popup = Me.nPopup1
			Me.nPopupCombo2.Size = New System.Drawing.Size(312, 24)
			Me.nPopupCombo2.TabIndex = 0
			Me.nPopupCombo2.Text = "nPopupCombo2"
			' 
			' nPopup1
			' 
			Me.nPopup1.HostedControl = Me.nExplorerBar1
			Me.nPopup1.Size = New Nevron.GraphicsCore.NSize(204, 316)
			Me.nPopup1.SizeStyle = Nevron.UI.PopupSizeStyle.Bottom
			' 
			' nExplorerBar1
			' 
			Me.nExplorerBar1.ClientPadding = New Nevron.UI.NPadding(8)
			Me.nExplorerBar1.Controls.Add(Me.nExpander5)
			Me.nExplorerBar1.Controls.Add(Me.nExpander4)
			Me.nExplorerBar1.Controls.Add(Me.nExpander6)
			Me.nExplorerBar1.Location = New System.Drawing.Point(8, 32)
			Me.nExplorerBar1.Name = "nExplorerBar1"
			Me.nExplorerBar1.Size = New System.Drawing.Size(200, 300)
			Me.nExplorerBar1.TabIndex = 8
			Me.nExplorerBar1.Text = "nExplorerBar1"
			Me.nExplorerBar1.Visible = False
			' 
			' nExpander5
			' 
			Me.nExpander5.BackColor = System.Drawing.Color.FromArgb((CByte(214)), (CByte(223)), (CByte(247)))
			Me.nExpander5.Controls.Add(Me.nRichTextLabel10)
			Me.nExpander5.Controls.Add(Me.nRichTextLabel11)
			Me.nExpander5.Controls.Add(Me.nRichTextLabel12)
			Me.nExpander5.Location = New System.Drawing.Point(8, 8)
			Me.nExpander5.Name = "nExpander5"
			Me.nExpander5.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nExpander5.Size = New System.Drawing.Size(184, 104)
			Me.nExpander5.TabIndex = 6
			Me.nExpander5.Text = "Other Places"
			' 
			' nRichTextLabel10
			' 
			Me.nRichTextLabel10.BackColor = System.Drawing.Color.Transparent
			Me.nRichTextLabel10.FillInfo.Draw = False
			Me.nRichTextLabel10.ForeColor = System.Drawing.Color.FromArgb((CByte(33)), (CByte(93)), (CByte(198)))
			Me.nRichTextLabel10.Item.Image = (CType(resources.GetObject("nRichTextLabel10.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel10.Item.ImageTextSpacing = 8
			Me.nRichTextLabel10.Location = New System.Drawing.Point(8, 75)
			Me.nRichTextLabel10.Name = "nRichTextLabel10"
			Me.nRichTextLabel10.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nRichTextLabel10.ShadowInfo.Draw = False
			Me.nRichTextLabel10.Size = New System.Drawing.Size(128, 24)
			Me.nRichTextLabel10.StrokeInfo.Draw = False
			Me.nRichTextLabel10.TabIndex = 5
			Me.nRichTextLabel10.Text = "Control Panel"
			' 
			' nRichTextLabel11
			' 
			Me.nRichTextLabel11.BackColor = System.Drawing.Color.Transparent
			Me.nRichTextLabel11.FillInfo.Draw = False
			Me.nRichTextLabel11.ForeColor = System.Drawing.Color.FromArgb((CByte(33)), (CByte(93)), (CByte(198)))
			Me.nRichTextLabel11.Item.Image = (CType(resources.GetObject("nRichTextLabel11.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel11.Item.ImageTextSpacing = 8
			Me.nRichTextLabel11.Location = New System.Drawing.Point(8, 51)
			Me.nRichTextLabel11.Name = "nRichTextLabel11"
			Me.nRichTextLabel11.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nRichTextLabel11.ShadowInfo.Draw = False
			Me.nRichTextLabel11.Size = New System.Drawing.Size(128, 24)
			Me.nRichTextLabel11.StrokeInfo.Draw = False
			Me.nRichTextLabel11.TabIndex = 4
			Me.nRichTextLabel11.Text = "My documents"
			' 
			' nRichTextLabel12
			' 
			Me.nRichTextLabel12.BackColor = System.Drawing.Color.Transparent
			Me.nRichTextLabel12.FillInfo.Draw = False
			Me.nRichTextLabel12.ForeColor = System.Drawing.Color.FromArgb((CByte(33)), (CByte(93)), (CByte(198)))
			Me.nRichTextLabel12.Item.Image = (CType(resources.GetObject("nRichTextLabel12.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel12.Item.ImageTextSpacing = 8
			Me.nRichTextLabel12.Location = New System.Drawing.Point(8, 27)
			Me.nRichTextLabel12.Name = "nRichTextLabel12"
			Me.nRichTextLabel12.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nRichTextLabel12.ShadowInfo.Draw = False
			Me.nRichTextLabel12.Size = New System.Drawing.Size(128, 24)
			Me.nRichTextLabel12.StrokeInfo.Draw = False
			Me.nRichTextLabel12.TabIndex = 3
			Me.nRichTextLabel12.Text = "My network places"
			' 
			' nExpander4
			' 
			Me.nExpander4.BackColor = System.Drawing.Color.FromArgb((CByte(214)), (CByte(223)), (CByte(247)))
			Me.nExpander4.Controls.Add(Me.nRichTextLabel7)
			Me.nExpander4.Controls.Add(Me.nRichTextLabel8)
			Me.nExpander4.Controls.Add(Me.nRichTextLabel9)
			Me.nExpander4.Location = New System.Drawing.Point(8, 120)
			Me.nExpander4.Name = "nExpander4"
			Me.nExpander4.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nExpander4.Size = New System.Drawing.Size(184, 104)
			Me.nExpander4.TabIndex = 4
			Me.nExpander4.Text = "System Tasks"
			' 
			' nRichTextLabel7
			' 
			Me.nRichTextLabel7.BackColor = System.Drawing.Color.Transparent
			Me.nRichTextLabel7.FillInfo.Draw = False
			Me.nRichTextLabel7.ForeColor = System.Drawing.Color.FromArgb((CByte(33)), (CByte(93)), (CByte(198)))
			Me.nRichTextLabel7.Item.Image = (CType(resources.GetObject("nRichTextLabel7.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel7.Item.ImageTextSpacing = 8
			Me.nRichTextLabel7.Location = New System.Drawing.Point(8, 74)
			Me.nRichTextLabel7.Name = "nRichTextLabel7"
			Me.nRichTextLabel7.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nRichTextLabel7.ShadowInfo.Draw = False
			Me.nRichTextLabel7.Size = New System.Drawing.Size(152, 24)
			Me.nRichTextLabel7.StrokeInfo.Draw = False
			Me.nRichTextLabel7.TabIndex = 2
			Me.nRichTextLabel7.Text = "Change a setting"
			' 
			' nRichTextLabel8
			' 
			Me.nRichTextLabel8.BackColor = System.Drawing.Color.Transparent
			Me.nRichTextLabel8.FillInfo.Draw = False
			Me.nRichTextLabel8.ForeColor = System.Drawing.Color.FromArgb((CByte(33)), (CByte(93)), (CByte(198)))
			Me.nRichTextLabel8.Item.Image = (CType(resources.GetObject("nRichTextLabel8.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel8.Item.ImageTextSpacing = 8
			Me.nRichTextLabel8.Location = New System.Drawing.Point(8, 50)
			Me.nRichTextLabel8.Name = "nRichTextLabel8"
			Me.nRichTextLabel8.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nRichTextLabel8.ShadowInfo.Draw = False
			Me.nRichTextLabel8.Size = New System.Drawing.Size(152, 24)
			Me.nRichTextLabel8.StrokeInfo.Draw = False
			Me.nRichTextLabel8.TabIndex = 1
			Me.nRichTextLabel8.Text = "Add or remove programs"
			' 
			' nRichTextLabel9
			' 
			Me.nRichTextLabel9.BackColor = System.Drawing.Color.Transparent
			Me.nRichTextLabel9.FillInfo.Draw = False
			Me.nRichTextLabel9.ForeColor = System.Drawing.Color.FromArgb((CByte(33)), (CByte(93)), (CByte(198)))
			Me.nRichTextLabel9.Item.Image = (CType(resources.GetObject("nRichTextLabel9.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel9.Item.ImageTextSpacing = 8
			Me.nRichTextLabel9.Location = New System.Drawing.Point(8, 26)
			Me.nRichTextLabel9.Name = "nRichTextLabel9"
			Me.nRichTextLabel9.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nRichTextLabel9.ShadowInfo.Draw = False
			Me.nRichTextLabel9.Size = New System.Drawing.Size(152, 24)
			Me.nRichTextLabel9.StrokeInfo.Draw = False
			Me.nRichTextLabel9.TabIndex = 0
			Me.nRichTextLabel9.Text = "View system information"
			' 
			' nExpander6
			' 
			Me.nExpander6.BackColor = System.Drawing.Color.FromArgb((CByte(214)), (CByte(223)), (CByte(247)))
			Me.nExpander6.Controls.Add(Me.nRichTextLabel13)
			Me.nExpander6.Location = New System.Drawing.Point(8, 232)
			Me.nExpander6.Name = "nExpander6"
			Me.nExpander6.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nExpander6.Size = New System.Drawing.Size(184, 56)
			Me.nExpander6.TabIndex = 7
			Me.nExpander6.Text = "Details"
			' 
			' nRichTextLabel13
			' 
			Me.nRichTextLabel13.BackColor = System.Drawing.Color.Transparent
			Me.nRichTextLabel13.FillInfo.Draw = False
			Me.nRichTextLabel13.Item.Image = (CType(resources.GetObject("nRichTextLabel13.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel13.Item.ImageTextSpacing = 8
			Me.nRichTextLabel13.Item.ItemStyle = Nevron.UI.ItemStyle.Text
			Me.nRichTextLabel13.Location = New System.Drawing.Point(8, 24)
			Me.nRichTextLabel13.Name = "nRichTextLabel13"
			Me.nRichTextLabel13.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nRichTextLabel13.ShadowInfo.Draw = False
			Me.nRichTextLabel13.Size = New System.Drawing.Size(112, 32)
			Me.nRichTextLabel13.StrokeInfo.Draw = False
			Me.nRichTextLabel13.TabIndex = 6
			Me.nRichTextLabel13.Text = "<b>My Computer</b><br/>System Folder"
			' 
			' NPopupComboUC
			' 
			Me.Name = "NPopupComboUC"
			Me.popupInstancePanel.ResumeLayout(False)
			CType(Me.nExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExplorerBar1.ResumeLayout(False)
			CType(Me.nExpander5, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander5.ResumeLayout(False)
			CType(Me.nRichTextLabel10, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nRichTextLabel11, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nRichTextLabel12, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nExpander4, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander4.ResumeLayout(False)
			CType(Me.nRichTextLabel7, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nRichTextLabel8, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nRichTextLabel9, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nExpander6, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander6.ResumeLayout(False)
			CType(Me.nRichTextLabel13, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nPopup1 As Nevron.UI.WinForm.Controls.NPopup
		Private nExplorerBar1 As Nevron.UI.WinForm.Controls.NExplorerBar
		Private nExpander5 As Nevron.UI.WinForm.Controls.NExpander
		Private nRichTextLabel10 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private nRichTextLabel11 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private nRichTextLabel12 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private nExpander4 As Nevron.UI.WinForm.Controls.NExpander
		Private nRichTextLabel7 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private nRichTextLabel8 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private nRichTextLabel9 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private nExpander6 As Nevron.UI.WinForm.Controls.NExpander
		Private nRichTextLabel13 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private nPopupCombo2 As Nevron.UI.WinForm.Controls.NPopupCombo

		#End Region
	End Class
End Namespace
