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
	Public Partial Class NLegendPositionUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithPercents(HorizontalMarginDropDownList, 10)
				HorizontalMarginDropDownList.SelectedIndex = 0

				ContentAlignmentDropDownList.Items.Add("BottomCenter")
				ContentAlignmentDropDownList.Items.Add("BottomLeft")
				ContentAlignmentDropDownList.Items.Add("BottomRight")
				ContentAlignmentDropDownList.Items.Add("MiddleCenter")
				ContentAlignmentDropDownList.Items.Add("MiddleLeft")
				ContentAlignmentDropDownList.Items.Add("MiddleRight")
				ContentAlignmentDropDownList.Items.Add("TopCenter")
				ContentAlignmentDropDownList.Items.Add("TopLeft")
				ContentAlignmentDropDownList.Items.Add("TopRight")
				ContentAlignmentDropDownList.SelectedIndex = 2

				WebExamplesUtilities.FillComboWithPercents(VerticalMarginDropDownList, 10)
				VerticalMarginDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithFontNames(DataFontDropDownList, "Arial")
				WebExamplesUtilities.FillComboWithValues(DataFontSizeDropDownList, 9, 30, 1)

				HasShadowCheckBox.Checked = True
				ShowLegendGridCheckBox.Checked = True

				WebExamplesUtilities.FillComboWithPercents(BackplaneTransparencyDropDownList, 10)
				BackplaneTransparencyDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add panels
			nChartControl1.Panels.Clear()

			Dim title As NLabel = New NLabel("Legend Position")
			nChartControl1.Panels.Add(title)

			Dim chart As NPieChart = New NPieChart()
			nChartControl1.Panels.Add(chart)

			Dim legend As NLegend = New NLegend()
			nChartControl1.Panels.Add(legend)

			' setup the chart title
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the legend
			If HasShadowCheckBox.Checked Then
				legend.ShadowStyle.Type = ShadowType.GaussianBlur
			Else
				legend.ShadowStyle.Type = ShadowType.None
			End If
			legend.ShadowStyle.Offset = New NPointL(2, 2)
			legend.ShadowStyle.Color = Color.FromArgb(64, 64, 64, 64)
			legend.FillStyle = New NColorFillStyle(Color.FromArgb(255 - CInt(Fix(BackplaneTransparencyDropDownList.SelectedIndex * 255 / 10.0f)), 255, 255, 255))
			legend.ContentAlignment = CType(System.Enum.Parse(GetType(ContentAlignment), ContentAlignmentDropDownList.SelectedItem.Text), ContentAlignment)
			legend.Location = New NPointL(New NLength(HorizontalMarginDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage), New NLength(VerticalMarginDropDownList.SelectedIndex * 10, NRelativeUnit.ParentPercentage))

			If ShowLegendGridCheckBox.Checked = True Then
				legend.HorizontalBorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)
				legend.VerticalBorderStyle.Width = New NLength(1, NGraphicsUnit.Pixel)
			Else
				legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			End If

			' setup the pie chart
			chart.DisplayOnLegend = legend
			chart.BoundsMode = BoundsMode.Fit
			chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))

			Dim pie As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pie.DataLabelStyle.Visible = False
			pie.Legend.Mode = SeriesLegendMode.DataPoints
			pie.Legend.Format = "<label> <percent>"
			pie.Legend.TextStyle.FontStyle.Name = DataFontDropDownList.SelectedItem.Text
			pie.Legend.TextStyle.FontStyle.EmSize = New NLength(DataFontSizeDropDownList.SelectedIndex + 9, NGraphicsUnit.Point)

			For i As Integer = 0 To 5
				pie.Values.Add(10 + Random.NextDouble() * 30)
				pie.Labels.Add("Item " & i.ToString())
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.PaleMultiColor)
			styleSheet.Apply(chart)
		End Sub
	End Class
End Namespace
