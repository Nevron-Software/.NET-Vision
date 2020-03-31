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
	Public Partial Class NAutoLabelsXYZPointUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				EnableInitialPositioningCheckBox.Checked = True
				RemoveOverlappedLabelsCheckBox.Checked = False
				EnableLabelAdjustmentCheckBox.Checked = True
				EnableDataPointSafeguardCheckBox.Checked = True

				WebExamplesUtilities.FillComboWithValues(SafeguardSizeDropDownList, 0, 20, 1)
				SafeguardSizeDropDownList.SelectedIndex = 12

				HiddenField1.Value = Random.Next().ToString()
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XYZ Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight)
			chart.Depth = 55.0f
			chart.Width = 55.0f
			chart.Height = 55.0f

			' set automatic walls
			For Each wall As NChartWall In chart.Walls
				wall.VisibilityMode = WallVisibilityMode.Auto
			Next wall

			' set auto axis anchors
			chart.Axis(StandardAxis.PrimaryX).Anchor = New NBestVisibilityAxisAnchor(AxisOrientation.Horizontal)
			chart.Axis(StandardAxis.PrimaryY).Anchor = New NBestVisibilityAxisAnchor(AxisOrientation.Vertical)
			chart.Axis(StandardAxis.Depth).Anchor = New NBestVisibilityAxisAnchor(AxisOrientation.Depth)

			' configure X axis
			Dim scaleX As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleX.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Floor, ChartWallType.Top, ChartWallType.Front }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' configure Y axis
			Dim scaleY As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleY.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left, ChartWallType.Right, ChartWallType.Front }
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = scaleY

			' add interlaced stripe for Y axis
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left, ChartWallType.Front, ChartWallType.Right }
			scaleY.StripStyles.Add(stripStyle)

			' configure Z axis
			Dim scaleZ As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			scaleZ.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			scaleZ.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Floor, ChartWallType.Top, ChartWallType.Left, ChartWallType.Right }
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = scaleZ

			' point series 1
			Dim series1 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			series1.Name = "Point 1"
			series1.PointShape = PointShape.Bar
			series1.Size = New NLength(2.4f, NRelativeUnit.ParentPercentage)
			series1.UseXValues = True
			series1.UseZValues = True
			series1.InflateMargins = True
			series1.FillStyle = New NColorFillStyle(DarkOrange)
			series1.DataLabelStyle.Visible = True
			series1.DataLabelStyle.VertAlign = VertAlign.Center
			series1.DataLabelStyle.ArrowLength = New NLength(12)
			series1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = DarkOrange
			series1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' point series 2
			Dim series2 As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			series2.Name = "Point 2"
			series2.PointShape = PointShape.Bar
			series2.Size = New NLength(2.4f, NRelativeUnit.ParentPercentage)
			series2.UseXValues = True
			series2.UseZValues = True
			series2.InflateMargins = True
			series2.FillStyle = New NColorFillStyle(Green)
			series2.DataLabelStyle.Visible = True
			series2.DataLabelStyle.VertAlign = VertAlign.Center
			series2.DataLabelStyle.ArrowLength = New NLength(12)
			series2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Green
			series2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' fill with random data
			GenerateData(chart)

			' label layout settings
			chart.LabelLayout.EnableInitialPositioning = EnableInitialPositioningCheckBox.Checked
			chart.LabelLayout.RemoveOverlappedLabels = RemoveOverlappedLabelsCheckBox.Checked
			chart.LabelLayout.EnableLabelAdjustment = EnableLabelAdjustmentCheckBox.Checked

			' enable / disable data point safeguard size for both series
			series1.LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheckBox.Checked
			series2.LabelLayout.EnableDataPointSafeguard = EnableDataPointSafeguardCheckBox.Checked

			' set data point safeguard size for both series
			Dim sizeValue As Single = CSng(SafeguardSizeDropDownList.SelectedIndex)
			Dim size As NSizeL = New NSizeL(New NLength(sizeValue, NGraphicsUnit.Point), New NLength(sizeValue, NGraphicsUnit.Point))
			series1.LabelLayout.DataPointSafeguardSize = size
			series2.LabelLayout.DataPointSafeguardSize = size

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

		End Sub

		Private Sub GenerateData(ByVal chart As NChart)
			Dim randSeed As Integer = Integer.Parse(HiddenField1.Value)
			Dim rand As Random = New Random(randSeed)

			Dim series0 As NPointSeries = CType(chart.Series(0), NPointSeries)
			Dim series1 As NPointSeries = CType(chart.Series(1), NPointSeries)

			Const count As Integer = 6

			series0.Values.FillRandomRange(rand, count, 0, 50)
			series0.XValues.FillRandomRange(rand, count, 0, 50)
			series0.ZValues.FillRandomRange(rand, count, 0, 50)

			series1.Values.FillRandomRange(rand, count, 25, 75)
			series1.XValues.FillRandomRange(rand, count, 25, 75)
			series1.ZValues.FillRandomRange(rand, count, 25, 75)
		End Sub

	End Class
End Namespace
