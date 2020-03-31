Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NDesktopToolbarContentUC.
	''' </summary>
	Public Class NDesktopToolbarContentUC
		Inherits System.Windows.Forms.UserControl
		Private nExplorerBar1 As Nevron.UI.WinForm.Controls.NExplorerBar
		Private nExpander1 As Nevron.UI.WinForm.Controls.NExpander
		Private nExpander2 As Nevron.UI.WinForm.Controls.NExpander
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()

			' TODO: Add any initialization after the InitializeComponent call

		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nExplorerBar1 = New Nevron.UI.WinForm.Controls.NExplorerBar()
			Me.nExpander1 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.nExpander2 = New Nevron.UI.WinForm.Controls.NExpander()
			CType(Me.nExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExplorerBar1.SuspendLayout()
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nExplorerBar1
			' 
			Me.nExplorerBar1.ClientPadding = New Nevron.UI.NPadding(8)
			Me.nExplorerBar1.Controls.Add(Me.nExpander1)
			Me.nExplorerBar1.Controls.Add(Me.nExpander2)
			Me.nExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nExplorerBar1.Location = New System.Drawing.Point(0, 0)
			Me.nExplorerBar1.Name = "nExplorerBar1"
			Me.nExplorerBar1.Size = New System.Drawing.Size(248, 344)
			Me.nExplorerBar1.TabIndex = 0
			Me.nExplorerBar1.Text = "nExplorerBar1"
			' 
			' nExpander1
			' 
			Me.nExpander1.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander1.Location = New System.Drawing.Point(8, 8)
			Me.nExpander1.Name = "nExpander1"
			Me.nExpander1.Size = New System.Drawing.Size(232, 160)
			Me.nExpander1.TabIndex = 1
			Me.nExpander1.Text = "nExpander1"
			' 
			' nExpander2
			' 
			Me.nExpander2.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander2.Location = New System.Drawing.Point(8, 176)
			Me.nExpander2.Name = "nExpander2"
			Me.nExpander2.Size = New System.Drawing.Size(232, 136)
			Me.nExpander2.TabIndex = 2
			Me.nExpander2.Text = "nExpander2"
			' 
			' NDesktopToolbarContentUC
			' 
			Me.Controls.Add(Me.nExplorerBar1)
			Me.Name = "NDesktopToolbarContentUC"
			Me.Size = New System.Drawing.Size(248, 344)
			CType(Me.nExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExplorerBar1.ResumeLayout(False)
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region
	End Class
End Namespace
