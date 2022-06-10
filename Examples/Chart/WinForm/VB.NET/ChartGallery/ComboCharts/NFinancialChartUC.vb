Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Functions
Imports Nevron.Chart.Windows


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NFinancialChartUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Stock As NStockSeries
		Private m_HighLow As NHighLowSeries
		Private m_LineSMA As NLineSeries
		Private WithEvents CandleStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents ShowSMA As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowBB As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.CandleStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.ShowBB = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowSMA = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' CandleStyleCombo
			' 
			Me.CandleStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.CandleStyleCombo.ListProperties.DataSource = Nothing
			Me.CandleStyleCombo.ListProperties.DisplayMember = ""
			Me.CandleStyleCombo.Location = New System.Drawing.Point(7, 36)
			Me.CandleStyleCombo.Name = "CandleStyleCombo"
			Me.CandleStyleCombo.Size = New System.Drawing.Size(164, 21)
			Me.CandleStyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CandleStyleCombo.SelectedIndexChanged += new System.EventHandler(this.CandleStyleCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(107, 21)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Candle Style:"
			' 
			' ShowBB
			' 
			Me.ShowBB.ButtonProperties.BorderOffset = 2
			Me.ShowBB.ButtonProperties.WrapText = True
			Me.ShowBB.Checked = True
			Me.ShowBB.CheckState = System.Windows.Forms.CheckState.Checked
			Me.ShowBB.Location = New System.Drawing.Point(7, 115)
			Me.ShowBB.Name = "ShowBB"
			Me.ShowBB.Size = New System.Drawing.Size(162, 35)
			Me.ShowBB.TabIndex = 3
			Me.ShowBB.Text = "Show Bollinger Bands"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowBB.CheckedChanged += new System.EventHandler(this.ShowBB_CheckedChanged);
			' 
			' ShowSMA
			' 
			Me.ShowSMA.ButtonProperties.BorderOffset = 2
			Me.ShowSMA.ButtonProperties.WrapText = True
			Me.ShowSMA.Checked = True
			Me.ShowSMA.CheckState = System.Windows.Forms.CheckState.Checked
			Me.ShowSMA.Location = New System.Drawing.Point(7, 70)
			Me.ShowSMA.Name = "ShowSMA"
			Me.ShowSMA.Size = New System.Drawing.Size(162, 37)
			Me.ShowSMA.TabIndex = 2
			Me.ShowSMA.Text = "Show Simple Moving Average"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowSMA.CheckedChanged += new System.EventHandler(this.ShowSMA_CheckedChanged);
			' 
			' NFinancialChartUC
			' 
			Me.Controls.Add(Me.CandleStyleCombo)
			Me.Controls.Add(Me.ShowBB)
			Me.Controls.Add(Me.ShowSMA)
			Me.Controls.Add(Me.label1)
			Me.Name = "NFinancialChartUC"
			Me.Size = New System.Drawing.Size(180, 177)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Const nNumberOfWeeks As Integer = 20
			Const nWorkDaysInWeek As Integer = 5
			Const nDaysInWeek As Integer = 7
			Const nTotalWorkDays As Integer = nNumberOfWeeks * nWorkDaysInWeek
			Const nTotalDays As Integer = nNumberOfWeeks * nDaysInWeek
			Const nHistoricalDays As Integer = 20

			Dim title As NLabel = nChartControl1.Labels.AddHeader("Financial Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.ContentAlignment = ContentAlignment.BottomCenter

			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Fit

			m_Chart.Location = New NPointL(New NLength(7, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(86, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			m_Chart.Height = 30
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.Wall(ChartWallType.Floor).Visible = False
			m_Chart.Wall(ChartWallType.Left).Visible = False
			m_Chart.Wall(ChartWallType.Back).Width = 0
			m_Chart.Wall(ChartWallType.Back).FillStyle = New NColorFillStyle(Color.FromArgb(239, 245, 239))
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' setup y axis
			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)

			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.LineStyle.Color = Color.Gray
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, False)

			' setup x axis
			Dim axisX1 As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)

			linearScale = New NLinearScaleConfigurator()
			axisX1.ScaleConfigurator = linearScale

			linearScale.AutoLabels = False

			linearScale.MinorTickCount = 4
			linearScale.MajorTickMode = MajorTickMode.CustomStep
			linearScale.CustomStep = 5
			linearScale.RoundToTickMax = False
			linearScale.RoundToTickMin = False
			linearScale.OuterMajorTickStyle.Length = New NLength(4, NGraphicsUnit.Point)
			linearScale.InnerMajorTickStyle.Length = New NLength(0, NGraphicsUnit.Point)
			linearScale.InnerMinorTickStyle.Length = New NLength(0, NGraphicsUnit.Point)
			linearScale.OuterMinorTickStyle.Length = New NLength(2, NGraphicsUnit.Point)
			linearScale.OuterMinorTickStyle.LineStyle.Color = Color.Brown
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, False)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.LabelStyle.ValueScale = 0.2

			' create a line series for the simple moving average
			m_LineSMA = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_LineSMA.Name = "SMA(20)"
			m_LineSMA.DataLabelStyle.Visible = False
			m_LineSMA.BorderStyle.Color = Color.DarkOrange

			' create the stock series
			m_Stock = CType(m_Chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.Name = "Stock Data"
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Bar
			m_Stock.CandleWidth = New NLength(5, NGraphicsUnit.Point)
			m_Stock.InflateMargins = False
			m_Stock.UpFillStyle = New NColorFillStyle(LightOrange)
			m_Stock.UpStrokeStyle.Color = Color.Black
			m_Stock.DownFillStyle = New NColorFillStyle(DarkOrange)
			m_Stock.DownStrokeStyle.Color = Color.Black
			m_Stock.DisplayOnAxis(StandardAxis.PrimaryX, True)
			m_Stock.InflateMargins = True
			m_Stock.OpenValues.Name = "open"
			m_Stock.CloseValues.Name = "close"
			m_Stock.HighValues.Name = "high"
			m_Stock.LowValues.Name = "low"

			' add the bollinger bands as high low area
			m_HighLow = CType(m_Chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			m_HighLow.Name = "BB(20, 2)"
			m_HighLow.DataLabelStyle.Visible = False
			m_HighLow.HighFillStyle = New NColorFillStyle(Color.FromArgb(80, 130, 134, 168))
			m_HighLow.HighBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_HighLow.DisplayOnAxis(StandardAxis.SecondaryX, True)

			' generate some stock data
			GenerateOHLCData(m_Stock, 300, nTotalWorkDays + nHistoricalDays)

			' create a function calculator
			Dim fc As New NFunctionCalculator()
			fc.Arguments.Add(m_Stock.CloseValues)

			' calculate the bollinger bands
			fc.Expression = "BOLLINGER(close; 20; 2)"
			m_HighLow.HighValues = fc.Calculate()
			m_HighLow.HighValues.Name = "BollingerUpper"

			fc.Expression = "BOLLINGER(close; 20; -2)"
			m_HighLow.LowValues = fc.Calculate()
			m_HighLow.LowValues.Name = "BollingerLower"

			' calculate the simple moving average
			fc.Expression = "SMA(close; 20)"
			m_LineSMA.Values = fc.Calculate()

			' remove data that won't be charted
			m_Stock.HighValues.RemoveRange(0, nHistoricalDays)
			m_Stock.LowValues.RemoveRange(0, nHistoricalDays)
			m_Stock.OpenValues.RemoveRange(0, nHistoricalDays)
			m_Stock.CloseValues.RemoveRange(0, nHistoricalDays)
			m_HighLow.HighValues.RemoveRange(0, nHistoricalDays)
			m_HighLow.LowValues.RemoveRange(0, nHistoricalDays)
			m_LineSMA.Values.RemoveRange(0, nHistoricalDays)

			GenerateDateLabels(nTotalDays)

			CandleStyleCombo.Items.Add("Candle")
			CandleStyleCombo.Items.Add("Stick")
			CandleStyleCombo.SelectedIndex = 0

			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			CType(m_Chart, NCartesianChart).RangeSelections.Add(rangeSelection)

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())
			nChartControl1.Controller.Tools.Add(New NDataPanTool())
		End Sub

		Private Sub GenerateDateLabels(ByVal nTotalDays As Integer)
			' the chart starts with the first monday of june 2003
			Dim dt As New Date(2003, 6, 2)
			Dim daySpan As New TimeSpan(1, 0, 0, 0)
			Dim labelFont As New NFontStyle("Arial", 9, FontStyle.Bold)
			Dim axisX1 As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim linearScale As NLinearScaleConfigurator = TryCast(axisX1.ScaleConfigurator, NLinearScaleConfigurator)
			Dim nCurCategory As Integer = 0
			m_Chart.ChildPanels.Clear()

			For i As Integer = 0 To nTotalDays - 1
				' add a custom label for the first work day of the month
				If (dt.Day = 1) OrElse ((dt.DayOfWeek = DayOfWeek.Monday) AndAlso (dt.Day = 2 OrElse dt.Day = 3)) Then
					Dim callout As New NRectangularCallout()
					callout.Anchor = New NAxisValueAnchor(axisX1, AxisValueAnchorMode.Clamp, nCurCategory)
					callout.Orientation = 270

					callout.TextStyle.FontStyle = labelFont
					callout.Text = dt.ToString("MMM yyyy")
					callout.StrokeStyle.Color = Color.DarkSeaGreen
					callout.StrokeStyle.Pattern = LinePattern.Dot
					callout.ArrowBasePercent = 0
					callout.UseAutomaticSize = True

					m_Chart.ChildPanels.Add(callout)

					Dim cl As NAxisConstLine = axisX1.ConstLines.Add()
					cl.Value = nCurCategory
					cl.StrokeStyle.Color = Color.DarkSeaGreen
				End If

				If dt.DayOfWeek = DayOfWeek.Monday Then
					If (dt.Day = 1) OrElse (dt.Day = 2) OrElse (dt.Day = 3) Then
						linearScale.Labels.Add("")
						nCurCategory += 1
					Else
						linearScale.Labels.Add(dt.Day.ToString())
						nCurCategory += 1
					End If
				ElseIf dt.DayOfWeek = DayOfWeek.Saturday Then
				ElseIf dt.DayOfWeek = DayOfWeek.Sunday Then
				Else
					nCurCategory += 1
				End If

				dt = dt.Add(daySpan)
			Next i
		End Sub

		Private Sub CandleStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CandleStyleCombo.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_Stock.CandleStyle = CType(CandleStyleCombo.SelectedIndex, CandleStyle)
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowSMA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowSMA.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_LineSMA.Visible = ShowSMA.Checked
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowBB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowBB.CheckedChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_HighLow.Visible = ShowBB.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace