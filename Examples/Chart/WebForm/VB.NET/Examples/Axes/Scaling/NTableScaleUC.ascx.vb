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
	Public Partial Class NTableScaleUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				ShowRowInterlacingCheckBox.Checked = True
				ShowColumnInterlacingCheckBox.Checked = True
				ShowRowHeadersCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			nChartControl1.Legends(0).Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Table Scale")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim yAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)
			Dim linearScale As NLinearScaleConfigurator = TryCast(yAxis.ScaleConfigurator, NLinearScaleConfigurator)
			Dim strip As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			strip.Interlaced = True
			strip.SetShowAtWall(ChartWallType.Back, True)
			linearScale.StripStyles.Add(strip)

			' create two series with random data
			Dim random As Random = New System.Random()
			Dim alcoholSales As NBarSeries = New NBarSeries()
			alcoholSales.Name = "Alcohol"
			alcoholSales.MultiBarMode = MultiBarMode.Stacked
			alcoholSales.Values.FillRandom(random, 12)
			alcoholSales.DataLabelStyle.Visible = False
			chart.Series.Add(alcoholSales)

			Dim beveragesSales As NBarSeries = New NBarSeries()
			beveragesSales.Name = "Beverages"
			beveragesSales.MultiBarMode = MultiBarMode.Stacked
			beveragesSales.Values.FillRandom(random, 12)
			beveragesSales.DataLabelStyle.Visible = False
			chart.Series.Add(beveragesSales)

			' create a table scale
			Dim tableScale As NTableScaleConfigurator = New NTableScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = tableScale

			Dim customRow As NCustomTableScaleRow = New NCustomTableScaleRow()
			customRow.Items = New Object() { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" }
			tableScale.Rows.Add(customRow)

			Dim i As Integer = 0
			Do While i < chart.Series.Count
				Dim row As NSeriesTableScaleRow = New NSeriesTableScaleRow()

				row.Series = chart.Series(i)

				' whether to show row headers
				row.ShowLeftRowHeader = ShowRowHeadersCheckBox.Checked
				tableScale.Rows.Add(row)
				i += 1
			Loop

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))

			' row interlacing
			If ShowRowInterlacingCheckBox.Checked Then
				Dim interlaceStyle As NTableInterlaceStyle = New NTableInterlaceStyle()

				interlaceStyle.Type = TableInterlaceStyleType.Row
				interlaceStyle.Length = 1
				interlaceStyle.Interval = 1
				interlaceStyle.FillStyle = New NColorFillStyle(Color.FromArgb(124, Color.Beige))

				tableScale.InterlaceStyles.Add(interlaceStyle)
			End If

			' col interlacing
			If ShowColumnInterlacingCheckBox.Checked Then
				Dim interlaceStyle As NTableInterlaceStyle = New NTableInterlaceStyle()

				interlaceStyle.Type = TableInterlaceStyleType.Col
				interlaceStyle.Length = 1
				interlaceStyle.Interval = 1
				interlaceStyle.FillStyle = New NColorFillStyle(Color.FromArgb(124, Color.Red))

				tableScale.InterlaceStyles.Add(interlaceStyle)
			End If
		End Sub
	End Class
End Namespace
