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
	Public Partial Class NSortedPieUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				SortDropDownList.Items.Add("Ascending")
				SortDropDownList.Items.Add("Descending")
				SortDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Sorted Pie Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Visible = False
			legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.Location = New NPointL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(0, NRelativeUnit.ParentPercentage))

			' by default the control contains a Cartesian chart -> remove it and create a Pie chart
			Dim chart As NChart = New NPieChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			chart.Enable3D = False
			chart.DisplayOnLegend = nChartControl1.Legends(0)
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(16, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))


			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pie.PieStyle = PieStyle.SmoothEdgePie
			pie.Legend.Mode = SeriesLegendMode.DataPoints
			pie.Legend.Format = "<label> <percent>"

			pie.AddDataPoint(New NDataPoint(0, "Cars"))
			pie.AddDataPoint(New NDataPoint(0, "Trains"))
			pie.AddDataPoint(New NDataPoint(0, "Buses"))
			pie.AddDataPoint(New NDataPoint(0, "Airplanes"))
			pie.AddDataPoint(New NDataPoint(0, "Ships"))
			pie.Values.FillRandomRange(Random, 5, 1, 40)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			Dim included As DataSeriesMask = DataSeriesMask.RandomAccess
			Dim excluded As DataSeriesMask = DataSeriesMask.PieDetachments
			Dim arr As NDataSeriesCollection = pie.GetDataSeries(included, excluded, False)

			Dim masterDataSeries As Integer = arr.FindByMask(DataSeriesMask.Values)

			If SortDropDownList.SelectedIndex = 0 Then
				arr.Sort(masterDataSeries, DataSeriesSortOrder.Ascending)
			Else
				arr.Sort(masterDataSeries, DataSeriesSortOrder.Descending)
			End If
		End Sub
	End Class
End Namespace