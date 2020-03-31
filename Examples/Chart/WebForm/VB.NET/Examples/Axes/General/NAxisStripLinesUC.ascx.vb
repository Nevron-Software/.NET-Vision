Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Dom

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAxisStripLinesUC
		Inherits NExampleUC

		Private m_Chart As NChart

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not Page.IsPostBack) Then
				HighLightRangeDropDownList.Items.Add("Weekdays")
				HighLightRangeDropDownList.Items.Add("Weekends")
				HighLightRangeDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Strip Lines")
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(13, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(94, NRelativeUnit.ParentPercentage), New NLength(85, NRelativeUnit.ParentPercentage))

			' Add a line series
			Dim line As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			line.UseXValues = True
			line.BorderStyle.Color = Color.DarkRed
			line.DataLabelStyle.Visible = False
			line.InflateMargins = True
			line.MarkerStyle.Visible = True
			line.MarkerStyle.BorderStyle.Color = Color.DarkRed
			line.MarkerStyle.FillStyle = New NColorFillStyle(Color.Red)
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(2, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(2, NRelativeUnit.ParentPercentage)
			line.Legend.Mode = SeriesLegendMode.None

			' create a date time scale
			Dim dateTimeScale As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()

			dateTimeScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 90)
			dateTimeScale.LabelStyle.ContentAlignment = ContentAlignment.MiddleLeft
			dateTimeScale.EnableUnitSensitiveFormatting = False
			dateTimeScale.MajorTickMode = MajorTickMode.CustomStep
			dateTimeScale.CustomStep = New NDateTimeSpan(1, NDateTimeUnit.Day)
			dateTimeScale.LabelValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.WeekDayShortName)

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale

			' create a strip line highlighting the working days
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(125, Color.Orange)), Nothing, True, 0, 0, 2, 5)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)

			Dim provider As NDateTimeRangeSamplerProvider = New NDateTimeRangeSamplerProvider()
			provider.SamplingMode = SamplingMode.CustomStep
			provider.UseOrigin = True
			provider.Origin = New DateTime(2007, 2, 19)
			provider.CustomStep = New NDateTimeSpan(1, NDateTimeUnit.Day)
			stripStyle.RangeSamplerProvider = provider

			' configure the x axis to use date time paging 
			Dim dateTimePagingView As NDateTimeAxisPagingView = New NDateTimeAxisPagingView(DateTime.Now, New NDateTimeSpan(10, NDateTimeUnit.Day))
			dateTimePagingView.Enabled = True
			m_Chart.Axis(StandardAxis.PrimaryX).PagingView = dateTimePagingView

			GenerateData(Nothing, Nothing)

			If (Not Page.IsPostBack) Then
				HighLightRangeDropDownList.SelectedIndex = 0
			End If

			UpdateHighlightRange()
		End Sub

		Private Sub GenerateData(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim startDate As DateTime = DateTime.Now
			Dim endDate As DateTime = DateTime.Now.Add(New TimeSpan(30, 0, 0, 0, 0))

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

		Private Sub UpdateHighlightRange()
			Dim stripStyle As NScaleStripStyle
			Dim origin As DateTime

			' create a strip line highlighting the working days
			If HighLightRangeDropDownList.SelectedIndex = 0 Then
				origin = New DateTime(2007, 2, 19)
				stripStyle = New NScaleStripStyle(New NColorFillStyle(Color.SkyBlue), Nothing, True, 0, 0, 2, 5)
			Else
				origin = New DateTime(2007, 2, 17)
				stripStyle = New NScaleStripStyle(New NColorFillStyle(Color.LightSeaGreen), Nothing, True, 0, 0, 5, 2)
			End If

			stripStyle.SetShowAtWall(ChartWallType.Back, True)

			Dim scaleConfigurator As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleConfigurator.StripStyles.Clear()
			scaleConfigurator.StripStyles.Add(stripStyle)

			Dim provider As NDateTimeRangeSamplerProvider = New NDateTimeRangeSamplerProvider()
			provider.SamplingMode = SamplingMode.CustomStep
			provider.UseOrigin = True
			provider.Origin = origin
			provider.CustomStep = New NDateTimeSpan(1, NDateTimeUnit.Day)
			stripStyle.RangeSamplerProvider = provider
		End Sub
	End Class
End Namespace
