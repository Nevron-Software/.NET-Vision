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
	''' Summary description for NProgressBarAppearanceUC.
	''' </summary>
	Public Class NProgressBarAppearanceUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			m_Timer = New Timer()
			m_Timer.Interval = 40
			AddHandler m_Timer.Tick, AddressOf OnTimer_Tick
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				m_Timer.Stop()
				m_Timer.Dispose()
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_Timer.Start()
		End Sub



		#End Region

		#Region "Event Handlers"

		Private Sub OnTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
			Dim bar As NProgressBar
			Dim count As Integer = Controls.Count
			Dim value As Integer

			Dim i As Integer = 0
			Do While i < count
				bar = TryCast(Controls(i), NProgressBar)
				If bar Is Nothing Then
					Continue Do
				End If

				value = bar.Properties.Value
				If value > 99 Then
					value = 0
				End If
				value += 1
				bar.Properties.Value = value
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
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NProgressBarAppearanceUC))
			Me.nProgressBar1 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.nProgressBar2 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.nProgressBar3 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.nProgressBar4 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.nProgressBar5 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.nProgressBar6 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.nProgressBar7 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.nProgressBar8 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.SuspendLayout()
			' 
			' nProgressBar1
			' 
			Me.nProgressBar1.Location = New System.Drawing.Point(96, 8)
			Me.nProgressBar1.Name = "nProgressBar1"
			Me.nProgressBar1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nProgressBar1.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nProgressBar1.Properties.Text = ""
			Me.nProgressBar1.Properties.Value = 30
			Me.nProgressBar1.Size = New System.Drawing.Size(304, 24)
			Me.nProgressBar1.TabIndex = 4
			Me.nProgressBar1.Text = "nProgressBar1"
			' 
			' nProgressBar2
			' 
			Me.nProgressBar2.Border.Style = Nevron.UI.BorderStyle3D.Raised
			Me.nProgressBar2.Location = New System.Drawing.Point(96, 72)
			Me.nProgressBar2.Name = "nProgressBar2"
			Me.nProgressBar2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Energy
			Me.nProgressBar2.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nProgressBar2.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
			Me.nProgressBar2.Properties.Text = ""
			Me.nProgressBar2.Properties.Value = 50
			Me.nProgressBar2.Size = New System.Drawing.Size(304, 24)
			Me.nProgressBar2.TabIndex = 5
			Me.nProgressBar2.Text = "nProgressBar2"
			' 
			' nProgressBar3
			' 
			Me.nProgressBar3.Border.Style = Nevron.UI.BorderStyle3D.Sunken
			Me.nProgressBar3.Location = New System.Drawing.Point(96, 40)
			Me.nProgressBar3.Name = "nProgressBar3"
			Me.nProgressBar3.Palette.Border = System.Drawing.SystemColors.ControlDarkDark
			Me.nProgressBar3.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark
			Me.nProgressBar3.Palette.CaptionText = System.Drawing.Color.White
			Me.nProgressBar3.Palette.CheckedDark = System.Drawing.Color.FromArgb((CByte(204)), (CByte(210)), (CByte(187)))
			Me.nProgressBar3.Palette.CheckedLight = System.Drawing.Color.FromArgb((CByte(204)), (CByte(210)), (CByte(187)))
			Me.nProgressBar3.Palette.Control = System.Drawing.SystemColors.Control
			Me.nProgressBar3.Palette.ControlBorder = System.Drawing.SystemColors.ControlDarkDark
			Me.nProgressBar3.Palette.ControlDark = System.Drawing.SystemColors.Control
			Me.nProgressBar3.Palette.ControlLight = System.Drawing.Color.FromArgb((CByte(246)), (CByte(244)), (CByte(236)))
			Me.nProgressBar3.Palette.ControlText = System.Drawing.SystemColors.ControlText
			Me.nProgressBar3.Palette.Highlight = System.Drawing.SystemColors.Highlight
			Me.nProgressBar3.Palette.HighlightDark = System.Drawing.Color.FromArgb((CByte(212)), (CByte(217)), (CByte(198)))
			Me.nProgressBar3.Palette.HighlightLight = System.Drawing.Color.FromArgb((CByte(212)), (CByte(217)), (CByte(198)))
			Me.nProgressBar3.Palette.HighlightText = System.Drawing.SystemColors.HighlightText
			Me.nProgressBar3.Palette.Menu = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nProgressBar3.Palette.MenuText = System.Drawing.SystemColors.MenuText
			Me.nProgressBar3.Palette.PressedDark = System.Drawing.SystemColors.Highlight
			Me.nProgressBar3.Palette.PressedLight = System.Drawing.Color.FromArgb((CByte(187)), (CByte(195)), (CByte(165)))
			Me.nProgressBar3.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Custom
			Me.nProgressBar3.Palette.SelectedBorder = System.Drawing.Color.FromArgb((CByte(50)), (CByte(55)), (CByte(36)))
			Me.nProgressBar3.Palette.UseThemes = False
			Me.nProgressBar3.Palette.Window = System.Drawing.SystemColors.Window
			Me.nProgressBar3.Palette.WindowText = System.Drawing.SystemColors.WindowText
			Me.nProgressBar3.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nProgressBar3.Properties.Segments = True
			Me.nProgressBar3.Properties.ShowText = True
			Me.nProgressBar3.Properties.Text = "Custom Text"
			Me.nProgressBar3.Properties.Value = 70
			Me.nProgressBar3.Size = New System.Drawing.Size(304, 24)
			Me.nProgressBar3.TabIndex = 6
			Me.nProgressBar3.Text = "nProgressBar3"
			' 
			' nProgressBar4
			' 
			Me.nProgressBar4.Border.Style = Nevron.UI.BorderStyle3D.Sunken
			Me.nProgressBar4.Location = New System.Drawing.Point(96, 104)
			Me.nProgressBar4.Name = "nProgressBar4"
			Me.nProgressBar4.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaSilver
			Me.nProgressBar4.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nProgressBar4.Properties.ShowText = True
			Me.nProgressBar4.Properties.Text = ""
			Me.nProgressBar4.Properties.Value = 65
			Me.nProgressBar4.Size = New System.Drawing.Size(304, 24)
			Me.nProgressBar4.TabIndex = 7
			Me.nProgressBar4.Text = "nProgressBar4"
			' 
			' nProgressBar5
			' 
			Me.nProgressBar5.Border.Style = Nevron.UI.BorderStyle3D.RaisedFrame
			Me.nProgressBar5.Location = New System.Drawing.Point(8, 8)
			Me.nProgressBar5.Name = "nProgressBar5"
			Me.nProgressBar5.Palette.Border = System.Drawing.Color.Black
			Me.nProgressBar5.Palette.Caption = System.Drawing.Color.FromArgb((CByte(8)), (CByte(8)), (CByte(8)))
			Me.nProgressBar5.Palette.CaptionText = System.Drawing.Color.White
			Me.nProgressBar5.Palette.CheckedDark = System.Drawing.Color.FromArgb((CByte(80)), (CByte(80)), (CByte(80)))
			Me.nProgressBar5.Palette.CheckedLight = System.Drawing.Color.FromArgb((CByte(60)), (CByte(60)), (CByte(60)))
			Me.nProgressBar5.Palette.Control = System.Drawing.Color.FromArgb((CByte(90)), (CByte(90)), (CByte(90)))
			Me.nProgressBar5.Palette.ControlBorder = System.Drawing.Color.Black
			Me.nProgressBar5.Palette.ControlDark = System.Drawing.Color.FromArgb((CByte(26)), (CByte(26)), (CByte(26)))
			Me.nProgressBar5.Palette.ControlLight = System.Drawing.Color.FromArgb((CByte(110)), (CByte(110)), (CByte(110)))
			Me.nProgressBar5.Palette.ControlText = System.Drawing.Color.White
			Me.nProgressBar5.Palette.Highlight = System.Drawing.Color.FromArgb((CByte(80)), (CByte(80)), (CByte(80)))
			Me.nProgressBar5.Palette.HighlightDark = System.Drawing.Color.FromArgb((CByte(60)), (CByte(60)), (CByte(60)))
			Me.nProgressBar5.Palette.HighlightLight = System.Drawing.Color.FromArgb((CByte(80)), (CByte(80)), (CByte(80)))
			Me.nProgressBar5.Palette.HighlightText = System.Drawing.Color.FromArgb((CByte(255)), (CByte(223)), (CByte(127)))
			Me.nProgressBar5.Palette.Menu = System.Drawing.Color.FromArgb((CByte(91)), (CByte(91)), (CByte(91)))
			Me.nProgressBar5.Palette.MenuText = System.Drawing.Color.White
			Me.nProgressBar5.Palette.PressedDark = System.Drawing.Color.FromArgb((CByte(255)), (CByte(102)), (CByte(0)))
			Me.nProgressBar5.Palette.PressedLight = System.Drawing.Color.FromArgb((CByte(123)), (CByte(123)), (CByte(123)))
			Me.nProgressBar5.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Custom
			Me.nProgressBar5.Palette.SelectedBorder = System.Drawing.Color.FromArgb((CByte(255)), (CByte(223)), (CByte(127)))
			Me.nProgressBar5.Palette.Window = System.Drawing.Color.FromArgb((CByte(131)), (CByte(131)), (CByte(131)))
			Me.nProgressBar5.Palette.WindowText = System.Drawing.Color.White
			Me.nProgressBar5.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nProgressBar5.Properties.Orientation = System.Windows.Forms.Orientation.Vertical
			Me.nProgressBar5.Properties.ShowText = True
			Me.nProgressBar5.Properties.Text = ""
			Me.nProgressBar5.Properties.Value = 20
			Me.nProgressBar5.Size = New System.Drawing.Size(32, 304)
			Me.nProgressBar5.TabIndex = 8
			Me.nProgressBar5.Text = "nProgressBar5"
			' 
			' nProgressBar6
			' 
			Me.nProgressBar6.Border.Style = Nevron.UI.BorderStyle3D.Bump
			Me.nProgressBar6.Location = New System.Drawing.Point(96, 136)
			Me.nProgressBar6.Name = "nProgressBar6"
			Me.nProgressBar6.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaSilver
			Me.nProgressBar6.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nProgressBar6.Properties.ShowText = True
			Me.nProgressBar6.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
			Me.nProgressBar6.Properties.Text = ""
			Me.nProgressBar6.Properties.Value = 70
			Me.nProgressBar6.Size = New System.Drawing.Size(304, 24)
			Me.nProgressBar6.TabIndex = 9
			Me.nProgressBar6.Text = "nProgressBar6"
			' 
			' nProgressBar7
			' 
			Me.nProgressBar7.Location = New System.Drawing.Point(48, 8)
			Me.nProgressBar7.Name = "nProgressBar7"
			Me.nProgressBar7.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault
			Me.nProgressBar7.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nProgressBar7.Properties.Orientation = System.Windows.Forms.Orientation.Vertical
			Me.nProgressBar7.Properties.ShowText = True
			Me.nProgressBar7.Properties.Text = "Installing... Please, wait!"
			Me.nProgressBar7.Properties.Value = 30
			Me.nProgressBar7.Size = New System.Drawing.Size(32, 304)
			Me.nProgressBar7.TabIndex = 10
			Me.nProgressBar7.Text = "nProgressBar7"
			' 
			' nProgressBar8
			' 
			Me.nProgressBar8.Location = New System.Drawing.Point(96, 168)
			Me.nProgressBar8.Name = "nProgressBar8"
			Me.nProgressBar8.Properties.ShowText = True
			Me.nProgressBar8.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
			Me.nProgressBar8.Properties.Text = ""
			Me.nProgressBar8.Properties.Value = 80
			Me.nProgressBar8.Size = New System.Drawing.Size(304, 24)
			Me.nProgressBar8.TabIndex = 11
			Me.nProgressBar8.Text = "nProgressBar8"
			' 
			' NProgressBarAppearanceUC
			' 
			Me.Controls.Add(Me.nProgressBar8)
			Me.Controls.Add(Me.nProgressBar7)
			Me.Controls.Add(Me.nProgressBar6)
			Me.Controls.Add(Me.nProgressBar5)
			Me.Controls.Add(Me.nProgressBar4)
			Me.Controls.Add(Me.nProgressBar3)
			Me.Controls.Add(Me.nProgressBar2)
			Me.Controls.Add(Me.nProgressBar1)
			Me.Name = "NProgressBarAppearanceUC"
			Me.Size = New System.Drawing.Size(480, 344)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nProgressBar1 As Nevron.UI.WinForm.Controls.NProgressBar
		Private nProgressBar3 As Nevron.UI.WinForm.Controls.NProgressBar
		Private nProgressBar4 As Nevron.UI.WinForm.Controls.NProgressBar
		Private nProgressBar5 As Nevron.UI.WinForm.Controls.NProgressBar
		Private nProgressBar6 As Nevron.UI.WinForm.Controls.NProgressBar
		Private nProgressBar7 As Nevron.UI.WinForm.Controls.NProgressBar
		Private nProgressBar2 As Nevron.UI.WinForm.Controls.NProgressBar
		Private nProgressBar8 As Nevron.UI.WinForm.Controls.NProgressBar

		Friend m_Timer As Timer

		#End Region
	End Class
End Namespace
