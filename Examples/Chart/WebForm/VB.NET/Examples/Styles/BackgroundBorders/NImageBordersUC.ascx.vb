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
	Public Partial Class NImageBordersUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				ImageBorderDropDownList.Items.Add("Common")
				ImageBorderDropDownList.Items.Add("Embed")
				ImageBorderDropDownList.Items.Add("Emboss")
				ImageBorderDropDownList.Items.Add("Rounded")
				ImageBorderDropDownList.Items.Add("RoundedBorder")
				ImageBorderDropDownList.Items.Add("Rectangular")
				ImageBorderDropDownList.Items.Add("Thin")
				ImageBorderDropDownList.Items.Add("Thick")
				ImageBorderDropDownList.Items.Add("OuterRounded")
				ImageBorderDropDownList.Items.Add("OpenLeft")
				ImageBorderDropDownList.Items.Add("OpenRight")

				WebExamplesUtilities.FillComboWithColorNames(BorderColorDropDownList, KnownColor.LightSteelBlue)
				WebExamplesUtilities.FillComboWithColorNames(FillingColorDropDownList, KnownColor.Snow)
				WebExamplesUtilities.FillComboWithColorNames(PageBackgroundColorDropDownList, KnownColor.White)
				HasShadowCheckBox.Checked = True

				ImageBorderDropDownList.SelectedIndex = 6
			End If

			' set an image frame
			Dim imageFrameStyle As NImageFrameStyle = New NImageFrameStyle()

			imageFrameStyle.SetPredefinedFrameStyle(CType(ImageBorderDropDownList.SelectedIndex, PredefinedImageFrame))
			imageFrameStyle.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(FillingColorDropDownList))
			imageFrameStyle.BorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)
			imageFrameStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(BorderColorDropDownList)
			imageFrameStyle.BackgroundColor = WebExamplesUtilities.ColorFromDropDownList(PageBackgroundColorDropDownList)
			If HasShadowCheckBox.Checked Then
				imageFrameStyle.ShadowStyle.Type = ShadowType.LinearBlur
			Else
				imageFrameStyle.ShadowStyle.Type = ShadowType.None
			End If

			nChartControl1.BackgroundStyle.FrameStyle = imageFrameStyle

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Image Border")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)

			' add the first bar
			Dim bar1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.DataLabelStyle.Visible = False
			bar1.Values.FillRandomRange(Random, 5, 10, 40)

			' add the second bar
			Dim bar2 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.MultiBarMode = MultiBarMode.Stacked
			bar2.DataLabelStyle.Visible = False
			bar2.Values.FillRandomRange(Random, 5, 10, 40)

			' add the third bar
			Dim bar3 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar3.MultiBarMode = MultiBarMode.Stacked
			bar3.DataLabelStyle.Visible = False
			bar3.Values.FillRandomRange(Random, 5, 10, 40)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace