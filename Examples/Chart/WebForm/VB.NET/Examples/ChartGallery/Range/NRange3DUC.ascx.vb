Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NRange3DUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				WebExamplesUtilities.FillComboWithEnumValues(ShapeDropDownList, GetType(BarShape))
				ShapeDropDownList.SelectedIndex = 0
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = New NLabel("3D Range Series")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			chart.Projection.Type = ProjectionType.Perspective
			chart.Projection.Rotation = -18
			chart.Projection.Elevation = 13
			chart.Depth = 55.0f
			chart.Width = 55.0f
			chart.Height = 55.0f

			' setup X axis
			Dim linearScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			chart.Axis(StandardAxis.PrimaryX).View = New NRangeAxisView(New NRange1DD(0, 20), True, True)

			' setup Y axis
			linearScale = New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(0, 20), True, True)

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' setup Depth axis
			linearScale = New NLinearScaleConfigurator()
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			chart.Axis(StandardAxis.Depth).View = New NRangeAxisView(New NRange1DD(0, 20), True, True)

			' setup shape series
			Dim rangeSeries As NRangeSeries = CType(chart.Series.Add(SeriesType.Range), NRangeSeries)
			rangeSeries.FillStyle = New NColorFillStyle(Color.Red)
			rangeSeries.BorderStyle.Color = Color.DarkRed
			rangeSeries.Legend.Mode = SeriesLegendMode.None
			rangeSeries.DataLabelStyle.Visible = False
			rangeSeries.UseXValues = True
			rangeSeries.UseZValues = True
			rangeSeries.Shape = CType(ShapeDropDownList.SelectedIndex, BarShape)

			' add data
			AddDataPoint(rangeSeries, 1, 5, 11, 17, 5, 9)
			AddDataPoint(rangeSeries, 4, 7, 15, 19, 16, 19)
			AddDataPoint(rangeSeries, 5, 15, 6, 11, 12, 18)
			AddDataPoint(rangeSeries, 9, 14, 2, 5, 3, 5)
			AddDataPoint(rangeSeries, 15, 19, 2, 5, 3, 5)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub AddDataPoint(ByVal series As NRangeSeries, ByVal x1 As Double, ByVal x2 As Double, ByVal y1 As Double, ByVal y2 As Double, ByVal z1 As Double, ByVal z2 As Double)
			series.XValues.Add(x1)
			series.X2Values.Add(x2)
			series.Values.Add(y1)
			series.Y2Values.Add(y2)
			series.ZValues.Add(z1)
			series.Z2Values.Add(z2)
		End Sub

		Private Sub ShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
'			NRangeSeries rangeSeries = (NRangeSeries)nChartControl1.Charts[0].Series[0];
'			rangeSeries.Shape = (BarShape)ShapeCombo.SelectedIndex;
'			nChartControl1.Refresh();
		End Sub
	End Class
End Namespace