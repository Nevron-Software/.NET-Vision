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
	Public Partial Class NThreeSetVennUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Three Set Venn")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			Dim chart As NVennChart = New NVennChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			Dim venn As NVennSeries = CType(chart.Series.Add(SeriesType.Venn), NVennSeries)

			ThreeSetVenn(venn)
			ThreeSetVennLabels(venn)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub ThreeSetVenn(ByVal venn As NVennSeries)
			Const nSetCount As Integer = 3
			Const fStartAngle As Single = -(CSng(Math.PI) / 2)
			Const fScale As Single = 14
			Const fCenterX As Single = 0
			Const fCenterY As Single = 0
			Dim fIncrementAngle As Single = CSng(2 * Math.PI / nSetCount)

			venn.ClearContours()

			For i As Integer = 0 To nSetCount - 1
				Dim fAngle As Single = fStartAngle + i * fIncrementAngle
				Dim x As Single = CSng(Math.Round(fCenterX + Math.Cos(fAngle) * fScale, 1))
				Dim y As Single = CSng(Math.Round(fCenterY + Math.Sin(fAngle) * fScale, 1))

				venn.AddVennContour(VennShape.Ellipse, New NPointF(x, y), New NSizeF(50, 50), 0, i)
			Next i
		End Sub

		Private Sub ThreeSetVennLabels(ByVal venn As NVennSeries)
			Dim s1 As String() = New String(){ "A", "B", "C" }
			Dim s2 As String() = New String(){ "BC", "AC", "AB" }

			venn.ClearLabels()
			venn.LabelsTextStyle.FontStyle = New NFontStyle("Verdana", 8)

			' add the center label
			venn.AddLabel("ABC", New NPointF(0, 0))

			' add outer labels
			Dim points As NPointF() = CalculateLabelPositions(3, 30, CSng(-Math.PI/2))
			For i As Integer = 0 To 2
				venn.AddLabel(s1(i), points(i))
			Next i

			' add middle labels
			points = CalculateLabelPositions(3, 17, CSng(Math.PI)/2)
			For i As Integer = 0 To 2
				venn.AddLabel(s2(i), points(i))
			Next i
		End Sub

		Private Function CalculateLabelPositions(ByVal nSetCount As Integer, ByVal fRadius As Single, ByVal fStartAngle As Single) As NPointF()
			Dim fIncrementAngle As Single = CSng(2 * Math.PI / nSetCount)
			Dim fCenterX As Single = 0
			Dim fCenterY As Single = 0

			Dim points As NPointF() = New NPointF(nSetCount - 1){}

			Dim i As Integer = 0
			Do While i < nSetCount
				Dim fAngle As Single = fStartAngle + i * fIncrementAngle
				Dim x As Single = CSng(Math.Round(fCenterX + Math.Cos(fAngle) * fRadius, 1))
				Dim y As Single = CSng(Math.Round(fCenterY + Math.Sin(fAngle) * fRadius, 1))

				points(i) = New NPointF(x, y)
				i += 1
			Loop

			Return points
		End Function
	End Class
End Namespace
