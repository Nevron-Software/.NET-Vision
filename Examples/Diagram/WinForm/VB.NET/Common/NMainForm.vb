Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands

Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' The NMainForm class represents the main form of the diagram examples browser
	''' </summary>
	Public Class NMainForm
		Inherits NExamplesForm
		#Region "Constructors"

		''' <summary>
		''' Default constructor
		''' </summary>
		Public Sub New()
			InitializeComponent()
			InitFromConfig(New NDiagramExamplesConfig())
			InitializeDiagramExamplesComponents()
		End Sub

		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' NMainForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(292, 266)
			Me.Name = "NMainForm"
			Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Main Entry Point"
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Dim MainForm As NMainForm = New NMainForm()
			Application.Run(MainForm)
		End Sub
		#End Region

		#Region "Component Overrides"
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

		#End Region

		#Region "Designer Fields"

		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		#End Region

		#Region "Overrides"

		Protected Overrides Function CreateDockManager() As NExamplesDockManager
			Return New NDiagramExamplesDockManager()
		End Function
		Protected Overrides Sub LayoutExample()
			MyBase.LayoutExample()

			Dim diagramDockManager As NDiagramExamplesDockManager = TryCast(DockManager, NDiagramExamplesDockManager)
			Dim diagramLayoutStrategy As NDiagramExamplesLayoutStrategy = TryCast(Config.LayoutStrategy, NDiagramExamplesLayoutStrategy)

			If CurrentExampleEntity Is Nothing Then
				Return
			End If

			If CurrentExampleEntity.LayoutType = currentLayoutType Then
				Return
			End If

			currentLayoutType = CurrentExampleEntity.LayoutType

			Dim zone As INDockZone = diagramDockManager.m_ExamplePanel.ParentZone
			If zone Is Nothing Then
				Return
			End If

			If CurrentExampleEntity.LayoutType = "Wide" Then
				diagramLayoutStrategy.WideScreenExampleZone.AddChild(zone)
				CType(CurrentExampleControl, NDiagramExampleUC).commonControlsPanel.Width = 260
				CType(CurrentExampleControl, NDiagramExampleUC).commonControlsPanel.Dock = DockStyle.Right
			Else
				diagramDockManager.m_Container.RootZone.AddChild(zone)
				CType(CurrentExampleControl, NDiagramExampleUC).commonControlsPanel.Height = 80
				CType(CurrentExampleControl, NDiagramExampleUC).commonControlsPanel.Dock = DockStyle.Bottom
			End If
		End Sub
		Protected Overrides Sub ClearExample(ByVal clearAll As Boolean)
			MyBase.ClearExample(clearAll)

			document_Renamed.Reset()
			view_Renamed.Reset()
		End Sub


		#End Region

		#Region "Implementation"

		''' <summary>
		''' 
		''' </summary>
		Private Sub InitializeDiagramExamplesComponents()
			Dim dockManager As NDiagramExamplesDockManager = CType(Me.DockManager, NDiagramExamplesDockManager)

			' create the view
			view_Renamed = New NDrawingView()
			view_Renamed.Dock = System.Windows.Forms.DockStyle.Fill

			' create the document
			document_Renamed = New NDrawingDocument()
			view_Renamed.Document = document_Renamed

			' create the event log
			eventLogControl = New NEventLogUC()
			dockManager.EventLogPanel.Controls.Add(eventLogControl)
			eventLogControl.Dock = System.Windows.Forms.DockStyle.Fill
			eventLogControl.Form = Me

			' create the property browser
			propertyBrowser_Renamed = New NPropertyBrowser()
			propertyBrowser_Renamed.Dock = System.Windows.Forms.DockStyle.Fill
			propertyBrowser_Renamed.View = view_Renamed
			dockManager.DiagramExplorerPanel.Controls.Add(propertyBrowser_Renamed)

			' create the diagram designer panel
			Dim designerPanel As Panel = New Panel()
			designerPanel.Dock = System.Windows.Forms.DockStyle.Fill
			designerPanel.Controls.Add(view_Renamed)
			dockManager.DiagramDesignerPanel.Controls.Add(designerPanel)

			' create the command bars manager
			commandBarsManager_Renamed = New NDiagramCommandBarsManager()
			commandBarsManager_Renamed.View = view_Renamed
			commandBarsManager_Renamed.ParentControl = designerPanel

			' create the status bar
			Dim statusBar As NDiagramStatusBar = New NDiagramStatusBar()
			statusBar.Visible = False
			statusBar.View = view_Renamed
			commandBarsManager_Renamed.StatusBar = statusBar
			Controls.Add(statusBar)
		End Sub

		#End Region

		#Region "Properties"

		''' <summary>
		''' Obtains a reference to the document view
		''' </summary>
		Public ReadOnly Property View() As NDrawingView
			Get
				Return view_Renamed
			End Get
		End Property
		''' <summary>
		''' Obtains a reference to the document 
		''' </summary>
		Public Property Document() As NDrawingDocument
			Get
				Return document_Renamed
			End Get
			Set
				document_Renamed = Value
			End Set
		End Property
		''' <summary>
		''' Obtains a reference to the command bars manager
		''' </summary>
		Public ReadOnly Property CommandBarsManager() As NDiagramCommandBarsManager
			Get
				Return commandBarsManager_Renamed
			End Get
		End Property
		''' <summary>
		''' Obtains a reference to the property browser
		''' </summary>
		Public ReadOnly Property PropertyBrowser() As NPropertyBrowser
			Get
				Return propertyBrowser_Renamed
			End Get
		End Property

		#End Region

		#Region "Fields"

		Private commandBarsManager_Renamed As NDiagramCommandBarsManager
		Private document_Renamed As NDrawingDocument
		Private view_Renamed As NDrawingView

		Private eventLogControl As NEventLogUC
		Private propertyBrowser_Renamed As NPropertyBrowser
		Private currentLayoutType As String

		#End Region
	End Class
End Namespace