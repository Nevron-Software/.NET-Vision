Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports Nevron.UI.WebForm.Controls
Imports Nevron.Chart.Functions
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NInteractiveTrainSalesPage
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Train Sales")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			Dim chart As NChart = nChartControl1.Charts(0)

			' perform manual stretch
			Dim fAspect As Single = (CSng(nChartControl1.Width.Value) / CSng(nChartControl1.Height.Value))

			' perform manual stretch
			If fAspect > 1 Then
				chart.Width = 86 * fAspect
				chart.Height = 70
			Else
				chart.Width = 86
				chart.Height = 70 * fAspect
			End If

			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(18, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(86, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.Wall(ChartWallType.Floor).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False
			chart.Axis(StandardAxis.Depth).Visible = False

			chart.Axis(StandardAxis.Depth).Visible = False
			Dim ordinalScaleConfigurator As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScaleConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			ordinalScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			ordinalScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, False)
			ordinalScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			Dim anchor As NDockAxisAnchor = New NDockAxisAnchor(AxisDockZone.FrontBottom, False, 5, 95)
			chart.Axis(StandardAxis.PrimaryX).Anchor = anchor
			Dim linearSclaeConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearSclaeConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)

			bar.Name = "Bar Series"
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.FillStyle = New NColorFillStyle(Color.MediumPurple)
			bar.DataLabelStyle.Visible = False
			bar.InflateMargins = True

			' fill with random data
			Dim random As Random = New Random()
			bar.Values.FillRandom(random, 10)

			' generate a data series cumulative sum of the bar values
			Dim fc As NFunctionCalculator = New NFunctionCalculator()
			fc.Expression = "CUMSUM(Value)"
			fc.Arguments.Add(bar.Values)

			' display this data series as line
			line.Name = "Cumulative"
			line.Values = fc.Calculate()
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.DataLabelStyle.Visible = False
			line.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

			bar.BarShape = BarShape.Cylinder

			Dim i As Integer = 0
			Do While i < bar.Values.Count
				bar.FillStyles(i) = New NColorFillStyle(WebExamplesUtilities.RandomColor())
				i += 1
			Loop
			bar.Legend.Mode = SeriesLegendMode.DataPoints
			line.Legend.Mode = SeriesLegendMode.None

			Dim imageResponse As NImageResponse = New NImageResponse()
			imageResponse.StreamImageToBrowser = True
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse
			nChartControl1.RenderControl(Nothing)
		End Sub
	End Class
End Namespace
