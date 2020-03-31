Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.IO

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NSkinningUC.
	''' </summary>
	Public Class NSkinningUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
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
			MyBase.Initialize()

			' no skin item
			Dim item As NListBoxItem = New NListBoxItem()
			item.Text = "None"
			item.Tag = Nothing
			skinCombo.Items.Add(item)

			Try
				Dim arrSkinInfo As NSkinResourceInfo() = m_MainForm.Config.AvailableSkins

				If Not arrSkinInfo Is Nothing Then
					Dim length As Integer = arrSkinInfo.Length
					Dim i As Integer = 0
					Do While i < length
						item = New NListBoxItem()
						item.Text = arrSkinInfo(i).SkinDisplayName
						item.Tag = arrSkinInfo(i).SkinResourceName
						skinCombo.Items.Add(item)
						i += 1
					Loop
				End If
			Catch
			End Try

			m_iSuspendUpdate += 1
			enableSkinManagerCheck.Checked = NSkinManager.Instance.Enabled
			m_iSuspendUpdate -= 1
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub enableSkinManagerCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles enableSkinManagerCheck.CheckedChanged
			If m_iSuspendUpdate > 0 Then
				Return
			End If

			NSkinManager.Instance.Enabled = enableSkinManagerCheck.Checked
		End Sub
		Private Sub skinCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles skinCombo.SelectedIndexChanged
			If m_iSuspendUpdate > 0 Then
				Return
			End If

			Dim skinName As String = TryCast(skinCombo.SelectedItem, String)

			If skinName Is Nothing Then
				NSkinManager.Instance.Skin = Nothing
			Else
				' load the skin
				Dim res As NSkinResource = New NSkinResource(SkinResourceType.GlobalAssembly, skinName)
				res.AssemblyName = "Nevron.UI.WinForm.Skins"

				Dim skin As NSkin = New NSkin()
				If skin.Load(res) Then
					NSkinManager.Instance.Skin = skin
				End If
			End If
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label1 = New System.Windows.Forms.Label()
			Me.skinCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.enableSkinManagerCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(0, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(88, 23)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Select skin:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' skinCombo
			' 
			Me.skinCombo.Location = New System.Drawing.Point(96, 8)
			Me.skinCombo.Name = "skinCombo"
			Me.skinCombo.Size = New System.Drawing.Size(168, 22)
			Me.skinCombo.TabIndex = 5
			Me.skinCombo.Text = "nComboBox1"
'			Me.skinCombo.SelectedIndexChanged += New System.EventHandler(Me.skinCombo_SelectedIndexChanged);
			' 
			' enableSkinManagerCheck
			' 
			Me.enableSkinManagerCheck.ButtonProperties.BorderOffset = 2
			Me.enableSkinManagerCheck.Checked = True
			Me.enableSkinManagerCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.enableSkinManagerCheck.Location = New System.Drawing.Point(96, 40)
			Me.enableSkinManagerCheck.Name = "enableSkinManagerCheck"
			Me.enableSkinManagerCheck.Size = New System.Drawing.Size(168, 24)
			Me.enableSkinManagerCheck.TabIndex = 7
			Me.enableSkinManagerCheck.Text = "Skin manager enabled"
'			Me.enableSkinManagerCheck.CheckedChanged += New System.EventHandler(Me.enableSkinManagerCheck_CheckedChanged);
			' 
			' NSkinningUC
			' 
			Me.Controls.Add(Me.enableSkinManagerCheck)
			Me.Controls.Add(Me.skinCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NSkinningUC"
			Me.Size = New System.Drawing.Size(288, 96)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private label1 As System.Windows.Forms.Label
		Private WithEvents skinCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents enableSkinManagerCheck As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace
