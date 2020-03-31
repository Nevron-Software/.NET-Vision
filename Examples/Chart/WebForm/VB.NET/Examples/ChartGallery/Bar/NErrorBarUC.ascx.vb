Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Dom
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStackedBarUC
		Inherits NExampleUC
		Protected nChart As NChart
		Protected nBar1 As NBarSeries
		Protected nBar2 As NBarSeries
		Protected nBar3 As NBarSeries


		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Error Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			chart.Axis(StandardAxis.Depth).Visible = False

			' setup a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.DataLabelStyle.Visible = False
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.ShadowStyle.Type = ShadowType.GaussianBlur
			bar.ShadowStyle.Offset = New NPointL(2, 2)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)
			bar.HasBottomEdge = False

			' add some data to the bar series
			bar.Values.Add(15)
			bar.UpperErrors.Add(2)
			bar.LowerErrors.Add(1)

			bar.Values.Add(21)
			bar.UpperErrors.Add(2.4)
			bar.LowerErrors.Add(1.3)

			bar.Values.Add(23)
			bar.UpperErrors.Add(3.2)
			bar.LowerErrors.Add(1.7)

			bar.Values.Add(27)
			bar.UpperErrors.Add(1.4)
			bar.LowerErrors.Add(2.5)

			bar.Values.Add(29)
			bar.UpperErrors.Add(4.0)
			bar.LowerErrors.Add(2.0)

			bar.Values.Add(26)
			bar.UpperErrors.Add(2.1)
			bar.LowerErrors.Add(1.6)


			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))

			bar.ShowUpperError = ShowUpperErrorCheckBox.Checked
			bar.ShowLowerError = ShowLowerErrorCheckBox.Checked
			chart.Enable3D = Enable3DCheckBox.Checked
		End Sub
	End Class
End Namespace
