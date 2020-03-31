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
	Public Partial Class NStandardBarUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(ShapeCombo, GetType(BarShape))
				ShapeCombo.SelectedIndex = 0

				ShowDataLabelsCheck.Checked = False
				UseOriginCheck.Checked = True
				DifferentColorsCheckBox.Checked = True
				OriginTextBox.Text = "0"
			End If

			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' configure chart
			Dim chart As NChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.Enable3D = True
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add bar and change bar color
			Dim barSeries As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			barSeries.Name = "Bar Series"
			barSeries.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			barSeries.DataLabelStyle.Format = "<value>"

			' add some data to the bar series
			barSeries.AddDataPoint(New NDataPoint(18, "Silverlight"))
			barSeries.AddDataPoint(New NDataPoint(15, "Ajax"))
			barSeries.AddDataPoint(New NDataPoint(21, "JackBe"))
			barSeries.AddDataPoint(New NDataPoint(23, "Laszlo"))
			barSeries.AddDataPoint(New NDataPoint(28, "Java FX"))
			barSeries.AddDataPoint(New NDataPoint(29, "Flex"))

			UpdateFillStyles(barSeries)

			If ShowDataLabelsCheck.Checked Then
				barSeries.DataLabelStyle.Visible = True
			Else
				barSeries.DataLabelStyle.Visible = False
				barSeries.DataLabelStyles.Clear()
			End If

			barSeries.BarShape = CType(ShapeCombo.SelectedIndex, BarShape)

			If UseOriginCheck.Checked = True Then
				OriginTextBox.Enabled = True
				barSeries.OriginMode = SeriesOriginMode.CustomOrigin

				Try
					barSeries.Origin = Int32.Parse(OriginTextBox.Text)
				Catch
				End Try
			Else
				OriginTextBox.Enabled = False
				barSeries.OriginMode = SeriesOriginMode.MinValue
			End If

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub UpdateFillStyles(ByVal barSeries As NBarSeries)
			If DifferentColorsCheckBox.Checked Then
				barSeries.Legend.Mode = SeriesLegendMode.DataPoints

				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			Else
				barSeries.Legend.Mode = SeriesLegendMode.Series

				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
				styleSheet.Apply(nChartControl1.Document)
			End If
		End Sub
	End Class
End Namespace
