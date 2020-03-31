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
	Public Partial Class NStandardSmoothLineUC
		Inherits NExampleUC
		Protected Label1 As System.Web.UI.WebControls.Label
		Protected LineStyleDropDownList As System.Web.UI.WebControls.DropDownList
		Private Const nValuesCount As Integer = 8

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(PointShape))
				MarkerShapeDropDownList.SelectedIndex = 7

				WebExamplesUtilities.FillComboWithValues(LineWidthDropDownList, 0, 5, 1)
				LineWidthDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithColorNames(LineColorDropDownList, KnownColor.Orange)

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1)
				MarkerSizeDropDownList.SelectedIndex = 2

				ShowMarkersCheckBox.Checked = True
				LeftAxisRoundToTickCheckBox.Checked = True
				InflateMarginsCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Smooth Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScaleConfigurator.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked
			linearScaleConfigurator.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' add the line
			Dim line As NSmoothLineSeries = CType(chart.Series.Add(SeriesType.SmoothLine), NSmoothLineSeries)
			line.Name = "Smooth Line"
			line.UseXValues = False
			line.UseZValues = False
			line.InflateMargins = InflateMarginsCheckBox.Checked
			line.DataLabelStyle.Visible = False
			line.MarkerStyle.Visible = ShowMarkersCheckBox.Checked
			line.MarkerStyle.AutoDepth = False
			line.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
			line.MarkerStyle.Height = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Width = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Depth = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
			line.MarkerStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList)
			line.MarkerStyle.FillStyle = New NColorFillStyle(Red)
			line.BorderStyle.Width = New NLength(LineWidthDropDownList.SelectedIndex, NGraphicsUnit.Pixel)
			line.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList)

			If ShowMarkersCheckBox.Checked Then
				MarkerSizeDropDownList.Enabled = True
				MarkerShapeDropDownList.Enabled = True
			Else
				MarkerSizeDropDownList.Enabled = False
				MarkerShapeDropDownList.Enabled = False
			End If

			GenreateYValues(nValuesCount)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub

		Private Sub GenreateYValues(ByVal nCount As Integer)
			Dim chart As NChart = nChartControl1.Charts(0)
			Dim series As NSeries = CType(chart.Series(0), NSeries)

			series.Values.Clear()

			Dim i As Integer = 0
			Do While i < nCount
				series.Values.Add(Random.NextDouble() * 20)
				i += 1
			Loop
		End Sub
	End Class
End Namespace
