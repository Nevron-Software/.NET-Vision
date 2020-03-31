Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDateTimeSmoothLineUC
		Inherits NExampleUC
		Private Const nValuesCount As Integer = 8

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("DateTime Smooth Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim scaleX As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()
			scaleX.EnableUnitSensitiveFormatting = False
			scaleX.LabelValueFormatter = New NDateTimeValueFormatter("dd MMM")
			scaleX.LabelStyle.Angle = New NScaleLabelAngle(90)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			' add the line
			Dim line As NSmoothLineSeries = CType(chart.Series.Add(SeriesType.SmoothLine), NSmoothLineSeries)
			line.Name = "Smooth Line"
			line.InflateMargins = True
			line.DataLabelStyle.Visible = False
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.AutoDepth = False
			line.MarkerStyle.Width = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Depth = New NLength(1.4f, NRelativeUnit.ParentPercentage)
			line.UseXValues = True
			line.UseZValues = False
			line.Use1DInterpolationForXYScatter = True

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			GenreateYValues(nValuesCount)
			GenreateXValues(nValuesCount)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenreateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			series.Values.Clear()

			Dim i As Integer = 0
			Do While i < nCount
				series.Values.Add(Random.NextDouble() * 20)
				i += 1
			Loop
		End Sub

		Private Sub GenreateXValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NXYScatterSeries = CType(chart.Series(0), NXYScatterSeries)

			series.XValues.Clear()

			Dim dt As DateTime = New DateTime(2005, 5, 24, 11, 0, 0)

			Dim i As Integer = 0
			Do While i < nCount
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				series.XValues.Add(dt)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
