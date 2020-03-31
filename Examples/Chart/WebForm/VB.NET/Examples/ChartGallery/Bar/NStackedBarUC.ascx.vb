Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Dom
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStackedBarUC
		Inherits NExampleUC
		Protected nChart As NChart
		Protected nBar1 As NBarSeries
		Protected nBar2 As NBarSeries
		Protected nBar3 As NBarSeries


		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stacked Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			nChart = nChartControl1.Charts(0)
			nChart.Enable3D = True
			nChart.Axis(StandardAxis.Depth).Visible = False
			nChart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			nChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlace stripe
			Dim scaleY As NLinearScaleConfigurator = TryCast(nChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY.StripStyles.Add(stripStyle)

			' add the first bar
			nBar1 = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar1.Name = "Bar1"
			nBar1.MultiBarMode = MultiBarMode.Series
			nBar1.DataLabelStyle.VertAlign = VertAlign.Center
			nBar1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			nBar1.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			nBar1.Values.ValueFormatter = New NNumericValueFormatter("0")

			' add the second bar
			nBar2 = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar2.Name = "Bar2"
			nBar2.MultiBarMode = MultiBarMode.Stacked
			nBar2.DataLabelStyle.VertAlign = VertAlign.Center
			nBar2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			nBar2.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			nBar2.Values.ValueFormatter = New NNumericValueFormatter("0")

			' add the third bar
			nBar3 = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar3.Name = "Bar3"
			nBar3.MultiBarMode = MultiBarMode.Stacked
			nBar3.DataLabelStyle.VertAlign = VertAlign.Center
			nBar3.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			nBar3.Legend.TextStyle.FontStyle.EmSize = New NLength(8)
			nBar3.Values.ValueFormatter = New NNumericValueFormatter("0")

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, nChart, title, nChartControl1.Legends(0))

			If (Not IsPostBack) Then
				' fill the data labels combos
				FirstBarLabelsDropDownList.Items.Add("Value")
				FirstBarLabelsDropDownList.Items.Add("Total")
				FirstBarLabelsDropDownList.Items.Add("Cumulative")
				FirstBarLabelsDropDownList.Items.Add("Percent")
				FirstBarLabelsDropDownList.Items.Add("No Label")
				FirstBarLabelsDropDownList.SelectedIndex = 0

				SecondBarLabelsDropDownList.Items.Add("Value")
				SecondBarLabelsDropDownList.Items.Add("Total")
				SecondBarLabelsDropDownList.Items.Add("Cumulative")
				SecondBarLabelsDropDownList.Items.Add("Percent")
				SecondBarLabelsDropDownList.Items.Add("No Label")
				SecondBarLabelsDropDownList.SelectedIndex = 0

				ThirdBarLabelsDropDownList.Items.Add("Value")
				ThirdBarLabelsDropDownList.Items.Add("Total")
				ThirdBarLabelsDropDownList.Items.Add("Cumulative")
				ThirdBarLabelsDropDownList.Items.Add("Percent")
				ThirdBarLabelsDropDownList.Items.Add("No Label")
				ThirdBarLabelsDropDownList.SelectedIndex = 0

				StackStyleDropDownList.Items.Add("Stacked")
				StackStyleDropDownList.Items.Add("Stacked %")
				StackStyleDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithEnumValues(BarShapeDropDownList, GetType(BarShape))
				BarShapeDropDownList.SelectedIndex = 0

				PositiveDataCheckBox.Checked = True
			End If

			nBar1.DataLabelStyle.Format = GetDataLabelsFormatString(FirstBarLabelsDropDownList)
			nBar2.DataLabelStyle.Format = GetDataLabelsFormatString(SecondBarLabelsDropDownList)
			nBar3.DataLabelStyle.Format = GetDataLabelsFormatString(ThirdBarLabelsDropDownList)

			Select Case StackStyleDropDownList.SelectedIndex
				Case 0
					nBar2.MultiBarMode = MultiBarMode.Stacked
					nBar3.MultiBarMode = MultiBarMode.Stacked

				Case 1
					nBar2.MultiBarMode = MultiBarMode.StackedPercent
					nBar3.MultiBarMode = MultiBarMode.StackedPercent

					scaleY.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.Percentage)
			End Select

			Dim shape As BarShape = CType(BarShapeDropDownList.SelectedIndex, BarShape)
			nBar1.BarShape = shape
			nBar2.BarShape = shape
			nBar3.BarShape = shape

			Dim bEnable As Boolean = (shape.Equals(BarShape.SmoothEdgeBar)) OrElse (shape.Equals(BarShape.CutEdgeBar))

			Dim arrControls As ArrayList = New ArrayList()
			arrControls.Add(FirstHasTopEdgeCheckBox)
			arrControls.Add(FirstHasBottomEdgeCheckBox)

			arrControls.Add(SecondHasTopEdgeCheckBox)
			arrControls.Add(SecondHasBottomEdgeCheckBox)

			arrControls.Add(ThirdHasTopEdgeCheckBox)
			arrControls.Add(ThirdHasBottomEdgeCheckBox)

			For Each check As CheckBox In arrControls
				check.Enabled = bEnable
			Next check

			If bEnable Then
				nBar1.HasTopEdge = FirstHasTopEdgeCheckBox.Checked
				nBar1.HasBottomEdge = FirstHasBottomEdgeCheckBox.Checked
				nBar2.HasTopEdge = SecondHasTopEdgeCheckBox.Checked
				nBar2.HasBottomEdge = SecondHasBottomEdgeCheckBox.Checked
				nBar3.HasTopEdge = ThirdHasTopEdgeCheckBox.Checked
				nBar3.HasBottomEdge = ThirdHasBottomEdgeCheckBox.Checked
			End If

			If PositiveDataCheckBox.Checked Then
				GeneratePositiveData()
			Else
				GeneratePositiveAndNegativeData()
			End If

			AddHandler PositiveDataButton.Click, AddressOf PositiveDataButton_Click
			AddHandler PositivAndNegativeDataButton.Click, AddressOf PositiveAndNegativeDataButton_Click
		End Sub

		Private Sub PositiveDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			GeneratePositiveData()
			PositiveDataCheckBox.Checked = False
		End Sub

		Private Sub PositiveAndNegativeDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			GeneratePositiveAndNegativeData()
			PositiveDataCheckBox.Checked = True
		End Sub

		Private Sub GeneratePositiveData()
			nBar1.Values.FillRandomRange(Random, 5, 20, 100)
			nBar2.Values.FillRandomRange(Random, 5, 20, 100)
			nBar3.Values.FillRandomRange(Random, 5, 20, 100)
		End Sub

		Private Sub GeneratePositiveAndNegativeData()
			nBar1.Values.FillRandomRange(Random, 5, -100, 100)
			nBar2.Values.FillRandomRange(Random, 5, -100, 100)
			nBar3.Values.FillRandomRange(Random, 5, -100, 100)
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
