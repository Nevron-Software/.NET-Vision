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
	Public Partial Class NExplodedPieUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				ExplodeModeDropDownList.Items.Add("No exploded pies")
				ExplodeModeDropDownList.Items.Add("Explode biggest")
				ExplodeModeDropDownList.Items.Add("Explode smallest")

				ExplodeModeDropDownList.SelectedIndex = 2
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Exploded Pie Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.FillStyle.SetTransparencyPercent(50)
			legend.Data.ExpandMode = LegendExpandMode.RowsFixed
			legend.Data.RowCount = 2
			legend.ContentAlignment = ContentAlignment.TopLeft
			legend.Location = New NPointL(New NLength(99, NRelativeUnit.ParentPercentage), New NLength(99, NRelativeUnit.ParentPercentage))

			' by default the control contains a Cartesian chart -> remove it and create a Pie chart
			Dim chart As NChart = New NPieChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			' configure the chart
			chart.Enable3D = True
			chart.DisplayOnLegend = nChartControl1.Legends(0)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(12, NRelativeUnit.ParentPercentage), New NLength(12, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(76, NRelativeUnit.ParentPercentage), New NLength(68, NRelativeUnit.ParentPercentage))

			' add a pie serires
			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pie.PieStyle = PieStyle.SmoothEdgePie
			pie.PieEdgePercent = 50
			pie.DataLabelStyle.Visible = False
			pie.Legend.Mode = SeriesLegendMode.DataPoints
			pie.Legend.Format = "<label> <percent>"
			pie.Legend.TextStyle.FontStyle = New NFontStyle("Arial", 8)

			pie.AddDataPoint(New NDataPoint(0, "Ships"))
			pie.AddDataPoint(New NDataPoint(0, "Trains"))
			pie.AddDataPoint(New NDataPoint(0, "Cars"))
			pie.AddDataPoint(New NDataPoint(0, "Buses"))
			pie.AddDataPoint(New NDataPoint(0, "Airplanes"))

			pie.Values.FillRandomRange(Random, pie.Values.Count, 1, 20)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			Select Case ExplodeModeDropDownList.SelectedIndex
				Case 0

				Case 1
					SetDetachments(pie.Values.FindMaxValue(), pie)

				Case 2
					SetDetachments(pie.Values.FindMinValue(), pie)
			End Select
		End Sub

		Private Sub SetDetachments(ByVal nExplodedIndex As Integer, ByVal pieSeries As NPieSeries)
			Dim nCount As Integer = pieSeries.Values.Count

			Dim i As Integer = 0
			Do While i < nCount
				If i = nExplodedIndex Then
					pieSeries.Detachments.Add(5.0f)
				Else
					pieSeries.Detachments.Add(0.0f)
				End If
				i += 1
			Loop
		End Sub
	End Class
End Namespace
