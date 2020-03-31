Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NTimeSpanScaleUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Date Time Scale")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' add a strip line style
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale

			' create line serie and dispay them on vertical axis
			Dim line As NLineSeries = New NLineSeries()
			chart.Series.Add(line)

			line.UseXValues = True
			line.Name = "Line"
			line.DataLabelStyle.Visible = False
			line.InflateMargins = True

			Dim timeSpanScale As NTimeSpanScaleConfigurator = New NTimeSpanScaleConfigurator()
			timeSpanScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 90)
			timeSpanScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeSpanScale

			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(85, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			If (Not IsPostBack) Then
				SampleTimeRangeDropDownList.Items.Add("Milliseconds")
				SampleTimeRangeDropDownList.Items.Add("Seconds")
				SampleTimeRangeDropDownList.Items.Add("Minutes")
				SampleTimeRangeDropDownList.Items.Add("Hours")
				SampleTimeRangeDropDownList.Items.Add("Days")
				SampleTimeRangeDropDownList.Items.Add("Weeks")
				SampleTimeRangeDropDownList.SelectedIndex = 2 ' minutes
				EnableUnitSensitiveFormattingCheckBox.Checked = True
			End If

			UpdateTimeSpanScale(timeSpanScale)
			FillDummyData(line)
		End Sub

		Private Sub UpdateTimeSpanScale(ByVal timeSpanScale As NTimeSpanScaleConfigurator)
			Dim timeUnits As List(Of NTimeUnit) = New List(Of NTimeUnit)()

			If MillisecondCheckBox.Checked Then
				timeUnits.Add(NTimeUnit.Millisecond)
			End If

			If SecondCheckBox.Checked Then
				timeUnits.Add(NTimeUnit.Second)
			End If

			If MinuteCheckBox.Checked Then
				timeUnits.Add(NTimeUnit.Minute)
			End If

			If HourCheckBox.Checked Then
				timeUnits.Add(NTimeUnit.Hour)
			End If

			If DayCheckBox.Checked Then
				timeUnits.Add(NTimeUnit.Day)
			End If

			If WeekCheckBox.Checked Then
				timeUnits.Add(NTimeUnit.Week)
			End If

			timeSpanScale.EnableUnitSensitiveFormatting = EnableUnitSensitiveFormattingCheckBox.Checked
			timeSpanScale.AutoDateTimeUnits = timeUnits.ToArray()
		End Sub


		Private Sub FillDummyData(ByVal line As NLineSeries)
			Dim timeUnit As NTimeUnit

			Select Case SampleTimeRangeDropDownList.SelectedIndex
				Case 0 ' Milliseconds
					timeUnit = NTimeUnit.Millisecond
				Case 1 ' Seconds
					timeUnit = NTimeUnit.Second
				Case 2 ' Minutes
					timeUnit = NTimeUnit.Minute
				Case 3 ' Hours
					timeUnit = NTimeUnit.Hour
				Case 4 ' Days
					timeUnit = NTimeUnit.Day
				Case 5 ' Weeks
					timeUnit = NTimeUnit.Week
				Case Else
					timeUnit = NTimeUnit.Day
			End Select

			Dim random As Random = New Random()

			Dim spanCount As Integer = 50 + random.Next(200)
			Dim begin As TimeSpan = New TimeSpan(0)
			Dim [end] As TimeSpan = timeUnit.Add(begin, spanCount)

			Dim current As TimeSpan = begin

			Do While current <= [end]
				line.Values.Add(random.Next(100) + 30)
				line.XValues.Add(current)
				current = timeUnit.Add(current, 1)
			Loop
		End Sub
	End Class
End Namespace
