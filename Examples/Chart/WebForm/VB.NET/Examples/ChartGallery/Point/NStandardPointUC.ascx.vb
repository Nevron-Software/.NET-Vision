Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStandardPointUC
		Inherits NExampleUC
		Protected InflateMarginsCheckBoxBox As CheckBox
		Protected LeftAxisLeftAxisRoundToTickCheckBoxBox As CheckBox
		Protected DifferentColorsCheckBoxBox As CheckBox
		Protected ShowDataLabelsCheckBoxCheckBox As CheckBox

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(PointShapeDropDownList, GetType(PointShape))
				PointShapeDropDownList.SelectedIndex = 0

				DataLabelFormatDropDownList.Items.Add("Value and Label")
				DataLabelFormatDropDownList.Items.Add("Value")
				DataLabelFormatDropDownList.Items.Add("Label")
				DataLabelFormatDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithValues(PointSizeDropDownList, 0, 10, 1)
				PointSizeDropDownList.SelectedIndex = 4

				WebExamplesUtilities.FillComboWithColorNames(PointColorDropDownList, KnownColor.Orange)

				DifferentColorsCheckBox.Checked = True
				LeftAxisRoundToTickCheckBox.Checked = True
				ShowDataLabelsCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' setup Y axis
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked
			linearScaleConfigurator.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked

			' add interlace stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			' hide the depth axis
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup point series
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point Series"
			point.Legend.Format = "<label>"
			point.DataLabelStyle.TextStyle.FontStyle.EmSize = New NLength(7)
			point.PointShape = CType(PointShapeDropDownList.SelectedIndex, PointShape)
			point.Size = New NLength(CSng(PointSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
			point.InflateMargins = InflateMarginsCheckBox.Checked

			point.AddDataPoint(New NDataPoint(23, "A"))
			point.AddDataPoint(New NDataPoint(67, "B"))
			point.AddDataPoint(New NDataPoint(47, "C"))
			point.AddDataPoint(New NDataPoint(12, "D"))
			point.AddDataPoint(New NDataPoint(56, "E"))
			point.AddDataPoint(New NDataPoint(78, "F"))

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			If DifferentColorsCheckBox.Checked Then
				PointColorDropDownList.Enabled = False

				Dim palette As NChartPalette = New NChartPalette()
				palette.SetPredefinedPalette(ChartPredefinedPalette.Nevron)

				Dim i As Integer = 0
				Do While i < point.Values.Count
					point.FillStyles(i) = New NColorFillStyle(palette.SeriesColors(i Mod palette.SeriesColors.Count))
					i += 1
				Loop

				point.Legend.Mode = SeriesLegendMode.DataPoints
			Else
				PointColorDropDownList.Enabled = True
				point.FillStyles.Clear()
				point.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(PointColorDropDownList))
				point.Legend.Mode = SeriesLegendMode.Series
			End If

			If ShowDataLabelsCheckBox.Checked Then
				point.DataLabelStyle.Visible = True
				DataLabelFormatDropDownList.Enabled = True

				Select Case DataLabelFormatDropDownList.SelectedIndex
					Case 0
						point.DataLabelStyle.Format = "<value> <label>"

					Case 1
						point.DataLabelStyle.Format = "<value>"

					Case 2
						point.DataLabelStyle.Format = "<label>"
				End Select
			Else
				point.DataLabelStyle.Visible = False
				DataLabelFormatDropDownList.Enabled = False
			End If
		End Sub
	End Class
End Namespace