Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStackedLineUC
		Inherits NExampleUC

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' fill the data labels combos
				FirstLineLabelsDropDownList.Items.Add("Value")
				FirstLineLabelsDropDownList.Items.Add("Total")
				FirstLineLabelsDropDownList.Items.Add("Cumulative")
				FirstLineLabelsDropDownList.Items.Add("Percent")
				FirstLineLabelsDropDownList.SelectedIndex = 0

				SecondLineLabelsDropDownList.Items.Add("Value")
				SecondLineLabelsDropDownList.Items.Add("Total")
				SecondLineLabelsDropDownList.Items.Add("Cumulative")
				SecondLineLabelsDropDownList.Items.Add("Percent")
				SecondLineLabelsDropDownList.SelectedIndex = 0

				ThirdLineLabelsDropDownList.Items.Add("Value")
				ThirdLineLabelsDropDownList.Items.Add("Total")
				ThirdLineLabelsDropDownList.Items.Add("Cumulative")
				ThirdLineLabelsDropDownList.Items.Add("Percent")
				ThirdLineLabelsDropDownList.SelectedIndex = 0

				StackStyleDropDownList.Items.Add("Stacked")
				StackStyleDropDownList.Items.Add("Stacked %")
				StackStyleDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Stacked Line")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' modify the chart margins and fitting strategy
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' add interlace stripe
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' setup legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Data.MarkSize = New NSizeL(4, 10)
			legend.OuterBottomBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterLeftBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterRightBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.OuterTopBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.FillStyle = New NColorFillStyle(Color.FromArgb(127, 255, 255, 255))
			legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)



			' add the first line
			Dim line1 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line1.MultiLineMode = MultiLineMode.Series
			line1.Name = "Orange"
			line1.DataLabelStyle.ArrowLength = New NLength(0, NRelativeUnit.ParentPercentage)
			line1.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			line1.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			line1.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse
			line1.DataLabelStyle.TextStyle.BackplaneStyle.FillStyle = New NColorFillStyle(Color.OldLace)
			line1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.OuterBorderColor = Color.DarkOrange
			line1.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.DarkOrange
			line1.BorderStyle.Color = Color.DarkOrange
			line1.Values.ValueFormatter = New NNumericValueFormatter("0.#")

			' add the second line
			Dim line2 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line2.MultiLineMode = MultiLineMode.Stacked
			line2.Name = "Green"
			line2.DataLabelStyle.ArrowLength = New NLength(0, NRelativeUnit.ParentPercentage)
			line2.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			line2.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			line2.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse
			line2.DataLabelStyle.TextStyle.BackplaneStyle.FillStyle = New NColorFillStyle(Color.Honeydew)
			line2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.OuterBorderColor = Color.LimeGreen
			line2.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.LimeGreen
			line2.BorderStyle.Color = Color.LimeGreen
			line2.FillStyle = New NColorFillStyle(Color.LimeGreen)
			line2.Values.ValueFormatter = New NNumericValueFormatter("0.#")

			' add the third line
			Dim line3 As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line3.MultiLineMode = MultiLineMode.Stacked
			line3.Name = "Blue"
			line3.DataLabelStyle.ArrowLength = New NLength(0, NRelativeUnit.ParentPercentage)
			line3.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			line3.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			line3.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse
			line3.DataLabelStyle.TextStyle.BackplaneStyle.FillStyle = New NColorFillStyle(Color.Azure)
			line3.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.OuterBorderColor = Color.RoyalBlue
			line3.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.RoyalBlue
			line3.BorderStyle.Color = Color.RoyalBlue
			line3.FillStyle = New NColorFillStyle(Color.RoyalBlue)
			line3.Values.ValueFormatter = New NNumericValueFormatter("0.#")

			Select Case StackStyleDropDownList.SelectedIndex
				Case 0
					line2.MultiLineMode = MultiLineMode.Stacked
					line3.MultiLineMode = MultiLineMode.Stacked

					' fill with random data
					line1.Values.FillRandomRange(Random, 7, 10, 80)
					line2.Values.FillRandomRange(Random, 7, 10, 80)
					line3.Values.FillRandomRange(Random, 7, 10, 80)

				Case 1
					line2.MultiLineMode = MultiLineMode.StackedPercent
					line3.MultiLineMode = MultiLineMode.StackedPercent

					' fill with random data
					line1.Values.FillRandomRange(Random, 7, 0, 100)
					line2.Values.FillRandomRange(Random, 7, 0, 100)
					line3.Values.FillRandomRange(Random, 7, 0, 100)

					' set the left axis to show percents
					linearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
					linearScaleConfigurator.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 7)

					linearScaleConfigurator.LabelValueFormatter = New NNumericValueFormatter(NumericValueFormat.Percentage)
			End Select

			SetDataLabelFormat(line1, FirstLineLabelsDropDownList.SelectedIndex)
			SetDataLabelFormat(line2, SecondLineLabelsDropDownList.SelectedIndex)
			SetDataLabelFormat(line3, ThirdLineLabelsDropDownList.SelectedIndex)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub SetDataLabelFormat(ByVal line As NLineSeries, ByVal index As Integer)
			Select Case index
				Case 0
					line.DataLabelStyle.Format = "<value>"

				Case 1
					line.DataLabelStyle.Format = "<total>"

				Case 2
					line.DataLabelStyle.Format = "<cumulative>"

				Case 3
					line.DataLabelStyle.Format = "<percent>"
			End Select
		End Sub
	End Class
End Namespace