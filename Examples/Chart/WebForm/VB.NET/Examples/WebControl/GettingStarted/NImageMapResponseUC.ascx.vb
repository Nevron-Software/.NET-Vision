Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NImageMapResponseUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			Dim imageMapResponse As NHtmlImageMapResponse = New NHtmlImageMapResponse()
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("HTML Image Map")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.DataLabelStyle.Visible = False
			bar.Legend.Mode = SeriesLegendMode.DataPoints
			bar.Legend.Format = "<label> <percent>"

			bar.AddDataPoint(New NDataPoint(12, "Cars"))
			bar.AddDataPoint(New NDataPoint(42, "Trains"))
			bar.AddDataPoint(New NDataPoint(56, "Buses"))
			bar.AddDataPoint(New NDataPoint(23, "Ships"))

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
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))

			' add interactivity styles with the urls to redirect to and the corresponding cursors and tooltips

			Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle("Click here to jump to Cars sales page", CursorType.Hand)
			interactivityStyle.UrlLink.OpenInNewWindow = True
			interactivityStyle.UrlLink.Url = "../Examples/GettingStarted/NCarSalesPage.aspx"
			bar.InteractivityStyles(0) = interactivityStyle

			interactivityStyle = New NInteractivityStyle("Click here to jump to Trains sales page", CursorType.Hand)
			interactivityStyle.UrlLink.OpenInNewWindow = True
			interactivityStyle.UrlLink.Url = "../Examples/GettingStarted/NTrainSalesPage.aspx"
			bar.InteractivityStyles(1) = interactivityStyle

			interactivityStyle = New NInteractivityStyle("Click here to jump to Bus sales page", CursorType.Hand)
			interactivityStyle.UrlLink.OpenInNewWindow = True
			interactivityStyle.UrlLink.Url = "../Examples/GettingStarted/NBusSalesPage.aspx"
			bar.InteractivityStyles(2) = interactivityStyle

			interactivityStyle = New NInteractivityStyle("Click here to jump to Ship sales page", CursorType.Hand)
			interactivityStyle.UrlLink.OpenInNewWindow = True
			interactivityStyle.UrlLink.Url = "../Examples/GettingStarted/NShipSalesPage.aspx"
			bar.InteractivityStyles(3) = interactivityStyle
		End Sub
	End Class
End Namespace
