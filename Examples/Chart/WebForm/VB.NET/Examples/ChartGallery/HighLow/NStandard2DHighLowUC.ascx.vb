Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports Nevron.Dom
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStandard2DHighLowUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				DataLabelFormatDropDownList.Items.Add("high")
				DataLabelFormatDropDownList.Items.Add("low")
				DataLabelFormatDropDownList.Items.Add("high low")
				DataLabelFormatDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(PointShape))
				MarkerShapeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithColorNames(HighAreaColorDropDownList, KnownColor.LightSlateGray)
				WebExamplesUtilities.FillComboWithColorNames(LowAreaColorDropDownList, KnownColor.DarkOrange)
				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 5, 1)
				MarkerSizeDropDownList.SelectedIndex = 2
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D High-Low Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.DisplayDataPointsBetweenTicks = False

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorGridStyle.LineStyle.Color = Color.LightGray

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			Dim highLow As NHighLowSeries = CType(chart.Series.Add(SeriesType.HighLow), NHighLowSeries)
			highLow.Name = "High-Low Series"
			highLow.InflateMargins = True
			highLow.Legend.Mode = SeriesLegendMode.SeriesLogic
			highLow.MarkerStyle.FillStyle = New NColorFillStyle(Red)
			highLow.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			highLow.LowValues.ValueFormatter = New NNumericValueFormatter("0.#")
			highLow.HighValues.ValueFormatter = New NNumericValueFormatter("0.#")

			highLow.HighFillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(HighAreaColorDropDownList))
			highLow.LowFillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(LowAreaColorDropDownList))

			highLow.DropLines = ShowDropLinesCheckBox.Checked
			highLow.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked

			Select Case DataLabelFormatDropDownList.SelectedIndex
				Case 0
					highLow.DataLabelStyle.Format = "<high_value>"
				Case 1
					highLow.DataLabelStyle.Format = "<low_value>"
				Case 2
					highLow.DataLabelStyle.Format = "<high_value> - <low_value>"
			End Select

			MarkerShapeDropDownList.Enabled = ShowMarkersCheckBox.Checked
			MarkerSizeDropDownList.Enabled = ShowMarkersCheckBox.Checked

			highLow.MarkerStyle.Visible = ShowMarkersCheckBox.Checked
			highLow.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
			highLow.MarkerStyle.Width = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
			highLow.MarkerStyle.Height = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex),NRelativeUnit.ParentPercentage)

			GenerateData(highLow)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub GenerateData(ByVal highLow As NHighLowSeries)
			highLow.ClearDataPoints()

			For i As Integer = 0 To 20
				Dim d1 As Double = Math.Log(i + 1) + 0.1 * Random.NextDouble()
				Dim d2 As Double = d1 + Math.Cos(0.33 * i) + 0.1 * Random.NextDouble()

				highLow.HighValues.Add(d1)
				highLow.LowValues.Add(d2)
			Next i
		End Sub
	End Class
End Namespace
