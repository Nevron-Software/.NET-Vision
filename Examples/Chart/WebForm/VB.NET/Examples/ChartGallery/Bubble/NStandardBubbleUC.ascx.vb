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
	Public Partial Class NStandardBubbleUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(BubbleShapeDropDownList, GetType(PointShape))
				BubbleShapeDropDownList.SelectedIndex = 6

				WebExamplesUtilities.FillComboWithValues(MinBubbleSizeDropDownList, 0, 30, 5)
				WebExamplesUtilities.FillComboWithValues(MaxBubbleSizeDropDownList, 0, 30, 5)

				MinBubbleSizeDropDownList.SelectedIndex = 2
				MaxBubbleSizeDropDownList.SelectedIndex = 4
				DifferentColorsCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bubble Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = False

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.DisplayDataPointsBetweenTicks = False
			scaleX.MajorTickMode = MajorTickMode.CustomTicks
			scaleX.CustomMajorTicks.AddRange(New Long() { 0, 1, 2, 3, 4, 5 })
			scaleX.CustomLabels.Add(New NCustomValueLabel(0, "A"))
			scaleX.CustomLabels.Add(New NCustomValueLabel(1, "B"))
			scaleX.CustomLabels.Add(New NCustomValueLabel(2, "C"))
			scaleX.CustomLabels.Add(New NCustomValueLabel(3, "D"))
			scaleX.CustomLabels.Add(New NCustomValueLabel(4, "E"))
			scaleX.CustomLabels.Add(New NCustomValueLabel(5, "F"))

			' add interlace stripe
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY.StripStyles.Add(stripStyle)

			Dim bubble As NBubbleSeries = CType(chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			bubble.InflateMargins = True
			bubble.DataLabelStyle.Visible = False
			bubble.Legend.Mode = SeriesLegendMode.DataPoints
			bubble.Legend.Format = "<size> <label>"

			bubble.AddDataPoint(New NBubbleDataPoint(10, 10, "A"))
			bubble.AddDataPoint(New NBubbleDataPoint(15, 20, "B"))
			bubble.AddDataPoint(New NBubbleDataPoint(12, 25, "C"))
			bubble.AddDataPoint(New NBubbleDataPoint(8, 15, "D"))
			bubble.AddDataPoint(New NBubbleDataPoint(14, 17, "E"))
			bubble.AddDataPoint(New NBubbleDataPoint(11, 12, "F"))

			bubble.BubbleShape = CType(BubbleShapeDropDownList.SelectedIndex, PointShape)
			bubble.MinSize = New NLength(MinBubbleSizeDropDownList.SelectedIndex * 5, NRelativeUnit.ParentPercentage)
			bubble.MaxSize = New NLength(MaxBubbleSizeDropDownList.SelectedIndex * 5, NRelativeUnit.ParentPercentage)

			If DifferentColorsCheckBox.Checked Then
				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			Else
				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)
			End If

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace

