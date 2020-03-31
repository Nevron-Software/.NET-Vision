Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.UI

Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NPrintingUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			nChartControl1.StateManager = New NChartBatonSessionStateManager(Context, "Nevron.Examples.Chart.WebForm.NPrintingUC")
			nChartControl1.BackgroundStyle.FrameStyle.Visible = False

			If nChartControl1.RequiresInitialization Then
				' enable jittering (full scene antialiasing)
				nChartControl1.Settings.JitterMode = JitterMode.Enabled

				' set a chart title
				Dim title As NLabel = nChartControl1.Labels.AddHeader("Welcome to Nevron Chart for .NET")
				title.TextStyle.BackplaneStyle.Visible = False
				title.TextStyle.FillStyle = New NColorFillStyle(Color.Navy)
				title.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur
				title.ContentAlignment = ContentAlignment.BottomRight
				title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

				' setup the legend
				Dim legend As NLegend = nChartControl1.Legends(0)
				legend.FillStyle.SetTransparencyPercent(50)
				legend.OuterBottomBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.OuterLeftBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.OuterRightBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.OuterTopBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.HorizontalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
				legend.VerticalBorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

				' setup the chart
				Dim chart As NChart = nChartControl1.Charts(0)
				chart.Enable3D = True
				chart.Axis(StandardAxis.Depth).Visible = False
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
				chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
				chart.BoundsMode = BoundsMode.Stretch
				chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(17, NRelativeUnit.ParentPercentage))
				chart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(73, NRelativeUnit.ParentPercentage))

				' add a bar series
				Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
				bar.Name = "Simple Bar Chart"
				bar.BarShape = BarShape.SmoothEdgeBar
				bar.Legend.Mode = SeriesLegendMode.DataPoints
				bar.DataLabelStyle.Format = "<value> <label>"

				bar.AddDataPoint(New NDataPoint(16, "Agriculture"))
				bar.AddDataPoint(New NDataPoint(42, "Construction"))
				bar.AddDataPoint(New NDataPoint(56, "Manufacturing"))
				bar.AddDataPoint(New NDataPoint(23, "Services"))
				bar.AddDataPoint(New NDataPoint(47, "Healthcare"))
				bar.AddDataPoint(New NDataPoint(38, "Finance"))

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor)
				styleSheet.Apply(nChartControl1.Document)
			End If
		End Sub
	End Class
End Namespace

