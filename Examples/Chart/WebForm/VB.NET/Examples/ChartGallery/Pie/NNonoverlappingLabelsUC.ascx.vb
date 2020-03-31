Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls

Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NNonoverlappingLabelsUC
		Inherits NExampleUC
		Private m_Pie As NPieSeries

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Nonoverlapping Pie Labels")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NPieChart = New NPieChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			chart.Enable3D = True
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(90, NRelativeUnit.ParentPercentage), New NLength(87, NRelativeUnit.ParentPercentage))

			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			chart.ClockwiseDirection = clockwiseCheckBox.Checked

			' setup pie series
			m_Pie = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			m_Pie.LabelMode = PieLabelMode.SpiderNoOverlap
			m_Pie.DataLabelStyle.Format = "<label>" & Constants.vbLf & "<percent>"
			m_Pie.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			m_Pie.Values.ValueFormatter = New NNumericValueFormatter("0.##")
			m_Pie.BorderStyle.Color = Color.White
			m_Pie.PieStyle = PieStyle.SmoothEdgePie


			Dim arrValues As Double() = { 4.17, 7.19, 5.62, 7.91, 15.28, 0.97, 1.3, 1.12, 8.54, 9.84 }

			Dim i As Integer = 0
			Do While i < arrValues.Length
				m_Pie.Values.Add(arrValues(i))
				i += 1
			Loop

			SetTexts()

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub GenerateRandomValues(ByVal count As Integer)
			m_Pie.Values.Clear()

			Dim i As Integer = 0
			Do While i < count
				m_Pie.Values.Add(Random.NextDouble() * 10)
				i += 1
			Loop
		End Sub

		Private Sub SetTexts()
			Dim arrTexts As String() = { "Athletics", "Basketball", "Boxing", "Cycling", "Football", "Golf", "Handball", "Ice Hockey", "Motorsports", "Rugby" }

			Dim i As Integer = 0
			Do While i < arrTexts.Length
				m_Pie.Labels.Add(arrTexts(i))
				i += 1
			Loop
		End Sub

		Protected Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			GenerateRandomValues(10)
		End Sub
	End Class
End Namespace
