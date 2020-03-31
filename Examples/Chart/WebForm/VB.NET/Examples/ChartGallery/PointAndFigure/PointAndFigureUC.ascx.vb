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
	Public Partial Class PointAndFigureUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Page.IsPostBack) Then
				WebExamplesUtilities.FillComboWithColorNames(UpColorDropDownList, KnownColor.Red)
				WebExamplesUtilities.FillComboWithColorNames(DownColorDropDownList, KnownColor.Black)
				ProportionalXCheckBox.Checked = False
				ProportionalYCheckBox.Checked = False
				WebExamplesUtilities.FillComboWithFloatValues(BoxSizeDropdownlist, 0.5F, 10, 0.5F)
				BoxSizeDropdownlist.SelectedIndex = 9
				WebExamplesUtilities.FillComboWithValues(ReversalAmountDropDownList, 1, 5, 1)
				ReversalAmountDropDownList.SelectedIndex = 2
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Point and Figure")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup X axis
			Dim priceConfigurator As NPriceScaleConfigurator = New NPriceScaleConfigurator()
			priceConfigurator.LabelValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			priceConfigurator.MajorTickMode = MajorTickMode.AutoMaxCount
			priceConfigurator.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0)
			priceConfigurator.MaxTickCount = 8

			Dim provider As NNumericRangeSamplerProvider = New NNumericRangeSamplerProvider()
			provider.SamplingMode = SamplingMode.CustomStep
			provider.CustomStep = 1
			provider.UseOrigin = True
			provider.Origin = -0.5
			priceConfigurator.MajorGridStyle.RangeSamplerProvider = provider

			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.MajorTickMode = MajorTickMode.CustomStep
			scaleY.CustomStep = 5
			scaleY.OuterMajorTickStyle.Width = New NLength(0)
			scaleY.InnerMajorTickStyle.Width = New NLength(0)
			scaleY.AutoMinorTicks = True
			scaleY.MinorTickCount = 1
			scaleY.RoundToTickMin = False
			scaleY.RoundToTickMax = False
			scaleY.MajorGridStyle.LineStyle.Width = New NLength(0)
			scaleY.MinorGridStyle.LineStyle.Width = New NLength(1)
			scaleY.MinorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }

			Dim highValues As Single() = New Single(19) { 21.3F, 42.4F, 11.2F, 65.7F, 38.0F, 71.3F, 49.54F, 83.7F, 13.9F, 56.12F, 27.43F, 23.1F, 31.0F, 75.4F, 9.3F, 39.12F, 10.0F, 44.23F, 21.76F, 49.2F }
			Dim lowValues As Single() = New Single(19) { 12.1F, 14.32F, 8.43F, 36.0F, 13.5F, 47.34F, 24.54F, 68.11F, 6.87F, 23.3F, 12.12F, 14.54F, 25.0F, 37.2F, 3.9F, 23.11F, 1.9F, 14.0F, 8.23F, 34.21F }

			' setup Point & Figure series
			Dim pointAndFigure As NPointAndFigureSeries = CType(chart.Series.Add(SeriesType.PointAndFigure), NPointAndFigureSeries)

			pointAndFigure.UseXValues = True

			' fill data
			pointAndFigure.HighValues.AddRange(highValues)
			pointAndFigure.LowValues.AddRange(lowValues)

			Dim dt As DateTime = New DateTime(2007, 1, 1)

			For i As Integer = 0 To 19
				pointAndFigure.XValues.Add(dt)
				dt = dt.AddDays(1)
			Next i

			Dim dBoxSize As Double = Convert.ToDouble(BoxSizeDropdownlist.SelectedValue)

			pointAndFigure.BoxSize = dBoxSize
			scaleY.CustomStep = dBoxSize

			pointAndFigure.ProportionalX = ProportionalXCheckBox.Checked
			pointAndFigure.ProportionalY = ProportionalYCheckBox.Checked
			pointAndFigure.ReversalAmount = Convert.ToInt32(ReversalAmountDropDownList.SelectedValue)
			pointAndFigure.UpStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(UpColorDropDownList)
			pointAndFigure.DownStrokeStyle.Color = WebExamplesUtilities.ColorFromDropDownList(DownColorDropDownList)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace