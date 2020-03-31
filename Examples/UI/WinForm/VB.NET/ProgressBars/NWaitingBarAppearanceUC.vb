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
	''' Summary description for NWaitingBarAppearanceUC.
	''' </summary>
	Public Class NWaitingBarAppearanceUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				Wait(False)

				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			Wait(True)
		End Sub
		Friend Sub Wait(ByVal begin As Boolean)
			Dim count As Integer = Controls.Count
			Dim bar As NWaitingBar

			Dim i As Integer = 0
			Do While i < count
				bar = TryCast(Controls(i), NWaitingBar)
				If bar Is Nothing Then
					Continue Do
				End If

				If begin Then
					bar.BeginWait()
				Else
					bar.EndWait()
				End If
				i += 1
			Loop
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NWaitingBarAppearanceUC))
			Me.nWaitingBar1 = New Nevron.UI.WinForm.Controls.NWaitingBar()
			Me.nWaitingBar2 = New Nevron.UI.WinForm.Controls.NWaitingBar()
			Me.nWaitingBar3 = New Nevron.UI.WinForm.Controls.NWaitingBar()
			Me.nWaitingBar4 = New Nevron.UI.WinForm.Controls.NWaitingBar()
			Me.nWaitingBar5 = New Nevron.UI.WinForm.Controls.NWaitingBar()
			Me.nWaitingBar6 = New Nevron.UI.WinForm.Controls.NWaitingBar()
			Me.nWaitingBar7 = New Nevron.UI.WinForm.Controls.NWaitingBar()
			Me.SuspendLayout()
			' 
			' nWaitingBar1
			' 
			Me.nWaitingBar1.Border.Style = Nevron.UI.BorderStyle3D.Raised
			Me.nWaitingBar1.Location = New System.Drawing.Point(112, 8)
			Me.nWaitingBar1.Name = "nWaitingBar1"
			Me.nWaitingBar1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Energy
			Me.nWaitingBar1.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nWaitingBar1.Properties.Position = 40
			Me.nWaitingBar1.Properties.Step = 3
			Me.nWaitingBar1.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
			Me.nWaitingBar1.Properties.WaitSize = 200
			Me.nWaitingBar1.Size = New System.Drawing.Size(336, 24)
			Me.nWaitingBar1.TabIndex = 0
			Me.nWaitingBar1.Text = "nWaitingBar1"
			' 
			' nWaitingBar2
			' 
			Me.nWaitingBar2.Location = New System.Drawing.Point(8, 8)
			Me.nWaitingBar2.Name = "nWaitingBar2"
			Me.nWaitingBar2.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nWaitingBar2.Properties.Orientation = System.Windows.Forms.Orientation.Vertical
			Me.nWaitingBar2.Properties.Position = 20
			Me.nWaitingBar2.Size = New System.Drawing.Size(24, 336)
			Me.nWaitingBar2.TabIndex = 1
			Me.nWaitingBar2.Text = "nWaitingBar2"
			' 
			' nWaitingBar3
			' 
			Me.nWaitingBar3.Border.BaseColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nWaitingBar3.Border.Style = Nevron.UI.BorderStyle3D.RaisedFrame
			Me.nWaitingBar3.Location = New System.Drawing.Point(112, 40)
			Me.nWaitingBar3.Name = "nWaitingBar3"
			Me.nWaitingBar3.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Lilac
			Me.nWaitingBar3.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nWaitingBar3.Properties.Position = 20
			Me.nWaitingBar3.Properties.Step = 2
			Me.nWaitingBar3.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
			Me.nWaitingBar3.Properties.WaitSize = 100
			Me.nWaitingBar3.Size = New System.Drawing.Size(336, 32)
			Me.nWaitingBar3.TabIndex = 2
			Me.nWaitingBar3.Text = "nWaitingBar3"
			' 
			' nWaitingBar4
			' 
			Me.nWaitingBar4.Location = New System.Drawing.Point(112, 80)
			Me.nWaitingBar4.Name = "nWaitingBar4"
			Me.nWaitingBar4.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nWaitingBar4.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nWaitingBar4.Properties.Position = 50
			Me.nWaitingBar4.Properties.Step = 2
			Me.nWaitingBar4.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
			Me.nWaitingBar4.Properties.WaitSize = 50
			Me.nWaitingBar4.Size = New System.Drawing.Size(336, 24)
			Me.nWaitingBar4.TabIndex = 3
			Me.nWaitingBar4.Text = "nWaitingBar4"
			' 
			' nWaitingBar5
			' 
			Me.nWaitingBar5.Location = New System.Drawing.Point(112, 112)
			Me.nWaitingBar5.Name = "nWaitingBar5"
			Me.nWaitingBar5.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nWaitingBar5.Properties.Position = 2
			Me.nWaitingBar5.Properties.Step = 2
			Me.nWaitingBar5.Properties.WaitSize = 60
			Me.nWaitingBar5.Size = New System.Drawing.Size(336, 24)
			Me.nWaitingBar5.TabIndex = 4
			Me.nWaitingBar5.Text = "nWaitingBar5"
			' 
			' nWaitingBar6
			' 
			Me.nWaitingBar6.Border.BaseColor = System.Drawing.Color.FromArgb((CByte(204)), (CByte(51)), (CByte(0)))
			Me.nWaitingBar6.Border.Style = Nevron.UI.BorderStyle3D.Bump
			Me.nWaitingBar6.Location = New System.Drawing.Point(40, 8)
			Me.nWaitingBar6.Name = "nWaitingBar6"
			Me.nWaitingBar6.Palette.Border = System.Drawing.Color.FromArgb((CByte(147)), (CByte(0)), (CByte(23)))
			Me.nWaitingBar6.Palette.Caption = System.Drawing.Color.FromArgb((CByte(245)), (CByte(0)), (CByte(38)))
			Me.nWaitingBar6.Palette.CaptionText = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nWaitingBar6.Palette.CheckedDark = System.Drawing.Color.FromArgb((CByte(153)), (CByte(77)), (CByte(0)))
			Me.nWaitingBar6.Palette.CheckedLight = System.Drawing.Color.FromArgb((CByte(255)), (CByte(179)), (CByte(102)))
			Me.nWaitingBar6.Palette.Control = System.Drawing.Color.FromArgb((CByte(255)), (CByte(128)), (CByte(0)))
			Me.nWaitingBar6.Palette.ControlBorder = System.Drawing.Color.FromArgb((CByte(147)), (CByte(0)), (CByte(23)))
			Me.nWaitingBar6.Palette.ControlDark = System.Drawing.Color.FromArgb((CByte(179)), (CByte(90)), (CByte(0)))
			Me.nWaitingBar6.Palette.ControlLight = System.Drawing.Color.FromArgb((CByte(255)), (CByte(223)), (CByte(191)))
			Me.nWaitingBar6.Palette.ControlText = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nWaitingBar6.Palette.Highlight = System.Drawing.Color.FromArgb((CByte(255)), (CByte(161)), (CByte(67)))
			Me.nWaitingBar6.Palette.HighlightDark = System.Drawing.Color.FromArgb((CByte(255)), (CByte(235)), (CByte(128)))
			Me.nWaitingBar6.Palette.HighlightLight = System.Drawing.Color.FromArgb((CByte(255)), (CByte(245)), (CByte(191)))
			Me.nWaitingBar6.Palette.HighlightText = System.Drawing.Color.FromArgb((CByte(8)), (CByte(8)), (CByte(8)))
			Me.nWaitingBar6.Palette.Menu = System.Drawing.Color.FromArgb((CByte(255)), (CByte(179)), (CByte(102)))
			Me.nWaitingBar6.Palette.MenuText = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nWaitingBar6.Palette.PressedDark = System.Drawing.Color.FromArgb((CByte(245)), (CByte(0)), (CByte(38)))
			Me.nWaitingBar6.Palette.PressedLight = System.Drawing.Color.FromArgb((CByte(255)), (CByte(102)), (CByte(126)))
			Me.nWaitingBar6.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Custom
			Me.nWaitingBar6.Palette.SelectedBorder = System.Drawing.Color.FromArgb((CByte(147)), (CByte(0)), (CByte(23)))
			Me.nWaitingBar6.Palette.Window = System.Drawing.Color.FromArgb((CByte(255)), (CByte(245)), (CByte(191)))
			Me.nWaitingBar6.Palette.WindowText = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nWaitingBar6.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nWaitingBar6.Properties.Orientation = System.Windows.Forms.Orientation.Vertical
			Me.nWaitingBar6.Properties.Position = 30
			Me.nWaitingBar6.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
			Me.nWaitingBar6.Properties.WaitSize = 200
			Me.nWaitingBar6.Size = New System.Drawing.Size(24, 336)
			Me.nWaitingBar6.TabIndex = 5
			Me.nWaitingBar6.Text = "nWaitingBar6"
			' 
			' nWaitingBar7
			' 
			Me.nWaitingBar7.Border.Style = Nevron.UI.BorderStyle3D.Sunken
			Me.nWaitingBar7.Location = New System.Drawing.Point(72, 8)
			Me.nWaitingBar7.Name = "nWaitingBar7"
			Me.nWaitingBar7.Palette.Border = System.Drawing.SystemColors.ControlDarkDark
			Me.nWaitingBar7.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark
			Me.nWaitingBar7.Palette.CaptionText = System.Drawing.Color.White
			Me.nWaitingBar7.Palette.CheckedDark = System.Drawing.Color.FromArgb((CByte(204)), (CByte(210)), (CByte(187)))
			Me.nWaitingBar7.Palette.CheckedLight = System.Drawing.Color.FromArgb((CByte(204)), (CByte(210)), (CByte(187)))
			Me.nWaitingBar7.Palette.Control = System.Drawing.SystemColors.Control
			Me.nWaitingBar7.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark
			Me.nWaitingBar7.Palette.ControlDark = System.Drawing.SystemColors.Control
			Me.nWaitingBar7.Palette.ControlLight = System.Drawing.SystemColors.Control
			Me.nWaitingBar7.Palette.ControlText = System.Drawing.SystemColors.ControlText
			Me.nWaitingBar7.Palette.Highlight = System.Drawing.SystemColors.Highlight
			Me.nWaitingBar7.Palette.HighlightDark = System.Drawing.Color.FromArgb((CByte(212)), (CByte(217)), (CByte(198)))
			Me.nWaitingBar7.Palette.HighlightLight = System.Drawing.Color.FromArgb((CByte(212)), (CByte(217)), (CByte(198)))
			Me.nWaitingBar7.Palette.HighlightText = System.Drawing.SystemColors.HighlightText
			Me.nWaitingBar7.Palette.Menu = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nWaitingBar7.Palette.MenuText = System.Drawing.SystemColors.MenuText
			Me.nWaitingBar7.Palette.PressedDark = System.Drawing.SystemColors.Highlight
			Me.nWaitingBar7.Palette.PressedLight = System.Drawing.Color.FromArgb((CByte(187)), (CByte(195)), (CByte(165)))
			Me.nWaitingBar7.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Custom
			Me.nWaitingBar7.Palette.SelectedBorder = System.Drawing.Color.FromArgb((CByte(50)), (CByte(55)), (CByte(36)))
			Me.nWaitingBar7.Palette.UseThemes = False
			Me.nWaitingBar7.Palette.Window = System.Drawing.SystemColors.Window
			Me.nWaitingBar7.Palette.WindowText = System.Drawing.SystemColors.WindowText
			Me.nWaitingBar7.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nWaitingBar7.Properties.Orientation = System.Windows.Forms.Orientation.Vertical
			Me.nWaitingBar7.Properties.Position = 50
			Me.nWaitingBar7.Properties.Step = 2
			Me.nWaitingBar7.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
			Me.nWaitingBar7.Properties.WaitSize = 50
			Me.nWaitingBar7.Size = New System.Drawing.Size(24, 336)
			Me.nWaitingBar7.TabIndex = 6
			Me.nWaitingBar7.Text = "nWaitingBar7"
			' 
			' NWaitingBarAppearanceUC
			' 
			Me.Controls.Add(Me.nWaitingBar7)
			Me.Controls.Add(Me.nWaitingBar6)
			Me.Controls.Add(Me.nWaitingBar5)
			Me.Controls.Add(Me.nWaitingBar4)
			Me.Controls.Add(Me.nWaitingBar3)
			Me.Controls.Add(Me.nWaitingBar2)
			Me.Controls.Add(Me.nWaitingBar1)
			Me.Name = "NWaitingBarAppearanceUC"
			Me.Size = New System.Drawing.Size(456, 352)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nWaitingBar1 As Nevron.UI.WinForm.Controls.NWaitingBar
		Private nWaitingBar2 As Nevron.UI.WinForm.Controls.NWaitingBar
		Private nWaitingBar3 As Nevron.UI.WinForm.Controls.NWaitingBar
		Private nWaitingBar4 As Nevron.UI.WinForm.Controls.NWaitingBar
		Private nWaitingBar6 As Nevron.UI.WinForm.Controls.NWaitingBar
		Private nWaitingBar7 As Nevron.UI.WinForm.Controls.NWaitingBar
		Private nWaitingBar5 As Nevron.UI.WinForm.Controls.NWaitingBar

		#End Region
	End Class
End Namespace
