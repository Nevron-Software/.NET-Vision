Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NLegendCustomItemsUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' confgigure chart
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = New NLabel("Legend Custom Items")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(0, 10, 0, 10)
			nChartControl1.Panels.Add(title)

			Dim container As NDockPanel = New NDockPanel()
			container.DockMode = PanelDockMode.Fill
			container.Margins = New NMarginsL(5, 5, 5, 5)
			container.PositionChildPanelsInContentBounds = True
			nChartControl1.Panels.Add(container)

				Dim markShapesNoStroke As NLegend = CreateLegend(container, "Mark Shapes, Margins, Background")

				Dim markShapes As Array = System.Enum.GetValues(GetType(LegendMarkShape))
				Dim palette As NChartPalette = New NChartPalette(ChartPredefinedPalette.Nevron)

				Dim i As Integer = 0
				Do While i < markShapes.Length
					Dim licd As NLegendItemCellData = New NLegendItemCellData()
					Dim markShape As LegendMarkShape = CType(markShapes.GetValue(i), LegendMarkShape)

					licd.Text = markShape.ToString()
					licd.TextStyle.FillStyle = New NColorFillStyle(Color.White)
					licd.TextStyle.FontStyle.EmSize = New NLength(8)
					licd.MarkShape = markShape
					licd.MarkFillStyle = New NColorFillStyle(Color.White)
					licd.MarkBorderStyle.Width = New NLength(0)
					licd.MarkLineStyle.Width = New NLength(0)
					licd.BackgroundFillStyle = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))

					markShapesNoStroke.Data.Items.Add(licd)
					i += 1
				Loop

				' increase teh margins around each cell
				markShapesNoStroke.Data.CellMargins = New NMarginsL(5, 5, 5, 5)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Function CreateLegend(ByVal container As NDockPanel, ByVal title As String) As NLegend
			' configure the legend
			Dim legend As NLegend = New NLegend()
			legend.Header.Text = title
			legend.Mode = LegendMode.Manual
			legend.Data.ExpandMode = LegendExpandMode.HorzWrap
			legend.DockMode = PanelDockMode.Top
			legend.Margins = New NMarginsL(20, 20, 20, 20)
			container.ChildPanels.Add(legend)

			Return legend
		End Function
	End Class
End Namespace
