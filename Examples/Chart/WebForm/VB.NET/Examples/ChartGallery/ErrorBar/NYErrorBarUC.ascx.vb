Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NYErrorBarUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Error Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' add interlaced stripe
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY.StripStyles.Add(stripStyle)

			Dim scaleX As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount

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

			GenerateData(series)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			If (Not IsPostBack) Then
				ShowUpperYErrorCheck.Checked = series.ShowUpperErrorY
				ShowLowerYErrorCheck.Checked = series.ShowLowerErrorY
				InflateMarginsCheck.Checked = series.InflateMargins
				RoundToTickCheck.Checked = True
			Else
				series.ShowUpperErrorY = ShowUpperYErrorCheck.Checked
				series.ShowLowerErrorY = ShowLowerYErrorCheck.Checked
				series.InflateMargins = InflateMarginsCheck.Checked

				Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
				linearScale.RoundToTickMin = RoundToTickCheck.Checked
				linearScale.RoundToTickMax = RoundToTickCheck.Checked
			End If
		End Sub

		Private Sub GenerateData(ByVal series As NErrorBarSeries)
			series.ClearDataPoints()

			Dim random As Random = New Random()

			Dim y As Double = 20.0
			Dim p As Double = Random.NextDouble() * 10

			For i As Integer = 0 To 14
				y = Math.Sin(p + i / 6.0) * 8 + Random.NextDouble()

				series.Values.Add(y)
				series.LowerErrorsY.Add(1 + random.NextDouble())
				series.UpperErrorsY.Add(1 + random.NextDouble())
			Next i
		End Sub
	End Class
End Namespace
