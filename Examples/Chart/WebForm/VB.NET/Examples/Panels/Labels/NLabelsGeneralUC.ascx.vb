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
	Public Partial Class NLabelsGeneralUC
		Inherits NExampleUC
		Protected HorizontalAlignDropDownList As DropDownList

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				LabelTextBox.Text = "Chart Title"

				WebExamplesUtilities.FillComboWithPercents(HorizontalMarginDropDownList, 10)
				HorizontalMarginDropDownList.SelectedIndex = 5

				WebExamplesUtilities.FillComboWithPercents(VerticalMarginDropDownList, 10)
				VerticalMarginDropDownList.SelectedIndex = 1

				ContentAlignmentDropDownList.Items.Add("BottomCenter")
				ContentAlignmentDropDownList.Items.Add("BottomLeft")
				ContentAlignmentDropDownList.Items.Add("BottomRight")
				ContentAlignmentDropDownList.Items.Add("MiddleCenter")
				ContentAlignmentDropDownList.Items.Add("MiddleLeft")
				ContentAlignmentDropDownList.Items.Add("MiddleRight")
				ContentAlignmentDropDownList.Items.Add("TopCenter")
				ContentAlignmentDropDownList.Items.Add("TopLeft")
				ContentAlignmentDropDownList.Items.Add("TopRight")
				ContentAlignmentDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithFontNames(FontDropDownList, "Arial")
				WebExamplesUtilities.FillComboWithValues(FontSizeDropDownList, 8, 52, 1)
				FontSizeDropDownList.SelectedIndex = 2

				WebExamplesUtilities.FillComboWithColorNames(FontColorDropDownList, KnownColor.Black)
				WebExamplesUtilities.FillComboWithValues(FontOrientationDropDownList, 0, 360, 10)

				HasBackplaneCheckBox.Checked = True

				BackplaneStyleDropDownList.Items.Add("Rectangle")
				BackplaneStyleDropDownList.Items.Add("Ellipse")
				BackplaneStyleDropDownList.Items.Add("Circle")
				BackplaneStyleDropDownList.Items.Add("Cut Edge Rectangle")
				BackplaneStyleDropDownList.Items.Add("Smooth Edge Rectangle")
				BackplaneStyleDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' setup the label
			Dim label As NLabel = New NLabel()
			nChartControl1.Panels.Add(label)
			label.Text = LabelTextBox.Text
			label.TextStyle.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(FontColorDropDownList))
			label.TextStyle.Orientation = FontOrientationDropDownList.SelectedIndex * 10
			label.TextStyle.BackplaneStyle.Visible = HasBackplaneCheckBox.Checked
			label.ContentAlignment = CType(System.Enum.Parse(GetType(ContentAlignment), ContentAlignmentDropDownList.SelectedItem.Text), ContentAlignment)
			label.Location = New NPointL(New NLength(HorizontalMarginDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage), New NLength(VerticalMarginDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage))

			Try
				label.TextStyle.FontStyle = New NFontStyle(FontDropDownList.SelectedItem.Text, FontSizeDropDownList.SelectedIndex + 8)

			Catch
			End Try

			BackplaneStyleDropDownList.Enabled = HasBackplaneCheckBox.Checked

			If HasBackplaneCheckBox.Checked Then
				label.TextStyle.BackplaneStyle.Shape = CType(BackplaneStyleDropDownList.SelectedIndex, BackplaneShape)
			End If

			' no legend
			nChartControl1.Legends.Clear()

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Fit
			chart.Axis(StandardAxis.PrimaryX).Visible = False
			chart.Axis(StandardAxis.PrimaryY).Visible = False
			chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))

			Dim series As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			series.DataLabelStyle.Visible = False
			series.Values.AddRange(New Double(){ 16, 42, 56, 23, 47, 38 })

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(series)
		End Sub
	End Class
End Namespace
