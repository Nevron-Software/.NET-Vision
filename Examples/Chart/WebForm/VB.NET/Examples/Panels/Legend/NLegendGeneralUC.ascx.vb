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
	Public Partial Class NLegendGeneralUC
		Inherits NExampleUC
		Protected m_Legend As NLegend
		Private Const numberOfDataPoints As Integer = 5

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				LegendModeDropDownList.Items.Add("Disabled")
				LegendModeDropDownList.Items.Add("Automatic")
				LegendModeDropDownList.Items.Add("Manual")
				LegendModeDropDownList.SelectedIndex = 1

				PredefinedStyleDropDownList.Items.Add("Top")
				PredefinedStyleDropDownList.Items.Add("Bottom")
				PredefinedStyleDropDownList.Items.Add("Left")
				PredefinedStyleDropDownList.Items.Add("Right")
				PredefinedStyleDropDownList.Items.Add("Top right")
				PredefinedStyleDropDownList.Items.Add("Top left")
				PredefinedStyleDropDownList.SelectedIndex = 4

				ExpandModeDropDownList.Items.Add("Rows only")
				ExpandModeDropDownList.Items.Add("Cols only")
				ExpandModeDropDownList.Items.Add("Rows fixed")
				ExpandModeDropDownList.Items.Add("Cols fixed")
				ExpandModeDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(ManualItemsDropDownList, 1, 20, 1)
				ManualItemsDropDownList.SelectedIndex = 5

				WebExamplesUtilities.FillComboWithValues(RowCountDropDownList, 1, 10, 1)
				RowCountDropDownList.SelectedIndex = 5

				WebExamplesUtilities.FillComboWithValues(ColCountDropDownList, 1, 10, 1)
				ColCountDropDownList.SelectedIndex = 5
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled
			nChartControl1.Settings.JitteringSteps = 4

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Legend General")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim barSeries As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			barSeries.DataLabelStyle.Visible = False
			barSeries.Legend.Mode = SeriesLegendMode.DataPoints
			barSeries.Legend.Format = "<label> <percent>"
			barSeries.Values.FillRandom(Random, numberOfDataPoints)

			For i As Integer = 0 To numberOfDataPoints - 1
				barSeries.Labels.Add("Item " & i.ToString())
			Next i

			' setup the legend
			m_Legend = nChartControl1.Legends(0)
			m_Legend.FillStyle.SetTransparencyPercent(50)
			m_Legend.Mode = (CType(LegendModeDropDownList.SelectedIndex, LegendMode))

			If m_Legend.Mode <> LegendMode.Manual Then
				ManualItemsDropDownList.Enabled = False
			Else
				Dim legendItemCellData As NLegendItemCellData
				ManualItemsDropDownList.Enabled = True

				' fill some manual legend data items.
				Dim manualItemCount As Integer = ManualItemsDropDownList.SelectedIndex + 1
				Dim i As Integer = 0
				Do While i < manualItemCount
					legendItemCellData = New NLegendItemCellData()

					legendItemCellData.Text = "Manual item " & i.ToString()
					legendItemCellData.MarkShape = LegendMarkShape.Rectangle

					Dim itemColor As Color = WebExamplesUtilities.RandomColor()

					legendItemCellData.MarkFillStyle = New NColorFillStyle(itemColor)

					m_Legend.Data.Items.Add(legendItemCellData)
					i += 1
				Loop
			End If

			m_Legend.Header.Text = LegendHeaderTextBox.Text
			m_Legend.Footer.Text = LegendFooterTextBox.Text

			m_Legend.SetPredefinedLegendStyle(CType(PredefinedStyleDropDownList.SelectedIndex, PredefinedLegendStyle))
			m_Legend.Data.ExpandMode = CType(ExpandModeDropDownList.SelectedIndex, LegendExpandMode)

			If m_Legend.Data.ExpandMode = LegendExpandMode.ColsOnly OrElse m_Legend.Data.ExpandMode = LegendExpandMode.RowsOnly Then
				RowCountDropDownList.Enabled = False
				ColCountDropDownList.Enabled = False
			ElseIf m_Legend.Data.ExpandMode = LegendExpandMode.RowsFixed Then
				RowCountDropDownList.Enabled = True
				ColCountDropDownList.Enabled = False

				m_Legend.Data.RowCount = RowCountDropDownList.SelectedIndex + 1
			ElseIf m_Legend.Data.ExpandMode = LegendExpandMode.ColsFixed Then
				RowCountDropDownList.Enabled = False
				ColCountDropDownList.Enabled = True

				m_Legend.Data.ColCount = ColCountDropDownList.SelectedIndex + 1
			End If

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Protected Sub PredefinedStyleDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			m_Legend.SetPredefinedLegendStyle(CType(PredefinedStyleDropDownList.SelectedIndex, PredefinedLegendStyle))

			ExpandModeDropDownList.SelectedIndex = CInt(Fix(m_Legend.Data.ExpandMode))

			RowCountDropDownList.Enabled = False
			ColCountDropDownList.Enabled = False
		End Sub
	End Class
End Namespace
