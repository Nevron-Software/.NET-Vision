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
	Public Class NRangeIndicatorsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Stock As NStockSeries
		Private m_LineUpper As NLineSeries
		Private m_LineLower As NLineSeries
		Private m_LineSMA As NLineSeries
		Private m_UpperCalculator As NFunctionCalculator
		Private m_LowerCalculator As NFunctionCalculator
		Private m_SMACalculator As NFunctionCalculator
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private m_PeriodLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private m_DeviationLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_NewDataBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_ShowAverageCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_ShowPricesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_DeviationScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents m_PeriodScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label3 As System.Windows.Forms.Label
		Private WithEvents m_FunctionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing
		Private m_Updating As Boolean

		Public Sub New()
			m_UpperCalculator = New NFunctionCalculator()
			m_LowerCalculator = New NFunctionCalculator()
			m_SMACalculator = New NFunctionCalculator()

			m_Updating = True
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
			Me.m_PeriodLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_PeriodScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_NewDataBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_DeviationScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_DeviationLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_ShowPricesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_ShowAverageCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_FunctionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' m_PeriodLabel
			' 
			Me.m_PeriodLabel.Location = New System.Drawing.Point(145, 74)
			Me.m_PeriodLabel.Name = "m_PeriodLabel"
			Me.m_PeriodLabel.ReadOnly = True
			Me.m_PeriodLabel.Size = New System.Drawing.Size(31, 18)
			Me.m_PeriodLabel.TabIndex = 11
			' 
			' m_PeriodScroll
			' 
			Me.m_PeriodScroll.LargeChange = 1
			Me.m_PeriodScroll.Location = New System.Drawing.Point(4, 74)
			Me.m_PeriodScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.m_PeriodScroll.Name = "m_PeriodScroll"
			Me.m_PeriodScroll.Size = New System.Drawing.Size(137, 18)
			Me.m_PeriodScroll.TabIndex = 10
			Me.m_PeriodScroll.Value = 20
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_PeriodScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PeriodScroll_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 54)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(126, 14)
			Me.label1.TabIndex = 9
			Me.label1.Text = "Period:"
			' 
			' m_NewDataBtn
			' 
			Me.m_NewDataBtn.Location = New System.Drawing.Point(4, 214)
			Me.m_NewDataBtn.Name = "m_NewDataBtn"
			Me.m_NewDataBtn.Size = New System.Drawing.Size(172, 25)
			Me.m_NewDataBtn.TabIndex = 12
			Me.m_NewDataBtn.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			' 
			' m_DeviationScroll
			' 
			Me.m_DeviationScroll.LargeChange = 1
			Me.m_DeviationScroll.Location = New System.Drawing.Point(4, 125)
			Me.m_DeviationScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.m_DeviationScroll.Name = "m_DeviationScroll"
			Me.m_DeviationScroll.Size = New System.Drawing.Size(137, 18)
			Me.m_DeviationScroll.TabIndex = 13
			Me.m_DeviationScroll.Value = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_DeviationScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.DeviationScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 105)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(117, 16)
			Me.label2.TabIndex = 14
			Me.label2.Text = "Deviation / Shift:"
			' 
			' m_DeviationLabel
			' 
			Me.m_DeviationLabel.Location = New System.Drawing.Point(145, 125)
			Me.m_DeviationLabel.Name = "m_DeviationLabel"
			Me.m_DeviationLabel.ReadOnly = True
			Me.m_DeviationLabel.Size = New System.Drawing.Size(31, 18)
			Me.m_DeviationLabel.TabIndex = 15
			' 
			' m_ShowPricesCheck
			' 
			Me.m_ShowPricesCheck.ButtonProperties.BorderOffset = 2
			Me.m_ShowPricesCheck.Location = New System.Drawing.Point(4, 156)
			Me.m_ShowPricesCheck.Name = "m_ShowPricesCheck"
			Me.m_ShowPricesCheck.Size = New System.Drawing.Size(172, 20)
			Me.m_ShowPricesCheck.TabIndex = 16
			Me.m_ShowPricesCheck.Text = "Show Prices"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_ShowPricesCheck.CheckedChanged += new System.EventHandler(this.ShowPricesCheck_CheckedChanged);
			' 
			' m_ShowAverageCheck
			' 
			Me.m_ShowAverageCheck.ButtonProperties.BorderOffset = 2
			Me.m_ShowAverageCheck.Location = New System.Drawing.Point(4, 181)
			Me.m_ShowAverageCheck.Name = "m_ShowAverageCheck"
			Me.m_ShowAverageCheck.Size = New System.Drawing.Size(172, 22)
			Me.m_ShowAverageCheck.TabIndex = 17
			Me.m_ShowAverageCheck.Text = "Show Moving Average"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_ShowAverageCheck.CheckedChanged += new System.EventHandler(this.ShowAverageCheck_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(4, 6)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(187, 16)
			Me.label3.TabIndex = 19
			Me.label3.Text = "Function:"
			' 
			' m_FunctionCombo
			' 
			Me.m_FunctionCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_FunctionCombo.ListProperties.DataSource = Nothing
			Me.m_FunctionCombo.ListProperties.DisplayMember = ""
			Me.m_FunctionCombo.Location = New System.Drawing.Point(4, 24)
			Me.m_FunctionCombo.Name = "m_FunctionCombo"
			Me.m_FunctionCombo.Size = New System.Drawing.Size(174, 23)
			Me.m_FunctionCombo.TabIndex = 20
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			' 
			' NRangeIndicatorsUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_FunctionCombo)
			Me.Controls.Add(Me.m_ShowAverageCheck)
			Me.Controls.Add(Me.m_ShowPricesCheck)
			Me.Controls.Add(Me.m_DeviationLabel)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.m_DeviationScroll)
			Me.Controls.Add(Me.m_NewDataBtn)
			Me.Controls.Add(Me.m_PeriodLabel)
			Me.Controls.Add(Me.m_PeriodScroll)
			Me.Controls.Add(Me.label1)
			Me.Name = "NRangeIndicatorsUC"
			Me.Size = New System.Drawing.Size(180, 267)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bollinger Bands / Envelopes")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			' setup X axis
			Dim scaleX As New NRangeTimelineScaleConfigurator()
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
			Dim wdr As New NWeekDayRule(WeekDayBit.All)
			wdr.Saturday = False
			wdr.Sunday = False
			scaleX.Calendar.Rules.Add(wdr)
			scaleX.EnableCalendar = True
			' set configurator
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = scaleX

			' setup Y axis
			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.InnerMajorTickStyle.Length = New NLength(0)

			' Add line series for the upper band
			m_LineUpper = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_LineUpper.DataLabelStyle.Visible = False
			m_LineUpper.BorderStyle.Color = Color.Green
			m_LineUpper.UseXValues = True

			' Add line series for lower band
			m_LineLower = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_LineLower.DataLabelStyle.Visible = False
			m_LineLower.BorderStyle.Color = Color.Green
			m_LineLower.UseXValues = True

			' Add line series for Simple Moving Average
			m_LineSMA = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_LineSMA.DataLabelStyle.Visible = False
			m_LineSMA.BorderStyle.Color = Color.Orange
			m_LineSMA.Name = "Simple Moving Average"
			m_LineSMA.UseXValues = True

			Dim color1 As Color = Color.FromArgb(100, 100, 150)
			Dim color2 As Color = Color.FromArgb(200, 120, 120)

			' Setup the stock series
			m_Stock = CType(m_Chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Stick
			m_Stock.CandleWidth = New NLength(0.5F, NRelativeUnit.ParentPercentage)
			m_Stock.UpStrokeStyle.Color = color1
			m_Stock.DownStrokeStyle.Color = color2
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.CloseValues.Name = "close"
			m_Stock.UseXValues = True
			m_Stock.InflateMargins = True

			' Add arguments
			m_UpperCalculator.Arguments.Add(m_Stock.CloseValues)
			m_LowerCalculator.Arguments.Add(m_Stock.CloseValues)
			m_SMACalculator.Arguments.Add(m_Stock.CloseValues)

			GenerateData()

			' form controls
			m_FunctionCombo.Items.Add("Bollinger Bands")
			m_FunctionCombo.Items.Add("Envelopes")

			m_Updating = False

			m_FunctionCombo.SelectedIndex = 0
			m_ShowPricesCheck.Checked = True
			m_ShowAverageCheck.Checked = True
		End Sub

		Private Sub GenerateData()
			Const initialPrice As Double = 500
			Const numDataPoits As Integer = 200

			GenerateOHLCData(m_Stock, initialPrice, numDataPoits)
			FillStockDates(m_Stock, numDataPoits, New Date(2010, 1, 11))
			CopyStockDates()
		End Sub
		Private Sub UpdateExpressions()
			If m_Updating Then
				Return
			End If

			Dim nPeriod As Integer = m_PeriodScroll.Value
			Dim nDeviation As Integer = m_DeviationScroll.Value

			m_SMACalculator.Expression = String.Format("SMA(close; {0})", nPeriod)

			If m_FunctionCombo.SelectedIndex = 0 Then
				m_LineUpper.Name = "Bollinger Band - Upper"
				m_LineLower.Name = "Bollinger Band - Lower"

				m_UpperCalculator.Expression = String.Format("BOLLINGER(close; {0}; {1})", nPeriod, nDeviation)
				m_LowerCalculator.Expression = String.Format("BOLLINGER(close; {0}; {1})", nPeriod, -nDeviation)
			Else
				m_LineUpper.Name = "Envelopes - Upper Line"
				m_LineLower.Name = "Envelopes - Lower Line"

				m_UpperCalculator.Expression = String.Format("ENV(close; {0}; {1})", nPeriod, nDeviation)
				m_LowerCalculator.Expression = String.Format("ENV(close; {0}; {1})", nPeriod, -nDeviation)
			End If

			' form controls
			m_PeriodLabel.Text = nPeriod.ToString()
			m_DeviationLabel.Text = nDeviation.ToString()
		End Sub
		Private Sub CalculateFunctions()
			m_LineUpper.Values = m_UpperCalculator.Calculate()
			m_LineLower.Values = m_LowerCalculator.Calculate()
			m_LineSMA.Values = m_SMACalculator.Calculate()
		End Sub
		Private Sub CopyStockDates()
			m_LineUpper.XValues.Clear()
			m_LineUpper.XValues.AddRange(m_Stock.XValues)

			m_LineLower.XValues.Clear()
			m_LineLower.XValues.AddRange(m_Stock.XValues)

			m_LineSMA.XValues.Clear()
			m_LineSMA.XValues.AddRange(m_Stock.XValues)
		End Sub

		Private Sub FunctionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FunctionCombo.SelectedIndexChanged
			If nChartControl1 IsNot Nothing Then
				UpdateExpressions()
				CalculateFunctions()
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub PeriodScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles m_PeriodScroll.ValueChanged
			If nChartControl1 IsNot Nothing Then
				UpdateExpressions()
				CalculateFunctions()
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub DeviationScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles m_DeviationScroll.ValueChanged
			If nChartControl1 IsNot Nothing Then
				UpdateExpressions()
				CalculateFunctions()
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub NewDataBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_NewDataBtn.Click
			If nChartControl1 IsNot Nothing Then
				GenerateData()
				CalculateFunctions()
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub ShowPricesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowPricesCheck.CheckedChanged
			If nChartControl1 IsNot Nothing Then
				m_Stock.Visible = m_ShowPricesCheck.Checked
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub ShowAverageCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowAverageCheck.CheckedChanged
			If nChartControl1 IsNot Nothing Then
				m_LineSMA.Visible = m_ShowAverageCheck.Checked
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace