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
	Public Partial Class NStandardFloatBar2DUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' init form controls
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, GetType(BarShape))
				BarShapeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithPercents(WidthPercentDropDownList, 10)
				WidthPercentDropDownList.SelectedIndex = 6

				WebExamplesUtilities.FillComboWithColorNames(BarColorDropDownList, KnownColor.Orange)

				DifferentColorsCheckBox.Checked = True
				ShadowsCheckBox.Checked = True
			End If

			' setup legend
			nChartControl1.Legends(0).ShadowStyle.Type = ShadowType.GaussianBlur
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Float Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup floatbar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.BarShape = CType(BarShapeDropDownList.SelectedIndex, BarShape)
			floatBar.WidthPercent = WidthPercentDropDownList.SelectedIndex * 10
			floatBar.BeginValues.ValueFormatter.FormatSpecifier = "0.00"
			floatBar.EndValues.ValueFormatter.FormatSpecifier = "0.00"

			floatBar.DataLabelStyle.Format = "<label>"
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center
			floatBar.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(8)

			' show the begin end values in the legend  
			floatBar.Legend.Format = "<begin> - <end>"
			floatBar.Legend.Mode = SeriesLegendMode.DataPoints
			floatBar.Legend.TextStyle.FontStyle.EmSize = New NLength(8)

			If ShadowsCheckBox.Checked Then
				floatBar.ShadowStyle.Type = ShadowType.LinearBlur
				floatBar.ShadowStyle.Color = Color.FromArgb(125, 60, 60, 60)
				floatBar.ShadowStyle.Offset = New NPointL(3, 3)
			End If

			' fill some data
			floatBar.AddDataPoint(New NFloatBarDataPoint(10, 20, "A"))
			floatBar.AddDataPoint(New NFloatBarDataPoint(20, 50, "B"))
			floatBar.AddDataPoint(New NFloatBarDataPoint(40, 70, "C"))
			floatBar.AddDataPoint(New NFloatBarDataPoint(65, 90, "D"))
			floatBar.AddDataPoint(New NFloatBarDataPoint(40, 60, "E"))
			floatBar.AddDataPoint(New NFloatBarDataPoint(55, 90, "F"))

			' fill styles
			If DifferentColorsCheckBox.Checked Then
				BarColorDropDownList.Enabled = False

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			Else
				BarColorDropDownList.Enabled = True

				floatBar.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromString(BarColorDropDownList.SelectedItem.Text))
			End If

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
