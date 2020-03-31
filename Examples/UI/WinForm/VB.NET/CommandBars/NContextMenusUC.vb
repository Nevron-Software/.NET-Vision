Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NContextMenusUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
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
		Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
			MyBase.OnMouseUp (e)
			If e.Button = System.Windows.Forms.MouseButtons.Right Then
				nContextMenu1.Show(Control.MousePosition)
			End If
		End Sub



		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NContextMenusUC))
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nComboBoxCommand1 = New Nevron.UI.WinForm.Controls.NComboBoxCommand()
			Me.nComboBoxCommand2 = New Nevron.UI.WinForm.Controls.NComboBoxCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nContextMenu1 = New Nevron.UI.WinForm.Controls.NContextMenu()
			Me.nCommand3 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nComboBoxCommand3 = New Nevron.UI.WinForm.Controls.NComboBoxCommand()
			Me.nComboBoxCommand4 = New Nevron.UI.WinForm.Controls.NComboBoxCommand()
			Me.nCommand4 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand5 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand6 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand7 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand8 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
			Me.nCommand9 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' nComboBoxCommand1
			' 
			Me.nComboBoxCommand1.ControlText = ""
			Me.nComboBoxCommand1.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never
			' 
			' nComboBoxCommand2
			' 
			Me.nComboBoxCommand2.ControlText = ""
			Me.nComboBoxCommand2.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never
			' 
			' nContextMenu1
			' 
			Me.nContextMenu1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand3, Me.nComboBoxCommand4, Me.nCommand4})
			Me.nContextMenu1.ImageList = Me.m_ImageList
			' 
			' nCommand3
			' 
			Me.nCommand3.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nComboBoxCommand3})
			Me.nCommand3.Properties.ImageIndex = 0
			Me.nCommand3.Properties.Text = "ComboBox Command"
			' 
			' nComboBoxCommand3
			' 
			Me.nComboBoxCommand3.ControlText = ""
			Me.nComboBoxCommand3.Items.AddRange(New Object() { New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0))})
			Me.nComboBoxCommand3.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never
			' 
			' nComboBoxCommand4
			' 
			Me.nComboBoxCommand4.ControlText = "NlistBoxItem"
			Me.nComboBoxCommand4.Items.AddRange(New Object() { New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0))})
			Me.nComboBoxCommand4.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never
			' 
			' nCommand4
			' 
			Me.nCommand4.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand5, Me.nCommand6, Me.nCommand7, Me.nCommand8})
			Me.nCommand4.Properties.BeginGroup = True
			Me.nCommand4.Properties.ImageIndex = 0
			Me.nCommand4.Properties.Text = "Add/Remove Commands"
			' 
			' nCommand5
			' 
			Me.nCommand5.Checked = True
			Me.nCommand5.Properties.ImageIndex = 2
			Me.nCommand5.Properties.Text = "&File"
			' 
			' nCommand6
			' 
			Me.nCommand6.Checked = True
			Me.nCommand6.Properties.BeginGroup = True
			Me.nCommand6.Properties.ImageIndex = 3
			Me.nCommand6.Properties.Text = "&New"
			' 
			' nCommand7
			' 
			Me.nCommand7.Checked = True
			Me.nCommand7.Properties.BeginGroup = True
			Me.nCommand7.Properties.ImageIndex = 5
			Me.nCommand7.Properties.Text = "Save"
			' 
			' nCommand8
			' 
			Me.nCommand8.Checked = True
			Me.nCommand8.Properties.ImageIndex = 16
			Me.nCommand8.Properties.Text = "Save &As..."
			' 
			' m_ImageList
			' 
			Me.m_ImageList.ImageStream = (CType(resources.GetObject("m_ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
			Me.m_ImageList.Images.SetKeyName(0, "")
			Me.m_ImageList.Images.SetKeyName(1, "")
			Me.m_ImageList.Images.SetKeyName(2, "")
			Me.m_ImageList.Images.SetKeyName(3, "")
			Me.m_ImageList.Images.SetKeyName(4, "")
			Me.m_ImageList.Images.SetKeyName(5, "")
			Me.m_ImageList.Images.SetKeyName(6, "")
			Me.m_ImageList.Images.SetKeyName(7, "")
			Me.m_ImageList.Images.SetKeyName(8, "")
			Me.m_ImageList.Images.SetKeyName(9, "")
			Me.m_ImageList.Images.SetKeyName(10, "")
			Me.m_ImageList.Images.SetKeyName(11, "")
			Me.m_ImageList.Images.SetKeyName(12, "")
			Me.m_ImageList.Images.SetKeyName(13, "")
			Me.m_ImageList.Images.SetKeyName(14, "")
			Me.m_ImageList.Images.SetKeyName(15, "")
			Me.m_ImageList.Images.SetKeyName(16, "")
			Me.m_ImageList.Images.SetKeyName(17, "")
			Me.m_ImageList.Images.SetKeyName(18, "")
			Me.m_ImageList.Images.SetKeyName(19, "")
			Me.m_ImageList.Images.SetKeyName(20, "")
			Me.m_ImageList.Images.SetKeyName(21, "")
			' 
			' label1
			' 
			Me.label1.Dock = System.Windows.Forms.DockStyle.Top
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(296, 32)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Right-click on the example to show the context menu"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' NContextMenusUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Name = "NContextMenusUC"
			Me.Size = New System.Drawing.Size(296, 232)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.IContainer


		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private nComboBoxCommand1 As Nevron.UI.WinForm.Controls.NComboBoxCommand
		Private nComboBoxCommand2 As Nevron.UI.WinForm.Controls.NComboBoxCommand
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nContextMenu1 As Nevron.UI.WinForm.Controls.NContextMenu
		Private nCommand3 As Nevron.UI.WinForm.Controls.NCommand
		Private nComboBoxCommand3 As Nevron.UI.WinForm.Controls.NComboBoxCommand
		Private nComboBoxCommand4 As Nevron.UI.WinForm.Controls.NComboBoxCommand
		Private nCommand5 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand6 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand7 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand8 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand9 As Nevron.UI.WinForm.Controls.NCommand
		Friend m_ImageList As System.Windows.Forms.ImageList
		Private label1 As System.Windows.Forms.Label
		Private nCommand4 As Nevron.UI.WinForm.Controls.NCommand

		#End Region
	End Class
End Namespace
