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
	Public Partial Class NFourSetVennUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Four Set Venn")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			Dim chart As NVennChart = New NVennChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			Dim venn As NVennSeries = CType(chart.Series.Add(SeriesType.Venn), NVennSeries)

			FourSetVenn(venn)
			FourSetVennLabels(venn)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub FourSetVenn(ByVal venn As NVennSeries)
			venn.ClearContours()

			venn.AddVennContour(VennShape.Ellipse, New NPointF(-12.5f, -10f), New NSizeF(60, 35), 135, 0)
			venn.AddVennContour(VennShape.Ellipse, New NPointF(12.5f, -10f), New NSizeF(60, 35), 45, 1)
			venn.AddVennContour(VennShape.Ellipse, New NPointF(-2.5f, 5), New NSizeF(60, 35), 135, 2)
			venn.AddVennContour(VennShape.Ellipse, New NPointF(2.5f, 5), New NSizeF(60, 35), 45, 3)
		End Sub

		Private Sub FourSetVennLabels(ByVal venn As NVennSeries)
			Dim centreLabel As String = "ABCD"
			Dim s1 As String() = New String(){ "A", "B", "C", "D" }
			Dim s2 As String() = New String(){ "AC", "CD", "BD", "AD", "AB", "BC" }
			Dim s3 As String() = New String(){ "ACD", "BCD", "ABD", "ABC"}

			venn.ClearLabels()
			venn.LabelsTextStyle.FontStyle = New NFontStyle("Verdana", 8)

			' add centre label
			venn.AddLabel(centreLabel, New NPointF(0, -8))

			' add layer 1 labels
			venn.AddLabel(s1(0), New NPointF(-12.5f - 15f, -10f + 10f))
			venn.AddLabel(s1(1), New NPointF(12.5f + 15f, -10f + 10f))
			venn.AddLabel(s1(2), New NPointF(-2.5f - 15f, 5f + 16f))
			venn.AddLabel(s1(3), New NPointF(2.5f + 15f, 5f + 16f))

			' add layer 2 labels
			venn.AddLabel(s2(0), New NPointF(-12.5f - 9f, -10f + 19f))
			venn.AddLabel(s2(1), New NPointF(0, -10f + 24f))
			venn.AddLabel(s2(2), New NPointF(12.5f + 9f, -10f + 19f))
			venn.AddLabel(s2(3), New NPointF(2.5f - 18f, 5f - 18f))
			venn.AddLabel(s2(4), New NPointF(0, -10f - 16f))
			venn.AddLabel(s2(5), New NPointF(-2.5f + 18f, 5f - 18f))

			' add layer 3 labels
			venn.AddLabel(s3(0), New NPointF(-12.5f + 1f, -10f + 10f))
			venn.AddLabel(s3(1), New NPointF(12.5f - 1f, -10f + 10f))
			venn.AddLabel(s3(2), New NPointF(2.5f - 10f, 5f - 21.5f))
			venn.AddLabel(s3(3), New NPointF(-2.5f + 10f, 5f - 21.5f))
		End Sub
	End Class
End Namespace
