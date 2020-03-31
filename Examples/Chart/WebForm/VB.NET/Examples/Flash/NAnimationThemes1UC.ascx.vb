Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NAnimationThemes1UC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' init form controls
				ChartTypeCombo.Items.Add("Bar")
				ChartTypeCombo.Items.Add("Line")
				ChartTypeCombo.Items.Add("Area")
				ChartTypeCombo.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithEnumValues(AnimationThemeTypeCombo, GetType(AnimationThemeType))
				AnimationThemeTypeCombo.SelectedIndex = CInt(Fix(AnimationThemeType.ScaleAndFade))

				WebExamplesUtilities.FillComboWithValues(AxesAnimationDurationCombo, 1, 10, 1)
				AxesAnimationDurationCombo.SelectedIndex = 2
				WebExamplesUtilities.FillComboWithValues(WallsAnimationDurationCombo, 1, 10, 1)
				WallsAnimationDurationCombo.SelectedIndex = 2
				WebExamplesUtilities.FillComboWithValues(SeriesAnimationDurationCombo, 1, 10, 1)
				SeriesAnimationDurationCombo.SelectedIndex = 2
			End If

			nChartControl1.Panels.Clear()
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = New NLabel("Animation Themes")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.DockMode = PanelDockMode.Top
			nChartControl1.Panels.Add(title)

			Dim contentPanel As NDockPanel = New NDockPanel()
			nChartControl1.Panels.Add(contentPanel)

			contentPanel.DockMode = PanelDockMode.Fill

			' configure the chart
			Dim chart As NCartesianChart = New NCartesianChart()
			contentPanel.ChildPanels.Add(chart)
			chart.Location = New NPointL(0, 0)
			chart.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))
			chart.Enable3D = False
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)
			chart.Margins = New NMarginsL(5, 5, 5, 5)
			chart.BoundsMode = BoundsMode.Stretch
			chart.DockMode = PanelDockMode.Fill

			' configure axes
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.Labels.Add("2004")
			ordinalScale.Labels.Add("2005")
			ordinalScale.Labels.Add("2006")
			ordinalScale.Labels.Add("2007")
			ordinalScale.Labels.Add("2008")
			ordinalScale.Labels.Add("2009")

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.Title.Text = "Sales in Thousands USD"
			linearScale.MinTickDistance = New NLength(15)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' create  series
			Dim series1 As NSeries = Nothing, series2 As NSeries = Nothing, series3 As NSeries = Nothing
			Select Case ChartTypeCombo.SelectedIndex
				Case 0 ' Bar
					series1 = CType(chart.Series.Add(SeriesType.Bar), NSeries)
					series2 = CType(chart.Series.Add(SeriesType.Bar), NSeries)
					series3 = CType(chart.Series.Add(SeriesType.Bar), NSeries)

					CType(series1, NBarSeries).MultiBarMode = MultiBarMode.Clustered
					CType(series2, NBarSeries).MultiBarMode = MultiBarMode.Clustered
					CType(series3, NBarSeries).MultiBarMode = MultiBarMode.Clustered
				Case 1 ' Line
					series1 = CType(chart.Series.Add(SeriesType.Line), NSeries)
					series2 = CType(chart.Series.Add(SeriesType.Line), NSeries)
					series3 = CType(chart.Series.Add(SeriesType.Line), NSeries)

					CType(series1, NLineSeries).MultiLineMode = MultiLineMode.Stacked
					CType(series2, NLineSeries).MultiLineMode = MultiLineMode.Stacked
					CType(series3, NLineSeries).MultiLineMode = MultiLineMode.Stacked

				Case 2 ' Area
					series1 = CType(chart.Series.Add(SeriesType.Area), NSeries)
					series2 = CType(chart.Series.Add(SeriesType.Area), NSeries)
					series3 = CType(chart.Series.Add(SeriesType.Area), NSeries)

					CType(series1, NAreaSeries).MultiAreaMode = MultiAreaMode.Stacked
					CType(series2, NAreaSeries).MultiAreaMode = MultiAreaMode.Stacked
					CType(series3, NAreaSeries).MultiAreaMode = MultiAreaMode.Stacked
			End Select

			' configure common settings
			series1.Name = "Company A"
			series1.DataLabelStyle.Visible = False

			series2.Name = "Company B"
			series2.DataLabelStyle.Visible = False

			series3.Name = "Company C"
			series3.DataLabelStyle.Visible = False

			' fill with random data
			series1.Values.FillRandomRange(Random, 6, 10, 100)
			series2.Values.FillRandomRange(Random, 6, 10, 100)
			series3.Values.FillRandomRange(Random, 6, 10, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply animation theme             
			Dim animationTheme As NAnimationTheme = New NAnimationTheme()

			animationTheme.AnimateSeriesSequentially = SequentialSeriesCheckBox.Checked
			animationTheme.AnimateDataPointsSequentially = SequentialDataPointsCheckBox.Checked
			animationTheme.AnimateChartsSequentially = SequentialChartsCheckBox.Checked

			animationTheme.WallsAnimationDuration = CSng(WallsAnimationDurationCombo.SelectedIndex + 1)
			animationTheme.AxesAnimationDuration = CSng(AxesAnimationDurationCombo.SelectedIndex + 1)
			animationTheme.SeriesAnimationDuration = CSng(SeriesAnimationDurationCombo.SelectedIndex + 1)

			animationTheme.AnimationThemeType = CType(AnimationThemeTypeCombo.SelectedIndex, AnimationThemeType)
			animationTheme.Apply(nChartControl1.Document)

			Dim swfResponse As NImageResponse = New NImageResponse()
			swfResponse.ImageFormat = New NSwfImageFormat()
'            swfResponse.StreamImageToBrowser = true;
			nChartControl1.ImageAcquisitionMode = ClientSideImageAcquisitionMode.TempFile
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse
		End Sub
	End Class
End Namespace
