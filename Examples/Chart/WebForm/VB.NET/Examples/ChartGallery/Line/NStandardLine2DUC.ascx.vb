Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStandardLine2DUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' fill the combo
				LineStyleDropDownList.Items.Add("Line")
				LineStyleDropDownList.Items.Add("Tape")
				LineStyleDropDownList.Items.Add("Tube")
				LineStyleDropDownList.Items.Add("Ellipsoid")
				LineStyleDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(PointShape))
				MarkerShapeDropDownList.SelectedIndex = 7

				WebExamplesUtilities.FillComboWithValues(LineWidthDropDownList, 0, 5, 1)
				LineWidthDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithColorNames(LineColorDropDownList)
				LineColorDropDownList.SelectedIndex = 34

				WebExamplesUtilities.FillComboWithColorNames(LineFillColorDropDownList)
				LineFillColorDropDownList.SelectedIndex = 72

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1)
				MarkerSizeDropDownList.SelectedIndex = 2

				ShowMarkersCheckBox.Checked = True
				LeftAxisRoundToTickCheckBox.Checked = True
				InflateMarginsCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScaleConfigurator.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked
			linearScaleConfigurator.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup the line series
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Values.FillRandom(Random, 10)
			line.DataLabelStyle.Visible = False
			line.Legend.Mode = SeriesLegendMode.DataPoints

			line.BorderStyle.Width = New NLength(LineWidthDropDownList.SelectedIndex, NGraphicsUnit.Pixel)
			line.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList)
			line.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(LineFillColorDropDownList))

			line.InflateMargins = InflateMarginsCheckBox.Checked
			line.MarkerStyle.Visible = ShowMarkersCheckBox.Checked

			line.ShadowStyle.Type = ShadowType.GaussianBlur
			line.ShadowStyle.Offset = New NPointL(New NLength(3, NGraphicsUnit.Pixel), New NLength(3, NGraphicsUnit.Pixel))
			line.ShadowStyle.FadeLength = New NLength(5, NGraphicsUnit.Pixel)
			line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0)

			Dim bSimpleLine As Boolean = (LineStyleDropDownList.SelectedIndex = 0)

			Select Case LineStyleDropDownList.SelectedIndex
				Case 0 ' line
					line.LineSegmentShape = LineSegmentShape.Line

				Case 1 ' tape
					line.LineSegmentShape = LineSegmentShape.Tape

				Case 2 ' tube
					line.LineSegmentShape = LineSegmentShape.Tube

				Case 3 ' elipsoid
					line.LineSegmentShape = LineSegmentShape.Ellipsoid
			End Select

			LineFillColorDropDownList.Enabled = Not bSimpleLine

			MarkerShapeDropDownList.Enabled = ShowMarkersCheckBox.Checked
			MarkerSizeDropDownList.Enabled = ShowMarkersCheckBox.Checked

			If line.MarkerStyle.Visible Then
				line.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
				line.MarkerStyle.Height = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
				line.MarkerStyle.Width = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
				line.MarkerStyle.FillStyle = New NColorFillStyle(Red)
				line.MarkerStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList)
			End If

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
