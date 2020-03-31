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
	Public Partial Class NSortingUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				SortOrderDropDownList.Items.Add("Ascending")
				SortOrderDropDownList.Items.Add("Descending")
				SortOrderDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Sorting Data")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(60, 90, 108))
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			' add a new bar serie
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Values.FillRandom(Random, 6)
			bar.Labels.FillRandom(Random, 6)

			Dim i As Integer = 0
			Do While i < bar.Values.Count
				bar.FillStyles(i) = New NColorFillStyle(WebExamplesUtilities.RandomColor())
				i += 1
			Loop

			bar.Legend.Mode = SeriesLegendMode.DataPoints
			bar.Values.Sort(CType(SortOrderDropDownList.SelectedIndex, DataSeriesSortOrder))
		End Sub
	End Class
End Namespace
