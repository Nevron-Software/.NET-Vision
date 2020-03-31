Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NLineControlUC.
	''' </summary>
	Public Class NLineControlUC
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
			Me.nLineControl1 = New Nevron.UI.WinForm.Controls.NLineControl()
			Me.nLineControl2 = New Nevron.UI.WinForm.Controls.NLineControl()
			Me.nLineControl3 = New Nevron.UI.WinForm.Controls.NLineControl()
			Me.nLineControl4 = New Nevron.UI.WinForm.Controls.NLineControl()
			Me.SuspendLayout()
			' 
			' nLineControl1
			' 
			Me.nLineControl1.Location = New System.Drawing.Point(8, 8)
			Me.nLineControl1.Name = "nLineControl1"
			Me.nLineControl1.Size = New System.Drawing.Size(280, 2)
			Me.nLineControl1.Text = "nLineControl1"
			' 
			' nLineControl2
			' 
			Me.nLineControl2.Location = New System.Drawing.Point(8, 16)
			Me.nLineControl2.Name = "nLineControl2"
			Me.nLineControl2.Orientation = System.Windows.Forms.Orientation.Vertical
			Me.nLineControl2.Size = New System.Drawing.Size(2, 216)
			Me.nLineControl2.Text = "nLineControl2"
			' 
			' nLineControl3
			' 
			Me.nLineControl3.Location = New System.Drawing.Point(24, 32)
			Me.nLineControl3.Name = "nLineControl3"
			Me.nLineControl3.Size = New System.Drawing.Size(256, 2)
			Me.nLineControl3.Text = "nLineControl3"
			' 
			' nLineControl4
			' 
			Me.nLineControl4.Location = New System.Drawing.Point(24, 40)
			Me.nLineControl4.Name = "nLineControl4"
			Me.nLineControl4.Orientation = System.Windows.Forms.Orientation.Vertical
			Me.nLineControl4.Size = New System.Drawing.Size(2, 192)
			Me.nLineControl4.Text = "nLineControl4"
			' 
			' NLineControlUC
			' 
			Me.Controls.Add(Me.nLineControl4)
			Me.Controls.Add(Me.nLineControl3)
			Me.Controls.Add(Me.nLineControl2)
			Me.Controls.Add(Me.nLineControl1)
			Me.Name = "NLineControlUC"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nLineControl1 As Nevron.UI.WinForm.Controls.NLineControl
		Private nLineControl2 As Nevron.UI.WinForm.Controls.NLineControl
		Private nLineControl3 As Nevron.UI.WinForm.Controls.NLineControl
		Private nLineControl4 As Nevron.UI.WinForm.Controls.NLineControl

		#End Region
	End Class
End Namespace
