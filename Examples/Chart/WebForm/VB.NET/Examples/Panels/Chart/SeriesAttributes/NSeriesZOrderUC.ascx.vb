Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm
Imports System.Diagnostics

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NSeriesZOrderUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' init form controls
				ZOrderModeCombo.Items.Add("123")
				ZOrderModeCombo.Items.Add("321")
				ZOrderModeCombo.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = New NLabel("Series Z Order")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			nChartControl1.Panels.Add(title)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.WidthPercent = 80
			bar1.Name = "Bar1"

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.WidthPercent = 60
			bar2.Name = "Bar2"

			' add the third bar
			Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar3.WidthPercent = 40
			bar3.Name = "Bar3"

			' position data labels in the center of the bars
			bar1.DataLabelStyle.Visible = False
			bar2.DataLabelStyle.Visible = False
			bar3.DataLabelStyle.Visible = False

			' fill some random data
			bar1.Values.FillRandomRange(Random, 6, 20, 100)
			bar2.Values.FillRandomRange(Random, 6, 20, 100)
			bar3.Values.FillRandomRange(Random, 6, 20, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))

			Select Case ZOrderModeCombo.SelectedIndex
				Case 0
					bar1.ZOrder = 1
					bar2.ZOrder = 2
					bar3.ZOrder = 3
				Case 1
					bar1.ZOrder = 3
					bar2.ZOrder = 2
					bar3.ZOrder = 1
				Case Else
					Debug.Assert(False)
			End Select
		End Sub
	End Class
End Namespace
