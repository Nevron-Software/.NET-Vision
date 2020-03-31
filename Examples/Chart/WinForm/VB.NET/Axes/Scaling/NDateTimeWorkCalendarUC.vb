Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Globalization
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.Functions
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDateTimeWorkCalendarUC
		Inherits NExampleBaseUC

		Private m_Chart As NCartesianChart
		Private m_Calendar As NWorkCalendar
		Private m_Stock As NStockSeries
		Private m_HighLow As NHighLowSeries
		Private m_Updating As Boolean
		Private WorkingDaysGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents SaturdayCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents FridayCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents TuesdayCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MondayCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ThursdayCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents WednesdayCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SundayCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableWeekRuleCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableMonthDayRuleCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MonthDayUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label10 As Label
		Private WithEvents RestRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents WorkRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents ZoomToFirst7DaysButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ZoomToFirst30DaysButton As Nevron.UI.WinForm.Controls.NButton
		Private m_LineSMA As NLineSeries

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.WorkingDaysGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.SundayCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SaturdayCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.FridayCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.TuesdayCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MondayCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ThursdayCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.WednesdayCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableWeekRuleCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableMonthDayRuleCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MonthDayUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label10 = New System.Windows.Forms.Label()
			Me.RestRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.WorkRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.ZoomToFirst7DaysButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ZoomToFirst30DaysButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.WorkingDaysGroupBox.SuspendLayout()
			DirectCast(Me.MonthDayUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' WorkingDaysGroupBox
			' 
			Me.WorkingDaysGroupBox.Controls.Add(Me.SundayCheckBox)
			Me.WorkingDaysGroupBox.Controls.Add(Me.SaturdayCheckBox)
			Me.WorkingDaysGroupBox.Controls.Add(Me.FridayCheckBox)
			Me.WorkingDaysGroupBox.Controls.Add(Me.TuesdayCheckBox)
			Me.WorkingDaysGroupBox.Controls.Add(Me.MondayCheckBox)
			Me.WorkingDaysGroupBox.Controls.Add(Me.ThursdayCheckBox)
			Me.WorkingDaysGroupBox.Controls.Add(Me.WednesdayCheckBox)
			Me.WorkingDaysGroupBox.ImageIndex = 0
			Me.WorkingDaysGroupBox.Location = New System.Drawing.Point(19, 36)
			Me.WorkingDaysGroupBox.Name = "WorkingDaysGroupBox"
			Me.WorkingDaysGroupBox.Size = New System.Drawing.Size(195, 145)
			Me.WorkingDaysGroupBox.TabIndex = 1
			Me.WorkingDaysGroupBox.TabStop = False
			Me.WorkingDaysGroupBox.Text = "Working Days"
			' 
			' SundayCheckBox
			' 
			Me.SundayCheckBox.ButtonProperties.BorderOffset = 2
			Me.SundayCheckBox.Location = New System.Drawing.Point(105, 79)
			Me.SundayCheckBox.Name = "SundayCheckBox"
			Me.SundayCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.SundayCheckBox.TabIndex = 6
			Me.SundayCheckBox.Text = "Sunday"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SundayCheckBox.CheckedChanged += new System.EventHandler(this.SundayCheckBox_CheckedChanged);
			' 
			' SaturdayCheckBox
			' 
			Me.SaturdayCheckBox.ButtonProperties.BorderOffset = 2
			Me.SaturdayCheckBox.Location = New System.Drawing.Point(105, 49)
			Me.SaturdayCheckBox.Name = "SaturdayCheckBox"
			Me.SaturdayCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.SaturdayCheckBox.TabIndex = 5
			Me.SaturdayCheckBox.Text = "Saturday"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SaturdayCheckBox.CheckedChanged += new System.EventHandler(this.SaturdayCheckBox_CheckedChanged);
			' 
			' FridayCheckBox
			' 
			Me.FridayCheckBox.ButtonProperties.BorderOffset = 2
			Me.FridayCheckBox.Location = New System.Drawing.Point(105, 19)
			Me.FridayCheckBox.Name = "FridayCheckBox"
			Me.FridayCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.FridayCheckBox.TabIndex = 4
			Me.FridayCheckBox.Text = "Friday"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FridayCheckBox.CheckedChanged += new System.EventHandler(this.FridayCheckBox_CheckedChanged);
			' 
			' TuesdayCheckBox
			' 
			Me.TuesdayCheckBox.ButtonProperties.BorderOffset = 2
			Me.TuesdayCheckBox.Location = New System.Drawing.Point(6, 49)
			Me.TuesdayCheckBox.Name = "TuesdayCheckBox"
			Me.TuesdayCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.TuesdayCheckBox.TabIndex = 1
			Me.TuesdayCheckBox.Text = "Tuesday"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TuesdayCheckBox.CheckedChanged += new System.EventHandler(this.TuesdayCheckBox_CheckedChanged);
			' 
			' MondayCheckBox
			' 
			Me.MondayCheckBox.ButtonProperties.BorderOffset = 2
			Me.MondayCheckBox.Location = New System.Drawing.Point(6, 19)
			Me.MondayCheckBox.Name = "MondayCheckBox"
			Me.MondayCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.MondayCheckBox.TabIndex = 0
			Me.MondayCheckBox.Text = "Monday"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MondayCheckBox.CheckedChanged += new System.EventHandler(this.MondayCheckBox_CheckedChanged);
			' 
			' ThursdayCheckBox
			' 
			Me.ThursdayCheckBox.ButtonProperties.BorderOffset = 2
			Me.ThursdayCheckBox.Location = New System.Drawing.Point(6, 109)
			Me.ThursdayCheckBox.Name = "ThursdayCheckBox"
			Me.ThursdayCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.ThursdayCheckBox.TabIndex = 3
			Me.ThursdayCheckBox.Text = "Thursday"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ThursdayCheckBox.CheckedChanged += new System.EventHandler(this.ThursdayCheckBox_CheckedChanged);
			' 
			' WednesdayCheckBox
			' 
			Me.WednesdayCheckBox.ButtonProperties.BorderOffset = 2
			Me.WednesdayCheckBox.Location = New System.Drawing.Point(6, 79)
			Me.WednesdayCheckBox.Name = "WednesdayCheckBox"
			Me.WednesdayCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.WednesdayCheckBox.TabIndex = 2
			Me.WednesdayCheckBox.Text = "Wednesday"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WednesdayCheckBox.CheckedChanged += new System.EventHandler(this.WednesdayCheckBox_CheckedChanged);
			' 
			' EnableWeekRuleCheckBox
			' 
			Me.EnableWeekRuleCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableWeekRuleCheckBox.Location = New System.Drawing.Point(19, 6)
			Me.EnableWeekRuleCheckBox.Name = "EnableWeekRuleCheckBox"
			Me.EnableWeekRuleCheckBox.Size = New System.Drawing.Size(187, 24)
			Me.EnableWeekRuleCheckBox.TabIndex = 0
			Me.EnableWeekRuleCheckBox.Text = "Enable Week Rule"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableWeekRuleCheckBox.CheckedChanged += new System.EventHandler(this.EnableWeekRuleCheckBox_CheckedChanged);
			' 
			' EnableMonthDayRuleCheckBox
			' 
			Me.EnableMonthDayRuleCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableMonthDayRuleCheckBox.Location = New System.Drawing.Point(19, 187)
			Me.EnableMonthDayRuleCheckBox.Name = "EnableMonthDayRuleCheckBox"
			Me.EnableMonthDayRuleCheckBox.Size = New System.Drawing.Size(187, 24)
			Me.EnableMonthDayRuleCheckBox.TabIndex = 2
			Me.EnableMonthDayRuleCheckBox.Text = "Enable Month Day Rule"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableMonthDayRuleCheckBox.CheckedChanged += new System.EventHandler(this.EnableMonthDayRuleCheckBox_CheckedChanged);
			' 
			' MonthDayUpDown
			' 
			Me.MonthDayUpDown.Location = New System.Drawing.Point(130, 217)
			Me.MonthDayUpDown.Maximum = New Decimal(New Integer() { 31, 0, 0, 0})
			Me.MonthDayUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.MonthDayUpDown.Name = "MonthDayUpDown"
			Me.MonthDayUpDown.Size = New System.Drawing.Size(83, 20)
			Me.MonthDayUpDown.TabIndex = 4
			Me.MonthDayUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MonthDayUpDown.ValueChanged += new System.EventHandler(this.MonthDayUpDown_ValueChanged);
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(19, 221)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(94, 16)
			Me.label10.TabIndex = 3
			Me.label10.Text = "Each Month Day:"
			' 
			' RestRadioButton
			' 
			Me.RestRadioButton.ButtonProperties.BorderOffset = 2
			Me.RestRadioButton.Location = New System.Drawing.Point(19, 271)
			Me.RestRadioButton.Name = "RestRadioButton"
			Me.RestRadioButton.Size = New System.Drawing.Size(135, 24)
			Me.RestRadioButton.TabIndex = 6
			Me.RestRadioButton.Text = "Rest"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RestRadioButton.CheckedChanged += new System.EventHandler(this.RestRadioButton_CheckedChanged);
			' 
			' WorkRadioButton
			' 
			Me.WorkRadioButton.ButtonProperties.BorderOffset = 2
			Me.WorkRadioButton.Location = New System.Drawing.Point(19, 251)
			Me.WorkRadioButton.Name = "WorkRadioButton"
			Me.WorkRadioButton.Size = New System.Drawing.Size(104, 24)
			Me.WorkRadioButton.TabIndex = 5
			Me.WorkRadioButton.Text = "Work"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WorkRadioButton.CheckedChanged += new System.EventHandler(this.WorkRadioButton_CheckedChanged);
			' 
			' ZoomToFirst7DaysButton
			' 
			Me.ZoomToFirst7DaysButton.Location = New System.Drawing.Point(18, 301)
			Me.ZoomToFirst7DaysButton.Name = "ZoomToFirst7DaysButton"
			Me.ZoomToFirst7DaysButton.Size = New System.Drawing.Size(195, 23)
			Me.ZoomToFirst7DaysButton.TabIndex = 8
			Me.ZoomToFirst7DaysButton.Text = "Zoom To First 7 Days"
			Me.ZoomToFirst7DaysButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZoomToFirst7DaysButton.Click += new System.EventHandler(this.ZoomToFirst7DaysButton_Click);
			' 
			' ZoomToFirst30DaysButton
			' 
			Me.ZoomToFirst30DaysButton.Location = New System.Drawing.Point(19, 330)
			Me.ZoomToFirst30DaysButton.Name = "ZoomToFirst30DaysButton"
			Me.ZoomToFirst30DaysButton.Size = New System.Drawing.Size(195, 23)
			Me.ZoomToFirst30DaysButton.TabIndex = 7
			Me.ZoomToFirst30DaysButton.Text = "Zoom to First 30 Days"
			Me.ZoomToFirst30DaysButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZoomToFirst30DaysButton.Click += new System.EventHandler(this.ZoomToFirst30DaysButton_Click);
			' 
			' NDateTimeWorkCalendarUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.ZoomToFirst7DaysButton)
			Me.Controls.Add(Me.ZoomToFirst30DaysButton)
			Me.Controls.Add(Me.RestRadioButton)
			Me.Controls.Add(Me.WorkRadioButton)
			Me.Controls.Add(Me.MonthDayUpDown)
			Me.Controls.Add(Me.label10)
			Me.Controls.Add(Me.EnableMonthDayRuleCheckBox)
			Me.Controls.Add(Me.EnableWeekRuleCheckBox)
			Me.Controls.Add(Me.WorkingDaysGroupBox)
			Me.Name = "NDateTimeWorkCalendarUC"
			Me.Size = New System.Drawing.Size(231, 457)
			Me.WorkingDaysGroupBox.ResumeLayout(False)
			DirectCast(Me.MonthDayUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Date Time Work Calendar<br/><font size = '9pt'>Demonstrates how to skip date time ranges using Week and Month rules</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			nChartControl1.Panels.Add(title)

			m_Chart = CType(nChartControl1.Charts(0), NCartesianChart)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' add interlace stripes
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.StripStyles.Add(stripStyle)

			' enable range selection
			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			m_Chart.RangeSelections.Add(rangeSelection)

			' enable zooming and scrolling
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = New NDateTimeAxisPagingView()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())
			nChartControl1.Controller.Tools.Add(New NDataPanTool())

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' update form controls
			m_Updating = True
			EnableWeekRuleCheckBox.Checked = True

			MondayCheckBox.Checked = True
			TuesdayCheckBox.Checked = True
			WednesdayCheckBox.Checked = True
			ThursdayCheckBox.Checked = True
			FridayCheckBox.Checked = True

			EnableMonthDayRuleCheckBox.Checked = True
			MonthDayUpDown.Value = 1
			WorkRadioButton.Checked = True
			m_Updating = False

			CreateWorkCalendar()
		End Sub

		Private Sub CreateWorkCalendar()
			If m_Updating Then
				Return
			End If

			If m_Chart IsNot Nothing Then
				m_Chart.Axis(StandardAxis.PrimaryX).PagingView.Enabled = False
				m_Chart.Axis(StandardAxis.PrimaryY).PagingView.Enabled = False
			End If

			' create calendar
			m_Calendar = New NWorkCalendar()

			' use week days
			If EnableWeekRuleCheckBox.Checked Then
				Dim weekDayRule As New NWeekDayRule()

				Dim weekDays As WeekDayBit = WeekDayBit.None
				If MondayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Monday
				End If

				If TuesdayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Tuesday
				End If

				If WednesdayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Wednesday
				End If

				If ThursdayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Thursday
				End If

				If FridayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Friday
				End If

				If SaturdayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Saturday
				End If

				If SundayCheckBox.Checked Then
					weekDays = weekDays Or WeekDayBit.Sunday
				End If

				If weekDays = WeekDayBit.None Then
					' cannot select all week days as non working as this leads to a scale with no
					' working days...
					MessageBox.Show("You cannot select all weekdays as non working.")
					Return
				End If

				weekDayRule.WeekDays = weekDays
				weekDayRule.Schedule.SetHourRange(0, 24, False)
				m_Calendar.Rules.Add(weekDayRule)
			End If

			If EnableMonthDayRuleCheckBox.Checked Then
				Dim monthDayRule As New NMonthDayRule()

				monthDayRule.Months = MonthBit.January Or MonthBit.February Or MonthBit.March Or MonthBit.April Or MonthBit.May Or MonthBit.June Or MonthBit.July Or MonthBit.August Or MonthBit.September Or MonthBit.October Or MonthBit.November Or MonthBit.December

				monthDayRule.Day = CInt(Math.Truncate(MonthDayUpDown.Value))
				monthDayRule.Working = WorkRadioButton.Checked
				m_Calendar.Rules.Add(monthDayRule)
			End If

			' apply calendar to scale
			Dim timeline As New NRangeTimelineScaleConfigurator()
			timeline.FirstRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			timeline.FirstRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(225, 225, 225))
			timeline.FirstRow.UseGridStyle = True
			timeline.SecondRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			timeline.SecondRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(215, 215, 215))
			timeline.SecondRow.UseGridStyle = True
			timeline.ThirdRow.GridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			timeline.ThirdRow.GridStyle.LineStyle = New NStrokeStyle(1, Color.FromArgb(205, 205, 205))
			timeline.ThirdRow.UseGridStyle = True

			timeline.EnableCalendar = True
			timeline.Calendar = m_Calendar
			timeline.ThirdRow.EnableUnitSensitiveFormatting = False

			If m_Chart IsNot Nothing Then
				m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeline
			End If

			' generate data for this calendar
			AddData()

			If nChartControl1 IsNot Nothing Then
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub AddData()
			Const nNumberOfWeeks As Integer = 20
			Const nWorkDaysInWeek As Integer = 5
			Const nTotalWorkDays As Integer = nNumberOfWeeks * nWorkDaysInWeek
			Const nHistoricalDays As Integer = 20

			m_LineSMA = New NLineSeries()

			If m_Chart IsNot Nothing Then
				' first clear all series
				m_Chart.Series.Clear()
				' create a line series for the simple moving average			
				m_Chart.Series.Add(m_LineSMA)
			End If
			m_LineSMA.Name = "SMA(20)"
			m_LineSMA.DataLabelStyle.Visible = False
			m_LineSMA.BorderStyle.Color = Color.DarkOrange
			m_LineSMA.UseXValues = True

			' create the stock series
			m_Stock = New NStockSeries()

			If m_Chart IsNot Nothing Then
				m_Chart.Series.Add(m_Stock)
				m_Stock.DisplayOnAxis(StandardAxis.PrimaryX, True)
			End If

			m_Stock.Name = "Stock Data"
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Bar
			m_Stock.CandleWidth = New NLength(0.8F, NRelativeUnit.ParentPercentage)
			m_Stock.InflateMargins = True
			m_Stock.UseXValues = True
			m_Stock.UpFillStyle = New NColorFillStyle(Green)
			m_Stock.UpStrokeStyle.Color = Color.Black
			m_Stock.DownFillStyle = New NColorFillStyle(Red)
			m_Stock.DownStrokeStyle.Color = Color.Black
			m_Stock.OpenValues.Name = "open"
			m_Stock.CloseValues.Name = "close"
			m_Stock.HighValues.Name = "high"
			m_Stock.LowValues.Name = "low"

			Dim period As Integer = 20

			' add the bollinger bands as high low area
			m_HighLow = New NHighLowSeries()
			If m_Chart IsNot Nothing Then
				m_Chart.Series.Add(m_HighLow)
				m_HighLow.DisplayOnAxis(StandardAxis.SecondaryX, True)
			End If
			m_HighLow.Name = "BB(" & period.ToString() & ", 2)"
			m_HighLow.DataLabelStyle.Visible = False
			m_HighLow.HighFillStyle = New NColorFillStyle(Color.FromArgb(80, 130, 134, 168))
			m_HighLow.HighBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

			m_HighLow.UseXValues = True

			' generate some stock data
			GenerateData(m_Stock, 300, nTotalWorkDays + nHistoricalDays)

			' create a function calculator
			Dim fc As New NFunctionCalculator()
			fc.Arguments.Add(m_Stock.CloseValues)

			' calculate the bollinger bands
			fc.Expression = "BOLLINGER(close;" & period.ToString() & "; 2)"
			m_HighLow.HighValues = fc.Calculate()
			m_HighLow.HighValues.Name = "BollingerUpper"

			fc.Expression = "BOLLINGER(close; " & period.ToString() & "; -2)"
			m_HighLow.LowValues = fc.Calculate()
			m_HighLow.LowValues.Name = "BollingerLower"
			m_HighLow.XValues.InsertRange(0, m_Stock.XValues)

			' calculate the simple moving average
			fc.Expression = "SMA(close; " & period.ToString() & ")"
			m_LineSMA.Values = fc.Calculate()
			m_LineSMA.XValues.InsertRange(0, m_Stock.XValues)

			' remove first period from line SMA
			m_LineSMA.Values.RemoveRange(0, period)
			m_LineSMA.XValues.RemoveRange(0, period)

			' remove first period from high low
			m_HighLow.XValues.RemoveRange(0, period)
			m_HighLow.HighValues.RemoveRange(0, period)
			m_HighLow.LowValues.RemoveRange(0, period)

			' remove first period from stock
			m_Stock.OpenValues.RemoveRange(0, period)
			m_Stock.HighValues.RemoveRange(0, period)
			m_Stock.LowValues.RemoveRange(0, period)
			m_Stock.CloseValues.RemoveRange(0, period)
			m_Stock.XValues.RemoveRange(0, period)
		End Sub

		Private Sub GenerateData(ByVal s As NStockSeries, ByVal dPrevClose As Double, ByVal nCount As Integer)
			Dim now As Date = Date.Now
			Dim timeline As NTimeline = m_Calendar.CreateTimeline(New NDateTimeRange(now, now.Add(New TimeSpan(730, 0, 0, 0, 0))))
			Dim open, high, low, close As Double

			s.ClearDataPoints()

			For nIndex As Integer = 0 To nCount - 1
				open = dPrevClose

				If dPrevClose < 25 OrElse Random.NextDouble() > 0.5 Then
					' upward price change
					close = open + (2 + (Random.NextDouble() * 20))
					high = close + (Random.NextDouble() * 10)
					low = open - (Random.NextDouble() * 10)
				Else
					' downward price change
					close = open - (2 + (Random.NextDouble() * 20))
					high = open + (Random.NextDouble() * 10)
					low = close - (Random.NextDouble() * 10)
				End If

				If low < 1 Then
					low = 1
				End If

				dPrevClose = close

				s.OpenValues.Add(open)
				s.HighValues.Add(high)
				s.LowValues.Add(low)
				s.CloseValues.Add(close)
				s.XValues.Add(now.ToOADate())

				' advance to next working day
				now = timeline.AddTimeSpan(now, New NDateTimeSpan(1, NDateTimeUnit.Day))
			Next nIndex
		End Sub

		Private Sub MondayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MondayCheckBox.CheckedChanged
			CreateWorkCalendar()
		End Sub

		Private Sub TuesdayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TuesdayCheckBox.CheckedChanged
			CreateWorkCalendar()
		End Sub

		Private Sub WednesdayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles WednesdayCheckBox.CheckedChanged
			CreateWorkCalendar()
		End Sub

		Private Sub ThursdayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ThursdayCheckBox.CheckedChanged
			CreateWorkCalendar()
		End Sub

		Private Sub FridayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FridayCheckBox.CheckedChanged
			CreateWorkCalendar()
		End Sub

		Private Sub SaturdayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SaturdayCheckBox.CheckedChanged
			CreateWorkCalendar()
		End Sub

		Private Sub SundayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SundayCheckBox.CheckedChanged
			CreateWorkCalendar()
		End Sub

		Private Sub EnableWeekRuleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableWeekRuleCheckBox.CheckedChanged
			CreateWorkCalendar()
			WorkingDaysGroupBox.Enabled = EnableWeekRuleCheckBox.Checked
		End Sub

		Private Sub MonthDayUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MonthDayUpDown.ValueChanged
			CreateWorkCalendar()
		End Sub

		Private Sub EnableMonthDayRuleCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableMonthDayRuleCheckBox.CheckedChanged
			CreateWorkCalendar()
			MonthDayUpDown.Enabled = EnableMonthDayRuleCheckBox.Checked
			WorkRadioButton.Enabled = EnableMonthDayRuleCheckBox.Checked
			RestRadioButton.Enabled = EnableMonthDayRuleCheckBox.Checked
		End Sub

		Private Sub WorkRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles WorkRadioButton.CheckedChanged
			CreateWorkCalendar()
		End Sub

		Private Sub RestRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RestRadioButton.CheckedChanged
			CreateWorkCalendar()
		End Sub

		Private Sub ZoomToFirst7DaysButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ZoomToFirst7DaysButton.Click
			Dim dt As Date = Date.FromOADate(DirectCast(m_Stock.XValues(0), Double))
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(New NRange1DD(dt.ToOADate(), (dt.Add(New TimeSpan(7, 0, 0, 0))).ToOADate()), 0.00001)
			nChartControl1.Refresh()
		End Sub

		Private Sub ZoomToFirst30DaysButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ZoomToFirst30DaysButton.Click
			Dim dt As Date = Date.FromOADate(DirectCast(m_Stock.XValues(0), Double))
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView.ZoomIn(New NRange1DD(dt.ToOADate(), (dt.Add(New TimeSpan(30, 0, 0, 0))).ToOADate()), 0.00001)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
