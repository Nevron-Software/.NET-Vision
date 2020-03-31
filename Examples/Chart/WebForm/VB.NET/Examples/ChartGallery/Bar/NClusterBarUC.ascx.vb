Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Dom
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm


Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NClusterBarUC
		Inherits NExampleUC
		Protected nChart As NChart
		Protected nBar1 As NBarSeries
		Protected nBar2 As NBarSeries


		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Cluster Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			nChart = nChartControl1.Charts(0)
			nChart.BoundsMode = BoundsMode.Stretch

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			linearScale.StripStyles.Add(stripStyle)

			' add the first bar
			nBar1 = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar1.Name = "Bar1"
			nBar1.MultiBarMode = MultiBarMode.Series
			nBar1.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			nBar1.DataLabelStyle.Format = "<value>"
			nBar1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			nBar1.FillStyle = New NColorFillStyle(Color.DarkSeaGreen)
			nBar1.Values.ValueFormatter = New NNumericValueFormatter("0")

			' add the second bar
			nBar2 = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar2.Name = "Bar2"
			nBar2.MultiBarMode = MultiBarMode.Clustered
			nBar2.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			nBar2.DataLabelStyle.Format = "<value>"
			nBar2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			nBar2.FillStyle = New NColorFillStyle(Color.MediumSlateBlue)
			nBar2.Values.ValueFormatter = New NNumericValueFormatter("0")

			' fill with random data
			nBar1.Values.FillRandomRange(Random, 5, 10, 100)
			nBar2.Values.FillRandomRange(Random, 5, 10, 500)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, nChart, title, nChartControl1.Legends(0))

			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithPercents(GapPercentDropDownList, 10)
				WebExamplesUtilities.FillComboWithPercents(WidthPercentDropDownList, 10)

				GapPercentDropDownList.SelectedIndex = 0
				WidthPercentDropDownList.SelectedIndex = 8
			Else
				nBar1.GapPercent = WebExamplesUtilities.GetPercentFromCombo(GapPercentDropDownList, 10)
				nBar2.GapPercent = WebExamplesUtilities.GetPercentFromCombo(GapPercentDropDownList, 10)

				nBar1.WidthPercent = WebExamplesUtilities.GetPercentFromCombo(WidthPercentDropDownList, 10)
				nBar2.WidthPercent = WebExamplesUtilities.GetPercentFromCombo(WidthPercentDropDownList, 10)

				If ScaleSecondaryClusterCheckBox.Checked = True Then
					nBar2.DisplayOnAxis(StandardAxis.PrimaryY, False)
					nBar2.DisplayOnAxis(StandardAxis.SecondaryY, True)

					nChart.Axis(StandardAxis.SecondaryY).Visible = True
				Else
					nBar2.DisplayOnAxis(StandardAxis.PrimaryY, True)
					nBar2.DisplayOnAxis(StandardAxis.SecondaryY, False)

					nChart.Axis(StandardAxis.SecondaryY).Visible = False
				End If
			End If
		End Sub

		Protected Sub PositiveDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			nBar1.Values.FillRandomRange(Random, 5, 10, 100)
			nBar2.Values.FillRandomRange(Random, 5, 10, 500)
		End Sub

		Protected Sub PositiveAndNegativeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			nBar1.Values.FillRandomRange(Random, 5, -100, 100)
			nBar2.Values.FillRandomRange(Random, 5, -100, 100)
		End Sub
	End Class
End Namespace
