Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NXYScatterBubbleUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(BubbleShapeDropDownList, GetType(PointShape))
				BubbleShapeDropDownList.SelectedIndex = 7

				WebExamplesUtilities.FillComboWithValues(MinBubbleSizeDropDownList, 0, 20, 2)
				MinBubbleSizeDropDownList.SelectedIndex = 2
				WebExamplesUtilities.FillComboWithValues(MaxBubbleSizeDropDownList, 0, 20, 2)
				MaxBubbleSizeDropDownList.SelectedIndex = 9

				LightingFilterCheckBox.Checked = True
				InflateMarginsCheckBox.Checked = True
				AxesRoundToTickCheckBox.Checked = False
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Scatter Bubble Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.RoundToTickMin = AxesRoundToTickCheckBox.Checked
			linearScale.RoundToTickMax = AxesRoundToTickCheckBox.Checked
			linearScale = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.RoundToTickMin = AxesRoundToTickCheckBox.Checked
			linearScale.RoundToTickMax = AxesRoundToTickCheckBox.Checked

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup bubble series
			Dim bubble As NBubbleSeries = CType(chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			bubble.BubbleShape = CType(BubbleShapeDropDownList.SelectedIndex, PointShape)
			bubble.InflateMargins = InflateMarginsCheckBox.Checked
			bubble.UseXValues = True
			bubble.DataLabelStyle.Visible = False
			bubble.BorderStyle.Width = New NLength(0)
			bubble.Legend.Format = "<label>"
			bubble.Legend.Mode = SeriesLegendMode.DataPoints
			bubble.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			bubble.ShadowStyle.Type = ShadowType.GaussianBlur
			bubble.ShadowStyle.Offset = New NPointL(New NLength(1, NGraphicsUnit.Pixel), New NLength(1, NGraphicsUnit.Pixel))
			bubble.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0)

			bubble.MinSize = New NLength(MinBubbleSizeDropDownList.SelectedIndex * 2, NRelativeUnit.ParentPercentage)
			bubble.MaxSize = New NLength(MaxBubbleSizeDropDownList.SelectedIndex * 2, NRelativeUnit.ParentPercentage)

			AddDataPoints(bubble)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub AddDataPoints(ByVal bubble As NBubbleSeries)
			Dim palette As NChartPalette = New NChartPalette()
			palette.SetPredefinedPalette(ChartPredefinedPalette.Dark)

			Dim fs0 As NColorFillStyle = New NColorFillStyle(palette.SeriesColors(0))
			Dim fs1 As NColorFillStyle = New NColorFillStyle(palette.SeriesColors(1))
			Dim fs2 As NColorFillStyle = New NColorFillStyle(palette.SeriesColors(2))
			Dim fs3 As NColorFillStyle = New NColorFillStyle(palette.SeriesColors(3))
			Dim fs4 As NColorFillStyle = New NColorFillStyle(palette.SeriesColors(4))
			Dim fs5 As NColorFillStyle = New NColorFillStyle(palette.SeriesColors(5))

			If LightingFilterCheckBox.Checked Then
				fs0.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter())
				fs1.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter())
				fs2.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter())
				fs3.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter())
				fs4.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter())
				fs5.ImageFiltersStyle.Filters.Add(CreateLightingImageFilter())
			End If

			bubble.AddDataPoint(New NBubbleDataPoint(27, 51, 1147995904, "India", fs0))
			bubble.AddDataPoint(New NBubbleDataPoint(50, 67, 1321851888, "China", fs1))
			bubble.AddDataPoint(New NBubbleDataPoint(76, 22, 109955400, "Mexico", fs2))
			bubble.AddDataPoint(New NBubbleDataPoint(210, 9, 142008838, "Russia", fs3))
			bubble.AddDataPoint(New NBubbleDataPoint(360, 4, 305843000, "USA", fs4))
			bubble.AddDataPoint(New NBubbleDataPoint(470, 5, 33560000, "Canada", fs5))
		End Sub

		Private Function CreateLightingImageFilter() As NLightingImageFilter
			Dim lightingFilter As NLightingImageFilter = New NLightingImageFilter()
			lightingFilter.BevelDepth = New NLength(5, NGraphicsUnit.Pixel)
			lightingFilter.BlurType = BlurType.Gaussian
			lightingFilter.DiffuseColor = Color.FromArgb(125, 100, 100, 100)
			lightingFilter.SpecularColor = Color.FromArgb(125, Color.Yellow)

			Return lightingFilter
		End Function
	End Class
End Namespace
