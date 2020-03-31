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
Imports Nevron.SmartShapes

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NMarkersUC
		Inherits NExampleUC
		Protected MarkerStyleDropDown As System.Web.UI.WebControls.DropDownList
		Protected Marker3StyleDropDown As System.Web.UI.WebControls.DropDownList

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Settings.JitterMode = JitterMode.Enabled

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Series Markers")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' add interlaced stripe to the Y axis
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			chart.Axis(StandardAxis.Depth).Visible = False

			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.LineSegmentShape = LineSegmentShape.Tape
			line.InflateMargins = True
			line.DepthPercent = 50
			line.Legend.Mode = SeriesLegendMode.DataPoints
			line.Name = "Line Series"
			line.Values.FillRandom(Random, 6)
			line.DataLabelStyle.Visible = False
			line.ShadowStyle.Type = ShadowType.GaussianBlur
			line.ShadowStyle.Offset = New NPointL(2, 2)
			line.ShadowStyle.Color = Color.FromArgb(88, 0, 0, 0)
			line.ShadowStyle.FadeLength = New NLength(5)
			line.MarkerStyle.Visible = True

			Dim marker As NMarkerStyle = New NMarkerStyle()
			marker.FillStyle = New NColorFillStyle(Color.Red)
			marker.PointShape = PointShape.Custom

			' Create a custom shape for this marker
			Dim factory As N2DSmartShapeFactory = New N2DSmartShapeFactory(New NColorFillStyle(Color.Red), New NStrokeStyle(1.0f, Color.Black), Nothing)
			marker.CustomShape = factory.CreateShape(SmartShape2D.Trapezoid)
			marker.Visible = True
			line.MarkerStyles(3) = marker

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, nChartControl1.Legends(0))
		End Sub
	End Class
End Namespace
