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
	Public Partial Class NStandardLineUC
		Inherits NExampleUC
		'protected NChart nChart;
		'protected NLineSeries nLine;

		Protected LightsCheckBoxBox As CheckBox
		Protected InflateMarginsCheckBoxBox As CheckBox
		Protected LeftAxisRoundToTickCheckBoxBox As CheckBox
		Protected ShowMarkersCheckBoxBox As CheckBox

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				' fill the combo
				LineStyleDropDownList.Items.Add("Line")
				LineStyleDropDownList.Items.Add("Tape")
				LineStyleDropDownList.Items.Add("Tube")
				LineStyleDropDownList.Items.Add("Ellipsoid")
				LineStyleDropDownList.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDownList, GetType(PointShape))
				MarkerShapeDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithPercents(LineDepthDropDownList, 10)
				LineDepthDropDownList.SelectedIndex = 4

				WebExamplesUtilities.FillComboWithValues(LineWidthDropDownList, 0, 5, 1)
				LineWidthDropDownList.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithColorNames(LineColorDropDownList, KnownColor.DarkSalmon)
				WebExamplesUtilities.FillComboWithColorNames(LineFillColorDropDownList, KnownColor.LightSalmon)

				WebExamplesUtilities.FillComboWithValues(MarkerSizeDropDownList, 0, 10, 1)
				MarkerSizeDropDownList.SelectedIndex = 2

				ShowMarkersCheckBox.Checked = True
				LeftAxisRoundToTickCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective2)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup Y axis
			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.RoundToTickMin = LeftAxisRoundToTickCheckBox.Checked
			scaleY.RoundToTickMax = LeftAxisRoundToTickCheckBox.Checked

			' add Y axis interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY.StripStyles.Add(stripStyle)

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False

			' setup the line series
			Dim nLine As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			nLine.Values.FillRandom(Random, 10)
			nLine.DataLabelStyle.Visible = False
			nLine.Legend.Mode = SeriesLegendMode.DataPoints

			nLine.BorderStyle.Width = New NLength(LineWidthDropDownList.SelectedIndex, NGraphicsUnit.Pixel)
			nLine.DepthPercent = LineDepthDropDownList.SelectedIndex * 10
			nLine.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList)
			nLine.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(LineFillColorDropDownList))

			nLine.InflateMargins = InflateMarginsCheckBox.Checked
			nLine.MarkerStyle.Visible = ShowMarkersCheckBox.Checked

			Dim bSimpleLine As Boolean = (LineStyleDropDownList.SelectedIndex = 0)

			Select Case LineStyleDropDownList.SelectedIndex
				Case 0 ' simple line
					nLine.LineSegmentShape = LineSegmentShape.Line

				Case 1 ' tape
					nLine.LineSegmentShape = LineSegmentShape.Tape

				Case 2 ' tube
					nLine.LineSegmentShape = LineSegmentShape.Tube

				Case 3 ' elipsoid
					nLine.LineSegmentShape = LineSegmentShape.Ellipsoid
			End Select

			LineDepthDropDownList.Enabled = Not bSimpleLine
			LineFillColorDropDownList.Enabled = Not bSimpleLine

			MarkerShapeDropDownList.Enabled = ShowMarkersCheckBox.Checked
			MarkerSizeDropDownList.Enabled = ShowMarkersCheckBox.Checked

			If nLine.MarkerStyle.Visible Then
				nLine.MarkerStyle.PointShape = CType(MarkerShapeDropDownList.SelectedIndex, PointShape)
				nLine.MarkerStyle.Height = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
				nLine.MarkerStyle.Width = New NLength(CSng(MarkerSizeDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
				nLine.MarkerStyle.FillStyle = New NColorFillStyle(Red)
				nLine.MarkerStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(LineColorDropDownList)
			End If

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace