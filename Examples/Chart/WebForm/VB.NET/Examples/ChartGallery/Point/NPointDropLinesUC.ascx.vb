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
	Public Partial Class NPointDropLines2DUC
		Inherits NExampleUC
		Protected InflateMarginsCheckBoxBox As CheckBox
		Protected LeftAxisLeftAxisRoundToTickCheckBoxBox As CheckBox
		Protected DifferentColorsCheckBoxBox As CheckBox
		Protected ShowDataLabelsCheckBoxCheckBox As CheckBox

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Point Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = Enable3DCheckBox.Checked
			chart.BoundsMode = BoundsMode.Stretch

			' add interlace stripe
			Dim yScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			yScale.StripStyles.Add(stripStyle)

			' hide the depth axis
			chart.Axis(StandardAxis.Depth).Visible = False

			' setup point series
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point Series"
			point.DataLabelStyle.Visible = False
			point.InflateMargins = True

			point.AddDataPoint(New NDataPoint(23, "A"))
			point.AddDataPoint(New NDataPoint(67, "B"))
			point.AddDataPoint(New NDataPoint(47, "C"))
			point.AddDataPoint(New NDataPoint(12, "D"))
			point.AddDataPoint(New NDataPoint(56, "E"))
			point.AddDataPoint(New NDataPoint(78, "F"))

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)

			point.ShowVerticalDropLines = ShowVerticalDropLinesCheckBox.Checked
			point.ShowHorizontalDropLines = ShowHorizontalDropLinesCheckBox.Checked
		End Sub
	End Class
End Namespace