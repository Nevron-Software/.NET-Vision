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
	Public Partial Class NFindingUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' set a chart title
			If (Not IsPostBack) Then
				SearchForDropDownList.Items.Add("Max value")
				SearchForDropDownList.Items.Add("Min value")
				SearchForDropDownList.Items.Add("Custom value")
				SearchForDropDownList.Items.Add("Custom string")
				SearchForDropDownList.SelectedIndex = 0

				CustomValueTextBox.Text = "20"
				CustomStringTextBox.Text = "Bar 5"
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' add header
			Dim header As NLabel = nChartControl1.Labels.AddHeader("Finding Data")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			header.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(60, 90, 108))
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure the chart
			Dim nChart As NChart = nChartControl1.Charts(0)
			nChart.BoundsMode = BoundsMode.Stretch
			nChart.Axis(StandardAxis.Depth).Visible = False
			nChart.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			nChart.Size = New NSizeL(New NLength(85, NRelativeUnit.ParentPercentage), New NLength(75, NRelativeUnit.ParentPercentage))

			Dim nBar As NBarSeries = CType(nChart.Series.Add(SeriesType.Bar), NBarSeries)
			nBar.DataLabelStyle.Format = "<label>"

			nBar.Values.Add(10)
			nBar.Values.Add(20)
			nBar.Values.Add(15)
			nBar.Values.Add(44)
			nBar.Values.Add(87)
			nBar.Values.Add(33)
			nBar.Values.Add(56)

			For i As Integer = 0 To 6
				nBar.Labels.Add("Bar " & (i+1))
			Next i

			FindAndHighlightDataPoints(nBar)

			' configure the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.Mode = LegendMode.Manual
			legend.Data.ExpandMode = LegendExpandMode.ColsOnly

			Dim item As NLegendItemCellData = New NLegendItemCellData("Found Data Point", LegendMarkShape.Rectangle, New NStrokeStyle(1, Color.Black), New NColorFillStyle(Color.Red), New NShadowStyle(), New NTextStyle())
			legend.Data.Items.Add(item)

			item = New NLegendItemCellData("Series Data Points", LegendMarkShape.Rectangle, New NStrokeStyle(1, Color.Black), CType(nBar.FillStyle.Clone(), NFillStyle), New NShadowStyle(), New NTextStyle())
			legend.Data.Items.Add(item)
		End Sub

		Private Sub DisplayString(ByVal sMessage As String)
			Dim label As NLabel = nChartControl1.Labels.AddHeader(sMessage)
			label.Location = New NPointL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(90, NRelativeUnit.ParentPercentage))
			label.TextStyle.FontStyle = New NFontStyle("Arial", 9)
			label.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			label.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top
			label.TextStyle.FillStyle = New NColorFillStyle(Color.Red)
			label.TextStyle.BackplaneStyle.Visible = False
		End Sub

		Private Sub FindAndHighlightDataPoints(ByVal bar As NSeries)
			Select Case SearchForDropDownList.SelectedIndex
				Case 0
					Dim index As Integer = bar.Values.FindMaxValue()
					bar.FillStyles(index) = New NColorFillStyle(Color.Red)
					Exit Select

				Case 1
					Dim index As Integer = bar.Values.FindMinValue()
					bar.FillStyles(index) = New NColorFillStyle(Color.Red)
					Exit Select

				Case 2
					Try
						Dim dValue As Double = Double.Parse(CustomValueTextBox.Text)

						Dim index As Integer = bar.Values.FindValue(dValue)
						If index = -1 Then
							DisplayString("The specified value was not found " & Constants.vbLf & " in the bar Values series")
						Else
							bar.FillStyles(index) = New NColorFillStyle(Color.Red)
						End If
					Catch
					End Try

					Exit Select

				Case 3
					Dim index As Integer = bar.Labels.FindString(CustomStringTextBox.Text)
					If index = -1 Then
						DisplayString("The specified string was not found " & Constants.vbLf & " in the bar Labels series")
					Else
						bar.FillStyles(index) = New NColorFillStyle(Color.Red)
					End If

					Exit Select
			End Select
		End Sub
	End Class
End Namespace
