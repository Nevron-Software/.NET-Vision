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
	''' <summary>
	''' Summary description for NCalculatorDropDownUC.
	''' </summary>
	Public Class NCalculatorDropDownUC
		Inherits NPopupDropDownUC
		#Region "Constructor"

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()

			' TODO: Add any initialization after the InitializeComponent call

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

		Friend Overrides Function GetDropDownControl() As NPopupDropDownControl
			Return nCalculatorDropDown1
		End Function


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nCalculatorDropDown1 = New Nevron.UI.WinForm.Controls.NCalculatorDropDown()
			Me.popupInstancePanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' popupInstancePanel
			' 
			Me.popupInstancePanel.Controls.Add(Me.nCalculatorDropDown1)
			Me.popupInstancePanel.Name = "popupInstancePanel"
			' 
			' nCalculatorDropDown1
			' 
			Me.nCalculatorDropDown1.Location = New System.Drawing.Point(8, 8)
			Me.nCalculatorDropDown1.Name = "nCalculatorDropDown1"
			Me.nCalculatorDropDown1.Size = New System.Drawing.Size(312, 24)
			Me.nCalculatorDropDown1.TabIndex = 0
			Me.nCalculatorDropDown1.Text = "nCalculatorDropDown1"
			' 
			' NCalculatorDropDownUC
			' 
			Me.Name = "NCalculatorDropDownUC"
			Me.Size = New System.Drawing.Size(336, 264)
			Me.popupInstancePanel.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nCalculatorDropDown1 As Nevron.UI.WinForm.Controls.NCalculatorDropDown

		#End Region
	End Class
End Namespace
