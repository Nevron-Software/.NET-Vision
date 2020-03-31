Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NXYErrorBarUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Error Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup Y axis
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			linearScaleConfigurator = New NLinearScaleConfigurator()
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScaleConfigurator

			' setup error bar series
			Dim series As NErrorBarSeries = CType(chart.Series.Add(SeriesType.ErrorBar), NErrorBarSeries)
			series.DataLabelStyle.Visible = False
			series.BorderStyle = New NStrokeStyle(GreyBlue)
			series.MarkerStyle.Visible = True
			series.MarkerStyle.AutoDepth = False
			series.MarkerStyle.FillStyle = New NColorFillStyle(DarkOrange)
			series.MarkerStyle.BorderStyle = New NStrokeStyle(GreyBlue)
			series.MarkerStyle.Width = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			series.MarkerStyle.Height = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			series.MarkerStyle.Depth = New NLength(1.5f, NRelativeUnit.ParentPercentage)
			series.UseXValues = True

			GenerateData(series)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			If (Not IsPostBack) Then
				ShowUpperYErrorCheck.Checked = series.ShowUpperErrorY
				ShowLowerYErrorCheck.Checked = series.ShowLowerErrorY
				ShowUpperXErrorCheck.Checked = series.ShowUpperErrorX
				ShowLowerXErrorCheck.Checked = series.ShowLowerErrorX
				InflateMarginsCheck.Checked = series.InflateMargins
				RoundToTickCheck.Checked = True
			Else
				series.ShowUpperErrorY = ShowUpperYErrorCheck.Checked
				series.ShowLowerErrorY = ShowLowerYErrorCheck.Checked
				series.ShowUpperErrorX = ShowUpperXErrorCheck.Checked
				series.ShowLowerErrorX = ShowLowerXErrorCheck.Checked
				series.InflateMargins = InflateMarginsCheck.Checked

				Dim linearScale As NLinearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)
				linearScale.RoundToTickMin = RoundToTickCheck.Checked
				linearScale.RoundToTickMax = RoundToTickCheck.Checked
			End If
		End Sub

		Private Sub GenerateData(ByVal series As NErrorBarSeries)
			series.ClearDataPoints()

			Dim y As Double
			Dim x As Double = 50.0
			Dim random As Random = New Random()

			For i As Integer = 0 To 14
				y = 20 + random.NextDouble() * 30
				x += 2.0 + random.NextDouble() * 2

				series.Values.Add(y)
				series.LowerErrorsY.Add(1 + random.NextDouble())
				series.UpperErrorsY.Add(1 + random.NextDouble())

				series.XValues.Add(x)
				series.LowerErrorsX.Add(1 + random.NextDouble())
				series.UpperErrorsX.Add(1 + random.NextDouble())
			Next i
		End Sub
	End Class
End Namespace
