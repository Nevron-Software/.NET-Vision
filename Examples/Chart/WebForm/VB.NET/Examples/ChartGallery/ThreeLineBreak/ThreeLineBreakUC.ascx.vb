Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Drawing

Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class ThreeLineBreakUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithColorNames(UpColorDropDownList, KnownColor.White)
				WebExamplesUtilities.FillComboWithColorNames(DownColorDropDownList, KnownColor.Black)
				BoxWidthDropDownList.Items.AddRange(New ListItem() { New ListItem("50%"), New ListItem("75%"), New ListItem("100%") })
				BoxWidthDropDownList.SelectedIndex = 2
				WebExamplesUtilities.FillComboWithValues(NumberOfLinesDropDownList, 1, 4, 1)
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Three Line Break")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' add interlaced stripe
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup X axis
			Dim priceConfigurator As NPriceScaleConfigurator = New NPriceScaleConfigurator()
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0)
			priceConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator

			' setup line break series
			Dim threeLineBreak As NThreeLineBreakSeries = CType(chart.Series.Add(SeriesType.ThreeLineBreak), NThreeLineBreakSeries)
			threeLineBreak.UseXValues = True

			threeLineBreak.UpFillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(UpColorDropDownList))
			threeLineBreak.DownFillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(DownColorDropDownList))
			threeLineBreak.NumberOfLinesToBreak = Convert.ToInt32(NumberOfLinesDropDownList.SelectedValue)

			Select Case BoxWidthDropDownList.SelectedIndex
				Case 0
					threeLineBreak.BoxWidthPercent = 50

				Case 1
					threeLineBreak.BoxWidthPercent = 75

				Case 2
					threeLineBreak.BoxWidthPercent = 100
			End Select

			GenerateData(threeLineBreak)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateData(ByVal threeLineBreak As NThreeLineBreakSeries)
			Dim dataGenerator As NStockDataGenerator = New NStockDataGenerator(New NRange1DD(50, 350), 0.002, 2)
			dataGenerator.Reset()

			Dim dt As DateTime = New DateTime(2007, 1, 1)

			For i As Integer = 0 To 99
				threeLineBreak.Values.Add(dataGenerator.GetNextValue())
				threeLineBreak.XValues.Add(dt)

				dt = dt.AddDays(1)
			Next i
		End Sub
	End Class
End Namespace