Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NFloatBarConnectorLinesUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Float Bar Connector Lines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			Dim i As Integer = 0
			Do While i < monthLetters.Length
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, monthLetters(i)))
				i += 1
			Loop

			' add interlaced stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' create the float bar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.DataLabelStyle.Visible = False
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center
			floatBar.DataLabelStyle.Format = "<begin> - <end>"

			' add bars
			floatBar.AddDataPoint(New NFloatBarDataPoint(2, 10))
			floatBar.NextTasks.Add(0, New UInteger() { 1 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 16))
			floatBar.NextTasks.Add(1, New UInteger() { 2 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(9, 17))
			floatBar.NextTasks.Add(2, New UInteger() { 3 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(12, 21))
			floatBar.NextTasks.Add(3, New UInteger() { 4 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 18))
			floatBar.NextTasks.Add(4, New UInteger() { 5 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(7, 18))
			floatBar.NextTasks.Add(5, New UInteger() { 6 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 11))
			floatBar.NextTasks.Add(6, New UInteger() { 7 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 12))
			floatBar.NextTasks.Add(7, New UInteger() { 8 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 17))
			floatBar.NextTasks.Add(8, New UInteger() { 9 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(6, 15))
			floatBar.NextTasks.Add(9, New UInteger() { 10 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 10))
			floatBar.NextTasks.Add(10, New UInteger() { 11 })

			floatBar.AddDataPoint(New NFloatBarDataPoint(1, 7))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			floatBar.ShowConnectorLines = ShowConnectorLinesCheckBox.Checked
			floatBar.ShowGanttConnectorLines = ShowGanttConnectorLinesCheckBox.Checked
		End Sub
	End Class
End Namespace
