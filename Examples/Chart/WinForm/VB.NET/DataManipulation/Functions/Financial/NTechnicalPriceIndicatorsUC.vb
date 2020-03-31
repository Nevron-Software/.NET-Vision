Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Text
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NTechnicalPriceIndicatorsUC
		Inherits NExampleBaseUC

		Private m_Stock As NStockSeries
		Private m_Line As NLineSeries
		Private m_Function As NFunctionCalculator
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private m_PeriodLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private m_ExpressionLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_NewDataBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_PeriodScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents m_FunctionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_Function = New NFunctionCalculator()
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
			Me.m_NewDataBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_PeriodLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_PeriodScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_ExpressionLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_FunctionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' m_NewDataBtn
			' 
			Me.m_NewDataBtn.Location = New System.Drawing.Point(7, 200)
			Me.m_NewDataBtn.Name = "m_NewDataBtn"
			Me.m_NewDataBtn.Size = New System.Drawing.Size(170, 22)
			Me.m_NewDataBtn.TabIndex = 9
			Me.m_NewDataBtn.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			' 
			' m_PeriodLabel
			' 
			Me.m_PeriodLabel.Location = New System.Drawing.Point(134, 150)
			Me.m_PeriodLabel.Name = "m_PeriodLabel"
			Me.m_PeriodLabel.ReadOnly = True
			Me.m_PeriodLabel.Size = New System.Drawing.Size(42, 18)
			Me.m_PeriodLabel.TabIndex = 8
			' 
			' m_PeriodScroll
			' 
			Me.m_PeriodScroll.LargeChange = 1
			Me.m_PeriodScroll.Location = New System.Drawing.Point(7, 150)
			Me.m_PeriodScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.m_PeriodScroll.Name = "m_PeriodScroll"
			Me.m_PeriodScroll.Size = New System.Drawing.Size(121, 18)
			Me.m_PeriodScroll.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_PeriodScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PeriodScroll_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 130)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(109, 14)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Period:"
			' 
			' m_ExpressionLabel
			' 
			Me.m_ExpressionLabel.Location = New System.Drawing.Point(7, 87)
			Me.m_ExpressionLabel.Name = "m_ExpressionLabel"
			Me.m_ExpressionLabel.ReadOnly = True
			Me.m_ExpressionLabel.Size = New System.Drawing.Size(170, 18)
			Me.m_ExpressionLabel.TabIndex = 11
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 68)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(170, 16)
			Me.label2.TabIndex = 10
			Me.label2.Text = "Expression:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 8)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(170, 16)
			Me.label3.TabIndex = 13
			Me.label3.Text = "Function:"
			' 
			' m_FunctionCombo
			' 
			Me.m_FunctionCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_FunctionCombo.ListProperties.DataSource = Nothing
			Me.m_FunctionCombo.ListProperties.DisplayMember = ""
			Me.m_FunctionCombo.Location = New System.Drawing.Point(7, 27)
			Me.m_FunctionCombo.Name = "m_FunctionCombo"
			Me.m_FunctionCombo.Size = New System.Drawing.Size(170, 21)
			Me.m_FunctionCombo.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			' 
			' NTechnicalPriceIndicatorsUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_FunctionCombo)
			Me.Controls.Add(Me.m_ExpressionLabel)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.m_NewDataBtn)
			Me.Controls.Add(Me.m_PeriodLabel)
			Me.Controls.Add(Me.m_PeriodScroll)
			Me.Controls.Add(Me.label1)
			Me.Name = "NTechnicalPriceIndicatorsUC"
			Me.Size = New System.Drawing.Size(180, 241)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Technical Price Indicators")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the legend position
			nChartControl1.Legends(0).Location = New NPointL(New NLength(95, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup Stock chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			SetupTimeScale(chart.Axis(StandardAxis.PrimaryX))
			SetupStockChart(chart)
			SetupIndicatorChart(chart)

			' generate data
			GenerateData()

			' form controls
			m_FunctionCombo.Items.Add("Average True Range")
			m_FunctionCombo.Items.Add("Chaikin's Volatility")
			m_FunctionCombo.Items.Add("Commodity Channel Index")
			m_FunctionCombo.Items.Add("Detrended Price Oscillator")
			m_FunctionCombo.Items.Add("MACD")
			m_FunctionCombo.Items.Add("Mass Index")
			m_FunctionCombo.Items.Add("Momentum")
			m_FunctionCombo.Items.Add("Momentum Div")
			m_FunctionCombo.Items.Add("Performance")
			m_FunctionCombo.Items.Add("Rate Of Change")
			m_FunctionCombo.Items.Add("Relative Strength Index")
			m_FunctionCombo.Items.Add("Standard Deviation")
			m_FunctionCombo.Items.Add("Stochastic")
			m_FunctionCombo.Items.Add("TRIX")
			m_FunctionCombo.Items.Add("William's %R")

			m_FunctionCombo.SelectedIndex = 0
			m_PeriodScroll.Value = 10
		End Sub

		Private Sub SetupStockChart(ByVal chart As NCartesianChart)
			' setup Y axis
			Dim axisY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 40, 100)

			Dim scaleY As NLinearScaleConfigurator = CType(axisY.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.InnerMajorTickStyle.Length = New NLength(0)

			Dim color1 As Color = Color.FromArgb(100, 100, 150)
			Dim color2 As Color = Color.FromArgb(200, 120, 120)

			' setup the stock series
			m_Stock = CType(chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.Name = "Price"
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Bar
			m_Stock.HighLowStrokeStyle.Color = color1
			m_Stock.UpStrokeStyle.Color = color1
			m_Stock.DownStrokeStyle.Color = color2
			m_Stock.UpFillStyle = New NColorFillStyle(color1)
			m_Stock.DownFillStyle = New NColorFillStyle(color2)
			m_Stock.OpenValues.Name = "open"
			m_Stock.HighValues.Name = "high"
			m_Stock.LowValues.Name = "low"
			m_Stock.CloseValues.Name = "close"
			m_Stock.CandleWidth = New NLength(0.4F, NRelativeUnit.ParentPercentage)
			m_Stock.UseXValues = True
			m_Stock.InflateMargins = True
		End Sub
		Private Sub SetupIndicatorChart(ByVal chart As NCartesianChart)
			' setup Y axis
			Dim axisY2 As NAxis = chart.Axis(StandardAxis.SecondaryY)
			axisY2.Visible = True
			axisY2.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, False, 0, 35)

			Dim scaleY2 As NLinearScaleConfigurator = CType(axisY2.ScaleConfigurator, NLinearScaleConfigurator)
			scaleY2.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY2.InnerMajorTickStyle.Length = New NLength(0)

			' Add line series for function
			m_Line = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.DataLabelStyle.Visible = False
			m_Line.BorderStyle.Color = Color.Blue
			m_Line.UseXValues = True
			m_Line.DisplayOnAxis(StandardAxis.PrimaryY, False)
			m_Line.DisplayOnAxis(StandardAxis.SecondaryY, True)
		End Sub
		Private Sub SetupTimeScale(ByVal axis As NAxis)
			Dim scaleX As New NValueTimelineScaleConfigurator()
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
			Dim wdr As New NWeekDayRule(WeekDayBit.All)
			wdr.Saturday = False
			wdr.Sunday = False
			scaleX.Calendar.Rules.Add(wdr)
			scaleX.EnableCalendar = True

			axis.ScaleConfigurator = scaleX
		End Sub
		Private Sub GenerateData()
			Const initialPrice As Double = 100
			Const numDataPoits As Integer = 200

			GenerateOHLCData(m_Stock, initialPrice, numDataPoits)
			FillStockDates(m_Stock, numDataPoits, New Date(2010, 1, 11))

			m_Line.XValues.Clear()
			m_Line.XValues.AddRange(m_Stock.XValues)
		End Sub
		Private Sub UpdateExpression()
			Dim nPeriod As Integer = m_PeriodScroll.Value
			Dim sb As New StringBuilder()

			m_Function.Arguments.Clear()

			Select Case m_FunctionCombo.SelectedIndex
				Case 0 ' Average True Range
					m_Function.Arguments.Add(m_Stock.CloseValues)
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.AppendFormat("MMA(TR(close; high; low); {0})", nPeriod)
					m_Line.Name = "Average True Range"
					m_PeriodScroll.Enabled = True

				Case 1 ' Chaikin's Volatility
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.AppendFormat("CHV(high; low; 10; {0})", nPeriod)
					m_Line.Name = "Chaikin's Volatility"
					m_PeriodScroll.Enabled = True

				Case 2 ' Commodity Channel Index
					m_Function.Arguments.Add(m_Stock.CloseValues)
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.AppendFormat("CCI(close; high; low; {0})", nPeriod)
					m_Line.Name = "Commodity Channel Index"
					m_PeriodScroll.Enabled = True

				Case 3 ' Detrended Price Oscillator
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("DPO(close; {0})", nPeriod)
					m_Line.Name = "Detrended Price Oscillator"
					m_PeriodScroll.Enabled = True

				Case 4 ' Moving Average Convergence Divergence
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.Append("SUB( EMA(close;12) ; EMA(close;26) )")
					m_Line.Name = "MACD"
					m_PeriodScroll.Enabled = False

				Case 5 ' Mass Index
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.AppendFormat("MI(high; low; 15; {0})", nPeriod)
					m_Line.Name = "Mass Index"
					m_PeriodScroll.Enabled = True

				Case 6 ' Momentum
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("MOMENTUM(close; {0})", nPeriod)
					m_Line.Name = "Momentum"
					m_PeriodScroll.Enabled = True

				Case 7 ' Momentum Div
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("MOMENTUMDIV(close; {0})", nPeriod)
					m_Line.Name = "Momentum Div"
					m_PeriodScroll.Enabled = True

				Case 8 ' Performance
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("PERFORMANCE(close)")
					m_Line.Name = "Performance"
					m_PeriodScroll.Enabled = False

				Case 9 ' Rate Of Change
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("ROC(close; {0})", nPeriod)
					m_Line.Name = "Rate Of Change"
					m_PeriodScroll.Enabled = True

				Case 10 ' Relative Strength Index
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("RSI(close; {0})", nPeriod)
					m_Line.Name = "Relative Strength Index"
					m_PeriodScroll.Enabled = True

				Case 11 ' Standard Deviation
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("STDDEV(close; {0})", nPeriod)
					m_Line.Name = "Standard Deviation"
					m_PeriodScroll.Enabled = True

				Case 12 ' Stochastic Oscillator
					m_Function.Arguments.Add(m_Stock.CloseValues)
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.AppendFormat("STOCHASTIC(close; high; low; {0})", nPeriod)
					m_Line.Name = "Stochastic Oscillator"
					m_PeriodScroll.Enabled = True

				Case 13 ' TRIX
					m_Function.Arguments.Add(m_Stock.CloseValues)
					sb.AppendFormat("TRIX(close; {0})", nPeriod)
					m_Line.Name = "TRIX"
					m_PeriodScroll.Enabled = True

				Case 14 ' William's %R
					m_Function.Arguments.Add(m_Stock.CloseValues)
					m_Function.Arguments.Add(m_Stock.HighValues)
					m_Function.Arguments.Add(m_Stock.LowValues)
					sb.AppendFormat("WILLIAMSR(close; high; low; {0})", nPeriod)
					m_Line.Name = "William's %R"
					m_PeriodScroll.Enabled = True

				Case Else
					Debug.Assert(False)
					Return
			End Select

			m_Function.Expression = sb.ToString()

			m_PeriodLabel.Text = nPeriod.ToString()
			m_ExpressionLabel.Text = m_Function.Expression
		End Sub
		Private Sub CalculateFunction()
			m_Line.Values = m_Function.Calculate()
		End Sub

		Private Sub NewDataBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_NewDataBtn.Click
			GenerateData()
			CalculateFunction()

			nChartControl1.Refresh()
		End Sub
		Private Sub PeriodScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles m_PeriodScroll.ValueChanged
			UpdateExpression()
			CalculateFunction()

			nChartControl1.Refresh()
		End Sub
		Private Sub FunctionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FunctionCombo.SelectedIndexChanged
			UpdateExpression()
			CalculateFunction()

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace