Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NIndividualSkinningUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Me.nButton1.TransparentBackground = True

			Me.nCommandContext1.Properties.ImageInfo.Image = NResourceHelper.BitmapFromResource(Me.GetType(), "JournalSmall.png", "Nevron.Examples.UI.WinForm.Resources.Images.NavigationPane")
			Me.nCommand1.Properties.ImageInfo.Image = NResourceHelper.BitmapFromResource(Me.GetType(), "JournalSmall.png", "Nevron.Examples.UI.WinForm.Resources.Images.NavigationPane")

			nCommandBarsManager1.ApplyPalette(NUIManager.Palette)

			Dim resource As NSkinResource = New NSkinResource(SkinResourceType.EntryAssembly, "ButtonsSkin")
			m_ButtonsSkin1 = New NSkin()
			m_ButtonsSkin1.Load(resource)

			resource.SkinName = "ScrollbarsSkin"
			m_ScrollbarsSkin1 = New NSkin()
			m_ScrollbarsSkin1.Load(resource)

			FillSkinCombo(buttonsSkinCombo)
			FillSkinCombo(scrollSkinCombo)
			FillSkinCombo(commandBarsSkinCombo)

			buttonsSkinCombo.SelectedIndex = 1
			scrollSkinCombo.SelectedIndex = 4
			commandBarsSkinCombo.SelectedIndex = 5
		End Sub

		#End Region

		#Region "Implementation"

		Friend Sub FillSkinCombo(ByVal combo As NComboBox)
			' global skin
			Dim item As NListBoxItem = New NListBoxItem()
			item.Text = "Global Skin"
			combo.Items.Add(item)

			Dim arrSkinInfo As NSkinResourceInfo() = m_MainForm.Config.AvailableSkins
			If arrSkinInfo Is Nothing Then
				Return
			End If

			Dim length As Integer = arrSkinInfo.Length

			Dim i As Integer = 0
			Do While i < length
				item = New NListBoxItem()
				item.Text = arrSkinInfo(i).SkinDisplayName
				item.Tag = arrSkinInfo(i).SkinResourceName
				combo.Items.Add(item)
				i += 1
			Loop
		End Sub
		Friend Sub OnSkinComboSelectedIndexChanged(ByVal combo As NComboBox, ByVal code As Integer)
			Dim skinResourceName As String = TryCast(combo.SelectedItem, String)

			Dim res As NSkinResource = New NSkinResource(SkinResourceType.GlobalAssembly, skinResourceName)
			res.AssemblyName = "Nevron.UI.WinForm.Skins"

			Dim skin As NSkin = New NSkin()
			If (Not skin.Load(res)) Then
				Return
			End If

			Select Case code
				Case 0
					Me.nButton1.Skin = skin
					Me.nCheckBox1.Skin = skin
					Me.nRadioButton1.Skin = skin
				Case 1
					Me.nhScrollBar1.Skin = skin
					Me.nhScrollBar2.Skin = skin
					Me.nvScrollBar1.Skin = skin
				Case 2
					Me.nCommandBarsManager1.Skin = skin
			End Select
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub buttonsSkinCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles buttonsSkinCombo.SelectedIndexChanged
			OnSkinComboSelectedIndexChanged(buttonsSkinCombo, 0)
		End Sub
		Private Sub scrollSkinCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles scrollSkinCombo.SelectedIndexChanged
			OnSkinComboSelectedIndexChanged(scrollSkinCombo, 1)
		End Sub
		Private Sub commandBarsSkinCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles commandBarsSkinCombo.SelectedIndexChanged
			OnSkinComboSelectedIndexChanged(commandBarsSkinCombo, 2)
		End Sub

		#End Region

		#Region "Fields"

		Friend m_ButtonsSkin1 As NSkin
		Friend m_ScrollbarsSkin1 As NSkin

		#End Region
	End Class
End Namespace
