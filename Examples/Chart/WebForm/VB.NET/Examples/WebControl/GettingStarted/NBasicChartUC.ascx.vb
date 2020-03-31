Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NBasicChartUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' enable jittering (full scene antialiasing)
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Panels.Clear()

			' apply background image border
			Dim frame As NImageFrameStyle = New NImageFrameStyle()
			frame.Type = ImageFrameType.Raised
			frame.BackgroundColor = Color.White
			frame.BorderStyle.Color = Color.Gainsboro
			nChartControl1.BackgroundStyle.FrameStyle = frame
			nChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(Color.White, Color.GhostWhite)

			' set a chart title
			Dim title As NLabel = New NLabel("Welcome to Nevron Chart for .NET")
			nChartControl1.Panels.Add(title)
			title.DockMode = PanelDockMode.Top
			title.Padding = New NMarginsL(4, 6, 4, 6)
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' configure the legend
			Dim legend As NLegend = New NLegend()
			nChartControl1.Panels.Add(legend)
			legend.DockMode = PanelDockMode.Right
			legend.Padding = New NMarginsL(1, 1, 3, 3)
			legend.FillStyle.SetTransparencyPercent(50)
			legend.OuterBottomBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterLeftBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterRightBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterTopBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

			' configure the chart
			Dim chart As NCartesianChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)
			chart.Enable3D = True
			chart.Fit3DAxisContent = True
			chart.DisplayOnLegend = legend
			chart.BoundsMode = BoundsMode.Fit
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.DockMode = PanelDockMode.Fill
			chart.Padding = New NMarginsL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))

			' setup the X axis
			Dim axisX As NAxis = chart.Axis(StandardAxis.PrimaryX)
			Dim scaleX As NOrdinalScaleConfigurator = CType(axisX.ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount

			' add interlaced stripe for the Y axis
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim scaleY As NLinearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			scaleY.StripStyles.Add(stripStyle)

			' hide the depth axis
			chart.Axis(StandardAxis.Depth).Visible = False

			' add a bar series and fill it with data
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Simple Bar Chart"
			bar.BarShape = BarShape.SmoothEdgeBar
			bar.Legend.Mode = SeriesLegendMode.DataPoints
			bar.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			bar.DataLabelStyle.Visible = False

			bar.AddDataPoint(New NDataPoint(16, "Spain"))
			bar.AddDataPoint(New NDataPoint(42, "France"))
			bar.AddDataPoint(New NDataPoint(56, "Germany"))
			bar.AddDataPoint(New NDataPoint(23, "Italy"))
			bar.AddDataPoint(New NDataPoint(47, "UK"))
			bar.AddDataPoint(New NDataPoint(38, "Sweden"))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(bar)
		End Sub
	End Class
End Namespace

