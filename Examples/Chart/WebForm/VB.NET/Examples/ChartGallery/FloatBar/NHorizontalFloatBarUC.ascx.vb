Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Dom
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NHorizontalFloatBarUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithPercents(WidthPercentDropDownList, 10)
				WidthPercentDropDownList.SelectedIndex = 7
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Gantt")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Projection.ViewerRotation = 270

			' setup the value axis
			Dim dateTimeScale As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()
			dateTimeScale.EnableUnitSensitiveFormatting = False
			dateTimeScale.LabelValueFormatter = New NDateTimeValueFormatter("d MMM")
			dateTimeScale.MajorTickMode = MajorTickMode.CustomStep
			dateTimeScale.CustomStep = New NDateTimeSpan(1, NDateTimeUnit.Week)
			dateTimeScale.LabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)
			dateTimeScale.LabelStyle.Angle = New NScaleLabelAngle(90)
			dateTimeScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			stripStyle.Interlaced = True
			dateTimeScale.StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = dateTimeScale
			chart.Axis(StandardAxis.PrimaryY).Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True, 0, 100)

			' label the X axis
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			ordinalScale.LabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)
			ordinalScale.MajorTickMode = MajorTickMode.AutoMaxCount
			ordinalScale.AutoLabels = False
			ordinalScale.Labels.Add("Market Research")
			ordinalScale.Labels.Add("Specifications")
			ordinalScale.Labels.Add("Architecture")
			ordinalScale.Labels.Add("Project Planning")
			ordinalScale.Labels.Add("Detailed Design")
			ordinalScale.Labels.Add("Development")
			ordinalScale.Labels.Add("Test Plan")
			ordinalScale.Labels.Add("Testing and QA")
			ordinalScale.Labels.Add("Documentation")

			' create a floatbar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.BeginValues.ValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			floatBar.EndValues.ValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			floatBar.DataLabelStyle.Visible = False

			AddDataPoint(floatBar, New DateTime(2009, 2, 2), New DateTime(2009, 2, 16))
			AddDataPoint(floatBar, New DateTime(2009, 2, 16), New DateTime(2009, 3, 2))
			AddDataPoint(floatBar, New DateTime(2009, 3, 2), New DateTime(2009, 3, 16))
			AddDataPoint(floatBar, New DateTime(2009, 3, 9), New DateTime(2009, 3, 23))
			AddDataPoint(floatBar, New DateTime(2009, 3, 16), New DateTime(2009, 3, 30))
			AddDataPoint(floatBar, New DateTime(2009, 3, 23), New DateTime(2009, 4, 27))
			AddDataPoint(floatBar, New DateTime(2009, 4, 13), New DateTime(2009, 4, 27))
			AddDataPoint(floatBar, New DateTime(2009, 4, 20), New DateTime(2009, 5, 4))
			AddDataPoint(floatBar, New DateTime(2009, 4, 27), New DateTime(2009, 5, 4))

			floatBar.WidthPercent = WidthPercentDropDownList.SelectedIndex * 10

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub AddDataPoint(ByVal floatBar As NFloatBarSeries, ByVal dtBegin As DateTime, ByVal dtEnd As DateTime)
			floatBar.BeginValues.Add(dtBegin.ToOADate())
			floatBar.EndValues.Add(dtEnd.ToOADate())
		End Sub
	End Class
End Namespace
