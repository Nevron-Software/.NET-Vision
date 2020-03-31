Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Text
Imports Nevron.Chart
Imports Nevron.Chart.Functions
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NThinWebGeneralUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not NThinChartControl1.Initialized) Then
				' enable jittering (full scene antialiasing)
				NThinChartControl1.Settings.JitterMode = JitterMode.Enabled

				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False
				NThinChartControl1.Panels.Clear()

				' add header
				Dim header As NLabel = NThinChartControl1.Labels.AddHeader("General Thin Web Functionality")
				header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				header.Margins = New NMarginsL(10, 10, 10, 10)
				header.DockMode = PanelDockMode.Top

				Dim chart As NChart = New NCartesianChart()
				NThinChartControl1.Panels.Add(chart)
				chart.BoundsMode = BoundsMode.Stretch
				chart.DockMode = PanelDockMode.Fill
				chart.Margins = New NMarginsL(10, 0, 10, 10)

				' setup X axis
				Dim scaleX As NRangeTimelineScaleConfigurator = New NRangeTimelineScaleConfigurator()
				' set configurator
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

				' enable the scrollbar
				chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True

				' setup primary Y axis
				Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryY)
				Dim scaleY As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

				' add interlace stripe
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
				stripStyle.Interlaced = True
				stripStyle.SetShowAtWall(ChartWallType.Back, True)
				stripStyle.SetShowAtWall(ChartWallType.Left, True)
				scaleY.StripStyles.Add(stripStyle)

				' line series for the function
				Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
				line.DataLabelStyle.Visible = False
				line.BorderStyle.Color = Color.Red
				line.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
				line.UseXValues = True

				Dim customColor As Color = Color.FromArgb(100, 100, 150)

				' setup the stock series
				Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
				stock.DataLabelStyle.Visible = False
				stock.CandleStyle = CandleStyle.Bar
				stock.CandleWidth = New NLength(1, NRelativeUnit.ParentPercentage)
				stock.HighLowStrokeStyle.Color = customColor
				stock.UpStrokeStyle.Color = customColor
				stock.DownStrokeStyle.Color = customColor
				stock.UpFillStyle = New NColorFillStyle(Color.White)
				stock.DownFillStyle = New NColorFillStyle(customColor)
				stock.OpenValues.Name = "open"
				stock.HighValues.Name = "high"
				stock.LowValues.Name = "low"
				stock.CloseValues.Name = "close"
				stock.UseXValues = True

				GenerateData(stock)
				Dim functionCalculator As NFunctionCalculator = New NFunctionCalculator()
				BuildExpression(functionCalculator, stock, line)

				line.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
				line.Values = functionCalculator.Calculate()

				NThinChartControl1.ServerSettings.EnableTiledZoom = True

				' configure toolbar
				NThinChartControl1.Toolbar.Visible = True
				NThinChartControl1.Controller.SetActivePanel(chart)

				' add a data zoom tool
				Dim dataZoomTool As NDataZoomTool = New NDataZoomTool()
				dataZoomTool.Exclusive = True
				dataZoomTool.Enabled = True
				dataZoomTool.AllowYAxisZoom = False
				NThinChartControl1.Controller.Tools.Add(dataZoomTool)

				' add a data pan tool
				Dim dataPanTool As NDataPanTool = New NDataPanTool()
				dataPanTool.Exclusive = True
				dataPanTool.Enabled = False
				NThinChartControl1.Controller.Tools.Add(dataPanTool)

				' add a tooltip tool
				NThinChartControl1.Controller.Tools.Add(New NTooltipTool())
				' add a cursor change tool
				NThinChartControl1.Controller.Tools.Add(New NCursorTool())

				NThinChartControl1.Toolbar.Visible = True
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NSaveImageAction("Save as PNG", New NPngImageFormat(), True, New NSize(0, 0), 96)))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarSeparator())

				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleDataZoomToolAction()))
				NThinChartControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleDataPanToolAction()))
			End If
		End Sub

		Private Sub GenerateData(ByVal stock As NStockSeries)
			Const initialPrice As Double = 100
			Const numDataPoints As Integer = 200

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoints)
			FillStockDates(stock, numDataPoints, New DateTime(2010, 1, 11))
		End Sub


		Private Sub BuildExpression(ByVal nFunction As NFunctionCalculator, ByVal stock As NStockSeries, ByVal line As NSeries)
			Dim arg As NDataSeriesDouble
			Dim sb As StringBuilder = New StringBuilder()
			Dim nPeriod As Integer = 10

			arg = stock.OpenValues
			arg = stock.OpenValues

				sb.AppendFormat("SMA({0}; {1})", arg.Name, nPeriod)
					line.Name = "Simple Moving Average"

			nFunction.Arguments.Clear()
			nFunction.Arguments.Add(arg)
			nFunction.Expression = sb.ToString()
		End Sub
	End Class
End Namespace
