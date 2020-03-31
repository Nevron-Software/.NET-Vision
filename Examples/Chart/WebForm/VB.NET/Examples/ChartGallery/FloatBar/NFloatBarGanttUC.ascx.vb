Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports System.Collections.Generic

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NFloatBarGanttUC
		Inherits NExampleUC
		Private Class Task
'INSTANT VB NOTE: The parameter label was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter begin was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter end was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter nextTasks was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal label_Renamed As String, ByVal begin_Renamed As DateTime, ByVal end_Renamed As DateTime, ByVal nextTasks_Renamed As UInteger())
				Begin = begin_Renamed
				[End] = end_Renamed
				Label = label_Renamed
				NextTasks = nextTasks_Renamed
			End Sub

			Public Index As Integer
			Public Label As String
			Public Begin As DateTime
			Public [End] As DateTime

			Public NextTasks As UInteger()
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
				ordinalScale.CustomStep = 1
				ordinalScale.LabelStyle.ContentAlignment = ContentAlignment.TopCenter
				ordinalScale.AutoLabels = False

				Dim floatBar As NFloatBarSeries = New NFloatBarSeries()
				floatBar.DataLabelStyle.Visible = False
				floatBar.WidthPercent = 50
				chart.Series.Add(floatBar)

				Dim i As Integer = 0
				Do While i < m_Tasks.Count
					Dim task As Task = m_Tasks(i)

					ordinalScale.Labels.Add(task.Label)
					floatBar.BeginValues.Add(task.Begin.ToOADate())
					floatBar.EndValues.Add(task.End.ToOADate())

					If Not task.NextTasks Is Nothing Then
						floatBar.NextTasks.Add(i, task.NextTasks)
					End If
					i += 1
				Loop
			End Sub

			Private m_Tasks As List(Of Task)
		End Class


		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Float Bar Connector Lines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft)
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup the value axis
			Dim dateTimeScale As NRangeTimelineScaleConfigurator = New NRangeTimelineScaleConfigurator()
			dateTimeScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			stripStyle.Interlaced = True
			dateTimeScale.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = dateTimeScale
			chart.Axis(StandardAxis.PrimaryY).Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True, 0, 100)

			' fill data
			Dim start As DateTime = DateTime.Now
			Dim [end] As DateTime = start.Add(New TimeSpan(10, 0, 0, 0))

			Dim tasks As TaskCollection = New TaskCollection()
			tasks.Add(New Task("Write Proposal", New DateTime(2001, 4, 1), New DateTime(2001, 4, 5), New UInteger() { 1, 2 }))

			tasks.Add(New Task("Obtain Approval", New DateTime(2001, 4, 12), New DateTime(2001, 9, 4), New UInteger() { 9 }))

			tasks.Add(New Task("Requirements Analysis", New DateTime(2001, 4, 9), New DateTime(2001, 5, 5), New UInteger() { 3 }))

			tasks.Add(New Task("Design Phase", New DateTime(2001, 5, 6), New DateTime(2001, 5, 30), New UInteger() { 4 }))

			tasks.Add(New Task("Design Signoff", New DateTime(2001, 6, 2), New DateTime(2001, 6, 2), New UInteger() { 5 }))

			tasks.Add(New Task("Alpha Implementation", New DateTime(2001, 6, 3), New DateTime(2001, 7, 31), New UInteger() { 6 }))

			tasks.Add(New Task("Design Review", New DateTime(2001, 8, 1), New DateTime(2001, 8, 8), New UInteger() { 7 }))

			tasks.Add(New Task("Revised Design Signoff", New DateTime(2001, 8, 10), New DateTime(2001, 8, 10), New UInteger() { 8 }))

			tasks.Add(New Task("Beta Implementation", New DateTime(2001, 8, 12), New DateTime(2001, 9, 12), New UInteger() { 9 }))

			tasks.Add(New Task("Testing", New DateTime(2001, 9, 13), New DateTime(2001, 10, 31), New UInteger() { 10 }))

			tasks.Add(New Task("Final Implementation", New DateTime(2001, 11, 1), New DateTime(2001, 11, 15), New UInteger() { 11 }))

			tasks.Add(New Task("Signoff", New DateTime(2001, 11, 28), New DateTime(2001, 11, 30), New UInteger() { 12 }))

			tasks.ConfigureChart(chart)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			floatBar.ShowGanttConnectorLines = ShowGanttConnectorLinesCheckBox.Checked
		End Sub
	End Class
End Namespace
