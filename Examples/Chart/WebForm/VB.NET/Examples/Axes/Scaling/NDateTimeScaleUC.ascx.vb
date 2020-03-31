Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Globalization
Imports System.Collections

Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm


Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDateTimeScaleUC
		Inherits NExampleUC

		Private m_Chart As NChart
		Private m_DateTimeScale As NDateTimeScaleConfigurator

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Date Time Scale")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' add a strip line style
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale

			' create line serie and dispay them on vertical axis
			Dim line1 As NLineSeries = CreateLineSeries(Color.Red, Color.DarkRed)

			Dim dateTimeScale As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()

			m_DateTimeScale = dateTimeScale
			m_DateTimeScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 90)
			m_DateTimeScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale

			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(85, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			If (Not IsPostBack) Then
				'set the begin date to today;
				StartDateCalendar.SelectedDate = DateTime.Today

				'set the end date to a date two years from now
				EndDateCalendar.VisibleDate = CultureInfo.CurrentCulture.Calendar.AddYears(StartDateCalendar.SelectedDate, 2)
				EndDateCalendar.SelectedDate = CultureInfo.CurrentCulture.Calendar.AddYears(StartDateCalendar.SelectedDate, 2)
				EnableUnitSensitiveFormattingCheckBox.Checked = True
			End If

			UpdateDateTimeScale()
			UpdateTimeSpan()

		End Sub

		Private Sub UpdateDateTimeScale()
			If m_DateTimeScale Is Nothing Then
				Return
			End If

			Dim dateTimeUnits As ArrayList = New ArrayList()
			dateTimeUnits.Add(NDateTimeUnit.Day)
			dateTimeUnits.Add(NDateTimeUnit.Week)
			dateTimeUnits.Add(NDateTimeUnit.Month)
			dateTimeUnits.Add(NDateTimeUnit.Quarter)
			dateTimeUnits.Add(NDateTimeUnit.Year)

			Dim autoUnits As NDateTimeUnit() = New NDateTimeUnit(dateTimeUnits.Count - 1){}
			Dim i As Integer = 0
			Do While i < autoUnits.Length
				autoUnits(i) = CType(dateTimeUnits(i), NDateTimeUnit)
				i += 1
			Loop
			m_DateTimeScale.EnableUnitSensitiveFormatting = EnableUnitSensitiveFormattingCheckBox.Checked
			m_DateTimeScale.AutoDateTimeUnits = autoUnits
		End Sub


		Private Function CreateLineSeries(ByVal lightColor As Color, ByVal darkColor As Color) As NLineSeries
			Dim line As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)

			line.UseXValues = True

			line.Name = "Line 1"
			line.BorderStyle.Color = darkColor
			line.DataLabelStyle.Visible = False
			line.InflateMargins = True
			line.MarkerStyle.Visible = True
			line.MarkerStyle.BorderStyle.Color = darkColor
			line.MarkerStyle.FillStyle = New NColorFillStyle(lightColor)
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(2, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(2, NRelativeUnit.ParentPercentage)

			Return line
		End Function

		Private Sub UpdateTimeSpan()
			Dim startDate As DateTime = StartDateCalendar.SelectedDate
			Dim endDate As DateTime = EndDateCalendar.SelectedDate

			If startDate > endDate Then
				Dim temp As DateTime = startDate

				startDate = endDate
				endDate = temp
			End If

			' Get the line series from the chart
			Dim line As NLineSeries = CType(m_Chart.Series(0), NLineSeries)

			Dim span As TimeSpan = endDate.Subtract(startDate)
			span = New TimeSpan(span.Ticks / 30)

			line.Values.Clear()
			line.XValues.Clear()

			If span.Ticks > 0 Then
				Do While startDate < endDate
					line.XValues.Add(startDate)
					startDate = startDate.Add(span)

					line.Values.Add(Random.Next(100))
				Loop
			End If
		End Sub

		Protected Sub StartDateCalendar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateTimeSpan()
		End Sub

		Protected Sub EndDateCalendar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			UpdateTimeSpan()
		End Sub
	End Class
End Namespace
