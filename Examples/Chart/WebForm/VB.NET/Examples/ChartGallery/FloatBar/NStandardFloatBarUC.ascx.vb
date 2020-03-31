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
	Public Partial Class NStandardFloatBarUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, GetType(BarShape))
				BarShapeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithPercents(WidthPercentDropDownList, 10)
				WidthPercentDropDownList.SelectedIndex = 6

				WebExamplesUtilities.FillComboWithPercents(DepthPercentDropDownList, 10)
				DepthPercentDropDownList.SelectedIndex = 3
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Float Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft)
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			Dim i As Integer = 0
			Do While i < monthLetters.Length
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, monthLetters(i)))
				i += 1
			Loop

			' add interlace stripe
			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY.StripStyles.Add(stripStyle)

			' setup floatbar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.DataLabelStyle.Format = "<label>"
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center

			floatBar.BarShape = CType(BarShapeDropDownList.SelectedIndex, BarShape)
			floatBar.WidthPercent = WidthPercentDropDownList.SelectedIndex * 10
			floatBar.DepthPercent = DepthPercentDropDownList.SelectedIndex * 10

			' add bars
			floatBar.AddDataPoint(New NFloatBarDataPoint(2, 10))
			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 16))
			floatBar.AddDataPoint(New NFloatBarDataPoint(9, 17))
			floatBar.AddDataPoint(New NFloatBarDataPoint(12, 21))
			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 18))
			floatBar.AddDataPoint(New NFloatBarDataPoint(7, 18))
			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 11))
			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 12))
			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 17))
			floatBar.AddDataPoint(New NFloatBarDataPoint(6, 15))
			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 10))
			floatBar.AddDataPoint(New NFloatBarDataPoint(1, 7))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
