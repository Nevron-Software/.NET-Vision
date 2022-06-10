Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NFloatBarGanttUC
		Inherits NExampleBaseUC

		Private WithEvents ShowGanttConnectorLinesCheckBox As UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
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
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.ShowGanttConnectorLinesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ShowGanttConnectorLinesCheckBox
			' 
			Me.ShowGanttConnectorLinesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowGanttConnectorLinesCheckBox.Location = New System.Drawing.Point(0, 0)
			Me.ShowGanttConnectorLinesCheckBox.Name = "ShowGanttConnectorLinesCheckBox"
			Me.ShowGanttConnectorLinesCheckBox.Size = New System.Drawing.Size(163, 21)
			Me.ShowGanttConnectorLinesCheckBox.TabIndex = 14
			Me.ShowGanttConnectorLinesCheckBox.Text = "Show Gantt Connector Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowGanttConnectorLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowGanttConnectorLinesCheckBox_CheckedChanged);
			' 
			' NFloatBarGanntUC
			' 
			Me.Controls.Add(Me.ShowGanttConnectorLinesCheckBox)
			Me.Name = "NFloatBarGanntUC"
			Me.Size = New System.Drawing.Size(180, 86)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Class Task
			Public Sub New(ByVal label As String, ByVal begin As Date, ByVal [end] As Date, ByVal nextTasks() As UInteger)
				Me.Begin = begin
				Me.End = [end]
				Me.Label = label
				Me.NextTasks = nextTasks
			End Sub

			Public Index As Integer
			Public Label As String
			Public Begin As Date
			Public [End] As Date

			Public NextTasks() As UInteger
		End Class

		Private Class TaskCollection
			Public Sub New()
				m_Tasks = New List(Of Task)()
			End Sub
			Public Sub Add(ByVal task As Task)
				task.Index = m_Tasks.Count - 1
				m_Tasks.Add(task)
			End Sub

			Public Sub ConfigureChart(ByVal chart As NCartesianChart)
				Dim ordinalScale As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
				ordinalScale.MajorTickMode = MajorTickMode.CustomStep
				ordinalScale.LabelStyle.ContentAlignment = ContentAlignment.TopCenter
				ordinalScale.CustomStep = 1
				ordinalScale.AutoLabels = False

				Dim floatBar As New NFloatBarSeries()
				floatBar.DataLabelStyle.Visible = False
				floatBar.WidthPercent = 50
				chart.Series.Add(floatBar)

				For i As Integer = 0 To m_Tasks.Count - 1
					Dim task As Task = m_Tasks(i)

					ordinalScale.Labels.Add(task.Label)
					floatBar.BeginValues.Add(task.Begin.ToOADate())
					floatBar.EndValues.Add(task.End.ToOADate())

					If task.NextTasks IsNot Nothing Then
						floatBar.NextTasks.Add(i, task.NextTasks)
					End If
				Next i
			End Sub

			Private m_Tasks As List(Of Task)
		End Class


		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Gantt Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft)
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup the value axis
			Dim dateTimeScale As New NRangeTimelineScaleConfigurator()
			dateTimeScale.MajorGridStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back }

			' add interlaced stripe
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back }
			stripStyle.Interlaced = True
			dateTimeScale.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = dateTimeScale
			chart.Axis(StandardAxis.PrimaryY).Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True, 0, 100)

			' fill data
			Dim start As Date = Date.Now
			Dim [end] As Date = start.Add(New TimeSpan(10, 0, 0, 0))

			Dim tasks As New TaskCollection()
			tasks.Add(New Task("Write Proposal", New Date(2001, 4, 1), New Date(2001, 4, 5), New UInteger() { 1, 2 }))

			tasks.Add(New Task("Obtain Approval", New Date(2001, 4, 12), New Date(2001, 9, 4), New UInteger() { 9 }))

			tasks.Add(New Task("Requirements Analysis", New Date(2001, 4, 9), New Date(2001, 5, 5), New UInteger() { 3 }))

			tasks.Add(New Task("Design Phase", New Date(2001, 5, 6), New Date(2001, 5, 30), New UInteger() { 4 }))

			tasks.Add(New Task("Design Signoff", New Date(2001, 6, 2), New Date(2001, 6, 2), New UInteger() { 5 }))

			tasks.Add(New Task("Alpha Implementation", New Date(2001, 6, 3), New Date(2001, 7, 31), New UInteger() { 6 }))

			tasks.Add(New Task("Design Review", New Date(2001, 8, 1), New Date(2001, 8, 8), New UInteger() { 7 }))

			tasks.Add(New Task("Revised Design Signoff", New Date(2001, 8, 10), New Date(2001, 8, 10), New UInteger() { 8 }))

			tasks.Add(New Task("Beta Implementation", New Date(2001, 8, 12), New Date(2001, 9, 12), New UInteger() { 9 }))

			tasks.Add(New Task("Testing", New Date(2001, 9, 13), New Date(2001, 10, 31), New UInteger() { 10 }))

			tasks.Add(New Task("Final Implementation", New Date(2001, 11, 1), New Date(2001, 11, 15), New UInteger() { 11 }))

			tasks.Add(New Task("Signoff", New Date(2001, 11, 28), New Date(2001, 11, 30), New UInteger() { 12 }))

			tasks.ConfigureChart(chart)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NFloatBarDragPointTool())

			' init form controls
			ShowGanttConnectorLinesCheckBox.Checked = True
		End Sub

		Private Sub ShowGanttConnectorLinesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowGanttConnectorLinesCheckBox.CheckedChanged
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			floatBar.ShowGanttConnectorLines = ShowGanttConnectorLinesCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace