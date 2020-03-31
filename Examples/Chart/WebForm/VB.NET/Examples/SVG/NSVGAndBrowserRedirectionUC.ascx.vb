Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.UI.WebForm.Controls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NSVGAndBrowserRedirectionUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			Dim chart As NChart
			Dim bar As NBarSeries

			nChartControl1.Legends(0).SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom)

			chart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))

			chart.Depth = 20
			bar = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)

			bar.AddDataPoint(New NDataPoint(100 + Random.Next(100), "Toyota", New NColorFillStyle(Color.Red)))
			bar.AddDataPoint(New NDataPoint(100 + Random.Next(100), "Volkswagen", New NColorFillStyle(Color.Gold)))
			bar.AddDataPoint(New NDataPoint(100 + Random.Next(100), "Ford", New NColorFillStyle(Color.Chocolate)))
			bar.AddDataPoint(New NDataPoint(100 + Random.Next(100), "Mazda", New NColorFillStyle(Color.LimeGreen)))

			bar.Legend.Mode = SeriesLegendMode.DataPoints
			bar.Legend.Format = "<label>"

			' add urls to redirect to

			Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle("Click here to jump to Toyota home page", CursorType.Hand)
			interactivityStyle.UrlLink.Url = "http://www.toyota.com"
			interactivityStyle.UrlLink.OpenInNewWindow = OpenLinkInNewWindowCheckBox.Checked
			bar.InteractivityStyles.Add(0, interactivityStyle)

			interactivityStyle = New NInteractivityStyle("Click here to jump to VW home page", CursorType.Hand)
			interactivityStyle.UrlLink.Url = "http://www.vw.com"
			interactivityStyle.UrlLink.OpenInNewWindow = OpenLinkInNewWindowCheckBox.Checked
			bar.InteractivityStyles.Add(1, interactivityStyle)

			interactivityStyle = New NInteractivityStyle("Click here to jump to Ford home page", CursorType.Hand)
			interactivityStyle.UrlLink.Url = "http://www.ford.com"
			interactivityStyle.UrlLink.OpenInNewWindow = OpenLinkInNewWindowCheckBox.Checked
			bar.InteractivityStyles.Add(2, interactivityStyle)

			interactivityStyle = New NInteractivityStyle("Click here to jump to Mazda home page", CursorType.Hand)
			interactivityStyle.UrlLink.Url = "http://www.mazda.com"
			interactivityStyle.UrlLink.OpenInNewWindow = OpenLinkInNewWindowCheckBox.Checked
			bar.InteractivityStyles.Add(3, interactivityStyle)

			Dim i As Integer = 0
			Do While i < bar.Values.Count
				bar.FillStyles(i) = New NColorFillStyle(WebExamplesUtilities.RandomColor())
				i += 1
			Loop

			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Car Sales per Company<br/><font size = '10'>Demonstrates anchor SVG tags</font>")
			header.TextStyle.BackplaneStyle.Visible = False
			header.TextStyle.TextFormat = TextFormat.XML
			header.TextStyle.FillStyle = New NColorFillStyle(Color.Black)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim imageResponse As NImageResponse = New NImageResponse()
			Dim svgImageFormat As NSvgImageFormat = New NSvgImageFormat()

			svgImageFormat.EnableInteractivity = True
			svgImageFormat.CustomScript = ""

			imageResponse.ImageFormat = svgImageFormat

			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageResponse
		End Sub
	End Class
End Namespace
