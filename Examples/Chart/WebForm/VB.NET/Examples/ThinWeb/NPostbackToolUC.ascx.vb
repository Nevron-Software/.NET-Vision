Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NPostbackToolUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not NThinChartControl1.Initialized) Then
				' enable jittering (full scene antialiasing)
				NThinChartControl1.Settings.JitterMode = JitterMode.Enabled
				NThinChartControl1.Panels.Clear()

				' apply background image border
				Dim frame As NImageFrameStyle = New NImageFrameStyle()
				frame.Type = ImageFrameType.Raised
				frame.BackgroundColor = Color.White
				frame.BorderStyle.Color = Color.Gainsboro
				NThinChartControl1.BackgroundStyle.FrameStyle = frame
				NThinChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(Color.White, Color.GhostWhite)

				' set a chart title
				Dim title As NLabel = New NLabel("Postback Tool")
				NThinChartControl1.Panels.Add(title)
				title.DockMode = PanelDockMode.Top
				title.Padding = New NMarginsL(4, 6, 4, 6)
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

				' configure the legend
				Dim legend As NLegend = New NLegend()
				NThinChartControl1.Panels.Add(legend)
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
				NThinChartControl1.Panels.Add(chart)
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

				Dim i As Integer = 0
				Do While i < bar.Values.Count
					bar.InteractivityStyles(i) = New NInteractivityStyle("Click on bar to make it red")
					i += 1
				Loop

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(bar)

				NThinChartControl1.Controller.Tools.Add(New NPostbackTool())
			End If

			AddHandler NThinChartControl1.Postback, AddressOf NThinChartControl1_Postback
			NThinChartControl1.Controller.Tools.Clear()

			Dim tooltipTool As NTooltipTool = New NTooltipTool()
			NThinChartControl1.Controller.Tools.Add(tooltipTool)

			Dim postbackTool As NPostbackTool = New NPostbackTool()
			postbackTool.PostbackOnlyOnInteractiveItems = PostbackOnlyOnInteractiveItemsCheckBox.Checked
			NThinChartControl1.Controller.Tools.Add(postbackTool)
		End Sub

		Private Sub NThinChartControl1_Postback(ByVal sender As Object, ByVal e As ThinWeb.NPostbackEventArgs)
			Dim hitTestResult As NHitTestResult = NThinChartControl1.HitTest(e.MousePosition.X, e.MousePosition.Y)

			Dim dataPointIndex As Integer = hitTestResult.DataPointIndex

			If dataPointIndex <> -1 Then
				Dim barSeries As NBarSeries = CType(hitTestResult.Series, NBarSeries)

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(barSeries)
				barSeries.FillStyles(dataPointIndex) = New NColorFillStyle(Color.Red)
			Else
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(NThinChartControl1.Charts(0))
			End If
		End Sub
	End Class
End Namespace
