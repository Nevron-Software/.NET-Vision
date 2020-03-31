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
	Public Class NCommandBarsPersistencyUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
			Init()

			m_State = New NCommandBarsState()
			m_State.Manager = m_Manager
			m_State.PersistencyFlags = NCommandBarsStateFlags.All
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
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


		#End Region

		#Region "Implementation"

		Friend Sub Init()
			InitManager()
			InitToolbars()
		End Sub
		Friend Sub InitManager()
			m_Manager = New NCommandBarsManager(Me)
			m_Manager.Palette.Copy(NUIManager.Palette)
			m_Manager.ImageLists.Add(MainForm.StandardImages)
			AddHandler m_Manager.CommandClicked, AddressOf OnCommandClicked
		End Sub


		#Region "Toolbars"

		Friend Sub InitToolbars()
			InitStandandardToolbar()
		End Sub

		Friend Sub InitStandandardToolbar()
			Dim tb As NDockingToolbar = New NDockingToolbar()
			tb.Text = "Standard"
			tb.ImageList = MainForm.StandardImages

			Dim comm, comm1 As NCommand

			comm = New NCommand()
			comm.Properties.Text = "File"
			comm.Properties.Style = CommandStyle.Text
			comm.Properties.MenuOptions.ImageSize = New Size(32, 32)
			tb.Commands.Add(comm)

			comm1 = New NCommand()
			comm1.Properties.Style = CommandStyle.ImageAndText
			comm1.Properties.Text = "Load State"
			comm1.Properties.ImageIndex = 1
			comm1.Properties.ID = CInt(Fix(Contexts.Open))
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.Style = CommandStyle.ImageAndText
			comm1.Properties.Text = "Save State"
			comm1.Properties.ImageIndex = 2
			comm1.Properties.ID = CInt(Fix(Contexts.Save))
			comm.Commands.Add(comm1)

			m_Manager.Toolbars.Add(tb)
		End Sub


		#End Region


		#End Region

		#Region "Event Handlers"

		Private Sub OnCommandClicked(ByVal sender As Object, ByVal e As CommandEventArgs)
			Select Case e.Command.Properties.ID
				Case CInt(Fix(Contexts.Open))
					m_State.Load()
				Case CInt(Fix(Contexts.Save))
					m_State.Save()
			End Select
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
		Friend m_Manager As NCommandBarsManager
		Friend m_State As NCommandBarsState

		#End Region
	End Class
End Namespace
