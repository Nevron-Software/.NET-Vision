Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NCustomMenusUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
			m_iContextID = 1
			Dock = DockStyle.Fill

			Init()

			NUIManager.MenuOptions.DefaultMenuType = GetType(NCustomMenu)
			NUIManager.MenuOptions.HasShadow = False
		End Sub


		#End Region

		#Region "Implementation"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			NUIManager.MenuOptions.DefaultMenuType = GetType(NMenuWindow)
			NUIManager.MenuOptions.HasShadow = True

			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
				If Not m_Manager Is Nothing Then
					m_Manager.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		Friend Sub Init()
			InitManager()
			InitRanges()
			InitContexts()
			InitToolbars()
		End Sub
		Friend Sub InitManager()
			m_Manager = New NCommandBarsManager(Me)
			m_Manager.Palette.Copy(NUIManager.Palette)
			m_Manager.Contexts.UniqueIDOnly = False
		End Sub

		Friend Sub InitRanges()
			Dim r As NRange = New NRange()
			r.Name = "Standard"
			r.ID = 0
			m_Manager.Ranges.Add(r)
		End Sub


		#Region "Contexts"

		Friend Sub InitContexts()
			Dim img As Image = NResourceHelper.BitmapFromResource(Me.GetType(), "orang021.jpg", "Nevron.Examples.UI.WinForm.Resources.Backgrounds")
			InitBackgroundImageContext(img, Contexts.BackgroundImage1)
		End Sub

		Friend Sub InitBackgroundImageContext(ByVal img As Image, ByVal contextID As Contexts)
			Dim c1, c2 As NCommandContext
			Dim i As Integer

			'create first context
			c1 = CreateContext("Background Image", CInt(Fix(contextID)), MainForm.TestImages, -1, -1, Nothing, False)
			c1.Properties.DropDownBehavior = DropDownBehavior.AlwaysDropDown

			'create three examples for ImageDrawMode.Normal
			c2 = CreateContext("DrawMode Normal, No Column On Left", -1, MainForm.TestImages, -1, -1, Nothing, False)
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img
			c2.Properties.MenuOptions.ColumnOnLeft = False
			For i = 0 To 14
				c2.Contexts.Add(CreateContext("Long text test item " & (i+1), -1, MainForm.TestImages, i, -1, New NShortcut(Keys.A, Keys.Control Or Keys.Shift Or Keys.Alt), False))
			Next i

			c1.Contexts.Add(c2)

			c2 = CreateContext("DrawMode Normal, Column On Left", -1, MainForm.TestImages, -1, -1, Nothing, False)
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img
			For i = 0 To 10
				c2.Contexts.Add(CreateContext("Long text test item " & (i+1), -1, MainForm.TestImages, i, -1, New NShortcut(Keys.A, Keys.Control Or Keys.Shift Or Keys.Alt), False))
			Next i
			c1.Contexts.Add(c2)

			c2 = CreateContext("DrawMode Normal, Column On Left, Alpha 0.5", -1, MainForm.TestImages, -1, -1, Nothing, False)
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img
			c2.Properties.MenuOptions.BackgroundImageInfo.Alpha = 0.5f
			For i = 0 To 10
				c2.Contexts.Add(CreateContext("Long text test item " & (i+1), -1, MainForm.TestImages, i, -1, New NShortcut(Keys.A, Keys.Control Or Keys.Shift Or Keys.Alt), False))
			Next i
			c1.Contexts.Add(c2)


			'create three examples for ImageDrawMode.Stretch
			c2 = CreateContext("DrawMode Stretch, No Column On Left", -1, MainForm.TestImages, -1, -1, Nothing, True)
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Stretch
			c2.Properties.MenuOptions.ColumnOnLeft = False
			For i = 0 To 10
				c2.Contexts.Add(CreateContext("Long text test item " & (i+1), -1, MainForm.TestImages, i, -1, New NShortcut(Keys.A, Keys.Control Or Keys.Shift Or Keys.Alt), False))
			Next i
			c1.Contexts.Add(c2)

			c2 = CreateContext("DrawMode Stretch, Column On Left", -1, MainForm.TestImages, -1, -1, Nothing, False)
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Stretch
			For i = 0 To 10
				c2.Contexts.Add(CreateContext("Long text test item " & (i+1), -1, MainForm.TestImages, i, -1, New NShortcut(Keys.A, Keys.Control Or Keys.Shift Or Keys.Alt), False))
			Next i
			c1.Contexts.Add(c2)

			c2 = CreateContext("DrawMode Stretch, Column On Left, Alpha 0.3", -1, MainForm.TestImages, -1, -1, Nothing, False)
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Stretch
			c2.Properties.MenuOptions.BackgroundImageInfo.Alpha = 0.3f
			For i = 0 To 10
				c2.Contexts.Add(CreateContext("Long text test item " & (i+1), -1, MainForm.TestImages, i, -1, New NShortcut(Keys.A, Keys.Control Or Keys.Shift Or Keys.Alt), False))
			Next i
			c1.Contexts.Add(c2)

			'create three examples for ImageDrawMode.Tile
			c2 = CreateContext("DrawMode Tile, No Column On Left", -1, MainForm.TestImages, -1, -1, Nothing, True)
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Tile
			c2.Properties.MenuOptions.ColumnOnLeft = False
			For i = 0 To 10
				c2.Contexts.Add(CreateContext("Long text test item " & (i+1), -1, MainForm.TestImages, i, -1, New NShortcut(Keys.A, Keys.Control Or Keys.Shift Or Keys.Alt), False))
			Next i
			c1.Contexts.Add(c2)

			c2 = CreateContext("DrawMode Tile, Column On Left", -1, MainForm.TestImages, -1, -1, Nothing, False)
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Tile
			For i = 0 To 10
				c2.Contexts.Add(CreateContext("Long text test item " & (i+1), -1, MainForm.TestImages, i, -1, New NShortcut(Keys.A, Keys.Control Or Keys.Shift Or Keys.Alt), False))
			Next i
			c1.Contexts.Add(c2)

			c2 = CreateContext("DrawMode Tile, Column On Left, Alpha 0.4", -1, MainForm.TestImages, -1, -1, Nothing, False)
			c2.Properties.MenuOptions.BackgroundImageInfo.Image = img
			c2.Properties.MenuOptions.BackgroundImageInfo.DrawMode = ImageDrawMode.Tile
			c2.Properties.MenuOptions.BackgroundImageInfo.Alpha = 0.4f
			For i = 0 To 10
				c2.Contexts.Add(CreateContext("Long text test item " & (i+1), -1, MainForm.TestImages, i, -1, New NShortcut(Keys.A, Keys.Control Or Keys.Shift Or Keys.Alt), False))
			Next i
			c1.Contexts.Add(c2)

			c2 = CreateContext("&Load Image", CInt(Fix(Contexts.LoadImage)), Nothing, -1, -1, Nothing, True)
			AddHandler c2.Executed, AddressOf OnLoadImage
			c1.Contexts.Add(c2)
		End Sub

		Friend Function CreateContext(ByVal text As String, ByVal id As Integer, ByVal images As ImageList, ByVal imageIndex As Integer, ByVal rangeID As Integer, ByVal sc As NShortcut, ByVal beginGroup As Boolean) As NCommandContext
			Dim c As NCommandContext = New NCommandContext()
			c.RangeID = rangeID
			If id <> -1 Then
				c.Properties.ID = id
				m_iContextID = id + 1
			Else
				c.Properties.ID = m_iContextID
			End If
			c.Properties.ImageList = images
			c.Properties.ImageIndex = imageIndex
			c.Properties.BeginGroup = beginGroup

			c.Properties.Text = text
			If Not sc Is Nothing Then
				c.Properties.Shortcut = sc
			End If

			m_Manager.Contexts.Add(c)
			m_iContextID += 1

			Return c
		End Function


		#End Region

		#Region "Toolbars"

		Friend Sub InitToolbars()
			InitStandandardToolbar()
		End Sub

		Friend Sub InitStandandardToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.DefaultRangeID = 0
			tb.AllowReset = False
			tb.Text = "Standard"
			tb.DefaultCommandStyle = CommandStyle.Text

			tb.Commands.Add(Nevron.UI.WinForm.Controls.NCommand.FromContext(m_Manager.Contexts.ContextFromID(CInt(Fix(Contexts.BackgroundImage1)))))

			Dim comm, comm1, comm2, comm3 As Nevron.UI.WinForm.Controls.NCommand

			comm = New Nevron.UI.WinForm.Controls.NCommand()
			'specify the custom menu type
			comm.Properties.Text = "Custom Region Menu"
			comm.Properties.DropDownBehavior = DropDownBehavior.AlwaysDropDown
			tb.Commands.Add(comm)

			For i As Integer = 0 To 9
				comm1 = New Nevron.UI.WinForm.Controls.NCommand()
				comm1.Properties.Text = "Nested Command " & i.ToString()
				comm.Commands.Add(comm1)

				For j As Integer = 0 To 9
					comm2 = New Nevron.UI.WinForm.Controls.NCommand()
					comm2.Properties.Text = "Nested Command " & j.ToString()
					comm1.Commands.Add(comm2)

					For k As Integer = 0 To 9
						comm3 = New Nevron.UI.WinForm.Controls.NCommand()
						comm3.Properties.Text = "Nested Command " & k.ToString()
						comm2.Commands.Add(comm3)
					Next k
				Next j
			Next i

			m_Manager.Toolbars.Add(tb)
		End Sub


		#End Region

		Friend Sub SetImage(ByVal img As Image)
			Dim c As NCommandContext = m_Manager.Contexts.ContextFromID(CInt(Fix(Contexts.BackgroundImage1)))
			For Each c1 As NCommandContext In c.Contexts
				Dim commands As Nevron.UI.WinForm.Controls.NCommand() = c1.GetCommands()
				For Each comm As Nevron.UI.WinForm.Controls.NCommand In commands
					comm.Properties.MenuOptions.BackgroundImageInfo.Image = img
				Next comm

			Next c1
		End Sub

		Friend Function GetInitalDirectory() As String
			Dim path As String = Application.StartupPath
			Dim index As Integer
			Dim count As Integer

			Dim dirSeparator As String = New String(System.IO.Path.DirectorySeparatorChar, 1)

			index = path.LastIndexOf(dirSeparator)
			count = path.Length - index

			path = path.Remove(index, count)

			index = path.LastIndexOf(dirSeparator)
			count = path.Length - index
			path = path.Remove(index, count)

			Return path & "\Resources\Backgrounds"
		End Function


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			' 
			' NCustomMenusUC
			' 
			Me.Name = "NCustomMenusUC"

		End Sub
		#End Region

		#Region "Event Handlers"

		Private Sub OnLoadImage(ByVal sender As Object, ByVal e As CommandContextEventArgs)
			Dim ofd As OpenFileDialog = New OpenFileDialog()
			ofd.Title = "Select Image:"
			ofd.Filter = NUIManager.AllImageFilesFilter
			ofd.RestoreDirectory = True

			ofd.InitialDirectory = "..\..\Resources\Backgrounds"
			ofd.Multiselect = False

			If ofd.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If

			Dim img As Image = Image.FromFile(ofd.FileName)
			SetImage(img)
		End Sub


		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Friend m_Manager As NCommandBarsManager
		Friend m_iContextID As Integer

		#End Region
	End Class

	''' <summary>
	''' Summary description for NCustomMenu.
	''' </summary>
	Public Class NCustomMenu
		Inherits NMenuWindow
		#Region "Constructor"

		Public Sub New()
		End Sub


		#End Region

		#Region "Implementation"

		Protected Overrides Sub ShowWindow(ByVal animate As Boolean)
			'apply new region first
			UpdateRegion()
			'do not allow shadow
			MenuOptions.Shadow = False

			MyBase.ShowWindow(animate)
		End Sub

		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			MyBase.OnPaint(e)

			Dim client As Rectangle = ClientRectangle
			client.Inflate(-1, -1)
			client.Width -= 1
			client.Height -= 1

			Dim path As GraphicsPath = GetRoundedRectanglePath(client, 16)
			Dim p As Pen = Renderer.Pen
			p.Width = 4
			p.Color = Palette.Border

			Dim g As Graphics = e.Graphics

			g.SmoothingMode = SmoothingMode.AntiAlias
			g.DrawPath(p, path)

			path.Dispose()

			p.Width = 1
		End Sub


		Private Sub UpdateRegion()
			Dim client As Rectangle = ClientRectangle
			Dim path As GraphicsPath = GetRoundedRectanglePath(client, 16)

			Region = New Region(path)
			path.Dispose()
		End Sub

		Friend Shared Function GetRoundedRectanglePath(ByVal client As Rectangle, ByVal arcWidth As Integer) As GraphicsPath
			Dim path As GraphicsPath = New GraphicsPath()

			Dim left As Integer = client.Left
			Dim right As Integer = client.Right
			Dim top As Integer = client.Top
			Dim bottom As Integer = client.Bottom

			Dim width As Integer = client.Width
			Dim height As Integer = client.Height

			Dim arcRectWidth As Integer = 2 * arcWidth

			Dim arc As Rectangle

			'topleft arc
			arc = New Rectangle(left, top, arcRectWidth, arcRectWidth)
			path.AddArc(arc, 180, 90)

			'top line
			path.AddLine(left + arcWidth, top, right - arcWidth, top)

			'topright arc
			arc = New Rectangle(right - arcRectWidth - 1, top, arcRectWidth + 1, arcRectWidth + 1)
			path.AddArc(arc, -90, 90)

			'right line
			path.AddLine(right, top + arcWidth, right, bottom - arcWidth)

			'bottomright arc
			arc = New Rectangle(right - arcRectWidth - 1, bottom - arcRectWidth - 1, arcRectWidth + 1, arcRectWidth + 1)
			path.AddArc(arc, 0, 90)

			'bottom line
			path.AddLine(right - arcWidth, bottom, left + arcWidth, bottom)

			'bottomleft arc
			arc = New Rectangle(left, bottom - arcRectWidth, arcRectWidth, arcRectWidth)
			path.AddArc(arc, 90, 90)

			'left line
			path.AddLine(left, bottom - arcWidth, left, top + arcWidth)

			path.CloseAllFigures()

			Return path
		End Function


		#End Region
	End Class
End Namespace
