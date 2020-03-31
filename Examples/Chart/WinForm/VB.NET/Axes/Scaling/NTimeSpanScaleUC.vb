Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NTimeSpanScaleUC
		Inherits NExampleBaseUC

		Private m_Line As NLineSeries
		Private m_TimeSpan As TimeSpan
		Private m_Random As Random
		Private WithEvents DayCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents WeekCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_TimeSpanScale As NTimeSpanScaleConfigurator
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private AllowedUnitsGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents EnableUnitSensitiveFormattingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents StartStopTimerButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents MillisecondCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents SecondCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents MinuteCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents HourCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents timer1 As System.Windows.Forms.Timer
		Private StepUnitComboBox As UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private StepCountUpDown As UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ClearDataButton As UI.WinForm.Controls.NButton
		Private components As IContainer

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
			m_Random = New Random()
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
			Me.components = New System.ComponentModel.Container()
			Me.DayCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.WeekCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.AllowedUnitsGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.HourCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SecondCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MinuteCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.MillisecondCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableUnitSensitiveFormattingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.StartStopTimerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.timer1 = New System.Windows.Forms.Timer(Me.components)
			Me.StepUnitComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.StepCountUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ClearDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.AllowedUnitsGroupBox.SuspendLayout()
			DirectCast(Me.StepCountUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' DayCheckBox
			' 
			Me.DayCheckBox.ButtonProperties.BorderOffset = 2
			Me.DayCheckBox.Location = New System.Drawing.Point(16, 76)
			Me.DayCheckBox.Name = "DayCheckBox"
			Me.DayCheckBox.Size = New System.Drawing.Size(104, 24)
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
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(0, 0)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(100, 23)
			Me.label3.TabIndex = 0
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(0, 0)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(100, 23)
			Me.label2.TabIndex = 0
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 23)
			Me.label1.TabIndex = 0
			' 
			' AllowedUnitsGroupBox
			' 
			Me.AllowedUnitsGroupBox.Controls.Add(Me.HourCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.SecondCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.MinuteCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.MillisecondCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.WeekCheckBox)
			Me.AllowedUnitsGroupBox.Controls.Add(Me.DayCheckBox)
			Me.AllowedUnitsGroupBox.ImageIndex = 0
			Me.AllowedUnitsGroupBox.Location = New System.Drawing.Point(8, 0)
			Me.AllowedUnitsGroupBox.Name = "AllowedUnitsGroupBox"
			Me.AllowedUnitsGroupBox.Size = New System.Drawing.Size(240, 109)
			Me.AllowedUnitsGroupBox.TabIndex = 0
			Me.AllowedUnitsGroupBox.TabStop = False
			Me.AllowedUnitsGroupBox.Text = "Allowed Date Time Units"
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
			Me.MinuteCheckBox.Size = New System.Drawing.Size(104, 24)
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
			Me.MillisecondCheckBox.Size = New System.Drawing.Size(104, 24)
			Me.MillisecondCheckBox.TabIndex = 0
			Me.MillisecondCheckBox.Text = "Millisecond"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MillisecondCheckBox.CheckedChanged += new System.EventHandler(this.MillisecondCheckBox_CheckedChanged);
			' 
			' EnableUnitSensitiveFormattingCheckBox
			' 
			Me.EnableUnitSensitiveFormattingCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableUnitSensitiveFormattingCheckBox.Location = New System.Drawing.Point(8, 115)
			Me.EnableUnitSensitiveFormattingCheckBox.Name = "EnableUnitSensitiveFormattingCheckBox"
			Me.EnableUnitSensitiveFormattingCheckBox.Size = New System.Drawing.Size(200, 24)
			Me.EnableUnitSensitiveFormattingCheckBox.TabIndex = 1
			Me.EnableUnitSensitiveFormattingCheckBox.Text = "Enable Unit Sensitive Formatting"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableUnitSensitiveFormattingCheckBox.CheckedChanged += new System.EventHandler(this.EnableUnitSensitiveFormattingCheckBox_CheckedChanged);
			' 
			' StartStopTimerButton
			' 
			Me.StartStopTimerButton.Location = New System.Drawing.Point(8, 174)
			Me.StartStopTimerButton.Name = "StartStopTimerButton"
			Me.StartStopTimerButton.Size = New System.Drawing.Size(232, 23)
			Me.StartStopTimerButton.TabIndex = 3
			Me.StartStopTimerButton.Text = "Stop Timer"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StartStopTimerButton.Click += new System.EventHandler(this.StartStopTimerButton_Click);
			' 
			' timer1
			' 
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			' 
			' StepUnitComboBox
			' 
			Me.StepUnitComboBox.ListProperties.CheckBoxDataMember = ""
			Me.StepUnitComboBox.ListProperties.DataSource = Nothing
			Me.StepUnitComboBox.ListProperties.DisplayMember = ""
			Me.StepUnitComboBox.Location = New System.Drawing.Point(124, 212)
			Me.StepUnitComboBox.Name = "StepUnitComboBox"
			Me.StepUnitComboBox.Size = New System.Drawing.Size(116, 21)
			Me.StepUnitComboBox.TabIndex = 6
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(5, 210)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(41, 23)
			Me.label4.TabIndex = 4
			Me.label4.Text = "Step:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' StepCountUpDown
			' 
			Me.StepCountUpDown.Location = New System.Drawing.Point(52, 213)
			Me.StepCountUpDown.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.StepCountUpDown.Name = "StepCountUpDown"
			Me.StepCountUpDown.Size = New System.Drawing.Size(66, 20)
			Me.StepCountUpDown.TabIndex = 5
			Me.StepCountUpDown.Value = New Decimal(New Integer() { 1, 0, 0, 0})
			' 
			' ClearDataButton
			' 
			Me.ClearDataButton.Location = New System.Drawing.Point(8, 145)
			Me.ClearDataButton.Name = "ClearDataButton"
			Me.ClearDataButton.Size = New System.Drawing.Size(232, 23)
			Me.ClearDataButton.TabIndex = 2
			Me.ClearDataButton.Text = "Clear Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
			' 
			' NTimeSpanScaleUC
			' 
			Me.Controls.Add(Me.ClearDataButton)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.StepCountUpDown)
			Me.Controls.Add(Me.StepUnitComboBox)
			Me.Controls.Add(Me.StartStopTimerButton)
			Me.Controls.Add(Me.EnableUnitSensitiveFormattingCheckBox)
			Me.Controls.Add(Me.AllowedUnitsGroupBox)
			Me.Name = "NTimeSpanScaleUC"
			Me.Size = New System.Drawing.Size(256, 416)
			Me.AllowedUnitsGroupBox.ResumeLayout(False)
			DirectCast(Me.StepCountUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Time Span Scale")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch

			' add a range selection, snapped to the vertical axis min/max values
			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			chart.RangeSelections.Add(rangeSelection)

			' add interlaced stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' Add a line series
			m_Line = New NLineSeries()
			chart.Series.Add(m_Line)

			m_Line.UseXValues = True

			m_Line.UseXValues = True
			m_Line.DataLabelStyle.Visible = False
			m_Line.SamplingMode = SeriesSamplingMode.Enabled

			' create a date time scale
			m_TimeSpanScale = New NTimeSpanScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = m_TimeSpanScale

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			Dim xAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			xAxis.ScrollBar.Visible = True

			' init form controls
			EnableUnitSensitiveFormattingCheckBox.Checked = True
			MillisecondCheckBox.Checked = True
			SecondCheckBox.Checked = True
			MinuteCheckBox.Checked = True
			HourCheckBox.Checked = True
			DayCheckBox.Checked = True
			WeekCheckBox.Checked = True

			UpdateDateTimeScale()

			StepUnitComboBox.Items.Add("Millisecond")
			StepUnitComboBox.Items.Add("Second")
			StepUnitComboBox.Items.Add("Minute")
			StepUnitComboBox.Items.Add("Hour")
			StepUnitComboBox.Items.Add("Day")
			StepUnitComboBox.Items.Add("Week")
			StepUnitComboBox.SelectedIndex = 2

			timer1.Start()
			nChartControl1.Refresh()
		End Sub

		Private Sub UpdateDateTimeScale()
			If m_TimeSpanScale Is Nothing Then
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

			Dim autoUnits(dateTimeUnits.Count - 1) As NTimeUnit
			For i As Integer = 0 To autoUnits.Length - 1
				autoUnits(i) = DirectCast(dateTimeUnits(i), NTimeUnit)
			Next i

			m_TimeSpanScale.EnableUnitSensitiveFormatting = EnableUnitSensitiveFormattingCheckBox.Checked

			m_TimeSpanScale.AutoDateTimeUnits = autoUnits
			nChartControl1.Refresh()
		End Sub

		Private Sub DayCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DayCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub WeekCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WeekCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub

		Private Sub MonthCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateDateTimeScale()
		End Sub

		Private Sub QuarterCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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

		Private Sub HalfYearCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateDateTimeScale()
		End Sub

		Private Sub YearCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateDateTimeScale()
		End Sub

		Private Sub DecadeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateDateTimeScale()
		End Sub

		Private Sub CenturyCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateDateTimeScale()
		End Sub

		Private Sub EnableUnitSensitiveFormattingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableUnitSensitiveFormattingCheckBox.CheckedChanged
			UpdateDateTimeScale()
		End Sub


		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timer1.Tick
			Dim [step] As New TimeSpan()
			Select Case StepUnitComboBox.SelectedIndex
				Case 0 ' Millisecond
					[step] = New TimeSpan(0, 0, 0, 0, CInt(Math.Truncate(StepCountUpDown.Value)))
				Case 1 ' Second
					[step] = New TimeSpan(0, 0, CInt(Math.Truncate(StepCountUpDown.Value)))
				Case 2 ' Minute
					[step] = New TimeSpan(0, CInt(Math.Truncate(StepCountUpDown.Value)), 0)
				Case 3 ' Hour
					[step] = New TimeSpan(CInt(Math.Truncate(StepCountUpDown.Value)), 0, 0)
				Case 4 ' Day
					[step] = New TimeSpan(CInt(Math.Truncate(StepCountUpDown.Value)), 0, 0, 0)
				Case 5 ' Week
					[step] = New TimeSpan(7 * CInt(Math.Truncate(StepCountUpDown.Value)), 0, 0, 0)
			End Select

			m_TimeSpan = m_TimeSpan.Add([step])

			m_Line.XValues.Add(m_TimeSpan)
			m_Line.Values.Add(m_Random.Next(100))

			If m_Line.Values.Count > 1000 Then
				m_Line.Values.RemoveAt(0)
				m_Line.XValues.RemoveAt(0)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub StartStopTimerButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartStopTimerButton.Click
			If timer1.Enabled Then
				m_TimeSpan = New TimeSpan()
				timer1.Stop()
				StartStopTimerButton.Text = "Start Timer"
			Else
				timer1.Start()
				StartStopTimerButton.Text = "Stop Timer"
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ClearDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ClearDataButton.Click
			m_Line.Values.Clear()
			m_Line.XValues.Clear()

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
