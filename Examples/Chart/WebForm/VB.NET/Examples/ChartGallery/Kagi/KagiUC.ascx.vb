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
	Public Partial Class KagiUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithColorNames(UpColorDropDownList, KnownColor.Black)
				WebExamplesUtilities.FillComboWithColorNames(DownColorDropDownList, KnownColor.Black)
				WebExamplesUtilities.FillComboWithValues(UpStrokeDropDownList, 1, 3, 1)
				UpStrokeDropDownList.SelectedIndex = 1
				WebExamplesUtilities.FillComboWithValues(DownStrokeDropDownList, 1, 3, 1)
				reversalAmountDropdownlist.Items.AddRange(New ListItem() { New ListItem("0.5"), New ListItem("1"), New ListItem("2"), New ListItem("1%"), New ListItem("2%"), New ListItem("5%") })
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' no legend
			nChartControl1.Legends.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Kagi Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

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

			'Setup Kagi series
			Dim kagi As NKagiSeries = CType(chart.Series.Add(SeriesType.Kagi), NKagiSeries)
			kagi.UpStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(UpColorDropDownList)
			kagi.DownStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(DownColorDropDownList)
			kagi.UpStrokeStyle.Width = New NLength(Convert.ToInt32(UpStrokeDropDownList.SelectedValue))
			kagi.DownStrokeStyle.Width = New NLength(Convert.ToInt32(DownStrokeDropDownList.SelectedValue))
			kagi.UseXValues = True

			Select Case reversalAmountDropdownlist.SelectedIndex
				Case 0
					kagi.ReversalAmount = 0.5
					kagi.ReversalAmountInPercents = False

				Case 1
					kagi.ReversalAmount = 1
					kagi.ReversalAmountInPercents = False

				Case 2
					kagi.ReversalAmount = 2
					kagi.ReversalAmountInPercents = False

				Case 3
					kagi.ReversalAmount = 1
					kagi.ReversalAmountInPercents = True

				Case 4
					kagi.ReversalAmount = 2
					kagi.ReversalAmountInPercents = True

				Case 5
					kagi.ReversalAmount = 5
					kagi.ReversalAmountInPercents = True
			End Select

			GenerateData(kagi)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenerateData(ByVal series As NKagiSeries)
			Dim dataGenerator As NStockDataGenerator = New NStockDataGenerator(New NRange1DD(50, 350), 0.002, 2)
			dataGenerator.Reset()

			Dim dt As DateTime = New DateTime(2007, 1, 1)

			For i As Integer = 0 To 99
				series.Values.Add(dataGenerator.GetNextValue())
				series.XValues.Add(dt)

				dt = dt.AddDays(1)
			Next i
		End Sub
	End Class
End Namespace
