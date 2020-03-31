Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStandardArea2DUC
		Inherits NExampleUC
		Protected StandardArea As System.Web.UI.HtmlControls.HtmlForm

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(PointShape))
				MarkerShapeDropDownList.SelectedIndex = 7

				WebExamplesUtilities.FillComboWithColorNames(AreaColorDropDownList, KnownColor.DarkOrange)

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1)
				MarkerSizeDropDownList.SelectedIndex = 2

				ShowDataLabelsCheckBox.Checked = False
				UseOriginCheckBox.Checked = True
				ShowMarkersCheckBox.Checked = False
				OriginTextBox.Text = "0"
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.InnerMajorTickStyle.Visible = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			Dim i As Integer = 0
			Do While i < monthLetters.Length
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, monthLetters(i)))
				i += 1
			Loop

			' add interlaced stripe for Y axis
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }

			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.StripStyles.Add(stripStyle)

			' setup area series
			Dim area As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area.Name = "Area Series"
			area.Legend.Mode = SeriesLegendMode.DataPoints
			area.Legend.TextStyle.FontStyle.EmSize = New NLength(8, NGraphicsUnit.Point)
			area.DropLines = DropLinesCheckBox.Checked
			area.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromString(AreaColorDropDownList.SelectedItem.Text))
			area.MarkerStyle.Visible = ShowMarkersCheckBox.Checked
			area.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
			area.MarkerStyle.Height = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex),NRelativeUnit.ParentPercentage)
			area.MarkerStyle.Width = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex),NRelativeUnit.ParentPercentage)
			area.ShadowStyle.Type = ShadowType.GaussianBlur
			area.ShadowStyle.Offset = New NPointL(3, 0)
			area.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0)

			area.Values.AddRange(monthValues)

			area.DataLabelStyle.Visible = ShowDataLabelsCheckBox.Checked
			area.DataLabelStyle.Format = "<value>"

			If UseOriginCheckBox.Checked = True Then
				OriginTextBox.Enabled = True
				area.OriginMode = SeriesOriginMode.CustomOrigin

				Try
					area.Origin = Int32.Parse(OriginTextBox.Text)
				Catch
				End Try
			Else
				OriginTextBox.Enabled = False
				area.OriginMode = SeriesOriginMode.MinValue
			End If

			MarkerShapeDropDownList.Enabled = ShowMarkersCheckBox.Checked
			MarkerSizeDropDownList.Enabled = ShowMarkersCheckBox.Checked

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
