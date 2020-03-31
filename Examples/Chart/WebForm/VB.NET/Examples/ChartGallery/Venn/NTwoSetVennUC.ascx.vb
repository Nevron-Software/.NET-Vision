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
	Public Partial Class NTwoSetVennUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Two Set Venn")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			Dim chart As NVennChart = New NVennChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			Dim venn As NVennSeries = CType(chart.Series.Add(SeriesType.Venn), NVennSeries)

			TwoSetVenn(venn)
			TwoSetVennLabels(venn)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub TwoSetVenn(ByVal venn As NVennSeries)
			venn.ClearContours()

			venn.AddVennContour(VennShape.Ellipse, New NPointF(-15, 0), New NSizeF(50, 50), 0, 0)
			venn.AddVennContour(VennShape.Ellipse, New NPointF(15, 0), New NSizeF(50, 50), 0, 1)
		End Sub

		Private Sub TwoSetVennLabels(ByVal venn As NVennSeries)
			Dim s1 As String() = New String(){ "A", "AB", "B"}

			venn.ClearLabels()
			venn.LabelsTextStyle.FontStyle = New NFontStyle("Verdana", 8)

			' add labels
			venn.AddLabel(s1(0), New NPointF(-25, 0))
			venn.AddLabel(s1(1), New NPointF(0, 0))
			venn.AddLabel(s1(2), New NPointF(25, 0))
		End Sub
	End Class
End Namespace
