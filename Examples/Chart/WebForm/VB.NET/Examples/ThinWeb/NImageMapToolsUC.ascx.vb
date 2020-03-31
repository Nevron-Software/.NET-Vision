Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NImageMapToolsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not NThinChartControl1.Initialized) Then
				' enable jittering (full scene antialiasing)
				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False
				NThinChartControl1.Settings.JitterMode = JitterMode.Enabled

				' set a chart title
				Dim title As NLabel = NThinChartControl1.Labels.AddHeader("Image Map Tools<br/>Tooltip, Browser Redirect, Cursor Change")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				title.TextStyle.TextFormat = TextFormat.XML

				' setup the chart
				Dim chart As NChart = NThinChartControl1.Charts(0)
				chart.Enable3D = True
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
				chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
				chart.Axis(StandardAxis.Depth).Visible = False

				' add a bar series
				Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
				bar.DataLabelStyle.Visible = False
				bar.Legend.Mode = SeriesLegendMode.DataPoints
				bar.Legend.Format = "<label> <percent>"

				bar.AddDataPoint(New NDataPoint(42, "Chart"))
				bar.AddDataPoint(New NDataPoint(56, "Diagram"))
				bar.AddDataPoint(New NDataPoint(12, "Gauges"))
				bar.AddDataPoint(New NDataPoint(23, "Maps"))

				' modify the axis labels
				Dim ordinalScale As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
				ordinalScale.AutoLabels = False

				Dim i As Integer = 0
				Do While i < bar.Labels.Count
					ordinalScale.Labels.Add(CStr(bar.Labels(i)))
					i += 1
				Loop

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.PaleMultiColor)
				styleSheet.Apply(chart)

				' apply layout
				ApplyLayoutTemplate(0, NThinChartControl1, chart, title, NThinChartControl1.Legends(0))

				' add interactivity styles with the urls to redirect to and the corresponding cursors and tooltips

				Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle("Click here to jump to Chart Gallery", CursorType.Hand)
				interactivityStyle.UrlLink.OpenInNewWindow = True
				interactivityStyle.UrlLink.Url = "https://www.nevron.com/products-dot-net-chart-gallery-charting-types-bar-chart.aspx"
				bar.InteractivityStyles(0) = interactivityStyle

				interactivityStyle = New NInteractivityStyle("Click here to jump to Diagram Gallery", CursorType.Hand)
				interactivityStyle.UrlLink.OpenInNewWindow = True
				interactivityStyle.UrlLink.Url = "https://www.nevron.com/products-dot-net-diagram-gallery-flow-and-organization-charts-flow-charts.aspx"
				bar.InteractivityStyles(1) = interactivityStyle

				interactivityStyle = New NInteractivityStyle("Click here to jump to Gauge Gallery", CursorType.Hand)
				interactivityStyle.UrlLink.OpenInNewWindow = True
				interactivityStyle.UrlLink.Url = "https://www.nevron.com/products-dot-net-chart-gallery-gauges-radial-gauge.aspx"
				bar.InteractivityStyles(2) = interactivityStyle

				interactivityStyle = New NInteractivityStyle("Click here to jump to Maps Gallery", CursorType.Hand)
				interactivityStyle.UrlLink.OpenInNewWindow = True
				interactivityStyle.UrlLink.Url = "https://www.nevron.com/products-dot-net-diagram-gallery-maps-general-maps.aspx"
				bar.InteractivityStyles(3) = interactivityStyle
				NThinChartControl1.Controller.SetActivePanel(chart)
			End If

			NThinChartControl1.Controller.Tools.Clear()

			If EnableBrowserRedirectCheckBox.Checked Then
				NThinChartControl1.Controller.Tools.Add(New NBrowserRedirectTool())
			End If

			If EnableTooltipsCheckBox.Checked Then
				Dim tooltipTool As NTooltipTool = New NTooltipTool()
				tooltipTool.FollowMouse = True
				NThinChartControl1.Controller.Tools.Add(tooltipTool)
			End If

			If EnableCursorChangeCheckBox.Checked Then
				NThinChartControl1.Controller.Tools.Add(New NCursorTool())
			End If

			NThinChartControl1.Controller.Tools.Add(New NTrackballTool())
		End Sub
	End Class
End Namespace
