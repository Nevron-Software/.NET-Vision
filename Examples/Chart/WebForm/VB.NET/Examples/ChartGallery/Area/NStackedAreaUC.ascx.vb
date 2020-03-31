Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Dom
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStackedAreaUC
		Inherits NExampleUC
		Private Const nCategoriesCount As Integer = 6

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' fill the data labels combos
				FirstAreaDataLabelsCombo.Items.Add("Value")
				FirstAreaDataLabelsCombo.Items.Add("Total")
				FirstAreaDataLabelsCombo.Items.Add("Cumulative")
				FirstAreaDataLabelsCombo.Items.Add("Percent")
				FirstAreaDataLabelsCombo.Items.Add("No Label")
				FirstAreaDataLabelsCombo.SelectedIndex = 0

				SecondAreaDataLabelsCombo.Items.Add("Value")
				SecondAreaDataLabelsCombo.Items.Add("Total")
				SecondAreaDataLabelsCombo.Items.Add("Cumulative")
				SecondAreaDataLabelsCombo.Items.Add("Percent")
				SecondAreaDataLabelsCombo.Items.Add("No Label")
				SecondAreaDataLabelsCombo.SelectedIndex = 0

				ThirdAreaDataLabelsCombo.Items.Add("Value")
				ThirdAreaDataLabelsCombo.Items.Add("Total")
				ThirdAreaDataLabelsCombo.Items.Add("Cumulative")
				ThirdAreaDataLabelsCombo.Items.Add("Percent")
				ThirdAreaDataLabelsCombo.Items.Add("No Label")
				ThirdAreaDataLabelsCombo.SelectedIndex = 0

				StackStyleCombo.Items.Add("Stacked")
				StackStyleCombo.Items.Add("Stacked %")
				StackStyleCombo.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stacked Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType(){ ChartWallType.Back, ChartWallType.Left }
			scaleY.StripStyles.Add(stripStyle)

			' add the first area
			Dim area1 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area1.MultiAreaMode = MultiAreaMode.Series
			area1.Name = "Area 1"
			area1.DataLabelStyle.Visible = True
			area1.DataLabelStyle.VertAlign = VertAlign.Center
			area1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			area1.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			area1.Values.ValueFormatter = New NNumericValueFormatter("0.##")

			' add the second area
			Dim area2 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area2.MultiAreaMode = MultiAreaMode.Stacked
			area2.Name = "Area 2"
			area2.DataLabelStyle.Visible = True
			area2.DataLabelStyle.VertAlign = VertAlign.Center
			area2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			area2.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			area2.Values.ValueFormatter = New NNumericValueFormatter("0.##")

			' add the third area
			Dim area3 As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area3.MultiAreaMode = MultiAreaMode.Stacked
			area3.Name = "Area 3"
			area3.DataLabelStyle.Visible = True
			area3.DataLabelStyle.VertAlign = VertAlign.Center
			area3.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			area3.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			area3.Values.ValueFormatter = New NNumericValueFormatter("0.##")

			area1.DataLabelStyle.Format = GetDataLabelsFormatString(FirstAreaDataLabelsCombo)
			area2.DataLabelStyle.Format = GetDataLabelsFormatString(SecondAreaDataLabelsCombo)
			area3.DataLabelStyle.Format = GetDataLabelsFormatString(ThirdAreaDataLabelsCombo)

			Select Case StackStyleCombo.SelectedIndex
				Case 0
					area2.MultiAreaMode = MultiAreaMode.Stacked
					area3.MultiAreaMode = MultiAreaMode.Stacked

				Case 1
					area2.MultiAreaMode = MultiAreaMode.StackedPercent
					area3.MultiAreaMode = MultiAreaMode.StackedPercent
					scaleY.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.Percentage)
			End Select

			' fill with random data
			area1.Values.FillRandomRange(Random, nCategoriesCount, 10, 20)
			area2.Values.FillRandomRange(Random, nCategoriesCount, 10, 20)
			area3.Values.FillRandomRange(Random, nCategoriesCount, 10, 20)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Function GetDataLabelsFormatString(ByVal list As DropDownList) As String
			Select Case list.SelectedIndex
				Case 0
					Return "<value>"

				Case 1
					Return "<total>"

				Case 2
					Return "<cumulative>"

				Case 3
					Return "<percent>"
			End Select

			Return ""
		End Function
	End Class
End Namespace