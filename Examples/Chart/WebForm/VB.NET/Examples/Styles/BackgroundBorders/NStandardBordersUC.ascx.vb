Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStandardBordersUC
		Inherits NExampleUC
		Protected ImageBordersGeneral As HtmlForm

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				StandardBorderDropDownList.Items.Add("None")
				StandardBorderDropDownList.Items.Add("SingleFixed")
				StandardBorderDropDownList.Items.Add("Sunken")
				StandardBorderDropDownList.Items.Add("Raised")
				StandardBorderDropDownList.Items.Add("SunkenRaised")
				StandardBorderDropDownList.Items.Add("RaisedSunken")

				WebExamplesUtilities.FillComboWithColorNames(BorderColorDropDownList, KnownColor.White)
				WebExamplesUtilities.FillComboWithValues(BevelWidthDropDownList, 1, 10, 1)
				WebExamplesUtilities.FillComboWithValues(BorderWidthDownList, 1, 10, 1)

				StandardBorderDropDownList.SelectedIndex = 2
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set an image frame
			Dim standardFrameStyle As NStandardFrameStyle = New NStandardFrameStyle()

			standardFrameStyle.SetPredefinedFrameStyle(CType(StandardBorderDropDownList.SelectedIndex, PredefinedStandardFrame))
			standardFrameStyle.InnerBevelWidth = New NLength(BevelWidthDropDownList.SelectedIndex + 1, NGraphicsUnit.Pixel)
			standardFrameStyle.OuterBevelWidth = New NLength(BevelWidthDropDownList.SelectedIndex + 1, NGraphicsUnit.Pixel)
			standardFrameStyle.OuterBorderColor = WebExamplesUtilities.ColorFromDropDownList(BorderColorDropDownList)
			standardFrameStyle.OuterBorderWidth = New NLength(BorderWidthDownList.SelectedIndex + 1, NGraphicsUnit.Pixel)

			nChartControl1.BackgroundStyle.FrameStyle = standardFrameStyle
			nChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightSteelBlue, Color.White)

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Standard Border")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Depth = 50
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			Dim scaleX As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount

			Dim scaleZ As NStandardScaleConfigurator = CType(chart.Axis(StandardAxis.Depth).ScaleConfigurator, NStandardScaleConfigurator)
			scaleZ.MajorTickMode = MajorTickMode.AutoMaxCount

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.Name = "Bar1"
			bar1.DataLabelStyle.Visible = False
			bar1.BorderStyle.Color = Color.Crimson
			bar1.FillStyle = New NColorFillStyle(Color.Crimson)
			bar1.Values.FillRandomRange(Random, 5, 10, 40)

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.MultiBarMode = MultiBarMode.Series
			bar2.Name = "Bar2"
			bar2.DataLabelStyle.Visible = False
			bar2.BorderStyle.Color = Color.PaleGreen
			bar2.FillStyle = New NColorFillStyle(Color.PaleGreen)
			bar2.Values.FillRandomRange(Random, 5, 30, 60)

			' add the third bar
			Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar3.MultiBarMode = MultiBarMode.Series
			bar3.Name = "Bar3"
			bar3.DataLabelStyle.Visible = False
			bar3.BorderStyle.Color = Color.CornflowerBlue
			bar3.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
			bar3.Values.FillRandomRange(Random, 5, 50, 80)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
