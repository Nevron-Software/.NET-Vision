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
	''' Summary description for NNewCommandContextUC.
	''' </summary>
	Public Class NNewCommandContextUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
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


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			components = New System.ComponentModel.Container()
		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
