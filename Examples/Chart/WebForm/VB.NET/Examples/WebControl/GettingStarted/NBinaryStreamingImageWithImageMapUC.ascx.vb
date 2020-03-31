Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NBinaryStreamingImageWithImageMapUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim nChartControl1 As NChartControl = New NChartControl()
			nChartControl1.Width = 420
			nChartControl1.Height = 320
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("HTML Image Map and Binary Streaming")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Mode = LegendMode.Disabled
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom)

			' setup a pie chart
			Dim chart As NPieChart = New NPieChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)
			chart.DisplayOnLegend = legend
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(17, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(66, NRelativeUnit.ParentPercentage))
			chart.InnerRadius = New NLength(20, NRelativeUnit.ParentPercentage)

			' add a pie series
			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pie.PieStyle = PieStyle.Torus
			pie.LabelMode = PieLabelMode.Rim
			pie.DataLabelStyle.Format = "<label> <percent>"
			pie.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			pie.Legend.Mode = SeriesLegendMode.DataPoints
			pie.Legend.Format = "<label> <value>"
			pie.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)

			pie.AddDataPoint(New NDataPoint(12, "Metals"))
			pie.AddDataPoint(New NDataPoint(42, "Glass"))
			pie.AddDataPoint(New NDataPoint(23, "Plastics"))
			pie.AddDataPoint(New NDataPoint(56, "Paper"))
			pie.AddDataPoint(New NDataPoint(23, "Other"))

			' add urls to redirect to
			pie.InteractivityStyles.Add(0, New NInteractivityStyle("Metals"))
			pie.InteractivityStyles.Add(1, New NInteractivityStyle("Glass"))
			pie.InteractivityStyles.Add(2, New NInteractivityStyle("Plastics"))
			pie.InteractivityStyles.Add(3, New NInteractivityStyle("Paper"))
			pie.InteractivityStyles.Add(4, New NInteractivityStyle("Other"))

			pie.PieStyle = PieStyle.Torus
			pie.LabelMode = PieLabelMode.Spider

			Dim imageMapResponse As NHtmlImageMapResponse = New NHtmlImageMapResponse()
			imageMapResponse.CreateImageFile = False
			imageMapResponse.ImageFileName = "NChartImageMap"
			imageMapResponse.ImageMapName = "MAP_NChartImageMap"
			nChartControl1.ServerSettings.BrowserResponseSettings.DefaultResponse = imageMapResponse

			Me.Controls.Add(nChartControl1)
		End Sub
	End Class
End Namespace
