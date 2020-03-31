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
	Public Partial Class NIntersectLineWithXYValueUC
		Inherits NExampleUC
		'protected NChart nChart;
		'protected NLineSeries nLine;

		Protected LightsCheckBoxBox As CheckBox
		Protected InflateMarginsCheckBoxBox As CheckBox
		Protected LeftAxisRoundToTickCheckBoxBox As CheckBox
		Protected ShowMarkersCheckBoxBox As CheckBox

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' fill the combo
				WebExamplesUtilities.FillComboWithValues(XValueDropDownList, 10, 90, 10)
				WebExamplesUtilities.FillComboWithValues(YValueDropDownList, 10, 90, 10)
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Intersect Line With X/Y Value")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			Dim chart As NChart = nChartControl1.Charts(0)

			' 2D line chart
			chart.BoundsMode = BoundsMode.Stretch

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = GetScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = GetScaleConfigurator()
			chart.Axis(StandardAxis.Depth).Visible = False

			Dim axes As NAxisCollection = chart.Axes

			' add point series
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.UseXValues = True
			point.FillStyle = New NColorFillStyle(Color.Red)
			point.DataLabelStyle.Visible = False
			point.Size = New NLength(2)

			Dim line As NLineSeries = New NLineSeries()
			chart.Series.Add(line)

			line.Name = "Point 1"
			line.FillStyle = New NColorFillStyle(Color.Red)
			line.BorderStyle.Color = Color.Pink
			line.DataLabelStyle.Visible = False
			line.UseXValues = True
			line.InflateMargins = True

			' fill with data
			Dim rand As Random = New Random()
			Dim radius As Double = 0
			Dim angle As Double = 0

			Dim dataPointCount As Integer = 1000
			Dim rStep As Double = 50.0 / dataPointCount
			Dim aStep As Double = 10.0

			Dim i As Integer = 0
			Do While i < dataPointCount
				Dim y As Double = Math.Sin(angle * 0.0174533f) * radius
				Dim x As Double = Math.Cos(angle * 0.0174533f) * radius

				line.XValues.Add(50.0 + x)
				line.Values.Add(50.0 + y)

				radius += rStep
				angle += aStep
				i += 1
			Loop

			point.XValues.Clear()
			point.Values.Clear()

			Dim horizontalAxisCursor As NAxisConstLine = New NAxisConstLine()
			Dim verticalAxisCursor As NAxisConstLine = New NAxisConstLine()

			chart.Axis(StandardAxis.PrimaryX).ConstLines.Add(horizontalAxisCursor)
			chart.Axis(StandardAxis.PrimaryY).ConstLines.Add(verticalAxisCursor)

			Dim xValue As Double = (XValueDropDownList.SelectedIndex + 1) * 10
			Dim yValue As Double = (YValueDropDownList.SelectedIndex + 1) * 10

			horizontalAxisCursor.Value = xValue

			Dim intersections As List(Of Double) = line.IntersectWithXValue(xValue)

			i = 0
			Do While i < intersections.Count
				point.XValues.Add(xValue)
				point.Values.Add(intersections(i))
				i += 1
			Loop

			verticalAxisCursor.Value = yValue
			intersections = line.IntersectWithYValue(yValue)

			i = 0
			Do While i < intersections.Count
				point.XValues.Add(intersections(i))
				point.Values.Add(yValue)
				i += 1
			Loop

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Function GetScaleConfigurator() As NLinearScaleConfigurator
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()

			linearScale.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)
			linearScale.MinorTickCount = 4

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			Return linearScale
		End Function
	End Class
End Namespace