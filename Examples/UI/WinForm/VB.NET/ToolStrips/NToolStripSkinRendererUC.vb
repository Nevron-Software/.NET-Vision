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
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NToolStripSkinRendererUC
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

			FillSkinCombo()

			Dock = DockStyle.Fill

			m_Renderer = New NToolStripSkinRenderer()
			ToolStripManager.Renderer = m_Renderer

			Me.undoToolStripMenuItem.Checked = True
		End Sub

		#End Region

		#Region "Implementation"

		Friend Sub FillSkinCombo()
			Dim arrSkinInfo As NSkinResourceInfo() = m_MainForm.Config.AvailableSkins
			If arrSkinInfo Is Nothing Then
				Return
			End If

			'add the "Use global skin" item
			Dim item As NListBoxItem = New NListBoxItem()
			item.Text = "Use global skin"
			Me.skinCombo.Items.Add(item)

			Dim length As Integer = arrSkinInfo.Length

			Dim i As Integer = 0
			Do While i < length
				item = New NListBoxItem()
				item.Text = arrSkinInfo(i).SkinDisplayName
				item.Tag = arrSkinInfo(i).SkinResourceName
				skinCombo.Items.Add(item)
				i += 1
			Loop

			skinCombo.SelectedIndex = 0
			AddHandler skinCombo.SelectedIndexChanged, AddressOf skinCombo_SelectedIndexChanged
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub skinCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim skinName As String = TryCast(skinCombo.SelectedItem, String)

			If skinName Is Nothing Then
				m_Renderer.Skin = Nothing
			Else
				' load the skin
				Dim res As NSkinResource = New NSkinResource(SkinResourceType.GlobalAssembly, skinName)
				res.AssemblyName = "Nevron.UI.WinForm.Skins"

				Dim skin As NSkin = New NSkin()
				If skin.Load(res) Then
					m_Renderer.Skin = skin
				End If
			End If
		End Sub

		#End Region

		#Region "Fields"

		Friend m_Renderer As NToolStripSkinRenderer

		#End Region
	End Class
End Namespace
