Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Chart.Functions
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NMovingAveragesUC
		Inherits NExampleUC
		Private nFunction As NFunctionCalculator

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nFunction = New NFunctionCalculator()

			If (Not IsPostBack) Then
				FunctionDropDownList.Items.Add("Simple Moving Average")
				FunctionDropDownList.Items.Add("Weighted Moving Average")
				FunctionDropDownList.Items.Add("Exponential Moving Average")
				FunctionDropDownList.Items.Add("Modified Moving Average")
				FunctionDropDownList.SelectedIndex = 0

				' form controls
				ApplyFunctionToDropDownList.Items.Add("Open")
				ApplyFunctionToDropDownList.Items.Add("High")
				ApplyFunctionToDropDownList.Items.Add("Low")
				ApplyFunctionToDropDownList.Items.Add("Close")
				ApplyFunctionToDropDownList.SelectedIndex = 3

				WebExamplesUtilities.FillComboWithFloatValues(PeriodDropDownList, 0, 50, 1)
				PeriodDropDownList.SelectedIndex = 10
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Moving Averages")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Location = New NPointL(New NLength(98, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.LightModel.EnableLighting = False
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Wall(ChartWallType.Floor).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			' align the chart and the legend
			Dim guideline As NSideGuideline = New NSideGuideline(PanelSide.Right)
			guideline.Targets.Add(legend)
			guideline.Targets.Add(chart)
			nChartControl1.Document.RootPanel.Guidelines.Add(guideline)

			' setup X axis
			Dim scaleX As NRangeTimelineScaleConfigurator = New NRangeTimelineScaleConfigurator()
			scaleX.FirstRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.FirstRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(225, 225, 225))
			scaleX.FirstRow.UseGridStyle = True
			scaleX.SecondRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.SecondRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(215, 215, 215))
			scaleX.SecondRow.UseGridStyle = True
			scaleX.ThirdRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.ThirdRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(205, 205, 205))
			scaleX.ThirdRow.UseGridStyle = True
			' calendar
			Dim wdr As NWeekDayRule = New NWeekDayRule(WeekDayBit.All)
			wdr.Saturday = False
			wdr.Sunday = False
			scaleX.Calendar.Rules.Add(wdr)
			scaleX.EnableCalendar = True
			' set configurator
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup primary Y axis
			Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)
			linearScaleConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

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
			stock.Legend.Mode = SeriesLegendMode.None
			stock.OpenValues.Name = "open"
			stock.HighValues.Name = "high"
			stock.LowValues.Name = "low"
			stock.CloseValues.Name = "close"
			stock.UseXValues = True
			stock.InflateMargins = True

			GenerateData(stock)
			BuildExpression(stock, line)

			line.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
			line.Values = nFunction.Calculate()
		End Sub

		Private Sub GenerateData(ByVal stock As NStockSeries)
			Const initialPrice As Double = 100
			Const numDataPoits As Integer = 50

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits)
			FillStockDates(stock, numDataPoits, New DateTime(2010, 1, 11))
		End Sub

		Private Sub BuildExpression(ByVal stock As NStockSeries, ByVal line As NSeries)
			Dim arg As NDataSeriesDouble
			Dim sb As StringBuilder = New StringBuilder()
			Dim nPeriod As Integer = PeriodDropDownList.SelectedIndex

			arg = stock.OpenValues

			Select Case ApplyFunctionToDropDownList.SelectedIndex
				Case 0
					arg = stock.OpenValues
				Case 1
					arg = stock.HighValues
				Case 2
					arg = stock.LowValues
				Case 3
					arg = stock.CloseValues
			End Select

			Select Case FunctionDropDownList.SelectedIndex
				Case 0
					sb.AppendFormat("SMA({0}; {1})", arg.Name, nPeriod)
					line.Name = "Simple Moving Average"
				Case 1
					sb.AppendFormat("WMA({0}; {1})", arg.Name, nPeriod)
					line.Name = "Weighted Moving Average"
				Case 2
					sb.AppendFormat("EMA({0}; {1})", arg.Name, nPeriod)
					line.Name = "Exponential Moving Average"
				Case 3
					sb.AppendFormat("MMA({0}; {1})", arg.Name, nPeriod)
					line.Name = "Modified Moving Average"
			End Select

			nFunction.Arguments.Clear()
			nFunction.Arguments.Add(arg)
			nFunction.Expression = sb.ToString()

			' form controls
			ExpressionTextBox.Text = nFunction.Expression
		End Sub
	End Class
End Namespace
