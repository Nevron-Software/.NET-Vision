Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NFlashInteractivityUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
			End If

			nChartControl1.Panels.Clear()
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = New NLabel("Flash Interactivity")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.DockMode = PanelDockMode.Top
			title.InteractivityStyle.UrlLink.Url = "http://www.apple.com"
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
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)

			bar1.MultiBarMode = MultiBarMode.Clustered
			bar2.MultiBarMode = MultiBarMode.Clustered
			bar3.MultiBarMode = MultiBarMode.Clustered

			' configure common settings
			bar1.Name = "Apple"
			bar2.InteractivityStyle.UrlLink.Url = "http://www.apple.com"
			bar1.DataLabelStyle.Visible = False

			bar2.Name = "Nokia"
			bar2.InteractivityStyle.UrlLink.Url = "http://www.nokia.com"
			bar2.DataLabelStyle.Visible = False

			bar3.Name = "HTC"
			bar3.InteractivityStyle.UrlLink.Url = "http://www.htc.com"
			bar3.DataLabelStyle.Visible = False

			' fill with random data
			bar1.Values.FillRandomRange(Random, 6, 10, 100)
			bar2.Values.FillRandomRange(Random, 6, 10, 100)
			bar3.Values.FillRandomRange(Random, 6, 10, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply animation theme             
			Dim animationTheme As NAnimationTheme = New NAnimationTheme()

			animationTheme.AnimateSeriesSequentially = True
			animationTheme.AnimateDataPointsSequentially = False
			animationTheme.AnimateChartsSequentially = False

			animationTheme.WallsAnimationDuration = 1
			animationTheme.AxesAnimationDuration = 1
			animationTheme.SeriesAnimationDuration = 1

			animationTheme.AnimationThemeType = AnimationThemeType.ScaleAndFade
		'	animationTheme.Apply(nChartControl1.Document);

			Dim swfResponse As NImageResponse = New NImageResponse()
			swfResponse.ImageFormat = New NSwfImageFormat()

			nChartControl1.ImageAcquisitionMode = ClientSideImageAcquisitionMode.TempFile
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse
		End Sub
	End Class
End Namespace
