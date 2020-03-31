Imports Microsoft.VisualBasic
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NPointChartAndBoxPlotUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Data Distribution")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Margins = New NMarginsL(5, 5, 5, 5)
			title.DockMode = PanelDockMode.Top
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' create box and whiskers chart
			Dim boxChart As NChart = New NCartesianChart()
			boxChart.Margins = New NMarginsL(5, 0, 5, 5)
			boxChart.BoundsMode = BoundsMode.Stretch
			boxChart.DockMode = PanelDockMode.Right
			boxChart.Size = New NSizeL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))

			' create point chart
			Dim pointChart As NChart = New NCartesianChart()
			pointChart.Margins = New NMarginsL(5, 0, 0, 5)
			pointChart.BoundsMode = BoundsMode.Stretch
			pointChart.DockMode = PanelDockMode.Fill

			' create a guide line to align the chart bottoms
			Dim bottomChartGuideline As NSideGuideline = New NSideGuideline(PanelSide.Bottom)
			nChartControl1.Document.RootPanel.Guidelines.Add(bottomChartGuideline)
			bottomChartGuideline.Targets.Add(pointChart)
			bottomChartGuideline.Targets.Add(boxChart)

			' arrange panels
			nChartControl1.Panels.Add(title)
			nChartControl1.Panels.Add(boxChart)
			nChartControl1.Panels.Add(pointChart)

			SetupCharts(pointChart, boxChart)

			Dim showAverage As Boolean = ShowAverageCheckBox.Checked
			Dim showOutliers As Boolean = ShowOutliersCheckBox.Checked

			Dim pointSeries As NPointSeries = CType(pointChart.Series(0), NPointSeries)
			Dim boxSeries As NBoxAndWhiskersSeries = CType(boxChart.Series(0), NBoxAndWhiskersSeries)

			Dim bwdp As NBoxAndWhiskersDataPoint = New NBoxAndWhiskersDataPoint(pointSeries.Values, showAverage, showOutliers)
			boxSeries.ClearDataPoints()
			boxSeries.AddDataPoint(bwdp)
		End Sub

		Private Sub SetupCharts(ByVal pointChart As NChart, ByVal boxChart As NChart)
			' data
			Dim arrValues As Double() = { 204.5, 190.6, 199.7, 131.8, 143.4, 215.1, 228.0, 209.2, 183.8, 169.5, 212.0, 254.9, 222.3, 201.0, 215.4, 191.3, 181.5, 207.0, 199.0, 210.0 }

			' setup point chart
			Dim scaleY1 As NStandardScaleConfigurator = CType(pointChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleY1.InnerMajorTickStyle.Visible = False
			scaleY1.MajorGridStyle.ShowAtWalls = New ChartWallType(){}

			Dim scaleX1 As NOrdinalScaleConfigurator = CType(pointChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX1.InnerMajorTickStyle.Visible = False
			scaleX1.DisplayDataPointsBetweenTicks = False

			' setup point series
			Dim point As NPointSeries = CType(pointChart.Series.Add(SeriesType.Point), NPointSeries)
			point.InflateMargins = True
			point.DataLabelStyle.Visible = False
			point.Size = New NLength(1.5f, NRelativeUnit.RootPercentage)
			point.PointShape = PointShape.Ellipse
			point.FillStyle = New NColorFillStyle(DarkOrange)
			point.BorderStyle = New NStrokeStyle(DarkOrange)
			point.Values.AddRange(arrValues)

			' setup box and whiskers chart
			boxChart.Width = 10
			boxChart.Axis(StandardAxis.PrimaryY).Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, False)
			Dim scaleY2 As NStandardScaleConfigurator = CType(boxChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			scaleY2.InnerMajorTickStyle.Visible = False
			scaleY2.MajorGridStyle.ShowAtWalls = New ChartWallType(){}

			boxChart.Axis(StandardAxis.PrimaryX).Visible = False

			' setup box and whiskers series
			Dim boxSeries As NBoxAndWhiskersSeries = CType(boxChart.Series.Add(SeriesType.BoxAndWhiskers), NBoxAndWhiskersSeries)
			boxSeries.InflateMargins = True
			boxSeries.DataLabelStyle.Visible = False
			boxSeries.FillStyle = New NColorFillStyle(Red)
			boxSeries.OutliersFillStyle = New NColorFillStyle(DarkOrange)
			boxSeries.OutliersBorderStyle = New NStrokeStyle(DarkOrange)
			boxSeries.OutliersSize = New NLength(1.5f, NRelativeUnit.RootPercentage)
			boxSeries.MedianStrokeStyle = New NStrokeStyle(Color.Indigo)
			boxSeries.AverageStrokeStyle = New NStrokeStyle(1, Color.DarkRed, LinePattern.Dot)

			' create a box and whiskers data point and initialize it from the point series
			Dim bwdp As NBoxAndWhiskersDataPoint = New NBoxAndWhiskersDataPoint(point.Values, True, True)
			boxSeries.AddDataPoint(bwdp)

			' synchronize axes
			Dim axis1 As NAxis = pointChart.Axis(StandardAxis.PrimaryY)
			Dim axis2 As NAxis = boxChart.Axis(StandardAxis.PrimaryY)
			axis1.Slaves.Add(axis2)
			axis2.Slaves.Add(axis1)

			' set an axis stripe for the interquartile range
			Dim dQ1 As Double = CDbl(bwdp(DataPointValue.LowerBoxValue))
			Dim dQ3 As Double = CDbl(bwdp(DataPointValue.UpperBoxValue))
			Dim boxStripe As NAxisStripe = axis1.Stripes.Add(dQ1, dQ3)
			boxStripe.FillStyle = New NColorFillStyle(Color.FromArgb(50, GreyBlue))

			' set an axis stripe for the min / max range
			Dim dMin As Double = CDbl(bwdp(DataPointValue.LowerWhiskerValue))
			Dim dMax As Double = CDbl(bwdp(DataPointValue.UpperWhiskerValue))
			Dim whiskersStripe As NAxisStripe = axis1.Stripes.Add(dMin, dMax)
			whiskersStripe.FillStyle = New NColorFillStyle(Color.FromArgb(30, GreyBlue))
		End Sub
	End Class
End Namespace
