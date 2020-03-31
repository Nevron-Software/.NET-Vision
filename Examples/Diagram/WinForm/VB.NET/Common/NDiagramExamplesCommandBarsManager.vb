Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Resources

Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	Public Class NDiagramExamplesCommandBarsManager
		Inherits NCommandBarsManager
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			Me.form = form
			AllowCustomize = False

			CreateColorSchemeContext()
			CreateMenuBar()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub CreateColorSchemeContext()
			'create the parent context for all color schemes
			Dim parent As NCommandContext = NCommandContext.CreateContext("Color &Scheme", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme)), Nothing, -1, -1, Nothing, False)
			Contexts.Add(parent)

			'create a context for each color scheme
			Dim scheme As NCommandContext

			scheme = NCommandContext.CreateContext("&Automatic", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_Automatic)), Nothing, -1, -1, Nothing, False)
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("&Standard", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_Standard)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.Standard
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("&Widows Default", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_WindowsDefault)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.WindowsDefault
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("Luna &Blue", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_LunaBlue)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.LunaBlue
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("Luna &Olive", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_LunaOlive)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.LunaOlive
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("Luna Sil&ver", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_LunaSilver)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.LunaSilver
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("&Longhorn", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_Longhorn)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.Longhorn
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("&Energy", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_Energy)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.Energy
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("Lila&c", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_Lilac)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.Lilac
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("Bl&ue", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_Blue)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.Blue
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("&Gold", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_Gold)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.Gold
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)

			scheme = NCommandContext.CreateContext("Custo&m", CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme_Custom)), Nothing, -1, -1, Nothing, False)
			scheme.Properties.Tag = ColorScheme.Custom
			parent.Contexts.Add(scheme)
			Contexts.Add(scheme)
		End Sub

		Private Sub CreateMenuBar()
			Dim menu As NMenuBar = New NMenuBar()
			menu.Text = "Examples Main Menu"
			'forbide toolbar permisiions
			menu.AllowReset = False
			menu.AllowRename = False
			menu.AllowHide = False

			Dim comm, comm1 As NCommand

			'create the "File" command
			comm = New NCommand()
			comm.Properties.Text = "&File"
			menu.Commands.Add(comm)

			'create the "Exit" command
			comm1 = New NCommand()
			comm1.Properties.ID = CInt(Fix(NDiagramExamplesCommandIDs.Exit))
			comm1.Properties.Text = "E&xit"
			comm.Commands.Add(comm1)

			'create the "View" command
			comm = New NCommand()
			comm.Properties.Text = "&View"
			'add the "View Navigation" command
			comm1 = New NCommand()
			comm1.Properties.Text = "Navigation Tree"
			comm1.Properties.ID = CInt(Fix(NDiagramExamplesCommandIDs.View_NavigationTree))
			comm.Commands.Add(comm1)
			'add the "View Example TabControl" command
			comm1 = New NCommand()
			comm1.Properties.Text = "Example TabControl"
			comm1.Properties.ID = CInt(Fix(NDiagramExamplesCommandIDs.View_ExampleTabControl))
			comm.Commands.Add(comm1)
			'add the "View Example CommandBars" command
			comm1 = New NCommand()
			comm1.Properties.Text = "Example Command Bars"
			comm1.Properties.ID = CInt(Fix(NDiagramExamplesCommandIDs.View_ExampleCommandBars))
			comm.Commands.Add(comm1)
			menu.Commands.Add(comm)


			'create the "Palette" command
			comm = New NCommand()
			comm.Properties.Text = "&Palette"
			'add the color scheme context
			comm.Commands.Add(NCommand.FromContext(Contexts.ContextFromID(CInt(Fix(NDiagramExamplesCommandIDs.ColorScheme)))))
			'add the style3d context
			comm.Commands.Add(NCommand.FromContext(Contexts.ContextFromID(CInt(Fix(NDiagramExamplesCommandIDs.Style3D)))))
			'add the "Edit Palette" command
			comm1 = New NCommand()
			comm1.Properties.BeginGroup = True
			comm1.Properties.Text = "&Edit"
			comm1.Properties.ID = CInt(Fix(NDiagramExamplesCommandIDs.Palette_Edit))
			comm.Commands.Add(comm1)
			menu.Commands.Add(comm)

			'create the "File" command
			comm = New NCommand()
			comm.Properties.Text = "&Help"
			comm1 = New NCommand()
			comm1.Properties.Text = "&About..."
			comm.Commands.Add(comm1)
			menu.Commands.Add(comm)

			'add the menu to the toolbars collection
			MyBase.Toolbars.Add(menu)
		End Sub


		#End Region

		#Region "Fields"

		Public form As NMainForm = Nothing

		#End Region
	End Class
End Namespace
