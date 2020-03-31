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
	Public Partial Class NDirectionalMovementUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithValues(PeriodDropDownList, 0, 100, 10)
				PeriodDropDownList.SelectedIndex = 2
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			Dim calc As NFunctionCalculator = New NFunctionCalculator()
			nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly
			legend.Location = New NPointL(New NLength(98, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))

			' align the chart and the legend
			Dim guideline As NSideGuideline = New NSideGuideline(PanelSide.Right)
			guideline.Targets.Add(legend)
			guideline.Targets.Add(chart)
			nChartControl1.Document.RootPanel.Guidelines.Add(guideline)

			' setup X axis
			Dim scaleX As NValueTimelineScaleConfigurator = New NValueTimelineScaleConfigurator()
			scaleX.FirstRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.FirstRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(225, 225, 225))
			scaleX.FirstRow.UseGridStyle = True
			scaleX.FirstRow.InnerTickStyle.Visible = False
			scaleX.SecondRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.SecondRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(215, 215, 215))
			scaleX.SecondRow.UseGridStyle = True
			scaleX.SecondRow.InnerTickStyle.Visible = False
			scaleX.ThirdRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleX.ThirdRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(205, 205, 205))
			scaleX.ThirdRow.UseGridStyle = True
			scaleX.ThirdRow.InnerTickStyle.Visible = False
			' calendar
			Dim wdr As NWeekDayRule = New NWeekDayRule(WeekDayBit.All)
			wdr.Saturday = False
			wdr.Sunday = False
			scaleX.Calendar.Rules.Add(wdr)
			scaleX.EnableCalendar = True
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup primary Y axis
			Dim axisY1 As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY1.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 45, 100)

			Dim scaleY1 As NLinearScaleConfigurator = CType(axisY1.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY1.RulerStyle.Height = New NLength(2, NGraphicsUnit.Pixel)
			scaleY1.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY1.InnerMajorTickStyle.LineStyle.Width = New NLength(0)

			' setup secondary Y axis
			Dim axisY2 As NAxis = chart.Axis(StandardAxis.SecondaryY)
			axisY2.Visible = True
			axisY2.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 0, 40)

			Dim scaleY2 As NLinearScaleConfigurator = CType(axisY2.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY2.RulerStyle.Height = New NLength(2, NGraphicsUnit.Pixel)
			scaleY2.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY2.InnerMajorTickStyle.LineStyle.Width = New NLength(0)

			Dim color1 As Color = Color.FromArgb(100, 100, 150)
			Dim color2 As Color = Color.FromArgb(200, 120, 120)
			Dim color3 As Color = Color.FromArgb(100, 150, 100)

			' setup the stock series
			Dim stock As NStockSeries = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			stock.DataLabelStyle.Visible = False
			stock.CandleStyle = CandleStyle.Stick
			stock.UpStrokeStyle.Color = color1
			stock.DownStrokeStyle.Color = color2
			stock.Legend.Mode = SeriesLegendMode.None
			stock.CandleWidth = New NLength(0.5f, NRelativeUnit.ParentPercentage)
			stock.UseXValues = True
			stock.InflateMargins = True

			' Add line series for ADX
			Dim lineADX As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			lineADX.DisplayOnAxis(StandardAxis.PrimaryY, False)
			lineADX.DisplayOnAxis(StandardAxis.SecondaryY, True)
			lineADX.BorderStyle.Color = Color.LimeGreen
			lineADX.Name = "ADX"
			lineADX.DataLabelStyle.Visible = False

			' Add line series for +DI
			Dim lineDIPos As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			lineDIPos.MultiLineMode = MultiLineMode.Overlapped
			lineDIPos.DisplayOnAxis(StandardAxis.PrimaryY, False)
			lineDIPos.DisplayOnAxis(StandardAxis.SecondaryY, True)
			lineDIPos.BorderStyle.Color = Color.Red
			lineDIPos.Name = "+DI"
			lineDIPos.DataLabelStyle.Visible = False

			' Add line series for -DI
			Dim lineDINeg As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			lineDINeg.MultiLineMode = MultiLineMode.Overlapped
			lineDINeg.DisplayOnAxis(StandardAxis.PrimaryY, False)
			lineDINeg.DisplayOnAxis(StandardAxis.SecondaryY, True)
			lineDINeg.BorderStyle.Color = Color.Blue
			lineDINeg.Name = "-DI"
			lineDINeg.DataLabelStyle.Visible = False

			' add arguments for function calculator
			stock.CloseValues.Name = "close"
			stock.HighValues.Name = "high"
			stock.LowValues.Name = "low"
			calc.Arguments.Add(stock.CloseValues)
			calc.Arguments.Add(stock.HighValues)
			calc.Arguments.Add(stock.LowValues)

			' form controls
			lineDIPos.Visible = ShowPosDICheckBox.Checked
			lineDINeg.Visible = ShowNegDICheckBox.Checked
			lineADX.Visible = ShowADXCheckBox.Checked

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Directional Movement")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			GenerateData(stock)

			UpdateFunctions(stock, lineDIPos, lineDINeg, lineADX, calc)
		End Sub

		Private Sub GenerateData(ByVal stock As NStockSeries)
			Const initialPrice As Double = 400
			Const numDataPoits As Integer = 100

			WebExamplesUtilities.GenerateOHLCData(stock, initialPrice, numDataPoits)
			FillStockDates(stock, numDataPoits, New DateTime(2010, 1, 11))
		End Sub

		Private Sub UpdateFunctions(ByVal stock As NStockSeries, ByVal lineDIPos As NLineSeries, ByVal lineDINeg As NLineSeries, ByVal lineADX As NLineSeries, ByVal calc As NFunctionCalculator)
			Dim sb As StringBuilder = New StringBuilder()
			Dim nPeriod As Integer = PeriodDropDownList.SelectedIndex * 10

			sb.AppendFormat("DI_POS(close; high; low; {0})", nPeriod)
			calc.Expression = sb.ToString()
			lineDIPos.Values = calc.Calculate()
			lineDIPos.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
			lineDIPos.UseXValues = True
			PosDITextBox.Text = calc.Expression

			sb.Remove(0, sb.Length)
			sb.AppendFormat("DI_NEG(close; high; low; {0})", nPeriod)
			calc.Expression = sb.ToString()
			lineDINeg.Values = calc.Calculate()
			lineDINeg.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
			lineDINeg.UseXValues = True
			NegDITextBox.Text = calc.Expression

			sb.Remove(0, sb.Length)
			sb.AppendFormat("MMA(DMI(close; high; low; {0}); {0})", nPeriod)
			calc.Expression = sb.ToString()
			lineADX.Values = calc.Calculate()
			lineADX.XValues = CType(stock.XValues.Clone(), NDataSeriesDouble)
			lineADX.UseXValues = True
			ADXTextBox.Text = calc.Expression
		End Sub
	End Class
End Namespace
