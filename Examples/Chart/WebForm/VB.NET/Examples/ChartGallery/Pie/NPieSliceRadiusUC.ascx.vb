Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports System
Imports System.Drawing
Imports System.Web.UI.WebControls

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStandardPieUC
		Inherits NExampleUC
		Protected Label5 As Label

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Pie Slice Radius")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.FillStyle = New NColorFillStyle(Color.FromArgb(124, 255, 255, 255))
			legend.HorizontalBorderStyle.Width = New NLength(0)
			legend.VerticalBorderStyle.Width = New NLength(0)
			legend.SetPredefinedLegendStyle(PredefinedLegendStyle.Bottom)
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed
			legend.Data.RowCount = 2
			legend.Data.CellMargins = New NMarginsL(New NLength(6, NGraphicsUnit.Pixel), New NLength(3, NGraphicsUnit.Pixel), New NLength(6, NGraphicsUnit.Pixel), New NLength(3, NGraphicsUnit.Pixel))
			legend.Data.MarkSize = New NSizeL(New NLength(7, NGraphicsUnit.Pixel), New NLength(7, NGraphicsUnit.Pixel))

			' by default the control contains a Cartesian chart -> remove it and create a Pie chart
			Dim pieChart As NPieChart = New NPieChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(pieChart)

			pieChart.Enable3D = True
			pieChart.InnerRadius = New NLength(0)
			pieChart.DisplayOnLegend = nChartControl1.Legends(0)
			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)
			pieChart.BoundsMode = BoundsMode.Fit
			pieChart.Location = New NPointL(New NLength(12, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			pieChart.Size = New NSizeL(New NLength(76, NRelativeUnit.ParentPercentage), New NLength(68, NRelativeUnit.ParentPercentage))

			Dim pieSeries As NPieSeries = New NPieSeries()
			pieChart.Series.Add(pieSeries)
			pieSeries.PieEdgePercent = 30
			pieSeries.PieStyle = PieStyle.SmoothEdgePie
			pieSeries.Legend.Mode = SeriesLegendMode.DataPoints
			pieSeries.Legend.Format = "<label> <percent>"
			pieSeries.UseBeginEndWidthPercents = True

			For i As Integer = 0 To 8
				pieSeries.Values.Add(10 + i * 10)
				pieSeries.BeginWidthPercents.Add(0)
				pieSeries.EndWidthPercents.Add(10 + i * 10)
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub
	End Class
End Namespace
