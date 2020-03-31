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
	Public Class NDailyScheduleWorkCalendarUC
		Inherits NExampleBaseUC

		Public Sub New()
			InitializeComponent()
		End Sub

		Private WithEvents EnableWorkCalendar As UI.WinForm.Controls.NCheckBox

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
			Me.EnableWorkCalendar = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' EnableWorkCalendar
			' 
			Me.EnableWorkCalendar.ButtonProperties.BorderOffset = 2
			Me.EnableWorkCalendar.Location = New System.Drawing.Point(14, 17)
			Me.EnableWorkCalendar.Name = "EnableWorkCalendar"
			Me.EnableWorkCalendar.Size = New System.Drawing.Size(200, 24)
			Me.EnableWorkCalendar.TabIndex = 2
			Me.EnableWorkCalendar.Text = "Enable Work Calendar"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableWorkCalendar.CheckedChanged += new System.EventHandler(this.EnableWorkCalendar_CheckedChanged);
			' 
			' NDailyScheduleWorkCalendarUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.EnableWorkCalendar)
			Me.Name = "NDailyScheduleWorkCalendarUC"
			Me.Size = New System.Drawing.Size(231, 457)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Daily Workload in Percents<br/><font size = '9pt'>Demonstrates how to skip hours in the working days, per day using the daily schedule object</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			nChartControl1.Panels.Add(title)

			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.BoundsMode = BoundsMode.Stretch

			Dim rangeSelection As New NRangeSelection()
			rangeSelection.VerticalValueSnapper = New NAxisRulerMinMaxSnapper()
			chart.RangeSelections.Add(rangeSelection)
			chart.BoundsMode = BoundsMode.Stretch

			Dim ranges As New NRangeSeries()
			ranges.DataLabelStyle.Visible = False
			ranges.UseXValues = True

			Dim dt As New Date(2014, 4, 14)
			Dim rand As New Random()

			Dim rangeTimeline As New NRangeTimelineScaleConfigurator()
			rangeTimeline.EnableCalendar = True
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = rangeTimeline
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True

			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Daily Workload in %"
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(0, 100), True, True)

			Dim workCalendar As NWorkCalendar = rangeTimeline.Calendar
			Dim dateTimeRangeRule As NDateTimeRangeRule = Nothing

			For i As Integer = 0 To 119
				Dim hourOfTheDay As Integer = i Mod 24
				If hourOfTheDay < 8 OrElse hourOfTheDay > 18 Then
					Dim curDate As New Date(dt.Year, dt.Month, dt.Day, 0, 0, 0)

					If dateTimeRangeRule IsNot Nothing Then
						If dateTimeRangeRule.Range.Begin <> curDate Then
							dateTimeRangeRule = Nothing
						End If
					End If

					If dateTimeRangeRule Is Nothing Then
						dateTimeRangeRule = New NDateTimeRangeRule(New NDateTimeRange(curDate, curDate.Add(New TimeSpan(24, 0, 0))), True)
						workCalendar.Rules.Add(dateTimeRangeRule)
					End If

					dateTimeRangeRule.Schedule.SetHourRange(dt.Hour, dt.Hour + 1, True)
				Else
					ranges.Values.Add(0)
					ranges.Y2Values.Add(rand.NextDouble() * 70 + 30.0R)
					ranges.XValues.Add((dt.Add(New TimeSpan(1, 0, 0))).ToOADate())
					ranges.X2Values.Add(dt.ToOADate())
				End If

				dt = dt.Add(New TimeSpan(1, 0, 0))
			Next i

			chart.Series.Add(ranges)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			nChartControl1.Controller.Tools.Add(New NSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())
			nChartControl1.Controller.Tools.Add(New NDataPanTool())

			' init form controls
			EnableWorkCalendar.Checked = True
		End Sub

		Private Sub EnableWorkCalendar_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableWorkCalendar.CheckedChanged
			Dim scaleX As NRangeTimelineScaleConfigurator = TryCast(nChartControl1.Charts(0).Axis(StandardAxis.PrimaryX).ScaleConfigurator, NRangeTimelineScaleConfigurator)

			If scaleX IsNot Nothing Then
				scaleX.EnableCalendar = EnableWorkCalendar.Checked
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
