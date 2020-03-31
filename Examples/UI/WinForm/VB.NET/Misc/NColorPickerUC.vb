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
	''' <summary>
	''' Summary description for NColorPickerUC.
	''' </summary>
	Public Class NColorPickerUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub


		#End Region

		#Region "Implementation"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nColorPicker1 = New Nevron.UI.WinForm.Controls.NColorPicker()
			Me.SuspendLayout()
			' 
			' nColorPicker1
			' 
			Me.nColorPicker1.Location = New System.Drawing.Point(0, 0)
			Me.nColorPicker1.Name = "nColorPicker1"
			Me.nColorPicker1.Size = New System.Drawing.Size(280, 336)
			Me.nColorPicker1.TabIndex = 0
			' 
			' NColorPickerUC
			' 
			Me.Controls.Add(Me.nColorPicker1)
			Me.Name = "NColorPickerUC"
			Me.Size = New System.Drawing.Size(280, 336)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nColorPicker1 As Nevron.UI.WinForm.Controls.NColorPicker

		#End Region
	End Class
End Namespace
