Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDrillDownDemoUC
		Inherits NExampleUC
		'	sample data, imitating the results of a query
		Private Shared startDate As DateTime = New DateTime(2008, 11, 01)
		Private Shared regionNames As String() = New String() { "Africa", "America", "Asia", "Europe", "Oceania" }
		Private Shared hitsPerDayPerRegion As Integer()() = New Integer()() { New Integer() {658, 8467, 8327, 7403, 1836}, New Integer() {467, 9658, 7740, 8363, 2273}, New Integer() {865, 7846, 7832, 9700, 3186}, New Integer() {568, 6867, 3827, 7483, 2227}, New Integer() {566, 8682, 6737, 8223, 3277} }

		'	stores the index of the currently selected bar series data point
		Private Property SelectedDataPointIndex() As Integer
			Get
				If Session("SelectedDataPointIndex") Is Nothing Then
					Return -1
				End If

				Return CInt(Fix(Session("SelectedDataPointIndex")))
			End Get
			Set
				Session("SelectedDataPointIndex") = Value
			End Set
		End Property

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			'	create a chart that displays the total hits per day
			LoadBarChart()
			'	create a chart that displays the hits hits per region for the selected day
			LoadPieChart()
		End Sub

		#Region "Bar Chart"

		Private Sub LoadBarChart()
			If nChartControl1.RequiresInitialization Then
				nChartControl1.BackgroundStyle.FrameStyle.Visible = False
				nChartControl1.Legends.Clear()

				' set a chart title
				Dim header As NLabel = nChartControl1.Labels.AddHeader("Total Web Site Hits per Day")
				header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				header.ContentAlignment = ContentAlignment.BottomRight
				header.Location = New NPointL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))

				' setup a Bar chart
				Dim chart As NChart = nChartControl1.Charts(0)
				chart.Enable3D = False
				chart.BoundsMode = BoundsMode.Stretch
				chart.Location = New NPointL(New NLength(4, NRelativeUnit.ParentPercentage), New NLength(25, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(88, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

				' setup Y axis
				Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
				linearScale.InnerMajorTickStyle.Visible = False

				' add interlace stripe to the Y axis
				Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(&Hfe, &Hed, &He2)), Nothing, True, 0, 0, 1, 1)
				stripStyle.Interlaced = True
				stripStyle.SetShowAtWall(ChartWallType.Back, True)
				stripStyle.SetShowAtWall(ChartWallType.Left, True)
				linearScale.StripStyles.Add(stripStyle)

				' setup X axis
				Dim timeScale As NDateTimeScaleConfigurator = New NDateTimeScaleConfigurator()
				timeScale.EnableUnitSensitiveFormatting = True
				timeScale.DateTimeUnitFormatterPairs.Clear()
				timeScale.DateTimeUnitFormatterPairs.Add(New NDateTimeUnitFormatterPair(NDateTimeUnit.Day, New NDateTimeValueFormatter("d/MM/yy")))
				timeScale.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }
				timeScale.MajorTickMode = MajorTickMode.CustomStep
				timeScale.CustomStep = New NDateTimeSpan(1, NDateTimeUnit.Day)
				timeScale.InnerMajorTickStyle.Visible = False
				timeScale.RoundToTickMin = False
				timeScale.RoundToTickMax = False
				chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = timeScale

				' setup bar series
				Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
				bar.Name = "Total Web Site Hits per Day"
				bar.DataLabelStyle.Format = "<value>"
				bar.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
				bar.BarWidth = New NLength(10, NRelativeUnit.ParentPercentage)
				bar.InflateMargins = True
				bar.UseXValues = True
				bar.UseZValues = False

				' initialize data points
				Dim [date] As DateTime = startDate
				Dim lengthDays As Integer = hitsPerDayPerRegion.Length
				Dim i As Integer = 0
				Do While i < lengthDays
					Dim totalHits As Integer = 0
					Dim lengthRegions As Integer = hitsPerDayPerRegion(i).Length
					Dim j As Integer = 0
					Do While j < lengthRegions
						totalHits += hitsPerDayPerRegion(i)(j)
						j += 1
					Loop

					bar.XValues.Add([date])
					bar.Values.Add(totalHits)

					If i > 0 Then
						bar.InteractivityStyles.Add(i, New NInteractivityStyle(True, i.ToString(), String.Format("{0}: {1}", [date].ToString("dd/MMM/yyyy"), totalHits), CursorType.Hand))
					End If

					[date] = [date].AddDays(1)
					i += 1
				Loop

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)

				' select the first bar
				Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)
				bar.FillStyles(0) = New NColorFillStyle(palette.SeriesColors(1))
			End If
		End Sub

		Protected Sub nChartControl1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True, False))
			nChartControl1.AjaxTools.Add(New NAjaxTooltipTool(True))
			nChartControl1.AjaxTools.Add(New NAjaxDynamicCursorTool(True))
		End Sub

		Protected Sub nChartControl1_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(TryCast(e, NCallbackMouseEventArgs))
			If result.ChartElement = ChartElement.DataPoint Then
				Dim barSeries As NBarSeries = TryCast(result.Series, NBarSeries)
				barSeries.FillStyles.Clear()
				Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)
				barSeries.FillStyles(result.DataPointIndex) = New NColorFillStyle(palette.SeriesColors(1))

				SelectedDataPointIndex = result.DataPointIndex

				Dim [date] As DateTime = startDate
				barSeries.InteractivityStyles.Clear()
				Dim lengthDays As Integer = hitsPerDayPerRegion.Length
				Dim i As Integer = 0
				Do While i < lengthDays
					Dim totalHits As Integer = 0
					Dim lengthRegions As Integer = hitsPerDayPerRegion(i).Length
					Dim j As Integer = 0
					Do While j < lengthRegions
						totalHits += hitsPerDayPerRegion(i)(j)
						j += 1
					Loop

					If SelectedDataPointIndex <> i Then
						barSeries.InteractivityStyles.Add(i, New NInteractivityStyle(True, i.ToString(), String.Format("{0}: {1}", [date].ToString("dd/MMM/yyyy"), totalHits), CursorType.Hand))
					End If

					[date] = [date].AddDays(1)
					i += 1
				Loop
			End If
		End Sub

		#End Region

		#Region "Pie Chart"

		Private Class PieChartHttpHandlerCallback
			Inherits NHttpHandlerCallback
			Public Overrides Sub OnAsyncCustomCommand(ByVal webControlId As String, ByVal context As System.Web.HttpContext, ByVal state As NStateObject, ByVal args As NCallbackCustomCommandArgs)
				Select Case args.Command.Name
					Case "displayHitsForDate"
						Dim chartState As NChartSessionStateObject = TryCast(state, NChartSessionStateObject)
						Dim rootPanel As NRootPanel = chartState.Document.RootPanel
						Dim pieSeries As NPieSeries = TryCast(rootPanel.Charts(0).Series(0), NPieSeries)

						Dim dataPointIndex As Integer = Integer.Parse(TryCast(args.Command.Arguments("dataPointIndex"), String))
						Dim data As Integer() = NDrillDownDemoUC.hitsPerDayPerRegion(dataPointIndex)

						pieSeries.Values.Clear()
						pieSeries.Labels.Clear()
						Dim length As Integer = hitsPerDayPerRegion(0).Length
						Dim i As Integer = 0
						Do While i < length
							pieSeries.Values.Add(data(i))
							pieSeries.Labels.Add(NDrillDownDemoUC.regionNames(i))
							i += 1
						Loop

						Dim selectedDate As DateTime = NDrillDownDemoUC.startDate.AddDays(dataPointIndex)
						Dim header As NLabel = rootPanel.Labels(0)
						header.Text = selectedDate.ToString("dd/MMM/yyyy") & ", Hits per Region"

				End Select
			End Sub
		End Class

		Private Sub LoadPieChart()
			nChartControl2.HttpHandlerCallback = New PieChartHttpHandlerCallback()

			If nChartControl2.RequiresInitialization Then
				nChartControl2.BackgroundStyle.FrameStyle.Visible = False
				nChartControl2.Settings.JitterMode = JitterMode.Enabled
				nChartControl2.Legends.Clear()
				nChartControl2.Charts.Clear()

				' read the selected bar data point info
				Dim barChart As NChart = nChartControl1.Charts(0)
				Dim bar As NBarSeries = CType(barChart.Series(0), NBarSeries)
				If bar.XValues.Count = 0 Then
					Return
				End If

				Dim selectedDate As DateTime = DateTime.FromOADate(CDbl(bar.XValues(0)))

				' set a chart title
				Dim header As NLabel = New NLabel(selectedDate.ToString("dd/MMM/yyyy") & ", Hits per Region")
				header.TextStyle.FontStyle = New NFontStyle("Verdana", 10, FontStyle.Regular)
				header.DockMode = PanelDockMode.Top
				nChartControl2.Panels.Add(header)

				' setup a Pie chart
				Dim chart As NPieChart = New NPieChart()
				chart.DockMode = PanelDockMode.Fill
				nChartControl2.Panels.Add(chart)

				chart.Enable3D = True
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
				chart.Projection.Elevation = 312
				chart.BoundsMode = BoundsMode.Fit
				chart.Location = New NPointL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(35, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(53, NRelativeUnit.ParentPercentage), New NLength(53, NRelativeUnit.ParentPercentage))

				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
				chart.LightModel.LightSources(0).Specular = Color.FromArgb(64, 64, 64)
				chart.LightModel.LightSources(1).Specular = Color.FromArgb(64, 64, 64)
				chart.LightModel.LightSources(2).Specular = Color.FromArgb(64, 64, 64)
				chart.Radius = New NLength(48, NRelativeUnit.ParentPercentage)
				chart.InnerRadius = New NLength(31, NRelativeUnit.ParentPercentage)

				' setup a Pie series
				Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
				pie.BorderStyle = New NStrokeStyle(New NLength(5), Color.White)
				pie.LabelMode = PieLabelMode.SpiderNoOverlap
				pie.PieStyle = PieStyle.Torus

				Dim length As Integer = hitsPerDayPerRegion(0).Length
				Dim i As Integer = 0
				Do While i < length
					pie.Values.Add(hitsPerDayPerRegion(0)(i))
					pie.Labels.Add(regionNames(i))
					i += 1
				Loop

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl2.Document)
			End If
		End Sub

		#End Region
	End Class
End Namespace
