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
	Public Partial Class RenkoUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithColorNames(UpColorDropDownList, KnownColor.White)
				WebExamplesUtilities.FillComboWithColorNames(DownColorDropDownList, KnownColor.Black)
				BoxSizeDropDownList.Items.AddRange(New ListItem() { New ListItem("0.5"), New ListItem("1"), New ListItem("2"), New ListItem("2%"), New ListItem("5%"), New ListItem("10%") })
				BoxSizeDropDownList.SelectedIndex = 1
				BoxWidthDropDownList.Items.AddRange(New ListItem() { New ListItem("50%"), New ListItem("75%"), New ListItem("100%") })
				BoxWidthDropDownList.SelectedIndex = 2
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Renko Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim priceConfigurator As NPriceScaleConfigurator = New NPriceScaleConfigurator()
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator

			' setup Y axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.StripStyles.Add(stripStyle)

			Dim renko As NRenkoSeries = CType(chart.Series.Add(SeriesType.Renko), NRenkoSeries)
			renko.UseXValues = True
			renko.UpFillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(UpColorDropDownList))
			renko.DownFillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(DownColorDropDownList))

			Select Case BoxSizeDropDownList.SelectedIndex
				Case 0
					renko.BoxSize = 0.5
					renko.BoxSizeInPercents = False

				Case 1
					renko.BoxSize = 1
					renko.BoxSizeInPercents = False

				Case 2
					renko.BoxSize = 2
					renko.BoxSizeInPercents = False

				Case 3
					renko.BoxSize = 2
					renko.BoxSizeInPercents = True

				Case 4
					renko.BoxSize = 5
					renko.BoxSizeInPercents = True

				Case 5
					renko.BoxSize = 10
					renko.BoxSizeInPercents = True
			End Select

			Select Case BoxWidthDropDownList.SelectedIndex
				Case 0
					renko.BoxWidthPercent = 50

				Case 1
					renko.BoxWidthPercent = 75

				Case 2
					renko.BoxWidthPercent = 100
			End Select

			GenerateData(renko)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateData(ByVal renko As NRenkoSeries)
			Dim dataGenerator As NStockDataGenerator = New NStockDataGenerator(New NRange1DD(50, 350), 0.02, 10)
			dataGenerator.Reset()

			Dim dt As DateTime = New DateTime(2007, 1, 1)

			For i As Integer = 0 To 19
				renko.Values.Add(dataGenerator.GetNextValue())
				renko.XValues.Add(dt)

				dt = dt.AddDays(1)
			Next i
		End Sub
	End Class
End Namespace
