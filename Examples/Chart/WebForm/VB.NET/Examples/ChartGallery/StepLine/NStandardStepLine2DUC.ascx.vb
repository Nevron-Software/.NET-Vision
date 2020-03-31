Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NStandardStepLine2DUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If (Not IsPostBack) Then
				RoundToTickCheck.Checked = True
				InflateMarginsCheck.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Step Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.BoundsMode = BoundsMode.Stretch

			' setup axes
			Dim scaleY As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.RoundToTickMin = RoundToTickCheck.Checked
			scaleY.RoundToTickMax = RoundToTickCheck.Checked

			' add interlaced stripe
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back }
			scaleY.StripStyles.Add(stripStyle)

			' add a step line series
			Dim stepLine As NStepLineSeries = CType(chart.Series.Add(SeriesType.StepLine), NStepLineSeries)
			stepLine.Name = "Series 1"
			stepLine.Legend.Mode = SeriesLegendMode.None
			stepLine.DataLabelStyle.VertAlign = VertAlign.Center
			stepLine.DataLabelStyle.Visible = False
			stepLine.MarkerStyle.Visible = True
			stepLine.MarkerStyle.PointShape = PointShape.Cylinder
			stepLine.MarkerStyle.Width = New NLength(1.2f, NRelativeUnit.ParentPercentage)
			stepLine.MarkerStyle.Height = New NLength(1.2f, NRelativeUnit.ParentPercentage)
			stepLine.ShadowStyle.Type = ShadowType.GaussianBlur
			stepLine.ShadowStyle.Offset = New NPointL(3, 3)
			stepLine.ShadowStyle.FadeLength = New NLength(5)
			stepLine.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0)
			stepLine.InflateMargins = InflateMarginsCheck.Checked

			' fill some random data
			Dim random As Random = New Random()
			stepLine.Values.FillRandom(random, 8)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ApplyLayoutTemplate(0, nChartControl1, chart, title, Nothing)
		End Sub
	End Class
End Namespace
