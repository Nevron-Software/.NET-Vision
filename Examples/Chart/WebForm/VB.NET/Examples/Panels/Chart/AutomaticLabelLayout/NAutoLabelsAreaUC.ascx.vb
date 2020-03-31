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
	Public Partial Class NAutoLabelsAreaUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				EnableLabelAdjustmentCheckBox.Checked = True
				EnableDataPointSafeguardCheckBox.Checked = True

				HiddenField1.Value = Random.Next().ToString()
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Height = 40
			chart.Depth = 5
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)

			' configure X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' configure Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' hide the Z axis
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe for Y axis
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			' area series
			Dim series1 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			series1.InflateMargins = True
			series1.UseXValues = True
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Top
			series1.DataLabelStyle.ArrowLength = New NLength(10)
			series1.DataLabelStyle.ArrowStrokeStyle.Color = DarkOrange
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' disable initial label positioning
			chart.LabelLayout.EnableInitialPositioning = False

			' enable label adjustment
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked

			' enable the data point safesuard and set its size
			series1.LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheckBox.Checked
			series1.LabelLayout.DataPointSafeguardSize = New NSizeL(New NLength(1.3f, NRelativeUnit.ParentPercentage), New NLength(1.3f, NRelativeUnit.ParentPercentage))

			' fill with random data
			GenerateData(series1)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateData(ByVal series As NAreaSeries)
			Dim randSeed As Integer = Integer.Parse(HiddenField1.Value)
			Dim rand As Random = New Random(randSeed)

			series.Values.Clear()
			series.XValues.Clear()

			Dim xvalue As Double = 10

			For i As Integer = 0 To 15
				Dim value As Double = Math.Sin(i * 0.6) * 5 + rand.NextDouble() * 3
				xvalue += 1 + rand.NextDouble() * 20

				series.Values.Add(value)
				series.XValues.Add(xvalue)
			Next i
		End Sub
	End Class
End Namespace
