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
	Public Partial Class NWatermarksGeneralUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				CountryDropDownList.Items.Add("USA")
				CountryDropDownList.Items.Add("CHINA")
				CountryDropDownList.Items.Add("JAPAN")
				CountryDropDownList.Items.Add("GERMANY")
				CountryDropDownList.Items.Add("FRANCE")
				CountryDropDownList.Items.Add("UK")

				CountryDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithPercents(XPositionDropDownList, 10)
				XPositionDropDownList.SelectedIndex = 0
				WebExamplesUtilities.FillComboWithPercents(YPositionDropDownList, 10)
				YPositionDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithPercents(FlagTransparencyDropDownList, 10)
				FlagTransparencyDropDownList.SelectedIndex = 5

				ContentAlignmentDropDownList.Items.Add("BottomCenter")
				ContentAlignmentDropDownList.Items.Add("BottomLeft")
				ContentAlignmentDropDownList.Items.Add("BottomRight")
				ContentAlignmentDropDownList.Items.Add("MiddleCenter")
				ContentAlignmentDropDownList.Items.Add("MiddleLeft")
				ContentAlignmentDropDownList.Items.Add("MiddleRight")
				ContentAlignmentDropDownList.Items.Add("TopCenter")
				ContentAlignmentDropDownList.Items.Add("TopLeft")
				ContentAlignmentDropDownList.Items.Add("TopRight")
				ContentAlignmentDropDownList.SelectedIndex = 2
			End If

			' enable the antialiasing of the whole scene
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' by default the chart contains a cartesian chart which cannot display a pie series
			nChartControl1.Charts.Clear()

			' create the legend
			Dim legend As NLegend = New NLegend()
			legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.FillStyle.SetTransparencyPercent(50)
			legend.OuterBottomBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterLeftBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterRightBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterTopBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.TopRight)

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Car sales for " & CountryDropDownList.SelectedItem.Text)
			title.ContentAlignment = ContentAlignment.TopRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(98, NRelativeUnit.ParentPercentage))
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' create the watermark
			Dim watermark As NWatermark = New NWatermark()
			watermark.FillStyle = New NImageFillStyle(Me.MapPathSecure(Me.TemplateSourceDirectory & "\" & CountryDropDownList.SelectedItem.Text & ".GIF"))
			watermark.Location = New NPointL(New NLength(XPositionDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage), New NLength(YPositionDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage))
			watermark.UseAutomaticSize = False
			watermark.Size = New NSizeL(150, 100)
			watermark.ContentAlignment = CType(ContentAlignment.Parse(GetType(ContentAlignment), ContentAlignmentDropDownList.SelectedItem.Text), ContentAlignment)
			watermark.FillStyle.SetTransparencyPercent(FlagTransparencyDropDownList.SelectedIndex * 10.0f)
			watermark.StandardFrameStyle.Visible = False

			' create the chart
			Dim chart As NPieChart = New NPieChart()
			chart.Enable3D = True
			chart.Depth = 5

			If ShowFlagAboveChartBox.Checked Then
				nChartControl1.Panels.Add(chart)
				nChartControl1.Panels.Add(legend)
				nChartControl1.Panels.Add(watermark)
			Else
				nChartControl1.Panels.Add(watermark)
				nChartControl1.Panels.Add(chart)
				nChartControl1.Panels.Add(legend)
			End If

			chart.DisplayOnLegend = legend
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)

			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pie.PieStyle = PieStyle.SmoothEdgePie
			pie.LabelMode = PieLabelMode.Center
			pie.Legend.Mode = SeriesLegendMode.DataPoints
			pie.DataLabelStyle.Visible = False

			pie.AddDataPoint(New NDataPoint(0, "Toyota"))
			pie.AddDataPoint(New NDataPoint(0, "Honda"))
			pie.AddDataPoint(New NDataPoint(0, "Volkswagen"))
			pie.AddDataPoint(New NDataPoint(0, "Chrysler"))
			pie.AddDataPoint(New NDataPoint(0, "Ford"))
			pie.Values.FillRandom(Random, 5)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(pie)
		End Sub
	End Class
End Namespace
