Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDateTimeStepLineUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("DateTime Step Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			Dim timeScaleConfigurator As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeScaleConfigurator
			timeScaleConfigurator.LabelGenerationMode = LabelGenerationMode.Stagger2
			timeScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			timeScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' setup step line series
			Dim line As NStepLineSeries = CType(chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			line.Name = "Step Line Series"
			line.InflateMargins = True
			line.UseXValues = True
			line.UseZValues = False
			line.Legend.Mode = SeriesLegendMode.None
			line.DataLabelStyle.Visible = False
			line.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			line.BorderStyle.Color = Color.YellowGreen
			line.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.Green, Color.BlanchedAlmond)
			line.ShadowStyle.Type = ShadowType.Solid
			line.ShadowStyle.Color = Color.FromArgb(15, 0, 0, 0)
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(1.2f, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.2f, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			line.MarkerStyle.BorderStyle.Color = Color.YellowGreen

			' generate some random data
			Dim random As Random = New Random()
			Dim valuesCount As Integer = 10

			GenreateYValues(valuesCount, random)
			GenreateXValues(valuesCount, random)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenreateYValues(ByVal nCount As Integer, ByVal random As Random)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NStepLineSeries = CType(chart.Series(0), NStepLineSeries)

			line.Values.Clear()

			Dim i As Integer = 0
			Do While i < nCount
				line.Values.Add(Random.NextDouble() * 20)
				i += 1
			Loop
		End Sub

		Private Sub GenreateXValues(ByVal nCount As Integer, ByVal random As Random)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim line As NStepLineSeries = CType(chart.Series(0), NStepLineSeries)

			line.XValues.Clear()

			Dim dt As DateTime = New DateTime(2005, 5, 24, 11, 0, 0)

			Dim i As Integer = 0
			Do While i < nCount
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				line.XValues.Add(dt)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
