Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRealTimeExampleBaseUC
		Inherits NExampleBaseUC

		Private components As IContainer
		Private m_PerformanceCounter As PerformanceCounter

		Private m_CpuUsage() As Single
		Private m_CpuUsageIndex As Integer
		Private m_CpuUsageCount As Integer

		Private m_ReadCPUUsage As Integer

		Private m_TimerRunning As Boolean
		Private m_Timer As Timer

		Public Sub New()
			m_CpuUsage = New Single(9){}

			m_TimerRunning = False
			m_Timer = New System.Windows.Forms.Timer()
			m_Timer.Interval = 25
			AddHandler m_Timer.Tick, AddressOf OnTimerTick

			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If

				If m_Timer IsNot Nothing Then
					m_Timer.Stop()
					RemoveHandler m_Timer.Tick, AddressOf OnTimerTick
					m_Timer.Dispose()
				End If
			End If

			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.SuspendLayout()
			' 
			' NRealTimeExampleBaseUC
			' 
			Me.Name = "NRealTimeExampleBaseUC"
			Me.Size = New System.Drawing.Size(192, 266)
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.NRealTimeExampleBaseUC_Load);
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Properties"

		''' <summary>
		''' Gets the CPU usage
		''' </summary>
		Friend ReadOnly Property CPUUsage() As Single
			Get
				' record the current cpu usage
				If m_ReadCPUUsage = 0 Then
					m_CpuUsage(m_CpuUsageIndex) = m_PerformanceCounter.NextValue()

					m_CpuUsageIndex += 1
					m_CpuUsageCount = Math.Min(m_CpuUsage.Length, m_CpuUsageCount + 1)

					If m_CpuUsageIndex >= m_CpuUsage.Length Then
						m_CpuUsageIndex = 0
					End If

					m_ReadCPUUsage = 5
				End If

				m_ReadCPUUsage -= 1

'INSTANT VB NOTE: The local variable cpuUsage was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
				Dim cpuUsage_Renamed As Single = 0
				For i As Integer = 0 To m_CpuUsageCount - 1
					cpuUsage_Renamed += m_CpuUsage(i)
				Next i

				Return cpuUsage_Renamed / m_CpuUsageCount
			End Get
		End Property

		#End Region

		#Region "Methods"

		''' <summary>
		''' Returns true if the timer is running
		''' </summary>
		''' <returns></returns>
		Protected Function IsTimerRunning() As Boolean
			Return m_TimerRunning
		End Function
		''' <summary>
		''' Starts the timer
		''' </summary>
		''' <param name="sender"></param>
		Protected Sub StartTimer()
			If Not m_TimerRunning Then
				m_Timer.Start()
				m_TimerRunning = True
			End If
		End Sub
		''' <summary>
		''' Toggles the timer
		''' </summary>
		''' <param name="sender"></param>
		Protected Sub ToggleTimer()
			If m_TimerRunning Then
				m_Timer.Stop()
				m_TimerRunning = False

				UpdateTitle(False, 0)
				nChartControl1.Refresh()
			Else
				m_Timer.Start()
				m_TimerRunning = True
			End If
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="working"></param>
		''' <param name="cpuUsage"></param>
		''' <returns></returns>
		Protected Overridable Sub UpdateTitle(ByVal working As Boolean, ByVal cpuUsage As Single)
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Protected Overridable Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			Try
				UpdateTitle(True, CPUUsage)
			Catch ex As Exception
			End Try
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub NRealTimeExampleBaseUC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			m_PerformanceCounter = New PerformanceCounter()
			m_PerformanceCounter.CategoryName = "Processor"
			m_PerformanceCounter.CounterName = "% Processor Time"
			m_PerformanceCounter.InstanceName = "_Total"
		End Sub

		#End Region
	End Class
End Namespace
