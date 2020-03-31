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
	Public Partial Class NPersistentServerControlUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' the control will save its state in the temp directory along with the
			' temporary image files
			nChartControl1.ServerSettings.ControlStateSettings.PersistControlState = True

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Settings.JitteringSteps = 4

			If (Not IsPostBack) Then
				' set a chart title
				Dim title As NLabel = nChartControl1.Labels.AddHeader("Persistent server control")
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				title.ContentAlignment = ContentAlignment.BottomCenter
				title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

				' no legend
				nChartControl1.Legends.Clear()

				' setup a pie chart
				Dim chart As NPieChart = New NPieChart()
				nChartControl1.Charts.Clear()
				nChartControl1.Charts.Add(chart)

				chart.Enable3D = True
				chart.LightModel.EnableLighting = True
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
				chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
				chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(65, NRelativeUnit.ParentPercentage))

				' add a pie series
				Dim pieSeries As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
				pieSeries.PieStyle = PieStyle.SmoothEdgePie
				pieSeries.LabelMode = PieLabelMode.SpiderNoOverlap

				' show a hand when over a pie slice
				pieSeries.InteractivityStyle.Cursor.Type = CursorType.Hand

				pieSeries.AddDataPoint(New NDataPoint(8, "Pie 1"))
				pieSeries.AddDataPoint(New NDataPoint(4, "Pie 2"))
				pieSeries.AddDataPoint(New NDataPoint(7, "Pie 3"))
				pieSeries.AddDataPoint(New NDataPoint(9, "Pie 4"))

				Dim i As Integer = 0
				Do While i < pieSeries.Values.Count
					pieSeries.FillStyles(i) = New NColorFillStyle(WebExamplesUtilities.RandomColor())
					i += 1
				Loop
			End If

			AddHandler AddPieButton.Click, AddressOf AddPieButton_Click
			AddHandler DeleteLastPieButton.Click, AddressOf DeleteLastPieButton_Click
		End Sub

		Private Sub AddPieButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim pieSeries As NPieSeries = CType(chart.Series(0), NPieSeries)

			Dim value As Double = Convert.ToDouble(PieValueTextBox.Text)
			Dim text As String = "Pie " & Convert.ToString(pieSeries.Values.Count + 1)
			Dim fill As NFillStyle = New NColorFillStyle(WebExamplesUtilities.RandomColor())

			pieSeries.AddDataPoint(New NDataPoint(value, text, fill))
		End Sub

		Private Sub DeleteLastPieButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim pieSeries As NPieSeries = CType(chart.Series(0), NPieSeries)

			If pieSeries.Values.Count = 0 Then
				Return
			End If

			Dim nLastIndex As Integer = pieSeries.Values.Count - 1

			pieSeries.Values.RemoveAt(nLastIndex)
		End Sub
	End Class
End Namespace
