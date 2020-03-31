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
	Public Partial Class NMarkersUC
		Inherits NExampleUC
		Protected MarkerStyleDropDown As System.Web.UI.WebControls.DropDownList
		Protected Marker3StyleDropDown As System.Web.UI.WebControls.DropDownList

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(MarkerShapeDropDown, GetType(PointShape))
				MarkerShapeDropDown.SelectedIndex = 0

				WebExamplesUtilities.FillComboWithEnumValues(Marker3ShapeDropDown, GetType(PointShape))
				Marker3ShapeDropDown.SelectedIndex = 1

				WebExamplesUtilities.FillComboWithValues(WidthDropDownList, 0, 5, 1)
				WebExamplesUtilities.FillComboWithValues(HeightDropDownList, 0, 5, 1)
				WebExamplesUtilities.FillComboWithPercents(DepthDropDownList, 10)
				WebExamplesUtilities.FillComboWithPercents(LineDepthDropDownList, 10)
				WebExamplesUtilities.FillComboWithColorNames(MarkerColorDropDown, KnownColor.Tan)
				WebExamplesUtilities.FillComboWithColorNames(Marker3ColorDropDown, KnownColor.Salmon)

				LineDepthDropDownList.SelectedIndex = 3
				WidthDropDownList.SelectedIndex = 2
				HeightDropDownList.SelectedIndex = 2
				AutoDepthCheckBox.Checked = True
				MarkersVisibleCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Series Markers")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlaced stripe
			Dim linearScaleConfigurator As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScaleConfigurator.StripStyles.Add(stripStyle)

			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.InflateMargins = True
			line.Legend.Mode = SeriesLegendMode.DataPoints
			line.LineSegmentShape = LineSegmentShape.Line
			line.Values.FillRandom(Random, 5)
			line.DataLabelStyle.Visible = False
			line.FillStyle = New NColorFillStyle(Color.DarkGray)
			line.BorderStyle.Color = Color.DarkGray

			DepthDropDownList.Enabled = Not AutoDepthCheckBox.Checked
			line.MarkerStyle.AutoDepth = AutoDepthCheckBox.Checked

			If AutoDepthCheckBox.Checked Then
				line.MarkerStyle.Depth = New NLength(CSng(DepthDropDownList.SelectedIndex * 10), NRelativeUnit.ParentPercentage)
			End If

			line.DepthPercent = LineDepthDropDownList.SelectedIndex * 10
			line.MarkerStyle.Height = New NLength(CSng(HeightDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Width = New NLength(CSng(WidthDropDownList.SelectedIndex), NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Visible = MarkersVisibleCheckBox.Checked
			line.MarkerStyle.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(MarkerColorDropDown))
			line.MarkerStyle.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(MarkerColorDropDown)
			line.MarkerStyle.PointShape = CType(MarkerShapeDropDown.SelectedIndex, PointShape)

			Dim marker As NMarkerStyle = New NMarkerStyle()
			marker.Visible = True
			marker.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(Marker3ColorDropDown))
			marker.BorderStyle.Color = WebExamplesUtilities.ColorFromDropDownList(Marker3ColorDropDown)
			marker.PointShape = CType(Marker3ShapeDropDown.SelectedIndex, PointShape)
			line.MarkerStyles(3) = marker

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
