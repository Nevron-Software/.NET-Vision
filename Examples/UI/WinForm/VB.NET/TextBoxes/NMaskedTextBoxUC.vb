Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NMaskedTextBoxUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub borderBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles borderBtn.Click
			Me.nMaskedTextBox1.Border.ShowEditor()
		End Sub
		Private Sub paletteBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles paletteBtn.Click
			Me.nMaskedTextBox1.Palette.ShowEditor()
		End Sub
		Private Sub enableSkinningCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles enableSkinningCheck.CheckedChanged
			Dim isChecked As Boolean = enableSkinningCheck.Checked

			Me.borderBtn.Enabled = isChecked = False
			Me.paletteBtn.Enabled = isChecked = False
			Me.nMaskedTextBox1.EnableSkinning = isChecked
		End Sub

		#End Region
	End Class
End Namespace
