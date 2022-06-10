Imports Nevron.Chart.WinForm
Imports Nevron.Examples.Framework.WinForm
Imports Nevron.UI.WinForm.Docking

Namespace Nevron.Examples.Chart.WinForm
	Public Class NMainForm
		Inherits NExamplesForm

		#Region "Fields"

		Friend chartControl As NChartControl
		Friend chartCommandBarsManager As NChartCommandBarsManager
		Friend m_CurrentLayout As ExampleLayout = ExampleLayout.Standard

		#End Region

		#Region "Constructors"

		Public Sub New()
			InitializeComponent()

			InitFromConfig(New NChartExamplesConfig())

			Me.StartPosition = FormStartPosition.CenterScreen
			Me.WindowState = FormWindowState.Maximized

			Me.chartControl = New Nevron.Chart.WinForm.NChartControl()

			Me.chartCommandBarsManager = New NChartCommandBarsManager()
			Me.chartCommandBarsManager.ChartControl = chartControl
			Me.chartCommandBarsManager.ParentControl = Me.MainControlHost
			Me.chartCommandBarsManager.AllowCustomize = False
			Me.chartCommandBarsManager.ContextMenuEnabled = True
			SetupToolbarCommands()

			Me.MainControlHost.Controls.Add(chartControl)

			Me.chartControl.Dock = DockStyle.Fill
			Me.chartControl.BringToFront()

		End Sub

		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.Name = "MainForm"
			Me.Text = "Nevron Chart for .NET - VB.NET examples"
		End Sub

		#End Region

		#Region "Main"

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Shared Sub Main()
			Dim form As New NMainForm()

			Application.Run(form)
		End Sub

		#End Region

		#Region "Overrides"

		Protected Overrides Sub OnFormLoading()
			MyBase.OnFormLoading()

			Me.DockManager.m_ControlHost.SizeInfo.SizeLogic = SizeLogic.FillInterior
		End Sub

		Protected Overrides Sub ClearExample(ByVal clearAll As Boolean)
			MyBase.ClearExample(clearAll)

			Me.chartControl.Clear()
			Me.chartControl.ServiceManager.LegendUpdateService.Start()
			Me.chartControl.DisposeEvents()
		End Sub

		Protected Overrides Sub LoadExample(ByVal example As NExampleEntity)
			MyBase.LoadExample(example)
			Me.chartControl.Refresh()
		End Sub

		Protected Overrides Sub LayoutExample()
			Dim uc As NExampleBaseUC = TryCast(CurrentExampleControl, NExampleBaseUC)

			If uc Is Nothing Then
				Return
			End If

			Dim nWidth As Integer = uc.Width + 10
			Dim nHeight As Integer = uc.Height + 60

			Dim newLayout As ExampleLayout = If(nWidth > 330, ExampleLayout.WideScreen, ExampleLayout.Standard)

			If m_CurrentLayout = newLayout Then
				If ExamplePanel.ParentZone IsNot Nothing Then
					If newLayout = ExampleLayout.WideScreen Then
						ExamplePanel.SizeInfo.AbsoluteSize = New Size(0, nHeight)
					ElseIf newLayout = ExampleLayout.Standard Then
						ExamplePanel.SizeInfo.AbsoluteSize = New Size(nWidth, 0)
					End If
				End If
			Else
				m_CurrentLayout = newLayout

				Dim mainContainer As NDockingPanelContainer = DockManager.MainContainer

				If newLayout = ExampleLayout.WideScreen Then
					Dim zone As INDockZone = DockManager.m_ControlHost.ParentZone
					Dim dpHost As NDockingPanelHost = FindDockingPanelHostInZone(zone)

					If dpHost IsNot Nothing Then
						ExamplePanel.PerformDock(dpHost, DockStyle.Fill, 0)
					Else
						ExamplePanel.PerformDock(zone, DockStyle.Bottom, 0)
					End If

					ExamplePanel.SizeInfo.AbsoluteSize = New Size(0, nHeight)
				ElseIf newLayout = ExampleLayout.Standard Then
					ExamplePanel.PerformDock(mainContainer.RootZone, DockStyle.Right, 0)
					ExamplePanel.SizeInfo.AbsoluteSize = New Size(nWidth, 0)
				End If
			End If
		End Sub

		Protected Overrides Function CreateExampleControl(ByVal example As NExampleEntity) As NExampleUserControl
			Dim uc As NExampleBaseUC = DirectCast(MyBase.CreateExampleControl(example), NExampleBaseUC)

			uc.nChartControl1 = chartControl

			Return uc
		End Function

		#End Region

		#Region "Implementation"

		Private Function FindDockingPanelHostInZone(ByVal zone As INDockZone) As NDockingPanelHost
			If zone Is Nothing Then
				Return Nothing
			End If

			If zone.LayoutInfo.Orientation <> Orientation.Vertical Then
				Return Nothing
			End If

			For Each child As INDockZoneChild In zone.Children
				Dim host As NDockingPanelHost = TryCast(child, NDockingPanelHost)

				If host IsNot Nothing Then
					Return host
				End If
			Next child

			Return Nothing
		End Function
		Private Sub SetupToolbarCommands()
			Return

'			chartCommandBarsManager.Toolbars["Aspect"].Visible = false;
'			chartCommandBarsManager.Toolbars["Panel"].Visible = false;
'			chartCommandBarsManager.Toolbars["Format"].Visible = false;
'
'			NCommandCollection standardCommands = chartCommandBarsManager.Toolbars["Standard"].Commands;
'			standardCommands.RemoveAt(7);
'			standardCommands.RemoveAt(6);
'			standardCommands.RemoveAt(5);
'			standardCommands.RemoveAt(1);
'			standardCommands.RemoveAt(0);
'
'			NCommandCollection toolsCommands = chartCommandBarsManager.Toolbars["Tools"].Commands;
'			toolsCommands.RemoveAt(3);
'			toolsCommands.RemoveAt(2);
'
'			NCommandCollection projectionCommands = chartCommandBarsManager.Toolbars["Projection"].Commands;
'			projectionCommands.RemoveAt(12);
'			projectionCommands.RemoveAt(8);
'			projectionCommands.RemoveAt(7);
'			projectionCommands.RemoveAt(6);
'			projectionCommands.RemoveAt(5);
'			projectionCommands.RemoveAt(4);
'			projectionCommands.RemoveAt(3);
'			projectionCommands.RemoveAt(2);
'			projectionCommands.RemoveAt(1);
'
'			for (int i = 0; i < chartCommandBarsManager.Toolbars.Count; i++)
'			{
'				NDockingToolbar toolbar = chartCommandBarsManager.Toolbars[i];
'				toolbar.HasPendantCommand = false;
'				toolbar.AllowHide = false;
'				toolbar.AllowDelete = false;
'				toolbar.RowIndex = 0;
'			}
		End Sub

		#End Region
	End Class
End Namespace