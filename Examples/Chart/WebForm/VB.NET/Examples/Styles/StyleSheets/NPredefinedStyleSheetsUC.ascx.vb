Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NPredefinedStyleSheetsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(PredefinedStyleSheetDropDownList, GetType(PredefinedStyleSheet))
				PredefinedStyleSheetDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Predefined Style Sheets")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 60
			chart.Height = 25
			chart.Depth = 45
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.MajorGridStyle.ShowAtWalls = New ChartWallType() {ChartWallType.Floor, ChartWallType.Back}

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.Name = "Bar1"
			bar1.DataLabelStyle.Visible = True
			bar1.DataLabelStyle.Format = "<value>"
			bar1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.MultiBarMode = MultiBarMode.Series
			bar2.Name = "Bar2"
			bar2.DataLabelStyle.Visible = True
			bar2.DataLabelStyle.Format = "<value>"
			bar2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)

			' add the third bar
			Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar3.MultiBarMode = MultiBarMode.Series
			bar3.Name = "Bar3"
			bar3.DataLabelStyle.Visible = True
			bar3.DataLabelStyle.Format = "<value>"
			bar3.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)

			' fill with random data
			Dim barCount As Integer = 6
			bar1.Values.FillRandomRange(Random, barCount, 10, 40)
			bar2.Values.FillRandomRange(Random, barCount, 30, 60)
			bar3.Values.FillRandomRange(Random, barCount, 50, 80)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(CType(PredefinedStyleSheetDropDownList.SelectedIndex, PredefinedStyleSheet))
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace