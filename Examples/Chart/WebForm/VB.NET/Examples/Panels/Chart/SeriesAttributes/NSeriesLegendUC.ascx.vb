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
	Public Partial Class NSeriesLegendUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' init form controls
				FormatDropDownList.Items.Add("[value] [label]")
				FormatDropDownList.Items.Add("[index] [cumulative]")
				FormatDropDownList.Items.Add("[percent] [total]")
				FormatDropDownList.SelectedIndex = 0

				ModeDropDownList.Items.Add("Disabled")
				ModeDropDownList.Items.Add("Series")
				ModeDropDownList.Items.Add("DataPoints")
				ModeDropDownList.Items.Add("SeriesCustom")
				ModeDropDownList.SelectedIndex = 2

				WebExamplesUtilities.FillComboWithEnumValues(PointShapeDropDownList, GetType(PointShape))
				PointShapeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithColorNames(ColorDropDownList, KnownColor.DarkOrange)

				DifferentColorsCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = New NLabel("Series Legend")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			nChartControl1.Panels.Add(title)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.DataLabelStyle.Visible = False
			point.InflateMargins = True
			point.PointShape = CType(PointShapeDropDownList.SelectedIndex, PointShape)
			point.Legend.Mode = CType(ModeDropDownList.SelectedIndex, SeriesLegendMode)

			point.AddDataPoint(New NDataPoint(16, "Agriculture"))
			point.AddDataPoint(New NDataPoint(42, "Construction"))
			point.AddDataPoint(New NDataPoint(56, "Manufacturing"))
			point.AddDataPoint(New NDataPoint(23, "Services"))
			point.AddDataPoint(New NDataPoint(47, "Healthcare"))
			point.AddDataPoint(New NDataPoint(38, "Finance"))

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))

			If DifferentColorsCheckBox.Checked Then
				Dim palette As NChartPalette = New NChartPalette()
				palette.SetPredefinedPalette(ChartPredefinedPalette.Nevron)

				Dim i As Integer = 0
				Do While i < point.Values.Count
					point.FillStyles(i) = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))
					i += 1
				Loop
				ColorDropDownList.Enabled = False
			Else
				point.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(ColorDropDownList))
				ColorDropDownList.Enabled = True
			End If

			If ModeDropDownList.SelectedIndex = 2 Then
				FormatDropDownList.Enabled = True
				point.Legend.Format = WebExamplesUtilities.GetXmlFormatString(FormatDropDownList.SelectedItem.Text)
			Else
				FormatDropDownList.Enabled = False
			End If
		End Sub
	End Class
End Namespace
