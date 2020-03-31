Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
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
	''' Summary description for NCommandImageSupportUC.
	''' </summary>
	Public Class NCommandImageSupportUC
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

			Me.nCommandBarsManager1.Palette.Copy(NUIManager.Palette)

			Dim t As Type = Me.GetType()

			nDockingToolbar1.ImageSize = New Size(48, 48)

			Dim path As String = "Nevron.Examples.UI.WinForm.Resources.Images"

			Dim bmp As Bitmap = NResourceHelper.BitmapFromResource(t, "Clock.png", path)
			nCommand1.Properties.ImageInfo.Image = bmp

			bmp = NResourceHelper.BitmapFromResource(t, "Envelope.png", path)
			nCommand2.Properties.ImageInfo.Image = bmp

			bmp = NResourceHelper.BitmapFromResource(t, "Flash.png", path)
			nCommand3.Properties.ImageInfo.Image = bmp

			bmp = NResourceHelper.BitmapFromResource(t, "Book.png", path)
			nCommand4.Properties.ImageInfo.Image = bmp

			bmp = NResourceHelper.BitmapFromResource(t, "Pencil.png", path)
			nCommand5.Properties.ImageInfo.Image = bmp

			bmp = NResourceHelper.BitmapFromResource(t, "Light.png", path)
			nCommand6.Properties.ImageInfo.Image = bmp

			bmp = NResourceHelper.BitmapFromResource(t, "Globe.png", path)
			nCommand7.Properties.ImageInfo.Image = bmp

			bmp = NResourceHelper.BitmapFromResource(t, "Mobile.png", path)
			nCommand8.Properties.ImageInfo.Image = bmp

			bmp = NResourceHelper.BitmapFromResource(t, "Flask.png", path)
			nCommand9.Properties.ImageInfo.Image = bmp

			bmp = NResourceHelper.BitmapFromResource(t, "Darts.png", path)
			nCommand10.Properties.ImageInfo.Image = bmp
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
			Process.Start("http://www.icongalore.com")
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NCommandImageSupportUC))
			Me.nCommandBarsManager1 = New Nevron.UI.WinForm.Controls.NCommandBarsManager(Me.components)
			Me.nDockingToolbar1 = New Nevron.UI.WinForm.Controls.NDockingToolbar()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand3 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand4 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand5 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand6 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand7 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand8 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand9 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand10 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.label1 = New System.Windows.Forms.Label()
			Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
			Me.SuspendLayout()
			' 
			' nCommandBarsManager1
			' 
			Me.nCommandBarsManager1.ParentControl = Me
			Me.nCommandBarsManager1.Toolbars.Add(Me.nDockingToolbar1)
			' 
			' nDockingToolbar1
			' 
			Me.nDockingToolbar1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand1, Me.nCommand2, Me.nCommand3, Me.nCommand4, Me.nCommand5, Me.nCommand6, Me.nCommand7, Me.nCommand8, Me.nCommand9, Me.nCommand10})
			Me.nDockingToolbar1.DefaultLocation = New System.Drawing.Point(0, 0)
			Me.nDockingToolbar1.Name = "nDockingToolbar1"
			Me.nDockingToolbar1.PrefferedRowIndex = 0
			Me.nDockingToolbar1.RowIndex = 0
			Me.nDockingToolbar1.Text = "Custom 1"
			' 
			' nCommand1
			' 
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(56, 104)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(144, 24)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Sample images used from:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' linkLabel1
			' 
			Me.linkLabel1.Location = New System.Drawing.Point(208, 104)
			Me.linkLabel1.Name = "linkLabel1"
			Me.linkLabel1.Size = New System.Drawing.Size(144, 23)
			Me.linkLabel1.TabIndex = 5
			Me.linkLabel1.TabStop = True
			Me.linkLabel1.Text = "http://www.icongalore.com"
			Me.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'			Me.linkLabel1.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.linkLabel1_LinkClicked);
			' 
			' NCommandImageSupportUC
			' 
			Me.Controls.Add(Me.linkLabel1)
			Me.Controls.Add(Me.label1)
			Me.Name = "NCommandImageSupportUC"
			Me.Size = New System.Drawing.Size(528, 400)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nCommandBarsManager1 As Nevron.UI.WinForm.Controls.NCommandBarsManager
		Private nDockingToolbar1 As Nevron.UI.WinForm.Controls.NDockingToolbar
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand3 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand4 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand5 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand6 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand7 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand8 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand9 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand10 As Nevron.UI.WinForm.Controls.NCommand
		Private label1 As System.Windows.Forms.Label
		Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
		Private components As System.ComponentModel.IContainer

		#End Region
	End Class
End Namespace
