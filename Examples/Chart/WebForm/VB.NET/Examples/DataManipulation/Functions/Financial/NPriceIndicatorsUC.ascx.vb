Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NPriceIndicatorsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddFooter("Price Indicators")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.LightModel.EnableLighting = False
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Wall(ChartWallType.Floor).Visible = False
			chart.Wall(ChartWallType.Left).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.Height = 40
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

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

			' setup Y axis
			Dim axis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.InnerMajorTickStyle.Length = New NLength(0)

			' line series for the function
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.DataLabelStyle.Visible = False
			line.BorderStyle.Color = Color.Red
			line.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			line.ShadowStyle.Type = ShadowType.GaussianBlur
			line.UseXValues = True

			Dim customColor As Color = Color.FromArgb(100, 100, 150)

			' setup the stock series
			Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Stick
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
			stock.CandleWidth = New NLength(1, NRelativeUnit.ParentPercentage)
			stock.InflateMargins = True
			stock.UseXValues = True

			GenerateData(stock)

			If (Not IsPostBack) Then
				FunctionDropDownList.Items.Add("Median Price")
				FunctionDropDownList.Items.Add("Typical Price")
				FunctionDropDownList.Items.Add("Weighted Close")
				FunctionDropDownList.SelectedIndex = 0
			End If

			CalculateFunction(stock, line)
		End Sub

		Private Sub GenerateData(ByVal stock As NStockSeries)
			Const initialPrice As Double = 100
			Const numDataPoits As Integer = 50

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits)
			FillStockDates(stock, numDataPoits, New DateTime(2010, 1, 11))
		End Sub

		Private Sub CalculateFunction(ByVal stock As NStockSeries, ByVal line As NLineSeries)
			Dim sb As StringBuilder = New StringBuilder()

			Dim [function] As NFunctionCalculator = New NFunctionCalculator()

			[function].Arguments.Clear()

			Select Case FunctionDropDownList.SelectedIndex
				Case 0
					sb.AppendFormat("MEDIANPRICE({0}; {1})", stock.HighValues.Name, stock.LowValues.Name)
					line.Name = "Median Price"

				Case 1
					sb.AppendFormat("TYPICALPRICE({0}; {1}; {2})", stock.CloseValues.Name, stock.HighValues.Name, stock.LowValues.Name)
					line.Name = "Typical Price"

				Case 2
					sb.AppendFormat("WEIGHTEDCLOSE({0}; {1}; {2})", stock.CloseValues.Name, stock.HighValues.Name, stock.LowValues.Name)
					line.Name = "Weighted Close"
				Case Else
					Return
			End Select

			[function].Expression = sb.ToString()
			[function].Arguments.Clear()
			[function].Arguments.Add(stock.CloseValues)
			[function].Arguments.Add(stock.HighValues)
			[function].Arguments.Add(stock.LowValues)

			line.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
			line.UseXValues = True
			line.Values = [function].Calculate()

			' form controls
			ExpressionLabel.Text = [function].Expression
		End Sub

	End Class
End Namespace
