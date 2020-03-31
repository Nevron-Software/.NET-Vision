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

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NDataLabelsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				DefaultFormatDropDown.Items.Add("[value] [label]")
				DefaultFormatDropDown.Items.Add("[index] [cumulative]")
				DefaultFormatDropDown.Items.Add("[percent] [total]")
				DefaultFormatDropDown.SelectedIndex = 0

				DefaultVerticalAlignDropDown.Items.Add("Center")
				DefaultVerticalAlignDropDown.Items.Add("Top")
				DefaultVerticalAlignDropDown.Items.Add("Bottom")
				DefaultVerticalAlignDropDown.SelectedIndex = 1

				DefaultLabelVisibleCheck.Checked = True
				DefaultBackplaneVisibleCheck.Checked = True

				Label3FormatDropDown.Items.Add("Individual")
				Label3FormatDropDown.Items.Add("[value] [label]")
				Label3FormatDropDown.Items.Add("[index] [cumulative]")
				Label3FormatDropDown.Items.Add("[percent] [total]")
				Label3FormatDropDown.SelectedIndex = 0

				Label3VerticalAlignDropDown.Items.Add("Center")
				Label3VerticalAlignDropDown.Items.Add("Top")
				Label3VerticalAlignDropDown.Items.Add("Bottom")
				Label3VerticalAlignDropDown.SelectedIndex = 1

				Label3VisibleCheck.Checked = True
				Backplane3VisibleCheck.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Legends(0).Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Data Labels")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Axis(StandardAxis.Depth).Visible = False

			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.AddDataPoint(New NDataPoint(10, "Item A"))
			bar.AddDataPoint(New NDataPoint(20, "Item B"))
			bar.AddDataPoint(New NDataPoint(30, "Item C"))
			bar.AddDataPoint(New NDataPoint(25, "Item D"))
			bar.AddDataPoint(New NDataPoint(29, "Item E"))

			' add interlaced stripe
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' apply style sheet
			Dim fillStyleSheet As NFillStyleSheetConfigurator = New NFillStyleSheetConfigurator()
			fillStyleSheet.SeriesFillTemplate = New NGradientFillStyleTemplate(GradientStyle.Horizontal, GradientVariant.Variant1)
			fillStyleSheet.MultiColorSeries = True
			fillStyleSheet.Palette.SetPredefinedPalette(ChartPredefinedPalette.Nature)
			Dim strokeStyleSheet As NStrokeStyleSheetConfigurator = New NStrokeStyleSheetConfigurator()
			strokeStyleSheet.MultiColorSeries = True
			strokeStyleSheet.ApplyToDataLabels = False
			strokeStyleSheet.Palette.SetPredefinedPalette(ChartPredefinedPalette.Nature)

			Dim styleSheet As NStyleSheet = New NStyleSheet()
			fillStyleSheet.ConfigureSheet(styleSheet)
			strokeStyleSheet.ConfigureSheet(styleSheet)
			styleSheet.Apply(bar)

			' add a different data label for data point 3
			Dim label As NDataLabelStyle = New NDataLabelStyle()
			label.TextStyle.FontStyle.Style = FontStyle.Bold
			label.TextStyle.FillStyle = New NColorFillStyle(Color.Crimson)
			label.TextStyle.BackplaneStyle.Inflate = New NSizeL(3, 3)
			label.TextStyle.BackplaneStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.White, Color.Lavender)
			bar.DataLabelStyles(3) = label

			label.Format = WebExamplesUtilities.GetXmlFormatString(Label3FormatDropDown.SelectedItem.Text)
			label.VertAlign = CType(Label3VerticalAlignDropDown.SelectedIndex, VertAlign)
			label.Visible = Label3VisibleCheck.Checked
			label.TextStyle.BackplaneStyle.Visible = Backplane3VisibleCheck.Checked

			bar.DataLabelStyle.Format = WebExamplesUtilities.GetXmlFormatString(DefaultFormatDropDown.SelectedItem.Text)
			bar.DataLabelStyle.VertAlign = CType(DefaultVerticalAlignDropDown.SelectedIndex, VertAlign)
			bar.DataLabelStyle.Visible = DefaultLabelVisibleCheck.Checked
			bar.DataLabelStyle.TextStyle.BackplaneStyle.Visible = DefaultBackplaneVisibleCheck.Checked

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
