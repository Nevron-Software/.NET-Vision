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
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDateTimeScaleUC
		Inherits NExampleBaseUC

		Private m_Chart As NCartesianChart
		Private WithEvents DayCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents WeekCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MonthCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents QuarterCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_DateTimeScale As NDateTimeScaleConfigurator
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private AllowedUnitsGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents EnableUnitSensitiveFormattingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents GenerateDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents StartDateTimePicker As Nevron.UI.WinForm.Controls.NDateTimePicker
		Private WithEvents EndDateTimePicker As Nevron.UI.WinForm.Controls.NDateTimePicker
		Private WithEvents MillisecondCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SecondCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MinuteCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HourCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HalfYearCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents YearCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents DecadeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents CenturyCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
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
			Me.DayCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.WeekCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MonthCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.QuarterCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.AllowedUnitsGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.CenturyCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.DecadeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.YearCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HalfYearCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.HourCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SecondCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MinuteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MillisecondCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableUnitSensitiveFormattingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.StartDateTimePicker = New Nevron.UI.WinForm.Controls.NDateTimePicker()
			Me.EndDateTimePicker = New Nevron.UI.WinForm.Controls.NDateTimePicker()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.GenerateDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.AllowedUnitsGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' DayCheckBox
			' 
			Me.DayCheckBox.ButtonProperties.BorderOffset = 2
			Me.DayCheckBox.Location = New System.Drawing.Point(16, 76)
			Me.DayCheckBox.Name = "DayCheckBox"
			Me.DayCheckBox.TabIndex = 4
			Me.DayCheckBox.Text = "Day"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DayCheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
			' 
			' WeekCheckBox
			' 
			Me.WeekCheckBox.ButtonProperties.BorderOffset = 2
			Me.WeekCheckBox.Location = New System.Drawing.Point(136, 76)
			Me.WeekCheckBox.Name = "WeekCheckBox"
			Me.WeekCheckBox.Size = New System.Drawing.Size(80, 24)
			Me.WeekCheckBox.TabIndex = 5
			Me.WeekCheckBox.Text = "Week"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WeekCheckBox.CheckedChanged += new System.EventHandler(this.WeekCheckBox_CheckedChanged);
			' 
			' MonthCheckBox
			' 
			Me.MonthCheckBox.ButtonProperties.BorderOffset = 2
			Me.MonthCheckBox.Location = New System.Drawing.Point(16, 106)
			Me.MonthCheckBox.Name = "MonthCheckBox"
			Me.MonthCheckBox.TabIndex = 6
			Me.MonthCheckBox.Text = "Month"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MonthCheckBox.CheckedChanged += new System.EventHandler(this.MonthCheckBox_CheckedChanged);
			' 
			' QuarterCheckBox
			' 
			Me.QuarterCheckBox.ButtonProperties.BorderOffset = 2
			Me.QuarterCheckBox.Location = New System.Drawing.Point(136, 106)
			Me.QuarterCheckBox.Name = "QuarterCheckBox"
			Me.QuarterCheckBox.Size = New System.Drawing.Size(80, 24)
			Me.QuarterCheckBox.TabIndex = 7
			Me.QuarterCheckBox.Text = "Quarter"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.QuarterCheckBox.CheckedChanged += new System.EventHandler(this.QuarterCheckBox_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(0, 0)
			Me.label3.Name = "label3"
			Me.label3.TabIndex = 0
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(0, 0)
			Me.label2.Name = "label2"
			Me.label2.TabIndex = 0
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.TabIndex = 0
			' 
			' AllowedUnitsGroupBox
			' 
			Me.AllowedUnitsGroupBox.Controls.Add(Me.CenturyCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.DecadeCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.YearCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.HalfYearCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.HourCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.SecondCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.MinuteCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.MillisecondCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.QuarterCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.MonthCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.WeekCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.DayCheckBox)
			Me.AllowedUnitsGroupBox.ImageIndex = 0
			Me.AllowedUnitsGroupBox.Location = New System.Drawing.Point(8, 0)
			Me.AllowedUnitsGroupBox.Name = "AllowedUnitsGroupBox"
			Me.AllowedUnitsGroupBox.Size = New System.Drawing.Size(240, 200)
			Me.AllowedUnitsGroupBox.TabIndex = 0
			Me.AllowedUnitsGroupBox.TabStop = False
			Me.AllowedUnitsGroupBox.Text = "Allowed Date Time Units"
			' 
			' CenturyCheckBox
			' 
			Me.CenturyCheckBox.ButtonProperties.BorderOffset = 2
			Me.CenturyCheckBox.Location = New System.Drawing.Point(136, 166)
			Me.CenturyCheckBox.Name = "CenturyCheckBox"
			Me.CenturyCheckBox.Size = New System.Drawing.Size(80, 24)
			Me.CenturyCheckBox.TabIndex = 11
			Me.CenturyCheckBox.Text = "Century"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CenturyCheckBox.CheckedChanged += new System.EventHandler(this.CenturyCheckBox_CheckedChanged);
			' 
			' DecadeCheckBox
			' 
			Me.DecadeCheckBox.ButtonProperties.BorderOffset = 2
			Me.DecadeCheckBox.Location = New System.Drawing.Point(16, 166)
			Me.DecadeCheckBox.Name = "DecadeCheckBox"
			Me.DecadeCheckBox.TabIndex = 10
			Me.DecadeCheckBox.Text = "Decade"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DecadeCheckBox.CheckedChanged += new System.EventHandler(this.DecadeCheckBox_CheckedChanged);
			' 
			' YearCheckBox
			' 
			Me.YearCheckBox.ButtonProperties.BorderOffset = 2
			Me.YearCheckBox.Location = New System.Drawing.Point(136, 136)
			Me.YearCheckBox.Name = "YearCheckBox"
			Me.YearCheckBox.Size = New System.Drawing.Size(80, 24)
			Me.YearCheckBox.TabIndex = 9
			Me.YearCheckBox.Text = "Year"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YearCheckBox.CheckedChanged += new System.EventHandler(this.YearCheckBox_CheckedChanged);
			' 
			' HalfYearCheckBox
			' 
			Me.HalfYearCheckBox.ButtonProperties.BorderOffset = 2
			Me.HalfYearCheckBox.Location = New System.Drawing.Point(16, 136)
			Me.HalfYearCheckBox.Name = "HalfYearCheckBox"
			Me.HalfYearCheckBox.TabIndex = 8
			Me.HalfYearCheckBox.Text = "Half Year"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HalfYearCheckBox.CheckedChanged += new System.EventHandler(this.HalfYearCheckBox_CheckedChanged);
			' 
			' HourCheckBox
			' 
			Me.HourCheckBox.ButtonProperties.BorderOffset = 2
			Me.HourCheckBox.Location = New System.Drawing.Point(136, 46)
			Me.HourCheckBox.Name = "HourCheckBox"
			Me.HourCheckBox.Size = New System.Drawing.Size(80, 24)
			Me.HourCheckBox.TabIndex = 3
			Me.HourCheckBox.Text = "Hour"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HourCheckBox.CheckedChanged += new System.EventHandler(this.HourCheckBox_CheckedChanged);
			' 
			' SecondCheckBox
			' 
			Me.SecondCheckBox.ButtonProperties.BorderOffset = 2
			Me.SecondCheckBox.Location = New System.Drawing.Point(136, 16)
			Me.SecondCheckBox.Name = "SecondCheckBox"
			Me.SecondCheckBox.Size = New System.Drawing.Size(80, 24)
			Me.SecondCheckBox.TabIndex = 1
			Me.SecondCheckBox.Text = "Second"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SecondCheckBox.CheckedChanged += new System.EventHandler(this.SecondCheckBox_CheckedChanged);
			' 
			' MinuteCheckBox
			' 
			Me.MinuteCheckBox.ButtonProperties.BorderOffset = 2
			Me.MinuteCheckBox.Location = New System.Drawing.Point(16, 46)
			Me.MinuteCheckBox.Name = "MinuteCheckBox"
			Me.MinuteCheckBox.TabIndex = 2
			Me.MinuteCheckBox.Text = "Minute"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MinuteCheckBox.CheckedChanged += new System.EventHandler(this.MinuteCheckBox_CheckedChanged);
			' 
			' MillisecondCheckBox
			' 
			Me.MillisecondCheckBox.ButtonProperties.BorderOffset = 2
			Me.MillisecondCheckBox.Location = New System.Drawing.Point(16, 16)
			Me.MillisecondCheckBox.Name = "MillisecondCheckBox"
			Me.MillisecondCheckBox.TabIndex = 0
			Me.MillisecondCheckBox.Text = "Millisecond"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MillisecondCheckBox.CheckedChanged += new System.EventHandler(this.MillisecondCheckBox_CheckedChanged);
			' 
			' EnableUnitSensitiveFormattingCheckBox
			' 
			Me.EnableUnitSensitiveFormattingCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableUnitSensitiveFormattingCheckBox.Location = New System.Drawing.Point(8, 208)
			Me.EnableUnitSensitiveFormattingCheckBox.Name = "EnableUnitSensitiveFormattingCheckBox"
			Me.EnableUnitSensitiveFormattingCheckBox.Size = New System.Drawing.Size(200, 24)
			Me.EnableUnitSensitiveFormattingCheckBox.TabIndex = 1
			Me.EnableUnitSensitiveFormattingCheckBox.Text = "Enable Unit Sensitive Formatting"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableUnitSensitiveFormattingCheckBox.CheckedChanged += new System.EventHandler(this.EnableUnitSensitiveFormattingCheckBox_CheckedChanged);
			' 
			' StartDateTimePicker
			' 
			Me.StartDateTimePicker.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.StartDateTimePicker.CalendarForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.StartDateTimePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb((CByte(235)), (CByte(235)), (CByte(235)))
			Me.StartDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb((CByte(76)), (CByte(76)), (CByte(76)))
			Me.StartDateTimePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb((CByte(242)), (CByte(242)), (CByte(242)))
			Me.StartDateTimePicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb((CByte(127)), (CByte(127)), (CByte(127)))
			Me.StartDateTimePicker.ForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.StartDateTimePicker.Location = New System.Drawing.Point(8, 264)
			Me.StartDateTimePicker.Name = "StartDateTimePicker"
			Me.StartDateTimePicker.Size = New System.Drawing.Size(232, 21)
			Me.StartDateTimePicker.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StartDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
			' 
			' EndDateTimePicker
			' 
			Me.EndDateTimePicker.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.EndDateTimePicker.CalendarForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.EndDateTimePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb((CByte(235)), (CByte(235)), (CByte(235)))
			Me.EndDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb((CByte(76)), (CByte(76)), (CByte(76)))
			Me.EndDateTimePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb((CByte(242)), (CByte(242)), (CByte(242)))
			Me.EndDateTimePicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb((CByte(127)), (CByte(127)), (CByte(127)))
			Me.EndDateTimePicker.ForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.EndDateTimePicker.Location = New System.Drawing.Point(8, 312)
			Me.EndDateTimePicker.Name = "EndDateTimePicker"
			Me.EndDateTimePicker.Size = New System.Drawing.Size(232, 21)
			Me.EndDateTimePicker.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EndDateTimePicker.ValueChanged += new System.EventHandler(this.EndDateTimePicker_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 240)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(64, 23)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Start date:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 288)
			Me.label5.Name = "label5"
			Me.label5.TabIndex = 4
			Me.label5.Text = "End date:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' GenerateDataButton
			' 
			Me.GenerateDataButton.Location = New System.Drawing.Point(8, 376)
			Me.GenerateDataButton.Name = "GenerateDataButton"
			Me.GenerateDataButton.Size = New System.Drawing.Size(232, 23)
			Me.GenerateDataButton.TabIndex = 6
			Me.GenerateDataButton.Text = "Generate Random Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
			' 
			' NDateTimeScaleUC
			' 
			Me.Controls.Add(Me.GenerateDataButton)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.EndDateTimePicker)
			Me.Controls.Add(Me.StartDateTimePicker)
			Me.Controls.Add(Me.EnableUnitSensitiveFormattingCheckBox)
			Me.Controls.Add(Me.AllowedUnitsGroupBox)
			Me.Name = "NDateTimeScaleUC"
			Me.Size = New System.Drawing.Size(256, 416)
			Me.AllowedUnitsGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Date Time Scale")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = CType(nChartControl1.Charts(0), NCartesianChart)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' add a range selection, snapped to the vertical axis min/max values
			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			m_Chart.RangeSelections.Add(rangeSelection)

			' add interlaced stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' Add a line series
			Dim line As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)

			line.UseXValues = True

			line.DataLabelStyle.Visible = False
			line.InflateMargins = True
			line.MarkerStyle.Visible = True
			line.MarkerStyle.BorderStyle.Color = Color.DarkRed
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(2, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(2, NRelativeUnit.ParentPercentage)

			' create a date time scale
			Dim dateTimeScale As New NDateTimeScaleConfigurator()

			m_DateTimeScale = dateTimeScale
			m_DateTimeScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.Scale, 90)
			m_DateTimeScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			Dim xAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			xAxis.ScrollBar.Visible = True

			' configure interactivity
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())

			' init form controls
			EndDateTimePicker.Value = CultureInfo.CurrentCulture.Calendar.AddYears(StartDateTimePicker.Value, 2)

			EnableUnitSensitiveFormattingCheckBox.Checked = True
			DayCheckBox.Checked = True
			WeekCheckBox.Checked = True
			MonthCheckBox.Checked = True
			QuarterCheckBox.Checked = True
			YearCheckBox.Checked = True

			UpdateDateTimeScale()
			GenerateDataButton_Click(Nothing, Nothing)

			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateDateTimeScale()
			If m_DateTimeScale Is Nothing Then
				Return
			End If

			Dim dateTimeUnits As New ArrayList()

			If MillisecondCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Millisecond)
			End If

			If SecondCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Second)
			End If

			If MinuteCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Minute)
			End If

			If HourCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Hour)
			End If

			If DayCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Day)
			End If

			If WeekCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Week)
			End If

			If MonthCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Month)
			End If

			If QuarterCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Quarter)
			End If

			If HalfYearCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.HalfYear)
			End If

			If YearCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Year)
			End If

			If DecadeCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Decade)
			End If

			If CenturyCheckBox.Checked Then
				dateTimeUnits.Add(NDateTimeUnit.Century)
			End If

			Dim autoUnits(dateTimeUnits.Count - 1) As NDateTimeUnit
			For i As Integer = 0 To autoUnits.Length - 1
				autoUnits(i) = DirectCast(dateTimeUnits(i), NDateTimeUnit)
			Next i

			m_DateTimeScale.EnableUnitSensitiveFormatting = EnableUnitSensitiveFormattingCheckBox.Checked

			m_DateTimeScale.AutoDateTimeUnits = autoUnits
			nChartControl1.Refresh()
		End Sub

		Private Sub DayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DayCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub WeekCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WeekCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub MonthCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonthCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub QuarterCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles QuarterCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub MillisecondCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MillisecondCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub SecondCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SecondCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub MinuteCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinuteCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub HourCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HourCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub HalfYearCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HalfYearCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub YearCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YearCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub DecadeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DecadeCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub CenturyCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CenturyCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub EnableUnitSensitiveFormattingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableUnitSensitiveFormattingCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub GenerateDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateDataButton.Click
			Dim startDate As Date = StartDateTimePicker.Value
			Dim endDate As Date = EndDateTimePicker.Value

			If startDate > endDate Then
				Dim temp As Date = startDate

				startDate = endDate
				endDate = temp
			End If

			' Get the line series from the chart
			Dim line As NLineSeries = CType(m_Chart.Series(0), NLineSeries)

			Dim span As TimeSpan = endDate.Subtract(startDate)
			span = New TimeSpan(span.Ticks \ 30)

			line.Values.Clear()
			line.XValues.Clear()

			If span.Ticks > 0 Then
				Do While startDate < endDate
					line.XValues.Add(startDate)
					startDate = startDate.Add(span)

					line.Values.Add(Random.Next(100))
				Loop
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub EndDateTimePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EndDateTimePicker.ValueChanged
			GenerateDataButton_Click(Nothing, Nothing)
		End Sub

		Private Sub StartDateTimePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartDateTimePicker.ValueChanged
			GenerateDataButton_Click(Nothing, Nothing)
		End Sub
	End Class
End Namespace
