Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Serialization
Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NDockingPanelPersistency.
	''' </summary>
	Public Class NDockingPanelsPersistencyUC
		Inherits NDockingPanelsBasicFeaturesUC
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
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
			MyBase.Initialize ()

			m_ExampleFormType = GetType(NPersistencyForm)
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

	''' <summary>
	''' Summary description for NPersistencyForm.
	''' </summary>
	Public Class NPersistencyForm
		Inherits NDockingPanelsExampleForm
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
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

		Protected Overrides Sub InitPanels()
			Dim root As INDockZone = m_DockManager.RootContainer.RootZone
			Dim target As INDockZone
			Dim panel As NDockingPanel

			panel = GetGenericPanel()
			panel.PerformDock(root, DockStyle.Left)

			target = panel.ParentZone
			panel = GetGenericPanel()
			panel.PerformDock(target, DockStyle.Bottom)

			target = m_DockManager.DocumentManager.DocumentViewHost
			panel = GetGenericPanel()
			panel.PerformDock(target, DockStyle.Bottom)

			panel = New NDockingPanel()
			panel.Controls.Add(m_PropertyGrid)
			m_PropertyGrid.SelectedObject = m_DockManager
			panel.PerformDock(root, DockStyle.Right)

			'add some documents to the doc view

			For i As Integer = 0 To 4
				Dim doc As NUIDocument = New NUIDocument()
				doc.Client = GetTextBox()
				m_DockManager.DocumentManager.AddDocument(doc)
			Next i
		End Sub

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)
		End Sub


		Protected Overrides Sub InitCommandBars()
			MyBase.InitCommandBars ()

			Dim comm, comm1, comm2 As NCommand
			Dim bar As NMenuBar = nCommandBarsManager1.Toolbars.GetMenu()

			comm = New NCommand()
			comm.Properties.Text = "Per&sistency"
			bar.Commands.Insert(0, comm)

			comm1 = New NCommand()
			comm1.Properties.Text = "&Save..."
			comm1.Properties.ID = 0
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.Text = "&Load..."
			comm1.Properties.ID = 1
			comm.Commands.Add(comm1)

			comm1 = New NCommand()
			comm1.Properties.BeginGroup = True
			comm1.Properties.Text = "Format"
			comm.Commands.Add(comm1)

			For Each format As PersistencyFormat In System.Enum.GetValues(GetType(PersistencyFormat))
				comm2 = New NCommand()
				comm2.Properties.Tag = format
				comm2.Properties.ID = 2
				comm2.Properties.Text = format.ToString()
				comm1.Commands.Add(comm2)
			Next format
		End Sub

		Protected Overrides Sub nCommandBarsManager1_CommandClicked(ByVal sender As Object, ByVal e As CommandEventArgs)
			Dim comm As NCommand = e.Command
			Dim id As Integer = comm.Properties.ID

			Dim state As NDockingFrameworkState = New NDockingFrameworkState(m_DockManager)

			AddHandler state.ResolveDocumentClient, AddressOf state_ResolveDocumentClient
			state.Format = m_Format

			Select Case id
				Case 0
					state.Save()
				Case 1
					state.Load()
				Case 2
					m_Format = CType(comm.Properties.Tag, PersistencyFormat)
			End Select

			RemoveHandler state.ResolveDocumentClient, AddressOf state_ResolveDocumentClient
		End Sub

		Protected Overrides Sub nCommandBarsManager1_QueryCommandUIState(ByVal sender As Object, ByVal e As QueryCommandUIStateEventArgs)
			Dim comm As NCommand = e.UIState.Command
			If Not(TypeOf comm.Properties.Tag Is PersistencyFormat) Then
				Return
			End If

			Dim pf As PersistencyFormat = CType(comm.Properties.Tag, PersistencyFormat)
			e.UIState.Checked = m_Format = pf
			e.UIState.Handled = True
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub state_ResolveDocumentClient(ByVal sender As Object, ByVal e As DocumentEventArgs)
			e.Document.Client = GetTextBox()
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.Size = New System.Drawing.Size(600,600)
			Me.Text = "Docking Panel Persistency Example"
		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Friend m_Format As PersistencyFormat

		#End Region
	End Class
End Namespace
