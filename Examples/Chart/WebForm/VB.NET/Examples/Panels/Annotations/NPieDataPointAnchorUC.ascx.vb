Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NPieDataPointAnchorUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			nChartControl1.Panels.Clear()

			' Create title label
			Dim title As NLabel = New NLabel("Pie Data Point Anchor")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			nChartControl1.Panels.Add(title)

			' Create a pie chart
			Dim chart As NPieChart = New NPieChart()
			nChartControl1.Panels.Add(chart)
			chart.Enable3D = False

			' Create a pie series with 6 data points
			Dim pieSeries As NPieSeries = New NPieSeries()
			chart.Series.Add(pieSeries)
			pieSeries.DataLabelStyle.Visible = True
			pieSeries.LabelMode = PieLabelMode.SpiderNoOverlap
			pieSeries.Values.FillRandomRange(New Random(), 6, 1, 5)

			' Create a rounded rect callout
			Dim callout As NRoundedRectangularCallout = New NRoundedRectangularCallout()
			callout.ArrowLength = New NLength(20, NGraphicsUnit.Point)
			callout.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightGreen))
			callout.UseAutomaticSize = True
			callout.Orientation = 80
			callout.ContentAlignment = ContentAlignment.TopLeft
			callout.Text = "Annotation"
			callout.TextStyle.FontStyle.EmSize = New NLength(8)

			' Anchor the callout to pie data point #0
			Dim anchor As NPieDataPointAnchor = New NPieDataPointAnchor(pieSeries, 0, 0.8f, StringAlignment.Near)
			callout.Anchor = anchor

			' add the annotation panel
			nChartControl1.Panels.Add(callout)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub
	End Class
End Namespace
