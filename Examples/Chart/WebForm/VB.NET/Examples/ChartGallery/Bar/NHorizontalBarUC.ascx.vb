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
	Public Partial Class NHorizontalBarUC
		Inherits NExampleUC
		Protected nChart As NChart
		Protected Const categoriesCount As Integer = 6

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Horizontal Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			nChart = nChartControl1.Charts(0)
			nChart.Enable3D = True
			nChart.Height = 70
			nChart.Width = 55
			nChart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft)
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterRight)
			nChart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			linearScale.StripStyles.Add(stripStyle)

			' add a bar series
			Dim b1 As NBarSeries = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			b1.MultiBarMode = MultiBarMode.Series
			b1.Name = "Bar 1"
			b1.DataLabelStyle.Format = "<value>"
			b1.Values.AddRange(New Double() { 10, 27, 43, 71, 89, 93 })

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, nChart, title, Nothing)

			' init form controls
			If IsPostBack Then
				Dim bar As NBarSeries = CType(nChart.Series(0), NBarSeries)
				bar.BarShape = CType(BarShapeDropDownList.SelectedIndex, BarShape)

				If PositiveDataCheckBox.Checked = True Then
					PositiveDataButton_Click(Nothing, Nothing)
				Else
					PositiveAndNegativeDataButton_Click(Nothing, Nothing)
				End If
			Else
				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, GetType(BarShape))
				BarShapeDropDownList.SelectedIndex = 0
			End If
		End Sub

		Protected Sub PositiveDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim bar As NBarSeries = CType(nChart.Series(0), NBarSeries)
			bar.Values.FillRandomRange(Random, categoriesCount, 10, 100)

			PositiveDataCheckBox.Checked = True
		End Sub

		Protected Sub PositiveAndNegativeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim bar As NBarSeries = CType(nChart.Series(0), NBarSeries)
			bar.Values.FillRandomRange(Random, categoriesCount, -100, 100)

			PositiveDataCheckBox.Checked = False
		End Sub
	End Class
End Namespace
