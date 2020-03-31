Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NLegendItemTextFitModeUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' confgigure chart
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Legend Item Text Fit Mode")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(0, 10, 0, 10)
			nChartControl1.Panels.Add(title)

			' configure the legend
			Dim legend As NLegend = New NLegend()
			legend.Header.Text = "Maximum Legend Item Text Size"
			legend.Mode = LegendMode.Manual
			legend.Data.ExpandMode = LegendExpandMode.HorzWrap
			legend.DockMode = PanelDockMode.Top
			legend.Margins = New NMarginsL(20, 20, 20, 20)
			nChartControl1.Panels.Add(legend)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init controls

			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumNames(LegendItemTextFitModeDropDownList, GetType(LegendTextFitMode))
				WebExamplesUtilities.FillComboWithValues(LegendItemMaximumWidthDropDownList, 50, 150, 50)
			End If

		' Update legend items
			Dim markShapes As Array = System.Enum.GetValues(GetType(LegendMarkShape))
			Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)

			Dim i As Integer = 0
			Do While i < markShapes.Length
				Dim licd As NLegendItemCellData = New NLegendItemCellData()
				Dim markShape As LegendMarkShape = CType(markShapes.GetValue(i), LegendMarkShape)

				licd.Text = "Some very long text about mark shape [" & markShape.ToString() & "]"
				licd.MarkShape = markShape
				licd.MarkFillStyle = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))

				licd.TextFitMode = CType(LegendItemTextFitModeDropDownList.SelectedIndex, LegendTextFitMode)
				licd.MaxTextWidth = New NLength(CSng(LegendItemMaximumWidthDropDownList.SelectedIndex + 1) * 50)

				legend.Data.Items.Add(licd)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
