Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NRange2DUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = New NLabel("2D Range Series")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.InnerMajorTickStyle.Visible = False

			' setup Y axis
			linearScale = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.InnerMajorTickStyle.Visible = False

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' setup shape series
			Dim rangeSeries As NRangeSeries = CType(chart.Series.Add(SeriesType.Range), NRangeSeries)
			rangeSeries.DataLabelStyle.Visible = False
			rangeSeries.UseXValues = True
			rangeSeries.FillStyle = New NColorFillStyle(DarkOrange)
			rangeSeries.BorderStyle.Color = Color.DarkRed

			' fill data
			FillData(rangeSeries)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Shared Sub FillData(ByVal rangeSeries As NRangeSeries)
			Dim arrIntervals As Double() = New Double() { 5, 5, 5, 5, 5, 5, 5, 5, 5, 15, 30, 60 }
			Dim arrValues As Double() = New Double() { 4180, 13687, 18618, 19634, 17981, 7190, 16369, 3212, 4122, 9200, 6461, 3435 }

			Dim count As Integer = Math.Min(arrIntervals.Length, arrValues.Length)
			Dim x As Double = 0

			Dim i As Integer = 0
			Do While i < count
				Dim dInterval As Double = arrIntervals(i)
				Dim dValue As Double = arrValues(i)

				rangeSeries.Values.Add(0)
				rangeSeries.XValues.Add(x)

				x += dInterval

				rangeSeries.Y2Values.Add(dValue / dInterval)
				rangeSeries.X2Values.Add(x)
				i += 1
			Loop
		End Sub
	End Class
End Namespace