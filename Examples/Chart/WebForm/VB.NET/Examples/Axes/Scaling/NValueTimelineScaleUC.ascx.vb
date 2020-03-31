Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NValueTimelineScaleUC
		Inherits NExampleUC
		Private m_Chart As NCartesianChart
		Private m_Stock As NStockSeries

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As NLabel = New NLabel("Value Timeline Scale")
			header.DockMode = PanelDockMode.Top
			header.Margins = New NMarginsL(2, 2, 0, 5)
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.ContentAlignment = ContentAlignment.BottomRight
			header.FitAlignment = ContentAlignment.MiddleLeft
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(header)

			' setup chart
			m_Chart = New NCartesianChart()
			nChartControl1.Panels.Add(m_Chart)
			m_Chart.DockMode = PanelDockMode.Fill
			m_Chart.Margins = New NMarginsL(2, 0, 2, 2)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.LightModel.EnableLighting = False
			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Wall(ChartWallType.Floor).Visible = False
			m_Chart.Wall(ChartWallType.Left).Visible = False
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Height = 40

			' setup X axis
			Dim axis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			axis.ScrollBar.Visible = True
			Dim timelineScale As NValueTimelineScaleConfigurator = New NValueTimelineScaleConfigurator()
			timelineScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			timelineScale.SecondRow.GridStyle.SetShowAtWall(ChartWallType.Back, True)
			timelineScale.ThirdRow.GridStyle.SetShowAtWall(ChartWallType.Back, True)
			axis.ScaleConfigurator = timelineScale

			' setup primary Y axis
			axis = m_Chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			' configure ticks and grid lines
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.InnerMajorTickStyle.Length = New NLength(0)

			' add interlaced stripe 
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' Setup the stock series
			m_Stock = CType(m_Chart.Series.Add(SeriesType.Stock), NStockSeries)
			m_Stock.DataLabelStyle.Visible = False
			m_Stock.CandleStyle = CandleStyle.Stick
			m_Stock.CandleWidth = New NLength(0.5f, NRelativeUnit.ParentPercentage)
			m_Stock.UpStrokeStyle.Color = Color.RoyalBlue
			m_Stock.Legend.Mode = SeriesLegendMode.None
			m_Stock.CloseValues.Name = "close"
			m_Stock.UseXValues = True

			' init form controls
			If (Not IsPostBack) Then
				FirstRowVisibleCheckBox.Checked = True
				SecondRowVisibleCheckBox.Checked = True
				ThirdRowVisibleCheckBox.Checked = True

				RandomDataTypeDropDownList.Items.Add("Daily")
				RandomDataTypeDropDownList.Items.Add("Weekly")
				RandomDataTypeDropDownList.Items.Add("Monthly")
				RandomDataTypeDropDownList.Items.Add("Yearly")
				RandomDataTypeDropDownList.SelectedIndex = 2
			End If

			timelineScale.FirstRow.Visible = FirstRowVisibleCheckBox.Checked
			timelineScale.SecondRow.Visible = SecondRowVisibleCheckBox.Checked
			timelineScale.ThirdRow.Visible = ThirdRowVisibleCheckBox.Checked

			Dim dtNow As DateTime = DateTime.Now
			Dim dtEnd As DateTime = dtNow
			Dim dtStart As DateTime = dtNow
			Dim span As NDateTimeSpan = New NDateTimeSpan()

			Select Case RandomDataTypeDropDownList.SelectedIndex
				Case 0
					' generate data for 30 days
					dtEnd = New DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 17, 0, 0, 0)
					dtStart = New DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
					span = New NDateTimeSpan(5, NDateTimeUnit.Minute)
				Case 1
					' generate data for 30 weeks
					dtEnd = New DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
					dtStart = NDateTimeUnit.Week.Add(dtEnd, -30)
					span = New NDateTimeSpan(1, NDateTimeUnit.Day)
				Case 2
					' generate data for 30 months 
					dtEnd = New DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
					dtStart = NDateTimeUnit.Month.Add(dtEnd, -30)
					span = New NDateTimeSpan(1, NDateTimeUnit.Week)
				Case 3
					' generate data for 30 years
					dtEnd = New DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 7, 0, 0, 0)
					dtStart = NDateTimeUnit.Year.Add(dtEnd, -30)
					span = New NDateTimeSpan(1, NDateTimeUnit.Month)
			End Select

			GenerateData(dtStart, dtEnd, span)
		End Sub

		Private Sub GenerateData(ByVal dtStart As DateTime, ByVal dtEnd As DateTime, ByVal span As NDateTimeSpan)
			Dim count As Long = span.GetSpanCountInRange(New NDateTimeRange(dtStart, dtEnd))

			WebExamplesUtilities.GenerateOHLCData(m_Stock, 100, CInt(Fix(count)))
			m_Stock.XValues.Clear()

			Dim dtNow As DateTime = dtStart

			Dim i As Integer = 0
			Do While i < m_Stock.Values.Count
				m_Stock.XValues.Add(dtNow.ToOADate())
				dtNow = span.Add(dtNow)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
