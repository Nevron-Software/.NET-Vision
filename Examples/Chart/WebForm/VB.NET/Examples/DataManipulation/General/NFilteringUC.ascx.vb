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
	Public Partial Class NFilteringUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				FilterDropDownList.Items.Add("More")
				FilterDropDownList.Items.Add("Less")
				FilterDropDownList.Items.Add("Equal")
				FilterDropDownList.Items.Add("More Or Equal")
				FilterDropDownList.Items.Add("Less Or Equal")
				FilterDropDownList.Items.Add("Not Equal")
				FilterDropDownList.SelectedIndex = 0

				ValueTextBox.Text = "50"
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Filtering Data")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(60, 90, 108))
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(85, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			Dim rnd As Random = New Random(0)

			Dim nBar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar.DataLabelStyle.Format = "<value>"
			nBar.Values.FillRandom(rnd, 10)

			' configure the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Mode = LegendMode.Manual
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly

			Dim item As NLegendItemCellData = New NLegendItemCellData("Filtered Data Points", LegendMarkShape.Rectangle, New NStrokeStyle(1, Color.Black), New NColorFillStyle(Color.Red), New NShadowStyle(), New NTextStyle())
			legend.Data.Items.Add(item)

			item = New NLegendItemCellData("Series Data Points", LegendMarkShape.Rectangle, New NStrokeStyle(1, Color.Black), CType(nBar.FillStyle.Clone(), NFillStyle), New NShadowStyle(), New NTextStyle())
			legend.Data.Items.Add(item)

			Filter(nBar)
		End Sub

		Private Sub Filter(ByVal bar As NBarSeries)
			Dim subsetAll As NDataSeriesSubset = New NDataSeriesSubset()
			Dim subsetFilter As NDataSeriesSubset = New NDataSeriesSubset()

			subsetAll.AddRange(0, bar.Values.Count - 1)

			Try
				Dim dValue As Double = Double.Parse(ValueTextBox.Text)

				Dim method As Nevron.Chart.CompareMethod = CType(FilterDropDownList.SelectedIndex, Nevron.Chart.CompareMethod)

				subsetFilter = bar.Values.Filter(method, dValue)

				' apply red color only to the bars in the filter subset
				For Each index As Integer In subsetFilter
					bar.FillStyles(index) = New NColorFillStyle(Color.Red)
				Next index
			Catch
			End Try
		End Sub
	End Class
End Namespace
