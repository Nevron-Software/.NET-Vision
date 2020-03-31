Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports System.Text
Imports System.Diagnostics
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.Functions

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NMovingAveragesUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents m_FunctionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_ApplyToCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private m_ExpressionLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_NewDataBtn As Nevron.UI.WinForm.Controls.NButton
		Private m_PeriodLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_PeriodScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private m_Chart As NChart
		Private m_Stock As NStockSeries
		Private m_Line As NLineSeries
		Private m_Function As NFunctionCalculator
		Private m_bSkipUpdate As Boolean

		Public Sub New()
			InitializeComponent()

			m_Function = New NFunctionCalculator()

			m_ApplyToCombo.Items.Add("Open Values")
			m_ApplyToCombo.Items.Add("High Values")
			m_ApplyToCombo.Items.Add("Low Values")
			m_ApplyToCombo.Items.Add("Close Values")
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
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_FunctionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_ExpressionLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_NewDataBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_PeriodLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_PeriodScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_ApplyToCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 9)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(169, 16)
			Me.label3.TabIndex = 21
			Me.label3.Text = "Function:"
			' 
			' m_FunctionCombo
			' 
			Me.m_FunctionCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_FunctionCombo.ListProperties.DataSource = Nothing
			Me.m_FunctionCombo.ListProperties.DisplayMember = ""
			Me.m_FunctionCombo.Location = New System.Drawing.Point(6, 30)
			Me.m_FunctionCombo.Name = "m_FunctionCombo"
			Me.m_FunctionCombo.Size = New System.Drawing.Size(169, 21)
			Me.m_FunctionCombo.TabIndex = 20
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_FunctionCombo.SelectedIndexChanged += new System.EventHandler(this.FunctionCombo_SelectedIndexChanged);
			' 
			' m_ExpressionLabel
			' 
			Me.m_ExpressionLabel.Location = New System.Drawing.Point(6, 140)
			Me.m_ExpressionLabel.Name = "m_ExpressionLabel"
			Me.m_ExpressionLabel.ReadOnly = True
			Me.m_ExpressionLabel.Size = New System.Drawing.Size(169, 18)
			Me.m_ExpressionLabel.TabIndex = 19
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 116)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(169, 16)
			Me.label2.TabIndex = 18
			Me.label2.Text = "Expression:"
			' 
			' m_NewDataBtn
			' 
			Me.m_NewDataBtn.Location = New System.Drawing.Point(6, 242)
			Me.m_NewDataBtn.Name = "m_NewDataBtn"
			Me.m_NewDataBtn.Size = New System.Drawing.Size(169, 22)
			Me.m_NewDataBtn.TabIndex = 17
			Me.m_NewDataBtn.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_NewDataBtn.Click += new System.EventHandler(this.NewDataBtn_Click);
			' 
			' m_PeriodLabel
			' 
			Me.m_PeriodLabel.Location = New System.Drawing.Point(126, 198)
			Me.m_PeriodLabel.Name = "m_PeriodLabel"
			Me.m_PeriodLabel.ReadOnly = True
			Me.m_PeriodLabel.Size = New System.Drawing.Size(49, 18)
			Me.m_PeriodLabel.TabIndex = 16
			' 
			' m_PeriodScroll
			' 
			Me.m_PeriodScroll.LargeChange = 1
			Me.m_PeriodScroll.Location = New System.Drawing.Point(6, 198)
			Me.m_PeriodScroll.Maximum = 50
			Me.m_PeriodScroll.Minimum = 1
			Me.m_PeriodScroll.MinimumSize = New System.Drawing.Size(32, 16)
			Me.m_PeriodScroll.Name = "m_PeriodScroll"
			Me.m_PeriodScroll.Size = New System.Drawing.Size(124, 18)
			Me.m_PeriodScroll.TabIndex = 15
			Me.m_PeriodScroll.Value = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_PeriodScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.PeriodScroll_Scroll);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 178)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(169, 14)
			Me.label1.TabIndex = 14
			Me.label1.Text = "Period:"
			' 
			' m_ApplyToCombo
			' 
			Me.m_ApplyToCombo.ListProperties.CheckBoxDataMember = ""
			Me.m_ApplyToCombo.ListProperties.DataSource = Nothing
			Me.m_ApplyToCombo.ListProperties.DisplayMember = ""
			Me.m_ApplyToCombo.Location = New System.Drawing.Point(6, 83)
			Me.m_ApplyToCombo.Name = "m_ApplyToCombo"
			Me.m_ApplyToCombo.Size = New System.Drawing.Size(169, 21)
			Me.m_ApplyToCombo.TabIndex = 22
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.m_ApplyToCombo.SelectedIndexChanged += new System.EventHandler(this.ApplyToCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 63)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(169, 16)
			Me.label4.TabIndex = 23
			Me.label4.Text = "Apply Function To:"
			' 
			' NMovingAveragesUC
			' 
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.m_ApplyToCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_FunctionCombo)
			Me.Controls.Add(Me.m_ExpressionLabel)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.m_NewDataBtn)
			Me.Controls.Add(Me.m_PeriodLabel)
			Me.Controls.Add(Me.m_PeriodScroll)
			Me.Controls.Add(Me.label1)
			Me.Name = "NMovingAveragesUC"
			Me.Size = New System.Drawing.Size(180, 306)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Moving Averages")
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

			' line series for the function
			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.DataLabelStyle.Visible = False
			m_Line.BorderStyle.Color = Color.Crimson
			m_Line.BorderStyle.Width = New NLength(2, NGraphicsUnit.Pixel)
			m_Line.UseXValues = True

			Dim customColor As Color = Color.FromArgb(100, 100, 150)

			' setup the stock series
			m_Stock = CType(m_Chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Bar
			m_Stock.HighLowStrokeStyle.Color = customColor
			m_Stock.UpStrokeStyle.Color = customColor
			m_Stock.DownStrokeStyle.Color = customColor
			m_Stock.UpFillStyle = New NColorFillStyle(Color.White)
			m_Stock.DownFillStyle = New NColorFillStyle(customColor)
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.OpenValues.Name = "open"
			m_Stock.HighValues.Name = "high"
			m_Stock.LowValues.Name = "low"
			m_Stock.CloseValues.Name = "close"
			m_Stock.CandleWidth = New NLength(1, NRelativeUnit.ParentPercentage)
			m_Stock.InflateMargins = True
			m_Stock.UseXValues = True

			GenerateData()

			' form controls
			m_bSkipUpdate = True
			m_ApplyToCombo.SelectedIndex = 3
			m_bSkipUpdate = False

			m_FunctionCombo.Items.Add("Simple Moving Average")
			m_FunctionCombo.Items.Add("Weighted Moving Average")
			m_FunctionCombo.Items.Add("Exponential Moving Average")
			m_FunctionCombo.Items.Add("Modified Moving Average")
			m_FunctionCombo.SelectedIndex = 0
		End Sub

		Private Sub GenerateData()
			Const initialPrice As Double = 100
			Const numDataPoits As Integer = 50

			GenerateOHLCData(m_Stock, initialPrice, numDataPoits)
			FillStockDates(m_Stock, numDataPoits, New Date(2010, 1, 11))
		End Sub

		Private Sub UpdateFunctionLine()
			BuildExpression()
			m_Line.Values = m_Function.Calculate()
			m_Line.XValues.Clear()
			m_Line.XValues.AddRange(m_Stock.XValues)
		End Sub

		Private Sub BuildExpression()
			Dim arg As NDataSeriesDouble
			Dim sb As New StringBuilder()
			Dim nPeriod As Integer = m_PeriodScroll.Value

			Select Case m_ApplyToCombo.SelectedIndex
				Case 0
					arg = m_Stock.OpenValues

				Case 1
					arg = m_Stock.HighValues

				Case 2
					arg = m_Stock.LowValues

				Case 3
					arg = m_Stock.CloseValues

				Case Else
					Debug.Assert(False)
					Return
			End Select

			Select Case m_FunctionCombo.SelectedIndex
				Case 0
					sb.AppendFormat("SMA({0}; {1})", arg.Name, nPeriod)
					m_Line.Name = "Simple Moving Average"

				Case 1
					sb.AppendFormat("WMA({0}; {1})", arg.Name, nPeriod)
					m_Line.Name = "Weighted Moving Average"

				Case 2
					sb.AppendFormat("EMA({0}; {1})", arg.Name, nPeriod)
					m_Line.Name = "Exponential Moving Average"

				Case 3
					sb.AppendFormat("MMA({0}; {1})", arg.Name, nPeriod)
					m_Line.Name = "Modified Moving Average"

				Case Else
					Debug.Assert(False)
					Return
			End Select

			m_Function.Arguments.Clear()
			m_Function.Arguments.Add(arg)
			m_Function.Expression = sb.ToString()

			' form controls
			m_ExpressionLabel.Text = m_Function.Expression
			m_PeriodLabel.Text = nPeriod.ToString()
		End Sub

		Private Sub FunctionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FunctionCombo.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			UpdateFunctionLine()
			nChartControl1.Refresh()
		End Sub

		Private Sub ApplyToCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ApplyToCombo.SelectedIndexChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			If m_bSkipUpdate Then
				Return
			End If

			UpdateFunctionLine()
			nChartControl1.Refresh()
		End Sub

		Private Sub PeriodScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles m_PeriodScroll.ValueChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			UpdateFunctionLine()
			nChartControl1.Refresh()
		End Sub

		Private Sub NewDataBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_NewDataBtn.Click
			GenerateData()
			UpdateFunctionLine()
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace